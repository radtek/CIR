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
	/// Entity class which represents the entity 'GearboxDefectCategorizationDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GearboxDefectCategorizationDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private BearingTypeEntity _bearingType;
		private GearboxDefectCategorizationEntity _gearboxDefectCategorization;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BearingType</summary>
			public static readonly string BearingType = "BearingType";
			/// <summary>Member name GearboxDefectCategorization</summary>
			public static readonly string GearboxDefectCategorization = "GearboxDefectCategorization";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GearboxDefectCategorizationDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GearboxDefectCategorizationDetailsEntity():base("GearboxDefectCategorizationDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GearboxDefectCategorizationDetailsEntity(IEntityFields2 fields):base("GearboxDefectCategorizationDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GearboxDefectCategorizationDetailsEntity</param>
		public GearboxDefectCategorizationDetailsEntity(IValidator validator):base("GearboxDefectCategorizationDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GearboxDefectCategorizationDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_bearingType = (BearingTypeEntity)info.GetValue("_bearingType", typeof(BearingTypeEntity));
				if(_bearingType!=null)
				{
					_bearingType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearboxDefectCategorization = (GearboxDefectCategorizationEntity)info.GetValue("_gearboxDefectCategorization", typeof(GearboxDefectCategorizationEntity));
				if(_gearboxDefectCategorization!=null)
				{
					_gearboxDefectCategorization.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((GearboxDefectCategorizationDetailsFieldIndex)fieldIndex)
			{
				case GearboxDefectCategorizationDetailsFieldIndex.GearboxDefectCategorizationId:
					DesetupSyncGearboxDefectCategorization(true, false);
					break;
				case GearboxDefectCategorizationDetailsFieldIndex.BearingTypeId:
					DesetupSyncBearingType(true, false);
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
				case "BearingType":
					this.BearingType = (BearingTypeEntity)entity;
					break;
				case "GearboxDefectCategorization":
					this.GearboxDefectCategorization = (GearboxDefectCategorizationEntity)entity;
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
				case "BearingType":
					SetupSyncBearingType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxDefectCategorization":
					SetupSyncGearboxDefectCategorization(relatedEntity);
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
				case "BearingType":
					DesetupSyncBearingType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxDefectCategorization":
					DesetupSyncGearboxDefectCategorization(false, true);
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
			if(_bearingType!=null)
			{
				toReturn.Add(_bearingType);
			}
			if(_gearboxDefectCategorization!=null)
			{
				toReturn.Add(_gearboxDefectCategorization);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_bearingType", (!this.MarkedForDeletion?_bearingType:null));
				info.AddValue("_gearboxDefectCategorization", (!this.MarkedForDeletion?_gearboxDefectCategorization:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GearboxDefectCategorizationDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GearboxDefectCategorizationDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GearboxDefectCategorizationDetailsRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxDefectCategorization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxDefectCategorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxDefectCategorizationFields.GearboxDefectCategorizationId, null, ComparisonOperator.Equal, this.GearboxDefectCategorizationId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BearingType", _bearingType);
			toReturn.Add("GearboxDefectCategorization", _gearboxDefectCategorization);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_bearingType!=null)
			{
				_bearingType.ActiveContext = base.ActiveContext;
			}
			if(_gearboxDefectCategorization!=null)
			{
				_gearboxDefectCategorization.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_bearingType = null;
			_gearboxDefectCategorization = null;

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

			_fieldsCustomProperties.Add("PartName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPartTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ItemNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Error1Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Error2Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Comments", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DamageDecisionId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bearingType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType, new PropertyChangedEventHandler( OnBearingTypePropertyChanged ), "BearingType", GearboxDefectCategorizationDetailsEntity.Relations.BearingTypeEntityUsingBearingTypeId, true, signalRelatedEntity, "GearboxDefectCategorizationDetails", resetFKFields, new int[] { (int)GearboxDefectCategorizationDetailsFieldIndex.BearingTypeId } );		
			_bearingType = null;
		}

		/// <summary> setups the sync logic for member _bearingType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType(true, true);
			_bearingType = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType, new PropertyChangedEventHandler( OnBearingTypePropertyChanged ), "BearingType", GearboxDefectCategorizationDetailsEntity.Relations.BearingTypeEntityUsingBearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearboxDefectCategorization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxDefectCategorization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxDefectCategorization, new PropertyChangedEventHandler( OnGearboxDefectCategorizationPropertyChanged ), "GearboxDefectCategorization", GearboxDefectCategorizationDetailsEntity.Relations.GearboxDefectCategorizationEntityUsingGearboxDefectCategorizationId, true, signalRelatedEntity, "GearboxDefectCategorizationDetails", resetFKFields, new int[] { (int)GearboxDefectCategorizationDetailsFieldIndex.GearboxDefectCategorizationId } );		
			_gearboxDefectCategorization = null;
		}

		/// <summary> setups the sync logic for member _gearboxDefectCategorization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxDefectCategorization(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxDefectCategorization(true, true);
			_gearboxDefectCategorization = (GearboxDefectCategorizationEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxDefectCategorization, new PropertyChangedEventHandler( OnGearboxDefectCategorizationPropertyChanged ), "GearboxDefectCategorization", GearboxDefectCategorizationDetailsEntity.Relations.GearboxDefectCategorizationEntityUsingGearboxDefectCategorizationId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxDefectCategorizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GearboxDefectCategorizationDetailsEntity</param>
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
		public  static GearboxDefectCategorizationDetailsRelations Relations
		{
			get	{ return new GearboxDefectCategorizationDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					GearboxDefectCategorizationDetailsEntity.Relations.BearingTypeEntityUsingBearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxDefectCategorization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxDefectCategorizationEntityFactory))),
					GearboxDefectCategorizationDetailsEntity.Relations.GearboxDefectCategorizationEntityUsingGearboxDefectCategorizationId, 
					(int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity, 0, null, null, null, null, "GearboxDefectCategorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GearboxDefectCategorizationDetailsEntity.CustomProperties;}
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
			get { return GearboxDefectCategorizationDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The GearboxDefectCategorizationId property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."GearboxDefectCategorizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxDefectCategorizationId
		{
			get { return (System.Int64)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.GearboxDefectCategorizationId, true); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.GearboxDefectCategorizationId, value); }
		}

		/// <summary> The PartName property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."PartName"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PartName
		{
			get { return (System.Int32)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.PartName, true); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.PartName, value); }
		}

		/// <summary> The GearboxPartTypeId property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."GearboxPartTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 GearboxPartTypeId
		{
			get { return (System.Int32)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.GearboxPartTypeId, true); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.GearboxPartTypeId, value); }
		}

		/// <summary> The ItemNumber property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."ItemNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ItemNumber
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.ItemNumber, true); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.ItemNumber, value); }
		}

		/// <summary> The BearingTypeId property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.BearingTypeId, false); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.BearingTypeId, value); }
		}

		/// <summary> The Error1Id property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."Error1Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Error1Id
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Error1Id, false); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Error1Id, value); }
		}

		/// <summary> The Error2Id property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."Error2Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Error2Id
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Error2Id, false); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Error2Id, value); }
		}

		/// <summary> The Comments property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."Comments"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Comments
		{
			get { return (System.String)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Comments, true); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.Comments, value); }
		}

		/// <summary> The DamageDecisionId property of the Entity GearboxDefectCategorizationDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GearboxDefectCategorizationDetails"."DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GearboxDefectCategorizationDetailsFieldIndex.DamageDecisionId, false); }
			set	{ SetValue((int)GearboxDefectCategorizationDetailsFieldIndex.DamageDecisionId, value); }
		}



		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType
		{
			get
			{
				return _bearingType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType != null)
						{
							_bearingType.UnsetRelatedEntity(this, "GearboxDefectCategorizationDetails");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GearboxDefectCategorizationDetails");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxDefectCategorizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxDefectCategorizationEntity GearboxDefectCategorization
		{
			get
			{
				return _gearboxDefectCategorization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxDefectCategorization(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxDefectCategorization != null)
						{
							_gearboxDefectCategorization.UnsetRelatedEntity(this, "GearboxDefectCategorizationDetails");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GearboxDefectCategorizationDetails");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity; }
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
