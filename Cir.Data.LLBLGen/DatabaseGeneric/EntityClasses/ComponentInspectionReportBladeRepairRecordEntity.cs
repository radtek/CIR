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
	/// Entity class which represents the entity 'ComponentInspectionReportBladeRepairRecord'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeRepairRecordEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ComponentInspectionReportBladeEntity _componentInspectionReportBlade;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ComponentInspectionReportBlade</summary>
			public static readonly string ComponentInspectionReportBlade = "ComponentInspectionReportBlade";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportBladeRepairRecordEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportBladeRepairRecordEntity():base("ComponentInspectionReportBladeRepairRecordEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportBladeRepairRecordEntity(IEntityFields2 fields):base("ComponentInspectionReportBladeRepairRecordEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeRepairRecordEntity</param>
		public ComponentInspectionReportBladeRepairRecordEntity(IValidator validator):base("ComponentInspectionReportBladeRepairRecordEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeRepairRecordId">PK value for ComponentInspectionReportBladeRepairRecord which data should be fetched into this ComponentInspectionReportBladeRepairRecord object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeRepairRecordEntity(System.Int64 componentInspectionReportBladeRepairRecordId):base("ComponentInspectionReportBladeRepairRecordEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportBladeRepairRecordId = componentInspectionReportBladeRepairRecordId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeRepairRecordId">PK value for ComponentInspectionReportBladeRepairRecord which data should be fetched into this ComponentInspectionReportBladeRepairRecord object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeRepairRecordEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeRepairRecordEntity(System.Int64 componentInspectionReportBladeRepairRecordId, IValidator validator):base("ComponentInspectionReportBladeRepairRecordEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportBladeRepairRecordId = componentInspectionReportBladeRepairRecordId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportBladeRepairRecordEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_componentInspectionReportBlade = (ComponentInspectionReportBladeEntity)info.GetValue("_componentInspectionReportBlade", typeof(ComponentInspectionReportBladeEntity));
				if(_componentInspectionReportBlade!=null)
				{
					_componentInspectionReportBlade.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportBladeRepairRecordFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeId:
					DesetupSyncComponentInspectionReportBlade(true, false);
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
				case "ComponentInspectionReportBlade":
					this.ComponentInspectionReportBlade = (ComponentInspectionReportBladeEntity)entity;
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
				case "ComponentInspectionReportBlade":
					SetupSyncComponentInspectionReportBlade(relatedEntity);
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
				case "ComponentInspectionReportBlade":
					DesetupSyncComponentInspectionReportBlade(false, true);
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
			if(_componentInspectionReportBlade!=null)
			{
				toReturn.Add(_componentInspectionReportBlade);
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


				info.AddValue("_componentInspectionReportBlade", (!this.MarkedForDeletion?_componentInspectionReportBlade:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportBladeRepairRecordFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportBladeRepairRecordFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportBladeRepairRecordRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReportBlade' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeRepairRecordEntityFactory));
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
			toReturn.Add("ComponentInspectionReportBlade", _componentInspectionReportBlade);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_componentInspectionReportBlade!=null)
			{
				_componentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_componentInspectionReportBlade = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportBladeRepairRecordId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportBladeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeAmbientTemp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeHumidity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeAdditionalDocumentReference", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeResinType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeResinTypeBatchNumbers", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeResinTypeExpiryDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeHardenerType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeHardenerTypeBatchNumbers", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeHardenerTypeExpiryDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeGlassSupplier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeGlassSupplierBatchNumbers", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeSurfaceMaxTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeSurfaceMinTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeResinUsed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladePostCureMaxTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladePostCureMinTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeTurnOffTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeTotalCureTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _componentInspectionReportBlade</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReportBlade(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReportBlade, new PropertyChangedEventHandler( OnComponentInspectionReportBladePropertyChanged ), "ComponentInspectionReportBlade", ComponentInspectionReportBladeRepairRecordEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, true, signalRelatedEntity, "ComponentInspectionReportBladeRepairRecord", resetFKFields, new int[] { (int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeId } );		
			_componentInspectionReportBlade = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReportBlade</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReportBlade(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReportBlade(true, true);
			_componentInspectionReportBlade = (ComponentInspectionReportBladeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReportBlade, new PropertyChangedEventHandler( OnComponentInspectionReportBladePropertyChanged ), "ComponentInspectionReportBlade", ComponentInspectionReportBladeRepairRecordEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportBladePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportBladeRepairRecordEntity</param>
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
		public  static ComponentInspectionReportBladeRepairRecordRelations Relations
		{
			get	{ return new ComponentInspectionReportBladeRepairRecordRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBlade' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBlade
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))),
					ComponentInspectionReportBladeRepairRecordEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, 0, null, null, null, null, "ComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportBladeRepairRecordEntity.CustomProperties;}
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
			get { return ComponentInspectionReportBladeRepairRecordEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportBladeRepairRecordId property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."ComponentInspectionReportBladeRepairRecordId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportBladeRepairRecordId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeRepairRecordId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeRepairRecordId, value); }
		}

		/// <summary> The ComponentInspectionReportBladeId property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."ComponentInspectionReportBladeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportBladeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeId, value); }
		}

		/// <summary> The BladeAmbientTemp property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeAmbientTemp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladeAmbientTemp
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAmbientTemp, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAmbientTemp, value); }
		}

		/// <summary> The BladeHumidity property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeHumidity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladeHumidity
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHumidity, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHumidity, value); }
		}

		/// <summary> The BladeAdditionalDocumentReference property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeAdditionalDocumentReference"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeAdditionalDocumentReference
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAdditionalDocumentReference, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAdditionalDocumentReference, value); }
		}

		/// <summary> The BladeResinType property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeResinType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeResinType
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinType, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinType, value); }
		}

		/// <summary> The BladeResinTypeBatchNumbers property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeResinTypeBatchNumbers"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeResinTypeBatchNumbers
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeBatchNumbers, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeBatchNumbers, value); }
		}

		/// <summary> The BladeResinTypeExpiryDate property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeResinTypeExpiryDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BladeResinTypeExpiryDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeExpiryDate, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeExpiryDate, value); }
		}

		/// <summary> The BladeHardenerType property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeHardenerType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeHardenerType
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerType, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerType, value); }
		}

		/// <summary> The BladeHardenerTypeBatchNumbers property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeHardenerTypeBatchNumbers"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeHardenerTypeBatchNumbers
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeBatchNumbers, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeBatchNumbers, value); }
		}

		/// <summary> The BladeHardenerTypeExpiryDate property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeHardenerTypeExpiryDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BladeHardenerTypeExpiryDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeExpiryDate, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeExpiryDate, value); }
		}

		/// <summary> The BladeGlassSupplier property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeGlassSupplier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeGlassSupplier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplier, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplier, value); }
		}

		/// <summary> The BladeGlassSupplierBatchNumbers property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeGlassSupplierBatchNumbers"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeGlassSupplierBatchNumbers
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplierBatchNumbers, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplierBatchNumbers, value); }
		}

		/// <summary> The BladeSurfaceMaxTemperature property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeSurfaceMaxTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladeSurfaceMaxTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMaxTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMaxTemperature, value); }
		}

		/// <summary> The BladeSurfaceMinTemperature property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeSurfaceMinTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladeSurfaceMinTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMinTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMinTemperature, value); }
		}

		/// <summary> The BladeResinUsed property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeResinUsed"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeResinUsed
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinUsed, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinUsed, value); }
		}

		/// <summary> The BladePostCureMaxTemperature property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladePostCureMaxTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladePostCureMaxTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMaxTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMaxTemperature, value); }
		}

		/// <summary> The BladePostCureMinTemperature property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladePostCureMinTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal BladePostCureMinTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMinTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMinTemperature, value); }
		}

		/// <summary> The BladeTurnOffTime property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeTurnOffTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BladeTurnOffTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTurnOffTime, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTurnOffTime, value); }
		}

		/// <summary> The BladeTotalCureTime property of the Entity ComponentInspectionReportBladeRepairRecord<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeRepairRecord"."BladeTotalCureTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeTotalCureTime
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTotalCureTime, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTotalCureTime, value); }
		}



		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportBladeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportBladeEntity ComponentInspectionReportBlade
		{
			get
			{
				return _componentInspectionReportBlade;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReportBlade(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReportBlade != null)
						{
							_componentInspectionReportBlade.UnsetRelatedEntity(this, "ComponentInspectionReportBladeRepairRecord");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBladeRepairRecord");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity; }
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
