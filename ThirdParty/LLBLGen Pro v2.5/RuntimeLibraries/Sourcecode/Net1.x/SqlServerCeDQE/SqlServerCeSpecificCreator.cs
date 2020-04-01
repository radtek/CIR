//////////////////////////////////////////////////////////////////////
// Part of the Dynamic Query Engine (DQE) for SqlServer CE, used in the generated code. 
// LLBLGen Pro specific. Do not modify. 
// LLBLGen Pro is (c) 2002-2006 Solutions Design. All rights reserved.
// http://www.llblgen.com
//////////////////////////////////////////////////////////////////////
// The sourcecode for this DQE is released as BSD2 licensed open source, so licensees and others can
// modify, update, extend or use it to write other DQE's. Do NOT, under any circumstance, change the
// INTERFACE of the DQE. Each DQE has to implement the same methods to make it work with LLBLGen Pro's
// generated code. 
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2006 Solutions Design. All rights reserved.
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
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Text;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DQE.SqlServer
{
	/// <summary>
	/// Implements IDbSpecificCreator for SqlServer CE. 
	/// </summary>
	[Serializable]
	public class SqlServerCeSpecificCreator : DbSpecificCreatorBase
	{
		#region Class Member Declarations
		private bool _useNoLockHintsForObjectNames = false;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public SqlServerCeSpecificCreator()
		{
		}


		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <param name="valueToSet">Value to set the parameter to.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public override IDataParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction, object valueToSet)
		{
			object value=base.GetRealValue(valueToSet, persistenceInfo.TypeConverterToUse, persistenceInfo.ActualDotNetType);
			if(value==null)
			{
				value=System.DBNull.Value;
			}

			return new SqlCeParameter(CreateParameterName(field.Alias), ConvertToSqlCeCompatibleType((SqlDbType)persistenceInfo.SourceColumnDbType), persistenceInfo.SourceColumnMaxLength, 
				persistenceInfo.SourceColumnIsNullable, persistenceInfo.SourceColumnPrecision, persistenceInfo.SourceColumnScale, 
				"", DataRowVersion.Current, value);
		}


		/// <summary>
		/// Creates a parameter based on the fieldcore passed in and the value passed in. The value is used to determine the DB type. 
		/// No precision/scale/length is set, this is left to the IDataParameter implementing object. This method is used to
		/// produce parameters for expression values. 
		/// </summary>
		/// <param name="name">name to be used for the parameter.</param>
		/// <param name="direction">Direction for the parameter</param>
		/// <param name="value">value the parameter is for.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public override IDataParameter CreateParameter(string name, ParameterDirection direction, object value)
		{
			SqlDbType dbTypeToUse = SqlDbType.VarChar;

			switch(value.GetType().UnderlyingSystemType.FullName)
			{
				case "System.String":
					if(((string)value).Length<4000)
					{
						dbTypeToUse = SqlDbType.NVarChar;
					}
					else
					{
						if(((string)value).Length<8000)
						{
							dbTypeToUse = SqlDbType.VarChar;
						}
						else
						{
							dbTypeToUse = SqlDbType.Text;
						}
					}
					break;
				case "System.Byte":
					dbTypeToUse = SqlDbType.TinyInt;
					break;
				case "System.Int32":
					dbTypeToUse = SqlDbType.Int;
					break;
				case "System.Int16":
					dbTypeToUse = SqlDbType.SmallInt;
					break;
				case "System.Int64":
					dbTypeToUse = SqlDbType.BigInt;
					break;
				case "System.DateTime":
					dbTypeToUse = SqlDbType.DateTime;
					break;
				case "System.Decimal":
					dbTypeToUse = SqlDbType.Decimal;
					break;
				case "System.Double":
					dbTypeToUse = SqlDbType.Float;
					break;
				case "System.Single":
					dbTypeToUse = SqlDbType.Real;
					break;
				case "System.Boolean":
					dbTypeToUse = SqlDbType.Bit;
					break;
				case "System.Byte[]":
					byte[] valueAsArray = (byte[])value;
					if(valueAsArray.Length<8000)
					{
						dbTypeToUse = SqlDbType.VarBinary;
					}
					else
					{
						dbTypeToUse = SqlDbType.Image;
					}
					break;
				case "System.Guid":
					dbTypeToUse = SqlDbType.UniqueIdentifier;
					break;
				default:
					dbTypeToUse = SqlDbType.VarChar;
					break;
			}

			IDataParameter toReturn = new SqlCeParameter(CreateParameterName(name), dbTypeToUse);
			if(value==null)
			{
				toReturn.Value=System.DBNull.Value;
			}
			else
			{
				toReturn.Value = value;
			}

			toReturn.Direction = direction;

			return toReturn;
		}


		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type. 
		/// </summary>
		/// <param name="fieldName">The name of the field the LIKE statement is used with.</param>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public override IDataParameter CreateLikeParameter(string fieldName, string pattern)
		{
			return new SqlCeParameter(CreateParameterName(fieldName), SqlDbType.NVarChar, pattern.Length, false, 0, 0, "", DataRowVersion.Current, pattern);
		}


		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <param name="containingObjectName">Name of the containing object of the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public override string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, bool appendAlias, 
			string containingObjectName, string actualContainingObjectName)
		{
			StringBuilder name = new StringBuilder(128);

			string aliasToUse = base.FindRealAlias(containingObjectName, objectAlias, actualContainingObjectName);
			if(aliasToUse.Length <= 0)
			{
				name.AppendFormat(null, "{0}.", CreateObjectName(persistenceInfo));
			}
			else
			{
				name.AppendFormat(null, "{0}.", aliasToUse);
			}

			name.AppendFormat(null, "\"{0}\"", persistenceInfo.SourceColumnName);

			if(appendAlias)
			{
				if(fieldName!=persistenceInfo.SourceColumnName)
				{
					name.AppendFormat(null, " AS \"{0}\"", fieldName);
				}
			}

			return name.ToString();
		}


		/// <summary>
		/// Routine which creates a valid alias string for the raw alias passed in. For example, the alias will be surrounded by "[]" on sqlserver. 
		/// Used by the RelationCollection to produce a valid alias for joins.
		/// </summary>
		/// <param name="rawAlias">the raw alias to make valid</param>
		/// <returns>valid alias string to use.</returns>
		public override string CreateValidAlias(string rawAlias)
		{
			return "\"" + rawAlias + "\"";
		}


		/// <summary>
		/// Creates the name for the field, and takes into account an aggregate function present and an expression present. If one or both are present, the
		/// field is replaced with (expression) or surrounded with (aggregate) the function (if applyAggregateFunction is true).
		/// </summary>
		/// <param name="fieldCore">fieldcore part of the field. Required to determine expression and aggregate function</param>
		/// <param name="persistenceInfo">persistence info object for the field.</param>
		/// <param name="fieldName">name for the field to be used</param>
		/// <param name="objectAlias">Alias for object hte field belongs to</param>
		/// <param name="uniqueMarker">uniquemarker variable for expression's toquerytext method.</param>
		/// <param name="applyAggregateFunction">flag to apply aggregate function or not. Aggregate functions can't be applied when the call originates
		/// from a predicate which is not part of a having clause.</param>
		/// <returns>string representing the field</returns>
		public override string CreateFieldName(IEntityFieldCore fieldCore, IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, ref int uniqueMarker, bool applyAggregateFunction)
		{
			string aggFieldName = base.ConvertFieldToRawName(fieldCore, persistenceInfo, fieldName, objectAlias, ref uniqueMarker, applyAggregateFunction);

			if(applyAggregateFunction)
			{
				StringBuilder name = new StringBuilder(128);
				switch(fieldCore.AggregateFunctionToApply)
				{
					case AggregateFunction.Avg:
						name.AppendFormat(null, "AVG({0})", aggFieldName);
						break;
					case AggregateFunction.Count:
						name.AppendFormat(null, "COUNT({0})", aggFieldName);
						break;
					case AggregateFunction.CountRow:
						name.Append("COUNT(*)");
						break;
					case AggregateFunction.Max:
						name.AppendFormat(null, "MAX({0})", aggFieldName);
						break;
					case AggregateFunction.Min:
						name.AppendFormat(null, "MIN({0})", aggFieldName);
						break;
					case AggregateFunction.Sum:
						name.AppendFormat(null, "SUM({0})", aggFieldName);
						break;
						
						// add more here.
					default:
						// unknown/not supported/none specified
						name.Append(aggFieldName);
						break;
				}

				return name.ToString();
			}
			else
			{
				return aggFieldName;
			}
		}


		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. The fieldname is 'simple' in that
		/// it doesn't contain any catalog, schema or table references. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public override string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName, bool appendAlias)
		{
			if(appendAlias)
			{
				if(fieldName!=persistenceInfo.SourceColumnName)
				{
					return string.Format("\"{0}\" AS \"{1}\"", persistenceInfo.SourceColumnName, fieldName);
				}
				else
				{
					return string.Format("\"{0}\"", persistenceInfo.SourceColumnName);
				}
			}
			else
			{
				return string.Format("\"{0}\"", persistenceInfo.SourceColumnName);
			}
		}


		/// <summary>
		/// Creates a valid object name (f.e. a name for a table or view) based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance which source object info is used to formulate the objectname</param>
		/// <returns>Valid object name</returns>
		public override string CreateObjectName(IFieldPersistenceInfo persistenceInfo)
		{
			return "\"" + persistenceInfo.SourceObjectName + "\"";
		}


		/// <summary>
		/// Converts the passed in expression operator (exop) to a string usable in a query 
		/// </summary>
		/// <param name="operatorToConvert">Expression operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		public override string ConvertExpressionOperator(ExOp operatorToConvert)
		{
			string toReturn = string.Empty;
			switch(operatorToConvert)
			{
				case ExOp.BitwiseAnd:
					toReturn = "&";
					break;
				case ExOp.BitwiseOr:
					toReturn = "|";
					break;
				case ExOp.BitwiseXor:
					toReturn = "^";
					break;
				case ExOp.Mod:
					toReturn = "%";
					break;
				default:
					toReturn = base.ConvertExpressionOperator(operatorToConvert);
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use as a subquery, based on the specified select list and the specified set of relations.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldPersistenceInfos">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="groupByClause">the group by clause to use</param>
		/// <param name="uniqueMarker">a unique marker value to use. </param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null or relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public override IRetrievalQuery CreateSubQuery(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldPersistenceInfos,
			IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relationsToWalk, 
			IGroupByCollection groupByClause, ref int uniqueMarker)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSubQuery", "Method Enter");

			ISortExpression sortClausesToPass = sortClauses;
			if(maxNumberOfItemsToReturn==0)
			{
				// can't pass order by clauses if no row limit is specified.
				sortClausesToPass = null;
			}
			DynamicQueryEngine dqEngine = new DynamicQueryEngine();
			dqEngine.UniqueMarker = uniqueMarker;
			base.SetCreatorInDQE(dqEngine);
			// as we're going into a new scope, create a new alias scope so aliases defined in this new scope don't pollute the current scope.
			base.CreateNewAliasScope();
			IRetrievalQuery query = dqEngine.CreateSelectDQ(selectList, fieldPersistenceInfos, null, selectFilter, maxNumberOfItemsToReturn, sortClausesToPass, relationsToWalk, (maxNumberOfItemsToReturn<2), groupByClause);
			// we're back, destroy the created scope for the subquery.
			base.DestroyCurrentAliasScope();
			uniqueMarker=dqEngine.UniqueMarker;

			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSubQuery", "Method Exit");
			return query;
		}


		/// <summary>
		/// Returns the SQL functionname to make a string uppercase.
		/// </summary>
		/// <returns></returns>
		public override string ToUpperFunctionName()
		{
			return "UPPER";
		}


		/// <summary>
		/// Creates from the passed in EntityField name a name usable for a Parameter. All spaces will be replaced by "_" characters. A "@" is added
		/// as a prefix. 
		/// </summary>
		/// <param name="fieldName">EntityField name to use as base for the parameter name.</param>
		/// <returns>Usable parameter name.</returns>
		private string CreateParameterName(string fieldName)
		{
			return "@" + fieldName.Replace(" ", "_");
		}


		/// <summary>
		/// Converts the passed in SqlServer type to the SqlCe compatible type. All non unicode types are converted to unicode types. Smallmoney is converted
		/// to money
		/// </summary>
		/// <param name="sqlServerType">SQL server type.</param>
		/// <returns></returns>
		private SqlDbType ConvertToSqlCeCompatibleType(SqlDbType sqlServerType)
		{
			SqlDbType toReturn = sqlServerType;

			switch(sqlServerType)
			{
				case SqlDbType.Char:
					toReturn = SqlDbType.NChar;
					break;
				case SqlDbType.VarChar:
					toReturn = SqlDbType.NVarChar;
					break;
				case SqlDbType.Text:
					toReturn = SqlDbType.NText;
					break;
				case SqlDbType.SmallMoney:
					toReturn = SqlDbType.Money;
					break;
			}

			return toReturn;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets useNoLockHintsForObjectNames
		/// </summary>
		public bool UseNoLockHintsForObjectNames
		{
			get
			{
				return _useNoLockHintsForObjectNames;
			}
			set
			{
				_useNoLockHintsForObjectNames = value;
			}
		}
		#endregion
	}
}
