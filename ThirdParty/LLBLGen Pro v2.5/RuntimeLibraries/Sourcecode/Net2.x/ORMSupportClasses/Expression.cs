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
using System.Text;
using System.Data;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Expression class which defines field expressions which are
	/// applied to fields in a select list, in update queries or in field predicates.
	/// <br/>
	/// Valid expressions:
	/// <list type="ul">
	/// <item>Field</item>
	/// <item>Field ExOp Field</item>
	/// <item>Field ExOp Value</item>
	/// <item>Field ExOp Expression</item>
	/// <item>Value ExOp Field</item>
	/// <item>Value ExOp Expression</item>
	/// <item>Expression ExOp Field</item>
	/// <item>Expression ExOp Value</item>
	/// </list>
	/// Use one of the constructors to create the particular expression object.
	/// </summary>
	/// <remarks>Values are transformed into parameters. The type of the parameter is determined of the field in the expression.
	/// <br/>
	/// You can also use EntityProperty instances instead of EntityField(2) instances, though the Expression instance then has to be used solely for
	/// in-memory actions.
	/// </remarks>
	[Serializable]
	public class Expression : IExpression, ISerializable, IExpressionInterpret
	{
		#region Class Member Declarations
		private IExpressionElement	_leftOperand, _rightOperand;
		private ExOp				_operator;

		[NonSerialized]
		private List<IDataParameter>	_parameters;
		[NonSerialized]
		private IDbSpecificCreator	_creator;
		#endregion

		#region Constructors
		/// <summary>
		/// CTor
		/// </summary>
		/// <remarks>Empty constructor, do not use, use one of the constructor overloads to create an expression instance.</remarks>
		public Expression()
		{
			InitClass();
			_leftOperand = null;
			_rightOperand = null;
			_operator = ExOp.None;
		}

        
		/// <summary>
		/// CTor for (expression) operator (expression) expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is an IExpression implementation</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is an IExpression implementation</param>
		public Expression(IExpression leftOperand, ExOp operatorToUse, IExpression rightOperand)
		{
			InitClass();
			_leftOperand = new ExpressionElement<IExpression>(ExpressionElementType.Expression, leftOperand);
			_rightOperand = new ExpressionElement<IExpression>( ExpressionElementType.Expression, rightOperand );
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for value operator (expression) expressions
		/// </summary>
		/// <param name="leftOperand">the left operand, which is a value</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is an expression</param>
		public Expression(object leftOperand, ExOp operatorToUse, IExpression rightOperand)
		{
			InitClass();
			_leftOperand = ConvertObjectOperandToExpressionElement( leftOperand );
			_rightOperand = new ExpressionElement<IExpression>(ExpressionElementType.Expression, rightOperand);
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for (expression) operator value expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is an IExpression implementation</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is a value</param>
		public Expression(IExpression leftOperand, ExOp operatorToUse, object rightOperand)
		{
			InitClass();
			_leftOperand = new ExpressionElement<IExpression>(ExpressionElementType.Expression, leftOperand);
			_rightOperand = ConvertObjectOperandToExpressionElement(rightOperand);
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for single field expressions. 
		/// </summary>
		/// <param name="field">the only element in this expression</param>
		public Expression(IEntityFieldCore field)
		{
			InitClass();
			_leftOperand = new ExpressionFieldElement(ExpressionElementType.Field, field, field as IFieldPersistenceInfo);
			_rightOperand = null;
			_operator = ExOp.None;
		}


		/// <summary>
		/// CTor for field operator field expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is a field</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is a field</param>
		public Expression( IEntityFieldCore leftOperand, ExOp operatorToUse, IEntityFieldCore rightOperand )
		{
			InitClass();
			_leftOperand = new ExpressionFieldElement( ExpressionElementType.Field, leftOperand, leftOperand as IFieldPersistenceInfo );
			_rightOperand = new ExpressionFieldElement( ExpressionElementType.Field, rightOperand, rightOperand as IFieldPersistenceInfo );
			_operator = operatorToUse;
		}

		
		/// <summary>
		/// CTor for field operator value expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is a field</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is a value</param>
		public Expression( IEntityFieldCore leftOperand, ExOp operatorToUse, object rightOperand )
		{
			InitClass();
			_leftOperand = new ExpressionFieldElement( ExpressionElementType.Field, leftOperand, leftOperand as IFieldPersistenceInfo );
			_rightOperand = ConvertObjectOperandToExpressionElement( rightOperand );
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for field operator (expression) expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is a field</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is an IExpression implementation</param>
		public Expression( IEntityFieldCore leftOperand, ExOp operatorToUse, IExpression rightOperand )
		{
			InitClass();
			_leftOperand = new ExpressionFieldElement( ExpressionElementType.Field, leftOperand, leftOperand as IFieldPersistenceInfo );
			_rightOperand = new ExpressionElement<IExpression>(ExpressionElementType.Expression, rightOperand);
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for value operator field expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is a value</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is a field</param>
		public Expression( object leftOperand, ExOp operatorToUse, IEntityFieldCore rightOperand )
		{
			InitClass();
			_leftOperand = ConvertObjectOperandToExpressionElement( leftOperand );
			_rightOperand = new ExpressionFieldElement( ExpressionElementType.Field, rightOperand, rightOperand as IFieldPersistenceInfo );
			_operator = operatorToUse;
		}


		/// <summary>
		/// CTor for (expression) operator field expressions. 
		/// </summary>
		/// <param name="leftOperand">the left operand, which is an IExpression implementation</param>
		/// <param name="operatorToUse">operator to use in this expression</param>
		/// <param name="rightOperand">the right operand, which is a field</param>
		public Expression( IExpression leftOperand, ExOp operatorToUse, IEntityFieldCore rightOperand )
		{
			InitClass();
			_leftOperand = new ExpressionElement<IExpression>(ExpressionElementType.Expression, leftOperand);
			_rightOperand = new ExpressionFieldElement( ExpressionElementType.Field, rightOperand, rightOperand as IFieldPersistenceInfo );
			_operator = operatorToUse;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
		protected Expression(SerializationInfo info, StreamingContext context)
		{
			InitClass();
			_leftOperand = (IExpressionElement)info.GetValue("_leftOperand", typeof(IExpressionElement));
			_rightOperand = (IExpressionElement)info.GetValue("_rightOperand", typeof(IExpressionElement));
			_operator = (ExOp)info.GetValue("_operator", typeof(ExOp));
		}

		#endregion


		/// <summary>
		/// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"></see>) for this serialization.</param>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_leftOperand", _leftOperand, typeof(IExpressionElement));
			info.AddValue("_rightOperand", _rightOperand, typeof(IExpressionElement));
			info.AddValue("_operator", _operator, typeof(ExOp));
		}


		/// <summary>
		/// Retrieves a ready to use text representation of the contained expression. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the expression and also in the expression(s) containing the expression.</param>
		/// <returns>The contained expression in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		public string ToQueryText(ref int uniqueMarker)
		{
			return ToQueryText(ref uniqueMarker, false);
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained expression. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the expression and also in the expression(s) containing the expression.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained expression in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		public virtual string ToQueryText(ref int uniqueMarker, bool inHavingClause)
		{
			if(_creator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			StringBuilder queryText = new StringBuilder(128);
			_parameters.Clear();

			if(_operator == ExOp.None)
			{
				// just a left operand
				OperandToText(ref queryText, _leftOperand, ref uniqueMarker, true, inHavingClause);
			}
			else
			{
				// 2 operands. 
				OperandToText(ref queryText, _leftOperand, ref uniqueMarker, true, inHavingClause);
				queryText.AppendFormat(null, " {0} ", _creator.ConvertExpressionOperator(_operator));
				OperandToText(ref queryText, _rightOperand, ref uniqueMarker, false, inHavingClause);
			}

			return queryText.ToString();
		}


		/// <summary>
		/// Converts the object operand to expression element.
		/// </summary>
		/// <param name="operand">The operand.</param>
		/// <returns></returns>
		protected virtual IExpressionElement ConvertObjectOperandToExpressionElement( object operand )
		{
			IExpressionElement toReturn = null;
			if( operand is IDbFunctionCall )
			{
				toReturn = new ExpressionElement<IDbFunctionCall>( ExpressionElementType.FunctionCall, (IDbFunctionCall)operand );
			}
			else
			{
				toReturn = new ExpressionElement<object>( ExpressionElementType.Value, operand );
			}

			return toReturn;
		}


		/// <summary>
		/// Produces the value for this expression for the entity passed in. This routine is used by IExpressionInterpret.GetValue and is used
		/// to evaluate an expression at runtime for in-memory filtering/sorting.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>The value the expression resolves to based on the entity passed in. Returns DBNull.Value if it resolves to null</returns>
		protected virtual object PerformGetValue( IEntityCore entity )
		{
			object leftOperandValue = null;
			object rightOperandValue = null;

			object resultValue = DBNull.Value;

			if( _operator == ExOp.None )
			{
				// just 1 operand, left
				if( _leftOperand == null )
				{
					throw new ORMInterpretationException( "The expression has just 1 operand and the operand is null" );
				}
				resultValue = OperandToValue( _leftOperand, entity );
			}
			else
			{
				// two operands
				if( _leftOperand == null )
				{
					throw new ORMInterpretationException( "The expression has its left operand set to null. Can't resolve expression." );
				}
				if( _rightOperand == null )
				{
					throw new ORMInterpretationException( "The expression has its right operand set to null. Can't resolve expression." );
				}
				leftOperandValue = OperandToValue( _leftOperand, entity );
				rightOperandValue = OperandToValue( _rightOperand, entity );
				if((leftOperandValue == null) || (rightOperandValue == null) || (leftOperandValue == DBNull.Value) || (rightOperandValue == DBNull.Value))
				{
					return DBNull.Value;
				}

				Type typeLeftValue = leftOperandValue.GetType();
				Type typeRightValue = rightOperandValue.GetType();
				if( typeLeftValue != typeRightValue)
				{
					try
					{
						rightOperandValue = Convert.ChangeType(rightOperandValue, typeLeftValue, null);
					}
					catch
					{
						// conversion failed.
						throw new ORMInterpretationException(
								string.Format("Left operand and right operand aren't of the same type. Left operand is of type '{0}', right operand is of type '{1}'",
									typeLeftValue, typeRightValue));
					}
				}

				// all operands have to be numeric if arithmetic operators are specified, except '+', which can be used for string concatenation.
				Comparer genericComparer = Comparer.DefaultInvariant;
				switch( _operator )
				{
					case ExOp.Add:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.And:
						if( typeLeftValue != typeof( bool ) )
						{
							throw new ORMInterpretationException(string.Format("You can't apply the boolean operator 'And' on an operand of type '{0}'",
								typeLeftValue));
						}
						resultValue = ( (bool)leftOperandValue && (bool)rightOperandValue);
						break;
					case ExOp.Div:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.Equal:
						resultValue = leftOperandValue.Equals(rightOperandValue);
						break;
					case ExOp.GreaterEqual:
						resultValue = (genericComparer.Compare( leftOperandValue, rightOperandValue ) >= 0);
						break;
					case ExOp.GreaterThan:
						resultValue = (genericComparer.Compare( leftOperandValue, rightOperandValue ) > 0);
						break;
					case ExOp.LessEqual:
						resultValue = (genericComparer.Compare( leftOperandValue, rightOperandValue ) <= 0);
						break;
					case ExOp.LesserThan:
						resultValue = (genericComparer.Compare( leftOperandValue, rightOperandValue ) >= 0);
						break;
					case ExOp.Mod:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.Mul:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.NotEqual:
						resultValue = !leftOperandValue.Equals( rightOperandValue );
						break;
					case ExOp.Or:
						if( typeLeftValue != typeof( bool ) )
						{
							throw new ORMInterpretationException(string.Format("You can't apply the boolean operator 'Or' on an operand of type '{0}'",
								typeLeftValue));
						}
						resultValue = ((bool)leftOperandValue | (bool)rightOperandValue);
						break;
					case ExOp.Sub:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.BitwiseAnd:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.BitwiseOr:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
					case ExOp.BitwiseXor:
						resultValue = NumericValueOperatorExecutor.PerformArithmethicOperation( leftOperandValue, _operator, rightOperandValue);
						break;
				}
			}

			return resultValue;
		}



		/// <summary>
		/// Resolves the passed in operand to its value at runtime. 
		/// </summary>
		/// <param name="operand">The operand to resolve.</param>
		/// <param name="entity">The entity to resolve the operand on</param>
		/// <returns>the value the operand resolves to</returns>
		protected virtual object OperandToValue( IExpressionElement operand, IEntityCore entity )
		{
			object toReturn = DBNull.Value;
			switch( operand.Type )
			{
				case ExpressionElementType.Value:
					toReturn = operand.Contents;
					break;
				case ExpressionElementType.Field:
					IExpressionFieldElement fieldElement = (IExpressionFieldElement)operand;
					IEntityFieldCoreInterpret field = fieldElement.Contents as IEntityFieldCoreInterpret;
					if( field == null )
					{
						throw new ORMInterpretationException( string.Format( "The field '{0}' doesn't implement IEntityFieldCoreInterpret.",
								((IEntityFieldCore)fieldElement.Contents).Alias ) );
					}
					toReturn = field.GetValue( entity );
					break;
				case ExpressionElementType.Expression:
					IExpressionInterpret expression = operand.Contents as IExpressionInterpret;
					if( expression == null )
					{
						throw new ORMInterpretationException( "The expression object set as operand doesn't implement IExpressionInterpret" );
					}
					toReturn = expression.GetValue( entity );
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Converts the passed in operand to text, appended to queryText. parameters created are added to _selectParameters.
		/// </summary>
		/// <param name="queryText"></param>
		/// <param name="operand"></param>
		/// <param name="uniqueMarker"></param>
		/// <param name="isLeftOperand"></param>
		/// <param name="inHavingClause"></param>
		private void OperandToText(ref StringBuilder queryText, IExpressionElement operand, ref int uniqueMarker, bool isLeftOperand, bool inHavingClause)
		{
			switch(operand.Type)
			{
				case ExpressionElementType.Value:
					IDataParameter parameter = _creator.CreateParameter("LO" + operand.GetHashCode().ToString("x"), ParameterDirection.Input, operand.Contents);
					_parameters.Add(parameter);
					uniqueMarker++;
					parameter.Value = operand.Contents;
					parameter.ParameterName += uniqueMarker.ToString();
					queryText.Append(parameter.ParameterName);
					break;
				case ExpressionElementType.Field:
					IExpressionFieldElement fieldElement = (IExpressionFieldElement)operand;
					IEntityFieldCore fieldCore = (IEntityFieldCore)fieldElement.Contents;
					queryText.AppendFormat(null, "{0}", _creator.CreateFieldName(fieldCore, fieldElement.PersistenceInfo, fieldCore.Name, fieldCore.ObjectAlias, 
							ref uniqueMarker, inHavingClause));
					if(fieldCore.ExpressionToApply!=null)
					{
						// add parameters to this expression's collection.
						_parameters.AddRange(fieldCore.ExpressionToApply.Parameters);
					}
					break;
				case ExpressionElementType.Expression:
				case ExpressionElementType.ScalarQuery:
					IExpression expressionToConvert = (IExpression)operand.Contents;
					// pass on the name creator object
					expressionToConvert.DatabaseSpecificCreator = _creator;
					queryText.AppendFormat(null, "({0})", expressionToConvert.ToQueryText(ref uniqueMarker, inHavingClause));
					_parameters.AddRange(expressionToConvert.Parameters);
					break;
				case ExpressionElementType.FunctionCall:
					IDbFunctionCall functionCall = (IDbFunctionCall)operand.Contents;
					queryText.Append(functionCall.ToQueryText(ref uniqueMarker, inHavingClause));
					break;
			}
		}


		/// <summary>
		/// inits members
		/// </summary>
		private void InitClass()
		{
			_parameters = new List<IDataParameter>();
			_creator = null;
		}


		#region Expression producing operator overloads
		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents value + expression
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value + expression
		/// </returns>
		public static Expression operator+(object value, Expression rightOperand)
		{
			if(value is IEntityField)
			{
				return ((EntityField)value + rightOperand);
			}
			if(value is IEntityField2)
			{
				return ((EntityField2)value + rightOperand);
			}
			return new Expression(value, ExOp.Add, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents value * expression
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value * expression
		/// </returns>
		public static Expression operator*(object value, Expression rightOperand)
		{
			if(value is IEntityField)
			{
				return ((EntityField)value * rightOperand);
			}
			if( value is IEntityField2 )
			{
				return ((EntityField2)value * rightOperand);
			}
			return new Expression(value, ExOp.Mul, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents value - expression
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value - expression
		/// </returns>
		public static Expression operator-(object value, Expression rightOperand)
		{
			if(value is IEntityField)
			{
				return ((EntityField)value - rightOperand);
			}
			if( value is IEntityField2 )
			{
				return ((EntityField2)value - rightOperand);
			}
			return new Expression(value, ExOp.Sub, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents value / expression
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value / expression
		/// </returns>
		public static Expression operator/(object value, Expression rightOperand)
		{
			if(value is IEntityField)
			{
				return ((EntityField)value / rightOperand);
			}
			if( value is IEntityField2 )
			{
				return ((EntityField2)value / rightOperand);
			}
			return new Expression(value, ExOp.Div, rightOperand);
		}


		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents expression + value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents value + expression
		/// </returns>
		public static Expression operator+(Expression leftOperand, object value)
		{
			if(value is IEntityField)
			{
				return (leftOperand + (EntityField)value);
			}
			if( value is IEntityField2 )
			{
				return (leftOperand + (EntityField2)value);
			}
			return new Expression(leftOperand, ExOp.Add, value);
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents  expression * value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents value * expression
		/// </returns>
		public static Expression operator*(Expression leftOperand, object value)
		{
			if(value is IEntityField)
			{
				return (leftOperand * (EntityField)value);
			}
			if( value is IEntityField2 )
			{
				return (leftOperand * (EntityField2)value);
			}
			return new Expression(leftOperand, ExOp.Mul, value);
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents expression - value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents value - expression
		/// </returns>
		public static Expression operator-(Expression leftOperand, object value)
		{
			if(value is IEntityField)
			{
				return (leftOperand - (EntityField)value);
			}
			if( value is IEntityField2 )
			{
				return (leftOperand - (EntityField2)value);
			}
			return new Expression(leftOperand, ExOp.Sub, value);
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents expression / value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents value / expression
		/// </returns>
		public static Expression operator/(Expression leftOperand, object value)
		{
			if(value is IEntityField)
			{
				return (leftOperand / (EntityField)value);
			}
			if( value is IEntityField2 )
			{
				return (leftOperand / (EntityField2)value);
			}
			return new Expression(leftOperand, ExOp.Div, value);
		}


		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents expression + expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value + expression
		/// </returns>
		public static Expression operator+(Expression leftOperand, Expression rightOperand)
		{
			return new Expression(leftOperand, ExOp.Add, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents  expression * expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value * expression
		/// </returns>
		public static Expression operator*(Expression leftOperand, Expression rightOperand)
		{
			return new Expression(leftOperand, ExOp.Mul, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents expression - expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value - expression
		/// </returns>
		public static Expression operator-(Expression leftOperand, Expression rightOperand)
		{
			return new Expression(leftOperand, ExOp.Sub, rightOperand);
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents expression / expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value / expression
		/// </returns>
		public static Expression operator/(Expression leftOperand, Expression rightOperand)
		{
			return new Expression(leftOperand, ExOp.Div, rightOperand);
		}
		#endregion

		#region Class Property Declarations
		/// <summary>
		/// The list of parameters created when the Expression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		public List<IDataParameter> Parameters 
		{
			get { return _parameters;}
		}
		
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		public IDbSpecificCreator DatabaseSpecificCreator 
		{
			get { return _creator;}
			set {_creator = value;}
		}

		/// <summary>
		/// Gets the left expression operand. Set by the constructor used.
		/// </summary>
		public IExpressionElement LeftOperand 
		{
			get { return _leftOperand;}
		}

		/// <summary>
		/// Gets the right expression operand. Set by the constructor used.
		/// Can be null
		/// </summary>
		public IExpressionElement RightOperand 
		{
			get { return _rightOperand;}
		}
		/// <summary>
		/// Gets the operator of the expression. Not valid (ExOp.None) if RightOperand is null. Set by the constructor used.
		/// </summary>
		public ExOp Operator 
		{
			get { return _operator;}
		}
		#endregion


		#region IExpressionInterpret Members
		/// <summary>
		/// Interprets the implementing expression class on the passed in entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>
		/// returns the value the expression resolves to for the entity passed in
		/// </returns>
		object IExpressionInterpret.GetValue( IEntityCore entity )
		{
			return PerformGetValue( entity );
		}
		#endregion
	}
}
