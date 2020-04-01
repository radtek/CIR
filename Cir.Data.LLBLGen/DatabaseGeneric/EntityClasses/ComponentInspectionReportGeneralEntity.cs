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
	/// Entity class which represents the entity 'ComponentInspectionReportGeneral'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportGeneralEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private BooleanAnswerEntity _booleanAnswer_;
		private BooleanAnswerEntity _booleanAnswer;
		private ComponentGroupEntity _componentGroup;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private ControllerTypeEntity _controllerType;
		private GearboxManufacturerEntity _gearboxManufacturer;
		private GeneratorManufacturerEntity _generatorManufacturer;
		private TowerHeightEntity _towerHeight;
		private TowerTypeEntity _towerType;
		private TransformerManufacturerEntity _transformerManufacturer;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BooleanAnswer_</summary>
			public static readonly string BooleanAnswer_ = "BooleanAnswer_";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name ComponentGroup</summary>
			public static readonly string ComponentGroup = "ComponentGroup";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name ControllerType</summary>
			public static readonly string ControllerType = "ControllerType";
			/// <summary>Member name GearboxManufacturer</summary>
			public static readonly string GearboxManufacturer = "GearboxManufacturer";
			/// <summary>Member name GeneratorManufacturer</summary>
			public static readonly string GeneratorManufacturer = "GeneratorManufacturer";
			/// <summary>Member name TowerHeight</summary>
			public static readonly string TowerHeight = "TowerHeight";
			/// <summary>Member name TowerType</summary>
			public static readonly string TowerType = "TowerType";
			/// <summary>Member name TransformerManufacturer</summary>
			public static readonly string TransformerManufacturer = "TransformerManufacturer";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportGeneralEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportGeneralEntity():base("ComponentInspectionReportGeneralEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportGeneralEntity(IEntityFields2 fields):base("ComponentInspectionReportGeneralEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGeneralEntity</param>
		public ComponentInspectionReportGeneralEntity(IValidator validator):base("ComponentInspectionReportGeneralEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGeneralId">PK value for ComponentInspectionReportGeneral which data should be fetched into this ComponentInspectionReportGeneral object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGeneralEntity(System.Int64 componentInspectionReportGeneralId):base("ComponentInspectionReportGeneralEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportGeneralId = componentInspectionReportGeneralId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGeneralId">PK value for ComponentInspectionReportGeneral which data should be fetched into this ComponentInspectionReportGeneral object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGeneralEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGeneralEntity(System.Int64 componentInspectionReportGeneralId, IValidator validator):base("ComponentInspectionReportGeneralEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportGeneralId = componentInspectionReportGeneralId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportGeneralEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_booleanAnswer_ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_!=null)
				{
					_booleanAnswer_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer = (BooleanAnswerEntity)info.GetValue("_booleanAnswer", typeof(BooleanAnswerEntity));
				if(_booleanAnswer!=null)
				{
					_booleanAnswer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentGroup = (ComponentGroupEntity)info.GetValue("_componentGroup", typeof(ComponentGroupEntity));
				if(_componentGroup!=null)
				{
					_componentGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_controllerType = (ControllerTypeEntity)info.GetValue("_controllerType", typeof(ControllerTypeEntity));
				if(_controllerType!=null)
				{
					_controllerType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearboxManufacturer = (GearboxManufacturerEntity)info.GetValue("_gearboxManufacturer", typeof(GearboxManufacturerEntity));
				if(_gearboxManufacturer!=null)
				{
					_gearboxManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorManufacturer = (GeneratorManufacturerEntity)info.GetValue("_generatorManufacturer", typeof(GeneratorManufacturerEntity));
				if(_generatorManufacturer!=null)
				{
					_generatorManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_towerHeight = (TowerHeightEntity)info.GetValue("_towerHeight", typeof(TowerHeightEntity));
				if(_towerHeight!=null)
				{
					_towerHeight.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_towerType = (TowerTypeEntity)info.GetValue("_towerType", typeof(TowerTypeEntity));
				if(_towerType!=null)
				{
					_towerType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_transformerManufacturer = (TransformerManufacturerEntity)info.GetValue("_transformerManufacturer", typeof(TransformerManufacturerEntity));
				if(_transformerManufacturer!=null)
				{
					_transformerManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportGeneralFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralComponentGroupId:
					DesetupSyncComponentGroup(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralClaimRelevantBooleanAnswerId:
					DesetupSyncBooleanAnswer(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralGeneratorManufacturerId:
					DesetupSyncGeneratorManufacturer(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralTransformerManufacturerId:
					DesetupSyncTransformerManufacturer(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralGearboxManufacturerId:
					DesetupSyncGearboxManufacturer(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralTowerTypeId:
					DesetupSyncTowerType(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralTowerHeightId:
					DesetupSyncTowerHeight(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralControllerTypeId:
					DesetupSyncControllerType(true, false);
					break;
				case ComponentInspectionReportGeneralFieldIndex.GeneralPicturesIncludedBooleanAnswerId:
					DesetupSyncBooleanAnswer_(true, false);
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
				case "BooleanAnswer_":
					this.BooleanAnswer_ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "ComponentGroup":
					this.ComponentGroup = (ComponentGroupEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "ControllerType":
					this.ControllerType = (ControllerTypeEntity)entity;
					break;
				case "GearboxManufacturer":
					this.GearboxManufacturer = (GearboxManufacturerEntity)entity;
					break;
				case "GeneratorManufacturer":
					this.GeneratorManufacturer = (GeneratorManufacturerEntity)entity;
					break;
				case "TowerHeight":
					this.TowerHeight = (TowerHeightEntity)entity;
					break;
				case "TowerType":
					this.TowerType = (TowerTypeEntity)entity;
					break;
				case "TransformerManufacturer":
					this.TransformerManufacturer = (TransformerManufacturerEntity)entity;
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
				case "BooleanAnswer_":
					SetupSyncBooleanAnswer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentGroup":
					SetupSyncComponentGroup(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ControllerType":
					SetupSyncControllerType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxManufacturer":
					SetupSyncGearboxManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					SetupSyncGeneratorManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TowerHeight":
					SetupSyncTowerHeight(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TowerType":
					SetupSyncTowerType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TransformerManufacturer":
					SetupSyncTransformerManufacturer(relatedEntity);
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
				case "BooleanAnswer_":
					DesetupSyncBooleanAnswer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentGroup":
					DesetupSyncComponentGroup(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ControllerType":
					DesetupSyncControllerType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxManufacturer":
					DesetupSyncGearboxManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					DesetupSyncGeneratorManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TowerHeight":
					DesetupSyncTowerHeight(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TowerType":
					DesetupSyncTowerType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TransformerManufacturer":
					DesetupSyncTransformerManufacturer(false, true);
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
			if(_booleanAnswer_!=null)
			{
				toReturn.Add(_booleanAnswer_);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_componentGroup!=null)
			{
				toReturn.Add(_componentGroup);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_controllerType!=null)
			{
				toReturn.Add(_controllerType);
			}
			if(_gearboxManufacturer!=null)
			{
				toReturn.Add(_gearboxManufacturer);
			}
			if(_generatorManufacturer!=null)
			{
				toReturn.Add(_generatorManufacturer);
			}
			if(_towerHeight!=null)
			{
				toReturn.Add(_towerHeight);
			}
			if(_towerType!=null)
			{
				toReturn.Add(_towerType);
			}
			if(_transformerManufacturer!=null)
			{
				toReturn.Add(_transformerManufacturer);
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


				info.AddValue("_booleanAnswer_", (!this.MarkedForDeletion?_booleanAnswer_:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_componentGroup", (!this.MarkedForDeletion?_componentGroup:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_controllerType", (!this.MarkedForDeletion?_controllerType:null));
				info.AddValue("_gearboxManufacturer", (!this.MarkedForDeletion?_gearboxManufacturer:null));
				info.AddValue("_generatorManufacturer", (!this.MarkedForDeletion?_generatorManufacturer:null));
				info.AddValue("_towerHeight", (!this.MarkedForDeletion?_towerHeight:null));
				info.AddValue("_towerType", (!this.MarkedForDeletion?_towerType:null));
				info.AddValue("_transformerManufacturer", (!this.MarkedForDeletion?_transformerManufacturer:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportGeneralFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportGeneralFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportGeneralRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.GeneralPicturesIncludedBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.GeneralClaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentGroupFields.ComponentGroupId, null, ComparisonOperator.Equal, this.GeneralComponentGroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.ComponentInspectionReportId, null, ComparisonOperator.Equal, this.ComponentInspectionReportId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ControllerType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoControllerType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ControllerTypeFields.ControllerTypeId, null, ComparisonOperator.Equal, this.GeneralControllerTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxManufacturerFields.GearboxManufacturerId, null, ComparisonOperator.Equal, this.GeneralGearboxManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorManufacturerFields.GeneratorManufacturerId, null, ComparisonOperator.Equal, this.GeneralGeneratorManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TowerHeight' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerHeight()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerHeightFields.TowerHeightId, null, ComparisonOperator.Equal, this.GeneralTowerHeightId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TowerType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.GeneralTowerTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.GeneralTransformerManufacturerId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneralEntityFactory));
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
			toReturn.Add("BooleanAnswer_", _booleanAnswer_);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("ComponentGroup", _componentGroup);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("ControllerType", _controllerType);
			toReturn.Add("GearboxManufacturer", _gearboxManufacturer);
			toReturn.Add("GeneratorManufacturer", _generatorManufacturer);
			toReturn.Add("TowerHeight", _towerHeight);
			toReturn.Add("TowerType", _towerType);
			toReturn.Add("TransformerManufacturer", _transformerManufacturer);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_booleanAnswer_!=null)
			{
				_booleanAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_componentGroup!=null)
			{
				_componentGroup.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_controllerType!=null)
			{
				_controllerType.ActiveContext = base.ActiveContext;
			}
			if(_gearboxManufacturer!=null)
			{
				_gearboxManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturer!=null)
			{
				_generatorManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_towerHeight!=null)
			{
				_towerHeight.ActiveContext = base.ActiveContext;
			}
			if(_towerType!=null)
			{
				_towerType.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturer!=null)
			{
				_transformerManufacturer.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_booleanAnswer_ = null;
			_booleanAnswer = null;
			_componentGroup = null;
			_componentInspectionReport = null;
			_controllerType = null;
			_gearboxManufacturer = null;
			_generatorManufacturer = null;
			_towerHeight = null;
			_towerType = null;
			_transformerManufacturer = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportGeneralId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralComponentGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralComponentType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralComponentManufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralOtherGearboxType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralClaimRelevantBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralOtherGearboxManufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralComponentSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralGeneratorManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralTransformerManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralGearboxManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralTowerTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralTowerHeightId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralBlade1SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralBlade2SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralBlade3SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralControllerTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralSoftwareRelease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralRamDumpNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralVdftrackNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralPicturesIncludedBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralInitiatedBy1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralInitiatedBy2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralInitiatedBy3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralInitiatedBy4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralMeasurementsConducted1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralMeasurementsConducted2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralMeasurementsConducted3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralMeasurementsConducted4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralExecutedBy1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralExecutedBy2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralExecutedBy3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralExecutedBy4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneralPositionOfFailedItem", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _booleanAnswer_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportGeneral_", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralPicturesIncludedBooleanAnswerId } );		
			_booleanAnswer_ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_(true, true);
			_booleanAnswer_ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralClaimRelevantBooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _componentGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentGroup, new PropertyChangedEventHandler( OnComponentGroupPropertyChanged ), "ComponentGroup", ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentGroupId } );		
			_componentGroup = null;
		}

		/// <summary> setups the sync logic for member _componentGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentGroup(IEntity2 relatedEntity)
		{
			DesetupSyncComponentGroup(true, true);
			_componentGroup = (ComponentGroupEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentGroup, new PropertyChangedEventHandler( OnComponentGroupPropertyChanged ), "ComponentGroup", ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _componentInspectionReport</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReport(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _controllerType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncControllerType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _controllerType, new PropertyChangedEventHandler( OnControllerTypePropertyChanged ), "ControllerType", ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralControllerTypeId } );		
			_controllerType = null;
		}

		/// <summary> setups the sync logic for member _controllerType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncControllerType(IEntity2 relatedEntity)
		{
			DesetupSyncControllerType(true, true);
			_controllerType = (ControllerTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _controllerType, new PropertyChangedEventHandler( OnControllerTypePropertyChanged ), "ControllerType", ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnControllerTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearboxManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxManufacturer, new PropertyChangedEventHandler( OnGearboxManufacturerPropertyChanged ), "GearboxManufacturer", ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralGearboxManufacturerId } );		
			_gearboxManufacturer = null;
		}

		/// <summary> setups the sync logic for member _gearboxManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxManufacturer(true, true);
			_gearboxManufacturer = (GearboxManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxManufacturer, new PropertyChangedEventHandler( OnGearboxManufacturerPropertyChanged ), "GearboxManufacturer", ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralGeneratorManufacturerId } );		
			_generatorManufacturer = null;
		}

		/// <summary> setups the sync logic for member _generatorManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorManufacturer(true, true);
			_generatorManufacturer = (GeneratorManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _towerHeight</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTowerHeight(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _towerHeight, new PropertyChangedEventHandler( OnTowerHeightPropertyChanged ), "TowerHeight", ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerHeightId } );		
			_towerHeight = null;
		}

		/// <summary> setups the sync logic for member _towerHeight</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTowerHeight(IEntity2 relatedEntity)
		{
			DesetupSyncTowerHeight(true, true);
			_towerHeight = (TowerHeightEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _towerHeight, new PropertyChangedEventHandler( OnTowerHeightPropertyChanged ), "TowerHeight", ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTowerHeightPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _towerType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTowerType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _towerType, new PropertyChangedEventHandler( OnTowerTypePropertyChanged ), "TowerType", ComponentInspectionReportGeneralEntity.Relations.TowerTypeEntityUsingGeneralTowerTypeId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerTypeId } );		
			_towerType = null;
		}

		/// <summary> setups the sync logic for member _towerType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTowerType(IEntity2 relatedEntity)
		{
			DesetupSyncTowerType(true, true);
			_towerType = (TowerTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _towerType, new PropertyChangedEventHandler( OnTowerTypePropertyChanged ), "TowerType", ComponentInspectionReportGeneralEntity.Relations.TowerTypeEntityUsingGeneralTowerTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTowerTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _transformerManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTransformerManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", ComponentInspectionReportGeneralEntity.Relations.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGeneral", resetFKFields, new int[] { (int)ComponentInspectionReportGeneralFieldIndex.GeneralTransformerManufacturerId } );		
			_transformerManufacturer = null;
		}

		/// <summary> setups the sync logic for member _transformerManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTransformerManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncTransformerManufacturer(true, true);
			_transformerManufacturer = (TransformerManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", ComponentInspectionReportGeneralEntity.Relations.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTransformerManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportGeneralEntity</param>
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
		public  static ComponentInspectionReportGeneralRelations Relations
		{
			get	{ return new ComponentInspectionReportGeneralRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentGroup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentGroupEntity, 0, null, null, null, null, "ComponentGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ControllerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathControllerType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.ControllerTypeEntity, 0, null, null, null, null, "ControllerType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity, 0, null, null, null, null, "GearboxManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, null, null, "GeneratorManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerHeight' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerHeight
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.TowerHeightEntity, 0, null, null, null, null, "TowerHeight", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.TowerTypeEntityUsingGeneralTowerTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, 0, null, null, null, null, "TowerType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TransformerManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTransformerManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))),
					ComponentInspectionReportGeneralEntity.Relations.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, null, null, "TransformerManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportGeneralEntity.CustomProperties;}
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
			get { return ComponentInspectionReportGeneralEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportGeneralId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."ComponentInspectionReportGeneralId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportGeneralId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportGeneralId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportGeneralId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The GeneralComponentGroupId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralComponentGroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralComponentGroupId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentGroupId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentGroupId, value); }
		}

		/// <summary> The GeneralComponentType property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralComponentType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralComponentType
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentType, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentType, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The GeneralComponentManufacturer property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralComponentManufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralComponentManufacturer
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentManufacturer, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentManufacturer, value); }
		}

		/// <summary> The GeneralOtherGearboxType property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralOtherGearboxType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralOtherGearboxType
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxType, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxType, value); }
		}

		/// <summary> The GeneralClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralClaimRelevantBooleanAnswerId, value); }
		}

		/// <summary> The GeneralOtherGearboxManufacturer property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralOtherGearboxManufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralOtherGearboxManufacturer
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxManufacturer, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxManufacturer, value); }
		}

		/// <summary> The GeneralComponentSerialNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralComponentSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralComponentSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentSerialNumber, value); }
		}

		/// <summary> The GeneralGeneratorManufacturerId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralGeneratorManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralGeneratorManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralGeneratorManufacturerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralGeneratorManufacturerId, value); }
		}

		/// <summary> The GeneralTransformerManufacturerId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralTransformerManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralTransformerManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTransformerManufacturerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTransformerManufacturerId, value); }
		}

		/// <summary> The GeneralGearboxManufacturerId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralGearboxManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralGearboxManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralGearboxManufacturerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralGearboxManufacturerId, value); }
		}

		/// <summary> The GeneralTowerTypeId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralTowerTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralTowerTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerTypeId, value); }
		}

		/// <summary> The GeneralTowerHeightId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralTowerHeightId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralTowerHeightId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerHeightId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerHeightId, value); }
		}

		/// <summary> The GeneralBlade1SerialNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralBlade1SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralBlade1SerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade1SerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade1SerialNumber, value); }
		}

		/// <summary> The GeneralBlade2SerialNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralBlade2SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralBlade2SerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade2SerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade2SerialNumber, value); }
		}

		/// <summary> The GeneralBlade3SerialNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralBlade3SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralBlade3SerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade3SerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade3SerialNumber, value); }
		}

		/// <summary> The GeneralControllerTypeId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralControllerTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralControllerTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralControllerTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralControllerTypeId, value); }
		}

		/// <summary> The GeneralSoftwareRelease property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralSoftwareRelease"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralSoftwareRelease
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralSoftwareRelease, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralSoftwareRelease, value); }
		}

		/// <summary> The GeneralRamDumpNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralRamDumpNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralRamDumpNumber
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralRamDumpNumber, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralRamDumpNumber, value); }
		}

		/// <summary> The GeneralVdftrackNumber property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralVDFTrackNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneralVdftrackNumber
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralVdftrackNumber, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralVdftrackNumber, value); }
		}

		/// <summary> The GeneralPicturesIncludedBooleanAnswerId property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralPicturesIncludedBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneralPicturesIncludedBooleanAnswerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralPicturesIncludedBooleanAnswerId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralPicturesIncludedBooleanAnswerId, value); }
		}

		/// <summary> The GeneralInitiatedBy1 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralInitiatedBy1"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralInitiatedBy1
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy1, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy1, value); }
		}

		/// <summary> The GeneralInitiatedBy2 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralInitiatedBy2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralInitiatedBy2
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy2, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy2, value); }
		}

		/// <summary> The GeneralInitiatedBy3 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralInitiatedBy3"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralInitiatedBy3
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy3, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy3, value); }
		}

		/// <summary> The GeneralInitiatedBy4 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralInitiatedBy4"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralInitiatedBy4
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy4, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy4, value); }
		}

		/// <summary> The GeneralMeasurementsConducted1 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralMeasurementsConducted1"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralMeasurementsConducted1
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted1, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted1, value); }
		}

		/// <summary> The GeneralMeasurementsConducted2 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralMeasurementsConducted2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralMeasurementsConducted2
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted2, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted2, value); }
		}

		/// <summary> The GeneralMeasurementsConducted3 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralMeasurementsConducted3"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralMeasurementsConducted3
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted3, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted3, value); }
		}

		/// <summary> The GeneralMeasurementsConducted4 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralMeasurementsConducted4"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralMeasurementsConducted4
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted4, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted4, value); }
		}

		/// <summary> The GeneralExecutedBy1 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralExecutedBy1"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralExecutedBy1
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy1, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy1, value); }
		}

		/// <summary> The GeneralExecutedBy2 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralExecutedBy2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralExecutedBy2
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy2, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy2, value); }
		}

		/// <summary> The GeneralExecutedBy3 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralExecutedBy3"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralExecutedBy3
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy3, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy3, value); }
		}

		/// <summary> The GeneralExecutedBy4 property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralExecutedBy4"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralExecutedBy4
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy4, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy4, value); }
		}

		/// <summary> The GeneralPositionOfFailedItem property of the Entity ComponentInspectionReportGeneral<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGeneral"."GeneralPositionOfFailedItem"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneralPositionOfFailedItem
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralPositionOfFailedItem, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneralFieldIndex.GeneralPositionOfFailedItem, value); }
		}



		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_
		{
			get
			{
				return _booleanAnswer_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_ != null)
						{
							_booleanAnswer_.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer
		{
			get
			{
				return _booleanAnswer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer != null)
						{
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ComponentGroupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentGroupEntity ComponentGroup
		{
			get
			{
				return _componentGroup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentGroup(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentGroup != null)
						{
							_componentGroup.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportEntity ComponentInspectionReport
		{
			get
			{
				return _componentInspectionReport;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReport(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReport != null)
						{
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ControllerTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ControllerTypeEntity ControllerType
		{
			get
			{
				return _controllerType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncControllerType(value);
				}
				else
				{
					if(value==null)
					{
						if(_controllerType != null)
						{
							_controllerType.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxManufacturerEntity GearboxManufacturer
		{
			get
			{
				return _gearboxManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxManufacturer != null)
						{
							_gearboxManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorManufacturerEntity GeneratorManufacturer
		{
			get
			{
				return _generatorManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorManufacturer != null)
						{
							_generatorManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TowerHeightEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TowerHeightEntity TowerHeight
		{
			get
			{
				return _towerHeight;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTowerHeight(value);
				}
				else
				{
					if(value==null)
					{
						if(_towerHeight != null)
						{
							_towerHeight.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TowerTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TowerTypeEntity TowerType
		{
			get
			{
				return _towerType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTowerType(value);
				}
				else
				{
					if(value==null)
					{
						if(_towerType != null)
						{
							_towerType.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TransformerManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TransformerManufacturerEntity TransformerManufacturer
		{
			get
			{
				return _transformerManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTransformerManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_transformerManufacturer != null)
						{
							_transformerManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGeneral");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGeneral");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity; }
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
