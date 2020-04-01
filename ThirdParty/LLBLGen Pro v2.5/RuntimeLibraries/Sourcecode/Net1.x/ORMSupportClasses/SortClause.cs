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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which implements ISortClause, a class which forms a single sort clause, thus an order by
	/// definition defined for a single IEntityField.
	/// </summary>
	[Serializable]
	public class SortClause : ISortClause
	{
		#region Class Member Declarations
		private	IEntityFieldCore		_fieldToSortCore;
		private IFieldPersistenceInfo	_persistenceInfo;
		private SortOperator			_sortOperatorToUse;
		private string					_objectAlias;
		private bool					_caseSensitiveCollation;
		#endregion
		
		
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="fieldToSort">IEntityField to sort on</param>
		/// <param name="sortOperatorToUse">the sort operator to use for this sort clause</param>
		public SortClause(IEntityField fieldToSort, SortOperator sortOperatorToUse)
		{
			_fieldToSortCore = fieldToSort;
			_persistenceInfo = fieldToSort;
			_sortOperatorToUse = sortOperatorToUse;
			_objectAlias = string.Empty;
			_caseSensitiveCollation = false;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="fieldToSort">IEntityField to sort on</param>
		/// <param name="sortOperatorToUse">the sort operator to use for this sort clause</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public SortClause(IEntityField fieldToSort, SortOperator sortOperatorToUse, string objectAlias)
		{
			_fieldToSortCore = fieldToSort;
			_persistenceInfo = fieldToSort;
			_sortOperatorToUse = sortOperatorToUse;
			_objectAlias = objectAlias;
			_caseSensitiveCollation = false;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="fieldToSort">IEntityFieldCore to sort on</param>
		/// <param name="persistenceInfo">Persistence info of fieldToSort</param>
		/// <param name="sortOperatorToUse">the sort operator to use for this sort clause</param>
		public SortClause(IEntityFieldCore fieldToSort, IFieldPersistenceInfo persistenceInfo, SortOperator sortOperatorToUse)
		{
			_fieldToSortCore = fieldToSort;
			_persistenceInfo = persistenceInfo;
			_sortOperatorToUse = sortOperatorToUse;
			_objectAlias = string.Empty;
			_caseSensitiveCollation = false;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="fieldToSort">IEntityFieldCore to sort on</param>
		/// <param name="persistenceInfo">Persistence info of fieldToSort</param>
		/// <param name="sortOperatorToUse">the sort operator to use for this sort clause</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public SortClause(IEntityFieldCore fieldToSort, IFieldPersistenceInfo persistenceInfo, SortOperator sortOperatorToUse, string objectAlias)
		{
			_fieldToSortCore = fieldToSort;
			_persistenceInfo = persistenceInfo;
			_sortOperatorToUse = sortOperatorToUse;
			_objectAlias = objectAlias;
			_caseSensitiveCollation = false;
		}


		/// <summary>
		/// Sets the case sensitive collation flag and returns the sortclause instance for further command chaining
		/// </summary>
		/// <param name="value">new value for teh CaseSensitiveCollation flag.</param>
		/// <returns>this instance for command chaining</returns>
		public SortClause SetCaseSensitiveCollation(bool value)
		{
			_caseSensitiveCollation = value;
			return this;
		}

		#region SortExpression producing operator overloads
		/// <summary>
		/// Operator overload for the '&amp;' operator to concatenate sortclauses into a sortexpression
		/// </summary>
		/// <param name="leftOperand">left operand</param>
		/// <param name="rightOperand">right operand</param>
		/// <returns>new sortexpression object with first the leftoperand and then the rightoperand</returns>
		public static SortExpression operator&(SortClause leftOperand, SortClause rightOperand)
		{
			SortExpression toReturn = new SortExpression(leftOperand);
			toReturn.Add(rightOperand);
			return toReturn;
		}

		/// <summary>
		/// Operator overload for the '&amp;' operator to concatenate sortclauses into a sortexpression
		/// </summary>
		/// <param name="leftOperand">left operand</param>
		/// <param name="rightOperand">right operand</param>
		/// <returns>the left operand to which the right operand is added</returns>
		public static SortExpression operator&(SortExpression leftOperand, SortClause rightOperand)
		{
			leftOperand.Add(rightOperand);
			return leftOperand;
		}
		#endregion


		#region Class Property Declarations
		/// <summary>
		/// IEntityFieldCore to sort on.
		/// </summary>
		public IEntityFieldCore FieldToSortCore
		{
			get
			{
				return _fieldToSortCore;
			}
			set
			{
				_fieldToSortCore = value;
				if( value is EntityField )
				{
					_persistenceInfo = (IFieldPersistenceInfo)value;
				}
			}
		}

		/// <summary>
		/// Persistence information for FieldToSort. Can be a cast of the same object, when an IEntityField is
		/// added to this sort clause
		/// </summary>
		public IFieldPersistenceInfo PersistenceInfo
		{
			get
			{
				return _persistenceInfo;
			}
			set
			{
				_persistenceInfo = value;
			}
		}
		
		/// <summary>
		/// The sort operator to use for this sort clause
		/// </summary>
		public SortOperator SortOperatorToUse
		{
			get { return _sortOperatorToUse; }
			set { _sortOperatorToUse = value; }
		}

		/// <summary>
		/// Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used).
		/// </summary>
		public string ObjectAlias
		{
			get
			{
				if(_objectAlias.Length>0)
				{
					return _objectAlias;
				}
				else
				{
					return _fieldToSortCore.ObjectAlias;
				}
			}
			set
			{
				_objectAlias = value;
			}
		}

		
		/// <summary>
		/// Gets / sets caseSensitiveCollation flag. If set to true, the UPPER() function (or db specific equivalent) is applied to the field. Default: false
		/// </summary>
		public bool CaseSensitiveCollation
		{
			get
			{
				return _caseSensitiveCollation;
			}
			set
			{
				_caseSensitiveCollation = value;
			}
		}

		#endregion
	}
}
