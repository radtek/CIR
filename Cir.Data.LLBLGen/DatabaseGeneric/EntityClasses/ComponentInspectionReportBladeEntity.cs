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
	/// Entity class which represents the entity 'ComponentInspectionReportBlade'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportBladeDamageEntity> _componentInspectionReportBladeDamage;
		private EntityCollection<ComponentInspectionReportBladeRepairRecordEntity> _componentInspectionReportBladeRepairRecord;
		private EntityCollection<BladeDamagePlacementEntity> _bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage;
		private EntityCollection<BladeEdgeEntity> _bladeEdgeCollectionViaComponentInspectionReportBladeDamage;
		private EntityCollection<BladeInspectionDataEntity> _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage;
		private BladeColorEntity _bladeColor;
		private BladeLengthEntity _bladeLength;
		private BooleanAnswerEntity _booleanAnswer_;
		private BooleanAnswerEntity _booleanAnswer;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private FaultCodeAreaEntity _faultCodeArea;
		private FaultCodeCauseEntity _faultCodeCause;
		private FaultCodeClassificationEntity _faultCodeClassification;
		private FaultCodeTypeEntity _faultCodeType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BladeColor</summary>
			public static readonly string BladeColor = "BladeColor";
			/// <summary>Member name BladeLength</summary>
			public static readonly string BladeLength = "BladeLength";
			/// <summary>Member name BooleanAnswer_</summary>
			public static readonly string BooleanAnswer_ = "BooleanAnswer_";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name FaultCodeArea</summary>
			public static readonly string FaultCodeArea = "FaultCodeArea";
			/// <summary>Member name FaultCodeCause</summary>
			public static readonly string FaultCodeCause = "FaultCodeCause";
			/// <summary>Member name FaultCodeClassification</summary>
			public static readonly string FaultCodeClassification = "FaultCodeClassification";
			/// <summary>Member name FaultCodeType</summary>
			public static readonly string FaultCodeType = "FaultCodeType";
			/// <summary>Member name ComponentInspectionReportBladeDamage</summary>
			public static readonly string ComponentInspectionReportBladeDamage = "ComponentInspectionReportBladeDamage";
			/// <summary>Member name ComponentInspectionReportBladeRepairRecord</summary>
			public static readonly string ComponentInspectionReportBladeRepairRecord = "ComponentInspectionReportBladeRepairRecord";
			/// <summary>Member name BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage = "BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage";
			/// <summary>Member name BladeEdgeCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string BladeEdgeCollectionViaComponentInspectionReportBladeDamage = "BladeEdgeCollectionViaComponentInspectionReportBladeDamage";
			/// <summary>Member name BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportBladeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportBladeEntity():base("ComponentInspectionReportBladeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportBladeEntity(IEntityFields2 fields):base("ComponentInspectionReportBladeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeEntity</param>
		public ComponentInspectionReportBladeEntity(IValidator validator):base("ComponentInspectionReportBladeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeId">PK value for ComponentInspectionReportBlade which data should be fetched into this ComponentInspectionReportBlade object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeEntity(System.Int64 componentInspectionReportBladeId):base("ComponentInspectionReportBladeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportBladeId = componentInspectionReportBladeId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeId">PK value for ComponentInspectionReportBlade which data should be fetched into this ComponentInspectionReportBlade object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeEntity(System.Int64 componentInspectionReportBladeId, IValidator validator):base("ComponentInspectionReportBladeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportBladeId = componentInspectionReportBladeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportBladeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeDamageEntity>)info.GetValue("_componentInspectionReportBladeDamage", typeof(EntityCollection<ComponentInspectionReportBladeDamageEntity>));
				_componentInspectionReportBladeRepairRecord = (EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>)info.GetValue("_componentInspectionReportBladeRepairRecord", typeof(EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>));
				_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeDamagePlacementEntity>)info.GetValue("_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<BladeDamagePlacementEntity>));
				_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeEdgeEntity>)info.GetValue("_bladeEdgeCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<BladeEdgeEntity>));
				_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeInspectionDataEntity>)info.GetValue("_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<BladeInspectionDataEntity>));
				_bladeColor = (BladeColorEntity)info.GetValue("_bladeColor", typeof(BladeColorEntity));
				if(_bladeColor!=null)
				{
					_bladeColor.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bladeLength = (BladeLengthEntity)info.GetValue("_bladeLength", typeof(BladeLengthEntity));
				if(_bladeLength!=null)
				{
					_bladeLength.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_faultCodeArea = (FaultCodeAreaEntity)info.GetValue("_faultCodeArea", typeof(FaultCodeAreaEntity));
				if(_faultCodeArea!=null)
				{
					_faultCodeArea.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_faultCodeCause = (FaultCodeCauseEntity)info.GetValue("_faultCodeCause", typeof(FaultCodeCauseEntity));
				if(_faultCodeCause!=null)
				{
					_faultCodeCause.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_faultCodeClassification = (FaultCodeClassificationEntity)info.GetValue("_faultCodeClassification", typeof(FaultCodeClassificationEntity));
				if(_faultCodeClassification!=null)
				{
					_faultCodeClassification.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_faultCodeType = (FaultCodeTypeEntity)info.GetValue("_faultCodeType", typeof(FaultCodeTypeEntity));
				if(_faultCodeType!=null)
				{
					_faultCodeType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportBladeFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeLengthId:
					DesetupSyncBladeLength(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeColorId:
					DesetupSyncBladeColor(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladePicturesIncludedBooleanAnswerId:
					DesetupSyncBooleanAnswer(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeFaultCodeClassificationId:
					DesetupSyncFaultCodeClassification(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeFaultCodeCauseId:
					DesetupSyncFaultCodeCause(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeFaultCodeTypeId:
					DesetupSyncFaultCodeType(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeFaultCodeAreaId:
					DesetupSyncFaultCodeArea(true, false);
					break;
				case ComponentInspectionReportBladeFieldIndex.BladeClaimRelevantBooleanAnswerId:
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
				case "BladeColor":
					this.BladeColor = (BladeColorEntity)entity;
					break;
				case "BladeLength":
					this.BladeLength = (BladeLengthEntity)entity;
					break;
				case "BooleanAnswer_":
					this.BooleanAnswer_ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "FaultCodeArea":
					this.FaultCodeArea = (FaultCodeAreaEntity)entity;
					break;
				case "FaultCodeCause":
					this.FaultCodeCause = (FaultCodeCauseEntity)entity;
					break;
				case "FaultCodeClassification":
					this.FaultCodeClassification = (FaultCodeClassificationEntity)entity;
					break;
				case "FaultCodeType":
					this.FaultCodeType = (FaultCodeTypeEntity)entity;
					break;
				case "ComponentInspectionReportBladeDamage":
					this.ComponentInspectionReportBladeDamage.Add((ComponentInspectionReportBladeDamageEntity)entity);
					break;
				case "ComponentInspectionReportBladeRepairRecord":
					this.ComponentInspectionReportBladeRepairRecord.Add((ComponentInspectionReportBladeRepairRecordEntity)entity);
					break;
				case "BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage":
					this.BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.Add((BladeDamagePlacementEntity)entity);
					this.BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
					break;
				case "BladeEdgeCollectionViaComponentInspectionReportBladeDamage":
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.Add((BladeEdgeEntity)entity);
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
					break;
				case "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage":
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.Add((BladeInspectionDataEntity)entity);
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
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
				case "BladeColor":
					SetupSyncBladeColor(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BladeLength":
					SetupSyncBladeLength(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					SetupSyncBooleanAnswer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FaultCodeArea":
					SetupSyncFaultCodeArea(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FaultCodeCause":
					SetupSyncFaultCodeCause(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FaultCodeClassification":
					SetupSyncFaultCodeClassification(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FaultCodeType":
					SetupSyncFaultCodeType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeDamage":
					this.ComponentInspectionReportBladeDamage.Add((ComponentInspectionReportBladeDamageEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeRepairRecord":
					this.ComponentInspectionReportBladeRepairRecord.Add((ComponentInspectionReportBladeRepairRecordEntity)relatedEntity);
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
				case "BladeColor":
					DesetupSyncBladeColor(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BladeLength":
					DesetupSyncBladeLength(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					DesetupSyncBooleanAnswer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FaultCodeArea":
					DesetupSyncFaultCodeArea(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FaultCodeCause":
					DesetupSyncFaultCodeCause(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FaultCodeClassification":
					DesetupSyncFaultCodeClassification(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FaultCodeType":
					DesetupSyncFaultCodeType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeDamage":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportBladeDamage, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeRepairRecord":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportBladeRepairRecord, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_bladeColor!=null)
			{
				toReturn.Add(_bladeColor);
			}
			if(_bladeLength!=null)
			{
				toReturn.Add(_bladeLength);
			}
			if(_booleanAnswer_!=null)
			{
				toReturn.Add(_booleanAnswer_);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_faultCodeArea!=null)
			{
				toReturn.Add(_faultCodeArea);
			}
			if(_faultCodeCause!=null)
			{
				toReturn.Add(_faultCodeCause);
			}
			if(_faultCodeClassification!=null)
			{
				toReturn.Add(_faultCodeClassification);
			}
			if(_faultCodeType!=null)
			{
				toReturn.Add(_faultCodeType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportBladeDamage);
			toReturn.Add(this.ComponentInspectionReportBladeRepairRecord);

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
				info.AddValue("_componentInspectionReportBladeDamage", ((_componentInspectionReportBladeDamage!=null) && (_componentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportBladeDamage:null);
				info.AddValue("_componentInspectionReportBladeRepairRecord", ((_componentInspectionReportBladeRepairRecord!=null) && (_componentInspectionReportBladeRepairRecord.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportBladeRepairRecord:null);
				info.AddValue("_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage", ((_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage!=null) && (_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_bladeEdgeCollectionViaComponentInspectionReportBladeDamage", ((_bladeEdgeCollectionViaComponentInspectionReportBladeDamage!=null) && (_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_bladeEdgeCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", ((_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage!=null) && (_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_bladeColor", (!this.MarkedForDeletion?_bladeColor:null));
				info.AddValue("_bladeLength", (!this.MarkedForDeletion?_bladeLength:null));
				info.AddValue("_booleanAnswer_", (!this.MarkedForDeletion?_booleanAnswer_:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_faultCodeArea", (!this.MarkedForDeletion?_faultCodeArea:null));
				info.AddValue("_faultCodeCause", (!this.MarkedForDeletion?_faultCodeCause:null));
				info.AddValue("_faultCodeClassification", (!this.MarkedForDeletion?_faultCodeClassification:null));
				info.AddValue("_faultCodeType", (!this.MarkedForDeletion?_faultCodeType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportBladeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportBladeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportBladeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportBladeDamage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeDamageFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportBladeRepairRecord' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBladeRepairRecord()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeRepairRecordFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeDamagePlacement' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeEdge' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeEdgeCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeInspectionData' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeInspectionDataCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeColor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeColor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeColorFields.BladeColorId, null, ComparisonOperator.Equal, this.BladeColorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeLength' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeLength()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.BladeClaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.BladePicturesIncludedBooleanAnswerId));
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
		/// the related entity of type 'FaultCodeArea' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeArea()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FaultCodeAreaFields.FaultCodeAreaId, null, ComparisonOperator.Equal, this.BladeFaultCodeAreaId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FaultCodeCause' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeCause()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FaultCodeCauseFields.FaultCodeCauseId, null, ComparisonOperator.Equal, this.BladeFaultCodeCauseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FaultCodeClassification' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeClassification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FaultCodeClassificationFields.FaultCodeClassificationId, null, ComparisonOperator.Equal, this.BladeFaultCodeClassificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FaultCodeType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FaultCodeTypeFields.FaultCodeTypeId, null, ComparisonOperator.Equal, this.BladeFaultCodeTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._componentInspectionReportBladeRepairRecord);
			collectionsQueue.Enqueue(this._bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeDamageEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportBladeRepairRecord = (EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>) collectionsQueue.Dequeue();
			this._bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeDamagePlacementEntity>) collectionsQueue.Dequeue();
			this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeEdgeEntity>) collectionsQueue.Dequeue();
			this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeInspectionDataEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._componentInspectionReportBladeRepairRecord != null)
			{
				return true;
			}
			if (this._bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeRepairRecordEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BladeColor", _bladeColor);
			toReturn.Add("BladeLength", _bladeLength);
			toReturn.Add("BooleanAnswer_", _booleanAnswer_);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("FaultCodeArea", _faultCodeArea);
			toReturn.Add("FaultCodeCause", _faultCodeCause);
			toReturn.Add("FaultCodeClassification", _faultCodeClassification);
			toReturn.Add("FaultCodeType", _faultCodeType);
			toReturn.Add("ComponentInspectionReportBladeDamage", _componentInspectionReportBladeDamage);
			toReturn.Add("ComponentInspectionReportBladeRepairRecord", _componentInspectionReportBladeRepairRecord);
			toReturn.Add("BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage", _bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage);
			toReturn.Add("BladeEdgeCollectionViaComponentInspectionReportBladeDamage", _bladeEdgeCollectionViaComponentInspectionReportBladeDamage);
			toReturn.Add("BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportBladeDamage!=null)
			{
				_componentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportBladeRepairRecord!=null)
			{
				_componentInspectionReportBladeRepairRecord.ActiveContext = base.ActiveContext;
			}
			if(_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeEdgeCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeColor!=null)
			{
				_bladeColor.ActiveContext = base.ActiveContext;
			}
			if(_bladeLength!=null)
			{
				_bladeLength.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_!=null)
			{
				_booleanAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeArea!=null)
			{
				_faultCodeArea.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeCause!=null)
			{
				_faultCodeCause.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeClassification!=null)
			{
				_faultCodeClassification.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeType!=null)
			{
				_faultCodeType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportBladeDamage = null;
			_componentInspectionReportBladeRepairRecord = null;
			_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage = null;
			_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = null;
			_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = null;
			_bladeColor = null;
			_bladeLength = null;
			_booleanAnswer_ = null;
			_booleanAnswer = null;
			_componentInspectionReport = null;
			_faultCodeArea = null;
			_faultCodeCause = null;
			_faultCodeClassification = null;
			_faultCodeType = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportBladeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLengthId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeColorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladePicturesIncludedBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeOtherSerialNumber1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeOtherSerialNumber2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeDamageIdentified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeFaultCodeClassificationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeFaultCodeCauseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeFaultCodeTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeFaultCodeAreaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeClaimRelevantBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsVtNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsCalibrationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePreRepairTip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePostRepairTip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePreRepair2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePostRepair2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePreRepair3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePostRepair3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePreRepair4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePostRepair4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePreRepair5", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsLeewardSidePostRepair5", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePreRepairTip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePostRepairTip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePreRepair2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePostRepair2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePreRepair3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePostRepair3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePreRepair4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePostRepair4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePreRepair5", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeLsWindwardSidePostRepair5", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeInspectionReportDescription", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bladeColor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeColor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeColor, new PropertyChangedEventHandler( OnBladeColorPropertyChanged ), "BladeColor", ComponentInspectionReportBladeEntity.Relations.BladeColorEntityUsingBladeColorId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeColorId } );		
			_bladeColor = null;
		}

		/// <summary> setups the sync logic for member _bladeColor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeColor(IEntity2 relatedEntity)
		{
			DesetupSyncBladeColor(true, true);
			_bladeColor = (BladeColorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeColor, new PropertyChangedEventHandler( OnBladeColorPropertyChanged ), "BladeColor", ComponentInspectionReportBladeEntity.Relations.BladeColorEntityUsingBladeColorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeColorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bladeLength</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeLength(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeLength, new PropertyChangedEventHandler( OnBladeLengthPropertyChanged ), "BladeLength", ComponentInspectionReportBladeEntity.Relations.BladeLengthEntityUsingBladeLengthId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeLengthId } );		
			_bladeLength = null;
		}

		/// <summary> setups the sync logic for member _bladeLength</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeLength(IEntity2 relatedEntity)
		{
			DesetupSyncBladeLength(true, true);
			_bladeLength = (BladeLengthEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeLength, new PropertyChangedEventHandler( OnBladeLengthPropertyChanged ), "BladeLength", ComponentInspectionReportBladeEntity.Relations.BladeLengthEntityUsingBladeLengthId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeLengthPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportBlade_", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeClaimRelevantBooleanAnswerId } );		
			_booleanAnswer_ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_(true, true);
			_booleanAnswer_ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladePicturesIncludedBooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _componentInspectionReport</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReport(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _faultCodeArea</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFaultCodeArea(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _faultCodeArea, new PropertyChangedEventHandler( OnFaultCodeAreaPropertyChanged ), "FaultCodeArea", ComponentInspectionReportBladeEntity.Relations.FaultCodeAreaEntityUsingBladeFaultCodeAreaId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeAreaId } );		
			_faultCodeArea = null;
		}

		/// <summary> setups the sync logic for member _faultCodeArea</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFaultCodeArea(IEntity2 relatedEntity)
		{
			DesetupSyncFaultCodeArea(true, true);
			_faultCodeArea = (FaultCodeAreaEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _faultCodeArea, new PropertyChangedEventHandler( OnFaultCodeAreaPropertyChanged ), "FaultCodeArea", ComponentInspectionReportBladeEntity.Relations.FaultCodeAreaEntityUsingBladeFaultCodeAreaId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFaultCodeAreaPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _faultCodeCause</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFaultCodeCause(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _faultCodeCause, new PropertyChangedEventHandler( OnFaultCodeCausePropertyChanged ), "FaultCodeCause", ComponentInspectionReportBladeEntity.Relations.FaultCodeCauseEntityUsingBladeFaultCodeCauseId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeCauseId } );		
			_faultCodeCause = null;
		}

		/// <summary> setups the sync logic for member _faultCodeCause</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFaultCodeCause(IEntity2 relatedEntity)
		{
			DesetupSyncFaultCodeCause(true, true);
			_faultCodeCause = (FaultCodeCauseEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _faultCodeCause, new PropertyChangedEventHandler( OnFaultCodeCausePropertyChanged ), "FaultCodeCause", ComponentInspectionReportBladeEntity.Relations.FaultCodeCauseEntityUsingBladeFaultCodeCauseId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFaultCodeCausePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _faultCodeClassification</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFaultCodeClassification(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _faultCodeClassification, new PropertyChangedEventHandler( OnFaultCodeClassificationPropertyChanged ), "FaultCodeClassification", ComponentInspectionReportBladeEntity.Relations.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeClassificationId } );		
			_faultCodeClassification = null;
		}

		/// <summary> setups the sync logic for member _faultCodeClassification</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFaultCodeClassification(IEntity2 relatedEntity)
		{
			DesetupSyncFaultCodeClassification(true, true);
			_faultCodeClassification = (FaultCodeClassificationEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _faultCodeClassification, new PropertyChangedEventHandler( OnFaultCodeClassificationPropertyChanged ), "FaultCodeClassification", ComponentInspectionReportBladeEntity.Relations.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFaultCodeClassificationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _faultCodeType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFaultCodeType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _faultCodeType, new PropertyChangedEventHandler( OnFaultCodeTypePropertyChanged ), "FaultCodeType", ComponentInspectionReportBladeEntity.Relations.FaultCodeTypeEntityUsingBladeFaultCodeTypeId, true, signalRelatedEntity, "ComponentInspectionReportBlade", resetFKFields, new int[] { (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeTypeId } );		
			_faultCodeType = null;
		}

		/// <summary> setups the sync logic for member _faultCodeType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFaultCodeType(IEntity2 relatedEntity)
		{
			DesetupSyncFaultCodeType(true, true);
			_faultCodeType = (FaultCodeTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _faultCodeType, new PropertyChangedEventHandler( OnFaultCodeTypePropertyChanged ), "FaultCodeType", ComponentInspectionReportBladeEntity.Relations.FaultCodeTypeEntityUsingBladeFaultCodeTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFaultCodeTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportBladeEntity</param>
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
		public  static ComponentInspectionReportBladeRelations Relations
		{
			get	{ return new ComponentInspectionReportBladeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBladeDamage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBladeDamage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, 0, null, null, null, null, "ComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBladeRepairRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBladeRepairRecord
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeRepairRecordEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeRepairRecordEntityUsingComponentInspectionReportBladeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity, 0, null, null, null, null, "ComponentInspectionReportBladeRepairRecord", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeDamagePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, 0, null, null, relations, null, "BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeEdge' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeEdgeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BladeEdgeEntity, 0, null, null, relations, null, "BladeEdgeCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeInspectionData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeInspectionDataCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity, 0, null, null, relations, null, "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeColor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeColor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeColorEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.BladeColorEntityUsingBladeColorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BladeColorEntity, 0, null, null, null, null, "BladeColor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeLength' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeLength
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.BladeLengthEntityUsingBladeLengthId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, 0, null, null, null, null, "BladeLength", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeArea' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeArea
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeAreaEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.FaultCodeAreaEntityUsingBladeFaultCodeAreaId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeAreaEntity, 0, null, null, null, null, "FaultCodeArea", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeCause' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeCause
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeCauseEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.FaultCodeCauseEntityUsingBladeFaultCodeCauseId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeCauseEntity, 0, null, null, null, null, "FaultCodeCause", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeClassification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeClassification
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeClassificationEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeClassificationEntity, 0, null, null, null, null, "FaultCodeClassification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeTypeEntityFactory))),
					ComponentInspectionReportBladeEntity.Relations.FaultCodeTypeEntityUsingBladeFaultCodeTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeTypeEntity, 0, null, null, null, null, "FaultCodeType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportBladeEntity.CustomProperties;}
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
			get { return ComponentInspectionReportBladeEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportBladeId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."ComponentInspectionReportBladeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportBladeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportBladeId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportBladeId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The BladeLengthId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLengthId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeLengthId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLengthId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLengthId, value); }
		}

		/// <summary> The BladeColorId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeColorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeColorId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeColorId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeColorId, value); }
		}

		/// <summary> The BladeSerialNumber property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeSerialNumber, value); }
		}

		/// <summary> The BladePicturesIncludedBooleanAnswerId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladePicturesIncludedBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladePicturesIncludedBooleanAnswerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladePicturesIncludedBooleanAnswerId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladePicturesIncludedBooleanAnswerId, value); }
		}

		/// <summary> The BladeOtherSerialNumber1 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeOtherSerialNumber1"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BladeOtherSerialNumber1
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber1, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber1, value); }
		}

		/// <summary> The BladeOtherSerialNumber2 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeOtherSerialNumber2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BladeOtherSerialNumber2
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber2, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber2, value); }
		}

		/// <summary> The BladeDamageIdentified property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeDamageIdentified"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BladeDamageIdentified
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeDamageIdentified, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeDamageIdentified, value); }
		}

		/// <summary> The BladeFaultCodeClassificationId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeFaultCodeClassificationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeFaultCodeClassificationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeClassificationId, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeClassificationId, value); }
		}

		/// <summary> The BladeFaultCodeCauseId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeFaultCodeCauseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeFaultCodeCauseId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeCauseId, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeCauseId, value); }
		}

		/// <summary> The BladeFaultCodeTypeId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeFaultCodeTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeFaultCodeTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeTypeId, value); }
		}

		/// <summary> The BladeFaultCodeAreaId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeFaultCodeAreaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeFaultCodeAreaId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeAreaId, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeAreaId, value); }
		}

		/// <summary> The BladeClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeClaimRelevantBooleanAnswerId, value); }
		}

		/// <summary> The BladeLsVtNumber property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsVtNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BladeLsVtNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsVtNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsVtNumber, value); }
		}

		/// <summary> The BladeLsCalibrationDate property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsCalibrationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> BladeLsCalibrationDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsCalibrationDate, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsCalibrationDate, value); }
		}

		/// <summary> The BladeLsLeewardSidePreRepairTip property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePreRepairTip"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePreRepairTip
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepairTip, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepairTip, value); }
		}

		/// <summary> The BladeLsLeewardSidePostRepairTip property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePostRepairTip"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePostRepairTip
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepairTip, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepairTip, value); }
		}

		/// <summary> The BladeLsLeewardSidePreRepair2 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePreRepair2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePreRepair2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair2, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair2, value); }
		}

		/// <summary> The BladeLsLeewardSidePostRepair2 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePostRepair2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePostRepair2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair2, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair2, value); }
		}

		/// <summary> The BladeLsLeewardSidePreRepair3 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePreRepair3"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePreRepair3
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair3, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair3, value); }
		}

		/// <summary> The BladeLsLeewardSidePostRepair3 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePostRepair3"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePostRepair3
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair3, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair3, value); }
		}

		/// <summary> The BladeLsLeewardSidePreRepair4 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePreRepair4"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePreRepair4
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair4, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair4, value); }
		}

		/// <summary> The BladeLsLeewardSidePostRepair4 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePostRepair4"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePostRepair4
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair4, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair4, value); }
		}

		/// <summary> The BladeLsLeewardSidePreRepair5 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePreRepair5"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePreRepair5
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair5, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair5, value); }
		}

		/// <summary> The BladeLsLeewardSidePostRepair5 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsLeewardSidePostRepair5"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsLeewardSidePostRepair5
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair5, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair5, value); }
		}

		/// <summary> The BladeLsWindwardSidePreRepairTip property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePreRepairTip"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePreRepairTip
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepairTip, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepairTip, value); }
		}

		/// <summary> The BladeLsWindwardSidePostRepairTip property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePostRepairTip"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePostRepairTip
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepairTip, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepairTip, value); }
		}

		/// <summary> The BladeLsWindwardSidePreRepair2 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePreRepair2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePreRepair2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair2, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair2, value); }
		}

		/// <summary> The BladeLsWindwardSidePostRepair2 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePostRepair2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePostRepair2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair2, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair2, value); }
		}

		/// <summary> The BladeLsWindwardSidePreRepair3 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePreRepair3"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePreRepair3
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair3, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair3, value); }
		}

		/// <summary> The BladeLsWindwardSidePostRepair3 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePostRepair3"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePostRepair3
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair3, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair3, value); }
		}

		/// <summary> The BladeLsWindwardSidePreRepair4 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePreRepair4"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePreRepair4
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair4, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair4, value); }
		}

		/// <summary> The BladeLsWindwardSidePostRepair4 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePostRepair4"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePostRepair4
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair4, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair4, value); }
		}

		/// <summary> The BladeLsWindwardSidePreRepair5 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePreRepair5"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePreRepair5
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair5, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair5, value); }
		}

		/// <summary> The BladeLsWindwardSidePostRepair5 property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeLsWindwardSidePostRepair5"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BladeLsWindwardSidePostRepair5
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair5, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair5, value); }
		}

		/// <summary> The BladeInspectionReportDescription property of the Entity ComponentInspectionReportBlade<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBlade"."BladeInspectionReportDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BladeInspectionReportDescription
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeFieldIndex.BladeInspectionReportDescription, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeFieldIndex.BladeInspectionReportDescription, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportBladeDamageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportBladeDamageEntity))]
		public virtual EntityCollection<ComponentInspectionReportBladeDamageEntity> ComponentInspectionReportBladeDamage
		{
			get
			{
				if(_componentInspectionReportBladeDamage==null)
				{
					_componentInspectionReportBladeDamage = new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory)));
					_componentInspectionReportBladeDamage.SetContainingEntityInfo(this, "ComponentInspectionReportBlade");
				}
				return _componentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportBladeRepairRecordEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportBladeRepairRecordEntity))]
		public virtual EntityCollection<ComponentInspectionReportBladeRepairRecordEntity> ComponentInspectionReportBladeRepairRecord
		{
			get
			{
				if(_componentInspectionReportBladeRepairRecord==null)
				{
					_componentInspectionReportBladeRepairRecord = new EntityCollection<ComponentInspectionReportBladeRepairRecordEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeRepairRecordEntityFactory)));
					_componentInspectionReportBladeRepairRecord.SetContainingEntityInfo(this, "ComponentInspectionReportBlade");
				}
				return _componentInspectionReportBladeRepairRecord;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeDamagePlacementEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeDamagePlacementEntity))]
		public virtual EntityCollection<BladeDamagePlacementEntity> BladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory)));
					_bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _bladeDamagePlacementCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeEdgeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeEdgeEntity))]
		public virtual EntityCollection<BladeEdgeEntity> BladeEdgeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_bladeEdgeCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory)));
					_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _bladeEdgeCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeInspectionDataEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeInspectionDataEntity))]
		public virtual EntityCollection<BladeInspectionDataEntity> BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory)));
					_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeColorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeColorEntity BladeColor
		{
			get
			{
				return _bladeColor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeColor(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeColor != null)
						{
							_bladeColor.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeLengthEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeLengthEntity BladeLength
		{
			get
			{
				return _bladeLength;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeLength(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeLength != null)
						{
							_bladeLength.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
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
							_booleanAnswer_.UnsetRelatedEntity(this, "ComponentInspectionReportBlade_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade_");
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
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
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
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FaultCodeAreaEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FaultCodeAreaEntity FaultCodeArea
		{
			get
			{
				return _faultCodeArea;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFaultCodeArea(value);
				}
				else
				{
					if(value==null)
					{
						if(_faultCodeArea != null)
						{
							_faultCodeArea.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FaultCodeCauseEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FaultCodeCauseEntity FaultCodeCause
		{
			get
			{
				return _faultCodeCause;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFaultCodeCause(value);
				}
				else
				{
					if(value==null)
					{
						if(_faultCodeCause != null)
						{
							_faultCodeCause.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FaultCodeClassificationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FaultCodeClassificationEntity FaultCodeClassification
		{
			get
			{
				return _faultCodeClassification;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFaultCodeClassification(value);
				}
				else
				{
					if(value==null)
					{
						if(_faultCodeClassification != null)
						{
							_faultCodeClassification.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FaultCodeTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FaultCodeTypeEntity FaultCodeType
		{
			get
			{
				return _faultCodeType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFaultCodeType(value);
				}
				else
				{
					if(value==null)
					{
						if(_faultCodeType != null)
						{
							_faultCodeType.UnsetRelatedEntity(this, "ComponentInspectionReportBlade");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBlade");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity; }
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
