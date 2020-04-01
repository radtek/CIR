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
	/// Entity class which represents the entity 'ComponentInspectionReportGenerator'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportGeneratorEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<GeneratorDefectCategorizationEntity> _generatorDefectCategorization;
		private EntityCollection<GeneratorMiscDecisionEntity> _generatorMiscDecisionCollectionViaGeneratorDefectCategorization___;
		private EntityCollection<GeneratorMiscDecisionEntity> _generatorMiscDecisionCollectionViaGeneratorDefectCategorization____;
		private EntityCollection<GeneratorMiscDecisionEntity> _generatorMiscDecisionCollectionViaGeneratorDefectCategorization__;
		private EntityCollection<GeneratorMiscDecisionEntity> _generatorMiscDecisionCollectionViaGeneratorDefectCategorization;
		private EntityCollection<GeneratorMiscDecisionEntity> _generatorMiscDecisionCollectionViaGeneratorDefectCategorization_;
		private ActionToBeTakenOnGeneratorEntity _actionToBeTakenOnGenerator;
		private BooleanAnswerEntity _booleanAnswer;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private CouplingEntity _coupling;
		private GeneratorCoverEntity _generatorCover;
		private GeneratorDriveEndEntity _generatorDriveEnd;
		private GeneratorManufacturerEntity _generatorManufacturer;
		private GeneratorNonDriveEndEntity _generatorNonDriveEnd;
		private GeneratorRotorEntity _generatorRotor;
		private OhmUnitEntity _ohmUnit______;
		private OhmUnitEntity _ohmUnit_____;
		private OhmUnitEntity _ohmUnit________;
		private OhmUnitEntity _ohmUnit_______;
		private OhmUnitEntity _ohmUnit____;
		private OhmUnitEntity _ohmUnit_;
		private OhmUnitEntity _ohmUnit;
		private OhmUnitEntity _ohmUnit___;
		private OhmUnitEntity _ohmUnit__;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ActionToBeTakenOnGenerator</summary>
			public static readonly string ActionToBeTakenOnGenerator = "ActionToBeTakenOnGenerator";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name Coupling</summary>
			public static readonly string Coupling = "Coupling";
			/// <summary>Member name GeneratorCover</summary>
			public static readonly string GeneratorCover = "GeneratorCover";
			/// <summary>Member name GeneratorDriveEnd</summary>
			public static readonly string GeneratorDriveEnd = "GeneratorDriveEnd";
			/// <summary>Member name GeneratorManufacturer</summary>
			public static readonly string GeneratorManufacturer = "GeneratorManufacturer";
			/// <summary>Member name GeneratorNonDriveEnd</summary>
			public static readonly string GeneratorNonDriveEnd = "GeneratorNonDriveEnd";
			/// <summary>Member name GeneratorRotor</summary>
			public static readonly string GeneratorRotor = "GeneratorRotor";
			/// <summary>Member name OhmUnit______</summary>
			public static readonly string OhmUnit______ = "OhmUnit______";
			/// <summary>Member name OhmUnit_____</summary>
			public static readonly string OhmUnit_____ = "OhmUnit_____";
			/// <summary>Member name OhmUnit________</summary>
			public static readonly string OhmUnit________ = "OhmUnit________";
			/// <summary>Member name OhmUnit_______</summary>
			public static readonly string OhmUnit_______ = "OhmUnit_______";
			/// <summary>Member name OhmUnit____</summary>
			public static readonly string OhmUnit____ = "OhmUnit____";
			/// <summary>Member name OhmUnit_</summary>
			public static readonly string OhmUnit_ = "OhmUnit_";
			/// <summary>Member name OhmUnit</summary>
			public static readonly string OhmUnit = "OhmUnit";
			/// <summary>Member name OhmUnit___</summary>
			public static readonly string OhmUnit___ = "OhmUnit___";
			/// <summary>Member name OhmUnit__</summary>
			public static readonly string OhmUnit__ = "OhmUnit__";
			/// <summary>Member name GeneratorDefectCategorization</summary>
			public static readonly string GeneratorDefectCategorization = "GeneratorDefectCategorization";
			/// <summary>Member name GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___</summary>
			public static readonly string GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___ = "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___";
			/// <summary>Member name GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____</summary>
			public static readonly string GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____ = "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____";
			/// <summary>Member name GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__</summary>
			public static readonly string GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__ = "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__";
			/// <summary>Member name GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization</summary>
			public static readonly string GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization = "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization";
			/// <summary>Member name GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_</summary>
			public static readonly string GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_ = "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportGeneratorEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportGeneratorEntity():base("ComponentInspectionReportGeneratorEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportGeneratorEntity(IEntityFields2 fields):base("ComponentInspectionReportGeneratorEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGeneratorEntity</param>
		public ComponentInspectionReportGeneratorEntity(IValidator validator):base("ComponentInspectionReportGeneratorEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGeneratorId">PK value for ComponentInspectionReportGenerator which data should be fetched into this ComponentInspectionReportGenerator object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGeneratorEntity(System.Int64 componentInspectionReportGeneratorId):base("ComponentInspectionReportGeneratorEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportGeneratorId = componentInspectionReportGeneratorId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGeneratorId">PK value for ComponentInspectionReportGenerator which data should be fetched into this ComponentInspectionReportGenerator object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGeneratorEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGeneratorEntity(System.Int64 componentInspectionReportGeneratorId, IValidator validator):base("ComponentInspectionReportGeneratorEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportGeneratorId = componentInspectionReportGeneratorId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportGeneratorEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_generatorDefectCategorization = (EntityCollection<GeneratorDefectCategorizationEntity>)info.GetValue("_generatorDefectCategorization", typeof(EntityCollection<GeneratorDefectCategorizationEntity>));
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___ = (EntityCollection<GeneratorMiscDecisionEntity>)info.GetValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___", typeof(EntityCollection<GeneratorMiscDecisionEntity>));
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____ = (EntityCollection<GeneratorMiscDecisionEntity>)info.GetValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____", typeof(EntityCollection<GeneratorMiscDecisionEntity>));
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__ = (EntityCollection<GeneratorMiscDecisionEntity>)info.GetValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__", typeof(EntityCollection<GeneratorMiscDecisionEntity>));
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization = (EntityCollection<GeneratorMiscDecisionEntity>)info.GetValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization", typeof(EntityCollection<GeneratorMiscDecisionEntity>));
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_ = (EntityCollection<GeneratorMiscDecisionEntity>)info.GetValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_", typeof(EntityCollection<GeneratorMiscDecisionEntity>));
				_actionToBeTakenOnGenerator = (ActionToBeTakenOnGeneratorEntity)info.GetValue("_actionToBeTakenOnGenerator", typeof(ActionToBeTakenOnGeneratorEntity));
				if(_actionToBeTakenOnGenerator!=null)
				{
					_actionToBeTakenOnGenerator.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_coupling = (CouplingEntity)info.GetValue("_coupling", typeof(CouplingEntity));
				if(_coupling!=null)
				{
					_coupling.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorCover = (GeneratorCoverEntity)info.GetValue("_generatorCover", typeof(GeneratorCoverEntity));
				if(_generatorCover!=null)
				{
					_generatorCover.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorDriveEnd = (GeneratorDriveEndEntity)info.GetValue("_generatorDriveEnd", typeof(GeneratorDriveEndEntity));
				if(_generatorDriveEnd!=null)
				{
					_generatorDriveEnd.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorManufacturer = (GeneratorManufacturerEntity)info.GetValue("_generatorManufacturer", typeof(GeneratorManufacturerEntity));
				if(_generatorManufacturer!=null)
				{
					_generatorManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorNonDriveEnd = (GeneratorNonDriveEndEntity)info.GetValue("_generatorNonDriveEnd", typeof(GeneratorNonDriveEndEntity));
				if(_generatorNonDriveEnd!=null)
				{
					_generatorNonDriveEnd.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorRotor = (GeneratorRotorEntity)info.GetValue("_generatorRotor", typeof(GeneratorRotorEntity));
				if(_generatorRotor!=null)
				{
					_generatorRotor.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit______ = (OhmUnitEntity)info.GetValue("_ohmUnit______", typeof(OhmUnitEntity));
				if(_ohmUnit______!=null)
				{
					_ohmUnit______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit_____ = (OhmUnitEntity)info.GetValue("_ohmUnit_____", typeof(OhmUnitEntity));
				if(_ohmUnit_____!=null)
				{
					_ohmUnit_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit________ = (OhmUnitEntity)info.GetValue("_ohmUnit________", typeof(OhmUnitEntity));
				if(_ohmUnit________!=null)
				{
					_ohmUnit________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit_______ = (OhmUnitEntity)info.GetValue("_ohmUnit_______", typeof(OhmUnitEntity));
				if(_ohmUnit_______!=null)
				{
					_ohmUnit_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit____ = (OhmUnitEntity)info.GetValue("_ohmUnit____", typeof(OhmUnitEntity));
				if(_ohmUnit____!=null)
				{
					_ohmUnit____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit_ = (OhmUnitEntity)info.GetValue("_ohmUnit_", typeof(OhmUnitEntity));
				if(_ohmUnit_!=null)
				{
					_ohmUnit_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit = (OhmUnitEntity)info.GetValue("_ohmUnit", typeof(OhmUnitEntity));
				if(_ohmUnit!=null)
				{
					_ohmUnit.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit___ = (OhmUnitEntity)info.GetValue("_ohmUnit___", typeof(OhmUnitEntity));
				if(_ohmUnit___!=null)
				{
					_ohmUnit___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_ohmUnit__ = (OhmUnitEntity)info.GetValue("_ohmUnit__", typeof(OhmUnitEntity));
				if(_ohmUnit__!=null)
				{
					_ohmUnit__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportGeneratorFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorManufacturerId:
					DesetupSyncGeneratorManufacturer(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.CouplingId:
					DesetupSyncCoupling(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.ActionToBeTakenOnGeneratorId:
					DesetupSyncActionToBeTakenOnGenerator(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorDriveEndId:
					DesetupSyncGeneratorDriveEnd(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorNonDriveEndId:
					DesetupSyncGeneratorNonDriveEnd(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorRotorId:
					DesetupSyncGeneratorRotor(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorCoverId:
					DesetupSyncGeneratorCover(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.UgroundOhmUnitId:
					DesetupSyncOhmUnit(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.VgroundOhmUnitId:
					DesetupSyncOhmUnit_(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.WgroundOhmUnitId:
					DesetupSyncOhmUnit__(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.UvohmUnitId:
					DesetupSyncOhmUnit___(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.UwohmUnitId:
					DesetupSyncOhmUnit____(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.VwohmUnitId:
					DesetupSyncOhmUnit_____(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.KgroundOhmUnitId:
					DesetupSyncOhmUnit______(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.LgroundOhmUnitId:
					DesetupSyncOhmUnit_______(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.MgroundOhmUnitId:
					DesetupSyncOhmUnit________(true, false);
					break;
				case ComponentInspectionReportGeneratorFieldIndex.GeneratorClaimRelevantBooleanAnswerId:
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
				case "ActionToBeTakenOnGenerator":
					this.ActionToBeTakenOnGenerator = (ActionToBeTakenOnGeneratorEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "Coupling":
					this.Coupling = (CouplingEntity)entity;
					break;
				case "GeneratorCover":
					this.GeneratorCover = (GeneratorCoverEntity)entity;
					break;
				case "GeneratorDriveEnd":
					this.GeneratorDriveEnd = (GeneratorDriveEndEntity)entity;
					break;
				case "GeneratorManufacturer":
					this.GeneratorManufacturer = (GeneratorManufacturerEntity)entity;
					break;
				case "GeneratorNonDriveEnd":
					this.GeneratorNonDriveEnd = (GeneratorNonDriveEndEntity)entity;
					break;
				case "GeneratorRotor":
					this.GeneratorRotor = (GeneratorRotorEntity)entity;
					break;
				case "OhmUnit______":
					this.OhmUnit______ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit_____":
					this.OhmUnit_____ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit________":
					this.OhmUnit________ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit_______":
					this.OhmUnit_______ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit____":
					this.OhmUnit____ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit_":
					this.OhmUnit_ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit":
					this.OhmUnit = (OhmUnitEntity)entity;
					break;
				case "OhmUnit___":
					this.OhmUnit___ = (OhmUnitEntity)entity;
					break;
				case "OhmUnit__":
					this.OhmUnit__ = (OhmUnitEntity)entity;
					break;
				case "GeneratorDefectCategorization":
					this.GeneratorDefectCategorization.Add((GeneratorDefectCategorizationEntity)entity);
					break;
				case "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___":
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___.IsReadOnly = false;
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___.Add((GeneratorMiscDecisionEntity)entity);
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___.IsReadOnly = true;
					break;
				case "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____":
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____.IsReadOnly = false;
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____.Add((GeneratorMiscDecisionEntity)entity);
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____.IsReadOnly = true;
					break;
				case "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__":
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__.IsReadOnly = false;
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__.Add((GeneratorMiscDecisionEntity)entity);
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__.IsReadOnly = true;
					break;
				case "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization":
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization.IsReadOnly = false;
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization.Add((GeneratorMiscDecisionEntity)entity);
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization.IsReadOnly = true;
					break;
				case "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_":
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_.IsReadOnly = false;
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_.Add((GeneratorMiscDecisionEntity)entity);
					this.GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_.IsReadOnly = true;
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
				case "ActionToBeTakenOnGenerator":
					SetupSyncActionToBeTakenOnGenerator(relatedEntity);
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
				case "Coupling":
					SetupSyncCoupling(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorCover":
					SetupSyncGeneratorCover(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDriveEnd":
					SetupSyncGeneratorDriveEnd(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					SetupSyncGeneratorManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorNonDriveEnd":
					SetupSyncGeneratorNonDriveEnd(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorRotor":
					SetupSyncGeneratorRotor(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit______":
					SetupSyncOhmUnit______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit_____":
					SetupSyncOhmUnit_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit________":
					SetupSyncOhmUnit________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit_______":
					SetupSyncOhmUnit_______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit____":
					SetupSyncOhmUnit____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit_":
					SetupSyncOhmUnit_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit":
					SetupSyncOhmUnit(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit___":
					SetupSyncOhmUnit___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit__":
					SetupSyncOhmUnit__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization":
					this.GeneratorDefectCategorization.Add((GeneratorDefectCategorizationEntity)relatedEntity);
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
				case "ActionToBeTakenOnGenerator":
					DesetupSyncActionToBeTakenOnGenerator(false, true);
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
				case "Coupling":
					DesetupSyncCoupling(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorCover":
					DesetupSyncGeneratorCover(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDriveEnd":
					DesetupSyncGeneratorDriveEnd(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					DesetupSyncGeneratorManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorNonDriveEnd":
					DesetupSyncGeneratorNonDriveEnd(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorRotor":
					DesetupSyncGeneratorRotor(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit______":
					DesetupSyncOhmUnit______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit_____":
					DesetupSyncOhmUnit_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit________":
					DesetupSyncOhmUnit________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit_______":
					DesetupSyncOhmUnit_______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit____":
					DesetupSyncOhmUnit____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit_":
					DesetupSyncOhmUnit_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit":
					DesetupSyncOhmUnit(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit___":
					DesetupSyncOhmUnit___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit__":
					DesetupSyncOhmUnit__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorDefectCategorization":
					base.PerformRelatedEntityRemoval(this.GeneratorDefectCategorization, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_actionToBeTakenOnGenerator!=null)
			{
				toReturn.Add(_actionToBeTakenOnGenerator);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_coupling!=null)
			{
				toReturn.Add(_coupling);
			}
			if(_generatorCover!=null)
			{
				toReturn.Add(_generatorCover);
			}
			if(_generatorDriveEnd!=null)
			{
				toReturn.Add(_generatorDriveEnd);
			}
			if(_generatorManufacturer!=null)
			{
				toReturn.Add(_generatorManufacturer);
			}
			if(_generatorNonDriveEnd!=null)
			{
				toReturn.Add(_generatorNonDriveEnd);
			}
			if(_generatorRotor!=null)
			{
				toReturn.Add(_generatorRotor);
			}
			if(_ohmUnit______!=null)
			{
				toReturn.Add(_ohmUnit______);
			}
			if(_ohmUnit_____!=null)
			{
				toReturn.Add(_ohmUnit_____);
			}
			if(_ohmUnit________!=null)
			{
				toReturn.Add(_ohmUnit________);
			}
			if(_ohmUnit_______!=null)
			{
				toReturn.Add(_ohmUnit_______);
			}
			if(_ohmUnit____!=null)
			{
				toReturn.Add(_ohmUnit____);
			}
			if(_ohmUnit_!=null)
			{
				toReturn.Add(_ohmUnit_);
			}
			if(_ohmUnit!=null)
			{
				toReturn.Add(_ohmUnit);
			}
			if(_ohmUnit___!=null)
			{
				toReturn.Add(_ohmUnit___);
			}
			if(_ohmUnit__!=null)
			{
				toReturn.Add(_ohmUnit__);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.GeneratorDefectCategorization);

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
				info.AddValue("_generatorDefectCategorization", ((_generatorDefectCategorization!=null) && (_generatorDefectCategorization.Count>0) && !this.MarkedForDeletion)?_generatorDefectCategorization:null);
				info.AddValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___", ((_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___!=null) && (_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___.Count>0) && !this.MarkedForDeletion)?_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___:null);
				info.AddValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____", ((_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____!=null) && (_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____.Count>0) && !this.MarkedForDeletion)?_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____:null);
				info.AddValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__", ((_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__!=null) && (_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__.Count>0) && !this.MarkedForDeletion)?_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__:null);
				info.AddValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization", ((_generatorMiscDecisionCollectionViaGeneratorDefectCategorization!=null) && (_generatorMiscDecisionCollectionViaGeneratorDefectCategorization.Count>0) && !this.MarkedForDeletion)?_generatorMiscDecisionCollectionViaGeneratorDefectCategorization:null);
				info.AddValue("_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_", ((_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_!=null) && (_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_.Count>0) && !this.MarkedForDeletion)?_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_:null);
				info.AddValue("_actionToBeTakenOnGenerator", (!this.MarkedForDeletion?_actionToBeTakenOnGenerator:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_coupling", (!this.MarkedForDeletion?_coupling:null));
				info.AddValue("_generatorCover", (!this.MarkedForDeletion?_generatorCover:null));
				info.AddValue("_generatorDriveEnd", (!this.MarkedForDeletion?_generatorDriveEnd:null));
				info.AddValue("_generatorManufacturer", (!this.MarkedForDeletion?_generatorManufacturer:null));
				info.AddValue("_generatorNonDriveEnd", (!this.MarkedForDeletion?_generatorNonDriveEnd:null));
				info.AddValue("_generatorRotor", (!this.MarkedForDeletion?_generatorRotor:null));
				info.AddValue("_ohmUnit______", (!this.MarkedForDeletion?_ohmUnit______:null));
				info.AddValue("_ohmUnit_____", (!this.MarkedForDeletion?_ohmUnit_____:null));
				info.AddValue("_ohmUnit________", (!this.MarkedForDeletion?_ohmUnit________:null));
				info.AddValue("_ohmUnit_______", (!this.MarkedForDeletion?_ohmUnit_______:null));
				info.AddValue("_ohmUnit____", (!this.MarkedForDeletion?_ohmUnit____:null));
				info.AddValue("_ohmUnit_", (!this.MarkedForDeletion?_ohmUnit_:null));
				info.AddValue("_ohmUnit", (!this.MarkedForDeletion?_ohmUnit:null));
				info.AddValue("_ohmUnit___", (!this.MarkedForDeletion?_ohmUnit___:null));
				info.AddValue("_ohmUnit__", (!this.MarkedForDeletion?_ohmUnit__:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportGeneratorFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportGeneratorFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportGeneratorRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDefectCategorization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDefectCategorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDefectCategorizationFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscWaterDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGroundingDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscBearingDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorMiscDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
			bucket.Relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, null, ComparisonOperator.Equal, this.ComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionToBeTakenOnGeneratorFields.ActionToBeTakenOnGeneratorId, null, ComparisonOperator.Equal, this.ActionToBeTakenOnGeneratorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.GeneratorClaimRelevantBooleanAnswerId));
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
		/// the related entity of type 'Coupling' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoupling()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouplingFields.CouplingId, null, ComparisonOperator.Equal, this.CouplingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCover()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorCoverFields.GeneratorCoverId, null, ComparisonOperator.Equal, this.GeneratorCoverId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEnd()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorDriveEndFields.GeneratorDriveEndId, null, ComparisonOperator.Equal, this.GeneratorDriveEndId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorManufacturerFields.GeneratorManufacturerId, null, ComparisonOperator.Equal, this.GeneratorManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEnd()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorNonDriveEndFields.GeneratorNonDriveEndId, null, ComparisonOperator.Equal, this.GeneratorNonDriveEndId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.KgroundOhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.VwohmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.MgroundOhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.LgroundOhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.UwohmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.VgroundOhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.UgroundOhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.UvohmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.WgroundOhmUnitId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._generatorDefectCategorization);
			collectionsQueue.Enqueue(this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization___);
			collectionsQueue.Enqueue(this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization____);
			collectionsQueue.Enqueue(this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization__);
			collectionsQueue.Enqueue(this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization);
			collectionsQueue.Enqueue(this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._generatorDefectCategorization = (EntityCollection<GeneratorDefectCategorizationEntity>) collectionsQueue.Dequeue();
			this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization___ = (EntityCollection<GeneratorMiscDecisionEntity>) collectionsQueue.Dequeue();
			this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization____ = (EntityCollection<GeneratorMiscDecisionEntity>) collectionsQueue.Dequeue();
			this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization__ = (EntityCollection<GeneratorMiscDecisionEntity>) collectionsQueue.Dequeue();
			this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization = (EntityCollection<GeneratorMiscDecisionEntity>) collectionsQueue.Dequeue();
			this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization_ = (EntityCollection<GeneratorMiscDecisionEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._generatorDefectCategorization != null)
			{
				return true;
			}
			if (this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization___ != null)
			{
				return true;
			}
			if (this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization____ != null)
			{
				return true;
			}
			if (this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization__ != null)
			{
				return true;
			}
			if (this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization != null)
			{
				return true;
			}
			if (this._generatorMiscDecisionCollectionViaGeneratorDefectCategorization_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ActionToBeTakenOnGenerator", _actionToBeTakenOnGenerator);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("Coupling", _coupling);
			toReturn.Add("GeneratorCover", _generatorCover);
			toReturn.Add("GeneratorDriveEnd", _generatorDriveEnd);
			toReturn.Add("GeneratorManufacturer", _generatorManufacturer);
			toReturn.Add("GeneratorNonDriveEnd", _generatorNonDriveEnd);
			toReturn.Add("GeneratorRotor", _generatorRotor);
			toReturn.Add("OhmUnit______", _ohmUnit______);
			toReturn.Add("OhmUnit_____", _ohmUnit_____);
			toReturn.Add("OhmUnit________", _ohmUnit________);
			toReturn.Add("OhmUnit_______", _ohmUnit_______);
			toReturn.Add("OhmUnit____", _ohmUnit____);
			toReturn.Add("OhmUnit_", _ohmUnit_);
			toReturn.Add("OhmUnit", _ohmUnit);
			toReturn.Add("OhmUnit___", _ohmUnit___);
			toReturn.Add("OhmUnit__", _ohmUnit__);
			toReturn.Add("GeneratorDefectCategorization", _generatorDefectCategorization);
			toReturn.Add("GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___", _generatorMiscDecisionCollectionViaGeneratorDefectCategorization___);
			toReturn.Add("GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____", _generatorMiscDecisionCollectionViaGeneratorDefectCategorization____);
			toReturn.Add("GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__", _generatorMiscDecisionCollectionViaGeneratorDefectCategorization__);
			toReturn.Add("GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization", _generatorMiscDecisionCollectionViaGeneratorDefectCategorization);
			toReturn.Add("GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_", _generatorMiscDecisionCollectionViaGeneratorDefectCategorization_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_generatorDefectCategorization!=null)
			{
				_generatorDefectCategorization.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___!=null)
			{
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____!=null)
			{
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__!=null)
			{
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization!=null)
			{
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization.ActiveContext = base.ActiveContext;
			}
			if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_!=null)
			{
				_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGenerator!=null)
			{
				_actionToBeTakenOnGenerator.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_coupling!=null)
			{
				_coupling.ActiveContext = base.ActiveContext;
			}
			if(_generatorCover!=null)
			{
				_generatorCover.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEnd!=null)
			{
				_generatorDriveEnd.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturer!=null)
			{
				_generatorManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEnd!=null)
			{
				_generatorNonDriveEnd.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotor!=null)
			{
				_generatorRotor.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit______!=null)
			{
				_ohmUnit______.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit_____!=null)
			{
				_ohmUnit_____.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit________!=null)
			{
				_ohmUnit________.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit_______!=null)
			{
				_ohmUnit_______.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit____!=null)
			{
				_ohmUnit____.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit_!=null)
			{
				_ohmUnit_.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit!=null)
			{
				_ohmUnit.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit___!=null)
			{
				_ohmUnit___.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit__!=null)
			{
				_ohmUnit__.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_generatorDefectCategorization = null;
			_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___ = null;
			_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____ = null;
			_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__ = null;
			_generatorMiscDecisionCollectionViaGeneratorDefectCategorization = null;
			_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_ = null;
			_actionToBeTakenOnGenerator = null;
			_booleanAnswer = null;
			_componentInspectionReport = null;
			_coupling = null;
			_generatorCover = null;
			_generatorDriveEnd = null;
			_generatorManufacturer = null;
			_generatorNonDriveEnd = null;
			_generatorRotor = null;
			_ohmUnit______ = null;
			_ohmUnit_____ = null;
			_ohmUnit________ = null;
			_ohmUnit_______ = null;
			_ohmUnit____ = null;
			_ohmUnit_ = null;
			_ohmUnit = null;
			_ohmUnit___ = null;
			_ohmUnit__ = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportGeneratorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherManufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorMaxTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorMaxTemperatureResetDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CouplingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActionToBeTakenOnGeneratorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorDriveEndId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorNonDriveEndId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorRotorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorCoverId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AirToAirCoolerInternalId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AirToAirCoolerExternalId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorComments", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Uground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Vground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Wground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Uv", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Uw", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Vw", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Kground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Lground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mground", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UvohmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UwohmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VwohmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("KgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MgroundOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("U1U2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("V1V2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("W1W2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("K1L1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("L1M1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("K1M1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("K2L2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("L2M2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("K2M2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorRewoundLocally", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratorClaimRelevantBooleanAnswerId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _actionToBeTakenOnGenerator</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActionToBeTakenOnGenerator(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _actionToBeTakenOnGenerator, new PropertyChangedEventHandler( OnActionToBeTakenOnGeneratorPropertyChanged ), "ActionToBeTakenOnGenerator", ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.ActionToBeTakenOnGeneratorId } );		
			_actionToBeTakenOnGenerator = null;
		}

		/// <summary> setups the sync logic for member _actionToBeTakenOnGenerator</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActionToBeTakenOnGenerator(IEntity2 relatedEntity)
		{
			DesetupSyncActionToBeTakenOnGenerator(true, true);
			_actionToBeTakenOnGenerator = (ActionToBeTakenOnGeneratorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _actionToBeTakenOnGenerator, new PropertyChangedEventHandler( OnActionToBeTakenOnGeneratorPropertyChanged ), "ActionToBeTakenOnGenerator", ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActionToBeTakenOnGeneratorPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorClaimRelevantBooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _coupling</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCoupling(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _coupling, new PropertyChangedEventHandler( OnCouplingPropertyChanged ), "Coupling", ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.CouplingId } );		
			_coupling = null;
		}

		/// <summary> setups the sync logic for member _coupling</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCoupling(IEntity2 relatedEntity)
		{
			DesetupSyncCoupling(true, true);
			_coupling = (CouplingEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _coupling, new PropertyChangedEventHandler( OnCouplingPropertyChanged ), "Coupling", ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCouplingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorCover</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorCover(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorCover, new PropertyChangedEventHandler( OnGeneratorCoverPropertyChanged ), "GeneratorCover", ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorCoverId } );		
			_generatorCover = null;
		}

		/// <summary> setups the sync logic for member _generatorCover</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorCover(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorCover(true, true);
			_generatorCover = (GeneratorCoverEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorCover, new PropertyChangedEventHandler( OnGeneratorCoverPropertyChanged ), "GeneratorCover", ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorCoverPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorDriveEnd</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorDriveEnd(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorDriveEnd, new PropertyChangedEventHandler( OnGeneratorDriveEndPropertyChanged ), "GeneratorDriveEnd", ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorDriveEndId } );		
			_generatorDriveEnd = null;
		}

		/// <summary> setups the sync logic for member _generatorDriveEnd</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorDriveEnd(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorDriveEnd(true, true);
			_generatorDriveEnd = (GeneratorDriveEndEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorDriveEnd, new PropertyChangedEventHandler( OnGeneratorDriveEndPropertyChanged ), "GeneratorDriveEnd", ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorDriveEndPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorManufacturerId } );		
			_generatorManufacturer = null;
		}

		/// <summary> setups the sync logic for member _generatorManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorManufacturer(true, true);
			_generatorManufacturer = (GeneratorManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _generatorNonDriveEnd</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorNonDriveEnd(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorNonDriveEnd, new PropertyChangedEventHandler( OnGeneratorNonDriveEndPropertyChanged ), "GeneratorNonDriveEnd", ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorNonDriveEndId } );		
			_generatorNonDriveEnd = null;
		}

		/// <summary> setups the sync logic for member _generatorNonDriveEnd</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorNonDriveEnd(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorNonDriveEnd(true, true);
			_generatorNonDriveEnd = (GeneratorNonDriveEndEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorNonDriveEnd, new PropertyChangedEventHandler( OnGeneratorNonDriveEndPropertyChanged ), "GeneratorNonDriveEnd", ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorNonDriveEndPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorRotor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorRotor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorRotor, new PropertyChangedEventHandler( OnGeneratorRotorPropertyChanged ), "GeneratorRotor", ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRotorId } );		
			_generatorRotor = null;
		}

		/// <summary> setups the sync logic for member _generatorRotor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorRotor(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorRotor(true, true);
			_generatorRotor = (GeneratorRotorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorRotor, new PropertyChangedEventHandler( OnGeneratorRotorPropertyChanged ), "GeneratorRotor", ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorRotorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit______, new PropertyChangedEventHandler( OnOhmUnit______PropertyChanged ), "OhmUnit______", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingKgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator______", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.KgroundOhmUnitId } );		
			_ohmUnit______ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit______(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit______(true, true);
			_ohmUnit______ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit______, new PropertyChangedEventHandler( OnOhmUnit______PropertyChanged ), "OhmUnit______", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingKgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit_____, new PropertyChangedEventHandler( OnOhmUnit_____PropertyChanged ), "OhmUnit_____", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVwohmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator_____", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.VwohmUnitId } );		
			_ohmUnit_____ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit_____(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit_____(true, true);
			_ohmUnit_____ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit_____, new PropertyChangedEventHandler( OnOhmUnit_____PropertyChanged ), "OhmUnit_____", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVwohmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit________, new PropertyChangedEventHandler( OnOhmUnit________PropertyChanged ), "OhmUnit________", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingMgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator________", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.MgroundOhmUnitId } );		
			_ohmUnit________ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit________(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit________(true, true);
			_ohmUnit________ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit________, new PropertyChangedEventHandler( OnOhmUnit________PropertyChanged ), "OhmUnit________", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingMgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit_______, new PropertyChangedEventHandler( OnOhmUnit_______PropertyChanged ), "OhmUnit_______", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingLgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator_______", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.LgroundOhmUnitId } );		
			_ohmUnit_______ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit_______(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit_______(true, true);
			_ohmUnit_______ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit_______, new PropertyChangedEventHandler( OnOhmUnit_______PropertyChanged ), "OhmUnit_______", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingLgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit____, new PropertyChangedEventHandler( OnOhmUnit____PropertyChanged ), "OhmUnit____", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUwohmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator____", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.UwohmUnitId } );		
			_ohmUnit____ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit____(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit____(true, true);
			_ohmUnit____ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit____, new PropertyChangedEventHandler( OnOhmUnit____PropertyChanged ), "OhmUnit____", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUwohmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit_, new PropertyChangedEventHandler( OnOhmUnit_PropertyChanged ), "OhmUnit_", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator_", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.VgroundOhmUnitId } );		
			_ohmUnit_ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit_(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit_(true, true);
			_ohmUnit_ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit_, new PropertyChangedEventHandler( OnOhmUnit_PropertyChanged ), "OhmUnit_", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit, new PropertyChangedEventHandler( OnOhmUnitPropertyChanged ), "OhmUnit", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.UgroundOhmUnitId } );		
			_ohmUnit = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit(true, true);
			_ohmUnit = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit, new PropertyChangedEventHandler( OnOhmUnitPropertyChanged ), "OhmUnit", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnitPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit___, new PropertyChangedEventHandler( OnOhmUnit___PropertyChanged ), "OhmUnit___", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUvohmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator___", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.UvohmUnitId } );		
			_ohmUnit___ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit___(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit___(true, true);
			_ohmUnit___ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit___, new PropertyChangedEventHandler( OnOhmUnit___PropertyChanged ), "OhmUnit___", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUvohmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _ohmUnit__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit__, new PropertyChangedEventHandler( OnOhmUnit__PropertyChanged ), "OhmUnit__", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingWgroundOhmUnitId, true, signalRelatedEntity, "ComponentInspectionReportGenerator__", resetFKFields, new int[] { (int)ComponentInspectionReportGeneratorFieldIndex.WgroundOhmUnitId } );		
			_ohmUnit__ = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit__(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit__(true, true);
			_ohmUnit__ = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit__, new PropertyChangedEventHandler( OnOhmUnit__PropertyChanged ), "OhmUnit__", ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingWgroundOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnit__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportGeneratorEntity</param>
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
		public  static ComponentInspectionReportGeneratorRelations Relations
		{
			get	{ return new ComponentInspectionReportGeneratorRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathGeneratorDefectCategorization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorDefectCategorizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDefectCategorizationEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity, 0, null, null, null, null, "GeneratorDefectCategorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, relations, null, "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscWaterDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, relations, null, "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGroundingDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, relations, null, "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscBearingDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, relations, null, "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorMiscDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId;
				intermediateRelation.SetAliases(string.Empty, "GeneratorDefectCategorization_");
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId, "ComponentInspectionReportGeneratorEntity__", "GeneratorDefectCategorization_", JoinHint.None);
				relations.Add(GeneratorDefectCategorizationEntity.Relations.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision, "GeneratorDefectCategorization_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity, 0, null, null, relations, null, "GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGenerator
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, null, null, "ActionToBeTakenOnGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoupling
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, null, null, "Coupling", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCover
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, null, null, "GeneratorCover", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEnd
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, null, null, "GeneratorDriveEnd", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, null, null, "GeneratorManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEnd
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, null, null, "GeneratorNonDriveEnd", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, null, null, "GeneratorRotor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingKgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVwohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingMgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingLgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUwohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUvohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingWgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportGeneratorEntity.CustomProperties;}
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
			get { return ComponentInspectionReportGeneratorEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportGeneratorId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."ComponentInspectionReportGeneratorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportGeneratorId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportGeneratorId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportGeneratorId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The GeneratorManufacturerId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneratorManufacturerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorManufacturerId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorManufacturerId, value); }
		}

		/// <summary> The GeneratorSerialNumber property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String GeneratorSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorSerialNumber, value); }
		}

		/// <summary> The OtherManufacturer property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."OtherManufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OtherManufacturer
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.OtherManufacturer, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.OtherManufacturer, value); }
		}

		/// <summary> The GeneratorMaxTemperature property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorMaxTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 5, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal GeneratorMaxTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperature, value); }
		}

		/// <summary> The GeneratorMaxTemperatureResetDate property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorMaxTemperatureResetDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime GeneratorMaxTemperatureResetDate
		{
			get { return (System.DateTime)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperatureResetDate, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperatureResetDate, value); }
		}

		/// <summary> The CouplingId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."CouplingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CouplingId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.CouplingId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.CouplingId, value); }
		}

		/// <summary> The ActionToBeTakenOnGeneratorId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."ActionToBeTakenOnGeneratorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ActionToBeTakenOnGeneratorId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.ActionToBeTakenOnGeneratorId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.ActionToBeTakenOnGeneratorId, value); }
		}

		/// <summary> The GeneratorDriveEndId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorDriveEndId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneratorDriveEndId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorDriveEndId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorDriveEndId, value); }
		}

		/// <summary> The GeneratorNonDriveEndId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorNonDriveEndId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneratorNonDriveEndId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorNonDriveEndId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorNonDriveEndId, value); }
		}

		/// <summary> The GeneratorRotorId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorRotorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneratorRotorId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRotorId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRotorId, value); }
		}

		/// <summary> The GeneratorCoverId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorCoverId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GeneratorCoverId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorCoverId, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorCoverId, value); }
		}

		/// <summary> The AirToAirCoolerInternalId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."AirToAirCoolerInternalId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AirToAirCoolerInternalId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerInternalId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerInternalId, value); }
		}

		/// <summary> The AirToAirCoolerExternalId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."AirToAirCoolerExternalId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AirToAirCoolerExternalId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerExternalId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerExternalId, value); }
		}

		/// <summary> The GeneratorComments property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorComments"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GeneratorComments
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorComments, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorComments, value); }
		}

		/// <summary> The Uground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Uground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uground, value); }
		}

		/// <summary> The Vground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."VGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Vground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Vground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Vground, value); }
		}

		/// <summary> The Wground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."WGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Wground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Wground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Wground, value); }
		}

		/// <summary> The Uv property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UV"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Uv
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uv, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uv, value); }
		}

		/// <summary> The Uw property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UW"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Uw
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uw, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Uw, value); }
		}

		/// <summary> The Vw property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."VW"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Vw
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Vw, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Vw, value); }
		}

		/// <summary> The Kground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."KGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Kground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Kground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Kground, value); }
		}

		/// <summary> The Lground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."LGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Lground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Lground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Lground, value); }
		}

		/// <summary> The Mground property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."MGround"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 12, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Mground
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.Mground, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.Mground, value); }
		}

		/// <summary> The UgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.UgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.UgroundOhmUnitId, value); }
		}

		/// <summary> The VgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."VGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> VgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.VgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.VgroundOhmUnitId, value); }
		}

		/// <summary> The WgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."WGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> WgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.WgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.WgroundOhmUnitId, value); }
		}

		/// <summary> The UvohmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UVOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UvohmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.UvohmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.UvohmUnitId, value); }
		}

		/// <summary> The UwohmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."UWOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UwohmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.UwohmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.UwohmUnitId, value); }
		}

		/// <summary> The VwohmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."VWOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> VwohmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.VwohmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.VwohmUnitId, value); }
		}

		/// <summary> The KgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."KGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> KgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.KgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.KgroundOhmUnitId, value); }
		}

		/// <summary> The LgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."LGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.LgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.LgroundOhmUnitId, value); }
		}

		/// <summary> The MgroundOhmUnitId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."MGroundOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MgroundOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.MgroundOhmUnitId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.MgroundOhmUnitId, value); }
		}

		/// <summary> The U1U2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."U1U2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> U1U2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.U1U2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.U1U2, value); }
		}

		/// <summary> The V1V2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."V1V2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> V1V2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.V1V2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.V1V2, value); }
		}

		/// <summary> The W1W2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."W1W2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> W1W2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.W1W2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.W1W2, value); }
		}

		/// <summary> The K1L1 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."K1L1"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> K1L1
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.K1L1, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.K1L1, value); }
		}

		/// <summary> The L1M1 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."L1M1"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> L1M1
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.L1M1, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.L1M1, value); }
		}

		/// <summary> The K1M1 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."K1M1"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> K1M1
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.K1M1, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.K1M1, value); }
		}

		/// <summary> The K2L2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."K2L2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> K2L2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.K2L2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.K2L2, value); }
		}

		/// <summary> The L2M2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."L2M2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> L2M2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.L2M2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.L2M2, value); }
		}

		/// <summary> The K2M2 property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."K2M2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> K2M2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.K2M2, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.K2M2, value); }
		}

		/// <summary> The GeneratorRewoundLocally property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorRewoundLocally"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GeneratorRewoundLocally
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRewoundLocally, true); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRewoundLocally, value); }
		}

		/// <summary> The GeneratorClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportGenerator<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGenerator"."GeneratorClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GeneratorClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGeneratorFieldIndex.GeneratorClaimRelevantBooleanAnswerId, value); }
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
					_generatorDefectCategorization.SetContainingEntityInfo(this, "ComponentInspectionReportGenerator");
				}
				return _generatorDefectCategorization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorMiscDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorMiscDecisionEntity))]
		public virtual EntityCollection<GeneratorMiscDecisionEntity> GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization___
		{
			get
			{
				if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___==null)
				{
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___ = new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory)));
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization___.IsReadOnly=true;
				}
				return _generatorMiscDecisionCollectionViaGeneratorDefectCategorization___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorMiscDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorMiscDecisionEntity))]
		public virtual EntityCollection<GeneratorMiscDecisionEntity> GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization____
		{
			get
			{
				if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____==null)
				{
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____ = new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory)));
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization____.IsReadOnly=true;
				}
				return _generatorMiscDecisionCollectionViaGeneratorDefectCategorization____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorMiscDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorMiscDecisionEntity))]
		public virtual EntityCollection<GeneratorMiscDecisionEntity> GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization__
		{
			get
			{
				if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__==null)
				{
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__ = new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory)));
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization__.IsReadOnly=true;
				}
				return _generatorMiscDecisionCollectionViaGeneratorDefectCategorization__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorMiscDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorMiscDecisionEntity))]
		public virtual EntityCollection<GeneratorMiscDecisionEntity> GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization
		{
			get
			{
				if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization==null)
				{
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization = new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory)));
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization.IsReadOnly=true;
				}
				return _generatorMiscDecisionCollectionViaGeneratorDefectCategorization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorMiscDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorMiscDecisionEntity))]
		public virtual EntityCollection<GeneratorMiscDecisionEntity> GeneratorMiscDecisionCollectionViaGeneratorDefectCategorization_
		{
			get
			{
				if(_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_==null)
				{
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_ = new EntityCollection<GeneratorMiscDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorMiscDecisionEntityFactory)));
					_generatorMiscDecisionCollectionViaGeneratorDefectCategorization_.IsReadOnly=true;
				}
				return _generatorMiscDecisionCollectionViaGeneratorDefectCategorization_;
			}
		}

		/// <summary> Gets / sets related entity of type 'ActionToBeTakenOnGeneratorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ActionToBeTakenOnGeneratorEntity ActionToBeTakenOnGenerator
		{
			get
			{
				return _actionToBeTakenOnGenerator;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncActionToBeTakenOnGenerator(value);
				}
				else
				{
					if(value==null)
					{
						if(_actionToBeTakenOnGenerator != null)
						{
							_actionToBeTakenOnGenerator.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
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
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
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
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CouplingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CouplingEntity Coupling
		{
			get
			{
				return _coupling;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCoupling(value);
				}
				else
				{
					if(value==null)
					{
						if(_coupling != null)
						{
							_coupling.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorCoverEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorCoverEntity GeneratorCover
		{
			get
			{
				return _generatorCover;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorCover(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorCover != null)
						{
							_generatorCover.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorDriveEndEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorDriveEndEntity GeneratorDriveEnd
		{
			get
			{
				return _generatorDriveEnd;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorDriveEnd(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorDriveEnd != null)
						{
							_generatorDriveEnd.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
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
							_generatorManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorNonDriveEndEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorNonDriveEndEntity GeneratorNonDriveEnd
		{
			get
			{
				return _generatorNonDriveEnd;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorNonDriveEnd(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorNonDriveEnd != null)
						{
							_generatorNonDriveEnd.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorRotorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorRotorEntity GeneratorRotor
		{
			get
			{
				return _generatorRotor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorRotor(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorRotor != null)
						{
							_generatorRotor.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit______
		{
			get
			{
				return _ohmUnit______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit______(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit______ != null)
						{
							_ohmUnit______.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit_____
		{
			get
			{
				return _ohmUnit_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit_____ != null)
						{
							_ohmUnit_____.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit________
		{
			get
			{
				return _ohmUnit________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit________(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit________ != null)
						{
							_ohmUnit________.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit_______
		{
			get
			{
				return _ohmUnit_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit_______ != null)
						{
							_ohmUnit_______.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator_______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator_______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit____
		{
			get
			{
				return _ohmUnit____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit____(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit____ != null)
						{
							_ohmUnit____.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit_
		{
			get
			{
				return _ohmUnit_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit_(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit_ != null)
						{
							_ohmUnit_.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit
		{
			get
			{
				return _ohmUnit;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit != null)
						{
							_ohmUnit.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit___
		{
			get
			{
				return _ohmUnit___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit___(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit___ != null)
						{
							_ohmUnit___.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit__
		{
			get
			{
				return _ohmUnit__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit__(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit__ != null)
						{
							_ohmUnit__.UnsetRelatedEntity(this, "ComponentInspectionReportGenerator__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGenerator__");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity; }
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
