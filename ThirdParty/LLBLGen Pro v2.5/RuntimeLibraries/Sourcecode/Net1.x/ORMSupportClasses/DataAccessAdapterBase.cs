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
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Base class for DAA classes which are generated.
	/// </summary>
	public abstract class DataAccessAdapterBase : IDataAccessAdapter
	{
		#region Private Enums
		/// <summary>
		/// Enum which is used to signal the element removal routine what to do while removing hte elements.
		/// This is a performance issue, now the loop has to be run just once
		/// </summary>
		private enum ActionToPerformDuringRemove:int
		{
			/// <summary>
			/// No action
			/// </summary>
			None, 
			/// <summary>
			/// Call ITransactionalElement.TransactionCommit()
			/// </summary>
			SendCommit,
			/// <summary>
			/// Call ITransactionalElement.TransactionRollback()
			/// </summary>
			SendRollback
		}
		#endregion
		
		#region Class Member Declarations
		private IsolationLevel				_transactionIsolationLevel;
		private string						_transactionName, _connectionString;
		private IDbConnection				_activeConnection;
		private IDbTransaction				_physicalTransaction;
		private ArrayList					_transactionParticipants;
		private bool						_isTransactionInProgress, _isDisposed, _keepConnectionOpen;
		private int							_commandTimeOut, _parameterisedPrefetchPathThreshold;
		private Hashtable					_transactionParticipantObjectIds, _savePointNames; 
		private IPersistenceInfoProvider	_persistenceInfoProvider;
		private ArrayList					_postponedDisposeCandidates;	// list for IQuery objects which is used to dispose query objects created for datareader fetches.
		private ArrayList					_auditorsToNotifyOnCommit;

#if !CF
		private ComPlusAdapterContextBase	_comPlusContextHost;
#endif
		#endregion

		#region Private Constants
		private const int defaultTimeOut = 30;
		private const int defaultThresholdForPrefetchPaths = 50;
		#endregion
		
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="persistenceInfoProvider">Persistence info provider.</param>
		public DataAccessAdapterBase(IPersistenceInfoProvider persistenceInfoProvider)
		{
			InitClass(null, persistenceInfoProvider);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="comPlusContextHost">the COM+ context host for this adapter instance.</param>
		/// <param name="persistenceInfoProvider">Persistence info provider.</param>
		/// <remarks>do not call this from your code</remarks>
		public DataAccessAdapterBase(IComPlusAdapterContext comPlusContextHost, IPersistenceInfoProvider persistenceInfoProvider)
		{
			InitClass(comPlusContextHost, persistenceInfoProvider);
		}


		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(IEntityField2 field, AggregateFunction aggregateToApply)
		{
			return GetScalar(field, null, aggregateToApply, null, null, null);
		}


		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply)
		{
			return GetScalar(field, expressionToExecute, aggregateToApply, null, null, null);
		}


		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, 
			IPredicate filter)
		{
			return GetScalar(field, expressionToExecute, aggregateToApply, filter, null, null);
		}


		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		public object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, 
			IPredicate filter, IGroupByCollection groupByClause)
		{
			return GetScalar(field, expressionToExecute, aggregateToApply, filter, groupByClause, null);
		}
		
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <param name="relations">The relations part of the filter.</param>
		/// <returns>the scalar value requested</returns>
		public virtual object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, 
			IPredicate filter, IGroupByCollection groupByClause, IRelationCollection relations)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetScalar(6)", "Method Enter");

			EntityFields2 fields = new EntityFields2(1);
			fields[0] = field;
			IExpression originalExpression = field.ExpressionToApply;
			AggregateFunction originalAggregateFunction = field.AggregateFunctionToApply;
			if((fields[0].ExpressionToApply == null) || (expressionToExecute != null))
			{
				fields[0].ExpressionToApply = expressionToExecute;
			}
			if((fields[0].AggregateFunctionToApply == AggregateFunction.None) || (aggregateToApply != AggregateFunction.None))
			{
				fields[0].AggregateFunctionToApply = aggregateToApply;
			}

			object toReturn = null;
			try
			{
				toReturn = GetScalar(fields, filter, groupByClause, relations);
			}
			finally
			{
				field.ExpressionToApply = originalExpression;
				field.AggregateFunctionToApply = originalAggregateFunction;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetScalar(6)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="filter">filter to use</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		public object GetScalar(IEntityFields2 fields, IPredicate filter, IGroupByCollection groupByClause)
		{
			return GetScalar(fields, filter, groupByClause, null);
		}


		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="filter">filter to use</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="relations">The relations part of the filter.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		public virtual object GetScalar(IEntityFields2 fields, IPredicate filter, IGroupByCollection groupByClause, IRelationCollection relations)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetScalar(4)", "Method Enter");

			IFieldPersistenceInfo[] persistenceInfo = new FieldPersistenceInfo[1];
			persistenceInfo[0] = GetFieldPersistenceInfo(fields[0]);
			IPredicateExpression filterExpression = null;
			if(filter!=null)
			{
				if(filter is IPredicateExpression)
				{
					// check if the expression is empty, if so skip it.
					if(((IPredicateExpression)filter).Count>0)
					{
						filterExpression = (IPredicateExpression)filter;
					}
				}
				else
				{
					// wrap in an expression
					filterExpression = new PredicateExpression(filter);
				}
			}
			InsertPersistenceInfoObjects(filterExpression);
			InsertPersistenceInfoObjects(relations);
			InsertPersistenceInfoObjects(groupByClause);
			object toReturn = null;

			using(IRetrievalQuery scalarQuery = CreateSelectDQ(fields, persistenceInfo, filterExpression, 1, null, relations, true, groupByClause, 0, 0))
			{
				toReturn = ExecuteScalarQuery(scalarQuery);
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetScalar(4)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Gets the estimated number of objects returned by a query for objects to store in the entity collection passed in, using the filter and 
		/// groupby clause specified. The number is estimated as duplicate objects can be present in the raw query results, but will be filtered out
		/// when the query result is transformed into objects.
		/// </summary>
		/// <param name="collection">EntityCollection instance which will be fetched by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		public int GetDbCount(IEntityCollection2 collection, IRelationPredicateBucket filter)
		{
			return GetDbCount(collection, filter, null);
		}


		/// <summary>
		/// Gets the estimated number of objects returned by a query for objects to store in the entity collection passed in, using the filter and 
		/// groupby clause specified. The number is estimated as duplicate objects can be present in the raw query results, but will be filtered out
		/// when the query result is transformed into objects.
		/// </summary>
		/// <param name="collection">EntityCollection instance which will be fetched by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		public int GetDbCount(IEntityCollection2 collection, IRelationPredicateBucket filter, IGroupByCollection groupByClause)
		{
			bool allowDuplicates = true;
			if(filter!=null)
			{
				allowDuplicates=!(filter.Relations.Count>0);
			}
			EntityBase2 dummy = (EntityBase2)collection.EntityFactoryToUse.Create();
			InheritanceHierarchyType hierarchyType = dummy.GetInheritanceHierarchyType();
			IEntityFields2 fieldsToPass = dummy.Fields;
			IRelationPredicateBucket filterToPass = filter;
			if(hierarchyType != InheritanceHierarchyType.None)
			{
				fieldsToPass = collection.EntityFactoryToUse.CreateHierarchyFields();
				if(hierarchyType == InheritanceHierarchyType.TargetPerEntity)
				{
					IRelationCollection relationsForHierarchy = collection.EntityFactoryToUse.CreateHierarchyRelations();
					// add hierarchy relations after all other relations. These relations are for subtype retrieval of the entity type to retrieve.
					// the original passed in relations already contain relations to build the actual relations and filters, as both should contain teh
					// relations to root.
					if(relationsForHierarchy != null)
					{
						filterToPass = CreateUsableBucketClone(filter);
						if(filterToPass == null)
						{
							filterToPass = new RelationPredicateBucket();
						}
						filterToPass.Relations.AddRange((RelationCollection)relationsForHierarchy);
					}
				}
			}
			return GetDbCount(fieldsToPass, filterToPass, groupByClause, allowDuplicates);
		}


		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		public int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter)
		{
			return GetDbCount(fields, filter, null, true);
		}


		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		public int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter, IGroupByCollection groupByClause)
		{
			return GetDbCount(fields, filter, groupByClause, true);
		}


		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		public virtual int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter, IGroupByCollection groupByClause, bool allowDuplicates)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetDbCount(4)", "Method Enter");

			IFieldPersistenceInfo[] persistenceInfo = new FieldPersistenceInfo[fields.Count];

			// get the persistence info objects for the fields in the collection
			for (int i = 0; i < fields.Count; i++)
			{
				persistenceInfo[i] = GetFieldPersistenceInfo(fields[i]);
			}

			IRelationPredicateBucket filterToUse = null;

			// if there are relations specified, nothing further has to be done. If not, hierarchy relations have to be added, IF required.
			if((filter==null)||((filter!=null)&&(filter.Relations.Count<=0)))
			{
				filterToUse = PreprocessQueryElements(fields, filter);
			}
			else
			{
				filterToUse = filter;
			}

			bool relationsPresent = false;
			IPredicateExpression expressionToPass = null;
			InterpretFilterBucket(filterToUse, ref relationsPresent, ref expressionToPass);
			InsertPersistenceInfoObjects(groupByClause);

			IRetrievalQuery scalarQuery = null;

			// construct query
			if(relationsPresent)
			{
				scalarQuery=CreateRowCountDQ(fields, persistenceInfo, expressionToPass, filterToUse.Relations, allowDuplicates, groupByClause);
			}
			else
			{
				scalarQuery=CreateRowCountDQ(fields, persistenceInfo, expressionToPass, null, allowDuplicates, groupByClause);
			}

			int toReturn = 0;
			try
			{
				object result = ExecuteScalarQuery(scalarQuery);
				if(result != null)
				{
					try
					{
						toReturn = Convert.ToInt32(result);
					}
					catch
					{
						// swallow
					}
				}
			}
			finally
			{
				scalarQuery.Dispose();
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.GetDbCount(4)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Executes the passed in query as a scalar query and returns the value returned from this scalar execution. 
		/// </summary>
		/// <param name="queryToExecute">a scalar query, which is a SELECT query which returns a single value</param>
		/// <returns>the scalar value returned from the query.</returns>
		public virtual object ExecuteScalarQuery(IRetrievalQuery queryToExecute)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteScalarQuery", "Method Enter");

			OnGetScalar(queryToExecute);
			if(queryToExecute.Connection == null)
			{
				// no connection set yet, set it.
				if(_activeConnection == null)
				{
					CreateConnection();
				}
				queryToExecute.Connection = _activeConnection;
			}

			WireTransaction(queryToExecute);
			if(_commandTimeOut>0)
			{
				queryToExecute.Command.CommandTimeout = _commandTimeOut;
			}

			OpenConnection();

			try
			{
				return queryToExecute.ExecuteScalar();
			}
			finally
			{
				if(!(_keepConnectionOpen||_isTransactionInProgress))
				{
					CloseConnection();
				}

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteScalarQuery", "Method Exit");
			}		
		}

		
		/// <summary>
		/// Executes the passed in action query and, if not null, runs it inside the passed in transaction.
		/// </summary>
		/// <param name="queryToExecute">ActionQuery to execute.</param>
		/// <returns>execution result, which is the amount of rows affected (if applicable)</returns>
		public virtual int ExecuteActionQuery(IActionQuery queryToExecute)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteActionQuery", "Method Enter");

			if(queryToExecute.Connection == null)
			{
				// no connection set yet, set it.
				if(_activeConnection == null)
				{
					CreateConnection();
				}
				queryToExecute.Connection = _activeConnection;
			}


			WireTransaction(queryToExecute);
			if(_commandTimeOut>0)
			{
				queryToExecute.SetCommandTimeout(_commandTimeOut);
			}

			OpenConnection();
			
			try
			{
				return queryToExecute.Execute();
			}
			finally
			{
				if(!(_keepConnectionOpen||_isTransactionInProgress))
				{
					CloseConnection();
				}

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteActionQuery", "Method Exit");
			}
		}


		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="fieldsToFill">The IEntityFields2 object to store the fetched data in</param>
		/// <param name="fieldsPersistenceInfo">The IFieldPersistenceInfo objects for the fieldsToFill fields</param>
		public virtual void ExecuteSingleRowRetrievalQuery(IRetrievalQuery queryToExecute, IEntityFields2 fieldsToFill, 
				IFieldPersistenceInfo[] fieldsPersistenceInfo)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteSingleRowRetrievalQuery", "Method Enter");

			queryToExecute.Connection=_activeConnection;
			WireTransaction(queryToExecute);
			IDataReader dataSource = null;
			if(_commandTimeOut>0)
			{
				queryToExecute.Command.CommandTimeout = _commandTimeOut;
			}

			try
			{
				OpenConnection();

				dataSource = queryToExecute.Execute(CommandBehavior.SingleRow);
				FetchOneRow(dataSource, fieldsToFill, fieldsPersistenceInfo);
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
				if(!(_keepConnectionOpen||_isTransactionInProgress))
				{
					CloseConnection();
				}

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteSingleRowRetrievalQuery", "Method Exit");
			}
		}


		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 or more rows.
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="entityFactory">the factory object which can produce the entities this method has to fill.</param>
		/// <param name="collectionToFill">Collection to fill with the retrieved rows.</param>
		/// <param name="fieldsPersistenceInfo">The persistence information for the fields of the entity created by entityFactory</param>
		/// <param name="allowDuplicates">Flag to signal if duplicates in the datastream should be loaded into the collection (true) or not (false)</param>
		/// <param name="fieldsUsedForQuery">Fields used for producing the query</param>
		public virtual void ExecuteMultiRowRetrievalQuery(IRetrievalQuery queryToExecute, IEntityFactory2 entityFactory, 
			IEntityCollection2 collectionToFill, IFieldPersistenceInfo[] fieldsPersistenceInfo, bool allowDuplicates,
			IEntityFields2 fieldsUsedForQuery)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowRetrievalQuery", "Method Enter");

			queryToExecute.Connection=_activeConnection;
			WireTransaction(queryToExecute);
			if(_commandTimeOut>0)
			{
				queryToExecute.Command.CommandTimeout = _commandTimeOut;
			}

			// construct hashtable for filtering out duplicates. Each hashtable entry is at first a section of
			// empty cells. When a hashcode is found in the set of hashes, add an entry, if not existend to this
			// hashtable. When the hashcode already is added to this hashtable, the entity of the new hashcode is
			// compared to all the entities with the same hashcode in the list related to the hashcode in this table.
			// when an equal object is found, it's a real duplicate, otherwise the entity is added to the list and the
			// collection.
			Hashtable objectHashtable = new Hashtable();
			Hashtable objectHashes = new Hashtable();
			EntityCollectionBase2 collection = (EntityCollectionBase2)collectionToFill;	

			IDataReader dataSource = null;
			bool isReadOnlySave = collection.IsReadOnly;
			bool allowEditSave = collection.AllowEdit;
			bool allowRemoveSave = collection.AllowRemove;
			bool allowNewSave = collection.AllowNew;
			bool doNotPerformAddIfPresentSave = collection.DoNotPerformAddIfPresent;
			collection.IsReadOnly=false;
			collection.DoNotPerformAddIfPresent=false;

			// first add the existing objects to the hashtables, if they're not new
			for (int i = 0; i < collection.Count; i++)
			{
				IEntity2 currentEntity = collection[i];
				if(currentEntity.IsNew)
				{
					continue;
				}
				CheckForDuplicate(currentEntity, ref objectHashtable, ref objectHashes);
			}

			try
			{
				OpenConnection();

				dataSource = queryToExecute.Execute(CommandBehavior.Default);
				if(dataSource==null)
				{
					// nothing to read from
					TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowRetrievalQuery: datareader is null.", "Method Exit");
					return;
				}

				if(dataSource.IsClosed)
				{
					// can't read
					TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowRetrievalQuery: datareader is closed.", "Method Exit");
					return;
				}

				// determine if the fetch concerns a hierarchy of type TargetPerEntity or not. 
				InheritanceHierarchyType typeOfHierarchy = ((EntityBase2)entityFactory.Create()).GetInheritanceHierarchyType();
				// Hashtable which is used to define per entity in the fieldsUsedInQuery the ordinal position in the selectlist.
				Hashtable hierarchyFieldAliasesToOrdinals = new Hashtable();
				// work variable with the ArrayList of IntValuePair instances for the current entity and its fields-ordinal relations. Set every time in case of a 
				// TargetPerEntity hierarchy and set once in all other situations.
				ArrayList fieldIndexToOrdinal = null;
				Hashtable entityFieldStartIndexesPerEntity = null;
				int index = 0;
				bool hasExcludedFields = false;
				switch(typeOfHierarchy)
				{
					case InheritanceHierarchyType.None:
						fieldIndexToOrdinal =new ArrayList(fieldsUsedForQuery.Count);
						for(int i=0;i<fieldsUsedForQuery.Count;i++)
						{
							IEntityField2 field = fieldsUsedForQuery[i];
							if(fieldsPersistenceInfo[i] == null)
							{
								// field was excluded
								fieldIndexToOrdinal.Add(new IntValuePair(field.FieldIndex, -1));
								hasExcludedFields=true;
							}
							else
							{
								fieldIndexToOrdinal.Add(new IntValuePair(field.FieldIndex, index));
								index++;
							}						
						}
						break;
					case InheritanceHierarchyType.TargetPerEntityHierarchy:
					case InheritanceHierarchyType.TargetPerEntity:
						// traverse from front to back, fields are packed per entity type. 
						string previousEntity = string.Empty;
						string currentEntity = string.Empty;
						entityFieldStartIndexesPerEntity = new Hashtable();
						for(int i=0;i<fieldsUsedForQuery.Count;i++)
						{
							IEntityField2 field = fieldsUsedForQuery[i];
							previousEntity=currentEntity;
							currentEntity = field.ContainingObjectName;
							if(previousEntity!=currentEntity)
							{
								// new entity, create ordinal hashtable
								fieldIndexToOrdinal = new ArrayList();
								hierarchyFieldAliasesToOrdinals.Add(currentEntity, fieldIndexToOrdinal);
								entityFieldStartIndexesPerEntity.Add(currentEntity, i);
							}
							if(fieldsPersistenceInfo[i] == null)
							{
								// field was excluded
								fieldIndexToOrdinal.Add(new IntValuePair(field.FieldIndex, -1));
								hasExcludedFields = true;
							}
							else
							{
								fieldIndexToOrdinal.Add(new IntValuePair(field.FieldIndex, index));
								index++;
							}
						}
						break;
				}

				IFieldPersistenceInfo[] persistenceInfosForRowReader = fieldsPersistenceInfo;
				if(hasExcludedFields)
				{
					// remove the null values from the fieldsPersistenceInfo, so the ordinal index matches the correct persistence info as the 
					// null values were skipped by the query engine.
					persistenceInfosForRowReader = FieldUtilities.RemoveExcludedFieldsPersistenceInfos(persistenceInfosForRowReader);
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
					IEntity2 entityToAdd = null;
					IEntityFields2 newFields  = null;

					IEntityFactory2 entityFactoryToUse = entityFactory;
					switch(typeOfHierarchy)
					{
						case InheritanceHierarchyType.None:
							// normal procedure
							newFields = entityFactoryToUse.CreateFields();
							ReadRowIntoFields(valuesOfRow, newFields, fieldIndexToOrdinal, persistenceInfosForRowReader);
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
								valuesOfRowToUseForTypeDetermination = ExpandValuesArrayToContainExcludedFieldSlots(valuesOfRow, fieldsUsedForQuery, fieldsPersistenceInfo);
							}
							entityFactoryToUse = entityFactory.GetEntityFactory(valuesOfRowToUseForTypeDetermination, entityFieldStartIndexesPerEntity);
							newFields = entityFactoryToUse.CreateFields();
							ICollection entityNamesUsed = ((EntityFields2)newFields).GetEntityNamesOfFields();
							foreach(string entityNameInField in entityNamesUsed)
							{
								fieldIndexToOrdinal = (ArrayList)hierarchyFieldAliasesToOrdinals[entityNameInField];
								ReadRowIntoFields(valuesOfRow, newFields, fieldIndexToOrdinal, persistenceInfosForRowReader);
							}
							break;
					}

					newFields.State = EntityState.Fetched;
					entityToAdd	= entityFactoryToUse.Create(newFields);
					bool canLoadEntity = ((EntityBase2)entityToAdd).CallOnCanLoadEntity();
					if(!canLoadEntity)
					{
						// Denied. check what to do
						switch(((EntityBase2)entityToAdd).CallOnGetFetchNewAuthorizationFailureResultHint())
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
						entityToAdd.IsNew = false;
					}

					if(collection.ActiveContext!=null)
					{
						// check if there is already an entity with this data in the context
						entityToAdd = collection.ActiveContext.Get(entityToAdd);
					}

					bool addEntityToCollection = false;
					if(allowDuplicates)
					{
						// always add, no client side paging required, if allowDuplicates is set to true.
						addEntityToCollection = true;
						amountObjectsRead++;
						amountObjectsSeen++;
					}
					else
					{
						// test if we already have read this entity in the resultset or if it's already present in the collection. If not, add it.
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
					if(addEntityToCollection)
					{
						// validate first.
						((EntityBase2)entityToAdd).CallValidateEntityAfterLoad();
						// .. then add.
						collection.Add(entityToAdd);
						if(canLoadEntity)
						{
							((EntityBase2)entityToAdd).CallOnAuditLoadOfEntity();
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
				if(!(_keepConnectionOpen||_isTransactionInProgress))
				{
					CloseConnection();
				}

				collection.IsReadOnly=isReadOnlySave;
				collection.AllowEdit =allowEditSave;
				collection.AllowRemove=allowRemoveSave;
				collection.AllowNew = allowNewSave;
				collection.DoNotPerformAddIfPresent=doNotPerformAddIfPresentSave;

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowRetrievalQuery", "Method Exit");
			}
		}


		/// <summary>
		/// Executes the passed in retrieval query and returns the results as a datatable using the passed in data-adapter.
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="fieldsPersistenceInfo">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>DataTable with the rows requested</returns>
		public DataTable ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, IFieldPersistenceInfo[] fieldsPersistenceInfo)
		{
			DataTable toReturn = new DataTable();
			ExecuteMultiRowDataTableRetrievalQuery(queryToExecute, dataAdapterToUse, toReturn, fieldsPersistenceInfo);
			return toReturn;
		}


		/// <summary>
		/// Executes the passed in retrieval query and returns the results in thedatatable specified using the passed in data-adapter. 
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="tableToFill">DataTable to fill</param>
		/// <param name="fieldsPersistenceInfo">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public virtual bool ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, DataTable tableToFill, IFieldPersistenceInfo[] fieldsPersistenceInfo)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowDataTableRetrievalQuery(4)", "Method Enter");

			if(_commandTimeOut>0)
			{
				queryToExecute.Command.CommandTimeout = _commandTimeOut;
			}

			OpenConnection();
			// wire up connection, command with adapter
			queryToExecute.Connection=_activeConnection;
			WireTransaction(queryToExecute);

			// check if there are converters defined in the persistence info. If so, branch out to our own fill routine. 
			bool useOwnFillRoutine = false;
			foreach(IFieldPersistenceInfo info in fieldsPersistenceInfo)
			{
				if(info.TypeConverterToUse!=null)
				{
					useOwnFillRoutine=true;
					break;
				}
			}

			if(useOwnFillRoutine)
			{
				IDataReader dataSource = queryToExecute.Execute(CommandBehavior.Default);
				// converter defined, use our own routine
				DataTableFiller.Fill(dataSource, tableToFill, fieldsPersistenceInfo, queryToExecute);
				dataSource.Close();
				dataSource.Dispose();
			}
			else
			{
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

			if(!(_keepConnectionOpen||_isTransactionInProgress))
			{
				CloseConnection();
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.ExecuteMultiRowDataTableRetrievalQuery(4)", "Method Exit");
			return true;
		}


		/// <summary>
		/// Wires an active transaction to the command object of the passed in query. If no transaction is in progress, nothing is wired.
		/// </summary>
		/// <param name="queryToWire">Query to wire up with the passed in transaction</param>
		public virtual void WireTransaction(IQuery queryToWire)
		{
			if((!_isTransactionInProgress)||(this.InComPlusTransaction))
			{
				// nothing to wire
				return;
			}

			queryToWire.WireTransaction(_physicalTransaction);
		}


		/// <summary>
		/// Starts a new transaction. All database activity after this call will be ran in this transaction and all objects will participate
		/// in this transaction until its committed or rolled back. 
		/// If there is a transaction in progress, an exception is thrown.
		/// Will create and open a new connection if a transaction is not open and/or available.
		/// </summary>
		/// <param name="isolationLevelToUse">The isolation level to use for this transaction</param>
		/// <param name="name">The name for this transaction</param>
		/// <exception cref="InvalidOperationException">If a transaction is already in progress.</exception>
		public virtual void StartTransaction(IsolationLevel isolationLevelToUse, string name)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.StartTransaction", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction name: {0}. Isolation level: {1}.", name, isolationLevelToUse.ToString()));

			if(_isTransactionInProgress)
			{
				throw new InvalidOperationException(String.Format("A transaction with the name '{0}' is already in progress. Commit or rollback that transaction first.", _transactionName));
			}
			_transactionName = name;
			_transactionIsolationLevel = isolationLevelToUse;

			_transactionParticipants.Clear();
			_transactionParticipantObjectIds.Clear();

			// clear auditors, as the auditors are gathered and used within the period of start-commit transaction.
			_auditorsToNotifyOnCommit.Clear();

			// open connection if needed
			OpenConnection();

			if(this.InComPlusTransaction)
			{
				// just set the flag to true, no physical transaction needed, as the transaction is controlled by COM+, not by ADO.NET
				_isTransactionInProgress = true;
			}
			else
			{
				_physicalTransaction = CreateNewPhysicalTransaction();
				if(_physicalTransaction!=null)
				{
					_isTransactionInProgress=true;
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.StartTransaction", "Method Exit");
		}


		/// <summary>
		/// Commits the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. Will close the connection.
		/// If in a COM+ transaction: it will flag the context to commit. It will NOT set the done bit.
		/// </summary>
		/// <remarks>Will close the active connection unless KeepConnectionOpen has been set to true</remarks>
		public virtual void Commit()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Commit", "Method Enter");

			if((_physicalTransaction==null)&&(!this.InComPlusTransaction))
			{
				// no ADO.NET transaction going on, however this situation should not happen.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Commit: No ADO.NET transaction in progress.", "Method Exit");
				return;
			}

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Commit: No ADO.NET transaction in progress.", "Method Exit");
				return;
			}

			OnBeforeTransactionCommit();

			// if there were any auditors in entities inside this transaction, gather the audit entities they might have to persist and save them.
			GatherAndFlushAuditData();

			// commit the transaction
