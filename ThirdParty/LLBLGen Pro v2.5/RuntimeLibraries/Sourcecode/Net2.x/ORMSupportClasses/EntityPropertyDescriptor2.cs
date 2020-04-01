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
		private Type			_typeOfBoundObject;
		private bool			_isReadOnly;
		private PropertyDescriptor	_descriptor;
		#endregion
		

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="field">Field which is exposed as a property and which has to be described in a PropertyDescriptor</param>
		/// <param name="typeOfBoundObject">The type of object this property is a property of</param>
		/// <param name="isReadOnly">True if the field is an identity field/primary key field and the entity itself is not new</param>
		public EntityPropertyDescriptor2(IEntityField2 field, Type typeOfBoundObject, bool isReadOnly):base(field.Name, null)
		{
			_field = field;
			_typeOfBoundObject = typeOfBoundObject;
			_isReadOnly = isReadOnly;
			if(_typeOfBoundObject != null)
			{
				_descriptor = TypeDescriptor.GetProperties(typeOfBoundObject)[_field.Name];
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>always false (not supported)</returns>
		public override bool CanResetValue(object component)
		{
			if(_descriptor != null)
			{
				return _descriptor.CanResetValue(component);
			}
			return false;
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>current value of associated IEntityField</returns>
		public override object GetValue(object component)
		{
			if(_descriptor != null)
			{
				return _descriptor.GetValue(component);
			}
			return ((IEntity2)component).GetCurrentFieldValue(_field.FieldIndex);
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <param name="value"></param>
		public override void SetValue(object component, object value)
		{
			if(_descriptor != null)
			{
				_descriptor.SetValue(component, value);
			}
			else
			{
				((IEntity2)component).SetNewFieldValue(_field.FieldIndex, value);
			}
			this.OnValueChanged(component, EventArgs.Empty);
		}


		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		/// <param name="component"></param>
		/// <returns>always false (not supported)</returns>
		public override bool ShouldSerializeValue(object component)
		{
			if(_descriptor != null)
			{
				return _descriptor.ShouldSerializeValue(component);
			}
			return false;
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override Type ComponentType
		{
			get
			{
				return _typeOfBoundObject;
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override string DisplayName
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.DisplayName;
				}
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
				if(_descriptor != null)
				{
					return _descriptor.IsBrowsable;
				}
				return true;
			}
		}


		/// <summary>
		/// Gets the collection of attributes for this member.
		/// </summary>
		/// <value></value>
		/// <returns>An <see cref="T:System.ComponentModel.AttributeCollection"></see> that provides the attributes for this member, or an empty collection if there are no attributes in the <see cref="P:System.ComponentModel.MemberDescriptor.AttributeArray"></see>.</returns>
		public override AttributeCollection Attributes
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.Attributes;
				}
				return base.Attributes;
			}
		}

		/// <summary>
		/// Gets the type converter for this property.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.ComponentModel.TypeConverter"></see> that is used to convert the <see cref="T:System.Type"></see> of this property.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
		public override TypeConverter Converter
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.Converter;
				}
				return base.Converter;
			}
		}


		/// <summary>
		/// Gets the description of the member, as specified in the <see cref="T:System.ComponentModel.DescriptionAttribute"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The description of the member. If there is no <see cref="T:System.ComponentModel.DescriptionAttribute"></see>, the property value is set to the default, which is an empty string ("").</returns>
		public override string Description
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.Description;
				}
				return base.Description;
			}
		}


		/// <summary>
		/// Gets whether this member should be set only at design time, as specified in the <see cref="T:System.ComponentModel.DesignOnlyAttribute"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if this member should be set only at design time; false if the member can be set during run time.</returns>
		public override bool DesignTimeOnly
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.DesignTimeOnly;
				}
				return base.DesignTimeOnly;
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> for a given object using a specified array of attributes as a filter.
		/// </summary>
		/// <param name="instance">A component to get the properties for.</param>
		/// <param name="filter">An array of type <see cref="T:System.Attribute"></see> to use as a filter.</param>
		/// <returns>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that match the specified attributes for the specified component.
		/// </returns>
		public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
		{
			if(_descriptor != null)
			{
				return _descriptor.GetChildProperties(instance, filter);
			}
			return base.GetChildProperties(instance, filter);
		}


		/// <summary>
		/// Gets an editor of the specified type.
		/// </summary>
		/// <param name="editorBaseType">The base type of editor, which is used to differentiate between multiple editors that a property supports.</param>
		/// <returns>
		/// An instance of the requested editor type, or null if an editor cannot be found.
		/// </returns>
		public override object GetEditor(Type editorBaseType)
		{
			if(_descriptor != null)
			{
				return _descriptor.GetEditor(editorBaseType);
			}
			return base.GetEditor(editorBaseType);
		}

		/// <summary>
		/// Gets a value indicating whether this property should be localized, as specified in the <see cref="T:System.ComponentModel.LocalizableAttribute"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if the member is marked with the <see cref="T:System.ComponentModel.LocalizableAttribute"></see> set to true; otherwise, false.</returns>
		public override bool IsLocalizable
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.IsLocalizable;
				}
				return base.IsLocalizable;
			}
		}



		/// <summary>
		/// Gets the name of the category to which the member belongs, as specified in the <see cref="T:System.ComponentModel.CategoryAttribute"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The name of the category to which the member belongs. If there is no <see cref="T:System.ComponentModel.CategoryAttribute"></see>, the category name is set to the default category, Misc.</returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/></PermissionSet>
		public override string Category
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.Category;
				}
				return base.Category;
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
				return _isReadOnly || (!_field.IsPrimaryKey && _field.IsReadOnly) || ((_descriptor!=null) && _descriptor.IsReadOnly);
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override string Name
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.Name;
				}
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
				if(_descriptor != null)
				{
					return _descriptor.PropertyType;
				}
				return _field.DataType;
			}
		}

		/// <summary>
		/// See PropertyDescriptor class.
		/// </summary>
		public override void ResetValue(object component)
		{
			if(_descriptor != null)
			{
				_descriptor.ResetValue(component);
			}
		}

		/// <summary>
		/// Enables other objects to be notified when this property changes.
		/// </summary>
		/// <param name="component">The component to add the handler for.</param>
		/// <param name="handler">The delegate to add as a listener.</param>
		/// <exception cref="T:System.ArgumentNullException">component or handler is null.</exception>
		public override void AddValueChanged(object component, EventHandler handler)
		{
			if(_descriptor!=null)
			{
				_descriptor.AddValueChanged(component, handler);
			}
			else
			{
				base.AddValueChanged(component, handler);
			}
		}


		/// <summary>
		/// Compares this to another object to see if they are equivalent.
		/// </summary>
		/// <param name="obj">The object to compare to this <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.</param>
		/// <returns>
		/// true if the values are equivalent; otherwise, false.
		/// </returns>
		public override bool Equals(object obj)
		{
			if(_descriptor != null)
			{
				return _descriptor.Equals(obj);
			}
			return base.Equals(obj);
		}


		/// <summary>
		/// Returns the hash code for this object.
		/// </summary>
		/// <returns>The hash code for this object.</returns>
		public override int GetHashCode()
		{
			if(_descriptor != null)
			{
				return _descriptor.GetHashCode();
			}
			return base.GetHashCode();
		}


		/// <summary>
		/// Enables other objects to be notified when this property changes.
		/// </summary>
		/// <param name="component">The component to remove the handler for.</param>
		/// <param name="handler">The delegate to remove as a listener.</param>
		/// <exception cref="T:System.ArgumentNullException">component or handler is null.</exception>
		public override void RemoveValueChanged(object component, EventHandler handler)
		{
			if(_descriptor != null)
			{
				_descriptor.RemoveValueChanged(component, handler);
			}
			else
			{
				base.RemoveValueChanged(component, handler);
			}
		}

		/// <summary>
		/// Gets a value indicating whether value change notifications for this property may originate from outside the property descriptor.
		/// </summary>
		/// <value></value>
		/// <returns>true if value change notifications may originate from outside the property descriptor; otherwise, false.</returns>
		public override bool SupportsChangeEvents
		{
			get
			{
				if(_descriptor != null)
				{
					return _descriptor.SupportsChangeEvents;
				}
				return base.SupportsChangeEvents;
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override string ToString()
		{
			if(_descriptor != null)
			{
				return _descriptor.ToString();
			}
			return base.ToString();
		}

		/// <summary>
		/// Gets or sets the field.
		/// </summary>
		/// <value>The field.</value>
		public IEntityField2 Field
		{
			get
			{
				return _field;
			}

			set
			{
				_field = value;
			}
		}
	}
}
