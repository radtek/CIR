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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Data;
#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the entity collection base class.
	/// </summary>
	[Serializable]
	public abstract class EntityCollectionBase<TEntity> : CollectionCore<TEntity>, IEntityCollection, ITransactionalElement, IXmlSerializable, IListSource, 
				IEntityCollectionAccess
		where TEntity : EntityBase, IEntity
	{
		#region Class Member Declarations
		private long							_maxNumberOfItemsToReturn;
		private ISortExpression					_sortClauses;
		private IEntityFactory					_entityFactoryToUse;
		private bool							_suppressClearInGetMulti;
		private IEntity							_containingEntity;
		private	string							_containingEntityMappedField;

		[NonSerialized]
		private	ITransaction					_containingTransaction;
		[NonSerialized]
		private Context							_activeContext;
		[NonSerialized]
		private Dictionary<int, List<IEntity>> _cachedPkHashes;
		[NonSerialized]
		private EntityView<TEntity> _defaultView;
		[NonSerialized]
		private IEntityCollection				_removedEntitiesTracker;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		public EntityCollectionBase(IEntityFactory entityFactoryToUse)
		{
			InitClass(entityFactoryToUse);
		}


		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollectionBase(SerializationInfo info, StreamingContext context):base(info, context)
		{
			try
			{
				base.DeserializationInProgress = true;
				_maxNumberOfItemsToReturn = info.GetInt64( "_maxNumberOfItemsToReturn" );
				_sortClauses = (ISortExpression)info.GetValue( "_sortClauses", typeof( ISortExpression ) );
				_entityFactoryToUse = (IEntityFactory)info.GetValue( "_entityFactoryToUse", typeof( IEntityFactory ) );
				_suppressClearInGetMulti = info.GetBoolean( "_suppressClearInGetMulti" );
				_containingEntity = (IEntity)info.GetValue( "_containingEntity", typeof( IEntity ) );
				_containingEntityMappedField = info.GetString( "_containingEntityMappedField" );

			}
			finally
			{
				base.DeserializationInProgress = false;
			}
		}

		
		/// <summary>
		/// Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
		/// it from the list again, and will set its flag that it is added by databinding. 
		/// </summary>
		/// <remarks>Do not call this method from your own code. This is a databinding ONLY method.</remarks>
		/// <exception cref="InvalidOperationException">If this collection is set to ReadOnly</exception>
		public override TEntity AddNew()
		{
			if( this.IsReadOnly && (this.Site==null))
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			TEntity newEntity = (TEntity)_entityFactoryToUse.Create();
			newEntity.IsNewViaDataBinding = true;
			newEntity.ParentCollection = this;
			if( this.ConcurrencyPredicateFactoryToUse != null )
			{
				newEntity.ConcurrencyPredicateFactoryToUse = this.ConcurrencyPredicateFactoryToUse;
			}
			this.Add(newEntity);
			return newEntity;
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
			EntityBase containingEntityAsEntityBase = containingEntity as EntityBase;
			if( containingEntityAsEntityBase != null )
			{
				base.Site = containingEntityAsEntityBase.Site;
			}
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
			List<IViewProjectionData> collectionProjections = new List<IViewProjectionData>();
			Dictionary<Type, IEntityCollection> entitiesPerType = null;
			BuildCollectionProjectors(collectionProjections, out entitiesPerType);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(Dictionary<Type, IEntityCollection> destination)
		{
			List<IViewProjectionData> collectionProjections = new List<IViewProjectionData>();
			Dictionary<Type, IEntityCollection> entitiesPerType = null;
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
		public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Dictionary<Type, IEntityCollection> entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this view and for each type in the complete graph found starting with each entity in this view,
		/// using the viewProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Dictionary<Type, IEntityCollection> entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Builds the collection projectors for this collection.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void BuildCollectionProjectors(List<IViewProjectionData> collectionProjections, out Dictionary<Type, IEntityCollection> entitiesPerType)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);
			foreach(KeyValuePair<Type, IEntityCollection> pair in entitiesPerType)
			{
				IEntity dummy = (IEntity)Activator.CreateInstance(pair.Key);
				// build projectors. Only project fields.
				List<IEntityPropertyProjector> projectors = EntityFields.ConvertToProjectors(dummy.Fields);
				ViewProjectionData<EntityBase> projector = new ViewProjectionData<EntityBase>(projectors, null, true, pair.Key);
				collectionProjections.Add(projector);
			}
		}


		/// <summary>
		/// Creates the hierarchical projection for the entities per type passed in into the destination specified.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void CreateHierarchicalProjectionInternal(List<IViewProjectionData> collectionProjections, DataSet destination,
			Dictionary<Type, IEntityCollection> entitiesPerType)
		{
			destination.Tables.Clear();
			Dictionary<Type, List<IEntityRelation>> relationsPerType = new Dictionary<Type, List<IEntityRelation>>();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity dummy = (IEntity)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection toProject = null;
				if(!entitiesPerType.TryGetValue(projectionData.TypeOfTargetEntity, out toProject))
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = dummy.GetEntityFactory().CreateEntityCollection();
				}
				DataTable resultsTable = new DataTable(dummy.LLBLGenProEntityName);
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsTable, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Tables.Add(resultsTable);
				int numberOfPkFields = FieldUtilities.DetermineNumberOfPkFields(dummy.PrimaryKeyFields);
				if(numberOfPkFields > 0)
				{
					DataColumn[] pkColumns = new DataColumn[numberOfPkFields];
					for(int i = (dummy.PrimaryKeyFields.Count - numberOfPkFields), j = 0; j < numberOfPkFields; j++)
					{
						IEntityField primaryKeyField = dummy.PrimaryKeyFields[i + j];
						pkColumns[j] = resultsTable.Columns[primaryKeyField.Name];
					}
					resultsTable.PrimaryKey = pkColumns;
				}
			}

			// create datarelations. 
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				// has to be there.
				List<IEntityRelation> relations = relationsPerType[projectionData.TypeOfTargetEntity];
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
		private void CreateHierarchicalProjectionInternal(List<IViewProjectionData> collectionProjections,
				Dictionary<Type, IEntityCollection> destination, Dictionary<Type, IEntityCollection> entitiesPerType)
		{
			destination.Clear();
			Dictionary<Type, List<IEntityRelation>> relationsPerType = new Dictionary<Type, List<IEntityRelation>>();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity dummy = (IEntity)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection toProject = null;
				if(!entitiesPerType.TryGetValue(projectionData.TypeOfTargetEntity, out toProject))
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
			return new EntityView<TEntity>(this, filter, sorter, dataChangeAction);
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


		/// <summary> Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a new Transaction (which is created in an inherited method.)</summary>
		/// <param name="recurse">If true, will recursively save the entities inside the collection</param>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		public virtual int SaveMulti( bool recurse )
		{
			int amountSaved = 0;
			if( !this.ParticipatesInTransaction )
			{
				ITransaction transactionManager = CreateTransaction( IsolationLevel.ReadCommitted, "SaveMulti" );
				transactionManager.Add( this );
				try
				{
					amountSaved = PerformSaveMulti( recurse );
					transactionManager.Commit();
				}
				catch
				{
					transactionManager.Rollback();
					throw;
				}
			}
			else
			{
				amountSaved = PerformSaveMulti( recurse );
			}
			return amountSaved;
		}


		/// <summary> Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
		/// to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a/ new Transaction.
		/// Deleted entities are marked deleted and are removed from the collection.</summary>
		/// <returns>Amount of entities deleted</returns>
		public virtual int DeleteMulti()
		{
			int amountDeleted = 0;
			if( !this.ParticipatesInTransaction )
			{
				ITransaction transactionManager = CreateTransaction( IsolationLevel.ReadCommitted, "DeleteMulti" );
				transactionManager.Add( this );
				try
				{
					amountDeleted = PerformDeleteMulti();
					transactionManager.Commit();
				}
				catch
				{
					transactionManager.Rollback();
					throw;
				}
			}
			else
			{
				amountDeleted = PerformDeleteMulti();
			}
			return amountDeleted;
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
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entity. If you used 
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
			return dao.GetMulti(this.Transaction, this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse, selectFilter, relations, prefetchPathToUse, excludedIncludedFields, pageNumber, pageSize);
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
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData( info, context );

			info.AddValue("_maxNumberOfItemsToReturn", _maxNumberOfItemsToReturn);
			info.AddValue("_sortClauses", _sortClauses, typeof(ISortExpression));
			info.AddValue("_entityFactoryToUse", _entityFactoryToUse);
			info.AddValue("_suppressClearInGetMulti", _suppressClearInGetMulti);
			info.AddValue("_containingEntity", _containingEntity, typeof(IEntity));
			info.AddValue("_containingEntityMappedField", _containingEntityMappedField);
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		/// <remarks>For backwards compatibility.</remarks>
		public override void Sort( int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse )
		{
			if( this.Count <= 0 )
			{
				return;
			}

			if( (fieldIndex < 0) || (fieldIndex >= this[0].Fields.Count) )
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties( this[0].GetType() )[this[0].Fields[fieldIndex].Name];
			Sort( descriptor, direction, comparerToUse );
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
			EntityCollection2Xml(rootNodeName, parentDocument, new Dictionary<Guid, IEntity>(), aspects, out entityCollectionNode);
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
			EntityCollection2Xml(rootNodeName, parentDocument, new Dictionary<Guid, IEntity>(), XmlFormatAspect.None, out entityCollectionNode);
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
			List<NodeEntityReference> nodeEntityReferences = new List<NodeEntityReference>();
			Dictionary<Guid, IEntity> processedObjectIDs = new Dictionary<Guid, IEntity>();
			Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);

			// walk all references found and set them to the correct objects.
			XmlHelper.SetReadReferencesSS(nodeEntityReferences, processedObjectIDs);
		}
		

		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// It will produce "EntityCollectionBase", if the passed in switch flag is false, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityCollectionBase" will be returned</param>
		/// <returns></returns>
		internal string GetEntityCollectionDescription( bool switchFlag )
		{
			if( !switchFlag || this.DeserializationInProgress )
			{
				return "EntityCollectionBase";
			}

			StringBuilder description = new StringBuilder( 256 );
			description.AppendFormat( null, "\r\n\tEntityCollection: {0}.\r\n", this.GetType().FullName );
			if( _containingEntity != null )
			{
				description.AppendFormat( null, "\tContained in: \r\n{0} via property: {1}\r\n", ((EntityBase)_containingEntity).GetEntityDescription( switchFlag ), _containingEntityMappedField );
			}

			return description.ToString();
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
		internal void EntityCollection2Xml( string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntity> processedObjectIDs,
				XmlFormatAspect aspects, out XmlNode entityCollectionNode )
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Enter" );

			XmlHelper nodeCreator = new XmlHelper();

			bool compactXml = ((aspects & XmlFormatAspect.Compact) == XmlFormatAspect.Compact);
			bool datesInXmlDataType = ((aspects & XmlFormatAspect.DatesInXmlDataType) == XmlFormatAspect.DatesInXmlDataType);
			bool mlInCDataBlocks = ((aspects & XmlFormatAspect.MLTextInCDataBlocks) == XmlFormatAspect.MLTextInCDataBlocks);

			// add root node
			entityCollectionNode = parentDocument.CreateNode( XmlNodeType.Element, rootNodeName, "" );
			XmlNode entitiesNode = nodeCreator.AddNode( entityCollectionNode, "Entities" );

			for( int i = 0; i < this.Count; i++ )
			{
				EntityBase entity = (EntityBase)this[i];

				XmlNode nodeToAppend = null;
				entity.Entity2Xml( "Entity", parentDocument, processedObjectIDs, aspects, out nodeToAppend );
				entitiesNode.AppendChild( nodeToAppend );
			}

			if( !compactXml )
			{
				// add assembly and type as attributes
				nodeCreator.AddAttribute( entityCollectionNode, "Assembly", this.GetType().Assembly.FullName );
				nodeCreator.AddAttribute( entityCollectionNode, "Type", this.GetType().FullName );
			}

			// get properties of this IEntityCollection implementing object
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( this.GetType() );
#if CF
			PropertyInfo[] propertyInfos = this.GetType().GetProperties();
			Hashtable propertyInfoHT = new Hashtable(propertyInfos.Length);
			foreach(PropertyInfo pinfo in propertyInfos)
			{
				propertyInfoHT.Add(pinfo.Name, pinfo);
			}
#endif
			for( int i = 0; i < properties.Count; i++ )
			{
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
				if( properties[i].PropertyType.IsInterface )
				{
					// check for EntityFactory
					if( properties[i].PropertyType.Equals( typeof( IEntityFactory ) ) )
					{
						if( !compactXml )
						{
							// .EntityFactoryToUse property
							XmlNode entityFactoryNode = nodeCreator.AddNode( entityCollectionNode, "EntityFactoryToUse" );

							IEntityFactory entityFactory = properties[i].GetValue( this ) as IEntityFactory;
							if( entityFactory == null )
							{
								nodeCreator.AddAttribute( entityFactoryNode, "Assembly", "Unknown" );
							}
							else
							{
								nodeCreator.AddAttribute( entityFactoryNode, "Assembly", entityFactory.GetType().Assembly.FullName );
								nodeCreator.AddAttribute( entityFactoryNode, "Type", entityFactory.GetType().FullName );
							}
						}
						// done with this property
						continue;
					}

					// check for ConcurrencyPredicateFactory
					if( properties[i].PropertyType.Equals( typeof( IConcurrencyPredicateFactory ) ) )
					{
						if( !compactXml )
						{
							// .ConcurrencyPredicateFactory property
							XmlNode concurrencyPredicateFactoryNode = nodeCreator.AddNode( entityCollectionNode, "ConcurrencyPredicateFactoryToUse" );
							IConcurrencyPredicateFactory cpFactory = properties[i].GetValue( this ) as IConcurrencyPredicateFactory;
							if( cpFactory == null )
							{
								nodeCreator.AddAttribute( concurrencyPredicateFactoryNode, "Assembly", "Unknown" );
							}
							else
							{
								nodeCreator.AddAttribute( concurrencyPredicateFactoryNode, "Assembly", cpFactory.GetType().Assembly.FullName );
								nodeCreator.AddAttribute( concurrencyPredicateFactoryNode, "Type", cpFactory.GetType().FullName );
							}
						}
						// done with this property
						continue;
					}
				}

				// Normal not yet handled property. Add it, if appropriate
				if( compactXml )
				{
					// only IBindingList.Allow* properties are added, or properties which are marked with the IncludeInCompactXmlAttribute attribute.
#if CF
					customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(IncludeInCompactXmlAttribute), true);
					bool includeInXml = (customAttributes.Length > 0);
#else
					bool includeInXml = properties[i].Attributes.Contains( new IncludeInCompactXmlAttribute() );
#endif
					if( !properties[i].Name.StartsWith( "Allow" ) && !includeInXml )
					{
						// skip it
						continue;
					}
				}
				XmlNode childNode = nodeCreator.AddNode( entityCollectionNode, properties[i].Name );
				string valueTypeName = properties[i].PropertyType.UnderlyingSystemType.FullName.ToString();
				if( !compactXml )
				{
					nodeCreator.AddAttribute( childNode, "Type", valueTypeName );
				}

				// convert the value of the property to a string. 
				nodeCreator.PropertyValueToString(parentDocument, datesInXmlDataType, mlInCDataBlocks, properties[i].GetValue(this), childNode, properties[i].PropertyType);
			}

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Exit" );
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">List with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		internal void Xml2EntityCollection(XmlNode node, Dictionary<Guid, IEntity> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");

				base.DeserializationInProgress = true;
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
									nodeEntityReferences.Add( newReference );
									// done with this node.
									continue;
								}

								TEntity referencedEntity = null;
								if(entityNode.Attributes.GetNamedItem("Assembly")==null)
								{
									XmlNode entityTypeValueAsNode = entityNode.Attributes.GetNamedItem("EntityType");
									if(entityTypeValueAsNode != null)
									{
										referencedEntity = (TEntity)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsNode.Value));
									}
									else
									{
										referencedEntity = (TEntity)this.EntityFactoryToUse.Create();
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
									referencedEntity = (TEntity)entityAssembly.CreateInstance( entityTypeName );
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
							if(descriptor != null)
							{
								descriptor.SetValue(this, typeConverter.XmlValueToObject(elementTypeName, xmlValue));
							}
							break;
					}
				}
			}
			finally
			{
				base.DeserializationInProgress= false;

				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");
			}
		}

		#region ICollectionMaintenance explicit implementations
		/// <summary>
		/// Removes the passed in entity from the collection without notifying the entity to remove that it has been removed from this collection.
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		void ICollectionMaintenance.SilentRemove( IEntityCore toRemove )
		{
			base.SilentRemove( (TEntity)toRemove );
		}

		/// <summary>
		/// Raises the list changed event, with the parameters passed in.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="typeOfChange">The type of change.</param>
		void ICollectionMaintenance.RaiseListChanged( int index, ListChangedType typeOfChange )
		{
			base.OnListChanged( index, typeOfChange );
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether [surpress list changed events].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [surpress list changed events]; otherwise, <c>false</c>.
		/// </value>
		bool ICollectionMaintenance.SurpressListChangedEvents
		{
			get { return base.SurpressListChangedEventsInternal; }
			set { base.SurpressListChangedEventsInternal = value; }
		}

		/// <summary>
		/// Resets the CachedPkHashes. 
		/// </summary>
		void ICollectionMaintenance.ResetCachedPkHashes()
		{
			_cachedPkHashes = null;
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		void ICollectionMaintenance.Clear()
		{
			this.Clear();
		}

		/// <summary>
		/// Gets / sets the DeserializationInProgress flag.
		/// </summary>
		bool ICollectionMaintenance.DeserializationInProgress
		{
			get { return this.DeserializationInProgress; }
			set { this.DeserializationInProgress = value; }
		}
		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// </summary>
		/// <param name="switchFlag">switch flag.</param>
		/// <returns></returns>
		string ICollectionMaintenance.GetEntityCollectionDescription( bool switchFlag )
		{
			return this.GetEntityCollectionDescription( switchFlag );
		}

		/// <summary>
		/// Creates a dummy instance using the entity factory stored in an inherited collection. This dummy instance is then used to produce
		/// property descriptors.
		/// </summary>
		/// <returns>
		/// Dummy instance of entity contained in this collection, using the set factory.
		/// </returns>
		IEntityCore ICollectionMaintenance.CreateDummyInstance()
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

		#endregion


		#region IEntityCollectionAccess Explicit implementation
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
		void IEntityCollectionAccess.EntityCollection2Xml( string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntity> processedObjectIDs,
				XmlFormatAspect aspects, out XmlNode entityCollectionNode )
		{
			this.EntityCollection2Xml( rootNodeName, parentDocument, processedObjectIDs, aspects, out entityCollectionNode );
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		void IEntityCollectionAccess.Xml2EntityCollection( XmlNode node, Dictionary<Guid, IEntity> processedObjectIDs,
				List<NodeEntityReference> nodeEntityReferences )
		{
			this.Xml2EntityCollection( node, processedObjectIDs, nodeEntityReferences );
		}


		/// <summary>
		/// Gets the cached pk hashes, if available, otherwise null
		/// </summary>
		/// <returns></returns>
		Dictionary<int, List<IEntity>> IEntityCollectionAccess.GetCachedPkHashes()
		{
			return this.CachedPkHashes;
		}

		/// <summary>
		/// Sets the cached pk hashes to the passed dictionary
		/// </summary>
		/// <param name="pkHashes">The pk hashes.</param>
		void IEntityCollectionAccess.SetCachedPkHashes( Dictionary<int, List<IEntity>> pkHashes )
		{
			this.CachedPkHashes = pkHashes;
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
		bool IEntityCollectionAccess.GetMultiInternal( ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses,
				ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			return this.GetMultiInternal( ref selectFilter, maxNumberOfItemsToReturn, sortClauses, ref relations, excludedIncludedFields, pageNumber, pageSize );
		}
		#endregion



		/// <summary>
		/// Performs the set related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the setrelated entity action on.</param>
		protected override void PerformSetRelatedEntity( TEntity entity )
		{
			if( (_containingEntity != null) && !EntityCollectionComponentDesigner.InDesignMode )
			{
				entity.SetRelatedEntity( _containingEntity, _containingEntityMappedField );
			}
		}

		/// <summary>
		/// Performs the unset related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the unsetrelated entity action on.</param>
		protected override void PerformUnsetRelatedEntity( TEntity entity )
		{
			if( (_containingEntity != null) && !EntityCollectionComponentDesigner.InDesignMode )
			{
				entity.UnsetRelatedEntity( _containingEntity, _containingEntityMappedField );
			}
		}

		/// <summary>
		/// Performs the add action to the active context for this collection
		/// </summary>
		/// <param name="entity">The entity.</param>
		protected override void PerformAddToActiveContext( TEntity entity )
		{
			if( _activeContext != null )
			{
				_activeContext.Add( entity );
			}
		}


		/// <summary>
		/// Gets the entity description for the entity passed in.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="switchFlag">if true, the method will produce TEntity.GetEntityDescription, otherwise it's a no-op</param>
		/// <returns></returns>
		protected override string GetEntityDescription( TEntity entity, bool switchFlag )
		{
			if(this.DeserializationInProgress)
			{
				return "EntityBase";
			}
			return ((EntityBase)entity).GetEntityDescription( switchFlag );
		}


		/// <summary>
		/// Places the item in the set RemovedEntitiesTracker.
		/// </summary>
		/// <param name="item">The item to add to the tracker.</param>
		protected override void PlaceInRemovedEntitiesTracker(TEntity item)
		{
			// if there's no tracker, return. Also if the entity is still in the collection, don't add it, because the tracker is used for
			// tracking entities to delete. As the entity is still in the collection, it can't be deleted from the db, as it's still present in the
			// collection. This is a safety check, to make sure that when a user does this:
			// myOrder.Customer = myCustomer;
			// myCustomer.Orders.Add(myOrder);// A
			// at line A, myOrder is already in myCustomer.Orders, because LLBLGen Pro syncs relations. Re-adding it will dereference myOrder first, making it
			// getting removed from myCustomer.Orders, then it gets re-added, and resynced. 
			if((_removedEntitiesTracker == null) || this.Contains(item))
			{
				return;
			}

			item.MarkedForDeletion = true;
			_removedEntitiesTracker.Add(item);
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
			if( _activeContext == null )
			{
				return;
			}

			foreach( IEntity containedEntity in this )
			{
				if( containedEntity.ActiveContext == null )
				{
					_activeContext.Add( containedEntity );
				}
			}
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		private void InitClass(IEntityFactory entityFactoryToUse)
		{
			base.InitCoreClass(0);
			_entityFactoryToUse = entityFactoryToUse;
			InitClass();
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		private void InitClass()
		{
			_containingTransaction = null;
			_maxNumberOfItemsToReturn = 0;
			_sortClauses = null;
			_suppressClearInGetMulti = false;
			_containingEntity = null;
			_containingEntityMappedField = string.Empty;
			_activeContext = null;
			_cachedPkHashes = null;
			_defaultView = null;
			_removedEntitiesTracker = null;
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
		private int PerformSaveMulti( bool recurse )
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti", "Method Enter" );

			// produce queues for processing.
			List<ActionQueueElement<IEntity>> insertQueue = new List<ActionQueueElement<IEntity>>( 1024 );
			List<ActionQueueElement<IEntity>> updateQueue = new List<ActionQueueElement<IEntity>>( 1024 );

			if( recurse )
			{
				ObjectGraphUtils graphUtils = new ObjectGraphUtils();
				graphUtils.DetermineActionQueues( this, ref insertQueue, ref updateQueue );
			}
			else
			{
				foreach( IEntity entityToSave in this )
				{
					if( entityToSave.IsDirty ||
						(!entityToSave.IsDirty && entityToSave.IsNew &&
							(((EntityBase)entityToSave).GetInheritanceHierarchyType() == InheritanceHierarchyType.TargetPerEntityHierarchy)) )
					{
						if( entityToSave.IsNew )
						{
							insertQueue.Add( new ActionQueueElement<IEntity>( entityToSave, null, false ) );
						}
						else
						{
							updateQueue.Add( new ActionQueueElement<IEntity>( entityToSave, entityToSave.GetConcurrencyPredicate( ConcurrencyPredicateType.Save ), false ) );
						}
					}
				}
			}

			if( (insertQueue.Count <= 0) && (updateQueue.Count <= 0) )
			{
				// empty queues, nothing to do
				TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti: no entities to save.", "Method Exit" );
				return 0;
			}
			bool saveSucceeded = true;
			int totalAmountInserted = 0;
			int totalAmountUpdated = 0;
			saveSucceeded &= DaoBase.PersistQueue( insertQueue, true, _containingTransaction, out totalAmountInserted );
			saveSucceeded &= DaoBase.PersistQueue( updateQueue, false, _containingTransaction, out totalAmountUpdated );

			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti", "Method Exit" );
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
		private int PerformDeleteMulti()
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformDeleteMulti", "Method Enter" );

			int amountDeleted = 0;
			List<TEntity> entitiesToRemove = new List<TEntity>();

			for( int i = 0; i < this.Count; i++ )
			{
				TEntity entityToDelete = this[i];
				if( !((ITransactionalElement)entityToDelete).ParticipatesInTransaction )
				{
					// doesn't participate in a transaction, add it to the current transaction. Has to be available.
					_containingTransaction.Add( (ITransactionalElement)entityToDelete );
				}
				bool wasSuccesful = entityToDelete.Delete();
				if( wasSuccesful )
				{
					// remove it, add it to the removelist
					entitiesToRemove.Add( entityToDelete );
					amountDeleted++;
				}
			}

			bool surpressChangedEventSave = base.SurpressListChangedEventsInternal;
			base.SurpressListChangedEventsInternal = true;
			try
			{
				// now, remove all entities in the remove list from this list
				for(int i = 0; i < entitiesToRemove.Count; i++)
				{
					this.Remove(entitiesToRemove[i]);
				}
			}
			finally
			{
				base.SurpressListChangedEventsInternal = surpressChangedEventSave;
			}

			entitiesToRemove.Clear();

			// flag this list that it is changed
			OnListChanged( 0, ListChangedType.Reset );

			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformDeleteMulti", "Method Exit" );
			return amountDeleted;
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
		private bool GetMultiInternal( ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses,
				ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize )
		{
			if( !this.SuppressClearInGetMulti )
			{
				this.Clear();
			}
			DaoBase dao = (DaoBase)CreateDAOInstance();
			return dao.GetMultiInternal( this.Transaction, this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse,
					ref selectFilter, ref relations, excludedIncludedFields, pageNumber, pageSize);
		}



		#region Explicit IEntityCollection members
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter )
		{
			return this.GetMulti( selectFilter );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn, sortClauses );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, IRelationCollection relations )
		{
			return this.GetMulti( selectFilter, relations );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn, sortClauses, relations );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, IPrefetchPath prefetchPathToUse )
		{
			return this.GetMulti( selectFilter, prefetchPathToUse );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, 
				int pageNumber, int pageSize )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, pageNumber, pageSize );
		}

		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
			IRelationCollection relations, IPrefetchPath prefetchPathToUse )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse );
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
		bool IEntityCollection.GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
				IRelationCollection relations, IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize )
		{
			return this.GetMulti( selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, pageNumber, pageSize );
		}

		/// <summary> Gets the amount of Entity objects in the database.</summary>
		/// <returns>the amount of objects found</returns>
		int IEntityCollection.GetDbCount()
		{
			return this.GetDbCount();
		}

		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <returns>the amount of objects found</returns>
		int IEntityCollection.GetDbCount( IPredicate filter )
		{
			return this.GetDbCount(filter);
		}

		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified and the relations specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <param name="relations">The relations to walk</param>
		/// <returns>the amount of objects found</returns>
		int IEntityCollection.GetDbCount( IPredicate filter, IRelationCollection relations )
		{
			return this.GetDbCount(filter, relations);
		}

		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		List<int> IEntityCollection.FindMatches( IPredicate filter )
		{
			return base.FindMatches( filter );
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		void IEntityCollection.Clear()
		{
			this.Clear();
		}

		/// <summary>
		/// Adds an IEntity object to the list.
		/// </summary>
		/// <param name="entityToAdd">Entity to add</param>
		/// <returns>Index in list</returns>
		int IEntityCollection.Add( IEntity entityToAdd )
		{
			TEntity toAdd = entityToAdd as TEntity;
			if( toAdd != null )
			{
				this.Add( toAdd );
				return (this.Count - 1);
			}
			else
			{
				throw new ArgumentException( "entityToAdd isn't of the right type.");
			}
		}

		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		void IEntityCollection.AddRange(IEntityCollection c)
		{
			ICollection<TEntity> collection = c as ICollection<TEntity>;
			if(collection != null)
			{
				this.AddRange(collection);
			}
			else
			{
				throw new ArgumentException("c isn't of the right type");
			}
		}

		/// <summary>
		/// Inserts an IEntity on position Index
		/// </summary>
		/// <param name="index">Index where to insert the Object Entity</param>
		/// <param name="entityToAdd">Entity to insert</param>
		void IEntityCollection.Insert( int index, IEntity entityToAdd )
		{
			TEntity toAdd = entityToAdd as TEntity;
			if( toAdd != null )
			{
				this.Insert( index, toAdd);
			}
			else
			{
				throw new ArgumentException( "entityToAdd isn't of the right type." );
			}
		}

		/// <summary>
		/// Remove given IEntity from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity object to remove from list.</param>
		void IEntityCollection.Remove( IEntity entityToRemove )
		{
			TEntity toRemove = entityToRemove as TEntity;
			if( toRemove != null )
			{
				this.Remove(toRemove);
			}
			else
			{
				throw new ArgumentException( "entityToRemove isn't of the right type." );
			}
		}

		/// <summary>
		/// Returns true if the list contains the given IEntity Object
		/// </summary>
		/// <param name="entityToFind">Entity object to check.</param>
		/// <returns>true if Entity exists in list.</returns>
		bool IEntityCollection.Contains( IEntity entityToFind )
		{
			TEntity entity = entityToFind as TEntity;
			if( entity != null )
			{
				return this.Contains( entity );
			}
			else
			{
				throw new ArgumentException( "entityToFind isn't of the right type" );
			}
		}

		/// <summary>
		/// Returns index in the list of given IEntity object.
		/// </summary>
		/// <param name="entityToFind">Entity Object to check</param>
		/// <returns>index in list.</returns>
		int IEntityCollection.IndexOf( IEntity entityToFind )
		{
			TEntity entity = entityToFind as TEntity;
			if( entity != null )
			{
				return this.IndexOf( entity );
			}
			else
			{
				throw new ArgumentException( "entityToFind isn't of the right type" );
			}
		}

		/// <summary>
		/// copy the complete list of IEntity objects to an array of IEntity objects.
		/// </summary>
		/// <param name="destination">Array of IEntity Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		void IEntityCollection.CopyTo( IEntity[] destination, int index )
		{
			TEntity[] dest = destination as TEntity[];
			if( dest != null )
			{
				this.CopyTo( dest, index );
			}
			else
			{
				throw new ArgumentException( "destination isn't of the right type" );
			}
		}

		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain IEntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the containing entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		void IEntityCollection.SetContainingEntityInfo( IEntity containingEntity, string fieldName )
		{
			this.SetContainingEntityInfo( containingEntity, fieldName );
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void IEntityCollection.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
		{
			this.CreateHierarchicalProjection(collectionProjections, destination);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void IEntityCollection.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination)
		{
			this.CreateHierarchicalProjection(collectionProjections, destination);
		}

		

		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView on this collection</returns>
		IEntityView IEntityCollection.CreateView()
		{
			return this.CreateView(null, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView IEntityCollection.CreateView(IPredicate filter)
		{
			return this.CreateView(filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView IEntityCollection.CreateView(IPredicate filter, ISortExpression sorter)
		{
			return this.CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView IEntityCollection.CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
		{
			return this.CreateView(filter, sorter, dataChangeAction);
		}



		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty.
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		/// <value></value>
		List<IEntity> IEntityCollection.DirtyEntities
		{
			get 
			{
				List<IEntity> toReturn = new List<IEntity>();
				List<TEntity> tmpDirtyEntities = this.DirtyEntities;
				foreach( IEntity entity in tmpDirtyEntities )
				{
					toReturn.Add( entity );
				}

				return toReturn;
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="IEntity"/> at the specified index.
		/// </summary>
		/// <value></value>
		IEntity IEntityCollection.this[int index]
		{
			get { return (IEntity)this[index]; }
			set
			{
				TEntity toSet = value as TEntity;
				if( toSet != null )
				{
					this[index] = toSet;
				}
				else
				{
					throw new ArgumentException( "Value isn't of the right type." );
				}
			}
		}

		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is a new instance every time this property is read. It's a new entity view without a 
		/// filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		IEntityView  IEntityCollection.DefaultView 
		{
			get { return this.DefaultView; }
		}

		/// <summary>
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		int IEntityCollection.Capacity
		{
			get { return this.Capacity; }
			set { this.Capacity = value; }
		}
		#endregion

		#region IListSource members
		/// <summary>
		/// Gets a value indicating whether the collection is a collection of <see cref="T:System.Collections.IList"></see> objects.
		/// </summary>
		/// <value></value>
		/// <returns>true if the collection is a collection of <see cref="T:System.Collections.IList"></see> objects; otherwise, false.</returns>
		[Browsable(false), XmlIgnore]
		public bool ContainsListCollection
		{
			get { return false; }
		}

		/// <summary>
		/// Returns an <see cref="T:System.Collections.IList"></see> that can be bound to a data source from an object that does not implement an <see cref="T:System.Collections.IList"></see> itself.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IList"></see> that can be bound to a data source from the object.
		/// </returns>
		public System.Collections.IList GetList()
		{
			return this.DefaultView;
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

		#region Class Property Declarations
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
				for(int i=0;i<this.Count;i++)
				{
					if(this[i].Fields.IsDirty)
					{
						return true;
					}
				}
				return false;
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
		/// The EntityFactory to use when creating entity objects during a GetMulti() call or other logic which requires the creation of new entities.
		/// </summary>
		/// <value></value>
		public IEntityFactory EntityFactoryToUse
		{
			get { return _entityFactoryToUse; }
			set { _entityFactoryToUse = value; }
		}

		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read. 
		/// It's an entity view without a filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		[Browsable( false ), XmlIgnore]
		public EntityView<TEntity> DefaultView
		{
			get 
			{
				if( _defaultView == null )
				{
					_defaultView = new EntityView<TEntity>( this );
				}
				return _defaultView;
			}
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


		/// <summary>
		/// Gets / sets the CachedPkHashes. This is a dictionary with the PK hashes for the entities in this collection. This is set during a 
		/// prefetch path fetch, to cache already calculated PK side hashes.
		/// </summary>
		[Browsable( false ), XmlIgnore]
		internal Dictionary<int, List<IEntity>> CachedPkHashes
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

		#endregion
	}
}
