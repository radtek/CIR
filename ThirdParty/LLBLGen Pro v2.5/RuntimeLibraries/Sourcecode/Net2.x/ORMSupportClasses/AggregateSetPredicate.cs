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
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Predicate class which performs an aggregate function on a set of entities and returns true or false depending if that aggregated value
	/// matches a specified expression. The set of entities this predicate is applied on are the elements of a member property with the name specified which 
	/// match the specified filter. 
	/// </summary>
	/// <remarks>Meant for in-memory filtering. Can't be used in database targeting filters.</remarks>
	[Serializable]
	public class AggregateSetPredicate : Predicate
	{
		#region Class Member Declarations
		private string _memberName;
		private IPredicate _setFilter;
		private object _operand;
		private AggregateSetFunction _functionToApply;
		private IExpression _valueProducer;
		private ComparisonOperator _operatorToApply;
		private bool _valueProducerIsCallback;
		private bool _aggregatorIsCallback;
		private AggregateSetPredicateCallback _aggregatorCallback;
		private InterpretSetValueCallback _valueProducerCallback;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducer">The value producer for each element in the set. The value produced by the value producer is added to the set.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, IExpression valueProducer,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter)
			: this(memberName, functionToApply, valueProducer, operatorToApply, operand, setFilter, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducer">The value producer for each element in the set. The value produced by the value producer is added to the set.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, IEntityFieldCore valueProducer,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter)
			: this(memberName, functionToApply, new Expression(valueProducer), operatorToApply, operand, setFilter, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducer">The value producer for each element in the set. The value produced by the value producer is added to the set.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		/// <param name="negate">Negate the comparison operator outcome for the final result of this predicate.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, IEntityFieldCore valueProducer,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter, bool negate)
			: this(memberName, functionToApply, new Expression(valueProducer), operatorToApply, operand, setFilter, negate)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducer">The value producer for each element in the set. The value produced by the value producer is added to the set.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		/// <param name="negate">Negate the comparison operator outcome for the final result of this predicate.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, IExpression valueProducer,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter, bool negate)
		{
			if(string.IsNullOrEmpty(memberName))
			{
				throw new ArgumentException("memberName can't be null nor empty", "memberName");
			}
			if((operand == null) || !CheckIfOperandIsNumeric(operand))
			{
				throw new ArgumentNullException("operand has to be a numeric value", "operand");
			}
			if(valueProducer == null)
			{
				throw new ArgumentNullException("valueProducer can't be null", "valueProducer");
			}
			_memberName = memberName;
			_functionToApply = functionToApply;
			_valueProducer = valueProducer;
			_setFilter = setFilter;
			_operatorToApply = operatorToApply;
			_operand = operand;
			base.Negate = negate;
			_valueProducerIsCallback = false;
			_aggregatorIsCallback = false;
		}



		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducerCallback">The value producer callback which is called for every entity matching the set filter and which should produce a value to aggregate.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, InterpretSetValueCallback valueProducerCallback,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter)
			: this(memberName, functionToApply, valueProducerCallback, operatorToApply, operand, setFilter, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="functionToApply">The function to apply as aggregate function.</param>
		/// <param name="valueProducerCallback">The value producer callback which is called for every entity matching the set filter and which should produce a value to aggregate.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		/// <param name="negate">Negate the comparison operator outcome for the final result of this predicate.</param>
		public AggregateSetPredicate(string memberName, AggregateSetFunction functionToApply, InterpretSetValueCallback valueProducerCallback,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter, bool negate)
		{
			if(string.IsNullOrEmpty(memberName))
			{
				throw new ArgumentException("memberName can't be null nor empty", "memberName");
			}
			if((operand == null) || !CheckIfOperandIsNumeric(operand))
			{
				throw new ArgumentNullException("operand has to be a numeric value", "operand");
			}
			if(valueProducerCallback == null)
			{
				throw new ArgumentNullException("valueProducerCallback can't be null", "valueProducerCallback");
			}
			_memberName = memberName;
			_functionToApply = functionToApply;
			_valueProducerCallback = valueProducerCallback;
			_setFilter = setFilter;
			_operatorToApply = operatorToApply;
			_operand = operand;
			base.Negate = negate;
			_valueProducerIsCallback = true;
			_aggregatorIsCallback = false;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="aggregatorCallback">The aggregator callback which is called to aggregate over the set of values produced by the individual calls to the valueProducerCallback.</param>
		/// <param name="valueProducerCallback">The value producer callback which is called for every entity matching the set filter and which should produce a value to aggregate.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		public AggregateSetPredicate(string memberName, AggregateSetPredicateCallback aggregatorCallback, InterpretSetValueCallback valueProducerCallback,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter)
			: this(memberName, aggregatorCallback, valueProducerCallback, operatorToApply, operand, setFilter, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AggregateSetPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="aggregatorCallback">The aggregator callback which is called to aggregate over the set of values produced by the individual calls to the valueProducerCallback.</param>
		/// <param name="valueProducerCallback">The value producer callback which is called for every entity matching the set filter and which should produce a value to aggregate.</param>
		/// <param name="operatorToApply">The operator to apply on the aggregated value.</param>
		/// <param name="operand">The value to compare the aggregated value with using the operatorToApply.</param>
		/// <param name="setFilter">The set filter to determine which elements in memberName form the set the aggregate function to apply on.</param>
		/// <param name="negate">Negate the comparison operator outcome for the final result of this predicate.</param>
		public AggregateSetPredicate(string memberName, AggregateSetPredicateCallback aggregatorCallback, InterpretSetValueCallback valueProducerCallback,
					ComparisonOperator operatorToApply, object operand, IPredicate setFilter, bool negate)
		{
			if(string.IsNullOrEmpty(memberName))
			{
				throw new ArgumentException("memberName can't be null nor empty", "memberName");
			}
			if((operand == null) || !CheckIfOperandIsNumeric(operand))
			{
				throw new ArgumentNullException("operand has to be a numeric value", "operand");
			}
			if(valueProducerCallback == null)
			{
				throw new ArgumentNullException("valueProducerCallback can't be null", "valueProducerCallback");
			}
			if(aggregatorCallback== null)
			{
				throw new ArgumentNullException("aggregatorCallback can't be null", "aggregatorCallback");
			}
			_memberName = memberName;
			_aggregatorCallback = aggregatorCallback;
			_valueProducerCallback = valueProducerCallback;
			_setFilter = setFilter;
			_operatorToApply = operatorToApply;
			_operand = operand;
			base.Negate = negate;
			_valueProducerIsCallback = true;
			_aggregatorIsCallback = true;
		}


		/// <summary>
		/// Checks if the passed in operand value is numeric.
		/// </summary>
		/// <param name="operand">The operand.</param>
		/// <returns></returns>
		private bool CheckIfOperandIsNumeric(object operand)
		{
			if(operand==null)
			{
				return false;
			}
			bool toReturn = false;
			switch(Type.GetTypeCode(operand.GetType()))
			{
				case TypeCode.Byte:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.Single:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.DateTime:
					toReturn = true;
					break;
				default:
					toReturn = false;
					break;
			}

			return toReturn;
		}
		

		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <returns>
		/// The contained Predicate in textual format.
		/// </returns>
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
		/// <returns>
		/// The contained Predicate in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public override string ToQueryText(ref int uniqueMarker, bool inHavingClause)
		{
#if CF
			return string.Empty;
#else
			string notString = string.Empty;
			if(base.Negate)
			{
				notString = "NOT ";
			}
			string aggregateFunction = string.Empty;
			if(_aggregatorIsCallback)
			{
				aggregateFunction = string.Format("{0}.{1}", _aggregatorCallback.Method.DeclaringType.FullName, _aggregatorCallback.Method.Name);
			}
			else
			{
				aggregateFunction = _functionToApply.ToString();
			}
			string valueFunction = string.Empty;
			if(_valueProducerIsCallback)
			{
				valueFunction = string.Format("{0}.{1}", _valueProducerCallback.Method.DeclaringType.FullName, _valueProducerCallback.Method.Name);
			}
			else
			{
				_valueProducer.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
				valueFunction = _valueProducer.ToQueryText(ref uniqueMarker, inHavingClause);
			}
			string setFilterString = string.Empty;
			if(_setFilter != null)
			{
				_setFilter.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
				setFilterString = " where " + _setFilter.ToQueryText(ref uniqueMarker, inHavingClause);
			}
			return string.Format("{0}{1}(on {2}, ({3})) {4} {5}{6}", notString, aggregateFunction, _memberName, valueFunction,
				_operatorToApply.ToString(), _operand.ToString(), setFilterString);
#endif
		}


		/// <summary>
		/// Interprets this predicate on the passed in entity
		/// </summary>
		/// <param name="entity">The entity to interpret this predicate on</param>
		/// <returns>
		/// true if the predicate interpretation resolves to true, otherwise false.
		/// </returns>
		protected override bool InterpretPredicate(IEntityCore entity)
		{
			// first determine the set to apply the function on, then apply the function on that set of values. 

			// get the members. 
			Dictionary<string, object> allMemberData = ((IEntityCoreInternal)entity).CallGetRelatedData();

			object memberData = null;
			if(!allMemberData.TryGetValue(_memberName, out memberData))
			{
				// member not found. 
				throw new ORMInterpretationException(string.Format("The member '{0}' isn't found in the entity '{1}'", _memberName, entity.LLBLGenProEntityName));
			}

			if(memberData == null)
			{
				// no values to aggregate on as the member itself is null. The function can't continue, so it will result in false.
				return false;
			}
			IList memberDataAsList = memberData as IList;
			if(memberDataAsList == null)
			{
				// this aggregate predicate can only work on collections. 
				throw new ORMInterpretationException(string.Format("The member '{0}' of entity '{1}' isn't a collection (it doesn't implement IList). AggregateSetPredicate only works on collections.",
						_memberName, entity.LLBLGenProEntityName));
			}

			// we have a collection. The elements in this collection have to be interpretable by the value producer. 
			ArrayList valuesToAggregate = new ArrayList();
			IPredicateInterpret filterInterpreter = _setFilter as IPredicateInterpret;
			if(_valueProducerIsCallback)
			{
				foreach(IEntityCore entityInMember in memberDataAsList)
				{
					if(filterInterpreter != null)
					{
						if(!filterInterpreter.Interpret(entityInMember))
						{
							// entity doesn't match the filter, ignore
							continue;
						}
					}
					valuesToAggregate.Add(_valueProducerCallback(entityInMember));
				}
			}
			else
			{
				IExpressionInterpret expressionInterpreter = _valueProducer as IExpressionInterpret;
				foreach(IEntityCore entityInMember in memberDataAsList)
				{
					if(filterInterpreter != null)
					{
						if(!filterInterpreter.Interpret(entityInMember))
						{
							// entity doesn't match the filter, ignore
							continue;
						}
					}
					if(expressionInterpreter == null)
					{
						valuesToAggregate.Add(entityInMember);
					}
					else
					{
						valuesToAggregate.Add(expressionInterpreter.GetValue(entityInMember));
					}
				}
			}

			return PerformAggregateFunction(valuesToAggregate);
		}


		/// <summary>
		/// Performs the aggregate function specified.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>true if the aggregate predicate resolves to true, otherwise false. </returns>
		private bool PerformAggregateFunction(ArrayList valuesToAggregate)
		{
			bool result = false;

			if(_aggregatorIsCallback)
			{
				result = ApplyOperator(_aggregatorCallback(valuesToAggregate));
			}
			else
			{
				switch(_functionToApply)
				{
					case AggregateSetFunction.Avg:
						result = PerformAvg(valuesToAggregate);
						break;
					case AggregateSetFunction.AvgDistinct:
						result = PerformAvgDistinct(valuesToAggregate);
						break;
					case AggregateSetFunction.Count:
						result = PerformCount(valuesToAggregate);
						break;
					case AggregateSetFunction.CountDistinct:
						result = PerformCountDistinct(valuesToAggregate);
						break;
					case AggregateSetFunction.Max:
						result = PerformMax(valuesToAggregate);
						break;
					case AggregateSetFunction.Min:
						result = PerformMin(valuesToAggregate);
						break;
					case AggregateSetFunction.Sum:
						result = PerformSum(valuesToAggregate);
						break;
					case AggregateSetFunction.SumDistinct:
						result = PerformSumDistinct(valuesToAggregate);
						break;
				}
			}
		
			return result ^ base.Negate;
		}


		/// <summary>
		/// Performs the count function and applies the operator on it with the operand
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformCount(ArrayList valuesToAggregate)
		{
			return ApplyOperator(valuesToAggregate.Count);
		}


		/// <summary>
		/// Performs the count function ignoring duplicate values and applies the operator on it with the operand
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformCountDistinct(ArrayList valuesToAggregate)
		{
			ArrayList distinctValues = CreateDistinctList(valuesToAggregate);
			return ApplyOperator(distinctValues.Count);
		}

		/// <summary>
		/// Performs the sum distinct.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformSumDistinct(ArrayList valuesToAggregate)
		{
			ArrayList distinctValues = CreateDistinctList(valuesToAggregate);
			return PerformSum(distinctValues);
		}


		/// <summary>
		/// Performs the sum.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformSum(ArrayList valuesToAggregate)
		{
			if(valuesToAggregate.Count<=0)
			{
				return false;
			}
			if(valuesToAggregate.Count==1)
			{
				return ApplyOperator(valuesToAggregate[0]);
			}
			object leftOperand = NumericValueOperatorExecutor.PerformArithmethicOperation(valuesToAggregate[0], ExOp.Add, valuesToAggregate[1]);
			for(int i = 2; i < valuesToAggregate.Count; i++)
			{
				if(valuesToAggregate[i] == DBNull.Value)
				{
					continue;
				}
				leftOperand = NumericValueOperatorExecutor.PerformArithmethicOperation(leftOperand, ExOp.Add, valuesToAggregate[i]);
			}
			return ApplyOperator(leftOperand);
		}


		/// <summary>
		/// Performs the min.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformMin(ArrayList valuesToAggregate)
		{
			if(valuesToAggregate.Count<=0)
			{
				return false;
			}

			valuesToAggregate.Sort();
			return ApplyOperator(valuesToAggregate[0]);
		}


		/// <summary>
		/// Performs the max.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformMax(ArrayList valuesToAggregate)
		{
			if(valuesToAggregate.Count <= 0)
			{
				return false;
			}

			valuesToAggregate.Sort();
			return ApplyOperator(valuesToAggregate[valuesToAggregate.Count - 1]);
		}


		/// <summary>
		/// Performs the avg distinct.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformAvgDistinct(ArrayList valuesToAggregate)
		{
			ArrayList distinctValues = CreateDistinctList(valuesToAggregate);
			return PerformAvg(distinctValues);
		}


		/// <summary>
		/// Performs the avg.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>the operator application result</returns>
		private bool PerformAvg(ArrayList valuesToAggregate)
		{
			if(valuesToAggregate.Count <= 0)
			{
				return false;
			}
			if(valuesToAggregate.Count == 1)
			{
				return ApplyOperator(valuesToAggregate[0]);
			}
			object leftOperand = NumericValueOperatorExecutor.PerformArithmethicOperation(valuesToAggregate[0], ExOp.Add, valuesToAggregate[1]);
			for(int i = 2; i < valuesToAggregate.Count; i++)
			{
				if(valuesToAggregate[i] == DBNull.Value)
				{
					continue;
				}
				leftOperand = NumericValueOperatorExecutor.PerformArithmethicOperation(leftOperand, ExOp.Add, valuesToAggregate[i]);
			}
			Decimal sumAsDecimal = Convert.ToDecimal(leftOperand);
			return ApplyOperator((sumAsDecimal / Convert.ToDecimal(valuesToAggregate.Count)));
		}


		/// <summary>
		/// Creates a distinct list from the list of values passed in.
		/// </summary>
		/// <param name="valuesToAggregate">The values to aggregate.</param>
		/// <returns>a new list with all distinct values in valuesToAggregate</returns>
		private ArrayList CreateDistinctList(ArrayList valuesToAggregate)
		{
			ArrayList toReturn = new ArrayList();
			Hashtable distinctFilter = new Hashtable();
			foreach(object o in valuesToAggregate)
			{
				if(distinctFilter.ContainsKey(o))
				{
					continue;
				}
				distinctFilter.Add(o, null);
				toReturn.Add(o);
			}

			return toReturn;
		}


		/// <summary>
		/// Applies the operator on the value passed in and the set operand. Value has to be numeric, so if it's not a value type, false will be returned. 
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		private bool ApplyOperator(object value)
		{
			if(!CheckIfOperandIsNumeric(value))
			{
				return false;
			}

			bool toReturn = false;
			Comparer genericComparer = Comparer.DefaultInvariant;
			switch(_operatorToApply)
			{
				case ComparisonOperator.Equal:
					toReturn = value.Equals(_operand);
					break;
				case ComparisonOperator.GreaterEqual:
					toReturn = (genericComparer.Compare(value, _operand) >= 0);
					break;
				case ComparisonOperator.GreaterThan:
					toReturn = (genericComparer.Compare(value, _operand) > 0);
					break;
				case ComparisonOperator.LessEqual:
					toReturn = (genericComparer.Compare(value, _operand) <= 0);
					break;
				case ComparisonOperator.LesserThan:
					toReturn = (genericComparer.Compare(value, _operand) < 0);
					break;
				case ComparisonOperator.NotEqual:
					toReturn = !value.Equals(_operand);
					break;
			}

			return toReturn;
		}
		

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets memberName, which is the name of the member of the entity this predicate is applied on, on which filter has to be applied.
		/// </summary>
		public string MemberName
		{
			get
			{
				return _memberName;
			}
			set
			{
				_memberName = value;
			}
		}

		/// <summary>
		/// Gets / sets the filter to apply to elements of the member (or the member itself in case of a single instance).
		/// </summary>
		public IPredicate SetFilter
		{
			get
			{
				return _setFilter;
			}
			set
			{
				_setFilter = value;
			}
		}


		/// <summary>
		/// Gets the value producer expression. 
		/// </summary>
		public IExpression ValueProducer
		{
			get { return _valueProducer;}
		}
		#endregion
	}
}
