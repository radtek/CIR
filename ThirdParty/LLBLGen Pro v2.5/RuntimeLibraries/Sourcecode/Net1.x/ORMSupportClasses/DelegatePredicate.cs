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
	/// Predicate class to filter in-memory entity collections based on a specified callback function. 
	/// </summary>
	/// <remarks>Meant for in-memory filtering. Can't be used in database targeting filters.</remarks>
	public class DelegatePredicate : Predicate
	{
		#region Class Member Declarations
		private DelegatePredicateCallback _callback;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DelegatePredicate"/> class.
		/// </summary>
		/// <param name="callback">The callback to call for entity interpretation.</param>
		public DelegatePredicate(DelegatePredicateCallback callback)
			: this(callback, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="DelegatePredicate"/> class.
		/// </summary>
		/// <param name="callback">The callback to call for entity interpretation.</param>
		/// <param name="negate">flag to negate the results of the predicate</param>
		public DelegatePredicate(DelegatePredicateCallback callback, bool negate)
		{
			if(callback == null)
			{
				throw new ArgumentNullException("callback can't be null", "callback");
			}

			_callback = callback;
			base.Negate = negate;
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
		protected override bool InterpretPredicate(IEntityCore entity)
		{
			return _callback(entity) ^ base.Negate;
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
			throw new ORMQueryConstructionException("The predicate DelegatePredicate can only be used in in-memory filters.");
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
			throw new ORMQueryConstructionException("The predicate DelegatePredicate can only be used in in-memory filters.");
		}
	}
}
