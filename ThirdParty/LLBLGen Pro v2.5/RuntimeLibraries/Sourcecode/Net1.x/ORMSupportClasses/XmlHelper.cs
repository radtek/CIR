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
using System.Xml;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which contains the data to set an entity reference found in an XmlNode to an entity instance.
	/// Instances of this class are used to store entity references found in an Xml tree in ReadXml() so these
	/// references can be set once the complete object tree is created and objects are known.
	/// </summary>
	internal class NodeEntityReference
	{
		/// <summary>
		/// The instance holding the ReferenceingProperty.
		/// </summary>
		public object				PropertyHoldingInstance;
		/// <summary>
		/// The ObjectID of the entity object to set as value of the ReferencingProperty
		/// </summary>
		public Guid					ObjectID;
		/// <summary>
		/// The property descriptor of the property to set to the instance with the ObjectID stored in ObjectID
		/// </summary>
		public PropertyDescriptor	ReferencingProperty;
		/// <summary>
		/// If set to true, this reference is not a property set but a collection add. Collection to add to is referenced
		/// by PropertyHoldingInstance
		/// </summary>
		public bool					IsCollectionAdd;
		/// <summary>
		/// The position in an entitycollection on which the node entity reference was encountered. Not valid if IsCollectionAdd is false.
		/// </summary>
		public int					Position;
	}


	/// <summary>
	/// Generic XML helper class to work more efficient with an XmlDocument and XmlNodes. This class
	/// contains various utility methods to ease the (de)serialization process of the data to /from Xml
	/// </summary>
	public class XmlHelper
	{
		#region Class Member Declarations
		/// <summary>
		/// Name for the culture to use when converting a value to a string for XML serialization and to use when converting a string back to an object when
		/// XML is deserialized. The name follows the standard names used for CultureInfo. Default: CurrentCulture.Name. See MSDN documentation on CultureInfo
		/// for more information about the specific culture name for the culture to use. For invariant culture, use empty string. 
		/// </summary>
		/// <remarks>You can also set this field by adding a key-value pair to the appSettings section of your application's config file. Use 
		/// 'cultureNameForXmlValueConversion' as key and the name of the culture to use as the value, or empty string for the invariant culture.</remarks>
		public static string CultureNameForXmlValueConversion = CultureInfo.CurrentCulture.Name;
		#endregion

		/// <summary>
		/// Initializes the <see cref="XmlHelper"/> class. Reads the Culturename for xml value conversion, if specified.
		/// </summary>
		static XmlHelper()
		{
#if !CF
			NameValueCollection appSettings = ConfigurationSettings.AppSettings;
			if(appSettings!=null)
			{
				string value = appSettings["cultureNameForXmlValueConversion"];
				if(value != null)
				{
					// defined
					XmlHelper.CultureNameForXmlValueConversion = value;
				}
			}
#endif
		}


		/// <summary>
		/// CTor
		/// </summary>
		public XmlHelper()
		{
		}


		/// <summary>
		/// Converts the value of the property passed in to a string and adds that string as a child node of type textnode to the childnode passed in.
		/// </summary>
		/// <param name="parentDocument">The parent document.</param>
		/// <param name="datesInXmlDataType">if set to <c>true</c> [dates in XML data type].</param>
		/// <param name="mlInCDataBlocks">if set to <c>true</c> [ml in C data blocks].</param>
		/// <param name="propertyValue">The property value.</param>
		/// <param name="childNode">The child node.</param>
		/// <param name="propertyType">Type of the property.</param>
		internal void PropertyValueToString(XmlDocument parentDocument, bool datesInXmlDataType, bool mlInCDataBlocks,
			object propertyValue, XmlNode childNode, Type propertyType)
		{
			string valueAsString = String.Empty;
			bool valueInCDataBlock = false;
			if(propertyValue != null)
			{
				valueAsString = XmlHelper.PropertyValueToString(datesInXmlDataType, mlInCDataBlocks, propertyValue, propertyValue.GetType(), out valueInCDataBlock);
			}
			if(valueInCDataBlock)
			{
				childNode.AppendChild(parentDocument.CreateCDataSection(valueAsString));
			}
			else
			{
				childNode.AppendChild(parentDocument.CreateTextNode(valueAsString));
			}
		}


		/// <summary>
		/// Converts the value of the property passed in to a string
		/// </summary>
		/// <param name="datesInXmlDataType">xml aspect</param>
		/// <param name="mlInCDataBlocks">xml aspect</param>
		/// <param name="propertyValue">The property value.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <param name="valueInCDataBlock">flag which will be true if the returned string should be wrapped in a CData block</param>
		/// <returns>
		/// the property value in string form, ready to use in the XML
		/// </returns>
		public static string PropertyValueToString(bool datesInXmlDataType, bool mlInCDataBlocks, object propertyValue, Type propertyType, 
			out bool valueInCDataBlock)
		{
			CultureInfo culture = new CultureInfo(XmlHelper.CultureNameForXmlValueConversion);

			string valueAsString = String.Empty;
			string realDataTypeName = propertyType.UnderlyingSystemType.FullName;
			valueInCDataBlock = false;
			if( propertyValue != null )
			{
				switch(realDataTypeName)
				{
					case "System.String":
						valueAsString = propertyValue.ToString();
						if( mlInCDataBlocks )
						{
							valueInCDataBlock = (valueAsString.IndexOfAny( new char[] { '<', '>' } ) >= 0);
						}
						break;
					case "System.Byte":
					case "System.Int32":
					case "System.Int16":
					case "System.Int64":
					case "System.Guid":
						valueAsString = propertyValue.ToString();
						break;
					case "System.Decimal":
						valueAsString = ((Decimal)propertyValue).ToString(culture.NumberFormat);
						break;
					case "System.Double":
						valueAsString = ((Double)propertyValue).ToString(culture.NumberFormat);
						break;
					case "System.Single":
						valueAsString = ((Single)propertyValue).ToString(culture.NumberFormat);
						break;
					case "System.DateTime":
						if( datesInXmlDataType )
						{
							valueAsString = XmlConvert.ToString((DateTime)propertyValue);
						}
						else
						{
							valueAsString = ((DateTime)propertyValue).Ticks.ToString();
						}
						break;
					case "System.Byte[]":
						// special case, base64encode it
						byte[] valueToConvert = (byte[])propertyValue;
						valueAsString = Convert.ToBase64String( valueToConvert, 0, valueToConvert.Length );
						break;
					default:
						valueAsString = propertyValue.ToString();
						break;
				}
			}
			return valueAsString;
		}


		/// <summary>
		/// Writes the value as string to XML.
		/// </summary>
		/// <param name="propertyType">Type of the property the value is read from.</param>
		/// <param name="value">The value read from the property.</param>
		/// <param name="verboseXml">flag if verbose XML has to be emitted</param>
		/// <param name="writeTypeInfoIfNull">true if the type info should be written into the element if the value is null</param>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="datesInXmlDataType">xmlaspect</param>
		/// <param name="mlInCDataBlocks">xmlaspect</param>
		/// <remarks>The writer should have written a StartElement right before this method is called.</remarks>
		public static void WriteValueAsStringToXml(Type propertyType, object value, bool verboseXml, bool writeTypeInfoIfNull, XmlWriter writer, bool datesInXmlDataType, bool mlInCDataBlocks)
		{
			bool wrapInCData = false;
			string valueAsString = XmlHelper.PropertyValueToString(datesInXmlDataType, mlInCDataBlocks, value, propertyType, out wrapInCData);
			if(verboseXml || ((value==null) && writeTypeInfoIfNull))
			{
				string valueTypeName = string.Empty;
				if(value == null)
				{
					valueTypeName = "Unknown";
				}
				else
				{
					valueTypeName = propertyType.UnderlyingSystemType.FullName;
				}
				writer.WriteAttributeString("Type", valueTypeName);
			}
			if(wrapInCData)
			{
				writer.WriteCData(valueAsString);
			}
			else
			{
				writer.WriteString(valueAsString);
			}
		}


		/// <summary>
		/// Gets the XML format in XmlFormatAspect of the xml in the reader. The reader has to point to the root element. 
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>format of xml.</returns>
		/// <remarks>Reader stays at the position it's on. Call Read() before calling this method</remarks>
		internal static XmlFormatAspect GetXmlFormat(XmlReader reader)
		{
			if(reader.ReadState == ReadState.Initial)
			{
				reader.Read();
			}
			XmlFormatAspect toReturn = XmlFormatAspect.None;
			string formatSpecification = string.Empty;
			if(reader.HasAttributes)
			{
				// check if the element has a Format attribute
				formatSpecification = reader.GetAttribute("Format");
			}

			if(formatSpecification == "Compact25")
			{
				toReturn = XmlFormatAspect.Compact25;
			}

			return toReturn;
		}


		/// <summary>
		/// Sets the references found during deserialization to the objects instantiated
		/// </summary>
		/// <param name="nodeEntityReferences">list of references</param>
		/// <param name="processedObjectIDs">list of processed objects to set references to</param>
		public static void SetReadReferences(ArrayList nodeEntityReferences, Hashtable processedObjectIDs)
		{
			for (int i = 0; i < nodeEntityReferences.Count; i++)
			{
				NodeEntityReference currentReference = (NodeEntityReference)nodeEntityReferences[i];
				if(currentReference.IsCollectionAdd)
				{
					// is a collection addition. Add it
					EntityCollectionBase2 collection = (EntityCollectionBase2)currentReference.PropertyHoldingInstance;
					collection.DeserializationInProgress=true;
					// insert object at position tracked.
					collection.Insert(currentReference.Position, (IEntity2)processedObjectIDs[currentReference.ObjectID]);
					collection.DeserializationInProgress=false;
				}
				else
				{
					// entity reference set in another entity.
					EntityBase2 currentEntity = (EntityBase2)currentReference.PropertyHoldingInstance;
					currentEntity.IsDeserializing=true;
					currentReference.ReferencingProperty.SetValue(currentEntity, (IEntity2)processedObjectIDs[currentReference.ObjectID]);
					currentEntity.IsDeserializing=false;
				}
			}
		}


		/// <summary>
		/// Sets the references found during deserialization to the objects instantiated
		/// SelfServicing version
		/// </summary>
		/// <param name="nodeEntityReferences">list of references</param>
		/// <param name="processedObjectIDs">list of processed objects to set references to</param>
		public static void SetReadReferencesSS(ArrayList nodeEntityReferences, Hashtable processedObjectIDs)
		{
			for (int i = 0; i < nodeEntityReferences.Count; i++)
			{
				NodeEntityReference currentReference = (NodeEntityReference)nodeEntityReferences[i];
				if(currentReference.IsCollectionAdd)
				{
					// is a collection addition. Add it
					EntityCollectionBase collection = (EntityCollectionBase)currentReference.PropertyHoldingInstance;
					collection.DeserializationInProgress=true;
					// insert object at position tracked.
					collection.Insert(currentReference.Position, (IEntity)processedObjectIDs[currentReference.ObjectID]);
					collection.DeserializationInProgress=false;
				}
				else
				{
					// entity reference set in another entity.
					EntityBase currentEntity = (EntityBase)currentReference.PropertyHoldingInstance;
					currentEntity.IsDeserializing=true;
					currentReference.ReferencingProperty.SetValue(currentEntity, (IEntity)processedObjectIDs[currentReference.ObjectID]);
					currentEntity.IsDeserializing=false;
				}
			}

			// call PostReadXmlFixups to set the alreadyFetched flags 
			foreach(EntityBase entity in processedObjectIDs.Values)
			{
				entity.CallPostReadXmlFixups();
			}
		}


		/// <summary>
		/// Adds a new XmlNode with the name nodeName to the document specified. Does not add the node to any
		/// parent node.
		/// </summary>
		/// <param name="parentDocument">document the new node will be added to</param>
		/// <param name="nodeName">name of node</param>
		/// <returns>New node created</returns>
		public virtual XmlNode CreateNewNode(XmlDocument parentDocument, string nodeName)
		{
			XmlNode newNode = parentDocument.CreateNode(XmlNodeType.Element, nodeName, "");
			return newNode;
		}


		/// <summary>
		/// Adds a new XmlNode with the name nodeName and the value nodeValue to the node parentNode specified
		/// </summary>
		/// <param name="parentNode">the parent node the node will be added to as a childnode</param>
		/// <param name="nodeName">name of node</param>
		/// <param name="nodeValue">value of node</param>
		/// <returns>New node created</returns>
		public virtual XmlNode AddNode(XmlNode parentNode, string nodeName, string nodeValue)
		{
			XmlNode newNode = CreateNewNode(parentNode.OwnerDocument, nodeName);
			parentNode.AppendChild(newNode);
			newNode.AppendChild(parentNode.OwnerDocument.CreateTextNode(nodeValue));
			return newNode;
		}


		/// <summary>
		/// Adds a new XmlNode with the name nodeName to the node parentNode specified
		/// </summary>
		/// <param name="parentNode">the parent node the node will be added to as a childnode</param>
		/// <param name="nodeName">name of node</param>
		/// <returns>New node created</returns>
		public virtual XmlNode AddNode(XmlNode parentNode, string nodeName)
		{
			XmlNode newNode = CreateNewNode(parentNode.OwnerDocument, nodeName);
			parentNode.AppendChild(newNode);
			return newNode;
		}


		/// <summary>
		/// Creates a new attribute with the name attributeName and the value attributeValue in the attributeCollection of the node parentNode, using
		/// the parentNode's owner document
		/// </summary>
		/// <param name="parentNode">the attribute's parent node</param>
		/// <param name="attributeName">the name for the new attribute</param>
		/// <param name="attributeValue">the value for the new attribute</param>
		/// <returns>the new attribute</returns>
		public virtual XmlAttribute AddAttribute(XmlNode parentNode, string attributeName, string attributeValue)
		{
			XmlAttribute newAttribute = parentNode.OwnerDocument.CreateAttribute(attributeName);
			newAttribute.Value = attributeValue;
			parentNode.Attributes.Append(newAttribute);
			return newAttribute;
		}


		/// <summary>
		/// Converts the passed in value to the type with the name typeName. The typeName has to be a known type in .NET, and
		/// currently can only be a simple type. The value is returned as 'object'. 
		/// </summary>
		/// <param name="typeName">name of the type the value should be converted in.</param>
		/// <param name="xmlValue">value of the xml node which should be converted into an object.</param>
		/// <returns>the value converted into its native type.</returns>
		public object XmlValueToObject(string typeName, string xmlValue)
		{
			CultureInfo culture = new CultureInfo(XmlHelper.CultureNameForXmlValueConversion);
			object toReturn = null;
			string typeOfValue = typeName;
			Type realType = Type.GetType(typeName, false, false);
#if !CF
			if(realType.IsEnum)
			{
				typeOfValue="System.Enum";
			}
#endif
			switch(typeOfValue)
			{
				case "System.String":
					toReturn = xmlValue;
					break;
				case "System.Byte":
					toReturn = Convert.ToByte(xmlValue);
					break;
				case "System.Int32":
					toReturn = Convert.ToInt32(xmlValue);
					break;
				case "System.Int16":
					toReturn = Convert.ToInt16(xmlValue);
					break;
				case "System.Int64":
					toReturn = Convert.ToInt64(xmlValue);
					break;
				case "System.Decimal":
					toReturn = Convert.ToDecimal(xmlValue, culture.NumberFormat);
					break;
				case "System.Double":
					toReturn = Convert.ToDouble(xmlValue, culture.NumberFormat);
					break;
				case "System.Single":
					toReturn = Convert.ToSingle(xmlValue, culture.NumberFormat);
					break;
				case "System.Boolean":
					toReturn = Convert.ToBoolean(xmlValue);
					break;
				case "System.Guid":
					toReturn = new Guid(xmlValue);
					break;
				case "System.DateTime":
					if(xmlValue.IndexOfAny(new char[] {':', '-', '.'})>0)
					{
						// standard date, convert
						toReturn = XmlConvert.ToDateTime(xmlValue);
					}
					else
					{
						long ticks = Convert.ToInt64(xmlValue);
						toReturn = new DateTime(ticks);
					}
					break;
				case "System.Byte[]":
					toReturn = Convert.FromBase64String(xmlValue);
					break;
#if !CF
				case "System.Enum":
					toReturn = Enum.Parse(realType, xmlValue, false);
					break;
#endif
				default:
					if(xmlValue.Length<=0)
					{
						toReturn=null;
					}
					else
					{
						toReturn = xmlValue;
					}
					break;
			}
			return toReturn;
		}
	}
}
















