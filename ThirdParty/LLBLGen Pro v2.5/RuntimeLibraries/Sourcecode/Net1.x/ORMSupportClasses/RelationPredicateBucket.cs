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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// IRelationPredicateBucket implementation which can be used as a single unit to pass to a data-access adapter for 
	/// filtering over multi-entities.
	/// </summary>
	[Serializable]
	public class RelationPredicateBucket : IRelationPredicateBucket, ICloneable
	{
		#region Class Member Declarations
		private RelationCollection		_relations;
		private PredicateExpression		_predicateExpression;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public RelationPredicateBucket()
		{
			_relations = new RelationCollection();
			_predicateExpression = new PredicateExpression();
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RelationPredicateBucket"/> class.
		/// </summary>
		/// <param name="filterToUse">Filter to use. Will be set as the initial PredicateExpression contents</param>
		public RelationPredicateBucket(IPredicate filterToUse)
		{
			_relations = new RelationCollection();
			if(filterToUse==null)
			{
				_predicateExpression = new PredicateExpression();
				return;
			}

			PredicateExpression filter = filterToUse as PredicateExpression;
			if(filter==null)
			{
				_predicateExpression = new PredicateExpression(filterToUse);
			}
			else
			{
				_predicateExpression = filter;
			}
		}

		
		/// <summary>
		/// The relation collection with EntityRelation objects which is used in combination with the PredicateExpression in this bucket
		/// </summary>
		public IRelationCollection Relations
		{
			get
			{
				return _relations;
			}
		}

		/// <summary>
		/// The predicate expression to use in combination with the Relations in this bucket.
		/// </summary>
		public IPredicateExpression PredicateExpression
		{
			get
			{
				return _predicateExpression;
			}
		}

		/// <summary>
		/// create a shallow copy of this object.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			RelationPredicateBucket toReturn = new RelationPredicateBucket();
			toReturn.Relations.AddRange((RelationCollection)this.Relations);
			if(this.PredicateExpression.Count>0)
			{
				toReturn.PredicateExpression.Add(this.PredicateExpression);
			}
			toReturn.Relations.ObeyWeakRelations = this.Relations.ObeyWeakRelations;
			return toReturn;
		}
	}
}
