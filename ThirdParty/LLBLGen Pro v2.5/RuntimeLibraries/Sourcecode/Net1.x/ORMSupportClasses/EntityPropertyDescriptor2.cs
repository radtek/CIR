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
using System.Reflection;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// EntityPropertyDescriptor2 implementation for adding property descriptors for entity fields in a complex databinding scenario.
	/// </summary>
	[Serializable]
	public class EntityPropertyDescriptor2 : PropertyDescriptor
	{
		#region Class Member Declarations
		private IEntityField2	_field;
		private Type			_typeOfBindedObject;
		private bool			_isReadOnly;
		private PropertyInfo	_info;
		#endregion
		

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="field">Field which is exposed as a property and which has to be described in a PropertyDescriptor</param>
		/// <param name="typeOfBindedObject">The type of object this property is a property of</param>
		/// <param name="isReadOnly">True if the field is an identity field/primary key field and the entity itself is not new</param>
		public EntityPropertyDescriptor2(IEntityField2 field, Type typeOfBindedObject, bool isReadOnly):base(field.Name, null)
		{
			_field = field;
			_typeOfBindedObject = typeOfBindedObject;
			_isReadOnly = isReadOnly;
			if(_typeOfBindedObject != null)
			{
				_info = _typeOfBindedObject.GetProperty(_field.Name);
			}		
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>always false (not supported)</returns>
		public override bool CanResetValue(object component)
		{
			return false;
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>current value of associated IEntityField</returns>
		public override object GetValue(object component)
		{
			if(_info == null)
			{
				return ((IEntity2)component).GetCurrentFieldValue(_field.FieldIndex);
			}
			else
			{
				return _info.GetValue(component, null);
			}		
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <param name="value"></param>
		public override void SetValue(object component, object value)
		{
			_info.SetValue(component, value, null);
		}


		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>always false (not supported)</returns>
		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override Type ComponentType
		{
			get
			{
				return _typeOfBindedObject;
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override string DisplayName
		{
			get
			{
				return _field.Name;
			}
		}

#if !CF
		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override bool IsBrowsable
		{
			get
			{
				return true;
			}
		}
#endif

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override bool IsReadOnly
		{
			get
			{
				return _isReadOnly || (!_field.IsPrimaryKey && _field.IsReadOnly) || ((_info!=null) && !_info.CanWrite);
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override string Name
		{
			get
			{
				return _field.Name;
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override Type PropertyType
		{
			get
			{
				return _field.DataType;
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override void ResetValue(object component)
		{
			// empty
		}
	}
}
