///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'GearboxDefectCategorization'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GearboxDefectCategorizationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GearboxDefectCategorizationDetailsEntity> _gearboxDefectCategorizationDetails;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaGearboxDefectCategorizationDetails;
		private GearboxTypeEntity _gearboxType;
		private OilTypeEntity _oilType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name GearboxType</summary>
			public static readonly string GearboxType = "GearboxType";
			/// <summary>Member name OilType</summary>
			public static readonly string OilType = "OilType";
			/// <summary>Member name GearboxDefectCategorizationDetails</summary>
			public static readonly string GearboxDefectCategorizationDetails = "GearboxDefectCategorizationDetails";
			/// <summary>Member name BearingTypeCollectionViaGearboxDefectCategorizationDetails</summary>
			public static readonly string BearingTypeCollectionViaGearboxDefectCategorizationDetails = "BearingTypeCollectionViaGearboxDefectCategorizationDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GearboxDefectCategorizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GearboxDefectCategorizationEntity():base("GearboxDefectCategorizationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GearboxDefectCategorizationEntity(IEntityFields2 fields):base("GearboxDefectCategorizationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GearboxDefectCategorizationEntity</param>
		public GearboxDefectCategorizationEntity(IValidator validator):base("GearboxDefectCategorizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="gearboxDefectCategorizationId">PK value for GearboxDefectCategorization which data should be fetched into this GearboxDefectCategorization object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GearboxDefectCategorizationEntity(System.Int64 gearboxDefectCategorizationId):base("GearboxDefectCategorizationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GearboxDefectCategorizationId = gearboxDefectCategorizationId;
		}

		/// <summary> CTor</summary>
		/// <param name="gearboxDefectCategorizationId">PK value for GearboxDefectCategorization which data should be fetched into this GearboxDefectCategorization object</param>
		/// <param name="validator">The custom validator object for this GearboxDefectCategorizationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GearboxDefectCategorizationEntity(System.Int64 gearboxDefectCategorizationId, IValidator validator):base("GearboxDefectCategorizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GearboxDefectCategorizationId = gearboxDefectCategorizationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GearboxDefectCategorizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_gearboxDefectCategorizationDetails = (EntityCollection<GearboxDefectCategorizationDetailsEntity>)info.GetValue("_gearboxDefectCategorizationDetails", typeof(EntityCollection<GearboxDefectCategorizationDetailsEntity>));
				_bearingTypeCollectionViaGearboxDefectCategorizationDetails = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaGearboxDefectCategorizationDetails", typeof(EntityCollection<BearingTypeEntity>));
				_gearboxType = (GearboxTypeEntity)info.GetValue("_gearboxType", typeof(GearboxTypeEntity));
				if(_gearboxType!=null)
				{
					_gearboxType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_oilType = (OilTypeEntity)info.GetValue("_oilType", typeof(OilTypeEntity));
				if(_oilType!=null)
				{
					_oilType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((GearboxDefectCategorizationFieldIndex)fieldIndex)
			{
				case GearboxDefectCategorizationFieldIndex.GearboxTypeId:
					DesetupSyncGearboxType(true, false);
					break;
				case GearboxDefectCategorizationFieldIndex.OilTypeId:
					DesetupSyncOilType(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "GearboxType":
					this.GearboxType = (GearboxTypeEntity)entity;
					break;
				case "OilType":
					this.OilType = (OilTypeEntity)entity;
					break;
				case "GearboxDefectCategorizationDetails":
					this.GearboxDefectCategorizationDetails.Add((GearboxDefectCategorizationDetailsEntity)entity);
					break;
				case "BearingTypeCollectionViaGearboxDefectCategorizationDetails":
					this.BearingTypeCollectionViaGearboxDefectCategorizationDetails.IsReadOnly = false;
					this.BearingTypeCollectionViaGearboxDefectCategorizationDetails.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaGearboxDefectCategorizationDetails.IsReadOnly = true;
					break;

				default:
					break;
			}
		}
#if !CF		
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));



				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "GearboxType":
					SetupSyncGearboxType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OilType":
					SetupSyncOilType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxDefectCategorizationDetails":
					this.GearboxDefectCategorizationDetails.Add((GearboxDefectCategorizationDetailsEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "GearboxType":
					DesetupSyncGearboxType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OilType":
					DesetupSyncOilType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxDefectCategorizationDetails":
					base.PerformRelatedEntityRemoval(this.GearboxDefectCategorizationDetails, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_gearboxType!=null)
			{
				toReturn.Add(_gearboxType);
			}
			if(_oilType!=null)
			{
				toReturn.Add(_oilType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.GearboxDefectCategorizationDetails);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_gearboxDefectCategorizationDetails", ((_gearboxDefectCategorizationDetails!=null) && (_gearboxDefectCategorizationDetails.Count>0) && !this.MarkedForDeletion)?_gearboxDefectCategorizationDetails:null);
				info.AddValue("_bearingTypeCollectionViaGearboxDefectCategorizationDetails", ((_bearingTypeCollectionViaGearboxDefectCategorizationDetails!=null) && (_bearingTypeCollectionViaGearboxDefectCategorizationDetails.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaGearboxDefectCategorizationDetails:null);
				info.AddValue("_gearboxType", (!this.MarkedForDeletion?_gearboxType:null));
				info.AddValue("_oilType", (!this.MarkedForDeletion?_oilType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GearboxDefectCategorizationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GearboxDefectCategorizationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GearboxDefectCategorizationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxDefectCategorizationDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxDefectCategorizationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxDefectCategorizationDetailsFields.GearboxDefectCategorizationId, null, ComparisonOperator.Equal, this.GearboxDefectCategorizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaGearboxDefectCategorizationDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GearboxDefectCategorizationEntity.Relations.GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId, "GearboxDefectCategorizationEntity__", "GearboxDefectCategorizationDetails_", JoinHint.None);
			bucket.Relations.Add(GearboxDefectCategorizationDetailsEntity.Relations.BearingTypeEntityUsingBearingTypeId, "GearboxDefectCategorizationDetails_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxDefectCategorizationFields.GearboxDefectCategorizationId, null, ComparisonOperator.Equal, this.GearboxDefectCategorizationId, "GearboxDefectCategorizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxTypeFields.GearboxTypeId, null, ComparisonOperator.Equal, this.GearboxTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OilType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OilTypeFields.OilTypeId, null, ComparisonOperator.Equal, this.OilTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._gearboxDefectCategorizationDetails);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaGearboxDefectCategorizationDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._gearboxDefectCategorizationDetails = (EntityCollection<GearboxDefectCategorizationDetailsEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaGearboxDefectCategorizationDetails = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._gearboxDefectCategorizationDetails != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaGearboxDefectCategorizationDetails != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxDefectCategorizationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("GearboxType", _gearboxType);
			toReturn.Add("OilType", _oilType);
			toReturn.Add("GearboxDefectCategorizationDetails", _gearboxDefectCategorizationDetails);
			toReturn.Add("BearingTypeCollectionViaGearboxDefectCategorizationDetails", _bearingTypeCollectionViaGearboxDefectCategorizationDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_gearboxDefectCategorizationDetails!=null)
			{
				_gearboxDefectCategorizationDetails.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaGearboxDefectCategorizationDetails!=null)
			{
				_bearingTypeCollectionViaGearboxDefectCategorizationDetails.ActiveContext = base.ActiveContext;
			}
			if(_gearboxType!=null)
			{
				_gearboxType.ActiveContext = base.ActiveContext;
			}
			if(_oilType!=null)
			{
				_oilType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_gearboxDefectCategorizationDetails = null;
			_bearingTypeCollectionViaGearboxDefectCategorizationDetails = null;
			_gearboxType = null;
			_oilType = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDefectCategorizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VendorName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearBoxManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ratio", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OilTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Frequency", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportGearboxId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InspectionDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InspectedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RepairManualNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("JobNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Timestamp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Noise", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MetalOnMagnet", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HighTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Leakage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Painting", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Others", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("None", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HssBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ImsBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LssBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PlanetBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoBearingDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HssToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ImsToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LssToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PlanetToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoToothDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DetailsOfDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ServiceHistory", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrimaryFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SecondaryFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConsequentialDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherFindings", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _gearboxType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxType, new PropertyChangedEventHandler( OnGearboxTypePropertyChanged ), "GearboxType", GearboxDefectCategorizationEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, true, signalRelatedEntity, "GearboxDefectCategorization", resetFKFields, new int[] { (int)GearboxDefectCategorizationFieldIndex.GearboxTypeId } );		
			_gearboxType = null;
		}

		/// <summary> setups the sync logic for member _gearboxType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxType(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxType(true, true);
			_gearboxType = (GearboxTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxType, new PropertyChangedEventHandler( OnGearboxTypePropertyChanged ), "GearboxType", GearboxDefectCategorizationEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _oilType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOilType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", GearboxDefectCategorizationEntity.Relations.OilTypeEntityUsingOilTypeId, true, signalRelatedEntity, "GearboxDefectCategorization", resetFKFields, new int[] { (int)GearboxDefectCategorizationFieldIndex.OilTypeId } );		
			_oilType = null;
		}

		/// <summary> setups the sync logic for member _oilType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOilType(IEntity2 relatedEntity)
		{
			DesetupSyncOilType(true, true);
			_oilType = (OilTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", GearboxDefectCategorizationEntity.Relations.OilTypeEntityUsingOilTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOilTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GearboxDefectCategorizationEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static GearboxDefectCategorizationRelations Relations
		{
			get	{ return new GearboxDefectCategorizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxDefectCategorizationDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxDefectCategorizationDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GearboxDefectCategorizationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationDetailsEntityFactory))),
					GearboxDefectCategorizationEntity.Relations.GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId, 
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity, 0, null, null, null, null, "GearboxDefectCategorizationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaGearboxDefectCategorizationDetails
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GearboxDefectCategorizationEntity.Relations.GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId;
				intermediateRelation.SetAliases(string.Empty, "GearboxDefectCategorizationDetails_");
				relations.Add(GearboxDefectCategorizationEntity.Relations.GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId, "GearboxDefectCategorizationEntity__", "GearboxDefectCategorizationDetails_", JoinHint.None);
				relations.Add(GearboxDefectCategorizationDetailsEntity.Relations.BearingTypeEntityUsingBearingTypeId, "GearboxDefectCategorizationDetails_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaGearboxDefectCategorizationDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxTypeEntityFactory))),
					GearboxDefectCategorizationEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxTypeEntity, 0, null, null, null, null, "GearboxType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))),
					GearboxDefectCategorizationEntity.Relations.OilTypeEntityUsingOilTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.OilTypeEntity, 0, null, null, null, null, "OilType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GearboxDefectCategorizationEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return GearboxDefectCategorizationEntity.FieldsCustomProperties;}
		}

		/// <summary> The GearboxDefectCategorizationId property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."GearboxDefectCategorizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 GearboxDefectCategorizationId
		{
			get { return (System.Int64)GetValue((int)GearboxDefectCategorizationFieldIndex.GearboxDefectCategorizationId, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.GearboxDefectCategorizationId, value); }
		}

		/// <summary> The VendorName property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."VendorName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VendorName
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.VendorName, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.VendorName, value); }
		}

		/// <summary> The GearboxTypeId property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."GearboxTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationFieldIndex.GearboxTypeId, false); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.GearboxTypeId, value); }
		}

		/// <summary> The SerialNumber property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SerialNumber
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.SerialNumber, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.SerialNumber, value); }
		}

		/// <summary> The GearBoxManufacturerId property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."GearBoxManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearBoxManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationFieldIndex.GearBoxManufacturerId, false); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.GearBoxManufacturerId, value); }
		}

		/// <summary> The Ratio property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Ratio"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ratio
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.Ratio, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Ratio, value); }
		}

		/// <summary> The OilTypeId property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."OilTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OilTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationFieldIndex.OilTypeId, false); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.OilTypeId, value); }
		}

		/// <summary> The Frequency property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Frequency"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Frequency
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.Frequency, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Frequency, value); }
		}

		/// <summary> The ComponentInspectionReportGearboxId property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."ComponentInspectionReportGearboxId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportGearboxId
		{
			get { return (System.Int64)GetValue((int)GearboxDefectCategorizationFieldIndex.ComponentInspectionReportGearboxId, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.ComponentInspectionReportGearboxId, value); }
		}

		/// <summary> The InspectionDate property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."InspectionDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> InspectionDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)GearboxDefectCategorizationFieldIndex.InspectionDate, false); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.InspectionDate, value); }
		}

		/// <summary> The InspectedBy property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."InspectedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InspectedBy
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.InspectedBy, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.InspectedBy, value); }
		}

		/// <summary> The Email property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.Email, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Email, value); }
		}

		/// <summary> The RepairManualNumber property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."RepairManualNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RepairManualNumber
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.RepairManualNumber, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.RepairManualNumber, value); }
		}

		/// <summary> The JobNumber property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."JobNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String JobNumber
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.JobNumber, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.JobNumber, value); }
		}

		/// <summary> The Timestamp property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Timestamp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] Timestamp
		{
			get { return (System.Byte[])GetValue((int)GearboxDefectCategorizationFieldIndex.Timestamp, true); }

		}

		/// <summary> The Noise property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Noise"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Noise
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.Noise, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Noise, value); }
		}

		/// <summary> The MetalOnMagnet property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."MetalOnMagnet"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MetalOnMagnet
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.MetalOnMagnet, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.MetalOnMagnet, value); }
		}

		/// <summary> The HighTemperature property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."HighTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HighTemperature
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.HighTemperature, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.HighTemperature, value); }
		}

		/// <summary> The Leakage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Leakage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Leakage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.Leakage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Leakage, value); }
		}

		/// <summary> The Painting property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Painting"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Painting
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.Painting, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Painting, value); }
		}

		/// <summary> The Others property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."Others"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Others
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.Others, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.Others, value); }
		}

		/// <summary> The None property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."None"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean None
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.None, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.None, value); }
		}

		/// <summary> The HssBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."HssBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HssBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.HssBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.HssBearingDamage, value); }
		}

		/// <summary> The ImsBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."ImsBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ImsBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.ImsBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.ImsBearingDamage, value); }
		}

		/// <summary> The LssBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."LssBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean LssBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.LssBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.LssBearingDamage, value); }
		}

		/// <summary> The PlanetBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."PlanetBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PlanetBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.PlanetBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.PlanetBearingDamage, value); }
		}

		/// <summary> The OtherBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."OtherBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean OtherBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.OtherBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.OtherBearingDamage, value); }
		}

		/// <summary> The NoBearingDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."NoBearingDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NoBearingDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.NoBearingDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.NoBearingDamage, value); }
		}

		/// <summary> The HssToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."HssToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HssToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.HssToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.HssToothDamage, value); }
		}

		/// <summary> The ImsToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."ImsToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ImsToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.ImsToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.ImsToothDamage, value); }
		}

		/// <summary> The LssToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."LssToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean LssToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.LssToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.LssToothDamage, value); }
		}

		/// <summary> The PlanetToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."PlanetToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PlanetToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.PlanetToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.PlanetToothDamage, value); }
		}

		/// <summary> The OtherToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."OtherToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean OtherToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.OtherToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.OtherToothDamage, value); }
		}

		/// <summary> The NoToothDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."NoToothDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NoToothDamage
		{
			get { return (System.Boolean)GetValue((int)GearboxDefectCategorizationFieldIndex.NoToothDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.NoToothDamage, value); }
		}

		/// <summary> The DetailsOfDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."DetailsOfDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DetailsOfDamage
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.DetailsOfDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.DetailsOfDamage, value); }
		}

		/// <summary> The ServiceHistory property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."ServiceHistory"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ServiceHistory
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.ServiceHistory, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.ServiceHistory, value); }
		}

		/// <summary> The PrimaryFailure property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."PrimaryFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PrimaryFailure
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.PrimaryFailure, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.PrimaryFailure, value); }
		}

		/// <summary> The SecondaryFailure property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."SecondaryFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SecondaryFailure
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.SecondaryFailure, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.SecondaryFailure, value); }
		}

		/// <summary> The ConsequentialDamage property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."ConsequentialDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ConsequentialDamage
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.ConsequentialDamage, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.ConsequentialDamage, value); }
		}

		/// <summary> The OtherFindings property of the Entity GearboxDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorization"."OtherFindings"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OtherFindings
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationFieldIndex.OtherFindings, true); }
			set	{ SetValue((int)GearboxDefectCategorizationFieldIndex.OtherFindings, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearboxDefectCategorizationDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearboxDefectCategorizationDetailsEntity))]
		public virtual EntityCollection<GearboxDefectCategorizationDetailsEntity> GearboxDefectCategorizationDetails
		{
			get
			{
				if(_gearboxDefectCategorizationDetails==null)
				{
					_gearboxDefectCategorizationDetails = new EntityCollection<GearboxDefectCategorizationDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationDetailsEntityFactory)));
					_gearboxDefectCategorizationDetails.SetContainingEntityInfo(this, "GearboxDefectCategorization");
				}
				return _gearboxDefectCategorizationDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaGearboxDefectCategorizationDetails
		{
			get
			{
				if(_bearingTypeCollectionViaGearboxDefectCategorizationDetails==null)
				{
					_bearingTypeCollectionViaGearboxDefectCategorizationDetails = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaGearboxDefectCategorizationDetails.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaGearboxDefectCategorizationDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxTypeEntity GearboxType
		{
			get
			{
				return _gearboxType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxType(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxType != null)
						{
							_gearboxType.UnsetRelatedEntity(this, "GearboxDefectCategorization");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GearboxDefectCategorization");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OilTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OilTypeEntity OilType
		{
			get
			{
				return _oilType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOilType(value);
				}
				else
				{
					if(value==null)
					{
						if(_oilType != null)
						{
							_oilType.UnsetRelatedEntity(this, "GearboxDefectCategorization");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GearboxDefectCategorization");
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
