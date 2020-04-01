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
using System.Collections.Generic;
using System.Text;
#if CF
using System.Data.SqlTypes;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class for sequence retrieval queries. Sequence retrieval queries are scalar queries (returning a value) which
	/// are used to retrieve the actual / to use sequence value in systems which do not support batched queries. Normally
	/// every DQE will batch the sequence retrieval query into the INSERT query as a batched query, however some systems
	/// do not support this and the only solution is the SequenceRetrievalQuery. Used for Access, Firebird and other systems.
	/// SequenceRetrievalQueries can be added to IActionQuery instances and will use the IActionQuery object's connection object.
	/// </summary>
	[Serializable]
	public class SequenceRetrievalQuery : ISequenceRetrievalQuery
	{
		#region Class Member Declarations
		private IDbCommand				_sequenceRetrievalCommand;
		private bool					_executeSequenceCommandFirst, _setParametersAsOutputParameters;
		private List<IDataParameter>	_sequenceParameters;

		[NonSerialized]
		private bool _disposed;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public SequenceRetrievalQuery()
		{
			_sequenceParameters = new List<IDataParameter>();
			_sequenceRetrievalCommand = null;
			_executeSequenceCommandFirst = false;
			_setParametersAsOutputParameters = false;
		}


		/// <summary>
		/// ToString representation of Sequence query, used in Trace logs.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder description = new StringBuilder(1024);
			description.Append(_sequenceRetrievalCommand.CommandText + "\r\n");
			description.AppendFormat(null, "\tExecutes before INSERT: {0}\r\n", _executeSequenceCommandFirst);
			return description.ToString();
		}


		/// <summary>
		/// Executes the scalar query contained in this object. (Executed with ExecuteScalar())
		/// Expects that the command can be executed without problems.
		/// </summary>
		/// <remarks>Will store its value in the sequence parameters after execution</remarks>
		/// <exception cref="System.InvalidOperationException">When there is no command object set</exception>
		/// <exception cref="ORMQueryExecutionException">when an exception was caught during query execution</exception>
		public void Execute()
		{
			if(_sequenceRetrievalCommand==null)
			{
				throw new InvalidOperationException("No Command present. Nothing to execute.");
			}

			// check if there is something to execute
			if(_sequenceRetrievalCommand.CommandText.Length==0)
			{
				return;
			}

			// execute the query
			try
			{
				object scalarValue = _sequenceRetrievalCommand.ExecuteScalar();
#if CF
				if(scalarValue is SqlDecimal)
				{
					scalarValue = ((SqlDecimal)scalarValue).Value;
				}
#endif
				// convert the scalar value to the right type.
				for (int i = 0; i < _sequenceParameters.Count; i++)
				{
					object convertedValue;
					DbType typeOfValue = _sequenceParameters[i].DbType;
					switch(typeOfValue)
					{
						case DbType.Byte:
							convertedValue = Convert.ToByte(scalarValue, null);
							break;
						case DbType.Int16:
							convertedValue = Convert.ToInt16(scalarValue, null);
							break;
						case DbType.Int32:
							convertedValue = Convert.ToInt32(scalarValue);
							break;
						case DbType.Int64:
							convertedValue = Convert.ToInt64(scalarValue);
							break;
						case DbType.Decimal:
							convertedValue = Convert.ToDecimal(scalarValue);
							break;
						default:
							convertedValue = scalarValue;
							break;
					}
					if(_setParametersAsOutputParameters)
					{
						_sequenceParameters[i].Direction = ParameterDirection.Output;
					}
					_sequenceParameters[i].Value = convertedValue;
				}
			}
			catch(Exception ex)
			{
				// throw a catchable exception with detailed query information.
				throw new ORMQueryExecutionException(
					String.Format("An exception was caught during the execution of a sequence retrieval query: {0}. Check InnerException, QueryExecuted and Parameters of this exception to examine the cause of this exception.", ex.Message), 
					_sequenceRetrievalCommand.CommandText, null, ex, null);
			}
		}


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or
		/// resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}


		/// <summary>
		/// Performs the dispose action.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose( bool isDisposing )
		{
			if( !_disposed )
			{
				if( isDisposing )
				{
					// clean up command and parameters. Parameters first. If the parameter objects don't support IDisposable, skip that routine.
					if( _sequenceRetrievalCommand != null )
					{
						if( (_sequenceRetrievalCommand.Parameters.Count > 0) && (_sequenceRetrievalCommand.Parameters[0] is IDisposable) )
						{
							foreach( IDisposable parameter in _sequenceRetrievalCommand.Parameters )
							{
								parameter.Dispose();
							}
						}

						IDisposable cmd = _sequenceRetrievalCommand as IDisposable;
						if( cmd != null )
						{
							cmd.Dispose();
						}
					}
					_disposed = true;
				}
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// The Scalar command used to retrieve the used/to use sequence value. This command will be executed as a scalar query and depending on
		/// ExecuteSequenceCommandFirst it will be executed before or after the actual query.
		/// </summary>
		public IDbCommand SequenceRetrievalCommand 
		{
			get { return _sequenceRetrievalCommand; } 
			set { _sequenceRetrievalCommand = value;}
		}

		/// <summary>
		/// Flag to signal if SequenceRetrievalCommand has to be executed before (true) or after (false) the 
		/// actual query in this ActionQuery object. 
		/// </summary>
		public bool ExecuteSequenceCommandFirst 
		{
			get { return _executeSequenceCommandFirst;}
			set { _executeSequenceCommandFirst = value;}
		}

		/// <summary>
		/// List with the parameter objects in the actual query which need the value returned by the execution of the command
		/// </summary>
		public List<IDataParameter> SequenceParameters 
		{
			get { return _sequenceParameters;}
		}

		/// <summary>
		/// Used to make SequenceParameters 'output' parameters. Required for Access. Default: false;
		/// </summary>
		public bool SetParametersAsOutputParameters 
		{ 
			get { return _setParametersAsOutputParameters;}
			set { _setParametersAsOutputParameters = value;}
		}
		#endregion

	}
}
