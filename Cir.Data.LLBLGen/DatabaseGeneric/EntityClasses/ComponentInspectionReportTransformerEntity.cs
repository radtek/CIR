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
	/// Entity class which represents the entity 'ComponentInspectionReportTransformer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportTransformerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ActionOnTransformerEntity _actionOnTransformer;
		private ArcDetectionEntity _arcDetection;
		private BooleanAnswerEntity _booleanAnswer;
		private BracketsEntity _brackets;
		private CableConditionEntity _cableCondition_;
		private CableConditionEntity _cableCondition;
		private ClimateEntity _climate;
		private CoilConditionEntity _coilCondition_;
		private CoilConditionEntity _coilCondition;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private ConnectionBarsEntity _connectionBars;
		private SurgeArrestorEntity _surgeArrestor;
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
			/// <summary>Member name ActionOnTransformer</summary>
			public static readonly string ActionOnTransformer = "ActionOnTransformer";
			/// <summary>Member name ArcDetection</summary>
			public static readonly string ArcDetection = "ArcDetection";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name Brackets</summary>
			public static readonly string Brackets = "Brackets";
			/// <summary>Member name CableCondition_</summary>
			public static readonly string CableCondition_ = "CableCondition_";
			/// <summary>Member name CableCondition</summary>
			public static readonly string CableCondition = "CableCondition";
			/// <summary>Member name Climate</summary>
			public static readonly string Climate = "Climate";
			/// <summary>Member name CoilCondition_</summary>
			public static readonly string CoilCondition_ = "CoilCondition_";
			/// <summary>Member name CoilCondition</summary>
			public static readonly string CoilCondition = "CoilCondition";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name ConnectionBars</summary>
			public static readonly string ConnectionBars = "ConnectionBars";
			/// <summary>Member name SurgeArrestor</summary>
			public static readonly string SurgeArrestor = "SurgeArrestor";
			/// <summary>Member name TransformerManufacturer</summary>
			public static readonly string TransformerManufacturer = "TransformerManufacturer";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportTransformerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportTransformerEntity():base("ComponentInspectionReportTransformerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportTransformerEntity(IEntityFields2 fields):base("ComponentInspectionReportTransformerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportTransformerEntity</param>
		public ComponentInspectionReportTransformerEntity(IValidator validator):base("ComponentInspectionReportTransformerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportTransformerId">PK value for ComponentInspectionReportTransformer which data should be fetched into this ComponentInspectionReportTransformer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportTransformerEntity(System.Int64 componentInspectionReportTransformerId):base("ComponentInspectionReportTransformerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportTransformerId = componentInspectionReportTransformerId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportTransformerId">PK value for ComponentInspectionReportTransformer which data should be fetched into this ComponentInspectionReportTransformer object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportTransformerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportTransformerEntity(System.Int64 componentInspectionReportTransformerId, IValidator validator):base("ComponentInspectionReportTransformerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportTransformerId = componentInspectionReportTransformerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportTransformerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_actionOnTransformer = (ActionOnTransformerEntity)info.GetValue("_actionOnTransformer", typeof(ActionOnTransformerEntity));
				if(_actionOnTransformer!=null)
				{
					_actionOnTransformer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_arcDetection = (ArcDetectionEntity)info.GetValue("_arcDetection", typeof(ArcDetectionEntity));
				if(_arcDetection!=null)
				{
					_arcDetection.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer = (BooleanAnswerEntity)info.GetValue("_booleanAnswer", typeof(BooleanAnswerEntity));
				if(_booleanAnswer!=null)
				{
					_booleanAnswer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_brackets = (BracketsEntity)info.GetValue("_brackets", typeof(BracketsEntity));
				if(_brackets!=null)
				{
					_brackets.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_cableCondition_ = (CableConditionEntity)info.GetValue("_cableCondition_", typeof(CableConditionEntity));
				if(_cableCondition_!=null)
				{
					_cableCondition_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_cableCondition = (CableConditionEntity)info.GetValue("_cableCondition", typeof(CableConditionEntity));
				if(_cableCondition!=null)
				{
					_cableCondition.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_climate = (ClimateEntity)info.GetValue("_climate", typeof(ClimateEntity));
				if(_climate!=null)
				{
					_climate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_coilCondition_ = (CoilConditionEntity)info.GetValue("_coilCondition_", typeof(CoilConditionEntity));
				if(_coilCondition_!=null)
				{
					_coilCondition_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_coilCondition = (CoilConditionEntity)info.GetValue("_coilCondition", typeof(CoilConditionEntity));
				if(_coilCondition!=null)
				{
					_coilCondition.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_connectionBars = (ConnectionBarsEntity)info.GetValue("_connectionBars", typeof(ConnectionBarsEntity));
				if(_connectionBars!=null)
				{
					_connectionBars.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_surgeArrestor = (SurgeArrestorEntity)info.GetValue("_surgeArrestor", typeof(SurgeArrestorEntity));
				if(_surgeArrestor!=null)
				{
					_surgeArrestor.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportTransformerFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.TransformerManufacturerId:
					DesetupSyncTransformerManufacturer(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.ActionOnTransformerId:
					DesetupSyncActionOnTransformer(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.HvcoilConditionId:
					DesetupSyncCoilCondition(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.LvcoilConditionId:
					DesetupSyncCoilCondition_(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.HvcableConditionId:
					DesetupSyncCableCondition(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.LvcableConditionId:
					DesetupSyncCableCondition_(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.BracketsId:
					DesetupSyncBrackets(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.TransformerArcDetectionId:
					DesetupSyncArcDetection(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.ClimateId:
					DesetupSyncClimate(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.SurgeArrestorId:
					DesetupSyncSurgeArrestor(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.ConnectionBarsId:
					DesetupSyncConnectionBars(true, false);
					break;
				case ComponentInspectionReportTransformerFieldIndex.TransformerClaimRelevantBooleanAnswerId:
					DesetupSyncBooleanAnswer(true, false);
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
				case "ActionOnTransformer":
					this.ActionOnTransformer = (ActionOnTransformerEntity)entity;
					break;
				case "ArcDetection":
					this.ArcDetection = (ArcDetectionEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "Brackets":
					this.Brackets = (BracketsEntity)entity;
					break;
				case "CableCondition_":
					this.CableCondition_ = (CableConditionEntity)entity;
					break;
				case "CableCondition":
					this.CableCondition = (CableConditionEntity)entity;
					break;
				case "Climate":
					this.Climate = (ClimateEntity)entity;
					break;
				case "CoilCondition_":
					this.CoilCondition_ = (CoilConditionEntity)entity;
					break;
				case "CoilCondition":
					this.CoilCondition = (CoilConditionEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "ConnectionBars":
					this.ConnectionBars = (ConnectionBarsEntity)entity;
					break;
				case "SurgeArrestor":
					this.SurgeArrestor = (SurgeArrestorEntity)entity;
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
				case "ActionOnTransformer":
					SetupSyncActionOnTransformer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ArcDetection":
					SetupSyncArcDetection(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Brackets":
					SetupSyncBrackets(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CableCondition_":
					SetupSyncCableCondition_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CableCondition":
					SetupSyncCableCondition(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Climate":
					SetupSyncClimate(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CoilCondition_":
					SetupSyncCoilCondition_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CoilCondition":
					SetupSyncCoilCondition(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ConnectionBars":
					SetupSyncConnectionBars(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "SurgeArrestor":
					SetupSyncSurgeArrestor(relatedEntity);
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
				case "ActionOnTransformer":
					DesetupSyncActionOnTransformer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ArcDetection":
					DesetupSyncArcDetection(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Brackets":
					DesetupSyncBrackets(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CableCondition_":
					DesetupSyncCableCondition_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CableCondition":
					DesetupSyncCableCondition(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Climate":
					DesetupSyncClimate(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CoilCondition_":
					DesetupSyncCoilCondition_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CoilCondition":
					DesetupSyncCoilCondition(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ConnectionBars":
					DesetupSyncConnectionBars(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "SurgeArrestor":
					DesetupSyncSurgeArrestor(false, true);
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
			if(_actionOnTransformer!=null)
			{
				toReturn.Add(_actionOnTransformer);
			}
			if(_arcDetection!=null)
			{
				toReturn.Add(_arcDetection);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_brackets!=null)
			{
				toReturn.Add(_brackets);
			}
			if(_cableCondition_!=null)
			{
				toReturn.Add(_cableCondition_);
			}
			if(_cableCondition!=null)
			{
				toReturn.Add(_cableCondition);
			}
			if(_climate!=null)
			{
				toReturn.Add(_climate);
			}
			if(_coilCondition_!=null)
			{
				toReturn.Add(_coilCondition_);
			}
			if(_coilCondition!=null)
			{
				toReturn.Add(_coilCondition);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_connectionBars!=null)
			{
				toReturn.Add(_connectionBars);
			}
			if(_surgeArrestor!=null)
			{
				toReturn.Add(_surgeArrestor);
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


				info.AddValue("_actionOnTransformer", (!this.MarkedForDeletion?_actionOnTransformer:null));
				info.AddValue("_arcDetection", (!this.MarkedForDeletion?_arcDetection:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_brackets", (!this.MarkedForDeletion?_brackets:null));
				info.AddValue("_cableCondition_", (!this.MarkedForDeletion?_cableCondition_:null));
				info.AddValue("_cableCondition", (!this.MarkedForDeletion?_cableCondition:null));
				info.AddValue("_climate", (!this.MarkedForDeletion?_climate:null));
				info.AddValue("_coilCondition_", (!this.MarkedForDeletion?_coilCondition_:null));
				info.AddValue("_coilCondition", (!this.MarkedForDeletion?_coilCondition:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_connectionBars", (!this.MarkedForDeletion?_connectionBars:null));
				info.AddValue("_surgeArrestor", (!this.MarkedForDeletion?_surgeArrestor:null));
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
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportTransformerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportTransformerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportTransformerRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ActionOnTransformer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionOnTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ArcDetection' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoArcDetection()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ArcDetectionFields.ArcDetectionId, null, ComparisonOperator.Equal, this.TransformerArcDetectionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.TransformerClaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Brackets' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBrackets()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BracketsFields.BracketsId, null, ComparisonOperator.Equal, this.BracketsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableCondition_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CableConditionFields.CableConditionId, null, ComparisonOperator.Equal, this.LvcableConditionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableCondition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CableConditionFields.CableConditionId, null, ComparisonOperator.Equal, this.HvcableConditionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Climate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClimate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClimateFields.ClimateId, null, ComparisonOperator.Equal, this.ClimateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilCondition_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CoilConditionFields.CoilConditionId, null, ComparisonOperator.Equal, this.LvcoilConditionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilCondition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CoilConditionFields.CoilConditionId, null, ComparisonOperator.Equal, this.HvcoilConditionId));
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
		/// the related entity of type 'ConnectionBars' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoConnectionBars()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ConnectionBarsFields.ConnectionBarsId, null, ComparisonOperator.Equal, this.ConnectionBarsId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SurgeArrestor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurgeArrestor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurgeArrestorFields.SurgeArrestorId, null, ComparisonOperator.Equal, this.SurgeArrestorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTransformerEntityFactory));
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
			toReturn.Add("ActionOnTransformer", _actionOnTransformer);
			toReturn.Add("ArcDetection", _arcDetection);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("Brackets", _brackets);
			toReturn.Add("CableCondition_", _cableCondition_);
			toReturn.Add("CableCondition", _cableCondition);
			toReturn.Add("Climate", _climate);
			toReturn.Add("CoilCondition_", _coilCondition_);
			toReturn.Add("CoilCondition", _coilCondition);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("ConnectionBars", _connectionBars);
			toReturn.Add("SurgeArrestor", _surgeArrestor);
			toReturn.Add("TransformerManufacturer", _transformerManufacturer);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_actionOnTransformer!=null)
			{
				_actionOnTransformer.ActiveContext = base.ActiveContext;
			}
			if(_arcDetection!=null)
			{
				_arcDetection.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_brackets!=null)
			{
				_brackets.ActiveContext = base.ActiveContext;
			}
			if(_cableCondition_!=null)
			{
				_cableCondition_.ActiveContext = base.ActiveContext;
			}
			if(_cableCondition!=null)
			{
				_cableCondition.ActiveContext = base.ActiveContext;
			}
			if(_climate!=null)
			{
				_climate.ActiveContext = base.ActiveContext;
			}
			if(_coilCondition_!=null)
			{
				_coilCondition_.ActiveContext = base.ActiveContext;
			}
			if(_coilCondition!=null)
			{
				_coilCondition.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_connectionBars!=null)
			{
				_connectionBars.ActiveContext = base.ActiveContext;
			}
			if(_surgeArrestor!=null)
			{
				_surgeArrestor.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturer!=null)
			{
				_transformerManufacturer.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_actionOnTransformer = null;
			_arcDetection = null;
			_booleanAnswer = null;
			_brackets = null;
			_cableCondition_ = null;
			_cableCondition = null;
			_climate = null;
			_coilCondition_ = null;
			_coilCondition = null;
			_componentInspectionReport = null;
			_connectionBars = null;
			_surgeArrestor = null;
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

			_fieldsCustomProperties.Add("ComponentInspectionReportTransformerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TransformerManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TransformerSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxTemp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxTempResetDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActionOnTransformerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HvcoilConditionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LvcoilConditionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HvcableConditionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LvcableConditionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BracketsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TransformerArcDetectionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClimateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SurgeArrestorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConnectionBarsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Comments", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TransformerClaimRelevantBooleanAnswerId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _actionOnTransformer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActionOnTransformer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _actionOnTransformer, new PropertyChangedEventHandler( OnActionOnTransformerPropertyChanged ), "ActionOnTransformer", ComponentInspectionReportTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.ActionOnTransformerId } );		
			_actionOnTransformer = null;
		}

		/// <summary> setups the sync logic for member _actionOnTransformer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActionOnTransformer(IEntity2 relatedEntity)
		{
			DesetupSyncActionOnTransformer(true, true);
			_actionOnTransformer = (ActionOnTransformerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _actionOnTransformer, new PropertyChangedEventHandler( OnActionOnTransformerPropertyChanged ), "ActionOnTransformer", ComponentInspectionReportTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActionOnTransformerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _arcDetection</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncArcDetection(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _arcDetection, new PropertyChangedEventHandler( OnArcDetectionPropertyChanged ), "ArcDetection", ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.TransformerArcDetectionId } );		
			_arcDetection = null;
		}

		/// <summary> setups the sync logic for member _arcDetection</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncArcDetection(IEntity2 relatedEntity)
		{
			DesetupSyncArcDetection(true, true);
			_arcDetection = (ArcDetectionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _arcDetection, new PropertyChangedEventHandler( OnArcDetectionPropertyChanged ), "ArcDetection", ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnArcDetectionPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.TransformerClaimRelevantBooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _brackets</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBrackets(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _brackets, new PropertyChangedEventHandler( OnBracketsPropertyChanged ), "Brackets", ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.BracketsId } );		
			_brackets = null;
		}

		/// <summary> setups the sync logic for member _brackets</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBrackets(IEntity2 relatedEntity)
		{
			DesetupSyncBrackets(true, true);
			_brackets = (BracketsEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _brackets, new PropertyChangedEventHandler( OnBracketsPropertyChanged ), "Brackets", ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBracketsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _cableCondition_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCableCondition_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _cableCondition_, new PropertyChangedEventHandler( OnCableCondition_PropertyChanged ), "CableCondition_", ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, true, signalRelatedEntity, "ComponentInspectionReportTransformer_", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.LvcableConditionId } );		
			_cableCondition_ = null;
		}

		/// <summary> setups the sync logic for member _cableCondition_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCableCondition_(IEntity2 relatedEntity)
		{
			DesetupSyncCableCondition_(true, true);
			_cableCondition_ = (CableConditionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _cableCondition_, new PropertyChangedEventHandler( OnCableCondition_PropertyChanged ), "CableCondition_", ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCableCondition_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _cableCondition</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCableCondition(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _cableCondition, new PropertyChangedEventHandler( OnCableConditionPropertyChanged ), "CableCondition", ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.HvcableConditionId } );		
			_cableCondition = null;
		}

		/// <summary> setups the sync logic for member _cableCondition</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCableCondition(IEntity2 relatedEntity)
		{
			DesetupSyncCableCondition(true, true);
			_cableCondition = (CableConditionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _cableCondition, new PropertyChangedEventHandler( OnCableConditionPropertyChanged ), "CableCondition", ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCableConditionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _climate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncClimate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _climate, new PropertyChangedEventHandler( OnClimatePropertyChanged ), "Climate", ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.ClimateId } );		
			_climate = null;
		}

		/// <summary> setups the sync logic for member _climate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncClimate(IEntity2 relatedEntity)
		{
			DesetupSyncClimate(true, true);
			_climate = (ClimateEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _climate, new PropertyChangedEventHandler( OnClimatePropertyChanged ), "Climate", ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClimatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _coilCondition_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCoilCondition_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _coilCondition_, new PropertyChangedEventHandler( OnCoilCondition_PropertyChanged ), "CoilCondition_", ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, true, signalRelatedEntity, "ComponentInspectionReportTransformer_", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.LvcoilConditionId } );		
			_coilCondition_ = null;
		}

		/// <summary> setups the sync logic for member _coilCondition_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCoilCondition_(IEntity2 relatedEntity)
		{
			DesetupSyncCoilCondition_(true, true);
			_coilCondition_ = (CoilConditionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _coilCondition_, new PropertyChangedEventHandler( OnCoilCondition_PropertyChanged ), "CoilCondition_", ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCoilCondition_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _coilCondition</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCoilCondition(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _coilCondition, new PropertyChangedEventHandler( OnCoilConditionPropertyChanged ), "CoilCondition", ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.HvcoilConditionId } );		
			_coilCondition = null;
		}

		/// <summary> setups the sync logic for member _coilCondition</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCoilCondition(IEntity2 relatedEntity)
		{
			DesetupSyncCoilCondition(true, true);
			_coilCondition = (CoilConditionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _coilCondition, new PropertyChangedEventHandler( OnCoilConditionPropertyChanged ), "CoilCondition", ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCoilConditionPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _connectionBars</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncConnectionBars(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _connectionBars, new PropertyChangedEventHandler( OnConnectionBarsPropertyChanged ), "ConnectionBars", ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.ConnectionBarsId } );		
			_connectionBars = null;
		}

		/// <summary> setups the sync logic for member _connectionBars</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncConnectionBars(IEntity2 relatedEntity)
		{
			DesetupSyncConnectionBars(true, true);
			_connectionBars = (ConnectionBarsEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _connectionBars, new PropertyChangedEventHandler( OnConnectionBarsPropertyChanged ), "ConnectionBars", ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnConnectionBarsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _surgeArrestor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSurgeArrestor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _surgeArrestor, new PropertyChangedEventHandler( OnSurgeArrestorPropertyChanged ), "SurgeArrestor", ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.SurgeArrestorId } );		
			_surgeArrestor = null;
		}

		/// <summary> setups the sync logic for member _surgeArrestor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSurgeArrestor(IEntity2 relatedEntity)
		{
			DesetupSyncSurgeArrestor(true, true);
			_surgeArrestor = (SurgeArrestorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _surgeArrestor, new PropertyChangedEventHandler( OnSurgeArrestorPropertyChanged ), "SurgeArrestor", ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSurgeArrestorPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", ComponentInspectionReportTransformerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportTransformer", resetFKFields, new int[] { (int)ComponentInspectionReportTransformerFieldIndex.TransformerManufacturerId } );		
			_transformerManufacturer = null;
		}

		/// <summary> setups the sync logic for member _transformerManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTransformerManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncTransformerManufacturer(true, true);
			_transformerManufacturer = (TransformerManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", ComponentInspectionReportTransformerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ComponentInspectionReportTransformerEntity</param>
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
		public  static ComponentInspectionReportTransformerRelations Relations
		{
			get	{ return new ComponentInspectionReportTransformerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionOnTransformer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionOnTransformer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, 0, null, null, null, null, "ActionOnTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ArcDetection' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathArcDetection
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ArcDetectionEntity, 0, null, null, null, null, "ArcDetection", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Brackets' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBrackets
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.BracketsEntity, 0, null, null, null, null, "Brackets", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CableCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCableCondition_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, null, null, "CableCondition_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CableCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCableCondition
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, null, null, "CableCondition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Climate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClimate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ClimateEntity, 0, null, null, null, null, "Climate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CoilCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoilCondition_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, null, null, "CoilCondition_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CoilCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoilCondition
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, null, null, "CoilCondition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ConnectionBars' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathConnectionBars
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity, 0, null, null, null, null, "ConnectionBars", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurgeArrestor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurgeArrestor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory))),
					ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity, 0, null, null, null, null, "SurgeArrestor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportTransformerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, null, null, "TransformerManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportTransformerEntity.CustomProperties;}
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
			get { return ComponentInspectionReportTransformerEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportTransformerId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."ComponentInspectionReportTransformerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportTransformerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportTransformerId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportTransformerId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportTransformerFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The TransformerManufacturerId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."TransformerManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TransformerManufacturerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerManufacturerId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerManufacturerId, value); }
		}

		/// <summary> The TransformerSerialNumber property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."TransformerSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TransformerSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerSerialNumber, value); }
		}

		/// <summary> The MaxTemp property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."MaxTemp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 5, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MaxTemp
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportTransformerFieldIndex.MaxTemp, false); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.MaxTemp, value); }
		}

		/// <summary> The MaxTempResetDate property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."MaxTempResetDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> MaxTempResetDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportTransformerFieldIndex.MaxTempResetDate, false); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.MaxTempResetDate, value); }
		}

		/// <summary> The ActionOnTransformerId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."ActionOnTransformerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ActionOnTransformerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.ActionOnTransformerId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.ActionOnTransformerId, value); }
		}

		/// <summary> The HvcoilConditionId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."HVCoilConditionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HvcoilConditionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.HvcoilConditionId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.HvcoilConditionId, value); }
		}

		/// <summary> The LvcoilConditionId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."LVCoilConditionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LvcoilConditionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.LvcoilConditionId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.LvcoilConditionId, value); }
		}

		/// <summary> The HvcableConditionId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."HVCableConditionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HvcableConditionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.HvcableConditionId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.HvcableConditionId, value); }
		}

		/// <summary> The LvcableConditionId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."LVCableConditionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LvcableConditionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.LvcableConditionId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.LvcableConditionId, value); }
		}

		/// <summary> The BracketsId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."BracketsId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BracketsId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.BracketsId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.BracketsId, value); }
		}

		/// <summary> The TransformerArcDetectionId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."TransformerArcDetectionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TransformerArcDetectionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerArcDetectionId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerArcDetectionId, value); }
		}

		/// <summary> The ClimateId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."ClimateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ClimateId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.ClimateId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.ClimateId, value); }
		}

		/// <summary> The SurgeArrestorId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."SurgeArrestorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SurgeArrestorId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.SurgeArrestorId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.SurgeArrestorId, value); }
		}

		/// <summary> The ConnectionBarsId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."ConnectionBarsId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ConnectionBarsId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportTransformerFieldIndex.ConnectionBarsId, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.ConnectionBarsId, value); }
		}

		/// <summary> The Comments property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."Comments"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Comments
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportTransformerFieldIndex.Comments, true); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.Comments, value); }
		}

		/// <summary> The TransformerClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportTransformer"."TransformerClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TransformerClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportTransformerFieldIndex.TransformerClaimRelevantBooleanAnswerId, value); }
		}



		/// <summary> Gets / sets related entity of type 'ActionOnTransformerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ActionOnTransformerEntity ActionOnTransformer
		{
			get
			{
				return _actionOnTransformer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncActionOnTransformer(value);
				}
				else
				{
					if(value==null)
					{
						if(_actionOnTransformer != null)
						{
							_actionOnTransformer.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ArcDetectionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ArcDetectionEntity ArcDetection
		{
			get
			{
				return _arcDetection;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncArcDetection(value);
				}
				else
				{
					if(value==null)
					{
						if(_arcDetection != null)
						{
							_arcDetection.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
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
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BracketsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BracketsEntity Brackets
		{
			get
			{
				return _brackets;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBrackets(value);
				}
				else
				{
					if(value==null)
					{
						if(_brackets != null)
						{
							_brackets.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CableConditionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CableConditionEntity CableCondition_
		{
			get
			{
				return _cableCondition_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCableCondition_(value);
				}
				else
				{
					if(value==null)
					{
						if(_cableCondition_ != null)
						{
							_cableCondition_.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CableConditionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CableConditionEntity CableCondition
		{
			get
			{
				return _cableCondition;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCableCondition(value);
				}
				else
				{
					if(value==null)
					{
						if(_cableCondition != null)
						{
							_cableCondition.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ClimateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ClimateEntity Climate
		{
			get
			{
				return _climate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncClimate(value);
				}
				else
				{
					if(value==null)
					{
						if(_climate != null)
						{
							_climate.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CoilConditionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CoilConditionEntity CoilCondition_
		{
			get
			{
				return _coilCondition_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCoilCondition_(value);
				}
				else
				{
					if(value==null)
					{
						if(_coilCondition_ != null)
						{
							_coilCondition_.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CoilConditionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CoilConditionEntity CoilCondition
		{
			get
			{
				return _coilCondition;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCoilCondition(value);
				}
				else
				{
					if(value==null)
					{
						if(_coilCondition != null)
						{
							_coilCondition.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
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
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ConnectionBarsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ConnectionBarsEntity ConnectionBars
		{
			get
			{
				return _connectionBars;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncConnectionBars(value);
				}
				else
				{
					if(value==null)
					{
						if(_connectionBars != null)
						{
							_connectionBars.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SurgeArrestorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SurgeArrestorEntity SurgeArrestor
		{
			get
			{
				return _surgeArrestor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSurgeArrestor(value);
				}
				else
				{
					if(value==null)
					{
						if(_surgeArrestor != null)
						{
							_surgeArrestor.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
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
							_transformerManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportTransformer");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportTransformer");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity; }
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
