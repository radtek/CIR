//////////////////////////////////////////////////////////////////////
// Part of the Dynamic Query Engine (DQE) for Sybase ASA, used in the generated code. 
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
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Configuration;

using SD.LLBLGen.Pro.ORMSupportClasses;
using iAnywhere.Data.SQLAnywhere;
using System.Collections;

namespace SD.LLBLGen.Pro.DQE.SybaseAsa
{
	/// <summary>
	/// DynamicQueryEngine for SybaseAsa.
	/// </summary>
	public class DynamicQueryEngine : DynamicQueryEngineBase
	{
		#region Static members
		private static Dictionary<string, string>	_schemaOverwrites;
		private static Regex _procMatchingMatcher = new Regex(@"(?<schemaName>\[[\w\. \$@#]+\]|\w+).(?<procName>\[[\w\. \$@#]+\])", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
		#endregion

		/// <summary>
		/// Creates a new <see cref="DynamicQueryEngine"/> instance.
		/// </summary>
		public DynamicQueryEngine():base()
		{
		}

		/// <summary>
		/// Static CTor for initializing TraceSwitch and name overwrites
		/// </summary>
		static DynamicQueryEngine()
		{
			DynamicQueryEngine.Switch = new TraceSwitch("SybaseAsaDQE", "Tracer for Sybase ASA Dynamic Query Engine");

			// load and initialize schema / catalog overwrites
			_schemaOverwrites = new Dictionary<string, string>();

			NameValueCollection schemaOverwriteDefinitions = (NameValueCollection)ConfigurationManager.GetSection("sybaseAsaSchemaNameOverwrites");
			if(schemaOverwriteDefinitions!=null)
			{
				for(int i=0;i<schemaOverwriteDefinitions.Count;i++)
				{
					string key = schemaOverwriteDefinitions.GetKey(i);
					string value = schemaOverwriteDefinitions.Get(i);
					if(_schemaOverwrites.ContainsKey(key))
					{
						continue;
					}
					_schemaOverwrites.Add(key, value);
				}
			}
		}

		#region Dynamic Insert Query construction methods.
		/// <summary>
		/// Creates a new Insert Query object which is ready to use. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the insert query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="fieldToParameter">Hashtable which will contain after the call for each field the parameter which contains or will contain the field's value.</param>
		/// <returns>IActionQuery Instance which is ready to be used.</returns>
		/// <remarks>Generic version.</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		/// <exception cref="ORMQueryConstructionException">When there are no fields to insert in the fields list. This exception is to prevent 
		/// INSERT INTO table () VALUES () style queries.</exception>
		protected override IActionQuery CreateSingleTargetInsertDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo,
				IDbConnection connectionToUse, ref Dictionary<IEntityFieldCore, IDataParameter> fieldToParameter )
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetInsertDQ", "Method Enter");
			IDbCommand command = CreateCommand();
			IActionQuery insertQuery = new ActionQuery(connectionToUse, command);

