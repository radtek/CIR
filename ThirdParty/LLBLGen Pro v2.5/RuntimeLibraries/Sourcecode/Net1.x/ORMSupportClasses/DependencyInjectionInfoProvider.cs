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
using System.Collections;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Singleton class which contains the single instance of the DependencyInjectionProvider 
	/// </summary>
	public class DependencyInjectionInfoProviderSingleton
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
			Hashtable toInject = DependencyInjectionInfoProviderSingleton.GetInstance().GetInstancesToInject(injectionTarget.GetType());
			if(toInject != null)
			{
				foreach(DictionaryEntry pair in toInject)
				{
					((InjectionData)pair.Value).PropertyToSet.SetValue(injectionTarget, ((InjectionData)pair.Value).InjectableObject, null);
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
		private MultiValueHashtable _interfaceTargetTypes;
		private MultiValueHashtable _normalTargetTypes;

		[ThreadStatic]
		private static Stack _scopeStorages;
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
		internal Hashtable GetInstancesToInject(Type targetType)
		{
			// first grab the values from a scope, if present
			MergeableHashtable toReturn = new MergeableHashtable();
			MergeableHashtable scopeData = GetScopeSpecificInstancesToInject(targetType);
			MergeableHashtable centralData = _centralStorage.GetInstancesToInject(targetType);

			// MergeableHashtable merges NEW data from the dictionary passed in into the dictionary the method is called on.
			// this means that overruling data should be merged first. 
			if(scopeData != null)
			{
				toReturn.MergeHashtable(scopeData);
			}
			if(centralData != null)
			{
				toReturn.MergeHashtable(centralData);
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


		/// <summary>
		/// Marks the begin of a scope and therefore creates the scope data storage.
		/// </summary>
		/// <param name="scopeStorage">The scope storage to use. This scopestorage is passed in by the di scope started.</param>
		internal static void BeginScope(DependencyInjectionInfoStorage scopeStorage)
		{
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
		private MergeableHashtable  GetScopeSpecificInstancesToInject(Type targetType)
		{
			MergeableHashtable toReturn = new MergeableHashtable();

			if(_scopeStorages == null)
			{
				_scopeStorages = new Stack();
			}

			foreach(DependencyInjectionInfoStorage scopeStorage in _scopeStorages)
			{
				MergeableHashtable toMerge = scopeStorage.GetInstancesToInject(targetType);
				if(toMerge != null)
				{
					toReturn.MergeHashtable(toMerge);
				}
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


		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Init()
		{
			_centralStorage = new DependencyInjectionInfoStorage();
			_scopeStorages = new Stack();
			_normalTargetTypes = new MultiValueHashtable();
			_interfaceTargetTypes = new MultiValueHashtable();

			MultiValueHashtable instanceTypesFound = new MultiValueHashtable();

			// check if autoDiscovery has to take place
			bool performAutoDiscovery = false;
			
			NameValueCollection appSettings = ConfigurationSettings.AppSettings;
			if(appSettings!=null)
			{
				string value = appSettings["autoDependencyInjectionDiscovery"];
				if(value!=null)
				{
					performAutoDiscovery = Convert.ToBoolean(value);
				}
			}

			performAutoDiscovery |= DependencyInjectionDiscoveryInformation.PerformAutoDiscoveryDependencyInjectionInformation;

			if(performAutoDiscovery)
			{
				// determine the types with the DependencyInjectionInfoAttribute attribute on them in the assemblies reachable from the current appdomain.
				AppDomain traverserAD = AppDomain.CreateDomain("Traverser", null, AppDomain.CurrentDomain.BaseDirectory, 
					AppDomain.CurrentDomain.RelativeSearchPath, false);

				// use the type discoverer class with an instance in the new appdomain.
				TypeDiscoverer discoverer = (TypeDiscoverer)traverserAD.CreateInstanceAndUnwrap(typeof(TypeDiscoverer).Assembly.FullName, typeof(TypeDiscoverer).FullName);

				// pass the currently loaded assembly names to the discoverer, so it can start with these to traverse the referenced assembly tree.
				ArrayList loadedAssemblyNames = new ArrayList();
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
				diInfoFromConfig = (DependencyInjectionConfigInformation)ConfigurationSettings.GetConfig("dependencyInjectionInformation");
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
				MultiValueHashtable instanceTypesFound)
		{
			// traverse all found instance types and check if the type has to be filtered out. 
			foreach(DictionaryEntry pair in instanceTypesFound)
			{
				bool acceptType = false;
				Type publicType = (Type)pair.Key;
				UniqueValueList diAttributes = (UniqueValueList)pair.Value;

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
					acceptType = (acceptType && diAttribute.Property.PropertyType.IsAssignableFrom((Type)pair.Key));

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
		public MultiValueHashtable InterfaceInstanceTypes
		{
			get { return _interfaceTargetTypes; }
		}

		/// <summary>
		/// Gets the normal target types discovered from the assemblies in the application
		/// </summary>
		public MultiValueHashtable NormalInstanceTypes
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
		public MultiValueHashtable Discover(ArrayList assemblyNamesCurrentAD)
		{
			Hashtable assemblyNames = new Hashtable();
			Hashtable assembliesTraversed = new Hashtable();
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
			MultiValueHashtable toReturn = new MultiValueHashtable();

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
		public static void GatherInstanceTypes(MultiValueHashtable instanceTypes, Assembly toExamine)
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
		private void Discover(Assembly toDiscover, Hashtable names, Hashtable assembliesTraversed)
		{
			string fullNameOfToDiscover = toDiscover.GetName().FullName;
			if(assembliesTraversed.ContainsKey(fullNameOfToDiscover))
			{
				return;
			}

			assembliesTraversed[fullNameOfToDiscover] = null;

			ArrayList referencedAssemblyNames = new ArrayList(toDiscover.GetReferencedAssemblies());
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
					referencedAssembly = Assembly.Load(name.FullName);
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
