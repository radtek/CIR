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
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Data;
using System.Collections.Specialized;

#if !CF
using System.ComponentModel.Design;
using System.Runtime.Serialization;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the entity collection base class.
	/// </summary>
#if !CF
	[ListBindable(true)]
	[Serializable]
	[Designer(typeof(EntityCollectionComponentDesigner))]
	[System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(typeof(EntityCollectionToolboxItem))]
#endif
	public abstract class EntityCollectionBase2 : CollectionBase, IEntityCollection2, ISerializable, IComponent, IListSource, 
			IXmlSerializable, IEntityViewSource
#if !CF
			,IFastSerializableEntityCollection2
#endif
	{
		#region Class Member Declarations
		private IEntityFactory2		_entityFactoryToUse;
		private bool				_allowNew, _allowRemove, _allowEdit, _isReadOnly, _doNotPerformAddIfPresent;
		private IEntity2			_containingEntity;
		private	string				_containingEntityMappedField;
		private IConcurrencyPredicateFactory	_concurrencyPredicateFactoryToUse;

		[NonSerialized]
		private bool				_allowSorting;
		[NonSerialized]
		private bool				_isSorted;
		[NonSerialized]
		private PropertyDescriptor	_propertySortedOn;
		[NonSerialized]
		private ListSortDirection	_sortDirection;
		[NonSerialized]
		private	ArrayList			_contentInOriginalOrder;			// valid when the collection gets sorted. 
		[NonSerialized]
		private bool				_listOperationInProgress;
		[NonSerialized]
		private bool				_deserializationInProgress;
		[NonSerialized]
		private ISite				_site;
		[NonSerialized]
		private Context				_activeContext;
		[NonSerialized]
		private	Hashtable			_cachedPkHashes;
		// fast-access index which stores per objectid the index in the collection. Is created the first time IndexOf is called and the index isn't there.
		// It's rebuild every time the index is considered invalid (when a remove/insert has taken place, or a reset is required due to a sort). 
		// Rebuild is postponed till the next time IndexOf is called. 
		[NonSerialized]
		private Hashtable			_entityIndices;			
		[NonSerialized]
		private IEntityView2		_defaultView;
		[NonSerialized]
		private IEntityCollection2	_removedEntitiesTracker;
		#endregion

		#region Event Declarations
		/// <summary>
		/// Event which is used in complex databinding.
		/// </summary>
		public event System.ComponentModel.ListChangedEventHandler ListChanged;
		/// <summary>
		/// Event which is raised at the start of the Remove or RemoveAt(index) routine. To cancel the remove action, set cancel to true.
		/// </summary>
		public event CancelableCollectionChangedEventHandler EntityRemoving;
		/// <summary>
		/// Event which is raised at the End of the Remove or RemoveAt(index) routine.
		/// </summary>
		public event CollectionChangedEventHandler EntityRemoved;
		/// <summary>
		/// Event which is raised at the start of the Add or Insert(index) routine. To cancel the addition action, set cancel to true.
		/// </summary>
		public event CancelableCollectionChangedEventHandler EntityAdding;
		/// <summary>
		/// Event which is raised at the End of the Add or Insert(index) routine.
		/// </summary>
		public event CollectionChangedEventHandler EntityAdded;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <remarks>En</remarks>
		public EntityCollectionBase2()
		{
			InitClass(null);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFactoryToUse">The entity factory object to use when this collection has to construct new objects.
		/// This is the case when the collection is bound to a grid-like control for example.</param>
		public EntityCollectionBase2(IEntityFactory2 entityFactoryToUse)
		{
			InitClass(entityFactoryToUse);
		}


		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollectionBase2(SerializationInfo info, StreamingContext context)
		{
			InitClass(null);

			try
			{
				_deserializationInProgress=true;

				if(SerializationHelper.Optimization==SerializationOptimization.None)
				{
					// deserialize the data back into this instance.
					int amountOfEntitiesInList = info.GetInt32("AmountEntitiesInList");

					_entityFactoryToUse = (IEntityFactory2)info.GetValue("_entityFactoryToUse", typeof(IEntityFactory2));
					_allowNew = info.GetBoolean("_allowNew");
					_allowRemove = info.GetBoolean("_allowRemove");
					_allowEdit = info.GetBoolean("_allowEdit");
					_containingEntity = (IEntity2)info.GetValue("_containingEntity", typeof(IEntity2));
					_containingEntityMappedField = info.GetString("_containingEntityMappedField");
					_doNotPerformAddIfPresent = info.GetBoolean("_doNotPerformAddIfPresent");
					bool readOnlyValue = info.GetBoolean("_isReadOnly");

					for(int i=0;i<amountOfEntitiesInList;i++)
					{
						IEntity2 entityToAdd = (IEntity2)info.GetValue("Entity" + i, typeof(IEntity2));
						// add it. It will wire the events automatically.
						this.Add(entityToAdd);
					}

					// set readonly now, otherwise it will affect Add.
					_isReadOnly = readOnlyValue;
				}
				else
				{
					SerializationHelper.Deserialize(this, info, context);
				}

				OnDeserialized(info, context);
			}
				// all exceptions are fatal
			finally
			{
				_deserializationInProgress=false;
			}
		}


		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity2 implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		public void AddRange(ICollection c)
		{
			base.InnerList.Capacity = Math.Max(base.InnerList.Capacity, base.InnerList.Count +c.Count);
			foreach(IEntity2 toAdd in c)
			{
				Add(toAdd);
			}
		}

		
		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity2 implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		public void AddRange(IEntityCollection2 c)
		{
			base.InnerList.Capacity = Math.Max(base.InnerList.Capacity, base.InnerList.Count +c.Count);
			foreach(IEntity2 toAdd in c)
			{
				Add(toAdd);
			}
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, a new datatable is created inside destination. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(DataSet destination)
		{
			ArrayList collectionProjections = new ArrayList();
			Hashtable entitiesPerType = null;
			BuildCollectionProjectors(collectionProjections, out entitiesPerType);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination hashtable in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(Hashtable destination)
		{
			ArrayList collectionProjections = new ArrayList();
			Hashtable entitiesPerType = null;
			BuildCollectionProjectors(collectionProjections, out entitiesPerType);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}
		
		
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(ArrayList collectionProjections, DataSet destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Hashtable entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this view and for each type in the complete graph found starting with each entity in this view,
		/// using the viewProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(ArrayList collectionProjections, Hashtable destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Hashtable entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);
			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}

		
		/// <summary>
		/// Builds the collection projectors for this collection.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void BuildCollectionProjectors(ArrayList collectionProjections, out Hashtable entitiesPerType)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);
			foreach(DictionaryEntry pair in entitiesPerType)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance((Type)pair.Key);
				// build projectors. Only project fields.
				ArrayList projectors = EntityFields2.ConvertToProjectors(dummy.Fields);
				ViewProjectionData projector = new ViewProjectionData((Type)pair.Key, projectors, null, true);
				collectionProjections.Add(projector);
			}
		}


		/// <summary>
		/// Creates the hierarchical projection for the entities per type passed in into the destination specified.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void CreateHierarchicalProjectionInternal(ArrayList collectionProjections, DataSet destination,
			Hashtable entitiesPerType)
		{
			destination.Tables.Clear();
			Hashtable relationsPerType = new Hashtable();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection2 toProject = (IEntityCollection2)entitiesPerType[projectionData.TypeOfTargetEntity];
				if(toProject==null)
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = new EntityCollectionForFetch(dummy.GetEntityFactory());
				}

				DataTable resultsTable = new DataTable(dummy.LLBLGenProEntityName);
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsTable, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Tables.Add(resultsTable);
				int numberOfPkFields = FieldUtilities.DetermineNumberOfPkFields(dummy.PrimaryKeyFields);
				if(numberOfPkFields>0)
				{
					DataColumn[] pkColumns = new DataColumn[numberOfPkFields];
					for(int i = (dummy.PrimaryKeyFields.Count - numberOfPkFields), j = 0; j < numberOfPkFields; j++)
					{
						IEntityField2 primaryKeyField = (IEntityField2)dummy.PrimaryKeyFields[i + j];
						pkColumns[j] = resultsTable.Columns[primaryKeyField.Name];
					}
					resultsTable.PrimaryKey = pkColumns;
				}
			}

			// create datarelations. 
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				// has to be there.
				ArrayList relations = (ArrayList)relationsPerType[projectionData.TypeOfTargetEntity];
				// create datarelations. 
				projectionData.CreateDataRelations(destination, relations);
			}
		}


		/// <summary>
		/// Creates the hierarchical projection for the entities per type passed in into the destination specified.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void CreateHierarchicalProjectionInternal(ArrayList collectionProjections, 
				Hashtable destination, Hashtable entitiesPerType)
		{
			destination.Clear();
			Hashtable relationsPerType = new Hashtable();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection2 toProject = (IEntityCollection2)entitiesPerType[projectionData.TypeOfTargetEntity];
				if(toProject==null)
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = new EntityCollectionForFetch(dummy.GetEntityFactory());
				}
				IEntityCollection2 resultsCollection = new EntityCollectionForFetch(dummy.GetEntityFactory());
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsCollection, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Add(dummy.GetType(), resultsCollection);
			}
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView()
		{
			return CreateView(null, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter)
		{
			return CreateView(filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter, ISortExpression sorter)
		{
			return CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
		{
			return new EntityView2(this, filter, sorter, dataChangeAction);
		}


		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain EntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the related entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		public void SetContainingEntityInfo(IEntity2 containingEntity, string fieldName)
		{
			_containingEntity = containingEntity;
			_containingEntityMappedField = fieldName;
			this.ActiveContext = _containingEntity.ActiveContext;
			AddContainedEntitiesToContext();
		}


		/// <summary>
		/// Adds an IEntity2 object to the list. Only new entities are added.
		/// </summary>
		/// <param name="entityToAdd">Entity2 to add</param>
		/// <returns>Index in list</returns>
		/// <exception cref="InvalidOperationException">If this collection is marked as ReadOnly</exception>
		public int Add(IEntity2 entityToAdd)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase2.Add", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase2)entityToAdd).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Add Description");

			if(_isReadOnly && !_deserializationInProgress && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			if(_doNotPerformAddIfPresent && !_deserializationInProgress)
			{
				if(List.Contains(entityToAdd))
				{
					int indexOfEntity = List.IndexOf(entityToAdd);
					TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, indexOfEntity, "Index of added entity");
					TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase2.Add", "Method Exit");
					return indexOfEntity;
				}
			}

			bool beginAddResult = OnEntityAdding( entityToAdd );
			if( !beginAddResult )
			{
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase2.PerformAdd", "Canceled by EntityAdding event. Method Exit" );
				return -1;
			}

			// it has to be added, add it.
			int index = List.Add(entityToAdd);
			_contentInOriginalOrder.Add(entityToAdd);
			if((_concurrencyPredicateFactoryToUse!=null) && (entityToAdd.ConcurrencyPredicateFactoryToUse==null))
			{
				entityToAdd.ConcurrencyPredicateFactoryToUse = _concurrencyPredicateFactoryToUse;
			}
			
			// index isn't valid anymore. Though, the add is always at the end of the list, so just append the entity to the index IF present.
			if( (_entityIndices != null) && !_entityIndices.ContainsKey( entityToAdd.ObjectID ) )
			{
				_entityIndices.Add( entityToAdd.ObjectID, index );
			}

			if(!_deserializationInProgress)
			{
				OnListChanged(index, ListChangedType.ItemAdded);
				if(_containingEntity!=null)
				{
					entityToAdd.SetRelatedEntity(_containingEntity, _containingEntityMappedField);
				}
			}

			// subscribe to the changed event.
			entityToAdd.EntityContentsChanged +=new EventHandler(EntityInListOnEntityContentsChanged);

			if(_activeContext!=null)
			{
				_activeContext.Add(entityToAdd);
			}

			OnEntityAdded(entityToAdd);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, index, "Index of added entity");
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase2.Add", "Method Exit");
			return index;
		}


		/// <summary>
		/// Inserts an IEntity2 on position Index. Only new entities are added.
		/// </summary>
		/// <param name="index">Index where to insert the Entity2</param>
		/// <param name="entityToAdd">Entity2 to insert</param>
		/// <exception cref="InvalidOperationException">If this collection is marked as ReadOnly</exception>
		public void Insert(int index, IEntity2 entityToAdd)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Insert", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase2)entityToAdd).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Insert Description");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in.");

			if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode && !_deserializationInProgress)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			bool insertTheEntity = true;
			if(_doNotPerformAddIfPresent)
			{
				insertTheEntity = !List.Contains(entityToAdd);
			}

			if(insertTheEntity)
			{
				insertTheEntity = OnEntityAdding(entityToAdd);
			}
			if(insertTheEntity)
			{
				List.Insert(index, entityToAdd);
				// index isn't valid anymore.
				_entityIndices = null;
				if(!_deserializationInProgress)
				{
					if(_containingEntity!=null)
					{
						entityToAdd.SetRelatedEntity(_containingEntity, _containingEntityMappedField);
					}

					OnListChanged(index, ListChangedType.ItemAdded);
				}

				if(_isSorted)
				{
					_contentInOriginalOrder.Add(entityToAdd);
				}
				else
				{
					_contentInOriginalOrder.Insert(index, entityToAdd);
				}
				// subscribe to the changed event.
				entityToAdd.EntityContentsChanged +=new EventHandler(EntityInListOnEntityContentsChanged);

				if(_activeContext!=null)
				{
					_activeContext.Add(entityToAdd);
				}
				OnEntityAdded(entityToAdd);
			}
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Insert", "Method Exit");
		}


		/// <summary>
		/// Remove given IEntity2 from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity2 object to remove from list.</param>
		/// <exception cref="InvalidOperationException">If this collection is marked as ReadOnly</exception>
		public void Remove(IEntity2 entityToRemove)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Remove", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase2)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");

			if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			int index = List.IndexOf(entityToRemove);
			if(index >=0)
			{
				bool beginRemoveResult = OnEntityRemoving( entityToRemove );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Remove", "Canceled by EntityRemoving event. Method Exit" );
					return;
				}
				if(_containingEntity!=null)
				{
					entityToRemove.UnsetRelatedEntity(_containingEntity, _containingEntityMappedField);
				}

				List.Remove(entityToRemove);
				_contentInOriginalOrder.Remove(entityToRemove);

				PlaceInRemovedEntitiesTracker(entityToRemove);

				// index isn't valid anymore.
				_entityIndices = null;

				OnListChanged(index, ListChangedType.ItemDeleted);
				// remove subscribtion to the changed event.
				entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			}
			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Remove", "Method Exit");
		} 


		/// <summary>
		/// Removes the IEntity2 instance at the index given.
		/// </summary>
		/// <param name="index">Index in list to remove the element</param>
		/// <exception cref="InvalidOperationException">If this collection is marked as ReadOnly</exception>
		public new void RemoveAt(int index)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.RemoveAt", "Method Enter");

			if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			IEntity2 entityToRemove = (IEntity2)List[index];
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase2)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in.");

			bool beginRemoveResult = OnEntityRemoving( entityToRemove );
			if( !beginRemoveResult )
			{
				// canceled. 
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.RemoveAt", "Canceled by EntityRemoving event. Method Exit" );
				return;
			}

			if(_containingEntity!=null)
			{
				entityToRemove.UnsetRelatedEntity(_containingEntity, _containingEntityMappedField);
			}

			base.RemoveAt(index);
			if(_isSorted)
			{
				_contentInOriginalOrder.RemoveAt(_contentInOriginalOrder.IndexOf(List[index]));
			}
			else
			{
				_contentInOriginalOrder.RemoveAt(index);
			}
			
			PlaceInRemovedEntitiesTracker(entityToRemove);

			// index isn't valid anymore.
			_entityIndices = null;

			OnListChanged(index, ListChangedType.ItemDeleted);

			// remove subscribtion to the changed event.
			entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.RemoveAt", "Method Exit");
		}


		/// <summary>
		/// Returns true if the list contains the given IEntity2 Object
		/// </summary>
		/// <param name="entityToFind">Entity2 object to check.</param>
		/// <returns>true if Entity2 exists in list.</returns>
		public bool Contains(IEntity2 entityToFind)
		{
			return List.Contains(entityToFind);
		}


		/// <summary>
		/// Returns index in the list of given IEntity2 object.
		/// </summary>
		/// <param name="entityToFind">Entity2 Object to check</param>
		/// <returns>index in list.</returns>
		public int IndexOf(IEntity2 entityToFind)
		{
			int toReturn = -1;
			if( _entityIndices == null )
			{
				RebuildEntityIndex();
			}

			object index = _entityIndices[entityToFind.ObjectID];
			if(index==null)
			{
				toReturn = List.IndexOf(entityToFind);
			}
			else
			{
				toReturn = (int)index;
			}
			return toReturn;
		}


		/// <summary>
		/// Performs a clear of the internals and its internal objects.
		/// </summary>
		protected override void OnClear()
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.OnClear", "Method Enter");
			if(!_listOperationInProgress)
			{
				if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
				{
					throw new InvalidOperationException("This collection is read-only.");
				}
				
				// unset related entity information
				if(_containingEntity!=null)
				{
					for (int i = 0; i < List.Count; i++)
					{
						((IEntity2)List[i]).UnsetRelatedEntity(_containingEntity, _containingEntityMappedField);
						((IEntity2)List[i]).EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
					}
				}
				else
				{
					for (int i = 0; i < List.Count; i++)
					{
						((IEntity2)List[i]).EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
					}
				}

				_contentInOriginalOrder.Clear();
			}
			base.OnClear ();
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.OnClear", "Method Exit");
		}


		/// <summary>
		/// Performs signaling of a list change, unless _listOperationInProgress is set to true
		/// </summary>
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			_isSorted=false;
			_propertySortedOn=null;
			_sortDirection=ListSortDirection.Ascending;
			if(_listOperationInProgress)
			{
				return;
			}
			OnListChanged(0, ListChangedType.Reset);
		}


		/// <summary>
		/// copy the complete list of IEntity2 objects to an array of IEntity2 objects.
		/// </summary>
		/// <param name="destination">Array of IEntity2 Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		public void CopyTo(IEntity2[] destination, int index)
		{
			List.CopyTo(destination, index);
		}


		/// <summary>
		/// ISerializable member. 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{
				info.AddValue("_entityFactoryToUse", _entityFactoryToUse);
				info.AddValue("_allowNew", _allowNew);
				info.AddValue("_allowRemove", _allowRemove);
				info.AddValue("_allowEdit", _allowEdit);
				info.AddValue("_isReadOnly", _isReadOnly);
				info.AddValue("_containingEntity", _containingEntity);
				info.AddValue("_containingEntityMappedField", _containingEntityMappedField);
				info.AddValue("_doNotPerformAddIfPresent", _doNotPerformAddIfPresent);
				info.AddValue("AmountEntitiesInList", this.Count);

				if(this.Count > 0)
				{
					// serialize the entities
					for(int i=0;i<this.Count;i++)
					{
						info.AddValue("Entity" + i, List[i]);
					}
				}
			}
			else
			{
				SerializationHelper.Serialize(this, info, context);
			}
			OnGetObjectData(info, context);
		}


		/// <summary>
		/// Applies sorting like IBindingList.ApplySort, on the field with the index fieldIndex and with the direction specified.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		public void Sort(int fieldIndex, ListSortDirection direction)
		{
			Sort(fieldIndex, direction, null);
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		public void Sort(int fieldIndex, ListSortDirection direction, IComparer comparerToUse)
		{
			if(!_allowSorting)
			{
				throw new NotSupportedException("Sort requires that SupportsSorting is set to true.");
			}

			if(List.Count<=0)
			{
				return;
			}

			if((fieldIndex<0)||(fieldIndex>=((IEntity2)_contentInOriginalOrder[0]).Fields.Count))
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties(_contentInOriginalOrder[0].GetType())[((IEntity2)_contentInOriginalOrder[0]).Fields[fieldIndex].Name];
			Sort(descriptor, direction, comparerToUse);
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="propertyName">property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		public void Sort(string propertyName, ListSortDirection direction, IComparer comparerToUse)
		{
			if(!_allowSorting)
			{
				throw new NotSupportedException("Sort requires that SupportsSorting is set to true.");
			}

			if(List.Count<=0)
			{
				return;
			}

			if(propertyName.Trim().Length<=0)
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties(_contentInOriginalOrder[0].GetType())[propertyName];
			if(descriptor!=null)
			{
				Sort(descriptor, direction, comparerToUse);
			}
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="descriptor">descriptor for property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		private void Sort(PropertyDescriptor descriptor, ListSortDirection direction, IComparer comparerToUse)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Sort(3)", "Method Enter");

			if(!_allowSorting)
			{
				throw new NotSupportedException("Sort requires that SupportsSorting is set to true.");
			}

			if(List.Count<=0)
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Sort(3): List is empty.", "Method Exit");
				return;
			}

			if(descriptor==null)
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Sort(3): invalid property descriptor passed in: null.", "Method Exit");
				return;
			}

			_listOperationInProgress=true;
			// do sorting. Use array list for this and the build in QuickSort algo
			ArrayList toSort = new ArrayList(_contentInOriginalOrder.Count);
			Hashtable valueToEntity = new Hashtable();
			ArrayList entityIndices = null;
			for (int i = 0; i < _contentInOriginalOrder.Count; i++)
			{
				IEntity2 currentEntity = (IEntity2)_contentInOriginalOrder[i];
				object value = descriptor.GetValue(currentEntity);
				if(valueToEntity.ContainsKey(value))
				{
					// already there, add index to arraylist with indices
					entityIndices = (ArrayList)valueToEntity[value];
				}
				else
				{
					entityIndices = new ArrayList();
					valueToEntity.Add(value, entityIndices);
					toSort.Add(value);
				}

				entityIndices.Add(i);
			}

			// sort the values. 
			toSort.Sort(comparerToUse);

			// toSort is now sorted in ascending order. Check the direction to read from front to back or from back to front.
			ArrayList newList = new ArrayList(_contentInOriginalOrder.Count);
			if(direction==ListSortDirection.Ascending)
			{
				// front to back
				for (int i = 0; i < toSort.Count; i++)
				{
					entityIndices = (ArrayList)valueToEntity[toSort[i]];
					foreach(int index in entityIndices)
					{
						newList.Add(_contentInOriginalOrder[index]);
					}
				}
			}
			else
			{
				// back to front
				for (int i = toSort.Count-1; i >= 0; i--)
				{
					entityIndices = (ArrayList)valueToEntity[toSort[i]];
					foreach(int index in entityIndices)
					{
						newList.Add(_contentInOriginalOrder[index]);
					}
				}
			}

			// newList contains objects in new Order. Clear list first, then insert the items again.
			List.Clear();
			for (int i = 0; i < newList.Count; i++)
			{
				List.Add(newList[i]);
			}

			_listOperationInProgress=false;
			_isSorted=true;
			_sortDirection = direction;
			_propertySortedOn = descriptor;

			// done. signal list change
			OnListChanged(0, ListChangedType.Reset);

			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Sort(3)", "Method Exit");
		}


		/// <summary>
		/// Constructs the actual property descriptor collection.
		/// </summary>
		/// <param name="entityToCheck">entity instance which properties should be included in the collection</param>
		/// <param name="typeOfEntity">full type of the entity</param>
		/// <returns>filled in property descriptor collection</returns>
		public virtual PropertyDescriptorCollection GetPropertyDescriptors(IEntity2 entityToCheck, Type typeOfEntity)
		{
			return GetPropertyDescriptors(entityToCheck, typeOfEntity, false);
		}

		/// <summary>
		/// Constructs the actual property descriptor collection. Skips collection properties when the flag skipCollections is true.
		/// This is the case when the collection is in design mode and the path between bound collection and requested collection is 2 long, so
		/// another level would cause a loop (in m:n related entities) and will make vs.net hang.
		/// </summary>
		/// <param name="entityToCheck">entity instance which properties should be included in the collection</param>
		/// <param name="typeOfEntity">full type of the entity</param>
		/// <param name="skipCollections">true when the properties are for an entity in a collection at level 1 in a listAccessors path</param>
		/// <returns>filled in property descriptor collection</returns>
		public virtual PropertyDescriptorCollection GetPropertyDescriptors(IEntity2 entityToCheck, Type typeOfEntity, bool skipCollections)
		{
			PropertyDescriptorCollection instancePropertiesCollection = TypeDescriptor.GetProperties(typeOfEntity);
			ArrayList instanceProperties = new ArrayList();
			Hashtable namesAdded = new Hashtable();

			foreach(IEntityField2 currentField in (EntityFields2)entityToCheck.Fields)
			{
				EntityPropertyDescriptor2 newDescriptor = new EntityPropertyDescriptor2(currentField, typeOfEntity, false);
				// check if the field is overriden. If so, replace it with THIS field. 
				if(namesAdded.ContainsKey(currentField.Name))
				{
					// replace
					instanceProperties.Remove( (EntityPropertyDescriptor2)namesAdded[currentField.Name]);
					instanceProperties.Add(newDescriptor);
					namesAdded[currentField.Name] = newDescriptor;
				}
				else
				{
					// add
					instanceProperties.Add(newDescriptor);
					namesAdded.Add(currentField.Name, newDescriptor);
				}
			}
#if CF
			// grab the propery info's. As the CF can't read the attributes from property descriptors, we have to use these. 
			PropertyInfo[] propertyInfos = typeOfEntity.GetProperties();

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
					if(skipCollections)
					{
						// check if the property is of a type which 
						if(property.PropertyType.IsSubclassOf(typeof(EntityCollectionBase2)))
						{
							// found a collection, skip it
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
			foreach(PropertyDescriptor property in instancePropertiesCollection)
			{
				if(!namesAdded.ContainsKey(property.Name))
				{
					if(!property.IsBrowsable)
					{
						continue;
					}
					if(skipCollections)
					{
						// check if the property is of a type which 
						if(property.PropertyType.IsSubclassOf(typeof(EntityCollectionBase2)))
						{
							// found a collection, skip it
							continue;
						}
					}
					// add it
					instanceProperties.Add(property);
				}
			}
#endif
			return new PropertyDescriptorCollection((PropertyDescriptor[])instanceProperties.ToArray(typeof(PropertyDescriptor))); 
		}


		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		public ArrayList FindMatches( IPredicate filter )
		{
			ArrayList toReturn = new ArrayList( this.Count );

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


		#region IBindingList methods
		/// <summary>
		/// IBindingList member. 
		/// </summary>
		/// <exception cref="NotSupportedException">thrown when called. Not supported.</exception>
		public virtual void AddIndex(PropertyDescriptor property)
		{
			throw new NotSupportedException("AddIndex is not supported.");
		}


		/// <summary>
		/// IBindingList member. Sorts on the given property
		/// </summary>
		/// <exception cref="NotSupportedException">thrown when called and SupportsSorting is set to false.</exception>
		public virtual void ApplySort(PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
		{
			if(!_allowSorting)
			{
				throw new NotSupportedException("ApplySort requires that SupportsSorting is set to true.");
			}

			if(List.Count<=0)
			{
				return;
			}

			Sort(property, direction, null);
		}


		/// <summary>
		/// IBindingList member. 
		/// </summary>
		/// <remarks>Does a linear search through all the loaded entities in this collection.</remarks>
		public virtual int Find(PropertyDescriptor property, object key)
		{
			int index = -1;
			for (int i = 0; i < List.Count; i++)
			{
				if(((IEntity2)List[i]).Fields[property.Name].CurrentValue.Equals(key))
				{
					index=i;
					break;
				}
			}

			return index;
		}


		/// <summary>
		/// IBindingList member. 
		/// </summary>
		/// <exception cref="NotSupportedException">thrown when called and SupportsSorting is set to false.</exception>
		public virtual void RemoveSort()
		{
			if(!_allowSorting)
			{
				throw new NotSupportedException("RemoveSort requires that SupportsSorting is set to true.");
			}

			if(!_isSorted)
			{
				return;
			}

			if(List.Count<=0)
			{
				return;
			}

			_listOperationInProgress=true;
			List.Clear();
			for (int i = 0; i < _contentInOriginalOrder.Count; i++)
			{
				List.Add(_contentInOriginalOrder[i]);
			}
			_listOperationInProgress=false;
			_isSorted=false;
			_propertySortedOn = null;
			_sortDirection = ListSortDirection.Ascending;

			// done. signal list change
			OnListChanged(0, ListChangedType.Reset);
		}


		/// <summary>
		/// IBindingList member. Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
		/// it from the list again, and will set its flag that it is added by databinding. 
		/// </summary>
		/// <remarks>Do not call this method from your own code. This is a databinding ONLY method.</remarks>
		/// <exception cref="InvalidOperationException">If this collection is set to ReadOnly</exception>
		public virtual object AddNew()
		{
			if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			IEntity2 newEntity = _entityFactoryToUse.Create();
			((EntityBase2)newEntity).IsNewViaDataBinding=true;
			((EntityBase2)newEntity).ParentCollection=this;
			this.Add(newEntity);
			return newEntity;
		}


		/// <summary>
		/// IBindingList member. 
		/// </summary>
		/// <exception cref="NotSupportedException">thrown when called. Not supported.</exception>
		public virtual void RemoveIndex(PropertyDescriptor property)
		{
			throw new NotSupportedException("RemoveIndex is not supported.");
		}
		#endregion


		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(out string entityCollectionXml)
		{
			WriteXml(XmlFormatAspect.None, "EntityCollection", out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(string rootNodeName, out string entityCollectionXml)
		{
			WriteXml(XmlFormatAspect.None, rootNodeName, out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, out string entityCollectionXml)
		{
			WriteXml(aspects, "EntityCollection", out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
				WriteXml(writer, aspects, rootNodeName);
				writer.Flush();
				stream.Seek(0, SeekOrigin.Begin);
				using(StreamReader reader = new StreamReader(stream))
				{
					entityCollectionXml = reader.ReadToEnd();
				}
				stream.Close();
			}
		}
		

		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(XmlFormatAspect.None, "EntityCollection", parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(XmlFormatAspect.None, rootNodeName, parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(aspects, "EntityCollection", parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				XmlWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
				WriteXml(writer, aspects, rootNodeName);
				writer.Flush();
				stream.Seek(0, SeekOrigin.Begin);
				XmlDocument tmpDoc = new XmlDocument();
				tmpDoc.Load(stream);
				entityCollectionNode = parentDocument.ImportNode(tmpDoc.FirstChild, true);
				stream.Close();
			}
		}


		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		public void WriteXml(XmlWriter writer, XmlFormatAspect aspects)
		{
			WriteXml(writer, aspects, "EntityCollection");
		}


		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		public void WriteXml(XmlWriter writer, XmlFormatAspect aspects, string rootNodeName)
		{
			EntityCollection2Xml(rootNodeName, writer, new Hashtable(), aspects, true, true);
		}


		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities,
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="emitFactory">if set to true, the XML will contain the factory name, otherwise it won't. Used in Compact25 format</param>
		/// <param name="isRootElement">if set to true, the start element produced is the absolute root element of the xml to produce.</param>
		internal void EntityCollection2Xml( string rootNodeName, XmlWriter writer, Hashtable processedObjectIDs, XmlFormatAspect aspects, 
						bool emitFactory, bool isRootElement)
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.EntityCollection2Xml", "Method Enter" );

			bool compactXml = ((aspects & XmlFormatAspect.Compact) == XmlFormatAspect.Compact);
			bool compact25Xml = ((aspects & XmlFormatAspect.Compact25) == XmlFormatAspect.Compact25);
			bool verboseXml = !(compact25Xml || compactXml);
			bool datesInXmlDataType = ((aspects & XmlFormatAspect.DatesInXmlDataType) == XmlFormatAspect.DatesInXmlDataType);
			bool mlInCDataBlocks = ((aspects & XmlFormatAspect.MLTextInCDataBlocks) == XmlFormatAspect.MLTextInCDataBlocks);
			if(compact25Xml && compactXml)
			{
				// only one allowed
				compactXml = false;
			}

			writer.WriteStartElement(rootNodeName);  // root node
			if(compact25Xml)
			{
				if( (this.EntityFactoryToUse != null) && emitFactory)
				{
					// write factory as attribute in start element.
					writer.WriteAttributeString("Factory", FieldUtilities.CreateFullTypeName(this.EntityFactoryToUse.GetType()));
				}
				if(isRootElement)
				{
					writer.WriteAttributeString("Format", "Compact25");
				}
			}
			if(verboseXml)
			{
				// add assembly and type as attributes to root node
				writer.WriteAttributeString("Assembly", this.GetType().Assembly.FullName);
				writer.WriteAttributeString("Type", this.GetType().FullName);
			}

			if(!compact25Xml)
			{
				writer.WriteStartElement("Entities");	// <Entities> element. 
			}

			// write all entity elements
			for( int i = 0; i < this.Count; i++ )
			{
				EntityBase2 entity = (EntityBase2)this[i];
				entity.Entity2Xml(entity.LLBLGenProEntityName, writer, processedObjectIDs, aspects, false);
			}
			if(!compact25Xml)
			{
				writer.WriteEndElement();	// </Entities> element
			}

			if(!compact25Xml)
			{
				writer.WriteStartElement("EntityFactoryToUse");		// <EntityFactoryToUse> element
				if(this.EntityFactoryToUse == null)
				{
					writer.WriteAttributeString("Assembly", "Unknown");
				}
				else
				{
					writer.WriteAttributeString("Assembly", this.EntityFactoryToUse.GetType().Assembly.FullName);
					writer.WriteAttributeString("Type", this.EntityFactoryToUse.GetType().FullName);
				}
				writer.WriteEndElement();		// </EntityFactoryToUse>

				if(verboseXml && (this.ConcurrencyPredicateFactoryToUse != null))
				{
					writer.WriteStartElement("ConcurrencyPredicateFactoryToUse");	// <ConcurrencyPredicateFactoryToUse>
					writer.WriteAttributeString("Assembly", this.ConcurrencyPredicateFactoryToUse.GetType().Assembly.FullName);
					writer.WriteAttributeString("Type", this.ConcurrencyPredicateFactoryToUse.GetType().FullName);
					writer.WriteEndElement();	// </ConcurrencyPredicateFactoryToUse>
				}
			}

			// append the rest of the properties to the root element. Do this via reflection. 
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( this.GetType() );
#if CF
			PropertyInfo[] propertyInfos = this.GetType().GetProperties();
			Hashtable propertyInfoHT = new Hashtable(propertyInfos.Length);
			foreach(PropertyInfo pinfo in propertyInfos)
			{
				propertyInfoHT.Add(pinfo.Name, pinfo);
			}
#endif
			Hashtable propertyNamesToExclude = new Hashtable();
			propertyNamesToExclude.Add("ConcurrencyPredicateFactoryToUse", null);
			propertyNamesToExclude.Add("EntityFactoryToUse", null);

			for( int i = 0; i < properties.Count; i++ )
			{
				if(propertyNamesToExclude.ContainsKey(properties[i].Name))
				{
					continue;
				}
#if !CF
				if( properties[i].Attributes.Contains( new XmlIgnoreAttribute() ) )
				{
					// ignore this property
					continue;
				}
#else
				PropertyInfo currentPropertyInfo = (PropertyInfo)propertyInfoHT[properties[i].Name];
				object[] customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(XmlIgnoreAttribute), true);
				if(customAttributes.Length>0)
				{
					// ignore
					continue;
				}
#endif
				// Normal not yet handled property. Add it, if appropriate
				if( compactXml || compact25Xml )
				{
					// only IBindingList.Allow* properties are added, or properties which are marked with the IncludeInCompactXmlAttribute attribute.
#if CF
					customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(IncludeInCompactXmlAttribute), true);
					bool includeInXml = (customAttributes.Length > 0);
#else
					bool includeInXml = properties[i].Attributes.Contains( new IncludeInCompactXmlAttribute() );
#endif
					switch(properties[i].Name)
					{
						case "AllowNew":
						case "AllowEdit":
						case "AllowRemove":
						case "DoNotPerformAddIfPresent":
							if(compact25Xml)
							{
								// excluded
								continue;
							}
							break;
						default:
							if(!includeInXml)
							{
								continue;
							}
							break;
					}
				}
				writer.WriteStartElement(properties[i].Name);	// <propertyName>
				XmlHelper.WriteValueAsStringToXml(properties[i].PropertyType, properties[i].GetValue(this), verboseXml, !compact25Xml, writer, datesInXmlDataType, mlInCDataBlocks);
				writer.WriteEndElement();		// </propertyName>
			}

			if(compact25Xml)
			{
				// emit state element
				BitVector32 stateFlags = new BitVector32();
				stateFlags[1] = this.AllowEdit;
				stateFlags[2] = this.AllowNew;
				stateFlags[4] = this.AllowRemove;
				stateFlags[8] = this.DoNotPerformAddIfPresent;

				writer.WriteStartElement("_lps");		// <_lps>
				writer.WriteAttributeString("f", stateFlags.Data.ToString());
				writer.WriteEndElement();	// </_lps>
			}

			writer.WriteEndElement(); // root node

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.EntityCollection2Xml", "Method Exit" );
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		public void ReadXml(string xmlData)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				StreamWriter writer = new StreamWriter(stream);
				writer.Write(xmlData);
				writer.Flush();
				stream.Seek(0, SeekOrigin.Begin);
				XmlReader reader = new XmlTextReader(stream);
				XmlFormatAspect format = XmlHelper.GetXmlFormat(reader);
				switch(format)
				{
					case XmlFormatAspect.Compact25:
						ReadXml(reader, format);
						break;
					case XmlFormatAspect.Compact:
					case XmlFormatAspect.None:
						// read into doc, use xmldocument route.
						XmlDocument tmpDoc = new XmlDocument();
						tmpDoc.Load(reader);
						ReadXml(tmpDoc.DocumentElement, format);
						break;
				}
				stream.Close();
			}
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity collection and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		public void ReadXml(XmlNode node)
		{
			ReadXml(node.OuterXml);
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity collection and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		/// <param name="format">The format.</param>
		private void ReadXml(XmlNode node, XmlFormatAspect format)
		{
			if(format == XmlFormatAspect.Compact25)
			{
				ReadXml(node);
			}
			ArrayList nodeEntityReferences = new ArrayList();
			Hashtable processedObjectIDs = new Hashtable();
			Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);

			// walk all references found and set them to the correct objects.
			XmlHelper.SetReadReferences(nodeEntityReferences, processedObjectIDs);
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">Reader with xml used to produce an object graph</param>
		public void ReadXml(XmlReader reader)
		{
			// do format check 
			ReadXml(reader, XmlHelper.GetXmlFormat(reader));
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="format">The format the xml of the reader is in.</param>
		public void ReadXml(XmlReader reader, XmlFormatAspect format)
		{
			ArrayList nodeEntityReferences = new ArrayList();
			Hashtable processedObjectIDs = new Hashtable();

			switch(format)
			{
				case XmlFormatAspect.Compact25:
					Xml2EntityCollection(reader, processedObjectIDs, nodeEntityReferences);
					XmlHelper.SetReadReferences(nodeEntityReferences, processedObjectIDs);
					break;
				case XmlFormatAspect.Compact:
				case XmlFormatAspect.None:
					// read into doc, use xmldocument route.
					XmlDocument tmpDoc = new XmlDocument();
					tmpDoc.Load(reader);
					ReadXml(tmpDoc.DocumentElement);
					break;
			}
		}
	

		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data.
		/// </summary>
		/// <param name="reader">The reader to read xml from.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		/// <remarks>Assumes Compact25 formatted xml is present in the reader.</remarks>
		internal void Xml2EntityCollection(XmlReader reader, Hashtable processedObjectIDs, ArrayList nodeEntityReferences)
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlReader..)", "Method Enter");
				this.DeserializationInProgress = true;

				if(reader.ReadState == ReadState.Initial)
				{
					reader.Read();
					if(reader.NodeType == XmlNodeType.XmlDeclaration)
					{
						reader.Read();
					}
				}

				// reader has to be on a start element.
				if(reader.NodeType != XmlNodeType.Element)
				{
					throw new ORMGeneralOperationException(
							string.Format("The Xml deserialization routine EntityCollectionBase2.Xml2EntityCollection encountered a problem: the reader passed in isn't positioned on a valid Xml element but on the element of type '{0}' and name '{1]'.", reader.NodeType.ToString(), reader.LocalName));
				}

				string startElementName = reader.LocalName;

				// position is on first node. 
				string factoryTypeName = reader.GetAttribute("Factory");
				if(factoryTypeName!=null)
				{
					this.EntityFactoryToUse = (IEntityFactory2)Activator.CreateInstance(Type.GetType(factoryTypeName));
				}

				if(this.EntityFactoryToUse == null)
				{
					throw new ORMGeneralOperationException("There's no entity factory set nor defined in the XML. Can't deserialize entity collection XML.");
				}

				// read childnodes. 
				int index = -1;
				while(reader.Read() && !((reader.LocalName==startElementName) && (reader.NodeType==XmlNodeType.EndElement)))
				{
					switch(reader.NodeType)
					{
						case XmlNodeType.Element:
							if(reader.LocalName == "_lps")
							{
								// llblgen pro state block
								int flagValues = Convert.ToInt32(reader.GetAttribute("f"));
								BitVector32 stateFlags = new BitVector32(flagValues);
								this.AllowEdit = stateFlags[1];
								this.AllowNew = stateFlags[2];
								this.AllowRemove = stateFlags[4];
								this.DoNotPerformAddIfPresent = stateFlags[8];
								if(!reader.IsEmptyElement)
								{
									reader.Read();	// read away the end node as the reader is still positioned on the end node.
								}
							}
							else
							{
								index++;
								// entity start node
								string refID = reader.GetAttribute("Ref");
								if(refID != null)
								{
									// entity we've already seen
									NodeEntityReference newReference = new NodeEntityReference();
									newReference.ObjectID = new Guid(refID);
									newReference.PropertyHoldingInstance = this;
									newReference.IsCollectionAdd = true;
									newReference.Position = index;
									newReference.ReferencingProperty = null;
									nodeEntityReferences.Add(newReference);
									if(!reader.IsEmptyElement)
									{
										reader.Read();	// read away the end node as the reader is still positioned on the end node.
									}
								}
								else
								{
									EntityBase2 newEntity = null;
									string entityTypeValueAsString = reader.GetAttribute("EntityType");
									if(entityTypeValueAsString != null)
									{
										newEntity = (EntityBase2)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsString));
									}
									else
									{
										newEntity = (EntityBase2)this.EntityFactoryToUse.Create();
									}
									newEntity.IsDeserializing = true;
									try
									{
										newEntity.Xml2Entity(reader, processedObjectIDs, nodeEntityReferences);
										this.Add(newEntity);
									}
									finally
									{
										newEntity.IsDeserializing = false;
									}
								}
							}
							break;
						case XmlNodeType.EndElement:
							// can't encounter end elements.
							if(reader.LocalName != startElementName)
							{
								throw new ORMGeneralOperationException(
									string.Format("The Xml deserialization routine EntityCollectionBase2.Xml2EntityCollection encountered a problem: the reader encountered an unexpected EndElement, with name '{0}'.", reader.LocalName));
							}
							break;
					}
				}
			}
			finally
			{
				this.DeserializationInProgress = false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlReader...", "Method Exit");
			}
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">Arraylist with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		internal void Xml2EntityCollection(XmlNode node, Hashtable processedObjectIDs, ArrayList nodeEntityReferences)
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlNode...", "Method Enter");

				_deserializationInProgress = true;
				XmlHelper typeConverter = new XmlHelper();

				// get this instance's properties.
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());

				// we need the factory FIRST. Grab that factory specification, then move on to the rest of the nodes.
				XmlNamespaceManager nsmgr = null;
				string nsprefix = string.Empty;
				if(node.NamespaceURI.Length>0)
				{
					// has namespace specified. As .NET has some nice XML bugs, we have to specify a 
					// namespace manager and a fake prefix.
					nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
					if(node.Prefix.Length<=0)
					{
						// use fake ns
						nsprefix = "col";
					}
					else
					{
						nsprefix = node.Prefix;
					}
					nsmgr.AddNamespace(nsprefix, node.NamespaceURI);
					nsprefix += ":";
				}
#if CF
				XmlNode entityFactoryElement = XmlCFUtilities.SelectSingleNode(node, "EntityFactoryToUse");
#else
				XmlNode entityFactoryElement = node.SelectSingleNode(nsprefix + "EntityFactoryToUse", nsmgr);
#endif
				if(entityFactoryElement==null)
				{
					// serious problem, abort
					return;
				}
				string entityFactoryAssemblyName = entityFactoryElement.Attributes["Assembly"].Value;
				if(entityFactoryAssemblyName!="Unknown")
				{
					Assembly entityFactoryAssembly = Assembly.Load(entityFactoryAssemblyName);
					string entityFactoryClassType = entityFactoryElement.Attributes["Type"].Value;
					this.EntityFactoryToUse = (IEntityFactory2)entityFactoryAssembly.CreateInstance(entityFactoryClassType);
				}

				// then walk the subnodes and process only the direct childs, skipping entity collections and entity references.
				foreach(XmlNode currentElement in node.ChildNodes)
				{
					switch(currentElement.Name)
					{
						case "Entities":
							// first test if this node is empty
							if(currentElement.ChildNodes.Count<=0)
							{
								// is empty
								continue;
							}

							int currentEntityInCollectionIndex = -1;

							// get all child nodes and de-serialize them one by one.
							XmlNodeList entityNodes = currentElement.ChildNodes;
							foreach(XmlNode entityNode in entityNodes)
							{
								currentEntityInCollectionIndex++;

								// check if this node is a reference node
								if(entityNode.Name=="ProcessedObjectReference")
								{
									NodeEntityReference newReference = new NodeEntityReference();
									newReference.ObjectID = new Guid(entityNode.Attributes["ObjectID"].Value);
									newReference.PropertyHoldingInstance = this;
									newReference.IsCollectionAdd=true;
									newReference.ReferencingProperty = null;
									newReference.Position = currentEntityInCollectionIndex;
									nodeEntityReferences.Add(newReference);
									// done with this node.
									continue;
								}

								EntityBase2 referencedEntity = null;
								if(entityNode.Attributes.GetNamedItem("Assembly")==null)
								{
									XmlNode entityTypeValueAsNode = entityNode.Attributes.GetNamedItem("EntityType");
									if(entityTypeValueAsNode != null)
									{
										referencedEntity = (EntityBase2)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsNode.Value));
									}
									else
									{
										referencedEntity = (EntityBase2)this.EntityFactoryToUse.Create();
									}
								}
								else
								{
									// get type and assembly for entity instance.
									string entityAssemblyName = entityNode.Attributes["Assembly"].Value;
									string entityTypeName = entityNode.Attributes["Type"].Value;
									// load assembly
									Assembly entityAssembly = Assembly.Load(entityAssemblyName);
									// create instance
									referencedEntity = (EntityBase2)entityAssembly.CreateInstance(entityTypeName);
								}
								referencedEntity.IsDeserializing=true;
								try
								{
									// convert this entity's xml into data inside this entity
									referencedEntity.Xml2Entity(entityNode, processedObjectIDs, nodeEntityReferences);
									// add to collection.
									this.Add(referencedEntity);
								}
								finally
								{
									referencedEntity.IsDeserializing=false;
								}
							}
							break;
						case "ConcurrencyPredicateFactoryToUse":
							// this node is not present in compact XML
							string cpFactoryAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(cpFactoryAssemblyName=="Unknown")
							{
								// no factory object set nor serialized
								continue;
							}
							Assembly cpFactoryAssembly = Assembly.Load(cpFactoryAssemblyName);
							string cpFactoryClassType = currentElement.Attributes["Type"].Value;
							this.ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)cpFactoryAssembly.CreateInstance(cpFactoryClassType);
							break;
						case "EntityFactoryToUse":
							// already processed before this loop.
							break;
						default:
							// custom property, not a field.
							string elementTypeName = string.Empty;
							if(currentElement.Attributes.GetNamedItem("Type")==null)
							{
								elementTypeName = properties[currentElement.Name].PropertyType.UnderlyingSystemType.FullName.ToString();
							}
							else
							{
								elementTypeName = currentElement.Attributes["Type"].Value;
							}
							string xmlValue = currentElement.InnerText;
							PropertyDescriptor descriptor = properties[currentElement.Name];
							if(descriptor!=null)
							{
								descriptor.SetValue(this, typeConverter.XmlValueToObject(elementTypeName, xmlValue));
							}
							break;
					}
				}
			}
			finally
			{
				_deserializationInProgress = false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlNode...", "Method Exit");
			}
		}


		/// <summary>
		/// Adds the contained entities to the active set context.
		/// </summary>
		protected virtual void AddContainedEntitiesToContext()
		{
			if(_activeContext==null)
			{
				return;
			}

			foreach(IEntity2 containedEntity in List)
			{
				if(containedEntity.ActiveContext==null)
				{
					_activeContext.Add(containedEntity);
				}
			}
		}


		/// <summary>
		/// Removes the passed in entity from the collection without notifying the entity to remove that it has been removed from this collection.
		/// </summary>
		/// <param name="entityToRemove">Entity to remove.</param>
		internal void SilentRemove(IEntity2 entityToRemove)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.SilentRemove", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase2)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");

			if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException("This collection is read-only.");
			}

			int index = List.IndexOf(entityToRemove);
			if(index >=0)
			{
				bool beginRemoveResult = OnEntityRemoving( entityToRemove );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.SilentRemove", "Canceled by EntityRemoving event. Method Exit" );
					return;
				}
				List.Remove(entityToRemove);
				_contentInOriginalOrder.Remove(entityToRemove);
				// index isn't valid anymore.
				_entityIndices = null;

				OnListChanged(index, ListChangedType.ItemDeleted);
				// remove subscribtion to the changed event.
				entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			}
			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.SilentRemove", "Method Exit");
		} 



		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// It will produce "EntityCollectionBase2", if the passed in switch flag is false, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityCollectionBase2" will be returned</param>
		/// <returns></returns>
		internal string GetEntityCollectionDescription(bool switchFlag)
		{
			if(!switchFlag)
			{
				return "EntityCollectionBase2";
			}

			StringBuilder description = new StringBuilder(256);
			description.AppendFormat(null, "\r\n\tEntityCollection: {0}.", this.GetType().FullName);
			if(this.EntityFactoryToUse!=null)
			{
				description.AppendFormat(null, "\tWill contain entities of type: {0}\r\n", this.EntityFactoryToUse.Create().LLBLGenProEntityName);
			}
			if(_containingEntity!=null)
			{
				description.AppendFormat(null, "\tContained in: {0}", ((EntityBase2)_containingEntity).GetEntityDescription(switchFlag));
			}

			return description.ToString();
		}


		/// <summary>
		/// Called when the List is changed and the event should be raised.
		/// </summary>
		/// <param name="index">Index of object causing the list change</param>
		/// <param name="typeOfChange">The type of change to reflect to subscribers</param>
		protected virtual void OnListChanged(int index, ListChangedType typeOfChange)
		{
			if( typeOfChange == ListChangedType.Reset )
			{
				_entityIndices = null;
			}
			
			if(ListChanged!=null)
			{
				ListChanged(this, new ListChangedEventArgs(typeOfChange, index));
			}
		}


		/// <summary>
		/// Called at the start of a remove routine which removes an entity from this collection. Will raise EntityRemoving event. 
		/// </summary>
		/// <param name="entityToRemove">The entity to remove.</param>
		/// <returns>true if the remove action can continue (e.g. the event wasn't canceled) otherwise false.</returns>
		protected virtual bool OnEntityRemoving( IEntity2 entityToRemove )
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
		protected virtual void OnEntityRemoved( IEntity2 entityToRemove )
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
		protected virtual bool OnEntityAdding( IEntity2 entityToAdd )
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
		protected virtual void OnEntityAdded( IEntity2 entityToAdd )
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
		private void EntityInListOnEntityContentsChanged(object sender, EventArgs e)
		{
			if( ListChanged == null )
			{
				// no listeners. return. This is a speed optimization, as all the work to do to find the entity in the collection isn't necessary.
				return;
			}

			// an entity in the list has changed. Fire the list changed event and mark it as changed, plus mark the collection as a collection with dirty
			// contents
			IEntity2 dirtyEntity = (IEntity2)sender;
			OnListChanged(this.IndexOf(dirtyEntity), ListChangedType.ItemChanged);
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
		/// Places the item in the set RemovedEntitiesTracker.
		/// </summary>
		/// <param name="entityToRemove">Entity to remove.</param>
		private void PlaceInRemovedEntitiesTracker(IEntity2 entityToRemove)
		{
			// if there's no tracker, return. Also if the entity is still in the collection, don't add it, because the tracker is used for
			// tracking entities to delete. As the entity is still in the collection, it can't be deleted from the db, as it's still present in the
			// collection. This is a safety check, to make sure that when a user does this:
			// myOrder.Customer = myCustomer;
			// myCustomer.Orders.Add(myOrder);// A
			// at line A, myOrder is already in myCustomer.Orders, because LLBLGen Pro syncs relations. Re-adding it will dereference myOrder first, making it
			// getting removed from myCustomer.Orders, then it gets re-added, and resynced. 
			if((_removedEntitiesTracker == null) || this.Contains(entityToRemove))
			{
				return;
			}
			((EntityBase2)entityToRemove).MarkedForDeletion = true;
			_removedEntitiesTracker.Add(entityToRemove);
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory2 to use when creating entity objects when a bound control is adding a new entity.</param>
		private void InitClass(IEntityFactory2 entityFactoryToUse)
		{
			_entityFactoryToUse = entityFactoryToUse;
			_allowNew=true;
			_allowEdit=true;
			_allowRemove=false;
			_allowSorting=false;
			_propertySortedOn = null;
			_isSorted=false;
			_sortDirection = ListSortDirection.Ascending;
			_contentInOriginalOrder = new ArrayList();
			_listOperationInProgress=false;
			_isReadOnly = false;
			_containingEntity = null;
			_containingEntityMappedField = string.Empty;
			_deserializationInProgress=false;
			_doNotPerformAddIfPresent = false;
			_site=null;
			_activeContext = null;
			_cachedPkHashes = null;
			_defaultView = null;
			_removedEntitiesTracker = null;
		}
	

		/// <summary>
		/// Rebuilds the index which contains per objectid the index in this collection.
		/// </summary>
		private void RebuildEntityIndex()
		{
			_entityIndices = new Hashtable( this.Count );
			for( int i = 0; i < this.Count; i++ )
			{
				IEntity2 toAdd = this[i];
				if( _entityIndices.ContainsKey( toAdd.ObjectID ) )
				{
					continue;
				}
				_entityIndices.Add( toAdd.ObjectID, i );
			}
		}


		#region IComponent Members

		/// <summary>
		/// Disposed event. Not used in this implementation.
		/// </summary>
		public event System.EventHandler Disposed;

		/// <summary>
		/// Gets or sets the site.
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get
			{
				return _site;
			}
			set
			{
				_site = value;
				if(value!=null)
				{
					EntityCollectionComponentDesigner.InDesignMode=true;
				}
			}
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public virtual void Dispose()
		{
			if(Disposed!=null)
			{
				Disposed(this, EventArgs.Empty);
			}
		}

		#endregion

		#region IListSource Members

		/// <summary>
		/// Gets the list.
		/// </summary>
		/// <returns></returns>
		public IList GetList()
		{
			return (IList)this.DefaultView;
		}

		/// <summary>
		/// Gets a value indicating whether [contains list collection].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [contains list collection]; otherwise, <c>false</c>.
		/// </value>
		[Browsable(false)]
		[XmlIgnore]
		public bool ContainsListCollection
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region IXmlSerializable Members

		/// <summary>
		/// Constructs the XML output from the object graph which has this object as the root. 
		/// </summary>
		/// <param name="writer">Writer to which the xml is written to</param>
		/// <remarks>Uses XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType.</remarks>
		public virtual void WriteXml(XmlWriter writer)
		{
			WriteXml(writer, XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType);
		}

		/// <summary>
		/// Produce the schema, always return null, as the XmlSerializer object otherwise can't handle our code.
		/// </summary>
		/// <returns></returns>
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">Reader with xml used to produce an object graph</param>
		/// <remarks>Uses XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType. Xml data should have been
		/// produced with WriteXml(writer) or a similar routine which is able to produce similar formatted XML</remarks>
		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			// assume compact25, as the IXmlSerializable.Writer implemenation writes Compact25 xml, bypasses version check.
			bool methodNodeStartRead = false;
			if(reader.ReadState != ReadState.Initial)
			{
				// read away method node
				reader.Read();
				methodNodeStartRead = true;
			}
			string startElementName = reader.LocalName; 
			this.ReadXml(reader, XmlFormatAspect.Compact25);
			if((reader.NodeType == XmlNodeType.EndElement) && (reader.LocalName == startElementName))
			{
				// read away end element of entity and position on next element
				reader.Read();
			}
			if(methodNodeStartRead)
			{
				// read away end node of start element which was read.
				reader.Read();
			}
		}
		#endregion

		#region IEntityViewSource explicit implementations
		/// <summary>
		/// Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
		/// it from the list again, and will set its flag that it is added by databinding. 
		/// </summary>
		object IEntityViewSource.AddNew()
		{
			return this.AddNew();
		}

		/// <summary>
		/// Determines the index of a specific item in the collection
		/// </summary>
		/// <param name="item">The object to locate in the collection.</param>
		/// <returns>
		/// The index of item if found in the list; otherwise, -1.
		/// </returns>
		int IEntityViewSource.IndexOf( IEntityCore item )
		{
			return this.IndexOf((IEntity2)item);
		}

		/// <summary>
		/// Removes the object at the index specified.
		/// </summary>
		/// <param name="index">Index.</param>
		void IEntityViewSource.RemoveAt(int index)
		{
			this.RemoveAt(index);
		}

		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		ArrayList IEntityViewSource.FindMatches( IPredicate filter )
		{
			return this.FindMatches(filter);
		}

		
		/// <summary>
		/// Creates a dummy instance using the entity factory stored in an inherited collection. This dummy instance is then used to produce
		/// property descriptors.
		/// </summary>
		/// <returns>
		/// Dummy instance of entity contained in this collection, using the set factory.
		/// </returns>
		IEntityCore IEntityViewSource.CreateDummyInstance()
		{
			if( _entityFactoryToUse == null )
			{
				return null;
			}
			else
			{
				return _entityFactoryToUse.Create();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is read only.
		/// </summary>
		/// <value>
		/// 	<see langword="true"/> if this instance is read only; otherwise, <see langword="false"/>.
		/// </value>
		bool IEntityViewSource.IsReadOnly 
		{ 
			get { return this.IsReadOnly;}
			set { this.IsReadOnly = value;}
		}

		/// <summary>
		/// Gets or sets the <see cref="IEntityCore"/> at the specified index.
		/// </summary>
		/// <value></value>
		IEntityCore IEntityViewSource.this[int index] 
		{
			get { return this[index]; }
		}

		/// <summary>
		/// Gets the count of this collection
		/// </summary>
		int IEntityViewSource.Count
		{
			get { return this.Count;}
		}
		#endregion
#if !CF
		#region Optimized Serialization related code.
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <param name="parseEntityList">If set to true, serialization flags are parsed</param>
		/// <param name="includeEntityMemberCollections">If set to true, entity menber collections are included as well.</param>
		/// <returns>Bitvector with the serialization flags</returns>
		internal BitVector32 GetSerializationFlags(bool parseEntityList, bool includeEntityMemberCollections)
		{
			BitVector32 flags = new BitVector32();
			flags[SerializationHelper.CollectionNotHasEntityFactoryMask] = (_entityFactoryToUse == null);
			flags[SerializationHelper.CollectionNotAllowNewMask] = !AllowNew;
			flags[SerializationHelper.CollectionNotAllowRemoveMask] = !AllowRemove;
			flags[SerializationHelper.CollectionNotAllowEditMask] = !AllowEdit;
			flags[SerializationHelper.CollectionReadOnlyMask] = IsReadOnly;
			flags[SerializationHelper.CollectionDoNotPerformAddIfPresentMask] = DoNotPerformAddIfPresent;
			flags[SerializationHelper.CollectionHasEntitiesMask] = Count != 0;
			flags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask] = (ConcurrencyPredicateFactoryToUse != null);

			if(parseEntityList && flags[SerializationHelper.CollectionHasEntitiesMask])
			{
				bool entityTypesAreCommon = AreEntityTypesCommon();
				flags[SerializationHelper.CollectionHasCommonEntityTypesMask] = entityTypesAreCommon;
				if(entityTypesAreCommon)
				{
					IEntityFactory2 commonEntityFactory = EntityFactoryCache2.GetEntityFactory(this[0] as EntityBase2);
					flags[SerializationHelper.CollectionIsCommonEntityFactoryCollectionEntityFactoryMask] =
						((_entityFactoryToUse != null) && (commonEntityFactory.GetType() == _entityFactoryToUse.GetType()));
				}

				bool hasDependentRelatedEntities = false;
				bool hasDependingRelatedEntities = false;
				bool hasPopulatedMemberCollectionEntities = !includeEntityMemberCollections;

				foreach(EntityBase2 entity in this)
				{
					if(!hasDependingRelatedEntities)
					{
						hasDependingRelatedEntities = entity.GetDependingRelatedEntities().Count != 0;
					}
					if(!hasDependentRelatedEntities)
					{
						hasDependentRelatedEntities = entity.GetDependentRelatedEntities().Count != 0;
					}
					if(!hasPopulatedMemberCollectionEntities)
					{
						hasPopulatedMemberCollectionEntities = entity.HasPopulatedMemberEntityCollections();
					}

					// Quick exit once we have all the information we need
					if(hasDependentRelatedEntities && hasDependingRelatedEntities && hasPopulatedMemberCollectionEntities) 
					{
						break;
					}
				}

				flags[SerializationHelper.CollectionHasEntitiesWithDependentRelatedEntitiesMask] = hasDependentRelatedEntities;
				flags[SerializationHelper.CollectionHasEntitiesWithDependingRelatedEntitiesMask] = hasDependingRelatedEntities;
				if(includeEntityMemberCollections)
				{
					flags[SerializationHelper.CollectionHasEntitiesWithPopulatedMemberCollectionsMask] = hasPopulatedMemberCollectionEntities;
				}
			}
			return flags;
		}


		/// <summary>
		/// Method which restores owned data - i.e. considered private to this collection
		/// and not shared with any external object
		/// </summary>
		/// <param name="writer">SerializationWriter</param>
		/// <param name="context">The serialization flags (previously constructed)</param>
		protected virtual void SerializeOwnedData(SerializationWriter writer, object context)
		{
			BitVector32 serializationFlags = (BitVector32)context;

			if(!serializationFlags[SerializationHelper.CollectionNotHasEntityFactoryMask])
			{
				writer.WriteTokenizedObject(EntityFactoryCache2.GetEntityFactory(_entityFactoryToUse), true);
			}

			if(serializationFlags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask])
			{
				writer.WriteTokenizedObject(ConcurrencyPredicateFactoryToUse, false);
			}
		}


		/// <summary>
		/// Method which restores owned data - i.e. considered private to this entity
		/// and not shared with any external object
		/// </summary>
		/// <param name="reader">The SerializationReader containing the serialized data</param>
		/// <param name="context">The serialization flags (previously read)</param>
		protected virtual void DeserializeOwnedData(SerializationReader reader, object context)
		{
			BitVector32 serializationFlags = (BitVector32)context;

			IsReadOnly = serializationFlags[SerializationHelper.CollectionReadOnlyMask];
			AllowNew = !serializationFlags[SerializationHelper.CollectionNotAllowNewMask];
			AllowRemove = !serializationFlags[SerializationHelper.CollectionNotAllowRemoveMask];
			AllowEdit = !serializationFlags[SerializationHelper.CollectionNotAllowEditMask];
			DoNotPerformAddIfPresent = serializationFlags[SerializationHelper.CollectionDoNotPerformAddIfPresentMask];

			if(!serializationFlags[SerializationHelper.CollectionNotHasEntityFactoryMask])
			{
				_entityFactoryToUse = (IEntityFactory2)reader.ReadTokenizedObject();
			}

			if(serializationFlags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask])
			{
				ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)reader.ReadTokenizedObject();
			}
		}


		/// <summary>
		/// Ares the entity types common.
		/// </summary>
		/// <returns></returns>
		private bool AreEntityTypesCommon()
		{
			if(this.Count == 0)
			{
				return false;
			}
			if(this.Count == 1) 
			{
				return true;
			}

			Type entityType = this[0].GetType();

			// Check in reverse order - quicker exit if sorted by type
			for(int i = this.Count - 1; i > 0; i--)
			{
				if(this[i].GetType() != entityType)
				{
					return false;
				}
			}
			return true;
		}

		#region IFastSerializableEntityCollection2
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <param name="parseEntityList">If set to true, serialization flags are parsed</param>
		/// <param name="includeEntityMemberCollections">If set to true, entity menber collections are included as well.</param>
		/// <returns>Bitvector with the serialization flags</returns>
		BitVector32 IFastSerializableEntityCollection2.GetSerializationFlags(bool parseEntityList, bool includeEntityMemberCollections)
		{
			return GetSerializationFlags(parseEntityList, includeEntityMemberCollections);
		}

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void IFastSerializableEntityCollection2.Add(EntityBase2 entity)
		{
			Add(entity);
		}

		/// <summary>
		/// Inits the class
		/// </summary>
		void IFastSerializableEntityCollection2.InitClassInternal()
		{
			InitClass(null);
		}
		
		/// <summary>
		/// Gets or sets the containing entity mapped field
		/// </summary>
		/// <value></value>
		string IFastSerializableEntityCollection2.ContainingEntityMappedFieldInternal
		{
			get { return _containingEntityMappedField; }
			set { _containingEntityMappedField = value; }
		}
		#endregion IFastSerializableEntityCollection2

		#region IOwnedDataSerializable
		/// <summary>
		/// Lets the implementing class store internal data directly into a SerializationWriter.
		/// </summary>
		/// <param name="writer">The SerializationWriter to use</param>
		/// <param name="context">Optional context to use as a hint as to what to store (BitVector32 is useful)</param>
		void IOwnedDataSerializable.SerializeOwnedData(SerializationWriter writer, object context)
		{
			SerializeOwnedData(writer, context);
		}

		/// <summary>
		/// Lets the implementing class retrieve internal data directly from a SerializationReader.
		/// </summary>
		/// <param name="reader">The SerializationReader to use</param>
		/// <param name="context">Optional context to use as a hint as to what to retrieve (BitVector32 is useful)</param>
		void IOwnedDataSerializable.DeserializeOwnedData(SerializationReader reader, object context)
		{
			DeserializeOwnedData(reader, context);
		}
		#endregion
		#endregion
