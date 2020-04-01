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
	/// Implementation of a Field Between ValueBegin And ValueEnd expression, using the following format:
	/// IEntityField(Core) Between Parameter1 And Parameter2 (f.e Foo BETWEEN @Foo1 AND Foo2)
	/// There is no check for types between the values specified and the specified IEntityField.
	/// </summary>
	[Serializable]
	public class FieldBetweenPredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore		_field;
		private IFieldPersistenceInfo	_persistenceInfo, _persistenceInfoBegin, _persistenceInfoEnd;
		private object					_valueBegin, _valueEnd;
		private IEntityFieldCore		_fieldBegin, _fieldEnd;
		private string					_objectAlias;
		private bool					_beginIsField, _endIsField;
		#endregion
		
		/// <summary>
		/// CTor
		/// </summary>
		public FieldBetweenPredicate()
		{
			InitClass(null, null, null, null, false, true, string.Empty);
		}

		#region SelfServicing Constructors
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Self servicing version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		public FieldBetweenPredicate(IEntityField field, object valueBegin, object valueEnd)
		{
			InitClass(field, field, valueBegin, valueEnd, false, true, string.Empty);
		}


		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Self servicing version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldBetweenPredicate(IEntityField field, object valueBegin, object valueEnd, string objectAlias)
		{
			InitClass(field, field, valueBegin, valueEnd, false, true, objectAlias);
		}

		
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Self servicing version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldBetweenPredicate(IEntityField field, object valueBegin, object valueEnd, bool negate)
		{
			InitClass(field, field, valueBegin, valueEnd, negate, true, string.Empty);
		}

		
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Self servicing version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldBetweenPredicate(IEntityField field, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			InitClass(field, field, valueBegin, valueEnd, negate, true, objectAlias);
		}
		#endregion

		#region Adapter Constructors
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression. (Adapter version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		public FieldBetweenPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, object valueBegin, object valueEnd)
		{
			InitClass(field, persistenceInfo, valueBegin, valueEnd, false, false, string.Empty);
		}


		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression. (Adapter version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldBetweenPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, object valueBegin, object valueEnd, string objectAlias)
		{
			InitClass(field, persistenceInfo, valueBegin, valueEnd, false, false, objectAlias);
		}

		
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Adapter version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldBetweenPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, object valueBegin, object valueEnd, bool negate)
		{
			InitClass(field, persistenceInfo, valueBegin, valueEnd, negate, false, string.Empty);
		}

		
		/// <summary>
		/// CTor. Creates the Field Between Value1 And Value2 expression (Adapter version)
		/// </summary>
		/// <param name="field">Field used in the Between expression</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="valueBegin">Begin value in the Between clause. Can be a field object</param>
		/// <param name="valueEnd">End value in the Between clause. Can be a field object</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldBetweenPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			InitClass(field, persistenceInfo, valueBegin, valueEnd, negate, false, objectAlias);
		}
		#endregion

		/// <summary>
		/// Implements the IPredicate ToQueryText method. Retrieves a ready to use text representation of the contained Predicate.
		/// The two parameters for begin and end value are constructed using the field's name plus the postfixes 'Begin' and 'End'.
		/// Generates SQL-92 syntaxis for BETWEEN, which is accepted by all databases known. 
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

			StringBuilder queryText = new StringBuilder(128);
			queryText.Append(base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause));

			if(_field.ExpressionToApply!=null)
			{
				for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
				{
					base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
				}
			}

			if(base.Negate)
			{
				queryText.Append(" NOT");
			}

			string beginName = string.Empty;
			string endName = string.Empty;
			if(_beginIsField)
			{
				beginName = base.DatabaseSpecificCreator.CreateFieldName(_fieldBegin, _persistenceInfoBegin, _fieldBegin.Name, _fieldBegin.ObjectAlias, ref uniqueMarker, inHavingClause);
				if(_fieldBegin.ExpressionToApply!=null)
				{
					for (int i = 0; i < _fieldBegin.ExpressionToApply.Parameters.Count; i++)
					{
						base.Parameters.Add(_fieldBegin.ExpressionToApply.Parameters[i]);
					}
				}
			}
			else
			{
				IDataParameter parameterBegin = base.DatabaseSpecificCreator.CreateParameter(_field, _persistenceInfo, ParameterDirection.Input, _valueBegin);
				uniqueMarker++;
				parameterBegin.ParameterName += uniqueMarker.ToString();
				base.Parameters.Add(parameterBegin);
				beginName = parameterBegin.ParameterName;
			}

			if(_endIsField)
			{
				endName = base.DatabaseSpecificCreator.CreateFieldName(_fieldEnd, _persistenceInfoEnd, _fieldEnd.Name, _fieldEnd.ObjectAlias, ref uniqueMarker, inHavingClause);
				if(_fieldEnd.ExpressionToApply!=null)
				{
					for (int i = 0; i < _fieldEnd.ExpressionToApply.Parameters.Count; i++)
					{
						base.Parameters.Add(_fieldEnd.ExpressionToApply.Parameters[i]);
					}
				}
			}
			else
			{
				IDataParameter parameterEnd = base.DatabaseSpecificCreator.CreateParameter(_field, _persistenceInfo, ParameterDirection.Input, _valueEnd);
				uniqueMarker++;
				parameterEnd.ParameterName += uniqueMarker.ToString();
				base.Parameters.Add(parameterEnd);
				endName = parameterEnd.ParameterName;
			}

			queryText.AppendFormat(null, " BETWEEN {0} AND {1}", beginName, endName);

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

			object fieldValue = ((IEntityFieldCoreInterpret)_field).GetValue( entity );;
			object beginValue = null;
			object endValue = null;

			if( _beginIsField )
			{
				beginValue = ((IEntityFieldCoreInterpret)_fieldBegin).GetValue( entity );
			}
			else
			{
				beginValue = _valueBegin;
			}

			if( _endIsField )
			{
				endValue = ((IEntityFieldCoreInterpret)_fieldEnd).GetValue( entity );
			}
			else
			{
				endValue = _valueEnd;
			}
			
			if(( fieldValue == null )||(fieldValue==DBNull.Value)||(beginValue==null)||(beginValue==DBNull.Value)||(endValue==null)||(endValue==DBNull.Value))
			{
				// always return false in this case
				return false;
			}

			// a = b between c resolves to true if (a>=b) and (a<=c)
			Comparer genericComparer = Comparer.DefaultInvariant;
			return (((genericComparer.Compare( fieldValue, beginValue ) >= 0) && (genericComparer.Compare( fieldValue, endValue ) <= 0)) ^ base.Negate);
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		/// <param name="field"></param>
		/// <param name="persistenceInfo"></param>
		/// <param name="valueBegin"></param>
		/// <param name="valueEnd"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, object valueBegin, object valueEnd, 
				bool negate, bool selfServicing, string objectAlias)
		{
			_field=field;
			_persistenceInfo = persistenceInfo;
			_fieldBegin = valueBegin as IEntityFieldCore;
			_fieldEnd = valueEnd as IEntityFieldCore;
			_beginIsField = (_fieldBegin != null);
			_endIsField = (_fieldEnd != null);
			_valueBegin = valueBegin;
			_valueEnd = valueEnd;
			base.Negate = negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldBetweenPredicate;
			_persistenceInfoBegin = null;
			_persistenceInfoEnd = null;
			if(selfServicing)
			{
				_persistenceInfoBegin = (IFieldPersistenceInfo)_fieldBegin;
				_persistenceInfoEnd = (IFieldPersistenceInfo)_fieldEnd;
			}

			_objectAlias = objectAlias;
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
		/// Gets / sets valueBegin
		/// </summary>
		public object ValueBegin
		{
			get
			{
				return _valueBegin;
			}
			set
			{
				_valueBegin = value;
			}
		}

		/// <summary>
		/// Gets / sets valueEnd
		/// </summary>
		public object ValueEnd
		{
			get
			{
				return _valueEnd;
			}
			set
			{
				_valueEnd = value;
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
		/// Gets beginIsField, flag to signal if the ValueBegin is a field object
		/// </summary>
		public bool BeginIsField
		{
			get
			{
				return _beginIsField;
			}
		}


		/// <summary>
		/// Gets endIsField, flag to signal if the ValueEnd is a field object
		/// </summary>
		public bool EndIsField
		{
			get
			{
				return _endIsField;
			}
		}

		/// <summary>
		/// Gets or sets the persistence info for the BeginValue, if that's a field
		/// </summary>
		/// <value></value>
		public IFieldPersistenceInfo PersistenceInfoBegin
		{
			get
			{
				return _persistenceInfoBegin;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfoBegin = value;
			}
		}

		/// <summary>
		/// Gets or sets the persistence info for the EndValue, if that's a field
		/// </summary>
		/// <value></value>
		public IFieldPersistenceInfo PersistenceInfoEnd
		{
			get
			{
				return _persistenceInfoEnd;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfoEnd = value;
			}
		}

		/// <summary>
		/// Gets the field which is the ValueBegin
		/// </summary>
		/// <value></value>
		public virtual IEntityField FieldBegin
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				return (IEntityField)_fieldBegin; 
			}
		}

		/// <summary>
		/// Gets the field which is the ValueEnd
		/// </summary>
		/// <value></value>
		public virtual IEntityField FieldEnd
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				return (IEntityField)_fieldEnd; 
			}
		}

		/// <summary>
		/// Gets the fieldcore which is the ValueBegin
		/// </summary>
		/// <value></value>
		public virtual IEntityFieldCore FieldBeginCore
		{
			get 
			{ 
				return _fieldBegin; 
			}
		}

		/// <summary>
		/// Gets the fieldcore which is the ValueEnd
		/// </summary>
		/// <value></value>
		public virtual IEntityFieldCore FieldEndCore
		{
			get 
			{ 
				return _fieldEnd; 
			}
		}

		#endregion
	}
}
