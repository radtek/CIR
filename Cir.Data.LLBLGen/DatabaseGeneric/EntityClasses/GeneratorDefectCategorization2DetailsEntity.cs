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
	/// Entity class which represents the entity 'GeneratorDefectCategorization2Details'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorDefectCategorization2DetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private GeneratorComponentDamageEntity _generatorComponentDamage_;
		private GeneratorDefectCategorization2Entity _generatorDefectCategorization2;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name GeneratorComponentDamage_</summary>
			public static readonly string GeneratorComponentDamage_ = "GeneratorComponentDamage_";
			/// <summary>Member name GeneratorDefectCategorization2</summary>
			public static readonly string GeneratorDefectCategorization2 = "GeneratorDefectCategorization2";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorDefectCategorization2DetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorDefectCategorization2DetailsEntity():base("GeneratorDefectCategorization2DetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorDefectCategorization2DetailsEntity(IEntityFields2 fields):base("GeneratorDefectCategorization2DetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorization2DetailsEntity</param>
		public GeneratorDefectCategorization2DetailsEntity(IValidator validator):base("GeneratorDefectCategorization2DetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorization2Id">PK value for GeneratorDefectCategorization2Details which data should be fetched into this GeneratorDefectCategorization2Details object</param>
		/// <param name="generatorComponentDamage">PK value for GeneratorDefectCategorization2Details which data should be fetched into this GeneratorDefectCategorization2Details object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorization2DetailsEntity(System.Int64 generatorDefectCategorization2Id, System.Int32 generatorComponentDamage):base("GeneratorDefectCategorization2DetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GeneratorDefectCategorization2Id = generatorDefectCategorization2Id;
			this.GeneratorComponentDamage = generatorComponentDamage;
		}

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorization2Id">PK value for GeneratorDefectCategorization2Details which data should be fetched into this GeneratorDefectCategorization2Details object</param>
		/// <param name="generatorComponentDamage">PK value for GeneratorDefectCategorization2Details which data should be fetched into this GeneratorDefectCategorization2Details object</param>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorization2DetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorization2DetailsEntity(System.Int64 generatorDefectCategorization2Id, System.Int32 generatorComponentDamage, IValidator validator):base("GeneratorDefectCategorization2DetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GeneratorDefectCategorization2Id = generatorDefectCategorization2Id;
			this.GeneratorComponentDamage = generatorComponentDamage;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorDefectCategorization2DetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_generatorComponentDamage_ = (GeneratorComponentDamageEntity)info.GetValue("_generatorComponentDamage_", typeof(GeneratorComponentDamageEntity));
				if(_generatorComponentDamage_!=null)
				{
					_generatorComponentDamage_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorDefectCategorization2 = (GeneratorDefectCategorization2Entity)info.GetValue("_generatorDefectCategorization2", typeof(GeneratorDefectCategorization2Entity));
				if(_generatorDefectCategorization2!=null)
				{
					_generatorDefectCategorization2.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((GeneratorDefectCategorization2DetailsFieldIndex)fieldIndex)
			{
				case GeneratorDefectCategorization2DetailsFieldIndex.GeneratorDefectCategorization2Id:
					DesetupSyncGeneratorDefectCategorization2(true, false);
					break;
				case GeneratorDefectCategorization2DetailsFieldIndex.GeneratorComponentDamage:
					DesetupSyncGeneratorComponentDamage_(true, false);
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
				case "GeneratorComponentDamage_":
					this.GeneratorComponentDamage_ = (GeneratorComponentDamageEntity)entity;
					break;
				case "GeneratorDefectCategorization2":
					this.GeneratorDefectCategorization2 = (GeneratorDefectCategorization2Entity)entity;
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
				case "GeneratorComponentDamage_":
					SetupSyncGeneratorComponentDamage_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization2":
					SetupSyncGeneratorDefectCategorization2(relatedEntity);
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
				case "GeneratorComponentDamage_":
					DesetupSyncGeneratorComponentDamage_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization2":
					DesetupSyncGeneratorDefectCategorization2(false, true);
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
			if(_generatorComponentDamage_!=null)
			{
				toReturn.Add(_generatorComponentDamage_);
			}
			if(_generatorDefectCategorization2!=null)
			{
				toReturn.Add(_generatorDefectCategorization2);
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


				info.AddValue("_generatorComponentDamage_", (!this.MarkedForDeletion?_generatorComponentDamage_:null));
				info.AddValue("_generatorDefectCategorization2", (!this.MarkedForDeletion?_generatorDefectCategorization2:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorDefectCategorization2DetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorDefectCategorization2DetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorDefectCategorization2DetailsRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorComponentDamage' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorComponentDamage_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorComponentDamageFields.Id, null, ComparisonOperator.Equal, this.GeneratorComponentDamage));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorDefectCategorization2' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization2()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorization2Fields.GeneratorDefectCategorizationId, null, ComparisonOperator.Equal, this.GeneratorDefectCategorization2Id));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2DetailsEntityFactory));
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
			toReturn.Add("GeneratorComponentDamage_", _generatorComponentDamage_);
			toReturn.Add("GeneratorDefectCategorization2", _generatorDefectCategorization2);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_generatorComponentDamage_!=null)
			{
				_generatorComponentDamage_.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization2!=null)
			{
				_generatorDefectCategorization2.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_generatorComponentDamage_ = null;
			_generatorDefectCategorization2 = null;

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

			_fieldsCustomProperties.Add("GeneratorDefectCategorization2Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorComponentDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDamage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Repair", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailureMode", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _generatorComponentDamage_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorComponentDamage_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorComponentDamage_, new PropertyChangedEventHandler( OnGeneratorComponentDamage_PropertyChanged ), "GeneratorComponentDamage_", GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorComponentDamageEntityUsingGeneratorComponentDamage, true, signalRelatedEntity, "GeneratorDefectCategorization2Details", resetFKFields, new int[] { (int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorComponentDamage } );		
			_generatorComponentDamage_ = null;
		}

		/// <summary> setups the sync logic for member _generatorComponentDamage_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorComponentDamage_(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorComponentDamage_(true, true);
			_generatorComponentDamage_ = (GeneratorComponentDamageEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorComponentDamage_, new PropertyChangedEventHandler( OnGeneratorComponentDamage_PropertyChanged ), "GeneratorComponentDamage_", GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorComponentDamageEntityUsingGeneratorComponentDamage, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorComponentDamage_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorDefectCategorization2</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorDefectCategorization2(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorDefectCategorization2, new PropertyChangedEventHandler( OnGeneratorDefectCategorization2PropertyChanged ), "GeneratorDefectCategorization2", GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id, true, signalRelatedEntity, "GeneratorDefectCategorization2Details", resetFKFields, new int[] { (int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorDefectCategorization2Id } );		
			_generatorDefectCategorization2 = null;
		}

		/// <summary> setups the sync logic for member _generatorDefectCategorization2</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorDefectCategorization2(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorDefectCategorization2(true, true);
			_generatorDefectCategorization2 = (GeneratorDefectCategorization2Entity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorDefectCategorization2, new PropertyChangedEventHandler( OnGeneratorDefectCategorization2PropertyChanged ), "GeneratorDefectCategorization2", GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorDefectCategorization2PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorDefectCategorization2DetailsEntity</param>
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
		public  static GeneratorDefectCategorization2DetailsRelations Relations
		{
			get	{ return new GeneratorDefectCategorization2DetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorComponentDamage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorComponentDamage_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorComponentDamageEntityFactory))),
					GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorComponentDamageEntityUsingGeneratorComponentDamage, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity, 0, null, null, null, null, "GeneratorComponentDamage_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization2' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization2
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorization2EntityFactory))),
					GeneratorDefectCategorization2DetailsEntity.Relations.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity, 0, null, null, null, null, "GeneratorDefectCategorization2", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorDefectCategorization2DetailsEntity.CustomProperties;}
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
			get { return GeneratorDefectCategorization2DetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The GeneratorDefectCategorization2Id property of the Entity GeneratorDefectCategorization2Details<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2Details"."GeneratorDefectCategorization2Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 GeneratorDefectCategorization2Id
		{
			get { return (System.Int64)GetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorDefectCategorization2Id, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorDefectCategorization2Id, value); }
		}

		/// <summary> The GeneratorComponentDamage property of the Entity GeneratorDefectCategorization2Details<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2Details"."GeneratorComponentDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 GeneratorComponentDamage
		{
			get { return (System.Int32)GetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorComponentDamage, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorComponentDamage, value); }
		}

		/// <summary> The IsDamage property of the Entity GeneratorDefectCategorization2Details<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2Details"."IsDamage"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String IsDamage
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.IsDamage, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.IsDamage, value); }
		}

		/// <summary> The Repair property of the Entity GeneratorDefectCategorization2Details<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2Details"."Repair"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Repair
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.Repair, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.Repair, value); }
		}

		/// <summary> The FailureMode property of the Entity GeneratorDefectCategorization2Details<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization2Details"."FailureMode"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FailureMode
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.FailureMode, true); }
			set	{ SetValue((int)GeneratorDefectCategorization2DetailsFieldIndex.FailureMode, value); }
		}



		/// <summary> Gets / sets related entity of type 'GeneratorComponentDamageEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorComponentDamageEntity GeneratorComponentDamage_
		{
			get
			{
				return _generatorComponentDamage_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorComponentDamage_(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorComponentDamage_ != null)
						{
							_generatorComponentDamage_.UnsetRelatedEntity(this, "GeneratorDefectCategorization2Details");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization2Details");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorDefectCategorization2Entity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorDefectCategorization2Entity GeneratorDefectCategorization2
		{
			get
			{
				return _generatorDefectCategorization2;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorDefectCategorization2(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorDefectCategorization2 != null)
						{
							_generatorDefectCategorization2.UnsetRelatedEntity(this, "GeneratorDefectCategorization2Details");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization2Details");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity; }
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
