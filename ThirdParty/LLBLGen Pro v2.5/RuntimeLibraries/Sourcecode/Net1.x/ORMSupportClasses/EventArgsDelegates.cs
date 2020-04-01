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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Event handler for events which are raised by the collection classes and are related to the contents of the collection being changed.
	/// </summary>
	public delegate void CollectionChangedEventHandler(object sender, CollectionChangedEventArgs e);
	/// <summary>
	/// Event handler for events which are raised by the collection classes and are related to the contents of the collection being changed and which are
	/// cancelable.
	/// </summary>
	public delegate void CancelableCollectionChangedEventHandler(object sender, CancelableCollectionChangedEventArgs e);
	/// <summary>
	/// Callback for the AggregateSetPredicate, which is used to aggregate over the set of values passed in. 
	/// </summary>
	/// <param name="valuesToAggregate">the values to aggregate. </param>
	/// <returns>the aggregation result of the values passed in.</returns>
	public delegate object AggregateSetPredicateCallback(IList valuesToAggregate);
	/// <summary>
	/// Callback for the AggregateSetPredicate, which is used to interpret a passed in entity and return the value to add to the set of values to aggregate
	/// in the AggregateSetPredicate. 
	/// </summary>
	/// <param name="toInterpret">The entity to interpret</param>
	/// <returns>the interpretation result of the passed in entity. This value is then added to the list of values to aggregate in the AggregateSetPredicate</returns>
	public delegate object InterpretSetValueCallback(IEntityCore toInterpret);
	/// <summary>
	/// Callback for the DelegatePredicate, which is used to perform the interpretation of the passed in entity. 
	/// </summary>
	/// <param name="toInterpret">The entity to interpret</param>
	/// <returns>true if the entity is accepted by the callback, otherwise false.</returns>
	public delegate bool DelegatePredicateCallback(IEntityCore toInterpret);

	/// <summary>
	/// EventArgs class for events raised by the entity collection classes for various actions. 
	/// </summary>
	public class CollectionChangedEventArgs : EventArgs
	{
		#region Class Member Declarations
		private IEntityCore _involvedEntity;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public CollectionChangedEventArgs( IEntityCore involvedEntity )
		{
			_involvedEntity = involvedEntity;
		}

		/// <summary>
		/// Gets / sets the entity involved in the action which took place and which triggered the raised event.
		/// </summary>
		public IEntityCore InvolvedEntity
		{
			get
			{
				return _involvedEntity;
			}
			set
			{
				_involvedEntity = value;
			}
		}
	}


	/// <summary>
	/// Event args which are used for collection changed events and which is raised by cancelable actions. Set the Cancel flag to cancel the action
	/// which raised the event. 
	/// </summary>
	public class CancelableCollectionChangedEventArgs : CollectionChangedEventArgs
	{
		#region Class Member Declarations
		private bool _cancel;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CancelableCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public CancelableCollectionChangedEventArgs( IEntityCore involvedEntity )
			: base( involvedEntity )
		{
		}

		/// <summary>
		/// Gets / sets the cancel flag to cancel the action.
		/// </summary>
		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}
	}
}
