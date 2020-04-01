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
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract transaction class which is used to control a serie of actions on multiple entities or entity collection classes.
	/// The database connection is opened in the constructor, so the transaction instance is ready to use.
	/// This class is the non-COM+ version, it will always start a new ADO.NET transaction and will not be using a COM+ 
	/// transaction when callers are participating in such a transaction.
	/// </summary>
	public abstract class TransactionBase : ITransaction, IDisposable
	{
		#region Private Enums
		/// <summary>
		/// Enum which is used to signal the element removal routine what to do while removing hte elements.
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
			private ArrayList		_participants, _entitiesInTransaction, _participantsInProgress;
			private bool			_isTransactionInProgress, _isDisposed;
			private Hashtable		_savePointNames;
			private ArrayList		_auditorsToNotifyOnCommit;
		#endregion
		
		/// <summary>
		/// CTor. Will read the connection string from an external source.
		/// </summary>
		/// <param name="transactionIsolationLevel">IsolationLevel to use in the transaction</param>
		/// <param name="name">The name of the transaction to use.</param>
		public TransactionBase(IsolationLevel transactionIsolationLevel, string name):this(transactionIsolationLevel, name, null)
		{
		}


		/// <summary>
		/// CTor. 
		/// </summary>
		/// <param name="transactionIsolationLevel">IsolationLevel to use in the transaction</param>
		/// <param name="name">The name of the transaction to use.</param>
		/// <param name="connectionString">Connection string to use in this transaction</param>
		public TransactionBase(IsolationLevel transactionIsolationLevel, string name, string connectionString)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.CTor(3)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction name: {0}. Isolation level: {1}.", name, transactionIsolationLevel.ToString()));

			_transactionIsolationLevel = transactionIsolationLevel;
			_name = name;
			_participants = new ArrayList();
			_participantsInProgress = new ArrayList();

			if( connectionString == null )
			{
				_connectionToUse = CreateConnection();
				_connectionString = _connectionToUse.ConnectionString;
			}
			else
			{
				_connectionString = connectionString;
				_connectionToUse = CreateConnection( connectionString );
			}

			if(_connectionToUse.State!=ConnectionState.Open)
			{
				_connectionToUse.Open();
			}
			_physicalTransaction = CreatePhysicalTransaction();
			_entitiesInTransaction = new ArrayList();
			_savePointNames = new Hashtable();

			if(_physicalTransaction!=null)
			{
				_isTransactionInProgress=true;
			}
			_auditorsToNotifyOnCommit = new ArrayList();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.CTor", "Method Exit");
		}


		/// <summary>
		/// Commits the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. When used in combination of COM+, it will
		/// call ContextUtil.SetCommit() to commit the current COM+ transaction.
		/// </summary>
		public void Commit()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Commit", "Method Enter");

			if(_physicalTransaction==null)
			{
				// no transaction going on, however this situation should not happen.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Commit: No transaction in progress.", "Method Exit");
				return;
			}

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Commit: No transaction in progress.", "Method Exit");
				return;
			}

			// if there were any auditors in entities inside this transaction, gather the audit entities they might have to persist and save them.
			GatherAndFlushAuditData();

			// commit the transaction
			_physicalTransaction.Commit();
			_isTransactionInProgress = false;
			_connectionToUse.Close();

			// Commit and Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendCommit);

			// any auditor has to be notified that the commit was successful. This allows an auditor to clear audit entity objects, if any.
			NotifyAuditorsForCommit();

			// reset this object.
			Reset();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Commit", "Method Exit");
		}


		/// <summary>
		/// Adds the passed in object as a participant of this transaction. 
		/// </summary>
		/// <param name="participant">The ITransactionalElement implementing object which actions have to be included in this transaction</param>
		public void Add(ITransactionalElement participant)
		{
			if(!participant.ParticipatesInTransaction)
			{
				// doesn't participate in a transaction yet. add it to this transaction.
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
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback", "Method Enter");

			if(_physicalTransaction==null)
			{
				// no transaction going on, however this situation should not happen.
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback: No transaction in progress.", "Method Exit");
				return;
			}

			if(!_isTransactionInProgress)
			{
				// no transaction going on
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback: No transaction in progress.", "Method Exit");
				return;
			}

			// rollback the transaction
			_physicalTransaction.Rollback();
			_isTransactionInProgress = false;
			_connectionToUse.Close();

			// Remove all objects participating in this transaction from this transaction.
			RemoveElementsFromTransaction(ActionToPerformDuringRemove.SendRollback);

			// reset this object.
			Reset();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback", "Method Exit");
		}


		/// <summary>
		/// Implements the IDispose' method Dispose.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		/// <summary>
		/// Creates a savepoint with the name savePointName in the current transaction. You can roll back to this savepoint using
		/// <see cref="Rollback(string)"/>.
		/// </summary>
		/// <param name="savePointName">name of savepoint. Must be unique in an active transaction</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null or there is already a savepoint defined with the name specified</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction saving or when COM+ is used.</exception>
		public virtual void Save(string savePointName)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Save", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction saved under name: {0}", savePointName));

			if((savePointName==null)||(savePointName.Length<=0))
			{
				throw new ArgumentException("savePointName can't be null or empty", "savePointName");
			}

			if(_physicalTransaction==null)
			{
				throw new InvalidOperationException("No transaction in progress.");
			}

			if(_savePointNames.ContainsKey(savePointName))
			{
				throw new ArgumentException("There is already a savepoint defined with the name '" + savePointName + "'", "savePointName");
			}

			// Get the Save method
			MethodInfo saveMethod = _physicalTransaction.GetType().GetMethod("Save");

			if(saveMethod==null)
			{
				// save not found, not supported.
				throw new NotSupportedException("The used .NET database provider doesn't support transaction saving, no Save(string) method present.");
			}

			// Invoke Save method
			saveMethod.Invoke(_physicalTransaction, new object[] {savePointName});
			_savePointNames.Add(savePointName, null);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Save", "Method Exit");
		}


		
		/// <summary>
		/// Rolls back the transaction in action to the savepoint with the name savepointName. No internal objects are being reset when this method is called,
		/// so call this Rollback overload only to roll back to a savepoint. To roll back a complete transaction, call Rollback() without specifying a savepoint
		/// name. Create a savepoint by calling Save(savePointName)
		/// </summary>
		/// <param name="savePointName">name of the savepoint to roll back to.</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null or there is no savepoint defined with the name specified</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction rolling back a transaction to a named
		/// point or when COM+ is used.</exception>
		/// <remarks>Not supported when using COM+</remarks>
		public virtual void Rollback(string savePointName)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback(1)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction will be rolled back to savepoint: {0}", savePointName));

			if((savePointName==null)||(savePointName.Length<=0))
			{
				throw new ArgumentException("savePointName can't be null or empty", "savePointName");
			}

			if(_physicalTransaction==null)
			{
				throw new InvalidOperationException("No transaction in progress.");
			}

			if(!_savePointNames.ContainsKey(savePointName))
			{
				throw new ArgumentException("There is no savepoint defined with the name '" + savePointName + "'", "savePointName");
			}

			// Get the Rollback method
			MethodInfo rollbackMethod = _physicalTransaction.GetType().GetMethod("Rollback", new Type[] {typeof(string)});
		
			if(rollbackMethod==null)
			{
				// save not found, not supported.
				throw new NotSupportedException("The used .NET database provider doesn't support transaction rollback to a given point, no Rollback(string) method present.");
			}

			// Invoke rollback method
			rollbackMethod.Invoke(_physicalTransaction, new object[] {savePointName});
			_savePointNames.Remove(savePointName);

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "TransactionBase.Rollback(1)", "Method Exit");
		}


		/// <summary>
		/// Adds the auditor passed in to the set of auditors to get audit entities from at commit. 
		/// </summary>
		/// <param name="toAdd">To add.</param>
		internal void AddAuditor(IAuditor toAdd)
		{
			if(toAdd == null)
			{
				return;
			}

			_auditorsToNotifyOnCommit.Add(toAdd);
		}


		/// <summary>
		/// Implements the Dispose functionality.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose(bool isDisposing)
		{
			// Check to see if Dispose has already been called.
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					// Dispose managed resources.
					if(_physicalTransaction != null)
					{
#if !CF
						_physicalTransaction.Dispose();
#endif
						_physicalTransaction = null;
					}
					if(_connectionToUse != null)
					{
						// closing the connection will abort (rollback) any pending transactions
						if(_connectionToUse.State == ConnectionState.Open)
						{
							_connectionToUse.Close();
						}
#if !CF
						_connectionToUse.Dispose();
#endif
						_connectionToUse = null;
					}
					_isDisposed = true;
				}
			}
		}


		/// <summary>
		/// Notifies the auditors that the transaction was committed. This means they should clean up any audit entities they contain.
		/// </summary>
		private void NotifyAuditorsForCommit()
		{
			foreach(IAuditor auditor in _auditorsToNotifyOnCommit)
			{
				auditor.TransactionCommitted();
			}
		}


		/// <summary>
		/// Gathers the audit entities to save and then saves them in 1 go.
		/// </summary>
		private void GatherAndFlushAuditData()
		{
			ArrayList entitiesToSave = new ArrayList();

			foreach(IAuditor auditor in _auditorsToNotifyOnCommit)
			{
				IList entitiesToPersist = auditor.GetAuditEntitiesToSave();
				if((entitiesToPersist == null) || (entitiesToPersist.Count <= 0))
				{
					continue;
				}
				foreach(IEntity entity in entitiesToPersist)
				{
					entitiesToSave.Add(entity);
				}
			}

			if(entitiesToSave.Count > 0)
			{
				foreach(IEntity toSave in entitiesToSave)
				{
					Add((ITransactionalElement)toSave);
					toSave.Save(true);
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
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionBase.Reset", "Method Enter");

			// test if there is a transaction going on.
			if(_isTransactionInProgress)
			{
				Rollback();
			}

			RemoveElementsFromTransaction(ActionToPerformDuringRemove.None);

			_participants.Clear();

			// reset the class
			_physicalTransaction = null;
			if(_connectionToUse!=null)
			{
				if(_connectionToUse.State == ConnectionState.Open)
				{
					_connectionToUse.Close();
				}
#if !CF
				_connectionToUse.Dispose();
#endif
				_connectionToUse = null;
			}

			_entitiesInTransaction.Clear();
			
			// no longer needed
			_auditorsToNotifyOnCommit.Clear();

			_isTransactionInProgress = false;

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "TransactionBase.Reset", "Method Exit");
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
		public ArrayList EntitiesInTransaction
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
		public ArrayList ParticipantsInProgress 
		{
			get
			{
				return _participantsInProgress;
			}
		}

		#endregion
	}
}
