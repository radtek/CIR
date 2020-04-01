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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the RetrievalQuery class. 
	/// </summary>
	[Serializable]
	public class RetrievalQuery : Query, IRetrievalQuery
	{
		#region Class Member Declarations
		private bool	_requiresClientSideLimitation, _requiresClientSidePaging, _requiresClientSideDistinctFiltering;
		private int		_manualPageSize, _manualPageNumber;
		private long	_maxNumberOfItemsToReturnClientSide;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="commandToUse">Command to use</param>
		public RetrievalQuery(IDbCommand commandToUse):base(commandToUse)
		{
			_requiresClientSideLimitation = false;
			_manualPageNumber = 0;
			_manualPageSize = 0;
			_requiresClientSidePaging = false;
			_requiresClientSideDistinctFiltering = false;
			_maxNumberOfItemsToReturnClientSide = 0;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="connectionToUse">Connection object to use</param>
		/// <param name="commandToUse">Command to use</param>
		public RetrievalQuery(IDbConnection connectionToUse, IDbCommand commandToUse)
			:base(connectionToUse, commandToUse)
		{
			_requiresClientSideLimitation = false;
			_maxNumberOfItemsToReturnClientSide = 0;
			_manualPageNumber = 0;
			_manualPageSize = 0;
			_requiresClientSideDistinctFiltering = false;
			_requiresClientSidePaging = false;
		}


		/// <summary>
		/// Executes the query contained by the IQuery instance. The connection has to be opened before calling Execute().
		/// </summary>
		/// <param name="behavior">The behavior setting to pass to the ExecuteReader method.</param>
		/// <returns>An open, ready to use IDataReader instance</returns>
		/// <exception cref="System.InvalidOperationException">When there is no command object inside the query object, 
		/// or no connection object inside the query object or the connection is closed.</exception>
		public IDataReader Execute(CommandBehavior behavior)
		{
			if(base.Command==null)
			{
				throw new InvalidOperationException("No Command present. Nothing to execute.");
			}

			if(base.Connection==null)
			{
				throw new InvalidOperationException("No Connection present. Cannot execute command.");
			}

			if(base.Connection.State != ConnectionState.Open)
			{
				throw new InvalidOperationException("The Connection is not in the prefered condition 'Open'. Cannot execute command.");
			}

			// execute the query
			try
			{
				IDataReader toReturn = base.Command.ExecuteReader(behavior);
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, this, "Executed Sql Query");
				return toReturn;
			}
			catch(Exception ex)
			{
				// throw a catchable exception with detailed query information.
				throw new ORMQueryExecutionException(
					String.Format("An exception was caught during the execution of a retrieval query: {0}. Check InnerException, QueryExecuted and Parameters of this exception to examine the cause of this exception.", ex.Message), 
					base.ToString(), base.Parameters, ex, GetExceptionInfo(ex));
			}
		}


		/// <summary>
		/// Executes the query contained by the IQuery instance as a scalar query. 
		/// </summary>
		/// <returns>the value returned by the scalar execution of the query</returns>
		public object ExecuteScalar()
		{
			if(base.Command==null)
			{
				throw new InvalidOperationException("No Command present. Nothing to execute.");
			}

			if(base.Connection==null)
			{
				throw new InvalidOperationException("No Connection present. Cannot execute command.");
			}

			if(base.Connection.State != ConnectionState.Open)
			{
				throw new InvalidOperationException("The Connection is not in the prefered condition 'Open'. Cannot execute command.");
			}

			// execute the query
			try
			{
				object toReturn = base.Command.ExecuteScalar();
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, this, "Executed Sql Query");
				return toReturn;
			}
			catch(Exception ex)
			{
				// throw a catchable exception with detailed query information.
				throw new ORMQueryExecutionException(
					String.Format("An exception was caught during the execution of a retrieval query: {0}. Check InnerException, QueryExecuted and Parameters of this exception to examine the cause of this exception.", ex.Message),
					base.ToString(), base.Parameters, ex, GetExceptionInfo(ex));
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the flag which signals fetch code to use client side (i.e. in code) limitation logic and it should not rely on the amount of rows
		/// returned for row limitations. This flag is set by DQEs if DISTINCT can't be used but row limitations are required and TOP is thus not reliable.
		/// Default: false.
		/// </summary>
		public bool RequiresClientSideLimitation 
		{	
			get { return _requiresClientSideLimitation; }
			set { _requiresClientSideLimitation = value;}
		}


		/// <summary>
		/// Used to set the amount of items to return for client side limitations. Only used if <see cref="RequiresClientSideLimitation"/> is true.
		/// </summary>
		public long MaxNumberOfItemsToReturnClientSide
		{
			get
			{
				return _maxNumberOfItemsToReturnClientSide;
			}
			set
			{
				_maxNumberOfItemsToReturnClientSide = value;
			}
		}


		/// <summary>
		/// Flag to tell the object fetcher to use manual paging. This is required when DISTINCT is required however due to DISTINCT violating types
		/// it can't be applied to the query. This then causes duplicates in the resultset, which shouldn't be there and thus causing pages with much
		/// lesser data. Only set by a DQE, normally false.
		/// </summary>
		public bool RequiresClientSidePaging
		{
			get
			{
				return _requiresClientSidePaging;
			}
			set
			{
				_requiresClientSidePaging = value;
			}
		}

		/// <summary>
		/// Only valid when RequiresClientSidePaging is set to true. Required to calculate the actual page start.
		/// </summary>
		public int ManualPageNumber
		{
			get
			{
				return _manualPageNumber;
			}
			set
			{
				_manualPageNumber = value;
			}
		}

		/// <summary>
		/// Only valid when RequiresClientSidePaging is set to true. Required to calculate the actual page start.
		/// </summary>
		public int ManualPageSize
		{
			get
			{
				return _manualPageSize;
			}
			set
			{
				_manualPageSize = value;
			}
		}


		/// <summary>
		/// Flag to tell the object fetcher to use manual distinct filtering, as the DISTINCT command couldn't be applied. Used to tell paging wrappers
		/// to set RequiresClientSidePaging.  
		/// </summary>
		public bool RequiresClientSideDistinctFiltering
		{
			get
			{
				return _requiresClientSideDistinctFiltering;
			}
			set
			{
				_requiresClientSideDistinctFiltering = value;
			}
		}



		#endregion
	}
}
