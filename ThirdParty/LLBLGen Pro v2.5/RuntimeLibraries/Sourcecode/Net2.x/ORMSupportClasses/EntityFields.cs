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
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Specialized;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which forms the EntityFields2 type. An EntityFields type is a collection of IEntityField objects which forms the total amount of fields 
	/// for a given entity.
	/// SelfServicing specific
	/// </summary>
	[Serializable]
	public class EntityFields : IEntityFields, IEnumerable
	{
		#region Class Member Declarations
		private IEntityField[]					_entityFields;					// the basic store for the entity fields
		private List<IEntityField>				_primaryKeyFields;				// the list of primary key entity field references.
		private bool							_isDirty, _wasDirtyWhenEditStarted, _isChangedInThisEditCycle;
		private EntityState						_state;

		[NonSerialized]
		private Dictionary<string, int>			_entityFieldIndexes;			// the indexes for the fields to find them by name.
		[NonSerialized]
		private IInheritanceInfoProvider		_inheritanceInfoProviderToUse;	// used for datatable oriented fetches.
		[NonSerialized]
		private bool _entityFieldIndexesIsLocalCopy;	// flag to signal if _entityFieldIndexes object is created locally (true) or a shared global instance.
		[NonSerialized]
		private ListDictionary _entityNamesOfFields;		// list of entity names 
		[NonSerialized]
		private bool _entityNamesOfFieldsIsLocalCopy;	// flag to signal if _entityNamesOfFields object is created locally (true) or a shared global instance.
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="amount">The initial amount of fields in this EntityFields collection</param>
		public EntityFields(int amount):this(amount, null, null)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="amount">The initial amount of fields in this EntityFields collection</param>
		/// <param name="inheritanceInfoProviderToUse">Inheritance info provider to use.</param>
		/// <param name="entityFieldIndexes">The entity field indexes.</param>
		public EntityFields(int amount, IInheritanceInfoProvider inheritanceInfoProviderToUse, Dictionary<string, int> entityFieldIndexes)
		{
			_entityFieldIndexes = entityFieldIndexes;
			_entityFieldIndexesIsLocalCopy = (entityFieldIndexes == null);
			if( _entityFieldIndexes == null )
			{
				_entityFieldIndexes = new Dictionary<string, int>();
			}

			_entityFields = new EntityField[amount];
			_entityNamesOfFields = new ListDictionary();
			_entityNamesOfFieldsIsLocalCopy = true;
			_primaryKeyFields = new List<IEntityField>();
			_state = EntityState.New;
			_inheritanceInfoProviderToUse = inheritanceInfoProviderToUse;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityFields"/> class.
		/// </summary>
		/// <param name="fields">Fields to initialize this object with.</param>
		/// <param name="entityFieldIndexes">The entity field indexes.</param>
		/// <remarks>Called from entity factory which call originates from InheritanceInfoProvider</remarks>
		public EntityFields(IEntityFieldCore[] fields, Dictionary<string, int> entityFieldIndexes):this(fields, null, entityFieldIndexes)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityFields"/> class.
		/// </summary>
		/// <param name="fields">Fields to initialize this object with.</param>
		/// <param name="inheritanceInfoProviderToUse">Inheritance info provider to use.</param>
		/// <param name="entityFieldIndexes">The entity field indexes.</param>
		/// <remarks>Called from entity factory which call originates from InheritanceInfoProvider</remarks>
		public EntityFields( IEntityFieldCore[] fields, IInheritanceInfoProvider inheritanceInfoProviderToUse, Dictionary<string, int> entityFieldIndexes )
		{
			_entityFieldIndexes = entityFieldIndexes;
			_entityFieldIndexesIsLocalCopy = (entityFieldIndexes == null);
			if( _entityFieldIndexes == null )
			{
				_entityFieldIndexes = new Dictionary<string, int>();
			}

			_entityFields = new EntityField[fields.Length];
			_entityNamesOfFields = new ListDictionary();
			_entityNamesOfFieldsIsLocalCopy = true;
			_primaryKeyFields = new List<IEntityField>();
			_state = EntityState.New;
			for (int i = 0; i < fields.Length; i++)
			{
				this[i] = (EntityField)fields[i];
				_entityNamesOfFields[fields[i].ContainingObjectName] = null;
			}
			_inheritanceInfoProviderToUse = inheritanceInfoProviderToUse;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityFields"/> class.
		/// </summary>
		/// <param name="fields">The fields to use for this instance.</param>
		/// <param name="inheritanceInfoProviderToUse">The inheritance info provider to use.</param>
		/// <param name="entityFieldIndexes">The entity field indexes.</param>
		/// <param name="pkFields">The pk fields. Fields in this set have to be present in fields as well.</param>
		/// <param name="entityNamesOfFields">The entity names of fields.</param>
		/// <remarks>Used internally to quickly create fields objects</remarks>
		internal EntityFields(IEntityField[] fields, IInheritanceInfoProvider inheritanceInfoProviderToUse, Dictionary<string, int> entityFieldIndexes,
			List<IEntityField> pkFields, ListDictionary entityNamesOfFields)
		{
			_entityFieldIndexes = entityFieldIndexes;
			_entityFieldIndexesIsLocalCopy = (entityFieldIndexes == null);
			if(_entityFieldIndexes == null)
			{
				_entityFieldIndexes = new Dictionary<string, int>();
			}

			_entityFields = fields;
			_primaryKeyFields = pkFields;
			_state = EntityState.New;
			_entityNamesOfFields = entityNamesOfFields;
			_inheritanceInfoProviderToUse = inheritanceInfoProviderToUse;
		}



		/// <summary>
		/// Converts the fields in the instance passed in to a new list of IEntityPropertyProjector instances which is ready to be used in a projection
		/// </summary>
		/// <param name="toConvert">To convert.</param>
		/// <returns>
		/// new list of IEntityPropertyProjector instances which is ready to be used in a projection
		/// </returns>
		public static List<IEntityPropertyProjector> ConvertToProjectors(IEntityFields toConvert)
		{
			Dictionary<string, object> nameHashes = new Dictionary<string, object>();
			List<IEntityPropertyProjector> toReturn = new List<IEntityPropertyProjector>();
			for(int i = toConvert.Count - 1; i >= 0; i--)
			{
				IEntityField field = toConvert[i];
				if(nameHashes.ContainsKey(field.Name))
				{
					continue;
				}
				toReturn.Add(new EntityPropertyProjector(field, field.Name));
				nameHashes.Add(field.Name, field);
			}
			return toReturn;
		}


		/// <summary>
		/// Expands this entity fields object by appending numberOfCells new cells to this object. 
		/// </summary>
		/// <param name="numberOfNewCells">number of cells to append to this fieldsobject</param>
		/// <remarks>Use with care. Empty cells can cause the DQE's to produce undefined results. Use this routine to append fields to a
		/// Typed list in code for example. </remarks>
		public void Expand(int numberOfNewCells)
		{
#if CF
			IEntityField[] newFieldsInstance = new EntityField[_entityFields.Length + numberOfNewCells];
			_entityFields.CopyTo(newFieldsInstance, 0);
			_entityFields = newFieldsInstance;
#else
			Array.Resize<IEntityField>(ref _entityFields, _entityFields.Length + numberOfNewCells);
#endif
			CreateEntityFieldIndexesLocalCopy();
		}

	

		/// <summary>
		/// Contracts the list of fields so all empty slots at the end of the list of fields are removed. Doesn't perform a contract operation if the
		/// fields object is empty
		/// </summary>
		/// <returns>the new size of the fields object, or if the fields object is completely empty, the full size</returns>
		public int Contract()
		{
			int indexOfFirstNonEmptySlot = -1;
			for(indexOfFirstNonEmptySlot = _entityFields.Length-1;(indexOfFirstNonEmptySlot>=0) && (_entityFields[indexOfFirstNonEmptySlot]==null);indexOfFirstNonEmptySlot--)
			{
				// empty
			}

			// indexOfFirstNonEmptySlot or points to the first nonempty slot or is -1, which means the complete array is empty.
			if(indexOfFirstNonEmptySlot<0)
			{
				return _entityFields.Length;
			}

			IEntityField[] newFieldsInstance = new IEntityField[indexOfFirstNonEmptySlot+1];
			for(int i=0;i<=indexOfFirstNonEmptySlot;i++)
			{
				newFieldsInstance[i] = _entityFields[i];
			}
			_entityFields = newFieldsInstance;

			return _entityFields.Length;
		}


		/// <summary>
		/// Compacts the list of fields so all empty slots are removed. 
		/// </summary>
		public void Compact()
		{
			List<IEntityField> fields = new List<IEntityField>();
			for(int i = 0; i < this.Count; i++)
			{
				if(this[i] == null)
				{
					continue;
				}
				fields.Add(this[i]);
			}

			if(fields.Count == this.Count)
			{
				// nothing changed
				return;
			}
			_entityFields = fields.ToArray();
		}


		/// <summary>
		/// Gets the enumerator for this object.
		/// </summary>
		/// <returns>an IEnumerator to use in for each loops over this fields collection</returns>
		public IEnumerator GetEnumerator()
		{
			return _entityFields.GetEnumerator();
		}


		/// <summary>
		/// Overrides the GetHashCode routine. It will calculate a hashcode for this set of entity fields using the eXclusive OR of the 
		/// hashcodes of the primary key fields in this set of entity fields. That hashcode is returned. If no primary key fields are present,
		/// the hashcode of the base class is returned, which will not be unique.
		/// </summary>
		/// <returns>Hashcode for this entity object, based on its primary key field values</returns>
		public override int GetHashCode()
		{
			if(_primaryKeyFields.Count<=0)
			{
				return base.GetHashCode();
			}

			int hashToReturn = _primaryKeyFields[0].GetHashCode();

			// calculate hash value
			for(int i=1;i<_primaryKeyFields.Count;i++)
			{
				IEntityField field = _primaryKeyFields[i];
				if(field.LinkedSuperTypeField!=null)
				{
					// subtype PK field, done.
					break;
				}

				hashToReturn ^= field.GetHashCode();
			}

			return hashToReturn;
		}


		/// <summary>
		/// Compares passed in object with the given object. This is a compare of PK fields. These have to be the same in VALUES. 
		/// When the values are not the same, or the type is not the same as the current type, false is returned, true otherwise.
		/// When this doesn't have any PK fields, all fields are compared. null values are considered as the same value. 
		/// </summary>
		/// <param name="obj">EntityFields object of the same type as this which will be compared to the PK values of this. </param>
		/// <returns>True when the PK values of this are the same as the PK values of obj, or when this doesn't have any PK fields, all fields
		/// have the same value as obj's fields. False otherwise.</returns>
		public override bool Equals(object obj)
		{
			EntityFields passedIn = obj as EntityFields;
			if(passedIn==null)
			{
				// not equal
				return false;
			}

			if((this.Count!=passedIn.Count)||(_primaryKeyFields.Count!=passedIn.PrimaryKeyFields.Count))
			{
				// not equal
				return false;
			}

			bool theSame=true;
			if(_primaryKeyFields.Count>0)
			{
				for (int i = 0; i < _primaryKeyFields.Count; i++)
				{
					IEntityField pkFieldThis = _primaryKeyFields[i];
					IEntityField pkFieldPassedIn = passedIn.PrimaryKeyFields[i];

					if(pkFieldThis.CurrentValue==null)
					{
						theSame &= (pkFieldPassedIn.CurrentValue==null);
					}
					else
					{
						theSame&=(pkFieldThis.CurrentValue.Equals( pkFieldPassedIn.CurrentValue) );
					}
					if(!theSame)
					{
						// already not the same. quit
						break;
					}
				}
			}
			else
			{
				// measure all fields
				for (int i = 0; i < _entityFields.Length; i++)
				{
					theSame&=(_entityFields[i].CurrentValue==passedIn[i].CurrentValue);
					if(!theSame)
					{
						// already not the same. quit
						break;
					}
				}
			}

			return theSame;
		}

		/// <summary>
		/// Links the specified fields with eachother so setting one to a different value will automatically set the other one as well.
		/// This is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		/// <param name="superTypeFieldIndex">index of field in the supertype</param>
		/// <param name="subTypeFieldIndex">index of field in the subtype</param>
		public void LinkFields(int superTypeFieldIndex, int subTypeFieldIndex)
		{
			if((superTypeFieldIndex<0)||(superTypeFieldIndex>=_entityFields.Length))
			{
				// index exceeded
				throw new ArgumentException("superTypeFieldIndex is out of range of the number of fields: " + superTypeFieldIndex + " with " + _entityFields.Length + " fields in this object.", "superTypeFieldIndex");
			}
			if((subTypeFieldIndex<0)||(subTypeFieldIndex>=_entityFields.Length))
			{
				// index exceeded
				throw new ArgumentException("subTypeFieldIndex is out of range of the number of fields: " + subTypeFieldIndex + " with " + _entityFields.Length + " fields in this object.", "subTypeFieldIndex");
			}
			IEntityField superTypeField = _entityFields[superTypeFieldIndex];
			IEntityField subTypeField = _entityFields[subTypeFieldIndex];

			((EntityField)superTypeField).LinkedSubTypeFields.Add(subTypeField);
			subTypeField.LinkedSuperTypeField = superTypeField;
		}


		/// <summary>
		/// Links the supertype PK fields with the subtype PK fields IF there are PK fields of multiple entities in the set of PK fields.
		/// Linking is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		public void LinkFields()
		{
			int numberOfPkFields = FieldUtilities.DetermineNumberOfPkFields(_primaryKeyFields);
			if((numberOfPkFields==_primaryKeyFields.Count)||(numberOfPkFields==0))
			{
				// nothing to link
				return;
			}

			for(int i = 0; i < ((_primaryKeyFields.Count/numberOfPkFields)-1); i++)
			{
				for(int j = 0; j < numberOfPkFields; j++)
				{
					LinkFields(_primaryKeyFields[((i * numberOfPkFields) + j)].FieldIndex, _primaryKeyFields[(((i * numberOfPkFields) + numberOfPkFields) + j)].FieldIndex);
				}
			}
		}


		/// <summary>
		/// Converts this EntityFields object to a set of XmlNodes with all the fields as individual nodes.
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the nodes this method will create. This document is required
		/// to create the new nodes for the fields</param>
		/// <param name="parentNode">the node the fields will have to be added to.</param>
		public void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, XmlNode parentNode)
		{
			Hashtable namesProcessed = new Hashtable();
			for( int i = 0; i < _entityFields.Length; i++ )
			{
				IEntityField field = _entityFields[i];
				if( namesProcessed.ContainsKey( field.Name ) )
				{
					// already processed, overriden field.
					continue;
				}
				namesProcessed.Add( field.Name, null );
				XmlNode entityFieldNode = null;
				field.WriteXml(aspects, parentDocument, out entityFieldNode);
				parentNode.AppendChild(entityFieldNode);
			}
		}


		/// <summary>
		/// Reads the fields which are childnodes of the passed in fieldsElement into this object
		/// </summary>
		/// <param name="fieldsElement"></param>
		public void ReadXml(XmlNode fieldsElement)
		{
			XmlHelper typeConverter = new XmlHelper();
			XmlNodeList fieldNodes = fieldsElement.ChildNodes;

			XmlNamespaceManager nsmgr = null;
			string nsprefix = string.Empty;
			if(fieldsElement.NamespaceURI.Length>0)
			{
				// has namespace specified. As .NET has some nice XML bugs, we have to specify a 
				// namespace manager and a fake prefix.
				nsmgr = new XmlNamespaceManager(fieldsElement.OwnerDocument.NameTable);
				if(fieldsElement.Prefix.Length<=0)
				{
					// use fake ns
					nsprefix = "fields";
				}
				else
				{
					nsprefix = fieldsElement.Prefix;
				}
				nsmgr.AddNamespace(nsprefix, fieldsElement.NamespaceURI);
				nsprefix += ":";
			}

			for (int i = 0; i < fieldNodes.Count; i++)
			{
				EntityField currentField = (EntityField)this[fieldNodes[i].Name];

#if CF
				XmlNode currentValueNode = XmlCFUtilities.SelectSingleNode(fieldNodes[i], "CurrentValue");
#else
				XmlNode currentValueNode = fieldNodes[i].SelectSingleNode(nsprefix + "CurrentValue", nsmgr);
#endif
				string currentValueTypeName = string.Empty;
				if((currentValueNode.Attributes==null)||(currentValueNode.Attributes.GetNamedItem("Type")==null))
				{
					currentValueTypeName = currentField.DataType.UnderlyingSystemType.FullName.ToString();
				}
				else
				{
					currentValueTypeName = currentValueNode.Attributes["Type"].Value;
				}
				string currentValueAsString = currentValueNode.InnerText;
				if(currentValueTypeName!="Unknown")
				{
					currentField.ForcedCurrentValueWrite(typeConverter.XmlValueToObject(currentValueTypeName, currentValueAsString));
				}
				else
				{
					currentField.ForcedCurrentValueWrite(null);
				}

#if CF
				XmlNode dbValueNode = XmlCFUtilities.SelectSingleNode(fieldNodes[i], "DbValue");
#else
				XmlNode dbValueNode = fieldNodes[i].SelectSingleNode(nsprefix + "DbValue", nsmgr);
#endif
				string dbValueTypeName = string.Empty;
				if((dbValueNode.Attributes==null)||(dbValueNode.Attributes.GetNamedItem("Type")==null))
				{
					dbValueTypeName = currentField.DataType.UnderlyingSystemType.FullName.ToString();
				}
				else
				{
					dbValueTypeName = dbValueNode.Attributes["Type"].Value;
				}
				string dbValueAsString = dbValueNode.InnerText;
				if((dbValueTypeName!="Unknown")&&(dbValueAsString.Length>0))
				{
					currentField.SetDbValue(typeConverter.XmlValueToObject(dbValueTypeName, dbValueAsString));
				}
				else
				{
					currentField.SetDbValue(null);
				}
#if CF
				XmlNode isNullNode = XmlCFUtilities.SelectSingleNode(fieldNodes[i], "IsNull");
#else
				XmlNode isNullNode = fieldNodes[i].SelectSingleNode(nsprefix + "IsNull", nsmgr);
#endif

				currentField.IsNull = (bool)typeConverter.XmlValueToObject("System.Boolean", isNullNode.InnerText);

#if CF
				XmlNode isChangedNode = XmlCFUtilities.SelectSingleNode(fieldNodes[i], "IsChanged");
#else
				XmlNode isChangedNode = fieldNodes[i].SelectSingleNode(nsprefix + "IsChanged", nsmgr);
#endif
				currentField.ForcedChangedWrite((bool)typeConverter.XmlValueToObject("System.Boolean", isChangedNode.InnerText));
			}
		}


		/// <summary>
		/// Returns the complete list of IEntityField objects as an array of IFieldPersistenceInfo objects. IEntityField objects implement
		/// IFieldPersistenceInfo.
		/// </summary>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		public IFieldPersistenceInfo[] GetAsPersistenceInfoArray()
		{
			return _entityFields;
		}


		/// <summary>
		/// Returns the complete list of IEntityField objects as an array of IEntityFieldCore objects. IEntityField objects implement
		/// IEntityFieldCore
		/// </summary>
		/// <returns>Array of IEntityFieldCore objects</returns>
		public IEntityFieldCore[] GetAsEntityFieldCoreArray()
		{
			return _entityFields;
		}


		/// <summary>
		/// All changes to all <see cref="IEntityField"/> objects in this collection are accepted. 
		/// </summary>
		internal void AcceptChanges()
		{
			for(int i=0;i<_entityFields.Length;i++)
			{
				if(_entityFields[i]!=null)
				{
					((EntityField)_entityFields[i]).AcceptChange();
				}
			}

			_isDirty = false;
		}

		
		/// <summary>
		/// Per field, the last change made is rejected.
		/// </summary>
		internal void RejectChanges()
		{
			for(int i=0;i<_entityFields.Length;i++)
			{
				if(_entityFields[i]!=null)
				{
					((EntityField)_entityFields[i]).RejectChange();
				}
			}

			_isDirty = false;
		}


		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// A succesful edit has been performed. All new values have to be moved to the current value slots.
		/// </summary>
		public void EndEdit()
		{
			if( _isChangedInThisEditCycle )
			{
				for( int i = 0; i < _entityFields.Length; i++ )
				{
					_entityFields[i].EndEdit();
				}
				_isChangedInThisEditCycle = false;
			}
		}


		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// Doesn't reset isDirty. 
		/// </summary>
		public void CancelEdit()
		{
			if( _isChangedInThisEditCycle )
			{
				for( int i = 0; i < _entityFields.Length; i++ )
				{
					_entityFields[i].CancelEdit();
				}

				_isDirty = _wasDirtyWhenEditStarted;
			}
		}


		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// </summary>
		public void BeginEdit()
		{
			for( int i = 0; i < _entityFields.Length; i++ )
			{
				_entityFields[i].BeginEdit();
			}
			_wasDirtyWhenEditStarted = _isDirty;
			_isChangedInThisEditCycle = false;
		}


		/// <summary>
		/// Clones this instance and its contents using a deep copy.
		/// </summary>
		/// <returns>an exact, deep copy of this EntityFields object and its contents.</returns>
		public virtual EntityFields Clone()
		{
			EntityFields fieldsToReturn = (EntityFields)this.MemberwiseClone();
			fieldsToReturn.SetupCloning();
			// pass false for local copy, as it's a reference to an existing index set.
			fieldsToReturn.SetEntityFieldIndexes( _entityFieldIndexes, false );
			fieldsToReturn.SetEntityNamesOfFields(_entityNamesOfFields, false);

			Dictionary<IEntityField, IEntityField> oldNewLookup = new Dictionary<IEntityField, IEntityField>();
			for(int i=0;i<fieldsToReturn.Count;i++)
			{
				fieldsToReturn[i] = (EntityField)((EntityField)this[i]).Clone();
				oldNewLookup.Add(this[i], fieldsToReturn[i]);
			}

			// correct linked supertype/subtype fields.
			foreach(EntityField clonedField in fieldsToReturn)
			{
				if(clonedField.LinkedSuperTypeField != null)
				{
					// correct it
					IEntityField newLinkedField = null;
					if(oldNewLookup.TryGetValue((IEntityField)clonedField.LinkedSuperTypeField, out newLinkedField))
					{
						clonedField.LinkedSuperTypeField = newLinkedField;
					}
				}
				if(clonedField.LinkedSubTypeFields.Count > 0)
				{
					for(int i = 0; i < clonedField.LinkedSubTypeFields.Count; i++)
					{
						IEntityField newSubTypeField = null;
						if(oldNewLookup.TryGetValue(clonedField.LinkedSubTypeFields[i], out newSubTypeField))
						{
							clonedField.LinkedSubTypeFields[i] = newSubTypeField;
						}
					}
				}
			}

			return fieldsToReturn;
		}


		/// <summary>
		/// Creates a shallow copy of this instance, which means that a new EntityFields object is created but all membervariables are kept the same. 
		/// </summary>
		/// <returns>Shallow copy of this instance</returns>
		public EntityFields ShallowClone()
		{
			return (EntityFields)this.MemberwiseClone();
		}


		/// <summary>
		/// Clones this object to a new EntityFields object where all fields are changed and the object itself is marked dirty.
		/// </summary>
		/// <returns></returns>
		public virtual EntityFields CloneAsDirty()
		{
			EntityFields toReturn = (EntityFields)Clone();
			foreach( IEntityField field in toReturn )
			{
				field.IsChanged = true;
			}
			toReturn.IsDirty = true;

			return toReturn;
		}


		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields )
		{
			DefineField( fieldToAdd, indexInFields, fieldToAdd.Alias, fieldToAdd.ObjectAlias, fieldToAdd.AggregateFunctionToApply );
		}


		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields, string alias )
		{
			DefineField( fieldToAdd, indexInFields, alias, fieldToAdd.ObjectAlias, fieldToAdd.AggregateFunctionToApply );
		}


		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields, AggregateFunction aggregateFunctionToApply )
		{
			DefineField( fieldToAdd, indexInFields, fieldToAdd.Alias, fieldToAdd.ObjectAlias, aggregateFunctionToApply );
		}


		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, AggregateFunction aggregateFunctionToApply )
		{
			DefineField( fieldToAdd, indexInFields, alias, fieldToAdd.ObjectAlias, aggregateFunctionToApply );
		}


		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, string entityAlias )
		{
			DefineField( fieldToAdd, indexInFields, alias, entityAlias, fieldToAdd.AggregateFunctionToApply );
		}
		

		/// <summary>Adds the specified field on the position indexInFields in the resultset.</summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		public void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply )
		{
			fieldToAdd.Alias = alias;
			fieldToAdd.ObjectAlias = entityAlias;
			fieldToAdd.AggregateFunctionToApply = aggregateFunctionToApply;
			((EntityField)fieldToAdd).SetFieldIndex(indexInFields);
			this[indexInFields] = fieldToAdd;
		}


		/// <summary>
		/// Sets the entity field indexes after a clone operation.
		/// </summary>
		/// <param name="entityFieldIndexes">The entity field indexes.</param>
		/// <param name="entityFieldIndexesIsLocalCopy">if set to <c>true</c> [entity field indexes is local copy].</param>
		internal void SetEntityFieldIndexes( Dictionary<string, int> entityFieldIndexes, bool entityFieldIndexesIsLocalCopy )
		{
			_entityFieldIndexes = entityFieldIndexes;
			_entityFieldIndexesIsLocalCopy = entityFieldIndexesIsLocalCopy;
		}


		/// <summary>
		/// Sets the entity names of fields.
		/// </summary>
		/// <param name="entityNamesOfFields">The entity names of fields.</param>
		/// <param name="entityNamesOfFieldsIsLocalCopy">if set to <c>true</c> [entity names of fields is local copy].</param>
		internal void SetEntityNamesOfFields(ListDictionary entityNamesOfFields, bool entityNamesOfFieldsIsLocalCopy)
		{
			_entityNamesOfFields = entityNamesOfFields;
			_entityNamesOfFieldsIsLocalCopy = entityNamesOfFieldsIsLocalCopy;
		}

		
		/// <summary>
		/// Prepares this object to be filled with objects. It is called after the MemberwiseClone call and resets all references
		/// to objects and creates new objects or sets them to null. 
		/// </summary>
		internal void SetupCloning()
		{
			_primaryKeyFields = new List<IEntityField>(_primaryKeyFields.Count);
			_entityFields = new EntityField[_entityFields.Length];
			_entityNamesOfFields = new ListDictionary();
		}


		/// <summary>
		/// Gets the entity names of fields.
		/// </summary>
		/// <returns></returns>
		internal ICollection<string> GetEntityNamesOfFields()
		{
			if( _entityNamesOfFields == null )
			{
				_entityNamesOfFields = new ListDictionary();
				foreach( EntityField field in _entityFields )
				{
					_entityNamesOfFields[field.ContainingObjectName] = null;
				}
			}
			List<string> toReturn = new List<string>();
			foreach( string name in _entityNamesOfFields.Keys )
			{
				if(!string.IsNullOrEmpty(name))
				{
					toReturn.Add( name );
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Gets this object's fields field data in a 2 column array: first column currentvalue second column dbvalue
		/// </summary>
		/// <returns></returns>
		internal object[,] GetFieldsDataArray()
		{
			object[,] toReturn = new object[2, _entityFields.Length];
			for(int i = 0; i < _entityFields.Length; i++)
			{
				toReturn[0, i] = _entityFields[i].CurrentValue;
				toReturn[1, i] = _entityFields[i].DbValue;
			}

			return toReturn;
		}

		/// <summary>
		/// Gets this object's fields change tracking flags and other flags: it's a bitarray, single dimension with 2 bits per row: 
		/// first bit IsChanged, second bit: IsNull
		/// </summary>
		/// <returns></returns>
		internal BitArray GetFieldsTrackingFlagsArray()
		{
			BitArray toReturn = new BitArray(_entityFields.Length * 2);
			for(int i = 0; i < _entityFields.Length; i++)
			{
				toReturn[(i * 2)] = _entityFields[i].IsChanged;
				toReturn[(i * 2) + 1] = _entityFields[i].IsNull;
			}

			return toReturn;
		}

		/// <summary>
		/// Creates the entity field indexes local copy.
		/// </summary>
		private void CreateEntityFieldIndexesLocalCopy()
		{
			if( _entityFieldIndexesIsLocalCopy )
			{
				return;
			}

			Dictionary<string, int> localCopy = new Dictionary<string, int>( _entityFieldIndexes.Count );
			foreach( KeyValuePair<string, int> entry in _entityFieldIndexes )
			{
				localCopy.Add( entry.Key, entry.Value );
			}

			_entityFieldIndexesIsLocalCopy = true;
			_entityFieldIndexes = localCopy;
		}


		/// <summary>
		/// Creates the entity names of fields local copy.
		/// </summary>
		private void CreateEntityNamesOfFieldsLocalCopy()
		{
			if(_entityNamesOfFieldsIsLocalCopy)
			{
				return;
			}
			ListDictionary localCopy = new ListDictionary();
			foreach(DictionaryEntry entry in _entityNamesOfFields)
			{
				localCopy.Add(entry.Key, entry.Value);
			}
			_entityNamesOfFields = localCopy;
			_entityNamesOfFieldsIsLocalCopy = true;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets the inheritance info provider to use.
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		internal IInheritanceInfoProvider InheritanceInfoProviderToUse
		{
			get { return _inheritanceInfoProviderToUse;}
		}

		/// <summary>
		/// The amount of IEntityFields allocated in the EntityFields object.
		/// </summary>
		public int Count 
		{
			get {return _entityFields.Length;}
		}

		/// <summary>
		/// Gets the flag if the contents of the EntityFields object is 'dirty', which means that one or more fields are changed. 
		/// <see cref="AcceptChanges"/> and <see cref="RejectChanges"/> reset this flag.
		/// </summary>
		public bool IsDirty 
		{
			get {return _isDirty; } 
			set {_isDirty = value; }
		}


		/// <summary>
		/// List of EntityField references which form the primary key
		/// </summary>
		/// <value></value>
		public List<IEntityField> PrimaryKeyFields
		{
			get { return _primaryKeyFields; }
		}


		/// <summary>
		/// Gets / sets the EntityField on the specified Index. 
		/// </summary>
		/// <exception cref="System.IndexOutOfRangeException">When the index specified is not found in the internal datastorage.</exception>
		/// <exception cref="System.ArgumentNullException">When the passed in <see cref="IEntityField"/> is null</exception>
		/// <exception cref="System.ArgumentException">When the passed in <see cref="IEntityField"/> is already added. Fields have to be unique.</exception>
		public IEntityField this [int index] 
		{
			get
			{
				if((index < 0) || (index >= _entityFields.Length))
				{
					throw new IndexOutOfRangeException("The specified index is not in the range of known indexes");
				}

				return _entityFields[index];
			}

			set
			{
				if(index<0)
				{
					throw new IndexOutOfRangeException("The index on which the object should be placed cannot be smaller than 0.");
				}

				if(index >= _entityFields.Length)
				{
					throw new IndexOutOfRangeException("The index on which the object should be placed is outside the specified range of indexes.");
				}

				if(value==null)
				{
					throw new ArgumentNullException("Item", "Item cannot be null");
				}

				if( _entityFieldIndexesIsLocalCopy )
				{
					if( this[index] != null )
					{
						_entityFieldIndexes.Remove( this[index].Alias );
					}
					_entityFieldIndexes.Add( value.Alias, index );
				}
				_entityFields[index] = value;
				if(_entityNamesOfFieldsIsLocalCopy)
				{
					_entityNamesOfFields[value.ContainingObjectName] = null;
				}
				if(value.IsPrimaryKey)
				{
					// add it to the primary key set too
					_primaryKeyFields.Add(value);
				}
			}
		}

		/// <summary>
		/// Gets the EntityField with the specified name.
		/// </summary>
		/// <exception cref="System.ArgumentException">When the specified name is the empty string or contains only spaces or is not found.</exception>
		/// <remarks>This property is read-only. If you want to set a value, use the int indexer</remarks>
		public IEntityField this [string name] 
		{
			get
			{
				if(name.Length <= 0)
				{
					// Names of zero length are rejected
					throw new ArgumentException("Name cannot be of zero length.");
				}
				if(name.Trim().Length <= 0)
				{
					throw new ArgumentException("Name has to contain other characters than just spaces.");
				}
				int index = 0;
				if( !_entityFieldIndexes.TryGetValue( name, out index ) )
				{
					return null;
				}
				return this[index];
			}
		}

		/// <summary>
		/// The state of the EntityFields object, the heart and soul of every EntityObject.
		/// </summary>
		public EntityState State 
		{
			get { return _state; } 
			set { _state = value; }
		}

		/// <summary>
		/// Flag to signal if the entity fields have changed during an edit cycle which is controlled outside this IEntityFields object. If set to
		/// true, EndEdit will succeed, otherwise EndEdit will ignore any changes, since these are made in a previous edit cycle which is already
		/// ended.
		/// </summary>
		public bool IsChangedInThisEditCycle 
		{
			get {return _isChangedInThisEditCycle;} 
			set {_isChangedInThisEditCycle = value;}
		}


		/// <summary>
		/// Sets the entity field indexes object. This is normally done by the factory which creates this EntityFields object. The entity field indexes object
		/// is shared among all instances of an entity type so indexing in this object using a name is fast and constructing an entity object is fast as well, 
		/// plus it avoids huge memory consumption.
		/// </summary>
		/// <value>The entity field indexes.</value>
		public Dictionary<string, int> EntityFieldIndexes
		{
			set 
			{ 
				_entityFieldIndexes = value;
				_entityFieldIndexesIsLocalCopy = false;
			}
		}


		#endregion

	}
}