#if CF
			_physicalTransaction.Commit();
#else
			if(this.InComPlusTransaction)
			{
				_comPlusContextHost.Commit();
			}
			else
			{
				// ADO.NET transaction
				_physicalTransaction.Commit();
			}
#endif
			_isTransactionInProgress = false;

			if(!_keepConnectionOpen)
			{
				_activeConnection.Close();
			}

			// Commit and Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendCommit);

			// any auditor has to be notified that the commit was successful. This allows an auditor to clear audit entity objects, if any.
			NotifyAuditorsForCommit();

			// reset the transactional membervariables.
			Reset();

			OnAfterTransactionCommit();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Commit", "Method Exit");
		}


		/// <summary>
		/// Rolls back the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. 
		/// If in a COM+ transaction: it will flag the context to abort. It will NOT set the done bit.
		/// </summary>
		/// <remarks>Will close the active connection unless KeepConnectionOpen has been set to true</remarks>
		public virtual void Rollback()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback", "Method Enter");

			if((_physicalTransaction==null)&&(!this.InComPlusTransaction))
			{
				// no ADO.NET transaction going on, however this situation should not happen.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback: No ADO.NET transaction in progress.", "Method Exit");
				return;
			}

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback: No ADO.NET transaction in progress.", "Method Exit");
				return;
			}

			OnBeforeTransactionRollback();

			// rollback the transaction
#if CF
			_physicalTransaction.Rollback();
#else
			if(this.InComPlusTransaction)
			{
				_comPlusContextHost.Rollback();
			}
			else
			{
				// ADO.NET transaction
				_physicalTransaction.Rollback();
			}
