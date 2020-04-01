///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.Linq
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.RelationClasses;

namespace Cir.Data.LLBLGen.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((Cir.Data.LLBLGen.EntityType)typeOfEntity)
			{
				case Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity:
					toReturn = this.ActionOnTransformer;
					break;
				case Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity:
					toReturn = this.ActionToBeTakenOnGenerator;
					break;
				case Cir.Data.LLBLGen.EntityType.ArcDetectionEntity:
					toReturn = this.ArcDetection;
					break;
				case Cir.Data.LLBLGen.EntityType.BearingDamageCategoryEntity:
					toReturn = this.BearingDamageCategory;
					break;
				case Cir.Data.LLBLGen.EntityType.BearingErrorEntity:
					toReturn = this.BearingError;
					break;
				case Cir.Data.LLBLGen.EntityType.BearingPosEntity:
					toReturn = this.BearingPos;
					break;
				case Cir.Data.LLBLGen.EntityType.BearingTypeEntity:
					toReturn = this.BearingType;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeColorEntity:
					toReturn = this.BladeColor;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity:
					toReturn = this.BladeDamagePlacement;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeEdgeEntity:
					toReturn = this.BladeEdge;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity:
					toReturn = this.BladeInspectionData;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeLengthEntity:
					toReturn = this.BladeLength;
					break;
				case Cir.Data.LLBLGen.EntityType.BladeManufacturerEntity:
					toReturn = this.BladeManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity:
					toReturn = this.BooleanAnswer;
					break;
				case Cir.Data.LLBLGen.EntityType.BracketsEntity:
					toReturn = this.Brackets;
					break;
				case Cir.Data.LLBLGen.EntityType.CableConditionEntity:
					toReturn = this.CableCondition;
					break;
				case Cir.Data.LLBLGen.EntityType.CimCaseFailureItemsEntity:
					toReturn = this.CimCaseFailureItems;
					break;
				case Cir.Data.LLBLGen.EntityType.CirAttachmentEntity:
					toReturn = this.CirAttachment;
					break;
				case Cir.Data.LLBLGen.EntityType.CirCommentHistoryEntity:
					toReturn = this.CirCommentHistory;
					break;
				case Cir.Data.LLBLGen.EntityType.CirDataEntity:
					toReturn = this.CirData;
					break;
				case Cir.Data.LLBLGen.EntityType.CirinboxTimestampEntity:
					toReturn = this.CirinboxTimestamp;
					break;
				case Cir.Data.LLBLGen.EntityType.CirInvalidEntity:
					toReturn = this.CirInvalid;
					break;
				case Cir.Data.LLBLGen.EntityType.CirLogEntity:
					toReturn = this.CirLog;
					break;
				case Cir.Data.LLBLGen.EntityType.CirMailArchiveEntity:
					toReturn = this.CirMailArchive;
					break;
				case Cir.Data.LLBLGen.EntityType.CirMetadataEntity:
					toReturn = this.CirMetadata;
					break;
				case Cir.Data.LLBLGen.EntityType.CirMetadataLookupEntity:
					toReturn = this.CirMetadataLookup;
					break;
				case Cir.Data.LLBLGen.EntityType.CirSystemLogEntity:
					toReturn = this.CirSystemLog;
					break;
				case Cir.Data.LLBLGen.EntityType.CirSystemMonitorEntity:
					toReturn = this.CirSystemMonitor;
					break;
				case Cir.Data.LLBLGen.EntityType.CirUserEntity:
					toReturn = this.CirUser;
					break;
				case Cir.Data.LLBLGen.EntityType.CirViewEntity:
					toReturn = this.CirView;
					break;
				case Cir.Data.LLBLGen.EntityType.CirXmlEntity:
					toReturn = this.CirXml;
					break;
				case Cir.Data.LLBLGen.EntityType.ClimateEntity:
					toReturn = this.Climate;
					break;
				case Cir.Data.LLBLGen.EntityType.CoilConditionEntity:
					toReturn = this.CoilCondition;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentGroupEntity:
					toReturn = this.ComponentGroup;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity:
					toReturn = this.ComponentInspectionReport;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity:
					toReturn = this.ComponentInspectionReportBlade;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity:
					toReturn = this.ComponentInspectionReportBladeDamage;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity:
					toReturn = this.ComponentInspectionReportBladeRepairRecord;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity:
					toReturn = this.ComponentInspectionReportGearbox;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity:
					toReturn = this.ComponentInspectionReportGeneral;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity:
					toReturn = this.ComponentInspectionReportGenerator;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity:
					toReturn = this.ComponentInspectionReportMainBearing;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity:
					toReturn = this.ComponentInspectionReportSkiiP;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPfailedComponentEntity:
					toReturn = this.ComponentInspectionReportSkiiPfailedComponent;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPnewComponentEntity:
					toReturn = this.ComponentInspectionReportSkiiPnewComponent;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportStateEntity:
					toReturn = this.ComponentInspectionReportState;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity:
					toReturn = this.ComponentInspectionReportTransformer;
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity:
					toReturn = this.ComponentInspectionReportType;
					break;
				case Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity:
					toReturn = this.ConnectionBars;
					break;
				case Cir.Data.LLBLGen.EntityType.ControllerTypeEntity:
					toReturn = this.ControllerType;
					break;
				case Cir.Data.LLBLGen.EntityType.CountryIsoEntity:
					toReturn = this.CountryIso;
					break;
				case Cir.Data.LLBLGen.EntityType.CouplingEntity:
					toReturn = this.Coupling;
					break;
				case Cir.Data.LLBLGen.EntityType.DamageEntity:
					toReturn = this.Damage;
					break;
				case Cir.Data.LLBLGen.EntityType.DamageDecisionEntity:
					toReturn = this.DamageDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.DebrisGearboxEntity:
					toReturn = this.DebrisGearbox;
					break;
				case Cir.Data.LLBLGen.EntityType.DebrisOnMagnetEntity:
					toReturn = this.DebrisOnMagnet;
					break;
				case Cir.Data.LLBLGen.EntityType.EditHistoryEntity:
					toReturn = this.EditHistory;
					break;
				case Cir.Data.LLBLGen.EntityType.ElectricalPumpEntity:
					toReturn = this.ElectricalPump;
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeAreaEntity:
					toReturn = this.FaultCodeArea;
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeCauseEntity:
					toReturn = this.FaultCodeCause;
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeClassificationEntity:
					toReturn = this.FaultCodeClassification;
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeTypeEntity:
					toReturn = this.FaultCodeType;
					break;
				case Cir.Data.LLBLGen.EntityType.FilterBlockTypeEntity:
					toReturn = this.FilterBlockType;
					break;
				case Cir.Data.LLBLGen.EntityType.FirstNotificationEntity:
					toReturn = this.FirstNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity:
					toReturn = this.GearboxDefectCategorization;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity:
					toReturn = this.GearboxDefectCategorizationDetails;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity:
					toReturn = this.GearboxManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxPartTypeEntity:
					toReturn = this.GearboxPartType;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxRevisionEntity:
					toReturn = this.GearboxRevision;
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxTypeEntity:
					toReturn = this.GearboxType;
					break;
				case Cir.Data.LLBLGen.EntityType.GearDamageCategoryEntity:
					toReturn = this.GearDamageCategory;
					break;
				case Cir.Data.LLBLGen.EntityType.GearErrorEntity:
					toReturn = this.GearError;
					break;
				case Cir.Data.LLBLGen.EntityType.GearTypeEntity:
					toReturn = this.GearType;
					break;
				case Cir.Data.LLBLGen.EntityType.GenerateCiridEntity:
					toReturn = this.GenerateCirid;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorBearingDecisionEntity:
					toReturn = this.GeneratorBearingDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity:
					toReturn = this.GeneratorCover;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity:
					toReturn = this.GeneratorDefectCategorization;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity:
					toReturn = this.GeneratorDriveEnd;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity:
					toReturn = this.GeneratorManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity:
					toReturn = this.GeneratorNonDriveEnd;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorPhaseOutletDecisionEntity:
					toReturn = this.GeneratorPhaseOutletDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity:
					toReturn = this.GeneratorRotor;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorDecisionEntity:
					toReturn = this.GeneratorRotorDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorLeadsDecisionEntity:
					toReturn = this.GeneratorRotorLeadsDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorStatorDecisionEntity:
					toReturn = this.GeneratorStatorDecision;
					break;
				case Cir.Data.LLBLGen.EntityType.HotItemEntity:
					toReturn = this.HotItem;
					break;
				case Cir.Data.LLBLGen.EntityType.HotItemAdministratorEntity:
					toReturn = this.HotItemAdministrator;
					break;
				case Cir.Data.LLBLGen.EntityType.HousingErrorEntity:
					toReturn = this.HousingError;
					break;
				case Cir.Data.LLBLGen.EntityType.InlineFilterEntity:
					toReturn = this.InlineFilter;
					break;
				case Cir.Data.LLBLGen.EntityType.InvalidNotificationEntity:
					toReturn = this.InvalidNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.LocationTypeEntity:
					toReturn = this.LocationType;
					break;
				case Cir.Data.LLBLGen.EntityType.MagnetPosEntity:
					toReturn = this.MagnetPos;
					break;
				case Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity:
					toReturn = this.MainBearingErrorLocation;
					break;
				case Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity:
					toReturn = this.MainBearingManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.MechanicalOilPumpEntity:
					toReturn = this.MechanicalOilPump;
					break;
				case Cir.Data.LLBLGen.EntityType.NoiseEntity:
					toReturn = this.Noise;
					break;
				case Cir.Data.LLBLGen.EntityType.OhmUnitEntity:
					toReturn = this.OhmUnit;
					break;
				case Cir.Data.LLBLGen.EntityType.OilLevelEntity:
					toReturn = this.OilLevel;
					break;
				case Cir.Data.LLBLGen.EntityType.OilTypeEntity:
					toReturn = this.OilType;
					break;
				case Cir.Data.LLBLGen.EntityType.OverallGearboxConditionEntity:
					toReturn = this.OverallGearboxCondition;
					break;
				case Cir.Data.LLBLGen.EntityType.PdfEntity:
					toReturn = this.Pdf;
					break;
				case Cir.Data.LLBLGen.EntityType.ReceiptNotificationEntity:
					toReturn = this.ReceiptNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.RejectNotificationEntity:
					toReturn = this.RejectNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.ReportTypeEntity:
					toReturn = this.ReportType;
					break;
				case Cir.Data.LLBLGen.EntityType.SbuEntity:
					toReturn = this.Sbu;
					break;
				case Cir.Data.LLBLGen.EntityType.SbunotificationEntity:
					toReturn = this.Sbunotification;
					break;
				case Cir.Data.LLBLGen.EntityType.SburejectNotificationEntity:
					toReturn = this.SburejectNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.SearchProfileEntity:
					toReturn = this.SearchProfile;
					break;
				case Cir.Data.LLBLGen.EntityType.SearchProfileDetailEntity:
					toReturn = this.SearchProfileDetail;
					break;
				case Cir.Data.LLBLGen.EntityType.SecondNotificationEntity:
					toReturn = this.SecondNotification;
					break;
				case Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity:
					toReturn = this.ServiceReportNumberType;
					break;
				case Cir.Data.LLBLGen.EntityType.ShaftErrorEntity:
					toReturn = this.ShaftError;
					break;
				case Cir.Data.LLBLGen.EntityType.ShaftTypeEntity:
					toReturn = this.ShaftType;
					break;
				case Cir.Data.LLBLGen.EntityType.ShrinkElementEntity:
					toReturn = this.ShrinkElement;
					break;
				case Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity:
					toReturn = this.SkiipackFailureCause;
					break;
				case Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity:
					toReturn = this.SurgeArrestor;
					break;
				case Cir.Data.LLBLGen.EntityType.TemplateInfoEntity:
					toReturn = this.TemplateInfo;
					break;
				case Cir.Data.LLBLGen.EntityType.ThreeMwGearboxesEntity:
					toReturn = this.ThreeMwGearboxes;
					break;
				case Cir.Data.LLBLGen.EntityType.TowerHeightEntity:
					toReturn = this.TowerHeight;
					break;
				case Cir.Data.LLBLGen.EntityType.TowerTypeEntity:
					toReturn = this.TowerType;
					break;
				case Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity:
					toReturn = this.TransformerManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineEntity:
					toReturn = this.Turbine;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineDataEntity:
					toReturn = this.TurbineData;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineFrequencyEntity:
					toReturn = this.TurbineFrequency;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity:
					toReturn = this.TurbineManufacturer;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineMarkVersionEntity:
					toReturn = this.TurbineMarkVersion;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity:
					toReturn = this.TurbineMatrix;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineNominelPowerEntity:
					toReturn = this.TurbineNominelPower;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineOldEntity:
					toReturn = this.TurbineOld;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbinePlacementEntity:
					toReturn = this.TurbinePlacement;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbinePowerRegulationEntity:
					toReturn = this.TurbinePowerRegulation;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineRotorDiameterEntity:
					toReturn = this.TurbineRotorDiameter;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity:
					toReturn = this.TurbineRunStatus;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineSmallGeneratorEntity:
					toReturn = this.TurbineSmallGenerator;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineTemperatureVariantEntity:
					toReturn = this.TurbineTemperatureVariant;
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineVoltageEntity:
					toReturn = this.TurbineVoltage;
					break;
				case Cir.Data.LLBLGen.EntityType.VibrationsEntity:
					toReturn = this.Vibrations;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting ActionOnTransformerEntity instances in the database.</summary>
		public DataSource2<ActionOnTransformerEntity> ActionOnTransformer
		{
			get { return new DataSource2<ActionOnTransformerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ActionToBeTakenOnGeneratorEntity instances in the database.</summary>
		public DataSource2<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGenerator
		{
			get { return new DataSource2<ActionToBeTakenOnGeneratorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ArcDetectionEntity instances in the database.</summary>
		public DataSource2<ArcDetectionEntity> ArcDetection
		{
			get { return new DataSource2<ArcDetectionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BearingDamageCategoryEntity instances in the database.</summary>
		public DataSource2<BearingDamageCategoryEntity> BearingDamageCategory
		{
			get { return new DataSource2<BearingDamageCategoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BearingErrorEntity instances in the database.</summary>
		public DataSource2<BearingErrorEntity> BearingError
		{
			get { return new DataSource2<BearingErrorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BearingPosEntity instances in the database.</summary>
		public DataSource2<BearingPosEntity> BearingPos
		{
			get { return new DataSource2<BearingPosEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BearingTypeEntity instances in the database.</summary>
		public DataSource2<BearingTypeEntity> BearingType
		{
			get { return new DataSource2<BearingTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeColorEntity instances in the database.</summary>
		public DataSource2<BladeColorEntity> BladeColor
		{
			get { return new DataSource2<BladeColorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeDamagePlacementEntity instances in the database.</summary>
		public DataSource2<BladeDamagePlacementEntity> BladeDamagePlacement
		{
			get { return new DataSource2<BladeDamagePlacementEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeEdgeEntity instances in the database.</summary>
		public DataSource2<BladeEdgeEntity> BladeEdge
		{
			get { return new DataSource2<BladeEdgeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeInspectionDataEntity instances in the database.</summary>
		public DataSource2<BladeInspectionDataEntity> BladeInspectionData
		{
			get { return new DataSource2<BladeInspectionDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeLengthEntity instances in the database.</summary>
		public DataSource2<BladeLengthEntity> BladeLength
		{
			get { return new DataSource2<BladeLengthEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BladeManufacturerEntity instances in the database.</summary>
		public DataSource2<BladeManufacturerEntity> BladeManufacturer
		{
			get { return new DataSource2<BladeManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BooleanAnswerEntity instances in the database.</summary>
		public DataSource2<BooleanAnswerEntity> BooleanAnswer
		{
			get { return new DataSource2<BooleanAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BracketsEntity instances in the database.</summary>
		public DataSource2<BracketsEntity> Brackets
		{
			get { return new DataSource2<BracketsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CableConditionEntity instances in the database.</summary>
		public DataSource2<CableConditionEntity> CableCondition
		{
			get { return new DataSource2<CableConditionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CimCaseFailureItemsEntity instances in the database.</summary>
		public DataSource2<CimCaseFailureItemsEntity> CimCaseFailureItems
		{
			get { return new DataSource2<CimCaseFailureItemsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirAttachmentEntity instances in the database.</summary>
		public DataSource2<CirAttachmentEntity> CirAttachment
		{
			get { return new DataSource2<CirAttachmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirCommentHistoryEntity instances in the database.</summary>
		public DataSource2<CirCommentHistoryEntity> CirCommentHistory
		{
			get { return new DataSource2<CirCommentHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirDataEntity instances in the database.</summary>
		public DataSource2<CirDataEntity> CirData
		{
			get { return new DataSource2<CirDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirinboxTimestampEntity instances in the database.</summary>
		public DataSource2<CirinboxTimestampEntity> CirinboxTimestamp
		{
			get { return new DataSource2<CirinboxTimestampEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirInvalidEntity instances in the database.</summary>
		public DataSource2<CirInvalidEntity> CirInvalid
		{
			get { return new DataSource2<CirInvalidEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirLogEntity instances in the database.</summary>
		public DataSource2<CirLogEntity> CirLog
		{
			get { return new DataSource2<CirLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirMailArchiveEntity instances in the database.</summary>
		public DataSource2<CirMailArchiveEntity> CirMailArchive
		{
			get { return new DataSource2<CirMailArchiveEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirMetadataEntity instances in the database.</summary>
		public DataSource2<CirMetadataEntity> CirMetadata
		{
			get { return new DataSource2<CirMetadataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirMetadataLookupEntity instances in the database.</summary>
		public DataSource2<CirMetadataLookupEntity> CirMetadataLookup
		{
			get { return new DataSource2<CirMetadataLookupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirSystemLogEntity instances in the database.</summary>
		public DataSource2<CirSystemLogEntity> CirSystemLog
		{
			get { return new DataSource2<CirSystemLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirSystemMonitorEntity instances in the database.</summary>
		public DataSource2<CirSystemMonitorEntity> CirSystemMonitor
		{
			get { return new DataSource2<CirSystemMonitorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirUserEntity instances in the database.</summary>
		public DataSource2<CirUserEntity> CirUser
		{
			get { return new DataSource2<CirUserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirViewEntity instances in the database.</summary>
		public DataSource2<CirViewEntity> CirView
		{
			get { return new DataSource2<CirViewEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CirXmlEntity instances in the database.</summary>
		public DataSource2<CirXmlEntity> CirXml
		{
			get { return new DataSource2<CirXmlEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClimateEntity instances in the database.</summary>
		public DataSource2<ClimateEntity> Climate
		{
			get { return new DataSource2<ClimateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CoilConditionEntity instances in the database.</summary>
		public DataSource2<CoilConditionEntity> CoilCondition
		{
			get { return new DataSource2<CoilConditionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentGroupEntity instances in the database.</summary>
		public DataSource2<ComponentGroupEntity> ComponentGroup
		{
			get { return new DataSource2<ComponentGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportEntity> ComponentInspectionReport
		{
			get { return new DataSource2<ComponentInspectionReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportBladeEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportBladeEntity> ComponentInspectionReportBlade
		{
			get { return new DataSource2<ComponentInspectionReportBladeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportBladeDamageEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportBladeDamageEntity> ComponentInspectionReportBladeDamage
		{
			get { return new DataSource2<ComponentInspectionReportBladeDamageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportBladeRepairRecordEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportBladeRepairRecordEntity> ComponentInspectionReportBladeRepairRecord
		{
			get { return new DataSource2<ComponentInspectionReportBladeRepairRecordEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportGearboxEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportGearboxEntity> ComponentInspectionReportGearbox
		{
			get { return new DataSource2<ComponentInspectionReportGearboxEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportGeneralEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportGeneralEntity> ComponentInspectionReportGeneral
		{
			get { return new DataSource2<ComponentInspectionReportGeneralEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportGeneratorEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator
		{
			get { return new DataSource2<ComponentInspectionReportGeneratorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportMainBearingEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportMainBearingEntity> ComponentInspectionReportMainBearing
		{
			get { return new DataSource2<ComponentInspectionReportMainBearingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportSkiiPEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportSkiiPEntity> ComponentInspectionReportSkiiP
		{
			get { return new DataSource2<ComponentInspectionReportSkiiPEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportSkiiPfailedComponentEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportSkiiPfailedComponentEntity> ComponentInspectionReportSkiiPfailedComponent
		{
			get { return new DataSource2<ComponentInspectionReportSkiiPfailedComponentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportSkiiPnewComponentEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportSkiiPnewComponentEntity> ComponentInspectionReportSkiiPnewComponent
		{
			get { return new DataSource2<ComponentInspectionReportSkiiPnewComponentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportStateEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportStateEntity> ComponentInspectionReportState
		{
			get { return new DataSource2<ComponentInspectionReportStateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportTransformerEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportTransformerEntity> ComponentInspectionReportTransformer
		{
			get { return new DataSource2<ComponentInspectionReportTransformerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ComponentInspectionReportTypeEntity instances in the database.</summary>
		public DataSource2<ComponentInspectionReportTypeEntity> ComponentInspectionReportType
		{
			get { return new DataSource2<ComponentInspectionReportTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ConnectionBarsEntity instances in the database.</summary>
		public DataSource2<ConnectionBarsEntity> ConnectionBars
		{
			get { return new DataSource2<ConnectionBarsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ControllerTypeEntity instances in the database.</summary>
		public DataSource2<ControllerTypeEntity> ControllerType
		{
			get { return new DataSource2<ControllerTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CountryIsoEntity instances in the database.</summary>
		public DataSource2<CountryIsoEntity> CountryIso
		{
			get { return new DataSource2<CountryIsoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CouplingEntity instances in the database.</summary>
		public DataSource2<CouplingEntity> Coupling
		{
			get { return new DataSource2<CouplingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DamageEntity instances in the database.</summary>
		public DataSource2<DamageEntity> Damage
		{
			get { return new DataSource2<DamageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DamageDecisionEntity instances in the database.</summary>
		public DataSource2<DamageDecisionEntity> DamageDecision
		{
			get { return new DataSource2<DamageDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DebrisGearboxEntity instances in the database.</summary>
		public DataSource2<DebrisGearboxEntity> DebrisGearbox
		{
			get { return new DataSource2<DebrisGearboxEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DebrisOnMagnetEntity instances in the database.</summary>
		public DataSource2<DebrisOnMagnetEntity> DebrisOnMagnet
		{
			get { return new DataSource2<DebrisOnMagnetEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EditHistoryEntity instances in the database.</summary>
		public DataSource2<EditHistoryEntity> EditHistory
		{
			get { return new DataSource2<EditHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ElectricalPumpEntity instances in the database.</summary>
		public DataSource2<ElectricalPumpEntity> ElectricalPump
		{
			get { return new DataSource2<ElectricalPumpEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FaultCodeAreaEntity instances in the database.</summary>
		public DataSource2<FaultCodeAreaEntity> FaultCodeArea
		{
			get { return new DataSource2<FaultCodeAreaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FaultCodeCauseEntity instances in the database.</summary>
		public DataSource2<FaultCodeCauseEntity> FaultCodeCause
		{
			get { return new DataSource2<FaultCodeCauseEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FaultCodeClassificationEntity instances in the database.</summary>
		public DataSource2<FaultCodeClassificationEntity> FaultCodeClassification
		{
			get { return new DataSource2<FaultCodeClassificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FaultCodeTypeEntity instances in the database.</summary>
		public DataSource2<FaultCodeTypeEntity> FaultCodeType
		{
			get { return new DataSource2<FaultCodeTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FilterBlockTypeEntity instances in the database.</summary>
		public DataSource2<FilterBlockTypeEntity> FilterBlockType
		{
			get { return new DataSource2<FilterBlockTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FirstNotificationEntity instances in the database.</summary>
		public DataSource2<FirstNotificationEntity> FirstNotification
		{
			get { return new DataSource2<FirstNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxDefectCategorizationEntity instances in the database.</summary>
		public DataSource2<GearboxDefectCategorizationEntity> GearboxDefectCategorization
		{
			get { return new DataSource2<GearboxDefectCategorizationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxDefectCategorizationDetailsEntity instances in the database.</summary>
		public DataSource2<GearboxDefectCategorizationDetailsEntity> GearboxDefectCategorizationDetails
		{
			get { return new DataSource2<GearboxDefectCategorizationDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxManufacturerEntity instances in the database.</summary>
		public DataSource2<GearboxManufacturerEntity> GearboxManufacturer
		{
			get { return new DataSource2<GearboxManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxPartTypeEntity instances in the database.</summary>
		public DataSource2<GearboxPartTypeEntity> GearboxPartType
		{
			get { return new DataSource2<GearboxPartTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxRevisionEntity instances in the database.</summary>
		public DataSource2<GearboxRevisionEntity> GearboxRevision
		{
			get { return new DataSource2<GearboxRevisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearboxTypeEntity instances in the database.</summary>
		public DataSource2<GearboxTypeEntity> GearboxType
		{
			get { return new DataSource2<GearboxTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearDamageCategoryEntity instances in the database.</summary>
		public DataSource2<GearDamageCategoryEntity> GearDamageCategory
		{
			get { return new DataSource2<GearDamageCategoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearErrorEntity instances in the database.</summary>
		public DataSource2<GearErrorEntity> GearError
		{
			get { return new DataSource2<GearErrorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GearTypeEntity instances in the database.</summary>
		public DataSource2<GearTypeEntity> GearType
		{
			get { return new DataSource2<GearTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GenerateCiridEntity instances in the database.</summary>
		public DataSource2<GenerateCiridEntity> GenerateCirid
		{
			get { return new DataSource2<GenerateCiridEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorBearingDecisionEntity instances in the database.</summary>
		public DataSource2<GeneratorBearingDecisionEntity> GeneratorBearingDecision
		{
			get { return new DataSource2<GeneratorBearingDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorCoverEntity instances in the database.</summary>
		public DataSource2<GeneratorCoverEntity> GeneratorCover
		{
			get { return new DataSource2<GeneratorCoverEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorDefectCategorizationEntity instances in the database.</summary>
		public DataSource2<GeneratorDefectCategorizationEntity> GeneratorDefectCategorization
		{
			get { return new DataSource2<GeneratorDefectCategorizationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorDriveEndEntity instances in the database.</summary>
		public DataSource2<GeneratorDriveEndEntity> GeneratorDriveEnd
		{
			get { return new DataSource2<GeneratorDriveEndEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorManufacturerEntity instances in the database.</summary>
		public DataSource2<GeneratorManufacturerEntity> GeneratorManufacturer
		{
			get { return new DataSource2<GeneratorManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorNonDriveEndEntity instances in the database.</summary>
		public DataSource2<GeneratorNonDriveEndEntity> GeneratorNonDriveEnd
		{
			get { return new DataSource2<GeneratorNonDriveEndEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorPhaseOutletDecisionEntity instances in the database.</summary>
		public DataSource2<GeneratorPhaseOutletDecisionEntity> GeneratorPhaseOutletDecision
		{
			get { return new DataSource2<GeneratorPhaseOutletDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorRotorEntity instances in the database.</summary>
		public DataSource2<GeneratorRotorEntity> GeneratorRotor
		{
			get { return new DataSource2<GeneratorRotorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorRotorDecisionEntity instances in the database.</summary>
		public DataSource2<GeneratorRotorDecisionEntity> GeneratorRotorDecision
		{
			get { return new DataSource2<GeneratorRotorDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorRotorLeadsDecisionEntity instances in the database.</summary>
		public DataSource2<GeneratorRotorLeadsDecisionEntity> GeneratorRotorLeadsDecision
		{
			get { return new DataSource2<GeneratorRotorLeadsDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GeneratorStatorDecisionEntity instances in the database.</summary>
		public DataSource2<GeneratorStatorDecisionEntity> GeneratorStatorDecision
		{
			get { return new DataSource2<GeneratorStatorDecisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HotItemEntity instances in the database.</summary>
		public DataSource2<HotItemEntity> HotItem
		{
			get { return new DataSource2<HotItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HotItemAdministratorEntity instances in the database.</summary>
		public DataSource2<HotItemAdministratorEntity> HotItemAdministrator
		{
			get { return new DataSource2<HotItemAdministratorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HousingErrorEntity instances in the database.</summary>
		public DataSource2<HousingErrorEntity> HousingError
		{
			get { return new DataSource2<HousingErrorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InlineFilterEntity instances in the database.</summary>
		public DataSource2<InlineFilterEntity> InlineFilter
		{
			get { return new DataSource2<InlineFilterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InvalidNotificationEntity instances in the database.</summary>
		public DataSource2<InvalidNotificationEntity> InvalidNotification
		{
			get { return new DataSource2<InvalidNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LocationTypeEntity instances in the database.</summary>
		public DataSource2<LocationTypeEntity> LocationType
		{
			get { return new DataSource2<LocationTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MagnetPosEntity instances in the database.</summary>
		public DataSource2<MagnetPosEntity> MagnetPos
		{
			get { return new DataSource2<MagnetPosEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MainBearingErrorLocationEntity instances in the database.</summary>
		public DataSource2<MainBearingErrorLocationEntity> MainBearingErrorLocation
		{
			get { return new DataSource2<MainBearingErrorLocationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MainBearingManufacturerEntity instances in the database.</summary>
		public DataSource2<MainBearingManufacturerEntity> MainBearingManufacturer
		{
			get { return new DataSource2<MainBearingManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MechanicalOilPumpEntity instances in the database.</summary>
		public DataSource2<MechanicalOilPumpEntity> MechanicalOilPump
		{
			get { return new DataSource2<MechanicalOilPumpEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoiseEntity instances in the database.</summary>
		public DataSource2<NoiseEntity> Noise
		{
			get { return new DataSource2<NoiseEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OhmUnitEntity instances in the database.</summary>
		public DataSource2<OhmUnitEntity> OhmUnit
		{
			get { return new DataSource2<OhmUnitEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OilLevelEntity instances in the database.</summary>
		public DataSource2<OilLevelEntity> OilLevel
		{
			get { return new DataSource2<OilLevelEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OilTypeEntity instances in the database.</summary>
		public DataSource2<OilTypeEntity> OilType
		{
			get { return new DataSource2<OilTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OverallGearboxConditionEntity instances in the database.</summary>
		public DataSource2<OverallGearboxConditionEntity> OverallGearboxCondition
		{
			get { return new DataSource2<OverallGearboxConditionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PdfEntity instances in the database.</summary>
		public DataSource2<PdfEntity> Pdf
		{
			get { return new DataSource2<PdfEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReceiptNotificationEntity instances in the database.</summary>
		public DataSource2<ReceiptNotificationEntity> ReceiptNotification
		{
			get { return new DataSource2<ReceiptNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RejectNotificationEntity instances in the database.</summary>
		public DataSource2<RejectNotificationEntity> RejectNotification
		{
			get { return new DataSource2<RejectNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReportTypeEntity instances in the database.</summary>
		public DataSource2<ReportTypeEntity> ReportType
		{
			get { return new DataSource2<ReportTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SbuEntity instances in the database.</summary>
		public DataSource2<SbuEntity> Sbu
		{
			get { return new DataSource2<SbuEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SbunotificationEntity instances in the database.</summary>
		public DataSource2<SbunotificationEntity> Sbunotification
		{
			get { return new DataSource2<SbunotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SburejectNotificationEntity instances in the database.</summary>
		public DataSource2<SburejectNotificationEntity> SburejectNotification
		{
			get { return new DataSource2<SburejectNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SearchProfileEntity instances in the database.</summary>
		public DataSource2<SearchProfileEntity> SearchProfile
		{
			get { return new DataSource2<SearchProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SearchProfileDetailEntity instances in the database.</summary>
		public DataSource2<SearchProfileDetailEntity> SearchProfileDetail
		{
			get { return new DataSource2<SearchProfileDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SecondNotificationEntity instances in the database.</summary>
		public DataSource2<SecondNotificationEntity> SecondNotification
		{
			get { return new DataSource2<SecondNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ServiceReportNumberTypeEntity instances in the database.</summary>
		public DataSource2<ServiceReportNumberTypeEntity> ServiceReportNumberType
		{
			get { return new DataSource2<ServiceReportNumberTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShaftErrorEntity instances in the database.</summary>
		public DataSource2<ShaftErrorEntity> ShaftError
		{
			get { return new DataSource2<ShaftErrorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShaftTypeEntity instances in the database.</summary>
		public DataSource2<ShaftTypeEntity> ShaftType
		{
			get { return new DataSource2<ShaftTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShrinkElementEntity instances in the database.</summary>
		public DataSource2<ShrinkElementEntity> ShrinkElement
		{
			get { return new DataSource2<ShrinkElementEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SkiipackFailureCauseEntity instances in the database.</summary>
		public DataSource2<SkiipackFailureCauseEntity> SkiipackFailureCause
		{
			get { return new DataSource2<SkiipackFailureCauseEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SurgeArrestorEntity instances in the database.</summary>
		public DataSource2<SurgeArrestorEntity> SurgeArrestor
		{
			get { return new DataSource2<SurgeArrestorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TemplateInfoEntity instances in the database.</summary>
		public DataSource2<TemplateInfoEntity> TemplateInfo
		{
			get { return new DataSource2<TemplateInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ThreeMwGearboxesEntity instances in the database.</summary>
		public DataSource2<ThreeMwGearboxesEntity> ThreeMwGearboxes
		{
			get { return new DataSource2<ThreeMwGearboxesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TowerHeightEntity instances in the database.</summary>
		public DataSource2<TowerHeightEntity> TowerHeight
		{
			get { return new DataSource2<TowerHeightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TowerTypeEntity instances in the database.</summary>
		public DataSource2<TowerTypeEntity> TowerType
		{
			get { return new DataSource2<TowerTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TransformerManufacturerEntity instances in the database.</summary>
		public DataSource2<TransformerManufacturerEntity> TransformerManufacturer
		{
			get { return new DataSource2<TransformerManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineEntity instances in the database.</summary>
		public DataSource2<TurbineEntity> Turbine
		{
			get { return new DataSource2<TurbineEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineDataEntity instances in the database.</summary>
		public DataSource2<TurbineDataEntity> TurbineData
		{
			get { return new DataSource2<TurbineDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineFrequencyEntity instances in the database.</summary>
		public DataSource2<TurbineFrequencyEntity> TurbineFrequency
		{
			get { return new DataSource2<TurbineFrequencyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineManufacturerEntity instances in the database.</summary>
		public DataSource2<TurbineManufacturerEntity> TurbineManufacturer
		{
			get { return new DataSource2<TurbineManufacturerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineMarkVersionEntity instances in the database.</summary>
		public DataSource2<TurbineMarkVersionEntity> TurbineMarkVersion
		{
			get { return new DataSource2<TurbineMarkVersionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineMatrixEntity instances in the database.</summary>
		public DataSource2<TurbineMatrixEntity> TurbineMatrix
		{
			get { return new DataSource2<TurbineMatrixEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineNominelPowerEntity instances in the database.</summary>
		public DataSource2<TurbineNominelPowerEntity> TurbineNominelPower
		{
			get { return new DataSource2<TurbineNominelPowerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineOldEntity instances in the database.</summary>
		public DataSource2<TurbineOldEntity> TurbineOld
		{
			get { return new DataSource2<TurbineOldEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbinePlacementEntity instances in the database.</summary>
		public DataSource2<TurbinePlacementEntity> TurbinePlacement
		{
			get { return new DataSource2<TurbinePlacementEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbinePowerRegulationEntity instances in the database.</summary>
		public DataSource2<TurbinePowerRegulationEntity> TurbinePowerRegulation
		{
			get { return new DataSource2<TurbinePowerRegulationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineRotorDiameterEntity instances in the database.</summary>
		public DataSource2<TurbineRotorDiameterEntity> TurbineRotorDiameter
		{
			get { return new DataSource2<TurbineRotorDiameterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineRunStatusEntity instances in the database.</summary>
		public DataSource2<TurbineRunStatusEntity> TurbineRunStatus
		{
			get { return new DataSource2<TurbineRunStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineSmallGeneratorEntity instances in the database.</summary>
		public DataSource2<TurbineSmallGeneratorEntity> TurbineSmallGenerator
		{
			get { return new DataSource2<TurbineSmallGeneratorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineTemperatureVariantEntity instances in the database.</summary>
		public DataSource2<TurbineTemperatureVariantEntity> TurbineTemperatureVariant
		{
			get { return new DataSource2<TurbineTemperatureVariantEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TurbineVoltageEntity instances in the database.</summary>
		public DataSource2<TurbineVoltageEntity> TurbineVoltage
		{
			get { return new DataSource2<TurbineVoltageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VibrationsEntity instances in the database.</summary>
		public DataSource2<VibrationsEntity> Vibrations
		{
			get { return new DataSource2<VibrationsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}