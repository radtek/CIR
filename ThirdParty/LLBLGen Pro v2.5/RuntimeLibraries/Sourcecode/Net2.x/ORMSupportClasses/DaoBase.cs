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
//		- Marcus Mac Innes
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Base class for DAO classes which are generated.
	/// </summary>
	public abstract class DaoBase : IDao
	{
		#region Static class members
		/// <summary>
		/// The parameterised prefetch path threshold. This threshold is used to determine when the prefetch path logic should switch to a 
		/// subquery or when it should use a WHERE field IN (value1, value2, ... valueN) construct, based on the # of elements in the parent collection.
		/// If that # of elements exceeds this threshold, a subquery is constructed, otherwise field IN (value1, value2, ...) construct is used.
		/// The default value is 50. On average, this is faster than using a subquery which returns 50 elements. Use this to tune prefetch path fetch logic
		/// for your particular needs. 
		/// <br/><br/>
		/// This threshold is also used to determine if paging is possible. A page size bigger than this threshold will disable the paging functionality
		/// when using paging + prefetch paths. 
		/// </summary>
		/// <remarks>Testing showed that values larger than 300 will be slower than a subquery. This setting is a global setting, so will affect all
		/// database actions after setting it to a new value.
		/// <br/><br/>
		/// Special thanks to Marcus Mac Innes (http://www.styledesign.biz) for this optimization code. 
		/// </remarks>
		public static int ParameterisedPrefetchPathThreshold = 50;
		#endregion

		#region Class Member Declarations
		private IInheritanceInfoProvider	_inheritanceInfoProviderToUse;
		private DynamicQueryEngineBase		_dqeToUse;	
		private InheritanceHierarchyType	_typeOfHierarchy;
		private	string						_entityName;
		private IEntityFactory				_entityFactory;
		#endregion
		

		/// <summary>
		/// CTor for TypedListDAO
		/// </summary>
		protected DaoBase()
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="inheritanceInfoProviderToUse">Inheritance info provider to use.</param>
		/// <param name="dqeToUse">Dqe to use.</param>
		/// <param name="typeOfInheritance">Type of inheritance.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="entityFactory">Entity factory.</param>
		protected DaoBase(IInheritanceInfoProvider inheritanceInfoProviderToUse, DynamicQueryEngineBase dqeToUse, InheritanceHierarchyType typeOfInheritance,
				string entityName, IEntityFactory entityFactory)
		{
			_dqeToUse = dqeToUse;
			_inheritanceInfoProviderToUse = inheritanceInfoProviderToUse;
			_typeOfHierarchy = typeOfInheritance;
			_entityName = entityName;
			_entityFactory = entityFactory;
		}


		/// <summary>
		/// Reads the data of an entity into the specified EntityFields object and returns that object. Which data is read is determined using
		/// the passed in Primary Key field(s). If specified, it also processes the prefetch path.
		/// </summary>
		/// <param name="entityToFetch">The entity to fetch. Contained data will be overwritten.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="contextToUse">The context to fetch the prefetch path with.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <exception cref="ArgumentNullException">When fieldsToFetch is null</exception>
		public void FetchExisting(IEntity entityToFetch, ITransaction containingTransaction, IPrefetchPath prefetchPathToUse, Context contextToUse, 
			ExcludeIncludeFieldsList excludedIncludedFields)
		{
			PerformFetchEntityAction(entityToFetch, containingTransaction, CreatePrimaryKeyFilter(entityToFetch.Fields), prefetchPathToUse, contextToUse, excludedIncludedFields);
		}


		/// <summary>
		/// Adds the given fields to the database as a new entity. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the insert.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <returns>true if the addition was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		public bool AddNew(IEntityFields fields, ITransaction containingTransaction)
		{
			if(fields==null)
			{
				throw new ArgumentNullException("fields", "fields can't be null");
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.AddNew", "Method Enter");

			if(_typeOfHierarchy==InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				// get inheritance info and set the discriminator column flag.
				IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
				((EntityField)fields[info.DiscriminatorColumnIndex]).SetDiscriminatorColumnFlag(true);
			}

			bool wasSuccesful =false;
			using( IActionQuery insertQuery = _dqeToUse.CreateInsertDQ( fields, this.DetermineConnectionToUse( containingTransaction ) ) )
			{
				wasSuccesful = (ExecuteActionQuery( insertQuery, containingTransaction ) > 0);
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, wasSuccesful, "Query Execution Result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.AddNew", "Method Exit");
			return wasSuccesful;
		}

	
		/// <summary>
		/// Updates an existing entity using the given fields. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the update</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <returns>true if the update was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		public bool UpdateExisting(IEntityFields fields, ITransaction containingTransaction)
		{
			if(fields==null)
			{
				throw new ArgumentNullException("fields", "fields can't be null");
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(2)", "Method Enter");

			if(!fields.IsDirty)
			{
				// not changed, nothing to update
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(2): nothing to update", "Method Exit");
				return true;
			}

			if(_typeOfHierarchy==InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				// get inheritance info and set the discriminator column flag.
				IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
				((EntityField)fields[info.DiscriminatorColumnIndex]).SetDiscriminatorColumnFlag(true);
			}

			List<IPredicate> pkFilters = null;
			switch(_typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					pkFilters = CreatePrimaryKeyFilters(fields);
					break;
				default:
					IPredicateExpression pkFilter = CreatePrimaryKeyFilter(fields);
					pkFilters = new List<IPredicate>(1);
					if(pkFilter != null)
					{
						pkFilters.Add(pkFilter);
					}
					break;
			}

			if((pkFilters==null)||((pkFilters!=null) && (pkFilters.Count<=0)))
			{
				// no identifying filter available. The update query will affect all rows, not only this entity. 
				throw new ORMQueryConstructionException("The entity '" + _entityName + "' doesn't have a PK defined. The update query will therefore affect all entities in the table(s), not just this entity. Please define a Primary Key field in the designer for this entity.");
			}

			bool toReturn = false;
			using( IActionQuery updateQuery = _dqeToUse.CreateUpdateDQ( fields, this.DetermineConnectionToUse( containingTransaction ), pkFilters ) )
			{
				toReturn = (ExecuteActionQuery( updateQuery, containingTransaction ) > 0);
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toReturn, "Query Execution Result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(2)", "Method Exit");
			return toReturn;
		}
		

		/// <summary>
		/// Updates an existing entity using the given fields. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the update</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if the update was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		public bool UpdateExisting(IEntityFields fields, ITransaction containingTransaction, IPredicate updateRestriction)
		{
			if(fields==null)
			{
				throw new ArgumentNullException("fields", "fields can't be null");
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(3)", "Method Enter");

			if(!fields.IsDirty)
			{
				// not changed, nothing to update
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(3): nothing to update", "Method Exit");
				return true;
			}

			IInheritanceInfo info = null;
			if(_typeOfHierarchy==InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				// get inheritance info and set the discriminator column flag.
				info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
				((EntityField)fields[info.DiscriminatorColumnIndex]).SetDiscriminatorColumnFlag(true);
			}

			List<IPredicate> pkFilters = null;
			IRelationCollection additionalRelationsUpdate = null;
			switch(_typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					pkFilters = CreatePrimaryKeyFilters(fields);
					if(updateRestriction!=null)
					{
						additionalRelationsUpdate = new RelationCollection();
						info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
						additionalRelationsUpdate.AddRange(info.RelationsToHierarchyRoot);
					}
					break;
				default:
					IPredicateExpression pkFilter = CreatePrimaryKeyFilter(fields);
					pkFilters = new List<IPredicate>(1);
					if(pkFilter != null)
					{
						pkFilters.Add(pkFilter);
					}
					break;
			}
			if((pkFilters==null)||((pkFilters!=null) && (pkFilters.Count<=0) && (updateRestriction==null)))
			{
				// no identifying filter available. The update query will affect all rows, not only this entity. 
				throw new ORMQueryConstructionException("The entity '" + _entityName + "' doesn't have a PK defined. The update query will therefore affect all entities in the table(s), not just this entity. Please define a Primary Key field in the designer for this entity.");
			}

			bool toReturn = false;
			using( IActionQuery updateQuery = _dqeToUse.CreateUpdateDQ( fields, this.DetermineConnectionToUse( containingTransaction ), pkFilters,
					updateRestriction, additionalRelationsUpdate ) )
			{
				toReturn = (ExecuteActionQuery( updateQuery, containingTransaction ) > 0);
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toReturn, "Query Execution Result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateExisting(3)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Reads the data of the entity passed in, and returns that object. Which data is read is determined using
		/// the set Primary Key field(s). If specified, it also processes the prefetch path.
		/// </summary>
		/// <param name="entityToFetch">The entity to fetch. Contained data will be overwritten.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="selectFilter">Select filter.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="contextToUse">The context to fetch the prefetch path with.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		public void PerformFetchEntityAction(IEntity entityToFetch, ITransaction containingTransaction, IPredicateExpression selectFilter,
				IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformFetchEntityAction", "Method Enter");

			entityToFetch.Fields.State = EntityState.New;
			IRelationCollection relations = null;
			int discriminatorFieldIndex = -1;
			IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
			switch(_typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					// grab the inheritanceInfo, and add the relations to the root of the hierarchy to the filter.
					relations = new RelationCollection();
					relations.AddRange(info.RelationsToHierarchyRoot);
					break;
				case InheritanceHierarchyType.TargetPerEntityHierarchy:
					discriminatorFieldIndex = info.DiscriminatorColumnIndex;
					break;
			}

			bool canLoadEntity = true;
			// remove the persistence infos from the persistentInfos array (set the slots to null) for the excluded fields in excludedFields.
			IFieldPersistenceInfo[] persistenceInfos = ExcludeFieldsFromPersistenceInfos(entityToFetch.Fields, excludedIncludedFields, _typeOfHierarchy, discriminatorFieldIndex);

			using( IRetrievalQuery selectQuery = _dqeToUse.CreateSelectDQ( entityToFetch.Fields.GetAsEntityFieldCoreArray(),
						persistenceInfos, DetermineConnectionToUse( containingTransaction ), selectFilter, 0, null, relations, true, null ) )
			{
				ExecuteSingleRowRetrievalQuery( selectQuery, containingTransaction, entityToFetch.Fields, persistenceInfos );
				canLoadEntity = ((EntityBase)entityToFetch).CallOnCanLoadEntity();
				if(!canLoadEntity)
				{
					// reset with new fields.
					entityToFetch.Fields = ((EntityBase)entityToFetch).GetEntityFactory().CreateFields();
				}
				else
				{
					if(entityToFetch.Fields.State == EntityState.Fetched)
					{
						Context activeContext = contextToUse;
						if((activeContext == null) && (entityToFetch.ActiveContext != null))
						{
							activeContext = entityToFetch.ActiveContext;
						}
						if((prefetchPathToUse != null) && (prefetchPathToUse.Count > 0))
						{
							IEntityCollection rootEntityCollection = _entityFactory.CreateEntityCollection();
							if(activeContext != null)
							{
								rootEntityCollection.ActiveContext = activeContext;
							}
							rootEntityCollection.Add(entityToFetch);
							FetchPrefetchPath(rootEntityCollection, selectFilter, relations, 0, null, prefetchPathToUse, containingTransaction, false);
							// clean up the temp collection so no event handlers are left behind.
							rootEntityCollection.Clear();
						}
					}
				}
			}

			if( entityToFetch.Fields.State == EntityState.Fetched )
			{
				entityToFetch.IsNew = false;
				if( contextToUse != null )
				{
					entityToFetch.ActiveContext = contextToUse;
					contextToUse.Get( entityToFetch );	// update existing with new values, if applicable.
				}
			}
			((EntityBase)entityToFetch).CallValidateEntityAfterLoad();

			if(canLoadEntity && (entityToFetch.Fields.State == EntityState.Fetched))
			{
				((EntityBase)entityToFetch).OnAuditLoadOfEntity();
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformFetchEntityAction", "Method Exit");
		}


		/// <summary>
		/// Performs the polymorphic entity fetch for the entity type of this DAO. It will produce an entity of that type or a subtype of that type, based
		/// on the values retrieved, or an empty entity if not found. The passed in fields object has its PK fields filled, which are used to
		/// produce a PK filter.
		/// </summary>
		/// <param name="containingTransaction">Containing transaction.</param>
		/// <param name="fields">Fields required for PK construction</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>New entity with the data filtered by the passed in PK filter, or an empty entity if not found. Entity can be of type
		/// produced by the set entity factory (which produces entities of the type this DAO is for) or a subtype.</returns>
		public IEntity FetchExistingPolymorphic(ITransaction containingTransaction, IEntityFields fields, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.FetchExistingPolymorphic", "Method Enter");

			IPredicateExpression pkFilter = CreatePrimaryKeyFilter(fields);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.FetchExistingPolymorphic", "Method Exit");
			return PerformPolymorphicEntityFetch(containingTransaction, pkFilter, contextToUse, excludedIncludedFields);
		}


		/// <summary>
		/// Deletes an entity from the persistent storage. Which entity is deleted is determined from the passed in EntityFields object.
		/// </summary>
		/// <param name="fields">The EntityField data to use for the deletion</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query. Can be null.</param>
		/// <returns>true if the delete was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		public bool DeleteExisting(IEntityFields fields, ITransaction containingTransaction, IPredicate deleteRestriction)
		{
			if(fields==null)
			{
				throw new ArgumentNullException("fields", "fields can't be null");
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformDeleteEntityAction", "Method Enter");

			List<IPredicate> pkFilters = null;
			IRelationCollection relations = null;
			switch(_typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					pkFilters = CreatePrimaryKeyFilters(fields);
					relations = new RelationCollection();
					IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityName, false);
					relations.AddRange(info.RelationsToHierarchyRoot);
					break;
				default:
					IPredicateExpression pkFilter = CreatePrimaryKeyFilter(fields);
					pkFilters = new List<IPredicate>(1);
					pkFilters.Add(pkFilter);
					break;
			}
			// pk filters already contain persistence info, the deleterestriction doesn't
			bool deleteSucceeded = false;
			using( IActionQuery deleteQuery = _dqeToUse.CreateDeleteDQ( fields.GetAsPersistenceInfoArray(),
												DetermineConnectionToUse( containingTransaction ), pkFilters, deleteRestriction, relations ) )
			{
				deleteSucceeded = (ExecuteActionQuery( deleteQuery, containingTransaction ) > 0);
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, deleteSucceeded, "delete result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformDeleteEntityAction", "Method Exit");
			return deleteSucceeded;
		}


		/// <summary>
		/// Executes the passed in retrievalquery and returns an open, ready to use IDataReader. The datareader's command behavior is set to the
		/// readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="queryToExecute">The query to execute.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		public IDataReader GetAsDataReader( ITransaction transactionToUse, IRetrievalQuery queryToExecute, CommandBehavior readerBehavior )
		{
			WireTransaction( queryToExecute, transactionToUse );

			queryToExecute.Connection = DetermineConnectionToUse( transactionToUse );
			if( queryToExecute.Connection.State != ConnectionState.Open )
			{
				queryToExecute.Connection.Open();
			}

			return queryToExecute.Execute(readerBehavior);
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		public IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior,
			int maxNumberOfItemsToReturn, bool allowDuplicates )
		{
			return GetAsDataReader( transactionToUse, fields, filter, relations, readerBehavior, maxNumberOfItemsToReturn, null, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		public IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior,
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates )
		{
			return GetAsDataReader( transactionToUse, fields, filter, relations, readerBehavior, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		public IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior,
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize )
		{
			return GetAsDataReader( transactionToUse, fields, filter, relations, readerBehavior, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, pageNumber, pageSize );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		public IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior,
				int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates, int pageNumber, int pageSize )
		{
			IRetrievalQuery query = CreateQueryFromElements( transactionToUse, fields, filter, relations, maxNumberOfItemsToReturn, sortClauses, 
				groupByClause, allowDuplicates, pageNumber, pageSize );

			return GetAsDataReader( transactionToUse, query, readerBehavior );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, bool allowDuplicates )
		{
			GetAsProjection( valueProjectors, projector, transactionToUse, fields, filter, relations, maxNumberOfItemsToReturn, null, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates )
		{
			GetAsProjection( valueProjectors, projector, transactionToUse, fields, filter, relations, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize )
		{
			GetAsProjection( valueProjectors, projector, transactionToUse, fields, filter, relations, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 
					pageNumber, pageSize );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause,
			bool allowDuplicates, int pageNumber, int pageSize )
		{
			using( IRetrievalQuery query = CreateQueryFromElements( transactionToUse, fields, filter, relations, maxNumberOfItemsToReturn, sortClauses, groupByClause,
					allowDuplicates, pageNumber, pageSize ) )
			{
				GetAsProjection( valueProjectors, projector, transactionToUse, query );
			}
		}


		/// <summary>
		/// Executes the passed in retrievalquery and projects the resultset using the value projectors and the projector specified.
		/// IF a transaction is specified, the command is wired to the transaction and executed inside the transaction. The projection results
		/// will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="queryToExecute">The query to execute.</param>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse,
			IRetrievalQuery queryToExecute )
		{
			try
			{
				using( IDataReader datasource = GetAsDataReader(transactionToUse, queryToExecute, CommandBehavior.Default ) )
				{
					ProjectionUtils.FetchProjectionFromReader( valueProjectors, projector, datasource, (int)queryToExecute.MaxNumberOfItemsToReturnClientSide,
						queryToExecute.ManualPageNumber, queryToExecute.ManualPageSize, queryToExecute.RequiresClientSideLimitation,
						queryToExecute.RequiresClientSideDistinctFiltering, queryToExecute.RequiresClientSidePaging );

					datasource.Close();
				}
			}
			finally
			{
				if( transactionToUse==null )
				{
					// locally opened connection
					queryToExecute.Connection.Close();
				}
			}
		}


		/// <summary>
		/// Projects the current resultset of the passed in datareader using the value projectors and the projector specified. The reader will be left open
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="reader">The reader which points to the first row of a resultset</param>
		/// <remarks>Use this overload together with FetchDataReader if your datareader contains multiple resultsets, so you have fine-grained
		/// control over how you want to project which resultset in the datareader</remarks>
		public void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IDataReader reader )
		{
			ProjectionUtils.FetchProjectionFromReader( valueProjectors, projector, reader, 0, 0, 0, false, false, false );
		}

		
		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter, 
			IRelationCollection relations, int pageNumber, int pageSize)
		{
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, selectFilter, relations,
				null, null, pageNumber, pageSize);
		}


		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter, 
			IRelationCollection relations, IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize)
		{
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, selectFilter, relations,
						prefetchPathToUse, null, pageNumber, pageSize);
		}


		/// <summary>
		/// Retrieves in the calling entity collection object all entity objects
		/// which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to 
		/// construct the total query. It will also prefetch all related objects defined in the prefetchpath specified.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter, 
			IRelationCollection relations, IPrefetchPath prefetchPathToUse)
		{
			return GetMulti(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, entityFactoryToUse, selectFilter, relations,
				prefetchPathToUse, null, 0, 0);
		}


		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter,
			IRelationCollection relations, IPrefetchPath prefetchPathToUse, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			_entityFactory = entityFactoryToUse;
			return PerformGetMultiAction(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, selectFilter, relations,
				prefetchPathToUse, excludedIncludedFields, pageNumber, pageSize);
		}


		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		/// <remarks>Internal version used for prefetch path fetching. This method alters the relations and filter objects in a hierarchical fetch
		/// to make sure the additional relations for hierarchical fetches are returned to the caller so they can be re-used in a recursive fetch
		/// like a prefetch path fetch.</remarks>
		internal bool GetMultiInternal( ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, ref IPredicateExpression selectFilter,
			ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			_entityFactory = entityFactoryToUse;
			return PerformGetMultiActionInternal( containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses,
					ref selectFilter, ref relations, excludedIncludedFields, pageNumber, pageSize);
		}


		/// <summary>
		/// Retrieves in the passed in entity collection object all entity objects which match with the specified filter,
		/// formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns></returns>
		protected bool PerformGetMultiAction(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPredicate selectFilter, IRelationCollection relations, IPrefetchPath prefetchPathToUse,
			ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAction", "Method Enter");
			IEntityFields fieldsForQuery = _entityFactory.CreateHierarchyFields();
			IRelationCollection relationsToUse = null;
			IPredicateExpression filterToUse = null;
			CreateGetMultiFiltersRelations(selectFilter, relations, false, out filterToUse, out relationsToUse);

			int discriminatorFieldIndex = -1;
			IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityFactory.ForEntityName, false);
			if(_typeOfHierarchy == InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				discriminatorFieldIndex = info.DiscriminatorColumnIndex;
			}
			IFieldPersistenceInfo[] persistenceInfos = ExcludeFieldsFromPersistenceInfos(fieldsForQuery, excludedIncludedFields,
				_typeOfHierarchy, discriminatorFieldIndex);

			using( IRetrievalQuery selectQuery = _dqeToUse.CreateSelectDQ( fieldsForQuery.GetAsEntityFieldCoreArray(), persistenceInfos,
					DetermineConnectionToUse( containingTransaction ), filterToUse, maxNumberOfItemsToReturn, sortClauses, relationsToUse, 
					!((relationsToUse != null) && (relationsToUse.Count > 0)), null, pageNumber, pageSize ) )
			{
				ExecuteMultiRowRetrievalQuery( selectQuery, containingTransaction, collectionToFill, false, fieldsForQuery, persistenceInfos );
			}

			if((prefetchPathToUse != null) && (prefetchPathToUse.Count > 0))
			{
				// fetch the prefetchpath
				FetchPrefetchPath(collectionToFill, filterToUse, relationsToUse, maxNumberOfItemsToReturn, sortClauses, prefetchPathToUse,
					containingTransaction, ((pageNumber > 0) && (pageSize > 0)));
				// reset cached pk hashes, so collection can be re-used
				((ICollectionMaintenance)collectionToFill).ResetCachedPkHashes();
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAction", "Method Exit");
			return true;
		}

		
		/// <summary>
		/// Retrieves in the passed in entity collection object all entity objects which match with the specified filter,
		/// formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns></returns>
		/// <remarks>Internal version used for prefetch path fetching. This method alters the relations and filter objects in a hierarchical fetch
		/// to make sure the additional relations for hierarchical fetches are returned to the caller so they can be re-used in a recursive fetch
		/// like a prefetch path fetch.</remarks>
		private bool PerformGetMultiActionInternal( ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, ref IPredicateExpression selectFilter, ref IRelationCollection relations,
			ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiActionInternal", "Method Enter" );
			IEntityFields fieldsForQuery = _entityFactory.CreateHierarchyFields();
			IRelationCollection relationsToUse = null;
			IPredicateExpression filterToUse = null;
			CreateGetMultiFiltersRelations( selectFilter, relations, false, out filterToUse, out relationsToUse );
			selectFilter = filterToUse;
			relations = relationsToUse;

			int discriminatorFieldIndex = -1;
			IInheritanceInfo info = _inheritanceInfoProviderToUse.GetInheritanceInfo(_entityFactory.ForEntityName, false);
			if(_typeOfHierarchy == InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				discriminatorFieldIndex = info.DiscriminatorColumnIndex;
			}
			IFieldPersistenceInfo[] persistenceInfos = ExcludeFieldsFromPersistenceInfos(fieldsForQuery, excludedIncludedFields, 
				_typeOfHierarchy, discriminatorFieldIndex);

			using( IRetrievalQuery selectQuery = _dqeToUse.CreateSelectDQ( fieldsForQuery.GetAsEntityFieldCoreArray(), persistenceInfos,
					DetermineConnectionToUse( containingTransaction ), filterToUse, maxNumberOfItemsToReturn, sortClauses, relationsToUse, 
					!((relationsToUse != null) && (relationsToUse.Count > 0)), null, pageNumber, pageSize ) )
			{
				bool allowDuplidates = ((collectionToFill.Count <= 0) && !selectQuery.RequiresClientSideDistinctFiltering);
				ExecuteMultiRowRetrievalQuery(selectQuery, containingTransaction, collectionToFill, allowDuplidates, fieldsForQuery, persistenceInfos);
			}
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiActionInternal", "Method Exit" );
			return true;
		}


		/// <summary>
		/// Retrieves entities of the type produced by the set entityfactory, in a datatable which match the specified filter. 
		/// It will always create a new connection to the database.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>a filled datatable if succeeded, false otherwise</returns>
		protected DataTable PerformGetMultiAsDataTableAction(long maxNumberOfItemsToReturn, ISortExpression sortClauses, IPredicate selectFilter, 
				IRelationCollection relations, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAsDataTableAction(6)", "Method Enter");
			DataTable toFill = new DataTable();
			PerformGetMultiAsDataTableAction(_entityFactory.CreateFields(), toFill, maxNumberOfItemsToReturn, sortClauses, selectFilter, relations, false, null, null, pageNumber, pageSize);
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAsDataTableAction(6)", "Method Exit");
			return toFill;
		}


		/// <summary>
		/// Retrieves rows in the datatable provided which match the specified filter, containing the fields specified. 
		/// It will always create a new connection to the database.
		/// </summary>
		/// <param name="fieldsToReturn">IEntityFields implementation which forms the definition of the resultset to return.</param>
		/// <param name="tableToFill">The datatable to fill with the rows retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows or not</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected bool PerformGetMultiAsDataTableAction(IEntityFields fieldsToReturn, DataTable tableToFill, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPredicate selectFilter, IRelationCollection relations, bool allowDuplicates, IGroupByCollection groupByClause, 
			ITransaction transactionToUse, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAsDataTableAction(11)", "Method Enter");

			bool toReturn = false;
			using( IRetrievalQuery selectQuery = CreateQueryFromElements(transactionToUse, fieldsToReturn, selectFilter, relations, (int)maxNumberOfItemsToReturn, 
					sortClauses, groupByClause, allowDuplicates, pageNumber, pageSize))
			{
				WireTransaction( selectQuery, transactionToUse );
				toReturn = ExecuteMultiRowDataTableRetrievalQuery( selectQuery, CreateDataAdapter(), tableToFill, fieldsToReturn );
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformGetMultiAsDataTableAction(11)", "Method Exit");
			return toReturn;
		}
				

		/// <summary>
		/// Performs the polymorphic entity fetch for the entity type of this DAO. It will produce an entity of that type or a subtype of that type, based
		/// on the values retrieved, or an empty entity if not found. The passed in filter, is a filter to be used to filter out the entity to fetch.
		/// </summary>
		/// <param name="containingTransaction">Containing transaction.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>
		/// New entity with the data filtered by the passed in PK filter, or an empty entity if not found. Entity can be of type
		/// produced by the set entity factory (which produces entities of the type this DAO is for) or a subtype.
		/// </returns>
		protected IEntity PerformPolymorphicEntityFetch(ITransaction containingTransaction, IPredicate filter, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformPolymorphicEntityFetch", "Method Enter");

			// use collection fetch for the single entity fetch, to re-use code for entity inheritance type recovery.
			IEntityCollection container = _entityFactory.CreateEntityCollection();
			if(contextToUse!=null)
			{
				container.ActiveContext = contextToUse;
			}
			PerformGetMultiAction(containingTransaction, container, 1, null, filter, null, null, excludedIncludedFields, 0, 0);

			IEntity toReturn = null;
			if(container.Count>0)
			{
				toReturn = container[0];
			}
			else
			{
				// not found, create new one
				toReturn = _entityFactory.Create();
			}
			// clean up the temp collection so no event handlers are left behind.
			container.Clear();
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, (container.Count>0), "Entity fetch result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PerformPolymorphicEntityFetch", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Deletes from the persistent storage all entities which match with the specified filter, formulated in
		/// the predicate or predicate expression definition, of the type and subtypes of the entity owning this DAO.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		/// <remarks>Not supported for deleting entities which are part of a TargetPerEntity hierarchy</remarks>
		public int DeleteMulti(ITransaction containingTransaction, IPredicate deleteFilter)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.DeleteMulti(2)", "Method Enter");

			int numberAffected = DeleteMulti(containingTransaction, deleteFilter, null);
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.DeleteMulti(2)", "Method Exit");
			return numberAffected;
		}


		/// <summary>
		/// Deletes from the persistent storage all 'Employee' entities which match with the specified filter, formulated in
		/// the predicate or predicate expression definition.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		/// <remarks>Not supported for deleting entities which are part of a TargetPerEntity hierarchy</remarks>
		public int DeleteMulti(ITransaction containingTransaction, IPredicate deleteFilter, IRelationCollection relations)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.DeleteMulti(3)", "Method Enter");
			int numberAffected = 0;
			// for authorization create a dummy instance
			IEntity dummy = _entityFactory.Create();
			if(((EntityBase)dummy).CallOnCanBatchDeleteEntitiesDirectly())
			{
				IEntityFields fields = _entityFactory.CreateHierarchyFields();
				using(IActionQuery deleteQuery = _dqeToUse.CreateDeleteDQ(fields.GetAsPersistenceInfoArray(), DetermineConnectionToUse(containingTransaction), null, deleteFilter, relations))
				{
					numberAffected = ExecuteActionQuery(deleteQuery, containingTransaction);
				}
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, numberAffected, "delete result");
				if(numberAffected > 0)
				{
					((EntityBase)dummy).CallOnAuditDirectDeleteOfEntities(deleteFilter, relations, numberAffected);
					((EntityBase)dummy).QueueAuditorForCommitFlush();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.DeleteMulti(3)", "Method Exit");
			return numberAffected;
		}


		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated. 
		/// </summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only
		/// changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled. Use the returned value to determine if the
		/// update succeeded (value &gt; 0)</returns>
		public int UpdateMulti(IEntity entityWithNewValues, ITransaction containingTransaction, IPredicate updateFilter)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateMulti(3)", "Method Enter");
			int numberAffected = UpdateMulti(entityWithNewValues, containingTransaction, updateFilter, null);
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateMulti(3)", "Method Exit");
			return numberAffected;
		}


		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated.
		/// </summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only
		/// changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <param name="relations">Set of relations to walk to construct the total query</param>
		/// <returns>
		/// Number of entities affected, if the used persistent storage has rowcounting enabled. Use the returned value to determine if the
		/// update succeeded (value &gt; 0)
		/// </returns>
		public int UpdateMulti(IEntity entityWithNewValues, ITransaction containingTransaction, IPredicate updateFilter, IRelationCollection relations)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateMulti(3)", "Method Enter");
			int numberAffected = 0;

			if(((EntityBase)entityWithNewValues).CallOnCanBatchUpdateEntitiesDirectly())
			{
				InheritanceHierarchyType typeOfHierarchy = ((EntityBase)entityWithNewValues).GetInheritanceHierarchyType();
				IRelationCollection relationsToUse = null;

				if(typeOfHierarchy == InheritanceHierarchyType.TargetPerEntity)
				{
					IInheritanceInfo info = ((EntityBase)entityWithNewValues).GetInheritanceInfo();
					relationsToUse = new RelationCollection();
					relationsToUse.AddRange(info.RelationsToHierarchyRoot);
				}
				if(relations != null)
				{
					if(relationsToUse == null)
					{
						relationsToUse = new RelationCollection();
					}
					relationsToUse.AddRange((RelationCollection)relations);
				}

				using(IActionQuery updateQuery = _dqeToUse.CreateUpdateDQ(entityWithNewValues.Fields, DetermineConnectionToUse(containingTransaction), null, updateFilter, relationsToUse))
				{
					numberAffected = ExecuteActionQuery(updateQuery, containingTransaction);
				}
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, numberAffected, "update result");
				if(numberAffected > 0)
				{
					// audit successful direct update of entities. 
					((EntityBase)entityWithNewValues).CallOnAuditDirectUpdateOfEntities(updateFilter, relations, numberAffected);
					((EntityBase)entityWithNewValues).QueueAuditorForCommitFlush();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.UpdateMulti(3)", "Method Exit");
			return numberAffected;
		}


		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		public object GetScalar(IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations,
			IGroupByCollection groupByClause)
		{
			return GetScalar(fields, containingTransaction, filter, relations, groupByClause, true);
		}


		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Allow duplicates in the resultset.</param>
		/// <returns>
		/// the value which is the result of the expression defined on the specified field
		/// </returns>
		public object GetScalar(IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations, 
			IGroupByCollection groupByClause, bool allowDuplicates)
		{
			IRelationCollection relationsToUse = null;
			if( (relations == null) || ((relations != null) && (relations.Count <= 0)) )
			{
				if( _typeOfHierarchy == InheritanceHierarchyType.TargetPerEntity )
				{
					// add relations for hierarchy
					relationsToUse = _inheritanceInfoProviderToUse.GetHierarchyRelations( _entityName );
				}
			}
			else
			{
				relationsToUse = relations;
			}

			using( IRetrievalQuery scalarQuery = _dqeToUse.CreateSelectDQ( fields.GetAsEntityFieldCoreArray(), fields.GetAsPersistenceInfoArray(),
				DetermineConnectionToUse( containingTransaction ), filter, 1, null, relationsToUse, allowDuplicates, groupByClause ) )
			{
				return ExecuteScalarQuery( scalarQuery, containingTransaction );
			}
		}


		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows in the set defined by the query elements passed in</returns>
		public int GetDbCount(IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations, 
			IGroupByCollection groupByClause)
		{
			return GetDbCount(fields, containingTransaction, filter, relations, groupByClause, !((relations!=null)&&(relations.Count>0)));
		}


		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Allow duplicates in the resultset.</param>
		/// <returns>the number of rows in the set defined by the query elements passed in</returns>
		public int GetDbCount(IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations, 
			IGroupByCollection groupByClause, bool allowDuplicates)
		{
			IRelationCollection relationsToUse = null;
			IPredicateExpression filterToUse = null;

			PreprocessQueryElements(fields, filter, relations, ref relationsToUse, ref filterToUse);

			int toReturn = 0;
			using( IRetrievalQuery scalarQuery = _dqeToUse.CreateRowCountDQ( fields.GetAsEntityFieldCoreArray(), fields.GetAsPersistenceInfoArray(),
						DetermineConnectionToUse( containingTransaction ), filterToUse, relationsToUse, allowDuplicates, groupByClause ) )
			{
				object result = ExecuteScalarQuery( scalarQuery, containingTransaction );
				if( result != null )
				{
					try
					{
						toReturn = Convert.ToInt32( result );
					}
					catch
					{
						// swallow
					}
				}
			}
			return toReturn;
		}

		
		/// <summary>
		/// Executes the passed in action query and, if not null, runs it inside the passed in transaction.
		/// </summary>
		/// <param name="queryToExecute">ActionQuery to execute.</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <returns>execution result, which is the amount of rows affected (if applicable)</returns>
		public virtual int ExecuteActionQuery(IActionQuery queryToExecute, ITransaction containingTransaction)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteActionQuery", "Method Enter");

			if(queryToExecute.Connection == null)
			{
				queryToExecute.Connection = DetermineConnectionToUse(containingTransaction);
			}

			WireTransaction(queryToExecute, containingTransaction);
			int toReturn = queryToExecute.Execute();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toReturn, "Query Execution Result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteActionQuery", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <param name="fieldsToFill">The IEntityFields object to store the fetched data in</param>
		/// <param name="fieldPersistenceInfos">The field persistence info objects used to produce the query. This array contains null for all excluded
		/// fields and is necessary for the row fetcher. Overriders of this method should pass fieldsToFill.GetAsPersistenceInfoArray() to this parameter</param>
		public virtual void ExecuteSingleRowRetrievalQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction, IEntityFields fieldsToFill, 
			IFieldPersistenceInfo[] fieldPersistenceInfos)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteSingleRowRetrievalQuery", "Method Enter");

			WireTransaction(queryToExecute, containingTransaction);

			bool isConnectionOpenedExternal = (queryToExecute.Connection.State == ConnectionState.Open);
			IDataReader dataSource = null;
			try
			{
				if(!isConnectionOpenedExternal)
				{
					if( queryToExecute.Connection.State != ConnectionState.Open )
					{
						queryToExecute.Connection.Open();
					}
				}

				dataSource = queryToExecute.Execute(CommandBehavior.SingleRow);
				FetchOneRow(dataSource, fieldsToFill, fieldPersistenceInfos);
			}
				// all exceptions are fatal.
			finally
			{
				if(dataSource!=null)
				{
					if(!dataSource.IsClosed)
					{
						dataSource.Close();
					}
					dataSource.Dispose();
				}
				if(!isConnectionOpenedExternal)
				{
					queryToExecute.Connection.Close();
				}

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteSingleRowRetrievalQuery", "Method Exit");
			}
		}


		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <param name="collectionToFill">Collection to fill with the retrieved rows.</param>
		/// <param name="allowDuplicates">Flag to signal if duplicates in the datastream should be loaded into the collection (true) or not (false)</param>
		/// <param name="fieldsUsedForQuery">Fields used for producing the query</param>
		/// <param name="fieldPersistenceInfos">The field persistence info objects used to produce the query. This array contains null for all excluded
		/// fields and is necessary for the row fetcher. Overriders of this method should pass fieldsToFill.GetAsPersistenceInfoArray() to this parameter</param>
		public virtual void ExecuteMultiRowRetrievalQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction, 
			IEntityCollection collectionToFill, bool allowDuplicates, IEntityFields fieldsUsedForQuery, IFieldPersistenceInfo[] fieldPersistenceInfos)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteMultiRowRetrievalQuery", "Method Enter");

			WireTransaction(queryToExecute, containingTransaction);

			// construct hashtable for filtering out duplicates. Each hashtable entry is at first a section of
			// empty cells. When a hashcode is found in the set of hashes, add an entry, if not existend to this
			// hashtable. When the hashcode already is added to this hashtable, the entity of the new hashcode is
			// compared to all the entities with the same hashcode in the list related to the hashcode in this table.
			// when an equal object is found, it's a real duplicate, otherwise the entity is added to the list and the
			// collectionToFill.
			Dictionary<int, List<IEntity>> objectHashtable = new Dictionary<int, List<IEntity>>();
			Dictionary<int, object> objectHashes = new Dictionary<int, object>();
			IDataReader dataSource = null;
			bool isReadOnlySave = collectionToFill.IsReadOnly;
			bool allowEditSave = collectionToFill.AllowEdit;
			bool allowRemoveSave = collectionToFill.AllowRemove;
			bool allowNewSave = collectionToFill.AllowNew;
			bool doNotPerformAddIfPresentSave = collectionToFill.DoNotPerformAddIfPresent;
			collectionToFill.IsReadOnly = false;
			collectionToFill.DoNotPerformAddIfPresent = false;

			bool isConnectionOpenedExternal = (queryToExecute.Connection.State == ConnectionState.Open);

			// first add the existing objects to the hashtables, if they're not new
			for (int i = 0; i < collectionToFill.Count; i++)
			{
				IEntity currentEntity = collectionToFill[i];
				if(currentEntity.IsNew)
				{
					continue;
				}
				CheckForDuplicate(currentEntity, ref objectHashtable, ref objectHashes);
			}

			try
			{
				((ICollectionMaintenance)collectionToFill).SurpressListChangedEvents = true;

				if( !isConnectionOpenedExternal )
				{
					if( queryToExecute.Connection.State != ConnectionState.Open )
					{
						queryToExecute.Connection.Open();
					}
				}

				dataSource = queryToExecute.Execute(CommandBehavior.Default);
				if(dataSource==null)
				{
					// nothing to read from
					return;
				}

				if(dataSource.IsClosed)
				{
					// can't read
					return;
				}

				// Hashtable which is used to define per entity in the fieldsUsedInQuery the ordinal position in the selectlist. 
				Dictionary<string, List<ValuePair<int, int>>> hierarchyFieldAliasesToOrdinals = new Dictionary<string, List<ValuePair<int, int>>>();
				// work variable with the list of valuepairs for the current entity and its fields-ordinal relations. Set every time in case of a 
				// TargetPerEntity hierarchy and set once in all other situations.
				List<ValuePair<int, int>> fieldIndexToOrdinal = null;
				Dictionary<string, int> entityFieldStartIndexesPerEntity = null;
				int index = 0;
				bool hasExcludedFields = false;
				switch(_typeOfHierarchy)
				{
					case InheritanceHierarchyType.None:
						fieldIndexToOrdinal = new List<ValuePair<int, int>>(fieldsUsedForQuery.Count);
						for(int i=0;i<fieldsUsedForQuery.Count;i++)
						{
							IEntityField field = fieldsUsedForQuery[i];
							if(fieldPersistenceInfos[i] == null)
							{
								// field was excluded
								fieldIndexToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, -1));
								hasExcludedFields = true;
							}
							else
							{
								fieldIndexToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, index));
								index++;
							}
						}
						break;
					case InheritanceHierarchyType.TargetPerEntityHierarchy:
					case InheritanceHierarchyType.TargetPerEntity:
						// traverse from front to back, fields are packed per entity type. 
						string previousEntity = string.Empty;
						string currentEntity = string.Empty;
						entityFieldStartIndexesPerEntity = new Dictionary<string,int>();
						for(int i=0;i<fieldsUsedForQuery.Count;i++)
						{
							IEntityField field = fieldsUsedForQuery[i];
							previousEntity=currentEntity;
							currentEntity = field.ContainingObjectName;
							if(previousEntity!=currentEntity)
							{
								// new entity, create ordinal hashtable
								fieldIndexToOrdinal = new List<ValuePair<int, int>>();
								hierarchyFieldAliasesToOrdinals.Add(currentEntity, fieldIndexToOrdinal);
								entityFieldStartIndexesPerEntity.Add(currentEntity, i);
							}
							if(fieldPersistenceInfos[i] == null)
							{
								// field was excluded
								fieldIndexToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, -1));
								hasExcludedFields = true;
							}
							else
							{
								fieldIndexToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, index));
								index++;
							}
						}
						break;
				}

				// for each row fetched, create a new entity and fill it with the row
				long amountObjectsRead=0, amountObjectsSeen=0;
				// set skip amount for client side paging logic:  pagesize * (page no-1) rows. 
				long amountToSkip = queryToExecute.ManualPageSize * (queryToExecute.ManualPageNumber-1);
				object[] valuesOfRow = new object[fieldsUsedForQuery.Count];
				while(dataSource.Read())
				{
					try
					{
						dataSource.GetValues( valuesOfRow );
					}
					catch( Exception ex )
					{
						bool handled = HandleValueReadErrors( dataSource, valuesOfRow, ex );
						if( !handled )
						{
							// not handled, rethrow the exception. 
							throw;
						}
					}

					IEntity entityToAdd = null;
					IEntityFields newFields  = null;
					IEntityFactory entityFactoryToUse = _entityFactory;

					switch(_typeOfHierarchy)
					{
						case InheritanceHierarchyType.None:
							// normal procedure
							newFields = entityFactoryToUse.CreateFields();
							ReadRowIntoFields(valuesOfRow, newFields, fieldIndexToOrdinal);
							break;
						case InheritanceHierarchyType.TargetPerEntity:
						case InheritanceHierarchyType.TargetPerEntityHierarchy:
							// determine factory based on values. First expand the values to the real size of the list of fields. 
							// this is to include excluded fields (but as null), so the code to determine the type doesn't have to mess with
							// excluded indexes and can use the field indexes it knows.
							object[] valuesOfRowToUseForTypeDetermination = valuesOfRow;
							if(hasExcludedFields)
							{
								// expand it
								valuesOfRowToUseForTypeDetermination = ExpandValuesArrayToContainExcludedFieldSlots(valuesOfRow, fieldsUsedForQuery, fieldPersistenceInfos);
							}
							// determine factory based on values
							entityFactoryToUse = (IEntityFactory)_inheritanceInfoProviderToUse.GetEntityFactory(_entityName, valuesOfRowToUseForTypeDetermination, entityFieldStartIndexesPerEntity);
							newFields = entityFactoryToUse.CreateFields();
							ICollection<string> entityNamesUsed = ((EntityFields)newFields).GetEntityNamesOfFields();
							foreach(string entityNameInField in entityNamesUsed)
							{
								fieldIndexToOrdinal = hierarchyFieldAliasesToOrdinals[entityNameInField];
								ReadRowIntoFields(valuesOfRow, newFields, fieldIndexToOrdinal);
							}
							break;
					}

					newFields.State = EntityState.Fetched;
					entityToAdd	= entityFactoryToUse.Create(newFields);
					bool canLoadEntity = ((EntityBase)entityToAdd).CallOnCanLoadEntity();
					if(!canLoadEntity)
					{
						// Denied. check what to do
						switch(((EntityBase)entityToAdd).CallOnGetFetchNewAuthorizationFailureResultHint())
						{
							case FetchNewAuthorizationFailureResultHint.ClearData:
								// clear the fields
								entityToAdd.Fields = entityFactoryToUse.CreateFields();
								break;
							case FetchNewAuthorizationFailureResultHint.ThrowAway:
								// this entity should be ignored. simply continue
								continue;
						}
					}
					else
					{
						if(containingTransaction != null)
						{
							containingTransaction.Add((EntityBase)entityToAdd);
						}
						entityToAdd.IsNew = false;
					}
					((EntityBase)entityToAdd).CallOnFetchComplete();

					if(collectionToFill.ActiveContext!=null)
					{
						// check if there is already an entity with this data in the context
						entityToAdd = collectionToFill.ActiveContext.Get(entityToAdd);
					}

					bool addEntityToCollection = false;
					if( allowDuplicates )
					{
						// add it to the collectionToFill.
						addEntityToCollection = true;
						amountObjectsRead++;
						amountObjectsSeen++;
					}
					else
					{
						// test if we already have read this entity in the resultset or if it's already present in the collectionToFill. If not, add it.
						if(CheckForDuplicate(entityToAdd, ref objectHashtable, ref objectHashes))
						{
							amountObjectsSeen++;

							// not a dupe, so a legitimate object to read. Check if we have reached the page already, if we need to do clientside paging.
							if(queryToExecute.RequiresClientSidePaging)
							{
								if(amountObjectsRead >= queryToExecute.ManualPageSize)
								{
									// read enough.
									break;
								}
								if(amountObjectsSeen <= amountToSkip)
								{
									// not there yet
									continue;
								}
								// in page, add object
								addEntityToCollection = true;
								amountObjectsRead++;
							}
							else
							{
								// no manual paging, just add the object
								addEntityToCollection = true;
								amountObjectsRead++;
							}
						}
					}
					if( addEntityToCollection )
					{
						// validate first.
						((EntityBase)entityToAdd).CallValidateEntityAfterLoad();
						// .. then add.
						collectionToFill.Add( entityToAdd );
						if(canLoadEntity)
						{
							((EntityBase)entityToAdd).CallOnAuditLoadOfEntity();
						}
					}
					if((queryToExecute.RequiresClientSideLimitation)&&(amountObjectsRead>=queryToExecute.MaxNumberOfItemsToReturnClientSide))
					{
						// done.
						break;
					}
				}
			}
				// all exceptions are fatal.
			finally
			{
				if(dataSource!=null)
				{
					if(!dataSource.IsClosed)
					{
						dataSource.Close();
					}
					dataSource.Dispose();
				}
				if(!isConnectionOpenedExternal)
				{
					queryToExecute.Connection.Close();
				}
				collectionToFill.IsReadOnly = isReadOnlySave;
				collectionToFill.AllowEdit = allowEditSave;
				collectionToFill.AllowRemove = allowRemoveSave;
				collectionToFill.AllowNew = allowNewSave;
				collectionToFill.DoNotPerformAddIfPresent = doNotPerformAddIfPresentSave;

				((ICollectionMaintenance)collectionToFill).SurpressListChangedEvents = false;
				((ICollectionMaintenance)collectionToFill).RaiseListChanged( 0, ListChangedType.Reset );

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteMultiRowRetrievalQuery", "Method Exit");
			}
		}


		/// <summary>
		/// Executes the passed in retrieval query and returns the results as a datatable using the passed in data-adapter. 
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="fieldsToReturn">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>DataTable with the rows requested</returns>
		public DataTable ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, IEntityFields fieldsToReturn)
		{
			DataTable toReturn = new DataTable();
			ExecuteMultiRowDataTableRetrievalQuery(queryToExecute, dataAdapterToUse, toReturn, fieldsToReturn);
			return toReturn;
		}


		/// <summary>
		/// Executes the passed in retrieval query and returns the results in thedatatable specified using the passed in data-adapter. 
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="tableToFill">DataTable to fill</param>
		/// <param name="fieldsToReturn">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public virtual bool ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, DataTable tableToFill, 
			IEntityFields fieldsToReturn)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteMultiRowDataTableRetrievalQuery(4)", "Method Enter");

			bool useOwnFillRoutine = false;
			foreach(IEntityField field in fieldsToReturn)
			{
				if(field.TypeConverterToUse!=null)
				{
					useOwnFillRoutine=true;
					break;
				}
			}

			if(useOwnFillRoutine)
			{
				bool connectionOpenedInLocalScope = false;
				IDataReader dataSource = null;
				try
				{
					if(queryToExecute.Command.Connection.State!=ConnectionState.Open)
					{
						queryToExecute.Command.Connection.Open();
						connectionOpenedInLocalScope = true;
					}
					dataSource = queryToExecute.Execute(CommandBehavior.Default);
					// converter defined, use our own routine
					DataTableFiller.Fill(dataSource, tableToFill, fieldsToReturn.GetAsPersistenceInfoArray(), queryToExecute);
				}
				finally
				{
					if(connectionOpenedInLocalScope)
					{
						queryToExecute.Command.Connection.Close();
					}
					dataSource.Close();
					dataSource.Dispose();
				}
			}
			else
			{
				// wire up connection, command with adapter
				((IDbDataAdapter)dataAdapterToUse).SelectCommand = queryToExecute.Command;
				if(queryToExecute.RequiresClientSidePaging || queryToExecute.RequiresClientSideLimitation)
				{
					DataSet dummyDS = new DataSet();
					dummyDS.Tables.Add(tableToFill);
					if(queryToExecute.RequiresClientSidePaging)
					{
						// client side paging.
						dataAdapterToUse.Fill(dummyDS, queryToExecute.ManualPageSize * (queryToExecute.ManualPageNumber-1), queryToExecute.ManualPageSize, tableToFill.TableName);
					}
					else
					{
						// client side limitation
						dataAdapterToUse.Fill(dummyDS, 0, (int)queryToExecute.MaxNumberOfItemsToReturnClientSide, tableToFill.TableName);
					}
					dummyDS.Tables.Remove(tableToFill);
				}
				else
				{
					dataAdapterToUse.Fill(tableToFill);
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteMultiRowDataTableRetrievalQuery(4)", "Method Exit");
			return true;
		}


		/// <summary>
		/// Wires the passed in transaction to the command object of the passed in query. If no transaction is passed in, nothing is wired.
		/// </summary>
		/// <param name="queryToWire">Query to wire up with the passed in transaction</param>
		/// <param name="activeTransaction">transaction to wire to the query</param>
		private void WireTransaction(IQuery queryToWire, ITransaction activeTransaction)
		{
			if(activeTransaction==null)
			{
				// nothing to wire
				return;
			}

			queryToWire.WireTransaction(activeTransaction.PhysicalTransaction);
		}


		/// <summary>
		/// Executes the passed in query as a scalar query and returns the value returned from this scalar execution. 
		/// </summary>
		/// <param name="queryToExecute">a scalar query, which is a SELECT query which returns a single value</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <returns>the scalar value returned from the query.</returns>
		public virtual object ExecuteScalarQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteScalarQuery", "Method Enter");

			WireTransaction(queryToExecute, containingTransaction);

			bool isConnectionOpenedExternal = (queryToExecute.Connection.State == ConnectionState.Open);
			try
			{
				if(!isConnectionOpenedExternal)
				{
					if( queryToExecute.Connection.State != ConnectionState.Open )
					{
						queryToExecute.Connection.Open();
					}
				}

				// Execute the scalar query
				object toReturn = queryToExecute.ExecuteScalar();
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.ExecuteScalarQuery", "Method Exit");

				return toReturn;
			}
			finally
			{
				if(!isConnectionOpenedExternal)
				{
					queryToExecute.Connection.Close();
				}
			}
		}

		
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity to load the excluded field data into.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		public void FetchExcludedFields(IEntity entity, ITransaction containingTransaction, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			if((excludedIncludedFields == null) || (excludedIncludedFields.Count <= 0) || (entity == null))
			{
				return;
			}

			IEntityCollection collection = _entityFactory.CreateEntityCollection();
			collection.Add(entity);
			FetchExcludedFields(collection, containingTransaction, excludedIncludedFields);
		}


		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in the entities collection passed in.
		/// </summary>
		/// <param name="entities">The entities to load the excluded field data into. The entities have to be either of the same type or have to be 
		/// in the same inheritance hierarchy as the entity which factory is set in the collection.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entitycollection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind that most databases have a limit
		/// on the # of parameters per query. 
		/// </remarks>
		public void FetchExcludedFields(IEntityCollection entities, ITransaction containingTransaction, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			if((entities == null) || (entities.Count <= 0))
			{
				return;
			}
			if(entities.EntityFactoryToUse == null)
			{
				throw new ORMGeneralOperationException("The entity factory of the passed in entities collection is null.");
			}

			int batchSize = 250;
			if(ParameterisedPrefetchPathThreshold > 0)
			{
				batchSize = 5 * ParameterisedPrefetchPathThreshold;
			}
			int numberOfPkFields = DetermineNumberOfPkFields(entities[0]);
			int numberOfBatches = ((numberOfPkFields * entities.Count) / batchSize) +
										((((numberOfPkFields * entities.Count) % batchSize) == 0) ? 0 : 1);

			if(numberOfPkFields <= 0)
			{
				throw new ORMGeneralOperationException("There are no PK fields defined for the entity type in the collection. This means that there can't be any identification of the entities in the passed-in set with any row in the database. Please define a PK on every entity in the project.");
			}

			RelationCollection relations = new RelationCollection();
			EntityBase dummy = (EntityBase)entities.EntityFactoryToUse.Create();

			IEntityFields fieldsForQuery = null;

			int discriminatorIndex = -1;
			// add inheritance relations if necessary. Use the collection's factory to determine this.
			switch(_typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					IRelationCollection relationsForHierarchy = entities.EntityFactoryToUse.CreateHierarchyRelations();
					// add hierarchy relations after all other relations. These relations are for subtype retrieval of the entity type to retrieve.
					// the original passed in relations already contain relations to build the actual relations and filters, as both should contain the
					// relations to root.
					if(relationsForHierarchy != null)
					{
						relations.AddRange((RelationCollection)relationsForHierarchy);
					}
					fieldsForQuery = entities.EntityFactoryToUse.CreateHierarchyFields();
					break;
				case InheritanceHierarchyType.TargetPerEntityHierarchy:
					discriminatorIndex = dummy.GetInheritanceInfo().DiscriminatorColumnIndex;
					fieldsForQuery = entities.EntityFactoryToUse.CreateHierarchyFields();
					break;
				case InheritanceHierarchyType.None:
					fieldsForQuery = dummy.Fields;
					break;
			}

			IList excludedFieldsToUse = FilterOutIllegalExcludedFields(excludedIncludedFields.BuildFieldsToExcludeList(fieldsForQuery), _typeOfHierarchy, discriminatorIndex);
			if(excludedFieldsToUse.Count <= 0)
			{
				// no excluded fields to load
				return;
			}

			// we calculate the hashes for the entities to process. This allows us to merge the fields with the correct entity. We can't use a 
			// forward only cursor style routine based on a sorted set because GUIDs sort differently in memory than in a db. 
			Dictionary<int, List<IEntity>> entityHashes = new Dictionary<int, List<IEntity>>();
			CreateHashes(entityHashes, entities);
			EntityFields hashProducer = entities[0].Fields.Clone();

			// create fields list for fetch
			EntityFields resultFields = new EntityFields(numberOfPkFields + excludedFieldsToUse.Count);
			int fieldIndex = 0;
			for(int i = 0; i < numberOfPkFields; i++)
			{
				resultFields[fieldIndex] = dummy.Fields.PrimaryKeyFields[i];
				fieldIndex++;
			}
			for(int i = 0; i < excludedFieldsToUse.Count; i++)
			{
				resultFields[fieldIndex] = (IEntityField)excludedFieldsToUse[i];
				fieldIndex++;
			}

			int currentIndex = 0;
			CommandBehavior readerCloseBehavior = CommandBehavior.CloseConnection;
			if(containingTransaction != null)
			{
				// keep connection open instead
				readerCloseBehavior = CommandBehavior.Default;
			}
			for(int i = 0; i < numberOfBatches; i++)
			{
				// per batch load the excluded fields. Prepare the filter for the batch and send that to the fetch routine.
				PredicateExpression batchFilter = new PredicateExpression();
				Hashtable pkValues = new Hashtable();
				for(int j = 0; (((j + currentIndex) < entities.Count) && (j < batchSize)); j++)
				{
					if(numberOfPkFields > 1)
					{
						// use field compare value predicates
						PredicateExpression pkFilter = new PredicateExpression();
						for(int k = 0; k < numberOfPkFields; k++)
						{
							object pkValue = entities[currentIndex + j].GetCurrentFieldValue(dummy.Fields.PrimaryKeyFields[k].FieldIndex);
							pkFilter.AddWithAnd(new FieldCompareValuePredicate(dummy.Fields.PrimaryKeyFields[k], ComparisonOperator.Equal, pkValue));
						}
						batchFilter.AddWithOr(pkFilter);
					}
					else
					{
						// use one field 
						object pkValue = entities[currentIndex + j].GetCurrentFieldValue(dummy.Fields.PrimaryKeyFields[0].FieldIndex);
						if(pkValue != null)
						{
							pkValues[pkValue] = null;
						}
					}
				}
				if(numberOfPkFields == 1)
				{
					batchFilter.Add(new FieldCompareRangePredicate(dummy.Fields.PrimaryKeyFields[0], new ArrayList(pkValues.Keys)));
				}

				// fetch batch using a datareader.
				IDataReader reader = null;
				try
				{
					reader = GetAsDataReader(containingTransaction, resultFields, batchFilter, relations, readerCloseBehavior, batchSize, null, true);
					object[] values = new object[resultFields.Count];
					while(reader.Read())
					{
						reader.GetValues(values);

						// calculate hash from pk fields in row. Do this by setting the pk fields in hashProducer and grab the hashvalue. 
						for(int j = 0; j < numberOfPkFields; j++)
						{
							// pk fields are at the front. 
							hashProducer[dummy.Fields.PrimaryKeyFields[j].FieldIndex].CurrentValue = values[j];
						}
						int childHash = hashProducer.GetHashCode();
						List<IEntity> entitiesWithHash = null;
						if(!entityHashes.TryGetValue(childHash, out entitiesWithHash))
						{
							// hash not found, continue
							continue;
						}
						// as a hashvalue can be the result of multiple pk values, we've to do a field compare
						IEntity currentEntity = null;
						for(int j = 0; j < entitiesWithHash.Count; j++)
						{
							bool theSame = true;
							for(int k = 0; k < numberOfPkFields; k++)
							{
								theSame &= FieldUtilities.ValuesAreEqual(entitiesWithHash[j].PrimaryKeyFields[k].CurrentValue,
													hashProducer.PrimaryKeyFields[k].CurrentValue);
								if(!theSame)
								{
									// already not the same, quit
									break;
								}
							}
							if(!theSame)
							{
								continue;
							}
							currentEntity = entitiesWithHash[j];
							break;
						}

						for(int j = 0; j < excludedFieldsToUse.Count; j++)
						{
							IEntityField excludedField = (IEntityField)excludedFieldsToUse[j];
							object value = values[numberOfPkFields + j];
#if !CF
							if(excludedField.TypeConverterToUse != null)
							{
								value = excludedField.TypeConverterToUse.ConvertFrom(null, null, value);
							}
#endif
							if(value == DBNull.Value)
							{
								value = null;
							}
							currentEntity.SetNewFieldValue(excludedField.Name, value);
						}
					}
				}
				finally
				{
					reader.Close();
					reader.Dispose();
				}

				currentIndex += batchSize;
			}
		}


		/// <summary>
		/// Routine which is meant to handle value read errors when GetValues is called on the passed in reader. This routine is only called when the
		/// GetValues() method on the passed in reader throws an exception. Implementors of this routine thus have to call different methods to retrieve
		/// the values for the current row. The data has to be read into the toFill array.
		/// </summary>
		/// <param name="openReader">The open datareader, positioned at the current active row</param>
		/// <param name="toFill">array to fill with the current row's values</param>
		/// <param name="ex">The exception thrown by GetValues(toFill)</param>
		/// <returns>
		/// true if the values are succesfully read, false otherwise. By default this routine returns false. If false is returned, 
		/// ex is bubbled upwards by the caller. 
		/// </returns>
		protected virtual bool HandleValueReadErrors( IDataReader openReader, object[] toFill, Exception ex )
		{
			return false;
		}


		/// <summary>
		/// Persists the queue passed in. The queue contains ActionQueueElements and is in the right order, just save it from front to back
		/// </summary>
		/// <param name="queueToPersist">Queue to persist.</param>
		/// <param name="insertActions">if true, the actions to perform are save actions, otherwise update actions</param>
		/// <param name="transactionToUse">Transaction to use.</param>
		/// <param name="totalAmountSaved">The total amount saved.</param>
		/// <returns>bool if the actions all went ok.</returns>
		/// <remarks>It assumes a transaction, if needed, is already created and opened and passed in. All exceptions are bubbled upwards</remarks>
		internal static bool PersistQueue(List<ActionQueueElement<IEntity>> queueToPersist, bool insertActions, ITransaction transactionToUse, out int totalAmountSaved)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PersistQueue", "Method Enter");
			if(insertActions)
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "Action: Insert. Queue length: " + queueToPersist.Count, "Persistence action info");
			}
			else
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "Action: Update. Queue length: " + queueToPersist.Count, "Persistence action info");
			}

			totalAmountSaved = 0;
			
			// first add all queue members to the transaction, if applicable. This way, if the transaction rolls back mid-way, the entities not yet processed
			// but already synched with entities already processed are rolled back as well. 
			if( (transactionToUse!=null))
			{
				foreach( ActionQueueElement<IEntity> element in queueToPersist )
				{
					EntityBase entityInElement = (EntityBase)element.Entity;
					if(!entityInElement.ParticipatesInTransaction)
					{
						transactionToUse.Add(entityInElement);
					}
				}
			}

			bool queuePersisted = true;
			foreach(ActionQueueElement<IEntity> element in queueToPersist)
			{
				bool wasSuccesful = true;
				EntityBase entityToSave = (EntityBase)element.Entity;
				// do test if entity is really dirty. An entity can end up in the queue and not be marked dirty if the entity
				// had fk syncs pending (for example an entity which is an intermediate entity for an m:n relation, with solely fk fields)
				// and the PK syncs turned out to be not succesful, because the fk fields already contained that value.
				// if the entity turns out to be not dirty and not new, simply skip it and move on to the next one.
				if(!entityToSave.IsDirty && !entityToSave.IsNew)
				{
					// not changed nor new, no fields to update, skip
					continue;
				}

				IPredicateExpression updateRestriction = element.AdditionalUpdateFilter;
				TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave.GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave), "Current persisted entity info");
				entityToSave.CallOnSave();
				// participates in the save process, validate the entity.
				entityToSave.CallValidateEntityBeforeSave();

				bool authorizationFailureOccured = false;
				if(insertActions)
				{
					if(entityToSave.CallOnCanSaveNewEntity())
					{
						wasSuccesful = entityToSave.CallInsertEntity();
					}
					else
					{
						// denied, flag as failed. 
						wasSuccesful = false;
						authorizationFailureOccured = true;
					}
				}
				else
				{
					if(entityToSave.CallOnCanSaveExistingEntity())
					{
						if(updateRestriction == null)
						{
							wasSuccesful = entityToSave.CallUpdateEntity();
						}
						else
						{
							wasSuccesful = entityToSave.CallUpdateEntity(updateRestriction);
						}
					}
					else
					{
						// denied, flag as failed. 
						wasSuccesful = false;
						authorizationFailureOccured = true;
					}
				}

				if(wasSuccesful)
				{
					// succesful save, accept changes now. Mark entity as OutOfSync and not new
					if(EntityBase.MarkSavedEntitiesAsFetched)
					{
						FieldUtilities.MarkSavedFieldsObjectAsFetched(entityToSave.Fields);
					}
					else
					{
						entityToSave.Fields.State = EntityState.OutOfSync;
					}
					((EntityFields)entityToSave.Fields).AcceptChanges();
					entityToSave.IsNew = false;

					// first validate again...
					entityToSave.CallValidateEntityAfterSave();
					
					// ... then flag the entity as saved. 
					entityToSave.FlagAsSaved();

					if(wasSuccesful && (transactionToUse==null) && (entityToSave.ActiveContext!=null))
					{
						entityToSave.ActiveContext.EntitySaveCommitted(entityToSave);
					}

					if(insertActions)
					{
						// audit successful insert
						entityToSave.CallOnAuditInsertOfNewEntity();
					}
					else
					{
						// audit succesful update
						entityToSave.CallOnAuditUpdateOfExistingEntity();
					}

					totalAmountSaved++;

					entityToSave.QueueAuditorForCommitFlush();
				}
				else
				{
					if(!insertActions && !authorizationFailureOccured)
					{
						// failed. throw exception
						throw new ORMConcurrencyException("During a save action an entity's update action failed. The entity which failed is enclosed.", entityToSave);
					}
				}
				entityToSave.CallOnSaveComplete();
				queuePersisted&=wasSuccesful;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "queuePersisted result: " + queuePersisted, "PersistQueue method result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.PersistQueue", "Method Exit");

			// done.
			return queuePersisted;
		}


		/// <summary>
		/// Determines the connection to use. If transaction to use is null, a new connection is created, otherwise the connection of the transaction is used.
		/// </summary>
		/// <param name="transactionToUse">Transaction to use.</param>
		/// <returns>a ready to use connection object.</returns>
		protected abstract IDbConnection DetermineConnectionToUse(ITransaction transactionToUse);
		/// <summary>
		/// Creates a new ADO.NET data adapter.
		/// </summary>
		/// <returns>ready to use ADO.NET data-adapter</returns>
		protected abstract DbDataAdapter CreateDataAdapter();


		/// <summary>
		/// Retrieves rows in the datatable provided which match the specified filter, containing the fields specified.
		/// It will always create a new connection to the database.
		/// Special routine for MergeManyToMany.
		/// </summary>
		/// <param name="fieldsToReturn">IEntityFields implementation which forms the definition of the resultset to return.</param>
		/// <param name="tableToFill">The datatable to fill with the rows retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the datatable which avoids deadlocks on SqlServer.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		private bool GetMultiAsDataTableMergeManyToMany( IEntityFields fieldsToReturn, DataTable tableToFill, long maxNumberOfItemsToReturn,
			IPredicate selectFilter, IRelationCollection relations, ITransaction transactionToUse )
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.GetMultiAsDataTableMergeManyToMany", "Method Enter" );
			IRelationCollection relationsToUse = null;
			IPredicateExpression filterToUse = null;

			CreateGetMultiFiltersRelations( selectFilter, relations, true, out filterToUse, out relationsToUse );
			_dqeToUse.ResetCreator();

			bool toReturn = false;
			using( IRetrievalQuery selectQuery = _dqeToUse.CreateSelectDQ( fieldsToReturn, DetermineConnectionToUse( transactionToUse ),
					filterToUse, maxNumberOfItemsToReturn, null, relationsToUse, false, null, 0, 0 ) )
			{
				WireTransaction( selectQuery, transactionToUse );
				toReturn = ExecuteMultiRowDataTableRetrievalQuery( selectQuery, CreateDataAdapter(), tableToFill, fieldsToReturn );
			}
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.GetMultiAsDataTableMergeManyToMany", "Method Exit" );
			return toReturn;
		}


		/// <summary>
		/// Checks if the passed in entity is present in the hashtables passed in. If so
		/// </summary>
		/// <param name="entityToAdd">Entity which has to be tested if there was already a duplicate in the hashtables.</param>
		/// <param name="objectHashtable">See remarks</param>
		/// <param name="objectHashes">See remarks</param>
		/// <returns>true if there is no duplicate for hte passed in entity seen yet. False otherwise</returns>
		/// <remarks>construct hashtable for filtering out duplicates. Each hashtable entry is at first a section of
		/// empty cells. When a hashcode is found in the set of hashes, add an entry, if not existend to this
		/// hashtable. When the hashcode already is added to this hashtable, the entity of the new hashcode is
		/// compared to all the entities with the same hashcode in the list related to the hashcode in this table.
		/// when an equal object is found, it's a real duplicate, otherwise the entity is added to the list and the
		/// collection.</remarks>
		private bool CheckForDuplicate( IEntity entityToAdd, ref Dictionary<int, List<IEntity>> objectHashtable, ref Dictionary<int, object> objectHashes )
		{
			int entityHash = entityToAdd.GetHashCode();
			bool noDuplicateSeen = false;
			if( !objectHashes.ContainsKey( entityHash ) )
			{
				// no, so add it to the collection and its hash to the hashlist.
				objectHashes.Add( entityHash, null );
				// add new hash bucket to hashtable
				List<IEntity> newBucket = new List<IEntity>();
				newBucket.Add( entityToAdd );
				objectHashtable.Add( entityHash, newBucket );
				// flag that no duplicate has been seen.
				noDuplicateSeen = true;
			}
			else
			{
				// hashcode exists. Bucket is there.
				// Check if the entity is equal to any of the entities in the list related to this hashcode.
				List<IEntity> bucket = objectHashtable[entityHash];
				bool equalFound = false;
				for( int i = 0; i < bucket.Count; i++ )
				{
					equalFound = bucket[i].Equals( entityToAdd );
					if( equalFound )
					{
						// duplicate
						break;
					}
				}

				if( !equalFound )
				{
					// not found, no duplicate
					noDuplicateSeen = true;
					bucket.Add( entityToAdd );
				}
			}

			return noDuplicateSeen;
		}


		/// <summary>
		/// Fetches one row from the open data-reader and places that row into the passed in object rowDestination. rowDestination
		/// should match the format of the rows read by DataSource. Will only read the current row.
		/// </summary>
		/// <param name="dataSource">The open datareader used to fetch the data</param>
		/// <param name="rowDestination">The IEntityFields implementing object where the data should be stored.</param>
		/// <param name="fieldPersistenceInfos">The field persistence info objects used to produce the query. This array contains null for all excluded fields</param>
		private void FetchOneRow(IDataReader dataSource, IEntityFields rowDestination, IFieldPersistenceInfo[] fieldPersistenceInfos)
		{
			if(dataSource==null)
			{
				// nothing to read from
				return;
			}

			if(dataSource.IsClosed)
			{
				// can't read
				return;
			}

			// read 1 row. First advance to first byte
			if(dataSource.Read())
			{
				object[] values = new object[dataSource.FieldCount];
				try
				{
					dataSource.GetValues( values );
				}
				catch( Exception ex )
				{
					bool handled = HandleValueReadErrors( dataSource, values, ex );
					if( !handled )
					{
						// not handled, rethrow the exception. 
						throw;
					}
				}
				List<ValuePair<int, int>> fieldNameToOrdinal = new List<ValuePair<int, int>>(rowDestination.Count);
				int index = 0;
				for(int i = 0; i < rowDestination.Count; i++)
				{
					IEntityField field = rowDestination[i];
					if(fieldPersistenceInfos[i] == null)
					{
						// field was excluded
						fieldNameToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, -1));
					}
					else
					{
						fieldNameToOrdinal.Add(new ValuePair<int, int>(field.FieldIndex, index));
						index++;
					}
				}

				ReadRowIntoFields(values, rowDestination, fieldNameToOrdinal);

				// set state to fetched
				rowDestination.State = EntityState.Fetched;
			}
		}


		/// <summary>
		/// Fetches the values passed in into the rowDestination. 
		/// </summary>
		/// <param name="values">the values to read into rowDestination</param>
		/// <param name="rowDestination">The IEntityFields implementing object where the data should be stored.</param>
		/// <param name="fieldIndexToOrdinal">list with valuepairs with per fieldIndex the ordinal position in values.</param>
		/// <remarks>Override this routine if you want to perform string / value caching.</remarks>
		protected virtual void ReadRowIntoFields(object[] values, IEntityFields rowDestination, List<ValuePair<int, int>> fieldIndexToOrdinal)
		{
			int columnOrdinal = 0;
			for(int i=0;i<fieldIndexToOrdinal.Count;i++)
			{
				ValuePair<int, int> pair = fieldIndexToOrdinal[i];
				bool isColumnValueDBNull = false;
				EntityField fieldToSet = (EntityField)rowDestination[pair.Value1];
				object value = null;

				columnOrdinal = pair.Value2;
				if(columnOrdinal >= 0)
				{
					value = values[columnOrdinal];
					isColumnValueDBNull = (value == System.DBNull.Value);
#if !CF
					if(fieldToSet.TypeConverterToUse != null)
					{
						value = fieldToSet.TypeConverterToUse.ConvertFrom(null, null, value);
					}
#endif
				}
				else
				{
					// field was ignored
					isColumnValueDBNull = true;
				}
				fieldToSet.IsNull = isColumnValueDBNull;
				if(isColumnValueDBNull)
				{
					// Store null as value. 
					fieldToSet.ForcedCurrentValueWriteInternal(null, null);
				}
				else
				{
					// simply store the value
					fieldToSet.ForcedCurrentValueWriteInternal(value, value);
				}
			}

			rowDestination.IsDirty = false;
		}


		/// <summary>
		/// Creates the sub path filter for a parameterized Prefetch path subnode.
		/// Routine is used for all prefetch path types.
		/// </summary>
		/// <param name="rootEntities">The root entities.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		/// <param name="currentElement">The current element.</param>
		/// <param name="elementFilterPredicateExpression">The element filter predicate expression.</param>
		/// <param name="values">The values to use for the parameterized query. Key has all values of all fields concatenated as string form, Value is either 
		/// a single value if the relation has just 1 field, or an arraylist of values if the relation has more than 1 field.</param>
		private void CreateSubPathFilterParameterizedPPath( IEntityCollection rootEntities, IPrefetchPath prefetchPath, IPrefetchPathElement currentElement, 
			IPredicateExpression elementFilterPredicateExpression, Hashtable values)
		{
			if(rootEntities.Count <= 0)
			{
				return;
			}

			if( (currentElement.Relation.AmountFields == 1) && (rootEntities.Count > 1) )
			{
				// optimization: use a CompareRange predicate instead. We select this routine only if there're more than 1 root entity as
				// a WHERE field IN (value) is very slow on sqlserver, compared to WHERE field = value. 
				string aliasToUse = string.Empty;
				EntityField fieldToUse = null;
				if( currentElement.Relation.StartEntityIsPkSide )
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasFKSide;
					fieldToUse = (EntityField)currentElement.Relation.GetFKEntityFieldCore( 0 );
				}
				else
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasPKSide;
					fieldToUse = (EntityField)currentElement.Relation.GetPKEntityFieldCore( 0 );
				}

				// Values of the hashtable are single values, not wrapped in arraylist.
				ArrayList valuesToUse = new ArrayList(values.Values);
				if( valuesToUse.Count > 0 )
				{
					// there are values to compare. Now check if there's just 1. If so, create a fieldcomparevaluepredicate, otherwise a range predicate
					if( valuesToUse.Count > 1 )
					{
						elementFilterPredicateExpression.Add( new FieldCompareRangePredicate( fieldToUse, aliasToUse, valuesToUse ) );
					}
					else
					{
						elementFilterPredicateExpression.Add( new FieldCompareValuePredicate( fieldToUse, ComparisonOperator.Equal, valuesToUse[0], aliasToUse ) );
					}
				}
			}
			else
			{
				string aliasToUse = string.Empty;
				if( currentElement.Relation.StartEntityIsPkSide )
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasFKSide;
				}
				else
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasPKSide;
				}

				PredicateExpression nodeFilterSet = new PredicateExpression();
				// values are already known, as they're passed in, so all we have to do is per entry in the hashtable, create a set of predicates. 
				IEntity rootEntity = null;
				// find the first root entity matching this node
				foreach(IEntity currentRootEntity in rootEntities)
				{
					if((prefetchPath.RootEntityType != currentElement.DestinationEntityType) &&
						!(currentRootEntity.CheckIfIsSubTypeOf(currentElement.DestinationEntityType) ||
						(currentRootEntity.LLBLGenProEntityTypeValue == currentElement.DestinationEntityType)))
					{
						// current element is meant for a supertype or rootentity which is of a different type than the rootentities in the rootentity list, 
						// polymorphic prefetch path
						continue;
					}
					rootEntity = currentRootEntity;
					break;
				}
				if(rootEntity == null)
				{
					// none found
					return;
				}

				foreach( DictionaryEntry entry in values)
				{
					IPredicateExpression filter = new PredicateExpression();
					IEntityField compareField = null;

					// construct the filter based on the given relation. Start entity in the relation is always the parent entity for this fetch.
					if(currentElement.Relation.AmountFields > 1)
					{
						ArrayList valueList = (ArrayList)entry.Value;

						for(int j = 0; j < currentElement.Relation.AmountFields; j++)
						{
							IEntityField valueField = null;
							if(currentElement.Relation.StartEntityIsPkSide)
							{
								valueField = rootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(j).Name];
								compareField = (IEntityField)currentElement.Relation.GetFKEntityFieldCore(j);
							}
							else
							{
								valueField = rootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(j).Name];
								compareField = (IEntityField)currentElement.Relation.GetPKEntityFieldCore(j);
							}
							filter.Add(new FieldCompareValuePredicate(compareField, ComparisonOperator.Equal, valueList[j], aliasToUse));
						}
					}
					else
					{
						IEntityField valueField = null;
						if(currentElement.Relation.StartEntityIsPkSide)
						{
							valueField = rootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(0).Name];
							compareField = (IEntityField)currentElement.Relation.GetFKEntityFieldCore(0);
						}
						else
						{
							valueField = rootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(0).Name];
							compareField = (IEntityField)currentElement.Relation.GetPKEntityFieldCore(0);
						}
						filter.Add(new FieldCompareValuePredicate(compareField, ComparisonOperator.Equal, entry.Value, aliasToUse));
					}

					// add the filter for the sub entities for this particular root entity to the nodeFilterSet, which we'll add later on as the single
					// expression for the path. it's a separate expression to avoid conflicts with additional filters. 
					nodeFilterSet.AddWithOr( filter );
				}

				if( nodeFilterSet.Count > 0 )
				{
					// add the filters for the entities to fetch for this path node to the filter to use in this fetch.
					elementFilterPredicateExpression.AddWithOr( nodeFilterSet );
				}
			}
		}



		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="rootEntities">EntityCollection object containing one or more root objects which will contain the entities to fetch (and their paths)
		/// defined in the prefetch path.</param>
		/// <param name="filter">filter information used to retrieve the root entities.</param>
		/// <param name="relations">relations information used to retrieve the root entities</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return limit used to retrieve the root entities.</param>
		/// <param name="sortClauses">SortClause expression which was applied to the query executed to retrieve the root entities</param>
		/// <param name="prefetchPath">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="containingTransaction">The transaction the caller is in.</param>
		/// <param name="forceParameterizedPPath">if set to true, it always will use a parameterized prefetch path, no matter what. Used for paging
		/// scenario's</param>
		private void FetchPrefetchPath(IEntityCollection rootEntities, IPredicate filter, IRelationCollection relations, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath prefetchPath, ITransaction containingTransaction, bool forceParameterizedPPath)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.FetchPrefetchPath", "Method Enter");

			if(rootEntities.Count<=0)
			{
				// no root objects, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.FetchPrefetchPath: No root objects.", "Method Exit");
				return;
			}

			if (prefetchPath == null)
			{
				// no prefetch path specified
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DaoBase.FetchPrefetchPath: No prefetch path.", "Method Exit");
				return;
			}

			int pkCount = DetermineNumberOfPkFields(rootEntities[0]);
			int setCount = rootEntities.Count;

			// if the # of root elements is already below the threshold, we can always use a parameterized query instead of a subquery, as the # of pk fields
			// or the # of fk values will never be above the threshold for this path element's subnodes. 
			bool alwaysUseParameterizedQueryForElement = (forceParameterizedPPath ||
				((((setCount * pkCount) <= ParameterisedPrefetchPathThreshold) && (pkCount > 0)) ||
				((pkCount == 0) && (setCount <= ParameterisedPrefetchPathThreshold))));

			InheritanceHierarchyType hierarchyTypeOfRootEntities = ((EntityBase)rootEntities[0]).GetInheritanceHierarchyType();

			// no shortcut possible, as the threshold is set to a smaller value than this prefetch path fetch requires, so a regular prefetch path
			// fetch.
			for(int i=0;i<prefetchPath.Count;i++)
			{
				IPrefetchPathElement currentElement = prefetchPath[i];
				bool rootEntitiesArePkSide = currentElement.Relation.StartEntityIsPkSide;

				if(hierarchyTypeOfRootEntities == InheritanceHierarchyType.None)
				{
					if(prefetchPath.RootEntityType!=currentElement.DestinationEntityType)
					{
						// not in a hierarchy. The element is added to a path which is illegal.
						throw new ApplicationException(
							string.Format("The prefetch path element at index {0} in the passed in prefetch path for root entity type {1} is meant for root entity type {2} which isn't a subtype of {1}. This means that you've added a prefetch path node to a Path of an unrelated entity, like adding OrderDetailsEntity.PrefetchPathProduct to a prefetch path for CustomerEntity.", 
							i, prefetchPath.RootEntityType, currentElement.DestinationEntityType));
					}
				}

				// switch off lazy loading for this element.
				for (int j = 0; j < rootEntities.Count; j++)
				{
					rootEntities[j].SetRelatedEntityProperty(currentElement.PropertyName, null);
				}

				IRelationCollection elementFilterRelations = new RelationCollection();
				IPredicateExpression elementFilterPredicateExpression = new PredicateExpression();

				// now determine if we need a parameterized query or a subquery based query. 
				// the following rules apply: (N is the root entities node, N+1 is the node we're going to fetch in this routine now)
				// if N is on the PK side in the N - (N+1) relation, then if alwaysUseParameterizedQueryForElement is true, use a parameterized query
				// if N is on the FK side in that relation, use a parameterized query if alwaysUseParameterizedQueryForElement is true OR if the 
				// total # of different FK values * the # of fk fields is smaller than the threshold. Otherwise use a subquery.
				Hashtable values = null;
				int amountRootEntitiesUsable = 0;

				bool useParameterizedQuery = false;
				if(rootEntitiesArePkSide || (currentElement.TypeOfRelation == RelationType.ManyToMany))
				{
					if(alwaysUseParameterizedQueryForElement)
					{
						useParameterizedQuery = true;
					}
				}
				else
				{
					// fk side, count the # of distinct values
					values = DetermineDifferentValuesForParameterizedPPath(rootEntities, prefetchPath, currentElement, ref amountRootEntitiesUsable);
					useParameterizedQuery = ((values.Count * currentElement.Relation.AmountFields) < ParameterisedPrefetchPathThreshold);
				}

				if(useParameterizedQuery)
				{
					if(values == null)
					{
						// calculate values, as they haven't been calculated yet
						values = DetermineDifferentValuesForParameterizedPPath(rootEntities, prefetchPath, currentElement, ref amountRootEntitiesUsable);
					}
					// check if there are even rootentities considered. If not, a subpath is specified for rootentities of a subtype which isn't part of the rootentities
					// collection, so we canjust ignore this complete path, as no entity will be matching the query.
					if(amountRootEntitiesUsable <= 0)
					{
						continue;
					}
					CreateSubPathFilterParameterizedPPath(rootEntities, prefetchPath, currentElement, elementFilterPredicateExpression, values);
				}
				else
				{
					CreateSubPathFilterSubQueryPPath(filter, relations, currentElement, elementFilterPredicateExpression, maxNumberOfItemsToReturn, sortClauses);
				}
				

				// append extra relations and filters, if applicable.
				if(currentElement.FilterRelations!=null)
				{
					for (int j = 0; j < currentElement.FilterRelations.Count; j++)
					{
						EntityRelation currentRelation = (EntityRelation)currentElement.FilterRelations[j];
						elementFilterRelations.Add(currentRelation, currentRelation.AliasStartEntity, currentRelation.AliasEndEntity, currentRelation.HintForJoins);
					}
				}
				if(currentElement.Filter!=null)
				{
					if(currentElement.Filter.Count>0)
					{
						elementFilterPredicateExpression.AddWithAnd(currentElement.Filter);
					}
				}

				// execute the fetch. 
				if(containingTransaction!=null)
				{
					if(!((ITransactionalElement)currentElement.RetrievalCollection).ParticipatesInTransaction)
					{
						containingTransaction.Add( (ITransactionalElement)currentElement.RetrievalCollection );	
					}
				}
				
				if(rootEntities.ActiveContext!=null)
				{
					currentElement.RetrievalCollection.ActiveContext = rootEntities.ActiveContext;
				}
				
				((IEntityCollectionAccess)currentElement.RetrievalCollection).GetMultiInternal(ref elementFilterPredicateExpression, 0, currentElement.Sorter, ref elementFilterRelations, currentElement.ExcludedIncludedFields, 0, 0);

				/////////////
				// merge the entities fetched with the entities in the rootEntities collection. 
				/////////////
				if(currentElement.TypeOfRelation==RelationType.ManyToMany)
				{
					MergeManyToMany(currentElement, elementFilterPredicateExpression, elementFilterRelations, maxNumberOfItemsToReturn, rootEntities, containingTransaction);
				}
				else
				{
					MergeNormal(rootEntities, currentElement, rootEntitiesArePkSide);
				}

				if(currentElement.SubPath.Count>0)
				{
					FetchPrefetchPath(currentElement.RetrievalCollection, elementFilterPredicateExpression, elementFilterRelations, currentElement.MaxAmountOfItemsToReturn, currentElement.Sorter, 
						currentElement.SubPath, containingTransaction, false);
				}
				// clear the retrieval collection and cached PK hashes, so the path can be re-used.
				((ICollectionMaintenance)currentElement.RetrievalCollection).Clear();
				((ICollectionMaintenance)currentElement.RetrievalCollection).ResetCachedPkHashes();
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.FetchPrefetchPath", "Method Exit");
		}

		/// <summary>
		/// Determines the different values for the parameterized query fragment of a prefetch path node fetch.
		/// </summary>
		/// <param name="rootEntities">The root entities.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		/// <param name="currentElement">The current element.</param>
		/// <param name="amountRootEntitiesUsable">The amount root entities usable. Determined by this routine</param>
		/// <returns>
		/// Hashtable with the different values for all fields in the relation together as a string as key, value is a list of all the values, field index
		/// in relation is index in list.
		/// </returns>
		/// <remarks>If the relation contains more than 1 field, the returned hashtable contains only the unique tuples of the values per root entity.
		/// If the root entity is on the PK side, all root entities are used, as the values to add are the PK values of the root entities. If the 
		/// root entity is on the FK side, many duplicates could exist which are filtered out by this routine.</remarks>
		private Hashtable DetermineDifferentValuesForParameterizedPPath(IEntityCollection rootEntities, IPrefetchPath prefetchPath, IPrefetchPathElement currentElement,
				ref int amountRootEntitiesUsable)
		{
			Hashtable values = new Hashtable();

			foreach(IEntity currentRootEntity in rootEntities)
			{
				if((prefetchPath.RootEntityType != currentElement.DestinationEntityType) &&
					!(currentRootEntity.CheckIfIsSubTypeOf(currentElement.DestinationEntityType) ||
					(currentRootEntity.LLBLGenProEntityTypeValue == currentElement.DestinationEntityType)))
				{
					// current element is meant for a supertype or rootentity which is of a different type than the rootentities in the rootentity list, 
					// polymorphic prefetch path
					continue;
				}

				bool useEntity = true;
				StringBuilder valuesAsString = new StringBuilder();
				ArrayList valueList = new ArrayList();
				Hashtable byteArrayValues = new Hashtable(); // key: Guid, value: byte array value. Only used in this routine if the field is a byte[] type
				for(int j = 0; j < currentElement.Relation.AmountFields; j++)
				{
					IEntityField valueField = null;
					if(currentElement.Relation.StartEntityIsPkSide)
					{
						valueField = currentRootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(j).Name];
					}
					else
					{
						valueField = currentRootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(j).Name];
					}
					if(valueField.IsNull || (valueField.CurrentValue == null))
					{
						// value field is null, this means that the related entity is never there, as there's no related entity. 
						useEntity = false;
						break;
					}
					if(valueField.DataType == typeof(byte[]))
					{
						// check if the array is already in the list. This can't be done with hashes as the chance for a duplicate hashes is high and therefore we
						// still had to check for value-equality
						bool found = false;
						foreach(DictionaryEntry entry in byteArrayValues)
						{
							if(FieldUtilities.CheckArraysAreEqual((Array)entry.Value, (Array)valueField.CurrentValue))
							{
								// found duplicate
								found = true;
								break;
							}
						}
						if(!found)
						{
							Guid valueID = Guid.NewGuid();
							byteArrayValues.Add(valueID, valueField.CurrentValue);
							valuesAsString.AppendFormat(null, ":|:{0}", valueID.ToString());
							valueList.Add(valueField.CurrentValue);
						}
					}
					else
					{
						valuesAsString.AppendFormat(null, ":|:{0}", valueField.CurrentValue);
						valueList.Add(valueField.CurrentValue);
					}
				}
				if(!useEntity || (valueList.Count <= 0))
				{
					continue;
				}
				else
				{
					if(valueList.Count > 1)
					{
						values[valuesAsString.ToString()] = valueList;
					}
					else
					{
						values[valuesAsString.ToString()] = valueList[0];
					}
				}
				amountRootEntitiesUsable++;
			}

			return values;
		}


		/// <summary>
		/// Creates the sub path filter for a sub query using prefetch path node fetch
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="currentElement">The current element.</param>
		/// <param name="elementFilterPredicateExpression">The element filter predicate expression.</param>
		/// <param name="maxNumberOfItemsToReturn">The maxNumberOfItemsToReturn value used for fetching the root elements. Used when currentElement
		/// is at graphLevel 0 (top of graph)</param>
		/// <param name="sorter">The sorter used for fetching the root elements. Used when currentElement
		/// is at graphLevel 0 (top of graph)</param>
		private void CreateSubPathFilterSubQueryPPath(IPredicate filter, IRelationCollection relations, IPrefetchPathElement currentElement,
				IPredicateExpression elementFilterPredicateExpression, long maxNumberOfItemsToReturn, ISortExpression sorter)
		{
			IRelationCollection elementFilterSubQueryRelations = null;
			IPredicateExpression elementFilterSubQueryFilter = null;
			if(filter != null)
			{
				elementFilterSubQueryFilter = new PredicateExpression(filter);
			}

			if(relations != null)
			{
				elementFilterSubQueryRelations = new RelationCollection();
				elementFilterSubQueryRelations.AddRange((RelationCollection)relations);
			}

			if(currentElement.Relation.StartEntityIsPkSide)
			{
				// add pkside inheritance info, if present to the relations collection.
				if(currentElement.Relation.InheritanceInfoPkSideEntity != null)
				{
					if(elementFilterSubQueryRelations == null)
					{
						elementFilterSubQueryRelations = new RelationCollection();
					}
					elementFilterSubQueryRelations.AddRange(currentElement.Relation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot);
				}
			}
			else
			{
				// add fkside inheritance info, if present to the relations collection.
				if(currentElement.Relation.InheritanceInfoFkSideEntity != null)
				{
					if(elementFilterSubQueryRelations == null)
					{
						elementFilterSubQueryRelations = new RelationCollection();
					}
					elementFilterSubQueryRelations.AddRange(currentElement.Relation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot);
				}
			}

			long maxLimitToUse = 0;
			ISortExpression sorterToUse = null;
			if((currentElement.GraphLevel <= 0) && PrefetchPath.UseRootMaxLimitAndSorterInPrefetchPathSubQueries)
			{
				maxLimitToUse = maxNumberOfItemsToReturn;
				sorterToUse = sorter;
			}
			if(currentElement.TypeOfRelation == RelationType.ManyToMany)
			{
				// Construct the filter based on the given relation, which is the relation between the start entity and the intermediate entity.
				// Start entity in the relation is always the parent entity for this fetch. 
				for(int j = 0; j < currentElement.Relation.AmountFields; j++)
				{
					// root objects are PK side, so the subquery will contain the PK fields, and the intermediate entities joined to the 
					// to fetch the FK fields
					elementFilterPredicateExpression.Add(new FieldCompareSetPredicate(
						currentElement.Relation.GetFKEntityFieldCore(j), currentElement.Relation.GetFKFieldPersistenceInfo(j),
						currentElement.Relation.GetPKEntityFieldCore(j), currentElement.Relation.GetPKFieldPersistenceInfo(j), SetOperator.In,
						elementFilterSubQueryFilter, elementFilterSubQueryRelations, ((EntityRelation)currentElement.Relation).AliasFKSide, maxLimitToUse, 
						sorterToUse));
				}
			}
			else
			{
				// construct the filter based on the given relation. Start entity in the relation is always the parent entity for this fetch. 
				for(int j = 0; j < currentElement.Relation.AmountFields; j++)
				{
					if(currentElement.Relation.StartEntityIsPkSide)
					{
						// root objects are PK side, so the subquery will contain the PK fields, and the entities to fetch the FK fields
						elementFilterPredicateExpression.Add(new FieldCompareSetPredicate(
							currentElement.Relation.GetFKEntityFieldCore(j), currentElement.Relation.GetFKFieldPersistenceInfo(j),
							currentElement.Relation.GetPKEntityFieldCore(j), currentElement.Relation.GetPKFieldPersistenceInfo(j), SetOperator.In,
							elementFilterSubQueryFilter, elementFilterSubQueryRelations, ((EntityRelation)currentElement.Relation).AliasFKSide, maxLimitToUse,
							sorterToUse));
					}
					else
					{
						// root objects are FK side, so the subquery will contain the FK fields, and the entities to fetch the PK fields
						elementFilterPredicateExpression.Add(new FieldCompareSetPredicate(
							currentElement.Relation.GetPKEntityFieldCore(j), currentElement.Relation.GetPKFieldPersistenceInfo(j),
							currentElement.Relation.GetFKEntityFieldCore(j), currentElement.Relation.GetFKFieldPersistenceInfo(j),
							SetOperator.In,
							elementFilterSubQueryFilter, elementFilterSubQueryRelations, ((EntityRelation)currentElement.Relation).AliasPKSide, maxLimitToUse,
							sorterToUse));
					}
				}
			}
		}


		/// <summary>
		/// Merges the fetched entities in currentElement.RetrievalCollection with the root entities for normal relations (i.e. not m:n)
		/// </summary>
		/// <param name="rootEntities">Root entities.</param>
		/// <param name="currentElement">Current element.</param>
		/// <param name="rootEntitiesArePkSide">Root entities are pk side.</param>
		private void MergeNormal(IEntityCollection rootEntities, IPrefetchPathElement currentElement, bool rootEntitiesArePkSide)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.MergeNormal", "Method Enter");

			Dictionary<IEntity, int> maxCountersPerRootEntity = null;
			int initialSize = rootEntities.Count;
			if(!rootEntitiesArePkSide)
			{
				initialSize = currentElement.RetrievalCollection.Count;
			}
			Dictionary<int, List<IEntity>> pkSideHashes = new Dictionary<int, List<IEntity>>( initialSize );

			IEntityCollection fkSideCollection, pkSideCollection;
			if( rootEntitiesArePkSide )
			{
				// the root entities contain the PK's, add these to the hashtable
				pkSideCollection = rootEntities;
				fkSideCollection = currentElement.RetrievalCollection;
				maxCountersPerRootEntity = new Dictionary<IEntity,int>(rootEntities.Count);
			}
			else
			{
				// the fetched entities contain the PK's, add these to the hashtable
				pkSideCollection = currentElement.RetrievalCollection;
				fkSideCollection = rootEntities;
			}

			if( ((IEntityCollectionAccess)pkSideCollection).GetCachedPkHashes() == null )
			{
				// calculate the hashes
				((IEntityCollectionAccess)pkSideCollection).SetCachedPkHashes( pkSideHashes );
				CreateHashes( pkSideHashes, pkSideCollection );
			}
			else
			{
				pkSideHashes = ((IEntityCollectionAccess)pkSideCollection).GetCachedPkHashes();
			}

			// per entity on the FK side, calculate the FK hash and find the PK entity using the hashtable and the exact values. 
			for (int j = 0; j < fkSideCollection.Count; j++)
			{
				int fkHash = 0;
				bool fkSideRejected = false;
				for(int k=0;k<currentElement.Relation.AmountFields;k++)
				{
					IEntityFieldCore fkField = fkSideCollection[j].Fields[currentElement.Relation.GetFKEntityFieldCore(k).Name];
					if(fkField==null)
					{
						// probably a supertype and the prefetch path was for a subtype 
						fkSideRejected = true;
						break;
					}
					if(k==0)
					{
						fkHash = fkField.GetHashCode();
					}
					else
					{
						fkHash ^= fkField.GetHashCode();
					}
				}

				if(fkSideRejected)
				{
					continue;
				}

				// with hash, find PK object.
				IEntity pkObject = FindPkObject(pkSideHashes, fkHash, fkSideCollection[j], currentElement.Relation);
				if(pkObject==null)
				{
					// no pk object found. continue
					continue;
				}

				// merge. 
				if(rootEntitiesArePkSide)
				{
					if(DetermineIfMerge(maxCountersPerRootEntity, pkObject, currentElement.MaxAmountOfItemsToReturn))
					{
						pkObject.SetRelatedEntityProperty(currentElement.PropertyName, fkSideCollection[j]);
					}
				}
				else
				{
					fkSideCollection[j].SetRelatedEntityProperty(currentElement.PropertyName, pkObject);
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.MergeNormal", "Method Exit");
		}


		/// <summary>
		/// Merges the entities fetched in currentElement.RetrievalCollection with the rootEntities for a many to many relation
		/// </summary>
		/// <param name="currentElement">Current element.</param>
		/// <param name="filter">Element filter.</param>
		/// <param name="relations">element filter relations</param>
		/// <param name="maxNumberOfItemsToReturn">Max number of items to return.</param>
		/// <param name="rootEntities">Root entities.</param>
		/// <param name="containingTransaction">the transaction we're in, if applicable.</param>
		private void MergeManyToMany(IPrefetchPathElement currentElement, IPredicateExpression filter, IRelationCollection relations, long maxNumberOfItemsToReturn, 
			IEntityCollection rootEntities, ITransaction containingTransaction)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.MergeManyToMany", "Method Enter");

			Dictionary<int, List<IEntity>> pkSideHashes = new Dictionary<int, List<IEntity>>();

			// special case. Retrieve in a typed list, the different PK fields related to eachother via the m:n relation. These
			// sets are required to make the proper merges. 
			EntityFields manyToManyPkPkFields = new EntityFields(currentElement.FilterRelations[0].AmountFields + currentElement.FilterRelations[1].AmountFields);
			// add start entity PK fields:
			int fieldsIndex = 0;
			EntityField fieldToAdd = null;

			for( int j = 0; j < currentElement.FilterRelations[0].AmountFields; j++ )
			{
				fieldToAdd = (EntityField)((EntityField)currentElement.FilterRelations[0].GetPKEntityFieldCore( j )).Clone();
				fieldToAdd.Alias = fieldToAdd.Name + fieldsIndex.ToString();
				fieldToAdd.ObjectAlias = currentElement.FilterRelations[0].AliasStartEntity;
				manyToManyPkPkFields[fieldsIndex] = fieldToAdd;
				fieldsIndex++;
			}
	
			for( int j = 0; j < currentElement.FilterRelations[1].AmountFields; j++ )
			{
				fieldToAdd = (EntityField)((EntityField)currentElement.FilterRelations[1].GetPKEntityFieldCore( j )).Clone();
				fieldToAdd.Alias = fieldToAdd.Name + fieldsIndex.ToString();
				fieldToAdd.ObjectAlias = currentElement.FilterRelations[1].AliasEndEntity;
				manyToManyPkPkFields[fieldsIndex] = fieldToAdd;
				fieldsIndex++;
			}

			DataTable pkpkFields = new DataTable();
			GetMultiAsDataTableMergeManyToMany( manyToManyPkPkFields, pkpkFields, maxNumberOfItemsToReturn, filter, relations, containingTransaction );

			// Create root entity hashes.
			CreateHashes(pkSideHashes, rootEntities);

			// create hashtables and fill them so we get end entity hash to datarow and datarow to start entity hash
			Dictionary<int, List<DataRow>> endEntityPkHashToDataRow = new Dictionary<int, List<DataRow>>();
			Dictionary<DataRow, int> dataRowToStartEntityPkHash = new Dictionary<DataRow, int>();
			CreateHashes( dataRowToStartEntityPkHash, endEntityPkHashToDataRow, pkpkFields, currentElement.FilterRelations );

			// now walk the fetched entities and with the hashtables find the root entities this entity belongs to and merge it. More root entities
			// can be related to a fetched entity.
			Dictionary<IEntity, int> maxCountersPerRootEntity = new Dictionary<IEntity, int>(rootEntities.Count);
			for(int j = 0; j < currentElement.RetrievalCollection.Count; j++)
			{
				IEntity currentEntity = currentElement.RetrievalCollection[j];
				int currentEntityHash = currentEntity.GetHashCode();
				if(!endEntityPkHashToDataRow.ContainsKey(currentEntityHash))
				{
					// not found, continue
					continue;
				}
				List<DataRow> dataRows = endEntityPkHashToDataRow[currentEntityHash];

				// for all datarows in this arraylist, use the ones with the same values for the fields as the current entity, and then check
				// with that datarow the root entities found with the hash value for the fields in the datarow for the root entity. 
				for(int k=0;k<dataRows.Count;k++)
				{
					DataRow row = dataRows[k];
					// check if this entity's PK fields are the same as the end entity fields in this datarow.
					bool theSame = true;
					for (int m = 0; m < currentElement.FilterRelations[1].AmountFields; m++)
					{
						theSame &= (currentEntity.Fields[currentElement.FilterRelations[1].GetPKEntityFieldCore( m ).Name].CurrentValue.Equals(
							row[m + currentElement.FilterRelations[0].AmountFields] )); 
						
						if( !theSame )
						{
							// already not the same. quit
							break;
						}
					}
					if(!theSame)
					{
						continue;
					}
					int startEntityHash = dataRowToStartEntityPkHash[row];
					// get arraylist of root objects
					if(!pkSideHashes.ContainsKey(startEntityHash))
					{
						// not found, continue
						continue;
					}

					// with hash, find start object.
					IEntity startEntity = FindStartEntity( pkSideHashes, startEntityHash, currentElement.FilterRelations[0], row );
					if(startEntity==null)
					{
						// no pk object found. continue
						continue;
					}

					// merge
					if(DetermineIfMerge(maxCountersPerRootEntity, startEntity, currentElement.MaxAmountOfItemsToReturn))
					{
						startEntity.SetRelatedEntityProperty(currentElement.PropertyName, currentEntity);
					}
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DaoBase.MergeManyToMany", "Method Exit");
		}


		/// <summary>
		/// Determines if the counter for the entity passed in is lower than the maximum passed in and increases teh counter as well.
		/// </summary>
		/// <param name="maxCounters"></param>
		/// <param name="rootObject"></param>
		/// <param name="maxAmountOfItemsToReturn"></param>
		/// <returns>true if the counter is less than the maximum, which means that the merge can take place</returns>
		private bool DetermineIfMerge( Dictionary<IEntity, int> maxCounters, IEntity rootObject, long maxAmountOfItemsToReturn )
		{
			bool doMerge = true;
			if(maxAmountOfItemsToReturn>0)
			{
				// limit set
				int maxCounter = 0;
				if(maxCounters.ContainsKey(rootObject))
				{
					maxCounter = (int)maxCounters[rootObject];
				}
				maxCounter++;
				maxCounters[rootObject] = maxCounter;
				doMerge = (maxCounter<=maxAmountOfItemsToReturn);
			}

			return doMerge;
		}


		/// <summary>
		/// Finds the pk object related to the FK object passed in via the relation specified.
		/// </summary>
		/// <param name="pkSideHashes">Pk side hashes hashtable to quickly find an entity based on the hash of the PK</param>
		/// <param name="fkHash">Fk hash value</param>
		/// <param name="fkObject">Fk object, to do a value compare</param>
		/// <param name="relation">the relation between pk and fk</param>
		/// <returns>the PK object related to the FK object, located in the pkSideHashes. if not found, null is returned.</returns>
		private IEntity FindPkObject( Dictionary<int, List<IEntity>> pkSideHashes, int fkHash, IEntity fkObject, IEntityRelation relation )
		{
			IEntity toReturn = null;

			if(!pkSideHashes.ContainsKey(fkHash))
			{
				// not there
				return toReturn;
			}

			List<IEntity> entitiesWithHash = pkSideHashes[fkHash];
			for (int i = 0; i < entitiesWithHash.Count; i++)
			{
				IEntity currentEntity=entitiesWithHash[i];
				// do Field compare. 
				bool theSame = true;
				for (int j = 0; j < relation.AmountFields; j++)
				{
					IEntityField pkField = currentEntity.Fields[relation.GetPKEntityFieldCore(j).Name];
					IEntityField fkField = fkObject.Fields[relation.GetFKEntityFieldCore(j).Name];
					if(pkField.DataType.IsArray)
					{
						Array pkCurrentValue = (Array)pkField.CurrentValue;
						Array fkCurrentValue = (Array)fkField.CurrentValue;

						// do a per value comparison of the array. That is, if length is below 
						if(pkCurrentValue.Length==fkCurrentValue.Length)
						{
							for(int k=0;k<pkCurrentValue.Length;k++)
							{
								theSame&=(pkCurrentValue.GetValue(k).Equals(fkCurrentValue.GetValue(k)));
								if(!theSame)
								{
									break;
								}
							}
						}
						else
						{
							theSame = false;
						}
					}
					else
					{
						theSame&=(pkField.CurrentValue.Equals(fkField.CurrentValue));
					}
					if(!theSame)
					{
						// already not the same. quit
						break;
					}
				}
				if(!theSame)
				{
					continue;
				}
				toReturn = currentEntity;
				break;
			}

			return toReturn;
		}



		/// <summary>
		/// Finds the start entity related to the end entity passed in via the relation specified.
		/// </summary>
		/// <param name="startEntityHashes">start entity hash to arraylist with startentity (root entities) matching this hash</param>
		/// <param name="startEntityHash">startentity hash value</param>
		/// <param name="relation">the relation between intermediate and start entity, required to retrieve the right values from the datarow</param>
		/// <param name="row">datarow with start-end PK fields, one relation per row.</param>
		/// <returns>the start entity object to find. if not found, null is returned.</returns>
		private IEntity FindStartEntity(Dictionary<int, List<IEntity>> startEntityHashes, int startEntityHash, IEntityRelation relation, DataRow row )
		{
			IEntity toReturn = null;

			if(!startEntityHashes.ContainsKey(startEntityHash))
			{
				// not there
				return toReturn;
			}

			List<IEntity> entitiesWithHash = startEntityHashes[startEntityHash];
			bool theSame = true;
			for(int i=0;i<entitiesWithHash.Count;i++)
			{
				IEntity currentEntity=entitiesWithHash[i];
				for (int j = 0; j < relation.AmountFields; j++)
				{
					IEntityField pkField = currentEntity.Fields[relation.GetPKEntityFieldCore(j).Name];
					if(pkField.DataType.IsArray)
					{
						Array pkCurrentValue = (Array)pkField.CurrentValue;
						Array fkCurrentValue = (Array)row[j];

						// do a per value comparison of the array. That is, if length is below 
						if(pkCurrentValue.Length==fkCurrentValue.Length)
						{
							for(int k=0;k<pkCurrentValue.Length;k++)
							{
								theSame&=(pkCurrentValue.GetValue(k).Equals(fkCurrentValue.GetValue(k)));
								if(!theSame)
								{
									break;
								}
							}
						}
						else
						{
							theSame = false;
						}
					}
					else
					{
						theSame&=(pkField.CurrentValue.Equals(row[j]));
					}
				}
				if(!theSame)
				{
					// already not the same. quit
					break;
				}
				toReturn = currentEntity;
			}

			return toReturn;
		}


		/// <summary>
		/// Creates the hashes for the collection passed in. 
		/// </summary>
		/// <param name="hashesToFill">Hashes to fill.</param>
		/// <param name="collectionToHash">Collection to hash.</param>
		/// <remarks>construct hashtable for looking up entities through their PK. Per hash value an arraylist is created with the entities
		/// with that hashvalue. Normally 1 entity per hashvalue is stored, but this can vary depending on the fact that the Hashvalue is 
		/// an int.</remarks>
		private void CreateHashes( Dictionary<int, List<IEntity>> hashesToFill, IEntityCollection collectionToHash )
		{
			for (int i = 0; i < collectionToHash.Count; i++)
			{
				int hashValue = collectionToHash[i].GetHashCode();
				List<IEntity> entitiesPerHash = null;
				if(!hashesToFill.ContainsKey(hashValue))
				{
					// not yet there, add it
					entitiesPerHash = new List<IEntity>();
					hashesToFill.Add(hashValue, entitiesPerHash);
				}
				else
				{
					entitiesPerHash = hashesToFill[hashValue];
				}

				// add entity to arraylist for this hashvalue
				entitiesPerHash.Add(collectionToHash[i]);
			}
		}


		/// <summary>
		/// Creates the hash code to datarow relations for both the start entity and the end entity. This is required because the hashvalues
		/// calculated from PK fields is sometimes not unique. We therefore have to store the values as well to do a value compare when required.
		/// the hash to datarow hashtable has per hashvalue an array list is stored with the datarows
		/// </summary>
		/// <param name="dataRowToStartEntityPkHash">datarow to startentity hash hashtable.</param>
		/// <param name="endEntityPkHashToDataRow">End entity pk hash to datarow hashtable</param>
		/// <param name="pkpkFields">Pkpkfields datatable</param>
		/// <param name="relations">Relations.</param>
		private void CreateHashes( Dictionary<DataRow, int> dataRowToStartEntityPkHash, Dictionary<int, List<DataRow>> endEntityPkHashToDataRow, DataTable pkpkFields, IRelationCollection relations )
		{
			for (int i = 0; i < pkpkFields.Rows.Count; i++)
			{
				// create start entity Hashvalue
				int startEntityHash = 0;
				int fieldsIndex = 0;
				for (int j = 0; j < relations[0].AmountFields; j++)
				{
					if(j==0)
					{
						startEntityHash = pkpkFields.Rows[i][fieldsIndex].GetHashCode();
					}
					else
					{
						startEntityHash ^= pkpkFields.Rows[i][fieldsIndex].GetHashCode();
					}
					fieldsIndex++;
				}
				// create end entity hashvalue
				int endEntityHash = 0;
				for (int j = 0; j < relations[1].AmountFields; j++)
				{
					object value = pkpkFields.Rows[i][fieldsIndex];
					if(j==0)
					{
						endEntityHash = value.GetHashCode();
					}
					else
					{
						endEntityHash ^= value.GetHashCode();
					}
					fieldsIndex++;
				}
				// store datarow to startentity pk hash in hashtable.
				dataRowToStartEntityPkHash.Add(pkpkFields.Rows[i], startEntityHash);

				// store endentity hash to datarow in hashtable
				List<DataRow> entry = null;
				if(!endEntityPkHashToDataRow.ContainsKey(endEntityHash))
				{
					// new
					entry = new List<DataRow>();
					endEntityPkHashToDataRow.Add(endEntityHash, entry);
				}
				else
				{
					entry = endEntityPkHashToDataRow[endEntityHash];
				}
				entry.Add(pkpkFields.Rows[i]);
			}
		}


		/// <summary>
		/// Creates the get multi filters / relations for various getmulti routines.
		/// </summary>
		/// <param name="selectFilter">Select filter.</param>
		/// <param name="relations">Relations.</param>
		/// <param name="ignoreHierarchyInformation">If set to true, the hierarchy information in this object is ignored. Only done during the MergeManyToMany datatable fetch.</param>
		/// <param name="filterToUse">Filter to use.</param>
		/// <param name="relationsToUse">Relations to use.</param>
		private void CreateGetMultiFiltersRelations( IPredicate selectFilter, IRelationCollection relations, bool ignoreHierarchyInformation,
				out IPredicateExpression filterToUse, out IRelationCollection relationsToUse )
		{
			// append type filter, if applicable (not used in typedlist fetches)
			if( !ignoreHierarchyInformation && ((_inheritanceInfoProviderToUse != null) && (_entityFactory != null)) )
			{
				filterToUse = _inheritanceInfoProviderToUse.GetEntityTypeFilter( _entityFactory.ForEntityName, false );
			}
			else
			{
				filterToUse = null;
			}

			if( selectFilter != null )
			{
				if( filterToUse == null )
				{
					filterToUse = new PredicateExpression();
				}
				filterToUse.Add( selectFilter );
			}

			if( ignoreHierarchyInformation )
			{
				relationsToUse = CreateUsableRelationCollectionClone(relations);
			}
			else
			{
				switch( _typeOfHierarchy )
				{
					case InheritanceHierarchyType.TargetPerEntity:
						IRelationCollection relationsForHierarchy = _entityFactory.CreateHierarchyRelations();
						// add hierarchy relations after all other relations. These relations are for subtype retrieval of the entity type to retrieve.
						// the original passed in relations already contain relations to build the actual relations and filters, as both should contain teh
						// relations to root.
						if( relationsForHierarchy != null )
						{
							// create clone, so passed in filter can be re-used.
							relationsToUse = new RelationCollection();
							if( relations != null )
							{
								relationsToUse.AddRange( (RelationCollection)relations );
								relationsToUse.ObeyWeakRelations = relations.ObeyWeakRelations;
							}

							relationsToUse.AddRange( (RelationCollection)relationsForHierarchy );
						}
						else
						{
							relationsToUse = CreateUsableRelationCollectionClone(relations);
						}
						break;
					case InheritanceHierarchyType.TargetPerEntityHierarchy:
						relationsToUse = CreateUsableRelationCollectionClone(relations);
						break;
					default:
						relationsToUse = CreateUsableRelationCollectionClone(relations);
						break;
				}
			}

			if((filterToUse!=null) && (filterToUse.Count<=0))
			{
				filterToUse=null;
			}
		}


		/// <summary>
		/// Creates a usable relation collection clone.
		/// </summary>
		/// <param name="toClone">To clone.</param>
		/// <returns></returns>
		private IRelationCollection CreateUsableRelationCollectionClone(IRelationCollection toClone)
		{
			IRelationCollection toReturn = null;
			if(toClone == null)
			{
				return toReturn;
			}

			toReturn = new RelationCollection();
			toReturn.AddRange((RelationCollection)toClone);
			toReturn.ObeyWeakRelations = toClone.ObeyWeakRelations;

			return toReturn;
		}


		/// <summary>
		/// Creates a new predicate expression which filters on the primary key fields and the set values for the
		/// given primary key fields. If no primary key fields are specified, null is returned.
		/// </summary>
		/// <param name="fields">IEntityField collection with all the fields of the entity for which the filter has to be constructed</param>
		/// <returns>filled in predicate expression or null if no primary key fields are specified.</returns>
		public virtual IPredicateExpression CreatePrimaryKeyFilter(IEntityFields fields)
		{
			List<IPredicate> filters = CreatePrimaryKeyFilters(fields);
			if(filters==null)
			{
				return null;
			}
			return (IPredicateExpression)filters[0];
		}


		/// <summary>
		/// Creates for each entity which PK field(s) are in the passed in arraylist a new predicate expression which filters on the 
		/// primary key fields of that entity and the set values for the given primary key fields. If no primary key fields are specified, null is returned.
		/// </summary>
		/// <param name="fields">IEntityField collection with all the fields of the entity for which the filter has to be constructed</param>
		/// <returns>ArrayList with for each entity a filled in predicate expression or null if no primary key fields are specified. PK filters
		/// are stored in the same order as entities appear in the pkfields, which is the same order in which entities are located in the hierarchy
		/// (from root to leaf)</returns>
		public virtual List<IPredicate> CreatePrimaryKeyFilters(IEntityFields fields)
		{
			if(fields.Count<=0)
			{
				return null;
			}

			List<IEntityField> primaryKeyFields = new List<IEntityField>(fields.Count);
			foreach(IEntityField field in fields)
			{
				if(field.IsPrimaryKey)
				{
					primaryKeyFields.Add(field);
				}
			}

			List<IPredicate> toReturn = new List<IPredicate>(primaryKeyFields.Count);

			IPredicateExpression pkFilter = null;
			string currentEntityName = string.Empty;
			string previousEntityName = string.Empty;
			foreach(IEntityField field in primaryKeyFields)
			{
				previousEntityName = currentEntityName;
				currentEntityName = field.ContainingObjectName;

				if(previousEntityName!=currentEntityName)
				{
					pkFilter = new PredicateExpression();
					toReturn.Add(pkFilter);
				}
				pkFilter.AddWithAnd(new FieldCompareValuePredicate(field, ComparisonOperator.Equal));
			}

			return toReturn;
		}



		/// <summary>
		/// Creates the query from elements.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns></returns>
		private IRetrievalQuery CreateQueryFromElements( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates, int pageNumber, int pageSize )
		{
			IRelationCollection relationsToUse = null;
			IPredicateExpression filterToUse = null;

			PreprocessQueryElements(fields, filter, relations, ref relationsToUse, ref filterToUse);

			_dqeToUse.ResetCreator();
			if(relationsToUse != null)
			{
				((RelationCollection)relationsToUse).ToggleArtificialAliasingForTargetPerEntityRelations(true);
			}
			IRetrievalQuery query = _dqeToUse.CreateSelectDQ(fields, DetermineConnectionToUse(transactionToUse),
					filterToUse, maxNumberOfItemsToReturn, sortClauses, relationsToUse, allowDuplicates, groupByClause, pageNumber, pageSize );
			return query;
		}


		/// <summary>
		/// Preprocesses the query elements.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="filterToUse">The filter to use.</param>
		private void PreprocessQueryElements(IEntityFields fields, IPredicate filter, IRelationCollection relations, ref IRelationCollection relationsToUse, 
			ref IPredicateExpression filterToUse)
		{
			if((_typeOfHierarchy == InheritanceHierarchyType.None) && (_entityName.Length <= 0))
			{
				// TypedListDAO. 
				relationsToUse = CreateUsableRelationCollectionClone(relations);
				if(_inheritanceInfoProviderToUse != null)
				{
					// _inheritanceInfoProviderToUse is a singleton instance, so this is thread safe.
					RelationCollection hierarchyRelations = PersistenceCore.DetermineInheritanceRelations(fields, relations, filter, _inheritanceInfoProviderToUse);
					if(relationsToUse == null)
					{
						relationsToUse = new RelationCollection();
					}
					if((hierarchyRelations != null) && (hierarchyRelations.Count>0))
					{
						relationsToUse.AddRange(hierarchyRelations);
					}
				}

				if(filter != null)
				{
					filterToUse = new PredicateExpression(filter);
				}
			}
			else
			{
				CreateGetMultiFiltersRelations(filter, relations, false, out filterToUse, out relationsToUse);
			}

			// Determine if we have to add one or more type filters for fields from entities in a TargetPerEntityHierarchy. 
			// E.g.: if FamilyCompanyCar.Brand is specified, it should filter on FamilyCompanyCar or all subtypes but shouldn't return 
			// brandnames of sibling types or supertypes.
			Dictionary<string, string> typeFilterEntityCandidates = new Dictionary<string, string>();
			foreach(EntityField field in fields)
			{
				if((field.ActualContainingObjectName != field.ContainingObjectName) && !typeFilterEntityCandidates.ContainsKey(field.ActualContainingObjectName))
				{
					// field is in a different entity than it's defined in (inherited field). 
					typeFilterEntityCandidates.Add(field.ActualContainingObjectName, field.ObjectAlias);
				}
			}

			if(typeFilterEntityCandidates.Count > 0)
			{
				// filter out entities in a hierarchy of TargetPerEntity, and also filter out supertypes if the subtype is also in the list. 
				// grab the filter and set the proper object alias.
				if(filterToUse == null)
				{
					filterToUse = _inheritanceInfoProviderToUse.GetEntityTypeFilters(typeFilterEntityCandidates);
				}
				else
				{
					filterToUse.AddWithAnd(_inheritanceInfoProviderToUse.GetEntityTypeFilters(typeFilterEntityCandidates));
				}
			}
		}


		/// <summary>
		/// Expands the values array to contain slots for excluded fields so all indices on the normal set of fields match the actual fields, because
		/// the resultset of a fetch with excluded fields is smaller than the resultset of a normal fetch (no columns are there for excluded fields)
		/// </summary>
		/// <param name="valuesOfRow">The values of row.</param>
		/// <param name="fieldsUsedForQuery">The fields used for query.</param>
		/// <param name="fieldsPersistenceInfo">The fields persistence info.</param>
		/// <returns>a new object array with the values of valuesOfRow, but now with field slots for all excluded fields.</returns>
		private object[] ExpandValuesArrayToContainExcludedFieldSlots(object[] valuesOfRow, IEntityFields fieldsUsedForQuery,
							IFieldPersistenceInfo[] fieldsPersistenceInfo)
		{
			object[] toReturn = new object[fieldsUsedForQuery.Count];
			int index = 0;
			for(int i = 0; i < fieldsUsedForQuery.Count; i++)
			{
				if(fieldsPersistenceInfo[i] != null)
				{
					// normal field
					toReturn[i] = valuesOfRow[index];
					index++;
				}
			}
			return toReturn;
		}

		
		/// <summary>
		/// Excludes the persistenceinfo objects (set slots to null) for all excluded fields in 'excludedFields'.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="hierarchyType">Type of the hierarchy the entity is in or to consider. If this is is targetperentity we have to traverse the
		/// complete fields list to find a field to exclude, otherwise we can rely on the fieldindex.</param>
		/// <param name="excludedIncludedFields">The fields to exclude/include, a list of IEntityField2 instances</param>
		/// <param name="discriminatorFieldIndex">Index of the discriminator field. Is -1 if the entity doesn't have any discriminator field. Used to
		/// ignore discriminator fields in a set of excluded fields.</param>
		/// <returns>IFieldPersistenceInfo array to use with query generation. It has for every excluded field a 'null' instead of the actual persistence info.
		/// this is a clone of the field array. </returns>
		private IFieldPersistenceInfo[] ExcludeFieldsFromPersistenceInfos(IEntityFields fields, ExcludeIncludeFieldsList excludedIncludedFields, InheritanceHierarchyType hierarchyType, 
			int discriminatorFieldIndex)
		{
			IFieldPersistenceInfo[] persistenceInfos = (IFieldPersistenceInfo[])fields.GetAsPersistenceInfoArray().Clone();

			if((excludedIncludedFields == null) || (excludedIncludedFields.Count <= 0))
			{
				// nothing to exclude
				return persistenceInfos;
			}

			IList fieldsToUse = FilterOutIllegalExcludedFields(excludedIncludedFields.BuildFieldsToExcludeList(fields), hierarchyType, discriminatorFieldIndex);

			foreach(IEntityField field in fieldsToUse)
			{
				if(field.FieldIndex >= fields.Count)
				{
					continue;
				}
				switch(hierarchyType)
				{
					case InheritanceHierarchyType.None:
					case InheritanceHierarchyType.TargetPerEntityHierarchy:
						persistenceInfos[field.FieldIndex] = null;
						break;
					case InheritanceHierarchyType.TargetPerEntity:
						// traverse all fields.
						for(int i = 0; i < fields.Count; i++)
						{
							if((fields[i].Name == field.Name) && (fields[i].ContainingObjectName == field.ContainingObjectName))
							{
								// exclude
								persistenceInfos[i] = null;
								break;
							}
						}
						break;
				}
			}

			return persistenceInfos;
		}



		/// <summary>
		/// Filters out the illegal fields in the excluded fields list and returns the list without the illegal excluded fields. 
		/// </summary>
		/// <param name="excludedFields">The excluded fields.</param>
		/// <param name="hierarchyType">Type of the hierarchy.</param>
		/// <param name="discriminatorFieldIndex">Index of the discriminator field.</param>
		/// <returns>The excluded fields list without the illegal fields. Illegal fields are: PK fields, FK fields and discriminatorFields</returns>
		private IList FilterOutIllegalExcludedFields(IList excludedFields, InheritanceHierarchyType hierarchyType, int discriminatorFieldIndex)
		{
			if((excludedFields == null) || (excludedFields.Count <= 0))
			{
				return excludedFields;
			}

			ArrayList excludedFieldsToUse = new ArrayList();
			foreach(IEntityField field in excludedFields)
			{
				if(field.IsPrimaryKey || field.IsForeignKey || (field.FieldIndex == discriminatorFieldIndex) || (field.FieldIndex <= 0))
				{
					// ignore
					continue;
				}
				excludedFieldsToUse.Add(field);
			}

			return excludedFieldsToUse;
		}
		

		/// <summary>
		/// Determines the number of pk fields for the entity passed in. Normally this is the # of entries in the PK field collection, however in the case of
		/// a subtype of a targetperentity, all PK fields of the supertypes are also present in this collection and therefore this routine has to determine how
		/// many of these fields are really there.
		/// </summary>
		/// <param name="entity">The entity to check the # of PK fields for.</param>
		/// <returns>the # of pk fields</returns>
		private int DetermineNumberOfPkFields(IEntity entity)
		{
			List<IEntityField> pkFields = entity.Fields.PrimaryKeyFields;
			return FieldUtilities.DetermineNumberOfPkFields(pkFields);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets entityFactory to use
		/// </summary>
		public IEntityFactory EntityFactoryToUse
		{
			get
			{
				return _entityFactory;
			}
			set
			{
				_entityFactory = value;
			}
		}
		#endregion
		
	}
}