#endif
			// FIRST set to false
			_isTransactionInProgress = false;

			// ... THEN call close connection if applicable. 
			if(!_keepConnectionOpen)
			{
				CloseConnection();
			}

			// Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendRollback);

			// reset this object.
			Reset();

			OnAfterTransactionRollback();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback", "Method Exit");
		}


		/// <summary>
		/// Opens the active connection object. If the connection is already open, nothing is done.
		/// If no connection object is present, a new one is created
		/// </summary>
		public virtual void OpenConnection()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.OpenConnection", "Method Enter");

			if(_activeConnection==null)
			{
#if CF
				_activeConnection = CreateNewPhysicalConnection(_connectionString);
#else
				if(this.InComPlusTransaction)
				{
					_activeConnection = _comPlusContextHost.CreateConnection(_connectionString);
				}
				else
				{
					_activeConnection = CreateNewPhysicalConnection(_connectionString);
				}
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "New connection created.");
#endif
				_postponedDisposeCandidates.Clear();
			}

			if(_activeConnection.State!=ConnectionState.Open)
			{
				_activeConnection.Open();
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "Connection physically opened.");
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.OpenConnection", "Method Exit");
		}


		/// <summary>
		/// Closes the active connection. If no connection is available or the connection is closed, nothing is done.
		/// If there is a transaction in progress, it's rolled back.
		/// </summary>
		public virtual void CloseConnection()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.CloseConnection", "Method Enter");

			// check if there is a transaction going on
			if(_isTransactionInProgress)
			{
				Rollback();
			}

			if(_activeConnection!=null)
			{
				if(_activeConnection.State!=ConnectionState.Closed)
				{
					DisposePostponedDisposeCandidates();

					_activeConnection.Close();
#if !CF
					_activeConnection.Dispose();
#endif
					_activeConnection=null;
					_keepConnectionOpen=false;
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.CloseConnection", "Method Exit");
		}


		/// <summary>
		/// Saves the passed in entity to the persistent storage. Will <i>not</i> refetch the entity after this save.
		/// The entity will stay out-of-sync. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		public bool SaveEntity(IEntity2 entityToSave)
		{
			return SaveEntity(entityToSave, false, entityToSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), true);
		}


		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		public bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave)
		{
			return SaveEntity(entityToSave, refetchAfterSave, entityToSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), true);
		}


		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. 
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by entityToSave also.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		public bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, bool recurse)
		{
			return SaveEntity(entityToSave, refetchAfterSave, entityToSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), recurse);
		}


		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored if the entity is new. This
		/// predicate is used instead of a predicate produced by a set ConcurrencyPredicateFactory.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		public bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, IPredicateExpression updateRestriction)
		{
			return SaveEntity(entityToSave, refetchAfterSave, updateRestriction, true);
		}


		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored if the entity is new. This
		/// predicate is used instead of a predicate produced by a set ConcurrencyPredicateFactory.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by entityToSave also.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		public virtual bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, IPredicateExpression updateRestriction, bool recurse)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntity(4)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)entityToSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave), "Active Entity Description");

			if(entityToSave.Fields.State==EntityState.Deleted)
			{
				// entity to save is already deleted. Return.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntity(4): Entity is already deleted.", "Method Exit");
				return true;
			}

			bool saveThisEntity = (entityToSave.IsDirty || 
								(!entityToSave.IsDirty && entityToSave.IsNew && 
									(((EntityBase2)entityToSave).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)));
			if(!saveThisEntity && !recurse)
			{
				// nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntity(4): Entity is not dirty and not saved recursively.", "Method Exit");
				return true;
			}

			ArrayList insertQueue = new ArrayList(1024);
			ArrayList updateQueue = new ArrayList(1024);

			if(recurse)
			{
				ObjectGraphUtils graphUtils = new ObjectGraphUtils();
				graphUtils.DetermineActionQueues(entityToSave, updateRestriction, ref insertQueue, ref updateQueue, refetchAfterSave);
			}
			else
			{
				if(entityToSave.IsNew)
				{
					insertQueue.Add(new ActionQueueElement(entityToSave, null, refetchAfterSave));
				}
				else
				{
					updateQueue.Add(new ActionQueueElement(entityToSave, updateRestriction, refetchAfterSave));
				}
			}

			if((insertQueue.Count<=0)&&(updateQueue.Count<=0))
			{
				// empty queues, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntity(4): no entities to save.", "Method Exit");
				return true;
			}

			// persist the queues. If no transaction is started, we should start one, if necessary.
			bool saveKeepConnectionOpen = _keepConnectionOpen;
			bool transactionStartedInThisScope = false;
			bool startTransactionLocally = recurse;
			if(!recurse)
			{
				// see if the entity is a multi-target entity. If so, start a transaction.
				InheritanceHierarchyType typeOfHierarchy = ((EntityBase2)entityToSave).GetInheritanceHierarchyType();
				startTransactionLocally = (((EntityBase2)entityToSave).GetIsSubType() && (typeOfHierarchy==InheritanceHierarchyType.TargetPerEntity));
				// if there's no transaction needed so far, ask the auditor if a transaction is required for audit entities to persist. 
				if(!startTransactionLocally)
				{
					if(entityToSave.IsNew)
					{
						startTransactionLocally = ((EntityBase2)entityToSave).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.NewEntityInsert);
					}
					else
					{
						startTransactionLocally = ((EntityBase2)entityToSave).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.ExistingEntityUpdate);
					}
				}			
			}

			startTransactionLocally &= !_isTransactionInProgress;

			bool saveSucceeded = true;
			try
			{
				if(startTransactionLocally)
				{
					StartTransaction(IsolationLevel.ReadCommitted, "RecursiveSave");
					transactionStartedInThisScope=true;
				}

				if(!_isTransactionInProgress)
				{
					OpenConnection();
					_keepConnectionOpen |= refetchAfterSave;
				}

				int totalAffected = 0;
				saveSucceeded &= PersistQueue(insertQueue, true, out totalAffected);
				saveSucceeded &= PersistQueue(updateQueue, false, out totalAffected);

				if(transactionStartedInThisScope)
				{
					Commit();
					transactionStartedInThisScope=false;
				}
			}
			catch
			{
				// if a transaction was started inside this scope, roll it back.
				if(transactionStartedInThisScope)
				{
					Rollback();
					transactionStartedInThisScope=false;
				}
				saveSucceeded = false;
				// bubble the exception upwards
				throw;
			}
			finally
			{
				_keepConnectionOpen = saveKeepConnectionOpen;
				// clean up a dangling automaticly opened connection if needed.
				if(!(_keepConnectionOpen || _isTransactionInProgress))
				{
					CloseConnection();
				}

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntity(4)", "Method Exit");
			}
			return saveSucceeded;
		}


		/// <summary>
		/// Persists the queue passed in. The queue contains ActionQueueElements and is in the right order, just save it from front to back
		/// </summary>
		/// <param name="queueToPersist">Queue to persist.</param>
		/// <param name="insertActions">if true, the actions to perform are insert actions, otherwise update actions</param>
		/// <param name="totalAmountSaved">Total amount saved.</param>
		/// <returns>bool if the actions all went ok.</returns>
		/// <remarks>It assumes a transaction, if needed, is already created and opened, as well as a connection. All exceptions are bubbled upwards</remarks>
		internal bool PersistQueue(ArrayList queueToPersist, bool insertActions, out int totalAmountSaved)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.PersistQueue", "Method Enter");
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
			if( _isTransactionInProgress )
			{
				foreach(ActionQueueElement element in queueToPersist)
				{
					AddTransactionParticipant((IEntity2)element.Entity);
				}
			}

			bool queuePersisted = true;
			foreach(ActionQueueElement element in queueToPersist)
			{
				bool saveSucceeded = true;
				EntityBase2 entityToSave = (EntityBase2)element.Entity;
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
				TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)entityToSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave), "Current persisted entity info");

				// notify that an entity is saved, so last-minute changes can be made.
				OnBeforeEntitySave(entityToSave, insertActions);

				InheritanceHierarchyType typeOfHierarchy = ((EntityBase2)entityToSave).GetInheritanceHierarchyType();
				bool isMultiTargetEntity = (((EntityBase2)entityToSave).GetIsSubType() && (typeOfHierarchy==InheritanceHierarchyType.TargetPerEntity));
				if(typeOfHierarchy==InheritanceHierarchyType.TargetPerEntityHierarchy)
				{
					// get inheritance info and set the discriminator column flag.
					IInheritanceInfo info = ((EntityBase2)entityToSave).GetInheritanceInfo();
					((EntityField2)entityToSave.Fields[info.DiscriminatorColumnIndex]).SetDiscriminatorColumnFlag(true);
				}

				entityToSave.CallValidateEntityBeforeSave();
				if(insertActions)
				{
					if(!entityToSave.CallOnCanSaveNewEntity())
					{
						// denied, continue
						continue;
					}
				}
				else
				{
					if(!entityToSave.CallOnCanSaveExistingEntity())
					{
					    // denied, continue
					    continue;
					}
				}

				// retrieve persistence information
				IFieldPersistenceInfo[] persistenceInfoObjects = null;
				if( typeOfHierarchy !=InheritanceHierarchyType.None)
				{
					persistenceInfoObjects = GetFieldPersistenceInfos(entityToSave.Fields);
				}
				else
				{
					persistenceInfoObjects = GetFieldPersistenceInfos(entityToSave);
				}

				// construct query
				IActionQuery saveQuery = null;
				if(insertActions)
				{
					saveQuery = CreateInsertDQ(entityToSave, persistenceInfoObjects);
				}
				else
				{
					ArrayList pkFilters = null;
					IRelationCollection additionalRelationsUpdate = null;
					switch(typeOfHierarchy)
					{
						case InheritanceHierarchyType.TargetPerEntity:
							pkFilters = CreatePrimaryKeyFilters(entityToSave.Fields.PrimaryKeyFields);
							if(updateRestriction!=null)
							{
								additionalRelationsUpdate = new RelationCollection();
								IInheritanceInfo info = ((EntityBase2)entityToSave).GetInheritanceInfo();
								additionalRelationsUpdate.AddRange(info.RelationsToHierarchyRoot);
								InsertPersistenceInfoObjects(additionalRelationsUpdate);
							}
							break;
						default:
							IPredicateExpression pkFilter = CreatePrimaryKeyFilter(entityToSave.Fields.PrimaryKeyFields);
							pkFilters = new ArrayList(1);
							if(pkFilter!=null)
							{
								pkFilters.Add(pkFilter);
							}
							break;
					}
					if((pkFilters==null)||((pkFilters!=null) && (pkFilters.Count<=0) && (updateRestriction==null)))
					{
						// no identifying filter available. The update query will affect all rows, not only this entity. 
						throw new ORMQueryConstructionException("The entity '" + entityToSave.LLBLGenProEntityName + "' doesn't have a PK defined. The update query will therefore affect all entities in the table(s), not just this entity. Please define a Primary Key field in the designer for this entity.");
					}
					if(updateRestriction==null)
					{
						saveQuery = CreateUpdateDQ(entityToSave, persistenceInfoObjects, pkFilters);
					}
					else
					{
						InsertPersistenceInfoObjects(updateRestriction);
						saveQuery = CreateUpdateDQ(entityToSave, persistenceInfoObjects, pkFilters, updateRestriction, additionalRelationsUpdate);
					}
				}

				try
				{
					// flag we're going to save an entity
					OnSaveEntity(saveQuery, entityToSave);
					
					// execute the query
					saveSucceeded = (ExecuteActionQuery(saveQuery) > 0);

					// flag save action was completed
					OnSaveEntityComplete(saveQuery, entityToSave);

					if(saveSucceeded)
					{
						// set state and other housekeeping info
						if(EntityBase2.MarkSavedEntitiesAsFetched)
						{
							FieldUtilities.MarkSavedFieldsObjectAsFetched(entityToSave.Fields);
						}
						else
						{
							entityToSave.Fields.State = EntityState.OutOfSync;
						}
						((EntityFields2)entityToSave.Fields).AcceptChanges();
						entityToSave.IsNew=false;

						// if refetch has to be done, refetch the entity. Use the fetch routine for that.
						if(element.RefetchAfterAction)
						{
							// refetch the entity, alter flag.
							saveSucceeded &= FetchEntity(entityToSave);
						}
					}
					
					// done, flag entity as persisted if save was succesful
					if(saveSucceeded)
					{
						entityToSave.CallValidateEntityAfterSave();

						entityToSave.FlagAsSaved();
						if(saveSucceeded && !_isTransactionInProgress && (entityToSave.ActiveContext!=null))
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

						// queue the auditor, if any, for entity data flush at commit time or NOW if there's no transaction in progress.
						QueueAuditorForCommitFlush(entityToSave.AuditorToUse);
					}
					else
					{
						if(!insertActions)
						{
							// throw concurrency exception, failed.
							throw new ORMConcurrencyException("During a save action an entity's update action failed. The entity which failed is enclosed.", entityToSave);
						}
					}
				}
				catch(ORMQueryExecutionException ex)
				{
					ex.InvolvedEntity = entityToSave;
					throw;
				}
				finally
				{
					saveQuery.Dispose();
				}
				queuePersisted&=saveSucceeded;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "queuePersisted result: " + queuePersisted, "PersistQueue method result");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.PersistQueue", "Method Exit");
			return queuePersisted;
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		public IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			bool allowDuplicates )
		{
			return FetchDataReader( fields, filter, readerBehavior, maxNumberOfItemsToReturn, null, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		public IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, bool allowDuplicates)
		{
			return FetchDataReader( fields, filter, readerBehavior, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		public IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize )
		{
			return FetchDataReader( fields, filter, readerBehavior, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, pageNumber, pageSize );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		public IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates, int pageNumber, int pageSize )
		{
			IFieldPersistenceInfo[] persistenceInfo;
			IRetrievalQuery selectQuery;
			CreateQueryFromElements( fields, filter, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, 
				pageNumber, pageSize, out persistenceInfo, out selectQuery );
			try
			{
				return FetchDataReader( selectQuery, readerBehavior );
			}
			finally
			{
				// don't dispose the query now. Place it in the postponed dispose list. it will then be disposed when the connection is closed or this adapter
				// is disposed.
				_postponedDisposeCandidates.Add(selectQuery);
			}
		}


		/// <summary>
		/// Executes the passed in retrievalquery and returns an open, ready to use IDataReader. The datareader's command behavior is set to the 
		/// readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction. 
		/// </summary>
		/// <param name="queryToExecute">The query to execute.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		public virtual IDataReader FetchDataReader( IRetrievalQuery queryToExecute, CommandBehavior readerBehavior )
		{
			OpenConnection();
			queryToExecute.Connection = _activeConnection;
			WireTransaction( queryToExecute );
			if( _commandTimeOut > 0 )
			{
				queryToExecute.Command.CommandTimeout = _commandTimeOut;
			}

			return queryToExecute.Execute( readerBehavior );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields,
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, bool allowDuplicates )
		{
			FetchProjection( valueProjectors, projector, fields, filter, maxNumberOfItemsToReturn, null, null, allowDuplicates, 0, 0);
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields,
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates )
		{
			FetchProjection( valueProjectors, projector, fields, filter, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 0, 0 );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields,
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize )
		{
			FetchProjection( valueProjectors, projector, fields, filter, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, pageNumber, pageSize );
		}


		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields,
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause,
			bool allowDuplicates, int pageNumber, int pageSize )
		{
			IFieldPersistenceInfo[] persistenceInfo;
			IRetrievalQuery selectQuery;
			CreateQueryFromElements( fields, filter, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause,
					pageNumber, pageSize, out persistenceInfo, out selectQuery );

			try
			{
				FetchProjection( valueProjectors, projector, selectQuery );
			}
			finally
			{
				selectQuery.Dispose();
			}
		}


		/// <summary>
		/// Executes the passed in retrievalquery and projects the resultset using the value projectors and the projector specified.
		/// IF a transaction is in progress, the command is wired to the transaction and executed inside the transaction. The projection results
		/// will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="queryToExecute">The query to execute.</param>
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IRetrievalQuery queryToExecute )
		{
			try
			{
				using( IDataReader datasource = FetchDataReader( queryToExecute, CommandBehavior.Default ) )
				{
					ProjectionUtils.FetchProjectionFromReader( valueProjectors, projector, datasource, (int)queryToExecute.MaxNumberOfItemsToReturnClientSide,
						queryToExecute.ManualPageNumber, queryToExecute.ManualPageSize, queryToExecute.RequiresClientSideLimitation,
						queryToExecute.RequiresClientSideDistinctFiltering, queryToExecute.RequiresClientSidePaging );

					datasource.Close();
				}
			}
			finally
			{
				if( !(_keepConnectionOpen || _isTransactionInProgress) )
				{
					CloseConnection();
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
		public void FetchProjection( ArrayList valueProjectors, IGeneralDataProjector projector, IDataReader reader )
		{
			ProjectionUtils.FetchProjectionFromReader( valueProjectors, projector, reader, 0, 0, 0, false, false, false );
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntity(IEntity2 entityToFetch)
		{
			return FetchEntity(entityToFetch, null, entityToFetch.ActiveContext, null);
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntity(IEntity2 entityToFetch, Context contextToUse)
		{
			return FetchEntity(entityToFetch, null, contextToUse, null);
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath)
		{
			return FetchEntity(entityToFetch, prefetchPath, entityToFetch.ActiveContext, null);
		}

		
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse)
		{
			return FetchEntity(entityToFetch, prefetchPath, contextToUse, null);
		}
		

		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object). 
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public virtual bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntity(4)", "Method Enter");
			RelationPredicateBucket filter = new RelationPredicateBucket();
			IPredicateExpression pkFilter = CreatePrimaryKeyFilter(entityToFetch.Fields.PrimaryKeyFields);
			if(pkFilter==null)
			{
				throw new ORMQueryConstructionException("The entity '" + entityToFetch.LLBLGenProEntityName + "' doesn't have a PK defined, and FetchEntity therefore can't create a query to fetch it. Please define a PK on the entity");
			}
			filter.PredicateExpression.Add(pkFilter);

			bool fetchResult = FetchEntityUsingFilter(entityToFetch, prefetchPath, contextToUse, filter, excludedIncludedFields);
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntity(4)", "Method Exit");
			return fetchResult;
		}

		
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter)
		{
			return FetchEntityUsingUniqueConstraint(entityToFetch, uniqueConstraintFilter, null, entityToFetch.ActiveContext, null);
		}
		

		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, Context contextToUse)
		{
			return FetchEntityUsingUniqueConstraint(entityToFetch, uniqueConstraintFilter, null, contextToUse, null);
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath)
		{
			return FetchEntityUsingUniqueConstraint(entityToFetch, uniqueConstraintFilter, prefetchPath, entityToFetch.ActiveContext, null);
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath, 
			Context contextToUse)
		{
			return FetchEntityUsingUniqueConstraint(entityToFetch, uniqueConstraintFilter, prefetchPath, contextToUse, null);
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		public virtual bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath,
			Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingUniqueConstraint(5)", "Method Enter");

			RelationPredicateBucket filter = new RelationPredicateBucket();
			filter.PredicateExpression.Add(uniqueConstraintFilter);

			bool fetchResult = FetchEntityUsingFilter(entityToFetch, prefetchPath, contextToUse, filter, excludedIncludedFields);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingUniqueConstraint(5)", "Method Exit");
			return fetchResult;
		}

		
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <returns>The new entity fetched.</returns>
		public IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket)
		{
			return FetchNewEntity(entityFactoryToUse, filterBucket, null, null, null);
		}


		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		public IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, Context contextToUse)
		{
			return FetchNewEntity(entityFactoryToUse, filterBucket, null, contextToUse, null);
		}


		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <returns>The new entity fetched.</returns>
		public IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath)
		{
			return FetchNewEntity(entityFactoryToUse, filterBucket, prefetchPath, null, null);
		}
		

		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		public IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath, 
			Context contextToUse)
		{
			return FetchNewEntity(entityFactoryToUse, filterBucket, prefetchPath, contextToUse, null);
		}


		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		public virtual IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath,
			Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchNewEntity(5)", "Method Enter");

			IEntity2 fetchedEntity = null;
			bool keepConnectionOpenSave = _keepConnectionOpen;

			try
			{
				this.KeepConnectionOpen = true;
				IRelationPredicateBucket filterToUse = CreateUsableBucketClone( filterBucket );
				fetchedEntity = FetchNewEntityInternal( entityFactoryToUse, ref filterToUse, contextToUse, excludedIncludedFields );

				if(!fetchedEntity.IsNew)
				{
					// process prefetch path. 
					if((prefetchPath != null) && (prefetchPath.Count > 0))
					{
						// create a new entity collection.
						IEntityCollection2 rootEntityCollection = Activator.CreateInstance(prefetchPath[0].RetrievalCollection.GetType()) as IEntityCollection2;
						if(rootEntityCollection!=null)
						{
							if(contextToUse != null)
							{
								rootEntityCollection.ActiveContext = contextToUse;
							}
							rootEntityCollection.Add(fetchedEntity);	// will set entityToFetch to the active context as well if it's not yet set.
							FetchPrefetchPath(rootEntityCollection, filterToUse, 0, null, prefetchPath);
							// clean up the temp collection so no event handlers are left behind.
							rootEntityCollection.Clear();
						}
					}
				}
			}
			finally
			{
				this.KeepConnectionOpen = keepConnectionOpenSave;
				if( !(_keepConnectionOpen || _isTransactionInProgress) )
				{
					CloseConnection();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchNewEntity(5)", "Method Exit");
			return fetchedEntity;
		}

		
		/// <summary>
		/// Deletes the specified entity from the persistent storage. The entity is not usable after this call, the state is set to OutOfSync.
		/// Will use the current transaction if a transaction is in progress.
		/// If the passed in entity has a concurrency predicate factory object, the returned predicate expression is used to restrict the delete process.		
		/// </summary>
		/// <param name="entityToDelete">The entity instance to delete from the persistent storage</param>
		/// <returns>true if the delete was succesful, otherwise false.</returns>
		public bool DeleteEntity(IEntity2 entityToDelete)
		{
			return DeleteEntity(entityToDelete, null);
		}


		/// <summary>
		/// Deletes the specified entity from the persistent storage. The entity is not usable after this call, the state is set to
		/// OutOfSync.
		/// Will use the current transaction if a transaction is in progress.
		/// </summary>
		/// <param name="entityToDelete">The entity instance to delete from the persistent storage</param>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query</param>
		/// <returns>true if the delete was succesful, otherwise false.</returns>
		/// <exception cref="ORMConcurrencyException">Will throw an ORMConcurrencyException if the delete fails.</exception>
		public virtual bool DeleteEntity(IEntity2 entityToDelete, IPredicateExpression deleteRestriction)
		{
			IPredicateExpression deleteRestrictionToUse = null;
			if(deleteRestriction==null)
			{
				deleteRestrictionToUse = entityToDelete.GetConcurrencyPredicate(ConcurrencyPredicateType.Delete);
			}
			else
			{
				deleteRestrictionToUse = deleteRestriction;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntity(2)", "Method Enter");
			if(!((EntityBase2)entityToDelete).CallOnCanDeleteEntity())
			{
				// denied
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntity(2)", "Method Exit");
				return false;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)entityToDelete).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Description");
			if(entityToDelete.Fields.PrimaryKeyFields.Count<=0)
			{
				// no primary key, can't delete
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntity(2): no PK defined.", "Method Exit");
				return false;
			}

			((EntityBase2)entityToDelete).CallValidateEntityBeforeDelete();

			InheritanceHierarchyType typeOfHierarchy = ((EntityBase2)entityToDelete).GetInheritanceHierarchyType();
			bool transactionStartedLocally = false;
			ArrayList pkFilters = null;
			IRelationCollection relations = null;
			switch(typeOfHierarchy)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					pkFilters = CreatePrimaryKeyFilters(entityToDelete.Fields.PrimaryKeyFields);
					if(deleteRestrictionToUse != null)
					{
						relations = new RelationCollection();
						IInheritanceInfo info = ((EntityBase2)entityToDelete).GetInheritanceInfo();
						relations.AddRange(info.RelationsToHierarchyRoot);
						InsertPersistenceInfoObjects(relations);
					}
					break;
				default:
					IPredicateExpression pkFilter = CreatePrimaryKeyFilter(entityToDelete.Fields.PrimaryKeyFields);
					pkFilters = new ArrayList();
					pkFilters.Add(pkFilter);
					break;
			}
			// pk filters already contain persistence info, the deleteRestrictionToUse doesn't
			IFieldPersistenceInfo[] persistenceInfos = GetFieldPersistenceInfos(entityToDelete.Fields);
			IActionQuery deleteQuery = null;
			if(deleteRestrictionToUse != null)
			{
				InsertPersistenceInfoObjects(deleteRestrictionToUse);
				deleteQuery = CreateDeleteDQ(persistenceInfos, pkFilters, deleteRestrictionToUse, relations);
			}
			else
			{
				deleteQuery = CreateDeleteDQ(persistenceInfos, pkFilters);
			}

			try
			{
				if( _isTransactionInProgress )
				{
					// add the entity physically to the transaction.
					AddTransactionParticipant( entityToDelete );
				}
				else
				{
					if(( pkFilters.Count > 1 ) || (((EntityBase2)entityToDelete).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.EntityDelete)))
					{
						// start transaction
						StartTransaction( System.Data.IsolationLevel.ReadCommitted, "DeleteEntity" );
						transactionStartedLocally = true;
						AddTransactionParticipant( entityToDelete );
					}
				}

				// flag we're about to execute a delete action
				OnDeleteEntity( deleteQuery, entityToDelete );

				bool deleteSucceeded = (ExecuteActionQuery( deleteQuery ) > 0);

				// flag we're done executing the delete action
				OnDeleteEntityComplete( deleteQuery, entityToDelete );

				if(deleteSucceeded)
				{
					// audit successful delete
					((EntityBase2)entityToDelete).CallOnAuditDeleteOfEntity();
					entityToDelete.Fields.State = EntityState.Deleted;
					QueueAuditorForCommitFlush(entityToDelete.AuditorToUse);
				}
				else
				{
					if(deleteRestrictionToUse != null)
					{
						// failed. 
						throw new ORMConcurrencyException("The delete action of an entity failed, probably due to the set delete restriction. The entity which failed is enclosed.", entityToDelete);
					}
				}

				if( transactionStartedLocally )
				{
					Commit();
					transactionStartedLocally = false;
				}
				TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntity(2)", "Method Exit" );
				return deleteSucceeded;
			}
			catch(ORMQueryExecutionException ex)
			{
				ex.InvolvedEntity = entityToDelete;
				if(transactionStartedLocally)
				{
					Rollback();
					transactionStartedLocally = false;
				}
				throw;
			}
			catch
			{
				if( transactionStartedLocally )
				{
					Rollback();
					transactionStartedLocally = false;
				}
				throw;
			}
			finally
			{
				deleteQuery.Dispose();
			}
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket)
		{
			FetchEntityCollection(collectionToFill, filterBucket, 0, null, null, null, 0, 0);
		}
		

		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, ExcludeIncludeFieldsList excludedIncludedFields, IRelationPredicateBucket filterBucket)
		{
			FetchEntityCollection(collectionToFill, filterBucket, 0, null, null, excludedIncludedFields, 0, 0);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath)
		{
			FetchEntityCollection(collectionToFill, filterBucket, 0, null, prefetchPath, null, 0, 0);
		}

		
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, null, null, null, 0, 0);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, null, null, 0, 0);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, null, 0, 0);
		}
		

		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, excludedIncludedFields, 0, 0);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, int pageNumber, int pageSize)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, null, null, pageNumber, pageSize);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// It will apply paging and it will from there use a prefetch path fetch using the read page. It's important that pageSize
		/// is smaller than the set <see cref="ParameterisedPrefetchPathThreshold"/>. If pagesize is larger than the limits set for
		/// the <see cref="ParameterisedPrefetchPathThreshold"/> value, the query is likely to be slower than expected, though will work.
		/// If pageNumber / pageSize are set to values which disable paging, a normal prefetch path fetch will be performed. 
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">Prefetch path to use.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		public void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, int pageNumber, int pageSize)
		{
			FetchEntityCollection(collectionToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, null, pageNumber, pageSize);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// It will apply paging and it will from there use a prefetch path fetch using the read page. It's important that pageSize
		/// is smaller than the set <see cref="ParameterisedPrefetchPathThreshold"/>. If pagesize is larger than the limits set for
		/// the <see cref="ParameterisedPrefetchPathThreshold"/> value, the query is likely to be slower than expected, though will work.
		/// If pageNumber / pageSize are set to values which disable paging, a normal prefetch path fetch will be performed. 
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">Prefetch path to use.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		/// <remarks>Special thanks to Marcus Mac Innes (http://www.styledesign.biz) for the paging optimization code.</remarks>
		public virtual void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityCollection(8)", "Method Enter");
			IRelationPredicateBucket filterToUse = CreateUsableBucketClone(filterBucket);

			bool keepConnectionOpenSave = _keepConnectionOpen;
			try
			{
				this.KeepConnectionOpen = true;
				FetchEntityCollectionInternal(collectionToFill, ref filterToUse, maxNumberOfItemsToReturn, sortClauses, excludedIncludedFields, pageNumber, pageSize);

				if((prefetchPath != null) && (prefetchPath.Count>0))
				{
					// then do the prefetch actions of the path specified.
					FetchPrefetchPath(collectionToFill, filterToUse, maxNumberOfItemsToReturn, sortClauses, prefetchPath, ((pageNumber>0) && (pageSize>0)));
					// reset cached pk hashes, so collection can be re-used
					((EntityCollectionBase2)collectionToFill).CachedPkHashes = null;
				}
			}
			finally
			{
				this.KeepConnectionOpen = keepConnectionOpenSave;
				if( !(_keepConnectionOpen || _isTransactionInProgress) )
				{
					CloseConnection();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityCollection(8)", "Method Exit");
		}


		/// <summary>
		/// Saves all dirty objects inside the collection passed to the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available. Will not refetch saved entities and will not recursively save the entities.
		/// </summary>
		/// <param name="collectionToSave">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <returns>the amount of persisted entities</returns>
		public int SaveEntityCollection(IEntityCollection2 collectionToSave)
		{
			return SaveEntityCollection(collectionToSave, false, false);
		}

		
		/// <summary>
		/// Saves all dirty objects inside the collection passed to the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available.
		/// </summary>
		/// <param name="collectionToSave">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <param name="refetchSavedEntitiesAfterSave">Refetches a saved entity from the database, so the entity will not be 'out of sync'</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by the entities inside collectionToSave also.</param>
		/// <returns>the amount of persisted entities</returns>
		public virtual int SaveEntityCollection(IEntityCollection2 collectionToSave, bool refetchSavedEntitiesAfterSave, bool recurse)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntityCollection(3)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityCollectionBase2)collectionToSave).GetEntityCollectionDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Collection Description");

			// produce queues for processing.
			ArrayList insertQueue = new ArrayList(1024);
			ArrayList updateQueue = new ArrayList(1024);

			if(recurse)
			{
				ObjectGraphUtils graphUtils = new ObjectGraphUtils();
				graphUtils.DetermineActionQueues(collectionToSave, ref insertQueue, ref updateQueue, refetchSavedEntitiesAfterSave);
			}
			else
			{
				foreach(IEntity2 entityToSave in collectionToSave)
				{
					if(entityToSave.IsDirty || 
						(!entityToSave.IsDirty && entityToSave.IsNew && 
							(((EntityBase2)entityToSave).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)))
					{
						if(entityToSave.IsNew)
						{
							insertQueue.Add(new ActionQueueElement(entityToSave, null, refetchSavedEntitiesAfterSave));
						}
						else
						{
							updateQueue.Add(new ActionQueueElement(entityToSave, entityToSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), refetchSavedEntitiesAfterSave));
						}
					}
				}
			}

			if((insertQueue.Count<=0)&&(updateQueue.Count<=0))
			{
				// empty queues, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntityCollection(3): no entities to save.", "Method Exit");
				return 0;
			}

			bool localTransactionUsed = false;
			bool saveSucceeded = true;
			int totalAmountInserted = 0;
			int totalAmountUpdated = 0;
			try
			{
				if(!_isTransactionInProgress)
				{
					// start own transaction
					StartTransaction(IsolationLevel.ReadCommitted, "SaveEntityCollection");
					localTransactionUsed=true;
				}

				// flag we're starting a saveentitycollection 
				OnSaveEntityCollection(collectionToSave);

				saveSucceeded &= PersistQueue(insertQueue, true, out totalAmountInserted);
				saveSucceeded &= PersistQueue(updateQueue, false, out totalAmountUpdated);

				// done
				if(localTransactionUsed)
				{
					// commit local transaction
					Commit();
				}
			}
			catch
			{
				if(localTransactionUsed)
				{
					// abort
					Rollback();
				}
				// throw the exception further
				throw;
			}
			finally
			{
				// clean up a dangling automaticly opened connection if needed.
				if(!(_keepConnectionOpen || _isTransactionInProgress))
				{
					CloseConnection();
				}

				// flag we're done with saveentitycollection 
				OnSaveEntityCollectionComplete(collectionToSave);

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveEntityCollection(3)", "Method Exit");
			}

			return totalAmountInserted + totalAmountUpdated;
		}


		/// <summary>
		/// Deletes all dirty objects inside the collection passed from the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available. Entities which are physically deleted from the persistent storage are marked with the state 'Deleted' but are not
		/// removed from the collection.
		/// </summary>
		/// <param name="collectionToDelete">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <returns>the amount of physically deleted entities</returns>
		public virtual int DeleteEntityCollection(IEntityCollection2 collectionToDelete)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntityCollection", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityCollectionBase2)collectionToDelete).GetEntityCollectionDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Collection Description");

			if(collectionToDelete.Count<=0)
			{
				// no entities, nothing to do.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntityCollection: No entities to delete.", "Method Enter");
				return 0;
			}

			bool localTransactionUsed = false;
			int amountDeleted=0;
			if(!_isTransactionInProgress)
			{
				// start own transaction
				StartTransaction(IsolationLevel.ReadCommitted, "DeleteEntityCollection");
				localTransactionUsed=true;
			}

			IEntity2 entityToDelete = null;
			try
			{
				// flag we're about to start a deleteentitycollection action
				OnDeleteEntityCollection(collectionToDelete);

				for (int i = 0; i < collectionToDelete.Count; i++)
				{
					entityToDelete = collectionToDelete[i];
					bool deleteSucceeded = DeleteEntity(entityToDelete, entityToDelete.GetConcurrencyPredicate(ConcurrencyPredicateType.Delete));
					if(deleteSucceeded)
					{
						amountDeleted++;
					}
				}
				// done
				if(localTransactionUsed)
				{
					// commit local transaction
					Commit();
				}
			}
			catch(ORMQueryExecutionException ex)
			{
				ex.InvolvedEntity = entityToDelete;
				if(localTransactionUsed)
				{
					// abort
					Rollback();
				}
				throw;
			}
			catch
			{
				if(localTransactionUsed)
				{
					// abort
					Rollback();
				}
				// throw the exception further
				throw;
			}
			finally
			{
				// clean up a dangling automaticly opened connection if needed.
				if(!(_keepConnectionOpen || _isTransactionInProgress))
				{
					CloseConnection();
				}

				// flag we're done executing deleteentitycollection action
				OnDeleteEntityCollectionComplete(collectionToDelete);

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntityCollection", "Method Exit");
			}

			return amountDeleted;	
		}
		
		
		/// <summary>
		/// Deletes all entities of the name passed in as <i>entityName</i> (e.g. "CustomerEntity") from the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>.
		/// </summary>
		/// <param name="entityName">The name of the entity to retrieve persistence information. For example "CustomerEntity". This name can be
		/// retrieved from an existing entity's LLBLGenProEntityName property.</param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <returns>the amount of physically deleted entities</returns>
		/// <remarks>Not supported for entities which are in a TargetPerEntity hierarchy.
		/// <br/>
		/// This overload doesn't support Authorization or Auditing. It's recommended, if you want to use authorization and/or auditing on this method, 
		/// use the overload of DeleteEntitiesDirectly which accepts a type.</remarks>
		public virtual int DeleteEntitiesDirectly(string entityName, IRelationPredicateBucket filterBucket)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntitiesDirectly", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tDeleting entities of type: {0}", entityName));

			// complete the filter
			bool relationsPresent = false;
			IPredicateExpression expressionToPass = null;
			InterpretFilterBucket(filterBucket, ref relationsPresent, ref expressionToPass);
			IActionQuery deleteQuery = null;
			IFieldPersistenceInfo[] persistenceInfos = GetFieldPersistenceInfos(entityName);

			if(relationsPresent)
			{
				deleteQuery=CreateDeleteDQ(persistenceInfos, null, expressionToPass, filterBucket.Relations);
			}
			else
			{
				deleteQuery=CreateDeleteDQ(persistenceInfos, null, expressionToPass, null);
			}

			int result = 0;
			try
			{
				// flag we're about to execute a delete entities directly query
				OnDeleteEntitiesDirectly(deleteQuery);

				result = ExecuteActionQuery(deleteQuery);

				// flag we're done deleting
				OnDeleteEntitiesDirectlyComplete(deleteQuery);
			}
			finally
			{
				deleteQuery.Dispose();
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DeleteEntitiesDirectly", "Method Exit");
			return result;
		}
		

		/// <summary>
		/// Deletes all entities of the name passed in as <i>entityName</i> (e.g. "CustomerEntity") from the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>.
		/// </summary>
		/// <param name="typeOfEntity">The type of the entity to retrieve persistence information. </param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <returns>the amount of physically deleted entities</returns>
		/// <remarks>Not supported for entities which are in a TargetPerEntity hierarchy.</remarks>
		public virtual int DeleteEntitiesDirectly(Type typeOfEntity, IRelationPredicateBucket filterBucket)
		{
			if(typeOfEntity == null)
			{
				throw new ArgumentNullException("typeOfEntity can't be null", "typeOfEntity");
			}
			int toReturn = 0;
			IEntity2 dummy = (IEntity2)Activator.CreateInstance(typeOfEntity);
			if(((EntityBase2)dummy).CallOnCanBatchDeleteEntitiesDirectly())
			{
				bool transactionStartedLocally = false;
				try
				{
					if(!_isTransactionInProgress)
					{
						if(((EntityBase2)dummy).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectDeleteEntities))
						{
							// start the transaction locally
							transactionStartedLocally = true;
							StartTransaction(System.Data.IsolationLevel.ReadCommitted, "delDirectTrans");
						}
					}
					toReturn = DeleteEntitiesDirectly(dummy.LLBLGenProEntityName, filterBucket);
					// audit success
					if(filterBucket == null)
					{
						((EntityBase2)dummy).CallOnAuditDirectDeleteOfEntities(null, null, toReturn);
					}
					else
					{
						((EntityBase2)dummy).CallOnAuditDirectDeleteOfEntities(filterBucket.PredicateExpression, filterBucket.Relations, toReturn);
					}
					QueueAuditorForCommitFlush(dummy.AuditorToUse);

					if(transactionStartedLocally)
					{
						Commit();
						transactionStartedLocally = false;
					}
				}
				catch
				{
					if(transactionStartedLocally)
					{
						Rollback();
						transactionStartedLocally = false;
					}
					throw;
				}
			}
			else
			{
				// denied.
				toReturn = 0;
			}

			return toReturn;
		}

		
		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated. 
		/// </summary>
		/// <param name="entityWithNewValues">Entity object which contains the new values for the entities of the same type and which match the filter
		/// in filterBucket. Only fields which are changed are updated.</param>
		/// <param name="filterBucket">filter information to filter out the entities to update.</param>
		/// <returns>the number of physically updated entities. Use this number only to test if the update succeeded (so value is &gt; 0).</returns>
		public virtual int UpdateEntitiesDirectly(IEntity2 entityWithNewValues, IRelationPredicateBucket filterBucket)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.UpdateEntitiesDirectly", "Method Enter");
			int result = 0;
			if(((EntityBase2)entityWithNewValues).CallOnCanBatchUpdateEntitiesDirectly())
			{
				bool transactionStartedLocally = false;
				try
				{
					if(!_isTransactionInProgress)
					{
						if(((EntityBase2)entityWithNewValues).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectUpdateEntities))
						{
							// start the transaction locally
							transactionStartedLocally = true;
							StartTransaction(System.Data.IsolationLevel.ReadCommitted, "updDirectTrans");
						}
					}
					TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tUpdating entities of type: {0}", entityWithNewValues.LLBLGenProEntityName));
					InheritanceHierarchyType typeOfHierarchy = ((EntityBase2)entityWithNewValues).GetInheritanceHierarchyType();
					IRelationPredicateBucket bucketToUse = new RelationPredicateBucket();

					if(typeOfHierarchy == InheritanceHierarchyType.TargetPerEntity)
					{
						IInheritanceInfo info = ((EntityBase2)entityWithNewValues).GetInheritanceInfo();
						bucketToUse.Relations.AddRange(info.RelationsToHierarchyRoot);
					}

					if(filterBucket!=null)
					{
						if(filterBucket.PredicateExpression.Count>0)
						{
							bucketToUse.PredicateExpression.Add(filterBucket.PredicateExpression);
						}
						bucketToUse.Relations.AddRange((RelationCollection)filterBucket.Relations);
						bucketToUse.Relations.ObeyWeakRelations = filterBucket.Relations.ObeyWeakRelations;
					}

					bool relationsPresent = false;
					IPredicateExpression expressionToPass = null;
					InterpretFilterBucket(bucketToUse, ref relationsPresent, ref expressionToPass);
					IFieldPersistenceInfo[] persistenceInfos = null;
					if(typeOfHierarchy==InheritanceHierarchyType.None)
					{
						persistenceInfos = GetFieldPersistenceInfos(entityWithNewValues);
					}
					else
					{
						persistenceInfos = GetFieldPersistenceInfos(entityWithNewValues.Fields);
					}
					IActionQuery updateQuery = null;
					if(relationsPresent)
					{
						updateQuery=CreateUpdateDQ(entityWithNewValues,	persistenceInfos, null, expressionToPass, bucketToUse.Relations);
					}
					else
					{
						updateQuery=CreateUpdateDQ(entityWithNewValues, persistenceInfos, null, expressionToPass, null);
					}

					try
					{
						// flag we're about to execute an UpdateEntities directly query
						OnUpdateEntitiesDirectly(updateQuery);

						result = ExecuteActionQuery(updateQuery);

						// flag we're done 
						OnUpdateEntitiesDirectlyComplete(updateQuery);
					}
					finally
					{
						updateQuery.Dispose();
					}
					if(result > 0)
					{
						// audit successful direct update of entities. 
						if(filterBucket != null)
						{
							((EntityBase2)entityWithNewValues).CallOnAuditDirectUpdateOfEntities(filterBucket.PredicateExpression, filterBucket.Relations, result);
						}
						else
						{
							((EntityBase2)entityWithNewValues).CallOnAuditDirectUpdateOfEntities(null, null, result);
						}
						QueueAuditorForCommitFlush(entityWithNewValues.AuditorToUse);
					}

					if(transactionStartedLocally)
					{
						Commit();
						transactionStartedLocally = false;
					}
				}
				catch
				{
					if(transactionStartedLocally)
					{
						Rollback();
						transactionStartedLocally = false;
					}
					throw;
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.UpdateEntitiesDirectly", "Method Exit");
			return result;
		}


		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity to load the excluded field data into.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		public void FetchExcludedFields(IEntity2 entity, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			if((excludedIncludedFields == null) || (excludedIncludedFields.Count <= 0)|| (entity==null))
			{
				return;
			}
			EntityCollectionForFetch collection = new EntityCollectionForFetch(entity.GetEntityFactory());
			collection.Add((EntityBase2)entity);
			FetchExcludedFields(collection, excludedIncludedFields);
		}


		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in the entities collection passed in.
		/// </summary>
		/// <param name="entities">The entities to load the excluded field data into. The entities have to be either of the same type or have to be 
		/// in the same inheritance hierarchy as the entity which factory is set in the collection.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in collection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind that most databases have a limit
		/// on the # of parameters per query. 
		/// </remarks>
		public void FetchExcludedFields(IEntityCollection2 entities, ExcludeIncludeFieldsList excludedIncludedFields)
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
			if(ParameterisedPrefetchPathThreshold>0)
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

			RelationPredicateBucket filter = new RelationPredicateBucket();
			EntityBase2 dummy = (EntityBase2)entities.EntityFactoryToUse.Create();
			InheritanceHierarchyType hierarchyType = dummy.GetInheritanceHierarchyType();
			IEntityFields2 fieldsForQuery = null;

			int discriminatorIndex = -1;
			// add inheritance relations if necessary. Use the collection's factory to determine this.
			switch(hierarchyType)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					IRelationCollection relationsForHierarchy = entities.EntityFactoryToUse.CreateHierarchyRelations();
					// add hierarchy relations after all other relations. These relations are for subtype retrieval of the entity type to retrieve.
					// the original passed in relations already contain relations to build the actual relations and filters, as both should contain the
					// relations to root.
					if(relationsForHierarchy != null)
					{
						filter.Relations.AddRange((RelationCollection)relationsForHierarchy);
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

			IList excludedFieldsToUse = FilterOutIllegalExcludedFields(excludedIncludedFields.BuildFieldsToExcludeList(fieldsForQuery), hierarchyType, discriminatorIndex );
			if(excludedFieldsToUse.Count <= 0)
			{
				// no excluded fields to load
				return;
			}

			// we calculate the hashes for the entities to process. This allows us to merge the fields with the correct entity. We can't use a 
			// forward only cursor style routine based on a sorted set because GUIDs sort differently in memory than in a db. 
			Hashtable entityHashes = new Hashtable();
			CreateHashes(entityHashes, entities);
			EntityFields2 hashProducer = entities[0].Fields.Clone();
			
			// create fields list for fetch
			EntityFields2 resultFields = new EntityFields2(numberOfPkFields + excludedFieldsToUse.Count);
			int fieldIndex = 0;
			for(int i = 0; i < numberOfPkFields; i++)
			{
				resultFields[fieldIndex] = (IEntityField2)dummy.Fields.PrimaryKeyFields[i];
				fieldIndex++;
			}
			for(int i = 0; i < excludedFieldsToUse.Count; i++)
			{
				resultFields[fieldIndex] = (IEntityField2)excludedFieldsToUse[i];
				fieldIndex++;
			}

			// Grab the field persistence infos for type converters
			IFieldPersistenceInfo[] persistenceInfos = GetFieldPersistenceInfos(resultFields);

			int currentIndex = 0;
			bool keepConnectionOpenSave = _keepConnectionOpen;
			try
			{
				KeepConnectionOpen = true;

				for(int i = 0; i < numberOfBatches; i++)
				{
					// per batch load the excluded fields. Prepare the filter for the batch and send that to the fetch routine.
					filter.PredicateExpression.Clear();

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
								object pkValue = entities[currentIndex + j].GetCurrentFieldValue(((IEntityField2)dummy.Fields.PrimaryKeyFields[k]).FieldIndex);
								pkFilter.AddWithAnd(new FieldCompareValuePredicate((IEntityField2)dummy.Fields.PrimaryKeyFields[k], null, ComparisonOperator.Equal, pkValue));
							}
							batchFilter.AddWithOr(pkFilter);
						}
						else
						{
							// use one field 
							object pkValue = entities[currentIndex + j].GetCurrentFieldValue(((IEntityField2)dummy.Fields.PrimaryKeyFields[0]).FieldIndex);
							if(pkValue != null)
							{
								pkValues[pkValue] = null;
							}
						}
					}
					if(numberOfPkFields == 1)
					{
						batchFilter.Add(new FieldCompareRangePredicate((IEntityField2)dummy.Fields.PrimaryKeyFields[0], null, new ArrayList(pkValues.Keys)));
					}
					filter.PredicateExpression.Add(batchFilter);

					// fetch batch using a datareader.
					IDataReader reader = null;
					try
					{
						reader = FetchDataReader(resultFields, filter, CommandBehavior.Default, batchSize, null, true);
						object[] values = new object[resultFields.Count];
						while(reader.Read())
						{
							reader.GetValues(values);
							// calculate hash from pk fields in row. Do this by setting the pk fields in hashProducer and grab the hashvalue. 
							for(int j = 0; j < numberOfPkFields; j++)
							{
								// pk fields are at the front. 
								hashProducer[((IEntityFieldCore)dummy.Fields.PrimaryKeyFields[j]).FieldIndex].CurrentValue = values[j];
							}
							int childHash = hashProducer.GetHashCode();
							ArrayList entitiesWithHash = (ArrayList)entityHashes[childHash];
							if(entitiesWithHash==null)
							{
								// hash not found, continue
								continue;
							}
							// as a hashvalue can be the result of multiple pk values, we've to do a field compare
							IEntity2 currentEntity =null;
							for(int j = 0; j < entitiesWithHash.Count; j++)
							{
								bool theSame = true;
								for(int k = 0; k < numberOfPkFields; k++)
								{
									theSame &= FieldUtilities.ValuesAreEqual(((IEntityFieldCore)((IEntity2)entitiesWithHash[j]).PrimaryKeyFields[k]).CurrentValue,
										((IEntityFieldCore)hashProducer.PrimaryKeyFields[k]).CurrentValue);
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
								currentEntity = (IEntity2)entitiesWithHash[j];
								break;
							}
							
							for(int j = 0; j < excludedFieldsToUse.Count; j++)
							{
								IEntityField2 excludedField = (IEntityField2)excludedFieldsToUse[j];
								object value = values[numberOfPkFields + j];
#if !CF
								if(persistenceInfos[numberOfPkFields + j].TypeConverterToUse != null)
								{
									// has type converter, convert the value first
									value = persistenceInfos[numberOfPkFields + j].TypeConverterToUse.ConvertFrom(null, null, value);
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

					currentIndex+=batchSize;
				}
			}
			finally
			{
				KeepConnectionOpen = keepConnectionOpenSave;
				if(!(_keepConnectionOpen || _isTransactionInProgress))
				{
					CloseConnection();
				}
			}
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		public void FetchTypedList(ITypedListLgp2 typedListToFill)
		{
			FetchTypedList(typedListToFill.GetFieldsInfo(), (TypedListBase2)typedListToFill, typedListToFill.GetRelationInfo(), 0, null, true, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		public void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter)
		{
			IRelationPredicateBucket bucket = typedListToFill.GetRelationInfo();
			if(additionalFilter!=null)
			{
				bucket.PredicateExpression.Add(additionalFilter);
			}
			FetchTypedList(typedListToFill.GetFieldsInfo(), (TypedListBase2)typedListToFill, bucket, 0, null, true, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		public void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter, int maxNumberOfItemsToReturn, 
				ISortExpression sortClauses, bool allowDuplicates)
		{
			IRelationPredicateBucket bucket = typedListToFill.GetRelationInfo();
			if(additionalFilter!=null)
			{
				bucket.PredicateExpression.Add(additionalFilter);
			}
			FetchTypedList(typedListToFill.GetFieldsInfo(), (TypedListBase2)typedListToFill, bucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		public void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize)
		{
			IRelationPredicateBucket bucket = typedListToFill.GetRelationInfo();
			if(additionalFilter!=null)
			{
				bucket.PredicateExpression.Add(additionalFilter);
			}
			FetchTypedList(typedListToFill.GetFieldsInfo(), (TypedListBase2)typedListToFill, bucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, pageNumber, pageSize);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting, doesn't limit
		/// the resultset on the amount of rows to return, does allow duplicates.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		public void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket)
		{
			FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, 0, null, true, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting, doesn't limit
		/// the resultset on the amount of rows to return.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates)
		{
			FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, 0, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, bool allowDuplicates)
		{
			FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public virtual void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates)
		{
			FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, 0,0);
		}

		
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		public void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, 0,0);
		}


		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		public virtual void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchTypedList(9)", "Method Enter");
			if( (fieldCollectionToFetch == null) || (fieldCollectionToFetch.Count <= 0) )
			{
				// no fields to fetch
				TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchTypedList(9)", "No fields in selectlist, so nothing to fetch. Method Exit" );
				return;
			}

			IFieldPersistenceInfo[] persistenceInfo;
			IRetrievalQuery selectQuery;
			CreateQueryFromElements( fieldCollectionToFetch, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, pageNumber, pageSize, out persistenceInfo, out selectQuery );

			try
			{
				// flag we're about to execute a fetch of a typed list
				OnFetchTypedList(selectQuery, fieldCollectionToFetch, dataTableToFill);

				ExecuteMultiRowDataTableRetrievalQuery(selectQuery, CreateNewPhysicalDataAdapter(), dataTableToFill, persistenceInfo);

				// flag we're done fetching
				OnFetchTypedListComplete(selectQuery, fieldCollectionToFetch, dataTableToFill);
			}
			finally
			{
				selectQuery.Dispose();
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchTypedList(9)", "Method Exit");
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't apply any filtering, allows duplicate rows.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		public void FetchTypedView(ITypedView2 typedViewToFill)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, null, 0, null, true, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't apply any filtering.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(ITypedView2 typedViewToFill, bool allowDuplicates)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, null, 0, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, filterBucket, 0, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, bool allowDuplicates)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, filterBucket, maxNumberOfItemsToReturn, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		public void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		public void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			FetchTypedView(typedViewToFill.GetFieldsInfo(), (DataTable)typedViewToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't
		/// apply any filtering, allows duplicate rows.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, null, 0, null, true, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't
		/// apply any filtering.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, bool allowDuplicates)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, null, 0, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, filterBucket, 0, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Doesn't apply any sorting
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, bool allowDuplicates)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, null, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		public void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			FetchTypedView(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, 0,0);
		}


		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		public virtual void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchTypedView(9)", "Method Enter");

			IFieldPersistenceInfo[] persistenceInfo = GetFieldPersistenceInfos(fieldCollectionToFetch[0].ContainingObjectName);

			if(persistenceInfo.Length>fieldCollectionToFetch.Count)
			{
				// not all fields of the view are passed in. Use a typedlist fetch instead. 
				FetchTypedList(fieldCollectionToFetch, dataTableToFill, filterBucket, maxNumberOfItemsToReturn, sortClauses, allowDuplicates, groupByClause, pageNumber, pageSize);
			}
			else
			{
				for (int i = 0; i < fieldCollectionToFetch.Count; i++)
				{
					InsertPersistenceInfoObjects(fieldCollectionToFetch[i]);
				}

				bool relationsPresent = false;
				IPredicateExpression expressionToPass = null;
				InterpretFilterBucket(filterBucket, ref relationsPresent, ref expressionToPass);
				InsertPersistenceInfoObjects(sortClauses);
				InsertPersistenceInfoObjects(groupByClause);

				IRetrievalQuery selectQuery = null;

				// construct query
				if(relationsPresent)
				{
					selectQuery=CreateSelectDQ(fieldCollectionToFetch, persistenceInfo, expressionToPass, maxNumberOfItemsToReturn, sortClauses, 
						filterBucket.Relations, allowDuplicates, groupByClause, pageNumber, pageSize);
				}
				else
				{
					selectQuery=CreateSelectDQ(fieldCollectionToFetch, persistenceInfo, expressionToPass, maxNumberOfItemsToReturn, sortClauses, 
						null, allowDuplicates, groupByClause, pageNumber, pageSize);
				}

				try
				{
					// flag we're about to execute a fetch of a typed view
					OnFetchTypedView(selectQuery, fieldCollectionToFetch, dataTableToFill);

					ExecuteMultiRowDataTableRetrievalQuery(selectQuery, CreateNewPhysicalDataAdapter(), dataTableToFill, persistenceInfo);

					// flag we're done fetching
					OnFetchTypedViewComplete(selectQuery, fieldCollectionToFetch, dataTableToFill);
				}
				finally
				{
					selectQuery.Dispose();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchTypedView(9)", "Method Exit");
		}


		/// <summary>
		/// Method which is called from the default clause of the InsertPersistenceInfoObjects(predicateexpression) routine, which is useful for people who
		/// implement their own Predicate objects.
		/// </summary>
		/// <param name="currentPredicate">The current predicate object to fill the persistence info of.</param>
		protected virtual void OnInsertPersistenceObjects( IPredicate currentPredicate )
		{
		}


		/// <summary>
		/// Called right before the actual scalar query is executed
		/// </summary>
		/// <param name="scalarQuery">RetrievalQuery object which will be executed</param>
		protected virtual void OnGetScalar(IRetrievalQuery scalarQuery)
		{
		}

		/// <summary>
		/// Called right before the actual Save action is executed.
		/// </summary>
		/// <param name="saveQuery">the ActionQuery object which will be executed</param>
		/// <param name="entityToSave">the entity which will be saved by saveQuery</param>
		protected virtual void OnSaveEntity(IActionQuery saveQuery, IEntity2 entityToSave)
		{
		}

		/// <summary>
		/// Called right after the actual Save action was executed.
		/// </summary>
		/// <param name="saveQuery">the ActionQuery object which will be executed</param>
		/// <param name="entityToSave">the entity which is saved by saveQuery</param>
		protected virtual void OnSaveEntityComplete(IActionQuery saveQuery, IEntity2 entityToSave)
		{
		}

		/// <summary>
		/// Called at the start of the SaveEntityCollection() method
		/// </summary>
		/// <param name="entityCollectionToSave">the entity collection to save</param>
		protected virtual void OnSaveEntityCollection(IEntityCollection2 entityCollectionToSave)
		{
		}

		/// <summary>
		/// Called at the end of the SaveEntityCollection() method
		/// </summary>
		/// <param name="entityCollectionToSave">the entity collection which was saved</param>
		protected virtual void OnSaveEntityCollectionComplete(IEntityCollection2 entityCollectionToSave)
		{
		}

		/// <summary>
		/// Called right before the actual delete action is executed
		/// </summary>
		/// <param name="deleteQuery">the ActionQuery object which will be executed</param>
		/// <param name="entityToDelete">the entity which will be deleted by deleteQuery</param>
		protected virtual void OnDeleteEntity(IActionQuery deleteQuery, IEntity2 entityToDelete)
		{
		}

		/// <summary>
		/// Called right before the actual delete action is executed
		/// </summary>
		/// <param name="deleteQuery">the ActionQuery object which will be executed</param>
		/// <param name="entityToDelete">the entity which was deleted by deleteQuery</param>
		protected virtual void OnDeleteEntityComplete(IActionQuery deleteQuery, IEntity2 entityToDelete)
		{
		}

		/// <summary>
		/// Called at the start of the DeleteEntityCollection method
		/// </summary>
		/// <param name="entityCollectionToDelete">the entity collection to delete</param>
		protected virtual void OnDeleteEntityCollection(IEntityCollection2 entityCollectionToDelete)
		{
		}

		/// <summary>
		/// Called at the end of the DeleteEntityCollection method
		/// </summary>
		/// <param name="entityCollectionToDelete">the entity collection which was delete</param>
		protected virtual void OnDeleteEntityCollectionComplete(IEntityCollection2 entityCollectionToDelete)
		{
		}

		/// <summary>
		/// Called right before the actual delete query is executed
		/// </summary>
		/// <param name="deleteQuery">The ActionQuery to execute</param>
		protected virtual void OnDeleteEntitiesDirectly(IActionQuery deleteQuery)
		{
		}

		/// <summary>
		/// Called right before the actual delete query is executed
		/// </summary>
		/// <param name="deleteQuery">The ActionQuery to execute</param>
		protected virtual void OnDeleteEntitiesDirectlyComplete(IActionQuery deleteQuery)
		{
		}

		/// <summary>
		/// Called right before the actual fetch is executed.
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery which will be executed</param>
		/// <param name="fieldsToFetch">the IEntityFields2 object which will be filled by selectQuery</param>
		protected virtual void OnFetchEntity(IRetrievalQuery selectQuery, IEntityFields2 fieldsToFetch)
		{
		}

		/// <summary>
		/// Called right after the actual fetch is executed.
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery which was executed</param>
		/// <param name="fieldsToFetch">the IEntityFields2 object which was filled by selectQuery</param>
		protected virtual void OnFetchEntityComplete(IRetrievalQuery selectQuery, IEntityFields2 fieldsToFetch)
		{
		}

		/// <summary>
		/// Called right before the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery which will be executed</param>
		/// <param name="entityCollectionToFetch">the entity collection to fill</param>
		protected virtual void OnFetchEntityCollection(IRetrievalQuery selectQuery, IEntityCollection2 entityCollectionToFetch)
		{
		}

		/// <summary>
		/// Called right after the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery which was executed</param>
		/// <param name="entityCollectionToFetch">the entity collection which was filled</param>
		protected virtual void OnFetchEntityCollectionComplete(IRetrievalQuery selectQuery, IEntityCollection2 entityCollectionToFetch)
		{
		}


		/// <summary>
		/// Called right before the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery object to execute</param>
		/// <param name="fieldCollectionToFetch">the fieldslist used to construct the query</param>
		/// <param name="dataTableToFill">the datatable object to fill</param>
		protected virtual void OnFetchTypedList(IRetrievalQuery selectQuery, IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill)
		{
		}

		/// <summary>
		/// Called right after the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery object which was executed</param>
		/// <param name="fieldCollectionToFetch">the fieldslist used to construct the query</param>
		/// <param name="dataTableToFill">the datatable object which was filled</param>
		protected virtual void OnFetchTypedListComplete(IRetrievalQuery selectQuery, IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill)
		{
		}

		/// <summary>
		/// Called right before the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery object to execute</param>
		/// <param name="fieldCollectionToFetch">the fieldslist used to construct the query</param>
		/// <param name="dataTableToFill">the datatable object to fill</param>
		protected virtual void OnFetchTypedView(IRetrievalQuery selectQuery, IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill)
		{
		}

		/// <summary>
		/// Called right after the actual fetch is executed
		/// </summary>
		/// <param name="selectQuery">the RetrievalQuery object which was executed</param>
		/// <param name="fieldCollectionToFetch">the fieldslist used to construct the query</param>
		/// <param name="dataTableToFill">the datatable object which was filled</param>
		protected virtual void OnFetchTypedViewComplete(IRetrievalQuery selectQuery, IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill)
		{
		}

		/// <summary>
		/// Called right before the actual update query is executed
		/// </summary>
		/// <param name="updateQuery">The ActionQuery to execute</param>
		protected virtual void OnUpdateEntitiesDirectly(IActionQuery updateQuery)
		{
		}

		/// <summary>
		/// Called right after the actual update query is executed
		/// </summary>
		/// <param name="updateQuery">The ActionQuery to execute</param>
		protected virtual void OnUpdateEntitiesDirectlyComplete(IActionQuery updateQuery)
		{
		}

		/// <summary>
		/// Called from PersistQueue, the internal queue processing routine, before the entity is validated and before the entity 
		/// is used to create a query and actually saved. The entity passed in as entitySaved is already added to the transaction.
		/// </summary>
		/// <param name="entitySaved">Entity to be saved.</param>
		/// <param name="insertAction">if true, the entity is in the insertqueue, otherwise the update queue.</param>
		protected virtual void OnBeforeEntitySave(IEntity2 entitySaved, bool insertAction)
		{
		}

		/// <summary>
		/// Called right before the Commit() method starts its logic.
		/// </summary>
		protected virtual void OnBeforeTransactionCommit()
		{
		}

		/// <summary>
		/// Called right after the Commit() method has performed its logic and the commit was succesful.
		/// </summary>
		protected virtual void OnAfterTransactionCommit()
		{
		}

		/// <summary>
		/// Called right before the Rollback() method starts its logic.
		/// </summary>
		protected virtual void OnBeforeTransactionRollback()
		{
		}

		/// <summary>
		/// Called right after the Rollback() method has performed its logic and the rollback was succesful.
		/// </summary>
		protected virtual void OnAfterTransactionRollback()
		{
		}


		/// <summary>
		/// Creates a savepoint with the name savePointName in the current transaction. You can roll back to this savepoint using
		/// <see cref="Rollback(string)"/>.
		/// </summary>
		/// <param name="savePointName">name of savepoint. Must be unique in an active transaction</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null or there is already a savepoint defined with the name specified</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction saving or when COM+ is used.</exception>
		public virtual void SaveTransaction(string savePointName)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveTransaction", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction saved under name: {0}", savePointName));

			if(this.InComPlusTransaction)
			{
				// not supported
				throw new NotSupportedException("In COM+, savepoints are not supported.");
			}

			if((savePointName==null)||(savePointName.Length<=0))
			{
				throw new ArgumentException("savePointName can't be null or empty", "savePointName");
			}

			if(_physicalTransaction==null)
			{
				throw new InvalidOperationException("No transaction in progress.");
			}

			if(_savePointNames.ContainsKey(savePointName))
			{
				throw new ArgumentException("There is already a savepoint defined with the name '" + savePointName + "'", "savePointName");
			}

			// Get the Save method
			MethodInfo saveMethod = _physicalTransaction.GetType().GetMethod("Save");

			if(saveMethod==null)
			{
				// save not found, not supported.
				throw new NotSupportedException("The used .NET database provider doesn't support transaction saving, no Save(string) method present.");
			}

			// Invoke Save method
			saveMethod.Invoke(_physicalTransaction, new object[] {savePointName});
			_savePointNames.Add(savePointName, null);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.SaveTransaction", "Method Exit");
		}

		
		/// <summary>
		/// Rolls back the transaction in action to the savepoint with the name savepointName. No internal objects are being reset when this method is called,
		/// so call this Rollback overload only to roll back to a savepoint. To roll back a complete transaction, call Rollback() without specifying a savepoint
		/// name. Create a savepoint by calling SaveTransaction(savePointName)
		/// </summary>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null or there is no savepoint defined with the name specified</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction rolling back a transaction to a named
		/// point or when COM+ is used.</exception>
		/// <param name="savePointName">name of the savepoint to roll back to.</param>
		public virtual void Rollback(string savePointName)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback(1)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction will be rolled back to savepoint: {0}", savePointName));

			if(this.InComPlusTransaction)
			{
				// not supported
				throw new NotSupportedException("In COM+, savepoints are not supported.");
			}

			if((savePointName==null)||(savePointName.Length<=0))
			{
				throw new ArgumentException("savePointName can't be null or empty", "savePointName");
			}

			if(_physicalTransaction==null)
			{
				throw new InvalidOperationException("No transaction in progress.");
			}

			if(!_savePointNames.ContainsKey(savePointName))
			{
				throw new ArgumentException("There is no savepoint defined with the name '" + savePointName + "'", "savePointName");
			}

 			// Get the Rollback method
			MethodInfo rollbackMethod = _physicalTransaction.GetType().GetMethod("Rollback", new Type[] {typeof(string)});
		
			if(rollbackMethod==null)
			{
				// save not found, not supported.
				throw new NotSupportedException("The used .NET database provider doesn't support transaction rollback to a given point, no Rollback(string) method present.");
			}

			// Invoke rollback method
			rollbackMethod.Invoke(_physicalTransaction, new object[] {savePointName});
			_savePointNames.Remove(savePointName);
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.Rollback(1)", "Method Exit");
		}


		/// <summary>
		/// Creates a new predicate expression which filters on the primary key fields and the set values for the
		/// given primary key fields. If no primary key fields are specified, null is returned.
		/// </summary>
		/// <param name="primaryKeyFields">ArrayList with IEntityField2 instances which form the primary key for which the filter has to be constructed</param>
		/// <returns>filled in predicate expression or null if no primary key fields are specified.</returns>
		/// <remarks>Call this method passing IEntity2.Fields.PrimaryKeyFields</remarks>
		public virtual IPredicateExpression CreatePrimaryKeyFilter(ArrayList primaryKeyFields)
		{
			ArrayList filters = CreatePrimaryKeyFilters(primaryKeyFields);
			if(filters==null)
			{
				return null;
			}
			return (IPredicateExpression)filters[0];
		}


		/// <summary>
		/// Creates for each entity which PK field(s) are in the passed in arraylist a new predicate expression which filters on the 
		/// primary key fields of that entity and the set values for the
		/// given primary key fields. If no primary key fields are specified, null is returned.
		/// </summary>
		/// <param name="primaryKeyFields">ArrayList with IEntityField2 instances which form the primary key for which the filter has to be constructed</param>
		/// <returns>ArrayList with for each entity a filled in predicate expression or null if no primary key fields are specified. PK filters
		/// are stored in the same order as entities appear in the pkfields, which is the same order in which entities are located in the hierarchy
		/// (from root to leaf)</returns>
		/// <remarks>Call this method passing IEntity2.Fields.PrimaryKeyFields</remarks>
		public virtual ArrayList CreatePrimaryKeyFilters(ArrayList primaryKeyFields)
		{
			if(primaryKeyFields.Count<=0)
			{
				return null;
			}

			ArrayList toReturn = new ArrayList(primaryKeyFields.Count);

			IPredicateExpression pkFilter = null;
			string currentEntityName = string.Empty;
			string previousEntityName = string.Empty;
			foreach(IEntityField2 field in primaryKeyFields)
			{
				previousEntityName = currentEntityName;
				currentEntityName = field.ContainingObjectName;

				if(previousEntityName!=currentEntityName)
				{
					pkFilter = new PredicateExpression();
					toReturn.Add(pkFilter);
				}
				IFieldPersistenceInfo persistenceInfo = GetFieldPersistenceInfo(field);
				pkFilter.AddWithAnd(new FieldCompareValuePredicate(field, persistenceInfo, ComparisonOperator.Equal));
			}

			return toReturn;
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
		/// Reads the value of the setting with the key SchemaNameUsageSetting from the *.config file and stores that value as the
		/// active setting for schemaNameUsageSetting for this instance, IF specified. If specified, a key with the name SchemaNameToUse is
		/// expected as well.
		/// </summary>
		/// <param name="schemaNameOverwrites">Schema name overwrites to fill.</param>
		protected void ReadHandleSchemaNameSettingFromConfig(SchemaNameOverwriteHashtable schemaNameOverwrites)
		{
#if !CF
			NameValueCollection appSettings = ConfigurationSettings.AppSettings;
			if(appSettings!=null)
			{
				object value =  appSettings["SchemaNameUsageSetting"];
				if(value != null)
				{
					SchemaNameUsage schemaNameUsageSetting = (SchemaNameUsage)Convert.ToInt32(value);
					value = appSettings["SchemaNameToUse"];
					if(value!=null)
					{
						string schemaNameToUse = (string)value;
						if(schemaNameUsageSetting != SchemaNameUsage.Default)
						{
							if(schemaNameOverwrites.ContainsKey("*"))
							{
								schemaNameOverwrites["*"] = schemaNameToUse;
							}
							else
							{
								schemaNameOverwrites.Add("*", schemaNameToUse);
							}
						}
					}
					else
					{
						// error, revert to default
						schemaNameUsageSetting = SchemaNameUsage.Default;
					}
					schemaNameOverwrites.SchemaNameUsageSetting = schemaNameUsageSetting;
				}
			}
#endif
		}


		/// <summary>
		/// Reads the value of the setting with the key CatalogNameUsageSetting from the *.config file and stores that value as the
		/// active setting for catalogNameUsageSetting for this instance, IF specified. If specified, a key with the name CatalogNameToUse is
		/// expected as well.
		/// </summary>
		/// <param name="catalogNameOverwrites">The catalog name overwrites.</param>
		protected void ReadHandleCatalogNameSettingFromConfig(CatalogNameOverwriteHashtable catalogNameOverwrites)
		{
#if !CF
			NameValueCollection appSettings = ConfigurationSettings.AppSettings;
			if(appSettings!=null)
			{
				object value = appSettings["CatalogNameUsageSetting"];
				if(value != null)
				{
					CatalogNameUsage catalogNameUsageSetting = (CatalogNameUsage)Convert.ToInt32(value);
					if(catalogNameUsageSetting != CatalogNameUsage.Default)
					{
						value = appSettings["CatalogNameToUse"];
						if(value != null)
						{
							string catalogNameToUse = (string)value;
							if(catalogNameOverwrites.ContainsKey("*"))
							{
								catalogNameOverwrites["*"] = catalogNameToUse;
							}
							else
							{
								catalogNameOverwrites.Add("*", catalogNameToUse);
							}
						}
						else
						{
							// error, revert to default.
							catalogNameUsageSetting = CatalogNameUsage.Default;
						}
					}
					catalogNameOverwrites.CatalogNameUsageSetting = catalogNameUsageSetting;
				}
			}
#endif
		}


		/// <summary>
		/// Creates a new connection object using the current connection string value
		/// </summary>
		/// <remarks>Will close and dispose an active connection.</remarks>
		protected void CreateConnection()
		{
			if(_activeConnection!=null)
			{
				if(_activeConnection.State==ConnectionState.Open)
				{
					CloseConnection();
#if !CF
					_activeConnection.Dispose();
#endif
				}
			}

			_activeConnection = CreateNewPhysicalConnection(_connectionString);
		}


		/// <summary>
		/// Returns the active connection object. If no connection object is present, a new one will be created.
		/// </summary>
		/// <returns>The active connection object</returns>
		protected IDbConnection GetActiveConnection()
		{
			if(_activeConnection==null)
			{
				_activeConnection = CreateNewPhysicalConnection(_connectionString);
			}

			return _activeConnection;
		}


		/// <summary>
		/// Creates a new physical connection object.
		/// </summary>
		/// <param name="connectionString">Connectionstring to use for the new connection object</param>
		/// <returns>IDbConnection implementing connection object.</returns>
		protected abstract IDbConnection CreateNewPhysicalConnection(string connectionString);
		/// <summary>
		/// Creates a new physical transaction object over the created connection. The connection is assumed to be open.
		/// </summary>
		/// <returns>a physical transaction object, like an instance of SqlTransaction.</returns>
		protected abstract IDbTransaction CreateNewPhysicalTransaction();
		/// <summary>
		/// Creates a new .NET DataAdapter for the database system this DataAccessAdapter object is targeting. 
		/// </summary>
		/// <returns>New .NET DataAdapter object</returns>
		protected abstract DbDataAdapter CreateNewPhysicalDataAdapter();
		/// <summary>
		/// Inserts in each predicate expression element the persistence info object for the field used. If there is already a fieldpersistenceinfo 
		/// element for a given field, it is skipped. 
		/// </summary>
		/// <param name="expression">IPredicateExpression object which has predicate elements whose persistence info objects have to be
		/// set to a value.</param>
		protected abstract void InsertPersistenceInfoObjects(IPredicateExpression expression);
		/// <summary>
		/// Creates a new Dynamic Query engine object and passes in the defined catalog/schema overwrite hashtables.
		/// </summary>
		protected abstract DynamicQueryEngineBase CreateDynamicQueryEngine();

		
		/// <summary>
		/// Retrieves the persistence info for the field passed in. 
		/// </summary>
		/// <param name="field">Field which fieldpersistence info has to be retrieved</param>
		/// <returns>the requested persistence information</returns>
		protected virtual IFieldPersistenceInfo GetFieldPersistenceInfo( IEntityField2 field )
		{
			if(field==null)
			{
				return null;
			}

			if( _persistenceInfoProvider == null )
			{
				throw new ApplicationException( "The IPersistenceInfoProvider object of this DataAccessAdapter is null. " );
			}
			IFieldPersistenceInfo toReturn = null;
			if( (field.ExpressionToApply!=null) && ((field.ContainingObjectName.Length <= 0) || (field.Name.Length <= 0) ))
			{
				// create dummy, as a placeholder field was used. 
				toReturn = new FieldPersistenceInfo();
			}
			else
			{
				toReturn = _persistenceInfoProvider.GetFieldPersistenceInfo( field.ContainingObjectName, field.Name );
			}
			InsertPersistenceInfoObjects( field );
			return toReturn;
		}


		/// <summary>
		/// Retrieves the persistence info objects for the fields of the entity passed in.
		/// </summary>
		/// <param name="entity">Entity object which fields the persistence information should be retrieved for</param>
		/// <returns>the requested persistence information</returns>
		protected virtual IFieldPersistenceInfo[] GetFieldPersistenceInfos( IEntity2 entity )
		{
			if( _persistenceInfoProvider == null )
			{
				throw new ApplicationException( "The IPersistenceInfoProvider object of this DataAccessAdapter is null. " );
			}
			for( int i = 0; i < entity.Fields.Count; i++ )
			{
				InsertPersistenceInfoObjects( entity.Fields[i] );
			}
			return _persistenceInfoProvider.GetAllFieldPersistenceInfos( entity );
		}


		/// <summary>
		/// Retrieves the persistence info objects for the fields of the entity passed in.
		/// </summary>
		/// <param name="entityName">Entity name for entity type which fields the persistence information should be retrieved for</param>
		/// <returns>the requested persistence information</returns>
		protected virtual IFieldPersistenceInfo[] GetFieldPersistenceInfos( string entityName )
		{
			if( _persistenceInfoProvider == null )
			{
				throw new ApplicationException( "The IPersistenceInfoProvider object of this DataAccessAdapter is null. " );
			}

			return _persistenceInfoProvider.GetAllFieldPersistenceInfos( entityName );
		}


		/// <summary>
		/// Inserts the persistence info objects on all objects referenced by the passed in field.
		/// </summary>
		/// <param name="field">The field.</param>
		protected virtual void InsertPersistenceInfoObjects( IEntityField2 field )
		{
			InsertPersistenceInfoObjects( field.ExpressionToApply );
		}


		/// <summary>
		/// Inserts in each entityrelation object the persistence info objects for the fields referenced.
		/// </summary>
		/// <param name="relations">IRelationCollection object which has entityrelation objects whose fields' persistence info objects have to be
		/// set to a value.</param>
		protected virtual void InsertPersistenceInfoObjects(IRelationCollection relations)
		{
			if(relations==null)
			{
				return;
			}

			for (int i = 0; i < ((RelationCollection)relations).Count; i++)
			{
				IEntityRelation currentRelation = relations[i];

				for (int j = 0; j < currentRelation.AmountFields; j++)
				{
					currentRelation.SetFKFieldPersistenceInfo(j, GetFieldPersistenceInfo((EntityField2)currentRelation.GetFKEntityFieldCore(j)));
					currentRelation.SetPKFieldPersistenceInfo(j, GetFieldPersistenceInfo((EntityField2)currentRelation.GetPKEntityFieldCore(j)));
					if(currentRelation.CustomFilter!=null)
					{
						InsertPersistenceInfoObjects(currentRelation.CustomFilter);
					}
				}
				
				if(currentRelation.InheritanceInfoPkSideEntity!=null)
				{
					InsertPersistenceInfoObjects(currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot);
				}
				if(currentRelation.InheritanceInfoFkSideEntity!=null)
				{
					InsertPersistenceInfoObjects(currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot);
				}
			}
		}


		/// <summary>
		/// Inserts in each SortClause object the persistence info object for the field referenced.
		/// </summary>
		/// <param name="sortClauses">ISortExpression object which has SortClause objects whose fields persistence info object has to be
		/// set to a value.</param>
		protected virtual void InsertPersistenceInfoObjects(ISortExpression sortClauses)
		{
			if(sortClauses==null)
			{
				return;
			}

			for (int i = 0; i < sortClauses.Count; i++)
			{
				sortClauses[i].PersistenceInfo = GetFieldPersistenceInfo((IEntityField2)sortClauses[i].FieldToSortCore);
			}
		}
		

		/// <summary>
		/// Inserts the persistence info objects into the scalar query expression object passed in.
		/// </summary>
		/// <param name="scalarQuery">The scalar query.</param>
		protected virtual void InsertPersistenceInfoObjects( IScalarQueryExpression scalarQuery )
		{
			if( scalarQuery == null )
			{
				return;
			}
			IEntityField2 selectField = scalarQuery.SelectField as IEntityField2;
			if(selectField==null)
			{
				return;
			}

			InsertPersistenceInfoObjects( selectField );
			InsertPersistenceInfoObjects( scalarQuery.FilterToUse );
			InsertPersistenceInfoObjects( scalarQuery.RelationsToUse );
			InsertPersistenceInfoObjects( scalarQuery.SorterToUse );
			InsertPersistenceInfoObjects( scalarQuery.GroupByClause );
			scalarQuery.SelectFieldPersistenceInfo = GetFieldPersistenceInfo( selectField );
		}


		/// <summary>
		/// Inserts the persistence info objects into the function call object passed in, for every field object present as parameter in the function call.
		/// </summary>
		/// <param name="functionCall">The function call.</param>
		protected virtual void InsertPersistenceInfoObjects( IDbFunctionCall functionCall )
		{
			if(functionCall==null)
			{
				return;
			}
			for( int i = 0; i < functionCall.FunctionParameters.Length; i++ )
			{
				IExpression parameterAsExpression = functionCall.FunctionParameters[i] as IExpression;
				if(parameterAsExpression != null)
				{
					InsertPersistenceInfoObjects(parameterAsExpression);
				}
				else
				{
					IEntityField2 parameterAsField = functionCall.FunctionParameters[i] as IEntityField2;
					if( parameterAsField != null )
					{
						functionCall.FieldPersistenceInfos[i] = GetFieldPersistenceInfo( parameterAsField );
					}
				}
			}
		}

		
		/// <summary>
		/// Inserts for each entityfield in the collection the persistence info object 
		/// </summary>
		/// <param name="groupByClause">IGroupByCollection object which has IEntityField(2) objects whose persistence info object has to be
		/// set to a value.</param>
		protected virtual void InsertPersistenceInfoObjects(IGroupByCollection groupByClause)
		{
			if(groupByClause==null)
			{
				return;
			}

			for (int i = 0; i < groupByClause.Count; i++)
			{
				groupByClause.SetFieldPersistenceInfo(GetFieldPersistenceInfo((IEntityField2)groupByClause[i]), i);
			}
			
			if(groupByClause.HavingClause!=null)
			{
				InsertPersistenceInfoObjects(groupByClause.HavingClause);
			}
		}


		/// <summary>
		/// Inserts for each entityfield in the expression the persistence info object 
		/// </summary>
		/// <param name="expression">IExpression object which has IEntityField(2) objects whose persistence info object has to be
		/// set to a value.</param>
		protected virtual void InsertPersistenceInfoObjects(IExpression expression)
		{
			if(expression==null)
			{
				return;
			}

			if(expression.LeftOperand==null)
			{
				// none set
				return;
			}

			// left operand isn't null, set it if required
			switch(expression.LeftOperand.Type)
			{
				case ExpressionElementType.Expression:
					InsertPersistenceInfoObjects((IExpression)expression.LeftOperand.Contents);
					break;
				case ExpressionElementType.Field:
					IExpressionFieldElement fieldElement = (IExpressionFieldElement)expression.LeftOperand;
					IEntityField2 field = (IEntityField2)fieldElement.Contents;
					if( field != null )
					{
						fieldElement.PersistenceInfo = GetFieldPersistenceInfo( field );
					}
					break;
				case ExpressionElementType.FunctionCall:
					InsertPersistenceInfoObjects( (IDbFunctionCall)expression.LeftOperand.Contents );
					break;
				case ExpressionElementType.ScalarQuery:
					InsertPersistenceInfoObjects( (IScalarQueryExpression)expression.LeftOperand.Contents );
					break;
				default:
					// nothing
					break;
			}

			if(expression.RightOperand!=null)
			{
				switch(expression.RightOperand.Type)
				{
					case ExpressionElementType.Expression:
						InsertPersistenceInfoObjects((IExpression)expression.RightOperand.Contents);
						break;
					case ExpressionElementType.Field:
						IExpressionFieldElement fieldElement = (IExpressionFieldElement)expression.RightOperand;
						IEntityField2 field = (IEntityField2)fieldElement.Contents;
						if( field != null )
						{
							fieldElement.PersistenceInfo = GetFieldPersistenceInfo( field );
						}
						break;
					case ExpressionElementType.FunctionCall:
						InsertPersistenceInfoObjects( (IDbFunctionCall)expression.LeftOperand.Contents );
						break;
					case ExpressionElementType.ScalarQuery:
						InsertPersistenceInfoObjects( (IScalarQueryExpression)expression.LeftOperand.Contents );
						break;
					default:
						// nothing
						break;
				}
			}
		}

		
		/// <summary>
		/// Creates a new insert DQ for the entity passed in.
		/// </summary>
		/// <param name="entityToSave">the entity to create the Insert query for</param>
		/// <param name="persistenceInfoObjects">persistence objects for the entity</param>
		/// <returns>a fully usable IActionQuery object</returns>
		protected virtual IActionQuery CreateInsertDQ(IEntity2 entityToSave, IFieldPersistenceInfo[] persistenceInfoObjects)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateInsertDQ(entityToSave.Fields.GetAsEntityFieldCoreArray(), persistenceInfoObjects, GetActiveConnection());
		}


		/// <summary>
		/// Creates a new Update DQ for the entity passed in.
		/// </summary>
		/// <param name="entityToSave">the entity to create the Update query for</param>
		/// <param name="persistenceInfoObjects">persistence objects for the entity</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <returns>a fully usable IActionQuery object</returns>
		protected virtual IActionQuery CreateUpdateDQ(IEntity2 entityToSave, IFieldPersistenceInfo[] persistenceInfoObjects, ArrayList pkFilters)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateUpdateDQ(entityToSave.Fields.GetAsEntityFieldCoreArray(), persistenceInfoObjects, GetActiveConnection(), pkFilters);
		}


		/// <summary>
		/// Creates a new Update DQ for the entity passed in.
		/// </summary>
		/// <param name="entityWithNewValues">the entity to with new values to use for the SET clauses</param>
		/// <param name="persistenceInfoObjects">persistence objects for the fields in entityWithNewValues</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <param name="additionalFilter">The additional filter to use in the update query, used for concurrency purposes</param>
		/// <param name="relationsToWalk">Relations to walk to fulfill the filter</param>
		/// <returns>a fully usable IActionQuery object</returns>
		protected virtual IActionQuery CreateUpdateDQ(IEntity2 entityWithNewValues, IFieldPersistenceInfo[] persistenceInfoObjects, ArrayList pkFilters, 
			IPredicateExpression additionalFilter, IRelationCollection relationsToWalk)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateUpdateDQ(entityWithNewValues.Fields.GetAsEntityFieldCoreArray(), persistenceInfoObjects, GetActiveConnection(), pkFilters, additionalFilter, relationsToWalk);
		}


		/// <summary>
		/// Creates a new Select DQ for the fields passed in using the parameters specified.
		/// </summary>
		/// <param name="fieldsToFetch">fields to fetch using the select</param>
		/// <param name="persistenceInfoObjects">persistence info objects for the fields</param>
		/// <param name="filter">filter to use for the where clause</param>
		/// <param name="maxNumberOfItemsToReturn">max. amount of rows to return</param>
		/// <param name="sortClauses">sort clause specifications to use</param>
		/// <param name="relationsToWalk">relations to walk to build the FROM clause</param>
		/// <param name="allowDuplicates">flag to specify if duplicates should be returned</param>
		/// <param name="groupByClause">group by clause to embed in the query</param>
		/// <param name="pageNumber">The page number to retrieve</param>
		/// <param name="pageSize">the page size to retrieve</param>
		/// <returns>ready to use query to use.</returns>
		protected virtual IRetrievalQuery CreateSelectDQ(IEntityFields2 fieldsToFetch, IFieldPersistenceInfo[] persistenceInfoObjects, 
			IPredicateExpression filter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relationsToWalk, 
			bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateSelectDQ(fieldsToFetch.GetAsEntityFieldCoreArray(),
				persistenceInfoObjects, GetActiveConnection(), filter, maxNumberOfItemsToReturn, sortClauses, relationsToWalk, allowDuplicates, groupByClause, pageNumber, pageSize);
		}


		/// <summary>
		/// Creates a new RowCount DQ for the query build with the elements passed in
		/// </summary>
		/// <param name="fieldsToFetch">fields to fetch using the select</param>
		/// <param name="persistenceInfoObjects">persistence info objects for the fields</param>
		/// <param name="filter">filter to use for the where clause</param>
		/// <param name="relationsToWalk">relations to walk to build the FROM clause</param>
		/// <param name="allowDuplicates">flag to specify if duplicates should be returned</param>
		/// <param name="groupByClause">group by clause to embed in the query</param>
		/// <returns>ready to use query to use.</returns>
		protected virtual IRetrievalQuery CreateRowCountDQ(IEntityFields2 fieldsToFetch, IFieldPersistenceInfo[] persistenceInfoObjects, 
			IPredicateExpression filter, IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateRowCountDQ(fieldsToFetch.GetAsEntityFieldCoreArray(),
				persistenceInfoObjects, GetActiveConnection(), filter, relationsToWalk, allowDuplicates, groupByClause);
		}

			
		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null</exception>
		protected virtual IActionQuery CreateDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, ArrayList pkFilters)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateDeleteDQ(fieldsPersistenceInfo, GetActiveConnection(), pkFilters);
		}


		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <param name="additionalDeleteFilter">Extra predicate for concurrency purposes.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a second FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null or when deleteFilter is null or when relationsToWalk is null</exception>
		protected virtual IActionQuery CreateDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, ArrayList pkFilters, IPredicate additionalDeleteFilter, IRelationCollection relationsToWalk)
		{
			DynamicQueryEngineBase engine = CreateDynamicQueryEngine();
			return engine.CreateDeleteDQ(fieldsPersistenceInfo, GetActiveConnection(), pkFilters, additionalDeleteFilter, relationsToWalk);
		}


		/// <summary>
		/// Retrieves the persistence info for the fields passed in. 
		/// </summary>
		/// <param name="fields">Fields for which the persistence info has to be determined</param>
		/// <returns>the requested persistence information</returns>
		protected virtual IFieldPersistenceInfo[] GetFieldPersistenceInfos(IEntityFields2 fields)
		{
			IFieldPersistenceInfo[] persistenceInfo = new FieldPersistenceInfo[fields.Count];
			for (int i = 0; i < fields.Count; i++)
			{
				persistenceInfo[i] = GetFieldPersistenceInfo(fields[i]);
			}

			return persistenceInfo;
		}


		/// <summary>
		/// Expands the values array to contain slots for excluded fields so all indices on the normal set of fields match the actual fields, because
		/// the resultset of a fetch with excluded fields is smaller than the resultset of a normal fetch (no columns are there for excluded fields)
		/// </summary>
		/// <param name="valuesOfRow">The values of row.</param>
		/// <param name="fieldsUsedForQuery">The fields used for query.</param>
		/// <param name="fieldsPersistenceInfo">The fields persistence info.</param>
		/// <returns>a new object array with the values of valuesOfRow, but now with field slots for all excluded fields.</returns>
		private object[] ExpandValuesArrayToContainExcludedFieldSlots(object[] valuesOfRow, IEntityFields2 fieldsUsedForQuery, 
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
		/// Excludes the persistenceinfo objects (set slots to null) for all excluded fields in 'excludedIncludedFields'.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="persistenceInfos">The persistence infos to manipulate.</param>
		/// <param name="hierarchyType">Type of the hierarchy the entity is in or to consider. If this is is targetperentity we have to traverse the
		/// complete fields list to find a field to exclude, otherwise we can rely on the fieldindex.</param>
		/// <param name="excludedIncludedFields">The fields to exclude/include, a list of IEntityField2 instances</param>
		/// <param name="discriminatorFieldIndex">Index of the discriminator field. Is -1 if the entity doesn't have any discriminator field. Used to
		/// ignore discriminator fields in a set of excluded fields.</param>
		private void ExcludeFieldsFromPersistenceInfos(IEntityFields2 fields, IFieldPersistenceInfo[] persistenceInfos,
			ExcludeIncludeFieldsList excludedIncludedFields, InheritanceHierarchyType hierarchyType, int discriminatorFieldIndex)
		{
			if((excludedIncludedFields == null) || (excludedIncludedFields.Count <= 0))
			{
				// nothing to exclude
				return;
			}

			IList fieldsToUse = FilterOutIllegalExcludedFields(excludedIncludedFields.BuildFieldsToExcludeList(fields), hierarchyType, discriminatorFieldIndex);

			foreach(IEntityField2 field in fieldsToUse)
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
			foreach(IEntityField2 field in excludedFields)
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
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		/// <remarks>Internal version. This version alters filterBucket if the entity to fetch is in a hierarchy: it adds hierarchy relations to
		/// the filter passed. Calling methods should first clone the filter passed in before calling this method</remarks>
		private void FetchEntityCollectionInternal(IEntityCollection2 collectionToFill, ref IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityCollectionInternal(6)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityCollectionBase2)collectionToFill).GetEntityCollectionDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Collection Description");

			if(collectionToFill.EntityFactoryToUse==null)
			{
				// no factory set. 
				throw new ArgumentException("No entity factory specified in the passed in IEntityCollection2 object. Cannot continue", "collectionToFill");
			}

			bool relationsPresent = false;
			IEntityFields2 fieldsForQuery = collectionToFill.EntityFactoryToUse.CreateHierarchyFields();

			EntityBase2 dummy = (EntityBase2)collectionToFill.EntityFactoryToUse.Create();
			InheritanceHierarchyType hierarchyType = dummy.GetInheritanceHierarchyType();
			int discriminatorFieldIndex = -1;

			if(hierarchyType != InheritanceHierarchyType.None)
			{
				// add type filter from factory. Create clone so filter can be re-used.
				if(filterBucket==null)
				{
					filterBucket = new RelationPredicateBucket();
				}
				filterBucket.PredicateExpression.AddWithAnd(collectionToFill.EntityFactoryToUse.GetEntityTypeFilter(false));

				if(hierarchyType == InheritanceHierarchyType.TargetPerEntity)
				{
					IRelationCollection relationsForHierarchy = collectionToFill.EntityFactoryToUse.CreateHierarchyRelations();
					// add hierarchy relations after all other relations. These relations are for subtype retrieval of the entity type to retrieve.
					// the original passed in relations already contain relations to build the actual relations and filters, as both should contain teh
					// relations to root.
					if(relationsForHierarchy!=null)
					{
						// Clone is already created in previous if statement.
						filterBucket.Relations.AddRange((RelationCollection)relationsForHierarchy);
					}
				}
				else
				{
					// targetperentity hierarchy
					discriminatorFieldIndex = dummy.GetInheritanceInfo().DiscriminatorColumnIndex;
				}			
			}

			IPredicateExpression predicateExpressionToUse = null;
			InterpretFilterBucket(filterBucket, ref relationsPresent, ref predicateExpressionToUse);
			InsertPersistenceInfoObjects(sortClauses);
			IFieldPersistenceInfo[] persistenceInfo = GetFieldPersistenceInfos(fieldsForQuery);
			// exclude fields, if any
			ExcludeFieldsFromPersistenceInfos(fieldsForQuery, persistenceInfo, excludedIncludedFields, hierarchyType, discriminatorFieldIndex);

			IRetrievalQuery selectQuery = null;
			if(relationsPresent)
			{
				selectQuery=CreateSelectDQ(fieldsForQuery, 
					persistenceInfo, predicateExpressionToUse, maxNumberOfItemsToReturn, sortClauses, filterBucket.Relations, false, null, pageNumber, pageSize);
			}
			else
			{
				selectQuery=CreateSelectDQ(fieldsForQuery, 
					persistenceInfo, predicateExpressionToUse, maxNumberOfItemsToReturn, sortClauses, null, true, null, pageNumber, pageSize);
			}

			try
			{
				// flag we're about to execute an entitycollection fetch
				OnFetchEntityCollection(selectQuery, collectionToFill);

				bool allowDuplidates = ((collectionToFill.Count <= 0) && !selectQuery.RequiresClientSideDistinctFiltering);
				ExecuteMultiRowRetrievalQuery(selectQuery, collectionToFill.EntityFactoryToUse, collectionToFill, persistenceInfo, allowDuplidates, fieldsForQuery);

				// flag we're done executing an entitycollection fetch
				OnFetchEntityCollectionComplete(selectQuery, collectionToFill);
			}
			finally
			{
				selectQuery.Dispose();
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityCollectionInternal(6)", "Method Exit");
		}


		/// <summary>
		/// Creates a retrieval query from elements.
		/// </summary>
		/// <param name="fieldCollectionToFetch">The field collection to fetch.</param>
		/// <param name="filterBucket">The filter bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="persistenceInfo">The persistence info.</param>
		/// <param name="selectQuery">The select query.</param>
		private void CreateQueryFromElements( IEntityFields2 fieldCollectionToFetch, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize, 
			out IFieldPersistenceInfo[] persistenceInfo, out IRetrievalQuery selectQuery )
		{
			persistenceInfo = new FieldPersistenceInfo[fieldCollectionToFetch.Count];

			// get the persistence info objects for the fields in the collection
			for( int i = 0; i < fieldCollectionToFetch.Count; i++ )
			{
				persistenceInfo[i] = GetFieldPersistenceInfo( fieldCollectionToFetch[i] );
			}

			RelationPredicateBucket filterToUse = PreprocessQueryElements(fieldCollectionToFetch, filterBucket);

			bool relationsPresent = false;
			IPredicateExpression expressionToPass = null;
			InterpretFilterBucket( filterToUse, ref relationsPresent, ref expressionToPass );
			InsertPersistenceInfoObjects( sortClauses );
			InsertPersistenceInfoObjects( groupByClause );

			((RelationCollection)filterToUse.Relations).ToggleArtificialAliasingForTargetPerEntityRelations(true);

			selectQuery = null;

			// construct query
			if( relationsPresent )
			{
				selectQuery = CreateSelectDQ( fieldCollectionToFetch, persistenceInfo, expressionToPass, maxNumberOfItemsToReturn, sortClauses,
					filterToUse.Relations, allowDuplicates, groupByClause, pageNumber, pageSize );
			}
			else
			{
				selectQuery = CreateSelectDQ( fieldCollectionToFetch, persistenceInfo, expressionToPass, maxNumberOfItemsToReturn, sortClauses,
					null, allowDuplicates, groupByClause, pageNumber, pageSize );
			}
		}


		/// <summary>
		/// Preprocesses the query elements.
		/// </summary>
		/// <param name="fieldCollectionToFetch">The field collection to fetch.</param>
		/// <param name="filterBucket">The filter bucket.</param>
		/// <returns>Cloned filterBucket with extra relations for inheritance + type filters, if required</returns>
		private RelationPredicateBucket PreprocessQueryElements(IEntityFields2 fieldCollectionToFetch, IRelationPredicateBucket filterBucket)
		{
			IInheritanceInfoProvider infoProvider = ((EntityFields2)fieldCollectionToFetch).InheritanceInfoProviderToUse;
			RelationPredicateBucket filterToUse = (RelationPredicateBucket)CreateUsableBucketClone( filterBucket );
			if( filterToUse == null )
			{
				filterToUse = new RelationPredicateBucket();
			}

			if(infoProvider != null)
			{
				RelationCollection hierarchyRelations = PersistenceCore.DetermineInheritanceRelations(fieldCollectionToFetch, filterToUse.Relations, 
					filterToUse.PredicateExpression, infoProvider);
				if((hierarchyRelations != null) && (hierarchyRelations.Count > 0))
				{
					filterToUse.Relations.AddRange(hierarchyRelations);
				}

				// Determine if we have to add one or more type filters for fields from entities in a TargetPerEntityHierarchy. 
				// E.g.: if FamilyCompanyCar.Brand is specified, it should filter on FamilyCompanyCar or all subtypes but shouldn't return 
				// brandnames of sibling types or supertypes.
				Hashtable entityNamesToCheck = new Hashtable();
				foreach(EntityField2 field in fieldCollectionToFetch)
				{
					if((field.ActualContainingObjectName != field.ContainingObjectName) && !entityNamesToCheck.ContainsKey(field.ActualContainingObjectName))
					{
						// field is in a different entity than it's defined in (inherited field). 
						entityNamesToCheck.Add(field.ActualContainingObjectName, field.ObjectAlias);
					}
				}

				if(entityNamesToCheck.Count > 0)
				{
					// filter out entities in a hierarchy of TargetPerEntity, and also filter out supertypes if the subtype is also in the list. 
					// grab the filter and set the proper object alias.
					filterToUse.PredicateExpression.AddWithAnd(infoProvider.GetEntityTypeFilters(entityNamesToCheck));
				}
			}

			return filterToUse;
		}


		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		/// <remarks>Internal version. This version alters filterBucket if the entity to fetch is in a hierarchy: it adds hierarchy relations to
		/// the filter passed. Calling methods should first clone the filter passed in before calling this method</remarks>
		private IEntity2 FetchNewEntityInternal( IEntityFactory2 entityFactoryToUse, ref IRelationPredicateBucket filterBucket, Context contextToUse,
			ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchNewEntityInternal(4)", "Method Enter");

			if((entityFactoryToUse==null)||(filterBucket==null))
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchNewEntityInternal(4): one or more method arguments are null.", "Method Exit");
				return null;
			}

			// use collection fetch for the single entity fetch, to re-use code for entity inheritance type discovery.
			EntityCollectionForFetch container = new EntityCollectionForFetch(entityFactoryToUse);
			if(contextToUse!=null)
			{
				container.ActiveContext = contextToUse;
			}
			FetchEntityCollectionInternal(container, ref filterBucket, 1, null, excludedIncludedFields, 0, 0);

			IEntity2 toReturn = null;
			if(container.Count>0)
			{
				toReturn = container[0];
			}
			else
			{
				// not found, create new one
				toReturn = entityFactoryToUse.Create();
				// set state to OutOfSync, as that's expected
				toReturn.Fields.State = EntityState.OutOfSync;
			}
			// clean up the temp collection so no event handlers are left behind.
			container.Clear();
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchNewEntityInternal(4)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Adds the passed in entity as a participant of this transaction. 
		/// </summary>
		/// <param name="participant">The participant which actions have to be included in this transaction</param>
		private void AddTransactionParticipant(IEntity2 participant)
		{
			if(!_transactionParticipantObjectIds.ContainsKey(participant.ObjectID))
			{
				// add it
				_transactionParticipants.Add(participant);
				_transactionParticipantObjectIds.Add(participant.ObjectID, null);
				// pass null, an ITransaction object is not used in Adapter. Will set ParticipatesInTransaction to true
				((ITransactionalElement)participant).Transaction = null;
			}
		}


		/// <summary>
		/// Checks if the passed in entity is present in the hashtables passed in. 
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
		private bool CheckForDuplicate(IEntity2 entityToAdd, ref Hashtable objectHashtable, ref Hashtable objectHashes)
		{
			int entityHash = entityToAdd.GetHashCode();
			bool noDuplicateSeen=false;
			if(!objectHashes.ContainsKey(entityHash))
			{
				// no, so add it to the collection and its hash to the hashlist.
				objectHashes.Add(entityHash, null);
				// add new hash bucket to hashtable
				ArrayList newBucket = new ArrayList();
				newBucket.Add(entityToAdd);
				objectHashtable.Add(entityHash, newBucket);
				// flag that no duplicate has been seen.
				noDuplicateSeen=true;
			}
			else
			{
				// hashcode exists. Bucket is there.
				// Check if the entity is equal to any of the entities in the list related to this hashcode.
				ArrayList bucket = (ArrayList)objectHashtable[entityHash];
				bool equalFound=false;
				for (int i = 0; i < bucket.Count; i++)
				{
					EntityBase2 currentEntity=(EntityBase2)bucket[i];
					equalFound = currentEntity.Equals(entityToAdd);
					if(equalFound)
					{
						// duplicate
						break;
					}
				}

				if(!equalFound)
				{
					// not found, no duplicate
					noDuplicateSeen=true;
					bucket.Add(entityToAdd);
				}
			}

			return noDuplicateSeen;
		}


		/// <summary>
		/// Interprets the passed in filterbucket and returns information determined after interpreting the data inside the IRelationPredicateBucket object.
		/// The Relations and predicate expression are initialized with field persistence info objects
		/// </summary>
		/// <param name="filterBucket">The IRelationPredicateBucket object with the filter information to interepret</param>
		/// <param name="relationsPresent">Ref parameter which will be true if there are relation objects specified inside filterBucket</param>
		/// <param name="expressionToPass">Ref parameter which will be the predicate expression to pass to query construction code</param>
		private void InterpretFilterBucket(IRelationPredicateBucket filterBucket, ref bool relationsPresent, ref IPredicateExpression expressionToPass)
		{
			relationsPresent = false;
			expressionToPass = null;
			if(filterBucket!=null)
			{
				if(((RelationCollection)filterBucket.Relations).Count > 0)
				{
					InsertPersistenceInfoObjects(filterBucket.Relations);
					relationsPresent=true;
				}
				if(filterBucket.PredicateExpression!=null)
				{
					if(filterBucket.PredicateExpression.Count>0)
					{
						expressionToPass = filterBucket.PredicateExpression;
						InsertPersistenceInfoObjects(expressionToPass);
					}
				}
			}
		}


		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using the filter specified.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="filter">The filter to use.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>
		/// true if the Fetch was succesful, false otherwise
		/// </returns>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be utilized</remarks>
		private bool FetchEntityUsingFilter(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse, IRelationPredicateBucket filter, 
			ExcludeIncludeFieldsList excludedIncludedFields)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingFilter(5)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)entityToFetch).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Description");

			if(filter == null)
			{
				throw new ORMGeneralOperationException("Filter can't be null.");
			}
			if(entityToFetch == null)
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingFilter(5): entity is null.", "Method Exit");
				return false;
			}

			int discriminatorFieldIndex = -1;
			IInheritanceInfo info = ((EntityBase2)entityToFetch).GetInheritanceInfo();
			InheritanceHierarchyType hierarchyType = ((EntityBase2)entityToFetch).GetInheritanceHierarchyType();
			switch(hierarchyType)
			{
				case InheritanceHierarchyType.TargetPerEntity:
					// grab the inheritanceInfo, and add the relations to the root of the hierarchy to the filter.
					filter.Relations.AddRange(info.RelationsToHierarchyRoot);
					break;
				case InheritanceHierarchyType.TargetPerEntityHierarchy:
					discriminatorFieldIndex = info.DiscriminatorColumnIndex;
					break;
			}

			Context activeContext = contextToUse;
			if((activeContext == null) && (entityToFetch.ActiveContext != null))
			{
				activeContext = entityToFetch.ActiveContext;
			}

			bool fetchResult = false;
			bool keepConnectionOpenSave = _keepConnectionOpen;
			try
			{
				this.KeepConnectionOpen = true;
				IFieldPersistenceInfo[] persistenceInfos = GetFieldPersistenceInfos(entityToFetch.Fields);
				// remove the persistence infos from the persistentInfos array (set the slots to null) for the excluded fields in excludedFields.
				ExcludeFieldsFromPersistenceInfos(entityToFetch.Fields, persistenceInfos, excludedIncludedFields, hierarchyType, discriminatorFieldIndex);
				fetchResult = FetchEntityUsingFilter(entityToFetch.Fields, persistenceInfos, filter);
				if(!((EntityBase2)entityToFetch).CallOnCanLoadEntity())
				{
					// reset with new fields.
					entityToFetch.Fields = ((EntityBase2)entityToFetch).GetEntityFactory().CreateFields();
					fetchResult = false;
				}
				else
				{
					entityToFetch.IsNew &= !fetchResult;
				}
				if(fetchResult)
				{
					if(activeContext != null)
					{
						entityToFetch.ActiveContext = activeContext;
						// update the fields on a previous entity object fetched with the same PK, if it's in the current context, with the fields just fetched
						IEntity2 dummy = activeContext.Get(entityToFetch);
					}

					// now it's time to validate the loaded entity. If validation fails, we don't have to do the whole prefetch path. 
					((EntityBase2)entityToFetch).CallValidateEntityAfterLoad();

					// process prefetch path. 
					if((prefetchPath != null) && (prefetchPath.Count > 0))
					{
						// create a new entity collection. 
						IEntityCollection2 rootEntityCollection = Activator.CreateInstance(prefetchPath[0].RetrievalCollection.GetType()) as IEntityCollection2;
						if(rootEntityCollection!=null)
						{
							if(activeContext != null)
							{
								rootEntityCollection.ActiveContext = activeContext;
							}
							rootEntityCollection.Add((EntityBase2)entityToFetch);
							FetchPrefetchPath(rootEntityCollection, filter, 0, null, prefetchPath);
							// clean up the temp collection so no event handlers are left behind.
							rootEntityCollection.Clear();
						}
					}

					((EntityBase2)entityToFetch).CallOnAuditLoadOfEntity();
				}
			}
			finally
			{
				this.KeepConnectionOpen = keepConnectionOpenSave;
				if(!(_keepConnectionOpen || _isTransactionInProgress))
				{
					CloseConnection();
				}
			}
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingFilter(5)", "Method Exit");
			return fetchResult;
		}


		/// <summary>
		/// Fetches an entity from the persistent storage using the filter specified.
		/// </summary>
		/// <param name="fieldsToFetch">The EntityFields2 object to store the entity data in</param>
		/// <param name="persistenceInfos">the field persistence infos for the fields passed in..</param>
		/// <param name="filter">The filter to use to retrieve one entity. If the filter matches more than 1 entity, the first entity read will be used.</param>
		/// <returns>true if fetch succeeded, false otherwise</returns>
		private bool FetchEntityUsingFilter(IEntityFields2 fieldsToFetch, IFieldPersistenceInfo[] persistenceInfos, IRelationPredicateBucket filter)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingFilter(3)", "Method Enter");

			bool fetchSucceeded = false;

			fieldsToFetch.State = EntityState.OutOfSync;
			IPredicateExpression predicateExpressionToUse = null;
			bool relationsPresent = false;
			InterpretFilterBucket(filter, ref relationsPresent, ref predicateExpressionToUse);

			for (int i = 0; i < fieldsToFetch.Count; i++)
			{
				InsertPersistenceInfoObjects(fieldsToFetch[i]);
			}

			IRetrievalQuery selectQuery = null;
			if(relationsPresent)
			{
				selectQuery=CreateSelectDQ(fieldsToFetch, persistenceInfos, predicateExpressionToUse, 0, null, filter.Relations, true, null, 0,0);
			}
			else
			{
				selectQuery=CreateSelectDQ(fieldsToFetch, persistenceInfos, predicateExpressionToUse, 0, null, null, true, null, 0, 0);
			}

			try
			{
				// Flag we're about to start a fetch entity action
				OnFetchEntity(selectQuery, fieldsToFetch);

				ExecuteSingleRowRetrievalQuery(selectQuery, fieldsToFetch, persistenceInfos);

				// Flag we're done with the fetch entity action
				OnFetchEntityComplete(selectQuery, fieldsToFetch);
			}
			finally
			{
				selectQuery.Dispose();
			}
			fetchSucceeded = (fieldsToFetch.State==EntityState.Fetched);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.FetchEntityUsingFilter", "Method Exit");
			return fetchSucceeded;
		}


		/// <summary>
		/// Removes all participating elements from this transaction and sends them a commit or rollback signal, based on the passed in boolean Commit.
		/// This action will make the participating objects to take care of their own connections again.
		/// </summary>
		/// <param name="action">Action to perform on each removed element.</param>
		private void RemoveElementsFromTransaction(ActionToPerformDuringRemove action)
		{
			for(int i=0;i<_transactionParticipants.Count;i++)
			{
				ITransactionalElement participant = (ITransactionalElement)_transactionParticipants[i];
				switch(action)
				{
					case ActionToPerformDuringRemove.None:
						// do nothing
						break;
					case ActionToPerformDuringRemove.SendCommit:
						participant.TransactionCommit();
						break;
					case ActionToPerformDuringRemove.SendRollback:
						participant.TransactionRollback();
						break;
				}
			}
		}


		/// <summary>
		/// Resets the transaction object. All participants will be notified.
		/// </summary>
		private void Reset()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.Reset", "Method Enter");

			// test if there is a transaction going on.
			if(_isTransactionInProgress)
			{
				Rollback();
			}

			RemoveElementsFromTransaction(ActionToPerformDuringRemove.None);

			_transactionParticipants.Clear();
			_transactionParticipantObjectIds.Clear();
			_savePointNames.Clear();
			
			// no longer needed
			_auditorsToNotifyOnCommit.Clear();
		
