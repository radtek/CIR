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
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;
using System.IO;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Singleton class which contains the single instance of the DependencyInjectionProvider 
	/// </summary>
	public static class DependencyInjectionInfoProviderSingleton
	{
		#region class member declarations
		private static readonly DependencyInjectionInfoProvider _instance = new DependencyInjectionInfoProvider();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static DependencyInjectionInfoProviderSingleton()
		{
		}

		/// <summary>
		/// Gets the singleton instance.
		/// </summary>
		internal static DependencyInjectionInfoProvider GetInstance()
		{
			return _instance;
		}
		

		/// <summary>
		/// Performs the dependency injection of the objects to inject into the target specified.
		/// </summary>
		/// <param name="injectionTarget">The target to inject objects in.</param>
		public static void PerformDependencyInjection(object injectionTarget)
		{
			Dictionary<string, InjectionData> toInject = GetInstance().GetInstancesToInject(injectionTarget.GetType());
			if(toInject != null)
			{
				foreach(KeyValuePair<string, InjectionData> pair in toInject)
				{
					// FUTURE ENHANCEMENT: optimize this with emitted IL. 
					pair.Value.PropertyToSet.SetValue(injectionTarget, pair.Value.InjectableObject, null);
				}
			}
		}
	}


	/// <summary>
	/// Dependency Injection Info provider class. This class provides the orm support classes with dependency injection information
	/// </summary>
	internal class DependencyInjectionInfoProvider
	{
		#region Class Member Declarations
		private DependencyInjectionInfoStorage _centralStorage;
		private MultiValueHashtable<Type, InjectionConfigInfo> _interfaceTargetTypes;
		private MultiValueHashtable<Type, InjectionConfigInfo> _normalTargetTypes;

		[ThreadStatic]
		private static Stack<DependencyInjectionInfoStorage> _scopeStorages;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyInjectionInfoProvider"/> class.
		/// </summary>
		internal DependencyInjectionInfoProvider()
		{
			Init();
		}


		/// <summary>
		/// Gets the instances to inject.
		/// </summary>
		/// <param name="targetType">Type of the target to inject instances in.</param>
		/// <returns>A dictionary with per PropertyName the injection data with the instance to inject, or null if nothing can be injected.</returns>
		internal Dictionary<string, InjectionData> GetInstancesToInject(Type targetType)
		{
			// first grab the values from a scope, if present
			MergeableDictionary<string, InjectionData> toReturn = null;
			MergeableDictionary<string, InjectionData> scopeData = GetScopeSpecificInstancesToInject(targetType);
			MergeableDictionary<string, InjectionData> centralData = _centralStorage.GetInstancesToInject(targetType);

			if((scopeData != null) || (centralData != null))
			{
				toReturn = new MergeableDictionary<string, InjectionData>();
				// MergeableDictionary merges NEW data from the dictionary passed in into the dictionary the method is called on.
				// this means that overruling data should be merged first. 
				if(scopeData != null)
				{
					toReturn.MergeDictionary(scopeData);
				}
				if(centralData != null)
				{
					toReturn.MergeDictionary(centralData);
				}

				if(toReturn.Count > 0)
				{
					return toReturn;
				}
				else
				{
					return null;
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Marks the begin of a scope and therefore creates the scope data storage.
		/// </summary>
		/// <param name="scopeStorage">The scope storage to use. This scopestorage is passed in by the di scope started.</param>
		internal static void BeginScope(DependencyInjectionInfoStorage scopeStorage)
		{
			if(_scopeStorages == null)
			{
				_scopeStorages = new Stack<DependencyInjectionInfoStorage>();
			}
			// push the scope onto the stack
			_scopeStorages.Push(scopeStorage);
		}


		/// <summary>
		/// Marks the end of a scope and therefore removes the scope data created.
		/// </summary>
		internal static void EndScope()
		{
			// remove the top scope from the stack.
			_scopeStorages.Pop();
		}


		/// <summary>
		/// Gets the scope specific instances to inject. This traverses the stack from top to bottom starting with the last pushed scope storage.
		/// If collects all the injection info for the given targetType over all the scopes on the stack. If a scope which is pushed later on the stack
		/// overrules injection info for a given propertyname, the info of the scope pushed later on the stack is used. 
		/// </summary>
		/// <param name="targetType">Type of the target.</param>
		/// <returns>Dictionary with for each propertyname the injection data with the object to inject or null if no data to inject was found</returns>
		private MergeableDictionary<string, InjectionData> GetScopeSpecificInstancesToInject(Type targetType)
		{
			MergeableDictionary<string, InjectionData> toReturn = null;

			if(_scopeStorages == null)
			{
				_scopeStorages = new Stack<DependencyInjectionInfoStorage>();
			}

			foreach(DependencyInjectionInfoStorage scopeStorage in _scopeStorages)
			{
				MergeableDictionary<string, InjectionData> toMerge = scopeStorage.GetInstancesToInject(targetType);
				if(toMerge != null)
				{
					if(toReturn == null)
					{
						toReturn = new MergeableDictionary<string, InjectionData>();
					}
					toReturn.MergeDictionary(toMerge);
				}
			}

			if((toReturn!=null) && (toReturn.Count > 0))
			{
				return toReturn;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Init()
		{
			_centralStorage = new DependencyInjectionInfoStorage();
			if(_scopeStorages == null)
			{
				_scopeStorages = new Stack<DependencyInjectionInfoStorage>();
			}
			_normalTargetTypes = new MultiValueHashtable<Type, InjectionConfigInfo>();
			_interfaceTargetTypes = new MultiValueHashtable<Type, InjectionConfigInfo>();

			MultiValueHashtable<Type, DependencyInjectionInfoAttribute> instanceTypesFound = new MultiValueHashtable<Type, DependencyInjectionInfoAttribute>();

			// check if autoDiscovery has to take place
			string autoDependencyInjectionDiscoveryValue = ConfigurationManager.AppSettings["autoDependencyInjectionDiscovery"];
			bool performAutoDiscovery = false;
			if(autoDependencyInjectionDiscoveryValue != null)
			{
				performAutoDiscovery = (autoDependencyInjectionDiscoveryValue.ToLowerInvariant() == "true");
			}
			performAutoDiscovery |= DependencyInjectionDiscoveryInformation.PerformAutoDiscoveryDependencyInjectionInformation;

			if(performAutoDiscovery)
			{
				// determine the types with the DependencyInjectionInfoAttribute attribute on them in the assemblies reachable from the current appdomain.
				AppDomain traverserAD = AppDomain.CreateDomain("Traverser", null, AppDomain.CurrentDomain.BaseDirectory,
					AppDomain.CurrentDomain.RelativeSearchPath, false);

				// use the type discoverer class with an instance in the new appdomain.
				TypeDiscoverer discoverer = (TypeDiscoverer)traverserAD.CreateInstanceAndUnwrap(typeof(TypeDiscoverer).Assembly.FullName, 
						typeof(TypeDiscoverer).FullName);

				// pass the currently loaded assembly names to the discoverer, so it can start with these to traverse the referenced assembly tree.
				List<AssemblyName> loadedAssemblyNames = new List<AssemblyName>();
				Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach(Assembly loadedAssembly in loadedAssemblies)
				{
					loadedAssemblyNames.Add(loadedAssembly.GetName());
				}
				// grab all annotated types, which we'll call instanceTypes
				instanceTypesFound = discoverer.Discover(loadedAssemblyNames);

				// done with the appdomain, unload. 
				AppDomain.Unload(traverserAD);
			}

			// we now need to see if there are assemblies defined in the config or in the discovery information in memory. 
			// If so, traverse these as well for instance types, and add these types to the list we already have. 
			DependencyInjectionConfigInformation diInfoFromConfig = null;
			if(DependencyInjectionDiscoveryInformation.ConfigInformation != null)
			{
				diInfoFromConfig = DependencyInjectionDiscoveryInformation.ConfigInformation;
			}
			else
			{
				diInfoFromConfig = (DependencyInjectionConfigInformation)ConfigurationManager.GetSection("dependencyInjectionInformation");
			}
			if(diInfoFromConfig!=null)
			{
				// traverse the assemblies defined for instance types. 
				foreach(Assembly configAssembly in diInfoFromConfig.AdditionalAssemblies)
				{
					TypeDiscoverer.GatherInstanceTypes(instanceTypesFound, configAssembly);
				}
			}

			// load all di info from attributes found in the assemblies in the current appdomain
			RetrieveDIInfoUsingAttributes(diInfoFromConfig, instanceTypesFound);
		}


		/// <summary>
		/// Retrieves the DI info which is defined using attributes and stores that inside the central storage.
		/// </summary>
		/// <param name="diInfoFromConfig">The di info from config.</param>
		/// <param name="instanceTypesFound">The instance types found.</param>
		private void RetrieveDIInfoUsingAttributes(DependencyInjectionConfigInformation diInfoFromConfig,
				MultiValueHashtable<Type, DependencyInjectionInfoAttribute> instanceTypesFound)
		{
			// traverse all found instance types and check if the type has to be filtered out. 
			foreach(KeyValuePair<Type, UniqueValueList<DependencyInjectionInfoAttribute>> pair in instanceTypesFound)
			{
				bool acceptType = false;
				Type publicType = pair.Key;
				UniqueValueList<DependencyInjectionInfoAttribute> diAttributes = pair.Value;

				// First see if this type has to be filtered out based on the config data (if any)
				if((diInfoFromConfig != null) && (diInfoFromConfig.NamespaceFilterFragments.Count > 0))
				{
					foreach(string namespaceFragment in diInfoFromConfig.NamespaceFilterFragments)
					{
						if(publicType.Namespace.StartsWith(namespaceFragment))
						{
							// match
							acceptType = true;
							break;
						}
					}
				}
				else
				{
					acceptType=true;
				}

				foreach(DependencyInjectionInfoAttribute diAttribute in diAttributes)
				{
					// check if the property can have an instance of the instance type. If not, reject the instance type.
					acceptType = (acceptType && diAttribute.Property.PropertyType.IsAssignableFrom(pair.Key));

					if(acceptType)
					{
						if(diAttribute.TargetType.IsInterface)
						{
							_interfaceTargetTypes.Add(diAttribute.TargetType,
									new InjectionConfigInfo(publicType, diAttribute, diAttribute.TargetNamespaceFilter));
						}
						else
						{
							// no assembly filtering needed. 
							_normalTargetTypes.Add(diAttribute.TargetType, new InjectionConfigInfo(publicType, diAttribute, string.Empty));
						}
					}
				}
			}

			_centralStorage.BuildStorage(_normalTargetTypes, _interfaceTargetTypes);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the interface target types discovered from the assemblies in the application
		/// </summary>
		public MultiValueHashtable<Type, InjectionConfigInfo> InterfaceInstanceTypes
		{
			get { return _interfaceTargetTypes; }
		}

		/// <summary>
		/// Gets the normal target types discovered from the assemblies in the application
		/// </summary>
		public MultiValueHashtable<Type, InjectionConfigInfo> NormalInstanceTypes
		{
			get { return _normalTargetTypes; }
		}
		#endregion
	}


	/// <summary>
	/// Class which is used to discover types in either the appdomain or the assembly passed in. This class can either be used in its own appdomain
	/// (for appdomain wide discovery) or in the executing appdomain (for assembly traversal).
	/// </summary>
	internal class TypeDiscoverer : MarshalByRefObject
	{
		#region Class Member Declarations
		/// <summary>
		/// Filter of assemblies which don't have to be traversed to search for annotated types as they're part of the .NET framework.
		/// </summary>
		private string[] _filter = new string[] { "System", "mscorlib", "System.", "Microsoft." };
		#endregion

		/// <summary>
		/// Discovers the specified assembly names passed in from the current application domain
		/// </summary>
		/// <param name="assemblyNamesCurrentAD">The assembly names of the current application domain.</param>
		/// <returns>List of types (keys) which are annotated with the DependencyInjectionInfoAttribute (values), thus which are instance types for DI</returns>
		public MultiValueHashtable<Type, DependencyInjectionInfoAttribute> Discover(List<AssemblyName> assemblyNamesCurrentAD)
		{
			Dictionary<string, AssemblyName> assemblyNames = new Dictionary<string, AssemblyName>();
			Dictionary<string, object> assembliesTraversed = new Dictionary<string, object>();
			foreach(AssemblyName loadedAssemblyName in assemblyNamesCurrentAD)
			{
				if(!CheckIfAssemblyIsAllowed(loadedAssemblyName))
				{
					continue;
				}
				if(!assemblyNames.ContainsKey(loadedAssemblyName.Name))
				{
					assemblyNames.Add(loadedAssemblyName.Name, loadedAssemblyName);
				}
				Assembly toDiscover = null;

				try
				{
					toDiscover = Assembly.Load(loadedAssemblyName);
					Discover(toDiscover, assemblyNames, assembliesTraversed);
				}
				catch
				{
					// swallow, couldn't load assembly. Which is odd, as the assembly to load is actually loaded in the calling appdomain. Happens sometimes
					// in appdomains controlled by remoted code (unittests etc.)
				}
			}
			MultiValueHashtable<Type, DependencyInjectionInfoAttribute> toReturn = new MultiValueHashtable<Type, DependencyInjectionInfoAttribute>();

			foreach(AssemblyName name in assemblyNames.Values)
			{
				Assembly toExamine = null;
				try
				{
					toExamine = Assembly.Load(name);
					if(toExamine == null)
					{
						continue;
					}
					TypeDiscoverer.GatherInstanceTypes(toReturn, toExamine);
				}
				catch
				{
					// swallow, ignore assembly.
					continue;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Gathers the instance types (types which have the DependencyInjectionInfoAttribute annotated onto them)
		/// </summary>
		/// <param name="instanceTypes">The instance types already collected and to which the new types have to be added.</param>
		/// <param name="toExamine">To examine.</param>
		public static void GatherInstanceTypes(MultiValueHashtable<Type, DependencyInjectionInfoAttribute> instanceTypes, Assembly toExamine)
		{
			Type[] publicTypes = toExamine.GetExportedTypes();
			foreach(Type publicType in publicTypes)
			{
				object[] attributes = publicType.GetCustomAttributes(typeof(DependencyInjectionInfoAttribute), true);
				if(attributes.Length > 0)
				{
					foreach(DependencyInjectionInfoAttribute attribute in attributes)
					{
						instanceTypes.Add(publicType, attribute);
					}
				}
			}
		}


		/// <summary>
		/// traverses the assemblies recursively and and collects the assembly names of the assemblies which aren't in the .NET framework but which could
		/// have DI annotated types in them.
		/// </summary>
		/// <param name="toDiscover">assembly to discover.</param>
		/// <param name="names">The names already collected.</param>
		/// <param name="assembliesTraversed">The assemblies already traversed.</param>
		private void Discover(Assembly toDiscover, Dictionary<string, AssemblyName> names, Dictionary<string, object> assembliesTraversed)
		{
			string fullNameOfToDiscover = toDiscover.GetName().FullName;
			if(assembliesTraversed.ContainsKey(fullNameOfToDiscover))
			{
				return;
			}

			assembliesTraversed[fullNameOfToDiscover] = null;

			List<AssemblyName> referencedAssemblyNames = new List<AssemblyName>(toDiscover.GetReferencedAssemblies());
			foreach(AssemblyName name in referencedAssemblyNames)
			{
				if(!CheckIfAssemblyIsAllowed(name))
				{
					// filter out
					continue;
				}

				if(!names.ContainsKey(name.Name))
				{
					names.Add(name.Name, name);
				}

				Assembly referencedAssembly = null;

				try
				{
					referencedAssembly = Assembly.ReflectionOnlyLoad(name.FullName);
					Discover(referencedAssembly, names, assembliesTraversed);
				}
				catch
				{
					// couldn't load assembly. Ignore assembly.
					continue;
				}
			}
		}


		/// <summary>
		/// Checks if assembly is allowed.
		/// </summary>
		/// <param name="toCheck">To check.</param>
		/// <returns>true if allowed, otherwise false.</returns>
		private bool CheckIfAssemblyIsAllowed(AssemblyName toCheck)
		{
			bool ignoreAssembly = false;
			foreach(string filterFragment in _filter)
			{
				ignoreAssembly = ((filterFragment.EndsWith(".") && toCheck.Name.StartsWith(filterFragment)) || (toCheck.Name == filterFragment));
				if(ignoreAssembly)
				{
					break;
				}
			}
			return !ignoreAssembly;
		}
	}
}
