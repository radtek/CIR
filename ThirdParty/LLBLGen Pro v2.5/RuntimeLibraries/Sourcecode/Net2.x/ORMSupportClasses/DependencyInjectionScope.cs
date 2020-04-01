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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract class which defines a Dependency Injection scope in which dependency injection takes place with the information provided with this scope.
	/// </summary>
	/// <remarks>To use a dependency injection scope to define dependency injection for a specific area in your code, derive a class from this
	/// class and fill it with data using subsequential calls to the AddInjectionInfo method from within an override of <see cref="InitializeScope"/>. 
	/// Instantiate the scope with a using statement which will automatically close the scope when Dispose is called.
	/// Languages which don't have a using statement (e.g. VB.NET in .NET 1.x) should call Dispose manually.
	/// The scope is thread safe and local to the calling thread. Don't pass scopes to other threads.</remarks>
	public abstract class DependencyInjectionScope : IDisposable
	{
		#region Class Member Declarations
		private DependencyInjectionInfoStorage _scopeStorage;
		private bool _started;
		private MultiValueHashtable<Type, InjectionConfigInfo> _normalTypes;
		private MultiValueHashtable<Type, InjectionConfigInfo> _interfaceTypes;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyInjectionScope"/> class. 
		/// </summary>
		/// <remarks>The scope is automatically started by this ctor</remarks>
		public DependencyInjectionScope()
		{
			_started = false;
			_scopeStorage = new DependencyInjectionInfoStorage();
			_normalTypes = new MultiValueHashtable<Type, InjectionConfigInfo>();
			_interfaceTypes = new MultiValueHashtable<Type, InjectionConfigInfo>();

			// call out to the code extending this class. 
			InitializeScope();

			// build the storage from the added types. 
			_scopeStorage.BuildStorage(_normalTypes, _interfaceTypes);
			BeginScope();
		}


		/// <summary>
		/// (Re)starts the scope and will add the scope to the dependency injection provider. Use this method if the scope was already stopped via the
		/// EndScope or (indirectly) through the Dispose method, and you want to re-start it, which can be useful if your scope contains a lot of injection 
		/// info and rebuilding it can take a couple of milliseconds so you can store scope instances in a thread local cache for example. 
		/// </summary>
		/// <remarks>You don't have to call StartScope explicitly after you've created the scope instance as the constructor calls StartScope automatically</remarks>
		public void BeginScope()
		{
			if(_started)
			{
				return;
			}
			// add the scope to the provider. 
			DependencyInjectionInfoProvider.BeginScope(_scopeStorage);
			_started = true;
		}


		/// <summary>
		/// Initializes the scope. Use this method to add injection info to the scope by subsequential calls to AddInjectionInfo
		/// </summary>
		protected abstract void InitializeScope();


		/// <summary>
		/// Adds the injection info passed in to the scope data. Call this method one or more times from an override of <see cref="InitializeScope"/>.
		/// </summary>
		/// <param name="instanceType">Type of the instance to inject.</param>
		/// <param name="targetType">Type of the target which contains propertyName and which gets an instance of instanceType injected.</param>
		/// <param name="propertyName">Name of the property to set with an instace of instanceType.</param>
		protected void AddInjectionInfo(Type instanceType, Type targetType, string propertyName)
		{
			AddInjectionInfo(instanceType, targetType, propertyName, DependencyInjectionTargetKind.Hierarchy, DependencyInjectionContextType.NewInstancePerTarget);
		}
		

		/// <summary>
		/// Adds the injection info passed in to the scope data. Call this method one or more times from an override of <see cref="InitializeScope"/>.
		/// </summary>
		/// <param name="instanceType">Type of the instance to inject.</param>
		/// <param name="targetType">Type of the target which contains propertyName and which gets an instance of instanceType injected.</param>
		/// <param name="propertyName">Name of the property to set with an instace of instanceType.</param>
		/// <param name="targetKind">targetKind definition.</param>
		/// <param name="contextType">contextType definition.</param>
		protected void AddInjectionInfo(Type instanceType, Type targetType, string propertyName, DependencyInjectionTargetKind targetKind,
				DependencyInjectionContextType contextType)
		{
			InjectionConfigInfo toAdd = new InjectionConfigInfo(instanceType, targetType, propertyName, targetKind, contextType);

			if(targetType.IsInterface)
			{
				_interfaceTypes.Add(targetType, toAdd);
			}
			else
			{
				_normalTypes.Add(targetType, toAdd);
			}
		}


		/// <summary>
		/// Ends the scope and removes the scope from the dependency injection provider. After this method, call StartScope again to re-add the DI data to
		/// the provider again. 
		/// </summary>
		public void EndScope()
		{
			if(!_started)
			{
				return;
			}
			try
			{
				// pop the scope from the stack. 
				DependencyInjectionInfoProvider.EndScope();
			}
			finally
			{
				_started = false;
			}
		}


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			EndScope();
		}
	}
}
