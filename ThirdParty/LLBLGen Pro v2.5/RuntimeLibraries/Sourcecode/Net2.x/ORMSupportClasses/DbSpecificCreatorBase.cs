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
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.ComponentModel;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Base class for every DbSpecificCreator implementation
	/// </summary>
	[Serializable]
	public abstract class DbSpecificCreatorBase : IDbSpecificCreator
	{
		#region Class Member Declarations
		private CatalogNameOverwriteHashtable	_perCallCatalogNameOverwrites;
		private SchemaNameOverwriteHashtable	_perCallSchemaNameOverwrites;
		private Stack<AliasScope> _aliasScopes;
		private int								_aliasSuffixCounter;
		#endregion


		/// <summary>
		/// Creates a new <see cref="DbSpecificCreatorBase"/> instance.
		/// </summary>
		public DbSpecificCreatorBase()
		{
			_perCallCatalogNameOverwrites = null;
			_perCallSchemaNameOverwrites = null;
			_aliasSuffixCounter=1;
			_aliasScopes = new Stack<AliasScope>();
			// create the initial scope
			CreateNewAliasScope();
		}


		/// <summary>
		/// Produces the alias scope data for the relations collection passed in, which define 0 or more aliases and form a separated scope.
		/// </summary>
		/// <param name="relations">Relations.</param>
		/// <remarks>produces the alias - entitynames in the current scope. If this has to be done in a new scope, call CreateNewAliasScope() first.</remarks>
		internal void ProduceAliasScopeData(IRelationCollection relations)
		{
			MultiValueHashtable<string, string> entityNamesPerAlias = new MultiValueHashtable<string,string>(relations.Count * 2);
			Dictionary<string, string> artificialAliasPerEntity = new Dictionary<string, string>();
			relations.GetUsedEntityTypeNamesAndAliases(entityNamesPerAlias, artificialAliasPerEntity);

			AliasScope scope = _aliasScopes.Peek();
			scope.ArtificialAliasPerEntity = artificialAliasPerEntity;
			foreach(KeyValuePair<string, UniqueValueList<string>> entry in entityNamesPerAlias)
			{
				string alias = entry.Key;
				UniqueValueList<string> entityNames = entry.Value;
				bool singleTargetAlias = false;
				foreach(string entityName in entityNames)
				{
					// split on ';'. Every name has its hierarchy type suffixed to it or if not in a hierarchy it doesn't have any suffix. 
					// the suffix is ';x', where x is 1 for TargetPerEntityHierarchy and 2 for TargetPerEntity
					// if the suffix is 1, all names share the same LPA_n alias, as there's just 1 table/view for the whole hierarchy anyway. 
					// if the suffix is 2 or not there, they get a new LPA_n alias. 
					string[] fragments = entityName.Split(';');
					singleTargetAlias = ((fragments.Length > 1) && (fragments[1] == "1"));
					string key = String.Format("{0}__{1}", fragments[0], alias);
					string value = String.Format("LPA_{0}{1}", alias[0], _aliasSuffixCounter);
					scope.Add(key, value);
					if(!singleTargetAlias)
					{
						_aliasSuffixCounter++;
					}
				}
				if(singleTargetAlias)
				{
					_aliasSuffixCounter++;
				}
			}
		}


		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityField implementation.
		/// </summary>
		/// <param name="field">IEntityField instance used to base the parameter on.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public virtual IDataParameter CreateParameter(IEntityField field, ParameterDirection direction)
		{
			return CreateParameter(field, field, direction, field.CurrentValue);
		}


		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public virtual IDataParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction)
		{
			return CreateParameter(field, persistenceInfo, direction, field.CurrentValue);
		}


		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <param name="valueToSet">Value to set the parameter to.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public virtual IDataParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction, object valueToSet)
		{
			return null;
		}


		/// <summary>
		/// Creates a parameter based on the the value passed in. The value is used to determine the DB type. 
		/// No precision/scale/length is set, this is left to the IDataParameter implementing object. This method is used to
		/// produce parameters for expression values. 
		/// </summary>
		/// <param name="name">name to be used for the parameter.</param>
		/// <param name="direction">Direction for the parameter</param>
		/// <param name="value">value the parameter is for.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public virtual IDataParameter CreateParameter(string name, ParameterDirection direction, object value)
		{
			return null;
		}


		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type. 
		/// </summary>
		/// <param name="fieldName">The name of the field the LIKE statement is used with.</param>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public virtual IDataParameter CreateLikeParameter(string fieldName, string pattern)
		{
			return null;
		}

		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type. 
		/// </summary>
		/// <param name="fieldName">The name of the field the LIKE statement is used with.</param>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <param name="targetFieldDbType">Type of the target field db</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		/// <remarks>This version ignores targetFieldDbType and calls CreateLikeParameter(fieldname, pattern). When you override this one, also
		/// override the other.</remarks>
		public virtual IDataParameter CreateLikeParameter(string fieldName, string pattern, int targetFieldDbType)
		{
			// for now, ignore targetFieldDbType.
			return CreateLikeParameter(fieldName, pattern);
		}


		/// <summary>
		/// Creates a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. This field name is
		/// not padded with an alias if that alias should be created. Effectively, this is the
		/// same as CreateFieldName(field persistence info, fieldname, false);
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="containingObjectName">Name of the containing object which defined the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, string containingObjectName, 
						string actualContainingObjectName)
		{
			return CreateFieldName(persistenceInfo, fieldName, objectAlias, false, containingObjectName, actualContainingObjectName);
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
		/// <returns>Valid field name for usage with the target database.</returns>
		public virtual string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, bool appendAlias, 
								string containingObjectName, string actualContainingObjectName)
		{
			return string.Empty;
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
		public virtual string CreateFieldName(IEntityFieldCore fieldCore, IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, ref int uniqueMarker, bool applyAggregateFunction)
		{
			return string.Empty;
		}


		/// <summary>
		/// Creates a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. This field name is
		/// not padded with an alias if that alias should be created. Effectively, this is the
		/// same as CreateFieldNameSimple(field persistence info, fieldname, false);. The fieldname is 'simple' in that
		/// it doesn't contain any catalog, schema or table references. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public virtual string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName)
		{
			return CreateFieldNameSimple(persistenceInfo, fieldName, false);
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
		public virtual string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName, bool appendAlias)
		{
			return string.Empty;
		}


		/// <summary>
		/// Creates a valid object name (f.e. a name for a table or view) based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance which source object info is used to formulate the objectname</param>
		/// <returns>Valid object name</returns>
		public virtual string CreateObjectName(IFieldPersistenceInfo persistenceInfo)
		{
			return persistenceInfo.SourceObjectName;
		}


		/// <summary>
		/// Converts the passed in comparison operator to a string usable in a query.
		/// </summary>
		/// <param name="operatorToConvert">Operator to convert to string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		public virtual string ConvertComparisonOperator(ComparisonOperator operatorToConvert)
		{
			string toReturn = string.Empty;

			switch(operatorToConvert)
			{
				case ComparisonOperator.Equal:
					toReturn = "=";
					break;
				case ComparisonOperator.GreaterEqual:
					toReturn = ">=";
					break;
				case ComparisonOperator.GreaterThan:
					toReturn = ">";
					break;
				case ComparisonOperator.LessEqual:
					toReturn = "<=";
					break;
				case ComparisonOperator.LesserThan:
					toReturn = "<";
					break;
				case ComparisonOperator.NotEqual:
					toReturn = "<>";
					break;
				default:
					toReturn = "";
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the passed in sort operator to a string usable in a query
		/// </summary>
		/// <param name="operatorToConvert">sort operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		public virtual string ConvertSortOperator(SortOperator operatorToConvert)
		{
			string toReturn = string.Empty;
			switch(operatorToConvert)
			{
				case SortOperator.Ascending:
					toReturn = "ASC";
					break;
				case SortOperator.Descending:
					toReturn = "DESC";
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the passed in expression operator (exop) to a string usable in a query 
		/// </summary>
		/// <param name="operatorToConvert">Expression operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		public virtual string ConvertExpressionOperator(ExOp operatorToConvert)
		{
			string toReturn = string.Empty;

			switch(operatorToConvert)
			{
				case ExOp.Add:
					toReturn = "+";
					break;
				case ExOp.And:
					toReturn = "AND";
					break;
				case ExOp.Div:
					toReturn = "/";
					break;
				case ExOp.Equal:
					toReturn = "=";
					break;
				case ExOp.GreaterEqual:
					toReturn = ">=";
					break;
				case ExOp.GreaterThan:
					toReturn = ">";
					break;
				case ExOp.LessEqual:
					toReturn = "<=";
					break;
				case ExOp.LesserThan:
					toReturn = "<";
					break;
				case ExOp.Mod:
					toReturn = "%";
					break;
				case ExOp.Mul:
					toReturn = "*";
					break;
				case ExOp.NotEqual:
					toReturn = "<>";
					break;
				case ExOp.Or:
					toReturn = "OR";
					break;
				case ExOp.Sub:
					toReturn = "-";
					break;
				case ExOp.None:
				default:
					toReturn = string.Empty;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the passed in set operator to a string usable in a query 
		/// </summary>
		/// <param name="operatorToConvert">Set operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		public virtual string ConvertSetOperator(SetOperator operatorToConvert)
		{
			string toReturn = string.Empty;

			switch(operatorToConvert)
			{
				case SetOperator.Exist:
					toReturn = "EXISTS";
					break;
				case SetOperator.In:
					toReturn = "IN";
					break;
				case SetOperator.Equal:
					toReturn = "=";
					break;
				case SetOperator.EqualAny:
					toReturn = "= ANY";
					break;
				case SetOperator.EqualAll:
					toReturn = "= ALL";
					break;
				case SetOperator.GreaterEqual:
					toReturn = ">=";
					break;
				case SetOperator.GreaterEqualAny:
					toReturn = ">= ANY";
					break;
				case SetOperator.GreaterEqualAll:
					toReturn = ">= ALL";
					break;
				case SetOperator.GreaterThan:
					toReturn = ">";
					break;
				case SetOperator.GreaterThanAny:
					toReturn = "> ANY";
					break;
				case SetOperator.GreaterThanAll:
					toReturn = "> ALL";
					break;
				case SetOperator.LessEqual:
					toReturn = "<=";
					break;
				case SetOperator.LessEqualAny:
					toReturn = "<= ANY";
					break;
				case SetOperator.LessEqualAll:
					toReturn = "<= ALL";
					break;
				case SetOperator.LesserThan:
					toReturn = "<";
					break;
				case SetOperator.LesserThanAny:
					toReturn = "< ANY";
					break;
				case SetOperator.LesserThanAll:
					toReturn = "< ALL";
					break;
				case SetOperator.NotEqual:
					toReturn = "<>";
					break;
				case SetOperator.NotEqualAny:
					toReturn = "<> ANY";
					break;
				case SetOperator.NotEqualAll:
					toReturn = "<> ALL";
					break;
				default:
					toReturn = "";
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Returns the SQL functionname to make a string uppercase.
		/// </summary>
		/// <returns></returns>
		public virtual string ToUpperFunctionName()
		{
			return string.Empty;
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
		public virtual IRetrievalQuery CreateSubQuery(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldPersistenceInfos,
			IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relationsToWalk, 
			IGroupByCollection groupByClause, ref int uniqueMarker)
		{
			return null;
		}


		/// <summary>
		/// Routine which creates a valid alias string for the raw alias passed in. For example, the alias will be surrounded by "[]" on sqlserver. 
		/// Used by the RelationCollection to produce a valid alias for joins.
		/// </summary>
		/// <param name="rawAlias">the raw alias to make valid</param>
		/// <returns>valid alias string to use.</returns>
		public virtual string CreateValidAlias(string rawAlias)
		{
			return rawAlias;
		}


		/// <summary>
		/// Sets this instance as the creator in the DQE.
		/// Used in subquery creations, to pass on the creator to a DQE.
		/// </summary>
		/// <param name="dqe">Dqe.</param>
		protected void SetCreatorInDQE(DynamicQueryEngineBase dqe)
		{
			dqe.Creator = this;
		}


		/// <summary>
		/// Gets the real value, by converting the passed in value, if necessary
		/// </summary>
		/// <param name="currentValue">Current value.</param>
		/// <param name="typeConverterToUse">Type converter to use.</param>
		/// <param name="actualDotNetType">Type of the actual dot net.</param>
		/// <returns></returns>
		protected virtual object GetRealValue(object currentValue, TypeConverter typeConverterToUse, Type actualDotNetType)
		{
#if !CF
			if(typeConverterToUse!=null)
			{
				return typeConverterToUse.ConvertTo(null, null, currentValue, actualDotNetType);
			}
			else
			{
				return currentValue;
			}
#else
			// not supported on CF.NET
			return currentValue;
#endif
		}


		/// <summary>
		/// Gets the new catalog name from the per-call hashtable name overwrites set into this object. If no per call name pairs are defined or the
		/// name passed in isn't found, the same name passed in is returned
		/// </summary>
		/// <param name="currentName">Name of the current.</param>
		/// <returns>the new name </returns>
		public string GetNewPerCallCatalogName(string currentName)
		{
			string toReturn = string.Empty;
			if(_perCallCatalogNameOverwrites==null)
			{
				toReturn = currentName;
			}
			else
			{
				string toMatch = StripObjectNameChars(currentName);

				switch(_perCallCatalogNameOverwrites.CatalogNameUsageSetting)
				{
					case CatalogNameUsage.Clear:
						toReturn = string.Empty;
						break;
					case CatalogNameUsage.ForceName:
						if(_perCallCatalogNameOverwrites.ContainsKey("*"))
						{
							// get the name specified for the "*" wildcard. Should be there.
							toReturn = _perCallCatalogNameOverwrites["*"];
						}
						break;
					case CatalogNameUsage.Default:
						if(_perCallCatalogNameOverwrites.ContainsKey(toMatch))
						{
							toReturn = _perCallCatalogNameOverwrites[toMatch];
						}
						else
						{
							toReturn = currentName;
						}
						break;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Gets the new schema name from the per-call hashtable name overwrites set into this object. If no per call name pairs are defined or the
		/// name passed in isn't found, the same name passed in is returned
		/// </summary>
		/// <param name="currentName">Name of the current.</param>
		/// <returns>the new name </returns>
		public string GetNewPerCallSchemaName(string currentName)
		{
			string toReturn = string.Empty;
			if(_perCallSchemaNameOverwrites==null)
			{
				toReturn = currentName;
			}
			else
			{
				string toMatch = StripObjectNameChars(currentName);

				switch(_perCallSchemaNameOverwrites.SchemaNameUsageSetting)
				{
					case SchemaNameUsage.Clear:
						toReturn = string.Empty;
						break;
					case SchemaNameUsage.ForceName:
						if(_perCallSchemaNameOverwrites.ContainsKey("*"))
						{
							// get the name specified for the "*" wildcard. Should be there.
							toReturn = _perCallSchemaNameOverwrites["*"];
						}
						break;
					case SchemaNameUsage.Default:
						if(_perCallSchemaNameOverwrites.ContainsKey(toMatch))
						{
							toReturn = _perCallSchemaNameOverwrites[toMatch];
						}
						else
						{
							toReturn = currentName;
						}
						break;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the name of the field to the raw base name to use further in the CreateFieldName routine. This routine
		/// makes sure expressions and function calls are taken into account. Used as the start call from CreateFieldName.
		/// </summary>
		/// <param name="fieldCore">The field core.</param>
		/// <param name="persistenceInfo">The persistence info.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="objectAlias">The object alias.</param>
		/// <param name="uniqueMarker">The unique marker.</param>
		/// <param name="applyAggregateFunction">if set to <c>true</c> [apply aggregate function].</param>
		/// <returns>
		/// base name for the field to use in a query.
		/// </returns>
		protected virtual string ConvertFieldToRawName(IEntityFieldCore fieldCore, IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, 
				ref int uniqueMarker, bool applyAggregateFunction)
		{
			string toReturn = string.Empty;

			if( fieldCore.ExpressionToApply != null )
			{
				fieldCore.ExpressionToApply.DatabaseSpecificCreator = this;
				toReturn = fieldCore.ExpressionToApply.ToQueryText( ref uniqueMarker, applyAggregateFunction );
			}
			else
			{
				string objectAliasToUse = objectAlias;
				if( objectAlias.Length <= 0 )
				{
					objectAliasToUse = fieldCore.ObjectAlias;
				}
				toReturn = CreateFieldName( persistenceInfo, fieldName, objectAliasToUse, false, fieldCore.ContainingObjectName, 
								fieldCore.ActualContainingObjectName);
			}

			return toReturn;
		}


		/// <summary>
		/// Strips the object name chars from the name passed in. For example [name] will become name
		/// </summary>
		/// <param name="toStrip">To strip.</param>
		/// <returns>name without the name's object name chars (Which are db specific)</returns>
		protected virtual string StripObjectNameChars(string toStrip)
		{
			return toStrip;
		}


		/// <summary>
		/// Creates a new alias scope and makes it active.
		/// </summary>
		protected void CreateNewAliasScope()
		{
			_aliasScopes.Push( new AliasScope() );
		}


		/// <summary>
		/// Destroys the current alias scope and makes the previous one active, if any.
		/// </summary>
		protected void DestroyCurrentAliasScope()
		{
			if(_aliasScopes.Count>0)
			{
				_aliasScopes.Pop();
			}
		}
        
		/// <summary>
		/// Finds the real alias for the entity + objectalias combination. A real alias is necessary as an entity mapped onto multiple tables (through inheritance)
		/// is aliased with a single object alias but each target has to have a different real alias. 
		/// </summary>
		/// <param name="containingObjectName">Name of the entity the holder of the objectAlias is defined in</param>
		/// <param name="objectAlias">Object alias.</param>
		/// <param name="actualContainingObjectName">The name of the entity the holder of the object alias is actually present in (is only different from
		/// entityName if holder is a subtype and did inherit the field)</param>
		/// <returns>the real alias for the entityname + objectAlias combination. If not found, objectAlias is returned.</returns>
		public string FindRealAlias(string containingObjectName, string objectAlias, string actualContainingObjectName)
		{
			string toReturn = string.Empty;

			// start with the current scope and then work down to the bottom of the stack. 
			int scopeNo = -1;
			foreach( AliasScope scope in _aliasScopes )
			{
				scopeNo++;
				// check if the objectAlias could be artificial. 
				string artificialAlias = string.Empty;
				string objectAliasToUse = objectAlias;
				// if objectAlias is empty, it might be this entity is artificial aliased so we should use that one instead. 
				// this is the situation when a field without an ObjectAlias set seeks for its alias to reference. 
				bool artificialAliasUsed = false;
				if((objectAlias.Length<=0) && scope.ArtificialAliasPerEntity.TryGetValue(actualContainingObjectName, out artificialAlias))
				{
					// alias is artificial as the actual containing object name is in the list of entities which is artificial aliased. 
					objectAliasToUse = artificialAlias;
					artificialAliasUsed = true;
				}

				string aliasToFind = String.Format("{0}__{1}", containingObjectName, objectAliasToUse);
				bool aliasFound = scope.GetRealAlias(aliasToFind, out toReturn);
				if(!aliasFound && artificialAliasUsed)
				{
					// should have been there, so try with containing object name as artificial alias. This is necessary if the relations in the relations set
					// are solely hierarchy relations and the field to find the alias for is a field which is actually in a subtype. 
					if(scope.ArtificialAliasPerEntity.TryGetValue(containingObjectName, out artificialAlias))
					{
						// alias is artificial as the containing object name is in the list of entities which is artificial aliased. 
						objectAliasToUse = artificialAlias;
						aliasToFind = String.Format("{0}__{1}", containingObjectName, objectAliasToUse);
						aliasFound = scope.GetRealAlias(aliasToFind, out toReturn);
					}
				}
				if(!aliasFound)
				{
					if(scopeNo == 0)
					{
						// try with the artificial alias for startentities in M:N relations: __containingObjectName__
						// This auto-aliassing is a fix for inheritance of both sides with subtypes from the same base entity. 
						// if this special alias isn't found in the first scope, it's thus defined in the outer scope and auto-aliasing shouldn't take place. 
						string artificialAliasToFind = String.Format("{0}__{1}", containingObjectName, string.Format("__{0}__", actualContainingObjectName));
						if(!scope.GetRealAlias(artificialAliasToFind, out toReturn))
						{
							toReturn = objectAlias;
						}
						else
						{
							// found it 
							break;
						}
					}
					else
					{
						toReturn = objectAlias;
					}
				}
				else
				{
					break;
				}
			}

			return toReturn;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets perCallCatalogNameOverwrites name pairs
		/// </summary>
		public CatalogNameOverwriteHashtable PerCallCatalogNameOverwrites
		{
			get
			{
				return _perCallCatalogNameOverwrites;
			}
			set
			{
				_perCallCatalogNameOverwrites = value;
			}
		}


		/// <summary>
		/// Gets / sets perCallSchemaNameOverwrites name pairs
		/// </summary>
		public SchemaNameOverwriteHashtable PerCallSchemaNameOverwrites
		{
			get
			{
				return _perCallSchemaNameOverwrites;
			}
			set
			{
				_perCallSchemaNameOverwrites = value;
			}
		}


		/// <summary>
		/// Gets the alias scopes.
		/// </summary>
		/// <value>The alias scopes.</value>
		protected Stack<AliasScope> AliasScopes
		{
			get { return _aliasScopes; }
		}
		#endregion

	}


	/// <summary>
	/// Class which is used as an alias scope in a DbSpecificCreator.
	/// </summary>
	public class AliasScope
	{
		#region Class Member Declarations
		private Dictionary<string, string> _scopeData;
		private Dictionary<string, string> _artificialAliasPerEntity;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="AliasScope"/> class.
		/// </summary>
		public AliasScope()
		{
			_scopeData = new Dictionary<string, string>();
			_artificialAliasPerEntity = new Dictionary<string, string>();
		}


		/// <summary>
		/// Adds the specified key with the specific value to the scope data
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void Add(string key, string value)
		{
			_scopeData.Add(key, value);
		}


		/// <summary>
		/// Gets the real alias.
		/// </summary>
		/// <param name="aliasToFind">The alias to find.</param>
		/// <param name="realAlias">The real alias.</param>
		/// <returns>true if the alias was retrievable, false otherwise</returns>
		public bool GetRealAlias(string aliasToFind, out string realAlias)
		{
			return _scopeData.TryGetValue(aliasToFind, out realAlias);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the artificial alias per entity list
		/// </summary>
		public Dictionary<string, string> ArtificialAliasPerEntity
		{
			get { return _artificialAliasPerEntity; }
			set { _artificialAliasPerEntity = value; }
		}
		#endregion
	}
}
