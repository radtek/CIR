//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2006 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Generic entity view base class, which provides the core class code for the EntityView class.
	/// EntityView provides 'view' capabilities for an entity collection. This class supports filtering and sorting in-memory,
	/// using type safe objects. Binding an entity collection to a grid or other complex databinding control will actually make the control
	/// bind to an instance of this class.
	/// </summary>
#if !CF
	[System.ComponentModel.DesignerCategory( "Code" )]
	[ListBindable(BindableSupport.Yes)]
#endif
	public abstract class EntityViewBase : MarshalByValueComponent, IBindingList, ITypedList, IEnumerable
	{
		#region Events
		/// <summary>
		/// Event which is fired when the entity collection related to this entityview is changed.
		/// </summary>
		public event ListChangedEventHandler ListChanged;
		#endregion

		#region enums
		/// <summary>
		/// Enum for usage with UpdateIndices.
		/// </summary>
		private enum ListAction
		{ 
			Insertion,
			Addition,
			Deletion
		}
		#endregion

		#region Class Member Declarations
		private IEntityViewSource		 _relatedCollection; 
		private bool _allowNew, _allowRemove, _allowEdit, _suspendChangeEvents;
		private ArrayList				_entityIndices;
		private IPredicate				_appliedFilter;
		private ISortExpression			_appliedSorter;
		private int						_indexAddNewResult;
		private	PostCollectionChangeAction	_dataChangeAction;
		#endregion

	
		/// <summary>
		/// Adds a new entity through databinding.
		/// </summary>
		/// <returns></returns>
		protected virtual IEntityCore AddNew()
		{
			if((this.Site!=null) && (!this.AllowNew ))
			{
				throw new InvalidOperationException( "Adding a new row isn't allowed in the current context as AllowNew is set to false." );
			}

			IEntityCore toReturn = null;
			try
			{
				_suspendChangeEvents = true;

				toReturn = (IEntityCore)_relatedCollection.AddNew();
				if( toReturn != null )
				{
					_indexAddNewResult = _relatedCollection.IndexOf( toReturn );
					_entityIndices.Add( _indexAddNewResult);
					OnListChanged( _entityIndices.Count-1, ListChangedType.ItemAdded );
				}
			}
			finally
			{
				_suspendChangeEvents = false;
			}

			return toReturn;
		}


		/// <summary>
		/// Removes the specified entity from the related collection, if the entity is in the view.
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		protected virtual void Remove( IEntityCore toRemove )
		{
			if( !this.AllowRemove )
			{
				throw new InvalidOperationException( "Removing a row isn't allowed in the current context as AllowRemove is set to false." );
			}

			int index = _relatedCollection.IndexOf( toRemove );
			if( (index < 0) || (!_entityIndices.Contains( index )) )
			{
				// not in this view, ignore
				return;
			}

			this.RemoveAt( this.IndexOf( toRemove ) );
		}


		/// <summary>
		/// Removes the item at the specified index in this view from the related collection 
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
		protected virtual void RemoveAt( int index )
		{
			if( !this.AllowRemove )
			{
				throw new InvalidOperationException( "Removing a row isn't allowed in the current context as AllowRemove is set to false." );
			}

			if( (index < 0) || (index >= this.Count) )
			{
#if CF
				throw new ArgumentOutOfRangeException( "The index specified is outside the view's set of entities" );
#else
				throw new ArgumentOutOfRangeException( "index", index, "The index specified is outside the view's set of entities" );
#endif
			}

			if( _indexAddNewResult == index )
			{
				_indexAddNewResult = -1;
			}

			try
			{
				int indexInCollection = (int)_entityIndices[index];
				_relatedCollection.RemoveAt( indexInCollection );

				// the remove action of the collection will come back as a ListChanged event to this view, and will be handled in the 
				// _relatedCollectionListChanged method. There, the housekeeping is done. It's done this way because the collection raises
				// events as well, which can make external code re-read the view (in databinding scenario's) which then will fail. 
			}
			finally
			{
				_suspendChangeEvents = false;
			}
		}


		/// <summary>
		/// Sets the sort expression for the filtered entities in this view. It sorts the entities which are in this view, 
		/// </summary>
		/// <param name="sorter">The sorter.</param>
		protected virtual bool SetSorter( ISortExpression sorter )
		{
			ISortExpression sorterToSet = sorter;
			if((sorter==null) || ( (sorter != null) && (sorter.Count == 0) ))
			{
				_appliedSorter = null;
				return false;
			}

			_entityIndices = SortIndices( new ArrayList( _entityIndices ), sorterToSet, 0 );
			_appliedSorter = sorterToSet;
			return true;
		}


		/// <summary>
		/// Applies the filter specified to the set related collection
		/// </summary>
		/// <param name="filter">The filter to set. Will perform the filtering on the collection.</param>
		protected virtual void SetFilter( IPredicate filter)
		{
			_entityIndices.Clear();

			// ask collection to provide list of indices of matching entities.
			_entityIndices = _relatedCollection.FindMatches( filter );
			_appliedFilter = filter;
		}


		#region ITypedList implementation
		/// <summary>
		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the properties on each item used to bind data.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the collection as bindable. This can be null.</param>
		/// <returns>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the properties on each item used to bind data.
		/// </returns>
		public virtual PropertyDescriptorCollection GetItemProperties( PropertyDescriptor[] listAccessors )
		{
			IEntityCore dummyInstance = null;

			// determine the type of the entity to return the properties of.
			if( (listAccessors == null) || listAccessors.Length == 0 )
			{
				dummyInstance = CreateDummyInstance();
			}
			else
			{
				// use the last entry in the listAccessors, grab its TypeContainedAttribute and instantiate an instance of the type in that attribute,
				// use that entity instance to produce properties.
#if CF
				object[] customAttributes = listAccessors[listAccessors.Length-1].ComponentType.GetCustomAttributes(typeof(TypeContainedAttribute), false);
				TypeContainedAttribute typeAttribute = null;
				if(customAttributes.Length>0)
				{
					typeAttribute = (TypeContainedAttribute)customAttributes[0];
				}
#else
				TypeContainedAttribute typeAttribute = (TypeContainedAttribute)listAccessors[listAccessors.Length - 1].Attributes[typeof( TypeContainedAttribute )];
#endif
				if( typeAttribute == null )
				{
					// Assume selfservicing. Instantiate the type returned from the property, and check if it's an IEntityCollection implementing type.
					Type propertyType = listAccessors[listAccessors.Length - 1].PropertyType;
					Type[] implementedInterfaces = propertyType.GetInterfaces();
					if(Array.IndexOf(implementedInterfaces, typeof(IEntityCollection), 0, implementedInterfaces.Length)>=0)
					{
						// implements IEntityCollection. Create an instance of this type and grab it's 
						IEntityViewSource relatedCollection = (IEntityViewSource)Activator.CreateInstance( propertyType );
						dummyInstance = relatedCollection.CreateDummyInstance();
					}
					else
					{
						if(Array.IndexOf(implementedInterfaces, typeof(ITypedList), 0, implementedInterfaces.Length)>=0)
						{
							ITypedList relatedObject = (ITypedList)Activator.CreateInstance( propertyType );
							return relatedObject.GetItemProperties( null );
						}
						dummyInstance = null;
					}
				}
				else
				{
					dummyInstance = (IEntityCore)Activator.CreateInstance( typeAttribute.TypeContainedInCollection );
				}
			}

			if( dummyInstance == null )
			{
				return new PropertyDescriptorCollection( null );
			}

			return GetPropertyDescriptors( dummyInstance, listAccessors );
		}


		/// <summary>
		/// Gets the property descriptors for the entity passed in. This is a dummy instance, and used to produce the property descriptors.
		/// </summary>
		/// <param name="dummyInstance">Dummy instance.</param>
		/// <param name="listAccessors">List accessors.</param>
		/// <returns>
		/// the propertydescriptor collection of the properties of the entity passed in.
		/// </returns>
		public virtual PropertyDescriptorCollection GetPropertyDescriptors( IEntityCore dummyInstance, PropertyDescriptor[] listAccessors)
		{
			// skip collections if we're in design time databinding.
			bool skipCollections = ((EntityCollectionComponentDesigner.InDesignMode || (this.Site!=null)) && 
				((listAccessors != null) && (listAccessors.Length >= 2)));

			PropertyDescriptorCollection instancePropertiesCollection = TypeDescriptor.GetProperties( dummyInstance.GetType() );
			ArrayList instanceProperties = new ArrayList();
			Hashtable namesAdded = new Hashtable();
			GetEntityFieldPropertyDescriptors( dummyInstance, ref instanceProperties, ref namesAdded );

#if CF
            // grab the propery info's. As the CF can't read the attributes from property descriptors, we have to use these. 
            PropertyInfo[] propertyInfos = dummyInstance.GetType().GetProperties();

            // now walk all properties in the property descriptor collection. 
            foreach(PropertyInfo property in propertyInfos)
            {
                if(!namesAdded.ContainsKey(property.Name))
                {
                    // check if the property has a BrowsableAttribute.
                    object[] customAttributes = property.GetCustomAttributes(typeof(BrowsableAttribute), false);
                    if(customAttributes.Length>0)
                    {
                        if(!((BrowsableAttribute)customAttributes[0]).Browsable)
                        {
                            continue;
                        }
                    }
                    // add it
                    PropertyDescriptor toAdd = instancePropertiesCollection[property.Name];
                    if(toAdd!=null)
                    {
                        instanceProperties.Add(toAdd);
                    }
                }
            }
#else
			// now walk all properties in the property descriptor collection. Check if the name occurs in the hashtable. 
			// If not and if browsable, copy the descriptor over.
			foreach( PropertyDescriptor property in instancePropertiesCollection )
			{
				if( !namesAdded.ContainsKey( property.Name ) )
				{
					if( !property.IsBrowsable )
					{
						continue;
					}
					if( skipCollections )
					{
						// check if the property is of a type which is an LLBLGen Pro collection. If so, skip it
						if(( property.PropertyType.GetInterface( "IEntityCollection" ) != null) || ( property.PropertyType.GetInterface( "IEntityCollection2" ) != null))
						{
							continue;
						}

					}
					// add it
					instanceProperties.Add( property );
				}
			}
#endif
			return new PropertyDescriptorCollection( (PropertyDescriptor[])instanceProperties.ToArray(typeof(PropertyDescriptor)) );
		}


		/// <summary>
		/// Returns the name of the list.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects, the list name for which is returned. This can be null.</param>
		/// <returns>The name of the list.</returns>
		/// <remarks>Creates a dummy instance of the entity type in the related entitycollection and returns "LLBLGenProEntityName" + "Collection"</remarks>
		public virtual string GetListName( PropertyDescriptor[] listAccessors )
		{
			IEntityCore dummyInstance = CreateDummyInstance();
			if( dummyInstance == null )
			{
				return string.Empty;
			}
			return dummyInstance.LLBLGenProEntityName + "Collection";
		}
		#endregion

		

		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="relatedCollection">The related collection.</param>
		/// <param name="filterToApply">The filter to apply.</param>
		/// <param name="sorterToApply">The sorter to apply.</param>
		/// <param name="dataChangeAction">Data change action.</param>
		internal void InitClassCore(IEntityViewSource relatedCollection, IPredicate filterToApply, ISortExpression sorterToApply,
				PostCollectionChangeAction dataChangeAction )
		{
			_allowRemove = !relatedCollection.IsReadOnly;
			_allowEdit = !relatedCollection.IsReadOnly;
			_allowNew = !relatedCollection.IsReadOnly;
			_entityIndices = new ArrayList(relatedCollection.Count);
			_relatedCollection = relatedCollection;
			_appliedFilter = null;
			_appliedSorter = null;
			_suspendChangeEvents = false;
			_indexAddNewResult = -1;
			_dataChangeAction = dataChangeAction;
			BindEvents();
			SetFilter( filterToApply);
			SetSorter( sorterToApply );
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
		/// </returns>
		public abstract IEnumerator GetEnumerator();

		/// <summary>
		/// Gets the entity field property descriptors for the dummy instance passed in.
		/// </summary>
		/// <param name="dummyInstance">The dummy instance.</param>
		/// <param name="instanceProperties">The instance properties.</param>
		/// <param name="namesAdded">The names added by this routine</param>
		protected abstract void GetEntityFieldPropertyDescriptors( IEntityCore dummyInstance, ref ArrayList instanceProperties, ref Hashtable namesAdded );
		/// <summary>
		/// Creates a dummy instance for the related entity collection of this view. This is done using the entityfactory of that entitycollection.
		/// </summary>
		/// <returns></returns>
		protected abstract IEntityCore CreateDummyInstance();
		/// <summary>
		/// Gets the property descriptor for the first sortclause. 
		/// </summary>
		/// <param name="appliedSorter">The applied sorter on this view..</param>
		/// <returns></returns>
		protected abstract PropertyDescriptor GetSortProperty( ISortExpression appliedSorter );


		/// <summary>
		/// Sorts the list based on a <see cref="T:System.ComponentModel.PropertyDescriptor"></see> and a <see cref="T:System.ComponentModel.ListSortDirection"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to sort by.</param>
		/// <param name="direction">One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</param>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		protected virtual void ApplySort( PropertyDescriptor property, ListSortDirection direction )
		{
			// build sort expression.
			ISortExpression sorter = new SortExpression();

			sorter.Add( new SortClause( new EntityProperty( property ), null, SortOperator.Ascending ) );
			if( direction == ListSortDirection.Descending )
			{
				sorter[0].SortOperatorToUse = SortOperator.Descending;
			}

			if( SetSorter( sorter ) )
			{
				OnListChanged( 0, ListChangedType.Reset );
			}
		}


		/// <summary>
		/// Creates a projection of the current view data, using the passed in field projections and the projector.
		/// </summary>
		/// <param name="propertyProjectors">The property projectors.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all rows.</param>
		/// <param name="filter">The filter to select the source entities in this view.</param>
		/// <param name="projector">the actual projector engine. It is used to convert raw projection data into a real object inside the
		/// projector object.</param>
		protected void CreateProjection( ArrayList propertyProjectors, bool allowDuplicates, IPredicate filter, IEntityDataProjector projector )
		{
			object[] projectionResult = null;

			Hashtable distinctHashes = new Hashtable( this.Count );

			foreach( IEntityCore entity in this )
			{
				if( filter != null )
				{
					if( !((IPredicateInterpret)filter).Interpret( entity ) )
					{
						// doesn't match the filter, skip
						continue;
					}
				}
				projectionResult = new object[propertyProjectors.Count];

				// process all propertyprojectors on the current entity
				for( int i = 0; i < propertyProjectors.Count; i++ )
				{
					projectionResult[i] = ((IEntityPropertyProjector)propertyProjectors[i]).ProjectEntityProperty( entity );
				}

				bool acceptResults = true;
				if( !allowDuplicates )
				{
					// perform distinct filtering using hashes. If it fails, simply continue.
					// calculate hash of current row.
					int hashValue = 0;
					for( int i = 0; i < projectionResult.Length; i++ )
					{
						if( projectionResult[i] == null )
						{
							hashValue = DBNull.Value.GetHashCode();
							continue;
						}
						if( ((IEntityPropertyProjector)propertyProjectors[i]).ValueType.IsArray )
						{
							Array valueAsArray = projectionResult[i] as Array;
							int tmpHashValue = 0;
							for( int j = 0; j < valueAsArray.Length; j++ )
							{
								tmpHashValue ^= valueAsArray.GetValue( j ).GetHashCode();
							}
							hashValue ^= tmpHashValue;
						}
						else
						{
							hashValue ^= projectionResult[i].GetHashCode();
						}
					}

					ArrayList projectionResults = null;
					// check the hash in the table. If hash exists, check value-by-value with all the stored rows with that same hashvalue
					if( distinctHashes.ContainsKey( hashValue ) )
					{
						// possible duplicate, check per value
						projectionResults = (ArrayList)distinctHashes[hashValue];
						foreach( object[] previousResult in projectionResults )
						{
							bool areEqual = true;
							for( int j = 0; j < projectionResult.Length; j++ )
							{
								areEqual &= FieldUtilities.ValuesAreEqual( previousResult[j], projectionResult[j] );
								if( !areEqual )
								{
									// already not equal, check next.
									break;
								}
							}
							if( areEqual )
							{
								// row is dupe of previous result, don't accept row
								acceptResults = false;
								break;
							}
						}
						if( acceptResults )
						{
							// row isn't a dupe of a previous row, add it to the list of rows for this hash.
							projectionResults.Add( projectionResult );
						}
					}
					else
					{
						projectionResults = new ArrayList();
						distinctHashes.Add( hashValue, projectionResults );
					}
					// if row is accepted, add it to the projectionresults.
					if( acceptResults )
					{
						projectionResults.Add( projectionResult );
					}
					else
					{
						// continue with next entity
						continue;
					}
				}

				// valid raw projection result, add it to the projector
				projector.AddProjectionResultToContainer( propertyProjectors, projectionResult );
			}
		}


		/// <summary>
		/// Returns the index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search on.</param>
		/// <param name="key">The value of the property parameter to search for.</param>
		/// <returns>
		/// The index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSearching"></see> is false. </exception>
		protected virtual int Find( PropertyDescriptor property, object key )
		{
			int toReturn = -1;
			for(int i=0;i<this.Count;i++)
			{
				IEntityCore entity = GetEntityAtIndex(i);
				object value = property.GetValue(entity);
				if(value != null)
				{
					if(value.Equals(key))
					{
						toReturn = i;
						break;
					}
				}
				else
				{
					if(key == null)
					{
						toReturn = i;
						break;
					}
				}
			}
			return toReturn;
		}

		/// <summary>
		/// Removes any sort applied using <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		protected virtual void RemoveSort()
		{
			SetFilter( _appliedFilter );
			SetSorter( null );
			OnListChanged( 0, ListChangedType.Reset );
		}


		/// <summary>
		/// Determines whether this entity view contains the entity passed in. This method returns false if the entity is outside the filter, but in the related
		/// entity collection, as it's then not contained in the entity view.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public bool Contains( IEntityCore value )
		{
			return (this.IndexOf( value ) >= 0);
		}

		/// <summary>
		/// Determines the index of the entity passed in in the entity view in filtered and sorted state.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public int IndexOf( IEntityCore value )
		{
			int indexInCollection = _relatedCollection.IndexOf( value );
			return _entityIndices.IndexOf( indexInCollection );
		}


		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.ICollection"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">array is null. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"></see> is greater than the available space from index to the end of the destination array. </exception>
		/// <exception cref="T:System.InvalidCastException">The type of the source <see cref="T:System.Collections.ICollection"></see> cannot be cast automatically to the type of the destination array. </exception>
		public virtual void CopyTo( Array array, int index )
		{
			for( int i = 0; i < this.Count; i++ )
			{
				array.SetValue(_relatedCollection[(int)_entityIndices[i]], i);
			}
		}


		/// <summary>
		/// Gets the entity at the specofied index in the view. 
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>entity at the specified index in this view</returns>
		protected IEntityCore GetEntityAtIndex( int index )
		{
			if( (index < 0) || (index >= _entityIndices.Count) )
			{
				throw new IndexOutOfRangeException( string.Format( "The index '{0}' is outside the list of entities in this view.", index ) );
			}

			return _relatedCollection[(int)_entityIndices[index]];
		}


		/// <summary>
		/// Called when something changes in the related list or this view.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="typeOfChange">The type of change.</param>
		protected virtual void OnListChanged( int index, ListChangedType typeOfChange )
		{
			if( ListChanged != null )
			{
				ListChanged( this, new ListChangedEventArgs( typeOfChange, index ) );
			}
		}


		/// <summary>
		/// Sorts the indices in the list passed in using the sortclause at the indexInSortExpression in sorter. If there are multiple entities which have the
		/// same value, this routine calls itself to sort those entities using the next sortclause until the sortexpression is done.
		/// It returns a new list with indices. All indices are indices in the related collection.
		/// </summary>
		/// <param name="listToSort">The list of indices to sort. </param>
		/// <param name="sorter">The sort expression to use.</param>
		/// <param name="indexInSortExpression">The index in sort expression which points to the sortclause to use</param>
		/// <returns>new list of indices with the entities at the indices in listToSort in the order implied by sorter[indexInSortExpression]</returns>
		/// <remarks>will use recursion if there are entities with the same value and there are more sort clauses / expressions specified. </remarks>
		private ArrayList SortIndices( ArrayList listToSort, ISortExpression sorter, int indexInSortExpression )
		{
			if(( sorter == null )||((sorter!=null)&&(sorter.Count<=indexInSortExpression)))
			{
				// nothing to sort anymore.
				return listToSort;
			}

			// perform sorting. Use list for this and the build in QuickSort algo
			ArrayList valuesToSort = new ArrayList( this.Count );
			Hashtable valueToEntity = new Hashtable();
			ArrayList entityIndices = null;
			ArrayList nullValueIndices = new ArrayList(listToSort.Count);
			ISortClause clauseToUse = sorter[indexInSortExpression];
			IEntityFieldCoreInterpret fieldToSort = clauseToUse.FieldToSortCore as IEntityFieldCoreInterpret;
			if( fieldToSort == null )
			{
				throw new ORMInterpretationException( string.Format( "The field object '{0}', which is specified in the ISortExpression in the clause at position {1}, doesn't implement IEntityFieldCoreInterpret",
						clauseToUse.FieldToSortCore.Alias, indexInSortExpression ) );
			}
			valueToEntity.Add( DBNull.Value, nullValueIndices );

			for( int i = 0; i < listToSort.Count; i++ )
			{
				IEntityCore currentEntity = _relatedCollection[(int)listToSort[i]];
				object value = fieldToSort.GetValue( currentEntity );
				if( (value == null) || (value == DBNull.Value) )
				{
					// a null value, we can't sort them, add this index to a special list.
					nullValueIndices.Add( i );
					continue;
				}

				if( (clauseToUse.CaseSensitiveCollation) && (clauseToUse.FieldToSortCore.DataType == typeof( string )) )
				{
					value = ((string)value).ToUpper( CultureInfo.InvariantCulture );
				}

				if( valueToEntity.ContainsKey( value ) )
				{
					// already there, add index to arraylist with indices
					entityIndices = (ArrayList)valueToEntity[value];
				}
				else
				{
					entityIndices = new ArrayList();
					valueToEntity.Add( value, entityIndices );
					valuesToSort.Add( value );
				}

				entityIndices.Add( i );
			}

			// sort the values. 
			valuesToSort.Sort();

			// valuesToSort is now sorted in ascending order. Check the direction to read from front to back or from back to front.
			ArrayList toReturn = new ArrayList(listToSort.Count);
			if( clauseToUse.SortOperatorToUse == SortOperator.Ascending )
			{
				// front to back
				// first the null values.
				nullValueIndices = (ArrayList)valueToEntity[DBNull.Value];
				if( nullValueIndices.Count > 0 )
				{
					// sort them on the other clauses, if present
					nullValueIndices = SortIndices( nullValueIndices, sorter, indexInSortExpression + 1 );
				}
				foreach( int index in nullValueIndices )
				{
					toReturn.Add( listToSort[index] );
				}

				for( int i = 0; i < valuesToSort.Count; i++ )
				{
					entityIndices = (ArrayList)valueToEntity[valuesToSort[i]];
					// if this value has more than 1 index filed with it, more than one entity has this value and we've to sort these
					// indices with the next sort clause.
					if( entityIndices.Count > 1 )
					{
						entityIndices = SortIndices( entityIndices, sorter, indexInSortExpression + 1 );
					}
					foreach( int index in entityIndices )
					{
						toReturn.Add( listToSort[index] );
					}
				}
			}
			else
			{
				// back to front
				for( int i = valuesToSort.Count - 1; i >= 0; i-- )
				{
					entityIndices = (ArrayList)valueToEntity[valuesToSort[i]];
					// if this value has more than 1 index filed with it, more than one entity has this value and we've to sort these
					// indices with the next sort clause.
					if( entityIndices.Count > 1 )
					{
						entityIndices = SortIndices( entityIndices, sorter, indexInSortExpression + 1 );
					}

					foreach( int index in entityIndices )
					{
						toReturn.Add( listToSort[index] );
					}
				}

				// then the null values.
				nullValueIndices = (ArrayList)valueToEntity[DBNull.Value];
				if( nullValueIndices.Count > 0 )
				{
					// sort them on the other clauses, if present
					nullValueIndices = SortIndices( nullValueIndices, sorter, indexInSortExpression + 1 );
				}
				foreach( int index in nullValueIndices )
				{
					toReturn.Add( listToSort[index] );
				}
			}

			return toReturn;
		}

#if !CF
		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.MarshalByValueComponent"></see> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				_relatedCollection.ListChanged -= new ListChangedEventHandler(_relatedCollectionListChanged);
				_relatedCollection = null;
			}
			base.Dispose(disposing);
		}
