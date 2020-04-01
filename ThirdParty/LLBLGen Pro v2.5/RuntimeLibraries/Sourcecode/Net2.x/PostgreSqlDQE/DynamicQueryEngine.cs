//////////////////////////////////////////////////////////////////////
// Part of the Dynamic Query Engine (DQE) for PostgreSql, used in the generated code. 
// LLBLGen Pro specific. Do not modify. 
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
//////////////////////////////////////////////////////////////////////
// The sourcecode for this DQE is released as BSD2 licensed open source, so licensees and others can
// modify, update, extend or use it to write other DQE's. Do NOT, under any circumstance, change the
// INTERFACE of the DQE. Each DQE has to implement the same methods to make it work with LLBLGen Pro's
// generated code. Because the methods are static, no interface definition is possible however.
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
//      - Carlos Guzman Alvarez
//////////////////////////////////////////////////////////////////////
using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.DQE.PostgreSql
{
	/// <summary>
	/// DynamicQueryEngine for PostgreSql.
	/// </summary>
	public class DynamicQueryEngine : DynamicQueryEngineBase
	{
		#region Static members
		private static Hashtable _schemaOverwrites;
		#endregion

        /// <summary>
        /// Static CTor for initializing TraceSwitch
        /// </summary>
        static DynamicQueryEngine()
        {
            DynamicQueryEngine.Switch = new TraceSwitch("PostgreSqlDQE", "Tracer for PostgreSql Dynamic Query Engine");

            // load and initialize schema overwrites
            _schemaOverwrites = new Hashtable();
			NameValueCollection schemaOverwriteDefinitions = (NameValueCollection)ConfigurationManager.GetSection( "postgreSqlSchemaNameOverwrites" );
            if (schemaOverwriteDefinitions != null)
            {
                for (int i = 0; i < schemaOverwriteDefinitions.Count; i++)
                {
                    string key = schemaOverwriteDefinitions.GetKey(i);
                    string value = schemaOverwriteDefinitions.Get(i);
                    if (_schemaOverwrites.ContainsKey(key))
                    {
                        continue;
                    }
                    _schemaOverwrites.Add(key, value);
                }
            }
        }

        /// <summary>
		/// Initializes a new instance of the <see cref="DynamicQueryEngine"/> class.
		/// </summary>
		public DynamicQueryEngine()
            : base()
		{
        }


        /// <summary>
        /// Creates a new IDbCommand object and initializes it
        /// </summary>
        /// <returns>ready to use IDbCommand object</returns>
        protected override IDbCommand CreateCommand()
        {
            IDbCommand toReturn = new NpgsqlCommand();
            toReturn.CommandTimeout = DynamicQueryEngine.CommandTimeOut;

            return toReturn;
        }

        /// <summary>
        /// Creates a new IDbSpecificCreator and initializes it
        /// </summary>
        /// <returns></returns>
        protected override IDbSpecificCreator CreateDbSpecificCreator()
        {
            return new PostgreSqlSpecificCreator();
        }

        #region Dynamic Insert Query construction methods

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

			// walk all EntityField instances in fields. We only support single table inserts, pick the table of the first field.
			queryText.AppendFormat("INSERT INTO {0} (", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			NpgsqlParameter newParameter = null;
			int amountFieldsAdded = 0;

			for (int i = 0; i < fields.Length; i++)
			{
				IEntityFieldCore field = fields[i];
				IFieldPersistenceInfo persistenceInfo = fieldsPersistenceInfo[i];

				if (!CheckIfFieldNeedsInsertAction(field) && !persistenceInfo.IsIdentity)
				{
					// doesn't have a value set or is readonly, and is not linked to a supertype field. This means that the field won't recieve a value
					// nor does it has a value set. Assume a default is set in the database or NULL is acceptable., skip field.
					continue;
				}

				// normal field which will be updated.
				if (amountFieldsAdded > 0)
				{
					queryText.Append(", ");
				}

				queryText.AppendFormat("{0}", base.Creator.CreateFieldNameSimple(persistenceInfo, field.Name));
				string valueString = string.Empty;
				newParameter = (NpgsqlParameter)base.Creator.CreateParameter( field, persistenceInfo, ParameterDirection.Input );
				base.UniqueMarker++;
				newParameter.ParameterName += base.UniqueMarker;
				if( persistenceInfo.IsIdentity )
				{
					// when the field is an identity, a sequence is defined. We'll generate nextval('sequence') as value. 
					insertQuery.AddParameterFieldRelation( new ParameterFieldRelation( field, newParameter, persistenceInfo.TypeConverterToUse ) );
					string sequenceName = GetNewPerCallSequenceName( persistenceInfo.IdentityValueSequenceName );
					// create SequenceRetrievalQuery
					ISequenceRetrievalQuery sequenceQuery = new SequenceRetrievalQuery();
					sequenceQuery.SequenceRetrievalCommand = CreateCommand();
					sequenceQuery.SequenceRetrievalCommand.Connection = connectionToUse;
					sequenceQuery.ExecuteSequenceCommandFirst = false;
					sequenceQuery.SequenceRetrievalCommand.CommandText = String.Format( "SELECT currval('{0}')", sequenceName );
					sequenceQuery.SequenceParameters.Add( newParameter );
					insertQuery.SequenceRetrievalQueries.Add( sequenceQuery );

					valueString = string.Format( "nextval('{0}')", sequenceName );
				}
				else
				{
					// just emit a parameter. 
					command.Parameters.Add( newParameter );
					valueString = newParameter.ParameterName;
				}

				if( amountFieldsAdded > 0 )
				{
					parametersText.Append( ", " );
				}
				parametersText.Append( valueString );
				
				amountFieldsAdded++;
				fieldToParameter.Add(field, newParameter);
			}

			if (amountFieldsAdded <= 0)
			{
				// empty field list, throw exception
				throw new ORMQueryConstructionException("The insert query doesn't contain any fields.");
			}

			// append the rest of the query elements.
			queryText.AppendFormat(") VALUES ({0})", parametersText.ToString());

            command.CommandText = queryText.ToString();
            command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?insertQuery.ToString():string.Empty, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetInsertDQ", "Method Exit");

			// query is done. 
			return insertQuery;
		}

		#endregion

		#region Dynamic Delete Query construction methods

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

			if (deleteFilter != null)
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", deleteFilter.ToQueryText(ref this.UniqueMarker));

				for (int i = 0; i < deleteFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(deleteFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?deleteQuery.ToString():string.Empty, "Generated Sql query");
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
			IActionQuery deleteQuery = new ActionQuery( connectionToUse, command );
			string deleteTablename = base.Creator.CreateObjectName( fieldsPersistenceInfo[0] );
			StringBuilder queryText = new StringBuilder( DeleteQueryBufferLength );

			string fromText = "";
			string whereText = "";

			ArrayList customFilterParameters = new ArrayList();
			NonAnsiJoinConstructor( relationsToWalk, ref fromText, ref whereText, deleteTablename, ref this.UniqueMarker, customFilterParameters );
			queryText.AppendFormat( "DELETE FROM {0} WHERE EXISTS ( SELECT * FROM {1} WHERE {2}", deleteTablename, fromText, whereText );

			for( int i = 0; i < customFilterParameters.Count; i++ )
			{
				command.Parameters.Add( customFilterParameters[i] );
			}

			if( deleteFilter != null )
			{
				deleteFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat( " AND {0}", deleteFilter.ToQueryText( ref this.UniqueMarker ) );

				for( int i = 0; i < deleteFilter.Parameters.Count; i++ )
				{
					command.Parameters.Add( deleteFilter.Parameters[i] );
				}
			}

			queryText.Append( ")" );

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?deleteQuery.ToString():string.Empty, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetDeleteDQ(4)", "Method Exit");

            // query is done. 
			return deleteQuery;
		}

		#endregion

		#region Dynamic Update Query construction methods

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

			if (fieldsToUpdate.Count <= 0)
			{
				// no fields to update. return empty query
				command.CommandText = "";
				
                return updateQuery;
			}

			StringBuilder queryText = new StringBuilder(UpdateQueryBufferLength);

			// walk all EntityField instances in fields. We only support single table updates, pick the table of the first field.
			queryText.AppendFormat("UPDATE {0} SET ", base.Creator.CreateObjectName(fieldsPersistenceInfo[0]));

			NpgsqlParameter newParameter = null;

			for (int i = 0; i < fieldsToUpdate.Count; i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];

				if (i > 0)
				{
					queryText.Append(",");
				}

				if (field.ExpressionToApply==null)
				{
					// normal field which will be updated.
					newParameter = (NpgsqlParameter)base.Creator.CreateParameter(field, persistenceInfo, ParameterDirection.Input);
					base.UniqueMarker++;
					newParameter.ParameterName += base.UniqueMarker;
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

			if (updateFilter != null)
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", updateFilter.ToQueryText(ref this.UniqueMarker));

				for (int i = 0; i < updateFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(updateFilter.Parameters[i]);
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?updateQuery.ToString():string.Empty, "Generated Sql query");
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

			if (fieldsToUpdate.Count <= 0)
			{
				// no fields to update. return empty query
				command.CommandText = "";

				return updateQuery;
			}

			StringBuilder queryText = new StringBuilder( UpdateQueryBufferLength );

			// walk all EntityField instances in fields. We only support single table updates.
			queryText.AppendFormat( "UPDATE {0} SET ", base.Creator.CreateObjectName( persistenceInfoFieldsToUpdate[0] ) );

			NpgsqlParameter newParameter = null;
			for( int i = 0; i < fieldsToUpdate.Count; i++ )
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsToUpdate[i];
				IFieldPersistenceInfo persistenceInfo = (IFieldPersistenceInfo)persistenceInfoFieldsToUpdate[i];

				if( i > 0 )
				{
					queryText.Append( "," );
				}

				if( field.ExpressionToApply == null )
				{
					// normal field which will be updated.
					newParameter = (NpgsqlParameter)base.Creator.CreateParameter( field, persistenceInfo, ParameterDirection.Input );
					command.Parameters.Add( newParameter );
					queryText.AppendFormat( "{0}={1}", base.Creator.CreateFieldNameSimple( persistenceInfo, field.Name ), newParameter.ParameterName );
				}
				else
				{
					field.ExpressionToApply.DatabaseSpecificCreator = base.Creator;
					queryText.AppendFormat( "{0}={1}", base.Creator.CreateFieldNameSimple( persistenceInfo, field.Name ), field.ExpressionToApply.ToQueryText( ref this.UniqueMarker ) );
					for( int j = 0; j < field.ExpressionToApply.Parameters.Count; j++ )
					{
						command.Parameters.Add( field.ExpressionToApply.Parameters[j] );
					}
				}
			}
			relationsToWalk.DatabaseSpecificCreator = base.Creator;
			queryText.AppendFormat( " FROM {0}", relationsToWalk.ToQueryText( ref this.UniqueMarker ) );
			if( updateFilter != null )
			{
				updateFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat( " WHERE {0}", updateFilter.ToQueryText( ref this.UniqueMarker ) );
				for( int i = 0; i < updateFilter.Parameters.Count; i++ )
				{
					command.Parameters.Add( updateFilter.Parameters[i] );
				}
			}

			for( int i = 0; i < ((RelationCollection)relationsToWalk).CustomFilterParameters.Count; i++ )
			{
				command.Parameters.Add( ((RelationCollection)relationsToWalk).CustomFilterParameters[i] );
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?updateQuery.ToString():string.Empty, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSingleTargetUpdateDQ(5)", "Method Exit");

            // query is done. 
            return updateQuery;
		}

		#endregion

		#region Dynamic Select Query construction methods

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
		
            if (relationsSpecified)
			{
				// set base.Creator so alias set can be produced
				relationsToWalk.DatabaseSpecificCreator = base.Creator;
			}

			IDbCommand command = CreateCommand();
			IRetrievalQuery selectQuery = new RetrievalQuery(connectionToUse, command);

			StringBuilder queryText = new StringBuilder(SelectJoinQueryBufferLength);
			StringBuilder resultsetText = new StringBuilder(SelectResultSetBufferLength);

			// first create the resultset text. During the loop, check if there are fields of type ntext, text or image. if so, we will
			// have to create another query if duplicates are not allowed.
			bool distinctViolatingTypesFound = false;
			Dictionary<string, object> fieldNamesInSelectList = null;

			if (sortClausesSpecified)
			{
				fieldNamesInSelectList = new Dictionary<string,object>(selectList.Length);
			}

			for (int i = 0; i < selectList.Length; i++)
			{
				if (i > 0)
				{
					resultsetText.Append(", ");
				}

				string fieldName = base.Creator.CreateFieldName(selectList[i], fieldsPersistenceInfo[i], selectList[i].Alias, selectList[i].ObjectAlias, ref this.UniqueMarker, true);
				resultsetText.Append(fieldName);

				if ((fieldsPersistenceInfo[i].SourceColumnName!=selectList[i].Alias)||
					(selectList[i].ExpressionToApply != null)||
					(selectList[i].AggregateFunctionToApply != AggregateFunction.None))
				{
					resultsetText.AppendFormat(" AS \"{0}\"", selectList[i].Alias);
				}

				if (sortClausesSpecified)
				{
					// we have to test the order by clauses for presence in the select list. store select list elements in hashtable.
					if (selectList[i].ExpressionToApply != null || selectList[i].AggregateFunctionToApply != AggregateFunction.None)
					{
						// add as alias
						if (!fieldNamesInSelectList.ContainsKey(selectList[i].Alias))
						{
							fieldNamesInSelectList.Add(selectList[i].Alias, null);
						}
					}
					else
					{
						// add with complete field name
						if (!fieldNamesInSelectList.ContainsKey(fieldName))
						{
							fieldNamesInSelectList.Add(fieldName, null);
						}
					}
				}
				if (selectList[i].ExpressionToApply != null)
				{
					// append parameters
					for (int j = 0; j < selectList[i].ExpressionToApply.Parameters.Count; j++)
					{
						command.Parameters.Add(selectList[i].ExpressionToApply.Parameters[j]);
					}
				}
			}

			queryText.Append("SELECT");

			bool distinctEmitted = false;

			if (!allowDuplicates && !distinctViolatingTypesFound)
			{
				bool emitDistinct = true;

				if (relationsSpecified && sortClausesSpecified)
				{
					// check if the sortclause fields are in the selectlist.
					emitDistinct = CheckIfSortClausesAreInSelectList(fieldNamesInSelectList, sortClauses);
				}
				if (emitDistinct)
				{
					queryText.Append(" DISTINCT");
					distinctEmitted = true;
				}
			}

            selectQuery.RequiresClientSideDistinctFiltering = (!allowDuplicates && !distinctEmitted);

			queryText.AppendFormat(" {0}", resultsetText.ToString());

            if (relationsSpecified)
            {
				queryText.Append(" FROM ");
                // build join list.
                queryText.Append(relationsToWalk.ToQueryText(ref this.UniqueMarker));

                for (int i = 0; i < ((RelationCollection)relationsToWalk).CustomFilterParameters.Count; i++)
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
						queryText.AppendFormat(" {0}", selectList[0].ObjectAlias);
					}
				}
            }

			// build where clause, if necessary
			if (selectFilter != null)
			{
				// append where clause
				selectFilter.DatabaseSpecificCreator = base.Creator;
				queryText.AppendFormat(" WHERE {0}", selectFilter.ToQueryText(ref this.UniqueMarker));

				for (int i = 0; i < selectFilter.Parameters.Count; i++)
				{
					command.Parameters.Add(selectFilter.Parameters[i]);
				}
			}

			if (groupByClause != null)
			{
				AppendGroupByClause(queryText, groupByClause, command);

				if (groupByClause.HavingClause != null)
				{
					for (int i = 0; i < groupByClause.HavingClause.Parameters.Count; i++)
					{
						command.Parameters.Add(groupByClause.HavingClause.Parameters[i]);
					}
				}
			}

			if (sortClausesSpecified)
			{
				AppendOrderByClause(queryText, sortClauses, command);
			}

			if (maxNumberOfItemsToReturn > 0)
			{
				// only emit the rowlimit SQL if DISTINCT is emitted as well or when there are no relations specified or when the limit is 1,
				// as a limit of 1 isn't selecting duplicates otherwise set the flag in the RetrievalQuery object for manual limitation.
				if (distinctEmitted || !relationsSpecified || maxNumberOfItemsToReturn == 1)
				{
                    queryText.AppendFormat(" LIMIT {0}", maxNumberOfItemsToReturn);
				}
				else
				{
					selectQuery.RequiresClientSideLimitation        = true;
					selectQuery.MaxNumberOfItemsToReturnClientSide  = maxNumberOfItemsToReturn;
				}
			}

			command.CommandText = queryText.ToString();
			command.CommandType = CommandType.Text;

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, (DynamicQueryEngine.Switch.TraceVerbose) ? selectQuery.ToString() : string.Empty, "Generated Sql query");
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

			long max            = 0;
			bool pagingRequired = true;

			if (pageSize < 1 || pageNumber < 1)
			{
				// no paging.
				max = maxNumberOfItemsToReturn;
				pagingRequired = false;
			}
			
			IRetrievalQuery normalQuery = this.CreateSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter, max, sortClauses, relationsToWalk, allowDuplicates, groupByClause);

			if (pageSize < 1 || pageNumber < 1)
			{
				TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ: no paging.", "Method Exit");
				return normalQuery;
			}

			if (normalQuery.RequiresClientSideDistinctFiltering)
			{
				// manual paging required
				normalQuery.RequiresClientSidePaging    =   pagingRequired;
				normalQuery.ManualPageNumber            = pageNumber;
				normalQuery.ManualPageSize              = pageSize;
			}
			else
            {
                // normal paging. Embed paging logic. 
                // There is no LIMIT statement in the query as we've passed '0' for maxAmountOfItemsToReturn
                normalQuery.Command.CommandText = String.Format("SELECT {2} LIMIT {0} OFFSET {1}",
                    pageSize, ((pageNumber - 1) * pageSize), normalQuery.Command.CommandText.Substring(6));
			}

			TraceHelper.WriteIf(DynamicQueryEngine.Switch.TraceVerbose, DynamicQueryEngine.Switch.TraceVerbose?normalQuery.ToString():string.Empty, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreatePagingSelectDQ", "Method Exit");

			return normalQuery;
		}

		#endregion

		#region Name overwrite access methods

		/// <summary>
		/// Gets the new name for the schema, given the current name. If the current name is not found in the list of schema name overwrites, 
		/// the current name is returned.
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <returns>New name for the schema which name was passed in.</returns>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		public static string GetNewSchemaName(string currentName)
		{
			string toReturn = currentName;

			if (_schemaOverwrites.Count > 0 && _schemaOverwrites.ContainsKey(currentName))
			{
				toReturn = (string)_schemaOverwrites[currentName];
			}

			return toReturn;
		}

		/// <summary>
		/// Gets the new name of the stored procedure passed in. Overwrites schema name with a new name if the name
		/// has been defined for overwriting. 
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public static string GetNewStoredProcedureName(string currentName)
		{
			// split proc name on '.'.
			string[] fragments = currentName.Split(new char[] {'.'});
			fragments[0] = GetNewSchemaName(fragments[0]);

            switch (fragments.Length)
			{
				case 2:
					if (fragments[0].Length > 0)
					{
						return fragments[0] + "." + fragments[1];
					}
					else
					{
						return fragments[1];
					}

				case 3:
					if (fragments[0].Length > 0)
					{
						return fragments[0] + "." + fragments[1] + "." + fragments[2];
					}
					else
					{
						return fragments[1] + "." + fragments[2];
					}
			}

			return currentName;
		}

		/// <summary>
		/// Gets the new name of the sequence passed in. Overwrites schema name with a new name if the name
		/// has been defined for overwriting. 
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public static string GetNewSequenceName(string currentName)
		{
			// split sequence name on '.'.
			string[] fragments = currentName.Split(new char[] {'.'});
			fragments[0] = GetNewSchemaName(fragments[0]);

			switch (fragments.Length)
			{
				case 2:
					if (fragments[0].Length > 0)
					{
						return string.Format("\"{0}\".\"{1}\"", fragments[0], fragments[1]);
					}
					else
					{
						return string.Format("\"{0}\"", fragments[1]);
					}
			}

			return string.Format("\"{0}\"", currentName);
		}

		/// <summary>
		/// Gets the new name of the stored procedure passed in. Overwrites schema name with a new name if the name
		/// has been defined for overwriting.  Works on the PerCallSchemaNameOverwrites set.
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>Thread safe, because the hashtable is never modified during execution.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public string GetNewPerCallStoredProcedureName(string currentName)
		{
			// split proc name on '.'.
			string[] fragments = currentName.Split(new char[] {'.'});
			fragments[0] = ((DbSpecificCreatorBase)base.Creator).GetNewPerCallSchemaName(fragments[0]);

			switch (fragments.Length)
			{
				case 2:
					if (fragments[0].Length > 0)
					{
						return fragments[0] + "." + fragments[1];
					}
					else
					{
						return fragments[1];
					}

				case 3:
					if (fragments[0].Length > 0)
					{
						return fragments[0] + "." + fragments[1] + "." + fragments[2];
					}
					else
					{
						return fragments[1] + "." + fragments[2];
					}
			}

			return currentName;
		}

		/// <summary>
		/// Gets the new name of the sequence passed in. Overwrites schema name with a new name if the name
		/// has been defined for overwriting. Works on the PerCallSchemaNameOverwrites set.
		/// </summary>
		/// <param name="currentName">current Name</param>
		/// <remarks>First the per-call name overwriting is called, then the config file defined name overwriting is called with the
		/// name retrieved from the per-call name overwriting, so config file settings overrule per-call settings, though are controlled by
		/// the per-call name overwriting.</remarks>
		/// <returns>full stored procedure name with new catalog name/schema name.</returns>
		public string GetNewPerCallSequenceName(string currentName)
		{
			// split sequence name on '.'.
			string[] fragments = currentName.Split(new char[] {'.'});
			fragments[0] = ((DbSpecificCreatorBase)base.Creator).GetNewPerCallSchemaName(fragments[0]);
			fragments[0] = DynamicQueryEngine.GetNewSchemaName(fragments[0]);

			switch (fragments.Length)
			{
				case 2:
					if (fragments[0].Length > 0)
					{
						return string.Format("\"{0}\".\"{1}\"", fragments[0], fragments[1]);
					}
					else
					{
						return string.Format("\"{0}\"", fragments[1]);
					}
			}

			return string.Format("\"{0}\"", currentName);
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
			return new PostgreSqlSpecificExceptionInfoRetriever();
		}
		
		/// <summary>
		/// Constructs a non-ansi join set of clauses for FROM and WHERE using the passed in relations collection.
		/// This is placed here and not in the relations collection, because non-ansi joins are non-standard, and
		/// require where clause output which is not implemented in the RelationCollection.ToQueryText().
		/// </summary>
		/// <param name="relations">relations to use to form the join</param>
		/// <param name="fromClause">from clause output. This string is usable as the argument for the FROM statement. It does not contain FROM</param>
		/// <param name="whereClause">where clause output. This string is usable as the argument for the WHERE statement. It does not contain WHERE</param>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the custom filter predicates</param>
		/// <param name="customFilterParameters">ArrayList which will contain after this call all parameters created during the processing of custom filters
		/// specified in EntityRelations</param>
		private void NonAnsiJoinConstructor( IRelationCollection relations, ref string fromClause, ref string whereClause, ref int uniqueMarker, ArrayList customFilterParameters )
		{
			NonAnsiJoinConstructor( relations, ref fromClause, ref whereClause, "", ref this.UniqueMarker, customFilterParameters );
		}

		/// <summary>
		/// Constructs a non-ansi join set of clauses for FROM and WHERE using the passed in relations collection.
		/// This is placed here and not in the relations collection, because non-ansi joins are non-standard, and
		/// require where clause output which is not implemented in the RelationCollection.ToQueryText().
		/// </summary>
		/// <param name="relations">relations to use to form the join</param>
		/// <param name="fromClause">from clause output. This string is usable as the argument for the FROM statement. It does not contain FROM</param>
		/// <param name="whereClause">where clause output. This string is usable as the argument for the WHERE statement. It does not contain WHERE</param>
		/// <param name="rootTableReference">This parameter is set in UPDATE and DELETE statements where a multi-table relation filter is used.
		/// These queries wrap the joins produced with this routine in a subquery and the table used outside the subquery shouldn't be mentioned in the
		/// join list. So if this table reference is in the join list, it is skipped (however field1=field2 statements are added to link the outer table to the
		/// subquery logic).</param>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the custom filter predicates</param>
		/// <param name="customFilterParameters">ArrayList which will contain after this call all parameters created during the processing of custom filters
		/// specified in EntityRelations</param>
		private void NonAnsiJoinConstructor( IRelationCollection relations, ref string fromClause, ref string whereClause, string rootTableReference,
					ref int uniqueMarker, ArrayList customFilterParameters )
		{
			// Hashtable with the Object name + the alias as key (f.e. "[dbo].[Customers] C") and a boolean as value which signals if the
			// object is added weakly or not.
			Hashtable objectsWithAliasesAdded = new Hashtable();
			StringBuilder fromText = new StringBuilder( 256 );
			StringBuilder whereText = new StringBuilder( 256 );
			string commaPrefix = string.Empty;

			RelationCollection relationsToWalk = ((RelationCollection)relations).PreprocessRelations();

			int amountRelations = relationsToWalk.Count;

			for( int i = 0; i < amountRelations; i++ )
			{
				EntityRelation relation = (EntityRelation)relationsToWalk[i];
				string pkElement;
				string fkElement;
				string aliasPKSide;
				string aliasFKSide;
				string pkElementReference;
				string fkElementReference;
				string fkFieldSuffix;
				string pkFieldSuffix;
				bool pkElementAddedWeak = false;
				bool fkElementAddedWeak = false;
				bool relationChainIsWeak = false;
				bool addFKSide = true;
				bool addPKSide = true;

				// construct the "PKelement jointype JOIN FKelement" join fragment
				aliasPKSide = relation.AliasPKSide;
				aliasFKSide = relation.AliasFKSide;

				// find real aliases using databasespecificcreator's scopes
				aliasPKSide = base.Creator.FindRealAlias( relation.GetPKEntityFieldCore( 0 ).ContainingObjectName, aliasPKSide,
												relation.GetPKEntityFieldCore(0).ActualContainingObjectName);
				aliasFKSide = base.Creator.FindRealAlias( relation.GetFKEntityFieldCore( 0 ).ContainingObjectName, aliasFKSide,
												relation.GetFKEntityFieldCore(0).ActualContainingObjectName);
				pkElement = base.Creator.CreateObjectName( relation.GetPKFieldPersistenceInfo( 0 ) );
				fkElement = base.Creator.CreateObjectName( relation.GetFKFieldPersistenceInfo( 0 ) );
				pkElementReference = pkElement;
				fkElementReference = fkElement;
				pkFieldSuffix = string.Empty;
				fkFieldSuffix = string.Empty;

				// Determine the suffix operator for the join columns. Joins are by definition done as: PKside join FKside. 
				// If start entity is FK side, jointype is different from join hint, if hint is left/right. 
				// The (+) operator is applied to the columns in the join condition of the side which is not the direction of the join.
				// so A LEFT JOIN B, will result in FROM A, B WHERE A.foo = B.foo(+)
				switch( relation.HintForJoins )
				{
					case JoinHint.Left:
						if( relation.StartEntityIsPkSide )
						{
							fkFieldSuffix = "(+)";
						}
						else
						{
							pkFieldSuffix = "(+)";
						}
						break;

					case JoinHint.Right:
						if( relation.StartEntityIsPkSide )
						{
							pkFieldSuffix = "(+)";
						}
						else
						{
							fkFieldSuffix = "(+)";
						}
						break;

					default:
						break;
				}

				if( aliasPKSide.Length > 0 )
				{
					aliasPKSide = base.Creator.CreateValidAlias( aliasPKSide );
					pkElement += " " + aliasPKSide;
					pkElementReference = aliasPKSide;
				}

				if( aliasFKSide.Length > 0 )
				{
					aliasFKSide = base.Creator.CreateValidAlias( aliasFKSide );
					fkElement += " " + aliasFKSide;
					fkElementReference = aliasFKSide;
				}

				bool pkSideAlreadyAdded = objectsWithAliasesAdded.ContainsKey( pkElement );
				bool fkSideAlreadyAdded = objectsWithAliasesAdded.ContainsKey( fkElement );

				if( pkSideAlreadyAdded && fkSideAlreadyAdded )
				{
					// no element to add
					continue;
				}

				// check if PK side or FK side are already added to the query text. If so, and if we're not the first iteration,
				// we can drop the side already added. 
				if( i > 0 )
				{
					if( pkSideAlreadyAdded )
					{
						// PK side already added 
						addPKSide = false;
						relationChainIsWeak = (bool)objectsWithAliasesAdded[pkElement];
					}
					else
					{
						// pk side is not yet added, fk side has to be in the list of already added elements. If not, the relation
						// set contains an error (FROM A INNER JOIN B ON A.x = B.x INNER JOIN D on C.x = D.x -> error, C is not in the list)
						if( !fkSideAlreadyAdded )
						{
							// not added as well. Error
							throw new ORMRelationException( "Relation at index " + i + " doesn't contain an entity already added to the FROM clause. Bad alias?" );
						}
						relationChainIsWeak = (bool)objectsWithAliasesAdded[fkElement];
						addFKSide = false;
					}
				}

				// drop a side in the FROM clause if the element is the same as the roottable.
				addFKSide &= (rootTableReference != fkElement);
				addPKSide &= (rootTableReference != pkElement);

				if( !addPKSide && !addFKSide )
				{
					// nothing to add
					continue;
				}

				// process weakness of the relation if _obeyWeakRelations is set and join hint is not set to a hint and the relation is weak.
				if( relations.ObeyWeakRelations && (relation.IsWeak || relationChainIsWeak) && relation.HintForJoins == JoinHint.None )
				{
					if( relation.TypeOfRelation == RelationType.ManyToOne )
					{
						// Always join towards the FK in this situation (m:1 relation).
						// Order.CustomerID - Customer.CustomerID, where Order.CustomerID can be null
						// PK side is mentioned first, FK side is mentioned second, so a RIGHT join will
						// include all elements of the FK side, in this case Order, despite a NULL.
						pkElementAddedWeak = true;
						fkElementAddedWeak = false;

						pkFieldSuffix = "(+)";
					}
					else
					{
						// Always join towards the PK in this situation (1:n or 1:1 relation)
						pkElementAddedWeak = false;
						fkElementAddedWeak = true;

						fkFieldSuffix = "(+)";
					}
				}

				if( addFKSide )
				{
					objectsWithAliasesAdded[fkElement] = fkElementAddedWeak;
				}
				if( addPKSide )
				{
					objectsWithAliasesAdded[pkElement] = pkElementAddedWeak;
				}

				// construct query elements
				if( addPKSide && addFKSide )
				{
					fromText.AppendFormat( " {0}, {1}", pkElement, fkElement );
				}
				else
				{
					if( addPKSide )
					{
						// pk side only
						fromText.AppendFormat( "{0}{1}", commaPrefix, pkElement );
					}
					else
					{
						// fk side only
						fromText.AppendFormat( "{0}{1}", commaPrefix, fkElement );
					}
				}
				commaPrefix = ", ";

				bool emitFieldsInOnClause = (relation.HintForJoins != JoinHint.Cross);
				bool emitCustomFilter = false;

				if( relation.CustomFilter != null )
				{
					if( relation.CustomFilter.Count > 0 )
					{
						emitFieldsInOnClause = !relation.CustomFilterReplacesOnClause;
						emitCustomFilter = true;
					}
				}

				if( emitFieldsInOnClause )
				{
					// create ON clauses.
					for( int j = 0; j < relation.AmountFields; j++ )
					{
						// append AND if we've more than one PK field or we've already had one relation.
						if( (i + j) > 0 )
						{
							whereText.Append( " AND" );
						}

						whereText.AppendFormat( " {0}.{1}{2}={3}.{4}{5}",
							pkElementReference,
							base.Creator.CreateFieldNameSimple( relation.GetPKFieldPersistenceInfo( j ), relation.GetPKEntityFieldCore( j ).Name ),
							pkFieldSuffix,
							fkElementReference,
							base.Creator.CreateFieldNameSimple( relation.GetFKFieldPersistenceInfo( j ), relation.GetFKEntityFieldCore( j ).Name ),
							fkFieldSuffix );
					}
				}

				if( emitCustomFilter )
				{
					// if this EntityRelation has a custom filter, add that filter with AND. 
					relation.CustomFilter.DatabaseSpecificCreator = base.Creator;
					if( emitFieldsInOnClause )
					{
						whereText.Append( " AND" );
					}
					whereText.AppendFormat( " {0}", relation.CustomFilter.ToQueryText( ref this.UniqueMarker ) );
					// add parameters created by this custom filter to our general list.
					customFilterParameters.AddRange( relation.CustomFilter.Parameters );
				}
			}

			fromClause = fromText.ToString();
			whereClause = whereText.ToString();
		}

    }
}
