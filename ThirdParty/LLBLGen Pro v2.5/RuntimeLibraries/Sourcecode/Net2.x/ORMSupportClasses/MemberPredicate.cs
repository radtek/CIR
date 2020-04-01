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
	/// Predicate class which allows in-memory filters to perform a predicate on one or more related entities. The entity this predicate
	/// is applied on has to have a member property with the name specified. Each element in that member (or the member itself, in case of a 
	/// single instance) will be interpreted with the specified filter. The result of that interpretation is used together with the MemberOperator specified
	/// what the result of this predicate will be: true or false, in which case the entity this predicate is applied on is accepted (true) or not (false).
	/// </summary>
	/// <remarks>Meant for in-memory filtering. Can't be used in database targeting filters.</remarks>
	[Serializable]
	public class MemberPredicate : Predicate
	{
		#region Class Member Declarations
		private string _memberName;
		private MemberOperator _operatorToUse;
		private IPredicate _filter;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="MemberPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="filter">The filter to apply to elements of the member (or the member itself in case of a single instance).</param>
		public MemberPredicate(string memberName, MemberOperator operatorToUse, IPredicate filter)
			: this(memberName, operatorToUse, filter, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="MemberPredicate"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member of the entity this predicate is applied on, on which filter has to be applied.</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="filter">The filter to apply to elements of the member (or the member itself in case of a single instance).</param>
		/// <param name="negate">If true, the result of the MemberPredicate will be negated prior to return.</param>
		public MemberPredicate(string memberName, MemberOperator operatorToUse, IPredicate filter, bool negate)
		{
			if(string.IsNullOrEmpty(memberName))
			{
				throw new ArgumentException("memberName has to be specified", "memberName");
			}
			if((filter == null) && (operatorToUse != MemberOperator.Null))
			{
				throw new ArgumentNullException("filter can't be null", "filter");
			}
			_memberName = memberName;
			_filter = filter;
			base.Negate = negate;
			_operatorToUse = operatorToUse;
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
			bool result = false;

			// get the members. 
			Dictionary<string, object> allMemberData = ((IEntityCoreInternal)entity).CallGetRelatedData();

			object memberData = null;
			if(!allMemberData.TryGetValue(_memberName, out memberData))
			{
				// member not found. 
				throw new ORMInterpretationException(string.Format("The member '{0}' isn't found in the entity '{1}'", _memberName, entity.LLBLGenProEntityName));
			}

			IPredicateInterpret filterToUse = (IPredicateInterpret)_filter;

			if(memberData == null)
			{
				result = (_operatorToUse == MemberOperator.Null);
			}
			else
			{
				IList memberDataAsList = memberData as IList;
				if(memberDataAsList == null)
				{
					// single instance. Apply filter to this single instance, which has to be an IEntityCore
					IEntityCore memberDataAsIEntityCore = memberData as IEntityCore;
					if(memberDataAsIEntityCore == null)
					{
						throw new ORMInterpretationException(string.Format("The data of the member '{0}' in entity '{1}' isn't an entity.", _memberName, entity.LLBLGenProEntityName));
					}
					result = filterToUse.Interpret(memberDataAsIEntityCore);
				}
				else
				{
					// collection. apply filter to all elements in list.
					// set start values for result, depending on operator.
					switch(_operatorToUse)
					{
						case MemberOperator.All:
							result = (memberDataAsList.Count > 0);
							break;
						case MemberOperator.Any:
							result = false;
							break;
					}
					bool quitLoop = false;
					foreach(IEntityCore containedEntity in memberDataAsList)
					{
						if(quitLoop)
						{
							break;
						}
						switch(_operatorToUse)
						{
							case MemberOperator.All:
								result &= filterToUse.Interpret(containedEntity);
								if(!result)
								{
									// already failed, will never be true again
									quitLoop = true;
								}
								break;
							case MemberOperator.Any:
								result |= filterToUse.Interpret(containedEntity);
								if(result)
								{
									// already true, found the one we're looking for
									quitLoop = true;
								}
								break;
						}
					}
				}
			}

			return result ^ base.Negate;
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
			string notString = string.Empty;
			if(base.Negate)
			{
				notString = "NOT ";
			}
			_filter.DatabaseSpecificCreator = base.DatabaseSpecificCreator;
			return string.Format("{0}{1} {2} where {3}", notString, _operatorToUse.ToString(), _memberName, _filter.ToQueryText(ref uniqueMarker, inHavingClause));
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
		/// Gets / sets operatorToUse
		/// </summary>
		public MemberOperator OperatorToUse
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
		/// Gets / sets the filter to apply to elements of the member (or the member itself in case of a single instance).
		/// </summary>
		public IPredicate Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}
		#endregion

	}
}
