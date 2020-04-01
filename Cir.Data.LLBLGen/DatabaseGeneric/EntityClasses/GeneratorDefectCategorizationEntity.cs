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
	/// Entity class which represents the entity 'GeneratorDefectCategorization'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorDefectCategorizationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ComponentInspectionReportGeneratorEntity _componentInspectionReportGenerator;
		private GeneratorMiscDecisionEntity _generatorMiscDecision___;
		private GeneratorMiscDecisionEntity _generatorMiscDecision____;
		private GeneratorMiscDecisionEntity _generatorMiscDecision__;
		private GeneratorMiscDecisionEntity _generatorMiscDecision;
		private GeneratorMiscDecisionEntity _generatorMiscDecision_;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ComponentInspectionReportGenerator</summary>
			public static readonly string ComponentInspectionReportGenerator = "ComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorMiscDecision___</summary>
			public static readonly string GeneratorMiscDecision___ = "GeneratorMiscDecision___";
			/// <summary>Member name GeneratorMiscDecision____</summary>
			public static readonly string GeneratorMiscDecision____ = "GeneratorMiscDecision____";
			/// <summary>Member name GeneratorMiscDecision__</summary>
			public static readonly string GeneratorMiscDecision__ = "GeneratorMiscDecision__";
			/// <summary>Member name GeneratorMiscDecision</summary>
			public static readonly string GeneratorMiscDecision = "GeneratorMiscDecision";
			/// <summary>Member name GeneratorMiscDecision_</summary>
			public static readonly string GeneratorMiscDecision_ = "GeneratorMiscDecision_";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorDefectCategorizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorDefectCategorizationEntity():base("GeneratorDefectCategorizationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorDefectCategorizationEntity(IEntityFields2 fields):base("GeneratorDefectCategorizationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorizationEntity</param>
		public GeneratorDefectCategorizationEntity(IValidator validator):base("GeneratorDefectCategorizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorizationId">PK value for GeneratorDefectCategorization which data should be fetched into this GeneratorDefectCategorization object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorizationEntity(System.Int64 generatorDefectCategorizationId):base("GeneratorDefectCategorizationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GeneratorDefectCategorizationId = generatorDefectCategorizationId;
		}

		/// <summary> CTor</summary>
		/// <param name="generatorDefectCategorizationId">PK value for GeneratorDefectCategorization which data should be fetched into this GeneratorDefectCategorization object</param>
		/// <param name="validator">The custom validator object for this GeneratorDefectCategorizationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorDefectCategorizationEntity(System.Int64 generatorDefectCategorizationId, IValidator validator):base("GeneratorDefectCategorizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GeneratorDefectCategorizationId = generatorDefectCategorizationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorDefectCategorizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_componentInspectionReportGenerator = (ComponentInspectionReportGeneratorEntity)info.GetValue("_componentInspectionReportGenerator", typeof(ComponentInspectionReportGeneratorEntity));
				if(_componentInspectionReportGenerator!=null)
				{
					_componentInspectionReportGenerator.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorMiscDecision___ = (GeneratorMiscDecisionEntity)info.GetValue("_generatorMiscDecision___", typeof(GeneratorMiscDecisionEntity));
				if(_generatorMiscDecision___!=null)
				{
					_generatorMiscDecision___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorMiscDecision____ = (GeneratorMiscDecisionEntity)info.GetValue("_generatorMiscDecision____", typeof(GeneratorMiscDecisionEntity));
				if(_generatorMiscDecision____!=null)
				{
					_generatorMiscDecision____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorMiscDecision__ = (GeneratorMiscDecisionEntity)info.GetValue("_generatorMiscDecision__", typeof(GeneratorMiscDecisionEntity));
				if(_generatorMiscDecision__!=null)
				{
					_generatorMiscDecision__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorMiscDecision = (GeneratorMiscDecisionEntity)info.GetValue("_generatorMiscDecision", typeof(GeneratorMiscDecisionEntity));
				if(_generatorMiscDecision!=null)
				{
					_generatorMiscDecision.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorMiscDecision_ = (GeneratorMiscDecisionEntity)info.GetValue("_generatorMiscDecision_", typeof(GeneratorMiscDecisionEntity));
				if(_generatorMiscDecision_!=null)
				{
					_generatorMiscDecision_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((GeneratorDefectCategorizationFieldIndex)fieldIndex)
			{
				case GeneratorDefectCategorizationFieldIndex.MiscBearingDecision:
					DesetupSyncGeneratorMiscDecision(true, false);
					break;
				case GeneratorDefectCategorizationFieldIndex.MiscGeneratorDecision:
					DesetupSyncGeneratorMiscDecision_(true, false);
					break;
				case GeneratorDefectCategorizationFieldIndex.MiscWaterDecision:
					DesetupSyncGeneratorMiscDecision____(true, false);
					break;
				case GeneratorDefectCategorizationFieldIndex.MiscPtsensorDecision:
					DesetupSyncGeneratorMiscDecision___(true, false);
					break;
				case GeneratorDefectCategorizationFieldIndex.MiscGroundingDecision:
					DesetupSyncGeneratorMiscDecision__(true, false);
					break;
				case GeneratorDefectCategorizationFieldIndex.ComponentInspectionReportGeneratorId:
					DesetupSyncComponentInspectionReportGenerator(true, false);
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
				case "ComponentInspectionReportGenerator":
					this.ComponentInspectionReportGenerator = (ComponentInspectionReportGeneratorEntity)entity;
					break;
				case "GeneratorMiscDecision___":
					this.GeneratorMiscDecision___ = (GeneratorMiscDecisionEntity)entity;
					break;
				case "GeneratorMiscDecision____":
					this.GeneratorMiscDecision____ = (GeneratorMiscDecisionEntity)entity;
					break;
				case "GeneratorMiscDecision__":
					this.GeneratorMiscDecision__ = (GeneratorMiscDecisionEntity)entity;
					break;
				case "GeneratorMiscDecision":
					this.GeneratorMiscDecision = (GeneratorMiscDecisionEntity)entity;
					break;
				case "GeneratorMiscDecision_":
					this.GeneratorMiscDecision_ = (GeneratorMiscDecisionEntity)entity;
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
				case "ComponentInspectionReportGenerator":
					SetupSyncComponentInspectionReportGenerator(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision___":
					SetupSyncGeneratorMiscDecision___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision____":
					SetupSyncGeneratorMiscDecision____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision__":
					SetupSyncGeneratorMiscDecision__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision":
					SetupSyncGeneratorMiscDecision(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision_":
					SetupSyncGeneratorMiscDecision_(relatedEntity);
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
				case "ComponentInspectionReportGenerator":
					DesetupSyncComponentInspectionReportGenerator(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision___":
					DesetupSyncGeneratorMiscDecision___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision____":
					DesetupSyncGeneratorMiscDecision____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision__":
					DesetupSyncGeneratorMiscDecision__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision":
					DesetupSyncGeneratorMiscDecision(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorMiscDecision_":
					DesetupSyncGeneratorMiscDecision_(false, true);
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
			if(_componentInspectionReportGenerator!=null)
			{
				toReturn.Add(_componentInspectionReportGenerator);
			}
			if(_generatorMiscDecision___!=null)
			{
				toReturn.Add(_generatorMiscDecision___);
			}
			if(_generatorMiscDecision____!=null)
			{
				toReturn.Add(_generatorMiscDecision____);
			}
			if(_generatorMiscDecision__!=null)
			{
				toReturn.Add(_generatorMiscDecision__);
			}
			if(_generatorMiscDecision!=null)
			{
				toReturn.Add(_generatorMiscDecision);
			}
			if(_generatorMiscDecision_!=null)
			{
				toReturn.Add(_generatorMiscDecision_);
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


				info.AddValue("_componentInspectionReportGenerator", (!this.MarkedForDeletion?_componentInspectionReportGenerator:null));
				info.AddValue("_generatorMiscDecision___", (!this.MarkedForDeletion?_generatorMiscDecision___:null));
				info.AddValue("_generatorMiscDecision____", (!this.MarkedForDeletion?_generatorMiscDecision____:null));
				info.AddValue("_generatorMiscDecision__", (!this.MarkedForDeletion?_generatorMiscDecision__:null));
				info.AddValue("_generatorMiscDecision", (!this.MarkedForDeletion?_generatorMiscDecision:null));
				info.AddValue("_generatorMiscDecision_", (!this.MarkedForDeletion?_generatorMiscDecision_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorDefectCategorizationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorDefectCategorizationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorDefectCategorizationRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecision___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.MiscPtsensorDecision));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecision____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.MiscWaterDecision));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecision__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.MiscGroundingDecision));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.MiscBearingDecision));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecision_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.MiscGeneratorDecision));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory));
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
			toReturn.Add("ComponentInspectionReportGenerator", _componentInspectionReportGenerator);
			toReturn.Add("GeneratorMiscDecision___", _generatorMiscDecision___);
			toReturn.Add("GeneratorMiscDecision____", _generatorMiscDecision____);
			toReturn.Add("GeneratorMiscDecision__", _generatorMiscDecision__);
			toReturn.Add("GeneratorMiscDecision", _generatorMiscDecision);
			toReturn.Add("GeneratorMiscDecision_", _generatorMiscDecision_);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_componentInspectionReportGenerator!=null)
			{
				_componentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecision___!=null)
			{
				_generatorMiscDecision___.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecision____!=null)
			{
				_generatorMiscDecision____.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecision__!=null)
			{
				_generatorMiscDecision__.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecision!=null)
			{
				_generatorMiscDecision.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecision_!=null)
			{
				_generatorMiscDecision_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_componentInspectionReportGenerator = null;
			_generatorMiscDecision___ = null;
			_generatorMiscDecision____ = null;
			_generatorMiscDecision__ = null;
			_generatorMiscDecision = null;
			_generatorMiscDecision_ = null;

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

			_fieldsCustomProperties.Add("StatorInsulation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StatorInductive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StatorVibrations", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StatorDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorInsulation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorInductive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorVibrations", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorPostFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorLeadInsulation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorLeadConnection", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RotorLeadDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhaseDamaged", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhaseDamagedDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsBearingFailure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsInnerRace", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsOuterRace", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsNoise", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsVibrations", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsSeal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BearingsDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscBearing", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscBearingDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscGenerator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscGeneratorDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscWater", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscWaterDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscPtsensor", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscPtsensorDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscGrounding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiscGroundingDecision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefectCategory", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RepairManualNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportGeneratorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Source", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Timestamp", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _componentInspectionReportGenerator</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReportGenerator(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReportGenerator, new PropertyChangedEventHandler( OnComponentInspectionReportGeneratorPropertyChanged ), "ComponentInspectionReportGenerator", GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, true, signalRelatedEntity, "GeneratorDefectCategorization", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.ComponentInspectionReportGeneratorId } );		
			_componentInspectionReportGenerator = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReportGenerator</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReportGenerator(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReportGenerator(true, true);
			_componentInspectionReportGenerator = (ComponentInspectionReportGeneratorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReportGenerator, new PropertyChangedEventHandler( OnComponentInspectionReportGeneratorPropertyChanged ), "ComponentInspectionReportGenerator", GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportGeneratorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorMiscDecision___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorMiscDecision___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorMiscDecision___, new PropertyChangedEventHandler( OnGeneratorMiscDecision___PropertyChanged ), "GeneratorMiscDecision___", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision, true, signalRelatedEntity, "GeneratorDefectCategorization___", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.MiscPtsensorDecision } );		
			_generatorMiscDecision___ = null;
		}

		/// <summary> setups the sync logic for member _generatorMiscDecision___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorMiscDecision___(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorMiscDecision___(true, true);
			_generatorMiscDecision___ = (GeneratorMiscDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorMiscDecision___, new PropertyChangedEventHandler( OnGeneratorMiscDecision___PropertyChanged ), "GeneratorMiscDecision___", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorMiscDecision___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorMiscDecision____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorMiscDecision____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorMiscDecision____, new PropertyChangedEventHandler( OnGeneratorMiscDecision____PropertyChanged ), "GeneratorMiscDecision____", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscWaterDecision, true, signalRelatedEntity, "GeneratorDefectCategorization____", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.MiscWaterDecision } );		
			_generatorMiscDecision____ = null;
		}

		/// <summary> setups the sync logic for member _generatorMiscDecision____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorMiscDecision____(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorMiscDecision____(true, true);
			_generatorMiscDecision____ = (GeneratorMiscDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorMiscDecision____, new PropertyChangedEventHandler( OnGeneratorMiscDecision____PropertyChanged ), "GeneratorMiscDecision____", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscWaterDecision, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorMiscDecision____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorMiscDecision__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorMiscDecision__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorMiscDecision__, new PropertyChangedEventHandler( OnGeneratorMiscDecision__PropertyChanged ), "GeneratorMiscDecision__", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGroundingDecision, true, signalRelatedEntity, "GeneratorDefectCategorization__", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.MiscGroundingDecision } );		
			_generatorMiscDecision__ = null;
		}

		/// <summary> setups the sync logic for member _generatorMiscDecision__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorMiscDecision__(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorMiscDecision__(true, true);
			_generatorMiscDecision__ = (GeneratorMiscDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorMiscDecision__, new PropertyChangedEventHandler( OnGeneratorMiscDecision__PropertyChanged ), "GeneratorMiscDecision__", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGroundingDecision, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorMiscDecision__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorMiscDecision</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorMiscDecision(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorMiscDecision, new PropertyChangedEventHandler( OnGeneratorMiscDecisionPropertyChanged ), "GeneratorMiscDecision", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscBearingDecision, true, signalRelatedEntity, "GeneratorDefectCategorization", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.MiscBearingDecision } );		
			_generatorMiscDecision = null;
		}

		/// <summary> setups the sync logic for member _generatorMiscDecision</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorMiscDecision(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorMiscDecision(true, true);
			_generatorMiscDecision = (GeneratorMiscDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorMiscDecision, new PropertyChangedEventHandler( OnGeneratorMiscDecisionPropertyChanged ), "GeneratorMiscDecision", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscBearingDecision, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorMiscDecisionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorMiscDecision_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorMiscDecision_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorMiscDecision_, new PropertyChangedEventHandler( OnGeneratorMiscDecision_PropertyChanged ), "GeneratorMiscDecision_", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision, true, signalRelatedEntity, "GeneratorDefectCategorization_", resetFKFields, new int[] { (int)GeneratorDefectCategorizationFieldIndex.MiscGeneratorDecision } );		
			_generatorMiscDecision_ = null;
		}

		/// <summary> setups the sync logic for member _generatorMiscDecision_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorMiscDecision_(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorMiscDecision_(true, true);
			_generatorMiscDecision_ = (GeneratorMiscDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorMiscDecision_, new PropertyChangedEventHandler( OnGeneratorMiscDecision_PropertyChanged ), "GeneratorMiscDecision_", GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorMiscDecision_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorDefectCategorizationEntity</param>
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
		public  static GeneratorDefectCategorizationRelations Relations
		{
			get	{ return new GeneratorDefectCategorizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecision___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, null, null, "GeneratorMiscDecision___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecision____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscWaterDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, null, null, "GeneratorMiscDecision____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecision__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGroundingDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, null, null, "GeneratorMiscDecision__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecision
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscBearingDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, null, null, "GeneratorMiscDecision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecision_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),
					GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, null, null, "GeneratorMiscDecision_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorDefectCategorizationEntity.CustomProperties;}
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
			get { return GeneratorDefectCategorizationEntity.FieldsCustomProperties;}
		}

		/// <summary> The GeneratorDefectCategorizationId property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."GeneratorDefectCategorizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 GeneratorDefectCategorizationId
		{
			get { return (System.Int64)GetValue((int)GeneratorDefectCategorizationFieldIndex.GeneratorDefectCategorizationId, true); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.GeneratorDefectCategorizationId, value); }
		}

		/// <summary> The StatorInsulation property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."StatorInsulation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> StatorInsulation
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.StatorInsulation, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.StatorInsulation, value); }
		}

		/// <summary> The StatorInductive property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."StatorInductive"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> StatorInductive
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.StatorInductive, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.StatorInductive, value); }
		}

		/// <summary> The StatorVibrations property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."StatorVibrations"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> StatorVibrations
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.StatorVibrations, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.StatorVibrations, value); }
		}

		/// <summary> The StatorDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."StatorDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> StatorDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.StatorDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.StatorDecision, value); }
		}

		/// <summary> The RotorInsulation property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorInsulation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorInsulation
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorInsulation, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorInsulation, value); }
		}

		/// <summary> The RotorInductive property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorInductive"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorInductive
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorInductive, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorInductive, value); }
		}

		/// <summary> The RotorVibrations property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorVibrations"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorVibrations
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorVibrations, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorVibrations, value); }
		}

		/// <summary> The RotorPostFailure property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorPostFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorPostFailure
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorPostFailure, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorPostFailure, value); }
		}

		/// <summary> The RotorDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> RotorDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorDecision, value); }
		}

		/// <summary> The RotorLeadInsulation property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorLeadInsulation"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorLeadInsulation
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadInsulation, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadInsulation, value); }
		}

		/// <summary> The RotorLeadConnection property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorLeadConnection"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RotorLeadConnection
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadConnection, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadConnection, value); }
		}

		/// <summary> The RotorLeadDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RotorLeadDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> RotorLeadDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RotorLeadDecision, value); }
		}

		/// <summary> The PhaseDamaged property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."PhaseDamaged"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PhaseDamaged
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.PhaseDamaged, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.PhaseDamaged, value); }
		}

		/// <summary> The PhaseDamagedDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."PhaseDamagedDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PhaseDamagedDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.PhaseDamagedDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.PhaseDamagedDecision, value); }
		}

		/// <summary> The BearingsBearingFailure property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsBearingFailure"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsBearingFailure
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsBearingFailure, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsBearingFailure, value); }
		}

		/// <summary> The BearingsInnerRace property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsInnerRace"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsInnerRace
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsInnerRace, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsInnerRace, value); }
		}

		/// <summary> The BearingsOuterRace property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsOuterRace"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsOuterRace
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsOuterRace, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsOuterRace, value); }
		}

		/// <summary> The BearingsNoise property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsNoise"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsNoise
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsNoise, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsNoise, value); }
		}

		/// <summary> The BearingsVibrations property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsVibrations"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsVibrations
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsVibrations, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsVibrations, value); }
		}

		/// <summary> The BearingsSeal property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsSeal"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BearingsSeal
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsSeal, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsSeal, value); }
		}

		/// <summary> The BearingsDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."BearingsDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> BearingsDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.BearingsDecision, value); }
		}

		/// <summary> The MiscBearing property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscBearing"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MiscBearing
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscBearing, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscBearing, value); }
		}

		/// <summary> The MiscBearingDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscBearingDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MiscBearingDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscBearingDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscBearingDecision, value); }
		}

		/// <summary> The MiscGenerator property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscGenerator"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MiscGenerator
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGenerator, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGenerator, value); }
		}

		/// <summary> The MiscGeneratorDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscGeneratorDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MiscGeneratorDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGeneratorDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGeneratorDecision, value); }
		}

		/// <summary> The MiscWater property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscWater"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MiscWater
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscWater, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscWater, value); }
		}

		/// <summary> The MiscWaterDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscWaterDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MiscWaterDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscWaterDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscWaterDecision, value); }
		}

		/// <summary> The MiscPtsensor property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscPTSensor"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MiscPtsensor
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscPtsensor, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscPtsensor, value); }
		}

		/// <summary> The MiscPtsensorDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscPTSensorDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MiscPtsensorDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscPtsensorDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscPtsensorDecision, value); }
		}

		/// <summary> The MiscGrounding property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscGrounding"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MiscGrounding
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGrounding, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGrounding, value); }
		}

		/// <summary> The MiscGroundingDecision property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."MiscGroundingDecision"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MiscGroundingDecision
		{
			get { return (Nullable<System.Int32>)GetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGroundingDecision, false); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.MiscGroundingDecision, value); }
		}

		/// <summary> The DefectCategory property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."DefectCategory"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefectCategory
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorizationFieldIndex.DefectCategory, true); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.DefectCategory, value); }
		}

		/// <summary> The RepairManualNumber property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."RepairManualNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String RepairManualNumber
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorizationFieldIndex.RepairManualNumber, true); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.RepairManualNumber, value); }
		}

		/// <summary> The ComponentInspectionReportGeneratorId property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."ComponentInspectionReportGeneratorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportGeneratorId
		{
			get { return (System.Int64)GetValue((int)GeneratorDefectCategorizationFieldIndex.ComponentInspectionReportGeneratorId, true); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.ComponentInspectionReportGeneratorId, value); }
		}

		/// <summary> The Source property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."Source"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Source
		{
			get { return (System.String)GetValue((int)GeneratorDefectCategorizationFieldIndex.Source, true); }
			set	{ SetValue((int)GeneratorDefectCategorizationFieldIndex.Source, value); }
		}

		/// <summary> The Timestamp property of the Entity GeneratorDefectCategorization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorDefectCategorization"."Timestamp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] Timestamp
		{
			get { return (System.Byte[])GetValue((int)GeneratorDefectCategorizationFieldIndex.Timestamp, true); }

		}



		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportGeneratorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportGeneratorEntity ComponentInspectionReportGenerator
		{
			get
			{
				return _componentInspectionReportGenerator;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReportGenerator(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReportGenerator != null)
						{
							_componentInspectionReportGenerator.UnsetRelatedEntity(this, "GeneratorDefectCategorization");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorMiscDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorMiscDecisionEntity GeneratorMiscDecision___
		{
			get
			{
				return _generatorMiscDecision___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorMiscDecision___(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorMiscDecision___ != null)
						{
							_generatorMiscDecision___.UnsetRelatedEntity(this, "GeneratorDefectCategorization___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorMiscDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorMiscDecisionEntity GeneratorMiscDecision____
		{
			get
			{
				return _generatorMiscDecision____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorMiscDecision____(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorMiscDecision____ != null)
						{
							_generatorMiscDecision____.UnsetRelatedEntity(this, "GeneratorDefectCategorization____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorMiscDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorMiscDecisionEntity GeneratorMiscDecision__
		{
			get
			{
				return _generatorMiscDecision__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorMiscDecision__(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorMiscDecision__ != null)
						{
							_generatorMiscDecision__.UnsetRelatedEntity(this, "GeneratorDefectCategorization__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorMiscDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorMiscDecisionEntity GeneratorMiscDecision
		{
			get
			{
				return _generatorMiscDecision;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorMiscDecision(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorMiscDecision != null)
						{
							_generatorMiscDecision.UnsetRelatedEntity(this, "GeneratorDefectCategorization");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorMiscDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorMiscDecisionEntity GeneratorMiscDecision_
		{
			get
			{
				return _generatorMiscDecision_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorMiscDecision_(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorMiscDecision_ != null)
						{
							_generatorMiscDecision_.UnsetRelatedEntity(this, "GeneratorDefectCategorization_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorDefectCategorization_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity; }
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
