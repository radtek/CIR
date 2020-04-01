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
	/// Entity class which represents the entity 'GeneratorDefectCategorization2'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorDefectCategorization2Entity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GeneratorDefectCategorization2DetailsEntity> _generatorDefectCategorization2Details;
		private EntityCollection<GeneratorComponentDamageEntity> _generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{

			/// <summary>Member name GeneratorDefectCategorization2Details</summary>
			public static readonly string GeneratorDefectCategorization2Details = "GeneratorDefectCategorization2Details";
			/// <summary>Member name GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details</summary>
			public static readonly string GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details = "GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorDefectCategorization2Entity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorDefectCategorization2Entity():base("GeneratorDefectCategorization2Entity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorDefectCategorization2Entity(IEntityFields2 fields):base("GeneratorDefectCategorization2Entity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorization2Entity</param>
		public GeneratorDefectCategorization2Entity(IValidator validator):base("GeneratorDefectCategorization2Entity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorizationId">PK value for GeneratorDefectCategorization2 which data should be fetched into this GeneratorDefectCategorization2 object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorization2Entity(System.Int64 generatorDefectCategorizationId):base("GeneratorDefectCategorization2Entity")
		{
			InitClassEmpty(null, CreateFields());
			this.GeneratorDefectCategorizationId = generatorDefectCategorizationId;
		}

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorizationId">PK value for GeneratorDefectCategorization2 which data should be fetched into this GeneratorDefectCategorization2 object</param>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorization2Entity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorization2Entity(System.Int64 generatorDefectCategorizationId, IValidator validator):base("GeneratorDefectCategorization2Entity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GeneratorDefectCategorizationId = generatorDefectCategorizationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorDefectCategorization2Entity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_generatorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2DetailsEntity>)info.GetValue("_generatorDefectCategorization2Details", typeof(EntityCollection<GeneratorDefectCategorization2DetailsEntity>));
				_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details = (EntityCollection<GeneratorComponentDamageEntity>)info.GetValue("_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details", typeof(EntityCollection<GeneratorComponentDamageEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((GeneratorDefectCategorization2FieldIndex)fieldIndex)
			{
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

				case "GeneratorDefectCategorization2Details":
					this.GeneratorDefectCategorization2Details.Add((GeneratorDefectCategorization2DetailsEntity)entity);
					break;
				case "GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details":
					this.GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details.IsReadOnly = false;
					this.GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details.Add((GeneratorComponentDamageEntity)entity);
					this.GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details.IsReadOnly = true;
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

				case "GeneratorDefectCategorization2Details":
					this.GeneratorDefectCategorization2Details.Add((GeneratorDefectCategorization2DetailsEntity)relatedEntity);
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

				case "GeneratorDefectCategorization2Details":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization2Details, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.GeneratorDefectCategorization2Details);

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
				info.AddValue("_generatorDefectCategorization2Details", ((_generatorDefectCategorization2Details!=null) && (_generatorDefectCategorization2Details.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization2Details:null);
				info.AddValue("_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details", ((_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details!=null) && (_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details.Count>0) && !this.MarkedForDeletion)?_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorDefectCategorization2FieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorDefectCategorization2FieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorDefectCategorization2Relations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization2Details' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization2Details()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorization2DetailsFields.GeneratorDefectCategorization2Id, null, ComparisonOperator.Equal, this.GeneratorDefectCategorizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorComponentDamage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorDefectCategorization2Entity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorDefectCategorization2Id, "GeneratorDefectCategorization2Entity__", "GeneratorDefectCategorization2Details_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorComponentDamageEntityUsingGeneratorComponentDamage, "GeneratorDefectCategorization2Details_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorization2Fields.GeneratorDefectCategorizationId, null, ComparisonOperator.Equal, this.GeneratorDefectCategorizationId, "GeneratorDefectCategorization2Entity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2EntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._generatorDefectCategorization2Details);
			collectionsQueue.Enqueue(this._generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._generatorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2DetailsEntity>) collectionsQueue.Dequeue();
			this._generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details = (EntityCollection<GeneratorComponentDamageEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._generatorDefectCategorization2Details != null)
			{
				return true;
			}
			if (this._generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorization2DetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2DetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorComponentDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorComponentDamageEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("GeneratorDefectCategorization2Details", _generatorDefectCategorization2Details);
			toReturn.Add("GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details", _generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_generatorDefectCategorization2Details!=null)
			{
				_generatorDefectCategorization2Details.ActiveContext = base.ActiveContext;
			}
			if(_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details!=null)
			{
				_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_generatorDefectCategorization2Details = null;
			_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details = null;


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

			_fieldsCustomProperties.Add("GeneratorDefectCategorizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VendorName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Kwtype", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hz", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Manufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CirId", fieldHashtable);
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

			_fieldsCustomProperties.Add("WindingsType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingManufacturerDe", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingTypeDe", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingNumberDe", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LubricationTypeDe", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingManufacturerNde", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingTypeNde", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingNumberNde", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LubricationTypeNde", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrimaryFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SecondaryFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConsequentialDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherFindings", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailureModes", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorDefectCategorization2Entity</param>
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
		public  static GeneratorDefectCategorization2Relations Relations
		{
			get	{ return new GeneratorDefectCategorization2Relations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization2Details' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization2Details
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorization2DetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2DetailsEntityFactory))),
					GeneratorDefectCategorization2Entity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorDefectCategorization2Id, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity, 0, null, null, null, null, "GeneratorDefectCategorization2Details", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorComponentDamage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorDefectCategorization2Entity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorDefectCategorization2Id;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization2Details_");
				relations.Add(GeneratorDefectCategorization2Entity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorDefectCategorization2Id, "GeneratorDefectCategorization2Entity__", "GeneratorDefectCategorization2Details_", JoinHint.None);
				relations.Add(GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorComponentDamageEntityUsingGeneratorComponentDamage, "GeneratorDefectCategorization2Details_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorComponentDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorComponentDamageEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity, (int)Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity, 0, null, null, relations, null, "GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorDefectCategorization2Entity.CustomProperties;}
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
			get { return GeneratorDefectCategorization2Entity.FieldsCustomProperties;}
		}

		/// <summary> The GeneratorDefectCategorizationId property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."GeneratorDefectCategorizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 GeneratorDefectCategorizationId
		{
			get { return (System.Int64)GetValue((int)GeneratorDefectCategorization2FieldIndex.GeneratorDefectCategorizationId, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.GeneratorDefectCategorizationId, value); }
		}

		/// <summary> The VendorName property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."VendorName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VendorName
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.VendorName, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.VendorName, value); }
		}

		/// <summary> The GeneratorType property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."GeneratorType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneratorType
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.GeneratorType, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.GeneratorType, value); }
		}

		/// <summary> The Kwtype property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."KWType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Kwtype
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.Kwtype, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.Kwtype, value); }
		}

		/// <summary> The Hz property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."Hz"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Hz
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.Hz, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.Hz, value); }
		}

		/// <summary> The SerialNumber property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SerialNumber
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.SerialNumber, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.SerialNumber, value); }
		}

		/// <summary> The Manufacturer property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."Manufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Manufacturer
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.Manufacturer, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.Manufacturer, value); }
		}

		/// <summary> The CirId property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."CirId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CirId
		{
			get { return (System.Int64)GetValue((int)GeneratorDefectCategorization2FieldIndex.CirId, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.CirId, value); }
		}

		/// <summary> The InspectionDate property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."InspectionDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> InspectionDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)GeneratorDefectCategorization2FieldIndex.InspectionDate, false); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.InspectionDate, value); }
		}

		/// <summary> The InspectedBy property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."InspectedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InspectedBy
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.InspectedBy, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.InspectedBy, value); }
		}

		/// <summary> The Email property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.Email, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.Email, value); }
		}

		/// <summary> The RepairManualNumber property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."RepairManualNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RepairManualNumber
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.RepairManualNumber, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.RepairManualNumber, value); }
		}

		/// <summary> The JobNumber property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."JobNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String JobNumber
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.JobNumber, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.JobNumber, value); }
		}

		/// <summary> The WindingsType property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."WindingsType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WindingsType
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.WindingsType, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.WindingsType, value); }
		}

		/// <summary> The BearingManufacturerDe property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingManufacturerDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingManufacturerDe
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerDe, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerDe, value); }
		}

		/// <summary> The BearingTypeDe property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingTypeDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingTypeDe
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingTypeDe, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingTypeDe, value); }
		}

		/// <summary> The BearingNumberDe property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingNumberDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingNumberDe
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingNumberDe, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingNumberDe, value); }
		}

		/// <summary> The LubricationTypeDe property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."LubricationTypeDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LubricationTypeDe
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.LubricationTypeDe, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.LubricationTypeDe, value); }
		}

		/// <summary> The BearingManufacturerNde property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingManufacturerNDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingManufacturerNde
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerNde, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerNde, value); }
		}

		/// <summary> The BearingTypeNde property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingTypeNDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingTypeNde
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingTypeNde, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingTypeNde, value); }
		}

		/// <summary> The BearingNumberNde property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."BearingNumberNDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BearingNumberNde
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.BearingNumberNde, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.BearingNumberNde, value); }
		}

		/// <summary> The LubricationTypeNde property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."LubricationTypeNDE"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LubricationTypeNde
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.LubricationTypeNde, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.LubricationTypeNde, value); }
		}

		/// <summary> The PrimaryFailure property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."PrimaryFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PrimaryFailure
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.PrimaryFailure, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.PrimaryFailure, value); }
		}

		/// <summary> The SecondaryFailure property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."SecondaryFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SecondaryFailure
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.SecondaryFailure, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.SecondaryFailure, value); }
		}

		/// <summary> The ConsequentialDamage property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."ConsequentialDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 150<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ConsequentialDamage
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.ConsequentialDamage, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.ConsequentialDamage, value); }
		}

		/// <summary> The OtherFindings property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."OtherFindings"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OtherFindings
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.OtherFindings, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.OtherFindings, value); }
		}

		/// <summary> The FailureModes property of the Entity GeneratorDefectCategorization2<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2"."FailureModes"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FailureModes
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2FieldIndex.FailureModes, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2FieldIndex.FailureModes, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorization2DetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorization2DetailsEntity))]
		public virtual EntityCollection<GeneratorDefectCategorization2DetailsEntity> GeneratorDefectCategorization2Details
		{
			get
			{
				if(_generatorDefectCategorization2Details==null)
				{
					_generatorDefectCategorization2Details = new EntityCollection<GeneratorDefectCategorization2DetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2DetailsEntityFactory)));
					_generatorDefectCategorization2Details.SetContainingEntityInfo(this, "GeneratorDefectCategorization2");
				}
				return _generatorDefectCategorization2Details;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorComponentDamageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorComponentDamageEntity))]
		public virtual EntityCollection<GeneratorComponentDamageEntity> GeneratorComponentDamageCollectionViaGeneratorDefectCategorization2Details
		{
			get
			{
				if(_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details==null)
				{
					_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details = new EntityCollection<GeneratorComponentDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorComponentDamageEntityFactory)));
					_generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details.IsReadOnly=true;
				}
				return _generatorComponentDamageCollectionViaGeneratorDefectCategorization2Details;
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity; }
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
