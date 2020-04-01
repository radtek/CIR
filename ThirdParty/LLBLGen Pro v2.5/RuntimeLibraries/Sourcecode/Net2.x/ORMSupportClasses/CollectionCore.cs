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
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Generic base class for the entity collection classes used by Selfservicing and adapter. This class is mainly written to 
	/// be able to tap into Add/Remove/Insert etc. without problems: the shipped collection classes in .NET don't have the ability to
	/// override Add etc. 
	/// </summary>
	/// <typeparam name="T">The type this collection is of (the type of the contained objects.) </typeparam>
	[Serializable]
	[DesignerCategory( "Code" )]
	public abstract class CollectionCore<T> : IList<T>, IList, ISerializable, IComponent
		where T : class, IEntityCore
	{
		#region Class Member Declarations
		private List<T> _contents;
		private bool _isReadOnly, _doNotPerformAddIfPresent, _allowNew, _allowRemove, _allowEdit;
		private IConcurrencyPredicateFactory _concurrencyPredicateFactoryToUse;
		private ISite _site;

		[NonSerialized]
		private bool _deserializationInProgress;
		[NonSerialized]
		private bool _listOperationInProgress;
		[NonSerialized]
		private bool _surpressListChangedEvents;
		// fast-access index which stores per objectid the index in the collection. Is created the first time IndexOf is called and the index isn't there.
		// It's rebuild every time the index is considered invalid (when a remove/insert has taken place, or a reset is required due to a sort). 
		// Rebuild is postponed till the next time IndexOf is called. 
		[NonSerialized]
		private Dictionary<Guid, int> _entityIndices;			
		#endregion

		#region Class Event Declarations
		/// <summary>
		/// IComponent's Disposed event. 
		/// </summary>
		public event EventHandler Disposed;
		/// <summary>
		/// Event which is used in complex databinding.
		/// </summary>
		public event System.ComponentModel.ListChangedEventHandler ListChanged;

		/// <summary>
		/// Event which is raised at the start of the Remove or RemoveAt(index) routine. To cancel the remove action, set cancel to true.
		/// </summary>
		public event EventHandler<CancelableCollectionChangedEventArgs> EntityRemoving;
		/// <summary>
		/// Event which is raised at the End of the Remove or RemoveAt(index) routine.
		/// </summary>
		public event EventHandler<CollectionChangedEventArgs> EntityRemoved;
		/// <summary>
		/// Event which is raised at the start of the Add or Insert(index) routine. To cancel the addition action, set cancel to true.
		/// </summary>
		public event EventHandler<CancelableCollectionChangedEventArgs> EntityAdding;
		/// <summary>
		/// Event which is raised at the End of the Add or Insert(index) routine.
		/// </summary>
		public event EventHandler<CollectionChangedEventArgs> EntityAdded;
		#endregion

		/// <summary>
		/// empty ctor.
		/// </summary>
		public CollectionCore()
		{
		}

		/// <summary>
		/// Deserialization CTor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionCore( SerializationInfo info, StreamingContext context )
		{
			if(SerializationHelper.Optimization == SerializationOptimization.Fast)
			{
				// collection will be handled elsewhere
				return;
			}

			try
			{
				_deserializationInProgress = true;
				int amountOfEntitiesInList = info.GetInt32( "AmountEntitiesInList" );
				InitCoreClass( amountOfEntitiesInList );
				bool readOnlyValue = info.GetBoolean( "_isReadOnly" );
				IConcurrencyPredicateFactory concurrencyPredicateFactoryToUseValue = (IConcurrencyPredicateFactory)info.GetValue( "_concurrencyPredicateFactoryToUse", typeof( IConcurrencyPredicateFactory ) );
				_allowNew = info.GetBoolean( "_allowNew" );
				_allowRemove = info.GetBoolean( "_allowRemove" );
				_allowEdit = info.GetBoolean( "_allowEdit" );

				// we can safely set this value here, because Add() will never check for existing entities during deserialization.
				_doNotPerformAddIfPresent = info.GetBoolean( "_doNotPerformAddIfPresent" );
				
				for( int i = 0; i < amountOfEntitiesInList; i++ )
				{
					T entityToAdd = (T)info.GetValue( "Entity" + i, typeof( T ) );
					// add it. It will wire the events automatically.
					this.Add( entityToAdd );
				}

				// set readonly now, otherwise it will affect Add.
				_isReadOnly = readOnlyValue;
				_concurrencyPredicateFactoryToUse = concurrencyPredicateFactoryToUseValue;
				OnDeserialized( info, context );
			}
			// all exceptions are fatal
			finally
			{
				_deserializationInProgress = false;
			}
		}


		/// <summary>
		/// ISerializable member. 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public virtual void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			info.AddValue( "_allowNew", _allowNew );
			info.AddValue( "_allowRemove", _allowRemove );
			info.AddValue( "_allowEdit", _allowEdit );
			info.AddValue( "_doNotPerformAddIfPresent", _doNotPerformAddIfPresent );
			info.AddValue( "_isReadOnly", _isReadOnly );
			info.AddValue( "_concurrencyPredicateFactoryToUse", _concurrencyPredicateFactoryToUse );

			info.AddValue( "AmountEntitiesInList", this.Count );

			if( this.Count > 0 )
			{
				// serialize the entities
				for( int i = 0; i < this.Count; i++ )
				{
					info.AddValue( "Entity" + i, _contents[i] );
				}
			}

			OnGetObjectData( info, context );
		}


		/// <summary>
		/// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"></see>.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"></see>.</param>
		/// <returns>
		/// The index of item if found in the list; otherwise, -1.
		/// </returns>
		public int IndexOf( T item )
		{
			int toReturn = -1;
			if( _entityIndices == null )
			{
				RebuildEntityIndex();
			}

			if( !_entityIndices.TryGetValue( item.ObjectID, out toReturn ) )
			{
				toReturn = _contents.IndexOf( item );
			}
			return toReturn;
		}


		/// <summary>
		/// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"></see> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"></see>.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"></see>.</exception>
		/// <exception cref="T:System.ArgumentNullException">item is null</exception>
		public void Insert( int index, T item )
		{
			if( item == null )
			{
				throw new ArgumentNullException( "item", "item can't be null" );
			}

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Insert", "Method Enter" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, GetEntityDescription(item, TraceHelper.GeneralSwitch.TraceVerbose ), "Entity to Insert Description" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in." );

			if( _isReadOnly && !_deserializationInProgress )
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			bool insertTheEntity = true;
			if( _doNotPerformAddIfPresent )
			{
				insertTheEntity = !this.Contains( item );
			}
			if( insertTheEntity )
			{
				insertTheEntity = OnEntityAdding( item );
			}
			if(insertTheEntity)
			{
				_contents.Insert( index, item );
				// index isn't valid anymore.
				_entityIndices = null;

				if( !_deserializationInProgress )
				{
					PerformSetRelatedEntity( item );
					OnListChanged( index, ListChangedType.ItemAdded );
				}
				item.EntityContentsChanged += new EventHandler( OnEntityInListOnEntityContentsChanged );
				PerformAddToActiveContext( item );
				OnEntityAdded( item );
			}
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Insert", "Method Exit" );
		}

		/// <summary>
		/// Removes the <see cref="T:System.Collections.Generic.IList`1"></see> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.IList`1"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"></see>.</exception>
		public void RemoveAt( int index )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.RemoveAt", "Method Enter" );

			if( _isReadOnly )
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			T objectToRemove = _contents[index];
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, GetEntityDescription(objectToRemove, TraceHelper.GeneralSwitch.TraceVerbose ), "Entity to Remove Description" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in." );

			bool beginRemoveResult = OnEntityRemoving( objectToRemove );
			if( !beginRemoveResult )
			{
				// canceled. 
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.RemoveAt", "Canceled by EntityRemoving event. Method Exit" );
				return;
			}
			PerformUnsetRelatedEntity( objectToRemove );
			_contents.RemoveAt( index );
			_entityIndices = null;
			PlaceInRemovedEntitiesTracker(objectToRemove);

			OnListChanged( index, ListChangedType.ItemDeleted );
			// remove subscribtion to the changed event.
			objectToRemove.EntityContentsChanged -= new EventHandler( OnEntityInListOnEntityContentsChanged );

			OnEntityRemoved( objectToRemove );
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.RemoveAt", "Method Exit" );
		}


		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
		public void Add( T item )
		{
			if( item == null )
			{
				throw new ArgumentNullException( "item", "item can't be null" );
			}

			PerformAdd( item );
		}


		/// <summary>
		/// Adds the range of objects passed in. 
		/// </summary>
		/// <param name="c">Collection to add</param>
		public void AddRange( ICollection<T> c )
		{
			_contents.Capacity = Math.Max(_contents.Capacity, _contents.Count + c.Count);

			foreach( T toAdd in c )
			{
				this.Add( toAdd );
			}
		}


		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		public void Clear()
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Clear", "Method Enter" );
			if( !_listOperationInProgress )
			{
				if( _isReadOnly )
				{
					throw new InvalidOperationException( "This collection is read-only." );
				}

				// unset related entity information
				foreach( T entity in _contents )
				{
					PerformUnsetRelatedEntity( entity );
					UnsetEntityEventHandlers(entity);
				}
			}

			_contents.Clear();
			if( _listOperationInProgress )
			{
				// don't fire a listchange operation just yet, as the operation in progress will do that anyway.
				return;
			}

			OnListChanged( 0, ListChangedType.Reset );
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Clear", "Method Exit" );
		}


		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// <returns>
		/// true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
		/// </returns>
		public bool Contains( T item )
		{
			return _contents.Contains( item );
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
		/// <exception cref="T:System.ArgumentNullException">array is null.</exception>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or-arrayIndex is equal to or greater than the length of array.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"></see> is greater than the available space from arrayIndex to the end of the destination array.-or-Type TEntity cannot be cast automatically to the type of the destination array.</exception>
		public void CopyTo( T[] array, int arrayIndex )
		{
			_contents.CopyTo( array, arrayIndex );
		}


		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// <returns>
		/// true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. 
		/// This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
		public bool Remove( T item )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Remove", "Method Enter" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, GetEntityDescription( item, TraceHelper.GeneralSwitch.TraceVerbose ), "Entity to Remove Description" );

			if( _isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			bool succeeded = false;
			int index = this.IndexOf( item );
			if( index >= 0 )
			{
				bool beginRemoveResult = OnEntityRemoving( item );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Remove", "Canceled by EntityRemoving event. Method Exit" );
					return false;
				}
				PerformUnsetRelatedEntity( item );

				succeeded = _contents.Remove( item );
				if( !succeeded )
				{
					throw new ApplicationException( "The remove failed, as List<T>.Remove returned false" );
				}
				PlaceInRemovedEntitiesTracker(item);

				// index isn't valid anymore.
				_entityIndices = null;

				OnListChanged( index, ListChangedType.ItemDeleted );
				item.EntityContentsChanged -= new EventHandler( OnEntityInListOnEntityContentsChanged );
			}
			OnEntityRemoved( item );
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Remove", "Method Exit" );
			return succeeded;
		}


		/// <summary>
		/// Applies sorting like IBindingList.ApplySort, on the field with the index fieldIndex and with the direction specified.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <remarks>For backwards compatibility.</remarks>
		public void Sort( int fieldIndex, ListSortDirection direction )
		{
			Sort( fieldIndex, direction, null );
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="propertyName">property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		/// <remarks>For backwards compatibility.</remarks>
		public void Sort( string propertyName, ListSortDirection direction, IComparer<object> comparerToUse )
		{
			if( this.Count <= 0 )
			{
				return;
			}

			if( propertyName.Trim().Length <= 0 )
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties( _contents[0].GetType() )[propertyName];
			if( descriptor != null )
			{
				Sort( descriptor, direction, comparerToUse );
			}
		}


		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		public virtual List<int> FindMatches( IPredicate filter )
		{
			List<int> toReturn = new List<int>( this.Count );

			IPredicateExpression filterAsExpression = filter as IPredicateExpression;

			if((filter == null) || ((filterAsExpression!=null) && (filterAsExpression.Count<=0)))
			{
				// shortcut
				for( int i = 0; i < this.Count; i++ )
				{
					toReturn.Add( i );
				}
			}
			else
			{
				IPredicateInterpret predicateInterpreter = filter as IPredicateInterpret;
				if(predicateInterpreter==null)
				{
					throw new ORMInterpretationException("The passed in filter doesn't implement IPredicateInterpret");
				}

				for( int i = 0; i < this.Count; i++ )
				{
					if( predicateInterpreter.Interpret( this[i] ) )
					{
						toReturn.Add( i );
					}
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<T> GetEnumerator()
		{
			return _contents.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _contents.GetEnumerator();
		}


		#region IList explicit implementations
		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.IList"></see>.
		/// </summary>
		/// <param name="value">The <see cref="T:System.Object"></see> to add to the <see cref="T:System.Collections.IList"></see>.</param>
		/// <returns>
		/// The position into which the new element was inserted.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
		int IList.Add( object value )
		{
			if( value == null )
			{
				throw new ArgumentNullException( "value", "value can't be null" );
			}

			T toAdd = value as T;
			if( toAdd == null )
			{
				throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
			}
			return PerformAdd( toAdd );
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		void IList.Clear()
		{
			this.Clear();
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
			if( value == null )
			{
				return false;
			}

			T toCheck = value as T;
			if( toCheck == null )
			{
				throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
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
			if( value == null )
			{
				return -1;
			}
			T toCheck = value as T;
			if( toCheck == null )
			{
				throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
			}
			return this.IndexOf( toCheck );
		}

		/// <summary>
		/// Inserts an item to the <see cref="T:System.Collections.IList"></see> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which value should be inserted.</param>
		/// <param name="value">The <see cref="T:System.Object"></see> to insert into the <see cref="T:System.Collections.IList"></see>.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
		/// <exception cref="T:System.ArgumentNullException">value is null</exception>
		void IList.Insert( int index, object value )
		{
			if( value == null )
			{
				throw new ArgumentNullException( "value", "value can't be null" );
			}

			T toAdd = value as T;
			if( toAdd == null )
			{
				throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
			}
			this.Insert( index, toAdd );
		}


		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"></see>.
		/// </summary>
		/// <param name="value">The <see cref="T:System.Object"></see> to remove from the <see cref="T:System.Collections.IList"></see>.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
		void IList.Remove( object value )
		{
			if( value == null )
			{
				throw new ArgumentNullException( "value", "value can't be null" );
			}

			T toRemove = value as T;
			if( toRemove == null )
			{
				throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
			}
			this.Remove( toRemove );
		}

		/// <summary>
		/// Removes the <see cref="T:System.Collections.Generic.IList`1"></see> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"></see>.</exception>
		void IList.RemoveAt( int index )
		{
			this.RemoveAt( index );
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
		void ICollection.CopyTo( Array array, int index )
		{
			((ICollection)_contents).CopyTo( array, index );
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.IList"></see> has a fixed size.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.IList"></see> has a fixed size; otherwise, false.</returns>
		bool IList.IsFixedSize
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
		bool IList.IsReadOnly
		{
			get { return _isReadOnly; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Object"/> at the specified index.
		/// </summary>
		/// <value></value>
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if( value == null )
				{
					throw new ArgumentNullException("value", "value can't be null" );
				}

				T toAdd = value as T;
				if( toAdd == null )
				{
					throw new ArgumentException( "value isn't a type which is the same or derived from the type set for this collection." );
				}
				this[index] = toAdd;
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
		int ICollection.Count
		{
			get { return _contents.Count; }
		}

		/// <summary>
		/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe).
		/// </summary>
		/// <value></value>
		/// <returns>true if access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe); otherwise, false.</returns>
		bool ICollection.IsSynchronized
		{
			get { return ((ICollection)_contents).IsSynchronized; }
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.</returns>
		object ICollection.SyncRoot
		{
			get { throw new NotSupportedException( "Collections derived from this class aren't thread safe by default. Use your own locking system in your code." ); }
		}
		#endregion

		#region IComponent implementations

		/// <summary>
		/// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:System.ComponentModel.IComponent"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.ComponentModel.ISite"></see> object associated with the component; or null, if the component does not have a site.</returns>
		[XmlIgnore]
		[Browsable( false )]
		public virtual ISite Site
		{
			get
			{
				return _site;
			}
			set
			{
				_site = value;
				if( _site != null )
				{
					// set, but don't reset, as code can't go out of designmode during design time.
					EntityCollectionComponentDesigner.InDesignMode = true;
				}
			}
		}


		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public virtual void Dispose()
		{
			// Don't use Clear() as that routine raises events we don't need/want but we do want to switch off listening to events of 
			foreach(T entity in _contents)
			{
				UnsetEntityEventHandlers(entity);
			}
			_contents.Clear();
			if( Disposed != null )
			{
				Disposed( this, EventArgs.Empty );
			}
		}

		#endregion


		/// <summary>
		/// Inits the core class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		protected void InitCoreClass( int capacity )
		{
			if(capacity > 0)
			{
				_contents = new List<T>(capacity);
			}
			else
			{
				// don't specify a capacity, which will make List<T> allocate no memory.
				_contents = new List<T>();
			}
			InitCoreClass();
		}


		/// <summary>
		/// Called when [list changed].
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="typeOfChange">The type of change.</param>
		protected virtual void OnListChanged( int index, ListChangedType typeOfChange)
		{
			if( _surpressListChangedEvents )
			{
				return;
			}

			if( typeOfChange == ListChangedType.Reset )
			{
				_entityIndices = null;
			}

			if( ListChanged != null )
			{
				ListChanged( this, new ListChangedEventArgs( typeOfChange, index ) );
			}
		}


		/// <summary>
		/// Called at the start of a remove routine which removes an entity from this collection. Will raise EntityRemoving event. 
		/// </summary>
		/// <param name="entityToRemove">The entity to remove.</param>
		/// <returns>true if the remove action can continue (e.g. the event wasn't canceled) otherwise false.</returns>
		protected virtual bool OnEntityRemoving( T entityToRemove )
		{
			bool toReturn = true;
			if( EntityRemoving != null )
			{
				CancelableCollectionChangedEventArgs args = new CancelableCollectionChangedEventArgs( entityToRemove );
				EntityRemoving( this, args );
				toReturn = !args.Cancel;
			}

			return toReturn;
		}


		/// <summary>
		/// Called at the end of a remove routine which removes an entity from this collection. Will raise EntityRemoved event. 
		/// </summary>
		/// <param name="entityToRemove">The entity to remove.</param>
		protected virtual void OnEntityRemoved( T entityToRemove )
		{
			if( EntityRemoved != null )
			{
				EntityRemoved( this, new CollectionChangedEventArgs( entityToRemove ) );
			}
		}


		/// <summary>
		/// Called at the start of the Add or Insert routine which adds an entity to this collection. Will raise EntityAdding event.
		/// </summary>
		/// <param name="entityToAdd">The entity to add.</param>
		/// <returns>
		/// true if the add action can continue (e.g. the event wasn't canceled) otherwise false.
		/// </returns>
		protected virtual bool OnEntityAdding( T entityToAdd )
		{
			bool toReturn = true;
			if( EntityAdding != null )
			{
				CancelableCollectionChangedEventArgs args = new CancelableCollectionChangedEventArgs( entityToAdd );
				EntityAdding( this, args );
				toReturn = !args.Cancel;
			}

			return toReturn;
		}


		/// <summary>
		/// Called at the end of the Add or Insert routine which adds an entity to this collection. Will raise EntityAdded event.
		/// </summary>
		/// <param name="entityToAdd">The entity to add.</param>
		protected virtual void OnEntityAdded( T entityToAdd )
		{
			if( EntityAdded != null )
			{
				EntityAdded( this, new CollectionChangedEventArgs( entityToAdd ) );
			}
		}


		/// <summary>
		/// Event handler for the EntityContentsChanged event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnEntityInListOnEntityContentsChanged( object sender, EventArgs e )
		{
			if( ListChanged == null )
			{
				// no listeners. return. This is a speed optimization, as all the work to do to find the entity in the collection isn't necessary.
				return;
			}

			// an entity in the list has changed. Fire the list changed event
			OnListChanged( this.IndexOf((T)sender), ListChangedType.ItemChanged );
		}


		/// <summary>
		/// Called at the end of GetObjectData. Method is used when this object is serialized. Override this method to 
		/// tap into the serialization sequence. (binary/soap formatter specific).
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected virtual void OnGetObjectData( SerializationInfo info, StreamingContext context )
		{
			// nop
		}


		/// <summary>
		/// Called at the end of the deserialization constructor. Method is used when this object is deserialized. Override this method to 
		/// tap into the deserialization sequence. (binary/soap formatter specific).
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected virtual void OnDeserialized( SerializationInfo info, StreamingContext context )
		{
			// nop
		}


		/// <summary>
		/// Removes the passed in entity from the collection without notifying the entity to remove that it has been removed from this collection.
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		protected void SilentRemove( T toRemove )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.SilentRemove", "Method Enter" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, GetEntityDescription( toRemove, TraceHelper.GeneralSwitch.TraceVerbose ), "Entity to Remove Description" );

			if( _isReadOnly && !EntityCollectionComponentDesigner.InDesignMode )
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			bool succeeded = false;
			int index = this.IndexOf( toRemove );
			if( index >= 0 )
			{
				bool beginRemoveResult = OnEntityRemoving( toRemove );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.SilentRemove", "Canceled by EntityRemoving event. Method Exit" );
				}
				succeeded = _contents.Remove( toRemove );
				if( !succeeded )
				{
					throw new ApplicationException( "The remove failed, as List<T>.Remove returned false" );
				}
				// index isn't valid anymore.
				_entityIndices = null;

				OnListChanged( index, ListChangedType.ItemDeleted );
				toRemove.EntityContentsChanged -= new EventHandler( OnEntityInListOnEntityContentsChanged );
			}
			OnEntityRemoved( toRemove );
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.SilentRemove", "Method Exit" );
		}
		

		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="descriptor">descriptor for property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		/// <remarks>For backwards compatibility</remarks>
		protected void Sort( PropertyDescriptor descriptor, ListSortDirection direction, IComparer<object> comparerToUse )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Sort(3)", "Method Enter" );

			if( this.Count <= 0 )
			{
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Sort(3): List is empty.", "Method Exit" );
				return;
			}

			if( descriptor == null )
			{
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Sort(3): invalid property descriptor passed in: null.", "Method Exit" );
				return;
			}

			_listOperationInProgress = true;
			// do sorting. Use list for this and the build in QuickSort algo
			List<object> toSort = new List<object>( this.Count );
			Dictionary<object, List<int>> valueToEntity = new Dictionary<object, List<int>>();
			List<int> entityIndices = null;
			List<int> nullIndices = new List<int>();
			for( int i = 0; i < _contents.Count; i++ )
			{
				T currentEntity = this[i];
				object value = descriptor.GetValue( currentEntity );
				if(value == null)
				{
					nullIndices.Add(i);
				}
				else
				{
					if(valueToEntity.ContainsKey(value))
					{
						// already there, add index to arraylist with indices
						entityIndices = valueToEntity[value];
					}
					else
					{
						entityIndices = new List<int>();
						valueToEntity.Add(value, entityIndices);
						toSort.Add(value);
					}

					entityIndices.Add(i);
				}
			}

			// sort the values. 
			toSort.Sort( comparerToUse );

			// toSort is now sorted in ascending order. Check the direction to read from front to back or from back to front.
			List<T> newList = new List<T>( this.Count );
			if( direction == ListSortDirection.Ascending )
			{
				// first add null indices
				foreach(int index in nullIndices)
				{
					newList.Add(_contents[index]);
				}

				// then add data from front to back
				for( int i = 0; i < toSort.Count; i++ )
				{
					entityIndices = valueToEntity[toSort[i]];
					foreach( int index in entityIndices )
					{
						newList.Add( _contents[index] );
					}
				}
			}
			else
			{
				// first add data from back to front
				for( int i = toSort.Count - 1; i >= 0; i-- )
				{
					entityIndices = valueToEntity[toSort[i]];
					foreach( int index in entityIndices )
					{
						newList.Add( _contents[index] );
					}
				}

				// then add the null indices
				foreach(int index in nullIndices)
				{
					newList.Add(_contents[index]);
				}
			}

			// newList contains objects in new Order. Clear list first, then insert the items again.
			this.Clear();
			for( int i = 0; i < newList.Count; i++ )
			{
				_contents.Add( newList[i] );
			}

			_listOperationInProgress = false;

			// done. signal list change
			OnListChanged( 0, ListChangedType.Reset );

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "CollectionCore.Sort(3)", "Method Exit" );
		}


		/// <summary>
		/// Rebuilds the index which contains per objectid the index in this collection.
		/// </summary>
		private void RebuildEntityIndex()
		{
			_entityIndices = new Dictionary<Guid, int>( this.Count );
			for( int i = 0; i < this.Count; i++ )
			{
				T toAdd = this[i];
				if( _entityIndices.ContainsKey( toAdd.ObjectID ) )
				{
					continue;
				}
				_entityIndices.Add( toAdd.ObjectID, i );
			}
		}


		/// <summary>
		/// Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
		/// it from the list again, and will set its flag that it is added by databinding. 
		/// </summary>
		/// <remarks>Do not call this method from your own code. This is a databinding ONLY method.</remarks>
		/// <exception cref="InvalidOperationException">If this collection is set to ReadOnly</exception>
		public abstract T AddNew();
		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		/// <remarks>For backwards compatibility.</remarks>
		public abstract void Sort( int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse );
		/// <summary>
		/// Performs the set related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the setrelated entity action on.</param>
		protected abstract void PerformSetRelatedEntity( T entity );
		/// <summary>
		/// Performs the unset related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the unsetrelated entity action on.</param>
		protected abstract void PerformUnsetRelatedEntity( T entity );
		/// <summary>
		/// Performs the add action to the active context for this collection
		/// </summary>
		/// <param name="entity">The entity.</param>
		protected abstract void PerformAddToActiveContext( T entity );
		/// <summary>
		/// Gets the entity description for the entity passed in.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="switchFlag">if true, the method will produce TEntity.GetEntityDescription, otherwise it's a no-op</param>
		/// <returns></returns>
		protected abstract string GetEntityDescription( T entity, bool switchFlag );
		/// <summary>
		/// Places the item in the set RemovedEntitiesTracker.
		/// </summary>
		/// <param name="item">The item to add to the tracker.</param>
		protected abstract void PlaceInRemovedEntitiesTracker(T item);

		/// <summary>
		/// Inits the core class.
		/// </summary>
		private void InitCoreClass()
		{
			_deserializationInProgress = false;
			_doNotPerformAddIfPresent = false;
			_isReadOnly = false;
			_concurrencyPredicateFactoryToUse = null;
			_allowEdit = true;
			_allowNew = true;
			_allowRemove = true;
			_listOperationInProgress = false;
			_site = null;
			_surpressListChangedEvents = false;
		}



		/// <summary>
		/// Unsets the entity event handlers. This prevents the entities keeping a reference to this collection.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void UnsetEntityEventHandlers(T entity)
		{
			entity.EntityContentsChanged -= new EventHandler(OnEntityInListOnEntityContentsChanged);
		}


		/// <summary>
		/// Sets the entity event handlers so this collection listens to events happening to an entity inside this collection.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void SetEntityEventHandlers(T entity)
		{
			entity.EntityContentsChanged += new EventHandler(OnEntityInListOnEntityContentsChanged);
		}


		/// <summary>
		/// Performs the add.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		private int PerformAdd( T item )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "CollectionCore.PerformAdd", "Method Enter" );
			TraceHelper.WriteIf( TraceHelper.GeneralSwitch.TraceVerbose, GetEntityDescription( item, TraceHelper.GeneralSwitch.TraceVerbose ), "Entity to Add Description" );

			if( _isReadOnly && !_deserializationInProgress && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			if( _doNotPerformAddIfPresent && !_deserializationInProgress )
			{
				if( this.Contains( item ) )
				{
					int indexOfEntity = this.IndexOf( item );
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, indexOfEntity, "Index of added entity" );
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "CollectionCore.PerformAdd", "Method Exit" );
					return indexOfEntity;
				}
			}

			bool beginAddResult = OnEntityAdding( item );
			if( !beginAddResult )
			{
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "CollectionCore.PerformAdd", "Canceled by EntityAdding event. Method Exit" );
				return -1;
			}

			_contents.Add( item );
			int index = (_contents.Count - 1);
			if((_concurrencyPredicateFactoryToUse != null) && (item.ConcurrencyPredicateFactoryToUse == null))
			{
				item.ConcurrencyPredicateFactoryToUse = _concurrencyPredicateFactoryToUse;
			}

			// index isn't valid anymore. Though, the add is always at the end of the list, so just append the entity to the index IF present.
			if( (_entityIndices != null) && !_entityIndices.ContainsKey( item.ObjectID ) )
			{
				_entityIndices.Add( item.ObjectID, index );
			}

			PerformAddToActiveContext( item );

			SetEntityEventHandlers(item);

			if( !_deserializationInProgress )
			{
				// first signal the views on this collection and other interested parties that a new entity has been added. 
				OnListChanged(index, ListChangedType.ItemAdded);
				// then sync it with a related entity (if this collection is contained inside an entity).
				PerformSetRelatedEntity(item);
			}

			OnEntityAdded( item );

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, index, "Index of added entity" );
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "CollectionCore.PerformAdd", "Method Exit" );
			return index;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory instance to use when creating entity objects during a GetMulti() call or when AddNew is called.
		/// </summary>
		/// <remarks>Deprecated. Please use the new Dependency injection mechanism to inject factories, validators and other objects into entities</remarks>
		//[Obsolete("Deprecated. Please use the new Dependency injection mechanism to inject factories, validators and other objects into entities", false)]
		public IConcurrencyPredicateFactory ConcurrencyPredicateFactoryToUse
		{
			get
			{
				return _concurrencyPredicateFactoryToUse;
			}
			set
			{
				_concurrencyPredicateFactoryToUse = value;
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
		[XmlIgnore]
		public int Count
		{
			get { return _contents.Count; }
		}


		/// <summary>
		/// Gets or sets the object at the specified index.
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		public T this[int index]
		{
			get
			{
				return _contents[index];
			}
			set
			{
				if( _isReadOnly )
				{
					throw new InvalidOperationException( "This collection is read-only" );
				}

				if( value == null )
				{
					throw new ArgumentNullException( "value can't be null" );
				}

				// first dereference the current entity on the index specified so the entity on list[index] can't keep this collection 
				// into memory.
				if( _contents[index] != null )
				{
					_contents[index].EntityContentsChanged -= new EventHandler( OnEntityInListOnEntityContentsChanged );
					if( _entityIndices != null )
					{
						_entityIndices.Remove( _contents[index].ObjectID );
					}

				}
				_contents[index] = value;
				if(( _entityIndices != null ) && !_entityIndices.ContainsKey(value.ObjectID))
				{
					_entityIndices.Add( value.ObjectID, index );
				}
				
				if( !_deserializationInProgress )
				{
					PerformSetRelatedEntity( value );
					OnListChanged( index, ListChangedType.ItemAdded );
				}

				// subscribe to changed event so the list can signal changes to bound controls.
				value.EntityContentsChanged += new EventHandler(OnEntityInListOnEntityContentsChanged);
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
		[XmlIgnore]
		public bool IsReadOnly
		{
			get { return _isReadOnly; }
			set { _isReadOnly = value; }
		}


		/// <summary>
		/// When set to true, an entity passed to Add() or Insert() will be tested if it's already present. If so, the index is returned and the
		/// object is not added again. If set to false (default: true) this check is not performed. Setting this property to true can slow down fetch logic.
		/// DataAccessAdapter's fetch logic sets this property to false during a multi-entity fetch.
		/// </summary>
		public bool DoNotPerformAddIfPresent
		{
			get
			{
				return _doNotPerformAddIfPresent;
			}
			set
			{
				_doNotPerformAddIfPresent = value;
			}
		}


		/// <summary>
		/// Default: true. If set to false, no new entities will be added through databinding. 
		/// </summary>
		public virtual bool AllowNew
		{
			get
			{
				return _allowNew;
			}
			set
			{
				_allowNew = value;
			}
		}

		/// <summary>
		/// Default: false. If set to true, entities can be removed through databinding.
		/// </summary>
		public virtual bool AllowRemove
		{
			get
			{
				return _allowRemove;
			}
			set
			{
				_allowRemove = value;
			}
		}

		/// <summary>
		/// Default: true. If set to false, entities inside this collection won't be editable in a complex databinding scenario.
		/// </summary>
		public virtual bool AllowEdit
		{
			get
			{
				return _allowEdit;
			}
			set
			{
				_allowEdit = value;
			}
		}

		/// <summary>
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		[XmlIgnore]
		public int Capacity
		{
			get { return _contents.Capacity; }
			set { _contents.Capacity = value; }
		}


		/// <summary>
		/// Items contained by this collection. Returns simply this instance.
		/// </summary>
		[XmlIgnore]
		public virtual IList<T> Items
		{
			get { return this; }
		}

		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty. 
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		[XmlIgnore]
		public List<T> DirtyEntities
		{
			get
			{
				List<T> toReturn = new List<T>();
				foreach( T entity in _contents )
				{
					if( entity.IsDirty )
					{
						toReturn.Add( entity );
					}
				}
				return toReturn;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [deserialization in progress].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [deserialization in progress]; otherwise, <c>false</c>.
		/// </value>
		[XmlIgnore]
		protected bool DeserializationInProgress
		{
			get { return _deserializationInProgress; }
			set { _deserializationInProgress = value; }
		}


		/// <summary>
		/// Gets or sets a value indicating whether [surpress list changed events].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [surpress list changed events]; otherwise, <c>false</c>.
		/// </value>
		protected bool SurpressListChangedEventsInternal
		{
			get { return _surpressListChangedEvents; }
			set { _surpressListChangedEvents = value; }
		}


		/// <summary>
		/// Obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net
		/// </summary>
		/// <value></value>
		[Obsolete( "This property is now obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net.", false )]
		[Browsable( false ), XmlIgnore]
#if !CF
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
#endif
		public object EntityValidatorToUse
		{
			get { return null; }
			set { /* nop */ }
		}

		/// <summary>
		/// Obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net
		/// </summary>
		/// <value></value>
		[Obsolete( "This property is now obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net.", false )]
		[Browsable(false), XmlIgnore]
#if !CF
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
#endif
		public object ValidatorToUse
		{
			get { return null; }
			set { /* nop */ }
		}

		#endregion
	}
}
