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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General class which defines the projection result and destination of a value in an object[] array. 
	/// </summary>
	[Serializable]
	public class DataValueProjector : IDataValueProjector
	{
		#region Class Member Declarations
		private int _valueIndex;
		private Type _valueType;
		private string _projectedResultName;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataValueProjector"/> class.
		/// </summary>
		/// <param name="projectedResultName">Name of the projected result.</param>
		/// <param name="valueIndex">Index of the value.</param>
		public DataValueProjector( string projectedResultName, int valueIndex )
			: this( projectedResultName, valueIndex, typeof( object ) )
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="DataValueProjector"/> class.
		/// </summary>
		/// <param name="projectedResultName">Name of the projected result.</param>
		/// <param name="valueIndex">Index of the value.</param>
		/// <param name="valueType">Type of the value.</param>
		public DataValueProjector( string projectedResultName, int valueIndex, Type valueType )
		{
			_valueIndex = valueIndex;
			_valueType = valueType;
			_projectedResultName = projectedResultName;
		}

		/// <summary>
		/// Projects the entity through this entity property projector and results into a single value, based on what the DefaultValueProducer is and
		/// what filter is specified (if any)
		/// </summary>
		/// <param name="sourceValues">The source values of which this projector will pick a value to project. The projection result is returned.</param>
		/// <returns>
		/// Projection result of a value in the sourcevalues or null if the value index is out of bounds. If the index is out of bounds, ValuePostProcess isn't called.
		/// </returns>
		/// <remarks>Calls, if a valid value was obtained from sourceValues, ValuePostProcess after the projection to allow derived classes to post-process
		/// the value.</remarks>
		public object ProjectValue( object[] sourceValues )
		{
			if( sourceValues == null )
			{
				throw new ArgumentNullException( "sourceValues can't be null", "sourceValues" );
			}
			if( sourceValues.Length <= 0 )
			{
				return null;
			}
			object projectionResult = null;
			if( (_valueIndex < 0) || (_valueIndex >= sourceValues.Length) )
			{
				// out of bounds
				return null;
			}
			projectionResult = sourceValues[_valueIndex];
			return ValuePostProcess( projectionResult, sourceValues );
		}


		/// <summary>
		/// Postprocesses the value passed in, which is the projection result determined by ProjectValue. Use this routine to post-process this
		/// value if you want to perform post-processing per value.
		/// </summary>
		/// <param name="preliminaryProjectionResult">The preliminary projection result.</param>
		/// <param name="sourceValues">The source values used for the processing.</param>
		/// <returns>
		/// the projection result processed by this routine. The base class version is empty and returns preliminaryProjectionResult
		/// </returns>
		protected virtual object ValuePostProcess( object preliminaryProjectionResult, object[] sourceValues )
		{
			return preliminaryProjectionResult;
		}


		#region Class Property Declarations

		/// <summary>
		/// Gets or sets the index of the value to return when Projectvalue is called.
		/// </summary>
		/// <value>The index of the default value.</value>
		public int ValueIndex
		{
			get
			{
				return _valueIndex;
			}
			set
			{
				_valueIndex = value;
			}
		}


		/// <summary>
		/// Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// </summary>
		/// <value></value>
		public string ProjectedResultName
		{
			get { return _projectedResultName; }
		}

		/// <summary>
		/// Gets or sets the type of the value returned by the value producer or producers routine of the projector.
		/// </summary>
		/// <value></value>
		public Type ValueType
		{
			get
			{
				return _valueType;
			}
			set
			{
				_valueType = value;
			}
		}

		#endregion
	}
}
