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
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// FieldFullTextSearchPredicate class. 
	/// CONTAINS(IEntityField(Core), Parameter) (f.e. CONTAINS(Foo, @Foo) )<br/>
	/// FREETEXT(IEntityField(Core), Parameter) (f.e. FREETEXT(Foo, @Foo) )<br/>
	/// SqlServer specific. <br/>
	/// On SqlServer 2005, also multi-field CONTAINS/FREETEXT predicates are supported. 
	/// </summary>
	/// <remarks>
	/// This predicate isn't supported for in-memory filtering.
	/// </remarks>
	[Serializable]
	public class FieldFullTextSearchPredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore		_field;
		private IFieldPersistenceInfo	_persistenceInfo;
		private string					_pattern, _objectAlias;
		private FullTextSearchOperator	_operatorToUse;
		private IList _fieldsList;
		private IList _persistenceInfosFieldsList;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public FieldFullTextSearchPredicate()
		{
			InitClass(null, null, string.Empty, FullTextSearchOperator.Contains, false, true, string.Empty);
		}



		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFields">The entity fields to include in the CONTAINS/FREETEXT fieldlist. List can contain EntityField or EntityField2 field objects.</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <remarks>SqlServer 2005 specific. To set the object alias for the fields, use the field object's method SetObjectAlias instead</remarks>
		public FieldFullTextSearchPredicate(IList entityFields, FullTextSearchOperator operatorToUse, string pattern)
		{
			if((entityFields == null) || (entityFields.Count <= 0))
			{
				throw new ArgumentNullException("entityFields can't be null nor empty.", "entityFields");
			}
			InitClass(entityFields, pattern, operatorToUse, false, (entityFields[0] is IEntityField), string.Empty);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFields">The entity fields to include in the CONTAINS/FREETEXT fieldlist. List can contain EntityField or EntityField2 field objects.</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		/// <remarks>SqlServer 2005 specific. To set the object alias for the fields, use the field object's method SetObjectAlias instead</remarks>
		public FieldFullTextSearchPredicate(IList entityFields, FullTextSearchOperator operatorToUse, string pattern, bool negate)
		{
			if((entityFields == null) || (entityFields.Count <= 0))
			{
				throw new ArgumentNullException("entityFields can't be null nor empty.", "entityFields");
			}
			InitClass(entityFields, pattern, operatorToUse, negate, (entityFields[0] is IEntityField), string.Empty);
		}


		#region Selfservicing constructors
		/// <summary>
		/// CTor
		/// SelfServicing specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		public FieldFullTextSearchPredicate(IEntityField field, FullTextSearchOperator operatorToUse, string pattern)
		{
			InitClass(field, field, pattern, operatorToUse, false, true, string.Empty);
		}


		/// <summary>
		/// CTor
		/// SelfServicing specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldFullTextSearchPredicate(IEntityField field, FullTextSearchOperator operatorToUse, string pattern, bool negate)
		{
			InitClass(field, field, pattern, operatorToUse, negate, true, string.Empty);
		}


		/// <summary>
		/// CTor
		/// SelfServicing specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldFullTextSearchPredicate(IEntityField field, FullTextSearchOperator operatorToUse, string pattern, string objectAlias)
		{
			InitClass(field, field, pattern, operatorToUse, false, true, objectAlias);
		}


		/// <summary>
		/// CTor
		/// SelfServicing specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldFullTextSearchPredicate(IEntityField field, FullTextSearchOperator operatorToUse, string pattern, string objectAlias, bool negate)
		{
			InitClass(field, field, pattern, operatorToUse, negate, true, objectAlias);
		}
		#endregion

		#region Adapter constructors
		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="persistenceInfo">The persistence info for the field</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		public FieldFullTextSearchPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, FullTextSearchOperator operatorToUse, string pattern)
		{
			InitClass(field, persistenceInfo, pattern, operatorToUse, false, false, string.Empty);
		}


		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="persistenceInfo">The persistence info for the field</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldFullTextSearchPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, FullTextSearchOperator operatorToUse, string pattern, bool negate)
		{
			InitClass(field, persistenceInfo, pattern, operatorToUse, negate, false, string.Empty);
		}


		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="persistenceInfo">The persistence info for the field</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldFullTextSearchPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, FullTextSearchOperator operatorToUse, string pattern, string objectAlias)
		{
			InitClass(field, persistenceInfo, pattern, operatorToUse, false, false, objectAlias);
		}


		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="persistenceInfo">The persistence info for the field</param>
		/// <param name="operatorToUse">operatore to use</param>
		/// <param name="pattern">pattern (incl. full text search commands)</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldFullTextSearchPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, FullTextSearchOperator operatorToUse, string pattern, string objectAlias, bool negate)
		{
			InitClass(field, persistenceInfo, pattern, operatorToUse, negate, false, objectAlias);
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
			if((_field == null) && (_fieldsList == null))
			{
				return "";
			}

			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();

			StringBuilder queryText = new StringBuilder(64);
			
			if(base.Negate)
			{
				queryText.Append("NOT ");
			}

			// create parameter 
			uniqueMarker++;
			string parameterName = string.Empty;
			if(TargetIsFieldList)
			{
				parameterName = "FieldsList";
			}
			else
			{
				parameterName = _field.Name;
			}
			IDataParameter parameter = base.DatabaseSpecificCreator.CreateLikeParameter(parameterName, _pattern);
			parameter.ParameterName += uniqueMarker.ToString();
			parameter.Value = _pattern;
			base.Parameters.Add(parameter);

			if(TargetIsFieldList)
			{
				StringBuilder targetBuilder = new StringBuilder();
				for(int i = 0; i < _fieldsList.Count; i++)
				{
					if(i > 0)
					{
						targetBuilder.Append(", ");
					}
					IEntityFieldCore field = (IEntityFieldCore)_fieldsList[i];
					targetBuilder.Append(
						base.DatabaseSpecificCreator.CreateFieldName(field, (IFieldPersistenceInfo)_persistenceInfosFieldsList[i], field.Name, field.ObjectAlias, ref uniqueMarker, inHavingClause));
				}
				queryText.AppendFormat(null, "{0}(({1}), {2})", _operatorToUse.ToString(), targetBuilder.ToString(), parameter.ParameterName);
			}
			else
			{
				queryText.AppendFormat(null, "{0}({1}, {2})", _operatorToUse.ToString(), 
						base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause), 
						parameter.ParameterName);
			}
			return queryText.ToString();
		}


		/// <summary>
		/// Initializes the class
		/// </summary>
		/// <param name="field"></param>
		/// <param name="persistenceInfo"></param>
		/// <param name="pattern"></param>
		/// <param name="operatorToUse"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string pattern, FullTextSearchOperator operatorToUse, bool negate, bool selfServicing, string objectAlias)
		{
			_field = field;
			_persistenceInfo = persistenceInfo;
			_pattern = pattern;
			_operatorToUse = operatorToUse;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldFullTextSearchPredicate;
			_objectAlias = objectAlias;
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="entityFields">The entity fields.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="negate">if set to <c>true</c> [negate].</param>
		/// <param name="selfServicing">if set to <c>true</c> [self servicing].</param>
		/// <param name="objectAlias">The object alias.</param>
		private void InitClass(IList entityFields, string pattern, FullTextSearchOperator operatorToUse, bool negate, bool selfServicing, string objectAlias)
		{
			_field = null;
			_persistenceInfo = null;
			_fieldsList = entityFields;
			_persistenceInfosFieldsList = null;
			if(selfServicing)
			{
				_persistenceInfosFieldsList = entityFields;
			}
			_pattern = pattern;
			_operatorToUse = operatorToUse;
			base.Negate = negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldFullTextSearchPredicate;
			_objectAlias = objectAlias;
		}



		#region Class Property Declarations
		/// <summary>
		/// Returns true if the target of this predicate is a list of fields instead of a single field. 
		/// </summary>
		public bool TargetIsFieldList
		{
			get { return ((_field == null) && (_fieldsList != null)); }
		}

		/// <summary>
		/// Field used in the comparison expression (SelfServicing).
		/// </summary>
		/// <exception cref="InvalidOperationException">if this object was constructed using a non-selfservicing constructor or when the predicate was constructed with a fieldslist.</exception>
		public virtual IEntityField Field
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				if(TargetIsFieldList)
				{
					throw new InvalidOperationException("This predicate targets multiple fields. Please retrieve the FieldsList instead.");
				}
				return (IEntityField)_field; 
			}
		}

		/// <summary>
		/// Field used in the comparison expression (IEntityFieldCore).
		/// </summary>
		public virtual IEntityFieldCore FieldCore
		{
			get 
			{
				if(TargetIsFieldList)
				{
					throw new InvalidOperationException("This predicate targets multiple fields. Please retrieve the FieldsList instead.");
				}
				return _field; 
			}
		}

		/// <summary>
		/// Gets / sets persistenceInfo for field
		/// </summary>
		/// <exception cref="InvalidOperationException">When a value is set for this property and this object was created using a selfservicing constructor.</exception>
		public IFieldPersistenceInfo PersistenceInfo
		{
			get
			{
				if(TargetIsFieldList)
				{
					throw new InvalidOperationException("This predicate targets multiple fields. Please retrieve the PersistenceInfosFieldsList instead.");
				}
				return _persistenceInfo;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				if(TargetIsFieldList)
				{
					throw new InvalidOperationException("This predicate targets multiple fields. Please set the PersistenceInfosFieldsList instead.");
				}
				_persistenceInfo = value;
			}
		}
		
		/// <summary>
		/// Gets / sets the pattern to use in a Field LIKE Pattern clause. 
		/// </summary>
		public virtual string Pattern
		{
			get { return _pattern; }
			set 
			{ 
				_pattern = value; 
			}
		}


		/// <summary>
		/// Gets / sets operatorToUse
		/// </summary>
		public FullTextSearchOperator OperatorToUse
		{
			get
			{
				return _operatorToUse;
			}
			set
			{
				_operatorToUse = value;
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
		/// Gets / sets persistenceInfosFieldsList
		/// </summary>
		public IList PersistenceInfosFieldsList
		{
			get
			{
				return _persistenceInfosFieldsList;
			}
			set
			{
				_persistenceInfosFieldsList = value;
			}
		}


		/// <summary>
		/// Gets / sets the entity fields to include in the CONTAINS/FREETEXT fieldlist. List can contain EntityField or EntityField2 field objects.
		/// </summary>
		/// <remarks>SqlServer 2005 specific</remarks>
		public IList FieldsList
		{
			get
			{
				if(!TargetIsFieldList)
				{
					throw new InvalidOperationException("This predicate targets a single field. Please call the Field or FieldCore properties instead.");
				}
				return _fieldsList;
			}
		}

		#endregion
	}
}