			StringBuilder queryText = new StringBuilder(InsertQueryBufferLength);
			StringBuilder parametersText = new StringBuilder(InsertQueryBufferLength);
			StringBuilder outputRetrievalQueryText = new StringBuilder(InsertQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table inserts, pick the table of the first field.
			queryText.AppendFormat("INSERT INTO {0} (", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			SAParameter newParameter = null;
			int amountFieldsAdded = 0;
			bool hasIdentity = false;
			string outputNewSequentialIdStatement = string.Empty;
			for(int i = 0; i < fields.Length; i++)
			{
				IEntityFieldCore field = fields[i];
				IFieldPersistenceInfo persistenceInfo = fieldsPersistenceInfo[i];

				if(persistenceInfo.IsIdentity)
				{
					// Create output parameter.
					newParameter = (SAParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.InputOutput);
					insertQuery.AddParameterFieldRelation(new ParameterFieldRelation(field, newParameter, persistenceInfo.TypeConverterToUse));
					hasIdentity = true;

					// create SequenceRetrievalQuery
					ISequenceRetrievalQuery sequenceQuery = new SequenceRetrievalQuery();
					sequenceQuery.SequenceRetrievalCommand = CreateCommand();
					sequenceQuery.SequenceRetrievalCommand.Connection = connectionToUse;
					sequenceQuery.ExecuteSequenceCommandFirst = false;
					sequenceQuery.SequenceRetrievalCommand.CommandText = "SELECT @@IDENTITY";
					sequenceQuery.SequenceParameters.Add(newParameter);
					insertQuery.SequenceRetrievalQueries.Add(sequenceQuery);

					fieldToParameter.Add(field, newParameter);
					continue;
				}

				if(!CheckIfFieldNeedsInsertAction(field))
				{
					// doesn't have a value set or is readonly, and is not linked to a supertype field. This means that the field won't recieve a value
					// nor does it has a value set. Assume a default is set in the database or NULL is acceptable., skip field.
					continue;
				}

				// normal field which will be updated.
				if(amountFieldsAdded > 0)
				{
					queryText.Append(", ");
				}
				queryText.AppendFormat("{0}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name));

				// add parameter
				newParameter = (SAParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
				command.Parameters.Add(newParameter);
				if(amountFieldsAdded > 0)
				{
					parametersText.Append(", ");
				}
				parametersText.Append(newParameter.ParameterName);
				amountFieldsAdded++;
				fieldToParameter.Add(field, newParameter);
			}

			if(amountFieldsAdded<=0)
			{
				if(hasIdentity)
				{
					// a table with just 1 identity field, use a special case query: INSERT INTO table values ()
					queryText = new StringBuilder("INSERT INTO ");
					queryText.AppendFormat("{0} VALUES()", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));
				}
				else
				{
					// empty field list, throw exception
					throw new ORMQueryConstructionException("The insert query doesn't contain any fields.");
				}
			}
			else
			{
				// append the rest of the query elements.
				queryText.AppendFormat(") {0} VALUES ({1}){2}", outputNewSequentialIdStatement, parametersText.ToString(), outputRetrievalQueryText.ToString());
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;
			MakeParametersAnonymous(command);

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

			if(deleteFilter != null)
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", deleteFilter.ToQueryText(ref this.UniqueMarker));

				for(int i = 0; i < deleteFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(deleteFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;
			MakeParametersAnonymous(command);

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

			queryText.AppendFormat("DELETE FROM {0} FROM {1}", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]), 
					relationsToWalk.ToQueryText(ref this.UniqueMarker));
			if(deleteFilter!=null)
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", deleteFilter.ToQueryText(ref this.UniqueMarker));
				for(int i = 0; i < deleteFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(deleteFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			for(int i = 0; i < ((RelationCollection)relationsToWalk).CustomFilterParameters.Count; i++)
			{
				command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
			}

			MakeParametersAnonymous(command);

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

			List<IEntityFieldCore> fieldsToUpdate = new List<IEntityFieldCore>();
			List<IFieldPersistenceInfo> persistenceInfoFieldsToUpdate = new List<IFieldPersistenceInfo>();
			ConstructFieldsToUpdateList(fields, fieldsPersistenceInfo, ref fieldsToUpdate, ref persistenceInfoFieldsToUpdate);

			IDbCommand command = CreateCommand();
			IActionQuery updateQuery = new ActionQuery(connectionToUse, command);

			if(fieldsToUpdate.Count <= 0)
			{
				// no fields to update. return empty query
				command.CommandText = "";
				return updateQuery;
			}

			StringBuilder queryText = new StringBuilder(UpdateQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table updates, pick the table of the first field.
			queryText.AppendFormat("UPDATE {0} SET ", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			SAParameter newParameter = null;
			for(int i = 0; i < fieldsToUpdate.Count; i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];

				if(i > 0)
				{
					queryText.Append(",");
				}

				if(field.ExpressionToApply==null)
				{
					// normal field which will be updated.
					newParameter = (SAParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
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

			if(updateFilter != null)
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", updateFilter.ToQueryText(ref this.UniqueMarker));

				for(int i = 0; i < updateFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(updateFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;
			MakeParametersAnonymous(command);

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

			List<IEntityFieldCore> fieldsToUpdate = new List<IEntityFieldCore>();
			List<IFieldPersistenceInfo> persistenceInfoFieldsToUpdate = new List<IFieldPersistenceInfo>();
			ConstructFieldsToUpdateList(fields, fieldsPersistenceInfo, ref fieldsToUpdate, ref persistenceInfoFieldsToUpdate);

			IDbCommand command = CreateCommand();
			IActionQuery updateQuery = new ActionQuery(connectionToUse, command);

			if(fieldsToUpdate.Count <= 0)
			{
				// no fields to update. return empty query
				command.CommandText = "";
				return updateQuery;
			}

			StringBuilder queryText = new StringBuilder(UpdateQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table updates, pick the table of the first field.
			queryText.AppendFormat("UPDATE {0} SET ", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			SAParameter newParameter = null;
			for(int i = 0; i < fieldsToUpdate.Count; i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];
				if(i > 0)
				{
					queryText.Append(",");
				}

				if(field.ExpressionToApply==null)
				{
					// normal field which will be updated.
					newParameter = (SAParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
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

			relationsToWalk.DatabaseSpecificCreator = base.Creator;
			queryText.AppendFormat(" FROM {0}", relationsToWalk.ToQueryText(ref this.UniqueMarker));
			if(updateFilter!=null)
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", updateFilter.ToQueryText(ref this.UniqueMarker));
				for(int i = 0; i < updateFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(updateFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			for(int i = 0; i < ((RelationCollection)relationsToWalk).CustomFilterParameters.Count; i++)
			{
				command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
			}

			MakeParametersAnonymous(command);

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

			// first create the resultset text. During the loop, check if there are fields of type ntext, text or image. if so, we will
			// have to create another query if duplicates are not allowed.
			bool distinctViolatingTypesFound = false;
			Dictionary<string, object> fieldNamesInSelectList = null;
			if(sortClausesSpecified && !allowDuplicates)
			{
				fieldNamesInSelectList = new Dictionary<string, object>( selectList.Length );
			}

			for(int i = 0; i < selectList.Length; i++)
			{
				if(i > 0)
				{
					resultsetText.Append(", ");
				}
				string fieldName = base.Creator.CreateFieldName(selectList[i], fieldsPersistenceInfo[i], selectList[i].Alias, selectList[i].ObjectAlias, ref this.UniqueMarker, true);
				resultsetText.Append(fieldName);
				if(((fieldsPersistenceInfo[i].SourceColumnName!=selectList[i].Alias)||
					(selectList[i].ExpressionToApply!=null)||
					(selectList[i].AggregateFunctionToApply != AggregateFunction.None)) &&
					!((SybaseAsaSpecificCreator)base.Creator).CreatingSubQuery)
				{
					resultsetText.AppendFormat(" AS {0}", selectList[i].Alias);
				}

				if(sortClausesSpecified && !allowDuplicates)
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
				for(int i = 0; i < ((RelationCollection)relationsToWalk).CustomFilterParameters.Count; i++)
				{
					command.Parameters.Add(((RelationCollection)relationsToWalk).CustomFilterParameters[i]);
				}
			}
			else
			{
				if(fieldsPersistenceInfo[0].SourceObjectName.Length > 0)
				{
					// target object specified
					queryText.AppendFormat(" FROM {0}", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));
					if(selectList[0].ObjectAlias != string.Empty)
					{
						queryText.AppendFormat(" AS {0}", base.Creator.CreateValidAlias(selectList[0].ObjectAlias));
					}
				}
			}

			// build where clause
			if(selectFilter != null)
			{
				// append where clause
				selectFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", selectFilter.ToQueryText(ref this.UniqueMarker));

				for(int i = 0; i < selectFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(selectFilter.Parameters[i]);
				}
			}

			if(groupByClause != null)
			{
				AppendGroupByClause(queryText, groupByClause, command);
			}

			if(sortClausesSpecified)
			{
				AppendOrderByClause(queryText, sortClauses, command);
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			MakeParametersAnonymous(command);

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

			long max = 0;
			bool pagingRequired = true;
			if((pageSize < 1)||(pageNumber<1))
			{
				// no paging.
				max = maxNumberOfItemsToReturn;
				pagingRequired = false;
			}

			IRetrievalQuery normalQuery = this.CreateSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter, max, sortClauses, relationsToWalk, allowDuplicates, groupByClause);
			if((pageSize < 1)||(pageNumber<1))
			{
				TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ: no paging.", "Method Exit");
				return normalQuery;
			}

			if(normalQuery.RequiresClientSideDistinctFiltering)
			{
				// manual paging required
				normalQuery.RequiresClientSidePaging=pagingRequired;
				normalQuery.ManualPageNumber = pageNumber;
				normalQuery.ManualPageSize = pageSize;
			}
			else
			{
				// normal paging. Embed paging logic. There is no TOP statement in the query as we've passed '0' for maxAmountOfItemsToReturn
				normalQuery.Command.CommandText = String.Format("SELECT TOP {0} START AT {1} {2}",
					pageSize, ((pageNumber - 1) * pageSize) + 1, normalQuery.Command.CommandText.Substring(6));
			}

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, normalQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ", "Method Exit");
			return normalQuery;
		}
		#endregion

		#region Name overwrite access methods
	
		/// <summary>
		/// Gets the new name for the schema, given the current name. If the current name is not found in the list of schema name overwrites, 
		/// the current name is returned. This routine works on the schema names specified in the config file.
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <returns>New name for the schema which name was passed in.</returns>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		public static string GetNewSchemaName(string currentName)
		{
			string toMatch = currentName;
			if(currentName.StartsWith("["))
			{
				toMatch = currentName.Substring(1, currentName.Length-2);
			}
			string toReturn = currentName;

			if((_schemaOverwrites.Count>0)&&(_schemaOverwrites.ContainsKey(toMatch)))
			{
				toReturn = (string)_schemaOverwrites[toMatch];
			}

			return toReturn;
		}


		/// <summary>
		/// Gets the new name of the stored procedure passed in. Overwrites schema and catalog name with a new name if these names
		/// have been defined for overwriting. This routine works on the catalog and schema names specified in the config file.
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public static string GetNewStoredProcedureName(string currentName)
		{
			string toReturn = currentName;
			Regex procNamePartFinder = DynamicQueryEngine._procMatchingMatcher;

			MatchCollection matchesFound = procNamePartFinder.Matches(currentName);

			if(matchesFound.Count<=0)
			{
				// just the proc name, or some weird format we don't support, return the proc name
				return currentName;
			}

			// there's just 1 match:
			string schemaName = matchesFound[0].Groups["schemaName"].Value;
			string procName = matchesFound[0].Groups["procName"].Value;
			
			return GetNewSchemaName(schemaName) + "." + procName;
		}


		/// <summary>
		/// Gets the new name of the stored procedure passed in. Overwrites schema and catalog name with a new name if these names
		/// have been defined for overwriting.  This routine works on the PerCallCatalogNameOverwrites and PerCallSchemaNameOverwrites names specified on this instance
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public string GetNewPerCallStoredProcedureName(string currentName)
		{
			string toReturn = currentName;
			Regex procNamePartFinder = DynamicQueryEngine._procMatchingMatcher;
			MatchCollection matchesFound = procNamePartFinder.Matches(currentName);

			if(matchesFound.Count<=0)
			{
				// just the proc name, or some weird format we don't support, return the proc name
				return currentName;
			}

			// there's just 1 match:
			string schemaName = matchesFound[0].Groups["schemaName"].Value;
			string procName = matchesFound[0].Groups["procName"].Value;
			
			return ((DbSpecificCreatorBase)base.Creator).GetNewPerCallSchemaName(schemaName) + "." + procName;
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
			return new SybaseAsaSpecificExceptionInfoRetriever();
		}

		/// <summary>
		/// Creates a new IDbCommand object and initializes it
		/// </summary>
		/// <returns>ready to use IDbCommand object</returns>
		protected override IDbCommand CreateCommand()
		{
			IDbCommand toReturn = new SACommand();
			toReturn.CommandTimeout = DynamicQueryEngine.CommandTimeOut;

			return toReturn;
		}


		/// <summary>
		/// Creates a new IDbSpecificCreator and initializes it
		/// </summary>
		/// <returns></returns>
		protected override IDbSpecificCreator CreateDbSpecificCreator()
		{
			return new SybaseAsaSpecificCreator();
		}


		/// <summary>
		/// Makes the parameters anonymous in the passed in query. An anonymous parameter is '?', not '@foo'. It walks all parameters and replaces the
		/// names of these parameters with "?" in the query text as Sybase ASA doesn't support named parameters
		/// </summary>
		/// <param name="command">The command.</param>
		private void MakeParametersAnonymous(IDbCommand command)
		{
			StringBuilder newQuery = new StringBuilder(command.CommandText, command.CommandText.Length);

			// sort the parameter names and start with the longest name. this assures no overlapping parameter names are replaced by a shorter one. 
			ArrayList sorter = new ArrayList(command.Parameters.Count);
			foreach(IDataParameter parameter in command.Parameters)
			{
				sorter.Add(parameter.ParameterName);
			}
			sorter.Sort(new CaseInsensitiveComparer());

			// sorter is now sorted ascending, so traverse sorter from back to front.
			for(int i = sorter.Count - 1; i >= 0; i--)
			{
				newQuery.Replace((string)sorter[i], "?");
			}

			command.CommandText = newQuery.ToString();
		}
	}
}