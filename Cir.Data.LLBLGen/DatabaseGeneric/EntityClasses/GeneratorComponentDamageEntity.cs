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
	/// Entity class which represents the entity 'GeneratorComponentDamage'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorComponentDamageEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GeneratorDefectCategorization2DetailsEntity> _generatorDefectCategorization2Details;
		private EntityCollection<GeneratorDefectCategorization2Entity> _generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details;


		
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
			/// <summary>Member name GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details</summary>
			public static readonly string GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details = "GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorComponentDamageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorComponentDamageEntity():base("GeneratorComponentDamageEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorComponentDamageEntity(IEntityFields2 fields):base("GeneratorComponentDamageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorComponentDamageEntity</param>
		public GeneratorComponentDamageEntity(IValidator validator):base("GeneratorComponentDamageEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for GeneratorComponentDamage which data should be fetched into this GeneratorComponentDamage object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorComponentDamageEntity(System.Int32 id):base("GeneratorComponentDamageEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for GeneratorComponentDamage which data should be fetched into this GeneratorComponentDamage object</param>
		/// <param name="validator">The custom validator object for this GeneratorComponentDamageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorComponentDamageEntity(System.Int32 id, IValidator validator):base("GeneratorComponentDamageEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorComponentDamageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_generatorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2DetailsEntity>)info.GetValue("_generatorDefectCategorization2Details", typeof(EntityCollection<GeneratorDefectCategorization2DetailsEntity>));
				_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2Entity>)info.GetValue("_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details", typeof(EntityCollection<GeneratorDefectCategorization2Entity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((GeneratorComponentDamageFieldIndex)fieldIndex)
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
				case "GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details":
					this.GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.IsReadOnly = false;
					this.GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.Add((GeneratorDefectCategorization2Entity)entity);
					this.GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.IsReadOnly = true;
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
				info.AddValue("_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details", ((_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details!=null) && (_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorComponentDamageFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorComponentDamageFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorComponentDamageRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization2Details' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization2Details()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorization2DetailsFields.GeneratorComponentDamage, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization2' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorComponentDamageEntity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage, "GeneratorComponentDamageEntity__", "GeneratorDefectCategorization2Details_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id, "GeneratorDefectCategorization2Details_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorComponentDamageFields.Id, null, ComparisonOperator.Equal, this.Id, "GeneratorComponentDamageEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorComponentDamageEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._generatorDefectCategorization2Details);
			collectionsQueue.Enqueue(this._generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._generatorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2DetailsEntity>) collectionsQueue.Dequeue();
			this._generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details = (EntityCollection<GeneratorDefectCategorization2Entity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._generatorDefectCategorization2Details != null)
			{
				return true;
			}
			if (this._generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorization2Entity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2EntityFactory))) : null);
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
			toReturn.Add("GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details", _generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_generatorDefectCategorization2Details!=null)
			{
				_generatorDefectCategorization2Details.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details!=null)
			{
				_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_generatorDefectCategorization2Details = null;
			_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details = null;


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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Component", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailureDamage", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorComponentDamageEntity</param>
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
		public  static GeneratorComponentDamageRelations Relations
		{
			get	{ return new GeneratorComponentDamageRelations(); }
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
					GeneratorComponentDamageEntity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity, 0, null, null, null, null, "GeneratorDefectCategorization2Details", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization2' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorComponentDamageEntity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization2Details_");
				relations.Add(GeneratorComponentDamageEntity.Relations.GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage, "GeneratorComponentDamageEntity__", "GeneratorDefectCategorization2Details_", JoinHint.None);
				relations.Add(GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id, "GeneratorDefectCategorization2Details_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDefectCategorization2Entity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2EntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity, 0, null, null, relations, null, "GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorComponentDamageEntity.CustomProperties;}
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
			get { return GeneratorComponentDamageEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity GeneratorComponentDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorComponentDamage"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)GeneratorComponentDamageFieldIndex.Id, true); }
			set	{ SetValue((int)GeneratorComponentDamageFieldIndex.Id, value); }
		}

		/// <summary> The Component property of the Entity GeneratorComponentDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorComponentDamage"."Component"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Component
		{
			get { return (System.String)GetValue((int)GeneratorComponentDamageFieldIndex.Component, true); }
			set	{ SetValue((int)GeneratorComponentDamageFieldIndex.Component, value); }
		}

		/// <summary> The FailureDamage property of the Entity GeneratorComponentDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorComponentDamage"."FailureDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FailureDamage
		{
			get { return (System.String)GetValue((int)GeneratorComponentDamageFieldIndex.FailureDamage, true); }
			set	{ SetValue((int)GeneratorComponentDamageFieldIndex.FailureDamage, value); }
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
					_generatorDefectCategorization2Details.SetContainingEntityInfo(this, "GeneratorComponentDamage_");
				}
				return _generatorDefectCategorization2Details;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorization2Entity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorization2Entity))]
		public virtual EntityCollection<GeneratorDefectCategorization2Entity> GeneratorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details
		{
			get
			{
				if(_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details==null)
				{
					_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details = new EntityCollection<GeneratorDefectCategorization2Entity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2EntityFactory)));
					_generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details.IsReadOnly=true;
				}
				return _generatorDefectCategorization2CollectionViaGeneratorDefectCategorization2Details;
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity; }
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
