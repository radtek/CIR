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
using System.Data;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of a Field compare-operator Value expression, using the following format:
	/// IEntityField(Core) ComparisonOperator Parameter (f.e. Foo = @Foo)
	/// There is no check for types between the value specified and the specified IEntityField.
	/// </summary>
	[Serializable]
	public class FieldCompareValuePredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore			_field;
		private IFieldPersistenceInfo		_persistenceInfo;
		private ComparisonOperator			_comparisonOperator;
		private object						_value;
		private	string						_objectAlias;
		private bool						_caseSensitiveCollation;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public FieldCompareValuePredicate()
		{
			InitClass(null, null, ComparisonOperator.Equal, null, false, true, string.Empty);
		}


		#region Selfservicing Constructors
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		public FieldCompareValuePredicate(IEntityField field, ComparisonOperator comparisonOperator)
		{
			InitClass(field, field, comparisonOperator, DetermineValueToUse(field), false, true, string.Empty);
		}

		
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		public FieldCompareValuePredicate(IEntityField field, ComparisonOperator comparisonOperator, object value)
		{
			InitClass(field, field, comparisonOperator, value, false, true, string.Empty);
		}


		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause
		/// </summary>
		/// <param name="field"></param>
		/// <param name="comparisonOperator"></param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareValuePredicate(IEntityField field, ComparisonOperator comparisonOperator, object value, bool negate)
		{
			InitClass(field, field, comparisonOperator, value, negate, true, string.Empty);
		}


		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldCompareValuePredicate(IEntityField field, ComparisonOperator comparisonOperator, object value, string objectAlias)
		{
			InitClass(field, field, comparisonOperator, value, false, true, objectAlias);
		}

		
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause
		/// </summary>
		/// <param name="field"></param>
		/// <param name="comparisonOperator"></param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareValuePredicate(IEntityField field, ComparisonOperator comparisonOperator, object value, string objectAlias, bool negate)
		{
			InitClass(field, field, comparisonOperator, value, negate, true, objectAlias);
		}
		#endregion


		#region Adapter Constructors
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		public FieldCompareValuePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator)
		{
			InitClass(field, persistenceInfo, comparisonOperator, DetermineValueToUse(field), false, false, string.Empty);
		}


		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		public FieldCompareValuePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, object value)
		{
			InitClass(field, persistenceInfo, comparisonOperator, value, false, false, string.Empty);
		}

		
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareValuePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, object value, bool negate)
		{
			InitClass(field, persistenceInfo, comparisonOperator, value, negate, false, string.Empty);
		}


		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldCompareValuePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, object value, string objectAlias)
		{
			InitClass(field, persistenceInfo, comparisonOperator, value, false, false, objectAlias);
		}

		
		/// <summary>
		/// CTor. Creates Field ComparisonOperator Parameter clause. The value to compare with is retrieved from the passed in field object.
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="comparisonOperator">Operator to use in the comparison</param>
		/// <param name="value">Value to set for the parameter</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareValuePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, object value, string objectAlias, bool negate)
		{
			InitClass(field, persistenceInfo, comparisonOperator, value, negate, false, objectAlias);
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
			if(_field==null)
			{
				return "";
			}

			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();
			string toReturn = string.Empty;

			if(((_value == null) || (_value == DBNull.Value)) && ((_comparisonOperator == ComparisonOperator.Equal) || (_comparisonOperator == ComparisonOperator.NotEqual)))
			{
				// compare with NULL, use FieldCompareNull predicate to get the snippet.
				FieldCompareNullPredicate nullPredicate = new FieldCompareNullPredicate(_field, _persistenceInfo, _objectAlias, (_comparisonOperator == ComparisonOperator.NotEqual));
				nullPredicate.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
				toReturn = nullPredicate.ToQueryText(ref uniqueMarker, inHavingClause);
				base.Parameters.AddRange(nullPredicate.Parameters);
			}
			else
			{
				StringBuilder queryText = new StringBuilder(128);
				
				if(base.Negate)
				{
					queryText.Append("NOT ");
				}

				// create parameter 
				IDataParameter parameter = null;
				if(_field.ExpressionToApply!=null)
				{
					parameter = base.DatabaseSpecificCreator.CreateParameter(_field.Name, ParameterDirection.Input, _value);
				}
				else
				{
					parameter = base.DatabaseSpecificCreator.CreateParameter(_field, _persistenceInfo, ParameterDirection.Input, _value);
				}
				uniqueMarker++;
				parameter.ParameterName += uniqueMarker.ToString();

				if( _caseSensitiveCollation && (_value is string) )
				{
					queryText.AppendFormat( null, "{0}({1}) {2} {3}",
						base.DatabaseSpecificCreator.ToUpperFunctionName(),
						base.DatabaseSpecificCreator.CreateFieldName( _field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause ),
						base.DatabaseSpecificCreator.ConvertComparisonOperator( _comparisonOperator ), parameter.ParameterName );
				}
				else
				{
					queryText.AppendFormat( null, "{0} {1} {2}",
						base.DatabaseSpecificCreator.CreateFieldName( _field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause ),
						base.DatabaseSpecificCreator.ConvertComparisonOperator( _comparisonOperator ), parameter.ParameterName );
				}
				// first add expression parameters... 
				if(_field.ExpressionToApply!=null)
				{
					for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
					{
						base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
					}
				}
				// ... then add the value parameter
				base.Parameters.Add(parameter);

				toReturn = queryText.ToString();
			}
			return toReturn;
		}


		/// <summary>
		/// Interprets this predicate on the passed in entity
		/// </summary>
		/// <param name="entity">The entity to interpret this predicate on</param>
		/// <returns>
		/// true if the predicate interpretation resolves to true, otherwise false.
		/// </returns>
		protected override bool InterpretPredicate( IEntityCore entity )
		{
			if(_field == null) 
			{
				return false;
			}

			object fieldValue = ((IEntityFieldCoreInterpret)_field).GetValue( entity );
			object valueToCompareWith = _value;

			if((fieldValue == null)||(fieldValue==DBNull.Value))
			{
				return false;
			}
			Type typeFieldValue = fieldValue.GetType();
			Type typeValueToCompareWith = valueToCompareWith.GetType();
			if(typeFieldValue != typeValueToCompareWith)
			{
				try
				{
					valueToCompareWith = Convert.ChangeType(valueToCompareWith, typeFieldValue, null);
				}
				catch
				{
					// conversion failed.
					throw new ORMInterpretationException(
						string.Format("Field value and value to compare with aren't of the same type. Field value is of type '{0}', value to compare with is of type '{1}'",
						typeFieldValue, typeValueToCompareWith));
				}
			}

#if DOTNET10
			Comparer genericComparer = Comparer.Default;
#else
			Comparer genericComparer = Comparer.DefaultInvariant;
#endif
			bool toReturn = false;
			string valueAsString = valueToCompareWith as string;
			switch( _comparisonOperator )
			{
				case ComparisonOperator.Equal:
					if( valueAsString != null )
					{
						toReturn = (string.Compare( fieldValue.ToString(), valueAsString, _caseSensitiveCollation, CultureInfo.InvariantCulture ) == 0);
					}
					else
					{
						toReturn = fieldValue.Equals( valueToCompareWith );
					}
					break;
				case ComparisonOperator.GreaterEqual:
					toReturn = (genericComparer.Compare( fieldValue, valueToCompareWith ) >= 0);
					break;
				case ComparisonOperator.GreaterThan:
					toReturn = (genericComparer.Compare( fieldValue, valueToCompareWith ) > 0);
					break;
				case ComparisonOperator.LessEqual:
					toReturn = (genericComparer.Compare( fieldValue, valueToCompareWith ) <= 0);
					break;
				case ComparisonOperator.LesserThan:
					toReturn = (genericComparer.Compare( fieldValue, valueToCompareWith ) < 0);
					break;
				case ComparisonOperator.NotEqual:
					if( valueAsString != null )
					{
						toReturn = (string.Compare( fieldValue.ToString(), valueAsString, _caseSensitiveCollation, CultureInfo.InvariantCulture ) != 0);
					}
					else
					{
						toReturn = !fieldValue.Equals( valueToCompareWith );
					}
					break;
			}

			return (toReturn ^ base.Negate);
		}


		/// <summary>
		/// Initializes the class.
		/// </summary>
		/// <param name="field"></param>
		/// <param name="persistenceInfo"></param>
		/// <param name="comparisonOperator"></param>
		/// <param name="value"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, 
				object value, bool negate, bool selfServicing, string objectAlias)
		{
			_field = field;
			_persistenceInfo = persistenceInfo;
			_comparisonOperator = comparisonOperator;
			_value = value;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldCompareValuePredicate;
			_objectAlias = objectAlias;
			_caseSensitiveCollation = false;
		}


		/// <summary>
		/// Returns the field's value to use: if the field is a PK field AND it is changed, use the DbValue value, otherwise the currentvalue
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		private object DetermineValueToUse(IEntityFieldCore field)
		{
			if(field.IsPrimaryKey && field.IsChanged && (field.DbValue!=null))
			{
				return field.DbValue;
			}
			else
			{
				return field.CurrentValue;
			}
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
				return _persistenceInfo;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfo = value;
			}
		}
		
		/// <summary>
		/// Operator to use in the comparison
		/// </summary>
		public virtual ComparisonOperator Operator
		{
			get { return _comparisonOperator; }
			set { _comparisonOperator = value; }
		}
		
		/// <summary>
		/// Value to set for the parameter
		/// </summary>
		public virtual object Value
		{
			get { return _value; }
			set { _value = value; }
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
		/// Gets / sets caseSensitiveCollation flag. If set to true, the UPPER() function (or db specific equivalent) is applied to the field, 
		/// IF the value specified is a string value. You can use this to do a case insensitive compare on a case sensitive database. Default: false
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
