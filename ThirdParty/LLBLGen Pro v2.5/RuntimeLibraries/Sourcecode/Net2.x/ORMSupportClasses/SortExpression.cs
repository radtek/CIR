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
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the ISortExpression interface. This class contains the 
	/// sort clauses used in IRetrievalQuery instances.
	/// </summary>
	[Serializable]
	public class SortExpression : CollectionBase, ISortExpression
	{
		#region Class Member Declarations
		[NonSerialized]
		private IDbSpecificCreator		_databaseSpecificCreator;
		[NonSerialized]
		private List<IDataParameter>	_parameters;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public SortExpression()
		{
		}


		/// <summary>
		/// CTor which initially adds the passed in sort clause. This is an accelerator constructor to 
		/// make code more compact.
		/// </summary>
		/// <param name="sortClauseToAdd">Sort clause to add.</param>
		public SortExpression(ISortClause sortClauseToAdd)
		{
			this.Add(sortClauseToAdd);
		}


		/// <summary>
		/// Adds the passed in sort clause to the list. 
		/// </summary>
		/// <param name="sortClauseToAdd">the sort clause to add</param>
		/// <returns>The index the sort clause was added to</returns>
		public int Add(ISortClause sortClauseToAdd)
		{
			return List.Add(sortClauseToAdd);
		}


		/// <summary>
		/// Inserts the passed in sort clause at the index provided.
		/// </summary>
		/// <param name="index">Index to insert the sortclause at</param>
		/// <param name="sortClauseToAdd">the sort clause to insert</param>
		public void Insert(int index, ISortClause sortClauseToAdd)
		{
			List.Insert(index, sortClauseToAdd);
		}


		/// <summary>
		/// Removes the given sort clause from the list.
		/// </summary>
		/// <param name="sortClauseToRemove">the sort clause to remove.</param>
		public void Remove(ISortClause sortClauseToRemove)
		{
			List.Remove(sortClauseToRemove);
		}


		/// <summary>
		/// Retrieves a ready to use text representation for the sort clauses contained in this expression.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <returns>string which is usable as the argument for the ORDER BY clause in a query</returns>
		/// <remarks>uses aliases for fields which have an expression and/or aggregate applied.</remarks>
		public string ToQueryText( ref int uniqueMarker )
		{
			return ToQueryText( ref uniqueMarker, true );
		}

		/// <summary>
		/// Retrieves a ready to use text representation for the sort clauses contained in this expression.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <param name="aliasesForExpressionsAggregates">If set to false (default is true), the full field name with expression / aggregate is placed in
		/// the result string instead of the alias of the field. If set to true, aliases are used for fields with an expression and/or aggregate applied.</param>
		/// <returns>string which is usable as the argument for the ORDER BY clause in a query</returns>
		public virtual string ToQueryText( ref int uniqueMarker, bool aliasesForExpressionsAggregates )
		{
			StringBuilder toReturn = new StringBuilder( 256 );
			_parameters = new List<IDataParameter>();

			for( int i = 0; i < this.Count; i++ )
			{
				ISortClause sortClauseToUse = this[i];
				if( i > 0 )
				{
					toReturn.Append( "," );
				}

				string fieldName = string.Empty;

				// create full fieldname in the cases:
				// - CaseSensitiveCollation
				// - Expression / Aggregate is applied and aliasesForExpressionsAggregates is false
				// - no expression / aggregate is applied
				bool expressionAggregateApplied = !((sortClauseToUse.FieldToSortCore.ExpressionToApply == null) &&
						(sortClauseToUse.FieldToSortCore.AggregateFunctionToApply == AggregateFunction.None));
			
				if( (!expressionAggregateApplied) || (expressionAggregateApplied && !aliasesForExpressionsAggregates) || sortClauseToUse.CaseSensitiveCollation )
				{
					// full name of column, can't sort on a column alias in this case.
					fieldName = _databaseSpecificCreator.CreateFieldName( sortClauseToUse.FieldToSortCore, sortClauseToUse.PersistenceInfo, 
							sortClauseToUse.FieldToSortCore.Alias, sortClauseToUse.ObjectAlias, ref uniqueMarker, true);
					if(( sortClauseToUse.FieldToSortCore.ExpressionToApply != null ) && !aliasesForExpressionsAggregates)
					{
						_parameters.AddRange( sortClauseToUse.FieldToSortCore.ExpressionToApply.Parameters );
					}
				}
				else
				{
					// create valid alias. 
					string aliasToMakeValid = sortClauseToUse.FieldToSortCore.Alias;
					if(aliasToMakeValid.IndexOf("(")>=0)
					{
						// function call trick used.
						fieldName = aliasToMakeValid;
					}
					else
					{
						fieldName = _databaseSpecificCreator.CreateValidAlias(sortClauseToUse.FieldToSortCore.Alias);
					}
				}
				if( sortClauseToUse.CaseSensitiveCollation )
				{
					toReturn.AppendFormat( null, "{0}({1}) {2}", _databaseSpecificCreator.ToUpperFunctionName(), fieldName, _databaseSpecificCreator.ConvertSortOperator( sortClauseToUse.SortOperatorToUse ) );
				}
				else
				{
					toReturn.AppendFormat( null, "{0} {1}", fieldName, _databaseSpecificCreator.ConvertSortOperator( sortClauseToUse.SortOperatorToUse ) );
				}
			}

			return toReturn.ToString();
		}


		#region Class Property Declarations
		/// <summary>
		/// Indexer for this list.
		/// </summary>
		public ISortClause this [int index]
		{
			get { return (ISortClause)List[index]; }
			set { List[index] = value; }
		}

		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		public IDbSpecificCreator DatabaseSpecificCreator
		{
			get { return _databaseSpecificCreator; }
			set { _databaseSpecificCreator = value; }
		}

		/// <summary>
		/// The list of parameters created when the sortexpression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		public List<IDataParameter> Parameters
		{
			get
			{
				if( _parameters == null )
				{
					_parameters = new List<IDataParameter>();
				}
				return _parameters;
			}
		}
		#endregion
	}
}
