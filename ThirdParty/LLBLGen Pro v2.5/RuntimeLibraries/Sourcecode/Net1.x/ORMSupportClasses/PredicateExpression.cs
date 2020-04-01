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
using System.Collections.Specialized;
using System.Text;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the IPredicateExpression interface.
	/// </summary>
	[Serializable]
	public class PredicateExpression : Predicate, IPredicateExpression, IEnumerable
	{
		#region Class Member Declarations
		private ArrayList	_predicates;
		#endregion
		
		
		/// <summary>
		/// CTor. This empty constructor is not recommended when adding this instance directly
		/// to another PredicateExpression.
		/// </summary>
		public PredicateExpression():base()
		{
			_predicates = new ArrayList();
			base.InstanceType = (int)PredicateType.PredicateExpression;
		}

		/// <summary>
		/// CTor.
		/// </summary>
		/// <param name="predicateToAdd">Initial IPredicate implementing object for this PredicateExpression</param>
		public PredicateExpression(IPredicate predicateToAdd):base()
		{
			_predicates = new ArrayList();
			base.InstanceType = (int)PredicateType.PredicateExpression;
			Add(predicateToAdd);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="operand1">operand one of the expression</param>
		/// <param name="predicateExpressionOperator">operator of the expression</param>
		/// <param name="operand2">operand two of the expression</param>
		public PredicateExpression(IPredicate operand1, PredicateExpressionOperator predicateExpressionOperator, IPredicate operand2):base()
		{
			_predicates = new ArrayList();
			base.InstanceType = (int)PredicateType.PredicateExpression;
			Add(operand1);

			switch(predicateExpressionOperator)
			{
				case PredicateExpressionOperator.And:
					AddWithAnd(operand2);
					break;
				case PredicateExpressionOperator.Or:
					AddWithOr(operand2);
					break;
			}
		}


		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression. This can be a Predicate derived class or a PredicateExpression. 
		/// If no object is present yet in the PredicateExpression, no operator is added, otherwise the object is added with an 'And'-operator. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When prPredicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		public IPredicateExpression Add(IPredicate predicateToAdd)
		{
			if(predicateToAdd==null)
			{
				throw new ArgumentNullException("predicateToAdd", "The IPredicate implementing object to add to this PredicateExpression is null.");
			}

			IPredicateExpression expression = predicateToAdd as IPredicateExpression;
			if((expression!=null)&&(expression.Count<=0))
			{
				// empty, skip
				return this;
			}

			if(_predicates.Count>0)
			{
				// add it with the And operator
				AddWithAnd(predicateToAdd);
			}
			else
			{
				_predicates.Add(new PredicateExpressionElement(PredicateExpressionElementType.Predicate, predicateToAdd));
			}

			return this;
		}


		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression with an 'Or'-operator. 
		/// The object added can be a Predicate derived class or a PredicateExpression. If no objects are present yet in the PredicateExpression,
		/// the operator is ignored. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When predicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		public IPredicateExpression AddWithOr(IPredicate predicateToAdd)
		{
			if(predicateToAdd==null)
			{
				throw new ArgumentNullException("predicateToAdd", "The IPredicate implementing object to add to this PredicateExpression is null.");
			}

			IPredicateExpression expression = predicateToAdd as IPredicateExpression;
			if((expression!=null)&&(expression.Count<=0))
			{
				// empty, skip
				return this;
			}

			if(_predicates.Count>0)
			{
				_predicates.Add(new PredicateExpressionElement(PredicateExpressionElementType.Operator, PredicateExpressionOperator.Or));
			}
			_predicates.Add(new PredicateExpressionElement(PredicateExpressionElementType.Predicate, predicateToAdd));

			return this;
		}


		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression with an 'And'-operator. 
		/// The object added can be a Predicate derived class or a PredicateExpression. If no objects are present yet in the PredicateExpression,
		/// the operator is ignored. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When predicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		public IPredicateExpression AddWithAnd(IPredicate predicateToAdd)
		{
			if(predicateToAdd==null)
			{
				throw new ArgumentNullException("predicateToAdd", "The IPredicate implementing object to add to this PredicateExpression is null.");
			}

			IPredicateExpression expression = predicateToAdd as IPredicateExpression;
			if((expression!=null)&&(expression.Count<=0))
			{
				// empty, skip
				return this;
			}

			if(_predicates.Count>0)
			{
				_predicates.Add(new PredicateExpressionElement(PredicateExpressionElementType.Operator, PredicateExpressionOperator.And));
			}
			_predicates.Add(new PredicateExpressionElement(PredicateExpressionElementType.Predicate, predicateToAdd));

			return this;
		}


		/// <summary>
		/// Implements the IPredicate ToQueryText method. Retrieves a ready to use text representation of the contained PredicateExpression.
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
			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			StringBuilder queryText = new StringBuilder(128);
			base.Parameters.Clear();
	
			if(base.Negate)
			{
				queryText.Append("NOT (");
			}
			else
			{
				queryText.Append("(");
			}

			for(int i=0;i<_predicates.Count;i++)
			{
				IPredicateExpressionElement element = (IPredicateExpressionElement)_predicates[i];

				switch(element.Type)
				{
					case PredicateExpressionElementType.Empty:
						// skip
						break;
					case PredicateExpressionElementType.Operator:
						queryText.AppendFormat(null, " {0}", ((PredicateExpressionOperator)element.Contents).ToString().ToUpper(CultureInfo.InvariantCulture));
						break;
					case PredicateExpressionElementType.Predicate:
						IPredicate predicateToAdd = (IPredicate)element.Contents;
						// pass on the name creator object
						predicateToAdd.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
						queryText.AppendFormat(null, " {0}", predicateToAdd.ToQueryText(ref uniqueMarker, inHavingClause));
						base.Parameters.AddRange(predicateToAdd.Parameters);
						break;
				}
			}

			// add closing bracket
			queryText.Append(")");

			return queryText.ToString();
		}


		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear()
		{
			_predicates.Clear();
		}


		/// <summary>
		/// Returns an enumerator that can iterate through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/>
		/// that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			return _predicates.GetEnumerator();
		}


		/// <summary>
		/// Imports the specified expression's elements into this expression, by appending the elements to the current contents. 
		/// </summary>
		/// <param name="expression">Expression.</param>
		internal void Import(IPredicateExpression expression)
		{
			foreach(IPredicateExpressionElement element in expression)
			{
				_predicates.Add(element);
			}
		}


		/// <summary>
		/// Interprets this predicate on the passed in entity
		/// </summary>
		/// <param name="entity">The entity to interpret this predicate on</param>
		/// <returns>
		/// true if the predicate interpretation resolves to true, otherwise false.
		/// </returns>
		/// <remarks>By default this method throws a NotSupported exception. It is only implemented on predicates which can be used
		/// for in-memory filtering.</remarks>
		protected override bool InterpretPredicate( IEntityCore entity )
		{
			bool overallResult = false;
			// set initial operator to or, so the first predicate we'll interpret will always set overallResult to the right value.
			PredicateExpressionOperator lastSeenOperator = PredicateExpressionOperator.Or;
			
			// check if the operators in this predicateexpression are all of the same kind. If so, this can be used to short-circuit the evaluation.
			bool seenOr = false;
			bool seenAnd = false;
			foreach(IPredicateExpressionElement element in _predicates)
			{
				switch(element.Type)
				{
					case PredicateExpressionElementType.Operator:
					switch((PredicateExpressionOperator)element.Contents)
					{
						case PredicateExpressionOperator.And:
							seenAnd = true;
							break;
						case PredicateExpressionOperator.Or:
							seenOr = true;
							break;
					}
						break;
				}
			}

			// now simply perform interpret on every predicate in this expression and perform the last operator encountered.
			bool done = false;
			for( int i = 0; (i < _predicates.Count) && !done; i++ )
			{
				IPredicateExpressionElement element = (IPredicateExpressionElement)_predicates[i];

				switch( element.Type )
				{
					case PredicateExpressionElementType.Empty:
						// skip
						break;
					case PredicateExpressionElementType.Operator:
						lastSeenOperator = (PredicateExpressionOperator)element.Contents;
						break;
					case PredicateExpressionElementType.Predicate:
						IPredicateInterpret predicateToInterpret = (IPredicateInterpret)element.Contents;
						bool interpretResult = predicateToInterpret.Interpret( entity );
						if( lastSeenOperator == PredicateExpressionOperator.And )
						{
							overallResult &= interpretResult;
							if(!overallResult && !seenOr)
							{
								// solely and operators in the expression, shortcircuit, as the expression will never become true anymore
								done = true;
							}
						}
						else
						{
							overallResult |= interpretResult;
							if(overallResult && !seenAnd)
							{
								// solely or operators in the expression, shortcircuit, as the expression will never become false anymore.
								done = true;
							}
						}
						break;
				}
			}

			return overallResult;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets the predicate expression element at the index specified
		/// </summary>
		public IPredicateExpressionElement this[int index] 
		{
			get { return (IPredicateExpressionElement)_predicates[index];}
		}
		
		/// <summary>
		/// Gets the amount of predicate expression elements in this predicate expression. This is including all operators.
		/// </summary>
		public int Count 
		{
			get { return _predicates.Count;}
		}
		#endregion

	}
}
