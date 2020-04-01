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
using System.Data;
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base implementation of the IPredicate interface.
	/// </summary>
	[Serializable]
	public abstract class Predicate : IPredicate, IPredicateInterpret
	{
		#region Class Member Declarations
		private bool					_negate, _selfServicing;
		private int						_instanceType;

		[NonSerialized]
		private List<IDataParameter>	_parameters;
		[NonSerialized]
		private IDbSpecificCreator		_databaseSpecificCreator;
		#endregion
		
		
		/// <summary>
		/// CTor
		/// </summary>
		public Predicate()
		{
			_negate = false;
			_parameters = new List<IDataParameter>();
			_databaseSpecificCreator = null;
			_selfServicing = true;
			_instanceType=(int)PredicateType.Undefined;
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		public abstract string ToQueryText(ref int uniqueMarker);
		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public abstract string ToQueryText(ref int uniqueMarker, bool inHavingClause);


		/// <summary>
		/// Operator overload for the '&amp;' operator, to concatenate predicates together. 
		/// </summary>
		/// <param name="leftHandSide"></param>
		/// <param name="rightHandSide"></param>
		/// <returns>Predicate expression containing: leftHandSide AND righthandside</returns>
		public static PredicateExpression operator&(Predicate leftHandSide, Predicate rightHandSide)
		{
			return new PredicateExpression(leftHandSide, PredicateExpressionOperator.And, rightHandSide);
		}


		/// <summary>
		/// Operator overload for the '|' operator, to concatenate predicates together
		/// </summary>
		/// <param name="leftHandSide"></param>
		/// <param name="rightHandSide"></param>
		/// <returns>Predicate expression containing: leftHandSide OR righthandside</returns>
		public static PredicateExpression operator|(Predicate leftHandSide, Predicate rightHandSide)
		{
			return new PredicateExpression(leftHandSide, PredicateExpressionOperator.Or, rightHandSide);
		}


		/// <summary>
		/// Operator overload for the ! operator, to negate the passed in predicate.
		/// </summary>
		/// <param name="rightHandSide">Right hand side.</param>
		/// <returns>passed in predicate with the negate flag toggled</returns>
		public static Predicate operator!(Predicate rightHandSide)
		{
			rightHandSide.Negate=!rightHandSide.Negate;
			return rightHandSide;
		}

		/// <summary>
		/// Interprets this predicate on the passed in entity
		/// </summary>
		/// <param name="entity">The entity to interpret this predicate on</param>
		/// <returns>true if the predicate interpretation resolves to true, otherwise false.</returns>
		/// <remarks>By default this method throws a NotSupported exception. It is only implemented on predicates which can be used 
		/// for in-memory filtering.</remarks>
		protected virtual bool InterpretPredicate( IEntityCore entity )
		{
			throw new NotSupportedException( "This method isn't supported in the current context." );
		}


		#region IPredicateInterpret Members

		/// <summary>
		/// Interprets the implementing class on the entity passed in.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>
		/// true if the predicte resolves to true for this entity, false otherwise
		/// </returns>
		bool IPredicateInterpret.Interpret( IEntityCore entity )
		{
			return InterpretPredicate( entity );
		}
		#endregion


		#region Class Property Declarations
		/// <summary>
		/// The PredicateType of this instance. Used to determine the instance nature without a lot of casting.
		/// </summary>
		/// <summary>
		/// Gets / sets instanceType
		/// </summary>
		public int InstanceType
		{
			get
			{
				return _instanceType;
			}
			set
			{
				_instanceType = value;
			}
		}

		/// <summary>
		/// The list of parameters created when the Predicate was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		public List<IDataParameter> Parameters 
		{
			get 
			{
				if(_parameters==null)
				{
					_parameters = new List<IDataParameter>();
				}
				return _parameters;
			}
		}

		/// <summary>
		/// Flag for setting the Predicate to negate itself, i.e. to add 'NOT' to its result.
		/// </summary>
		public bool Negate 
		{
			get { return _negate; } 
			set { _negate = value; }
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
		/// Gets / sets selfServicing, a flag to signal if this predicate is constructed using a selfservicing constructor (field is of type IEntityField)
		/// Default: true;
		/// </summary>
		internal bool SelfServicing
		{
			get
			{
				return _selfServicing;
			}
			set
			{
				_selfServicing = value;
			}
		}
		#endregion

	}
}
