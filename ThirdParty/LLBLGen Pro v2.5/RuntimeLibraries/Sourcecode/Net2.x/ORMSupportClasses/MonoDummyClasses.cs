//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2006 Solutions Design. All rights reserved.
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
// This file contains various dummy constructs to make the general code compile on Mono without a lot of compiler directives. 
/////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Xml;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Dummy class which is used to keep code clean, as it's used in a lot of tests in the code.
	/// </summary>
	internal class EntityCollectionComponentDesigner
	{
		private static bool _inDesignMode = false;

		public static bool InDesignMode
		{
			get { return false; }
			set { _inDesignMode = value; }
		}
	}


	/// <summary>
	/// Dummy class to replace the ComPlusAdapterContextBase class. Mono doesn't support COM+
	/// </summary>
	public abstract class ComPlusAdapterContextBase : IComPlusAdapterContext
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapter;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		protected ComPlusAdapterContextBase()
		{
		}

		/// <summary>
		/// Creates the physical connection object
		/// </summary>
		/// <param name="connectionString">connection string to use</param>
		/// <returns>Usable connection object (closed)</returns>
		protected abstract IDbConnection CreateDatabaseConnection(string connectionString);

		/// <summary>
		/// Sets the adapter to host in this context. Adapter is already aware of this context.
		/// </summary>
		/// <param name="adapter">Com+ context aware adapter instance</param>
		protected void SetAdapter(IDataAccessAdapter adapter)
		{
			if(adapter == null)
			{
				throw new ArgumentNullException("adapter", "You can't pass in null for adapter");
			}

			_adapter = adapter;
		}


		#region Class Property Declarations
		/// <summary>
		/// Returns the DataAccessAdapter object related to this COM+ context. Use this adapter instance to perform persistence actions
		/// inside the COM+ transaction this IComPlusAdapterContext implementing object is participating in.
		/// </summary>
		public IDataAccessAdapter Adapter
		{
			get
			{
				return _adapter;
			}
		}
		#endregion
	}
}
