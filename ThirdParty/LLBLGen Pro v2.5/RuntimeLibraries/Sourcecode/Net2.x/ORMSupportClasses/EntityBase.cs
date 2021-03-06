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
using System.Diagnostics;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Text;
using System.Data;
using System.Globalization;

#if !CF
using System.Runtime.Serialization;
using System.Configuration;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General Entity Base class, which is used to inherit the Entity classes from.
	/// </summary>
	[Serializable]
	public abstract class EntityBase : IEntity, ITransactionalElement, ISerializable, IEditableObject, IXmlSerializable, INotifyPropertyChanged, 
			IDataErrorInfo, IEntityCoreInternal
	{
		#region Event Handler Declarations
		/// <summary>
		/// Event fired when a field / property is changed. To fire this event from a derived class, call OnPropertyChanged.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Event handler declaration for the event that is fired each time the one of values of this entity are changed.
		/// The event does not contain the value / field which is changed, it only signals subscribers the entity is changed
		/// and the subscriber should act accordingly, f.e. fire a ListChanged event.
		/// </summary>
		public event EventHandler EntityContentsChanged;

		/// <summary>
		/// Event handler declaration for the event that is fired each time this entity is persisted. Related entities can subscribe to
		/// this event to start housekeeping actions, like syncing internal FK fields with the PK fields of this entity.
		/// </summary>
		public event EventHandler AfterSave;

		/// <summary>
		/// Event which is raised at the start of the initialization routine of the entity. The entity is clean and has no entity fields object yet. 
		/// </summary>
		public event EventHandler Initializing;

		/// <summary>
		/// Event which is raised at the end of the initialization routine of the entity. This event is also raised if the entity is pre-filled with a 
		/// filled EntityFields(2) object. In your handler, check the State property of the entity Fields to see if you're dealing with a new entity or with an 
		/// entity which is new, but pre-initialized with filled field objects.
		/// </summary>
		public event EventHandler Initialized;
		#endregion

		#region Class Member Declarations
		private IEntityFields		_fields;
		private FastDictionary<Guid, FastDictionary<string, EntitySyncInfo<IEntity>>> _relatedEntitySyncInfos;		// EntitySyncInfo<IEntity> objects stored in a Dictionary per ObjectID
		private FastDictionary<string, Guid> _field2RelatedEntity;			// Fieldname (mapped on relation) - ObjectID combinations. Used to find back entries in _relatedEntitySyncInfos
		private bool				_isNew, _isAlreadyRefetching, _backupIsNew, _editCycleInProgress;
		private IValidator			_validator;
		private IConcurrencyPredicateFactory	_concurrencyPredicateFactoryToUse;
		private FastDictionary<string, IEntityFields> _savedFields;
		private FastDictionary<string, string> _dataErrorInfoErrorsPerField;
		private string _dataErrorInfoError;
		private ITypeDefaultValue	_typeDefaultValueProvider;
		private IAuthorizer			_authorizerToUse;
		private IAuditor			_auditorToUse;
		private Guid				_objectID;

		[NonSerialized]
		private IEntityFields		_backupFields;
		[NonSerialized]
		private bool				_pendingChangedEvent;
		[NonSerialized]
		private bool _pendingCancelEdit;
		[NonSerialized]
		private	ITransaction		_containingTransaction;
		[NonSerialized]
		private IEntityCollection	_parentCollection;		// databinding related
		[NonSerialized]
		private	bool				_isNewViaDataBinding;	// databinding related
		[NonSerialized]
		private	bool				_isDeserializing;
		[NonSerialized]
		private	bool				_isSerializing;
		[NonSerialized]
		private Context				_activeContext;
		[NonSerialized]
		private ISite				_site;
		[NonSerialized]
		private bool				_markedForDeletion;		// flag which is set when the entity is removed from an entity collection and added to a tracker. This flag is used to cut off hierarchies in serialization scenario's

		/// <summary>
		/// Flag (default: false), which can be used to track down errors in code at runtime when migrating from LLBLGen Pro v1.0.xx to v2.0. 
		/// When set to true, it will make invalid field reads fatal and will make the entity throw an ORMInvalidFieldReadException when a field is
		/// read while the field's value hasn't been set yet.
		/// </summary>
		/// <remarks>This is to track down the following errors:<br/>
		/// <code>
		/// OrderEntity order = new OrderEntity();
		/// order.SomeNullableField+=10;
		/// </code>
		/// This code resulted in the value 10 in v1.0, but will result in 0 in v2, if you're using .NET 2.0. This is caused by the fact that SomeNullableField
		/// is null/Nothing in v2 when the entity is initialized, not 0.
		/// By switching on this flag you can track down these errors at runtime. <br/>
		/// It will cause problems with asp.net grids and new entities, so use this flag only for checking the code after you've migrated to v2.
		/// </remarks>
		public static bool MakeInvalidFieldReadsFatal = false;

		/// <summary>
		/// The mode (default: NoBypass) to use for the build-in validation checks. Build-in validation checks are performed on every value a field is set to,
		/// unless this mode is set to a different value than NoBypass which makes the code to bypass these build-in validation checks. The build-in validation checks
		/// are used to prevent overflow exceptions when the entity is persisted to the database. 
		/// </summary>
		/// <remarks>You can also set this field by adding a key-value pair to the appSettings section of your application's config file. Use 
		/// 'buildInValidationBypassMode' as key and the numeric value of the BuildInValidationBypass enum value as value.</remarks>
		public static BuildInValidationBypass BuildInValidationBypassMode = BuildInValidationBypass.NoBypass;

		/// <summary>
		/// Flag (default: false) which controls if saved entities which aren't fetched back in the same call should be marked as Fetched instead of the
		/// default 'OutOfSync'. Setting this to true can save fetch roundtrips to the database to refetch data for the entity already in memory. However
		/// setting this setting to true can also cause getting the entity out of sync with the database because another thread has updated the same
		/// entity data. Use with care. It's recommended to leave it on its default value: false and only set this to true if you're sure the data in-memory
		/// reflects the entity data in the database.
		/// </summary>
		public static bool MarkSavedEntitiesAsFetched = false;

		/// <summary>
		/// The action to use when the build-in validation detects a scale overflow (e.g. scale of a field is 2, and the value to set the field to is 10.455, which 
		/// has a scale of 3). Default is 'Truncate', which means that the overflow value will be truncated to the scale size.
		/// If validation is bypassed by setting BuildInValidationBypassMode to a value which makes the build-in validation to be bypassed, this
		/// setting has no effect.
		/// </summary>
		/// <remarks>You can also set this field by adding a key-value pair to the appSettings section of your application's config file. Use 
		/// 'scaleOverflowCorrectionActionToUse ' as key and the numeric value of the ScaleOverFlowCorrectionAction enum value as value.</remarks>
		public static ScaleOverflowCorrectionAction ScaleOverflowCorrectionActionToUse = ScaleOverflowCorrectionAction.Truncate;
		#endregion

		
		/// <summary>
		/// Static CTor
		/// </summary>
		static EntityBase()
		{
#if !CF
			string value = ConfigurationManager.AppSettings["buildInValidationBypassMode"];
			if(value != null)
			{
				// defined
				int valueAsInt = 0;
				try
				{
					valueAsInt = Convert.ToInt32(value);
					if(!Enum.IsDefined(typeof(BuildInValidationBypass), valueAsInt))
					{
						// not defined
						throw new ORMGeneralOperationException("The value defined for 'buildInValidationBypassMode' in the appSettings section of the config file isn't a valid value. The value should be the numeric representation of one of the BuildInValidationBypass enum values.");
					}
					EntityBase.BuildInValidationBypassMode = (BuildInValidationBypass)valueAsInt;
				}
				catch(InvalidCastException)
				{
					throw new ORMGeneralOperationException("The value defined for 'buildInValidationBypassMode' in the appSettings section of the config file isn't convertable to Int32.");
				}
			}

			value = ConfigurationManager.AppSettings["scaleOverflowCorrectionActionToUse"];
			if(value != null)
			{
				int valueAsInt = 0;
				try
				{
					valueAsInt = Convert.ToInt32(value);
					if(!Enum.IsDefined(typeof(ScaleOverflowCorrectionAction), valueAsInt))
					{
						// not defined
						throw new ORMGeneralOperationException("The value defined for 'scaleOverflowCorrectionActionToUse' in the appSettings section of the config file isn't a valid value. The value should be the numeric representation of one of the ScaleOverFlowCorrectionAction enum values.");
					}
					EntityBase.ScaleOverflowCorrectionActionToUse = (ScaleOverflowCorrectionAction)valueAsInt;
				}
				catch(InvalidCastException)
				{
					throw new ORMGeneralOperationException("The value defined for 'scaleOverFlowCorrectionActionToUse' in the appSettings section of the config file isn't convertable to Int32.");
				}
			}

			value = ConfigurationManager.AppSettings["markSavedEntitiesAsFetched"];
			if(value != null)
			{
				EntityBase.MarkSavedEntitiesAsFetched = XmlConvert.ToBoolean(value);
			}
#endif
		}


		/// <summary>
		/// CTor
		/// </summary>
		public EntityBase()
		{
			InitClass();
		}


		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityBase(SerializationInfo info, StreamingContext context)
		{
			try
			{
				_isDeserializing = true;

				_isAlreadyRefetching = info.GetBoolean("_isAlreadyRefetching");
				_isNew = info.GetBoolean("_isNew");
				_validator = (IValidator)info.GetValue("_validator", typeof(IValidator));
				_relatedEntitySyncInfos = (FastDictionary<Guid, FastDictionary<string, EntitySyncInfo<IEntity>>>)info.GetValue("_relatedEntitySyncInfos", typeof(FastDictionary<Guid, FastDictionary<string, EntitySyncInfo<IEntity>>>));
				_field2RelatedEntity = (FastDictionary<string, Guid>)info.GetValue("_field2RelatedEntity", typeof(FastDictionary<string, Guid>));
				_concurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)info.GetValue("_concurrencyPredicateFactoryToUse", typeof(IConcurrencyPredicateFactory));
				_savedFields = (FastDictionary<string, IEntityFields>)info.GetValue("_savedFields", typeof(FastDictionary<string, EntityFields>));
				_objectID = (Guid)info.GetValue("_objectID", typeof(Guid));
				_dataErrorInfoErrorsPerField = (FastDictionary<string, string>)info.GetValue("_dataErrorInfoErrorsPerField", typeof(FastDictionary<string, string>));
				_dataErrorInfoError = (string)info.GetString( "_dataErrorInfoError" );
				_typeDefaultValueProvider = (ITypeDefaultValue)SerializationUtils.InfoGetValue(info, "_typeDefaultValueProvider", typeof(ITypeDefaultValue));
				_authorizerToUse = (IAuthorizer)SerializationUtils.InfoGetValue(info, "_authorizerToUse", typeof(IAuthorizer));
				_auditorToUse = (IAuditor)SerializationUtils.InfoGetValue(info, "_auditorToUse", typeof(IAuditor));

				_fields = CreateEntityFactory().CreateFields();
				object[,] fieldsData = (object[,])info.GetValue("_fieldsData", typeof(object[,]));
				BitArray fieldsFlags = (BitArray)info.GetValue("_fieldsFlags", typeof(BitArray));
				for(int i = 0; i < _fields.Count; i++)
				{
					_fields[i].ForcedCurrentValueWrite(fieldsData[0, i], fieldsData[1, i]);
					((EntityField)_fields[i]).ForcedChangedWrite(fieldsFlags[(i * 2)]);
					((EntityField)_fields[i]).ForcedIsNullWrite(fieldsFlags[(i * 2) + 1]);
				}

				_fields.State = (EntityState)info.GetValue("_fieldsState", typeof(EntityState));
				_fields.IsDirty = info.GetBoolean("_fieldsIsDirty");

				OnDeserialized( info, context );
			}
			finally
			{
				_isDeserializing = false;
			}
		}


		/// <summary>
		/// Method which will fire the AfterSave event to signal that this entity is persisted and refetched succesfully.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FlagAsSaved()
		{
			if(AfterSave!=null)
			{
				// fire the AfterSave event.
				AfterSave(this, new EventArgs());
			}
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, out string entityXml)
		{
			WriteXml(aspects, "Entity", out entityXml);
		}


		/// <summary>
		/// Converts this entity to XML, recursively. Uses the LLBLGenProEntityName for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityNode)
		{
			WriteXml(aspects, "Entity", parentDocument, out entityNode);
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, out string entityXml)
		{
			XmlNode entityNode = null;
			WriteXml(aspects, rootNodeName, new XmlDocument(), out entityNode);
			entityXml = entityNode.OuterXml;
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityNode)
		{
			Entity2Xml(rootNodeName, parentDocument, new Dictionary<Guid, IEntity>(), aspects, out entityNode);
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(out string entityXml)
		{
			WriteXml("Entity", out entityXml);
		}


		/// <summary>
		/// Converts this entity to XML, recursively. Uses the LLBLGenProEntityName for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlDocument parentDocument, out XmlNode entityNode)
		{
			WriteXml("Entity", parentDocument, out entityNode);
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(string rootNodeName, out string entityXml)
		{
			XmlNode entityNode = null;
			WriteXml(rootNodeName, new XmlDocument(), out entityNode);
			entityXml = entityNode.OuterXml;
		}


		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		public void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityNode)
		{
			Entity2Xml( rootNodeName, parentDocument, new Dictionary<Guid, IEntity>(), XmlFormatAspect.None, out entityNode );
		}


		/// <summary>
		/// Produces the actual XML for this entity, recursively. Because it recurses through referenced entities, it keeps track of which objects are processed
		/// so cyclic references are not resulting in cyclic recursion and thus a crash. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="processedObjectIDs">Dictionary with ObjectIDs of all the objects already processed. If this entity's ObjectID is in the
		/// key list, a ProcessedObjectReference tag is emitted and the routine simply returns. </param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		internal void Entity2Xml(string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntity> processedObjectIDs, XmlFormatAspect aspects, out XmlNode entityNode)
		{
			TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityBase.Entity2Xml", "Method Enter");

			XmlHelper nodeCreator = new XmlHelper();

			bool compactXml = ((aspects & XmlFormatAspect.Compact)==XmlFormatAspect.Compact);
			bool datesInXmlDataType = ((aspects & XmlFormatAspect.DatesInXmlDataType)==XmlFormatAspect.DatesInXmlDataType);
			bool mlInCDataBlocks = ((aspects & XmlFormatAspect.MLTextInCDataBlocks)==XmlFormatAspect.MLTextInCDataBlocks);

			if(processedObjectIDs.ContainsKey(this.ObjectID))
			{
				// already processed. Simply create a ProcessedObjectReference with the ObjectID and return.
				entityNode = parentDocument.CreateNode(XmlNodeType.Element, "ProcessedObjectReference", "");
				nodeCreator.AddAttribute(entityNode, "ObjectID", this.ObjectID.ToString());

				// done.
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityBase.Entity2Xml: ProcessedObjectReference", "Method Exit");
				return;
			}

			entityNode = parentDocument.CreateNode(XmlNodeType.Element, rootNodeName, "");
			// add ourselves to the processedObjectIDs
			processedObjectIDs.Add(this.ObjectID, null);

			if(this.GetInheritanceHierarchyType() != InheritanceHierarchyType.None)
			{
				nodeCreator.AddAttribute(entityNode, "EntityType", this.LLBLGenProEntityTypeValue.ToString());
			}

			// add PK fields as attributes.
			int numberOfPkFields = FieldUtilities.DetermineNumberOfPkFields(_fields.PrimaryKeyFields);
			for(int i = (_fields.PrimaryKeyFields.Count - numberOfPkFields), j = 0; j < numberOfPkFields; j++)
			{
				IEntityField primaryKeyField = _fields.PrimaryKeyFields[i+j];
				string pkFieldCurrentValue = string.Empty;
				if( primaryKeyField.CurrentValue != null )
				{
					pkFieldCurrentValue = primaryKeyField.CurrentValue.ToString();
				}
				nodeCreator.AddAttribute( entityNode, primaryKeyField.Name, pkFieldCurrentValue );
			}

			if(!compactXml)
			{
				// add assembly as attribute
				nodeCreator.AddAttribute(entityNode, "Assembly", this.GetType().Assembly.FullName);
				nodeCreator.AddAttribute(entityNode, "Type", this.GetType().FullName);
			}

			// create hashtable with names of all fields inside this entity
			Dictionary<string, object> fieldNames = new Dictionary<string,object>(_fields.Count);
			for (int i = 0; i < _fields.Count; i++)
			{
				if( fieldNames.ContainsKey( _fields[i].Name ) )
				{
					// overriden field.
					continue;
				}
				fieldNames.Add( _fields[i].Name, null );
			}

			// get properties of this IEntity2 implementing object
			_isSerializing=true;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());
			try
			{
#if CF
				PropertyInfo[] propertyInfos = this.GetType().GetProperties();
				Hashtable propertyInfoHT = new Hashtable(propertyInfos.Length);
				foreach(PropertyInfo pinfo in propertyInfos)
				{
					propertyInfoHT.Add(pinfo.Name, pinfo);
				}
#endif
				for (int i = 0; i < properties.Count; i++)
				{
#if !CF
					if(properties[i].Attributes.Contains(new XmlIgnoreAttribute()))
					{
						// ignore this property
						continue;
					}
#else
					PropertyInfo currentPropertyInfo = (PropertyInfo)propertyInfoHT[properties[i].Name];
					object[] customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(XmlIgnoreAttribute), true);
					if(customAttributes.Length>0)
					{
						// ignore
						continue;
					}
#endif
					// check if this property is part of the Fields collection. If so, skip it, because it is handled by the Fields property
					if(fieldNames.ContainsKey(properties[i].Name))
					{
						// field, continue
						continue;
					}

					if(properties[i].PropertyType.IsInterface)
					{
						if( properties[i].PropertyType.Equals( typeof( IEntityFields ) ) )
						{
							// handled further down
							continue;
						}

						// check for Validator
						if(properties[i].PropertyType.Equals(typeof(IValidator)))
						{
							if(!compactXml)
							{
								// .Validator property
								XmlNode validatorNode = nodeCreator.AddNode(entityNode, "Validator");
								IValidator validator = properties[i].GetValue(this) as IValidator;
								if(validator==null)
								{
									nodeCreator.AddAttribute(validatorNode, "Assembly", "Unknown");
								}
								else
								{
									nodeCreator.AddAttribute(validatorNode, "Assembly", validator.GetType().Assembly.FullName);
									nodeCreator.AddAttribute(validatorNode, "Type", validator.GetType().FullName);
								}
							}
							// done with this property
							continue;
						}

						// check for ConcurrencyPredicateFactory
						if(properties[i].PropertyType.Equals(typeof(IConcurrencyPredicateFactory)))
						{
							if(!compactXml)
							{
								// .ConcurrencyPredicateFactory property
								XmlNode concurrencyPredicateFactoryNode = nodeCreator.AddNode(entityNode, "ConcurrencyPredicateFactory");
								IConcurrencyPredicateFactory factory = properties[i].GetValue(this) as IConcurrencyPredicateFactory;
								if(factory==null)
								{
									nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Assembly", "Unknown");
								}
								else
								{
									nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Assembly", factory.GetType().Assembly.FullName);
									nodeCreator.AddAttribute(concurrencyPredicateFactoryNode, "Type", factory.GetType().FullName);
								}
							}
							// done with this property
							continue;
						}
						if(properties[i].PropertyType.Equals(typeof(IAuthorizer)))
						{
							if(!compactXml)
							{
								XmlNode authorizerNode = nodeCreator.AddNode(entityNode, "Authorizer");
								IAuthorizer authorizer = properties[i].GetValue(this) as IAuthorizer;
								if(authorizer == null)
								{
									nodeCreator.AddAttribute(authorizerNode, "Assembly", "Unknown");
								}
								else
								{
									nodeCreator.AddAttribute(authorizerNode, "Assembly", authorizer.GetType().Assembly.FullName);
									nodeCreator.AddAttribute(authorizerNode, "Type", authorizer.GetType().FullName);
								}
							}
							// done with this property
							continue;
						}
						if(properties[i].PropertyType.Equals(typeof(IAuditor)))
						{
							if(!compactXml)
							{
								XmlNode auditorNode = nodeCreator.AddNode(entityNode, "Auditor");
								IAuditor auditor = properties[i].GetValue(this) as IAuditor;
								if(auditor == null)
								{
									nodeCreator.AddAttribute(auditorNode, "Assembly", "Unknown");
								}
								else
								{
									nodeCreator.AddAttribute(auditorNode, "Assembly", auditor.GetType().Assembly.FullName);
									nodeCreator.AddAttribute(auditorNode, "Type", auditor.GetType().FullName);
								}
							}
							// done with this property
							continue;
						}
					}

					// get all interfaces of the type of this property
					Type[] propertyInterfaces = properties[i].PropertyType.GetInterfaces();

					bool propertyHandled = false;
					for(int j = 0; j < propertyInterfaces.Length; j++)
					{
						// Use waterfall method, check using Equals.
						if(propertyInterfaces[j].Equals(typeof(IEntity)))
						{
							if(!_markedForDeletion)
							{
								// a related Entity property which references an entity related to this entity. 
								XmlNode propertyNode = nodeCreator.AddNode(entityNode, "EntityReference");
								nodeCreator.AddAttribute(propertyNode, "PropertyName", properties[i].Name);

								XmlNode refEntityNode = null;
								EntityBase referencedEntity = properties[i].GetValue(this) as EntityBase;
								if(referencedEntity != null)
								{
									referencedEntity.Entity2Xml("Entity", parentDocument, processedObjectIDs, aspects, out refEntityNode);
									propertyNode.AppendChild(refEntityNode);
								}
							}
							propertyHandled = true;
							break;
						}

						if(propertyInterfaces[j].Equals(typeof(IEntityCollection)))
						{
							if(!_markedForDeletion)
							{
								// a related entity collection property which references an EntityCollectionBase2 derived class with entities related to this entity.
								XmlNode propertyNode = nodeCreator.AddNode(entityNode, "EntityCollectionReference");
								nodeCreator.AddAttribute(propertyNode, "PropertyName", properties[i].Name);

								XmlNode refEntityCollectionNode = null;
								IEntityCollection referencedEntityCollection = properties[i].GetValue(this) as IEntityCollection;
								if(referencedEntityCollection != null)
								{
									((IEntityCollectionAccess)referencedEntityCollection).EntityCollection2Xml(properties[i].Name, parentDocument, processedObjectIDs, aspects, out refEntityCollectionNode);
									propertyNode.AppendChild(refEntityCollectionNode);
								}
							}
							propertyHandled = true;
							break;
						}
					}

					if(propertyHandled)
					{
						continue;
					}

					// Normal not yet handled property. Add it.
					XmlNode childNode = nodeCreator.AddNode(entityNode, properties[i].Name);
					string valueTypeName = properties[i].PropertyType.UnderlyingSystemType.FullName.ToString();
					if(!compactXml)
					{
						nodeCreator.AddAttribute(childNode, "Type", valueTypeName);
					}

					// convert the value of the property to a string. 
					nodeCreator.PropertyValueToString(parentDocument, datesInXmlDataType, mlInCDataBlocks, properties[i].GetValue(this), childNode, properties[i].PropertyType);
				}

				// add fields
				XmlNode entityFieldsNode = nodeCreator.AddNode(entityNode, "Fields");

				// add the fields
				_fields.WriteXml(aspects, parentDocument, entityFieldsNode);

				// error info, if present.
				if(!String.IsNullOrEmpty(_dataErrorInfoError))
				{
					// error set, serialize it into the xml.
					XmlNode entityErrorNode = nodeCreator.AddNode(entityNode, "EntityError", _dataErrorInfoError);
				}
				// error info per field, if present.
				if((_dataErrorInfoErrorsPerField != null) && (_dataErrorInfoErrorsPerField.Count > 0))
				{
					// errors set, serialize them into the xml.
					XmlNode entityFieldErrorsNode = nodeCreator.AddNode(entityNode, "EntityFieldErrors");
					foreach(KeyValuePair<string, string> fieldError in _dataErrorInfoErrorsPerField)
					{
						XmlNode fieldErrorNode = nodeCreator.AddNode(entityFieldErrorsNode, fieldError.Key, fieldError.Value);
					}
				}

				// add info nodes
				XmlNode isDirtyNode = nodeCreator.AddNode(entityNode, "IsDirty", _fields.IsDirty.ToString());
				if(!compactXml)
				{
					nodeCreator.AddAttribute(isDirtyNode, "Type", "System.Boolean");
				}

				XmlNode entityStateNode = nodeCreator.AddNode(entityNode, "EntityState", _fields.State.ToString());
				if(!compactXml)
				{
					nodeCreator.AddAttribute(entityStateNode, "Type", _fields.State.GetType().FullName.ToString());
				}

				// add saved fieldsets.
				XmlNode savedFieldSetsNode = nodeCreator.AddNode(entityNode, "SavedFieldSets");

				if(_savedFields!=null)
				{
					foreach(KeyValuePair<string, IEntityFields> savedFieldSet in _savedFields)
					{
						XmlNode savedFieldSetNode = nodeCreator.AddNode(savedFieldSetsNode, "SavedFieldSet");
						nodeCreator.AddAttribute(savedFieldSetNode, "Name", savedFieldSet.Key);

						// add the entityfields collection.
						XmlNode savedFieldSetFieldsNode = nodeCreator.AddNode(savedFieldSetNode, "Fields");

						// add the fields
						savedFieldSet.Value.WriteXml(aspects, parentDocument, savedFieldSetFieldsNode );
					}
				}

			}
			finally
			{
				_isSerializing=false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityBase.Entity2Xml", "Method Exit");
			}
		}


		/// <summary>
		/// Will fill the entity and its containing members (recursively) with the data stored in the Xml string passed in. The string xmlData has to
		/// be filled with Xml in the format written by IEntity.WriteXml() and the Xml has to be compatible with the structure of this entity.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		public void ReadXml(string xmlData)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlData);
			ReadXml(doc.DocumentElement);
		}


		/// <summary>
		/// Will fill the entity and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntity.WriteXml() and the Xml has to be compatible with the structure of this entity.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
		/// of the entity's Xml data</param>
		public virtual void ReadXml(XmlNode node)
		{
			List<NodeEntityReference> nodeEntityReferences = new List<NodeEntityReference>();
			Dictionary<Guid, IEntity> processedObjectIDs = new Dictionary<Guid,IEntity>();
			Xml2Entity(node, processedObjectIDs, nodeEntityReferences);

			// walk all references found and set them to the correct objects.
			XmlHelper.SetReadReferencesSS(nodeEntityReferences, processedObjectIDs);
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity data. 
		/// </summary>
		/// <param name="node">current node which points to an entity node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">Arraylist with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		internal void Xml2Entity( XmlNode node, Dictionary<Guid, IEntity> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences )
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityBase.Xml2Entity", "Method Enter");

				_isDeserializing = true;
				XmlHelper typeConverter = new XmlHelper();

				// get this instance's properties.
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());
				
				XmlNamespaceManager nsmgr = null;
				string nsprefix = string.Empty;
				if(node.NamespaceURI.Length>0)
				{
					// has namespace specified. As .NET has some nice XML bugs, we have to specify a namespace manager and a fake prefix.
					nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
					if(node.Prefix.Length<=0)
					{
						// use fake ns
						nsprefix = "entity";
					}
					else
					{
						nsprefix = node.Prefix;
					}
					nsmgr.AddNamespace(nsprefix, node.NamespaceURI);
					nsprefix += ":";
				}

				// first walk the subnodes and process only the direct childs, skipping entity collections and entity references.
				foreach(XmlNode currentElement in node.ChildNodes)
				{
					switch(currentElement.Name)
					{
							// filter out special cases, the rest is handled by the default section.
						case "EntityCollectionReference":
							// create a new instance.
							XmlNode entityCollectionNode = currentElement.FirstChild;
							// get a reference to the collection object.
							IEntityCollection referencedEntityCollection = (IEntityCollection)properties[currentElement.Attributes["PropertyName"].Value].GetValue(this);
							((IEntityCollectionAccess)referencedEntityCollection).Xml2EntityCollection(entityCollectionNode, processedObjectIDs, nodeEntityReferences);
							break;
						case "EntityReference":
							// first test if this node is empty
							if(currentElement.ChildNodes.Count<=0)
							{
								// is empty
								continue;
							}

							// if this node contains an entity reference, add a new entity reference to the arraylist. If it contains
							// a full object in Xml, deserialize that object.
							// find 'ProcessedObjectReference' subnode, if present.
#if CF
							XmlNode referenceNode = XmlCFUtilities.SelectSingleNode(currentElement, "ProcessedObjectReference");
#else
							XmlNode referenceNode = currentElement.SelectSingleNode(nsprefix + "ProcessedObjectReference", nsmgr);
#endif
							if(referenceNode!=null)
							{
								// reference node found. Add reference.
								NodeEntityReference newReference = new NodeEntityReference();
								newReference.ObjectID = new Guid(referenceNode.Attributes["ObjectID"].Value);
								newReference.PropertyHoldingInstance = this;
								newReference.IsCollectionAdd=false;
								newReference.ReferencingProperty = properties[currentElement.Attributes["PropertyName"].Value];
								nodeEntityReferences.Add(newReference);
								// done with this node.
								continue;
							}
							// not a reference, instantiate the full node if a full node is present
							XmlNode entityNode = currentElement.FirstChild;

							EntityBase referencedEntity = null;
							if(entityNode.Attributes.GetNamedItem("Assembly")==null)
							{
								// check if there's an attribute 'EntityType'. 
								XmlNode entityTypeValueAsNode = entityNode.Attributes.GetNamedItem("EntityType");
								if(entityTypeValueAsNode != null)
								{
									referencedEntity = (EntityBase)this.GetEntityFactory().CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsNode.Value));
								}
								else
								{
									referencedEntity = (EntityBase)Activator.CreateInstance(properties[currentElement.Attributes["PropertyName"].Value].PropertyType);
								}
							}
							else
							{
								// get type and assembly for entity instance.
								string entityAssemblyName = entityNode.Attributes["Assembly"].Value;
								string entityTypeName = entityNode.Attributes["Type"].Value;
								// load assembly
								Assembly entityAssembly = Assembly.Load(entityAssemblyName);
								// create instance
								referencedEntity = (EntityBase)entityAssembly.CreateInstance(entityTypeName);
							}
							referencedEntity.IsDeserializing=true;
							try
							{
								// convert this entity's xml into data inside this entity
								referencedEntity.Xml2Entity(entityNode, processedObjectIDs, nodeEntityReferences);
								properties[currentElement.Attributes["PropertyName"].Value].SetValue(this, referencedEntity);
							}
							finally
							{
								referencedEntity.IsDeserializing=false;
							}
							break;
						case "Validator":
							// this node is not present in compact XML
							string validatorAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(validatorAssemblyName=="Unknown")
							{
								// no validator set nor serialized
								continue;
							}
							Assembly validatorAssembly = Assembly.Load(validatorAssemblyName);
							string validatorClassType = currentElement.Attributes["Type"].Value;
							this.Validator = (IValidator)validatorAssembly.CreateInstance(validatorClassType);
							break;
						case "ConcurrencyPredicateFactory":
							// this node is not present in compact XML
							string cpFactoryAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(cpFactoryAssemblyName=="Unknown")
							{
								// no factory object set nor serialized
								continue;
							}
							Assembly cpFactoryAssembly = Assembly.Load(cpFactoryAssemblyName);
							string cpFactoryClassType = currentElement.Attributes["Type"].Value;
							this.ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)cpFactoryAssembly.CreateInstance(cpFactoryClassType);
							break;
						case "Authorizer":
							// this node is not present in compact XML
							string authorizerAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(authorizerAssemblyName == "Unknown")
							{
								// no factory object set nor serialized
								continue;
							}
							Assembly authorizerAssembly = Assembly.Load(authorizerAssemblyName);
							string authorizerClassType = currentElement.Attributes["Type"].Value;
							this.AuthorizerToUse = (IAuthorizer)authorizerAssembly.CreateInstance(authorizerClassType);
							break;
						case "Auditor":
							// this node is not present in compact XML
							string auditorAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(auditorAssemblyName == "Unknown")
							{
								// no factory object set nor serialized
								continue;
							}
							Assembly auditorAssembly = Assembly.Load(auditorAssemblyName);
							string auditorClassType = currentElement.Attributes["Type"].Value;
							this.AuditorToUse = (IAuditor)auditorAssembly.CreateInstance(auditorClassType);
							break;
						case "Fields":
							_fields.ReadXml(currentElement);
							break;
						case "SavedFieldSets":
							// get all child nodes. If no child nodes are there, no saved sets are stored.
							XmlNodeList savedFieldSetNodes = currentElement.ChildNodes;
							if(savedFieldSetNodes.Count>0)
							{
								// there are field sets in the XML, restore them.
								_savedFields = new FastDictionary<string, IEntityFields>();
								foreach(XmlNode currentSavedFieldSetNode in savedFieldSetNodes)
								{
									// get fields node
#if CF
									XmlNode fieldsNode = XmlCFUtilities.SelectSingleNode(currentSavedFieldSetNode, "Fields");
#else
									XmlNode fieldsNode = currentSavedFieldSetNode.SelectSingleNode(nsprefix + "Fields", nsmgr);
#endif
									IEntityFields savedFields = (IEntityFields)((EntityFields)_fields).Clone();
									savedFields.ReadXml(fieldsNode);

									// add to dictionary
									string savedFieldsName = currentSavedFieldSetNode.Attributes["Name"].Value;
									_savedFields[savedFieldsName] = savedFields;
								}
							}
							else
							{
								_savedFields = null;
							}
							break;
						case "IsDirty":
							this.Fields.IsDirty = Convert.ToBoolean(currentElement.InnerText);
							break;
						case "EntityState":
							string entityState = currentElement.InnerText;
							switch(entityState)
							{
								case "Deleted":
									this.Fields.State = EntityState.Deleted;
									break;
								case "Fetched":
									this.Fields.State = EntityState.Fetched;
									break;
								case "New":
									this.Fields.State = EntityState.New;
									break;
								case "OutOfSync":
									this.Fields.State = EntityState.OutOfSync;
									break;
							}
							break;
						case "EntityError":
							string entityError = currentElement.InnerText;
							SetEntityError(entityError);
							break;
						case "EntityFieldErrors":
							XmlNodeList fieldErrorNodes = currentElement.ChildNodes;
							foreach(XmlNode fieldErrorNode in fieldErrorNodes)
							{
								SetEntityFieldError(fieldErrorNode.Name, fieldErrorNode.InnerText, false);
							}
							break;
						default:
							// custom property, not a field.
							string elementTypeName = string.Empty;
							if(currentElement.Attributes.GetNamedItem("Type")==null)
							{
								elementTypeName = properties[currentElement.Name].PropertyType.UnderlyingSystemType.FullName.ToString();
							}
							else
							{
								elementTypeName = currentElement.Attributes["Type"].Value;
							}
							string xmlValue = currentElement.InnerText;
							properties[currentElement.Name].SetValue(this, typeConverter.XmlValueToObject(elementTypeName, xmlValue));
							break;
					}
				}

				// add the ObjectID of this object, which is now read from XML, to the hashtable
				processedObjectIDs.Add(this.ObjectID, this);
			}
			finally
			{
				_isDeserializing = false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityBase.Xml2Entity", "Method Exit");
			}
		}


		/// <summary>
		/// Overrides the GetHashCode routine. It will calculate a hashcode for this entity using the eXclusive OR of the 
		/// hashcodes of the primary key fields in this entity. That hashcode is returned. If no primary key fields are present,
		/// the hashcode of the base class is returned, which will not be unique.
		/// </summary>
		/// <returns>Hashcode for this entity object, based on its primary key field values</returns>
		public override int GetHashCode()
		{
			return _fields.GetHashCode();
		}

		
		/// <summary>
		/// General validation method which isn't used by the LLBLGen Pro framework, but can be used by your own code to validate an entity at any given moment.
		/// </summary>
		public virtual void ValidateEntity()
		{
			if( _validator != null )
			{
				_validator.ValidateEntity(this);
			}
		}


		/// <summary>
		/// Method to keep code compilable however which is now marked as obsolete, as people should call ValidateEntity.
		/// </summary>
		/// <returns>always true</returns>
		/// <remarks>Calls ValidateEntity.</remarks>
		[Obsolete( "This method is now obsolete. Please call ValidateEntity() or one of the other validation methods instead.", false )]
		public virtual bool Validate()
		{
			ValidateEntity();
			return true;
		}


		/// <summary>
		/// Routine which will flag all subscribers of the EntityContentsChanged event that this entity's contents is changed.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FlagMeAsChanged()
		{
			if(EntityContentsChanged!=null)
			{
				EntityContentsChanged(this, new EventArgs());
			}
		}


		/// <summary>
		/// Will check if the entity should refetch itself. Will use the factory pattern trick.
		/// Refetching occurs when the EntityFields are marked OutOfSync and thus not dirty. 
		/// </summary>
		protected void CheckForRefetch()
		{
			TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.CheckForRefetch", "Method Enter");

			if(_fields==null)
			{
				// nothing to refetch
				TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.CheckForRefetch: field object is null.", "Method Exit");
				return;
			}

			if(_isAlreadyRefetching || _fields.IsDirty)
			{
				// already refetching or is dirty. No can do. exit
				TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.CheckForRefetch: already refetching or isdirty.", "Method Exit");
				return;
			}

			if(_fields.State == EntityState.OutOfSync)
			{
				// refetch. 
				try
				{
					_isAlreadyRefetching = true;
					bool wasSuccesful = Refetch();
					if(wasSuccesful)
					{
						// refetch succeeded, update state
						_fields.State = EntityState.Fetched;
					}
				}
					// all exceptions are fatal
				finally
				{
					_isAlreadyRefetching = false;
				}

				TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.CheckForRefetch", "Method Exit");
			}
			else
			{
				TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.CheckForRefetch: state is not OutOfSync", "Method Exit");
			}
		}


		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. Will not recursively save internal dirty entities. 
		/// Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit save activity.
		/// </summary>
		/// <returns>true if all changed fields were successfully persisted to the database, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public bool Save()
		{
			if(_fields == null)
			{
				// nothing to save
				return true;
			}

			if(this.IsDirty || (!this.IsDirty && this.IsNew && (this.GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)))
			{
				return Save(GetConcurrencyPredicate(ConcurrencyPredicateType.Save), false);
			}
			else
			{
				// not changed, return immediately so no transaction is started
				return true;
			}

		}


		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit save activity.
		/// </summary>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if all changed fields were successfully persisted to the database, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public bool Save(bool recurse)
		{
			if(_fields == null)
			{
				// nothing to save
				return true;
			}

			if((this.IsDirty || (!this.IsDirty && this.IsNew && (this.GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy))) 
				|| recurse)
			{
				return Save(GetConcurrencyPredicate(ConcurrencyPredicateType.Save), recurse);
			}
			else
			{
				// not changed, return immediately so no transaction is started
				return true;
			}
		}


		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. If the entity is new, an insert is done and the updateRestriction is ignored. If the entity is not new, the updateRestriction
		/// predicate is used to create an additional where clause (it will be added with AND) for the update query. This predicate can be used for
		/// concurrency checks, like checks on timestamp column values. Will not recursively save internal dirty entities. 
		/// </summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is
		/// new. Overrules an optional set ConcurrencyPredicateFactory.</param>
		/// <returns>true if all changed fields were successfully persisted to the database, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public bool Save(IPredicate updateRestriction)
		{
			if(_fields == null)
			{
				// nothing to save
				return true;
			}

			if(this.IsDirty || (!this.IsDirty && this.IsNew && (this.GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)))
			{
				return Save(updateRestriction, false);
			}
			else
			{
				// not changed, return immediately so no transaction is started
				return true;
			}
		}


		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. If the entity is new, an insert is done and the updateRestriction is ignored. If the entity is not new, the updateRestriction
		/// predicate is used to create an additional where clause (it will be added with AND) for the update query. This predicate can be used for
		/// concurrency checks, like checks on timestamp column values.
		/// </summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is
		/// new. Overrules an optional set ConcurrencyPredicateFactory.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if all changed fields were successfully persisted to the database, false otherwise</returns>
		/// <remarks>Do not call this routine directly, use the overloaded version in a derived class as this version doesn't construct a
		/// local transaction during recursive save, this is done in the overloaded version in a derived class.</remarks>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public virtual bool Save(IPredicate updateRestriction, bool recurse)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityBase.Save(2)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Description");

			bool saveThisEntity = (this.IsDirty || 
								(!this.IsDirty && this.IsNew && (this.GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)));
			if((_fields.State==EntityState.Deleted) ||	( !recurse && !saveThisEntity))
			{
				// deleted or not changed, nothing to save
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityBase.Save(2): entity not changed, or deleted.", "Method Exit");
				return true;
			}

			bool transactionStartedInThisScope = false;
			ITransaction transactionManager = null;

			SingleStatementQueryAction action = SingleStatementQueryAction.NewEntityInsert;
			if(!_isNew)
			{
				action = SingleStatementQueryAction.ExistingEntityUpdate;
			}

			List<ActionQueueElement<IEntity>> insertQueue = new List<ActionQueueElement<IEntity>>();
			List<ActionQueueElement<IEntity>> updateQueue = new List<ActionQueueElement<IEntity>>();

			if(recurse)
			{
				ObjectGraphUtils graphUtils = new ObjectGraphUtils();
				graphUtils.DetermineActionQueues(this, updateRestriction, ref insertQueue, ref updateQueue);
			}
			else
			{
				if(_isNew)
				{
					insertQueue.Add(new ActionQueueElement<IEntity>(this, null, false));
				}
				else
				{
					IPredicateExpression filterToAdd = null;
					if(updateRestriction!=null)
					{
						filterToAdd = new PredicateExpression(updateRestriction);
					}
					updateQueue.Add(new ActionQueueElement<IEntity>(this, filterToAdd, false));
				}
			}

			if((insertQueue.Count<=0)&&(updateQueue.Count<=0))
			{
				// empty queues, nothing to do
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityBase.Save(2): no entities to save.", "Method Exit");
				return true;
			}

			if(recurse || ((this.LLBLGenProIsInHierarchyOfType == InheritanceHierarchyType.TargetPerEntity) && this.LLBLGenProIsSubType) ||
				OnRequiresTransactionForAuditEntities(action))
			{
				if(!ParticipatesInTransaction)
				{
					transactionManager = CreateTransaction(IsolationLevel.ReadCommitted, "SaveRecursively");
					transactionManager.Add(this);
					transactionStartedInThisScope = true;
				}
			}

			bool wasSuccesful = true;
			try
			{
				int totalAffected = 0;
				wasSuccesful &= DaoBase.PersistQueue(insertQueue, true, _containingTransaction, out totalAffected);
				wasSuccesful &= DaoBase.PersistQueue(updateQueue, false, _containingTransaction, out totalAffected);
				if(transactionStartedInThisScope)
				{
					transactionManager.Commit();
				}
			}
			catch(ORMQueryExecutionException ex)
			{
				ex.InvolvedEntity = this;
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			catch
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Dispose();
				} 
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityBase.Save(2)", "Method Exit");
			}
			// done.
			return wasSuccesful;
		}


		/// <summary>
		/// When the <see cref="ITransaction"/> in which this IEntity participates is commited, this IEntity can succesfully finish actions performed by this
		/// IEntity. This method is called by <see cref="ITransaction"/>, you should not call it by yourself. When this IEntity doesn't participate in a
		/// transaction it finishes the actions itself, calling this method is not needed.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransactionCommit()
		{
			_backupFields = null;

			// if this entity is in a context, tell the context the save was committed
			if(_activeContext!=null)
			{
				_activeContext.EntitySaveCommitted(this);
			}

			OnTransactionCommit();
		}


		/// <summary>
		/// When the <see cref="ITransaction"/> in which this IEntity participates is rolled back, this IEntity has to roll back its internal variables.
		/// This method is called by <see cref="ITransaction"/>, you should not call it by yourself. 
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransactionRollback()
		{
			_fields = _backupFields;
			_isNew = _backupIsNew;
			_backupFields = null;

			OnTransactionRollback();
		}


		/// <summary>
		/// Compares passed in object with the given object. This is a compare of PK fields. These have to be the same in VALUES. 
		/// When the values are not the same, or the type is not the same as the current type, false is returned, true otherwise.
		/// When this doesn't have any PK fields, all fields are compared. null values are considered as the same value. 
		/// </summary>
		/// <param name="obj">IEntity implementing object of the same type as this which will be compared to the PK values of this. </param>
		/// <returns>True when the PK values of this are the same as the PK values of obj, or when this doesn't have any PK fields, all fields
		/// have the same value as obj's fields. False otherwise.</returns>
		/// <remarks>If this entity or the passed in entity is new, no values are compared, but the physical objects are compared (object.Equals()),
		/// because new entities can look the same, value wise due to identity fields which are all 0, however which are physical different entities 
		/// (object wise)</remarks>
		public override bool Equals(object obj)
		{
			IEntity passedIn = obj as IEntity;
			if(passedIn==null)
			{
				// not the same type, not identical.
				return false;
			}

			if(!this.GetType().Equals(obj.GetType()))
			{
				// Not of the same type
				return false;
			}

			if((_fields==null)||(passedIn.Fields==null))
			{
				return false;
			}

			// new entities are always different. If one of the two (this, or passed in object) is new, they have to be tested using reference testing.
			// if that fails, they're not the same. New entities can't be compared using field values
			if(_isNew || passedIn.IsNew)
			{
				// one or both is new, use instance compare.
				return (this==passedIn);
			}

			return _fields.Equals(passedIn.Fields);
		}


		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into this entity. 
		/// </summary>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		public virtual void FetchExcludedFields(ExcludeIncludeFieldsList excludedIncludedFields)
		{
			IDao dao = CreateDAOInstance();
			dao.FetchExcludedFields(this, this.Transaction, excludedIncludedFields);
		}


		/// <summary>
		/// Deletes the Entity from the persistent storage. This method succeeds also when the Entity is not present.
		/// Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit delete activity.
		/// </summary>
		/// <returns>true if Delete succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the delete process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public bool Delete()
		{
			return Delete(GetConcurrencyPredicate(ConcurrencyPredicateType.Delete));
		}


		/// <summary>
		/// Deletes the Entity from the persistent storage. This method succeeds also when the Entity is not present.
		/// </summary>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query. Overrules the predicate returned
		/// by a set ConcurrencyPredicateFactory object.</param>
		/// <returns>true if Delete succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the delete process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public virtual bool Delete(IPredicate deleteRestriction)
		{
			if(!OnCanDeleteEntity())
			{
				// denied
				return false;
			}

			bool transactionStartedInThisScope = false;
			ITransaction transactionManager = null;
			if(((this.LLBLGenProIsInHierarchyOfType == InheritanceHierarchyType.TargetPerEntity) && this.LLBLGenProIsSubType) ||
				OnRequiresTransactionForAuditEntities(SingleStatementQueryAction.EntityDelete))
			{
				if(!this.ParticipatesInTransaction)
				{
					transactionManager = CreateTransaction(IsolationLevel.ReadCommitted, "DeleteEntity");
					transactionManager.Add(this);
					transactionStartedInThisScope = true;
				}
			}
			try
			{
				OnValidateEntityBeforeDelete();
				OnDelete();
				IDao dao = CreateDAOInstance();
				bool wasSuccesful = dao.DeleteExisting(_fields, this.Transaction, deleteRestriction);
				if(wasSuccesful)
				{
					// audit as successful delete
					OnAuditDeleteOfEntity();
					_fields.State = EntityState.Deleted;
					QueueAuditorForCommitFlush();
				}
				else
				{
					if(deleteRestriction != null)
					{
						throw new ORMConcurrencyException("The delete action of an entity failed, probably due to the set delete restriction provided. The entity which failed is enclosed.", this);
					}
				}
				if(transactionStartedInThisScope)
				{
					transactionManager.Commit();
				}
				return wasSuccesful;
			}
			catch(ORMQueryExecutionException ex)
			{
				ex.InvolvedEntity = this;
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			catch
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Rollback();
				}
				throw;
			}
			finally
			{
				if(transactionStartedInThisScope)
				{
					transactionManager.Dispose();
				}
				OnDeleteComplete();
			}
		}


		/// <summary>
		/// ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// </summary>
		/// <param name="info">See ISerializable</param>
		/// <param name="context">See ISerialilzable</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_fieldsData", ((EntityFields)_fields).GetFieldsDataArray());
			info.AddValue("_fieldsFlags", ((EntityFields)_fields).GetFieldsTrackingFlagsArray());
			info.AddValue("_fieldsState", _fields.State);
			info.AddValue("_fieldsIsDirty", _fields.IsDirty);

			info.AddValue("_isNew", _isNew);
			info.AddValue("_isAlreadyRefetching", _isAlreadyRefetching);
			info.AddValue("_validator", _validator);
			if(_markedForDeletion)
			{
				info.AddValue("_relatedEntitySyncInfos", null);
				info.AddValue("_field2RelatedEntity", null);
			}
			else
			{
				info.AddValue("_relatedEntitySyncInfos", _relatedEntitySyncInfos);
				info.AddValue("_field2RelatedEntity", _field2RelatedEntity);
			}
			info.AddValue("_concurrencyPredicateFactoryToUse", _concurrencyPredicateFactoryToUse);
			info.AddValue("_savedFields", _savedFields);
			info.AddValue("_objectID", this.ObjectID);
			info.AddValue( "_dataErrorInfoError", _dataErrorInfoError );
			info.AddValue( "_dataErrorInfoErrorsPerField", _dataErrorInfoErrorsPerField );
			info.AddValue("_typeDefaultValueProvider", _typeDefaultValueProvider, typeof(ITypeDefaultValue));
			info.AddValue("_authorizerToUse", _authorizerToUse, typeof(IAuthorizer));
			info.AddValue("_auditorToUse", _auditorToUse, typeof(IAuditor));

			OnGetObjectData( info, context );
		}


		/// <summary>
		/// Creates the requested predicate of the type specified. If no IConcurrencyPredicateFactory instance is stored in this entity instance, null
		/// is returned.
		/// </summary>
		/// <param name="predicateTypeToCreate">The type of predicate to create</param>
		/// <returns>A ready to use predicate to use in the query to execute, or null/Nothing if no IConcurrencyPredicateFactory instance is present, 
		/// in which case the predicate is ignored</returns>
		public virtual IPredicateExpression GetConcurrencyPredicate(ConcurrencyPredicateType predicateTypeToCreate)
		{
			if(_concurrencyPredicateFactoryToUse!=null)
			{
				return _concurrencyPredicateFactoryToUse.CreatePredicate(predicateTypeToCreate, this);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// Gets the current value of the EntityField with the index fieldIndex. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to get the current value of</param>
		/// <returns>The current value of the EntityField specified</returns>
		/// <exception cref="ORMEntityIsDeletedException">When the entity is marked as deleted.</exception>
		/// <exception cref="ArgumentOutOfRangeException">When fieldIndex is smaller than 0 or bigger than the amount of fields in the fields collection.</exception>
		public object GetCurrentFieldValue(int fieldIndex)
		{
			// always get the raw value
			return GetValue(fieldIndex, false);
		}


		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// A succesful edit has been performed. All new values have to be moved to the current value slots.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EndEdit()
		{
			if(_fields!=null)
			{
				if(_editCycleInProgress)
				{
					_fields.EndEdit();
					_editCycleInProgress = false;

					if(_isNewViaDataBinding)
					{
						_isNewViaDataBinding=false;
					}

					// check if there is a changed event pending
					if(_pendingChangedEvent)
					{
						// yes. Mark it as changed
						FlagMeAsChanged();
						_pendingChangedEvent=false;
					}
					OnEndEdit();
				}
			}
		}


		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CancelEdit()
		{
			if(_fields!=null)
			{
				if(_editCycleInProgress)
				{
					_fields.CancelEdit();
					_editCycleInProgress = false;

					if(_isNewViaDataBinding)
					{
						if( !_pendingCancelEdit )
						{
							try
							{
								_pendingCancelEdit = true;
								// remove from parent
								_parentCollection.Remove( this );
							}
							finally
							{
								_pendingCancelEdit = false;
							}
						}
					}

					// deny a change
					_pendingChangedEvent = false;
					OnCancelEdit();
				}
			}
		}

		/// <summary>
		/// IEditableObject method. Used by databinding.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BeginEdit()
		{
			if(_fields!=null)
			{
				if(!_editCycleInProgress)
				{
					_fields.BeginEdit();
					_editCycleInProgress = true;
					OnBeginEdit();
				}
			}
		}


		/// <summary>
		/// Returns a new ready to use factory for the type of this instance.
		/// </summary>
		/// <returns>a new ready to use factory for the type of this instance.</returns>
		public IEntityFactory GetEntityFactory()
		{
			return CreateEntityFactory();
		}


		/// <summary>
		/// Sets the EntityField with the name fieldName to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldName">Name of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the databas</exception>
		public bool SetNewFieldValue(string fieldName, object value)
		{
			IEntityField field = _fields[fieldName];
			if(field == null)
			{
				return false;
			}
			return SetValue(field.FieldIndex, value, true);
		}

		
		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the database
		/// or the index passed in is not in the fields range of valid indexes.</exception> 
		public bool SetNewFieldValue(int fieldIndex, object value)
		{
			return SetValue(fieldIndex, value, true);
		}

		
		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <param name="checkForRefetch">If set to true, it will check if this entity is out of sync and will refetch it first if it is. Use true in normal
		/// behavior, false for framework specific code.</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the database
		/// or the index passed in is not in the fields range of valid indexes.</exception> 
		[Obsolete("This method is obsolete, starting with version v2.5. Use SetValue(3) instead", true)]
		protected bool SetNewFieldValue(int fieldIndex, object value, bool checkForRefetch)
		{
			return SetValue(fieldIndex, value, checkForRefetch);
		}


		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <param name="checkForRefetch">If set to true, it will check if this entity is out of sync and will refetch it first if it is. Use true in normal
		/// behavior, false for framework specific code.</param>
		/// <param name="fireChangeEvent">if set to true, the change event is fired if the value is set, if applicable. 
		/// If set to false, the caller is responsible for calling the change event mechanism, recommended is then: PostFieldValueSetAction()</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <remarks>This method is used by templates released first on 26-may-2005, hence the 'protected' modifier</remarks>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the database
		/// or the index passed in is not in the fields range of valid indexes.</exception> 
		[Obsolete("This method is obsolete, starting with version v2.5. Use SetValue(3) instead", true)]
		protected bool SetNewFieldValue(int fieldIndex, object value, bool checkForRefetch, bool fireChangeEvent)
		{
			return SetValue(fieldIndex, value, checkForRefetch);
		}


		/// <summary>
		/// Saves the current set of fields under the name specified in an internal hashtable. All data inside the field objects is preserved.
		/// If there is already a set of fields saved under the name specified, that set of fields is overwritten.
		/// </summary>
		/// <param name="name">Name to store the fields under. Case sensitive</param>
		/// <remarks>Creates a deep copy of the fields object.</remarks>
		/// <exception cref="InvalidOperationException">when this method is called while the object is participating in a transaction.</exception>
		public virtual void SaveFields(string name)
		{
			// do not continue if we're in a transaction as the transaction already performs its own versioning of the fields.
			if(ParticipatesInTransaction)
			{
				throw new InvalidOperationException("This entity participates in a transaction, which contains its own fields versioning.");
			}
			
			// clone the fields and add it to the hashtable
			IEntityFields fieldsCopy = (EntityFields)((EntityFields)_fields).Clone();
			if(_savedFields==null)
			{
				_savedFields = new FastDictionary<string, IEntityFields>();
			}

			_savedFields[name] = fieldsCopy;
		}
		
		
		/// <summary>
		/// Replaces the current set of fields with the fields saved under the name specified. If no set of fields is found with the name specified
		/// an exception is thrown. Removes the entry after a succesful rollback.
		/// </summary>
		/// <param name="name">Name under which the fields are stored which have to replace the current set of fields. Case sensitive</param>
		/// <remarks>replaces the current set of fields with the set of fields saved under the name specified. The current set of fields, with all the
		/// data are lost after a succesful rollback.</remarks>
		/// <exception cref="ArgumentException">thrown when the name specified is not found.</exception>
		/// <exception cref="InvalidOperationException">when this method is called while the object is participating in a transaction.</exception>
		public virtual void RollbackFields(string name)
		{
			// do not continue if we're in a transaction as the transaction already performs its own versioning of the fields.
			if(ParticipatesInTransaction)
			{
				throw new InvalidOperationException("This entity participates in a transaction, which contains its own fields versioning.");
			}

			if((_savedFields==null)||(!_savedFields.ContainsKey(name)))
			{
				// not found
				throw new System.ArgumentException("No saved fields were found under the name '" + name + "'", "name");
			}

			// fields exist, set back the fields 
			_fields = _savedFields[name];
			_savedFields.Remove(name);
			FlagMeAsChanged();
			FlagAllFieldsAsChanged();
		}

		
		/// <summary>
		/// Removes all saved field sets from the internal hashtable, clearing up space. This method is also called when 
		/// an entity is saved.
		/// </summary>
		public void DiscardSavedFields()
		{
			if(_savedFields!=null)
			{
				_savedFields.Clear();
			}
			_savedFields=null;
		}


		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return false;
		}

		/// <summary>
		/// Sets the error message which is returned by IDataErrorInfo.Error
		/// </summary>
		/// <param name="errorMessage">the message to set</param>
		public virtual void SetEntityError( string errorMessage )
		{
			_dataErrorInfoError = errorMessage;
		}


		/// <summary>
		/// Sets the error message for the field specified. If there's already a message stored for this field, it's overwritten unless append is
		/// set to true, which appends the message to the existing error using a semi-colon as separator. The message stored
		/// is returned by IDataErrorInfo[fieldName];
		/// </summary>
		/// <param name="fieldName">name of the field</param>
		/// <param name="errorMessage">message to store. If it's an empty string, an existing error message for fieldName is cleared instead</param>
		/// <param name="append">If true, the value is appended to an already existing error message. As separator a semi-colon is used.</param>
		public virtual void SetEntityFieldError(string fieldName, string errorMessage, bool append)
		{
			bool isEmptyMessage = string.IsNullOrEmpty(errorMessage);
			if(_dataErrorInfoErrorsPerField == null)
			{
				if(isEmptyMessage)
				{
					// no hashtable and an empty message, just leave it as is
					return;
				}
				_dataErrorInfoErrorsPerField = new FastDictionary<string, string>();
			}
			if(isEmptyMessage)
			{
				// clear if present
				_dataErrorInfoErrorsPerField.Remove(fieldName);
			}
			else
			{
				if(_dataErrorInfoErrorsPerField.ContainsKey(fieldName) && append)
				{
					// append the value
					_dataErrorInfoErrorsPerField[fieldName] += ";" + errorMessage;
				}
				else
				{
					_dataErrorInfoErrorsPerField[fieldName] = errorMessage;
				}
			}
		}


		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity()
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		public void UnsetRelatedEntity( IEntity relatedEntity, string fieldName )
		{
			UnsetRelatedEntity( relatedEntity, fieldName, true );
		}


		/// <summary>
		/// Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect.
		/// </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		/// <exception cref="System.ApplicationException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		public abstract bool Refetch();
		/// <summary>
		/// Performs the insert action of a new Entity to the persistent storage.
		/// </summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected abstract bool InsertEntity();
		/// <summary>
		/// Performs the update action of an existing Entity to the persistent storage.
		/// </summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected abstract bool UpdateEntity();
		/// <summary>
		/// Performs the update action of an existing Entity to the persistent storage.
		/// </summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected abstract bool UpdateEntity(IPredicate updateRestriction);
		/// <summary>
		/// Sets the internal parameter related to the fieldname passed to the instance relatedEntity. 
		/// </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		public abstract void SetRelatedEntity(IEntity relatedEntity, string fieldName);
		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity()
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		public abstract void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne);
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public abstract List<IEntity> GetDependingRelatedEntities();
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public abstract List<IEntity> GetDependentRelatedEntities();
		/// <summary>
		/// Gets a list of all entity collections stored as member variables in this entity. The contents of the list is
		/// used by the Save logic to perform recursive saves. Only 1:n related collections are returned.
		/// </summary>
		/// <returns>
		/// Collection with 0 or more IEntityCollection objects, referenced by this entity
		/// </returns>
		public abstract List<IEntityCollection> GetMemberEntityCollections();
		/// <summary>
		/// Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		public abstract void SetRelatedEntityProperty(string propertyName, IEntity entity);
		/// <summary>
		/// Gets a list of all the EntityRelation objects the type of this instance has. 
		/// </summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public abstract List<IEntityRelation> GetAllRelations();

		/// <summary>
		/// Creates the DAO instance for this type
		/// </summary>
		/// <returns></returns>
		protected abstract IDao CreateDAOInstance();
		/// <summary>
		/// Creates the entity factory for this type.
		/// </summary>
		/// <returns></returns>
		protected abstract IEntityFactory CreateEntityFactory();
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public abstract Dictionary<string, object> GetRelatedData();
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		/// <returns>Transaction ready to use</returns>
		protected abstract ITransaction CreateTransaction(IsolationLevel levelOfIsolation, string name);

		/// <summary>
		/// Performs the related entity removal.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="toRemove">To remove.</param>
		/// <param name="signalRelatedEntityManyToOne">if set to <c>true</c> [signal related entity many to one].</param>
		protected void PerformRelatedEntityRemoval( IEntityCollection collection, IEntity toRemove, bool signalRelatedEntityManyToOne)
		{
			if( signalRelatedEntityManyToOne )
			{
				collection.Remove( toRemove );
			}
			else
			{
				ICollectionMaintenance c = collection as ICollectionMaintenance;
				if( c != null )
				{
					c.SilentRemove( toRemove );
				}
			}
		}


		/// <summary>
		/// Creates the validator object for this entity. Routine is called when the entity is constructed. Implement in an entity
		/// class to set a particular entity validator object at construction time. Use this routine if you don't want to use
		/// LLBLGen Pro's build in dependency injection mechanism.
		/// </summary>
		/// <returns>ready to use validator.</returns>
		/// <remarks>Users of the .NET compact framework can't use dependency injection and should use this method instead</remarks>
		protected virtual IValidator CreateValidator()
		{
			return null;
		}


		/// <summary>
		/// Creates the authorizer object for this entity. Routine is called when the entity is constructed. Implement in an entity
		/// class to set a particular entity authorizer object at construction time. Use this routine if you don't want to use
		/// LLBLGen Pro's build in dependency injection mechanism.
		/// </summary>
		/// <returns>ready to use authorizer</returns>
		/// <remarks>Users of the .NET compact framework can't use dependency injection and should use this method instead</remarks>
		protected virtual IAuthorizer CreateAuthorizer()
		{
			return null;
		}


		/// <summary>
		/// Creates the auditor object for this entity. Routine is called when the entity is constructed. Implement in an entity
		/// class to set a particular entity auditor object at construction time. Use this routine if you don't want to use
		/// LLBLGen Pro's build in dependency injection mechanism.
		/// </summary>
		/// <returns>ready to use auditor</returns>
		/// <remarks>Users of the .NET compact framework can't use dependency injection and should use this method instead</remarks>
		protected virtual IAuditor CreateAuditor()
		{
			return null;
		}


		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns>ready to use TypeDefaultvalueProvider</returns>
		protected virtual ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return null;
		}


		/// <summary>
		/// Creates the concurrency predicate factory for this entity. Routine is called from the entity constructor. Implement in an entity
		/// class to set a particular ConcurrentyPredicateFactory object at construction time. Use this routine if you don't want to use
		/// LLBLGen Pro's build in dependency injection mechanism.
		/// </summary>
		/// <returns>Ready to use ConcurrencyPredicateFactory</returns>
		/// <remarks>Users of the .NET compact framework can't use dependency injection and should use this method instead</remarks>
		protected virtual IConcurrencyPredicateFactory CreateConcurrencyPredicateFactory()
		{
			return null;
		}
		

		/// <summary>
		/// Performs the dependency injection of related objects. This method will call the Create* methods to create validator, concurrency predicate factory 
		/// and will then kick in the DependencyInjection functionality build into LLBLGen Pro. 
		/// This method is called at the end of an entity's InitClassMembers method in the generated code.
		/// </summary>
		/// <remarks>If a Validator object is already set for this entity, this method won't set the Validator property to a different object, this to 
		/// avoid breaking code written for previous versions of LLBLGen Pro.</remarks>
		protected virtual void PerformDependencyInjection()
		{
			if(_validator == null)
			{
				_validator = CreateValidator();
			}
			_concurrencyPredicateFactoryToUse = CreateConcurrencyPredicateFactory();
			_authorizerToUse = CreateAuthorizer();
			_auditorToUse = CreateAuditor();
#if !CF
			DependencyInjectionInfoProviderSingleton.PerformDependencyInjection(this);
#endif
		}


		/// <summary>
		/// Called when a property changed value. Call this method to signal databound controls a property has changed. 
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void OnPropertyChanged( string propertyName )
		{
			if( PropertyChanged != null )
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		/// <summary>
		/// Fixes deserialization empty references, because fieldinfo isn't serialized into the data.
		/// </summary>
		/// <param name="fieldProvider">The field provider.</param>
		/// <param name="persistenceProvider">The persistence provider.</param>
		protected void FixupDeserialization( IFieldInfoProvider fieldProvider, IPersistenceInfoProvider persistenceProvider )
		{
			// NO-OP
		}



		/// <summary>
		/// Checks if the current value of the field on the index specified is null / not defined. 
		/// </summary>
		/// <param name="fieldIndex">Index of the field.</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		protected virtual bool CheckIfCurrentFieldValueIsNull(int fieldIndex)
		{
			if(_isNew)
			{
				// a new entity field's value is null / not defined if it's not changed yet, or IF it's changed, it's set to null.
				return (!_fields[fieldIndex].IsChanged || ( _fields[fieldIndex].IsChanged && (_fields[fieldIndex].CurrentValue==null)));
			}
			else
			{
				// a non-new entity field's value is null / not defined if:
				// - it's not changed and original field value is null
				// - it's changed and the current value is null. 
				return ( (_fields[fieldIndex].IsChanged && (_fields[fieldIndex].CurrentValue==null)) ||
					(!_fields[fieldIndex].IsChanged && _fields[fieldIndex].IsNull));
			}
		}


		/// <summary>
		/// Gets the inheritance info for this entity, if applicable (it's then overriden) or null if not.
		/// </summary>
		/// <returns>InheritanceInfo object if this entity is in a hierarchy of type TargetPerEntity, or null otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual IInheritanceInfo GetInheritanceInfo()
		{
			return null;
		}

		
		/// <summary>
		/// Adds the internals to context. No-op in base class, overriden in generated code.
		/// </summary>
		protected virtual void AddInternalsToContext()
		{
		}
	

		/// <summary>
		/// A method to call OnPropertyChanged for all fields to signal that all fields have been changed
		/// to bound controls. This is required after a RollbackFields() call.
		/// </summary>
		protected virtual void FlagAllFieldsAsChanged()
		{
			foreach( IEntityField field in _fields )
			{
				OnPropertyChanged( field.Name );
			}
		}


		/// <summary>
		/// Method which is meant to be overriden to pre-process a value right before it is set as a field's new value. In general you don't need to override
		/// this method. By default it's a no-op.
		/// </summary>
		/// <param name="fieldToSet">The field to set.</param>
		/// <param name="valueToSet">The value to set.</param>
		protected virtual void PreProcessValueToSet( IEntityField fieldToSet, ref object valueToSet )
		{
			// nothing
		}


		/// <summary>
		/// Post-processes the value to return from GetValue. Override this method to be able to post-process any value to return from an entity field's property.
		/// </summary>
		/// <param name="fieldToGet">The field to get the value for.</param>
		/// <param name="valueToReturn">The value to return.</param>
		/// <remarks>It's recommended that you don't change the type of the value passed in. If you want to change the type, use a type-converter.</remarks>
		protected virtual void PostProcessValueToGet(IEntityField fieldToGet, ref object valueToReturn)
		{
			// nothing
		}


		/// <summary>
		/// Gets the value of the field with the index specified. 
		/// </summary>
		/// <param name="fieldIndex">Index of the field.</param>
		/// <param name="returnDefaultIfNull">helper flag which signals the routine if a default value should be obtained for the type of the field or not if 
		/// the value is null.</param>
		/// <returns>the value of the field</returns>
		/// <exception cref="ORMEntityOutOfSyncException">When the entity is out of sync and needs to be refetched first.</exception>
		/// <exception cref="ORMEntityIsDeletedException">When the entity is marked as deleted.</exception>
		/// <exception cref="ArgumentOutOfRangeException">When fieldIndex is smaller than 0 or bigger than the amount of fields in the fields collection.</exception>
		protected object GetValue(int fieldIndex, bool returnDefaultIfNull)
		{
			if(_fields == null)
			{
				return null;
			}

			if(_fields.State == EntityState.Deleted)
			{
				throw new ORMEntityIsDeletedException("This entity is deleted from the database and can't be used in logic.");
			}


			if((fieldIndex < 0) || (fieldIndex >= _fields.Count))
			{
#if !CF
				throw new ArgumentOutOfRangeException("fieldIndex", fieldIndex, "The field index passed is not a valid index in the fields collection of this entity.");
#else
				throw new ArgumentOutOfRangeException("The field index passed is not a valid index in the fields collection of this entity.");
#endif
			}

			CheckForRefetch();

			// check if the field is set to a value, if that's required. 
			if(EntityBase.MakeInvalidFieldReadsFatal && (_isNew && !_fields[fieldIndex].IsChanged && _fields[fieldIndex].CurrentValue == null))
			{
				// not set to a value, illegal.
				throw new ORMInvalidFieldReadException(string.Format("The field '{0}' at index {1} isn't set to a value yet, so reading its value leads to invalid results. ", _fields[fieldIndex].Alias, fieldIndex));
			}

			object valueToReturn = null;
			IEntityField field = _fields[fieldIndex];

			bool cancel = false;
			OnGetValue(fieldIndex, out cancel);
			if(!cancel)
			{
				valueToReturn = field.CurrentValue;
			}
			bool authorizerResult = OnCanGetFieldValue(fieldIndex);
			if(!authorizerResult)
			{
				// not allowed. Set to null
				valueToReturn = null;
			}
			if((valueToReturn == null) && returnDefaultIfNull)
			{
				ITypeDefaultValue providerToUse = _typeDefaultValueProvider;
				if(providerToUse == null)
				{
					providerToUse = CreateTypeDefaultValueProvider();
				}
				if(providerToUse != null)
				{
					valueToReturn = providerToUse.DefaultValue(field.DataType);
				}
			} 
			OnGetValueComplete(fieldIndex);
			if(authorizerResult)
			{
				OnAuditEntityFieldGet(fieldIndex);
			}
			PostProcessValueToGet(field, ref valueToReturn);
			return valueToReturn;
		}


		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <param name="checkForRefetch">If set to true, it will check if this entity is out of sync and will refetch it first if it is. Use true in normal
		/// behavior, false for framework specific code.</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the database
		/// or the index passed in is not in the fields range of valid indexes.</exception> 
		protected bool SetValue(int fieldIndex, object value, bool checkForRefetch)
		{
			return SetValue(fieldIndex, value, checkForRefetch, true);
		}


		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <param name="checkForRefetch">If set to true, it will check if this entity is out of sync and will refetch it first if it is. Use true in normal
		/// behavior, false for framework specific code.</param>
		/// <param name="performDesyncForFKFields">if set to true, it will call into the desync routine if the field with the index passed in is an FK field.</param>
		/// <returns>
		/// true if the value is actually set, false otherwise.
		/// </returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the database
		/// or the index passed in is not in the fields range of valid indexes.</exception>
		private bool SetValue(int fieldIndex, object value, bool checkForRefetch, bool performDesyncForFKFields)
		{
			if(_fields == null)
			{
				throw new NullReferenceException("A field's value is tried to be set, but there's no Fields object in this entity!");
			}

			if((fieldIndex < 0) || (fieldIndex >= _fields.Count))
			{
#if CF
				throw new ArgumentOutOfRangeException("The field index passed is not a valid index in the fields collection of this entity.");
#else
				throw new ArgumentOutOfRangeException("fieldIndex", fieldIndex, "The field index passed is not a valid index in the fields collection of this entity.");
#endif
			}

			if(checkForRefetch)
			{
				CheckForRefetch();
			}

			bool valueIsSet = false;
			object valueToSet = value;
			IEntityField fieldToSet = _fields[fieldIndex];
			object originalValue = fieldToSet.CurrentValue;
			// first call an overridable method which allows developers to mangle the value before it's set.
			PreProcessValueToSet(fieldToSet, ref valueToSet);

			bool cancel = false;
			OnSetValue(fieldIndex, valueToSet, out cancel);
			if(cancel)
			{
				// canceled, abort
				return false;
			}
			bool authorizerResult = OnCanSetFieldValue(fieldIndex);
			if(!authorizerResult)
			{
				// not allowed. 
				return false;
			}

			if(FieldUtilities.DetermineIfFieldShouldBeSet(fieldToSet, _isNew, valueToSet))
			{
				// set value is not the same as the value to set, proceed
				if(ValidateValue(fieldToSet, ref valueToSet, fieldIndex))
				{
					if(_editCycleInProgress)
					{
						// do not control the editing of the field's value with the field's edit cycle routines.
						fieldToSet.CurrentValue = valueToSet;
						_fields.IsChangedInThisEditCycle = true;
						_fields.IsDirty = true;
						valueIsSet = true;
					}
					else
					{
						try
						{
							fieldToSet.BeginEdit();
							fieldToSet.CurrentValue = valueToSet;
							fieldToSet.EndEdit();
							_fields.IsDirty = true;
							valueIsSet = true;
						}
						catch
						{
							fieldToSet.CancelEdit();
							throw;
						}
					}
				}
			}

			if(valueIsSet)
			{
				// audit set
				OnAuditEntityFieldSet(fieldIndex, originalValue);
				// signal change
				OnFieldValueChanged(originalValue, fieldToSet);
				if(fieldToSet.IsForeignKey && performDesyncForFKFields)
				{
					PerformDesyncSetupFKFieldChange(fieldIndex);
				} 
				PostFieldValueSetAction(valueIsSet, fieldToSet.Name);
				// clear an error message if applicable
				SetEntityFieldError(fieldToSet.Name, string.Empty, false);
			}

			OnSetValueComplete(fieldIndex);
			return valueIsSet;
		}
		

		/// <summary>
		/// Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync
		/// info will be removed.
		/// </summary>
		/// <param name="fieldindex">The fieldindex.</param>
		/// <remarks>Method is implemented in generated code.</remarks>
		protected virtual void PerformDesyncSetupFKFieldChange(int fieldindex)
		{
			// nop
		}


		/// <summary>
		/// Called right at the beginning of GetValue(), which is called from an entity field property getter
		/// </summary>
		/// <param name="fieldIndex">Index of the field to get.</param>
		/// <param name="cancel">if set to true, the getvalue is cancelled and null is returned instead.</param>
		protected virtual void OnGetValue(int fieldIndex, out bool cancel)
		{
			cancel = false;
		}


		/// <summary>
		/// Called right at the end of GetValue(), which is called from an entity field property getter
		/// </summary>
		/// <param name="fieldIndex">Index of the field to get.</param>
		protected virtual void OnGetValueComplete(int fieldIndex)
		{
			// nop
		}


		/// <summary>
		/// Called right at the beginning of SetValue(), which is called from an entity field property setter
		/// </summary>
		/// <param name="fieldIndex">Index of the field to set.</param>
		/// <param name="valueToSet">The value to set.</param>
		/// <param name="cancel">if set to true, the setvalue is cancelled and the set action is terminated</param>
		protected virtual void OnSetValue(int fieldIndex, object valueToSet, out bool cancel)
		{
			cancel = false;
		}


		/// <summary>
		/// Called right at the end of SetValue(), which is called from an entity field property setter
		/// </summary>
		/// <param name="fieldIndex">Index of the field to set.</param>
		protected virtual void OnSetValueComplete(int fieldIndex)
		{
			// nop
		}


		/// <summary>
		/// Called right before the entity's save logic is started. This is right after all entities this entity depends on are saved succesfully.
		/// </summary>
		protected virtual void OnSave()
		{
		}


		/// <summary>
		/// Called after the entity's save routine is finished.
		/// </summary>
		protected virtual void OnSaveComplete()
		{
		}


		/// <summary>
		/// Called right before the entity's Delete logic is started. 
		/// </summary>
		protected virtual void OnDelete()
		{
		}


		/// <summary>
		/// Called after the entity's delete routine is finished.
		/// </summary>
		protected virtual void OnDeleteComplete()
		{
		}


		/// <summary>
		/// Called right before the entity's Fetch logic is started. 
		/// </summary>
		protected virtual void OnFetch()
		{
		}


		/// <summary>
		/// Called after the entity's Fetch routine is finished.
		/// </summary>
		protected virtual void OnFetchComplete()
		{
		}



		/// <summary>
		/// Called after the TransactionCommit routine has been finished.
		/// </summary>
		protected virtual void OnTransactionCommit()
		{
		}


		/// <summary>
		/// Called after the TransactionRollback routine has been finished.
		/// </summary>
		protected virtual void OnTransactionRollback()
		{
		}


		/// <summary>
		/// Called after BeginEdit is succesfully called.
		/// </summary>
		protected virtual void OnBeginEdit()
		{
		}


		/// <summary>
		/// Called after EndEdit is succesfully called.
		/// </summary>
		protected virtual void OnEndEdit()
		{
		}

		
		/// <summary>
		/// Called after CancelEdit is succesfully called.
		/// </summary>
		protected virtual void OnCancelEdit()
		{
		}


		/// <summary>
		/// Method which is called right after a field's value has been changed. There are a couple of methods called in the process of setting a 
		/// field's value. This particular method is solely there to act on a field's value set action. It doesn't 
		/// raise an event, though it receives the old and new value of the field. Not called if a fieldvalue set action failed. This method is 
		/// called before changed events are raised. 
		/// </summary>
		/// <param name="originalValue">The original value of the field, can be null if the field didn't have a value.</param>
		/// <param name="field">The field which value was set.</param>
		/// <remarks>In an override, cast the field's fieldindex to the fieldindex of the entity to quickly determine which field you're dealing with</remarks>
		protected virtual void OnFieldValueChanged( object originalValue, IEntityField field )
		{
			// nop.
		}


		/// <summary>
		/// Method which is called at the end of the SetRelatedEntity() routine. Usable to act on the fact that a related entity has been set.
		/// </summary>
		/// <param name="relatedEntity">The related entity.</param>
		/// <param name="fieldName">Name of the field mapped onto the relation which resolves to the instance relatedEntity</param>
		protected virtual void OnRelatedEntitySet( IEntity relatedEntity, string fieldName )
		{
			// nop.
		}


		/// <summary>
		/// Method which is called at the end of the UnsetRelatedEntity() routine. Usable to act on the fact that an entity has been 
		/// dereferenced as a related entity by the containing entity.
		/// </summary>
		/// <param name="relatedEntity">The related entity.</param>
		/// <param name="fieldName">Name of the field mapped onto the relation which resolves to the instance relatedEntity</param>
		protected virtual void OnRelatedEntityUnset( IEntity relatedEntity, string fieldName )
		{
			// nop.
		}


		/// <summary>
		/// Called at the start of the initialization routine. Raises Initializing event.
		/// </summary>
		protected virtual void OnInitializing()
		{
			if( Initializing != null )
			{
				Initializing( this, new EventArgs() );
			}
		}


		/// <summary>
		/// Called at the end of the initialization routine. Raises Initialized event.
		/// </summary>
		protected virtual void OnInitialized()
		{
			if( Initialized != null )
			{
				Initialized( this, new EventArgs() );
			}
		}


		/// <summary>
		/// Called when InitClassMembers is complete. 
		/// </summary>
		protected virtual void OnInitClassMembersComplete()
		{ 
			// nop
		}


		/// <summary>
		/// Called at the end of GetObjectData. Method is used when this object is serialized. Override this method to 
		/// tap into the serialization sequence. (binary/soap formatter specific).
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected virtual void OnGetObjectData( SerializationInfo info, StreamingContext context )
		{
			// nop
		}


		/// <summary>
		/// Called at the end of the deserialization constructor. Method is used when this object is deserialized. Override this method to 
		/// tap into the deserialization sequence. (binary/soap formatter specific).
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected virtual void OnDeserialized( SerializationInfo info, StreamingContext context )
		{
			// nop
		}
		

		/// <summary>
		/// Returns the FetchNewAuthorizationFailureResultHint as returned by the authorizer. Only called when the CanGetLoad failed (authorization failed, so load was denied)
		/// </summary>
		/// <returns>any of the FetchNewAuthorizationFailureResultHint values</returns>
		protected virtual FetchNewAuthorizationFailureResultHint OnGetFetchNewAuthorizationFailureResultHint()
		{
			FetchNewAuthorizationFailureResultHint toReturn = FetchNewAuthorizationFailureResultHint.ThrowAway;
			if(_authorizerToUse != null)
			{
				toReturn = _authorizerToUse.GetFetchNewAuthorizationFailureResultHint();
			}

			return toReturn;
		}
		

		/// <summary>
		/// Method which returns true if this auditor expects to have audit entities to persist and therefore needs a transaction.
		/// This method is called in the situation when there's no transaction going on though one should be started right before the single-statement action
		/// in the case if the auditor has entities to save afterwards. It's recommended to return true if the auditor might have audit entities
		/// to persist after an entity save/delete/direct update/direct delete of entities. Default: false
		/// </summary>
		/// <param name="actionToStart">The single statement action which is about to be started.</param>
		/// <returns>
		/// true if a transaction should be started prior to the action to perform (entity save/delete/direct update/direct delete of entities)
		/// false otherwise.
		/// </returns>
		/// <remarks>If false is returned and GetAuditEntitiesToSave returns 1 or more entities, a new transaction is started to save these audit entities
		/// which means that this transaction isn't re-tryable if this transaction might fail.</remarks>
		protected virtual bool OnRequiresTransactionForAuditEntities(SingleStatementQueryAction actionToStart)
		{
			bool toReturn = false;
			if(_auditorToUse != null)
			{
				toReturn = _auditorToUse.RequiresTransactionForAuditEntities(actionToStart);
			}
			return toReturn;
		}


		/// <summary>
		/// Audits when an entity field's value is succesfully obtained from the passed in entity
		/// </summary>
		/// <param name="fieldIndex">Index of the field which value was obtained.</param>
		/// <remarks>Be careful when using this auditing routine, because a lot of calls will be made to this routine when data is for example shown in
		/// a grid. Another thing to realize is that the audit information is stored inside the auditor which is inside an entity which might not be
		/// persisted/deleted later on. This means that if you use the audit data to produce entities which are then returned by GetAuditEntitiesToSave
		/// are never persisted if the entity this auditor is the auditor of is never persisted/deleted. In that situation, to get reliable journalling,
		/// use an external service to log the audit data.</remarks>
		protected virtual void OnAuditEntityFieldGet(int fieldIndex)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditEntityFieldGet(this, fieldIndex);
			}
		}


		/// <summary>
		/// Audits when an entity field is set succesfully to a new value.
		/// </summary>
		/// <param name="fieldIndex">Index of the field which got a new value.</param>
		/// <param name="originalValue">The original value of the field with the index passed in before it received a new value.</param>
		protected virtual void OnAuditEntityFieldSet(int fieldIndex, object originalValue)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditEntityFieldSet(this, fieldIndex, originalValue);
			}
		}


		/// <summary>
		/// Audits the successful dereference of related entity from the entity passed in.
		/// </summary>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was dereferenced.</param>
		public virtual void OnAuditDereferenceOfRelatedEntity(IEntityCore relatedEntity, string mappedFieldName)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditDereferenceOfRelatedEntity(this, relatedEntity, mappedFieldName);
			}
		}


		/// <summary>
		/// Audits the successful reference of related entity from the entity passed in.
		/// </summary>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was referenced.</param>
		public virtual void OnAuditReferenceOfRelatedEntity(IEntityCore relatedEntity, string mappedFieldName)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditReferenceOfRelatedEntity(this, relatedEntity, mappedFieldName);
			}
		}


		/// <summary>
		/// Audits the successful insert of a new entity into the database.
		/// </summary>
		public virtual void OnAuditInsertOfNewEntity()
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditInsertOfNewEntity(this);
			}
		}


		/// <summary>
		/// Audits the successful update of an existing entity in the database
		/// </summary>
		public virtual void OnAuditUpdateOfExistingEntity()
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditUpdateOfExistingEntity(this);
			}
		}


		/// <summary>
		/// Audits the succesful direct update of entities in the database.
		/// </summary>
		/// <param name="filter">The filter to filter out the entities to update. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesUpdated">The number of entities updated.</param>
		public virtual void OnAuditDirectUpdateOfEntities(IPredicate filter, IRelationCollection relations, int numberOfEntitiesUpdated)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditDirectUpdateOfEntities(this, filter, relations, numberOfEntitiesUpdated);
			}
		}


		/// <summary>
		/// Audits the successful delete of an entity from the database
		/// </summary>
		/// <remarks>As the entity passed in was deleted succesfully, reading values from the passed in entity is only possible in this routine. After this call, the
		/// state of the entity will be reset to Deleted again and reading the fields will result in an exception. It's also recommended not to reference
		/// the passed in entity in any audit entity you might want to persist as the entity doesn't exist anymore in the database.</remarks>
		public virtual void OnAuditDeleteOfEntity()
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditDeleteOfEntity(this);
			}
		}


		/// <summary>
		/// Audits the successful load of an entity from the database
		/// </summary>
		/// <remarks>Be careful when using this auditing routine, because the audit information is stored inside the auditor which is inside an entity 
		/// which might not be persisted/deleted later on. This means that if you use the audit data to produce entities which are then 
		/// returned by GetAuditEntitiesToSave are never persisted if the entity this auditor is the auditor of is never persisted/deleted. 
		/// In that situation, to get reliable journalling, use an external service to log the audit data.</remarks>
		public virtual void OnAuditLoadOfEntity()
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditLoadOfEntity(this);
			}
		}


		/// <summary>
		/// Audits the successful direct delete of entities in the database
		/// </summary>
		/// <param name="filter">The filter to filter out the entities to delete. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesDeleted">The number of entities deleted.</param>
		public virtual void OnAuditDirectDeleteOfEntities(IPredicate filter, IRelationCollection relations, int numberOfEntitiesDeleted)
		{
			if(_auditorToUse != null)
			{
				_auditorToUse.AuditDirectDeleteOfEntities(this.GetType(), filter, relations, numberOfEntitiesDeleted);
			}
		}


		/// <summary>
		/// Method which will check if the caller is allowed to get the field value with the index specified.
		/// </summary>
		/// <param name="fieldIndex">Index of the field of which the value has to be obtained.</param>
		/// <returns>true if the caller is allowed to obtain the value for the field specified.</returns>
		protected virtual bool OnCanGetFieldValue(int fieldIndex)
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanGetFieldValue(this, fieldIndex);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to set the field value with the index specified.
		/// </summary>
		/// <param name="fieldIndex">Index of the field of which the value has to be set.</param>
		/// <returns>true if the caller is allowed to set the value for the field specified.</returns>
		protected virtual bool OnCanSetFieldValue(int fieldIndex)
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanSetFieldValue(this, fieldIndex);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to fill this entity object with entity data from the database or not.
		/// </summary>
		/// <returns>true if the caller is allowed to load the data into this instance, otherwise false.</returns>
		protected virtual bool OnCanLoadEntity()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanLoadEntity(this);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to save this new entity object
		/// </summary>
		/// <returns>true if the caller is allowed to save this new entity, otherwise false.</returns>
		protected virtual bool OnCanSaveNewEntity()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanSaveNewEntity(this);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to save this existing entity object
		/// </summary>
		/// <returns>true if the caller is allowed to save this existing entity, otherwise false.</returns>
		protected virtual bool OnCanSaveExistingEntity()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanSaveExistingEntity(this);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to update entities directly in the database. 
		/// </summary>
		/// <returns>true if the caller is allowed to update entities directly in the database, otherwise false.</returns>
		protected virtual bool OnCanBatchUpdateEntitiesDirectly()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanBatchUpdateEntitiesDirectly(this);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to delete entities directly in the database. 
		/// </summary>
		/// <returns>true if the caller is allowed to delete entities directly in the database, otherwise false.</returns>
		protected virtual bool OnCanBatchDeleteEntitiesDirectly()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanBatchDeleteEntitiesDirectly(this.GetType());
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will check if the caller is allowed to delete this existing entity object
		/// </summary>
		/// <returns>true if the caller is allowed to delete this existing entity, otherwise false.</returns>
		protected virtual bool OnCanDeleteEntity()
		{
			bool returnValue = true;
			if(_authorizerToUse != null)
			{
				returnValue = _authorizerToUse.CanDeleteEntity(this);
			}
			return returnValue;
		}


		/// <summary>
		/// Method which will validate, using custom code supplied this class, the field with index fieldIndex if it should accept
		/// the specified value. This routine is only called when standard checks already succeeded, so value isn't null, and value does match the
		/// destination column definition of the EntityField related to fieldIndex.
		/// </summary>
		/// <param name="fieldIndex">Index of field to validate</param>
		/// <param name="value">value to validate</param>
		/// <returns>True if the validation succeeded, false otherwise.</returns>
		protected virtual bool OnValidateFieldValue( int fieldIndex, object value )
		{
			bool returnValue = true;
			if( _validator != null )
			{
				returnValue = _validator.ValidateFieldValue(this, fieldIndex, value );
			}
			return returnValue;
		}

		
		/// <summary>
		/// Method to validate the containing entity after it is loaded. This method is called after the entity has been fully loaded.
		/// </summary>
		protected virtual void OnValidateEntityAfterLoad()
		{
			if( _validator != null )
			{
				_validator.ValidateEntityAfterLoad(this);
			}
		}


		/// <summary>
		/// Method to validate the containing entity right before the save sequence for the entity will start. LLBLGen Pro will call this method right after the
		/// containing entity is selected from the save queue to be saved.
		/// </summary>
		protected virtual void OnValidateEntityBeforeSave()
		{
			if( _validator != null )
			{
				_validator.ValidateEntityBeforeSave(this);
			}
		}


		/// <summary>
		/// Method to validate the containing entity right after the entity's save action has been completed and the entity has been refetched (if applicable). 
		/// Note for adapter users: if the entity wasn't set to be refetched, take into account that reading properties from the containing entity will result in an
		/// OutOfSync exception.
		/// </summary>
		protected virtual void OnValidateEntityAfterSave()
		{
			if( _validator != null )
			{
				_validator.ValidateEntityAfterSave(this);
			}
		}


		/// <summary>
		/// Method to validate the containig entity right beforethe entity's delete action will take place. 
		/// </summary>
		protected virtual void OnValidateEntityBeforeDelete()
		{
			if( _validator != null )
			{
				_validator.ValidateEntityBeforeDelete(this);
			}
		}


		/// <summary>
		/// Routine which is used by the generated code to set _alreadyFetched* flags after a ReadXml() action on this entity instance.
		/// </summary>
		protected virtual void PostReadXmlFixups()
		{ 
			// none.
		}


		/// <summary>
		/// Method to perform post-fieldvalue set actions, like flagging this object as changed.
		/// This code was previously part of SetNewFieldValue, but the timing to fire the changed event was then not controllable.
		/// </summary>
		/// <param name="fieldValueSet">Field value set flag. If false, nothing happens in this method.</param>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void PostFieldValueSetAction(bool fieldValueSet, string propertyName)
		{
			if(!fieldValueSet)
			{
				return;
			}

			// if in edit cycle, always postpone the entity changed event till it's completed.
			if( _editCycleInProgress )
			{
				// edit cycle in progress, hold the signal till endedit is called
				_pendingChangedEvent = true;
			}
			else
			{
				// fire the EntityContentsChanged event, if there are subscribers. 
				FlagMeAsChanged();
			}

			// notify that a property has been changed
			OnPropertyChanged( propertyName );
		}


		/// <summary>
		/// Synchronizes the PK values of the dataSupplier with the related FK values of this entity.
		/// </summary>
		/// <param name="syncInfo">Sync info with the information which to synch with what.</param>
		protected virtual void SyncFKFields(EntitySyncInfo<IEntity> syncInfo)
		{
			IEntityRelation relation = syncInfo.Relation;
			IEntity dataSupplier = syncInfo.DataSupplyingEntity;

			TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.SyncFKFields", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.StateManagementSwitch.TraceVerbose, GetEntityDescription(TraceHelper.StateManagementSwitch.TraceVerbose), "Active Entity Description");
			TraceHelper.WriteIf(TraceHelper.StateManagementSwitch.TraceVerbose, GetEntityDescription(TraceHelper.StateManagementSwitch.TraceVerbose, dataSupplier), "Data Supplying Entity Description");

			if(dataSupplier==null)
			{
				// nothing to sync
				TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.SyncFKFields: nothing to sync.", "Method Exit");
				return;
			}

			// walk the fields in the relation and store data from the dataSupplier into the fields of this entity.
			bool fieldChanged = false;
			string fieldName = string.Empty;
			for (int i = 0; i < relation.AmountFields; i++)
			{
				if(! (_fields[relation.GetFKEntityFieldCore(i).Name].IsPrimaryKey && !_isNew) )
				{
					// we're syncing a field which is not a PK or a PK field and we're new
					string fkFieldName = relation.GetFKEntityFieldCore(i).Name;
					string pkFieldName = relation.GetPKEntityFieldCore(i).Name;
					bool setValue = true;
					IEntityField field = _fields[fkFieldName];
					if(field.CurrentValue!=null)
					{
						setValue = ((!FieldUtilities.ValuesAreEqual(field.CurrentValue, dataSupplier.Fields[pkFieldName].CurrentValue) && !_isNew) || _isNew);
					}
					if( dataSupplier.IsNew )
					{
						// only sync new PK sides with FKs if the PK field is changed and not NULL.
						setValue &= (dataSupplier.Fields[pkFieldName].IsChanged && dataSupplier.Fields[pkFieldName].CurrentValue != null);
					}
					if(setValue)
					{
						// store fieldname for event later on.
						fieldName = fkFieldName;

						if( field.IsReadOnly )
						{
							field.ForcedCurrentValueWrite( dataSupplier.Fields[pkFieldName].CurrentValue );
							field.IsChanged=true;
						}
						else
						{
							field.CurrentValue = dataSupplier.Fields[pkFieldName].CurrentValue;
						}
						// clear an error message if applicable
						SetEntityFieldError(fieldName, string.Empty, false);
						// set IsDirty flag
						_fields.IsDirty=true;
						fieldChanged = true;
						TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, String.Format("\tSyncing FK field {0} with PK field {1}", fkFieldName, pkFieldName));
					}
				}
			}

			if(fieldChanged)
			{
				OnPropertyChanged( fieldName );

				syncInfo.Used = true;
				FlagMeAsChanged();
			}

			TraceHelper.WriteLineIf(TraceHelper.StateManagementSwitch.TraceVerbose, "EntityBase.SyncFKFields", "Method Exit");
		}


		/// <summary> Event handler which is called by a related entity after that entity is persisted.</summary>
		/// <param name="sender">IEntity instance</param>
		/// <param name="e"></param>
		protected void OnEntityAfterSave(object sender, EventArgs e)
		{
			IEntity persistedEntity = (IEntity)sender;
			List<EntitySyncInfo<IEntity>> entitySyncInfos = new List<EntitySyncInfo<IEntity>>(GetEntitySyncInformation(persistedEntity).Values);
			for (int i = 0; i < entitySyncInfos.Count; i++)
			{
				SyncFKFields(entitySyncInfos[i]);
			}
		}


		/// <summary>
		/// Will retrieve all stored entity synchronization information for the passed in entity. If no information is
		/// stored, an empty hashtable is returned. All sync info is stored by fieldname
		/// </summary>
		/// <param name="relatedEntity">related entity to retrieve the sync info for</param>
		/// <returns>Hashtable with the sync info, stored per fieldname, set for this entity</returns>
		protected virtual Dictionary<string, EntitySyncInfo<IEntity>> GetEntitySyncInformation( IEntity relatedEntity )
		{
			if(_relatedEntitySyncInfos.ContainsKey(relatedEntity.ObjectID))
			{
				return _relatedEntitySyncInfos[relatedEntity.ObjectID];
			}
			else
			{
				// not found.
				return new Dictionary<string, EntitySyncInfo<IEntity>>();
			}
		}


		/// <summary>
		/// Will unset (remove) the passed in information as Entity sync information. If there is no sync information stored for the related entity
		/// after this info has been removed, the complete hashentry is removed.
		/// </summary>
		/// <param name="fieldName">Name of field of this entity mapped onto passed in relation</param>
		/// <param name="relatedEntity">related entity set as value for field with name fieldName</param>
		/// <param name="relation">EntityRelation object which is the relation between this entity and the passed in relatedEntity</param>
		protected virtual void UnsetEntitySyncInformation(string fieldName, IEntity relatedEntity, IEntityRelation relation)
		{
			Dictionary<string, EntitySyncInfo<IEntity>> entitySyncInfos = null;

			if(!_field2RelatedEntity.ContainsKey(fieldName))
			{
				// no, nothing to unset
				return;
			}

			Guid setRelatedEntityObjectID = (Guid)_field2RelatedEntity[fieldName];

			if( setRelatedEntityObjectID == relatedEntity.ObjectID)
			{
				// this entity is set as the related entity. remove sync info
				entitySyncInfos = _relatedEntitySyncInfos[setRelatedEntityObjectID];
				// remove the sync info for the field
				entitySyncInfos.Remove(fieldName);
				// remove fieldname - objectid
				_field2RelatedEntity.Remove(fieldName);
			}
		}


		/// <summary>
		/// Will set the passed in information as Entity sync information. If there is no sync information stored yet for the related entity
		/// then a new entry is created, otherwise it's info is added to the sync information of this entity, if it isn't already present.
		/// If there is already sync information for this field stored for another related entity, that information is removed.
		/// </summary>
		/// <param name="fieldName">Name of field of this entity mapped onto passed in relation</param>
		/// <param name="relatedEntity">related entity set as value for field with name fieldName</param>
		/// <param name="relation">EntityRelation object which is the relation between this entity and the passed in relatedEntity</param>
		protected virtual void SetEntitySyncInformation(string fieldName, IEntity relatedEntity, IEntityRelation relation)
		{
			FastDictionary<string, EntitySyncInfo<IEntity>> entitySyncInfos = null;
			EntitySyncInfo<IEntity> syncInfo = null;

			// first check if there is already sync info for this fieldname
			if(_field2RelatedEntity.ContainsKey(fieldName))
			{
				// yes. Check if it's about the passed in entity
				Guid setRelatedEntityObjectID = _field2RelatedEntity[fieldName];
				entitySyncInfos = _relatedEntitySyncInfos[setRelatedEntityObjectID];
				if(relatedEntity==null)
				{
					// no, remove the sync info for this entity for the field-relation combination
					// remove the sync info for the field
					entitySyncInfos.Remove(fieldName);
					// remove fieldname - objectid
					_field2RelatedEntity.Remove(fieldName);
					// done
					return;
				}

				if( setRelatedEntityObjectID != relatedEntity.ObjectID)
				{
					// no, remove the sync info for this entity for the field-relation combination
					// remove the sync info for the field
					entitySyncInfos.Remove(fieldName);
					// remove fieldname - objectid
					_field2RelatedEntity.Remove(fieldName);
					// continue with routine as normal. 
				}
				else
				{
					// already stored. find it.
					syncInfo = entitySyncInfos[fieldName];
				}
			}

			if(syncInfo==null)
			{
				// add new one

				// check if there is already a bucket for sync infos for this entity
				if(_relatedEntitySyncInfos.ContainsKey(relatedEntity.ObjectID))
				{
					// yes.
					entitySyncInfos = _relatedEntitySyncInfos[relatedEntity.ObjectID];
				}
				else
				{
					// no
					entitySyncInfos = new FastDictionary<string, EntitySyncInfo<IEntity>>();
					_relatedEntitySyncInfos.Add(relatedEntity.ObjectID, entitySyncInfos);
				}

				// there is no sync info for this field present, add the combi first
				_field2RelatedEntity.Add(fieldName, relatedEntity.ObjectID);

				// Create sync info
				syncInfo = new EntitySyncInfo<IEntity>();
				syncInfo.DataSupplyingEntity = relatedEntity;
				syncInfo.Relation = relation;
				entitySyncInfos.Add(fieldName, syncInfo);
			}

			// sync now
			SyncFKFields(syncInfo);
		}


		/// <summary>
		/// Performs the desetup of the sync info related to the relatedentity passed in
		/// </summary>
		/// <param name="relatedEntity">The related entity.</param>
		/// <param name="propertiesChangedHandler">The properties changed handler.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="relation">The relation.</param>
		/// <param name="disconnectFromSaveEvent">if set to <c>true</c> [disconnect from save event].</param>
		/// <param name="signalRelatedEntity">if set to true, it will signal the related entity that it's been dereferenced by calling it's UnsetRelatedEntity
		/// method. If the relation is a m:1 relation, the related entity is told not to signal us back IF resetFKFields is false. 
		/// This is a special case because the 1:n location is in a collection and by telling the related entity not to signal us back, the related 
		/// entity will use a silent remove on the collection, otherwise the remove is done by the public Remove method which will always signal us back. THe
		/// resetFKFields flag signals that this call originates from a location where FK fields are written manually, and the signal back from the related
		/// entity will do that again, if performed, hence the special case.</param>
		/// <param name="fieldInRelatedEntity">The field in related entity.</param>
		/// <param name="resetFKFields">if set to <c>true</c> [reset FK fields].</param>
		/// <param name="fkFieldIndexes">The fk field indexes.</param>
		protected void PerformDesetupSyncRelatedEntity( IEntity relatedEntity, PropertyChangedEventHandler propertiesChangedHandler, string fieldName,
			IEntityRelation relation, bool disconnectFromSaveEvent, bool signalRelatedEntity, string fieldInRelatedEntity, bool resetFKFields, 
			int[] fkFieldIndexes )
		{
			if( relatedEntity != null )
			{
				relatedEntity.PropertyChanged -= propertiesChangedHandler;
				if( disconnectFromSaveEvent )
				{
					relatedEntity.AfterSave -= new EventHandler( OnEntityAfterSave );
					UnsetEntitySyncInformation( fieldName, relatedEntity, relation );
				}
				if( signalRelatedEntity )
				{
					if( !resetFKFields && (relation.TypeOfRelation == RelationType.ManyToOne) )
					{
						relatedEntity.UnsetRelatedEntity( this, fieldInRelatedEntity, false );
					}
					else
					{
						relatedEntity.UnsetRelatedEntity( this, fieldInRelatedEntity, true );
					}
				}
				if( resetFKFields )
				{
					foreach( int index in fkFieldIndexes )
					{
						SetValue( index, null, false, false);
					}
				}
				// audit dereference
				OnAuditDereferenceOfRelatedEntity(relatedEntity, fieldName);
			}
		}


		/// <summary>
		/// Performs the setup sync related entity.
		/// </summary>
		/// <param name="relatedEntity">The related entity.</param>
		/// <param name="propertiesChangedHandler">The properties changed handler.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="relation">The relation.</param>
		/// <param name="connectToSaveEvent">if set to <c>true</c> [connect to save event].</param>
		/// <param name="alreadyFetchedFlag">The already fetched flag.</param>
		/// <param name="forfNames">The forf names.</param>
		protected void PerformSetupSyncRelatedEntity( IEntity relatedEntity, PropertyChangedEventHandler propertiesChangedHandler,
				string fieldName, IEntityRelation relation, bool connectToSaveEvent, ref bool alreadyFetchedFlag, string[] forfNames )
		{
			if( relatedEntity != null )
			{
				relatedEntity.ActiveContext = this.ActiveContext;
				alreadyFetchedFlag = true;
				if( connectToSaveEvent )
				{
					relatedEntity.AfterSave += new EventHandler( OnEntityAfterSave );
					SetEntitySyncInformation( fieldName, relatedEntity, relation );
				}
				relatedEntity.PropertyChanged += propertiesChangedHandler;
				foreach( string forfName in forfNames )
				{
					OnPropertyChanged( forfName );
				}
				if(!IsDeserializing)
				{
					// audit reference
					OnAuditReferenceOfRelatedEntity(relatedEntity, fieldName);
				}
			}
			else
			{
				alreadyFetchedFlag = false;
			}
		}


		/// <summary>
		/// Checks if lazy loading should occur for the relation passed in and the FK fields in this entity for the relation 
		/// Routine is used by GetSingle... lazy loaders in selfservicing entities.
		/// </summary>
		/// <param name="relation">The relation. Is 1:1 or m:1 relation</param>
		/// <returns>
		/// If lazy loading should take place, true is returned, otherwise false. True is returned if the fk fields aren't null.
		/// </returns>
		protected bool CheckIfLazyLoadingShouldOccur( IEntityRelation relation )
		{
			bool fkFieldsAreValid = true;

			List<IEntityFieldCore> fieldsToCheck = null;
			switch(relation.TypeOfRelation)
			{
				case RelationType.OneToOne:
					if(relation.StartEntityIsPkSide)
					{
						fieldsToCheck = relation.GetAllPKEntityFieldCoreObjects();
					}
					else
					{
						fieldsToCheck = relation.GetAllFKEntityFieldCoreObjects();
					}
					break;
				case RelationType.ManyToOne:
					fieldsToCheck = relation.GetAllFKEntityFieldCoreObjects();
					break;
				default:
					throw new InvalidOperationException("This routine can't be called with a relation of type: " + relation.TypeOfRelation.ToString());
			}

			foreach( IEntityFieldCore field in fieldsToCheck )
			{
				// field is invalid if it's null. 
				fkFieldsAreValid &= !CheckIfCurrentFieldValueIsNull( field.FieldIndex );
			}

			return fkFieldsAreValid;
		}



		/// <summary>
		/// Calls CheckIfCurrentFieldValueIsNull which is a protected method, but also useful for internal interpretation code. 
		/// </summary>
		/// <param name="fieldIndex"></param>
		/// <returns></returns>
		internal bool CallCheckIfCurrentFieldValueIsNull( int fieldIndex )
		{
			return CheckIfCurrentFieldValueIsNull( fieldIndex );
		}


		/// <summary>
		/// Calls the OnFetchComplete routine, which is a protected routine. This method is used by the DaoBase multi-entity fetch logic
		/// </summary>
		internal void CallOnFetchComplete()
		{
			OnFetchComplete();
		}


		/// <summary>
		/// Calls the OnSave routine, which is a protected routine. 
		/// </summary>
		internal void CallOnSave()
		{
			OnSave();
		}


		/// <summary>
		/// Calls the OnSaveComplete routine, which is a protected routine. 
		/// </summary>
		internal void CallOnSaveComplete()
		{
			OnSaveComplete();
		}


		/// <summary>
		/// Calls OnGetFetchNewAuthorizationFailureResultHint on the authorizer. Only called when the CanGetLoad failed (authorization failed, so load was denied)
		/// </summary>
		/// <returns>any of the FetchNewAuthorizationFailureResultHint values</returns>
		internal FetchNewAuthorizationFailureResultHint CallOnGetFetchNewAuthorizationFailureResultHint()
		{
			return OnGetFetchNewAuthorizationFailureResultHint();
		}


		/// <summary>
		/// Calls the OnRequiresTransactionForAuditEntities routine
		/// </summary>
		/// <param name="actionToStart">The action to start.</param>
		/// <returns></returns>
		internal bool CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction actionToStart)
		{
			return OnRequiresTransactionForAuditEntities(actionToStart);
		}


		/// <summary>
		/// calls the OnAuditDirectDeleteOfEntities routine
		/// </summary>
		/// <param name="filter">The filter to filter out the entities to delete. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesDeleted">The number of entities deleted.</param>
		internal void CallOnAuditDirectDeleteOfEntities(IPredicate filter, IRelationCollection relations, int numberOfEntitiesDeleted)
		{
			OnAuditDirectDeleteOfEntities(filter, relations, numberOfEntitiesDeleted);
		}


		/// <summary>
		/// calls the OnAuditDirectUpdateOfEntities routine
		/// </summary>
		/// <param name="filter">The filter to filter out the entities to update. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesUpdated">The number of entities updated.</param>
		internal void CallOnAuditDirectUpdateOfEntities(IPredicate filter, IRelationCollection relations, int numberOfEntitiesUpdated)
		{
			OnAuditDirectUpdateOfEntities(filter, relations, numberOfEntitiesUpdated);
		}


		/// <summary>
		/// Calls the OnAuditLoadOfEntity() routine.
		/// </summary>
		internal void CallOnAuditLoadOfEntity()
		{
			OnAuditLoadOfEntity();
		}


		/// <summary>
		/// Calls the OnAuditInsertOfNewEntity routine.
		/// </summary>
		internal void CallOnAuditInsertOfNewEntity()
		{
			OnAuditInsertOfNewEntity();
		}


		/// <summary>
		/// Calls the OnAuditUpdateOfExistingEntity routine.
		/// </summary>
		internal void CallOnAuditUpdateOfExistingEntity()
		{
			OnAuditUpdateOfExistingEntity();
		}


		/// <summary>
		/// Calls the OnCanSaveNewEntity routine for this entity
		/// </summary>
		/// <returns>the result of OnCanSaveNewEntity</returns>
		internal bool CallOnCanSaveNewEntity()
		{
			return OnCanSaveNewEntity();
		}


		/// <summary>
		/// Calls the OnCanSaveExistingEntity routine for this entity
		/// </summary>
		/// <returns>the result of OnCanSaveExistingEntity</returns>
		internal bool CallOnCanSaveExistingEntity()
		{
			return OnCanSaveExistingEntity();
		}


		/// <summary>
		/// Calls the OnCanBatchUpdateEntitiesDirectly routine for this entity
		/// </summary>
		/// <returns>the result of OnCanBatchUpdateEntitiesDirectly</returns>
		internal bool CallOnCanBatchUpdateEntitiesDirectly()
		{
			return OnCanBatchUpdateEntitiesDirectly();
		}


		/// <summary>
		/// Calls the OnCanBatchDeleteEntitiesDirectly routine for this entity
		/// </summary>
		/// <returns>the result of OnCanBatchDeleteEntitiesDirectly</returns>
		internal bool CallOnCanBatchDeleteEntitiesDirectly()
		{
			return OnCanBatchDeleteEntitiesDirectly();
		}


		/// <summary>
		/// Calls the OnCanDeleteEntity routine for this entity
		/// </summary>
		/// <returns>the result of OnCanDeleteEntity</returns>
		internal bool CallOnCanDeleteEntity()
		{
			return OnCanDeleteEntity();
		}


		/// <summary>
		/// Calls the insert entity.
		/// </summary>
		internal bool CallInsertEntity()
		{
			return InsertEntity();
		}


		/// <summary>
		/// Calls the update entity.
		/// </summary>
		/// <returns></returns>
		internal bool CallUpdateEntity()
		{
			return UpdateEntity();
		}


		/// <summary>
		/// Calls the update entity.
		/// </summary>
		/// <param name="updateRestriction">Update restriction.</param>
		/// <returns></returns>
		internal bool CallUpdateEntity(IPredicate updateRestriction)
		{
			return UpdateEntity(updateRestriction);
		}

		
		/// <summary>
		/// Calls the validate entity after load method.
		/// </summary>
		internal void CallValidateEntityAfterLoad()
		{
			OnValidateEntityAfterLoad();
		}


		/// <summary>
		/// Calls the validate entity before save method
		/// </summary>
		internal void CallValidateEntityBeforeSave()
		{
			OnValidateEntityBeforeSave();
		}


		/// <summary>
		/// Calls the validate entity after save method
		/// </summary>
		internal void CallValidateEntityAfterSave()
		{
			OnValidateEntityAfterSave();
		}


		/// <summary>
		/// Calls the validate entity before delete method.
		/// </summary>
		internal void CallValidateEntityBeforeDelete()
		{
			OnValidateEntityBeforeDelete();
		}


		/// <summary>
		/// Calls the OnCanLoadEntity routine for this entity.
		/// </summary>
		/// <returns>the result of OnCanLoadEntity</returns>
		internal bool CallOnCanLoadEntity()
		{
			return OnCanLoadEntity();
		}


		/// <summary>
		/// Method to be used by XmlHelper, which is using this method to call this entity's PostReadXmlFixups.
		/// </summary>
		internal void CallPostReadXmlFixups()
		{
			PostReadXmlFixups();
		}


		/// <summary>
		/// Queues the auditor of this entity (if any) for commit flush in the transaction in progress. This way, entities produced by the auditor will
		/// be flushed in the transaction. If no transaction is in progress and there are entities produced by the auditor of this entity, the audit
		/// entities are flushed with a new transaction.
		/// </summary>
		internal void QueueAuditorForCommitFlush()
		{
			if(_auditorToUse == null)
			{
				return;
			}

			if(ParticipatesInTransaction)
			{
				// add auditor to transaction so it can take care of it when the commit comes. 
				((TransactionBase)_containingTransaction).AddAuditor(_auditorToUse);
			}
			else
			{
				// not in a transaction. If the audit object produces any entities, these have to be saved now, inside a new transaction. 
				IList auditEntities = _auditorToUse.GetAuditEntitiesToSave();
				if((auditEntities == null) || (auditEntities.Count <= 0))
				{
					// nothing to do
					return;
				}
				ITransaction trans = CreateTransaction(IsolationLevel.ReadCommitted, "auditTrans");
				try
				{
					foreach(IEntity auditEntity in auditEntities)
					{
						trans.Add((ITransactionalElement)auditEntity);
						auditEntity.Save(true);
					}
					trans.Commit();
					_auditorToUse.TransactionCommitted();
				}
				catch
				{
					trans.Rollback();
					throw;
				}
				finally
				{
					trans.Dispose();
				}
			}
		}


		/// <summary>
		/// Gets the entity description. This string is used in verbose trace messages.
		/// It will produce "EntityBase", if the passed in switch flag is false, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityBase" will be returned</param>
		/// <returns></returns>
		internal string GetEntityDescription(bool switchFlag)
		{
			return GetEntityDescription(switchFlag, this);
		}


		/// <summary>
		/// Gets the entity description. This string is used in verbose trace messages.
		/// It will produce "EntityBase", if verbose tracing is switched off for the GeneralSwitch, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityBase" will be returned</param>
		/// <param name="entity">the entity to get the description for</param>
		/// <returns></returns>
		internal string GetEntityDescription(bool switchFlag, IEntity entity)
		{
			if(!switchFlag || (entity == null) || ((entity != null) && entity.IsDeserializing))
			{
				return "EntityBase";
			}

			StringBuilder description = new StringBuilder(256);
			description.AppendFormat(null, "\r\n\tEntity: {0}. ObjectID: {1}\r\n", entity.GetType().FullName, this.ObjectID.ToString());
			foreach(EntityField field in entity.Fields.PrimaryKeyFields)
			{
				string currentValue = "<undefined value>";
				if( field.CurrentValue != null )
				{
					currentValue = field.CurrentValue.ToString();
				}
				description.AppendFormat( null, "\tPrimaryKey field: {0}. Type: {1}. Value: {2}\r\n", field.Name, field.DataType.FullName, currentValue );
			}

			return description.ToString();
		}

		/// <summary>
		/// Gets the type of the inheritance hierarchy this entity is in.
		/// </summary>
		/// <returns></returns>
		internal InheritanceHierarchyType GetInheritanceHierarchyType()
		{
			return this.LLBLGenProIsInHierarchyOfType;
		}
		

		/// <summary>
		/// Checks whether this instance has pending fk syncs. A pending FK sync is a sync which hasn't been used yet.
		/// If an entity has pending FK syncs, it has to be included into a save queue. Only syncs with entities in the passed in queue are considered. 
		/// If a sync is with an entity which isn't in the passed in queue, the sync isn't honoured anyway, so the fk sync can be ignored.
		/// </summary>
		/// <param name="inQueue">Hashtable of the entities which are currently scheduled to be saved in the queue. A pending sync has to be with an entity in this queue</param>
		/// <returns></returns>
		[System.ComponentModel.Browsable( false )]
		[EditorBrowsable( EditorBrowsableState.Never )]
		internal bool CheckIfEntityHasPendingFkSyncs( Dictionary<Guid, IEntity> inQueue )
		{
			bool hasPendingFkSync = false;
			if( _relatedEntitySyncInfos != null )
			{
				foreach( Dictionary<string, EntitySyncInfo<IEntity>> syncInfos in _relatedEntitySyncInfos.Values )
				{
					foreach( EntitySyncInfo<IEntity> syncInfo in syncInfos.Values )
					{
						if( (!syncInfo.Used) && inQueue.ContainsKey( syncInfo.DataSupplyingEntity.ObjectID ) )
						{
							hasPendingFkSync = true;
							break;
						}
					}
					if( hasPendingFkSync )
					{
						break;
					}
				}
			}
			return hasPendingFkSync;
		}


		/// <summary>
		/// Validates the input variable if it is a valid value for the target table field related to the passed in EntityField fieldToValidate.
		/// </summary>
		/// <param name="fieldToValidate">EntityField which is the destination of the value to validate</param>
		/// <param name="value">Value to validate. In the case of a scale overflow and a correction action, this value will be altered.</param>
		/// <param name="fieldIndex">The index of ValueDestination in the EntityFields2 array.</param>
		/// <returns>true if the value is valid, false otherwise</returns>
		/// <remarks>If a scale overflow is detected and the ScaleOverflowCorrectionActionToUse property suggests to alter the value instead
		/// the value is altered and no exception is thrown.</remarks>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as ValueDestination field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the databas</exception>
		private bool ValidateValue(IEntityField fieldToValidate, ref object value, int fieldIndex)
		{
			bool validationResult = true;

			// If the field is readonly, value can't be set.
			if(fieldToValidate.IsReadOnly)
			{
				// can't update a readonly field
				string errorMessage = string.Format( "The field '{0}' is read-only and can't be changed.", fieldToValidate.Name );
				SetEntityFieldError( fieldToValidate.Name, errorMessage, true );
				throw new ORMFieldIsReadonlyException( errorMessage );
			}

			bool performBuildInValidation = true;

			switch(EntityBase.BuildInValidationBypassMode)
			{
				case BuildInValidationBypass.BypassWhenValidatorPresent:
					performBuildInValidation = (_validator == null);
					break;
				case BuildInValidationBypass.AlwaysBypass:
					performBuildInValidation = false;
					break;
				default:
					performBuildInValidation = true;
					break;
			}
			
			if(performBuildInValidation)
			{
				// first filter out NULL values which are specified for not nullable fields
				if(value == null)
				{
					validationResult = fieldToValidate.IsNullable;
				}
				else
				{
					Type typeOfValue = value.GetType();
					if((fieldToValidate.DataType != typeof(object)) && (typeOfValue != fieldToValidate.DataType)
						&& !fieldToValidate.DataType.IsInstanceOfType(value))
					{
						string errorMessage = string.Format("The value {0} is of type '{1}' while the field is of type '{2}'", value.ToString(), typeOfValue.ToString(), fieldToValidate.DataType.ToString());
						SetEntityFieldError(fieldToValidate.Name, errorMessage, true);
						throw new ORMValueTypeMismatchException(errorMessage);
					}

					// value can be valid. 
					bool wasSuccesful = true;
					string exceptionMessage = "";
					string valueAsString = string.Empty;
					bool precisionViolation = false;
					bool scaleViolation = false;
					Type typeTocheck = fieldToValidate.DataType;
					if(typeTocheck.IsGenericType && typeTocheck.GetGenericTypeDefinition() == (typeof(Nullable<>)))
					{
						// use the parameter type instead. There's just 1
						Type[] parameterTypes = typeTocheck.GetGenericArguments();
						typeTocheck = parameterTypes[0];
					}
					switch(Type.GetTypeCode(typeTocheck))
					{
						case TypeCode.String:
							// check length
							valueAsString = (string)value;
							wasSuccesful = ((valueAsString.Length >= 0) && (valueAsString.Length <= fieldToValidate.MaxLength));
							exceptionMessage = "The value specified will cause an overflow error in the database. Value length: " + valueAsString.Length + ". Column max. length: " + fieldToValidate.MaxLength;
							break;
						case TypeCode.Object:
							if(fieldToValidate.DataType == typeof(System.Byte[]))
							{
								// check size
								Byte[] valueAsByteArray = (Byte[])value;
								wasSuccesful = ((valueAsByteArray.Length >= 0) && (valueAsByteArray.Length <= fieldToValidate.MaxLength));
								exceptionMessage = "The value specified will cause an overflow error in the database. Value length: " + valueAsByteArray.Length + ". Column max. length: " + fieldToValidate.MaxLength;
							}
							break;
						case TypeCode.Byte:
						case TypeCode.SByte:
						case TypeCode.Int16:
						case TypeCode.Int32:
						case TypeCode.Int64:
							if(fieldToValidate.Precision > 0)
							{
								if(value is Enum)
								{
									valueAsString = Convert.ToInt64(value).ToString();
								}
								else
								{
									valueAsString = value.ToString();
								}
								wasSuccesful = FieldUtilities.CheckPrecision(valueAsString, fieldToValidate.Precision, ref exceptionMessage);
							}
							break;
						case TypeCode.Decimal:
							if(fieldToValidate.Precision > 0)
							{
								Decimal valueAsDecimal = (decimal)value;
								if(valueAsDecimal < Decimal.Zero)
								{
									valueAsDecimal = Decimal.Negate(valueAsDecimal);
								}
								valueAsString = valueAsDecimal.ToString();
								FieldUtilities.CheckPrecisionAndScale(valueAsString, ref value, EntityBase.ScaleOverflowCorrectionActionToUse, fieldToValidate.Precision, fieldToValidate.Scale, out precisionViolation, out scaleViolation, ref exceptionMessage);
								wasSuccesful = !(precisionViolation || scaleViolation);
							}
							break;
						case TypeCode.Single:
							if((fieldToValidate.Precision > 0) && (fieldToValidate.Scale > 0))
							{
								Single valueAsSingle = (Single)value;
								if(valueAsSingle < 0.0f)
								{
									valueAsSingle = -1.0f * valueAsSingle;
								}
								valueAsString = valueAsSingle.ToString();
								FieldUtilities.CheckPrecisionAndScale(valueAsString, ref value, EntityBase.ScaleOverflowCorrectionActionToUse, fieldToValidate.Precision, fieldToValidate.Scale, out precisionViolation, out scaleViolation, ref exceptionMessage);
							}
							break;
						case TypeCode.Double:
							if((fieldToValidate.Precision > 0) && (fieldToValidate.Scale > 0))
							{
								Double valueAsDouble = (Double)value;
								if(valueAsDouble < 0.0)
								{
									valueAsDouble = -1.0 * valueAsDouble;
								}
								valueAsString = valueAsDouble.ToString();
								FieldUtilities.CheckPrecisionAndScale(valueAsString, ref value, EntityBase.ScaleOverflowCorrectionActionToUse, fieldToValidate.Precision, fieldToValidate.Scale, out precisionViolation, out scaleViolation, ref exceptionMessage);
							}
							break;
					}
					// all other types are not causing overflows, since these types are checked by the CLR.

					// If already not valid, throw exception.
					if(!wasSuccesful)
					{
						if(!CheckIfFieldErrorMessageIsAlreadyPresent(fieldToValidate.Name, exceptionMessage))
						{
							SetEntityFieldError(fieldToValidate.Name, exceptionMessage, true);
						}

						// throw exception
#if CF
						throw new ArgumentOutOfRangeException(exceptionMessage);
#else
						throw new ArgumentOutOfRangeException(fieldToValidate.Name, exceptionMessage);
#endif
					}
				}
			}

			// perform the custom validation IF either the build-in validation succeeded IF executed or if it was bypassed.
			if((performBuildInValidation && validationResult) || !performBuildInValidation)
			{
				validationResult = OnValidateFieldValue(fieldIndex, value);
			}
			return validationResult;
		}


		/// <summary>
		/// Checks if the specified field error message is already present for the given field. 
		/// </summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="errorMessage">The error message.</param>
		/// <returns>true if the error message is already present for the field, otherwise false. Case insensitive compare</returns>
		private bool CheckIfFieldErrorMessageIsAlreadyPresent(string fieldName, string errorMessage)
		{
			if(_dataErrorInfoErrorsPerField == null)
			{
				return false;
			}

			bool toReturn = false;

			string existingErrorMessage = string.Empty;
			if(_dataErrorInfoErrorsPerField.TryGetValue(fieldName, out existingErrorMessage))
			{
				toReturn = (existingErrorMessage.ToLower(CultureInfo.InvariantCulture).IndexOf(errorMessage.ToLower(CultureInfo.InvariantCulture)) >=0);
			}

			return toReturn;
		}


		/// <summary>
		/// Called when this Entity is added to a transaction object. This routine make sure all data currently inside the entity can be
		/// recovered when the transaction is rolled back.
		/// </summary>
		private void TransactionStart()
		{
			// back up vital info
			_backupIsNew = _isNew;

			// copy EntityFields, if present.
			if(_fields!=null)
			{
				// create copy of efsfields.
				_backupFields = (IEntityFields)((EntityFields)_fields).Clone();
			}
		}


		/// <summary>
		/// Initializes the class' members
		/// </summary>
		private void InitClass()
		{
#if CF
			_objectID = GeneralCFUtilities.CreateNewGuid();
#else
			_objectID = Guid.Empty;
#endif
			_relatedEntitySyncInfos = new FastDictionary<Guid, FastDictionary<string, EntitySyncInfo<IEntity>>>();
			_field2RelatedEntity = new FastDictionary<string, Guid>();
			_dataErrorInfoError = string.Empty;
		}


		#region IDataErrorInfo Members
		/// <summary>
		/// Gets an error message indicating what is wrong with this object.
		/// </summary>
		/// <value></value>
		/// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
		string IDataErrorInfo.Error
		{
			get { return this.DataErrorInfoError; }
		}

		/// <summary>
		/// Gets the <see cref="String"/> with the specified column name.
		/// </summary>
		/// <value></value>
		string IDataErrorInfo.this[string columnName]
		{
			get 
			{
				string toReturn = string.Empty;
				if( _dataErrorInfoErrorsPerField != null )
				{
					if( _dataErrorInfoErrorsPerField.TryGetValue( columnName, out toReturn ) )
					{
						return toReturn;
					}
				}
				return toReturn;
			}
		}

		#endregion

		#region IXmlSerializable Members

		/// <summary>
		/// Constructs the XML output from the object graph which has this object as the root. 
		/// </summary>
		/// <param name="writer">Writer to which the xml is written to</param>
		/// <remarks>Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType.</remarks>
		public virtual void WriteXml(XmlWriter writer)
		{
			string xmlOutput = string.Empty;
			WriteXml(XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType, out xmlOutput);

			XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlOutput));
			writer.WriteNode(reader, true);
		}

		/// <summary>
		/// Produce the schema, always return null, as the XmlSerializer object otherwise can't handle our code.
		/// </summary>
		/// <returns></returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">Reader with xml used to produce an object graph</param>
		/// <remarks>Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType. Xml data should have been
		/// produced with WriteXml(writer) or a similar routine which is able to produce similar formatted XML</remarks>
		public virtual void ReadXml(XmlReader reader)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(reader.ReadOuterXml());
			ReadXml(doc.DocumentElement.FirstChild);
		}

		#endregion

		#region IEntityCoreInternal Members
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.
		/// </summary>
		/// <returns>
		/// Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null
		/// </returns>
		Dictionary<string, object> IEntityCoreInternal.CallGetRelatedData()
		{
			return GetRelatedData();
		}
		#endregion


		#region Class Property Declarations
		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public abstract Dictionary<string, string> CustomPropertiesOfType { get;}
		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public abstract Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType { get;}

		/// <summary>
		/// Gets / sets isAddedViaDataBinding. Databinding related.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool IsNewViaDataBinding
		{
			get
			{
				return _isNewViaDataBinding;
			}
			set
			{
				_isNewViaDataBinding = value;
			}
		}

		/// <summary>
		/// Gets / sets parentCollection. databinding related.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		internal IEntityCollection ParentCollection
		{
			get
			{
				return _parentCollection;
			}
			set
			{
				_parentCollection = value;
			}
		}


		/// <summary>
		/// The validator object used to validate the entity on several moments in the entity's life.
		/// </summary>
		[Browsable(false)]
		public IValidator Validator
		{
			get { return _validator; }
			set 
			{
				if( _validator != null )
				{
					_validator.UnassignedFromEntity( this );
				}
				_validator = value;
				if( _validator != null )
				{
					_validator.AssignedToEntity( this );
				}
			}
		}


		/// <summary>
		/// Gets or sets the Authorizer for this entity.
		/// </summary>
		[Browsable(false)]
		public IAuthorizer AuthorizerToUse
		{
			get { return _authorizerToUse; }
			set { _authorizerToUse = value; }
		}


		/// <summary>
		/// Gets or sets the auditor object for this entity.
		/// </summary>
		[Browsable(false)]
		public IAuditor AuditorToUse
		{
			get { return _auditorToUse; }
			set { _auditorToUse = value; }
		}

		
		/// <summary>
		/// The internal presentation of the data, which is an EntityFields object, which implements <see cref="IEntityFields"/>.
		/// </summary>
		[Browsable(false)]
		public virtual IEntityFields Fields
		{
			get { return _fields; }
			set 
			{ 
				if(value==null)
				{
					throw new ArgumentNullException("Fields", "Fields can't be set to null");
				}

				if(_fields != null)
				{
					if(value.Count != _fields.Count)
					{
						// different EntityFields object
						throw new ArgumentException("The EntityFields object specified has a different layout than expected");
					}
				}

				_fields = value; 
			}
		}

		/// <summary>
		/// Marker for the entity object if the object is new and should be inserted when saved (true) or read from the
		/// database (false).
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public virtual bool IsNew
		{
			get { return _isNew; }
			set { _isNew = value; }
		}

		/// <summary>
		/// The <see cref="ITransaction"/> this ITransactionalElement implementing object is participating in. Only valid if
		/// <see cref="ParticipatesInTransaction"/> is true. If set to null, the ITransactionalElement is no longer participating
		/// in a transaction.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		public virtual ITransaction Transaction
		{
			get
			{
				return _containingTransaction;
			}
			set
			{
				if((value!=null)&&(_containingTransaction!=null))
				{
					// already is in a transaction. Ignore
					return;
				}

				_containingTransaction = value;
				if((_containingTransaction!=null)&&(_fields!=null))
				{
					TransactionStart();
				}
			}
		}

		/// <summary>
		/// Flag to check if the ITransactionalElement implementing object is participating in a transaction or not.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool ParticipatesInTransaction
		{
			get
			{
				return (_containingTransaction!=null);
			}
		}

		/// <summary>
		/// Gets / sets the unique Object ID which is created at runtime when the entity is instantiated. Can be used for external caches.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public virtual Guid ObjectID 
		{
			get 
			{
				if(_objectID == Guid.Empty)
				{
					_objectID = Guid.NewGuid();
				}
				return _objectID;
			}
			set {_objectID = value;}
		}

		/// <summary>
		/// Returns true if this entity instance is in the middle of a deserialization process, for example during a ReadXml() call.
		/// For internal use only. 
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsDeserializing 
		{
			get { return _isDeserializing; }
			set { _isDeserializing=value;}
		}

		/// <summary>
		/// Returns true if this entity instance is in the middle of a Serialization process, for example during a WriteXml() call.
		/// For internal use only. 
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable( EditorBrowsableState.Never )]
		public bool IsSerializing 
		{
			get { return _isSerializing; }
			set { _isSerializing=value;}
		}

		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory to use for <see cref="GetConcurrencyPredicate"/>.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public IConcurrencyPredicateFactory ConcurrencyPredicateFactoryToUse
		{
			get
			{
				return _concurrencyPredicateFactoryToUse;
			}
			set
			{
				_concurrencyPredicateFactoryToUse = value;
			}
		}


		/// <summary>
		/// Marker for the entity object if the object is 'dirty' (changed, true) or not (false). Affects/reads .Fields.IsDirty.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		public bool IsDirty
		{
			get
			{
				if(_isDeserializing || (_fields==null))
				{
					return false;
				}
				return _fields.IsDirty;
			}
			set
			{
				if(_fields!=null)
				{
					_fields.IsDirty = value;
				}
			}
		}


		/// <summary>
		/// Gets or sets the TypeDefaultValue provider to use. This object is used to provide default values for value typed fields which are null 
		/// and not of type Nullable(Of T)
		/// </summary>
		[Browsable(false)]
		[XmlIgnore]
		public ITypeDefaultValue TypeDefaultValueProviderToUse
		{
			get { return _typeDefaultValueProvider; }
			set { _typeDefaultValueProvider = value; }
		}


		/// <summary>
		/// List of IEntityField references which form the primary key. Reads/Affects .Fields.PrimaryKeyFields
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<IEntityField> PrimaryKeyFields 
		{
			get 
			{
				if(_fields!=null)
				{
					return _fields.PrimaryKeyFields;
				}
				else
				{
					return new List<IEntityField>();
				}
			}
		}

		/// <summary>
		/// Gets / sets the active context this entity is in. Setting this property is not adding the entity to the context, it will make contained
		/// entities be added to the passed in context. If the entity is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entities.
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		public Context ActiveContext
		{
			get
			{
				return _activeContext;
			}
			set 
			{
				if( ((_activeContext==null)&&(value!=null)) || ((_activeContext!=null)&&(value==null)))
				{
					_activeContext = value;
					AddInternalsToContext();
				}
			}
		}


		/// <summary>
		/// Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.
		/// </summary>
		/// <example>CustomerEntity</example>
		[System.ComponentModel.Browsable( false )]
		[XmlIgnore]
		[EditorBrowsable( EditorBrowsableState.Never )]
		public virtual string LLBLGenProEntityName
		{
			get { return string.Empty; }
		}



		/// <summary>
		/// Gets the type of the hierarchy this entity is in. 
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		protected virtual InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}


		/// <summary>
		/// Gets or sets a value indicating whether this entity is a subtype
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		[XmlIgnore]
		protected virtual bool LLBLGenProIsSubType
		{
			get { return false;}
		}		

		
		/// <summary>
		/// Returns the EntityType enum value for this entity.
		/// </summary>
		[Browsable(false), XmlIgnore]
		[EditorBrowsable( EditorBrowsableState.Never )]
		public virtual int LLBLGenProEntityTypeValue 
		{ 
			get { return 0; }
		}
		

		/// <summary>
		/// Gets or sets the site, which is set during design time databinding. 
		/// </summary>
		/// <value>The site.</value>
		[Browsable( false ), XmlIgnore]
		internal ISite Site
		{
			get { return _site; }
			set
			{
				_site = value;
			}
		}


		/// <summary>
		/// Gets the stored error messages per field name. Used for IDataErrorInfo. Use this property in your own code to re-channel the error messages through
		/// another interface. 
		/// </summary>
		[Browsable(false), XmlIgnore]
		protected Dictionary<string, string> DataErrorInfoErrorsPerField
		{
			get { return _dataErrorInfoErrorsPerField; }
		}


		/// <summary>
		/// Gets the data error info error message set by SetEntityError
		/// </summary>
		/// <value>The data error info error.</value>
		[Browsable(false), XmlIgnore]
		protected virtual string DataErrorInfoError
		{
			get { return _dataErrorInfoError; }
		}


		/// <summary>
		/// returns true if the classes are used in design-mode in vs.net.
		/// </summary>
		[Browsable(false), XmlIgnore]
		protected bool InDesignMode
		{
			get
			{
				return ((_site != null) || EntityCollectionComponentDesigner.InDesignMode);
			}
		}

		/// <summary>
		/// flag which is set when the entity is removed from an entity collection and added to a tracker. This flag is 
		/// used to cut off hierarchies in serialization scenario's
		/// </summary>
		[Browsable(false), XmlIgnore, EditorBrowsable(EditorBrowsableState.Never)]
		protected internal bool MarkedForDeletion
		{
			get { return _markedForDeletion; }
			set { _markedForDeletion = value; }
		}
		#endregion
	}
}
