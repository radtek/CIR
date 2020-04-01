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
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for the FieldInfoProvider class which is used by generated code to provide IFieldInfo objects and nametoindex dictionaries for 
	/// EntityFields(2) objects. 
	/// </summary>
	public abstract class FieldInfoProviderBase : IFieldInfoProvider
	{
		#region Class Member Declarations
		private Dictionary<string, ElementFields>	_elementFieldInfos;
		#endregion

		#region Private class declarations
		/// <summary>
		/// private class which is used to store mapping info of an element.
		/// </summary>
		private class ElementFields
		{
			#region Class Member Declarations
			private Dictionary<string, IFieldInfo>	_elementFields;
			private SortedList<int, IFieldInfo>		_elementFieldsOnIndex;
			private Dictionary<string, int>			_elementFieldIndexes;
			private IFieldInfo[]					_fieldInfos;
			private ListDictionary					_entityNamesOfFields;
			private List<int>						_pkFieldIndices;
			private List<int>						_overridenFieldIndices;		// indices of fields which should get their aliases fixed.
			#endregion


			/// <summary>
			/// Initializes a new instance of the <see cref="ElementFields"/> class.
			/// </summary>
			internal ElementFields()
			{
				_elementFields = new Dictionary<string, IFieldInfo>();
				_elementFieldsOnIndex = new SortedList<int, IFieldInfo>();
				_elementFieldIndexes = new Dictionary<string, int>();
				_fieldInfos = null;
				_entityNamesOfFields = new ListDictionary();
				_pkFieldIndices = new List<int>();
				_overridenFieldIndices = new List<int>();
			}


			/// <summary>
			/// Creates internal structures from the information added to this class.
			/// </summary>
			internal void PostProcessInfo()
			{
				_fieldInfos = new IFieldInfo[_elementFieldsOnIndex.Count];
				_elementFieldsOnIndex.Values.CopyTo(_fieldInfos, 0);

				foreach(IFieldInfo fieldInfo in _fieldInfos)
				{
					_entityNamesOfFields[fieldInfo.ContainingObjectName] = null;
				}

				for(int i = 0; i < _fieldInfos.Length; i++)
				{
					IFieldInfo fieldInfo = _fieldInfos[i];
					if(fieldInfo.IsPrimaryKey)
					{
						_pkFieldIndices.Add(i);
					}
					int indexUsingAlias = 0;
					_elementFieldIndexes.TryGetValue(fieldInfo.Name, out indexUsingAlias);
					if(indexUsingAlias != i)
					{
						// needs its alias corrected
						_overridenFieldIndices.Add(i);
					}
				}
			}


			#region Class Property Declarations
			/// <summary>
			/// Gets the overriden field indices.
			/// </summary>
			/// <value>The overriden field indices.</value>
			internal List<int> OverridenFieldIndices
			{
				get { return _overridenFieldIndices; }
			}

			/// <summary>
			/// Gets the pk field indices.
			/// </summary>
			/// <value>The pk field indices.</value>
			internal List<int> PkFieldIndices
			{
				get { return _pkFieldIndices; }
			}

			/// <summary>
			/// Gets the entity names of fields.
			/// </summary>
			/// <value>The entity names of fields.</value>
			internal ListDictionary EntityNamesOfFields
			{
				get { return _entityNamesOfFields; }
			}

			/// <summary>
			/// Gets the element field infos.
			/// </summary>
			internal Dictionary<string, IFieldInfo> ElementFieldInfos
			{
				get { return _elementFields; }
			}

			/// <summary>
			/// Gets the indexes of the element field infos of this element.
			/// </summary>
			internal SortedList<int, IFieldInfo> ElementFieldsOnIndex
			{
				get { return _elementFieldsOnIndex; }
			}

			/// <summary>
			/// Gets the element field indexes.
			/// </summary>
			/// <value>The element field indexes.</value>
			internal Dictionary<string, int> ElementFieldIndexes
			{
				get { return _elementFieldIndexes; }
			}

			/// <summary>
			/// Gets the field infos.
			/// </summary>
			/// <value>The field infos.</value>
			internal IFieldInfo[] FieldInfos
			{
				get { return _fieldInfos; }
			}

			#endregion
		}
		#endregion


		/// <summary>
		/// Gets the field info for the field passed in for the element passed in
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldName">Name of the element field.</param>
		/// <returns></returns>
		public IFieldInfo GetFieldInfo( string elementName, string elementFieldName )
		{
			ElementFields fields = GetElementFieldInfos( elementName );
			if( fields == null )
			{
				return null;
			}
			IFieldInfo toReturn = null;
			if( !fields.ElementFieldInfos.TryGetValue( elementFieldName, out toReturn ) )
			{
				// unknown field
				throw new ArgumentException(string.Format("The field '{0}' isn't known in the element '{1}'", elementFieldName, elementName), "elementFieldName");
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the field info for the field passed in for the element passed in
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldIndex">Index of the element field.</param>
		/// <returns></returns>
		public IFieldInfo GetFieldInfo(string elementName, int elementFieldIndex)
		{
			ElementFields fields = GetElementFieldInfos(elementName);
			if(fields == null)
			{
				return null;
			}
			IFieldInfo toReturn = null;
			if(!fields.ElementFieldsOnIndex.TryGetValue(elementFieldIndex, out toReturn))
			{
				// unknown field
				throw new ArgumentException(string.Format("The fieldindex '{0}' isn't known in the element '{1}'", elementFieldIndex, elementName), "elementFieldIndex");
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the field infos for the element passed in.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		public IFieldInfo[] GetFieldInfos( string elementName )
		{
			ElementFields fields = GetElementFieldInfos( elementName );
			if( fields == null )
			{
				return null;
			}
			return fields.FieldInfos;
		}


		/// <summary>
		/// Gets the field indexes object for the element passed in. This is an object which is used by EntityFields(2) objects to quickly find a field
		/// based on the field name.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		public Dictionary<string, int> GetFieldIndexes( string elementName )
		{
			ElementFields fields = GetElementFieldInfos( elementName );
			if( fields == null )
			{
				return null;
			}
			return fields.ElementFieldIndexes;
		}


		/// <summary>
		/// Fills the entity fields object for the adapter entity with the name specified.
		/// </summary>
		/// <param name="inheritanceProvider">The inheritance provider.</param>
		/// <param name="persistenceInfoProvider">The persistence info provider.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns></returns>
		/// <remarks>SelfServicing specific</remarks>
		public IEntityFields GetEntityFields(IInheritanceInfoProvider inheritanceProvider, IPersistenceInfoProvider persistenceInfoProvider, string entityName)
		{
			ElementFields fields = GetElementFieldInfos(entityName);
			if(fields == null)
			{
				return null;
			}
			IFieldInfo[] fieldInfos = GetFieldInfos(entityName);
			IEntityField[] fieldsArray = new IEntityField[fieldInfos.Length];
			List<IEntityField> pkFields = new List<IEntityField>();

			for(int i = 0; i < fieldInfos.Length; i++)
			{
				IFieldInfo fieldInfo = fieldInfos[i];
				fieldsArray[i] = new EntityField(fieldInfo, persistenceInfoProvider.GetFieldPersistenceInfo(fieldInfo.ContainingObjectName, fieldInfo.Name));
			}

			List<int> indicesToProcess = fields.PkFieldIndices;
			for(int i = 0; i < indicesToProcess.Count; i++)
			{
				pkFields.Add(fieldsArray[indicesToProcess[i]]);
			}

			indicesToProcess = fields.OverridenFieldIndices;
			for(int i = 0; i < indicesToProcess.Count; i++)
			{
				IEntityField field = fieldsArray[indicesToProcess[i]];
				field.Alias = string.Format("{0}_{1}", field.Alias, field.ContainingObjectName);
			}

			EntityFields toReturn = new EntityFields(fieldsArray, inheritanceProvider, GetFieldIndexes(entityName), pkFields, fields.EntityNamesOfFields);
			toReturn.LinkFields();

			return toReturn;
		}


		/// <summary>
		/// Fills the entity fields object for the adapter entity with the name specified.
		/// </summary>
		/// <param name="inheritanceProvider">The inheritance provider.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <remarks>Adapter specific</remarks>
		public IEntityFields2 GetEntityFields(IInheritanceInfoProvider inheritanceProvider, string entityName)
		{
			ElementFields fields = GetElementFieldInfos(entityName);
			if(fields == null)
			{
				return null;
			}
			IFieldInfo[] fieldInfos = GetFieldInfos(entityName);
			IEntityField2[] fieldsArray = new IEntityField2[fieldInfos.Length];
			List<IEntityField2> pkFields = new List<IEntityField2>();

			for(int i = 0; i < fieldInfos.Length; i++)
			{
				fieldsArray[i] = new EntityField2(fieldInfos[i]);
			}

			List<int> indicesToProcess = fields.PkFieldIndices;
			for(int i = 0; i < indicesToProcess.Count; i++)
			{
				pkFields.Add(fieldsArray[indicesToProcess[i]]);
			}

			indicesToProcess = fields.OverridenFieldIndices;
			for(int i = 0; i < indicesToProcess.Count; i++)
			{
				IEntityField2 field = fieldsArray[indicesToProcess[i]];
				field.Alias = string.Format("{0}_{1}", field.Alias, field.ContainingObjectName);
			}

			EntityFields2 toReturn = new EntityFields2(fieldsArray, inheritanceProvider, GetFieldIndexes(entityName), pkFields, fields.EntityNamesOfFields);
			toReturn.LinkFields();

			return toReturn;
		}

		
		/// <summary>
		/// Gets the entity fields array.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns>array of the fields which solely belong to the entity specified so no inherited fields are present.</returns>
		/// <remarks>Adapter specific.</remarks>
		public IEntityFieldCore[] GetEntityFieldsArray(string entityName)
		{
			ElementFields fields = GetElementFieldInfos(entityName);
			if(fields == null)
			{
				return null;
			}
			if(fields.ElementFieldInfos.Count <= 0)
			{
				return null;
			}

			IEntityFieldCore[] toReturn = new IEntityFieldCore[fields.ElementFieldInfos.Count];

			// simply select the last set of size toReturn.Length of fields from elementFieldsOnIndex, as these are the fields of the entityName entity
			for(int i = 0; i < toReturn.Length; i++)
			{
				toReturn[i] = new EntityField2(fields.ElementFieldsOnIndex[(fields.ElementFieldsOnIndex.Count - fields.ElementFieldInfos.Count) + i]);
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the entity fields array.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="persistenceProvider">The persistence provider.</param>
		/// <returns>
		/// array of the fields which solely belong to the entity specified so no inherited fields are present.
		/// </returns>
		/// <remarks>selfservicing specific.</remarks>
		public IEntityFieldCore[] GetEntityFieldsArray(string entityName, IPersistenceInfoProvider persistenceProvider)
		{
			ElementFields fields = GetElementFieldInfos(entityName);
			if(fields == null)
			{
				return null;
			}
			if(fields.ElementFieldInfos.Count <= 0)
			{
				return null;
			}

			IEntityFieldCore[] toReturn = new IEntityFieldCore[fields.ElementFieldInfos.Count];

			// simply select the last set of size toReturn.Length of fields from elementFieldsOnIndex, as these are the fields of the entityName entity
			for(int i = 0; i < toReturn.Length; i++)
			{
				IFieldInfo fieldInfo = fields.ElementFieldsOnIndex[(fields.ElementFieldsOnIndex.Count - fields.ElementFieldInfos.Count) + i];
				toReturn[i] = new EntityField(fieldInfo, persistenceProvider.GetFieldPersistenceInfo(fieldInfo.ContainingObjectName, fieldInfo.Name));
			}
			return toReturn;
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		protected void InitClass(int capacity)
		{
			_elementFieldInfos = new Dictionary<string, ElementFields>( capacity );
		}


		/// <summary>
		/// Constructs the element field objects, which are used by EntityFields(2) object to find back an entity field based on the name and also for
		/// creating fields. This routine utilizes the inheritance info provider to understand the full fields list of an entity (if applicable).
		/// </summary>
		/// <param name="inheritanceInfoProvider">The inheritance info provider.</param>
		protected void ConstructElementFieldStructures(IInheritanceInfoProvider inheritanceInfoProvider)
		{
			List<string> entityNamesToProcess = new List<string>(_elementFieldInfos.Keys);
			// add all names which are in a hierarchy but not in this provider. These names represent subtypes which don't have own fields. 
			List<string> entitiesInInheritanceHierarchies = inheritanceInfoProvider.GetAllEntityNamesInProvider();
			foreach(string name in entitiesInInheritanceHierarchies)
			{
				if(!_elementFieldInfos.ContainsKey(name))
				{
					entityNamesToProcess.Add(name);
					_elementFieldInfos.Add(name, new ElementFields());
				}
			}

			Hashtable namesProcessed = new Hashtable();
			foreach(string elementName in entityNamesToProcess)
			{
				if(namesProcessed.ContainsKey(elementName))
				{
					continue;
				}

				ElementFields fieldInfos = ProcessEntityFields(inheritanceInfoProvider, namesProcessed, elementName);
			}

			foreach(string elementName in entityNamesToProcess)
			{
				ElementFields fieldInfos = GetElementFieldInfos(elementName);
				if(fieldInfos == null)
				{
					continue;
				}
				fieldInfos.PostProcessInfo();
			}
		}


		/// <summary>
		/// Processes the element fields for the element with the name elementName. This processing is necessary because entities in an inheritance hierarchy
		/// inherit fields from their supertype and these aren't in the fieldsinfo yet. This process routine makes sure that's done. 
		/// </summary>
		/// <param name="inheritanceInfoProvider">The inheritance info provider.</param>
		/// <param name="namesProcessed">The names processed.</param>
		/// <param name="elementName">Name of the element.</param>
		/// <returns>the fieldsinfo for the element with elementName specified.</returns>
		private ElementFields ProcessEntityFields(IInheritanceInfoProvider inheritanceInfoProvider, Hashtable namesProcessed, string elementName)
		{
			ElementFields fieldInfos = GetElementFieldInfos(elementName);
			if(namesProcessed.ContainsKey(elementName))
			{
				return fieldInfos;
			}

			InheritanceHierarchyType hierarchyType = inheritanceInfoProvider.GetHierarchyType(elementName);
			if(hierarchyType == InheritanceHierarchyType.None)
			{
				// not in a hierarchy, skip, as all fields are already added to the entity.
				namesProcessed.Add(elementName, null);
				return fieldInfos;
			}

			List<string> entityNamesOnHierarchyPath = ((InheritanceInfoProviderBase)inheritanceInfoProvider).GetEntityNamesOnHierarchyPath(elementName);

			if(entityNamesOnHierarchyPath != null)
			{
				// in a hierarchy. Process. Start with the root and work ourselves downwards
				int fieldIndex = 0;
				if(entityNamesOnHierarchyPath.Count<=1)
				{
					// current entity is root. 
					foreach(KeyValuePair<int, IFieldInfo> entry in fieldInfos.ElementFieldsOnIndex)
					{
						// only set IsInMultiTargetEntity flag
						((FieldInfo)entry.Value).SetIsInMultiTargetEntity(hierarchyType == InheritanceHierarchyType.TargetPerEntity);
					}
				}
				else
				{
					for(int i = 0; i < entityNamesOnHierarchyPath.Count; i++)
					{
						string elementOnPathName = entityNamesOnHierarchyPath[i];
						if((elementName!=elementOnPathName) && !namesProcessed.ContainsKey(elementOnPathName))
						{
							// first process this entity
							ProcessEntityFields(inheritanceInfoProvider, namesProcessed, elementOnPathName);
						}

						ElementFields fieldInfosOfElement = GetElementFieldInfos(elementOnPathName);
						string fieldNameToUse = string.Empty;
						foreach(KeyValuePair<int, IFieldInfo> entry in fieldInfosOfElement.ElementFieldsOnIndex)
						{
							if(entry.Value.ContainingObjectName != elementOnPathName)
							{
								// inherited field, already processed when we processed supertype
								continue;
							}

							if(elementOnPathName == elementName)
							{
								// only set IsInMultiTargetEntity flag
								((FieldInfo)entry.Value).SetIsInMultiTargetEntity(hierarchyType == InheritanceHierarchyType.TargetPerEntity);
							}
							else
							{
								fieldNameToUse = entry.Value.Name;
								if(hierarchyType == InheritanceHierarchyType.TargetPerEntity)
								{
									if(fieldInfos.ElementFieldInfos.ContainsKey(entry.Value.Name))
									{
										// field is overriden in the current element. Append suffix for field indexes. 
										fieldNameToUse = String.Format("{0}_{1}", entry.Value.Name, elementOnPathName);
									}
									else
									{
										fieldNameToUse = entry.Value.Name;
									}
									if(fieldInfos.ElementFieldIndexes.ContainsKey(fieldNameToUse))
									{
										// correct name
										fieldNameToUse = string.Format("{0}_{1}", entry.Value.Name, elementOnPathName);
									}
								}
								// now store this field name with the current field index.
								fieldInfos.ElementFieldIndexes.Add(fieldNameToUse, fieldIndex);
								// create a clone of the fieldinfo object in entry.Value and add to that clone the info of the actualcontaining object name and the 
								// fact if the field is part of an entity which is multi-target.
								IFieldInfo clone = ((FieldInfo)entry.Value).CreateClone(elementName, (hierarchyType == InheritanceHierarchyType.TargetPerEntity));
								fieldInfos.ElementFieldsOnIndex.Add(fieldIndex, clone);
								fieldIndex++;
							}
						}
					}
				}
			}
			namesProcessed.Add(elementName, null);
			return fieldInfos;
		}


		/// <summary>
		/// Adds an element field info object for the element name.elementfieldname field.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldName">Name of the element field.</param>
		/// <param name="dataType">Type of the data.</param>
		/// <param name="isPrimaryKey">if set to <c>true</c> [is primary key].</param>
		/// <param name="isForeignKey">if set to <c>true</c> [is foreign key].</param>
		/// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
		/// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
		/// <param name="fieldIndex">Index of the field.</param>
		/// <param name="maxLength">Length of the max.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="precision">The precision.</param>
		protected void AddElementFieldInfo( string elementName, string elementFieldName, Type dataType, bool isPrimaryKey, bool isForeignKey, bool isReadOnly, 
			bool isNullable, int fieldIndex, int maxLength, byte scale, byte precision )
		{
			ElementFields fieldInfos = null;
			if( !_elementFieldInfos.TryGetValue( elementName, out fieldInfos ) )
			{
				// not yet known here. create it.
				fieldInfos = new ElementFields();
				_elementFieldInfos.Add( elementName, fieldInfos );
			}

			if( fieldInfos.ElementFieldInfos.ContainsKey( elementFieldName ) )
			{
				throw new ArgumentException( "elementFieldName '" + elementFieldName + "' is already added to the fields of element '" + elementName + "'", "elementFieldName" );
			}
			FieldInfo info = new FieldInfo( elementFieldName, elementName, dataType, isPrimaryKey, isForeignKey, isReadOnly, isNullable, fieldIndex, maxLength, scale,
					precision );

			// Add the field mapping to the mapping store of the element.
			fieldInfos.ElementFieldInfos.Add( elementFieldName, info );
			fieldInfos.ElementFieldsOnIndex.Add( fieldIndex, info);
			fieldInfos.ElementFieldIndexes.Add(elementFieldName, fieldIndex);
		}


		/// <summary>
		/// Gets the element field infos for a given element.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		private ElementFields GetElementFieldInfos( string elementName )
		{
			ElementFields toReturn = null;
			_elementFieldInfos.TryGetValue( elementName, out toReturn );
			return toReturn;
		}
	}
}
