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
using System.ComponentModel;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which at runtime represents an entity property, and which is used in Predicate expressions for filtering and sorting 
	/// in-memory using EntityView(2) objects. Both selfservicing and adapter use this class.
	/// </summary>
	[Serializable]
	public class EntityProperty : IEntityFieldCore, IEntityFieldCoreInterpret
	{
		#region Class Member Declarations
		private string			_propertyName;
		private IExpression		_expressionToApply;

		[NonSerialized]
		private PropertyDescriptor _propertyDescriptor;

		[NonSerialized]
		private bool _propertyDescriptorSetByCTor;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="EntityProperty"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property. Case sensitive</param>
		public EntityProperty( string propertyName )
		{
			_propertyName = propertyName;
			_expressionToApply = null;
			_propertyDescriptor = null;
			_propertyDescriptorSetByCTor = false;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityProperty"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor of the property this object has to represent</param>
		public EntityProperty( PropertyDescriptor descriptor )
		{
			if( descriptor == null )
			{
				throw new ArgumentNullException( "descriptor", "Descriptor can't be null" );
			}
			_propertyDescriptor = descriptor;
			_expressionToApply = null;
			_propertyName = descriptor.Name;
			_propertyDescriptorSetByCTor = (_propertyDescriptor != null);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
		/// <returns>
		/// 	<see langword="true"/> if the specified <see cref="T:System.Object"/> is equal to the
		/// current <see cref="T:System.Object"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}


		/// <summary>
		/// Serves as a hash function for a particular type, suitable
		/// for use in hashing algorithms and data structures like a hash table.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}



		#region IEntityFieldCore members which aren't implemented in this class.
		/// <summary>
		/// Not implemented
		/// </summary>
		public void AcceptChange()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void RejectChange()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void ForcedCurrentValueWrite( object value )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void ForcedCurrentValueWrite( object value, object dbValue )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool GetDiscriminatorColumnFlag()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public string Alias
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public object CurrentValue
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public object DbValue
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsChanged
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsNull
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public string ObjectAlias
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public AggregateFunction AggregateFunctionToApply
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public IEntityFieldCore LinkedSuperTypeField
		{
			get
			{
				throw new Exception( "The method or operation is not implemented." );
			}
			set
			{
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void BeginEdit()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void CancelEdit()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public void EndEdit()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public Type DataType
		{
			get 
			{
				if( _propertyDescriptor != null )
				{
					return _propertyDescriptor.PropertyType;
				}
				else
				{
					return null;
				}
			}		
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsPrimaryKey
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsNullable
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public int FieldIndex
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public string ContainingObjectName
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsForeignKey
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public bool IsReadOnly
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public int MaxLength
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public byte Scale
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		/// <summary>
		/// Not implemented
		/// </summary>
		public byte Precision
		{
			get { throw new Exception( "The method or operation is not implemented." ); }
		}
		
		/// <summary>
		/// Not Implemented
		/// </summary>
		public string ActualContainingObjectName
		{
			get { throw new Exception("The method or operation is not implemented."); }
		}

		/// <summary>
		/// Not Implemented
		/// </summary>
		public bool IsInMultiTargetEntity
		{
			get { throw new Exception("The method or operation is not implemented."); }
		}
		#endregion


		#region Predicate producing operator overloads
		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareExpressionPredicate to represent leftOperand == rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator ==( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.Equal, new Expression( rightOperand ) );
		}

		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand != rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate which is negated</returns>
		public static Predicate operator !=( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.Equal, new Expression( rightOperand ), true );
		}


		/// <summary>
		/// Operator overload for the '&gt;' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &gt; rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator >( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.GreaterThan, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&gt;=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &gt;= rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator >=( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.GreaterEqual, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&lt;' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &lt; rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator <( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.LesserThan, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&lt;=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &lt;= rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator <=( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.LessEqual, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareExpressionPredicate to represent leftOperand == rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator ==( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.Equal, new Expression( rightOperand ) );
		}

		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand != rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate which is negated</returns>
		public static Predicate operator !=( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.Equal, new Expression( rightOperand ), true );
		}


		/// <summary>
		/// Operator overload for the '&gt;' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &gt; rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator >( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.GreaterThan, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&gt;=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &gt;= rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator >=( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.GreaterEqual, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&lt;' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &lt; rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator <( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.LesserThan, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '&lt;=' operator to produce a FieldCompareExpressionPredicate to represent leftOperand &lt;= rigthOperand
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>A FieldCompareExpressionPredicate</returns>
		public static Predicate operator <=( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new FieldCompareExpressionPredicate( leftOperand, null, ComparisonOperator.LessEqual, new Expression( rightOperand ) );
		}


		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareRangePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="values">the values to compare with.</param>
		/// <returns>A FieldCompareRangePredicate</returns>
		public static Predicate operator ==( EntityProperty field, object[] values )
		{
			return new FieldCompareRangePredicate( field, null, values );
		}


		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareRangePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="values">the values to compare with.</param>
		/// <returns>A FieldCompareRangePredicate which is negated</returns>
		public static Predicate operator !=( EntityProperty field, object[] values )
		{
			return new FieldCompareRangePredicate( field, null, true, values );
		}


		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareRangePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="values">the values to compare with.</param>
		/// <returns>A FieldCompareRangePredicate</returns>
		public static Predicate operator ==( EntityProperty field, ArrayList values )
		{
			return new FieldCompareRangePredicate( field, null, values );
		}


		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareRangePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="values">the values to compare with.</param>
		/// <returns>A FieldCompareRangePredicate which is negated</returns>
		public static Predicate operator !=( EntityProperty field, ArrayList values )
		{
			return new FieldCompareRangePredicate( field, null, true, values );
		}


		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareValue/Null predicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with. If value is null, a FieldCompareNullPredicate will be created instead.</param>
		/// <returns>A FieldCompareNullPredicate or FieldCompareValuePredicate with the operator ComparisonOperator.Equal</returns>
		public static Predicate operator ==( EntityProperty field, object value )
		{
			if( (value == null) || (value == System.DBNull.Value) )
			{
				return new FieldCompareNullPredicate( field, null );
			}
			else
			{
				if( value is EntityProperty )
				{
					return (field == (EntityProperty)value);
				}
				return new FieldCompareValuePredicate( field, null, ComparisonOperator.Equal, value );
			}
		}


		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareValue/Null predicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with. If value is null, a FieldCompareNullPredicate will be created instead.</param>
		/// <returns>A FieldCompareNullPredicate or FieldCompareValuePredicate with the operator ComparisonOperator.NotEqual</returns>
		public static Predicate operator !=( EntityProperty field, object value )
		{
			if( (value == null) || (value == System.DBNull.Value) )
			{
				return new FieldCompareNullPredicate( field, null, true );
			}
			else
			{
				if( value is EntityProperty )
				{
					return (field != (EntityProperty)value);
				}
				return new FieldCompareValuePredicate( field, null, ComparisonOperator.NotEqual, value );
			}
		}


		/// <summary>
		/// Operator overload for the '&gt;' operator to produce a FieldCompareValuePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with.</param>
		/// <returns>A FieldCompareValuePredicate with the operator ComparisonOperator.GreaterThan</returns>
		public static Predicate operator >( EntityProperty field, object value )
		{
			if( value is EntityProperty )
			{
				return (field > (EntityProperty)value);
			}
			return new FieldCompareValuePredicate( field, null, ComparisonOperator.GreaterThan, value );
		}


		/// <summary>
		/// Operator overload for the '&gt;=' operator to produce a FieldCompareValuePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with.</param>
		/// <returns>A FieldCompareValuePredicate with the operator ComparisonOperator.GreaterEqual</returns>
		public static Predicate operator >=( EntityProperty field, object value )
		{
			if( value is EntityProperty )
			{
				return (field >= (EntityProperty)value);
			}
			return new FieldCompareValuePredicate( field, null, ComparisonOperator.GreaterEqual, value );
		}


		/// <summary>
		/// Operator overload for the '&lt;' operator to produce a FieldCompareValuePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with.</param>
		/// <returns>A FieldCompareValuePredicate with the operator ComparisonOperator.LesserThan</returns>
		public static Predicate operator <( EntityProperty field, object value )
		{
			if( value is EntityProperty )
			{
				return (field < (EntityProperty)value);
			}
			return new FieldCompareValuePredicate( field, null, ComparisonOperator.LesserThan, value );
		}


		/// <summary>
		/// Operator overload for the '&lt;=' operator to produce a FieldCompareValuePredicate. 
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="value">the value to compare with.</param>
		/// <returns>A FieldCompareValuePredicate with the operator ComparisonOperator.LessEqual</returns>
		public static Predicate operator <=( EntityProperty field, object value )
		{
			if( value is EntityProperty )
			{
				return (field <= (EntityProperty)value);
			}
			return new FieldCompareValuePredicate( field, null, ComparisonOperator.LessEqual, value );
		}


		/// <summary>
		/// Operator overload for the '==' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.Equal</returns>
		public static Predicate operator ==( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.Equal, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '!=' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.NotEqual</returns>
		public static Predicate operator !=( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.NotEqual, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '&gt;' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.GreaterThan</returns>
		public static Predicate operator >( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.GreaterThan, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '&gt;=' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.GreaterEqual</returns>
		public static Predicate operator >=( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.GreaterEqual, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '&lt;' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.LesserThan</returns>
		public static Predicate operator <( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.LesserThan, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '&lt;=' operator to produce a FieldCompareExpression predicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="toCompareWith">To compare with.</param>
		/// <returns>A FieldCompareExpressionPredicate with operator ComparisonOperator.LessEqual</returns>
		public static Predicate operator <=( EntityProperty field, Expression toCompareWith )
		{
			return new FieldCompareExpressionPredicate( field, null, ComparisonOperator.LessEqual, toCompareWith );
		}


		/// <summary>
		/// Operator overload for the '%' operator to produce a FieldLikePredicate.
		/// </summary>
		/// <param name="field">Field to compare</param>
		/// <param name="pattern">Pattern.</param>
		/// <returns>
		/// A FieldLikePredicate 
		/// </returns>
		public static Predicate operator %( EntityProperty field, string pattern )
		{
			return new FieldLikePredicate( field, null, pattern );
		}

		#endregion

		#region Expression producing operator overloads
		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents field + value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents field + value
		/// </returns>
		public static Expression operator +( EntityProperty leftOperand, object value )
		{
			if( value is EntityProperty )
			{
				return (leftOperand + (EntityProperty)value);
			}
			return new Expression( leftOperand, ExOp.Add, value );
		}

		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents field + expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents field + value
		/// </returns>
		public static Expression operator +( EntityProperty leftOperand, Expression rightOperand )
		{
			return new Expression( leftOperand, ExOp.Add, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents field + field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field + value</returns>
		public static Expression operator +( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Add, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents field + field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field + value</returns>
		public static Expression operator +( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new Expression( leftOperand, ExOp.Add, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents value + field
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value + field
		/// </returns>
		public static Expression operator +( object value, EntityProperty rightOperand )
		{
			return new Expression( value, ExOp.Add, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '+' operator to produce an Expression which represents expression + field
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns></returns>
		public static Expression operator +( Expression leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Add, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents field * value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents field * value
		/// </returns>
		public static Expression operator *( EntityProperty leftOperand, object value )
		{
			if( value is EntityProperty )
			{
				return (leftOperand * (EntityProperty)value);
			}
			return new Expression( leftOperand, ExOp.Mul, value );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents field * expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field * expression</returns>
		public static Expression operator *( EntityProperty leftOperand, Expression rightOperand )
		{
			return new Expression( leftOperand, ExOp.Mul, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents field * field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field * field2</returns>
		public static Expression operator *( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Mul, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents field * field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field * field2</returns>
		public static Expression operator *( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new Expression( leftOperand, ExOp.Mul, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents value * field
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value * field
		/// </returns>
		public static Expression operator *( object value, EntityProperty rightOperand )
		{
			if( value is EntityProperty )
			{
				return ((EntityProperty)value * rightOperand);
			}
			return new Expression( value, ExOp.Mul, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '*' operator to produce an Expression which represents expression * field
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns></returns>
		public static Expression operator *( Expression leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Mul, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents field - value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents field - value
		/// </returns>
		public static Expression operator -( EntityProperty leftOperand, object value )
		{
			if( value is EntityProperty )
			{
				return (leftOperand - (EntityProperty)value);
			}
			return new Expression( leftOperand, ExOp.Sub, value );
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents field - expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field - expression</returns>
		public static Expression operator -( EntityProperty leftOperand, Expression rightOperand )
		{
			return new Expression( leftOperand, ExOp.Sub, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents field - field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field - field2</returns>
		public static Expression operator -( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Sub, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents value - field
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value - field
		/// </returns>
		public static Expression operator -( object value, EntityProperty rightOperand )
		{
			if( value is EntityProperty )
			{
				return ((EntityProperty)value - rightOperand);
			}
			return new Expression( value, ExOp.Sub, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '-' operator to produce an Expression which represents expression - field
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns></returns>
		public static Expression operator -( Expression leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Sub, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents field / value
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="value">Value.</param>
		/// <returns>
		/// Expression object which represents field / value
		/// </returns>
		public static Expression operator /( EntityProperty leftOperand, object value )
		{
			if( value is EntityProperty )
			{
				return (leftOperand / (EntityProperty)value);
			}
			return new Expression( leftOperand, ExOp.Div, value );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents field / expression
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field / expression</returns>
		public static Expression operator /( EntityProperty leftOperand, Expression rightOperand )
		{
			return new Expression( leftOperand, ExOp.Div, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents field / field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field / field2</returns>
		public static Expression operator /( EntityProperty leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Div, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents field / field2
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand</param>
		/// <returns>Expression object which represents field / field2</returns>
		public static Expression operator /( EntityProperty leftOperand, EntityField2 rightOperand )
		{
			return new Expression( leftOperand, ExOp.Div, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents value / field
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns>
		/// Expression object which represents value / field
		/// </returns>
		public static Expression operator /( object value, EntityProperty rightOperand )
		{
			if( value is EntityProperty )
			{
				return ((EntityProperty)value / rightOperand);
			}
			return new Expression( value, ExOp.Div, rightOperand );
		}

		/// <summary>
		/// Operator overload for the '/' operator to produce an Expression which represents expression / field
		/// </summary>
		/// <param name="leftOperand">Left operand.</param>
		/// <param name="rightOperand">Right operand.</param>
		/// <returns></returns>
		public static Expression operator /( Expression leftOperand, EntityProperty rightOperand )
		{
			return new Expression( leftOperand, ExOp.Div, rightOperand );
		}

		#endregion

		#region SortExpression producing operator overloads
		/// <summary>
		/// Operator overload for the '|' operator to concatenate sortoperators to a field
		/// </summary>
		/// <param name="field">Field.</param>
		/// <param name="operatorToUse">Operator to use.</param>
		/// <returns>new SortClause object</returns>
		public static SortClause operator |( EntityProperty field, SortOperator operatorToUse )
		{
			return new SortClause( field, null, operatorToUse );
		}
		#endregion

		#region IEntityFieldCoreInterpret Members
		/// <summary>
		/// Gets the value for the field implementing this interface for the entity passed in.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>
		/// the value of the property in the entity passed in. If the field isn't present in the entity passed in, null is returned.
		/// If the value for the property is null, DBNull.Value is returned.
		/// </returns>
		object IEntityFieldCoreInterpret.GetValue( IEntityCore entity )
		{
			object toReturn = null;
			if(_expressionToApply!=null)
			{
				// has expression.
				IExpressionInterpret expression = _expressionToApply as IExpressionInterpret;
				if(expression==null)
				{
					throw new ORMInterpretationException("The expression object set for entity property '" + _propertyName + "' isn't implementing IExpressionInterpret");
				}
				toReturn = expression.GetValue(entity);
			}
			if( !_propertyDescriptorSetByCTor )
			{
				// grab property descriptor first. 
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( entity.GetType() );
				_propertyDescriptor = properties.Find( _propertyName, false );
				if( _propertyDescriptor == null )
				{
					// not present
					toReturn = null;
				}
			}
			if(_propertyDescriptor!=null)
			{
				toReturn = _propertyDescriptor.GetValue( entity );
			}
			if( toReturn == null )
			{
				toReturn = DBNull.Value;
			}

			return toReturn;
		}

		#endregion

		#region Class Property Declarations
		/// <summary>
		/// The name of the property. Name cannot be of zero length nor can they consist of solely spaces. Leading and trailing spaces are trimmed.
		/// </summary>
		/// <value></value>
		/// <exception cref="ArgumentException">The value specified for Name is invalid.</exception>
		public string Name
		{
			get { return _propertyName; }
		}

		/// <summary>
		/// The expression to apply to this field in a select list, update statement or predicate.
		/// Expression is applied before AggregateFunctionToApply.
		/// </summary>
		/// <value></value>
		public IExpression ExpressionToApply
		{
			get
			{
				return _expressionToApply;
			}
			set
			{
				_expressionToApply = value;
			}
		}


		/// <summary>
		/// The database function call to apply on this field in a selectlist, update statement or predicate or expression.
		/// FunctionCallToApply is applied before ExpressionToApply.
		/// </summary>
		public IDbFunctionCall FunctionCallToApply
		{
			get { throw new NotSupportedException("FunctionCallToApply isn't supported on Entityproperty, as it's a Database function call"); }
			set { throw new NotSupportedException("FunctionCallToApply isn't supported on Entityproperty, as it's a Database function call"); }
		}


		/// <summary>
		/// Gets the representing property descriptor.
		/// </summary>
		/// <value>The representing property descriptor.</value>
		internal PropertyDescriptor RepresentingPropertyDescriptor
		{
			get { return _propertyDescriptor; }
		}

		#endregion

	}
}
