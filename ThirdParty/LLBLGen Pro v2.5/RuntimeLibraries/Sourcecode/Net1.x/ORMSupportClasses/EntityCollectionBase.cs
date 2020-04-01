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
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the entity collection base class.
	/// </summary>
#if !CF
	[ListBindable(true)]
	[Serializable]
	[System.ComponentModel.DesignerCategory("Code")]
#endif
	public abstract class EntityCollectionBase : CollectionBase, IEntityCollection, ITransactionalElement, 
			ISerializable, IComponent, IListSource, IXmlSerializable, IEntityViewSource
	{
		#region Class Member Declarations
		private long							_maxNumberOfItemsToReturn;
		private ISortExpression					_sortClauses;
		private IEntityFactory					_entityFactoryToUse;
		private bool							_suppressClearInGetMulti, _allowNew, _allowRemove, _allowEdit, _doNotPerformAddIfPresent;
		private IEntity							_containingEntity;
		private	string							_containingEntityMappedField;
		private IConcurrencyPredicateFactory	_concurrencyPredicateFactoryToUse;

		[NonSerialized]
		private	ITransaction					_containingTransaction;
		[NonSerialized]
		private bool							_allowSorting;
		[NonSerialized]
		private bool							_isSorted;
		[NonSerialized]
		private PropertyDescriptor				_propertySortedOn;
		[NonSerialized]
		private ListSortDirection				_sortDirection;
		[NonSerialized]
		private	ArrayList						_contentInOriginalOrder;			// valid when the collection gets sorted. 
		[NonSerialized]
		private bool							_listOperationInProgress;
		[NonSerialized]
		private bool							_deserializationInProgress;
		[NonSerialized]
		private ISite							_site;
		[NonSerialized]
		private Context							_activeContext;
		[NonSerialized]
		private	Hashtable						_cachedPkHashes;
		// fast-access index which stores per objectid the index in the collection. Is created the first time IndexOf is called and the index isn't there.
		// It's rebuild every time the index is considered invalid (when a remove/insert has taken place, or a reset is required due to a sort). 
		// Rebuild is postponed till the next time IndexOf is called. 
		[NonSerialized]
		private Hashtable						_entityIndices;			
		[NonSerialized]
		private bool							_surpressChangedEvent;
		[NonSerialized]
		private IEntityView						_defaultView;
		[NonSerialized]
		private IEntityCollection				_removedEntitiesTracker;
		#endregion

		#region Static members
		/// <summary>
		/// Static bool which is used by lazy loading code in entities to determine if the code is called from somewhere in design mode.
		/// This boolean is set by IComponent.Site if site is not null. It is after that never reset, as that would not make sense: instance code
		/// can't be in design mode and not in design mode at the same time.
		/// </summary>
		public static bool InDesignMode = false;
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
		public EntityCollectionBase()
		{
			InitClass(null);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call. </param>
		public EntityCollectionBase(IEntityFactory entityFactoryToUse)
		{
			InitClass(entityFactoryToUse);
		}


		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollectionBase(SerializationInfo info, StreamingContext context)
		{
			InitClass(null);

			try
			{
				_deserializationInProgress=true;

				// deserialize the data back into this instance.
				int amountOfEntitiesInList = info.GetInt32("AmountEntitiesInList");

				_maxNumberOfItemsToReturn = info.GetInt64("_maxNumberOfItemsToReturn");
				_sortClauses = (ISortExpression)info.GetValue("_sortClauses", typeof(ISortExpression));
				_entityFactoryToUse = (IEntityFactory)info.GetValue("_entityFactoryToUse", typeof(IEntityFactory));
				_suppressClearInGetMulti = info.GetBoolean("_suppressClearInGetMulti");
				_containingEntity = (IEntity)info.GetValue("_containingEntity", typeof(IEntity));
				_containingEntityMappedField = info.GetString("_containingEntityMappedField");
				_allowNew = info.GetBoolean("_allowNew");
				_allowRemove = info.GetBoolean("_allowRemove");
				_allowEdit = info.GetBoolean("_allowEdit");
				_doNotPerformAddIfPresent = info.GetBoolean("_doNotPerformAddIfPresent");

				for(int i=0;i<amountOfEntitiesInList;i++)
				{
					IEntity entityToAdd = (IEntity)info.GetValue("Entity" + i, typeof(IEntity));
					// add it. It will wire the events automatically.
					this.FastAdd(entityToAdd);
				}

				OnDeserialized(info, context);
			}
			finally
			{
				_deserializationInProgress = false;
			}
		}


		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain EntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the related entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		public void SetContainingEntityInfo(IEntity containingEntity, string fieldName)
		{
			_containingEntity = containingEntity;
			_containingEntityMappedField = fieldName;
			this.ActiveContext = _containingEntity.ActiveContext;
			AddContainedEntitiesToContext();
		}

		/// <summary>
		/// When the <see cref="ITransaction"/> in which this IEntity participates is commited, this IEntity can succesfully finish actions performed by this
		/// IEntity. This method is called by <see cref="ITransaction"/>, you should not call it by yourself. When this IEntity doesn't participate in a
		/// transaction it finishes the actions itself, calling this method is not needed.
		/// </summary>
		public void TransactionCommit()
		{
			// empty, because entities in this collection are added to the transaction automatically and thus receive this call themselves
		}


		/// <summary>
		/// When the <see cref="ITransaction"/> in which this IEntity participates is rolled back, this IEntity has to roll back its internal variables.
		/// This method is called by <see cref="ITransaction"/>, you should not call it by yourself. 
		/// </summary>
		public void TransactionRollback()
		{
			// empty, because entities in this collection are added to the transaction automatically and thus receive this call themselves
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
				IEntity dummy = (IEntity)Activator.CreateInstance((Type)pair.Key);
				// build projectors. Only project fields.
				ArrayList projectors = EntityFields.ConvertToProjectors(dummy.Fields);
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
				IEntity dummy = (IEntity)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection toProject = (IEntityCollection)entitiesPerType[projectionData.TypeOfTargetEntity];
				if(toProject==null)
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = dummy.GetEntityFactory().CreateEntityCollection();
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
						IEntityField primaryKeyField = (IEntityField)dummy.PrimaryKeyFields[i + j];
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
				IEntity dummy = (IEntity)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection toProject = (IEntityCollection)entitiesPerType[projectionData.TypeOfTargetEntity];
				if(toProject==null)
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = dummy.GetEntityFactory().CreateEntityCollection();
				}
				IEntityCollection resultsCollection = dummy.GetEntityFactory().CreateEntityCollection();
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsCollection, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Add(dummy.GetType(), resultsCollection);
			}
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView on this collection</returns>
		public IEntityView CreateView()
		{
			return CreateView(null, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView on this collection</returns>
		public IEntityView CreateView(IPredicate filter)
		{
			return CreateView(filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView on this collection</returns>
		public IEntityView CreateView(IPredicate filter, ISortExpression sorter)
		{
			return CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView on this collection</returns>
		public IEntityView CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
		{
			return new EntityView(this, filter, sorter, dataChangeAction);
		}

		/// <summary>
		/// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
		/// to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
		/// new Transaction (which is created in an inherited method.). Will not recursively save entities inside the collection.
		/// </summary>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		public int SaveMulti()
		{
			return SaveMulti(false);
		}


		/// <summary>
		/// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
		/// to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
		/// new Transaction (which is created in an inherited method.)
		/// </summary>
		/// <param name="recurse">If true, will recursively save the entities inside the collection</param>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		public virtual int SaveMulti(bool recurse)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.SaveMulti", "Method Enter");

			// produce queues for processing.
			ArrayList insertQueue = new ArrayList(1024);
			ArrayList updateQueue = new ArrayList(1024);

			if(recurse)
			{
				ObjectGraphUtils graphUtils = new ObjectGraphUtils();
				graphUtils.DetermineActionQueues(this, ref insertQueue, ref updateQueue);
			}
			else
			{
				foreach(IEntity entityToSave in this)
				{
					if(entityToSave.IsDirty || 
						(!entityToSave.IsDirty && entityToSave.IsNew && 
							(((EntityBase)entityToSave).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)))
					{
						if(entityToSave.IsNew)
						{
							insertQueue.Add(new ActionQueueElement(entityToSave, null, false));
						}
						else
						{
							updateQueue.Add(new ActionQueueElement(entityToSave, entityToSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), false));
						}
					}
				}
			}

			if((insertQueue.Count<=0)&&(updateQueue.Count<=0))
			{
				// empty queues, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.SaveMulti: no entities to save.", "Method Exit");
				return 0;
			}
			bool saveSucceeded = true;
			int totalAmountInserted = 0;
			int totalAmountUpdated = 0;
			saveSucceeded &= DaoBase.PersistQueue(insertQueue, true, _containingTransaction, out totalAmountInserted);
			saveSucceeded &= DaoBase.PersistQueue(updateQueue, false, _containingTransaction, out totalAmountUpdated);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.SaveMulti", "Method Exit");
			return totalAmountInserted + totalAmountUpdated;	
		}


		/// <summary>
		/// Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
		/// to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a
		/// new Transaction (which is created in an inherited method.)
		/// Deleted entities are marked deleted and are removed from the collection.
		/// </summary>
		/// <returns>Amount of entities deleted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		public virtual int DeleteMulti()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.DeleteMulti", "Method Enter");

			int amountDeleted = 0;
			ArrayList entitiesToRemove = new ArrayList();

			for(int i=0;i<List.Count;i++)
			{
				IEntity entityToDelete = (IEntity)List[i];
				if(!((ITransactionalElement)List[i]).ParticipatesInTransaction)
				{
					// doesn't participate in a transaction, add it to the current transaction. Has to be available.
					_containingTransaction.Add((ITransactionalElement)List[i]);
				}
				bool wasSuccesful = entityToDelete.Delete();
				if(wasSuccesful)
				{
					// remove it, add it to the removelist
					entitiesToRemove.Add(entityToDelete);
					amountDeleted++;
				}
			}

			bool surpressChangedEventSave = _surpressChangedEvent;
			_surpressChangedEvent = true;
			try
			{
				// now, remove all entities in the remove list from this list
				for (int i = 0; i < entitiesToRemove.Count; i++)
				{
					List.Remove(entitiesToRemove[i]);
					_contentInOriginalOrder.Remove(entitiesToRemove[i]);
				}
			}
			finally
			{
				_surpressChangedEvent = surpressChangedEventSave;
			}

			entitiesToRemove.Clear();

			// flag this list that it is changed
			OnListChanged(0, ListChangedType.Reset);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.DeleteMulti", "Method Exit");
			return amountDeleted;
		}


		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		public void AddRange(ICollection c)
		{
			base.InnerList.Capacity = Math.Max(base.InnerList.Capacity, base.InnerList.Count +c.Count);
			foreach(IEntity toAdd in c)
			{
				Add(toAdd);
			}
		}

		
		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		public void AddRange(IEntityCollection c)
		{
			base.InnerList.Capacity = Math.Max(base.InnerList.Capacity, base.InnerList.Count +c.Count);
			foreach(IEntity toAdd in c)
			{
				Add(toAdd);
			}
		}


		/// <summary>
		/// Adds an IEntity object to the list. Only new entities are added.
		/// </summary>
		/// <param name="entityToAdd">Entity to add</param>
		/// <returns>Index in list</returns>
		public int Add(IEntity entityToAdd)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase.Add", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase)entityToAdd).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Add Description");

			int toReturn = 0;
			if(_doNotPerformAddIfPresent)
			{
				int currentIndex = this.IndexOf(entityToAdd);
				if(currentIndex>=0)
				{
					toReturn = currentIndex;
				}
				else
				{
					toReturn = FastAdd(entityToAdd);
				}
			}
			else
			{
				toReturn = FastAdd(entityToAdd);
			}
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, toReturn, "Index of added entity");
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase.Add", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Adds an IEntity object to the list. This version doesn't check for presence of teh passed in entity.
		/// </summary>
		/// <param name="entityToAdd">Entity to add</param>
		/// <returns>Index in list</returns>
		internal int FastAdd(IEntity entityToAdd)
		{
			bool beginAddResult = OnEntityAdding( entityToAdd );
			if( !beginAddResult )
			{
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase.FastAdd", "Addition canceled by EntityAdding event." );
				return -1;
			}

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
			return index;
		}


		/// <summary>
		/// Inserts an IEntity on position Index. Only entities which aren't present in the collection are added.
		/// </summary>
		/// <param name="index">Index where to insert the Entity</param>
		/// <param name="entityToAdd">Entity to insert</param>
		public void Insert(int index, IEntity entityToAdd)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Insert", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase)entityToAdd).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Insert Description");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in.");
			if(!List.Contains(entityToAdd))
			{
				bool beginInsertResult = OnEntityAdding(entityToAdd);
				if(!beginInsertResult)
				{
					// abort.
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceVerbose, "EntityCollectionBase.Insert", "Canceled by EntityAdding event. Method Exit" );
					return;
				}
				List.Insert(index, entityToAdd);
				if(_isSorted)
				{
					_contentInOriginalOrder.Add(entityToAdd);
				}
				else
				{
					_contentInOriginalOrder.Insert(index, entityToAdd);
				}
				_entityIndices=null;
				
				if(!_deserializationInProgress)
				{
					if(_containingEntity!=null)
					{
						entityToAdd.SetRelatedEntity(_containingEntity, _containingEntityMappedField);
					}

					OnListChanged(index, ListChangedType.ItemAdded);
				}

				// subscribe to the changed event.
				entityToAdd.EntityContentsChanged +=new EventHandler(EntityInListOnEntityContentsChanged);

				if(_activeContext!=null)
				{
					_activeContext.Add(entityToAdd);
				}
				OnEntityAdded(entityToAdd);
			}
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Insert", "Method Exit");
		}


		/// <summary>
		/// Remove given IEntity from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity object to remove from list.</param>
		public void Remove(IEntity entityToRemove)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Remove", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");
			int index = List.IndexOf(entityToRemove);
			if(index >=0)
			{
				bool beginRemoveResult = OnEntityRemoving( entityToRemove );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Remove", "Canceled by EntityRemoving event. Method Exit" );
					return;
				}
				if(_containingEntity!=null)
				{
					entityToRemove.UnsetRelatedEntity(_containingEntity, _containingEntityMappedField);
				}
				List.Remove(entityToRemove);
				_contentInOriginalOrder.Remove(entityToRemove);
				
				PlaceInRemovedEntitiesTracker(entityToRemove);

				_entityIndices=null;
				OnListChanged(index, ListChangedType.ItemDeleted);

				// remove subscribtion to the changed event.
				entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			}

			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Remove", "Method Exit");
		} 


		/// <summary>
		/// Removes the IEntity instance at the index given.
		/// </summary>
		/// <param name="index">Index in list to remove the element.</param>
		public new void RemoveAt(int index)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.RemoveAt", "Method Enter");
			IEntity entityToRemove = (IEntity)List[index];
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, index, "Index passed in.");

			bool beginRemoveResult = OnEntityRemoving( entityToRemove );
			if( !beginRemoveResult )
			{
				// canceled. 
				TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.RemoveAt", "Canceled by EntityRemoving event. Method Exit" );
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

			_entityIndices=null;
			OnListChanged(index, ListChangedType.ItemDeleted);

			// remove subscribtion to the changed event.
			entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.RemoveAt", "Method Exit");
		}


		/// <summary>
		/// Returns true if the list contains the given IEntity Object
		/// </summary>
		/// <param name="entityToFind">Entity object to check.</param>
		/// <returns>true if Entity exists in list.</returns>
		public bool Contains(IEntity entityToFind)
		{
			return List.Contains(entityToFind);
		}


		/// <summary>
		/// Performs a clear of the internals and its internal objects.
		/// </summary>
		protected override void OnClear()
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.OnClear", "Method Enter");
			if(!_listOperationInProgress)
			{
				// unset related entity information
				if(_containingEntity!=null)
				{
					for (int i = 0; i < List.Count; i++)
					{
						((IEntity)List[i]).UnsetRelatedEntity(_containingEntity, _containingEntityMappedField);
						((IEntity)List[i]).EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
					}
				}
				else
				{
					for (int i = 0; i < List.Count; i++)
					{
						((IEntity)List[i]).EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
					}
				}

				_contentInOriginalOrder.Clear();
			}
			base.OnClear ();
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.OnClear", "Method Exit");
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
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// It will produce "EntityCollectionBase", if the passed in switch flag is false, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityCollectionBase" will be returned</param>
		/// <returns></returns>
		internal string GetEntityCollectionDescription(bool switchFlag)
		{
			if(!switchFlag)
			{
				return "EntityCollectionBase";
			}

			StringBuilder description = new StringBuilder(256);
			description.AppendFormat(null, "\r\n\tEntityCollection: {0}.\r\n", this.GetType().FullName);
			if(_containingEntity!=null)
			{
				description.AppendFormat(null, "\tContained in: \r\n{0} via property: {1}\r\n", ((EntityBase)_containingEntity).GetEntityDescription(switchFlag), _containingEntityMappedField);
			}

			return description.ToString();
		}


		/// <summary>
		/// Returns index in the list of given IEntity object.
		/// </summary>
		/// <param name="entityToFind">Entity Object to check</param>
		/// <returns>index in list.</returns>
		public int IndexOf(IEntity entityToFind)
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
		/// copy the complete list of IEntity objects to an array of IEntity objects.
		/// </summary>
		/// <param name="destination">Array of IEntity Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		public void CopyTo(IEntity[] destination, int index)
		{
			List.CopyTo(destination, index);
		}
		
		
		/// <summary> Deletes from the persistent storage all entities of the type this collection is for which match with the specified filter, 
		/// formulated in the predicate or predicate expression definition.</summary>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete. Can be null, 
		/// which will result in a query removing all entities of the type this collection is for from the persistent storage</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		/// <remarks>Not supported for entities which are in a hierarchy of TargetPerEntity</remarks>
		public virtual int DeleteMulti(IPredicate deleteFilter)
		{
			return DeleteMulti(deleteFilter, null);
		}


		/// <summary> Deletes from the persistent storage all entities of the type this collection is for which match with the specified filter, 
		/// formulated in the predicate or predicate expression definition.</summary>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete. Can be null, 
		/// which will result in a query removing all entities of the type this collection is for from the persistent storage</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <remarks>Not supported for entities which are in a hierarchy of TargetPerEntity</remarks>
		public virtual int DeleteMulti(IPredicate deleteFilter, IRelationCollection relations)
		{
			IDao dao = CreateDAOInstance();
			bool transactionStartedLocally = false;
			ITransaction localTrans = null;
			int toReturn = 0;
			try
			{
				if(!ParticipatesInTransaction && (_entityFactoryToUse != null))
				{
					EntityBase dummy = (EntityBase)_entityFactoryToUse.Create();
					if(dummy.CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectDeleteEntities))
					{
						// start transaction locally
						localTrans = CreateTransaction(IsolationLevel.ReadCommitted, "delDirectTrans");
						transactionStartedLocally = true;
						localTrans.Add(this);
					}
				}
				toReturn = dao.DeleteMulti(Transaction, deleteFilter, relations);

				if(transactionStartedLocally)
				{
					localTrans.Commit();
				}
			}
			catch
			{
				if(transactionStartedLocally)
				{
					localTrans.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedLocally)
				{
					localTrans.Dispose();
				}
			}
			
			return toReturn;
		}


		/// <summary>Updates in the persistent storage all entities of the type this collection is for which have data in common with the specified 
		/// entity. Which fields are updated in those matching entities depends on which fields are
		/// <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues. </summary>
		/// <param name="entityWithNewValues">entity instance which holds the new values for the matching entities to update. Only changed fields are taken 
		/// into account</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update. Can be null, which
		/// will result in an update action which will affect all Customer entities.</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(IEntity entityWithNewValues, IPredicate updateFilter)
		{
			return UpdateMulti(entityWithNewValues, updateFilter, null);
		}


		/// <summary>Updates in the persistent storage all entities of the type this collection is for which have data in common with the specified 
		/// entity. Which fields are updated in those matching entities depends on which fields are
		/// <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues. </summary>
		/// <param name="entityWithNewValues">entity instance which holds the new values for the matching entities to update. Only changed fields are taken 
		/// into account</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(IEntity entityWithNewValues, IPredicate updateFilter, IRelationCollection relations)
		{
			IDao dao = CreateDAOInstance();
			bool transactionStartedLocally = false;
			ITransaction localTrans = null;
			int toReturn = 0;
			try
			{
				if(!ParticipatesInTransaction)
				{
					if(((EntityBase)entityWithNewValues).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectUpdateEntities))
					{
						// start transaction locally
						localTrans = CreateTransaction(IsolationLevel.ReadCommitted, "delDirectTrans");
						transactionStartedLocally = true;
						localTrans.Add(this);
					}
				}

				toReturn = dao.UpdateMulti(entityWithNewValues, Transaction, updateFilter, relations);
				if(transactionStartedLocally)
				{
					localTrans.Commit();
				}
			}
			catch
			{
				if(transactionStartedLocally)
				{
					localTrans.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedLocally)
				{
					localTrans.Dispose();
				}
			}

			return toReturn;
		}



		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in this collection.
		/// </summary>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entitycollection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*DaoBase.ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind 
		/// that most databases have a limit on the # of parameters per query. 
		/// </remarks>
		public virtual void FetchExcludedFields(ExcludeIncludeFieldsList excludedIncludedFields)
		{
			IDao dao = CreateDAOInstance();
			dao.FetchExcludedFields(this, this.Transaction, excludedIncludedFields);
		}


		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter)
		{
			return GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, null, null, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, this.SortClauses, null, null, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, long maxNumberOfItemsToReturn)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, this.SortClauses, null, null, excludedIncludedFields, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, null, null, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, IRelationCollection relations)
		{
			return GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, relations, null, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, null, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, IPrefetchPath prefetchPathToUse)
		{
			return GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, null, prefetchPathToUse, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath prefetchPathToUse)
		{
			return GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, null, prefetchPathToUse, excludedIncludedFields, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, 
			int pageNumber, int pageSize)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, null, null, pageNumber, pageSize);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, 
			IPrefetchPath prefetchPathToUse)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, null, 0, 0);
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, 
			IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize)
		{
			return GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, null, pageNumber, pageSize);
		}


		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations,
			IPrefetchPath prefetchPathToUse, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			if(!this.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			DaoBase dao = (DaoBase)CreateDAOInstance();
			return dao.GetMulti(this.Transaction, this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse, selectFilter, relations, prefetchPathToUse,
						excludedIncludedFields, pageNumber, pageSize);
		}

		/// <summary> Gets the amount of Entity objects in the database.</summary>
		/// <returns>the amount of objects found</returns>
		public int GetDbCount()
		{
			return GetDbCount(null, null);
		}

		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <returns>the amount of objects found</returns>
		public int GetDbCount(IPredicate filter)
		{
			return GetDbCount(filter, null);
		}

		
		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified and the relations specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <param name="relations">The relations to walk</param>
		/// <returns>the amount of objects found</returns>
		public int GetDbCount(IPredicate filter, IRelationCollection relations)
		{
			DaoBase dao = (DaoBase)CreateDAOInstance();
			return dao.GetDbCount(this.EntityFactoryToUse.Create().Fields, this.Transaction, filter, relations, null);
		}


		/// <summary>
		/// ISerializable member. 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_maxNumberOfItemsToReturn", _maxNumberOfItemsToReturn);
			info.AddValue("_sortClauses", _sortClauses, typeof(ISortExpression));
			info.AddValue("_entityFactoryToUse", _entityFactoryToUse);
			info.AddValue("_suppressClearInGetMulti", _suppressClearInGetMulti);
			info.AddValue("_allowNew", _allowNew);
			info.AddValue("_allowRemove", _allowRemove);
			info.AddValue("_allowEdit", _allowEdit);
			info.AddValue("_containingEntity", _containingEntity, typeof(IEntity));
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

			OnGetObjectData(info, context);
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

			if((fieldIndex<0)||(fieldIndex>=((IEntity)_contentInOriginalOrder[0]).Fields.Count))
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties(_contentInOriginalOrder[0].GetType())[((IEntity)_contentInOriginalOrder[0]).Fields[fieldIndex].Name];
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
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Sort(3)", "Method Enter");

			if(!_allowSorting)
			{
				throw new NotSupportedException("Sort requires that SupportsSorting is set to true.");
			}

			if(List.Count<=0)
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Sort(3): List is empty.", "Method Exit");
				return;
			}

			if(descriptor==null)
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Sort(3): invalid property descriptor passed in: null.", "Method Exit");
				return;
			}

			_listOperationInProgress=true;
			// do sorting. Use array list for this and the build in QuickSort algo
			ArrayList toSort = new ArrayList(_contentInOriginalOrder.Count);
			Hashtable valueToEntity = new Hashtable();
			ArrayList entityIndices = null;
			for (int i = 0; i < _contentInOriginalOrder.Count; i++)
			{
				IEntity currentEntity = (IEntity)_contentInOriginalOrder[i];
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

			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Sort(3)", "Method Exit");
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
				if(((IEntity)List[i]).Fields[property.Name].CurrentValue.Equals(key))
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
		public virtual object AddNew()
		{
			IEntity newEntity = _entityFactoryToUse.Create();
			((EntityBase)newEntity).IsNewViaDataBinding=true;
			((EntityBase)newEntity).ParentCollection=this;
			if(_concurrencyPredicateFactoryToUse!=null)
			{
				newEntity.ConcurrencyPredicateFactoryToUse = _concurrencyPredicateFactoryToUse;
			}
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
		/// Converts the Entities inside this entitycollection into an entity node with inner nodes for each field, which is stored in a generic collection node.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entitycollection.</param>
		/// <returns>a complete xml representation for this entitycollection</returns>
		[Obsolete("ToXml is obsolete. use WriteXml instead.", true)]
		protected virtual XmlNode ToXml(string rootNodeName)
		{
			return null;
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
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml)
		{
			XmlNode entityCollectionNode = null;
			WriteXml(aspects, rootNodeName, new XmlDocument(), out entityCollectionNode);
			entityCollectionXml = entityCollectionNode.OuterXml;
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public virtual void WriteXml(XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			EntityCollection2Xml(rootNodeName, parentDocument, new Hashtable(), aspects, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(out string entityCollectionXml)
		{
			WriteXml("EntityCollection", out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml("EntityCollection", parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(string rootNodeName, out string entityCollectionXml)
		{
			XmlNode entityCollectionNode = null;
			WriteXml(rootNodeName, new XmlDocument(), out entityCollectionNode);
			entityCollectionXml = entityCollectionNode.OuterXml;
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
			EntityCollection2Xml(rootNodeName, parentDocument, new Hashtable(), XmlFormatAspect.None, out entityCollectionNode);
		}


		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities, 
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further. </param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		internal void EntityCollection2Xml(string rootNodeName, XmlDocument parentDocument, Hashtable processedObjectIDs, XmlFormatAspect aspects, out XmlNode entityCollectionNode)		
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Enter");

			XmlHelper nodeCreator = new XmlHelper();

			bool compactXml = ((aspects & XmlFormatAspect.Compact)==XmlFormatAspect.Compact);
			bool datesInXmlDataType = ((aspects & XmlFormatAspect.DatesInXmlDataType)==XmlFormatAspect.DatesInXmlDataType);
			bool mlInCDataBlocks = ((aspects & XmlFormatAspect.MLTextInCDataBlocks)==XmlFormatAspect.MLTextInCDataBlocks);

			// add root node
			entityCollectionNode = parentDocument.CreateNode(XmlNodeType.Element, rootNodeName, "");
			XmlNode entitiesNode = nodeCreator.AddNode(entityCollectionNode, "Entities");

			for(int i=0;i<this.Count;i++)
			{
				EntityBase entity = (EntityBase)List[i];

				XmlNode nodeToAppend = null;
				entity.Entity2Xml("Entity", parentDocument, processedObjectIDs, aspects, out nodeToAppend);
				entitiesNode.AppendChild(nodeToAppend);
			}

			if(!compactXml)
			{
				// add assembly and type as attributes
				nodeCreator.AddAttribute(entityCollectionNode, "Assembly", this.GetType().Assembly.FullName);
				nodeCreator.AddAttribute(entityCollectionNode, "Type", this.GetType().FullName);
			}

			// get properties of this IEntityCollection implementing object
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());
#if CF
			PropertyInfo[] propertyInfos = this.GetType().GetProperties();
			Hashtable propertyInfoHT = new Hashtable(propertyInfos.Length);
			foreach(PropertyInfo pinfo in propertyInfos)
			{
				propertyInfoHT.Add(pinfo.Name, pinfo);
			}
#endif
			for (int i = 0; i < properties.Count; i++)
			{
#if !CF
				if(properties[i].Attributes.Contains(new XmlIgnoreAttribute()))
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
				if(properties[i].PropertyType.IsInterface)
				{
					// check for EntityFactory
					if(properties[i].PropertyType.Equals(typeof(IEntityFactory)))
					{
						if(!compactXml)
						{
							// .EntityFactoryToUse property
							XmlNode entityFactoryNode = nodeCreator.AddNode(entityCollectionNode, "EntityFactoryToUse");

							IEntityFactory entityFactory = properties[i].GetValue(this) as IEntityFactory;
							if(entityFactory==null)
							{
								nodeCreator.AddAttribute(entityFactoryNode, "Assembly", "Unknown");
							}
							else
							{
								nodeCreator.AddAttribute(entityFactoryNode, "Assembly", entityFactory.GetType().Assembly.FullName);
								nodeCreator.AddAttribute(entityFactoryNode, "Type", entityFactory.GetType().FullName);
							}
						}
						// done with this property
						continue;
					}

					// check for ConcurrencyPredicateFactory
					if(properties[i].PropertyType.Equals(typeof(IConcurrencyPredicateFactory)))
					{
						if(!compactXml)
						{
							// .ConcurrencyPredicateFactory property
							XmlNode concurrencyPredicateFactoryNode = nodeCreator.AddNode(entityCollectionNode, "ConcurrencyPredicateFactoryToUse");
							IConcurrencyPredicateFactory cpFactory = properties[i].GetValue(this) as IConcurrencyPredicateFactory;
							if(cpFactory==null)
							{
								nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Assembly", "Unknown");
							}
							else
							{
								nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Assembly", cpFactory.GetType().Assembly.FullName);
								nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Type", cpFactory.GetType().FullName);
							}
						}
						// done with this property
						continue;
					}
				}

				// Normal not yet handled property. Add it, if appropriate
				if(compactXml)
				{
					// only IBindingList.Allow* properties are added, or properties which are marked with the IncludeInCompactXmlAttribute attribute.
#if CF
					customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(IncludeInCompactXmlAttribute), true);
					bool includeInXml = (customAttributes.Length > 0);
#else
					bool includeInXml = properties[i].Attributes.Contains( new IncludeInCompactXmlAttribute() );
#endif
					if( !properties[i].Name.StartsWith( "Allow" ) && !includeInXml)
					{
						// skip it
						continue;
					}
				}
				XmlNode childNode = nodeCreator.AddNode(entityCollectionNode, properties[i].Name);
				string valueTypeName = properties[i].PropertyType.UnderlyingSystemType.FullName.ToString();
				if(!compactXml)
				{
					nodeCreator.AddAttribute(childNode, "Type", valueTypeName);
				}

				// convert the value of the property to a string. 
				nodeCreator.PropertyValueToString( parentDocument, datesInXmlDataType, mlInCDataBlocks, properties[i].GetValue( this ), childNode, properties[i].PropertyType );
			}

			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Exit");
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		public void ReadXml(string xmlData)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlData);
			ReadXml(doc.DocumentElement);
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		public virtual void ReadXml(XmlNode node)
		{
			ArrayList nodeEntityReferences = new ArrayList();
			Hashtable processedObjectIDs = new Hashtable();
			Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);

			// walk all references found and set them to the correct objects.
			XmlHelper.SetReadReferencesSS(nodeEntityReferences, processedObjectIDs);
		}

		/// <summary>Creats a new DAO instance so code which is in the base class can still use the proper DAO object.</summary>
		protected abstract IDao CreateDAOInstance();
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		/// <returns>Transaction ready to use</returns>
		protected abstract ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name );

		/// <summary>
		/// Adds the contained entities to the active set context.
		/// </summary>
		protected virtual void AddContainedEntitiesToContext()
		{
			if(_activeContext==null)
			{
				return;
			}

			foreach(IEntity containedEntity in List)
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
		/// <param name="entityToRemove">Entity object to remove from list.</param>
		internal void SilentRemove(IEntity entityToRemove)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.SilentRemove", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.GeneralSwitch.TraceVerbose, ((EntityBase)entityToRemove).GetEntityDescription(TraceHelper.GeneralSwitch.TraceVerbose), "Entity to Remove Description");
			int index = List.IndexOf(entityToRemove);
			if(index >=0)
			{
				bool beginRemoveResult = OnEntityRemoving( entityToRemove );
				if( !beginRemoveResult )
				{
					// canceled. 
					TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.SilentRemove", "Canceled by EntityRemoving event. Method Exit" );
					return;
				}
				List.Remove(entityToRemove);
				_contentInOriginalOrder.Remove(entityToRemove);
				_entityIndices=null;

				OnListChanged(index, ListChangedType.ItemDeleted);

				// remove subscribtion to the changed event.
				entityToRemove.EntityContentsChanged -= new EventHandler(EntityInListOnEntityContentsChanged);
			}

			OnEntityRemoved(entityToRemove);
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.SilentRemove", "Method Exit");
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
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");

				_deserializationInProgress = true;
				XmlHelper typeConverter = new XmlHelper();

				// get this instance's properties.
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());

				// first walk the subnodes and process only the direct childs, skipping entity collections and entity references.
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

								EntityBase referencedEntity = null;
								if(entityNode.Attributes.GetNamedItem("Assembly")==null)
								{
									XmlNode entityTypeValueAsNode = entityNode.Attributes.GetNamedItem("EntityType");
									if(entityTypeValueAsNode != null)
									{
										referencedEntity = (EntityBase)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsNode.Value));
									}
									else
									{
										referencedEntity = (EntityBase)this.EntityFactoryToUse.Create();
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
									referencedEntity = (EntityBase)entityAssembly.CreateInstance(entityTypeName);
								}
								referencedEntity.IsDeserializing=true;
								try
								{
									// convert this entity's xml into data inside this entity
									referencedEntity.Xml2Entity(entityNode, processedObjectIDs, nodeEntityReferences);
									// add to collection.
									this.FastAdd(referencedEntity);
								}
								finally
								{
									referencedEntity.IsDeserializing=false;
								}
							}
							break;
						case "EntityFactoryToUse":
							// this node is not present in compact XML
							string entityFactoryAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(entityFactoryAssemblyName=="Unknown")
							{
								// no entityfactory set nor serialized
								continue;
							}
							Assembly entityFactoryAssembly = Assembly.Load(entityFactoryAssemblyName);
							string entityFactoryClassType = currentElement.Attributes["Type"].Value;
							this.EntityFactoryToUse = (IEntityFactory)entityFactoryAssembly.CreateInstance(entityFactoryClassType);
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

				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");
			}
		}


		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		/// <remarks>special version which is used by prefetch path code, and which modifies the relation collection and filter for hierarchical fetches</remarks>
		internal bool GetMultiInternal(ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
			ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			if(!this.SuppressClearInGetMulti)
			{
				this.Clear();
			}
			DaoBase dao = (DaoBase)CreateDAOInstance();
			return dao.GetMultiInternal(this.Transaction, this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse, 
				ref selectFilter, ref relations, excludedIncludedFields, pageNumber, pageSize);
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
		protected virtual bool OnEntityRemoving(IEntity entityToRemove )
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
		protected virtual void OnEntityRemoved(IEntity entityToRemove )
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
		protected virtual bool OnEntityAdding( IEntity entityToAdd )
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
		protected virtual void OnEntityAdded( IEntity entityToAdd )
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

			// an entity in the list has changed. Fire the list changed event
			OnListChanged(this.IndexOf((IEntity)sender), ListChangedType.ItemChanged);
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
		private void PlaceInRemovedEntitiesTracker(IEntity entityToRemove)
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
			((EntityBase)entityToRemove).MarkedForDeletion = true;
			_removedEntitiesTracker.Add(entityToRemove);
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		private void InitClass(IEntityFactory entityFactoryToUse)
		{
			_containingTransaction = null;
			_maxNumberOfItemsToReturn = 0;
			_sortClauses = null;
			_entityFactoryToUse = entityFactoryToUse;
			_allowNew=true;
			_allowRemove=false;
			_allowEdit=true;
			_allowSorting=false;
			_propertySortedOn = null;
			_isSorted=false;
			_sortDirection = ListSortDirection.Ascending;
			_contentInOriginalOrder = new ArrayList();
			_listOperationInProgress=false;
			_deserializationInProgress = false;
			_suppressClearInGetMulti = false;
			_containingEntity = null;
			_containingEntityMappedField = string.Empty;
			_site = null;
			_activeContext = null;
			_doNotPerformAddIfPresent = false;
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
				IEntity toAdd = this[i];
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
					EntityCollectionBase.InDesignMode=true;
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
		[XmlIgnore]
		[Browsable(false)]
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
		/// <remarks>Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType.</remarks>
		public virtual void WriteXml(XmlWriter writer)
		{
			string xmlOutput = string.Empty;
			WriteXml(XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType, out xmlOutput);
			writer.WriteRaw(xmlOutput);
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
		/// <remarks>Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType. Xml data should have been
		/// produced with WriteXml(writer) or a similar routine which is able to produce similar formatted XML</remarks>
		public virtual void ReadXml(XmlReader reader)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(reader.ReadOuterXml());
			ReadXml(doc.DocumentElement.FirstChild);
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
			return this.IndexOf((IEntity)item);
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
			get { return (!this.AllowEdit && !this.AllowNew && !this.AllowRemove); }
			set { /* no-op */}
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

		#region Class Property Declarations
		

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
				foreach(IEntity entity in List)
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
		/// The <see cref="ITransaction"/> this ITransactionalElement implementing object is participating in. Only valid if
		/// <see cref="ParticipatesInTransaction"/> is true. If set to null, the ITransactionalElement is no longer participating
		/// in a transaction.
		/// </summary>
		[XmlIgnore]
		public virtual ITransaction Transaction
		{
			get
			{
				return _containingTransaction;
			}
			set
			{
				if((value!=null)&&(_containingTransaction!=null))
				{
					// already is in a transaction. Ignore
					return;
				}

				_containingTransaction = value;
			}
		}

		/// <summary>
		/// Flag to check if the ITransactionalElement implementing object is participating in a transaction or not.
		/// </summary>
		[XmlIgnore]
		public virtual bool ParticipatesInTransaction
		{
			get
			{
				return (_containingTransaction!=null);
			}
		}

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
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		public int Capacity
		{
			get { return InnerList.Capacity;}
			set { InnerList.Capacity = value;}
		}

		/// <summary>
		/// The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.
		/// </summary>
		[XmlIgnore]
		public long MaxNumberOfItemsToReturn 
		{
			get { return _maxNumberOfItemsToReturn; } 
			set { _maxNumberOfItemsToReturn = value; }
		}
		
		/// <summary>
		/// The order by specifications for the sorting of the resultset when fetching it from the persistent storage.
		/// When not specified, no sorting is applied.
		/// </summary>
		[XmlIgnore]
		public ISortExpression SortClauses 
		{
			get { return _sortClauses; }
			set { _sortClauses = value; }
		}

		/// <summary>
		/// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an 
		/// already filled collection should not be refreshed until a save is performed. This property is calculated in real time
		/// and can be time consuming when the collection contains a lot of objects. Use this property only in cases when the value
		/// of this property is used to do a refetch or not.
		/// </summary>
		[XmlIgnore]
		public bool ContainsDirtyContents
		{
            get 
			{ 
				for(int i=0;i<List.Count;i++)
				{
					if(((IEntity)List[i]).Fields.IsDirty)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// The EntityFactory to use when creating entity objects during a GetMulti() call.
		/// </summary>
		public IEntityFactory EntityFactoryToUse 
		{
			get { return _entityFactoryToUse; }
			set { _entityFactoryToUse = value;}
		}


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
		/// When set to true, an entity passed to Add() will be tested if it's already present. If so, the index is returned and the
		/// object is not added again. If set to false (default: true) this check is not performed. Setting this property to true can slow down fetch logic.
		/// GetMulti fetch logic sets this property to false during a multi-entity fetch.
		/// </summary>
		[XmlIgnore]
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
		/// Surpresses the removal of all contents of the collection in a GetMulti*() call. Used by code in related entities to prevent the removal
		/// of objects when collection properties are accessed.
		/// </summary>
		public bool SuppressClearInGetMulti
		{
			get
			{
				return _suppressClearInGetMulti;
			}
			set
			{
				_suppressClearInGetMulti = value;
			}
		}


		[XmlIgnore]
		internal IEntity this[int index]
		{
			get { return (IEntity)List[index];}
		}


#if !DOTNET10
		[XmlIgnore]
#endif
		IEntity IEntityCollection.this[int index]
		{
			get { return this[index];}
			set { List[index] = value;}
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
		public IEntityView DefaultView
		{
			get 
			{ 
				if(_defaultView==null)
				{
					_defaultView = new EntityView( this ); 
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
		/// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection instance,
		/// all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
		/// This collection can then later on be used to delete these entities from the database in one go.
		/// </summary>
		[Browsable(false), XmlIgnore]
		public IEntityCollection RemovedEntitiesTracker
		{
			get { return _removedEntitiesTracker; }
			set { _removedEntitiesTracker = value; }
		}
		#endregion

	}
}
