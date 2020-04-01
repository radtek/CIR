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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class to define a relation between two parameters, one is the source and one is the destination. 
	/// These relation objects are used in multi-command queries for inserting multi-target entities.
	/// </summary>
	public class ParameterParameterRelation
	{
		#region Class Member Declarations
		private IDataParameter _sourceParameter, _destinationParameter;
		#endregion


		/// <summary>
		/// Creates a new <see cref="ParameterParameterRelation"/> instance.
		/// </summary>
		/// <param name="sourceParameter">Source parameter.</param>
		/// <param name="destionationParameter">Destionation parameter.</param>
		public ParameterParameterRelation(IDataParameter sourceParameter, IDataParameter destionationParameter)
		{
			_sourceParameter = sourceParameter;
			_destinationParameter = destionationParameter;
		}


		/// <summary>
		/// Syncs the destination parameter's value with the source parameter's value.
		/// </summary>
		public void Sync()
		{
			if((_sourceParameter!=null) && (_destinationParameter!=null))
			{
				_destinationParameter.Value = _sourceParameter.Value;
			}
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets sourceParameter
		/// </summary>
		public IDataParameter SourceParameter
		{
			get
			{
				return _sourceParameter;
			}
			set
			{
				_sourceParameter = value;
			}
		}

		/// <summary>
		/// Gets / sets destinationParameter
		/// </summary>
		public IDataParameter DestinationParameter
		{
			get
			{
				return _destinationParameter;
			}
			set
			{
				_destinationParameter = value;
			}
		}

		#endregion


	}
}
