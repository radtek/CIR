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
	/// Entity class which represents the entity 'GeneratorMiscDecision'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorMiscDecisionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization___;
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization____;
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization__;
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization;
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization_;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{

			/// <summary>Member name GeneratorDefectCategorization___</summary>
			public static readonly string GeneratorDefectCategorization___ = "GeneratorDefectCategorization___";
			/// <summary>Member name GeneratorDefectCategorization____</summary>
			public static readonly string GeneratorDefectCategorization____ = "GeneratorDefectCategorization____";
			/// <summary>Member name GeneratorDefectCategorization__</summary>
			public static readonly string GeneratorDefectCategorization__ = "GeneratorDefectCategorization__";
			/// <summary>Member name GeneratorDefectCategorization</summary>
			public static readonly string GeneratorDefectCategorization = "GeneratorDefectCategorization";
			/// <summary>Member name GeneratorDefectCategorization_</summary>
			public static readonly string GeneratorDefectCategorization_ = "GeneratorDefectCategorization_";
			/// <summary>Member name ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___</summary>
			public static readonly string ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ = "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___";
			/// <summary>Member name ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____</summary>
			public static readonly string ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ = "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____";
			/// <summary>Member name ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__</summary>
			public static readonly string ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ = "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__";
			/// <summary>Member name ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization</summary>
			public static readonly string ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization = "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization";
			/// <summary>Member name ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_</summary>
			public static readonly string ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ = "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorMiscDecisionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorMiscDecisionEntity():base("GeneratorMiscDecisionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorMiscDecisionEntity(IEntityFields2 fields):base("GeneratorMiscDecisionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorMiscDecisionEntity</param>
		public GeneratorMiscDecisionEntity(IValidator validator):base("GeneratorMiscDecisionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="generatorMiscDecisionId">PK value for GeneratorMiscDecision which data should be fetched into this GeneratorMiscDecision object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorMiscDecisionEntity(System.Int32 generatorMiscDecisionId):base("GeneratorMiscDecisionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GeneratorMiscDecisionId = generatorMiscDecisionId;
		}

		/// <summary> CTor</summary>
		/// <param name="generatorMiscDecisionId">PK value for GeneratorMiscDecision which data should be fetched into this GeneratorMiscDecision object</param>
		/// <param name="validator">The custom validator object for this GeneratorMiscDecisionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorMiscDecisionEntity(System.Int32 generatorMiscDecisionId, IValidator validator):base("GeneratorMiscDecisionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GeneratorMiscDecisionId = generatorMiscDecisionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorMiscDecisionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_generatorDefectCategorization___ = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization___", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_generatorDefectCategorization____ = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization____", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_generatorDefectCategorization__ = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization__", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_generatorDefectCategorization = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_generatorDefectCategorization_ = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization_", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((GeneratorMiscDecisionFieldIndex)fieldIndex)
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

				case "GeneratorDefectCategorization___":
					this.GeneratorDefectCategorization___.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "GeneratorDefectCategorization____":
					this.GeneratorDefectCategorization____.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "GeneratorDefectCategorization__":
					this.GeneratorDefectCategorization__.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "GeneratorDefectCategorization":
					this.GeneratorDefectCategorization.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "GeneratorDefectCategorization_":
					this.GeneratorDefectCategorization_.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___":
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.IsReadOnly = false;
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.Add((ComponentInspectionReportGeneratorEntity)entity);
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.IsReadOnly = true;
					break;
				case "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____":
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.IsReadOnly = false;
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.Add((ComponentInspectionReportGeneratorEntity)entity);
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.IsReadOnly = true;
					break;
				case "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__":
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.IsReadOnly = false;
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.Add((ComponentInspectionReportGeneratorEntity)entity);
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.IsReadOnly = true;
					break;
				case "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization":
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.IsReadOnly = false;
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.Add((ComponentInspectionReportGeneratorEntity)entity);
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.IsReadOnly = true;
					break;
				case "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_":
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.IsReadOnly = false;
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.Add((ComponentInspectionReportGeneratorEntity)entity);
					this.ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.IsReadOnly = true;
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

				case "GeneratorDefectCategorization___":
					this.GeneratorDefectCategorization___.Add((GeneratorDefectCategorizationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization____":
					this.GeneratorDefectCategorization____.Add((GeneratorDefectCategorizationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization__":
					this.GeneratorDefectCategorization__.Add((GeneratorDefectCategorizationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization":
					this.GeneratorDefectCategorization.Add((GeneratorDefectCategorizationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization_":
					this.GeneratorDefectCategorization_.Add((GeneratorDefectCategorizationEntity)relatedEntity);
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

				case "GeneratorDefectCategorization___":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization___, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization____":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization____, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization__":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization__, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization_":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization_, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.GeneratorDefectCategorization___);
			toReturn.Add(this.GeneratorDefectCategorization____);
			toReturn.Add(this.GeneratorDefectCategorization__);
			toReturn.Add(this.GeneratorDefectCategorization);
			toReturn.Add(this.GeneratorDefectCategorization_);

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
				info.AddValue("_generatorDefectCategorization___", ((_generatorDefectCategorization___!=null) && (_generatorDefectCategorization___.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization___:null);
				info.AddValue("_generatorDefectCategorization____", ((_generatorDefectCategorization____!=null) && (_generatorDefectCategorization____.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization____:null);
				info.AddValue("_generatorDefectCategorization__", ((_generatorDefectCategorization__!=null) && (_generatorDefectCategorization__.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization__:null);
				info.AddValue("_generatorDefectCategorization", ((_generatorDefectCategorization!=null) && (_generatorDefectCategorization.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization:null);
				info.AddValue("_generatorDefectCategorization_", ((_generatorDefectCategorization_!=null) && (_generatorDefectCategorization_.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization_:null);
				info.AddValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___", ((_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___!=null) && (_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___:null);
				info.AddValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____", ((_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____!=null) && (_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____:null);
				info.AddValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__", ((_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__!=null) && (_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__:null);
				info.AddValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization", ((_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization!=null) && (_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization:null);
				info.AddValue("_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_", ((_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_!=null) && (_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorMiscDecisionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorMiscDecisionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorMiscDecisionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.MiscPtsensorDecision, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.MiscWaterDecision, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.MiscGroundingDecision, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.MiscBearingDecision, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.MiscGeneratorDecision, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId, "GeneratorMiscDecisionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscWaterDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId, "GeneratorMiscDecisionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGroundingDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId, "GeneratorMiscDecisionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscBearingDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId, "GeneratorMiscDecisionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, null, ComparisonOperator.Equal, this.GeneratorMiscDecisionId, "GeneratorMiscDecisionEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._generatorDefectCategorization___);
			collectionsQueue.Enqueue(this._generatorDefectCategorization____);
			collectionsQueue.Enqueue(this._generatorDefectCategorization__);
			collectionsQueue.Enqueue(this._generatorDefectCategorization);
			collectionsQueue.Enqueue(this._generatorDefectCategorization_);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._generatorDefectCategorization___ = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._generatorDefectCategorization____ = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._generatorDefectCategorization__ = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._generatorDefectCategorization = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._generatorDefectCategorization_ = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._generatorDefectCategorization___ != null)
			{
				return true;
			}
			if (this._generatorDefectCategorization____ != null)
			{
				return true;
			}
			if (this._generatorDefectCategorization__ != null)
			{
				return true;
			}
			if (this._generatorDefectCategorization != null)
			{
				return true;
			}
			if (this._generatorDefectCategorization_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization != null)
			{
				return true;
			}
			if (this._componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("GeneratorDefectCategorization___", _generatorDefectCategorization___);
			toReturn.Add("GeneratorDefectCategorization____", _generatorDefectCategorization____);
			toReturn.Add("GeneratorDefectCategorization__", _generatorDefectCategorization__);
			toReturn.Add("GeneratorDefectCategorization", _generatorDefectCategorization);
			toReturn.Add("GeneratorDefectCategorization_", _generatorDefectCategorization_);
			toReturn.Add("ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___", _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___);
			toReturn.Add("ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____", _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____);
			toReturn.Add("ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__", _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__);
			toReturn.Add("ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization", _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization);
			toReturn.Add("ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_", _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_generatorDefectCategorization___!=null)
			{
				_generatorDefectCategorization___.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization____!=null)
			{
				_generatorDefectCategorization____.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization__!=null)
			{
				_generatorDefectCategorization__.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization!=null)
			{
				_generatorDefectCategorization.ActiveContext = base.ActiveContext;
			}
			if(_generatorDefectCategorization_!=null)
			{
				_generatorDefectCategorization_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___!=null)
			{
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____!=null)
			{
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__!=null)
			{
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization!=null)
			{
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_!=null)
			{
				_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_generatorDefectCategorization___ = null;
			_generatorDefectCategorization____ = null;
			_generatorDefectCategorization__ = null;
			_generatorDefectCategorization = null;
			_generatorDefectCategorization_ = null;
			_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ = null;
			_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ = null;
			_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ = null;
			_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization = null;
			_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ = null;


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

			_fieldsCustomProperties.Add("GeneratorMiscDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorMiscDecisionEntity</param>
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
		public  static GeneratorMiscDecisionRelations Relations
		{
			get	{ return new GeneratorMiscDecisionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization___
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization____
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscWaterDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization__
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGroundingDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscBearingDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDefectCategorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, relations, null, "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscWaterDecision;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscWaterDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, relations, null, "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGroundingDecision;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGroundingDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, relations, null, "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscBearingDecision;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscBearingDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, relations, null, "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(GeneratorMiscDecisionEntity.Relations.GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision, "GeneratorMiscDecisionEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, relations, null, "ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorMiscDecisionEntity.CustomProperties;}
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
			get { return GeneratorMiscDecisionEntity.FieldsCustomProperties;}
		}

		/// <summary> The GeneratorMiscDecisionId property of the Entity GeneratorMiscDecision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorMiscDecision"."GeneratorMiscDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 GeneratorMiscDecisionId
		{
			get { return (System.Int32)GetValue((int)GeneratorMiscDecisionFieldIndex.GeneratorMiscDecisionId, true); }
			set	{ SetValue((int)GeneratorMiscDecisionFieldIndex.GeneratorMiscDecisionId, value); }
		}

		/// <summary> The Name property of the Entity GeneratorMiscDecision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorMiscDecision"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)GeneratorMiscDecisionFieldIndex.Name, true); }
			set	{ SetValue((int)GeneratorMiscDecisionFieldIndex.Name, value); }
		}

		/// <summary> The Sort property of the Entity GeneratorMiscDecision<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorMiscDecision"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Sort
		{
			get { return (System.Int32)GetValue((int)GeneratorMiscDecisionFieldIndex.Sort, true); }
			set	{ SetValue((int)GeneratorMiscDecisionFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorizationEntity))]
		public virtual EntityCollection<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization___
		{
			get
			{
				if(_generatorDefectCategorization___==null)
				{
					_generatorDefectCategorization___ = new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory)));
					_generatorDefectCategorization___.SetContainingEntityInfo(this, "GeneratorMiscDecision___");
				}
				return _generatorDefectCategorization___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorizationEntity))]
		public virtual EntityCollection<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization____
		{
			get
			{
				if(_generatorDefectCategorization____==null)
				{
					_generatorDefectCategorization____ = new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory)));
					_generatorDefectCategorization____.SetContainingEntityInfo(this, "GeneratorMiscDecision____");
				}
				return _generatorDefectCategorization____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorizationEntity))]
		public virtual EntityCollection<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization__
		{
			get
			{
				if(_generatorDefectCategorization__==null)
				{
					_generatorDefectCategorization__ = new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory)));
					_generatorDefectCategorization__.SetContainingEntityInfo(this, "GeneratorMiscDecision__");
				}
				return _generatorDefectCategorization__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorizationEntity))]
		public virtual EntityCollection<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization
		{
			get
			{
				if(_generatorDefectCategorization==null)
				{
					_generatorDefectCategorization = new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory)));
					_generatorDefectCategorization.SetContainingEntityInfo(this, "GeneratorMiscDecision");
				}
				return _generatorDefectCategorization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDefectCategorizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDefectCategorizationEntity))]
		public virtual EntityCollection<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization_
		{
			get
			{
				if(_generatorDefectCategorization_==null)
				{
					_generatorDefectCategorization_ = new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory)));
					_generatorDefectCategorization_.SetContainingEntityInfo(this, "GeneratorMiscDecision_");
				}
				return _generatorDefectCategorization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___
		{
			get
			{
				if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___==null)
				{
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___.IsReadOnly=true;
				}
				return _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____
		{
			get
			{
				if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____==null)
				{
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____.IsReadOnly=true;
				}
				return _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__
		{
			get
			{
				if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__==null)
				{
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__.IsReadOnly=true;
				}
				return _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization
		{
			get
			{
				if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization==null)
				{
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization.IsReadOnly=true;
				}
				return _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_
		{
			get
			{
				if(_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_==null)
				{
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_.IsReadOnly=true;
				}
				return _componentInspectionReportGeneratorCollectionViaGeneratorDefectCategorization_;
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity; }
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
