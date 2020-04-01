//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2007 Solutions Design. All rights reserved.
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
using System.Reflection;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Injection configuration info class which is used to store injection information per target type, as found in DI configuration elements
	/// (be it attribute based, config file based or scope based)
	/// </summary>
	internal class InjectionConfigInfo
	{
		#region Class Member Declarations
		private Type _instanceType, _targetType;
		private string _propertyName;
		private DependencyInjectionContextType _contextType;
		private DependencyInjectionTargetKind _targetKind;
		private PropertyInfo _property;
		private List<string> _targetNamespaceFilterFragments;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionInfo"/> class.
		/// </summary>
		/// <param name="instanceType">Type of the instance to inject.</param>
		/// <param name="targetType">Type of the target which contains propertyName and which gets an instance of instanceType injected.</param>
		/// <param name="propertyName">Name of the property to set with an instace of instanceType.</param>
		/// <param name="targetKind">targetKind definition.</param>
		/// <param name="contextType">contextType definition.</param>
		internal InjectionConfigInfo(Type instanceType, Type targetType, string propertyName, DependencyInjectionTargetKind targetKind,
				DependencyInjectionContextType contextType)
		{
			if(instanceType == null)
			{
				throw new ArgumentNullException("instanceType can't be null", "instanceType");
			}
			if(targetType == null)
			{
				throw new ArgumentNullException("instanceType can't be null", "instanceType");
			}

			_instanceType = instanceType;
			_targetType = targetType;
			_propertyName = propertyName;
			_targetKind = targetKind;
			_contextType = contextType;
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
					// interfaces have always targetkind set to absolute.
					_targetKind = DependencyInjectionTargetKind.Absolute;
				}
			}
			_targetNamespaceFilterFragments = new List<string>();
			if(_property == null)
			{
				throw new ArgumentException(string.Format("TargetType '{0}' doesn't implement property '{1}'", targetType.FullName, propertyName), "propertyName");
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionInfo"/> class.
		/// </summary>
		/// <param name="instanceType">Type of the instance.</param>
		/// <param name="infoAttribute">The info attribute.</param>
		/// <param name="targetNamespaceFilterFragments">The target namespace filter fragments.</param>
		internal InjectionConfigInfo(Type instanceType, DependencyInjectionInfoAttribute infoAttribute, string targetNamespaceFilterFragments)
		{
			_instanceType = instanceType;
			_targetType = infoAttribute.TargetType;
			_propertyName = infoAttribute.PropertyName;
			_contextType = infoAttribute.ContextType;
			_targetKind = infoAttribute.TargetKind;
			_property = infoAttribute.Property;
			_targetNamespaceFilterFragments = new List<string>();
			string[] tmpFilterFragments = targetNamespaceFilterFragments.Split(';');
			foreach(string fragment in tmpFilterFragments)
			{
				if(fragment.Trim().Length <= 0)
				{
					continue;
				}
				_targetNamespaceFilterFragments.Add(fragment);
			}
		}


		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
		/// </returns>
		/// <remarks>Compares on instancetype, targettype, property name, context type and targetkind</remarks>
		public override bool Equals(object obj)
		{
			InjectionConfigInfo toCompareWith = obj as InjectionConfigInfo;
			if(toCompareWith == null)
			{
				return false;
			}

			return ((_instanceType == toCompareWith.InstanceType) &&
						(_targetType == toCompareWith.TargetType) &&
						(_propertyName == toCompareWith.PropertyName) &&
						(_contextType == toCompareWith.ContextType) &&
						(_targetKind == toCompareWith._targetKind));
		}


		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override int GetHashCode()
		{
			return _instanceType.GetHashCode() ^ _targetType.GetHashCode() ^ _targetKind.GetHashCode() ^ _propertyName.GetHashCode();
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets targetType
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
		/// Gets / sets contextType
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
		/// Gets / sets targetKind
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
			}
		}

		/// <summary>
		/// Gets / sets propertyName
		/// </summary>
		public string PropertyName
		{
			get
			{
				return _propertyName;
			}
			set
			{
				_propertyName = value;
			}
		}

		/// <summary>
		/// Gets / sets instanceType
		/// </summary>
		public Type InstanceType
		{
			get
			{
				return _instanceType;
			}
			set
			{
				_instanceType = value;
			}
		}

		/// <summary>
		/// Gets / sets property
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
		/// Gets the target namespace filter fragments. 
		/// </summary>
		public List<string> TargetNamespaceFilterFragments
		{
			get { return _targetNamespaceFilterFragments; }
		}
		#endregion
	}



	/// <summary>
	/// Injection info class which is used to store injection information per target type in the storage
	/// </summary>
	internal class InjectionInfo
	{
		#region Class Member Declarations
		private Type _instanceType;
		private string _propertyName;
		private PropertyInfo _property;
		private DependencyInjectionContextType _contextType;
		private InjectionInfoEqualComparer _comparerToUse;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionInfo"/> class.
		/// </summary>
		/// <param name="configInfo">The config info which contains the data to fill this object with.</param>
		internal InjectionInfo(InjectionConfigInfo configInfo)
			: this(configInfo, new InjectionInfoEqualComparer())
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionInfo"/> class.
		/// </summary>
		/// <param name="configInfo">The config info which contains the data to fill this object with.</param>
		/// <param name="comparerToUse">The comparer to use.</param>
		internal InjectionInfo(InjectionConfigInfo configInfo, InjectionInfoEqualComparer comparerToUse)
		{
			_instanceType = configInfo.InstanceType;
			_propertyName = configInfo.PropertyName;
			_property = configInfo.Property;
			_contextType = configInfo.ContextType;
			_comparerToUse = comparerToUse;
		}


		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
		/// </returns>
		/// <remarks>Compares on instancetype, targettype, property name</remarks>
		public override bool Equals(object obj)
		{
			InjectionInfo toCompareWith = obj as InjectionInfo;
			if((toCompareWith == null) || (_comparerToUse == null))
			{
				return false;
			}

			return _comparerToUse.Compare(this, toCompareWith);
		}


		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override int GetHashCode()
		{
			return _instanceType.GetHashCode() ^ _contextType.GetHashCode() ^ _propertyName.GetHashCode();
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets contextType
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
		/// Gets / sets propertyName
		/// </summary>
		public string PropertyName
		{
			get
			{
				return _propertyName;
			}
			set
			{
				_propertyName = value;
			}
		}

		/// <summary>
		/// Gets / sets instanceType
		/// </summary>
		public Type InstanceType
		{
			get
			{
				return _instanceType;
			}
			set
			{
				_instanceType = value;
			}
		}

		/// <summary>
		/// Gets / sets property
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


		#endregion
	}


	/// <summary>
	/// Class to compare injection info objects. 
	/// </summary>
	internal class InjectionInfoEqualComparer
	{
		/// <summary>
		/// compares a with b. 
		/// </summary>
		/// <param name="a">a.</param>
		/// <param name="b">b.</param>
		/// <returns>true if a's values are equal to b's values</returns>
		internal virtual bool Compare(InjectionInfo a, InjectionInfo b)
		{
			return ((a.InstanceType == b.InstanceType) &&
						(a.PropertyName == b.PropertyName) &&
						(a.ContextType == b.ContextType));
		}
	}


	/// <summary>
	/// Class to compare injection info objects based on the property name only
	/// </summary>
	internal class InjectionInfoPropertyEqualComparer : InjectionInfoEqualComparer
	{
		internal override bool Compare(InjectionInfo a, InjectionInfo b)
		{
			return (a.PropertyName == b.PropertyName);
		}
	}


	/// <summary>
	/// Class for the injection data passed back from a storage to the injection performer methods which inject the data.
	/// </summary>
	internal class InjectionData
	{
		#region Class Member Declarations
		private object _injectableObject;
		private PropertyInfo _propertyToSet;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="InjectionData"/> class.
		/// </summary>
		/// <param name="injectableData">The injectable data.</param>
		/// <param name="propertyToSet">The property to set.</param>
		internal InjectionData(object injectableData, PropertyInfo propertyToSet)
		{
			_injectableObject = injectableData;
			_propertyToSet = propertyToSet;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets injectableObject
		/// </summary>
		public object InjectableObject
		{
			get
			{
				return _injectableObject;
			}
			set
			{
				_injectableObject = value;
			}
		}

		/// <summary>
		/// Gets / sets propertyToSet
		/// </summary>
		public PropertyInfo PropertyToSet
		{
			get
			{
				return _propertyToSet;
			}
			set
			{
				_propertyToSet = value;
			}
		}

		#endregion
	}
}
