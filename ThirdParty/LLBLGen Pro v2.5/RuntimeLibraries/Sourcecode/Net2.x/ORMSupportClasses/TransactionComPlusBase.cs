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
using System.Data;
using System.EnterpriseServices;
using System.Diagnostics;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract transaction class which is used to control a serie of actions on multiple entities or entity collection classes.
	/// The database connection is opened in the constructor so the COM+ transaction is flowing into the creation of the database connection.
	/// No ADO.NET transaction is started, everything runs in the containing COM+ transaction.
	/// This class is the COM+ version, it will never start a new ADO.NET transaction and will always be using a COM+ 
	/// transaction. All actions MUST be explicitly be commited or rolled back (aborted), there is no autocomplete implemented in this
	/// class.
	/// </summary>
	public abstract class TransactionComPlusBase: ServicedComponent, ITransaction, IDisposable
	{
		#region Private Enums
		/// <summary>
		/// Enum which is used to signal the element removal routine what to do while removing the elements.
		/// This is a performance issue, now the loop has to be run just once
		/// </summary>
		private enum ActionToPerformDuringRemove:int
		{
			/// <summary>
			/// No action
			/// </summary>
			None, 
			/// <summary>
			/// Call ITransactionalElement.TransactionCommit()
			/// </summary>
			SendCommit,
			/// <summary>
			/// Call ITransactionalElement.TransactionRollback()
			/// </summary>
			SendRollback
		}
		#endregion

		#region Class Member Declarations
		private IsolationLevel	_transactionIsolationLevel;
		private string			_name, _connectionString;
		private IDbConnection	_connectionToUse;
		private IDbTransaction	_physicalTransaction;
		private List<ITransactionalElement> _participants;
		private List<Guid> _entitiesInTransaction, _participantsInProgress;
		private bool			_isTransactionInProgress, _isDisposed;
		private int				_recursionCounter;
		#endregion
		
		/// <summary>
		/// CTor. Will read the connection string from an external source.
		/// </summary>
		public TransactionComPlusBase()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.CTor", "Method Enter");

			_transactionIsolationLevel = IsolationLevel.ReadCommitted;
			_name = "LLBLGenProComPlusTransaction";
			_participants = new List<ITransactionalElement>();
			_participantsInProgress = new List<Guid>();

			_connectionToUse = CreateConnection();
			_connectionString = _connectionToUse.ConnectionString;
			_connectionToUse.Open();
			// Will not be used in this class.
			_physicalTransaction = CreatePhysicalTransaction();
			// transaction is active, it's a COM+ transaction
			_isTransactionInProgress=true;
			_entitiesInTransaction = new List<Guid>();
			_recursionCounter = 0;

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.CTor", "Method Exit");
		}


		/// <summary>
		/// CTor. 
		/// </summary>
		/// <param name="connectionString">Connection string to use in this transaction</param>
		public TransactionComPlusBase(string connectionString)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.CTor(1)", "Method Enter");

			_transactionIsolationLevel = IsolationLevel.ReadCommitted;
			_name = "LLBLGenProComPlusTransaction";
			_connectionString = connectionString;
			_participants = new List<ITransactionalElement>();
			_participantsInProgress = new List<Guid>();

			_connectionToUse = CreateConnection(connectionString);
			_connectionToUse.Open();
			// Will not be used in this class.
			_physicalTransaction = CreatePhysicalTransaction();
			// transaction is active, it's a COM+ transaction
			_isTransactionInProgress=true;
			_entitiesInTransaction = new List<Guid>();
			_recursionCounter = 0;

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.CTor(1)", "Method Exit");
		}


		/// <summary>
		/// Commits the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. When used in combination of COM+, it will
		/// call ContextUtil.SetComplete() to commit the current COM+ transaction.
		/// </summary>
		public void Commit()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Commit", "Method Enter");

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Commit: No transaction in progress.", "Method Exit");
				return;
			}

			_connectionToUse.Close();
			// Commit and Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendCommit);

			// Flag to commit the transaction
			ContextUtil.MyTransactionVote = TransactionVote.Commit;
			_isTransactionInProgress = false;

			// reset this object.
			Reset();
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Commit", "Method Exit");
		}


		/// <summary>
		/// Adds the passed in object as a participant of this transaction. 
		/// </summary>
		/// <param name="participant">The ITransactionalElement implementing object which actions have to be included in this transaction</param>
		public void Add(ITransactionalElement participant)
		{
			if(!_participants.Contains(participant))
			{
				_participants.Add(participant);
				participant.Transaction = this;
			}
		}


		/// <summary>
		/// Removes the passed in object from the transaction.
		/// </summary>
		/// <param name="participant">The ITransactionalElement implementing object which should be removed from this transaction</param>
		public void Remove(ITransactionalElement participant)
		{
			if(_participants.Contains(participant))
			{
				_participants.Remove(participant);
				participant.Transaction = null;
			}
		}


		/// <summary>
		/// Rolls back the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. When used in combination of COM+, it will
		/// call ContextUtil.SetAbort() to abort (rollback) the current COM+ transaction.
		/// </summary>
		public void Rollback()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Rollback", "Method Enter");

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Rollback: No transaction in progress.", "Method Exit");
				return;
			}

			_connectionToUse.Close();

			// Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendRollback);

			// rollback the transaction
			ContextUtil.MyTransactionVote = TransactionVote.Abort;
			_isTransactionInProgress = false;

			// reset this object.
			Reset();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionComPlusBase.Rollback", "Method Exit");
		}


		/// <summary>
		/// Increases the recursion counter with 1. If the counter reaches 0, the objectID's in the _entitiesInTransaction collection are removed.
		/// For internal use only.
		/// </summary>
		public void SaveInRecursionStarted()
		{
			_recursionCounter++;
		}


		/// <summary>
		/// Decreases the recursion counter with 1. If the counter reaches 0, the objectID's in the _entitiesInTransaction collection are removed.
		/// For internal use only.
		/// </summary>
		public void SaveInRecursionEnded()
		{
			_recursionCounter--;

			if(_recursionCounter==0)
			{
				_entitiesInTransaction.Clear();
			}
		}


		/// <summary>
		/// Creates a savepoint with the name savePointName in the current transaction. You can roll back to this savepoint using
		/// <see cref="Rollback(string)"/>.
		/// </summary>
		/// <param name="savePointName">name of savepoint. Must be unique in an active transaction</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null</exception>
		/// <remarks>Not supported in COM+. Throws NotSupportedException.</remarks>
		public virtual void Save(string savePointName)
		{
			throw new NotSupportedException("In COM+, savepoints are not supported.");
		}


		/// <summary>
		/// Rolls back the transaction in action to the savepoint with the name savepointName. No internal objects are being reset when this method is called,
		/// so call this Rollback overload only to roll back to a savepoint. To roll back a complete transaction, call Rollback() without specifying a savepoint
		/// name. Create a savepoint by calling Save(savePointName)
		/// </summary>
		/// <param name="savePointName">name of the savepoint to roll back to.</param>
		/// <remarks>Not supported in COM+. Throws NotSupportedException.</remarks>
		public virtual void Rollback(string savePointName)
		{
			throw new NotSupportedException("In COM+, savepoints are not supported.");
		}


		/// <summary>
		/// Implements the Dispose functionality.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected override void Dispose(bool isDisposing)
		{
			// Check to see if Dispose has already been called.
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					// Dispose managed resources.
					if(_connectionToUse != null)
					{
						// closing the connection will abort (rollback) any pending transactions
						if(_connectionToUse.State == ConnectionState.Open)
						{
							_connectionToUse.Close();
						}
						_connectionToUse.Dispose();
						_connectionToUse = null;
					}
					base.Dispose(isDisposing);
					_isDisposed = true;
				}
			}
		}


		/// <summary>
		/// Removes all participating elements from this transaction and sends them a commit or rollback signal, based on the passed in boolean Commit.
		/// This action will make the participating objects to take care of their own connections again.
		/// </summary>
		/// <param name="action">Action to perform on each removed element.</param>
		private void RemoveElementsFromTransaction(ActionToPerformDuringRemove action)
		{
			for(int i=0;i<_participants.Count;i++)
			{
				ITransactionalElement participant = (ITransactionalElement)_participants[i];
				switch(action)
				{
					case ActionToPerformDuringRemove.None:
						// do nothing
						break;
					case ActionToPerformDuringRemove.SendCommit:
						participant.TransactionCommit();
						break;
					case ActionToPerformDuringRemove.SendRollback:
						participant.TransactionRollback();
						break;
				}
				participant.Transaction = null;
			}
		}


		/// <summary>
		/// Resets the transaction object. All participants will be notified.
		/// </summary>
		private void Reset()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionComPlusBase.Reset", "Method Enter");

			// test if there is a transaction going on.
			if(_isTransactionInProgress)
			{
				Rollback();
			}

			RemoveElementsFromTransaction(ActionToPerformDuringRemove.None);

			_participants.Clear();
			_participantsInProgress.Clear();
	
			// reset the class
			_physicalTransaction = null;
			if(_connectionToUse!=null)
			{
				if(_connectionToUse.State == ConnectionState.Open)
				{
					_connectionToUse.Close();
				}
				_connectionToUse.Dispose();
				_connectionToUse = null;
			}

			_isTransactionInProgress = false;

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionComPlusBase.Reset", "Method Exit");
		}

        
		/// <summary>
		/// Creates a new IDbConnection instance which will be used by all elements using this ITransaction instance. 
		/// Reads connectionstring from .config file.
		/// </summary>
		/// <returns>new IDbConnection instance</returns>
		protected abstract IDbConnection CreateConnection();

		/// <summary>
		/// Creates a new IDbConnection instance which will be used by all elements using this ITransaction instance
		/// </summary>
		/// <param name="connectionString">Connection string to use</param>
		/// <returns>new IDbConnection instance</returns>
		protected abstract IDbConnection CreateConnection(string connectionString);

		/// <summary>
		/// Creates a new physical transaction object over the created connection. The connection is assumed to be open.
		/// </summary>
		/// <returns>a physical transaction object, like an instance of SqlTransaction.</returns>
		protected abstract IDbTransaction CreatePhysicalTransaction();

		#region Class Property Declarations
		/// <summary>
		/// Gets the isolation level the transaction should use. Only settable with the constructor.
		/// </summary>
		public virtual IsolationLevel TransactionIsolationLevel
		{
			get
			{
				return _transactionIsolationLevel;
			}
		}

		/// <summary>
		/// Gets the name of the transaction. Only settable with the constructor.
		/// </summary>
		public virtual string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// Gets the connection string used for the connection with the database. Only settable with the constructor.
		/// </summary>
		public virtual string ConnectionString
		{
			get
			{
				return _connectionString;
			}
		}

		/// <summary>
		/// The connection object to use with this transaction. 
		/// </summary>
		public virtual IDbConnection ConnectionToUse
		{
			get
			{
				return _connectionToUse;
			}
		}

		/// <summary>
		/// The physical transaction object used over <see cref="ConnectionToUse"/>.
		/// </summary>
		public virtual IDbTransaction PhysicalTransaction
		{
			get
			{
				return _physicalTransaction;
			}
		}

		/// <summary>
		/// ArrayList of GUID's of the entities currently participating in this transaction. This collection is
		/// used to keep track of which entities already have been added during a recursive save.
		/// </summary>
		public List<Guid> EntitiesInTransaction
		{
			get
			{
				return _entitiesInTransaction;
			}
		}

		/// <summary>
		/// ArrayList of GUID's of the entities currently participating in this transaction which are in progress, i.e. their
		/// Save() routine has been called but execution is transfered to a dependent object first.
		/// </summary>
		public List<Guid> ParticipantsInProgress 
		{
			get
			{
				return _participantsInProgress;
			}
		}

		#endregion
	}
}
