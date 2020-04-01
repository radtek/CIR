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
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of a Field compare-range Values expression, using the following format:
	/// IEntityField(Core) ComparisonOperator Parameters (f.e. Foo IN (@Foo1, @Foo2 ... ))
	/// There is no check for types between the value specified and the specified IEntityField.
	/// </summary>
	[Serializable]
	public class FieldCompareRangePredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore        _field;
		private IFieldPersistenceInfo	_persistenceInfo;
		private List<object>            _values;
		private string					_objectAlias;

		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public FieldCompareRangePredicate()
		{
			InitClass(null, null, false, true, string.Empty, new object[0]);
		}


		#region Selfservicing Constructors
		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityField field, params object[] values)
		{
			InitClass(field, field, false, true, string.Empty, values);
		}


		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityField field, string objectAlias, params object[] values)
		{
			InitClass(field, field, false, true, objectAlias, values);
		}


		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityField field, bool negate, params object[] values)
		{
			InitClass(field, field, negate, true, string.Empty, values);
		}

		
		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityField field, string objectAlias, bool negate, params object[] values)
		{
			InitClass(field, field, negate, true, objectAlias, values);
		}
		#endregion


		#region Adapter Constructors
		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, params object[] values)
		{
			InitClass(field, persistenceInfo, false, false, string.Empty, values);
		}


		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string objectAlias, params object[] values)
		{
			InitClass(field, persistenceInfo, false, false, objectAlias, values);
		}

		
		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, bool negate, params object[] values)
		{
			InitClass(field, persistenceInfo, negate, false, string.Empty, values);
		}


		/// <summary>
		/// CTor. Creates Field IN (values) clause
		/// </summary>
		/// <param name="field">Field used in the comparison expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		/// <param name="values">Value range to set for the IN clause. Specify any range of values.
		/// If a single array is passed or an ArrayList, this will be converted to a range of values.</param>
		public FieldCompareRangePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string objectAlias, bool negate, params object[] values)
		{
			InitClass(field, persistenceInfo, negate, false, objectAlias, values);
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

			if(_values.Count<=0)
			{
				return "";
			}

			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();

			StringBuilder queryText = new StringBuilder(128);
			queryText.Append(base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause));
			queryText.Append(" ");

			if(_field.ExpressionToApply!=null)
			{
				for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
				{
					base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
				}
			}

			if(base.Negate)
			{
				queryText.Append("NOT ");
			}

			queryText.Append("IN (");

			// create parameters, one for each value
			for (int i = 0; i < _values.Count; i++)
			{
				if(i>0)
				{
					queryText.Append(", ");
				}

				IDataParameter parameter = base.DatabaseSpecificCreator.CreateParameter(_field, _persistenceInfo, ParameterDirection.Input, _values[i]);
				base.Parameters.Add(parameter);
				uniqueMarker++;
				parameter.ParameterName += uniqueMarker.ToString();

				queryText.Append(parameter.ParameterName);
			}
			queryText.Append(")");
			return queryText.ToString();
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
			if( _field == null )
			{
				return false;
			}

			object fieldValue = ((IEntityFieldCoreInterpret)_field).GetValue( entity );

			bool inRange = false;
			foreach( object rangeValue in _values )
			{
				if(rangeValue == null)
				{
					if(fieldValue == null)
					{
						// found a match
						inRange = true;
						break;
					}
					// not in range
					continue;
				}

				if( rangeValue.Equals( fieldValue ) )
				{
					// in range
					inRange = true;
					break;
				}
			}

			return (inRange ^ base.Negate);
		}


		/// <summary>
		/// Initializes the class.
		/// </summary>
		/// <param name="field"></param>
		/// <param name="persistenceInfo"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		/// <param name="values"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, bool negate, bool selfServicing, string objectAlias, params object[] values)
		{
			_field = field;
			_persistenceInfo = persistenceInfo;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldCompareRangePredicate;
			_objectAlias = objectAlias;

			_values = new List<object>();
			// convert the passed in set of values to a valid set of values. If an array is passed in, it has to be unwrapped. if an ICollection has been
			// passed in, it has to be unwrapped as well.
			for (int i = 0; i < values.Length; i++)
			{
				// check type of values[i]. If required, unwrap it.
				IList valueAsList = values[i] as IList;
				if(valueAsList!=null)
				{
					// unwrap IList. If this is a multi-dimensional array, it will create an exception
					foreach(object listValue in valueAsList)
					{
						_values.Add(listValue);
					}
					// done.
					continue;
				}
				else
				{
					// not a list, add the value directly
					_values.Add(values[i]);
				}
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
		/// Values to set for the IN Clause
		/// </summary>
		public virtual List<object> Values
		{
			get { return _values; }
			set { _values = value; }
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

		#endregion
        
	}
}