#endif

		#region Class Property Declarations
		/// <summary>
		/// IBindingList property. Default: true
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
		/// IBindingList property. Default: null.
		/// </summary>
		[XmlIgnore]
		public virtual PropertyDescriptor SortProperty
		{
			get
			{
				return _propertySortedOn;
			}
		}

		/// <summary>
		/// IBindingList property. Default: false
		/// </summary>
		public virtual bool SupportsSorting
		{
			get
			{
				return _allowSorting;
			}
			set
			{
				_allowSorting = value;
			}
		}

		/// <summary>
		/// IBindingList property. Default: false
		/// </summary>
		[XmlIgnore]
		public virtual bool IsSorted
		{
			get
			{
				return _isSorted;
			}
		}

		/// <summary>
		/// IBindingList property. Default: false
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
		/// IBindingList property. Default: true
		/// </summary>
		public virtual bool SupportsSearching
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// IBindingList property. Default: Ascending.
		/// </summary>
		[XmlIgnore]
		public virtual ListSortDirection SortDirection
		{
			get
			{
				return _sortDirection;
			}
		}

		/// <summary>
		/// IBindingList property. Default: true
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
		/// IBindingList property. Default: supported
		/// </summary>
		public virtual bool SupportsChangeNotification
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Items contained by this collection. This is the SORTED collection (if sorted). Remove sorting first to get the original list.
		/// </summary>
		[XmlIgnore]
		public virtual IList Items
		{
			get { return List; }
		}


		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty. 
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		[XmlIgnore]
		public ArrayList DirtyEntities
		{
			get
			{
				ArrayList toReturn = new ArrayList();
				foreach(IEntity2 entity in List)
				{
					if(entity.IsDirty)
					{
						toReturn.Add(entity);
					}
				}
#if CF
				return toReturn;
#else
				return ArrayList.ReadOnly(toReturn);
#endif
			}
		}


		/// <summary>
		/// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an 
		/// already filled collection should not be refreshed until a save is performed. 
		/// </summary>
		[XmlIgnore]
		public bool ContainsDirtyContents
		{
			get 
			{ 
				foreach(IEntity2 entity in List)
				{
					if(entity.IsDirty)
					{
						return true;
					}
				}
				return false;
			}
		}

	
		/// <summary>
		/// The EntityFactory2 to use when creating entity objects when bound to a grid and AddNew is enabled.
		/// </summary>
		public IEntityFactory2 EntityFactoryToUse 
		{
			get { return _entityFactoryToUse; }
			set { _entityFactoryToUse = value;}
		}

		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory instance to use when creating entity objects during an entity collection fetch
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
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		public int Capacity
		{
			get { return InnerList.Capacity;}
			set { InnerList.Capacity = value;}
		}


		/// <summary>
		/// Simple indexer. 
		/// </summary>
		/// <exception cref="InvalidOperationException">When a value is Set and the collection is marked ReadOnly</exception>
		[XmlIgnore]
		public virtual IEntity2 this [int index]
		{
			get { return (IEntity2)List[index]; }
			set 
			{ 
				if(_isReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
				{
					throw new InvalidOperationException("This collection is read-only");
				}
				// first dereference the current entity on the index specified so the entity on list[index] can't keep this collection 
				// into memory.
				IEntity2 currentEntity = this[index];
				if(currentEntity!=null)
				{
					((EntityBase2)currentEntity).EntityContentsChanged-= new EventHandler(EntityInListOnEntityContentsChanged);
					if( _entityIndices != null )
					{
						_entityIndices.Remove( currentEntity.ObjectID );
					}				
				}
				List[index]=value;
				if(( _entityIndices != null ) && !_entityIndices.ContainsKey(value.ObjectID))
				{
					_entityIndices.Add( value.ObjectID, index );
				}
				if(!_deserializationInProgress)
				{
					if(_containingEntity!=null)
					{
						value.SetRelatedEntity(_containingEntity, _containingEntityMappedField);
					}

					OnListChanged(index, ListChangedType.ItemAdded);
				}

				// subscribe to changed event so the list can signal changes to bound controls.
				value.EntityContentsChanged+=new EventHandler(EntityInListOnEntityContentsChanged);
			}
		}

		/// <summary>
		/// The amount of IEntity2 elements in this entity collection
		/// </summary>
		public new int Count 
		{
			get { return base.Count;}
		}


		/// <summary>
		/// Get / set the readonly flag for this collection. If set to true, it will affect IBindingList parameters as well.
		/// </summary>
		public bool IsReadOnly 
		{
			get { return _isReadOnly;}
			set 
			{ 
				_isReadOnly = value;
				if(!_deserializationInProgress)
				{
					_allowNew = !value;
					_allowRemove = !value;
					_allowEdit = !value;
				}
			}
		}


		/// <summary>
		/// sets the internal flag to say that this collection is being deserialized.
		/// </summary>
		[XmlIgnore]
		internal bool DeserializationInProgress
		{
			set
			{
				_deserializationInProgress = value;
			}
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
		/// Gets the name of the entity factory.
		/// </summary>
		/// <value></value>
		[DesignOnly(true)]
		[XmlIgnore()]
		public string EntityFactoryName
		{
			get 
			{
				if(_entityFactoryToUse==null)
				{
					return string.Empty;
				}
				else
				{
					return _entityFactoryToUse.ToString();
				}
			}
		}

		/// <summary>
		/// Gets / sets the active context this entity collection is in. Setting this property is not adding the entity collection to the context, 
		/// it will make contained entities be added to the passed in context. If the entity collection is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entity collections.
		/// </summary>
		[XmlIgnore]
		public Context ActiveContext 
		{ 
			get { return _activeContext;}
			set 
			{ 
				if( ((_activeContext==null)&&(value!=null)) || ((_activeContext!=null)&&(value==null)))
				{
					if((_activeContext == null) && (value != null))
					{
						// set the dupe prevention flag. 
						DoNotPerformAddIfPresent = true;
					}
					_activeContext = value;
					AddContainedEntitiesToContext();
				}
			}
		}
	
				
		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read. 
		/// It's an entity view without a filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		[Browsable( false ), XmlIgnore]
		public IEntityView2 DefaultView
		{
			get 
			{ 
				if(_defaultView==null)
				{
					_defaultView = new EntityView2( this ); 
				}
				return _defaultView;
			}
		}


		/// <summary>
		/// Gets / sets the CachedPkHashes. This is a hashtable with the PK hashes for the entities in this collection. This is set during a 
		/// prefetch path fetch, to cache already calculated PK side hashes.
		/// </summary>
		[Browsable(false), XmlIgnore]
		internal Hashtable CachedPkHashes
		{
			get
			{
				return _cachedPkHashes;
			}
			set
			{
				_cachedPkHashes = value;
			}
		}


		/// <summary>
		/// Obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net
		/// </summary>
		/// <value></value>
		[Obsolete("This property is now obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net.", false)]
		[Browsable(false), XmlIgnore]
#if !CF
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
#endif
		public object EntityValidatorToUse
		{
			get { return null;}
			set { /* nop */ }
		}

		/// <summary>
		/// Obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net
		/// </summary>
		/// <value></value>
		[Obsolete("This property is now obsolete. Collections don't store validator objects anymore. Present to make sure users can continue designing their forms in vs.net.", false)]
		[Browsable(false), XmlIgnore]
#if !CF
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
#endif
		public object ValidatorToUse
		{
			get { return null;}
			set { /* nop */ }
		}

		
		/// <summary>
		/// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection2 instance,
		/// all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
		/// This collection can then later on be used to delete these entities from the database in one go.
		/// </summary>
		[Browsable(false), XmlIgnore]
		public IEntityCollection2 RemovedEntitiesTracker
		{
			get { return _removedEntitiesTracker; }
			set { _removedEntitiesTracker = value; }
		}
		#endregion
	}


	/// <summary>
	/// Container for entity fetch in DataAccessAdapter. This entity collection is an IEntityCollection2 implementation, just to use
	/// with the fetch logic to have a collection to store entities in, without the need for ITypedList implementations.
	/// </summary>
	internal class EntityCollectionForFetch : EntityCollectionBase2
	{
		internal EntityCollectionForFetch(IEntityFactory2 factoryToUse):base(factoryToUse)
		{
		}
	}
}
