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
using System.Reflection;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Attribute to use on properties which return an entity collection in the Adapter template set.
	/// This attribute will tell the property descriptor construction code to construct a list of 
	/// properties of the type set as the value of the attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class TypeContainedAttribute : Attribute
	{
		#region Class Member Declarations
		private Type	_typeContainedInCollection;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="typeContainedInCollection">The type of the objects contained in the collection
		/// returned by the property this attribute is applied to.</param>
		public TypeContainedAttribute(Type typeContainedInCollection)
		{
			_typeContainedInCollection = typeContainedInCollection;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets typeContainedInCollection
		/// </summary>
		public Type TypeContainedInCollection
		{
			get
			{
				return _typeContainedInCollection;
			}
		}

		#endregion
	}


	/// <summary>
	/// Simple attribute which signals the xml serialization/deserialization logic for adapter to call out to custom routines 
	/// (PerformCustomXmlSerialization and PerformCustomXmlDeserialization) for serialization and deserialization of the property
	/// data.
	/// </summary>
	/// <remarks>Adapter specific, Compact25 specific</remarks>
	[AttributeUsage(AttributeTargets.Property)]
	public class CustomXmlSerializationAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomXmlSerializationAttribute"/> class.
		/// </summary>
		public CustomXmlSerializationAttribute()
			: base()
		{
		}
	}


	/// <summary>
	/// Simple attribute which is used to mark a property in an entity collection that it has to be included in Compact XML. Compact XML is used
	/// when the entity collection is send to/from a webservice.
	/// </summary>
	[AttributeUsage( AttributeTargets.Property )]
	public class IncludeInCompactXmlAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IncludeInCompactXmlAttribute"/> class.
		/// </summary>
		public IncludeInCompactXmlAttribute()
			: base()
		{
		}
	}

	

	/// <summary>
	/// Attribute definition to define dependency injection information on a class which instances are injected into other objects (targets). 
	/// A usage of this attribute can be a validator class which is injected at runtime into an entity object to be its validator object to use.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	[Serializable]
	public class DependencyInjectionInfoAttribute : Attribute
	{
		#region Class Member Declarations
		private Type _targetType;
		private string _propertyName;
		private DependencyInjectionTargetKind _targetKind;
		private DependencyInjectionContextType _contextType;
		private PropertyInfo _property;
		private string _targetNamespaceFilter;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyInjectionInfoAttribute"/> class.
		/// </summary>
		/// <param name="targetType">Type of the target into which to inject an instance of the type annotated with this attribute. Can be null, in which case
		/// all types with the specified propertyName will get the instance type injected (if applicable)</param>
		/// <param name="propertyName">Name of the property to set with the instance of the type annotated with this attribute.</param>
		public DependencyInjectionInfoAttribute(Type targetType, string propertyName)
		{
			if(targetType == null)
			{
				throw new ArgumentNullException("targetType can't be null", "targetType");
			}
			_targetType = targetType;
			if((propertyName == null) || (propertyName.Length <= 0))
			{
				throw new ArgumentException("propertyName can't be null nor empty", "propertyName");
			}
			_propertyName = propertyName;

			_property = _targetType.GetProperty(_propertyName);
			if(_targetType.IsInterface)
			{
				// interfaces which derive from other interfaces actually 'implement' the parent interfaces so we've to check all interfaces in the interface. 
				// check the supertypes if _property is null, as that means the current interface doesn't implement it.
				if(_property == null)
				{
					// check supertypes
					Type[] interfaces = _targetType.GetInterfaces();
					foreach(Type interfaceToExamine in interfaces)
					{
						_property = interfaceToExamine.GetProperty(_propertyName);
						if(_property != null)
						{
							// found it
							break;
						}
					}
				}
				_targetKind = DependencyInjectionTargetKind.Absolute;
			}
			else
			{
				_targetKind = DependencyInjectionTargetKind.Hierarchy;
			}

			if(_property == null)
			{
				throw new ArgumentException(string.Format("The type '{0}' doesn't implement (indirectly) property '{1}'", _targetType.FullName, _propertyName), "propertyName");
			}

			_targetNamespaceFilter = string.Empty;
			_contextType = DependencyInjectionContextType.NewInstancePerTarget;
		}


		#region class property declarations
		/// <summary>
		/// Gets / sets the targetNamespaceFilter string which contains semi-colon (;) separated names, or fragments of names of namespaces to limit 
		/// implementations of TargetType to, when TargetType is an interface. If any fragment specified is found as the start of the type’s namespace 
		/// name, that type is a valid target. Optional. If no targetnamespacefilter is specified, all types are targeted.
		/// </summary>
		public string TargetNamespaceFilter
		{
			get
			{
				return _targetNamespaceFilter;
			}
			set
			{
				_targetNamespaceFilter = value;
			}
		}


		/// <summary>
		/// Gets / sets the propertyinfo object for the property to go.
		/// </summary>
		public PropertyInfo Property
		{
			get
			{
				return _property;
			}
			set
			{
				_property = value;
			}
		}


		/// <summary>
		/// Gets / sets targetKind. Targetkind defines which types get the instance injected: only the specified type (absolute) or also all subtypes 
		/// (hierarchy, default). If this property is set to a value and TargetType is an interface, TargetKind will be reset to Absolute.
		/// </summary>
		public DependencyInjectionTargetKind TargetKind
		{
			get
			{
				return _targetKind;
			}
			set
			{
				_targetKind = value;
				if(_targetType.IsInterface)
				{
					_targetKind = DependencyInjectionTargetKind.Absolute;
				}
			}
		}


		/// <summary>
		/// Gets / sets contextType. ContextType is the specification of what kind of instance is injected: a shared instance (Singleton) or a new instance each time
		/// an injection has to be made (NewInstancePerTarget, default).
		/// </summary>
		public DependencyInjectionContextType ContextType
		{
			get
			{
				return _contextType;
			}
			set
			{
				_contextType = value;
			}
		}


		/// <summary>
		/// Gets / sets targetType, into which to inject an instance of the type annotated with this attribute. Can be an interface, in 
		/// which case all types which implement the interface and thus with the specified propertyName will get the instance type injected (if applicable)
		/// </summary>
		public Type TargetType
		{
			get
			{
				return _targetType;
			}
			set
			{
				_targetType = value;
			}
		}


		/// <summary>
		/// Gets / sets propertyName, which is the name of the property to set with the instance of the type annotated with this attribute.
		/// </summary>
		public string PropertyName
		{
			get
			{
				return _propertyName;
			}
			set
			{
				if((value == null) || (value .Length <= 0))
				{
					throw new ArgumentException("PropertyName can't be null nor empty", "PropertyName");
				}
				_propertyName = value;
			}
		}
		#endregion
	}

}
