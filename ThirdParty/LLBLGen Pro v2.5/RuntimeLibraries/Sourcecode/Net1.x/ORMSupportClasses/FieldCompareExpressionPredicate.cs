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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of a Field compare-operator Expression expression, using the following format:
	/// IEntityField(Core) ComparisonOperator Expression (f.e. Foo = (Bar * 2))
	/// </summary>
	[Serializable]
	public class FieldCompareExpressionPredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore			_field;
		private IFieldPersistenceInfo		_persistenceInfo;
		private ComparisonOperator			_comparisonOperator;
		private IExpression					_expression;
		private	string						_objectAlias;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public FieldCompareExpressionPredicate()
		{
			InitClass(null, null, ComparisonOperator.Equal, null, false, false, string.Empty);
		}


		#region SelfServicing constructors
		/// <summary>
		/// CTor
		/// Selfservicing specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		public FieldCompareExpressionPredicate(IEntityField field, ComparisonOperator operatorToUse, IExpression expressionToCompare)
		{
			InitClass(field, field, operatorToUse, expressionToCompare, false, true, string.Empty);
		}

		/// <summary>
		/// CTor
		/// Selfservicing specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareExpressionPredicate(IEntityField field, ComparisonOperator operatorToUse, IExpression expressionToCompare, bool negate)
		{
			InitClass(field, field, operatorToUse, expressionToCompare, negate, true, string.Empty);
		}

		/// <summary>
		/// CTor
		/// Selfservicing specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldCompareExpressionPredicate(IEntityField field, ComparisonOperator operatorToUse, IExpression expressionToCompare, string objectAlias)
		{
			InitClass(field, field, operatorToUse, expressionToCompare, false, true, objectAlias);
		}

		/// <summary>
		/// CTor
		/// Selfservicing specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareExpressionPredicate(IEntityField field, ComparisonOperator operatorToUse, IExpression expressionToCompare, string objectAlias, bool negate)
		{
			InitClass(field, field, operatorToUse, expressionToCompare, negate, true, objectAlias);
		}

		#endregion

		#region Adapter constructors
		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		public FieldCompareExpressionPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator operatorToUse, 
				IExpression expressionToCompare)
		{
			InitClass(field, persistenceInfo, operatorToUse, expressionToCompare, false, false, string.Empty);
		}

		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareExpressionPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator operatorToUse, 
				IExpression expressionToCompare, bool negate)
		{
			InitClass(field, persistenceInfo, operatorToUse, expressionToCompare, negate, false, string.Empty);
		}

		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		public FieldCompareExpressionPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator operatorToUse, 
				IExpression expressionToCompare, string objectAlias)
		{
			InitClass(field, persistenceInfo, operatorToUse, expressionToCompare, false, false, objectAlias);
		}

		/// <summary>
		/// CTor
		/// Adapter specific
		/// </summary>
		/// <param name="field">Entityfield to compare</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="operatorToUse">Operator to use</param>
		/// <param name="expressionToCompare">Expression to compare with</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldCompareExpressionPredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator operatorToUse, 
				IExpression expressionToCompare, string objectAlias, bool negate)
		{
			InitClass(field, persistenceInfo, operatorToUse, expressionToCompare, negate, false, objectAlias);
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
				throw new ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();

			StringBuilder queryText = new StringBuilder(128);
			
			if(base.Negate)
			{
				queryText.Append("NOT ");
			}

			// create string from expression
			_expression.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
			string expressionAsString = _expression.ToQueryText(ref uniqueMarker, inHavingClause);

			queryText.AppendFormat(null, "{0} {1} {2}", 
				base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause), 
				base.DatabaseSpecificCreator.ConvertComparisonOperator(_comparisonOperator), 
				expressionAsString);

			// First the field's expression parameters
			if(_field.ExpressionToApply!=null)
			{
				for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
				{
					base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
				}
			}

			// then the expression's parameters. 
			for (int i = 0; i < _expression.Parameters.Count; i++)
			{
				base.Parameters.Add(_expression.Parameters[i]);
			}

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
			if(( _field == null ) || (_expression==null))
			{
				return false;
			}

			object fieldValue = ((IEntityFieldCoreInterpret)_field).GetValue( entity );
			object expressionValue = null;
			IExpressionInterpret expression = _expression as IExpressionInterpret;
			if( expression == null )
			{
				throw new ORMInterpretationException( "The expression to compare with isn't implementing IExpressionInterpret" );
			}

			expressionValue = expression.GetValue( entity );

			if( (fieldValue == null) || (fieldValue==DBNull.Value) || (expressionValue == null) )
			{
				return false;
			}

#if DOTNET10
			Comparer genericComparer = Comparer.Default;
#else
			Comparer genericComparer = Comparer.DefaultInvariant;
#endif
			bool toReturn = false;
			switch( _comparisonOperator )
			{
				case ComparisonOperator.Equal:
					toReturn = fieldValue.Equals( expressionValue );
					break;
				case ComparisonOperator.GreaterEqual:
					toReturn = (genericComparer.Compare( fieldValue, expressionValue ) >= 0);
					break;
				case ComparisonOperator.GreaterThan:
					toReturn = (genericComparer.Compare( fieldValue, expressionValue ) > 0);
					break;
				case ComparisonOperator.LessEqual:
					toReturn = (genericComparer.Compare( fieldValue, expressionValue ) <= 0);
					break;
				case ComparisonOperator.LesserThan:
					toReturn = (genericComparer.Compare( fieldValue, expressionValue ) < 0);
					break;
				case ComparisonOperator.NotEqual:
					toReturn = !fieldValue.Equals( expressionValue );
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
		/// <param name="expression"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ComparisonOperator comparisonOperator, 
			IExpression expression, bool negate, bool selfServicing, string objectAlias)
		{
			_field = field;
			_persistenceInfo = persistenceInfo;
			_comparisonOperator = comparisonOperator;
			_expression = expression;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldCompareExpressionPredicate;
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
		/// Operator to use in the comparison
		/// </summary>
		public virtual ComparisonOperator Operator
		{
			get { return _comparisonOperator; }
			set { _comparisonOperator = value; }
		}

		
		/// <summary>
		/// Gets / sets expressionToCompareWith
		/// </summary>
		public IExpression ExpressionToCompareWith
		{
			get
			{
				return _expression;
			}
			set
			{
				_expression = value;
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

		#endregion
	}
}
