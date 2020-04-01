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
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.DQE.Access
{
	/// <summary>
	/// Implements IDbSpecificCreator for Access. 
	/// </summary>
	[Serializable]
	public class AccessSpecificCreator : DbSpecificCreatorBase, IDbSpecificHintCreator
	{
		#region Class Member Declarations
		private SortedList<int, List<IDataParameter>> _parametersPerScope;
		private bool _enableParameterPerScopeTracking;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public AccessSpecificCreator()
		{
			_parametersPerScope = new SortedList<int, List<IDataParameter>>();
			_enableParameterPerScopeTracking = false;
		}


		/// <summary>
		/// Routine which creates a valid alias string for the raw alias passed in. For example, the alias will be surrounded by "[]" on sqlserver. 
		/// Used by the RelationCollection to produce a valid alias for joins.
		/// </summary>
		/// <param name="rawAlias">the raw alias to make valid</param>
		/// <returns>valid alias string to use.</returns>
		public override string CreateValidAlias(string rawAlias)
		{
			return "[" + rawAlias + "]";
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

			IDataParameter toReturn = null;

			if(field.DataType == null)
			{
				// artifical field without real persistence info (e.g. an entityfield instance which is solely an expression)
				toReturn = new OleDbParameter(CreateParameterName(field.Alias), value);
			}
			else
			{
				toReturn = new OleDbParameter(CreateParameterName(field.Alias), (OleDbType)persistenceInfo.SourceColumnDbType, persistenceInfo.SourceColumnMaxLength,
								 direction, persistenceInfo.SourceColumnIsNullable, persistenceInfo.SourceColumnPrecision, persistenceInfo.SourceColumnScale,
								 "", DataRowVersion.Current, value);
			}
			AddParameterToScopeTracker(toReturn);
			return toReturn;
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
			OleDbType dbTypeToUse = OleDbType.VarWChar;

			switch(value.GetType().UnderlyingSystemType.FullName)
			{
				case "System.String":
					dbTypeToUse = OleDbType.LongVarWChar;
					break;
				case "System.Byte":
					dbTypeToUse = OleDbType.UnsignedTinyInt;
					break;
				case "System.Int32":
					dbTypeToUse = OleDbType.Integer;
					break;
				case "System.Int16":
					dbTypeToUse = OleDbType.SmallInt;
					break;
				case "System.Int64":
					throw new NotSupportedException("Int64s are not supported in Access databases.");
				case "System.DateTime":
					dbTypeToUse = OleDbType.Date;
					break;
				case "System.Decimal":
					dbTypeToUse = OleDbType.Numeric;
					break;
				case "System.Double":
					dbTypeToUse = OleDbType.Double;
					break;
				case "System.Single":
					dbTypeToUse = OleDbType.Single;
					break;
				case "System.Boolean":
					dbTypeToUse = OleDbType.Boolean;
					break;
				case "System.Byte[]":
					dbTypeToUse = OleDbType.LongVarBinary;
					break;
				case "System.Guid":
					dbTypeToUse = OleDbType.Guid;
					break;
				default:
					dbTypeToUse = OleDbType.VarWChar;
					break;
			}

			IDataParameter toReturn = new OleDbParameter(CreateParameterName(name), dbTypeToUse);
			if(value==null)
			{
				toReturn.Value = System.DBNull.Value;
			}
			else
			{
				toReturn.Value = value;
			}
			toReturn.Direction = direction;

			AddParameterToScopeTracker(toReturn);

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
			IDataParameter toReturn = new OleDbParameter(CreateParameterName(fieldName), OleDbType.VarWChar, pattern.Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pattern);
			AddParameterToScopeTracker(toReturn);
			return toReturn;
		}


		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required.
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <param name="containingObjectName">Name of the containing object which defined the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>
		/// Valid field name for usage with the target database.
		/// </returns>
		public override string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, bool appendAlias,
				string containingObjectName, string actualContainingObjectName)
		{
			StringBuilder name = new StringBuilder(128);

			string aliasToUse = base.FindRealAlias(containingObjectName, objectAlias, actualContainingObjectName);
			if(aliasToUse.Length <= 0)
			{
				name.AppendFormat("{0}.", CreateObjectName(persistenceInfo));
			}
			else
			{
				name.AppendFormat("[{0}].", aliasToUse);
			}
			name.AppendFormat("[{0}]", persistenceInfo.SourceColumnName);

			if(appendAlias)
			{
				if(fieldName!=persistenceInfo.SourceColumnName)
				{
					name.AppendFormat(" AS [{0}]", fieldName);
				}
			}

			return name.ToString();
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
						name.AppendFormat("AVG({0})", aggFieldName);
						break;
					case AggregateFunction.Count:
						name.AppendFormat("COUNT({0})", aggFieldName);
						break;
					case AggregateFunction.CountRow:
						name.Append("COUNT(*)");
						break;
					case AggregateFunction.Max:
						name.AppendFormat("MAX({0})", aggFieldName);
						break;
					case AggregateFunction.Min:
						name.AppendFormat("MIN({0})", aggFieldName);
						break;
					case AggregateFunction.StDev:
						name.AppendFormat("STDEV({0})", aggFieldName);
						break;
					case AggregateFunction.Sum:
						name.AppendFormat("SUM({0})", aggFieldName);
						break;
					case AggregateFunction.Variance:
						name.AppendFormat("VAR({0})", aggFieldName);
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
					return string.Format("[{0}] AS [{1}]", persistenceInfo.SourceColumnName, fieldName);
				}
				else
				{
					return string.Format("[{0}]", persistenceInfo.SourceColumnName);
				}
			}
			else
			{
				return string.Format("[{0}]", persistenceInfo.SourceColumnName);
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
			return string.Format("[{0}]", persistenceInfo.SourceObjectName);
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
				case ExOp.Mod:
					toReturn = "Mod";
					break;
				case ExOp.BitwiseAnd:
				case ExOp.BitwiseOr:
				case ExOp.BitwiseXor:
					throw new NotSupportedException(string.Format("The expression operator {0} is not supported by Access.", operatorToConvert.ToString()));
				case ExOp.None:
				default:
					toReturn = base.ConvertExpressionOperator(operatorToConvert);
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Returns the SQL functionname to make a string uppercase.
		/// </summary>
		/// <returns></returns>
		public override string ToUpperFunctionName()
		{
			return "UCASE";
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
			DynamicQueryEngine dqEngine = new DynamicQueryEngine();
			dqEngine.UniqueMarker = uniqueMarker;
			base.SetCreatorInDQE(dqEngine);
			// as we're going into a new scope, create a new alias scope so aliases defined in this new scope don't pollute the current scope.
			base.CreateNewAliasScope();
			IRetrievalQuery query = dqEngine.CreateSelectDQ(selectList, fieldPersistenceInfos, null, selectFilter, maxNumberOfItemsToReturn, sortClauses, relationsToWalk, (maxNumberOfItemsToReturn<2), groupByClause);
			// we're back, destroy the created scope for the subquery.
			base.DestroyCurrentAliasScope();
			uniqueMarker=dqEngine.UniqueMarker;

			TraceHelper.WriteLineIf(DynamicQueryEngine.Switch.TraceInfo, "CreateSubQuery", "Method Exit");
			return query;
		}


		/// <summary>
		/// Creates the hint statement for the hint passed in.
		/// </summary>
		/// <param name="hint">Hint specification to create the statement for.</param>
		/// <param name="values">Additional parameters for the hint statement producer. The values can be very provider specific.</param>
		/// <returns>the hint statement, ready to use.</returns>
		public string CreateHintStatement(RdbmsHint hint, params object[] values)
		{
			// no hints implemented
			return string.Empty;
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
		/// Adds the parameter to scope tracker.
		/// </summary>
		/// <param name="toAdd">To add.</param>
		private void AddParameterToScopeTracker(IDataParameter toAdd)
		{
			if(!_enableParameterPerScopeTracking)
			{
				// no tracking enabled
				return;
			}

			int currentScopeIndex = AliasScopes.Count - 1;
			List<IDataParameter> parameters = null;
			if(!_parametersPerScope.TryGetValue(currentScopeIndex, out parameters))
			{
				parameters = new List<IDataParameter>();
				_parametersPerScope.Add(currentScopeIndex, parameters);
			}

			parameters.Add(toAdd);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the parameters per scope.
		/// </summary>
		internal SortedList<int, List<IDataParameter>> ParametersPerScope
		{
			get { return _parametersPerScope; }
		}

		/// <summary>
		/// Gets a value indicating whether [enable parameter per scope tracking].
		/// </summary>
		internal bool EnableParameterPerScopeTracking
		{
			get { return _enableParameterPerScopeTracking; }
			set
			{
				if(_enableParameterPerScopeTracking && !value)
				{
					// scope tracking switched off
					_parametersPerScope.Clear();
				}
				_enableParameterPerScopeTracking = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Retriever class which retrieves the db specific information from the passed in OleDbException. This way the db specific info can be obtained in
	/// db generic code.
	/// </summary>
	public class AccessSpecificExceptionInfoRetriever : ExceptionInfoRetrieverBase
	{
		/// <summary>
		/// Gets the exception info which is included in the passed in db specific exception. This retrieval has to be done in this class as not all .NET
		/// providers derive their exception classes from DbException.
		/// </summary>
		/// <param name="dbSpecificException">The db specific exception object.</param>
		/// <returns>
		/// A dictionary with per exception info element the value retrieved from the db specific exception
		/// </returns>
		public override Dictionary<ExceptionInfoElement, object> GetExceptionInfo(Exception dbSpecificException)
		{
			OleDbException ex = dbSpecificException as OleDbException;
			if(ex == null)
			{
				// not a OleDbException
				return null;
			}

			Dictionary<ExceptionInfoElement, object> toReturn = new Dictionary<ExceptionInfoElement, object>();
			toReturn.Add(ExceptionInfoElement.ErrorCode, ex.ErrorCode);
			toReturn.Add(ExceptionInfoElement.ErrorNumber, ex.ErrorCode);
			toReturn.Add(ExceptionInfoElement.ErrorObjects, ex.Errors);
			toReturn.Add(ExceptionInfoElement.ServerName, ex.Source);
			toReturn.Add(ExceptionInfoElement.Message, ex.Message);
			toReturn.Add(ExceptionInfoElement.HelpLink, ex.HelpLink);

			return toReturn;
		}
	}
}
