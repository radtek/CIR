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
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract query class for the various query objects in the framework.
	/// </summary>
	[Serializable]
	public abstract class Query : IQuery
	{
		#region Class Member Declarations
		private IDbConnection	_connection;
		private IDbCommand		_command;
		private ArrayList		_parameterFieldRelations;
		private ExceptionInfoRetrieverBase		_exceptionInfoRetriever;

		[NonSerialized]
		private bool			_disposed;
		#endregion
		
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="commandToUse">Command to use</param>
		public Query(IDbCommand commandToUse)
		{
			_command = commandToUse;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="connectionToUse">Connection object to use</param>
		/// <param name="commandToUse">Command to use</param>
		public Query(IDbConnection connectionToUse, IDbCommand commandToUse)
		{
			_connection = connectionToUse;
			_command = commandToUse;

			_command.Connection = _connection;
		}


		/// <summary>
		/// Will walk all <see cref="IParameterFieldRelation"/> instances of this query and reflect the parameter values in the related fields.
		/// Only output parameters are taken into account. Used by Insert queries which retrieve Identity / sequence values back from the database
		/// after a succesful insert.
		/// </summary>
		public void ReflectOutputValuesInRelatedFields()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "Query.ReflectOutputValuesInRelatedFields", "Method Enter");

			if(_parameterFieldRelations==null)
			{
				// no parameter relations
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "Query.ReflectOutputValuesInRelatedFields: no parameter relations.", "Method Exit");
				return;
			}

			if(_parameterFieldRelations.Count<=0)
			{
				// no parameter relations to reflect
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "Query.ReflectOutputValuesInRelatedFields: no parameters to reflect.", "Method Exit");
				return;
			}

			foreach(IParameterFieldRelation relation in _parameterFieldRelations)
			{
				// reflect value in related field object.
				relation.Sync();

				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tSyncing field {0} with parameter {1}.", 
					relation.Field.Name, relation.Parameter.ParameterName));
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "Query.ReflectOutputValuesInRelatedFields", "Method Exit");
		}


		/// <summary>
		/// Overloaded ToString implementation
		/// </summary>
		/// <returns>Returns a complete textual representation of the command stored. The textual representation
		/// will not include parameter values, but will list their names and types.</returns>
		public override string ToString()
		{
			if(_command==null)
			{
				return "";
			}

			StringBuilder queryText = new StringBuilder();
			switch(_command.CommandType)
			{
				case CommandType.StoredProcedure:
					StringBuilder procParameters = new StringBuilder();
					for(int i = 0; i < _command.Parameters.Count; i++)
					{
						if(i > 0)
						{
							procParameters.Append(", ");
						}
						procParameters.Append(((IDataParameter)_command.Parameters[i]).ParameterName);
					}
					queryText.AppendFormat(null, "\r\n\tQuery: Stored procedure call: {0}({1})\r\n", _command.CommandText, procParameters.ToString());
					break;
				default:
					queryText.AppendFormat(null, "\r\n\tQuery: {0}\r\n", _command.CommandText);
					break;
			}

			string value = string.Empty;
			foreach(IDbDataParameter currentParameter in this.Parameters)
			{
				if((currentParameter.Value == null) || (currentParameter.Value == System.DBNull.Value))
				{
					value = "<undefined value>";
				}
				else
				{
					switch(currentParameter.DbType)
					{
						case DbType.Binary:
						case DbType.Object:
							// the value can't be displayed
							value = "binary lob";
							break;
						case DbType.AnsiString:
						case DbType.AnsiStringFixedLength:
						case DbType.String:
						case DbType.StringFixedLength:
							value = string.Format("\"{0}\"", currentParameter.Value.ToString());
							break;
						default:
							value = currentParameter.Value.ToString();
							break;
					}
				}
				queryText.AppendFormat(null, "\tParameter: {0} : {1}. Length: {2}. Precision: {3}. Scale: {4}. Direction: {5}. Value: {6}.\r\n", 
					currentParameter.ParameterName, 
					currentParameter.DbType, 
					currentParameter.Size,
					currentParameter.Precision, 
					currentParameter.Scale,
					currentParameter.Direction, 
					value);
			}

			return queryText.ToString();
		}

		/// <summary>
		/// Adds a new <see cref="IParameterFieldRelation"/> to the collection of <see cref="ParameterFieldRelations"/>. 
		/// </summary>
		/// <param name="relation">The <see cref="IParameterFieldRelation"/> to add</param>
		public void AddParameterFieldRelation(IParameterFieldRelation relation)
		{
			if(_parameterFieldRelations==null)
			{
				_parameterFieldRelations = new ArrayList();
			}

			if(_parameterFieldRelations.Contains(relation))
			{
				// already there
				return;
			}

			// add it
			_parameterFieldRelations.Add(relation);
		}


		/// <summary>
		/// Wires the command of this query with the transaction passed in.
		/// </summary>
		/// <param name="transactionToWire">the transaction to wire the command with</param>
		public void WireTransaction(IDbTransaction transactionToWire)
		{
			if(_command!=null)
			{
				_command.Transaction = transactionToWire;
			}
		}


		/// <summary>
		/// Sets the command timeout.
		/// </summary>
		/// <param name="timeoutInterval">Timeout interval, in seconds.</param>
		public void SetCommandTimeout(int timeoutInterval)
		{
			if(_command!=null)
			{
				_command.CommandTimeout = timeoutInterval;
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
					// clean up command and parameters. Parameters first. If the parameter objects don't support IDisposable, skip that routine.
					if(_command!=null)
					{
						try
						{
							if((_command.Parameters.Count>0) && (_command.Parameters[0] is IDisposable))
							{
								foreach(IDisposable parameter in _command.Parameters)
								{
									parameter.Dispose();
								}
							}
						}
						catch(ObjectDisposedException)
						{
							// Sybase ASE provider disposes everything already when the connection is disposed. This sometimes happens before this dispose
							// and this causes a problem as there's no way to check if the command object is already disposed. Swallow.
						}
						IDisposable cmd = _command as IDisposable;
						if(cmd!=null)
						{
							cmd.Dispose();
						}
					}
					_disposed = true;
				}
			}
		}

		
		/// <summary>
		/// Gets the exception info using the info retriever set to this query object.
		/// </summary>
		/// <param name="ex">The ex.</param>
		/// <returns></returns>
		protected Hashtable GetExceptionInfo(Exception ex)
		{
			if(_exceptionInfoRetriever != null)
			{
				return _exceptionInfoRetriever.GetExceptionInfo(ex);
			}
			else
			{
				return null;
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// The connection object to use with the <see cref="Command"/>
		/// </summary>
		public IDbConnection Connection 
		{
			get { return _connection; }
			set 
			{
				_connection = value; 
				if(_command != null)
				{
					_command.Connection = value;
				}
			}
		}
		
		/// <summary>
		/// The command used for this query.
		/// </summary>
		public IDbCommand Command 
		{
			get { return _command; }
			set
			{
				_command = value;
				if(value!=null)
				{
					if(_connection!=null)
					{
						_command.Connection = _connection;
					}
				}
			}
		}

		/// <summary>
		/// The list of parameters used in the <see cref="Command"/>. 
		/// </summary>
		public IList Parameters
		{
			get
			{
				if(_command!=null)
				{
					return _command.Parameters;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Array list with the <see cref="IParameterFieldRelation"/> instances for the relations between IEntityFields and output parameters.
		/// </summary>
		public ArrayList ParameterFieldRelations 
		{
#if !CF
			get {return ArrayList.ReadOnly(_parameterFieldRelations);}
#else
			get {return new ArrayList(_parameterFieldRelations);}
#endif
		}
		

		/// <summary>
		/// Gets / sets the ExceptionInfoRetriever object to retrieve db specific info from a db specific exception.
		/// </summary>
		public ExceptionInfoRetrieverBase ExceptionInfoRetriever
		{
			get
			{
				return _exceptionInfoRetriever;
			}
			set
			{
				_exceptionInfoRetriever = value;
			}
		}
		#endregion
	}
}