#if !CF
			if(_physicalTransaction!=null)
			{
				_physicalTransaction.Dispose();
			}
#endif
			_physicalTransaction = null;
			_isTransactionInProgress = false;

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.Reset", "Method Exit");
		}


		/// <summary>
		/// Fetches one row from the open data-reader and places that row into the passed in object rowDestination. rowDestination
		/// should match the format of the rows read by DataSource. Will only read the current row.
		/// </summary>
		/// <param name="dataSource">The open datareader used to fetch the data</param>
		/// <param name="rowDestination">The IEntityFields2 implementing object where the data should be stored.</param>
		/// <param name="fieldsPersistenceInfo">The IFieldPersistenceInfo objects for the rowDestination fields</param>
		private void FetchOneRow(IDataReader dataSource, IEntityFields2 rowDestination, IFieldPersistenceInfo[] fieldsPersistenceInfo)
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
					dataSource.GetValues( values);
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
				ArrayList fieldNameToOrdinal = new ArrayList(rowDestination.Count);
				int index = 0;
				for(int i=0;i<rowDestination.Count;i++)
				{
					IEntityField2 field =rowDestination[i];
					if(fieldsPersistenceInfo[i] == null)
					{
						// field was excluded
						fieldNameToOrdinal.Add(new IntValuePair(field.FieldIndex, -1));
					}
					else
					{
						fieldNameToOrdinal.Add(new IntValuePair(field.FieldIndex, index));
						index++;
					}
				}

				ReadRowIntoFields(values, rowDestination, fieldNameToOrdinal, fieldsPersistenceInfo);

				// set state to fetched
				rowDestination.State = EntityState.Fetched;
			}
		}


		/// <summary>
		/// Fetches the values passed in into the rowDestination. 
		/// </summary>
		/// <param name="values">the values to read into rowDestination</param>
		/// <param name="rowDestination">The IEntityFields2 implementing object where the data should be stored.</param>
		/// <param name="fieldIndexToOrdinal">List with IntValuePairs with per fieldindex the ordinal position in values.</param>
		/// <param name="fieldsPersistenceInfo">The IFieldPersistenceInfo objects used for the fields to produce the query. They're in the same order
		/// as the values in 'values', and values[0] belongs to fieldsPersistenceInfo[0]. Used for type converters.</param>
		/// <remarks>Override this routine if you want to perform string / value caching.</remarks>
		protected virtual void ReadRowIntoFields(object[] values, IEntityFields2 rowDestination, ArrayList fieldIndexToOrdinal, IFieldPersistenceInfo[] fieldsPersistenceInfo)
		{
			int columnOrdinal = 0;
			for(int i=0;i<fieldIndexToOrdinal.Count;i++)
			{
				IntValuePair pair = (IntValuePair)fieldIndexToOrdinal[i];
				bool isColumnValueDBNull = false;
				EntityField2 fieldToSet = (EntityField2)rowDestination[pair.Value1];
				bool isConverted = false;
				object value = null;

				columnOrdinal = pair.Value2;
				if(columnOrdinal >= 0)
				{
					value = values[columnOrdinal];
					// first test for NULL
					isColumnValueDBNull = (value == System.DBNull.Value);
#if !CF
					if((fieldsPersistenceInfo[columnOrdinal] != null) && (fieldsPersistenceInfo[columnOrdinal].TypeConverterToUse != null))
					{
						// converter set. Convert from this value to the converter's core type, which is the same type as the fieldToSet's .NET type.
						object oldValue = value;
						value = fieldsPersistenceInfo[columnOrdinal].TypeConverterToUse.ConvertFrom(null, null, value);
						isConverted = !oldValue.Equals(value);
					}
#endif
				}
				else
				{
					// field was ignored. 
					isColumnValueDBNull = true;
				}

				fieldToSet.IsNull = isColumnValueDBNull;
				if(isColumnValueDBNull && !isConverted)
				{
					fieldToSet.ForcedCurrentValueWriteInternal(null, null);
				}
				else
				{
					// simply store the value
					fieldToSet.ForcedCurrentValueWriteInternal(value, value);
				}
			}
			rowDestination.IsDirty=false;
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="rootEntities">EntityCollection object containing one or more root objects which will contain the entities to fetch (and their paths)
		/// defined in the prefetch path.</param>
		/// <param name="filterBucket">filter information used to retrieve the root entities.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return limit used to retrieve the root entities.</param>
		/// <param name="sortClauses">SortClause expression which was applied to the query executed to retrieve the root entities</param>
		/// <param name="prefetchPath">the PrefetchPath which defines the graph of objects to fetch.</param>
		protected virtual void FetchPrefetchPath(IEntityCollection2 rootEntities, IRelationPredicateBucket filterBucket, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath)
		{
			FetchPrefetchPath(rootEntities, filterBucket, maxNumberOfItemsToReturn, sortClauses, prefetchPath, false);
		}


		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="rootEntities">EntityCollection object containing one or more root objects which will contain the entities to fetch (and their paths)
		/// defined in the prefetch path.</param>
		/// <param name="filterBucket">filter information used to retrieve the root entities.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return limit used to retrieve the root entities.</param>
		/// <param name="sortClauses">SortClause expression which was applied to the query executed to retrieve the root entities</param>
		/// <param name="prefetchPath">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="forceParameterizedPPath">if set to true, it always will use a parameterized prefetch path, no matter what. Used for paging
		/// scenario's</param>
		private void FetchPrefetchPath(IEntityCollection2 rootEntities, IRelationPredicateBucket filterBucket, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, bool forceParameterizedPPath)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.FetchPrefetchPath", "Method Enter");

			if(rootEntities.Count<=0)
			{
				// no root objects, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.FetchPrefetchPath: No root objects.", "Method Exit");
				return;
			}

			if(prefetchPath==null)
			{
				// no prefetch path specified
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.FetchPrefetchPath: No prefetch path.", "Method Exit");
				return;
			}

			int pkCount = DetermineNumberOfPkFields(rootEntities[0]);
			int setCount = rootEntities.Count;
			// if the # of root elements is already below the threshold, we can always use a parameterized query instead of a subquery, as the # of pk fields
			// or the # of fk values will never be above the threshold for this path element's subnodes. 
			bool alwaysUseParameterizedQueryForElement = (forceParameterizedPPath ||
				((((setCount * pkCount) <= ParameterisedPrefetchPathThreshold) && (pkCount > 0)) ||
				((pkCount == 0) && (setCount <= ParameterisedPrefetchPathThreshold))));

			InheritanceHierarchyType hierarchyTypeOfRootEntities = ((EntityBase2)rootEntities[0]).GetInheritanceHierarchyType();
			for(int i=0;i<prefetchPath.Count;i++)
			{
				IPrefetchPathElement2 currentElement = prefetchPath[i];
				bool rootEntitiesArePkSide = currentElement.Relation.StartEntityIsPkSide;

				// check if element is meant for the root entities currently set as rootentities. 
				// only elements which are meant for the root entities or, if not meant for the root type of the path, 
				// for a subtype of the root entities (if applicable) are accepted, which is tested by checking if the rootentities are in a hierarchy.
				if(hierarchyTypeOfRootEntities==InheritanceHierarchyType.None)
				{
					if(prefetchPath.RootEntityType!=currentElement.DestinationEntityType)
					{
						// not in a hierarchy. The element is added to a path which is illegal.
						throw new ApplicationException(
							string.Format("The prefetch path element at index {0} in the passed in prefetch path for root entity type {1} is meant for root entity type {2} which isn't a subtype of {1}. This means that you've added a prefetch path node to a Path of an unrelated entity, for example adding OrderDetailsEntity.PrefetchPathProduct to a prefetch path for CustomerEntity.", 
							i, prefetchPath.RootEntityType, currentElement.DestinationEntityType));
					}
				}

				IRelationPredicateBucket elementFilter = new RelationPredicateBucket();

				// now determine if we need a parameterized query or a subquery based query. 
				// the following rules apply: (N is the root entities node, N+1 is the node we're going to fetch in this routine now)
				// if N is on the PK side in the N - (N+1) relation, then if alwaysUseParameterizedQueryForElement is true, use a parameterized query
				// if N is on the FK side in that relation, use a parameterized query if alwaysUseParameterizedQueryForElement is true OR if the 
				// total # of different FK values * the # of fk fields is smaller than the threshold. Otherwise use a subquery.
				Hashtable values = null;
				int amountRootEntitiesUsable = 0;

				bool useParameterizedQuery = false;
				if(rootEntitiesArePkSide || (currentElement.TypeOfRelation==RelationType.ManyToMany))
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
					CreateSubPathFilterParameterizedPPath(rootEntities, prefetchPath, currentElement, elementFilter, values);
				}
				else
				{
					CreateSubPathFilterSubQueryPPath(filterBucket, currentElement, elementFilter, maxNumberOfItemsToReturn, sortClauses);
				}

				// append extra relations and filters, if applicable.
				if(currentElement.FilterRelations!=null)
				{
					for (int j = 0; j < currentElement.FilterRelations.Count; j++)
					{
						EntityRelation currentRelation = (EntityRelation)currentElement.FilterRelations[j];
						elementFilter.Relations.Add(currentRelation, currentRelation.AliasStartEntity, currentRelation.AliasEndEntity, currentRelation.HintForJoins);
					}
				}
				if(currentElement.Filter!=null)
				{
					if(currentElement.Filter.Count>0)
					{
						elementFilter.PredicateExpression.AddWithAnd(currentElement.Filter);
					}
				}

				if(rootEntities.ActiveContext!=null)
				{
					currentElement.RetrievalCollection.ActiveContext = rootEntities.ActiveContext;
				}

				// execute the fetch. 
				FetchEntityCollectionInternal(currentElement.RetrievalCollection, ref elementFilter, 0, currentElement.Sorter, currentElement.ExcludedIncludedFields, 0, 0);

				/////////////
				// merge the entities fetched with the entities in the rootEntities collection. 
				/////////////
				if(currentElement.TypeOfRelation==RelationType.ManyToMany)
				{
					MergeManyToMany(currentElement, elementFilter, maxNumberOfItemsToReturn, rootEntities);
				}
				else
				{
					MergeNormal(rootEntities, currentElement, rootEntitiesArePkSide);
				}

				if(currentElement.SubPath.Count>0)
				{
					FetchPrefetchPath(currentElement.RetrievalCollection, elementFilter, currentElement.MaxAmountOfItemsToReturn, currentElement.Sorter, 
						currentElement.SubPath);
				}
				// clear the retrieval collection and cached PK hashes, so the path can be re-used.
				((EntityCollectionBase2)currentElement.RetrievalCollection).Clear();
				((EntityCollectionBase2)currentElement.RetrievalCollection).CachedPkHashes = null;
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.FetchPrefetchPath", "Method Exit");
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
		private Hashtable DetermineDifferentValuesForParameterizedPPath(IEntityCollection2 rootEntities, IPrefetchPath2 prefetchPath, IPrefetchPathElement2 currentElement, 
			ref int amountRootEntitiesUsable)
		{
			Hashtable values = new Hashtable();

			foreach(IEntity2 currentRootEntity in rootEntities)
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
					IEntityField2 valueField = null;
					if(currentElement.Relation.StartEntityIsPkSide)
					{
						valueField = currentRootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(j).Name];
					}
					else
					{
						valueField = currentRootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(j).Name];
					}
					if(valueField.IsNull || (valueField.CurrentValue==null)) 
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

				if(!useEntity || (valueList.Count<=0))
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
		/// Creates the sub path filter for a parameterized Prefetch path subnode.
		/// Routine is used for all prefetch path types.
		/// </summary>
		/// <param name="rootEntities">The root entities.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		/// <param name="currentElement">The current element.</param>
		/// <param name="elementFilter">The element filter.</param>
		/// <param name="values">The values to use for the parameterized query. Key has all values of all fields concatenated as string form, Value is either 
		/// a single value if the relation has just 1 field, or an arraylist of values if the relation has more than 1 field.</param>
		private void CreateSubPathFilterParameterizedPPath( IEntityCollection2 rootEntities, IPrefetchPath2 prefetchPath, IPrefetchPathElement2 currentElement, 
			IRelationPredicateBucket elementFilter, Hashtable values )
		{
			if(rootEntities.Count <= 0)
			{
				return;
			}

			if((currentElement.Relation.AmountFields==1)&&(rootEntities.Count>1))
			{
				// optimization: use a CompareRange predicate instead. We select this routine only if there're more than 1 root entity as
				// a WHERE field IN (value) is very slow on sqlserver, compared to WHERE field = value. 
				string aliasToUse=string.Empty;
				IEntityFieldCore fieldToUse = null;
				if (currentElement.Relation.StartEntityIsPkSide)
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasFKSide;
					fieldToUse = currentElement.Relation.GetFKEntityFieldCore(0);
				} 
				else
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasPKSide;
					fieldToUse = currentElement.Relation.GetPKEntityFieldCore(0);
				}
				// Values of the hashtable are single values, not wrapped in arraylist.
				ArrayList valuesToUse = new ArrayList(values.Values);
				if(valuesToUse.Count>0)
				{
					// there are values to compare. Now check if there's just 1. If so, create a fieldcomparevaluepredicate, otherwise a range predicate
					if(valuesToUse.Count>1)
					{
						elementFilter.PredicateExpression.Add(new FieldCompareRangePredicate(fieldToUse, null, aliasToUse, valuesToUse));
					}
					else
					{
						elementFilter.PredicateExpression.Add(new FieldCompareValuePredicate(fieldToUse, null, ComparisonOperator.Equal, valuesToUse[0], aliasToUse));
					}
				}
			}
			else
			{
				string aliasToUse = string.Empty;
				if (currentElement.Relation.StartEntityIsPkSide)
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasFKSide;
				} 
				else
				{
					aliasToUse = ((EntityRelation)currentElement.Relation).AliasPKSide;
				}
				PredicateExpression nodeFilterSet = new PredicateExpression();
				// values are already known, as they're passed in, so all we have to do is per entry in the hashtable, create a set of predicates. 
				IEntity2 rootEntity = null;
				// find the first root entity matching this node
				foreach(IEntity2 currentRootEntity in rootEntities)
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
					IEntityFieldCore compareField = null;

					// construct the filter based on the given relation. Start entity in the relation is always the parent entity for this fetch.
					if(currentElement.Relation.AmountFields > 1)
					{
						ArrayList valueList = (ArrayList)entry.Value;

						for(int j = 0; j < currentElement.Relation.AmountFields; j++)
						{
							IEntityField2 valueField = null;
							if(currentElement.Relation.StartEntityIsPkSide)
							{
								valueField = rootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(j).Name];
								compareField = currentElement.Relation.GetFKEntityFieldCore(j);
							}
							else
							{
								valueField = rootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(j).Name];
								compareField = currentElement.Relation.GetPKEntityFieldCore(j);
							}
							filter.Add(new FieldCompareValuePredicate(compareField, null, ComparisonOperator.Equal, valueList[j], aliasToUse));
						}
					}
					else
					{
						IEntityField2 valueField = null;
						if(currentElement.Relation.StartEntityIsPkSide)
						{
							valueField = rootEntity.Fields[currentElement.Relation.GetPKEntityFieldCore(0).Name];
							compareField = currentElement.Relation.GetFKEntityFieldCore(0);
						}
						else
						{
							valueField = rootEntity.Fields[currentElement.Relation.GetFKEntityFieldCore(0).Name];
							compareField = currentElement.Relation.GetPKEntityFieldCore(0);
						}
						filter.Add(new FieldCompareValuePredicate(compareField, null, ComparisonOperator.Equal, entry.Value, aliasToUse));
					}

					// add the filter for the sub entities for this particular root entity to the nodeFilterSet, which we'll add later on as the single
					// expression for the path. it's a separate expression to avoid conflicts with additional filters. 
					nodeFilterSet.AddWithOr(filter);
				}

				if(nodeFilterSet.Count>0)
				{
					// add the filters for the entities to fetch for this path node to the filter to use in this fetch.
					elementFilter.PredicateExpression.AddWithOr(nodeFilterSet);
				}				
			}
		}


		/// <summary>
		/// Creates the sub path filter for a sub query using prefetch path node fetch
		/// </summary>
		/// <param name="filterBucket">The filter bucket.</param>
		/// <param name="currentElement">The current element.</param>
		/// <param name="elementFilter">The element filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The maxNumberOfItemsToReturn value used for fetching the root elements. Used when currentElement
		/// is at graphLevel 0 (top of graph)</param>
		/// <param name="sorter">The sorter used for fetching the root elements. Used when currentElement
		/// is at graphLevel 0 (top of graph)</param>
		private void CreateSubPathFilterSubQueryPPath(IRelationPredicateBucket filterBucket, IPrefetchPathElement2 currentElement, 
			IRelationPredicateBucket elementFilter, long maxNumberOfItemsToReturn, ISortExpression sorter)
		{
			IRelationCollection elementFilterSubQueryRelations = null;
			IPredicateExpression elementFilterSubQueryFilter = null;
			if(filterBucket != null)
			{
				elementFilterSubQueryRelations = new RelationCollection();
				elementFilterSubQueryRelations.AddRange((RelationCollection)filterBucket.Relations);
				if(filterBucket.PredicateExpression.Count > 0)
				{
					elementFilterSubQueryFilter = new PredicateExpression(filterBucket.PredicateExpression);
				}
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
			if((currentElement.GraphLevel <= 0) && PrefetchPath2.UseRootMaxLimitAndSorterInPrefetchPathSubQueries)
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
					elementFilter.PredicateExpression.Add(new FieldCompareSetPredicate(
						currentElement.Relation.GetFKEntityFieldCore(j), null,
						currentElement.Relation.GetPKEntityFieldCore(j), null, SetOperator.In,
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
						elementFilter.PredicateExpression.Add(new FieldCompareSetPredicate(
							currentElement.Relation.GetFKEntityFieldCore(j), null,
							currentElement.Relation.GetPKEntityFieldCore(j), null, SetOperator.In,
							elementFilterSubQueryFilter, elementFilterSubQueryRelations, ((EntityRelation)currentElement.Relation).AliasFKSide, maxLimitToUse, 
							sorterToUse));
					}
					else
					{
						// root objects are FK side, so the subquery will contain the FK fields, and the entities to fetch the PK fields
						elementFilter.PredicateExpression.Add(new FieldCompareSetPredicate(
							currentElement.Relation.GetPKEntityFieldCore(j), null,
							currentElement.Relation.GetFKEntityFieldCore(j), null,
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
		protected virtual void MergeNormal(IEntityCollection2 rootEntities, IPrefetchPathElement2 currentElement, bool rootEntitiesArePkSide)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.MergeNormal", "Method Enter");

			Hashtable maxCountersPerRootEntity = null;
			int initialSize = rootEntities.Count;
			if(!rootEntitiesArePkSide)
			{
				initialSize = currentElement.RetrievalCollection.Count;
			}
			Hashtable pkSideHashes = new Hashtable(initialSize);

			IEntityCollection2 fkSideCollection, pkSideCollection;
			if(rootEntitiesArePkSide)
			{
				// the root entities contain the PK's, add these to the hashtable
				pkSideCollection = rootEntities;
				fkSideCollection = currentElement.RetrievalCollection;
				maxCountersPerRootEntity = new Hashtable(rootEntities.Count);
			}
			else
			{
				// the fetched entities contain the PK's, add these to the hashtable
				pkSideCollection = currentElement.RetrievalCollection;
				fkSideCollection = rootEntities;
			}

			if(((EntityCollectionBase2)pkSideCollection).CachedPkHashes==null)
			{
				// calculate the hashes
				((EntityCollectionBase2)pkSideCollection).CachedPkHashes = pkSideHashes;
				CreateHashes(pkSideHashes, pkSideCollection);
			}
			else
			{
				pkSideHashes = ((EntityCollectionBase2)pkSideCollection).CachedPkHashes;
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
				IEntity2 pkObject = FindPkObject(pkSideHashes, fkHash, fkSideCollection[j], currentElement.Relation);
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

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.MergeNormal", "Method Exit");
		}



		/// <summary>
		/// Merges the entities fetched in currentElement.RetrievalCollection with the rootEntities for a many to many relation
		/// </summary>
		/// <param name="currentElement">Current element.</param>
		/// <param name="elementFilter">Element filter.</param>
		/// <param name="maxNumberOfItemsToReturn">Max number of items to return.</param>
		/// <param name="rootEntities">Root entities.</param>
		protected virtual void MergeManyToMany(IPrefetchPathElement2 currentElement, IRelationPredicateBucket elementFilter, long maxNumberOfItemsToReturn, 
				IEntityCollection2 rootEntities)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.MergeManyToMany", "Method Enter");

			Hashtable pkSideHashes = new Hashtable();

			// special case. Retrieve in a typed list, the different PK fields related to eachother via the m:n relation. These
			// sets are required to make the proper merges. 
			EntityFields2 manyToManyPkPkFields = new EntityFields2(currentElement.FilterRelations[0].AmountFields + currentElement.FilterRelations[1].AmountFields);
			// add start entity PK fields:
			int fieldsIndex = 0;
			EntityField2 fieldToAdd = null;
			for (int j = 0; j < currentElement.FilterRelations[0].AmountFields; j++)
			{
				fieldToAdd = (EntityField2)((EntityField2)currentElement.FilterRelations[0].GetPKEntityFieldCore(j)).Clone();
				fieldToAdd.Alias = fieldToAdd.Name + fieldsIndex.ToString();
				fieldToAdd.ObjectAlias = currentElement.FilterRelations[0].AliasStartEntity;
				manyToManyPkPkFields[fieldsIndex] = fieldToAdd;
				fieldsIndex++;
			}
			for (int j = 0; j < currentElement.FilterRelations[1].AmountFields; j++)
			{
				fieldToAdd = (EntityField2)((EntityField2)currentElement.FilterRelations[1].GetPKEntityFieldCore(j)).Clone();
				fieldToAdd.Alias = fieldToAdd.Name + fieldsIndex.ToString();
				fieldToAdd.ObjectAlias = currentElement.FilterRelations[1].AliasEndEntity;
				manyToManyPkPkFields[fieldsIndex] = fieldToAdd;
				fieldsIndex++;
			}

			DataTable pkpkFields = new DataTable();
			FetchTypedList(manyToManyPkPkFields, pkpkFields, elementFilter, (int)maxNumberOfItemsToReturn, false);

			// Create root entity hashes.
			CreateHashes(pkSideHashes, rootEntities);

			// create hashtables and fill them so we get end entity hash to datarow and datarow to start entity hash
			Hashtable endEntityPkHashToDataRow = new Hashtable();
			Hashtable dataRowToStartEntityPkHash = new Hashtable();
			CreateHashes(dataRowToStartEntityPkHash, endEntityPkHashToDataRow, pkpkFields, currentElement.FilterRelations);

			// now walk the fetched entities and with the hashtables find the root entities this entity belongs to and merge it. More root entities
			// can be related to a fetched entity.
			Hashtable maxCountersPerRootEntity = new Hashtable(rootEntities.Count);
			for (int j = 0; j < currentElement.RetrievalCollection.Count; j++)
			{
				IEntity2 currentEntity = currentElement.RetrievalCollection[j];
				int currentEntityHash = currentEntity.GetHashCode();
				if(!endEntityPkHashToDataRow.ContainsKey(currentEntityHash))
				{
					// not found, continue
					continue;
				}
				ArrayList dataRows = (ArrayList)endEntityPkHashToDataRow[currentEntityHash];

				// for all datarows in this arraylist, use the ones with the same values for the fields as the current entity, and then check
				// with that datarow the root entities found with the hash value for the fields in the datarow for the root entity. 
				for(int k=0;k<dataRows.Count;k++)
				{
					DataRow row = (DataRow)dataRows[k];
					// check if this entity's PK fields are the same as the end entity fields in this datarow.
					bool theSame = true;
					for (int m = 0; m < currentElement.FilterRelations[1].AmountFields; m++)
					{
						theSame&=(currentEntity.Fields[currentElement.FilterRelations[1].GetPKEntityFieldCore(m).Name].CurrentValue.Equals(
							row[m+currentElement.FilterRelations[0].AmountFields]));
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
					int startEntityHash = (int)dataRowToStartEntityPkHash[row];
					// get arraylist of root objects
					if(!pkSideHashes.ContainsKey(startEntityHash))
					{
						// not found, continue
						continue;
					}

					// with hash, find start object.
					IEntity2 startEntity = FindStartEntity(pkSideHashes, startEntityHash, currentElement.FilterRelations[0], row);
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

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "DataAccessAdapterBase.MergeManyToMany", "Method Exit");
		}


		/// <summary>
		/// Determines if the counter for the entity passed in is lower than the maximum passed in and increases teh counter as well.
		/// </summary>
		/// <param name="maxCounters"></param>
		/// <param name="rootObject"></param>
		/// <param name="maxAmountOfItemsToReturn"></param>
		/// <returns>true if the counter is less than the maximum, which means that the merge can take place</returns>
		protected virtual bool DetermineIfMerge(Hashtable maxCounters, IEntity2 rootObject, long maxAmountOfItemsToReturn)
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
		protected IEntity2 FindPkObject(Hashtable pkSideHashes, int fkHash, IEntity2 fkObject, IEntityRelation relation)
		{
			IEntity2 toReturn = null;

			if(!pkSideHashes.ContainsKey(fkHash))
			{
				// not there
				return toReturn;
			}

			ArrayList entitiesWithHash = (ArrayList)pkSideHashes[fkHash];
			for (int i = 0; i < entitiesWithHash.Count; i++)
			{
				IEntity2 currentEntity=(IEntity2)entitiesWithHash[i];
				// do Field compare. 
				bool theSame = true;
				for (int j = 0; j < relation.AmountFields; j++)
				{
					IEntityField2 pkField = currentEntity.Fields[relation.GetPKEntityFieldCore(j).Name];
					IEntityField2 fkField = fkObject.Fields[relation.GetFKEntityFieldCore(j).Name];
					if(pkField.DataType.IsArray)
					{
						Array pkCurrentValue = (Array)pkField.CurrentValue;
						Array fkCurrentValue = (Array)fkField.CurrentValue;

						// do a per value comparison of the array. That is, if length is equal 
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
		protected IEntity2 FindStartEntity(Hashtable startEntityHashes, int startEntityHash, IEntityRelation relation, DataRow row)
		{
			IEntity2 toReturn = null;

			if(!startEntityHashes.ContainsKey(startEntityHash))
			{
				// not there
				return toReturn;
			}

			ArrayList entitiesWithHash = (ArrayList)startEntityHashes[startEntityHash];
			bool theSame = true;
			for(int i=0;i<entitiesWithHash.Count;i++)
			{
				IEntity2 currentEntity=(IEntity2)entitiesWithHash[i];
				for (int j = 0; j < relation.AmountFields; j++)
				{
					IEntityField2 pkField = currentEntity.Fields[relation.GetPKEntityFieldCore(j).Name];
					if(pkField.DataType.IsArray)
					{
						Array pkCurrentValue = (Array)pkField.CurrentValue;
						Array fkCurrentValue = (Array)row[j];

						// do a per value comparison of the array. That is, if length is equal
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
		protected void CreateHashes(Hashtable hashesToFill, IEntityCollection2 collectionToHash)
		{
			for (int i = 0; i < collectionToHash.Count; i++)
			{
				int hashValue = collectionToHash[i].GetHashCode();
				ArrayList entitiesPerHash = null;
				if(!hashesToFill.ContainsKey(hashValue))
				{
					// not yet there, add it
					entitiesPerHash = new ArrayList();
					hashesToFill.Add(hashValue, entitiesPerHash);
				}
				else
				{
					entitiesPerHash = (ArrayList)hashesToFill[hashValue];
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
		protected void CreateHashes(Hashtable dataRowToStartEntityPkHash, Hashtable endEntityPkHashToDataRow, DataTable pkpkFields, IRelationCollection relations)
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
				ArrayList entry = null;
				if(!endEntityPkHashToDataRow.ContainsKey(endEntityHash))
				{
					// new
					entry = new ArrayList();
					endEntityPkHashToDataRow.Add(endEntityHash, entry);
				}
				else
				{
					entry = (ArrayList)endEntityPkHashToDataRow[endEntityHash];
				}
				entry.Add(pkpkFields.Rows[i]);
			}
		}


		/// <summary>
		/// Creates the usable bucket clone.
		/// </summary>
		/// <param name="toClone">To clone.</param>
		/// <returns></returns>
		private IRelationPredicateBucket CreateUsableBucketClone(IRelationPredicateBucket toClone)
		{
			if(toClone == null)
			{
				return null;
			}
			return (IRelationPredicateBucket)((RelationPredicateBucket)toClone).Clone();
		}


		/// <summary>
		/// Queues the auditor for audit entity flush at commit time. If no transaction is going on, it will flush the entities now
		/// in a separate transaction
		/// </summary>
		/// <param name="auditor">The auditor.</param>
		private void QueueAuditorForCommitFlush(IAuditor auditor)
		{
			if(auditor==null)
			{
				return;
			}

			_auditorsToNotifyOnCommit.Add(auditor);

			if(IsTransactionInProgress)
			{
				// simply use the transaction in progress, which will commit at the end of the transaction.
				return;
			}
			else
			{
				// gather now
				int result = GatherAndFlushAuditData();
				if(result > 0)
				{
					// succeeded
					auditor.TransactionCommitted();
				}
			}
		}


		/// <summary>
		/// Notifies the auditors that the transaction was committed. This means they should clean up any audit entities they contain.
		/// </summary>
		private void NotifyAuditorsForCommit()
		{
			foreach(IAuditor auditor in _auditorsToNotifyOnCommit)
			{
				auditor.TransactionCommitted();
			}
		}


		/// <summary>
		/// Gathers the audit entities to save and then saves them in 1 go.
		/// </summary>
		private int GatherAndFlushAuditData()
		{
			int toReturn = 0;
			EntityCollectionForFetch entitiesToSave = new EntityCollectionForFetch(null);

			foreach(IAuditor auditor in _auditorsToNotifyOnCommit)
			{
				IList entitiesToPersist = auditor.GetAuditEntitiesToSave();
				if((entitiesToPersist == null) || (entitiesToPersist.Count <= 0))
				{
					continue;
				}
				foreach(IEntity2 entity in entitiesToPersist)
				{
					entitiesToSave.Add(entity);
				}
			}

			if(entitiesToSave.Count > 0)
			{
				// Flush waiting audit entities (if any)
				toReturn = SaveEntityCollection(entitiesToSave, false, true);
			}

			return toReturn;
		}


		/// <summary>
		/// Disposes the postponed dispose candidates. Postponed dispose candidates are queries which couldn't be disposed when it was required and are disposed
		/// later on: when the connection is closed or when this adapter is disposed.
		/// </summary>
		private void DisposePostponedDisposeCandidates()
		{
			foreach(IQuery toDispose in _postponedDisposeCandidates)
			{
				toDispose.Dispose();
			}
			_postponedDisposeCandidates.Clear();
		}


		/// <summary>
		/// Determines the number of pk fields for the entity passed in. Normally this is the # of entries in the PK field collection, however in the case of
		/// a subtype of a targetperentity, all PK fields of the supertypes are also present in this collection and therefore this routine has to determine how
		/// many of these fields are really there.
		/// </summary>
		/// <param name="entity">The entity to check the # of PK fields for.</param>
		/// <returns>the # of pk fields</returns>
		private int DetermineNumberOfPkFields(IEntity2 entity)
		{
			ArrayList pkFields = entity.Fields.PrimaryKeyFields;
			return FieldUtilities.DetermineNumberOfPkFields(pkFields);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="comPlusContextHost">Com plus context host.</param>
		/// <param name="persistenceInfoProvider">Persistence info provider.</param>
		private void InitClass(IComPlusAdapterContext comPlusContextHost, IPersistenceInfoProvider persistenceInfoProvider)
		{
			_persistenceInfoProvider = persistenceInfoProvider;
			_transactionIsolationLevel = IsolationLevel.ReadCommitted;

			_transactionName = String.Empty;
			_transactionParticipants = new ArrayList();
			_transactionParticipantObjectIds = new Hashtable();

			_activeConnection = null;
			_connectionString = String.Empty;
			_physicalTransaction = null;
			_isDisposed=false;
			_isTransactionInProgress=false;
			_keepConnectionOpen=false;
			_commandTimeOut = defaultTimeOut;
			_savePointNames = new Hashtable();
			_parameterisedPrefetchPathThreshold = defaultThresholdForPrefetchPaths;
			_postponedDisposeCandidates = new ArrayList();
			_auditorsToNotifyOnCommit = new ArrayList();

#if !CF
			_comPlusContextHost = (ComPlusAdapterContextBase)comPlusContextHost;
#endif
		}


		#region IDisposable
		/// <summary>
		/// Implements the IDispose' method Dispose.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		/// <summary>
		/// Implements the Dispose functionality. If a transaction is in progress, it will rollback that transaction.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose(bool isDisposing)
		{
			// Check to see if Dispose has already been called.
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					// Dispose managed resources.
					if(_physicalTransaction != null)
					{
						if(_isTransactionInProgress)
						{
							Rollback();
						}
						else
						{
#if !CF
							_physicalTransaction.Dispose();
#endif
							_physicalTransaction = null;
						}
					}

					DisposePostponedDisposeCandidates();
					
					if(_activeConnection != null)
					{
						// closing the connection will abort (rollback) any pending transactions
						if(_activeConnection.State == ConnectionState.Open)
						{
							_activeConnection.Close();
						}
#if !CF
						_activeConnection.Dispose();
#endif
						_activeConnection = null;
					}
					_isDisposed = true;
				}
			}
		}
		#endregion


		#region Obsolete methods
		/// <summary>
		/// Creates a new delete DQ for the entity passed in.
		/// </summary>
		/// <param name="persistenceInfoObject">persistence objects for the entity's first field.</param>
		/// <param name="filter">The filter to use in the delete query</param>
		/// <returns>a fully usable IActionQuery object</returns>
		[Obsolete("This method is obsolete, starting with 1.0.2005.1. Upgrade your derived class to utilize the new CreateDeleteDQ routines.", true)]
		protected virtual IActionQuery CreateDeleteDQ(IFieldPersistenceInfo persistenceInfoObject, IPredicateExpression filter) {return null;}
		/// <summary>
		/// Creates a new delete DQ for the entity passed in.
		/// </summary>
		/// <param name="persistenceInfoObject">persistence objects for the entity's first field.</param>
		/// <param name="filter">The filter to use in the delete query</param>
		/// <param name="relationsToWalk">Relations to use walk to fulfill the filter</param>
		/// <returns>a fully usable IActionQuery object</returns>
		[Obsolete("This method is obsolete, starting with 1.0.2005.1. Upgrade your derived class to utilize the new CreateDeleteDQ routines.", true)]
		protected virtual IActionQuery CreateDeleteDQ(IFieldPersistenceInfo persistenceInfoObject, IPredicateExpression filter, 
			IRelationCollection relationsToWalk) {return null;}
		/// <summary>
		/// Creates a new Update DQ for the entity passed in.
		/// </summary>
		/// <param name="entityToSave">the entity to create the Update query for</param>
		/// <param name="persistenceInfoObjects">persistence objects for the entity</param>
		/// <param name="filter">The filter to use in the update query</param>
		/// <returns>a fully usable IActionQuery object</returns>
		[Obsolete("This method is obsolete, starting with 1.0.2005.1. Upgrade your derived class to utilize the new CreateUpdateDQ routines.", true)]
		protected virtual IActionQuery CreateUpdateDQ(IEntity2 entityToSave, IFieldPersistenceInfo[] persistenceInfoObjects, IPredicateExpression filter) {return null;}
		/// <summary>
		/// Creates a new Update DQ for the entity passed in.
		/// </summary>
		/// <param name="entityWithNewValues">the entity to with new values to use for the SET clauses</param>
		/// <param name="persistenceInfoObjects">persistence objects for the fields in entityWithNewValues</param>
		/// <param name="filter">The filter to use in the update query</param>
		/// <param name="relationsToWalk">Relations to walk to fulfill the filter</param>
		/// <returns>a fully usable IActionQuery object</returns>
		[Obsolete("This method is obsolete, starting with 1.0.2005.1. Upgrade your derived class to utilize the new CreateUpdateDQ routines.", true)]
		protected virtual IActionQuery CreateUpdateDQ(IEntity2 entityWithNewValues, IFieldPersistenceInfo[] persistenceInfoObjects, 
			IPredicateExpression filter, IRelationCollection relationsToWalk) { return null;}
		#endregion

		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the parameterised prefetch path threshold. This threshold is used to determine when the prefetch path logic should switch to a 
		/// subquery or when it should use a WHERE field IN (value1, value2, ... valueN) construct, based on the # of elements in the parent collection.
		/// If that # of elements exceeds this threshold, a subquery is constructed, otherwise field IN (value1, value2, ...) construct is used.
		/// The default value is 50. On average, this is faster than using a subquery which returns 50 elements. Use this to tune prefetch path fetch logic
		/// for your particular needs. 
		/// <br/><br/>
		/// This threshold is also used to determine if paging is possible. A page size bigger than this threshold will disable the paging functionality
		/// when using paging + prefetch paths. 
		/// </summary>
		/// <remarks>Testing showed that values larger than 300 will be slower than a subquery.
		/// <br/><br/>
		/// Special thanks to Marcus Mac Innes (http://www.styledesign.biz) for this optimization code. 
		/// </remarks>
		public int ParameterisedPrefetchPathThreshold 
		{ 
			get 
			{ 
				return _parameterisedPrefetchPathThreshold; 
			} 
			set 
			{
				_parameterisedPrefetchPathThreshold = value; 
			} 
		}


		/// <summary>
		/// Gets IsTransactionInProgress. True when there is a transaction in progress.
		/// </summary>
		public bool IsTransactionInProgress
		{
			get
			{
				return _isTransactionInProgress;
			}
		}


		/// <summary>
		/// Gets / sets the isolation level a transaction should use. 
		/// Setting this during a transaction in progress has no effect on the current running transaction.
		/// </summary>
		public virtual IsolationLevel TransactionIsolationLevel
		{
			get
			{
				return _transactionIsolationLevel;
			}
			set
			{
				_transactionIsolationLevel = value;
			}
		}


		/// <summary>
		/// Gets the name of the transaction. Setting this during a transaction in progress has no effect on the current running transaction.
		/// </summary>
		public virtual string TransactionName
		{
			get
			{
				return _transactionName;
			}
			set
			{
				_transactionName = value;
			}
		}


		/// <summary>
		/// Gets / sets the connection string to use for the connection with the database.
		/// </summary>
		public virtual string ConnectionString
		{
			get
			{
				return _connectionString;
			}
			set
			{
				_connectionString = value;
			}
		}


		/// <summary>
		/// Gets / sets KeepConnectionOpen, a flag used to keep open connections after a database action has finished.
		/// </summary>
		public bool KeepConnectionOpen
		{
			get
			{
				return _keepConnectionOpen;
			}
			set
			{
				_keepConnectionOpen = value;
			}
		}


		/// <summary>
		/// The physical transaction object used over the current ActiveConnection.
		/// </summary>
		protected IDbTransaction PhysicalTransaction
		{
			get
			{
				return _physicalTransaction;
			}
		}

		/// <summary>
		/// Gets / sets the timeout value to use with the command object(s) created by the adapter.
		/// Default is 30 seconds
		/// Set this prior to calling a method which executes database logic.
		/// </summary>
		/// <remarks>Setting it to 0 won't have any effect. Set it to a value larger than 0</remarks>
		public int CommandTimeOut 
		{
			get
			{
				return _commandTimeOut;
			}
			set
			{
				_commandTimeOut = value;
			}
		}

		/// <summary>
		/// Returns true if this DataAccessAdapter is hosted inside an IComPlusAdapterContext implementing object.
		/// This means that all transactions by this DataAccessAdapter object are routed through COM+ and not controlled by ADO.NET.
		/// </summary>
		public bool InComPlusTransaction 
		{
#if !CF
			get { return (_comPlusContextHost != null); }
#else
			get{ return false; }
#endif
		}
		#endregion
	}
}
