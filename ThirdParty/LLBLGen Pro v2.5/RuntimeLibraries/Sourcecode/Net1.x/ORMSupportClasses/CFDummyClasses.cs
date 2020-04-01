//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2006 Solutions Design. All rights reserved.
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
// This file contains various dummy constructs to make the general code compile on the Compact Framework (CF)
// It contains mostly re-defines of normal .NET classes with empty bodies. Use this file at the command line
// to build the code for the CF. Specify the compiler directive 'CF' to include this code.
/////////////////////////////////////////////////////////////
using System;
using System.Xml;
using OpenNETCF;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// 
	/// </summary>
	public class EntityFactoryCache2
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="factoryType"></param>
		/// <returns></returns>
		public static IEntityFactory2 GetEntityFactory(Type factoryType)
		{
			return (IEntityFactory2)Activator.CreateInstance(factoryType);
		}
	}

	/// <summary>
	/// Dummy class to make it easier to compile the code which refers to this class which is only present in the normal ormsupportclasses dll.
	/// </summary>
	public class SerializationHelper
	{
		/// <summary>
		/// Optimization to take. 
		/// </summary>
		public static SerializationOptimization Optimization = SerializationOptimization.None;

		/// <summary>
		/// Dummy method
		/// </summary>
		/// <param name="toDeserialize"></param>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public static void Deserialize(object toDeserialize, SerializationInfo info, StreamingContext context)
		{
			// nop
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="toSerialize"></param>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public static void Serialize(object toSerialize, SerializationInfo info, StreamingContext context)
		{
			// nop
		}
	}


	/// <summary>
	/// Dummy class for SerializationInfo, as the CF doesn't support remoting. This dummy class makes sure that serialization code does
	/// compile.
	/// </summary>
	public class SerializationInfo
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="name"></param>
		public void AddValue(object o, object name) {}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="o"></param>
		/// <param name="name"></param>
		/// <param name="type"></param>
		public void AddValue(object o, object name, object type) {}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool GetBoolean(string name) {return false;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public byte GetByte(string name) {return 0;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public char GetChar(string name) {return ' ';}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public DateTime GetDateTime(string name) {return DateTime.Now;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public decimal GetDecimal(string name) {return 0M;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public double GetDouble(string name) {return 0.0;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public short GetInt16(string name) {return 0;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public int GetInt32(string name) {return 0;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public long GetInt64(string name) {return 0;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public float GetSingle(string name) {return 0.0f;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public string GetString(string name) {return string.Empty;}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public object GetValue(string name, Type type) {return null;}
	}


	/// <summary>
	/// Dummy struct for Serialization code.
	/// </summary>
	public struct StreamingContext
	{
		int dummy;
	}


	/// <summary>
	/// Dummy class to simulate trace switch code. On the CF tracing isn't supported. To avoid a lot of conditional compilations, this class
	/// is added. 
	/// </summary>
	public class TraceSwitch
	{
		// Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="displayName"></param>
		/// <param name="description"></param>
		public TraceSwitch(string displayName, string description) {}

		// Properties
		/// <summary>
		/// 
		/// </summary>
		public bool TraceError { get { return false;} }
		/// <summary>
		/// 
		/// </summary>
		public bool TraceInfo { get { return false;} }
		/// <summary>
		/// 
		/// </summary>
		public bool TraceVerbose { get { return false;} }
		/// <summary>
		/// 
		/// </summary>
		public bool TraceWarning { get { return false;} }
	}

	/// <summary>
	/// Dummy replacer attribute for CF, as CF doesn't have a serializable attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class SerializableAttribute : Attribute
	{

	}

	/// <summary>
	/// Dummy class for serialization exception. Not used on CF, but makes the code compile better
	/// </summary>
	public class SerializationException : Exception
	{
		
	}


	/// <summary>
	/// Dummy replacer attribute for CF, as CF doesn't have a DesignOnly attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class DesignOnlyAttribute : Attribute
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="b"></param>
		public DesignOnlyAttribute(bool b)
		{
		}
	}


	/// <summary>
	/// Basic class which contains utility methods for Xml usage as the CF lacks XPath. 
	/// </summary>
	public class XmlCFUtilities
	{
		/// <summary>
		/// Selects a single node with the name nameToFind in the childs of toSearch
		/// </summary>
		/// <param name="toSearch">To search.</param>
		/// <param name="nameToFind">Name to find.</param>
		/// <returns></returns>
		public static XmlNode SelectSingleNode(XmlNode toSearch, string nameToFind)
		{
			XmlNode toReturn = null;

			foreach(XmlNode node in toSearch.ChildNodes)
			{
				if(node.Name==nameToFind)
				{
					toReturn = node;
					break;
				}
			}

			return toReturn;
		}
	}


	/// <summary>
	/// General class with various CF utility routines.
	/// </summary>
	/// <remarks>some code from OpenNETCF.org: http://www.opennetcf.org </remarks>
	public class GeneralCFUtilities
	{
		/// <summary>
		/// Create a new GUID. The CF framework lacks Guid.NewGuid so this utility method is used. It uses code from OpenNETCF.org
		/// </summary>
		/// <returns></returns>
		public static Guid CreateNewGuid()
		{
			return GuidEx.NewGuid();
		}
	}


	/// <summary>
	/// Dummy class which is used to keep code clean, as it's used in a lot of tests in the code.
	/// </summary>
	internal class EntityCollectionComponentDesigner
	{
		private static bool _inDesignMode = false;

		public static bool InDesignMode
		{
			get { return false;}
			set { _inDesignMode = value;}
		}
	}


	#region Compact Framework Dummy Interfaces
	/// <summary>
	/// 
	/// </summary>
	public interface ISerializable
	{
		/// <summary>
		/// ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// </summary>
		/// <param name="info">See ISerializable</param>
		/// <param name="context">See ISerialilzable</param>
		void GetObjectData(SerializationInfo info, StreamingContext context);
	}
	#endregion
}

namespace System.ComponentModel
{
	/// <summary>
	/// Dummy replacer attribute for CF, as CF doesn't have a Browsable attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class BrowsableAttribute : Attribute
	{
		private bool _isBrowsable;

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="b"></param>
		public BrowsableAttribute(bool b)
		{
			_isBrowsable = b;
		}


		/// <summary>
		/// Gets browsable flag.
		/// </summary>
		public bool Browsable
		{
			get { return _isBrowsable;}
		}
	}
}

