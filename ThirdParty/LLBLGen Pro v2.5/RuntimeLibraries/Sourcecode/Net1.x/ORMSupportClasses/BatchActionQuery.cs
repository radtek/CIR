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
	/// Action query which contains multiple action queries which have to be executed in the order in which they're stored.
	/// Used for multi-target entities, like saving an inherited entity in a target-per-entity hierarchy.
	/// </summary>
	public class BatchActionQuery : IActionQuery
	{
		#region Class Member Declarations
		private ArrayList	_actionQueries;
		private bool		_quitOnPartlyFailure;

		[NonSerialized]
		private bool			_disposed;
		#endregion


		/// <summary>
		/// Creates a new <see cref="BatchActionQuery"/> instance.
		/// </summary>
		public BatchActionQuery()
		{
			_actionQueries = new ArrayList();
			_quitOnPartlyFailure = false;
		}


		/// <summary>
		/// Adds the action query passed in.
		/// </summary>
		/// <param name="query">Query.</param>
		/// <returns>the index in the execution queue</returns>
		public int AddActionQuery(IActionQuery query)
		{
			return _actionQueries.Add(query);
		}


		/// <summary>
		/// Produces a string representation of this batch action query.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder description = new StringBuilder(2048);
			for(int i=0;i<_actionQueries.Count;i++)
			{
				IActionQuery query = (IActionQuery)_actionQueries[i];
				description.AppendFormat(null, "IActionQuery #{0} :\r\n", i);
				description.Append(query.ToString()+ "\r\n");
			}
			return description.ToString();
		}


		/// <summary>
		/// Executes all action queries in this batchactionquery, in the order in which they were added.
		/// </summary>
		/// <returns>The number of rows affected (if applicable) of all queries executed combined, otherwise 0.</returns>
		/// <exception cref="System.InvalidOperationException">When there is no command object inside one or more query objects, 
		/// or no connection object inside the query object</exception>
		/// <exception cref="ORMQueryExecutionException">when an exception was caught during query execution</exception>
		public int Execute()
		{
			int toReturn = 0;
			foreach(IActionQuery query in _actionQueries)
			{
				int result = query.Execute();
				if((result==0) && _quitOnPartlyFailure)
				{
					// failed, quit execution
					toReturn = 0;
					break;
				}
				else
				{
					if(query.Command.CommandText.Length > 0)
					{
						toReturn += result;
					}				
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Adds the parameter field relation.
		/// </summary>
		/// <param name="relation">Relation.</param>
		public void AddParameterFieldRelation(IParameterFieldRelation relation)
		{
			// do nothing, not implemented on batchaction queries.
		}

		/// <summary>
		/// Reflects the output values in related fields for all actionqueries in this batchactionquery.
		/// </summary>
		public void ReflectOutputValuesInRelatedFields()
		{
			foreach(IActionQuery query in _actionQueries)
			{
				query.ReflectOutputValuesInRelatedFields();
			}
		}


		/// <summary>
		/// Wires the command of this query with the transaction passed in.
		/// </summary>
		/// <param name="transactionToWire">the transaction to wire the command with</param>
		public void WireTransaction(IDbTransaction transactionToWire)
		{
			foreach(IActionQuery query in _actionQueries)
			{
				query.WireTransaction(transactionToWire);
			}
		}
		

		/// <summary>
		/// Sets the command timeout.
		/// </summary>
		/// <param name="timeoutInterval">Timeout interval, in seconds.</param>
		public void SetCommandTimeout(int timeoutInterval)
		{
			foreach(IActionQuery query in _actionQueries)
			{
				query.SetCommandTimeout(timeoutInterval);
			}
		}

		
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or
		/// resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		/// <summary>
		/// Performs the dispose action.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose(bool isDisposing)
		{
			if(!_disposed)
			{
				if(isDisposing)
				{
					foreach(IActionQuery query in _actionQueries)
					{
						query.Dispose();
					}
				}
				_disposed=true;
			}
		}

		
		#region Class Property Declarations
		/// <summary>
		/// Gets the actionQueries set in this batch action query object.
		/// </summary>
		public ArrayList ActionQueries
		{
			get
			{
				return _actionQueries;
			}
		}

		/// <summary>
		/// Gets the sequence retrieval queries. Not implemented in BatchActionQueries.
		/// </summary>
		/// <value></value>
		public System.Collections.ArrayList SequenceRetrievalQueries
		{
			get
			{
				throw new NotSupportedException("IActionQuery.SequenceRetrievalQueries get isn't implemented in the BatchActionQuery class");
			}
		}


		/// <summary>
		/// Gets or sets the connection for this action query object. Get will return the connection of the first action query stored.
		/// Set will set the connection on all actionquery objects.
		/// </summary>
		/// <value></value>
		public System.Data.IDbConnection Connection
		{
			get
			{
				if(_actionQueries.Count>0)
				{
					return ((IActionQuery)_actionQueries[0]).Connection;
				}
				return null;
			}
			set
			{
				foreach(IActionQuery query in _actionQueries)
				{
					query.Connection=value;
				}
			}
		}


		/// <summary>
		/// Gets or sets the command. Not implemented on Batch action query objects. Use the indexer instead.
		/// </summary>
		/// <value></value>
		public System.Data.IDbCommand Command
		{
			get
			{
				throw new NotSupportedException("IQuery.Command get isn't implemented in the BatchActionQuery class");
			}
			set
			{
				throw new NotSupportedException("IQuery.Command set isn't implemented in the BatchActionQuery class");
			}
		}


		/// <summary>
		/// Gets the parameters of all queries.
		/// </summary>
		/// <value></value>
		public IList Parameters
		{
			get
			{
				ArrayList toReturn = new ArrayList();
				foreach(IActionQuery query in _actionQueries)
				{
					toReturn.AddRange(query.Parameters);
				}

				return toReturn;
			}
		}


		/// <summary>
		/// Gets the parameter field relations.
		/// </summary>
		/// <value></value>
		public System.Collections.ArrayList ParameterFieldRelations
		{
			get
			{
				throw new NotSupportedException("IActionQuery.ParameterFieldRelations get isn't implemented in the BatchActionQuery class");
			}
		}


		/// <summary>
		/// Gets or sets the <see cref="IDbCommand"/> at the specified index.
		/// </summary>
		/// <value></value>
		public IDbCommand this[int index]
		{
			get { return (IDbCommand)_actionQueries[index]; }
			set { _actionQueries[index] = value;}
		}


		/// <summary>
		/// Gets the number of IActionQueries in this query.
		/// </summary>
		/// <value></value>
		public int Count
		{
			get { return _actionQueries.Count;}
		}

		/// <summary>
		/// Gets the parameter parameter relations for this IActionQuery. These definitions are used for insert queries in multi-target entity inserts.
		/// </summary>
		/// <value></value>
		public ArrayList ParameterParameterRelations
		{
			get { throw new NotSupportedException("BatchActionQuery.ParameterParameterRelations is not supported"); }
		}


		/// <summary>
		/// Gets / sets quitOnPartlyFailure
		/// </summary>
		internal bool QuitOnPartlyFailure
		{
			get
			{
				return _quitOnPartlyFailure;
			}
			set
			{
				_quitOnPartlyFailure = value;
			}
		}



		/// <summary>
		/// Gets / sets the ExceptionInfoRetriever object to retrieve db specific info from a db specific exception.
		/// </summary>
		public ExceptionInfoRetrieverBase ExceptionInfoRetriever 
		{
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}
		#endregion

	}
}
