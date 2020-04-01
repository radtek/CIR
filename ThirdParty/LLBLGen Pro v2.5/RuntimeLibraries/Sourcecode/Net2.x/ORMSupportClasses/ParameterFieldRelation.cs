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
using System.ComponentModel;
using System.Data;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class to define the relation between a parameter of a query and a field. This relation is 
	/// used to find back a related EntityFieldCore instance when an Output Parameter is found in a query so the value 
	/// of the Output Parameter can be assigned to the related EntityField
	/// </summary>
	[Serializable]
	public class ParameterFieldRelation : IParameterFieldRelation 
	{
		#region Class Member Declarations
		private IEntityFieldCore	_field;
		private IDataParameter		_parameter;
		private TypeConverter		_typeConverterToUse;
		#endregion
		
		
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="field">The <see cref="IEntityFieldCore"/> in the relationship.</param>
		/// <param name="parameter">The Parameter in the relationship.</param>
		/// <param name="typeConverterToUse">The type converter to use, if applicable (can be null)</param>
		public ParameterFieldRelation(IEntityFieldCore field, IDataParameter parameter, TypeConverter typeConverterToUse)
		{
			_field = field;
			_parameter = parameter;
			_typeConverterToUse = typeConverterToUse;
		}

		/// <summary>
		/// Sets the field's value using ForceCurrentValueWrite with the value of the parameter.
		/// </summary>
		public void Sync()
		{
			if((_field!=null)&&(_parameter!=null))
			{
				object value = _parameter.Value;
#if !CF
				if(_typeConverterToUse!=null)
				{
					value = _typeConverterToUse.ConvertFrom(null, null, value);
				}
#endif
				_field.ForcedCurrentValueWrite(value);
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// The <see cref="IEntityFieldCore"/> in the relationship. Only settable via a constructor.
		/// </summary>
		public IEntityFieldCore Field
		{
			get
			{
				return _field;
			}
		}

		/// <summary>
		/// The Parameter in the relationship. Only settable via a constructor.
		/// </summary>
		public System.Data.IDataParameter Parameter
		{
			get
			{
				return _parameter;
			}
		}

		/// <summary>
		/// The Typeconverter to use, if applicable.
		/// </summary>
		public TypeConverter TypeConverterToUse 
		{
			get { return _typeConverterToUse; }
		}
		#endregion
	}
}
