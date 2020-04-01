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
using System.Collections;
using System.Text;
using System.ComponentModel;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract class for the persistence info provider class which is used to provide FieldPersistenceInfo objects for fields/entities.
	/// </summary>
	public abstract class PersistenceInfoProviderBase : IPersistenceInfoProvider
	{
		#region Class Member Declarations
		private Hashtable _elementMappings;
		#endregion

		#region Private class declarations
		/// <summary>
		/// private class which is used to store mapping info of an element.
		/// </summary>
		private class ElementToTargetMapping
		{
			#region Class Member Declarations
			private string _catalogName, _schemaName, _targetName;
			private Hashtable	_elementFieldMappings;
#if CF
			private Hashtable _elementFieldMappingsOnIndex;
#else
			private SortedList	_elementFieldMappingsOnIndex;
#endif
			#endregion

			/// <summary>
			/// Initializes a new instance of the <see cref="ElementToTargetMapping"/> class.
			/// </summary>
			/// <param name="catalogName">Name of the catalog.</param>
			/// <param name="schemaName">Name of the schema.</param>
			/// <param name="targetName">Name of the target.</param>
			/// <param name="numberOfFields">The number of fields.</param>
			internal ElementToTargetMapping( string catalogName, string schemaName, string targetName, int numberOfFields)
			{
				_catalogName = catalogName;
				_schemaName = schemaName;
				_targetName = targetName;
				_elementFieldMappings = new Hashtable( numberOfFields );
#if CF
				_elementFieldMappingsOnIndex = new Hashtable( numberOfFields );
#else
				_elementFieldMappingsOnIndex = new SortedList( numberOfFields );
#endif
			}

			#region Class Property Declarations
			/// <summary>
			/// Gets or sets the name of the catalog.
			/// </summary>
			/// <value>The name of the catalog.</value>
			internal string CatalogName
			{
				get { return _catalogName; }
				set { _catalogName = value; }
			}

			/// <summary>
			/// Gets or sets the name of the schema.
			/// </summary>
			/// <value>The name of the schema.</value>
			internal string SchemaName
			{
				get { return _schemaName; }
				set { _schemaName = value; }
			}

			/// <summary>
			/// Gets or sets the name of the target.
			/// </summary>
			/// <value>The name of the target.</value>
			internal string TargetName
			{
				get { return _targetName; }
				set { _targetName = value; }
			}

			/// <summary>
			/// Gets the element field mappings.
			/// </summary>
			/// <value>The element field mappings.</value>
			internal Hashtable ElementFieldMappings
			{
				get { return _elementFieldMappings; }
			}

			/// <summary>
			/// Gets the indexes of the element field mappings.
			/// </summary>
			/// <value>The index of the element field mappings on.</value>
#if CF
			internal Hashtable ElementFieldMappingsOnIndex
#else
			internal SortedList ElementFieldMappingsOnIndex
#endif
			{
				get { return _elementFieldMappingsOnIndex; }
			}

			#endregion
		}
		#endregion


		/// <summary>
		/// Retrieves for each field of entity / typed view with the name passed in the corresponding IFieldPersistenceInfo instance.
		/// The order of these IFieldPersistenceInfo objects is the same as the corresponding fields in an 
		/// entity / typed view with the name objectName.
		/// </summary>
		/// <param name="elementName">Name of the entity / typed view to retrieve the IFieldPersistenceInfo objects for. Example: CustomerEntity</param>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		public IFieldPersistenceInfo[] GetAllFieldPersistenceInfos( string elementName )
		{
			if( (elementName.Length<=0 ))
			{
				return null;
			}

			ElementToTargetMapping mapping = GetElementMappingInfo( elementName );
			IFieldPersistenceInfo[] toReturn = new IFieldPersistenceInfo[mapping.ElementFieldMappings.Count];
#if CF
			foreach(DictionaryEntry entry in mapping.ElementFieldMappingsOnIndex)
			{
				toReturn[(int)entry.Key] = (IFieldPersistenceInfo)entry.Value;
			}
#else
			mapping.ElementFieldMappingsOnIndex.Values.CopyTo( toReturn, 0 );
#endif
			return toReturn;
		}


		/// <summary>
		/// Retrieves for each field of the entity instance passed in the corresponding IFieldPersistenceInfo instance.
		/// </summary>
		/// <param name="entity">Entity instance to return the IFieldPersistenceInfo objects for.</param>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		public IFieldPersistenceInfo[] GetAllFieldPersistenceInfos( IEntity2 entity )
		{
			return GetAllFieldPersistenceInfos( entity.LLBLGenProEntityName );
		}


		/// <summary>
		/// Retrieves for the field with name fieldName of entity / typed view with the name passed in the corresonding IFieldPersistenceInfo instance.
		/// </summary>
		/// <param name="elementName">Name of the entity / typed view the field belongs to. Example: CustomerEntity</param>
		/// <param name="fieldName">Name of the field which fieldpersistenceinfo should be returned. Example: CustomerID</param>
		/// <returns>Requested IFieldPersistenceInfo object</returns>
		public IFieldPersistenceInfo GetFieldPersistenceInfo( string elementName, string fieldName )
		{
			if( (elementName.Length<=0 ) || (fieldName.Length<=0 ) )
			{
				return null;
			}

			ElementToTargetMapping mapping = GetElementMappingInfo( elementName );
			if( !mapping.ElementFieldMappings.ContainsKey( fieldName ) )
			{
				throw new ArgumentException( "The field name '" + fieldName + "' isn't known in the element '" + elementName + "'", "fieldName" );
			}

			return (IFieldPersistenceInfo)mapping.ElementFieldMappings[fieldName];
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		protected void InitClass(int capacity)
		{
			_elementMappings = new Hashtable( capacity );
		}


		/// <summary>
		/// Adds an element mapping.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="catalogName">Name of the catalog.</param>
		/// <param name="schemaName">Name of the schema.</param>
		/// <param name="targetName">Name of the target.</param>
		/// <param name="numberOfFields">The number of fields.</param>
		protected void AddElementMapping( string elementName, string catalogName, string schemaName, string targetName, int numberOfFields)
		{
			if(_elementMappings.ContainsKey(elementName))
			{
				throw new ArgumentException("elementName '" + elementName + "' is already added to this provider.", "elementName");
			}

			_elementMappings.Add( elementName, new ElementToTargetMapping( catalogName, schemaName, targetName, numberOfFields ) );
		}


		/// <summary>
		/// Adds an element field mapping for the element name.elementfieldname field.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldName">Name of the element field.</param>
		/// <param name="sourceColumnName">Name of the source column.</param>
		/// <param name="isSourceColumnNullable">if set to <c>true</c> [is source column nullable].</param>
		/// <param name="sourceColumnDbType">Type of the source column db.</param>
		/// <param name="sourceColumnMaxLength">Length of the source column max.</param>
		/// <param name="sourceColumnScale">The source column scale.</param>
		/// <param name="sourceColumnPrecision">The source column precision.</param>
		/// <param name="isIdentity">if set to <c>true</c> [is identity].</param>
		/// <param name="identityValueSequenceName">Name of the identity value sequence.</param>
		/// <param name="typeConverterToUse">The type converter to use.</param>
		/// <param name="actualDotNetType">Type of the actual dot net.</param>
		/// <param name="fieldIndex">Index of the field.</param>
		protected void AddElementFieldMapping( string elementName, string elementFieldName, string sourceColumnName,
			bool isSourceColumnNullable, int sourceColumnDbType, int sourceColumnMaxLength, byte sourceColumnScale, byte sourceColumnPrecision,
			bool isIdentity, string identityValueSequenceName, TypeConverter typeConverterToUse, Type actualDotNetType, int fieldIndex)
		{
			ElementToTargetMapping mapping = GetElementMappingInfo( elementName );
			if( mapping.ElementFieldMappings.ContainsKey( elementFieldName ) )
			{
				throw new ArgumentException( "elementFieldName '" + elementFieldName + "' is already added to the mappings of element '" + elementName + "'", "elementFieldName" );
			}
			FieldPersistenceInfo persistenceInfo = new FieldPersistenceInfo( mapping.CatalogName, mapping.SchemaName, mapping.TargetName,
				sourceColumnName, isSourceColumnNullable, sourceColumnDbType, sourceColumnMaxLength, sourceColumnScale, sourceColumnPrecision, isIdentity,
				identityValueSequenceName, typeConverterToUse, actualDotNetType );

			// Add the field mapping to the mapping store of the element.
			mapping.ElementFieldMappings.Add( elementFieldName, persistenceInfo );
			mapping.ElementFieldMappingsOnIndex.Add( fieldIndex, persistenceInfo );
		}


		/// <summary>
		/// Gets the element mapping info.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		private ElementToTargetMapping GetElementMappingInfo( string elementName )
		{
			if( !_elementMappings.ContainsKey( elementName ) )
			{
				throw new ArgumentException( "The element name '" + elementName + "' isn't known in this provider", "elementName" );
			}
			return (ElementToTargetMapping)_elementMappings[elementName];
		}
	}
}
