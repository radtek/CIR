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
using System.Threading;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which contains information for the dependency injection logic. The data inside this storage is either filled by code in a scope, or 
	/// read from attributes and/or .diconfig config files. 
	/// </summary>
	internal class DependencyInjectionInfoStorage
	{
		#region Class Member Declarations
		/// <summary>
		/// Dictionary which contains per Type the injection information applicable for that type. If teh list of injectioninfos is empty for a given type,
		/// that type doesn't have any injection info and isn't a target for any instance type. Initially this cache is empty and is filled on the fly when
		/// the first type a target type needs objects injected. 
		/// 
		/// Locking mechanism is as follows: It uses a monitor object to schedule reads/writes
		/// - First a reader lock is obtained to see if a type is in the cache. If so, injectioninfo's are returned, lock is released. 
		/// - if a type isn't present in the cache, it's considered not yet discovered. So the thread will create the InjectionInfo for the type.
		///   when done, it will obtain a writer lock and check again if the type is present. If not, it will add the injection info and release the lock
		///   if it IS present it will drop its own data and will use the present info (which is thus added by another thread during creation of the
		///   injectioninfo). This gives the best performance as the writers don't block reads (reads are readonly always: the data is never modified) and
		///   writers are only be frequently writing at the start of the application. After a while all access are reads, as all types are then cached. 
		/// </summary>
		/// <remarks>Every type stored as key can be injected with the instance defined in injectioninfo.</remarks>
		private MultiValueHashtable _dependencyInfoDataCache;
		private MultiValueHashtable _absoluteNormalTargetTypes;
		private MultiValueHashtable _hierarchyNormalTargetTypes;
		private MultiValueHashtable _interfaceTargetTypes;


		/// <summary>
		/// Instance cache for instances of instancetypes which have to act as singleton's (per thread). Key is the instance type, value is the instance to pick.
		/// </summary>
		[ThreadStatic]
		private static Hashtable _instanceCache;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyInjectionInfoStorage"/> class.
		/// </summary>
		internal DependencyInjectionInfoStorage()
		{
			_dependencyInfoDataCache = new MultiValueHashtable();
		}


		/// <summary>
		/// Gets the instances to inject.
		/// </summary>
		/// <param name="targetType">Type of the target to inject instances in.</param>
		/// <returns>A MergeableDictionary with per PropertyName the injection data with the instance to inject, or null if nothing can be injected.</returns>
		internal MergeableHashtable GetInstancesToInject(Type targetType)
		{
			if(_instanceCache == null)
			{
				_instanceCache = new Hashtable();
			}

			UniqueValueList injectionInfos = null;
			bool isPresent = false;
			// lock the cache. This operation is very fast but it also prevents writers mess with readers. It's faster than using a reader/writer
			// lock here has that lock has problems in scenario's with a lot of readers and a single writer, which is the case when the application
			// runs for some time as then most types are in the cache. 
			using(TimedLock.Lock(_dependencyInfoDataCache))
			{
				injectionInfos = (UniqueValueList)_dependencyInfoDataCache[targetType];
				isPresent = (injectionInfos!=null);
			}

			if(!isPresent)
			{
				// not found. Build the injection info and if not present, add it to the cache. Buildig is outside a lock as it's an expensive operation.
				injectionInfos = BuildInjectionInfo(targetType);
				// obtain a lock for writing so we can write to the cache. First check if the data is again present. 
				using(TimedLock.Lock(_dependencyInfoDataCache))
				{
					UniqueValueList infosFromCache = (UniqueValueList)_dependencyInfoDataCache[targetType];
					if(infosFromCache==null)
					{
						// not present, add it
						_dependencyInfoDataCache.Add(targetType, injectionInfos);
					}
					else
					{
						// added by other thread, use that info
						injectionInfos = infosFromCache;
					}
				}
			}

			if((injectionInfos == null) || (injectionInfos.Count<=0))
			{
				// this type doesn't have stuff to inject
				return null;
			}

			// injectables to process
			MergeableHashtable toReturn = new MergeableHashtable();
			foreach(InjectionInfo info in injectionInfos)
			{
				toReturn.Add(info.PropertyName, new InjectionData(GetInstanceForInjection(info), info.Property));
			}

			return toReturn;
		}


		/// <summary>
		/// Builds the injection info list for the type passed in. This list has to be compiled once for each type and is then cached in the
		/// _dependencyInfoDataCache.
		/// </summary>
		/// <param name="targetType">Type of the target.</param>
		/// <returns>list of injectioninfo objects for the target type or null if the targettype isn't a target for any instance type known.</returns>
		private UniqueValueList BuildInjectionInfo(Type targetType)
		{
			// local cache to speed up lookup process. If already an instance type is found for a given property, we don't have to test if another instance
			// type is also a possible instance for this property.
			Hashtable propertiesAlreadyTaken = new Hashtable();

			UniqueValueList toReturn = new UniqueValueList();

			// traverse all normal types first, then the interfaces. First the absolute target type specifications, then the hierarchies, then the interfaces.
			// this assures that we can easily filter out instance types for properties for which we've already found an instance type for. 
			UniqueValueList infosToProcess = (UniqueValueList)_absoluteNormalTargetTypes[targetType];
			if(infosToProcess!=null)
			{
				ProcessInjectionConfigInfos(propertiesAlreadyTaken, toReturn, infosToProcess, targetType);
			}

			// now traverse the hierarchy defined target types. Do this by first getting a complete list of subtypes of the targettype, with the direct supertype
			// as the first type in the list. By traversing the list, it's assured that the config info of a supertype which is more closer to the target type is
			// used instead of a configinfo of a supertype higher up the hierarchy.
			ArrayList inheritanceHierarchy = new ArrayList();
			inheritanceHierarchy.Add(targetType);
			GetInheritanceHierarchy(targetType, inheritanceHierarchy);
			foreach(Type t in inheritanceHierarchy)
			{
				infosToProcess = (UniqueValueList)_hierarchyNormalTargetTypes[t];
				if(infosToProcess!=null)
				{
					ProcessInjectionConfigInfos(propertiesAlreadyTaken, toReturn, infosToProcess, targetType);
				}
			}

			// the last category are the interface target types. Check all interfaces implemented by the target type to see if there's one in the known lists.
			Type[] implementedInterfaces = targetType.GetInterfaces();
			foreach(Type implementedInterface in implementedInterfaces)
			{
				infosToProcess = (UniqueValueList)_interfaceTargetTypes[implementedInterface];
				if(infosToProcess!=null)
				{
					ProcessInjectionConfigInfos(propertiesAlreadyTaken, toReturn, infosToProcess, targetType);
				}
			}

			// done.
			return toReturn;
		}


		/// <summary>
		/// Processes the injection config infos into InjectionInfo objects
		/// </summary>
		/// <param name="propertiesAlreadyTaken">The properties already taken.</param>
		/// <param name="collectedInjectionInfos">The collected injection infos.</param>
		/// <param name="infosToProcess">The infos to process.</param>
		/// <param name="targetType">Type of the target.</param>
		private void ProcessInjectionConfigInfos(Hashtable propertiesAlreadyTaken, 
				 UniqueValueList collectedInjectionInfos, UniqueValueList infosToProcess, Type targetType)
		{
			foreach(InjectionConfigInfo configInfo in infosToProcess)
			{
				InjectionConfigInfo cachedInfo = (InjectionConfigInfo)propertiesAlreadyTaken[configInfo.PropertyName];
				if(cachedInfo==null)
				{
					// not yet present
					// check if the type has to be filtered out. 
					if(configInfo.TargetNamespaceFilterFragments.Count > 0)
					{
						bool acceptType = false;
						foreach(string fragment in configInfo.TargetNamespaceFilterFragments)
						{
							if(targetType.Namespace.StartsWith(fragment))
							{
								// match
								acceptType = true;
								break;
							}
						}

						if(!acceptType)
						{
							continue;
						}
					}

					collectedInjectionInfos.Add(new InjectionInfo(configInfo, new InjectionInfoEqualComparer()));
					propertiesAlreadyTaken.Add(configInfo.PropertyName, configInfo);
				}
			}
		}


		/// <summary>
		/// Gets the inheritance hierarchy for the type passed in. The type passed in is NOT added to the hierarchy.
		/// </summary>
		/// <param name="currentType">Type of the current.</param>
		/// <param name="collectedTypes">The collected types.</param>
		private void GetInheritanceHierarchy(Type currentType, ArrayList collectedTypes)
		{
			if(currentType.BaseType==null)
			{
				return;
			}
			collectedTypes.Add(currentType.BaseType);
			GetInheritanceHierarchy(currentType.BaseType, collectedTypes);
		}


		/// <summary>
		/// Builds the storage data from the passed in injectioninfo's to quickly find back injection info when a type needs its instances injected.
		/// </summary>
		/// <param name="normalTargetTypes">The normal target types found.</param>
		/// <param name="interfaceTargetTypes">The interface target found.</param>
		internal void BuildStorage(MultiValueHashtable normalTargetTypes, MultiValueHashtable interfaceTargetTypes)
		{
			_hierarchyNormalTargetTypes = new MultiValueHashtable();
			_absoluteNormalTargetTypes = new MultiValueHashtable();
			_interfaceTargetTypes = new MultiValueHashtable();

			foreach(DictionaryEntry pair in normalTargetTypes)
			{
				foreach(InjectionConfigInfo info in (UniqueValueList)pair.Value)
				{
					if(info.TargetKind == DependencyInjectionTargetKind.Absolute)
					{
						_absoluteNormalTargetTypes.Add((Type)pair.Key, info);
					}
					else
					{
						_hierarchyNormalTargetTypes.Add((Type)pair.Key, info);
					}
				}
			}

			foreach(DictionaryEntry pair in interfaceTargetTypes)
			{
				_interfaceTargetTypes.Add((Type)pair.Key, (UniqueValueList)pair.Value);
			}

			if(_dependencyInfoDataCache == null)
			{
				_dependencyInfoDataCache = new MultiValueHashtable();
			}
			_dependencyInfoDataCache.Clear();
		}


		/// <summary>
		/// Get the instance for the injection info passed in.
		/// </summary>
		/// <param name="info">The info.</param>
		/// <returns>the instance to inject</returns>
		private object GetInstanceForInjection(InjectionInfo info)
		{
			object instance = null;
			if(info.ContextType == DependencyInjectionContextType.Singleton)
			{
				instance = _instanceCache[info.InstanceType];
				if(instance==null)
				{
					// not there
					instance = Activator.CreateInstance(info.InstanceType);
					_instanceCache.Add(info.InstanceType, instance);
				}
			}
			else
			{
				instance = Activator.CreateInstance(info.InstanceType);
			}
			return instance;
		}
	}
}