#endif
		
		/// <summary>
		/// Binds the events of the related collection to own event handlers so the changes in the related collection are noted and handled here as well.
		/// </summary>
		private void BindEvents()
		{
			_relatedCollection.ListChanged += new ListChangedEventHandler( _relatedCollectionListChanged );
		}


		/// <summary>
		/// Applies the filter on entity at index passed. If no filter is set, this method is a no-op and always returns true, unless the index is out of bounds.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>true if the filter resolved to true, or no filter is present, otherwise false</returns>
		private bool ApplyFilterOnEntity( int index)
		{
			bool toReturn = false;
			if((index<0) || (index>=_relatedCollection.Count))
			{
				toReturn = false;
			}
			if( _appliedFilter == null )
			{
				toReturn =  true;
			}
			else
			{
				if( ((IPredicateInterpret)_appliedFilter).Interpret( _relatedCollection[index] ) )
				{
					toReturn= true;
				}
			}
			return toReturn;
		}

		
		/// <summary>
		/// Handles the ListChanged event of the related collection. It executes various actions based on the listchanged type.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.ListChangedEventArgs"/> instance containing the event data.</param>
		private void _relatedCollectionListChanged( object sender, ListChangedEventArgs e )
		{
			if( _suspendChangeEvents )
			{
				return;
			}

			bool filterResult = false;
			int indexForEvent = 0;
			ListChangedType changetypeForEvent = ListChangedType.Reset;
			bool fireEvent = true; 
			bool isNewIndex = false;
			bool isInsert = false;
			switch( e.ListChangedType )
			{
				case ListChangedType.ItemAdded:
					isInsert = (_entityIndices.Contains(e.NewIndex) && (_entityIndices.Count<_relatedCollection.Count)); 
					isNewIndex = (!_entityIndices.Contains(e.NewIndex) || isInsert);
					switch( _dataChangeAction )
					{
						case PostCollectionChangeAction.NoAction:
							// simply append the index to the list of indices, IF the entity is added through databinding.
							if((_indexAddNewResult>=0) && ( _indexAddNewResult == e.NewIndex )&& isNewIndex)
							{
								_entityIndices.Add( e.NewIndex );
								UpdateIndices( e.NewIndex,  ListAction.Addition, (_entityIndices.Count-1) );
								OnListChanged( _entityIndices.Count - 1, ListChangedType.ItemAdded );
							}
							break;
						case PostCollectionChangeAction.ReapplyFilterAndSorter:
							fireEvent = false;
							filterResult = ApplyFilterOnEntity( e.NewIndex );
							if( filterResult && (e.NewIndex>=0) && isNewIndex)
							{
								// new index, of an entity matching the filter, add it. If it's an insert, insert it at the spot
								// where now the existing index is located.
								if( isInsert )
								{
									indexForEvent = _entityIndices.IndexOf( e.NewIndex );
									_entityIndices.Insert( indexForEvent, e.NewIndex );
									UpdateIndices( indexForEvent,  ListAction.Insertion, indexForEvent );
									changetypeForEvent = ListChangedType.Reset;
								}
								else
								{
									_entityIndices.Add( e.NewIndex );
									UpdateIndices( e.NewIndex,  ListAction.Addition, (_entityIndices.Count-1) );
									indexForEvent = (_entityIndices.Count-1);
									changetypeForEvent = ListChangedType.ItemAdded;
								}
								fireEvent = true;
							}
							if( SetSorter( _appliedSorter ) )
							{
								OnListChanged( 0, ListChangedType.Reset );
							}
							else
							{
								if( fireEvent )
								{
									OnListChanged( indexForEvent, changetypeForEvent );
								}
							}
							break;
						case PostCollectionChangeAction.ReapplySorter:
							fireEvent = false; 
							if((_indexAddNewResult>=0) && ( _indexAddNewResult == e.NewIndex ) && isNewIndex)
							{
								_entityIndices.Add( e.NewIndex );
								UpdateIndices( e.NewIndex,  ListAction.Addition, (_entityIndices.Count-1) );
								fireEvent = true;
							}
							if( SetSorter( _appliedSorter ) )
							{
								OnListChanged( 0, ListChangedType.Reset );
							}
							else
							{
								if( fireEvent )
								{
									OnListChanged( _entityIndices.Count - 1, ListChangedType.ItemAdded );
								}
							}
							break;
					}
					break;
				case ListChangedType.ItemChanged:
					// this event is fired after the change is finalized in the entity which was changed, so if the view is bound to a grid or other control,
					// the event is fired after EndEdit() is called on the entity. This avoids a lot of events being fired for multiple entity field edits and
					// thus also multiple filter/sorts being applied when an entity is still being edited.
					switch( _dataChangeAction )
					{
						case PostCollectionChangeAction.NoAction:
							if( _entityIndices.Contains( e.NewIndex ) )
							{
								OnListChanged( _entityIndices.IndexOf(e.NewIndex), ListChangedType.ItemChanged );
							}
							break;
						case PostCollectionChangeAction.ReapplyFilterAndSorter:
							fireEvent = true; 
							filterResult = ApplyFilterOnEntity( e.NewIndex );
							if(filterResult)
							{
								if(_entityIndices.Contains(e.NewIndex))
								{
									indexForEvent = _entityIndices.IndexOf(e.NewIndex);
									changetypeForEvent = ListChangedType.ItemChanged;
								}
								else
								{
									if(e.NewIndex>=0)
									{
										_entityIndices.Add(e.NewIndex);
										indexForEvent = _entityIndices.Count-1;
										changetypeForEvent = ListChangedType.ItemAdded;
									}
								}
							}
							else
							{
								if( _entityIndices.Contains( e.NewIndex ) )
								{
									// remove index as filter failed.
									indexForEvent = _entityIndices.IndexOf(e.NewIndex);
									changetypeForEvent = ListChangedType.ItemDeleted;
									_entityIndices.Remove( e.NewIndex );
								}
								else
								{
									// not in view now, not in view after filter, ignore
									fireEvent = false;
								}
							}
							if( SetSorter( _appliedSorter ) )
							{
								OnListChanged( 0, ListChangedType.Reset );
							}
							else
							{
								if( fireEvent )
								{
									OnListChanged( indexForEvent, changetypeForEvent );
								}
							}
							break;
						case PostCollectionChangeAction.ReapplySorter:
							if( _entityIndices.Contains( e.NewIndex ) )
							{
								if( SetSorter( _appliedSorter ) )
								{
									OnListChanged( 0, ListChangedType.Reset );
								}
								else
								{
									OnListChanged( _entityIndices.IndexOf( e.NewIndex ), ListChangedType.ItemChanged );
								}
							}
							break;
					}
					break;
				case ListChangedType.ItemDeleted:
					if(_entityIndices.Contains( e.NewIndex))
					{
						// complete reset, as all indices change. If the row was added through AddNew, the index has to be reset as well.
						if((_indexAddNewResult>=0) && ( _indexAddNewResult == e.NewIndex ))
						{
							_indexAddNewResult = -1;
						}

						int viewIndex = _entityIndices.IndexOf( e.NewIndex );
						_entityIndices.Remove( e.NewIndex );
						UpdateIndices( e.NewIndex, ListAction.Deletion, viewIndex );
						switch( _dataChangeAction )
						{
							case PostCollectionChangeAction.NoAction:
								OnListChanged( viewIndex, ListChangedType.ItemDeleted );
								break;
							case PostCollectionChangeAction.ReapplySorter:
							case PostCollectionChangeAction.ReapplyFilterAndSorter:
								if( SetSorter( _appliedSorter ) )
								{
									OnListChanged( 0, ListChangedType.Reset );
								}
								else
								{
									OnListChanged( viewIndex, ListChangedType.ItemDeleted );
								}
								break;
						}
					}
					else
					{
						// complete reset of indices, no event signaling upwards, as nothing relevant for the outside has changed.
						UpdateIndices(e.NewIndex, ListAction.Deletion, 0);
					}
					break;
				case ListChangedType.ItemMoved:
					break;
				case ListChangedType.Reset:
					// complete reset. Reapply filter, and Reapply sorter
					SetFilter( _appliedFilter );
					SetSorter( _appliedSorter );
					OnListChanged( 0, ListChangedType.Reset );
					break;
			}
		}

		/// <summary>
		/// Adjusts the indices in the _entityIndices collection, which is necessary if an entity in this view was added/removed/inserted to/from the
		/// related list.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="action">The action.</param>
		/// <param name="newItemInEntityIndicesIndex">New index of the item in entity indices. Used in inserts. With inserts, there are two 
		/// positions in entityIndices, which have the same value. The position newItemInEntityIndicesIndex has to stay that value, all other
		/// values have to be adjusted if they're equal or greater than index..</param>
		private void UpdateIndices( int index, ListAction action, int newItemInEntityIndicesIndex )
		{
			switch(action)
			{
				case ListAction.Addition:
					for( int i = 0; i < _entityIndices.Count; i++ )
					{
						if( (int)_entityIndices[i] > index )
						{
							_entityIndices[i]=(int)_entityIndices[i] + 1;
						}
					}
					break;
				case ListAction.Deletion:
					for( int i = 0; i < _entityIndices.Count; i++ )
					{
						if( (int)_entityIndices[i] > index )
						{
							_entityIndices[i]=(int)_entityIndices[i] - 1;
						}
					}
					break;
				case ListAction.Insertion:
					for( int i = 0; i < _entityIndices.Count; i++ )
					{
						if(( (int)_entityIndices[i] >= index ) && (i!=newItemInEntityIndicesIndex))
						{
							_entityIndices[i]=(int)_entityIndices[i] + 1;
						}
					}
					break;
			}
		}

		#region IBindingList Members
		/// <summary>
		/// Adds the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to the indexes used for searching.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to add to the indexes used for searching.</param>
		void IBindingList.AddIndex( PropertyDescriptor property )
		{
			throw new NotSupportedException("IBindingList.AddIndex isn't supported.");
		}

		/// <summary>
		/// Adds a new item to the list.
		/// </summary>
		/// <returns>The item added to the list.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.AllowNew"></see> is false. </exception>
		object IBindingList.AddNew()
		{
			return this.AddNew();
		}

		/// <summary>
		/// Sorts the list based on a <see cref="T:System.ComponentModel.PropertyDescriptor"></see> and a <see cref="T:System.ComponentModel.ListSortDirection"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to sort by.</param>
		/// <param name="direction">One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</param>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		void IBindingList.ApplySort( PropertyDescriptor property, ListSortDirection direction )
		{
			this.ApplySort( property, direction );
		}

		/// <summary>
		/// Returns the index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search on.</param>
		/// <param name="key">The value of the property parameter to search for.</param>
		/// <returns>
		/// The index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSearching"></see> is false. </exception>
		int IBindingList.Find( PropertyDescriptor property, object key )
		{
			return this.Find( property, key );
		}

		/// <summary>
		/// Removes the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> from the indexes used for searching.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to remove from the indexes used for searching.</param>
		void IBindingList.RemoveIndex( PropertyDescriptor property )
		{
			throw new NotSupportedException( "IBindingList.RemoveIndex isn't supported." );
		}

		/// <summary>
		/// Removes any sort applied using <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		void IBindingList.RemoveSort()
		{
			this.RemoveSort();
		}


		/// <summary>
		/// Gets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		bool IBindingList.AllowEdit
		{
			get { return this.AllowEdit; }
		}

		/// <summary>
		/// Gets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		bool IBindingList.AllowNew
		{
			get { return this.AllowNew; }
		}

		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can remove items from the list; otherwise, false.</returns>
		bool IBindingList.AllowRemove
		{
			get { return this.AllowRemove; }
		}


		/// <summary>
		/// Gets whether the items in the list are sorted.
		/// </summary>
		/// <value></value>
		/// <returns>true if <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see> has been called and <see cref="M:System.ComponentModel.IBindingList.RemoveSort"></see> has not been called; otherwise, false.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		bool IBindingList.IsSorted
		{
			get { return this.IsSorted; }
		}

		/// <summary>
		/// Gets the direction of the sort.
		/// </summary>
		/// <value></value>
		/// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		ListSortDirection IBindingList.SortDirection
		{
			get { return this.SortDirection; }
		}

		/// <summary>
		/// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		PropertyDescriptor IBindingList.SortProperty
		{
			get { return this.SortProperty; }
		}

		/// <summary>
		/// Gets whether a <see cref="E:System.ComponentModel.IBindingList.ListChanged"></see> event is raised when the list changes or an item in the list changes.
		/// </summary>
		/// <value></value>
		/// <returns>true if a <see cref="E:System.ComponentModel.IBindingList.ListChanged"></see> event is raised when the list changes or when an item changes; otherwise, false.</returns>
		bool IBindingList.SupportsChangeNotification
		{
			get { return true; }
		}

		/// <summary>
		/// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, searching is supported.</returns>
		bool IBindingList.SupportsSearching
		{
			get { return true; }
		}

		/// <summary>
		/// Gets whether the list supports sorting.
		/// </summary>
		/// <value></value>
		/// <returns>true, sorting is always enabled.</returns>
		bool IBindingList.SupportsSorting
		{
			get { return true; }
		}
		#endregion

		#region IList Members
		/// <summary>
		/// Not supported. Use AddNew() or add a new object to the related entity collection.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		int IList.Add( object value )
		{
			if( value == null )
			{
				// design time databinding.
				IEntityCore newEntity = this.AddNew();
				return this.IndexOf(newEntity);
			}
			throw new NotSupportedException( "Add a new object to the related collection instead, or use IBindingList.AddNew() on this object." );
		}

		/// <summary>
		/// Not supported. Clear the related entity collection instead.
		/// </summary>
		void IList.Clear()
		{
			throw new NotSupportedException( "Clear the related collection instead." );
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.IList"></see> contains a specific value.
		/// </summary>
		/// <param name="value">The <see cref="T:System.Object"></see> to locate in the <see cref="T:System.Collections.IList"></see>.</param>
		/// <returns>
		/// true if the <see cref="T:System.Object"></see> is found in the <see cref="T:System.Collections.IList"></see>; otherwise, false.
		/// </returns>
		bool IList.Contains( object value )
		{
			IEntityCore toCheck = value as IEntityCore;
			if( toCheck == null )
			{
				throw new ArgumentException( "value isn't of the correct type." );
			}
			return this.Contains( toCheck );
		}

		/// <summary>
		/// Determines the index of a specific item in the <see cref="T:System.Collections.IList"></see>.
		/// </summary>
		/// <param name="value">The <see cref="T:System.Object"></see> to locate in the <see cref="T:System.Collections.IList"></see>.</param>
		/// <returns>
		/// The index of value if found in the list; otherwise, -1.
		/// </returns>
		int IList.IndexOf( object value )
		{
			IEntityCore toCheck = value as IEntityCore;
			if( toCheck == null )
			{
				throw new ArgumentException( "value isn't of the correct type." );
			}
			return this.IndexOf( toCheck );
		}

		/// <summary>
		/// Not supported. Insert a new entity in the related collection instead.
		/// </summary>
		void IList.Insert( int index, object value )
		{
			throw new NotSupportedException( "Insert a new entity in the related collection instead." );
		}

		/// <summary>
		/// Not supported. Remove the entity from the related collection instead.
		/// </summary>
		void IList.Remove( object value )
		{
			if( !(value is IEntityCore) )
			{
				throw new ArgumentException( "value isn't of the correct type." );
			}

			this.Remove((IEntityCore)value );
		}

		/// <summary>
		/// Not supported. Remove the entity from the related collection instead.
		/// </summary>
		void IList.RemoveAt( int index )
		{
			this.RemoveAt( index );
		}

		/// <summary>
		/// Returns false
		/// </summary>
		bool IList.IsFixedSize
		{
			get { return false; }
		}

		/// <summary>
		/// Returns false.
		/// </summary>
		bool IList.IsReadOnly
		{
			get { return (!this.AllowEdit) && (!this.AllowNew) && (!this.AllowRemove); }
		}

		/// <summary>
		/// Indexer via IList. Setter isn't supported, getter returns the typed indexer's value.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		object IList.this[int index]
		{
			get
			{
				return GetEntityAtIndex( index );
			}
			set
			{
				throw new Exception( "To add an element to this view, add it to the related collection instead." );
			}
		}

		#endregion

		#region ICollection Members

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.ICollection"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">array is null. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"></see> is greater than the available space from index to the end of the destination array. </exception>
		/// <exception cref="T:System.InvalidCastException">The type of the source <see cref="T:System.Collections.ICollection"></see> cannot be cast automatically to the type of the destination array. </exception>
		void ICollection.CopyTo( Array array, int index )
		{
			this.CopyTo( array, index );
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.</returns>
		int ICollection.Count
		{
			get { return _entityIndices.Count; }
		}

		/// <summary>
		/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe).
		/// </summary>
		/// <value></value>
		/// <returns>true if access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe); otherwise, false.</returns>
		bool ICollection.IsSynchronized
		{
			get { return false; }
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.</returns>
		object ICollection.SyncRoot
		{
			get { return this; }
		}

		#endregion

		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the data change action which specifies what to do when the data in the related collection of an entity view changes. A change in 
		/// data can be: entity added or changed. If an entity is removed from the underlying collection, the entity is simply removed from the entity 
		/// view, as the view doesn't contain any data by itself.
		/// </summary>
		/// <value>The data change action.</value>
		public PostCollectionChangeAction DataChangeAction
		{
			get { return _dataChangeAction; }
			set { _dataChangeAction = value; }
		}

		/// <summary>
		/// Gets/sets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		public virtual bool AllowNew
		{
			get { return _allowNew; }
			set 
			{
				if( !_relatedCollection.IsReadOnly )
				{
					_allowNew = value;
				}
			}
		}

		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		public virtual bool AllowRemove
		{
			get { return _allowRemove; }
			set 
			{
				if( !_relatedCollection.IsReadOnly )
				{
					_allowRemove = value;
				}
			}
		}

		/// <summary>
		/// Gets / sets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		public virtual bool AllowEdit
		{
			get { return _allowEdit; }
			set 
			{
				if( !_relatedCollection.IsReadOnly )
				{
					_allowEdit = value;
				}
			}
		}

		/// <summary>
		/// Gets whether the items in the list are sorted.
		/// </summary>
		/// <value></value>
		/// <returns>true if <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see> has been called and <see cref="M:System.ComponentModel.IBindingList.RemoveSort"></see> has not been called; otherwise, false.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		public bool IsSorted
		{
			get { return (_appliedSorter!=null); }
			set { throw new NotSupportedException( "Set this property by sorting this instance." ); }
		}

		/// <summary>
		/// IBindingList member. Gets the direction of the sort. This property returns the value of the first SortClause in the set sorter. 
		/// </summary>
		/// <value></value>
		/// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		public ListSortDirection SortDirection
		{
			get 
			{
				if( !this.IsSorted )
				{
					// it is the right spot to throw an exception, but .NET grids are pretty stupid so they read this property without doing proper research
					// and if a view is unsorted, what to return? There are just 2 sortdirection values... :/
					return ListSortDirection.Ascending;
				}

				ListSortDirection toReturn = ListSortDirection.Ascending;
				switch( _appliedSorter[0].SortOperatorToUse )
				{
					case SortOperator.Ascending:
						toReturn = ListSortDirection.Ascending;
						break;
					case SortOperator.Descending:
						toReturn = ListSortDirection.Descending;
						break;
				}

				return toReturn;
			}
			set { throw new NotSupportedException( "Set this property by sorting this instance." ); }
		}

		/// <summary>
		/// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		public PropertyDescriptor SortProperty
		{
			get 
			{
				if( this.IsSorted )
				{
					return GetSortProperty(_appliedSorter);
				}
				return null; 
			}
			set { throw new NotSupportedException( "Set this property by sorting this instance." ); }
		}


		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.</returns>
		public int Count
		{
			get { return _entityIndices.Count; }
		}


		/// <summary>
		/// Gets or sets the sorter for this entity view. Setting this property will re-sort the view and will reset the view in databinding scenario's.
		/// </summary>
		/// <value>The sort expression to use.</value>
		public ISortExpression Sorter
		{
			get { return _appliedSorter; }
			set 
			{ 
				if( SetSorter( value ) )
				{
					OnListChanged( 0, ListChangedType.Reset );
				}
			}
		}


		/// <summary>
		/// Gets or sets the filter to use for this entity view.
		/// </summary>
		/// <value>The filter to use</value>
		public IPredicate Filter
		{
			get { return _appliedFilter; }
			set 
			{ 
				SetFilter( value ); 
				SetSorter( _appliedSorter );
				OnListChanged(0, ListChangedType.Reset);
			}
		}


		/// <summary>
		/// Gets the entity indices for the entities which are in this view, in the order sorted by the sorter set.
		/// </summary>
		/// <value>The entity indices.</value>
		protected ArrayList EntityIndices
		{
			get { return _entityIndices; }
		}


		/// <summary>
		/// Gets the related collection using a property which is solely for internal usage. This is then used by the derived classes to expose the collection
		/// in a more typed manner.
		/// </summary>
		/// <value>The related collection internal.</value>
		internal IEntityViewSource RelatedCollectionInternal
		{
			get { return _relatedCollection; }
		}

#if CF
		// dummy property for CF.NET as MarshallByValue doesn't have a Site property.
		private ISite _site;
		internal ISite Site
		{
			get { return null;}
			set { _site = value;}
		}
#endif
		#endregion
	}
}
