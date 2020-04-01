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
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of a Field compare-operator Set expression, using the following format:
	/// IEntityField(Core) ComparisonOperator (Subquery)
	/// </summary>
	/// <remarks>If the operator EXISTS is used, the field is ignored so can be set to null/Nothing, as the predicate will simply
	/// result in EXISTS (SELECT setField FROM ...)<br/>
	/// This predicate isn't supported for in-memory filtering. Use FieldCompareRange for that.
	/// </remarks>
	[Serializable]
	public class FieldCompareSetPredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore			_field, _setField;
		private IFieldPersistenceInfo		_persistenceInfoField, _persistenceInfoSetField;
		private SetOperator					_operatorToUse;
		private IPredicate					_setFilter;
		private IRelationCollection			_setRelations;
		private	string						_objectAlias;
		private long						_maxNumberOfItemsToReturn;
		private ISortExpression				_setSorter;
		private IGroupByCollection			_groupByClause;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public FieldCompareSetPredicate()
		{
			InitClass(null, null, null, null, SetOperator.In, null, null, string.Empty, false, true, 0, null, null);
		}


		#region SelfServicing constructors
		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, null, string.Empty, false, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, string objectAlias)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, null, objectAlias, false, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, string.Empty, false, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
				IRelationCollection relations, string objectAlias)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, objectAlias, false, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
			IRelationCollection relations, string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, objectAlias, false, true, maxNumberOfItemsToReturn, sorter, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, bool negate)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, null, string.Empty, negate, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, string objectAlias, bool negate)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, null, objectAlias, negate, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
				IRelationCollection relations, bool negate)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, string.Empty, negate, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
			IRelationCollection relations, string objectAlias, bool negate)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, objectAlias, negate, true, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
			IRelationCollection relations, string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter, bool negate)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, objectAlias, negate, true, maxNumberOfItemsToReturn, sorter, null);
		}

		
		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <param name="negate">negate the compare expression</param>
		/// <param name="groupByClause">The Group By clause to use in the set query.</param>
		/// <remarks>SelfServicing specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityField field, IEntityField setField, SetOperator operatorToUse, IPredicate filter, 
			IRelationCollection relations, string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter, bool negate, 
			IGroupByCollection groupByClause)
		{
			InitClass(field, setField, field, setField, operatorToUse, filter, relations, objectAlias, negate, true, maxNumberOfItemsToReturn, sorter, groupByClause);
		}
		#endregion


		#region Adapter constructors
		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, null, string.Empty, false, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, string objectAlias)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, null, objectAlias, false, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, string.Empty, false, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, string objectAlias)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, objectAlias, false, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, 
				string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, objectAlias, false, false, maxNumberOfItemsToReturn, sorter, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, bool negate)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, null, string.Empty, negate, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, string objectAlias, bool negate)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, null, objectAlias, negate, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, bool negate)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, string.Empty, negate, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, 
				string objectAlias, bool negate)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, objectAlias, negate, false, 0, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <param name="negate">negate the compare expression</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, 
				string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter, bool negate)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, objectAlias, negate, false, maxNumberOfItemsToReturn, sorter, null);
		}

		
		/// <summary>
		/// Creates a new <see cref="FieldCompareSetPredicate"/> instance.
		/// </summary>
		/// <param name="field">field to compare to the set results. specify null if EXISTS operator is used</param>
		/// <param name="persistenceInfoField">the persistence info for field. Set to null</param>
		/// <param name="setField">field to base the set on</param>
		/// <param name="persistenceInfoSetField">the persistence info for SetField. Set to null</param>
		/// <param name="operatorToUse">operator to use as operator between field and the set</param>
		/// <param name="filter">filter to use in the set query. Can be null</param>
		/// <param name="relations">relations to use in the setquery. Can be null</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection of the query this 
		/// predicate is part of or should be left empty if no alias is specified (or no relation collection is used in the query this predicate is part of). 
		/// In that case, use another overload.</param>
		/// <param name="maxNumberOfItemsToReturn">the maximum amount of rows to return in the set query.</param>
		/// <param name="sorter">The sort expression to use in the set query</param>
		/// <param name="negate">negate the compare expression</param>
		/// <param name="groupByClause">The Group By clause to use in the set query.</param>
		/// <remarks>Adapter specific constructor</remarks>
		public FieldCompareSetPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfoField, IEntityFieldCore setField, 
			IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate filter, IRelationCollection relations, 
			string objectAlias, long maxNumberOfItemsToReturn, ISortExpression sorter, bool negate, IGroupByCollection groupByClause)
		{
			InitClass(field, setField, persistenceInfoField, persistenceInfoSetField, operatorToUse, filter, relations, objectAlias, negate, false, maxNumberOfItemsToReturn, sorter, groupByClause);
		}
		#endregion


		/// <summary>
		/// Implements the IPredicate ToQueryText method. Retrieves a ready to use text representation of the contained Predicate.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public override string ToQueryText(ref int uniqueMarker)
		{
			return ToQueryText(ref uniqueMarker, false);
		}


		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public override string ToQueryText(ref int uniqueMarker, bool inHavingClause)
		{
			if((_field==null) && (_operatorToUse != SetOperator.Exist))
			{
				return "";
			}

			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();

			StringBuilder queryText = new StringBuilder(1024);
			
			if(base.Negate)
			{
				queryText.Append("NOT ");
			}

			IEntityFieldCore[] setFieldList = new IEntityFieldCore[1];
			setFieldList[0] = _setField;
			IFieldPersistenceInfo[] setFieldPersistenceInfo = new IFieldPersistenceInfo[1];
			setFieldPersistenceInfo[0] = _persistenceInfoSetField; 
			IRetrievalQuery subQuery = base.DatabaseSpecificCreator.CreateSubQuery(setFieldList, setFieldPersistenceInfo, _setFilter, _maxNumberOfItemsToReturn,
					_setSorter, _setRelations, _groupByClause, ref uniqueMarker);

			string fieldName = string.Empty;
			if((_field!=null)&&(_operatorToUse!=SetOperator.Exist))
			{
				fieldName = base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfoField, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause);

				if(_field.ExpressionToApply!=null)
				{
					for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
					{
						base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
					}
				}
			}
			queryText.AppendFormat(null, "{0} {1} ({2})", 
				fieldName, 
				base.DatabaseSpecificCreator.ConvertSetOperator(_operatorToUse),
				subQuery.Command.CommandText);


			// add subquery parameters as well
			List<IDataParameter> parameters = new List<IDataParameter>();
			for (int i = 0; i < subQuery.Parameters.Count; i++)
			{
				parameters.Add((IDataParameter)subQuery.Parameters[i]);
			}
			// clear the subquery's command's parameter collection, as we're moving the parameters from one collection to another.
			subQuery.Parameters.Clear();
			for (int i = 0; i < parameters.Count; i++)
			{
				base.Parameters.Add(parameters[i]);
			}

			return queryText.ToString();
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="field"></param>
		/// <param name="setField"></param>
		/// <param name="persistenceInfoField"></param>
		/// <param name="persistenceInfoSetField"></param>
		/// <param name="operatorToUse"></param>
		/// <param name="setFilter"></param>
		/// <param name="setRelations"></param>
		/// <param name="objectAlias"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="maxNumberOfItemsToReturn"></param>
		/// <param name="setSorter"></param>
		/// <param name="groupByClause"></param>
		private void InitClass(IEntityFieldCore field, IEntityFieldCore setField, IFieldPersistenceInfo persistenceInfoField, 
				IFieldPersistenceInfo persistenceInfoSetField, SetOperator operatorToUse, IPredicate setFilter, IRelationCollection setRelations,
				string objectAlias, bool negate, bool selfServicing, long maxNumberOfItemsToReturn, ISortExpression setSorter,
				IGroupByCollection groupByClause)
		{
			_field=field;
			_setField = setField;
			_persistenceInfoField = persistenceInfoField;
			_persistenceInfoSetField = persistenceInfoSetField;
			_operatorToUse = operatorToUse;
			_setFilter = setFilter;
			_setRelations = setRelations;
			_objectAlias = objectAlias;
			_maxNumberOfItemsToReturn = maxNumberOfItemsToReturn;
			_setSorter = setSorter;
			_groupByClause = groupByClause;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldCompareSetPredicate;
		}


		#region Class Property Declarations
		/// <summary>
		/// Field used in the comparison expression (SelfServicing).
		/// </summary>
		/// <exception cref="InvalidOperationException">if this object was constructed using a non-selfservicing constructor.</exception>
		public virtual IEntityField Field
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				if(_field!=null)
				{
					return (IEntityField)_field; 
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Field used in the comparison expression (IEntityFieldCore).
		/// </summary>
		public virtual IEntityFieldCore FieldCore
		{
			get 
			{ 
				return _field; 
			}
		}

		/// <summary>
		/// Gets / sets persistenceInfo for field
		/// </summary>
		/// <exception cref="InvalidOperationException">When a value is set for this property and this object was created using a selfservicing constructor.</exception>
		public IFieldPersistenceInfo PersistenceInfoField
		{
			get
			{
				return _persistenceInfoField;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfoField = value;
			}
		}

		
		/// <summary>
		/// Field used in the subquery (the field the set is of) (SelfServicing).
		/// </summary>
		/// <exception cref="InvalidOperationException">if this object was constructed using a non-selfservicing constructor.</exception>
		public virtual IEntityField SetField
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				return (IEntityField)_setField; 
			}
		}

		/// <summary>
		/// Field used in the subquery (the field the set is of) (SelfServicing).
		/// </summary>
		public virtual IEntityFieldCore SetFieldCore
		{
			get 
			{ 
				return _setField; 
			}
		}

		/// <summary>
		/// Gets / sets persistenceInfo for Setfield
		/// </summary>
		/// <exception cref="InvalidOperationException">When a value is set for this property and this object was created using a selfservicing constructor.</exception>
		public IFieldPersistenceInfo PersistenceInfoSetField
		{
			get
			{
				return _persistenceInfoSetField;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfoSetField = value;
			}
		}

		/// <summary>
		/// Operator to use in the comparison
		/// </summary>
		public virtual SetOperator OperatorToUse
		{
			get { return _operatorToUse; }
			set { _operatorToUse = value; }
		}

		
		/// <summary>
		/// Gets / sets the set relations to use in the subquery.
		/// </summary>
		public virtual IRelationCollection SetRelations
		{
			get { return _setRelations;}
			set { _setRelations = value;}
		}


		/// <summary>
		/// Gets / sets the filter to use in the subquery
		/// </summary>
		public virtual IPredicate SetFilter
		{
			get { return _setFilter;}
			set { _setFilter = value;}
		}


		/// <summary>
		/// Wraps SetFilter in an IPredicateExpression instance
		/// </summary>
		public virtual IPredicateExpression SetFilterAsPredicateExpression
		{
			get
			{
				if(_setFilter!=null)
				{
					return new PredicateExpression(_setFilter);
				}
				else
				{
					return null;
				}
			}
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
				return _objectAlias;
			}
			set
			{
				_objectAlias = value;
			}
		}


		/// <summary>
		/// Gets / sets maxNumberOfItemsToReturn for the subquery. Default: 0 (return all rows)
		/// </summary>
		public long MaxNumberOfItemsToReturn
		{
			get
			{
				return _maxNumberOfItemsToReturn;
			}
			set
			{
				_maxNumberOfItemsToReturn = value;
			}
		}

		/// <summary>
		/// Gets / sets the setSorter expression to order the subquery results. Use it in combination with MaxNumberOfItemsToReturn set to 1
		/// </summary>
		public ISortExpression SetSorter
		{
			get
			{
				return _setSorter;
			}
			set
			{
				_setSorter = value;
			}
		}


		/// <summary>
		/// Gets / sets the groupByClause for this FieldCompareSetPredicate instance
		/// </summary>
		public IGroupByCollection GroupByClause
		{
			get
			{
				return _groupByClause;
			}
			set
			{
				_groupByClause = value;
			}
		}



		#endregion
	}
}
