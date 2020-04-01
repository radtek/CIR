//////////////////////////////////////////////////////////////////////
// Part of the Dynamic Query Engine (DQE) for Access, used in the generated code. 
// LLBLGen Pro specific. Do not modify. 
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
//////////////////////////////////////////////////////////////////////
// The sourcecode for this DQE is released as BSD2 licensed open source, so licensees and others can
// modify, update, extend or use it to write other DQE's. 
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2007 Solutions Design. All rights reserved.
// 
// This DQE is released under the following license: (BSD2)
// -------------------------------------------
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
using System.Data;
using System.Text;
using System.Diagnostics;

using System.Data.OleDb;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DQE.Access
{
	/// <summary>
	/// DynamicQueryEngine for Access.
	/// </summary>
	public class DynamicQueryEngine : DynamicQueryEngineBase
	{
		/// <summary>
		/// Creates a new <see cref="DynamicQueryEngine"/> instance.
		/// </summary>
		public DynamicQueryEngine():base()
		{
		}


		/// <summary>
		/// Static CTor for initializing TraceSwitch
		/// </summary>
		static DynamicQueryEngine()
		{
			DynamicQueryEngine.Switch = new TraceSwitch("AccessDQE", "Tracer for MS Access Dynamic Query Engine");
		}


		#region Dynamic Insert Query construction methods.
		/// <summary>
		/// Creates a new Insert Query object which is ready to use. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the insert query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="fieldToParameter">Hashtable which will contain after the call for each field the parameter which contains or will contain
		/// the field's value.</param>
		/// <returns>IActionQuery Instance which is ready to be used.</returns>
		/// <remarks>Generic version.
		/// </remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		/// <exception cref="ORMQueryConstructionException">When there are no fields to insert in the fields list. This exception is to prevent 
		/// INSERT INTO table () VALUES () style queries.</exception>
		protected override IActionQuery CreateSingleTargetInsertDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
				IDbConnection connectionToUse, ref Hashtable fieldToParameter)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetInsertDQ", "Method Enter");
			IDbCommand command = CreateCommand();
			IActionQuery insertQuery = new ActionQuery(connectionToUse, command);

			StringBuilder queryText = new StringBuilder(InsertQueryBufferLength);
			StringBuilder parametersText = new StringBuilder(InsertQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table inserts, pick the table of the first field.
			queryText.AppendFormat("INSERT INTO {0} (", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			ArrayList outputParameters = new ArrayList();
			OleDbParameter newParameter=null;
			int amountFieldsAdded=0;
			for(int i=0;i<fields.Length;i++)
			{
				IEntityFieldCore field = fields[i];
				IFieldPersistenceInfo persistenceInfo = fieldsPersistenceInfo[i];

				if(persistenceInfo.IsIdentity)
				{
					// Create output parameter.
					OleDbParameter newOutputParameter = (OleDbParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
					outputParameters.Add(newOutputParameter);
					newOutputParameter.Value=0;

					insertQuery.AddParameterFieldRelation(new ParameterFieldRelation(field, newOutputParameter, persistenceInfo.TypeConverterToUse));

					// create SequenceRetrievalQuery
					ISequenceRetrievalQuery sequenceQuery = new SequenceRetrievalQuery();
					sequenceQuery.SequenceRetrievalCommand = CreateCommand();
					sequenceQuery.SequenceRetrievalCommand.Connection = connectionToUse;
					sequenceQuery.ExecuteSequenceCommandFirst = false;
					sequenceQuery.SequenceRetrievalCommand.CommandText = "SELECT @@IDENTITY;";
					sequenceQuery.SequenceParameters.Add(newOutputParameter);
					insertQuery.SequenceRetrievalQueries.Add(sequenceQuery);
					sequenceQuery.SetParametersAsOutputParameters = true;

					fieldToParameter.Add(field, newOutputParameter);
					continue;
				}

				if(!CheckIfFieldNeedsInsertAction(field))
				{
					// doesn't have a value set or is readonly, and is not linked to a supertype field. This means that the field won't recieve a value
					// nor does it has a value set. Assume a default is set in the database or NULL is acceptable., skip field.
					continue;
				}

				// normal field which will be updated.
				if(amountFieldsAdded>0)
				{
					queryText.Append(", ");
				}
				queryText.AppendFormat("{0}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name));

				newParameter = (OleDbParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
				command.Parameters.Add(newParameter);
				if(amountFieldsAdded>0)
				{
					parametersText.Append(", ");
				}
				parametersText.Append(newParameter.ParameterName);
				amountFieldsAdded++;
				fieldToParameter.Add(field, newParameter);
			}

			if(amountFieldsAdded<=0)
			{
				// empty field list, throw exception
				throw new ORMQueryConstructionException("The insert query doesn't contain any fields.");
			}

			for (int i = 0; i < outputParameters.Count; i++)
			{
				command.Parameters.Add(outputParameters[i]);
			}

			// append the rest of the query elements.
			queryText.AppendFormat(") VALUES ({0})", parametersText.ToString());

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, insertQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetInsertDQ", "Method Exit");
			// query is done. 
			return insertQuery;
		}
		#endregion

		#region Dynamic Delete Query construction methods.
		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="deleteFilter">A complete IPredicate implementing object which contains the filter for the rows to delete</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null</exception>
		protected override IActionQuery CreateSingleTargetDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, IDbConnection connectionToUse, IPredicate deleteFilter)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetDeleteDQ(3)", "Method Enter");

			IDbCommand command = CreateCommand();
			IActionQuery deleteQuery = new ActionQuery(connectionToUse, command);
			StringBuilder queryText = new StringBuilder(DeleteQueryBufferLength);

			queryText.AppendFormat("DELETE FROM {0}", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			if(deleteFilter!=null)
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", deleteFilter.ToQueryText(ref this.UniqueMarker));

				for(int i=0;i<deleteFilter.Parameters.Count;i++)
				{
					command.Parameters.Add (deleteFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, deleteQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetDeleteDQ(3)", "Method Exit");
			// query is done. 
			return deleteQuery;
		}


		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="deleteFilter">A complete IPredicate implementing object which contains the filter for the rows to delete</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a second FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null or when deleteFilter is null or when relationsToWalk is null</exception>
		protected override IActionQuery CreateSingleTargetDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, IDbConnection connectionToUse, IPredicate deleteFilter, IRelationCollection relationsToWalk)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetDeleteDQ(4)", "Method Enter");

			IDbCommand command = CreateCommand();
			IActionQuery deleteQuery = new ActionQuery(connectionToUse, command);
			StringBuilder queryText = new StringBuilder(DeleteQueryBufferLength);
			if(relationsToWalk!=null)
			{
				relationsToWalk.DatabaseSpecificCreator = base.Creator;
			}

			string deleteTable = base.Creator.CreateObjectName(fieldsPersistenceInfo[0]);
			string deleteTableAlias = "[ALIAS__" + fieldsPersistenceInfo[0].SourceObjectName.Replace(" ", "_") + "__ALIAS]";

			queryText.AppendFormat("DELETE FROM {0} {1} WHERE EXISTS ( SELECT * FROM {2} WHERE {3}", 
				deleteTable, deleteTableAlias, relationsToWalk.ToQueryText(ref this.UniqueMarker),
				CreateSubqueryConnectionClausesDelete(deleteTable, deleteTableAlias, (RelationCollection)relationsToWalk));
			if(deleteFilter!=null)
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" AND {0}", deleteFilter.ToQueryText(ref this.UniqueMarker));
				for(int i=0;i<deleteFilter.Parameters.Count;i++)
				{
					command.Parameters.Add(deleteFilter.Parameters[i]);
				}
			}
			queryText.Append(")");

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			for(int i=0;i<((RelationCollection)relationsToWalk).CustomFilterParameters.Count;i++)
			{
				command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
			}

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, deleteQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetDeleteDQ(4)", "Method Exit");
			// query is done. 
			return deleteQuery;
		}
		#endregion

		#region Dynamic Update Query construction methods.
		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore fields are included in the update query. 
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">EntityFieldCore array to use to build the update query.</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="updateFilter">A complete IPredicate implementing object which contains the filter for the rows to update</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected override IActionQuery CreateSingleTargetUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
							IDbConnection connectionToUse, IPredicate updateFilter)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetUpdateDQ(4)", "Method Enter");

			ArrayList fieldsToUpdate = new ArrayList();
			ArrayList persistenceInfoFieldsToUpdate = new ArrayList();
			ConstructFieldsToUpdateList(fields, fieldsPersistenceInfo, ref fieldsToUpdate, ref persistenceInfoFieldsToUpdate);

			IDbCommand command = CreateCommand();
			IActionQuery updateQuery = new ActionQuery(connectionToUse, command);

			if(fieldsToUpdate.Count <=0)
			{
				// no fields to update. return empty query
				command.CommandText="";
				return updateQuery;
			}

			StringBuilder queryText = new StringBuilder(UpdateQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table updates, pick the table of the first field.
			queryText.AppendFormat("UPDATE {0} SET ", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			OleDbParameter newParameter=null;
			for(int i=0;i<fieldsToUpdate.Count;i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];

				if(i>0)
				{
					queryText.Append(",");
				}

				if(field.ExpressionToApply==null)
				{
					// normal field which will be updated.
					newParameter = (OleDbParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
					command.Parameters.Add(newParameter);
					queryText.AppendFormat("{0}={1}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name), newParameter.ParameterName);
				}
				else
				{
					field.ExpressionToApply.DatabaseSpecificCreator = base.Creator;
					queryText.AppendFormat("{0}={1}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name), field.ExpressionToApply.ToQueryText(ref this.UniqueMarker));
					for (int j = 0; j < field.ExpressionToApply.Parameters.Count; j++)
					{
						command.Parameters.Add(field.ExpressionToApply.Parameters[j]);
					}
				}
			}

			if(updateFilter!=null)
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", updateFilter.ToQueryText(ref this.UniqueMarker));

				for(int i=0;i<updateFilter.Parameters.Count;i++)
				{
					command.Parameters.Add(updateFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, updateQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetUpdateDQ(4)", "Method Exit");
			// query is done. 
			return updateQuery;
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore are included in the update query.
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="updateFilter">A complete IPredicate implementing object which contains the filter for the rows to update</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or when updateFilter is null or 
		/// when relationsToWalk is null or when fieldsPersistence is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected override IActionQuery CreateSingleTargetUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
						IDbConnection connectionToUse, IPredicate updateFilter, IRelationCollection relationsToWalk)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetUpdateDQ(5)", "Method Enter");

			ArrayList fieldsToUpdate = new ArrayList();
			ArrayList persistenceInfoFieldsToUpdate = new ArrayList();
			ConstructFieldsToUpdateList(fields, fieldsPersistenceInfo, ref fieldsToUpdate, ref persistenceInfoFieldsToUpdate);

			IDbCommand command = CreateCommand();
			IActionQuery updateQuery = new ActionQuery(connectionToUse, command);

			if(fieldsToUpdate.Count <=0)
			{
				// no fields to update. return empty query
				command.CommandText="";
				return updateQuery;
			}

			StringBuilder queryText = new StringBuilder(UpdateQueryBufferLength);

			// the updated table receives an alias for tying the subquery with the where clauses to this table.
			string updatedTable = base.Creator.CreateObjectName((IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[0]);
			string updatedTableAlias = "[ALIAS__" + ((IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[0]).SourceObjectName.Replace(" ", "_") + "__ALIAS]";

			// walk all EntityField instances in fields. We only support single table updates.
			queryText.AppendFormat("UPDATE {0} {1} SET ", updatedTable, updatedTableAlias);

			OleDbParameter newParameter=null;
			ArrayList updateParameters = new ArrayList();
			for(int i=0;i<fieldsToUpdate.Count;i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];

				if(i>0)
				{
					queryText.Append(",");
				}

				if(field.ExpressionToApply==null)
				{
					// normal field which will be updated.
					newParameter = (OleDbParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
					updateParameters.Add(newParameter);
					queryText.AppendFormat("{0}={1}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name), newParameter.ParameterName);
				}
				else
				{
					field.ExpressionToApply.DatabaseSpecificCreator = base.Creator;
					queryText.AppendFormat("{0}={1}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name), field.ExpressionToApply.ToQueryText(ref this.UniqueMarker));
					for (int j = 0; j < field.ExpressionToApply.Parameters.Count; j++)
					{
						command.Parameters.Add(field.ExpressionToApply.Parameters[j]);
					}
				}
			}

			relationsToWalk.DatabaseSpecificCreator=base.Creator;
			queryText.AppendFormat(" WHERE EXISTS (SELECT * FROM {0} WHERE {1}", 
					relationsToWalk.ToQueryText(ref this.UniqueMarker), 
					CreateSubqueryConnectionClausesUpdate(((IEntityFieldCore)fieldsToUpdate[0]).ContainingObjectName, updatedTableAlias, (RelationCollection)relationsToWalk));
			if(updateFilter!=null)
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" AND {0}", updateFilter.ToQueryText(ref this.UniqueMarker));
				for(int i=0;i<updateFilter.Parameters.Count;i++)
				{
					command.Parameters.Add(updateFilter.Parameters[i]);
				}
			}
			queryText.Append(")");

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			for(int i=0;i<((RelationCollection)relationsToWalk).CustomFilterParameters.Count;i++)
			{
				command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
			}
			// add the update parameters last, as access' JET engine will otherwise get confused.
			for(int i=0;i<updateParameters.Count;i++)
			{
				command.Parameters.Add(updateParameters[i]);
			}

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, updateQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetUpdateDQ(5)", "Method Exit");
			// query is done. 
			return updateQuery;
		}
		#endregion

		#region Dynamic Select Query construction methods.
		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="relationsSpecified">flag to signal if relations are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <param name="sortClausesSpecified">flag to signal if sortClauses are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected override IRetrievalQuery CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
				IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
				IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause,
				bool relationsSpecified, bool sortClausesSpecified)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSelectDQ", "Method Enter");

			IDbCommand command = CreateCommand();
			IRetrievalQuery selectQuery = new RetrievalQuery(connectionToUse, command);
			if(relationsSpecified)
			{
				// set base.Creator so alias set can be produced
				relationsToWalk.DatabaseSpecificCreator = base.Creator;
			}

			StringBuilder queryText = new StringBuilder(SelectJoinQueryBufferLength);
			StringBuilder resultsetText = new StringBuilder(SelectResultSetBufferLength);

			bool distinctViolatingTypesFound = false;
			Hashtable fieldNamesInSelectList = null;
			if(sortClausesSpecified)
			{
				fieldNamesInSelectList = new Hashtable(selectList.Length);
			}
			for(int i=0;i<selectList.Length;i++)
			{
				if(i>0)
				{
					resultsetText.Append(", ");
				}
				string fieldName = base.Creator.CreateFieldName(selectList[i], fieldsPersistenceInfo[i], selectList[i].Alias, selectList[i].ObjectAlias, ref this.UniqueMarker, true);
				resultsetText.Append(fieldName);
				if((fieldsPersistenceInfo[i].SourceColumnName!=selectList[i].Alias)||
					(selectList[i].ExpressionToApply!=null)||
					(selectList[i].AggregateFunctionToApply!=AggregateFunction.None))
				{
					resultsetText.AppendFormat(" AS [{0}]", selectList[i].Alias);
				}
				if(sortClausesSpecified)
				{
					// we have to test the order by clauses for presence in the select list. store select list elements in hashtable.
					if((selectList[i].ExpressionToApply!=null)||(selectList[i].AggregateFunctionToApply != AggregateFunction.None))
					{
						// add as alias
						if(!fieldNamesInSelectList.ContainsKey(selectList[i].Alias))
						{
							fieldNamesInSelectList.Add(selectList[i].Alias, null);
						}
					}
					else
					{
						// add with complete field name
						if(!fieldNamesInSelectList.ContainsKey(fieldName))
						{
							fieldNamesInSelectList.Add(fieldName, null);
						}
					}
				}
				if(selectList[i].ExpressionToApply!=null)
				{
					// append parameters
					for(int j = 0; j < selectList[i].ExpressionToApply.Parameters.Count; j++)
					{
						command.Parameters.Add(selectList[i].ExpressionToApply.Parameters[j]);
					}
				}

				if(!allowDuplicates)
				{
					distinctViolatingTypesFound |= (((OleDbType)fieldsPersistenceInfo[i].SourceColumnDbType == OleDbType.LongVarWChar) ||
						((OleDbType)fieldsPersistenceInfo[i].SourceColumnDbType == OleDbType.LongVarBinary));
				}
			}

			queryText.Append("SELECT");

			bool distinctEmitted = false;
			if(!allowDuplicates && !distinctViolatingTypesFound)
			{
				bool emitDistinct = true;
				if(sortClausesSpecified)
				{
					// check if the sortclause fields are in the selectlist.
					emitDistinct = CheckIfSortClausesAreInSelectList(fieldNamesInSelectList, sortClauses);
				}
				if(emitDistinct)
				{
					queryText.Append(" DISTINCT");
					distinctEmitted = true;
				}
			}
			selectQuery.RequiresClientSideDistinctFiltering = (!allowDuplicates && !distinctEmitted);

			if(maxNumberOfItemsToReturn > 0)
			{
				// only emit TOP if DISTINCT is emitted as well or when there are no relations or when the limit is 1 as duplicates don't hurt a limit of 1,
				// otherwise set the flag in the RetrievalQuery object for manual limitation.
				if(distinctEmitted || !relationsSpecified || (maxNumberOfItemsToReturn==1))
				{
					queryText.AppendFormat(" TOP {0}", maxNumberOfItemsToReturn);
				}
				else
				{
					selectQuery.RequiresClientSideLimitation=true;
					selectQuery.MaxNumberOfItemsToReturnClientSide = maxNumberOfItemsToReturn;
				}
			}

			queryText.AppendFormat(" {0}", resultsetText.ToString());

			if(relationsSpecified)
			{
				queryText.Append(" FROM ");
				// build join list.
				queryText.Append(relationsToWalk.ToQueryText(ref this.UniqueMarker));
				for(int i=0;i<((RelationCollection)relationsToWalk).CustomFilterParameters.Count;i++)
				{
					command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
				}
			}
			else
			{
				if(fieldsPersistenceInfo[0].SourceObjectName.Length > 0)
				{
					queryText.AppendFormat(" FROM {0}", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));
					if(selectList[0].ObjectAlias != string.Empty)
					{
						queryText.AppendFormat(" AS [{0}]", selectList[0].ObjectAlias);
					}
				}
			}

			// build where clause
			if(selectFilter!=null)
			{
				// append where clause
				selectFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", selectFilter.ToQueryText(ref this.UniqueMarker));

				for(int i=0;i<selectFilter.Parameters.Count;i++)
				{
					command.Parameters.Add(selectFilter.Parameters[i]);
				}
			}

			if(groupByClause!=null)
			{
				AppendGroupByClause(queryText, groupByClause, command);
			}

			if(sortClausesSpecified)
			{
				AppendOrderByClause(queryText, sortClauses, command);
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, selectQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSelectDQ", "Method Exit");
			// query is done. 
			return selectQuery;
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="pageNumber">the page number to retrieve. First page starts with 1. If set to 0 or lower, no paging logic is applied</param>
		/// <param name="pageSize">the page size to retrieve. If set to 0 no paging logic is applied.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null or relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected override IRetrievalQuery CreatePagingSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
			IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ", "Method Enter");

			// On access paging is always client side.
			long max = 0;
			bool pagingRequired = true;
			if((pageSize < 1)||(pageNumber<1))
			{
				// no paging.
				pagingRequired = false;
				max = maxNumberOfItemsToReturn;
			}
			
			// As MS Access evaluates inner subqueries first, it requires that parameters in these queries are defined first as well. We therefore need to
			// track the parameters per scope so we can sort them later on.
			AccessSpecificCreator creator = base.Creator as AccessSpecificCreator;
			if(creator != null)
			{
				creator.EnableParameterPerScopeTracking = true;
			}

			IRetrievalQuery normalQuery = this.CreateSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter, max, sortClauses, relationsToWalk, allowDuplicates, groupByClause);
			normalQuery.ManualPageNumber = pageNumber;
			normalQuery.ManualPageSize = pageSize;
			normalQuery.RequiresClientSidePaging = pagingRequired;

			if(creator != null)
			{
				// sort the parameters by scope. Access first executes inner subqueries and parameters of these queries have to be placed first in the query.
				// this is guaranteed by sorting per scope, as subqueries are created using a new scope. 
				SortParameters(normalQuery);

				// done tracking, switch it off.
				creator.EnableParameterPerScopeTracking = false;
			}
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ", "Method Exit");
			return normalQuery;
		}
		#endregion

		/// <summary>
		/// Creates the exception info retriever for this DQE
		/// </summary>
		/// <returns>
		/// the db specific exception info retriever object.
		/// </returns>
		protected override ExceptionInfoRetrieverBase CreateExceptionInfoRetriever()
		{
			return new AccessSpecificExceptionInfoRetriever();
		}

		/// <summary>
		/// Creates a new IDbCommand object and initializes it
		/// </summary>
		/// <returns>ready to use IDbCommand object</returns>
		protected override IDbCommand CreateCommand()
		{
			IDbCommand toReturn = new OleDbCommand();
			toReturn.CommandTimeout = DynamicQueryEngine.CommandTimeOut;
			return toReturn;
		}

		
		/// <summary>
		/// Creates a new IDbSpecificCreator and initializes it
		/// </summary>
		/// <returns></returns>
		protected override IDbSpecificCreator CreateDbSpecificCreator()
		{
			return new AccessSpecificCreator();
		}

		

		/// <summary>
		/// Sorts the parameters per scope.
		/// </summary>
		/// <param name="query">The query.</param>
		private void SortParameters(IRetrievalQuery query)
		{
			AccessSpecificCreator creator = base.Creator as AccessSpecificCreator;
			if(creator == null)
			{
				return;
			}

			SortedList parametersPerScope = creator.ParametersPerScope;
			if(parametersPerScope.Keys.Count <= 1)
			{
				// nothing to sort, just 1 or 0 scopes
				return;
			}

			// multiple scopes. handle parameters from back to front. 
			ArrayList parametersInCommand = new ArrayList(query.Command.Parameters);
			query.Command.Parameters.Clear();
			for(int i = parametersPerScope.Count-1; i >=0 ; i--)
			{
				ArrayList parameters = (ArrayList)parametersPerScope[i];
				foreach(IDataParameter parameter in parameters)
				{
					if(parametersInCommand.Contains(parameter))
					{
						query.Command.Parameters.Add(parameter);
					}
				}
			}
		}
	}
}
