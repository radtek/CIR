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
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.IO;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Handles the DependencyInjectionInformation section in the config file and creates an instance of DependencyInjectionConfigInformation with
	/// information stored in the section.
	/// </summary>
	public class DependencyInjectionSectionHandler : IConfigurationSectionHandler 
	{
		/// <summary>
		/// Creates an instance of DependencyInjectionConfigInformation with the information defined in the config file
		/// </summary>
		/// <param name="parent">Parent object.</param>
		/// <param name="configContext">Configuration context object.</param>
		/// <param name="section">Section XML node.</param>
		/// <returns>an instance of DependencyInjectionConfigInformation with the information read from the config file.</returns>
		public object Create(object parent, object configContext, XmlNode section)
		{
			return CreateStatic(section);
		}


		/// <summary>
		/// Performs the Create method's logic statically to be thread safe. 
		/// </summary>
		/// <param name="section">The section.</param>
		/// <returns>an instance of DependencyInjectionConfigInformation with the information read from the config file.</returns>
		private static object CreateStatic(XmlNode section)
		{
			DependencyInjectionConfigInformation toReturn = new DependencyInjectionConfigInformation();
			foreach(XmlNode childNode in section.ChildNodes)
			{
				switch(childNode.Name)
				{
					case "additionalAssemblies":
						ArrayList additionalAssemblies = ParseAssemblies(childNode);
						foreach(Assembly toAdd in additionalAssemblies)
						{
							toReturn.AddAssembly(toAdd);
						}
						break;
					case "instanceTypeFilters":
						ArrayList namespaceFilterFragments = ParseInstanceTypeFilters(childNode);
						foreach(string fragment in namespaceFilterFragments)
						{
							toReturn.AddNamespaceFilterFragment(fragment);
						}
						break;
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Parses the instance type filters node in a DependencyInjectionInformation section
		/// </summary>
		/// <param name="instanceTypeFiltersNode">The instance type filters node.</param>
		/// <returns>List with fragments for namespaces to filter</returns>
		private static ArrayList ParseInstanceTypeFilters(XmlNode instanceTypeFiltersNode)
		{
			ArrayList toReturn = new ArrayList();
			foreach(XmlNode fragmentFilterNode in instanceTypeFiltersNode)
			{
				if(fragmentFilterNode.Name != "instanceTypeFilter")
				{
					continue;
				}

				XmlAttribute parameter = fragmentFilterNode.Attributes["namespace"];
				if(parameter == null)
				{
					continue;
				}
				string toAdd = parameter.Value;
				if(toAdd.Trim().Length <= 0)
				{
					continue;
				}
				toReturn.Add(toAdd);
			}
			return toReturn;
		}


		/// <summary>
		/// Parses the additionalAssemblies node in a DependencyInjectionInformation section.
		/// </summary>
		/// <param name="assembliesNode">The assemblies node.</param>
		/// <returns>List with assembly instances of the assemblies specified.</returns>
		private static ArrayList ParseAssemblies(XmlNode assembliesNode)
		{
			ArrayList toReturn = new ArrayList();
			foreach(XmlNode assemblyNode in assembliesNode.ChildNodes)
			{
				if(assemblyNode.Name != "assembly")
				{
					continue;
				}
				// check if this node defines a filename or a full name
				XmlAttribute parameter = assemblyNode.Attributes["filename"];
				bool isFilename = true;
				if(parameter == null)
				{
					// full name
					isFilename = false;
					parameter = assemblyNode.Attributes["fullName"];
				}
				if(parameter == null)
				{
					continue;
				}
				Assembly toAdd = null;
				if(isFilename)
				{
					string filename = parameter.Value;
					if(!Path.IsPathRooted(filename))
					{
						filename = Path.Combine(Path.GetDirectoryName(typeof(DependencyInjectionSectionHandler).Assembly.Location), filename);
					}
					if(!File.Exists(filename))
					{
						continue;
					}
#if DOTNET10
					toAdd = Assembly.LoadFrom(filename);
#else
					toAdd = Assembly.LoadFile(filename);
#endif
				}
				else
				{
					toAdd = Assembly.Load(parameter.Value);
				}
				if(toAdd == null)
				{
					continue;
				}
				toReturn.Add(toAdd);
			}
			return toReturn;
		}
	}


	/// <summary>
	/// Class which is used for storing the information read from a DependencyInjectionInformation section in the config file. 
	/// Instances are created by the DependencyInjectionSectionHandler
	/// </summary>
	public class DependencyInjectionConfigInformation
	{
		#region Class member declarations
		private ArrayList _additionalAssemblies;
		private ArrayList _namespaceFilterFragments;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyInjectionConfigInformation"/> class.
		/// </summary>
		public DependencyInjectionConfigInformation()
		{
			_additionalAssemblies =	new ArrayList();
			_namespaceFilterFragments = new ArrayList();
		}


		/// <summary>
		/// Adds the assembly.
		/// </summary>
		/// <param name="toAdd">To add.</param>
		public void AddAssembly(Assembly toAdd)
		{
			_additionalAssemblies.Add(toAdd);
		}


		/// <summary>
		/// Adds the namespace filter fragment.
		/// </summary>
		/// <param name="namespaceFilterFragment">The namespace filter fragment.</param>
		public void AddNamespaceFilterFragment(string namespaceFilterFragment)
		{
			_namespaceFilterFragments.Add(namespaceFilterFragment);
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets additionalAssemblies
		/// </summary>
		public ArrayList AdditionalAssemblies
		{
			get
			{
				return _additionalAssemblies;
			}
			set
			{
				_additionalAssemblies = value;
			}
		}

		/// <summary>
		/// Gets / sets namespaceFilterFragments
		/// </summary>
		public ArrayList NamespaceFilterFragments
		{
			get
			{
				return _namespaceFilterFragments;
			}
			set
			{
				_namespaceFilterFragments = value;
			}
		}
		#endregion
	}
	

	/// <summary>
	/// Static class which is used to set discovery information for dependency injection info for the situation when there's no config file available
	/// in the application. Set the variables of this static class in a static constructor of your application in such a way that the static constructor is
	/// ran before an entity is instantiated so the DependencyInjectionInfoProvider is initialized after this class is initialized by your application. 
	/// </summary>
	public class DependencyInjectionDiscoveryInformation
	{
		/// <summary>
		/// Private CTor
		/// </summary>
		static DependencyInjectionDiscoveryInformation()
		{
		}

		/// <summary>
		/// Flag to signal the DependencyInjectionProvider that the auto discovery of dependency injection info in the assemblies of the application should be
		/// performed (true) or not (false). Default: false
		/// </summary>
		public static bool PerformAutoDiscoveryDependencyInjectionInformation = false;
		/// <summary>
		/// Set this object to an instance of DependencyInjectionConfigInformation with the assemblies / namespace fragments as if it was loaded from the
		/// config file. If you need information read from the config file, leave this field to null / Nothing (default) so it will signal the 
		/// DependencyInjectionInfoProvider to read the config file for additional information instead. 
		/// </summary>
		/// <remarks>Is initially null. Only set this field to a value if you don't use the config file to specify additional dependency injection 
		/// information and assemblies.</remarks>
		public static DependencyInjectionConfigInformation ConfigInformation = null;
	}
}
