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
using System.Transactions;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Resource manager which is used with System.Transactions transactions: the transaction object manager (DataAccessAdapter or Transaction) will 
	/// enlist itself using an instance of this class with the ambient System.Transactions transaction so when that transaction is completed, the
	/// end result is propagated to the participating entities. This enlistment is automatic and transparent for the developer.
	/// </summary>
	internal class TransactionResourceManager : IEnlistmentNotification
	{
		#region Class Member Declarations
		private ITransactionNotification _transactionManager;
		private bool _commit;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="TransactionResourceManager"/> class.
		/// </summary>
		/// <param name="transactionManager">The LLBLGen Pro transaction manager object</param>
		internal TransactionResourceManager( ITransactionNotification transactionManager )
		{
			if( transactionManager == null )
			{
				throw new ArgumentNullException( "transactionManagement", "transactionManagement can't be null" );
			}
			_transactionManager = transactionManager;
			_commit = true;
		}


		/// <summary>
		/// Notifies an enlisted object that a transaction is being committed.
		/// </summary>
		/// <param name="enlistment">An <see cref="T:System.Transactions.Enlistment"></see> object used to send a response to the transaction manager.</param>
		public void Commit( Enlistment enlistment )
		{
			if( _transactionManager == null )
			{
				return;
			}

			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Commit", "Method Enter" );
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionResourceManager.Commit", "Transaction committed." );
			_transactionManager.NotifyCommit();
			
			// unset transaction management object so they don't keep each other in memory
			_transactionManager = null;
			enlistment.Done();
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Commit", "Method Exit" );
		}

		/// <summary>
		/// Notifies an enlisted object that the status of a transaction is in doubt.
		/// </summary>
		/// <param name="enlistment">An <see cref="T:System.Transactions.Enlistment"></see> object used to send a response to the transaction manager.</param>
		public void InDoubt( Enlistment enlistment )
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.InDoubt", "Transaction is in doubt and couldn't be completed." );
			enlistment.Done();
		}

		/// <summary>
		/// Notifies an enlisted object that a transaction is being prepared for commitment.
		/// </summary>
		/// <param name="preparingEnlistment">A <see cref="T:System.Transactions.PreparingEnlistment"></see> object used to send a response to the transaction manager.</param>
		public void Prepare( PreparingEnlistment preparingEnlistment )
		{
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Prepare", "Method Enter" );
			if( _commit )
			{
				preparingEnlistment.Prepared();
				TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionResourceManager.Prepare", "'Prepared' reported" );
			}
			else
			{
				preparingEnlistment.ForceRollback();
				TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionResourceManager.Prepare", "'ForcedRollback' reported" );
			}
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Prepare", "Method Exit" );
		}

		/// <summary>
		/// Notifies an enlisted object that a transaction is being rolled back (aborted).
		/// </summary>
		/// <param name="enlistment">A <see cref="T:System.Transactions.Enlistment"></see> object used to send a response to the transaction manager.</param>
		public void Rollback( Enlistment enlistment )
		{
			if( _transactionManager == null )
			{
				return;
			}

			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Rollback", "Method Enter" );
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionResourceManager.Rollback", "Transaction rolled back." );
			_transactionManager.NotifyRollback();

			// unset transaction management object so they don't keep each other in memory
			_transactionManager = null;
			enlistment.Done();
			TraceHelper.WriteLineIf( TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionResourceManager.Rollback", "Method Exit" );
		}


		/// <summary>
		/// Sets the transaction outcome vote. This method is called from the transaction management object if Commit or Rollback is called on that object.
		/// </summary>
		/// <param name="performCommit">If false, the resource manager will vote for a rollback, otherwise for a commit. </param>
		/// <remarks>Once the vote has been set to a rollback, it will always report a rollback</remarks>
		internal void SetTransactionOutcomeVote( bool performCommit )
		{
			_commit &= performCommit;
		}
	}
}
