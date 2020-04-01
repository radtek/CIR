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
using System.Collections;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the ActionQuery class. 
	/// </summary>
	[Serializable]
	public class ActionQuery : Query, IActionQuery
	{
		#region Class Member Declarations
		private ArrayList _sequenceRetrievalQueries, _parameterParameterRelations;
		
		[NonSerialized]
		private bool			_disposed;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="commandToUse">Command to use</param>
		public ActionQuery(IDbCommand commandToUse):base(commandToUse)
		{
			_sequenceRetrievalQueries = new ArrayList();
			_parameterParameterRelations = new ArrayList();
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="connectionToUse">Connection object to use</param>
		/// <param name="commandToUse">Command to use</param>
		public ActionQuery(IDbConnection connectionToUse, IDbCommand commandToUse)
				:base(connectionToUse, commandToUse)
		{
			_sequenceRetrievalQueries = new ArrayList();
			_parameterParameterRelations = new ArrayList();
		}


		/// <summary>
		/// Produces a string representation of this query.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder description = new StringBuilder(2048);
			description.Append(base.ToString() + "\r\n");
			foreach(ISequenceRetrievalQuery sequenceQuery in _sequenceRetrievalQueries)
			{
				description.AppendFormat(null, "\tSequence query: {0}\r\n", sequenceQuery.ToString());
			}

			return description.ToString();
		}


		/// <summary>
		/// Executes the query contained by the IQuery instance. If there was nothing to execute, 0 is returned.
		/// </summary>
		/// <returns>The number of rows affected (if applicable), otherwise 0.</returns>
		/// <exception cref="System.InvalidOperationException">When there is no command object inside the query object, 
		/// or no connection object inside the query object</exception>
		/// <exception cref="ORMQueryExecutionException">when an exception was caught during query execution</exception>
		public int Execute()
		{
			if(base.Command==null)
			{
				throw new InvalidOperationException("No Command present. Nothing to execute.");
			}

			if(base.Connection==null)
			{
				throw new InvalidOperationException("No Connection present. Cannot execute command.");
			}

			// check if there is something to execute
			if(base.Command.CommandText.Length==0)
			{
				// no. return 'succeeded' (1 row affected at least)
				return 1;
			}

			bool wasConnectionClosed = (base.Connection.State != ConnectionState.Open);

			// execute the query
			try
			{
				if(wasConnectionClosed)
				{
					base.Connection.Open();
				}
				else
				{
					// wire a transaction object with all sequence retrieval queries
					if(base.Command.Transaction!=null)
					{
						for (int i = 0; i < _sequenceRetrievalQueries.Count; i++)
						{
							ISequenceRetrievalQuery sequenceQuery = (ISequenceRetrievalQuery)_sequenceRetrievalQueries[i];
							if(sequenceQuery.SequenceRetrievalCommand!=null)
							{
								sequenceQuery.SequenceRetrievalCommand.Transaction = base.Command.Transaction;
							}
						}
					}
				}

				// execute pre-query sequence retrieval queries
				for (int i = 0; i < _sequenceRetrievalQueries.Count; i++)
				{
					ISequenceRetrievalQuery sequenceQuery = (ISequenceRetrievalQuery)_sequenceRetrievalQueries[i];
					if(sequenceQuery.ExecuteSequenceCommandFirst)
					{
						sequenceQuery.Execute();
					}
				}
				// sync parameter-parameter relations set, if any. This will make sure the sequence values returned by a previous action query in a batch
				// are synced with parameters used for this query.
				SyncParameterParameterRelations();

				int returnValue = base.Command.ExecuteNonQuery();

				// execute post-query sequence retrieval queries
				for (int i = 0; i < _sequenceRetrievalQueries.Count; i++)
				{
					ISequenceRetrievalQuery sequenceQuery = (ISequenceRetrievalQuery)_sequenceRetrievalQueries[i];
					if(!sequenceQuery.ExecuteSequenceCommandFirst)
					{
						sequenceQuery.Execute();
					}
				}

				// sync parameter-parameter relations set, if any. This will make sure the sequence values returned by a previous action query in a batch
				// are synced with parameters used for this query.
				SyncParameterParameterRelations();

				if(returnValue>0)
				{
					// reflect new PK field values retrieved, if any, in their related fields. 
					base.ReflectOutputValuesInRelatedFields();
				}
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, this, "Executed Sql Query");
				return returnValue;
			}
			catch(Exception ex)
			{
				// throw a catchable exception with detailed query information.
				throw new ORMQueryExecutionException(
						String.Format("An exception was caught during the execution of an action query: {0}. Check InnerException, QueryExecuted and Parameters of this exception to examine the cause of this exception.", ex.Message), 
						base.ToString(), base.Parameters, ex, base.GetExceptionInfo(ex));
			}
			finally
			{
				if(wasConnectionClosed)
				{
					base.Connection.Close();
				}
			}
		}


		/// <summary>
		/// Performs the dispose action.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected override void Dispose(bool isDisposing)
		{
			if(!_disposed)
			{
				if(isDisposing)
				{
					base.Dispose (isDisposing);
					foreach(ISequenceRetrievalQuery query in _sequenceRetrievalQueries)
					{
						query.Dispose();
					}
					_disposed = true;
				}
			}
		}


		/// <summary>
		/// Syncs the parameter parameter relations.
		/// </summary>
		private void SyncParameterParameterRelations()
		{
			foreach(ParameterParameterRelation relation in _parameterParameterRelations)
			{
				relation.Sync();
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Array list of ISequenceRetrievalQuery objects which are used to produce sequence values for input/output parameters in
		/// this query. Normally this collection is empty, as it is only used when the target database provider doesn't support batched
		/// queries (firebird/access/sqlce and others). Execute will wire the transaction if present. 
		/// </summary>
		public ArrayList SequenceRetrievalQueries 
		{ 
			get { return _sequenceRetrievalQueries;}
		}

		/// <summary>
		/// Gets the parameter parameter relations for this IActionQuery. These definitions are used for insert queries in multi-target entity inserts.
		/// </summary>
		/// <value></value>
		public ArrayList ParameterParameterRelations
		{
			get { return _parameterParameterRelations; }
		}
		#endregion


	}
}
