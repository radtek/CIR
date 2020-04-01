///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.DatabaseSpecific
{
	/// <summary>
	/// Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal sealed class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			base.InitClass((154 + 0));
			InitActionOnTransformerEntityMappings();
			InitActionToBeTakenOnGeneratorEntityMappings();
			InitArcDetectionEntityMappings();
			InitBearingDamageCategoryEntityMappings();
			InitBearingErrorEntityMappings();
			InitBearingErrorVendorEntityMappings();
			InitBearingPosEntityMappings();
			InitBearingTypeEntityMappings();
			InitBirDataEntityMappings();
			InitBirReportPlaceholdersEntityMappings();
			InitBirWordDocumentEntityMappings();
			InitBladeColorEntityMappings();
			InitBladeDamagePlacementEntityMappings();
			InitBladeEdgeEntityMappings();
			InitBladeInspectionDataEntityMappings();
			InitBladeLengthEntityMappings();
			InitBladeManufacturerEntityMappings();
			InitBooleanAnswerEntityMappings();
			InitBracketsEntityMappings();
			InitCableConditionEntityMappings();
			InitCimCaseFailureItemsEntityMappings();
			InitCirAttachmentEntityMappings();
			InitCirCommentHistoryEntityMappings();
			InitCirDataEntityMappings();
			InitCirinboxTimestampEntityMappings();
			InitCirInvalidEntityMappings();
			InitCirLogEntityMappings();
			InitCirMailArchiveEntityMappings();
			InitCirMetadataEntityMappings();
			InitCirMetadataLookupEntityMappings();
			InitCirStandardTextsEntityMappings();
			InitCirSystemLogEntityMappings();
			InitCirSystemMonitorEntityMappings();
			InitCirUserEntityMappings();
			InitCirViewEntityMappings();
			InitCirXmlEntityMappings();
			InitClimateEntityMappings();
			InitCoilConditionEntityMappings();
			InitComponentGroupEntityMappings();
			InitComponentInspectionReportEntityMappings();
			InitComponentInspectionReportBladeEntityMappings();
			InitComponentInspectionReportBladeDamageEntityMappings();
			InitComponentInspectionReportBladeRepairRecordEntityMappings();
			InitComponentInspectionReportGearboxEntityMappings();
			InitComponentInspectionReportGeneralEntityMappings();
			InitComponentInspectionReportGeneratorEntityMappings();
			InitComponentInspectionReportMainBearingEntityMappings();
			InitComponentInspectionReportSkiiPEntityMappings();
			InitComponentInspectionReportSkiiPfailedComponentEntityMappings();
			InitComponentInspectionReportSkiiPnewComponentEntityMappings();
			InitComponentInspectionReportStateEntityMappings();
			InitComponentInspectionReportTransformerEntityMappings();
			InitComponentInspectionReportTypeEntityMappings();
			InitComponentUpTowerSolutionEntityMappings();
			InitConnectionBarsEntityMappings();
			InitControllerTypeEntityMappings();
			InitCountryIsoEntityMappings();
			InitCouplingEntityMappings();
			InitDamageEntityMappings();
			InitDamageDecisionEntityMappings();
			InitDebrisGearboxEntityMappings();
			InitDebrisOnMagnetEntityMappings();
			InitDynamicTableInputEntityMappings();
			InitEditHistoryEntityMappings();
			InitElectricalPumpEntityMappings();
			InitFaultCodeAreaEntityMappings();
			InitFaultCodeCauseEntityMappings();
			InitFaultCodeClassificationEntityMappings();
			InitFaultCodeTypeEntityMappings();
			InitFilterBlockTypeEntityMappings();
			InitFirstNotificationEntityMappings();
			InitGearboxDefectCategorizationEntityMappings();
			InitGearboxDefectCategorizationDetailsEntityMappings();
			InitGearboxManufacturerEntityMappings();
			InitGearboxPartTypeEntityMappings();
			InitGearboxRevisionEntityMappings();
			InitGearboxTypeEntityMappings();
			InitGearDamageCategoryEntityMappings();
			InitGearErrorEntityMappings();
			InitGearErrorVendorEntityMappings();
			InitGearTypeEntityMappings();
			InitGenerateCiridEntityMappings();
			InitGeneratorBearingDecisionEntityMappings();
			InitGeneratorComponentDamageEntityMappings();
			InitGeneratorCoverEntityMappings();
			InitGeneratorDefectCategorizationEntityMappings();
			InitGeneratorDefectCategorization2EntityMappings();
			InitGeneratorDefectCategorization2DetailsEntityMappings();
			InitGeneratorDriveEndEntityMappings();
			InitGeneratorManufacturerEntityMappings();
			InitGeneratorMiscDecisionEntityMappings();
			InitGeneratorNonDriveEndEntityMappings();
			InitGeneratorPhaseOutletDecisionEntityMappings();
			InitGeneratorRotorEntityMappings();
			InitGeneratorRotorDecisionEntityMappings();
			InitGeneratorRotorLeadsDecisionEntityMappings();
			InitGeneratorStatorDecisionEntityMappings();
			InitHotItemEntityMappings();
			InitHotItemAdministratorEntityMappings();
			InitHousingErrorEntityMappings();
			InitHousingErrorVendorEntityMappings();
			InitInlineFilterEntityMappings();
			InitInvalidNotificationEntityMappings();
			InitLocationTypeEntityMappings();
			InitMagnetPosEntityMappings();
			InitMainBearingErrorLocationEntityMappings();
			InitMainBearingManufacturerEntityMappings();
			InitMapBirCirEntityMappings();
			InitMechanicalOilPumpEntityMappings();
			InitNoiseEntityMappings();
			InitOhmUnitEntityMappings();
			InitOilLevelEntityMappings();
			InitOilTypeEntityMappings();
			InitOverallGearboxConditionEntityMappings();
			InitPartNameEntityMappings();
			InitPdfEntityMappings();
			InitReceiptNotificationEntityMappings();
			InitRejectNotificationEntityMappings();
			InitReportTypeEntityMappings();
			InitSbuEntityMappings();
			InitSbunotificationEntityMappings();
			InitSburejectNotificationEntityMappings();
			InitSearchProfileEntityMappings();
			InitSearchProfileDetailEntityMappings();
			InitSecondNotificationEntityMappings();
			InitServiceReportNumberTypeEntityMappings();
			InitShaftErrorEntityMappings();
			InitShaftErrorVendorEntityMappings();
			InitShaftTypeEntityMappings();
			InitShrinkElementEntityMappings();
			InitSkiipackFailureCauseEntityMappings();
			InitSurgeArrestorEntityMappings();
			InitTemplateDynamicTableDefEntityMappings();
			InitTemplateInfoEntityMappings();
			InitThreeMwGearboxesEntityMappings();
			InitTowerHeightEntityMappings();
			InitTowerTypeEntityMappings();
			InitTransformerManufacturerEntityMappings();
			InitTurbineEntityMappings();
			InitTurbineDataEntityMappings();
			InitTurbineFrequencyEntityMappings();
			InitTurbineManufacturerEntityMappings();
			InitTurbineMarkVersionEntityMappings();
			InitTurbineMatrixEntityMappings();
			InitTurbineNominelPowerEntityMappings();
			InitTurbineOldEntityMappings();
			InitTurbinePlacementEntityMappings();
			InitTurbinePowerRegulationEntityMappings();
			InitTurbineRotorDiameterEntityMappings();
			InitTurbineRunStatusEntityMappings();
			InitTurbineSmallGeneratorEntityMappings();
			InitTurbineTemperatureVariantEntityMappings();
			InitTurbineVoltageEntityMappings();
			InitVibrationsEntityMappings();

		}


		/// <summary>Inits ActionOnTransformerEntity's mappings</summary>
		private void InitActionOnTransformerEntityMappings()
		{
			base.AddElementMapping( "ActionOnTransformerEntity", "CIM_ComponentInspectionReports", @"dbo", "ActionOnTransformer", 5 );
			base.AddElementFieldMapping( "ActionOnTransformerEntity", "ActionOnTransformerId", "ActionOnTransformerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ActionOnTransformerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ActionOnTransformerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ActionOnTransformerEntity", "ParentActionOnTransformerId", "ParentActionOnTransformerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ActionOnTransformerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ActionToBeTakenOnGeneratorEntity's mappings</summary>
		private void InitActionToBeTakenOnGeneratorEntityMappings()
		{
			base.AddElementMapping( "ActionToBeTakenOnGeneratorEntity", "CIM_ComponentInspectionReports", @"dbo", "ActionToBeTakenOnGenerator", 5 );
			base.AddElementFieldMapping( "ActionToBeTakenOnGeneratorEntity", "ActionToBeTakenOnGeneratorId", "ActionToBeTakenOnGeneratorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ActionToBeTakenOnGeneratorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ActionToBeTakenOnGeneratorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ActionToBeTakenOnGeneratorEntity", "ParentActionToBeTakenOnGeneratorId", "ParentActionToBeTakenOnGeneratorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ActionToBeTakenOnGeneratorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ArcDetectionEntity's mappings</summary>
		private void InitArcDetectionEntityMappings()
		{
			base.AddElementMapping( "ArcDetectionEntity", "CIM_ComponentInspectionReports", @"dbo", "ArcDetection", 5 );
			base.AddElementFieldMapping( "ArcDetectionEntity", "ArcDetectionId", "ArcDetectionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ArcDetectionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ArcDetectionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ArcDetectionEntity", "ParentArcDetectionId", "ParentArcDetectionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ArcDetectionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BearingDamageCategoryEntity's mappings</summary>
		private void InitBearingDamageCategoryEntityMappings()
		{
			base.AddElementMapping( "BearingDamageCategoryEntity", "CIM_ComponentInspectionReports", @"dbo", "BearingDamageCategory", 3 );
			base.AddElementFieldMapping( "BearingDamageCategoryEntity", "BearingDamageCategoryId", "BearingDamageCategoryId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "BearingDamageCategoryEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BearingDamageCategoryEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits BearingErrorEntity's mappings</summary>
		private void InitBearingErrorEntityMappings()
		{
			base.AddElementMapping( "BearingErrorEntity", "CIM_ComponentInspectionReports", @"dbo", "BearingError", 5 );
			base.AddElementFieldMapping( "BearingErrorEntity", "BearingErrorId", "BearingErrorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BearingErrorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BearingErrorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BearingErrorEntity", "ParentBearingErrorId", "ParentBearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BearingErrorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BearingErrorVendorEntity's mappings</summary>
		private void InitBearingErrorVendorEntityMappings()
		{
			base.AddElementMapping( "BearingErrorVendorEntity", "CIM_ComponentInspectionReports", @"dbo", "BearingErrorVendor", 3 );
			base.AddElementFieldMapping( "BearingErrorVendorEntity", "BearingErrorVendorId", "BearingErrorVendorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "BearingErrorVendorEntity", "Name", "Name", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BearingErrorVendorEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits BearingPosEntity's mappings</summary>
		private void InitBearingPosEntityMappings()
		{
			base.AddElementMapping( "BearingPosEntity", "CIM_ComponentInspectionReports", @"dbo", "BearingPos", 5 );
			base.AddElementFieldMapping( "BearingPosEntity", "BearingPosId", "BearingPosId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BearingPosEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BearingPosEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BearingPosEntity", "ParentBearingPosId", "ParentBearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BearingPosEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BearingTypeEntity's mappings</summary>
		private void InitBearingTypeEntityMappings()
		{
			base.AddElementMapping( "BearingTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "BearingType", 5 );
			base.AddElementFieldMapping( "BearingTypeEntity", "BearingTypeId", "BearingTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BearingTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BearingTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BearingTypeEntity", "ParentBearingTypeId", "ParentBearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BearingTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
            base.AddElementFieldMapping("BearingTypeEntity", "Brand", "Brand", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5);
        }
		/// <summary>Inits BirDataEntity's mappings</summary>
		private void InitBirDataEntityMappings()
		{
			base.AddElementMapping( "BirDataEntity", "CIM_ComponentInspectionReports", @"dbo", "BirData", 13 );
			base.AddElementFieldMapping( "BirDataEntity", "BirDataId", "BirDataID", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BirDataEntity", "BirCode", "BirCode", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BirDataEntity", "RevisionNumber", "RevisionNumber", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "BirDataEntity", "RepairingSolutions", "RepairingSolutions", false, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "BirDataEntity", "RawMaterials", "RawMaterials", false, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "BirDataEntity", "ConclusionsAndRecommendations", "ConclusionsAndRecommendations", false, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "BirDataEntity", "CirIds", "CirIDs", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "BirDataEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "BirDataEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "BirDataEntity", "Modified", "Modified", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 9 );
			base.AddElementFieldMapping( "BirDataEntity", "ModifiedBy", "ModifiedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "BirDataEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 11 );
			base.AddElementFieldMapping( "BirDataEntity", "BladeSerialNos", "BladeSerialNos", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, "", null, typeof(System.String), 12 );
		}
		/// <summary>Inits BirReportPlaceholdersEntity's mappings</summary>
		private void InitBirReportPlaceholdersEntityMappings()
		{
			base.AddElementMapping( "BirReportPlaceholdersEntity", "CIM_ComponentInspectionReports", @"dbo", "BirReportPlaceholders", 4 );
			base.AddElementFieldMapping( "BirReportPlaceholdersEntity", "BirReportPlaceholderId", "BirReportPlaceholderId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BirReportPlaceholdersEntity", "FieldId", "FieldID", false, (int)SqlDbType.UniqueIdentifier, 0, 0, 0, false, "", null, typeof(System.Guid), 1 );
			base.AddElementFieldMapping( "BirReportPlaceholdersEntity", "Placeholder", "Placeholder", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "BirReportPlaceholdersEntity", "ComponentType", "ComponentType", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
		}
		/// <summary>Inits BirWordDocumentEntity's mappings</summary>
		private void InitBirWordDocumentEntityMappings()
		{
			base.AddElementMapping( "BirWordDocumentEntity", "CIM_ComponentInspectionReports", @"dbo", "BirWordDocument", 4 );
			base.AddElementFieldMapping( "BirWordDocumentEntity", "BirWordDocumentId", "BirWordDocumentID", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BirWordDocumentEntity", "BirDataId", "BirDataID", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "BirWordDocumentEntity", "WordDocBytes", "WordDocBytes", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 2 );
			base.AddElementFieldMapping( "BirWordDocumentEntity", "BirCode", "BirCode", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 3 );
		}
		/// <summary>Inits BladeColorEntity's mappings</summary>
		private void InitBladeColorEntityMappings()
		{
			base.AddElementMapping( "BladeColorEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeColor", 5 );
			base.AddElementFieldMapping( "BladeColorEntity", "BladeColorId", "BladeColorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeColorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeColorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeColorEntity", "ParentBladeColorId", "ParentBladeColorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeColorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BladeDamagePlacementEntity's mappings</summary>
		private void InitBladeDamagePlacementEntityMappings()
		{
			base.AddElementMapping( "BladeDamagePlacementEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeDamagePlacement", 5 );
			base.AddElementFieldMapping( "BladeDamagePlacementEntity", "BladeDamagePlacementId", "BladeDamagePlacementId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeDamagePlacementEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeDamagePlacementEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeDamagePlacementEntity", "ParentBladeDamagePlacementId", "ParentBladeDamagePlacementId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeDamagePlacementEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BladeEdgeEntity's mappings</summary>
		private void InitBladeEdgeEntityMappings()
		{
			base.AddElementMapping( "BladeEdgeEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeEdge", 7 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "BladeEdgeId", "BladeEdgeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "ParentBladeEdgeId", "ParentBladeEdgeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "StartVersion", "StartVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "BladeEdgeEntity", "EndVersion", "EndVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits BladeInspectionDataEntity's mappings</summary>
		private void InitBladeInspectionDataEntityMappings()
		{
			base.AddElementMapping( "BladeInspectionDataEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeInspectionData", 5 );
			base.AddElementFieldMapping( "BladeInspectionDataEntity", "BladeInspectionDataId", "BladeInspectionDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeInspectionDataEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeInspectionDataEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeInspectionDataEntity", "ParentBladeInspectionDataId", "ParentBladeInspectionDataId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeInspectionDataEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BladeLengthEntity's mappings</summary>
		private void InitBladeLengthEntityMappings()
		{
			base.AddElementMapping( "BladeLengthEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeLength", 5 );
			base.AddElementFieldMapping( "BladeLengthEntity", "BladeLengthId", "BladeLengthId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeLengthEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeLengthEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeLengthEntity", "ParentBladeLengthId", "ParentBladeLengthId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeLengthEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BladeManufacturerEntity's mappings</summary>
		private void InitBladeManufacturerEntityMappings()
		{
			base.AddElementMapping( "BladeManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "BladeManufacturer", 8 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "BladeManufacturerId", "BladeManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "ParentBladeManufacturerId", "ParentBladeManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "Cc", "Cc", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "BladeManufacturerEntity", "EmailContactName", "EmailContactName", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits BooleanAnswerEntity's mappings</summary>
		private void InitBooleanAnswerEntityMappings()
		{
			base.AddElementMapping( "BooleanAnswerEntity", "CIM_ComponentInspectionReports", @"dbo", "BooleanAnswer", 5 );
			base.AddElementFieldMapping( "BooleanAnswerEntity", "BooleanAnswerId", "BooleanAnswerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BooleanAnswerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BooleanAnswerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BooleanAnswerEntity", "ParentBooleanAnswerId", "ParentBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BooleanAnswerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits BracketsEntity's mappings</summary>
		private void InitBracketsEntityMappings()
		{
			base.AddElementMapping( "BracketsEntity", "CIM_ComponentInspectionReports", @"dbo", "Brackets", 5 );
			base.AddElementFieldMapping( "BracketsEntity", "BracketsId", "BracketsId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "BracketsEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "BracketsEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "BracketsEntity", "ParentBracketsId", "ParentBracketsId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "BracketsEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits CableConditionEntity's mappings</summary>
		private void InitCableConditionEntityMappings()
		{
			base.AddElementMapping( "CableConditionEntity", "CIM_ComponentInspectionReports", @"dbo", "CableCondition", 5 );
			base.AddElementFieldMapping( "CableConditionEntity", "CableConditionId", "CableConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CableConditionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CableConditionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "CableConditionEntity", "ParentCableConditionId", "ParentCableConditionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "CableConditionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits CimCaseFailureItemsEntity's mappings</summary>
		private void InitCimCaseFailureItemsEntityMappings()
		{
			base.AddElementMapping( "CimCaseFailureItemsEntity", "CIM_ComponentInspectionReports", @"dbo", "CimCaseFailureItems", 2 );
			base.AddElementFieldMapping( "CimCaseFailureItemsEntity", "CaseNo", "CaseNo", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CimCaseFailureItemsEntity", "ItemNo", "ItemNo", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits CirAttachmentEntity's mappings</summary>
		private void InitCirAttachmentEntityMappings()
		{
			base.AddElementMapping( "CirAttachmentEntity", "CIM_ComponentInspectionReports", @"dbo", "CirAttachment", 6 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "CirAttachmentId", "CirAttachmentId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "CirId", "CirId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "Filename", "Filename", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "CirAttachmentEntity", "BinaryData", "BinaryData", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 5 );
		}
		/// <summary>Inits CirCommentHistoryEntity's mappings</summary>
		private void InitCirCommentHistoryEntityMappings()
		{
			base.AddElementMapping( "CirCommentHistoryEntity", "CIM_ComponentInspectionReports", @"dbo", "CirCommentHistory", 6 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "CirCommentHistoryId", "CirCommentHistoryId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "Comment", "Comment", false, (int)SqlDbType.NVarChar, 1024, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "Date", "Date", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "Initials", "Initials", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "CirCommentHistoryEntity", "Type", "Type", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 5 );
		}
		/// <summary>Inits CirDataEntity's mappings</summary>
		private void InitCirDataEntityMappings()
		{
			base.AddElementMapping( "CirDataEntity", "CIM_ComponentInspectionReports", @"dbo", "CirData", 12 );
			base.AddElementFieldMapping( "CirDataEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirDataEntity", "CirId", "CirId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirDataEntity", "Guid", "Guid", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirDataEntity", "State", "State", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 3 );
			base.AddElementFieldMapping( "CirDataEntity", "Progress", "Progress", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 4 );
			base.AddElementFieldMapping( "CirDataEntity", "Email", "Email", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "CirDataEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "CirDataEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "CirDataEntity", "Filename", "Filename", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "CirDataEntity", "Modified", "Modified", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 9 );
			base.AddElementFieldMapping( "CirDataEntity", "ModifiedBy", "ModifiedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "CirDataEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 11 );
		}
		/// <summary>Inits CirinboxTimestampEntity's mappings</summary>
		private void InitCirinboxTimestampEntityMappings()
		{
			base.AddElementMapping( "CirinboxTimestampEntity", "CIM_ComponentInspectionReports", @"dbo", "CIRInboxTimestamp", 3 );
			base.AddElementFieldMapping( "CirinboxTimestampEntity", "CirinboxTimestampId", "CIRInboxTimestampId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CirinboxTimestampEntity", "Timestamp", "Timestamp", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "CirinboxTimestampEntity", "MailSent", "MailSent", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits CirInvalidEntity's mappings</summary>
		private void InitCirInvalidEntityMappings()
		{
			base.AddElementMapping( "CirInvalidEntity", "CIM_ComponentInspectionReports", @"dbo", "CirInvalid", 6 );
			base.AddElementFieldMapping( "CirInvalidEntity", "CirInvalidId", "CirInvalidId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirInvalidEntity", "Filename", "Filename", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CirInvalidEntity", "Xml", "Xml", false, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirInvalidEntity", "Error", "Error", false, (int)SqlDbType.NVarChar, 1024, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CirInvalidEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "CirInvalidEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits CirLogEntity's mappings</summary>
		private void InitCirLogEntityMappings()
		{
			base.AddElementMapping( "CirLogEntity", "CIM_ComponentInspectionReports", @"dbo", "CirLog", 6 );
			base.AddElementFieldMapping( "CirLogEntity", "CirLogId", "CirLogId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirLogEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirLogEntity", "Timestamp", "Timestamp", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "CirLogEntity", "Text", "Text", false, (int)SqlDbType.NVarChar, 1024, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CirLogEntity", "Type", "Type", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 4 );
			base.AddElementFieldMapping( "CirLogEntity", "Initials", "Initials", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits CirMailArchiveEntity's mappings</summary>
		private void InitCirMailArchiveEntityMappings()
		{
			base.AddElementMapping( "CirMailArchiveEntity", "CIM_ComponentInspectionReports", @"dbo", "CirMailArchive", 6 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "CirMailArchiveId", "CirMailArchiveId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "Mail", "Mail", false, (int)SqlDbType.Text, 2147483647, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "Type", "Type", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 3 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "Date", "Date", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "CirMailArchiveEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits CirMetadataEntity's mappings</summary>
		private void InitCirMetadataEntityMappings()
		{
			base.AddElementMapping( "CirMetadataEntity", "CIM_ComponentInspectionReports", @"dbo", "CirMetadata", 4 );
			base.AddElementFieldMapping( "CirMetadataEntity", "CirMetadataId", "CirMetadataId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirMetadataEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirMetadataEntity", "Metadata", "Metadata", false, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 2 );
			base.AddElementFieldMapping( "CirMetadataEntity", "TurbineId", "TurbineId", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
		}
		/// <summary>Inits CirMetadataLookupEntity's mappings</summary>
		private void InitCirMetadataLookupEntityMappings()
		{
			base.AddElementMapping( "CirMetadataLookupEntity", "CIM_ComponentInspectionReports", @"dbo", "CirMetadataLookup", 5 );
			base.AddElementFieldMapping( "CirMetadataLookupEntity", "CirMetadataLookupId", "CirMetadataLookupId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirMetadataLookupEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirMetadataLookupEntity", "FieldId", "FieldId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "CirMetadataLookupEntity", "FieldValue", "FieldValue", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CirMetadataLookupEntity", "FieldIntegerValue", "FieldIntegerValue", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits CirStandardTextsEntity's mappings</summary>
		private void InitCirStandardTextsEntityMappings()
		{
			base.AddElementMapping( "CirStandardTextsEntity", "CIM_ComponentInspectionReports", @"dbo", "CirStandardTexts", 9 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Title", "Title", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Description", "Description", false, (int)SqlDbType.NVarChar, 4000, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "ComponentInspectionReportTypeId", "ComponentInspectionReportTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "CreatedBy", "CreatedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Modified", "Modified", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "ModifiedBy", "ModifiedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "CirStandardTextsEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 8 );
		}
		/// <summary>Inits CirSystemLogEntity's mappings</summary>
		private void InitCirSystemLogEntityMappings()
		{
			base.AddElementMapping( "CirSystemLogEntity", "CIM_ComponentInspectionReports", @"dbo", "CirSystemLog", 5 );
			base.AddElementFieldMapping( "CirSystemLogEntity", "CirSystemLogId", "CirSystemLogId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirSystemLogEntity", "Timestamp", "Timestamp", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "CirSystemLogEntity", "Type", "Type", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			base.AddElementFieldMapping( "CirSystemLogEntity", "Message", "Message", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "CirSystemLogEntity", "Details", "Details", false, (int)SqlDbType.NVarChar, 1024, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits CirSystemMonitorEntity's mappings</summary>
		private void InitCirSystemMonitorEntityMappings()
		{
			base.AddElementMapping( "CirSystemMonitorEntity", "CIM_ComponentInspectionReports", @"dbo", "CirSystemMonitor", 4 );
			base.AddElementFieldMapping( "CirSystemMonitorEntity", "CirSystemMonitorId", "CirSystemMonitorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirSystemMonitorEntity", "LastUpdate", "LastUpdate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "CirSystemMonitorEntity", "NotificationWarningSent", "NotificationWarningSent", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 2 );
			base.AddElementFieldMapping( "CirSystemMonitorEntity", "WatchDogWarningSent", "WatchDogWarningSent", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits CirUserEntity's mappings</summary>
		private void InitCirUserEntityMappings()
		{
			base.AddElementMapping( "CirUserEntity", "CIM_ComponentInspectionReports", @"dbo", "CirUser", 5 );
			base.AddElementFieldMapping( "CirUserEntity", "CirUserId", "CirUserId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirUserEntity", "Initials", "Initials", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CirUserEntity", "UserName", "UserName", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CirUserEntity", "PermissionLevel", "PermissionLevel", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			base.AddElementFieldMapping( "CirUserEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
		}
		/// <summary>Inits CirViewEntity's mappings</summary>
		private void InitCirViewEntityMappings()
		{
			base.AddElementMapping( "CirViewEntity", "CIM_ComponentInspectionReports", @"dbo", "CirView", 6 );
			base.AddElementFieldMapping( "CirViewEntity", "CirViewId", "CirViewId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "CirViewEntity", "ViewData", "ViewData", false, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CirViewEntity", "Type", "Type", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			base.AddElementFieldMapping( "CirViewEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "CirViewEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "CirViewEntity", "InspectionApplicable", "InspectionApplicable", true, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 5 );
		}
		/// <summary>Inits CirXmlEntity's mappings</summary>
		private void InitCirXmlEntityMappings()
		{
			base.AddElementMapping( "CirXmlEntity", "CIM_ComponentInspectionReports", @"dbo", "CirXml", 3 );
			base.AddElementFieldMapping( "CirXmlEntity", "CirXmlId", "CirXmlId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CirXmlEntity", "CirDataId", "CirDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "CirXmlEntity", "Xml", "Xml", false, (int)SqlDbType.NText, 1073741823, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits ClimateEntity's mappings</summary>
		private void InitClimateEntityMappings()
		{
			base.AddElementMapping( "ClimateEntity", "CIM_ComponentInspectionReports", @"dbo", "Climate", 5 );
			base.AddElementFieldMapping( "ClimateEntity", "ClimateId", "ClimateId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ClimateEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ClimateEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ClimateEntity", "ParentClimateId", "ParentClimateId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ClimateEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits CoilConditionEntity's mappings</summary>
		private void InitCoilConditionEntityMappings()
		{
			base.AddElementMapping( "CoilConditionEntity", "CIM_ComponentInspectionReports", @"dbo", "CoilCondition", 5 );
			base.AddElementFieldMapping( "CoilConditionEntity", "CoilConditionId", "CoilConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CoilConditionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CoilConditionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "CoilConditionEntity", "ParentCoilConditionId", "ParentCoilConditionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "CoilConditionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ComponentGroupEntity's mappings</summary>
		private void InitComponentGroupEntityMappings()
		{
			base.AddElementMapping( "ComponentGroupEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentGroup", 5 );
			base.AddElementFieldMapping( "ComponentGroupEntity", "ComponentGroupId", "ComponentGroupId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentGroupEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ComponentGroupEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ComponentGroupEntity", "ParentComponentGroupId", "ParentComponentGroupId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentGroupEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ComponentInspectionReportEntity's mappings</summary>
		private void InitComponentInspectionReportEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReport", 41 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ComponentInspectionReportTypeId", "ComponentInspectionReportTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ComponentInspectionReportStateId", "ComponentInspectionReportStateId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Cirtemplate", "CIRTemplate", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ReconstructionBooleanAnswerId", "ReconstructionBooleanAnswerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "CimcaseNumber", "CIMCaseNumber", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ReasonForService", "ReasonForService", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "TurbineNumber", "TurbineNumber", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "CountryIsoid", "CountryISOId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "SiteName", "SiteName", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "TurbineMatrixId", "TurbineMatrixId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "LocationTypeId", "LocationTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "LocalTurbineId", "LocalTurbineId", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "SecondGeneratorBooleanAnswerId", "SecondGeneratorBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "BeforeInspectionTurbineRunStatusId", "BeforeInspectionTurbineRunStatusId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "CommisioningDate", "CommisioningDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "InstallationDate", "InstallationDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "FailureDate", "FailureDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "InspectionDate", "InspectionDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ServiceReportNumber", "ServiceReportNumber", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ServiceReportNumberTypeId", "ServiceReportNumberTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ServiceEngineer", "ServiceEngineer", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "RunHours", "RunHours", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Generator1Hrs", "Generator1Hrs", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 24 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Generator2Hrs", "Generator2Hrs", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "TotalProduction", "TotalProduction", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 26 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "AfterInspectionTurbineRunStatusId", "AfterInspectionTurbineRunStatusId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 27 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Quantity", "Quantity", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 28 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "AlarmLogNumber", "AlarmLogNumber", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 29 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Description", "Description", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 30 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "DescriptionConsquential", "DescriptionConsquential", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 31 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ConductedBy", "ConductedBy", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 32 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Sbuid", "SBUId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 33 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "CirtemplateGuid", "CIRTemplateGUID", false, (int)SqlDbType.NChar, 36, 0, 0, false, "", null, typeof(System.String), 34 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "VestasItemNumber", "VestasItemNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 35 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "Deleted", "Deleted", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 36 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 37 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "NotificationNumber", "NotificationNumber", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 38 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "MountedOnMainComponentBooleanAnswerId", "MountedOnMainComponentBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 39 );
			base.AddElementFieldMapping( "ComponentInspectionReportEntity", "ComponentUpTowerSolutionId", "ComponentUpTowerSolutionID", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 40 );
            //New Manually Code for below Fields
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "ComponentInspectionReportName", "ComponentInspectionReportName", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 41);
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "ComponentInspectionReportVersion", "ComponentInspectionReportVersion", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 42);
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "TemplateVersion", "TemplateVersion", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 43);

            base.AddElementFieldMapping("ComponentInspectionReportEntity", "SBURecommendation", "SBURecommendation", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 44);
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "InternalComments", "InternalComments", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 45);
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "AdditionalInfo", "AdditionalInfo", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 46);
            base.AddElementFieldMapping("ComponentInspectionReportEntity", "Brand", "Brand", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 47);
        }
        /// <summary>Inits ComponentInspectionReportBladeEntity's mappings</summary>
        private void InitComponentInspectionReportBladeEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportBladeEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportBlade", 38 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "ComponentInspectionReportBladeId", "ComponentInspectionReportBladeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLengthId", "BladeLengthId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeColorId", "BladeColorId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeSerialNumber", "BladeSerialNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladePicturesIncludedBooleanAnswerId", "BladePicturesIncludedBooleanAnswerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeOtherSerialNumber1", "BladeOtherSerialNumber1", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeOtherSerialNumber2", "BladeOtherSerialNumber2", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeDamageIdentified", "BladeDamageIdentified", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeFaultCodeClassificationId", "BladeFaultCodeClassificationId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeFaultCodeCauseId", "BladeFaultCodeCauseId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeFaultCodeTypeId", "BladeFaultCodeTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeFaultCodeAreaId", "BladeFaultCodeAreaId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeClaimRelevantBooleanAnswerId", "BladeClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsVtNumber", "BladeLsVtNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsCalibrationDate", "BladeLsCalibrationDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepairTip", "BladeLsLeewardSidePreRepairTip", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepairTip", "BladeLsLeewardSidePostRepairTip", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair2", "BladeLsLeewardSidePreRepair2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair2", "BladeLsLeewardSidePostRepair2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair3", "BladeLsLeewardSidePreRepair3", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair3", "BladeLsLeewardSidePostRepair3", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair4", "BladeLsLeewardSidePreRepair4", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair4", "BladeLsLeewardSidePostRepair4", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 24 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair5", "BladeLsLeewardSidePreRepair5", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair5", "BladeLsLeewardSidePostRepair5", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 26 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepairTip", "BladeLsWindwardSidePreRepairTip", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 27 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepairTip", "BladeLsWindwardSidePostRepairTip", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 28 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair2", "BladeLsWindwardSidePreRepair2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 29 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair2", "BladeLsWindwardSidePostRepair2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 30 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair3", "BladeLsWindwardSidePreRepair3", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 31 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair3", "BladeLsWindwardSidePostRepair3", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 32 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair4", "BladeLsWindwardSidePreRepair4", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 33 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair4", "BladeLsWindwardSidePostRepair4", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 34 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair5", "BladeLsWindwardSidePreRepair5", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 35 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair5", "BladeLsWindwardSidePostRepair5", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 36 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeEntity", "BladeInspectionReportDescription", "BladeInspectionReportDescription", true, (int)SqlDbType.VarChar, 5000, 0, 0, false, "", null, typeof(System.String), 37 );
		}
		/// <summary>Inits ComponentInspectionReportBladeDamageEntity's mappings</summary>
		private void InitComponentInspectionReportBladeDamageEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportBladeDamageEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportBladeDamage", 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "ComponentInspectionReportBladeDamageId", "ComponentInspectionReportBladeDamageId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "ComponentInspectionReportBladeId", "ComponentInspectionReportBladeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladeDamagePlacementId", "BladeDamagePlacementId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladeInspectionDataId", "BladeInspectionDataId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladeRadius", "BladeRadius", false, (int)SqlDbType.Float, 0, 0, 38, false, "", null, typeof(System.Double), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladeEdgeId", "BladeEdgeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladeDescription", "BladeDescription", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "BladePictureNumber", "BladePictureNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeDamageEntity", "PictureOrder", "PictureOrder", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
		}
		/// <summary>Inits ComponentInspectionReportBladeRepairRecordEntity's mappings</summary>
		private void InitComponentInspectionReportBladeRepairRecordEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportBladeRepairRecordEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportBladeRepairRecord", 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "ComponentInspectionReportBladeRepairRecordId", "ComponentInspectionReportBladeRepairRecordId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "ComponentInspectionReportBladeId", "ComponentInspectionReportBladeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeAmbientTemp", "BladeAmbientTemp", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeHumidity", "BladeHumidity", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeAdditionalDocumentReference", "BladeAdditionalDocumentReference", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeResinType", "BladeResinType", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeResinTypeBatchNumbers", "BladeResinTypeBatchNumbers", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeResinTypeExpiryDate", "BladeResinTypeExpiryDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerType", "BladeHardenerType", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerTypeBatchNumbers", "BladeHardenerTypeBatchNumbers", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerTypeExpiryDate", "BladeHardenerTypeExpiryDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeGlassSupplier", "BladeGlassSupplier", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeGlassSupplierBatchNumbers", "BladeGlassSupplierBatchNumbers", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeSurfaceMaxTemperature", "BladeSurfaceMaxTemperature", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeSurfaceMinTemperature", "BladeSurfaceMinTemperature", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeResinUsed", "BladeResinUsed", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladePostCureMaxTemperature", "BladePostCureMaxTemperature", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladePostCureMinTemperature", "BladePostCureMinTemperature", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeTurnOffTime", "BladeTurnOffTime", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportBladeRepairRecordEntity", "BladeTotalCureTime", "BladeTotalCureTime", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 19 );
		}
		/// <summary>Inits ComponentInspectionReportGearboxEntity's mappings</summary>
		private void InitComponentInspectionReportGearboxEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportGearboxEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportGearbox", 150 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "ComponentInspectionReportGearboxId", "ComponentInspectionReportGearboxId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeId", "GearboxTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxRevisionId", "GearboxRevisionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxManufacturerId", "GearboxManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "OtherGearboxType", "OtherGearboxType", true, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxSerialNumber", "GearboxSerialNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOtherManufacturer", "GearboxOtherManufacturer", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxLastOilChangeDate", "GearboxLastOilChangeDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOilTypeId", "GearboxOilTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxMechanicalOilPumpId", "GearboxMechanicalOilPumpId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOilLevelId", "GearboxOilLevelId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxRunHours", "GearboxRunHours", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOilTemperature", "GearboxOilTemperature", false, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxProduction", "GearboxProduction", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGeneratorManufacturerId", "GearboxGeneratorManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGeneratorManufacturerId2", "GearboxGeneratorManufacturerId2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxElectricalPumpId", "GearboxElectricalPumpId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShrinkElementId", "GearboxShrinkElementId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShrinkElementSerialNumber", "GearboxShrinkElementSerialNumber", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxCouplingId", "GearboxCouplingId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxFilterBlockTypeId", "GearboxFilterBlockTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxInLineFilterId", "GearboxInLineFilterId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOffLineFilterId", "GearboxOffLineFilterId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 24 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxSoftwareRelease", "GearboxSoftwareRelease", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation1ShaftTypeId", "GearboxShaftsExactLocation1ShaftTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 26 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation2ShaftTypeId", "GearboxShaftsExactLocation2ShaftTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 27 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation3ShaftTypeId", "GearboxShaftsExactLocation3ShaftTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 28 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation4ShaftTypeId", "GearboxShaftsExactLocation4ShaftTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 29 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage1ShaftErrorId", "GearboxShaftsTypeofDamage1ShaftErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 30 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage2ShaftErrorId", "GearboxShaftsTypeofDamage2ShaftErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 31 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage3ShaftErrorId", "GearboxShaftsTypeofDamage3ShaftErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 32 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage4ShaftErrorId", "GearboxShaftsTypeofDamage4ShaftErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 33 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation1GearTypeId", "GearboxExactLocation1GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 34 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation2GearTypeId", "GearboxExactLocation2GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 35 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation3GearTypeId", "GearboxExactLocation3GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 36 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation4GearTypeId", "GearboxExactLocation4GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 37 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation5GearTypeId", "GearboxExactLocation5GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 38 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage1GearErrorId", "GearboxTypeofDamage1GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 39 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage2GearErrorId", "GearboxTypeofDamage2GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 40 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage3GearErrorId", "GearboxTypeofDamage3GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 41 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage4GearErrorId", "GearboxTypeofDamage4GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 42 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage5GearErrorId", "GearboxTypeofDamage5GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 43 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation1BearingTypeId", "GearboxBearingsLocation1BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 44 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation2BearingTypeId", "GearboxBearingsLocation2BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 45 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation3BearingTypeId", "GearboxBearingsLocation3BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 46 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation4BearingTypeId", "GearboxBearingsLocation4BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 47 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation5BearingTypeId", "GearboxBearingsLocation5BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 48 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition1BearingPosId", "GearboxBearingsPosition1BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 49 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition2BearingPosId", "GearboxBearingsPosition2BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 50 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition3BearingPosId", "GearboxBearingsPosition3BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 51 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition4BearingPosId", "GearboxBearingsPosition4BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 52 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition5BearingPosId", "GearboxBearingsPosition5BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 53 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage1BearingErrorId", "GearboxBearingsDamage1BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 54 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage2BearingErrorId", "GearboxBearingsDamage2BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 55 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage3BearingErrorId", "GearboxBearingsDamage3BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 56 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage4BearingErrorId", "GearboxBearingsDamage4BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 57 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage5BearingErrorId", "GearboxBearingsDamage5BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 58 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPlanetStage1HousingErrorId", "GearboxPlanetStage1HousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 59 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPlanetStage2HousingErrorId", "GearboxPlanetStage2HousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 60 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHelicalStageHousingErrorId", "GearboxHelicalStageHousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 61 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxFrontPlateHousingErrorId", "GearboxFrontPlateHousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 62 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxAuxStageHousingErrorId", "GearboxAuxStageHousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 63 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHsstageHousingErrorId", "GearboxHSStageHousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 64 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxLooseBolts", "GearboxLooseBolts", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 65 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBrokenBolts", "GearboxBrokenBolts", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 66 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDefectDamperElements", "GearboxDefectDamperElements", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 67 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTooMuchClearance", "GearboxTooMuchClearance", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 68 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxCrackedTorqueArm", "GearboxCrackedTorqueArm", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 69 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxNeedsToBeAligned", "GearboxNeedsToBeAligned", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 70 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing1", "GearboxPT100Bearing1", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 71 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing2", "GearboxPT100Bearing2", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 72 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing3", "GearboxPT100Bearing3", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 73 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOilLevelSensor", "GearboxOilLevelSensor", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 74 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOilPressure", "GearboxOilPressure", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 75 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPt100OilSump", "GearboxPT100OilSump", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 76 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxFilterIndicator", "GearboxFilterIndicator", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 77 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxImmersionHeater", "GearboxImmersionHeater", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 78 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDrainValve", "GearboxDrainValve", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 79 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxAirBreather", "GearboxAirBreather", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 80 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxSightGlass", "GearboxSightGlass", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 81 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxChipDetector", "GearboxChipDetector", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 82 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxVibrationsId", "GearboxVibrationsId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 83 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxNoiseId", "GearboxNoiseId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 84 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDebrisOnMagnetId", "GearboxDebrisOnMagnetId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 85 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDebrisStagesMagnetPosId", "GearboxDebrisStagesMagnetPosId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 86 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDebrisGearBoxId", "GearboxDebrisGearBoxId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 87 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxMaxTempResetDate", "GearboxMaxTempResetDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 88 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTempBearing1", "GearboxTempBearing1", true, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 89 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTempBearing2", "GearboxTempBearing2", true, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 90 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTempBearing3", "GearboxTempBearing3", true, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 91 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTempOilSump", "GearboxTempOilSump", true, (int)SqlDbType.Decimal, 0, 2, 6, false, "", null, typeof(System.Decimal), 92 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxLssnrend", "GearboxLSSNRend", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 93 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxImsnrend", "GearboxIMSNRend", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 94 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxImsrend", "GearboxIMSRend", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 95 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHssnrend", "GearboxHSSNRend", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 96 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHssrend", "GearboxHSSRend", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 97 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxPitchTube", "GearboxPitchTube", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 98 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxSplitLines", "GearboxSplitLines", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 99 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHoseAndPiping", "GearboxHoseAndPiping", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 100 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxInputShaft", "GearboxInputShaft", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 101 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxHsspto", "GearboxHSSPTO", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 102 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxClaimRelevantBooleanAnswerId", "GearboxClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 103 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxOverallGearboxConditionId", "GearboxOverallGearboxConditionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 104 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation6GearTypeId", "GearboxExactLocation6GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 105 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation7GearTypeId", "GearboxExactLocation7GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 106 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation8GearTypeId", "GearboxExactLocation8GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 107 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation9GearTypeId", "GearboxExactLocation9GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 108 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation10GearTypeId", "GearboxExactLocation10GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 109 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation11GearTypeId", "GearboxExactLocation11GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 110 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation12GearTypeId", "GearboxExactLocation12GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 111 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation13GearTypeId", "GearboxExactLocation13GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 112 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation14GearTypeId", "GearboxExactLocation14GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 113 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxExactLocation15GearTypeId", "GearboxExactLocation15GearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 114 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage6GearErrorId", "GearboxTypeofDamage6GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 115 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage7GearErrorId", "GearboxTypeofDamage7GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 116 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage8GearErrorId", "GearboxTypeofDamage8GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 117 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage9GearErrorId", "GearboxTypeofDamage9GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 118 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage10GearErrorId", "GearboxTypeofDamage10GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 119 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage11GearErrorId", "GearboxTypeofDamage11GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 120 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage12GearErrorId", "GearboxTypeofDamage12GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 121 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage13GearErrorId", "GearboxTypeofDamage13GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 122 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage14GearErrorId", "GearboxTypeofDamage14GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 123 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage15GearErrorId", "GearboxTypeofDamage15GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 124 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision1DamageDecisionId", "GearboxGearDecision1DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 125 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision2DamageDecisionId", "GearboxGearDecision2DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 126 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision3DamageDecisionId", "GearboxGearDecision3DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 127 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision4DamageDecisionId", "GearboxGearDecision4DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 128 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision5DamageDecisionId", "GearboxGearDecision5DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 129 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision6DamageDecisionId", "GearboxGearDecision6DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 130 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision7DamageDecisionId", "GearboxGearDecision7DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 131 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision8DamageDecisionId", "GearboxGearDecision8DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 132 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision9DamageDecisionId", "GearboxGearDecision9DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 133 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision10DamageDecisionId", "GearboxGearDecision10DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 134 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision11DamageDecisionId", "GearboxGearDecision11DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 135 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision12DamageDecisionId", "GearboxGearDecision12DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 136 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision13DamageDecisionId", "GearboxGearDecision13DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 137 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision14DamageDecisionId", "GearboxGearDecision14DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 138 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxGearDecision15DamageDecisionId", "GearboxGearDecision15DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 139 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation6BearingTypeId", "GearboxBearingsLocation6BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 140 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition6BearingPosId", "GearboxBearingsPosition6BearingPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 141 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage6BearingErrorId", "GearboxBearingsDamage6BearingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 142 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision1DamageDecisionId", "GearboxBearingDecision1DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 143 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision2DamageDecisionId", "GearboxBearingDecision2DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 144 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision3DamageDecisionId", "GearboxBearingDecision3DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 145 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision4DamageDecisionId", "GearboxBearingDecision4DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 146 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision5DamageDecisionId", "GearboxBearingDecision5DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 147 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxBearingDecision6DamageDecisionId", "GearboxBearingDecision6DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 148 );
			base.AddElementFieldMapping( "ComponentInspectionReportGearboxEntity", "GearboxDefectCategorizationScore", "GearboxDefectCategorizationScore", true, (int)SqlDbType.Char, 10, 0, 0, false, "", null, typeof(System.String), 149 );
		}
		/// <summary>Inits ComponentInspectionReportGeneralEntity's mappings</summary>
		private void InitComponentInspectionReportGeneralEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportGeneralEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportGeneral", 36 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "ComponentInspectionReportGeneralId", "ComponentInspectionReportGeneralId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralComponentGroupId", "GeneralComponentGroupId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralComponentType", "GeneralComponentType", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralComponentManufacturer", "GeneralComponentManufacturer", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralOtherGearboxType", "GeneralOtherGearboxType", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralClaimRelevantBooleanAnswerId", "GeneralClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralOtherGearboxManufacturer", "GeneralOtherGearboxManufacturer", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralComponentSerialNumber", "GeneralComponentSerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralGeneratorManufacturerId", "GeneralGeneratorManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralTransformerManufacturerId", "GeneralTransformerManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralGearboxManufacturerId", "GeneralGearboxManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralTowerTypeId", "GeneralTowerTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralTowerHeightId", "GeneralTowerHeightId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralBlade1SerialNumber", "GeneralBlade1SerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralBlade2SerialNumber", "GeneralBlade2SerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralBlade3SerialNumber", "GeneralBlade3SerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralControllerTypeId", "GeneralControllerTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralSoftwareRelease", "GeneralSoftwareRelease", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralRamDumpNumber", "GeneralRamDumpNumber", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralVdftrackNumber", "GeneralVDFTrackNumber", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralPicturesIncludedBooleanAnswerId", "GeneralPicturesIncludedBooleanAnswerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy1", "GeneralInitiatedBy1", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy2", "GeneralInitiatedBy2", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 24 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy3", "GeneralInitiatedBy3", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy4", "GeneralInitiatedBy4", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 26 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted1", "GeneralMeasurementsConducted1", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 27 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted2", "GeneralMeasurementsConducted2", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 28 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted3", "GeneralMeasurementsConducted3", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 29 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted4", "GeneralMeasurementsConducted4", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 30 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralExecutedBy1", "GeneralExecutedBy1", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 31 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralExecutedBy2", "GeneralExecutedBy2", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 32 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralExecutedBy3", "GeneralExecutedBy3", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 33 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralExecutedBy4", "GeneralExecutedBy4", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 34 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneralEntity", "GeneralPositionOfFailedItem", "GeneralPositionOfFailedItem", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 35 );
		}
		/// <summary>Inits ComponentInspectionReportGeneratorEntity's mappings</summary>
		private void InitComponentInspectionReportGeneratorEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportGeneratorEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportGenerator", 46 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "ComponentInspectionReportGeneratorId", "ComponentInspectionReportGeneratorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorManufacturerId", "GeneratorManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorSerialNumber", "GeneratorSerialNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "OtherManufacturer", "OtherManufacturer", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorMaxTemperature", "GeneratorMaxTemperature", false, (int)SqlDbType.Decimal, 0, 2, 5, false, "", null, typeof(System.Decimal), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorMaxTemperatureResetDate", "GeneratorMaxTemperatureResetDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "CouplingId", "CouplingId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "ActionToBeTakenOnGeneratorId", "ActionToBeTakenOnGeneratorId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorDriveEndId", "GeneratorDriveEndId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorNonDriveEndId", "GeneratorNonDriveEndId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorRotorId", "GeneratorRotorId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorCoverId", "GeneratorCoverId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "AirToAirCoolerInternalId", "AirToAirCoolerInternalId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "AirToAirCoolerExternalId", "AirToAirCoolerExternalId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorComments", "GeneratorComments", true, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Uground", "UGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Vground", "VGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Wground", "WGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Uv", "UV", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Uw", "UW", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Vw", "VW", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Kground", "KGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Lground", "LGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 24 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "Mground", "MGround", true, (int)SqlDbType.Decimal, 0, 2, 12, false, "", null, typeof(System.Decimal), 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "UgroundOhmUnitId", "UGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 26 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "VgroundOhmUnitId", "VGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 27 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "WgroundOhmUnitId", "WGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 28 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "UvohmUnitId", "UVOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 29 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "UwohmUnitId", "UWOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 30 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "VwohmUnitId", "VWOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 31 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "KgroundOhmUnitId", "KGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 32 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "LgroundOhmUnitId", "LGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 33 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "MgroundOhmUnitId", "MGroundOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 34 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "U1U2", "U1U2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 35 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "V1V2", "V1V2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 36 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "W1W2", "W1W2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 37 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "K1L1", "K1L1", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 38 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "L1M1", "L1M1", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 39 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "K1M1", "K1M1", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 40 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "K2L2", "K2L2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 41 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "L2M2", "L2M2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 42 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "K2M2", "K2M2", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 43 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorRewoundLocally", "GeneratorRewoundLocally", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 44 );
			base.AddElementFieldMapping( "ComponentInspectionReportGeneratorEntity", "GeneratorClaimRelevantBooleanAnswerId", "GeneratorClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 45 );
		}
		/// <summary>Inits ComponentInspectionReportMainBearingEntity's mappings</summary>
		private void InitComponentInspectionReportMainBearingEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportMainBearingEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportMainBearing", 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "ComponentInspectionReportMainBearingId", "ComponentInspectionReportMainBearingId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingLastLubricationDate", "MainBearingLastLubricationDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingManufacturerId", "MainBearingManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingTemperature", "MainBearingTemperature", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingLubricationOilTypeId", "MainBearingLubricationOilTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingGrease", "MainBearingGrease", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingLubricationRunHours", "MainBearingLubricationRunHours", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingOilTemperature", "MainBearingOilTemperature", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingTypeId", "MainBearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingRevision", "MainBearingRevision", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingErrorLocationId", "MainBearingErrorLocationId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingSerialNumber", "MainBearingSerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingRunHours", "MainBearingRunHours", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingMechanicalOilPump", "MainBearingMechanicalOilPump", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportMainBearingEntity", "MainBearingClaimRelevantBooleanAnswerId", "MainBearingClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 16 );
		}
		/// <summary>Inits ComponentInspectionReportSkiiPEntity's mappings</summary>
		private void InitComponentInspectionReportSkiiPEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportSkiiPEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportSkiiP", 25 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "ComponentInspectionReportSkiiPid", "ComponentInspectionReportSkiiPId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiPotherDamagedComponentsReplaced", "SkiiPOtherDamagedComponentsReplaced", true, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiPcauseId", "SkiiPCauseId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiPquantityOfFailedModules", "SkiiPQuantityOfFailedModules", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv521BooleanAnswerId", "SkiiP2MWV521BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv522BooleanAnswerId", "SkiiP2MWV522BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv523BooleanAnswerId", "SkiiP2MWV523BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv524BooleanAnswerId", "SkiiP2MWV524BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv525BooleanAnswerId", "SkiiP2MWV525BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv526BooleanAnswerId", "SkiiP2MWV526BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv521BooleanAnswerId", "SkiiP3MWV521BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv522BooleanAnswerId", "SkiiP3MWV522BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv523BooleanAnswerId", "SkiiP3MWV523BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv524xBooleanAnswerId", "SkiiP3MWV524xBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv524yBooleanAnswerId", "SkiiP3MWV524yBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv525xBooleanAnswerId", "SkiiP3MWV525xBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv525yBooleanAnswerId", "SkiiP3MWV525yBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv526xBooleanAnswerId", "SkiiP3MWV526xBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv526yBooleanAnswerId", "SkiiP3MWV526yBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv520BooleanAnswerId", "SkiiP850KWV520BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 20 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv524BooleanAnswerId", "SkiiP850KWV524BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 21 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv525BooleanAnswerId", "SkiiP850KWV525BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 22 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv526BooleanAnswerId", "SkiiP850KWV526BooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 23 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPEntity", "SkiiPclaimRelevantBooleanAnswerId", "SkiiPClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 24 );
		}
		/// <summary>Inits ComponentInspectionReportSkiiPfailedComponentEntity's mappings</summary>
		private void InitComponentInspectionReportSkiiPfailedComponentEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportSkiiPFailedComponent", 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "ComponentInspectionReportSkiiPfailedComponentId", "ComponentInspectionReportSkiiPFailedComponentId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "ComponentInspectionReportSkiiPid", "ComponentInspectionReportSkiiPId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentVestasUniqueIdentifier", "SkiiPFailedComponentVestasUniqueIdentifier", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentVestasItemNumber", "SkiiPFailedComponentVestasItemNumber", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentSerialNumber", "SkiiPFailedComponentSerialNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits ComponentInspectionReportSkiiPnewComponentEntity's mappings</summary>
		private void InitComponentInspectionReportSkiiPnewComponentEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportSkiiPNewComponent", 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "ComponentInspectionReportSkiiPnewComponentId", "ComponentInspectionReportSkiiPNewComponentId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "ComponentInspectionReportSkiiPid", "ComponentInspectionReportSkiiPId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentVestasUniqueIdentifier", "SkiiPNewComponentVestasUniqueIdentifier", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentVestasItemNumber", "SkiiPNewComponentVestasItemNumber", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentSerialNumber", "SkiiPNewComponentSerialNumber", false, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits ComponentInspectionReportStateEntity's mappings</summary>
		private void InitComponentInspectionReportStateEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportStateEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportState", 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportStateEntity", "ComponentInspectionReportStateId", "ComponentInspectionReportStateId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportStateEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits ComponentInspectionReportTransformerEntity's mappings</summary>
		private void InitComponentInspectionReportTransformerEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportTransformerEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportTransformer", 19 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "ComponentInspectionReportTransformerId", "ComponentInspectionReportTransformerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "VestasUniqueIdentifier", "VestasUniqueIdentifier", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "TransformerManufacturerId", "TransformerManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "TransformerSerialNumber", "TransformerSerialNumber", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "MaxTemp", "MaxTemp", true, (int)SqlDbType.Decimal, 0, 2, 5, false, "", null, typeof(System.Decimal), 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "MaxTempResetDate", "MaxTempResetDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "ActionOnTransformerId", "ActionOnTransformerId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "HvcoilConditionId", "HVCoilConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "LvcoilConditionId", "LVCoilConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "HvcableConditionId", "HVCableConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "LvcableConditionId", "LVCableConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "BracketsId", "BracketsId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "TransformerArcDetectionId", "TransformerArcDetectionId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "ClimateId", "ClimateId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 14 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "SurgeArrestorId", "SurgeArrestorId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "ConnectionBarsId", "ConnectionBarsId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 16 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "Comments", "Comments", true, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 17 );
			base.AddElementFieldMapping( "ComponentInspectionReportTransformerEntity", "TransformerClaimRelevantBooleanAnswerId", "TransformerClaimRelevantBooleanAnswerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
		}
		/// <summary>Inits ComponentInspectionReportTypeEntity's mappings</summary>
		private void InitComponentInspectionReportTypeEntityMappings()
		{
			base.AddElementMapping( "ComponentInspectionReportTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentInspectionReportType", 5 );
			base.AddElementFieldMapping( "ComponentInspectionReportTypeEntity", "ComponentInspectionReportTypeId", "ComponentInspectionReportTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ComponentInspectionReportTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ComponentInspectionReportTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ComponentInspectionReportTypeEntity", "ParentComponentInspectionReportTypeId", "ParentComponentInspectionReportTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ComponentInspectionReportTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ComponentUpTowerSolutionEntity's mappings</summary>
		private void InitComponentUpTowerSolutionEntityMappings()
		{
			base.AddElementMapping( "ComponentUpTowerSolutionEntity", "CIM_ComponentInspectionReports", @"dbo", "ComponentUpTowerSolution", 2 );
			base.AddElementFieldMapping( "ComponentUpTowerSolutionEntity", "ComponentUpTowerSolutionId", "ComponentUpTowerSolutionID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ComponentUpTowerSolutionEntity", "Name", "Name", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits ConnectionBarsEntity's mappings</summary>
		private void InitConnectionBarsEntityMappings()
		{
			base.AddElementMapping( "ConnectionBarsEntity", "CIM_ComponentInspectionReports", @"dbo", "ConnectionBars", 5 );
			base.AddElementFieldMapping( "ConnectionBarsEntity", "ConnectionBarsId", "ConnectionBarsId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ConnectionBarsEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ConnectionBarsEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ConnectionBarsEntity", "ParentConnectionBarsId", "ParentConnectionBarsId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ConnectionBarsEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ControllerTypeEntity's mappings</summary>
		private void InitControllerTypeEntityMappings()
		{
			base.AddElementMapping( "ControllerTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "ControllerType", 5 );
			base.AddElementFieldMapping( "ControllerTypeEntity", "ControllerTypeId", "ControllerTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ControllerTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ControllerTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ControllerTypeEntity", "ParentControllerTypeId", "ParentControllerTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ControllerTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits CountryIsoEntity's mappings</summary>
		private void InitCountryIsoEntityMappings()
		{
			base.AddElementMapping( "CountryIsoEntity", "CIM_ComponentInspectionReports", @"dbo", "CountryISO", 7 );
			base.AddElementFieldMapping( "CountryIsoEntity", "CountryIsoid", "CountryISOId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CountryIsoEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CountryIsoEntity", "ShortName", "ShortName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "CountryIsoEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "CountryIsoEntity", "ParentCountryIsoid", "ParentCountryISOId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "CountryIsoEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "CountryIsoEntity", "Sbuid", "SBUId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
		}
		/// <summary>Inits CouplingEntity's mappings</summary>
		private void InitCouplingEntityMappings()
		{
			base.AddElementMapping( "CouplingEntity", "CIM_ComponentInspectionReports", @"dbo", "Coupling", 5 );
			base.AddElementFieldMapping( "CouplingEntity", "CouplingId", "CouplingId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "CouplingEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "CouplingEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "CouplingEntity", "ParentCouplingId", "ParentCouplingId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "CouplingEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits DamageEntity's mappings</summary>
		private void InitDamageEntityMappings()
		{
			base.AddElementMapping( "DamageEntity", "CIM_ComponentInspectionReports", @"dbo", "Damage", 4 );
			base.AddElementFieldMapping( "DamageEntity", "DamageId", "DamageId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "DamageEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "DamageEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "DamageEntity", "GearErrorId", "GearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
		}
		/// <summary>Inits DamageDecisionEntity's mappings</summary>
		private void InitDamageDecisionEntityMappings()
		{
			base.AddElementMapping( "DamageDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "DamageDecision", 5 );
			base.AddElementFieldMapping( "DamageDecisionEntity", "DamageDecisionId", "DamageDecisionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "DamageDecisionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "DamageDecisionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "DamageDecisionEntity", "ParentDamageDecisionId", "ParentDamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "DamageDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits DebrisGearboxEntity's mappings</summary>
		private void InitDebrisGearboxEntityMappings()
		{
			base.AddElementMapping( "DebrisGearboxEntity", "CIM_ComponentInspectionReports", @"dbo", "DebrisGearbox", 5 );
			base.AddElementFieldMapping( "DebrisGearboxEntity", "DebrisGearboxId", "DebrisGearboxId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "DebrisGearboxEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "DebrisGearboxEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "DebrisGearboxEntity", "ParentDebrisGearboxId", "ParentDebrisGearboxId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "DebrisGearboxEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits DebrisOnMagnetEntity's mappings</summary>
		private void InitDebrisOnMagnetEntityMappings()
		{
			base.AddElementMapping( "DebrisOnMagnetEntity", "CIM_ComponentInspectionReports", @"dbo", "DebrisOnMagnet", 5 );
			base.AddElementFieldMapping( "DebrisOnMagnetEntity", "DebrisOnMagnetId", "DebrisOnMagnetId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "DebrisOnMagnetEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "DebrisOnMagnetEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "DebrisOnMagnetEntity", "ParentDebrisOnMagnetId", "ParentDebrisOnMagnetId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "DebrisOnMagnetEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits DynamicTableInputEntity's mappings</summary>
		private void InitDynamicTableInputEntityMappings()
		{
			base.AddElementMapping( "DynamicTableInputEntity", "CIM_ComponentInspectionReports", @"dbo", "DynamicTableInput", 42 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "CirId", "CirId", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row1Col1", "Row1Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row1Col2", "Row1Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row1Col3", "Row1Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row1Col4", "Row1Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row2Col1", "Row2Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row2Col2", "Row2Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row2Col3", "Row2Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row2Col4", "Row2Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row3Col1", "Row3Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row3Col2", "Row3Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row3Col3", "Row3Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row3Col4", "Row3Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row4Col1", "Row4Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 14 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row4Col2", "Row4Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row4Col3", "Row4Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 16 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row4Col4", "Row4Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 17 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row5Col1", "Row5Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 18 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row5Col2", "Row5Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 19 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row5Col3", "Row5Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 20 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row5Col4", "Row5Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 21 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row6Col1", "Row6Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 22 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row6Col2", "Row6Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 23 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row6Col3", "Row6Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 24 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row6Col4", "Row6Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 25 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row7Col1", "Row7Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 26 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row7Col2", "Row7Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 27 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row7Col3", "Row7Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 28 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row7Col4", "Row7Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 29 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row8Col1", "Row8Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 30 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row8Col2", "Row8Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 31 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row8Col3", "Row8Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 32 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row8Col4", "Row8Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 33 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row9Col1", "Row9Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 34 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row9Col2", "Row9Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 35 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row9Col3", "Row9Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 36 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row9Col4", "Row9Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 37 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row10Col1", "Row10Col1", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 38 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row10Col2", "Row10Col2", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 39 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row10Col3", "Row10Col3", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 40 );
			base.AddElementFieldMapping( "DynamicTableInputEntity", "Row10Col4", "Row10Col4", true, (int)SqlDbType.VarChar, 100, 0, 0, false, "", null, typeof(System.String), 41 );
		}
		/// <summary>Inits EditHistoryEntity's mappings</summary>
		private void InitEditHistoryEntityMappings()
		{
			base.AddElementMapping( "EditHistoryEntity", "CIM_ComponentInspectionReports", @"dbo", "EditHistory", 6 );
			base.AddElementFieldMapping( "EditHistoryEntity", "EditHistoryId", "EditHistoryId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "EditHistoryEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "EditHistoryEntity", "EditInitials", "EditInitials", false, (int)SqlDbType.Char, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "EditHistoryEntity", "EditDate", "EditDate", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "EditHistoryEntity", "EditVersion", "EditVersion", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "EditHistoryEntity", "EditReason", "EditReason", true, (int)SqlDbType.NVarChar, 512, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits ElectricalPumpEntity's mappings</summary>
		private void InitElectricalPumpEntityMappings()
		{
			base.AddElementMapping( "ElectricalPumpEntity", "CIM_ComponentInspectionReports", @"dbo", "ElectricalPump", 5 );
			base.AddElementFieldMapping( "ElectricalPumpEntity", "ElectricalPumpId", "ElectricalPumpId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ElectricalPumpEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ElectricalPumpEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ElectricalPumpEntity", "ParentElectricalPumpId", "ParentElectricalPumpId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ElectricalPumpEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits FaultCodeAreaEntity's mappings</summary>
		private void InitFaultCodeAreaEntityMappings()
		{
			base.AddElementMapping( "FaultCodeAreaEntity", "CIM_ComponentInspectionReports", @"dbo", "FaultCodeArea", 7 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "FaultCodeAreaId", "FaultCodeAreaId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "ParentFaultCodeAreaId", "ParentFaultCodeAreaId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "StartVersion", "StartVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "FaultCodeAreaEntity", "EndVersion", "EndVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits FaultCodeCauseEntity's mappings</summary>
		private void InitFaultCodeCauseEntityMappings()
		{
			base.AddElementMapping( "FaultCodeCauseEntity", "CIM_ComponentInspectionReports", @"dbo", "FaultCodeCause", 5 );
			base.AddElementFieldMapping( "FaultCodeCauseEntity", "FaultCodeCauseId", "FaultCodeCauseId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FaultCodeCauseEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "FaultCodeCauseEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "FaultCodeCauseEntity", "ParentFaultCodeCauseId", "ParentFaultCodeCauseId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FaultCodeCauseEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits FaultCodeClassificationEntity's mappings</summary>
		private void InitFaultCodeClassificationEntityMappings()
		{
			base.AddElementMapping( "FaultCodeClassificationEntity", "CIM_ComponentInspectionReports", @"dbo", "FaultCodeClassification", 5 );
			base.AddElementFieldMapping( "FaultCodeClassificationEntity", "FaultCodeClassificationId", "FaultCodeClassificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FaultCodeClassificationEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "FaultCodeClassificationEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "FaultCodeClassificationEntity", "ParentFaultCodeClassificationId", "ParentFaultCodeClassificationId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FaultCodeClassificationEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits FaultCodeTypeEntity's mappings</summary>
		private void InitFaultCodeTypeEntityMappings()
		{
			base.AddElementMapping( "FaultCodeTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "FaultCodeType", 5 );
			base.AddElementFieldMapping( "FaultCodeTypeEntity", "FaultCodeTypeId", "FaultCodeTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FaultCodeTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "FaultCodeTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "FaultCodeTypeEntity", "ParentFaultCodeTypeId", "ParentFaultCodeTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FaultCodeTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits FilterBlockTypeEntity's mappings</summary>
		private void InitFilterBlockTypeEntityMappings()
		{
			base.AddElementMapping( "FilterBlockTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "FilterBlockType", 5 );
			base.AddElementFieldMapping( "FilterBlockTypeEntity", "FilterBlockTypeId", "FilterBlockTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FilterBlockTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "FilterBlockTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "FilterBlockTypeEntity", "ParentFilterBlockTypeId", "ParentFilterBlockTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FilterBlockTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits FirstNotificationEntity's mappings</summary>
		private void InitFirstNotificationEntityMappings()
		{
			base.AddElementMapping( "FirstNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "FirstNotification", 16 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "FirstNotificationId", "FirstNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "Sbuid", "SBUId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "EditDate", "EditDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "EditInitials", "EditInitials", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "TurbineMatrixId", "TurbineMatrixId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "Sitename", "Sitename", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "CountryIsoid", "CountryISOId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "ComponentType", "ComponentType", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "ManufacturerId", "ManufacturerID", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "SerialNo", "SerialNo", true, (int)SqlDbType.NVarChar, 2000, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "CommisioningDate", "CommisioningDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 12 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "FailureDate", "FailureDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 13 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "QueuedOn", "QueuedOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 14 );
			base.AddElementFieldMapping( "FirstNotificationEntity", "CirDataId", "CirDataId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
		}
		/// <summary>Inits GearboxDefectCategorizationEntity's mappings</summary>
		private void InitGearboxDefectCategorizationEntityMappings()
		{
			base.AddElementMapping( "GearboxDefectCategorizationEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxDefectCategorization", 40 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "GearboxDefectCategorizationId", "GearboxDefectCategorizationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "VendorName", "VendorName", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "GearboxTypeId", "GearboxTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "SerialNumber", "SerialNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "GearBoxManufacturerId", "GearBoxManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Ratio", "Ratio", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "OilTypeId", "OilTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Frequency", "Frequency", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "ComponentInspectionReportGearboxId", "ComponentInspectionReportGearboxId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "InspectionDate", "InspectionDate", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 9 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "InspectedBy", "InspectedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "RepairManualNumber", "RepairManualNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "JobNumber", "JobNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Timestamp", "Timestamp", false, (int)SqlDbType.Timestamp, 0, 0, 0, false, "", null, typeof(System.Byte[]), 14 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Noise", "Noise", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 15 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "MetalOnMagnet", "MetalOnMagnet", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 16 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "HighTemperature", "HighTemperature", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 17 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Leakage", "Leakage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 18 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Painting", "Painting", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 19 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "Others", "Others", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 20 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "None", "None", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 21 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "HssBearingDamage", "HssBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 22 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "ImsBearingDamage", "ImsBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 23 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "LssBearingDamage", "LssBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 24 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "PlanetBearingDamage", "PlanetBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 25 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "OtherBearingDamage", "OtherBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 26 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "NoBearingDamage", "NoBearingDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 27 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "HssToothDamage", "HssToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 28 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "ImsToothDamage", "ImsToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 29 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "LssToothDamage", "LssToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 30 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "PlanetToothDamage", "PlanetToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 31 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "OtherToothDamage", "OtherToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 32 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "NoToothDamage", "NoToothDamage", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 33 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "DetailsOfDamage", "DetailsOfDamage", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 34 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "ServiceHistory", "ServiceHistory", true, (int)SqlDbType.NVarChar, 2147483647, 0, 0, false, "", null, typeof(System.String), 35 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "PrimaryFailure", "PrimaryFailure", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 36 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "SecondaryFailure", "SecondaryFailure", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 37 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "ConsequentialDamage", "ConsequentialDamage", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 38 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationEntity", "OtherFindings", "OtherFindings", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 39 );
		}
		/// <summary>Inits GearboxDefectCategorizationDetailsEntity's mappings</summary>
		private void InitGearboxDefectCategorizationDetailsEntityMappings()
		{
			base.AddElementMapping( "GearboxDefectCategorizationDetailsEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxDefectCategorizationDetails", 9 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "GearboxDefectCategorizationId", "GearboxDefectCategorizationId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "PartName", "PartName", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "GearboxPartTypeId", "GearboxPartTypeId", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "ItemNumber", "ItemNumber", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "BearingTypeId", "BearingTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "Error1Id", "Error1Id", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "Error2Id", "Error2Id", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "Comments", "Comments", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "GearboxDefectCategorizationDetailsEntity", "DamageDecisionId", "DamageDecisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
		}
		/// <summary>Inits GearboxManufacturerEntity's mappings</summary>
		private void InitGearboxManufacturerEntityMappings()
		{
			base.AddElementMapping( "GearboxManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxManufacturer", 8 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "GearboxManufacturerId", "GearboxManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "ParentGearboxManufacturerId", "ParentGearboxManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "Cc", "Cc", true, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "GearboxManufacturerEntity", "EmailContactName", "EmailContactName", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits GearboxPartTypeEntity's mappings</summary>
		private void InitGearboxPartTypeEntityMappings()
		{
			base.AddElementMapping( "GearboxPartTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxPartType", 3 );
			base.AddElementFieldMapping( "GearboxPartTypeEntity", "GearboxPartTypeId", "GearboxPartTypeId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GearboxPartTypeEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearboxPartTypeEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GearboxRevisionEntity's mappings</summary>
		private void InitGearboxRevisionEntityMappings()
		{
			base.AddElementMapping( "GearboxRevisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxRevision", 5 );
			base.AddElementFieldMapping( "GearboxRevisionEntity", "GearboxRevisionId", "GearboxRevisionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearboxRevisionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearboxRevisionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearboxRevisionEntity", "ParentGearboxRevisionId", "ParentGearboxRevisionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GearboxRevisionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GearboxTypeEntity's mappings</summary>
		private void InitGearboxTypeEntityMappings()
		{
			base.AddElementMapping( "GearboxTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "GearboxType", 6 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "GearboxTypeId", "GearboxTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "ParentGearboxTypeId", "ParentGearboxTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "GearboxTypeEntity", "GearboxManufacturerId", "GearboxManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
		}
		/// <summary>Inits GearDamageCategoryEntity's mappings</summary>
		private void InitGearDamageCategoryEntityMappings()
		{
			base.AddElementMapping( "GearDamageCategoryEntity", "CIM_ComponentInspectionReports", @"dbo", "GearDamageCategory", 3 );
			base.AddElementFieldMapping( "GearDamageCategoryEntity", "GearDamageCategoryId", "GearDamageCategoryId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GearDamageCategoryEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearDamageCategoryEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GearErrorEntity's mappings</summary>
		private void InitGearErrorEntityMappings()
		{
			base.AddElementMapping( "GearErrorEntity", "CIM_ComponentInspectionReports", @"dbo", "GearError", 5 );
			base.AddElementFieldMapping( "GearErrorEntity", "GearErrorId", "GearErrorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearErrorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearErrorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearErrorEntity", "ParentGearErrorId", "ParentGearErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GearErrorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GearErrorVendorEntity's mappings</summary>
		private void InitGearErrorVendorEntityMappings()
		{
			base.AddElementMapping( "GearErrorVendorEntity", "CIM_ComponentInspectionReports", @"dbo", "GearErrorVendor", 3 );
			base.AddElementFieldMapping( "GearErrorVendorEntity", "GearErrorVendorId", "GearErrorVendorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GearErrorVendorEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearErrorVendorEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GearTypeEntity's mappings</summary>
		private void InitGearTypeEntityMappings()
		{
			base.AddElementMapping( "GearTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "GearType", 5 );
			base.AddElementFieldMapping( "GearTypeEntity", "GearTypeId", "GearTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GearTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GearTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GearTypeEntity", "ParentGearTypeId", "ParentGearTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GearTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GenerateCiridEntity's mappings</summary>
		private void InitGenerateCiridEntityMappings()
		{
			base.AddElementMapping( "GenerateCiridEntity", "CIM_ComponentInspectionReports", @"dbo", "GenerateCIRId", 1 );
			base.AddElementFieldMapping( "GenerateCiridEntity", "Cirid", "CIRId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
		}
		/// <summary>Inits GeneratorBearingDecisionEntity's mappings</summary>
		private void InitGeneratorBearingDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorBearingDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorBearingDecision", 3 );
			base.AddElementFieldMapping( "GeneratorBearingDecisionEntity", "GeneratorBearingDecisionId", "GeneratorBearingDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorBearingDecisionEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorBearingDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GeneratorComponentDamageEntity's mappings</summary>
		private void InitGeneratorComponentDamageEntityMappings()
		{
			base.AddElementMapping( "GeneratorComponentDamageEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorComponentDamage", 3 );
			base.AddElementFieldMapping( "GeneratorComponentDamageEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorComponentDamageEntity", "Component", "Component", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorComponentDamageEntity", "FailureDamage", "FailureDamage", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits GeneratorCoverEntity's mappings</summary>
		private void InitGeneratorCoverEntityMappings()
		{
			base.AddElementMapping( "GeneratorCoverEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorCover", 5 );
			base.AddElementFieldMapping( "GeneratorCoverEntity", "GeneratorCoverId", "GeneratorCoverId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorCoverEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorCoverEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorCoverEntity", "ParentGeneratorCoverId", "ParentGeneratorCoverId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorCoverEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GeneratorDefectCategorizationEntity's mappings</summary>
		private void InitGeneratorDefectCategorizationEntityMappings()
		{
			base.AddElementMapping( "GeneratorDefectCategorizationEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorDefectCategorization", 37 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "GeneratorDefectCategorizationId", "GeneratorDefectCategorizationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "StatorInsulation", "StatorInsulation", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "StatorInductive", "StatorInductive", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "StatorVibrations", "StatorVibrations", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "StatorDecision", "StatorDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorInsulation", "RotorInsulation", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorInductive", "RotorInductive", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorVibrations", "RotorVibrations", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorPostFailure", "RotorPostFailure", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorDecision", "RotorDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorLeadInsulation", "RotorLeadInsulation", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorLeadConnection", "RotorLeadConnection", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RotorLeadDecision", "RotorLeadDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 12 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "PhaseDamaged", "PhaseDamaged", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 13 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "PhaseDamagedDecision", "PhaseDamagedDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 14 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsBearingFailure", "BearingsBearingFailure", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 15 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsInnerRace", "BearingsInnerRace", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 16 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsOuterRace", "BearingsOuterRace", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 17 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsNoise", "BearingsNoise", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 18 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsVibrations", "BearingsVibrations", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 19 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsSeal", "BearingsSeal", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 20 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "BearingsDecision", "BearingsDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 21 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscBearing", "MiscBearing", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 22 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscBearingDecision", "MiscBearingDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 23 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscGenerator", "MiscGenerator", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 24 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscGeneratorDecision", "MiscGeneratorDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 25 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscWater", "MiscWater", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 26 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscWaterDecision", "MiscWaterDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 27 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscPtsensor", "MiscPTSensor", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 28 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscPtsensorDecision", "MiscPTSensorDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 29 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscGrounding", "MiscGrounding", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 30 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "MiscGroundingDecision", "MiscGroundingDecision", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 31 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "DefectCategory", "DefectCategory", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 32 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "RepairManualNumber", "RepairManualNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 33 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "ComponentInspectionReportGeneratorId", "ComponentInspectionReportGeneratorId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 34 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "Source", "Source", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 35 );
			base.AddElementFieldMapping( "GeneratorDefectCategorizationEntity", "Timestamp", "Timestamp", false, (int)SqlDbType.Timestamp, 0, 0, 0, false, "", null, typeof(System.Byte[]), 36 );
		}
		/// <summary>Inits GeneratorDefectCategorization2Entity's mappings</summary>
		private void InitGeneratorDefectCategorization2EntityMappings()
		{
			base.AddElementMapping( "GeneratorDefectCategorization2Entity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorDefectCategorization2", 27 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "GeneratorDefectCategorizationId", "GeneratorDefectCategorizationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "VendorName", "VendorName", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "GeneratorType", "GeneratorType", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "Kwtype", "KWType", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "Hz", "Hz", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "SerialNumber", "SerialNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "Manufacturer", "Manufacturer", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "CirId", "CirId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "InspectionDate", "InspectionDate", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 8 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "InspectedBy", "InspectedBy", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "Email", "Email", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "RepairManualNumber", "RepairManualNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "JobNumber", "JobNumber", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "WindingsType", "WindingsType", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingManufacturerDe", "BearingManufacturerDE", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 14 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingTypeDe", "BearingTypeDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingNumberDe", "BearingNumberDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 16 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "LubricationTypeDe", "LubricationTypeDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 17 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingManufacturerNde", "BearingManufacturerNDE", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 18 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingTypeNde", "BearingTypeNDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 19 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "BearingNumberNde", "BearingNumberNDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 20 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "LubricationTypeNde", "LubricationTypeNDE", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 21 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "PrimaryFailure", "PrimaryFailure", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 22 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "SecondaryFailure", "SecondaryFailure", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 23 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "ConsequentialDamage", "ConsequentialDamage", true, (int)SqlDbType.NVarChar, 150, 0, 0, false, "", null, typeof(System.String), 24 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "OtherFindings", "OtherFindings", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 25 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2Entity", "FailureModes", "FailureModes", true, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 26 );
		}
		/// <summary>Inits GeneratorDefectCategorization2DetailsEntity's mappings</summary>
		private void InitGeneratorDefectCategorization2DetailsEntityMappings()
		{
			base.AddElementMapping( "GeneratorDefectCategorization2DetailsEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorDefectCategorization2Details", 5 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2DetailsEntity", "GeneratorDefectCategorization2Id", "GeneratorDefectCategorization2Id", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2DetailsEntity", "GeneratorComponentDamage", "GeneratorComponentDamage", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2DetailsEntity", "IsDamage", "IsDamage", false, (int)SqlDbType.NVarChar, 10, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2DetailsEntity", "Repair", "Repair", true, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "GeneratorDefectCategorization2DetailsEntity", "FailureMode", "FailureMode", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits GeneratorDriveEndEntity's mappings</summary>
		private void InitGeneratorDriveEndEntityMappings()
		{
			base.AddElementMapping( "GeneratorDriveEndEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorDriveEnd", 5 );
			base.AddElementFieldMapping( "GeneratorDriveEndEntity", "GeneratorDriveEndId", "GeneratorDriveEndId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorDriveEndEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorDriveEndEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorDriveEndEntity", "ParentGeneratorDriveEndId", "ParentGeneratorDriveEndId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorDriveEndEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GeneratorManufacturerEntity's mappings</summary>
		private void InitGeneratorManufacturerEntityMappings()
		{
			base.AddElementMapping( "GeneratorManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorManufacturer", 8 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "GeneratorManufacturerId", "GeneratorManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "ParentGeneratorManufacturerId", "ParentGeneratorManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "Cc", "Cc", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "GeneratorManufacturerEntity", "EmailContactName", "EmailContactName", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits GeneratorMiscDecisionEntity's mappings</summary>
		private void InitGeneratorMiscDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorMiscDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorMiscDecision", 3 );
			base.AddElementFieldMapping( "GeneratorMiscDecisionEntity", "GeneratorMiscDecisionId", "GeneratorMiscDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorMiscDecisionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorMiscDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GeneratorNonDriveEndEntity's mappings</summary>
		private void InitGeneratorNonDriveEndEntityMappings()
		{
			base.AddElementMapping( "GeneratorNonDriveEndEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorNonDriveEnd", 5 );
			base.AddElementFieldMapping( "GeneratorNonDriveEndEntity", "GeneratorNonDriveEndId", "GeneratorNonDriveEndId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorNonDriveEndEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorNonDriveEndEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorNonDriveEndEntity", "ParentGeneratorNonDriveEndId", "ParentGeneratorNonDriveEndId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorNonDriveEndEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GeneratorPhaseOutletDecisionEntity's mappings</summary>
		private void InitGeneratorPhaseOutletDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorPhaseOutletDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorPhaseOutletDecision", 3 );
			base.AddElementFieldMapping( "GeneratorPhaseOutletDecisionEntity", "GeneratorPhaseOutletDecisionId", "GeneratorPhaseOutletDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorPhaseOutletDecisionEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorPhaseOutletDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GeneratorRotorEntity's mappings</summary>
		private void InitGeneratorRotorEntityMappings()
		{
			base.AddElementMapping( "GeneratorRotorEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorRotor", 5 );
			base.AddElementFieldMapping( "GeneratorRotorEntity", "GeneratorRotorId", "GeneratorRotorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "GeneratorRotorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorRotorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "GeneratorRotorEntity", "ParentGeneratorRotorId", "ParentGeneratorRotorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "GeneratorRotorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits GeneratorRotorDecisionEntity's mappings</summary>
		private void InitGeneratorRotorDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorRotorDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorRotorDecision", 3 );
			base.AddElementFieldMapping( "GeneratorRotorDecisionEntity", "GeneratorRotorDecisionId", "GeneratorRotorDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorRotorDecisionEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorRotorDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GeneratorRotorLeadsDecisionEntity's mappings</summary>
		private void InitGeneratorRotorLeadsDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorRotorLeadsDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorRotorLeadsDecision", 3 );
			base.AddElementFieldMapping( "GeneratorRotorLeadsDecisionEntity", "GeneratorRotorLeadsDecisionId", "GeneratorRotorLeadsDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorRotorLeadsDecisionEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorRotorLeadsDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits GeneratorStatorDecisionEntity's mappings</summary>
		private void InitGeneratorStatorDecisionEntityMappings()
		{
			base.AddElementMapping( "GeneratorStatorDecisionEntity", "CIM_ComponentInspectionReports", @"dbo", "GeneratorStatorDecision", 3 );
			base.AddElementFieldMapping( "GeneratorStatorDecisionEntity", "GeneratorStatorDecisionId", "GeneratorStatorDecisionId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "GeneratorStatorDecisionEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "GeneratorStatorDecisionEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits HotItemEntity's mappings</summary>
		private void InitHotItemEntityMappings()
		{
			base.AddElementMapping( "HotItemEntity", "CIM_ComponentInspectionReports", @"dbo", "HotItem", 10 );
			base.AddElementFieldMapping( "HotItemEntity", "HotItemId", "HotItemId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "HotItemEntity", "ComponentInspectionReportTypeId", "ComponentInspectionReportTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "HotItemEntity", "VestasItemNumber", "VestasItemNumber", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "HotItemEntity", "VestasItemName", "VestasItemName", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "HotItemEntity", "ManufacturerName", "ManufacturerName", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "HotItemEntity", "LanguageId", "LanguageId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "HotItemEntity", "Sort", "Sort", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "HotItemEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "HotItemEntity", "Cc", "Cc", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "HotItemEntity", "HotItemDisplay", "HotItemDisplay", true, (int)SqlDbType.NVarChar, 108, 0, 0, false, "", null, typeof(System.String), 9 );
		}
		/// <summary>Inits HotItemAdministratorEntity's mappings</summary>
		private void InitHotItemAdministratorEntityMappings()
		{
			base.AddElementMapping( "HotItemAdministratorEntity", "CIM_ComponentInspectionReports", @"dbo", "HotItemAdministrator", 2 );
			base.AddElementFieldMapping( "HotItemAdministratorEntity", "HotItemAdministratorId", "HotItemAdministratorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "HotItemAdministratorEntity", "Initials", "Initials", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits HousingErrorEntity's mappings</summary>
		private void InitHousingErrorEntityMappings()
		{
			base.AddElementMapping( "HousingErrorEntity", "CIM_ComponentInspectionReports", @"dbo", "HousingError", 5 );
			base.AddElementFieldMapping( "HousingErrorEntity", "HousingErrorId", "HousingErrorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "HousingErrorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "HousingErrorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "HousingErrorEntity", "ParentHousingErrorId", "ParentHousingErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "HousingErrorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits HousingErrorVendorEntity's mappings</summary>
		private void InitHousingErrorVendorEntityMappings()
		{
			base.AddElementMapping( "HousingErrorVendorEntity", "CIM_ComponentInspectionReports", @"dbo", "HousingErrorVendor", 3 );
			base.AddElementFieldMapping( "HousingErrorVendorEntity", "HousingErrorVendorId", "HousingErrorVendorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "HousingErrorVendorEntity", "Name", "Name", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "HousingErrorVendorEntity", "Sort", "Sort", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits InlineFilterEntity's mappings</summary>
		private void InitInlineFilterEntityMappings()
		{
			base.AddElementMapping( "InlineFilterEntity", "CIM_ComponentInspectionReports", @"dbo", "InlineFilter", 5 );
			base.AddElementFieldMapping( "InlineFilterEntity", "InlineFilterId", "InlineFilterId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "InlineFilterEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "InlineFilterEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "InlineFilterEntity", "ParentInlineFilterId", "ParentInlineFilterId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "InlineFilterEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits InvalidNotificationEntity's mappings</summary>
		private void InitInvalidNotificationEntityMappings()
		{
			base.AddElementMapping( "InvalidNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "InvalidNotification", 6 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "InvalidNotificationId", "InvalidNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "Received", "Received", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "Sbuid", "SBUId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "InfoPathFileName", "InfoPathFileName", false, (int)SqlDbType.NChar, 500, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "InvalidNotificationEntity", "SendTo", "SendTo", true, (int)SqlDbType.NChar, 200, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits LocationTypeEntity's mappings</summary>
		private void InitLocationTypeEntityMappings()
		{
			base.AddElementMapping( "LocationTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "LocationType", 5 );
			base.AddElementFieldMapping( "LocationTypeEntity", "LocationTypeId", "LocationTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "LocationTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "LocationTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "LocationTypeEntity", "ParentLocationTypeId", "ParentLocationTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "LocationTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits MagnetPosEntity's mappings</summary>
		private void InitMagnetPosEntityMappings()
		{
			base.AddElementMapping( "MagnetPosEntity", "CIM_ComponentInspectionReports", @"dbo", "MagnetPos", 5 );
			base.AddElementFieldMapping( "MagnetPosEntity", "MagnetPosId", "MagnetPosId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "MagnetPosEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "MagnetPosEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "MagnetPosEntity", "ParentMagnetPosId", "ParentMagnetPosId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "MagnetPosEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits MainBearingErrorLocationEntity's mappings</summary>
		private void InitMainBearingErrorLocationEntityMappings()
		{
			base.AddElementMapping( "MainBearingErrorLocationEntity", "CIM_ComponentInspectionReports", @"dbo", "MainBearingErrorLocation", 5 );
			base.AddElementFieldMapping( "MainBearingErrorLocationEntity", "MainBearingErrorLocationId", "MainBearingErrorLocationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "MainBearingErrorLocationEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "MainBearingErrorLocationEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "MainBearingErrorLocationEntity", "ParentMainBearingErrorLocationId", "ParentMainBearingErrorLocationId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "MainBearingErrorLocationEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits MainBearingManufacturerEntity's mappings</summary>
		private void InitMainBearingManufacturerEntityMappings()
		{
			base.AddElementMapping( "MainBearingManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "MainBearingManufacturer", 5 );
			base.AddElementFieldMapping( "MainBearingManufacturerEntity", "MainBearingManufacturerId", "MainBearingManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "MainBearingManufacturerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "MainBearingManufacturerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "MainBearingManufacturerEntity", "ParentMainBearingManufacturerId", "ParentMainBearingManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "MainBearingManufacturerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits MapBirCirEntity's mappings</summary>
		private void InitMapBirCirEntityMappings()
		{
			base.AddElementMapping( "MapBirCirEntity", "CIM_ComponentInspectionReports", @"dbo", "MapBirCir", 7 );
			base.AddElementFieldMapping( "MapBirCirEntity", "MapBirCirId", "MapBirCirID", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "MapBirCirEntity", "BirDataId", "BirDataID", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "MapBirCirEntity", "CirDataId", "CirDataID", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "MapBirCirEntity", "Master", "Master", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			base.AddElementFieldMapping( "MapBirCirEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "MapBirCirEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "MapBirCirEntity", "Deleted", "Deleted", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
		}
		/// <summary>Inits MechanicalOilPumpEntity's mappings</summary>
		private void InitMechanicalOilPumpEntityMappings()
		{
			base.AddElementMapping( "MechanicalOilPumpEntity", "CIM_ComponentInspectionReports", @"dbo", "MechanicalOilPump", 5 );
			base.AddElementFieldMapping( "MechanicalOilPumpEntity", "MechanicalOilPumpId", "MechanicalOilPumpId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "MechanicalOilPumpEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "MechanicalOilPumpEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "MechanicalOilPumpEntity", "ParentMechanicalOilPumpId", "ParentMechanicalOilPumpId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "MechanicalOilPumpEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits NoiseEntity's mappings</summary>
		private void InitNoiseEntityMappings()
		{
			base.AddElementMapping( "NoiseEntity", "CIM_ComponentInspectionReports", @"dbo", "Noise", 5 );
			base.AddElementFieldMapping( "NoiseEntity", "NoiseId", "NoiseId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "NoiseEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "NoiseEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "NoiseEntity", "ParentNoiseId", "ParentNoiseId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "NoiseEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits OhmUnitEntity's mappings</summary>
		private void InitOhmUnitEntityMappings()
		{
			base.AddElementMapping( "OhmUnitEntity", "CIM_ComponentInspectionReports", @"dbo", "OhmUnit", 7 );
			base.AddElementFieldMapping( "OhmUnitEntity", "OhmUnitId", "OhmUnitId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "OhmUnitEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "OhmUnitEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "OhmUnitEntity", "ParentOhmUnitId", "ParentOhmUnitId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "OhmUnitEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "OhmUnitEntity", "StartVersion", "StartVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "OhmUnitEntity", "EndVersion", "EndVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits OilLevelEntity's mappings</summary>
		private void InitOilLevelEntityMappings()
		{
			base.AddElementMapping( "OilLevelEntity", "CIM_ComponentInspectionReports", @"dbo", "OilLevel", 5 );
			base.AddElementFieldMapping( "OilLevelEntity", "OilLevelId", "OilLevelId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "OilLevelEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "OilLevelEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "OilLevelEntity", "ParentOilLevelId", "ParentOilLevelId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "OilLevelEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits OilTypeEntity's mappings</summary>
		private void InitOilTypeEntityMappings()
		{
			base.AddElementMapping( "OilTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "OilType", 7 );
			base.AddElementFieldMapping( "OilTypeEntity", "OilTypeId", "OilTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "OilTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "OilTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "OilTypeEntity", "ParentOilTypeId", "ParentOilTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "OilTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "OilTypeEntity", "StartVersion", "StartVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			base.AddElementFieldMapping( "OilTypeEntity", "EndVersion", "EndVersion", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits OverallGearboxConditionEntity's mappings</summary>
		private void InitOverallGearboxConditionEntityMappings()
		{
			base.AddElementMapping( "OverallGearboxConditionEntity", "CIM_ComponentInspectionReports", @"dbo", "OverallGearboxCondition", 5 );
			base.AddElementFieldMapping( "OverallGearboxConditionEntity", "OverallGearboxConditionId", "OverallGearboxConditionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "OverallGearboxConditionEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "OverallGearboxConditionEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "OverallGearboxConditionEntity", "ParentOverallGearboxConditionId", "ParentOverallGearboxConditionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "OverallGearboxConditionEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits PartNameEntity's mappings</summary>
		private void InitPartNameEntityMappings()
		{
			base.AddElementMapping( "PartNameEntity", "CIM_ComponentInspectionReports", @"dbo", "tComponentFailureReportNotValidatedField", 2 );
			base.AddElementFieldMapping( "PartNameEntity", "PartNameId", "cComponentFailureReportID", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "PartNameEntity", "Name", "cFieldName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits PdfEntity's mappings</summary>
		private void InitPdfEntityMappings()
		{
			base.AddElementMapping( "PdfEntity", "CIM_ComponentInspectionReports", @"dbo", "PDF", 5 );
			base.AddElementFieldMapping( "PdfEntity", "Pdfid", "PDFId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "PdfEntity", "Pdfdata", "PDFData", false, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 1 );
			base.AddElementFieldMapping( "PdfEntity", "Cirstate", "CIRState", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			base.AddElementFieldMapping( "PdfEntity", "CirtemplateGuid", "CIRTemplateGUID", false, (int)SqlDbType.NChar, 36, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "PdfEntity", "Cirname", "CIRName", false, (int)SqlDbType.NVarChar, 250, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits ReceiptNotificationEntity's mappings</summary>
		private void InitReceiptNotificationEntityMappings()
		{
			base.AddElementMapping( "ReceiptNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "ReceiptNotification", 6 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "ReceiptNotificationId", "ReceiptNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "InfoPathFilename", "InfoPathFilename", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "SendTo", "SendTo", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "ReceiptNotificationEntity", "CirVersion", "CirVersion", true, (int)SqlDbType.Decimal, 0, 1, 10, false, "", null, typeof(System.Decimal), 5 );
		}
		/// <summary>Inits RejectNotificationEntity's mappings</summary>
		private void InitRejectNotificationEntityMappings()
		{
			base.AddElementMapping( "RejectNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "RejectNotification", 10 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "RejectNotificationId", "RejectNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "InfoPathFilename", "InfoPathFilename", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "SendTo", "SendTo", false, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "RejectedBy", "RejectedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "Comment", "Comment", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "Received", "Received", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "Sbuid", "SBUId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "RejectNotificationEntity", "CimcaseNo", "CIMCaseNo", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
		}
		/// <summary>Inits ReportTypeEntity's mappings</summary>
		private void InitReportTypeEntityMappings()
		{
			base.AddElementMapping( "ReportTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "ReportType", 5 );
			base.AddElementFieldMapping( "ReportTypeEntity", "ReportTypeId", "ReportTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ReportTypeEntity", "Name", "Name", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ReportTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ReportTypeEntity", "ParentReportTypeId", "ParentReportTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ReportTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits SbuEntity's mappings</summary>
		private void InitSbuEntityMappings()
		{
			base.AddElementMapping( "SbuEntity", "CIM_ComponentInspectionReports", @"dbo", "SBU", 9 );
			base.AddElementFieldMapping( "SbuEntity", "Sbuid", "SBUId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SbuEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SbuEntity", "ShortName", "ShortName", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SbuEntity", "VpdptId", "VPDptId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "SbuEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "SbuEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "SbuEntity", "Deleted", "Deleted", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			base.AddElementFieldMapping( "SbuEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "SbuEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 8 );
		}
		/// <summary>Inits SbunotificationEntity's mappings</summary>
		private void InitSbunotificationEntityMappings()
		{
			base.AddElementMapping( "SbunotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "SBUNotification", 12 );
			base.AddElementFieldMapping( "SbunotificationEntity", "SbunotificationId", "SBUNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SbunotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "SbunotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "SbunotificationEntity", "EditDate", "EditDate", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "SbunotificationEntity", "State", "State", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "SbunotificationEntity", "ComponentType", "ComponentType", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "SbunotificationEntity", "TurbineMatrixId", "TurbineMatrixId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "SbunotificationEntity", "Sitename", "Sitename", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "SbunotificationEntity", "CountryIsoid", "CountryISOId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "SbunotificationEntity", "Sbuid", "SBUId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "SbunotificationEntity", "CimcaseNo", "CIMCaseNo", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "SbunotificationEntity", "Warning", "Warning", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, "", null, typeof(System.Int16), 11 );
		}
		/// <summary>Inits SburejectNotificationEntity's mappings</summary>
		private void InitSburejectNotificationEntityMappings()
		{
			base.AddElementMapping( "SburejectNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "SBURejectNotification", 8 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "SburejectNotificationId", "SBURejectNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "InfoPathFilename", "InfoPathFilename", false, (int)SqlDbType.NVarChar, 500, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "RejectedBy", "RejectedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "Comment", "Comment", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "Sbuid", "SBUId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "SburejectNotificationEntity", "CimcaseNo", "CIMCaseNo", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
		}
		/// <summary>Inits SearchProfileEntity's mappings</summary>
		private void InitSearchProfileEntityMappings()
		{
			base.AddElementMapping( "SearchProfileEntity", "CIM_ComponentInspectionReports", @"dbo", "SearchProfile", 4 );
			base.AddElementFieldMapping( "SearchProfileEntity", "SearchProfileId", "SearchProfileId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SearchProfileEntity", "UserId", "UserId", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SearchProfileEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SearchProfileEntity", "Public", "Public", false, (int)SqlDbType.Bit, 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits SearchProfileDetailEntity's mappings</summary>
		private void InitSearchProfileDetailEntityMappings()
		{
			base.AddElementMapping( "SearchProfileDetailEntity", "CIM_ComponentInspectionReports", @"dbo", "SearchProfileDetail", 5 );
			base.AddElementFieldMapping( "SearchProfileDetailEntity", "SearchProfileDetailId", "SearchProfileDetailId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SearchProfileDetailEntity", "SearchProfileId", "SearchProfileId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "SearchProfileDetailEntity", "InputId", "InputId", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "SearchProfileDetailEntity", "Value", "Value", false, (int)SqlDbType.NVarChar, 1000, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "SearchProfileDetailEntity", "InputType", "InputType", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits SecondNotificationEntity's mappings</summary>
		private void InitSecondNotificationEntityMappings()
		{
			base.AddElementMapping( "SecondNotificationEntity", "CIM_ComponentInspectionReports", @"dbo", "SecondNotification", 10 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "SecondNotificationId", "SecondNotificationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "ComponentInspectionReportId", "ComponentInspectionReportId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "SendOn", "SendOn", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "ManufacturerId", "ManufacturerID", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "Sbuid", "SBUId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "ComponentType", "ComponentType", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "Cirtemplate", "CIRTemplate", true, (int)SqlDbType.Image, 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 6 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "CimcaseNumber", "CIMCaseNumber", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "TurbineMatrixId", "TurbineMatrixId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "SecondNotificationEntity", "CirDataId", "CirDataId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
		}
		/// <summary>Inits ServiceReportNumberTypeEntity's mappings</summary>
		private void InitServiceReportNumberTypeEntityMappings()
		{
			base.AddElementMapping( "ServiceReportNumberTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "ServiceReportNumberType", 5 );
			base.AddElementFieldMapping( "ServiceReportNumberTypeEntity", "ServiceReportNumberTypeId", "ServiceReportNumberTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ServiceReportNumberTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ServiceReportNumberTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ServiceReportNumberTypeEntity", "ParentServiceReportNumberTypeId", "ParentServiceReportNumberTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ServiceReportNumberTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ShaftErrorEntity's mappings</summary>
		private void InitShaftErrorEntityMappings()
		{
			base.AddElementMapping( "ShaftErrorEntity", "CIM_ComponentInspectionReports", @"dbo", "ShaftError", 5 );
			base.AddElementFieldMapping( "ShaftErrorEntity", "ShaftErrorId", "ShaftErrorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ShaftErrorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ShaftErrorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ShaftErrorEntity", "ParentShaftErrorId", "ParentShaftErrorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ShaftErrorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ShaftErrorVendorEntity's mappings</summary>
		private void InitShaftErrorVendorEntityMappings()
		{
			base.AddElementMapping( "ShaftErrorVendorEntity", "CIM_ComponentInspectionReports", @"dbo", "ShaftErrorVendor", 3 );
			base.AddElementFieldMapping( "ShaftErrorVendorEntity", "ShaftErrorVendorId", "ShaftErrorVendorId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ShaftErrorVendorEntity", "Name", "Name", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ShaftErrorVendorEntity", "Sort", "Sort", true, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits ShaftTypeEntity's mappings</summary>
		private void InitShaftTypeEntityMappings()
		{
			base.AddElementMapping( "ShaftTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "ShaftType", 5 );
			base.AddElementFieldMapping( "ShaftTypeEntity", "ShaftTypeId", "ShaftTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ShaftTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ShaftTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ShaftTypeEntity", "ParentShaftTypeId", "ParentShaftTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ShaftTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits ShrinkElementEntity's mappings</summary>
		private void InitShrinkElementEntityMappings()
		{
			base.AddElementMapping( "ShrinkElementEntity", "CIM_ComponentInspectionReports", @"dbo", "ShrinkElement", 5 );
			base.AddElementFieldMapping( "ShrinkElementEntity", "ShrinkElementId", "ShrinkElementId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "ShrinkElementEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "ShrinkElementEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "ShrinkElementEntity", "ParentShrinkElementId", "ParentShrinkElementId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "ShrinkElementEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits SkiipackFailureCauseEntity's mappings</summary>
		private void InitSkiipackFailureCauseEntityMappings()
		{
			base.AddElementMapping( "SkiipackFailureCauseEntity", "CIM_ComponentInspectionReports", @"dbo", "SkiipackFailureCause", 5 );
			base.AddElementFieldMapping( "SkiipackFailureCauseEntity", "SkiipackFailureCauseId", "SkiipackFailureCauseId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SkiipackFailureCauseEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SkiipackFailureCauseEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "SkiipackFailureCauseEntity", "ParentSkiipackFailureCauseId", "ParentSkiipackFailureCauseId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "SkiipackFailureCauseEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits SurgeArrestorEntity's mappings</summary>
		private void InitSurgeArrestorEntityMappings()
		{
			base.AddElementMapping( "SurgeArrestorEntity", "CIM_ComponentInspectionReports", @"dbo", "SurgeArrestor", 5 );
			base.AddElementFieldMapping( "SurgeArrestorEntity", "SurgeArrestorId", "SurgeArrestorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "SurgeArrestorEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "SurgeArrestorEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "SurgeArrestorEntity", "ParentSurgeArrestorId", "ParentSurgeArrestorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "SurgeArrestorEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits TemplateDynamicTableDefEntity's mappings</summary>
		private void InitTemplateDynamicTableDefEntityMappings()
		{
			base.AddElementMapping( "TemplateDynamicTableDefEntity", "CIM_ComponentInspectionReports", @"dbo", "TemplateDynamicTableDef", 17 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "CimcaseNo", "CIMcaseNo", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "TableHeader", "TableHeader", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "ColHeader1", "ColHeader1", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "ColHeader2", "ColHeader2", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "ColHeader3", "ColHeader3", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "ColHeader4", "ColHeader4", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader1", "RowHeader1", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader2", "RowHeader2", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader3", "RowHeader3", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader4", "RowHeader4", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader5", "RowHeader5", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader6", "RowHeader6", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader7", "RowHeader7", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader8", "RowHeader8", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 14 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader9", "RowHeader9", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "TemplateDynamicTableDefEntity", "RowHeader10", "RowHeader10", true, (int)SqlDbType.VarChar, 50, 0, 0, false, "", null, typeof(System.String), 16 );
		}
		/// <summary>Inits TemplateInfoEntity's mappings</summary>
		private void InitTemplateInfoEntityMappings()
		{
			base.AddElementMapping( "TemplateInfoEntity", "CIM_ComponentInspectionReports", @"dbo", "TemplateInfo", 3 );
			base.AddElementFieldMapping( "TemplateInfoEntity", "Version", "Version", false, (int)SqlDbType.Decimal, 0, 1, 10, false, "", null, typeof(System.Decimal), 0 );
			base.AddElementFieldMapping( "TemplateInfoEntity", "Message", "Message", false, (int)SqlDbType.Text, 2147483647, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TemplateInfoEntity", "Url", "URL", false, (int)SqlDbType.NVarChar, 256, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits ThreeMwGearboxesEntity's mappings</summary>
		private void InitThreeMwGearboxesEntityMappings()
		{
			base.AddElementMapping( "ThreeMwGearboxesEntity", "CIM_ComponentInspectionReports", @"dbo", "3MWGearboxes", 2 );
			base.AddElementFieldMapping( "ThreeMwGearboxesEntity", "Id", "Id", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "ThreeMwGearboxesEntity", "Casenumber", "Casenumber", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
		}
		/// <summary>Inits TowerHeightEntity's mappings</summary>
		private void InitTowerHeightEntityMappings()
		{
			base.AddElementMapping( "TowerHeightEntity", "CIM_ComponentInspectionReports", @"dbo", "TowerHeight", 5 );
			base.AddElementFieldMapping( "TowerHeightEntity", "TowerHeightId", "TowerHeightId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TowerHeightEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TowerHeightEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "TowerHeightEntity", "ParentTowerHeightId", "ParentTowerHeightId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "TowerHeightEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits TowerTypeEntity's mappings</summary>
		private void InitTowerTypeEntityMappings()
		{
			base.AddElementMapping( "TowerTypeEntity", "CIM_ComponentInspectionReports", @"dbo", "TowerType", 5 );
			base.AddElementFieldMapping( "TowerTypeEntity", "TowerTypeId", "TowerTypeId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TowerTypeEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TowerTypeEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "TowerTypeEntity", "ParentTowerTypeId", "ParentTowerTypeId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "TowerTypeEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits TransformerManufacturerEntity's mappings</summary>
		private void InitTransformerManufacturerEntityMappings()
		{
			base.AddElementMapping( "TransformerManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "TransformerManufacturer", 8 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "TransformerManufacturerId", "TransformerManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "ParentTransformerManufacturerId", "ParentTransformerManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "Email", "Email", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "Cc", "Cc", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "TransformerManufacturerEntity", "EmailContactName", "EmailContactName", true, (int)SqlDbType.NVarChar, 200, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits TurbineEntity's mappings</summary>
		private void InitTurbineEntityMappings()
		{
			base.AddElementMapping( "TurbineEntity", "CIM_ComponentInspectionReports", @"dbo", "Turbine", 6 );
			base.AddElementFieldMapping( "TurbineEntity", "TurbineId", "TurbineId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineEntity", "Turbine", "Turbine", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineDataEntity's mappings</summary>
		private void InitTurbineDataEntityMappings()
		{
			base.AddElementMapping( "TurbineDataEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineData", 18 );
			base.AddElementFieldMapping( "TurbineDataEntity", "TurbineDataId", "TurbineDataId", false, (int)SqlDbType.Int, 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			base.AddElementFieldMapping( "TurbineDataEntity", "TurbineId", "TurbineId", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineDataEntity", "TurbineType", "TurbineType", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 2 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Voltage", "Voltage", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Frequency", "Frequency", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 4 );
			base.AddElementFieldMapping( "TurbineDataEntity", "RotorDiameter", "RotorDiameter", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
			base.AddElementFieldMapping( "TurbineDataEntity", "NominalPower", "NominalPower", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 6 );
			base.AddElementFieldMapping( "TurbineDataEntity", "PowerRegulation", "PowerRegulation", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 7 );
			base.AddElementFieldMapping( "TurbineDataEntity", "SmallGenerator", "SmallGenerator", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 8 );
			base.AddElementFieldMapping( "TurbineDataEntity", "TemperatureVariant", "TemperatureVariant", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 9 );
			base.AddElementFieldMapping( "TurbineDataEntity", "MkVersion", "MkVersion", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 10 );
			base.AddElementFieldMapping( "TurbineDataEntity", "OnshoreOffshore", "OnshoreOffshore", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 11 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Manufacturer", "Manufacturer", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 12 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Country", "Country", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Site", "Site", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 14 );
			base.AddElementFieldMapping( "TurbineDataEntity", "LocalTurbineId", "LocalTurbineId", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Created", "Created", false, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 16 );
			base.AddElementFieldMapping( "TurbineDataEntity", "Deleted", "Deleted", true, (int)SqlDbType.DateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 17 );
		}
		/// <summary>Inits TurbineFrequencyEntity's mappings</summary>
		private void InitTurbineFrequencyEntityMappings()
		{
			base.AddElementMapping( "TurbineFrequencyEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineFrequency", 6 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "TurbineFrequencyId", "TurbineFrequencyId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "Frequency", "Frequency", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, "", null, typeof(System.Byte), 1 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineFrequencyEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineManufacturerEntity's mappings</summary>
		private void InitTurbineManufacturerEntityMappings()
		{
			base.AddElementMapping( "TurbineManufacturerEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineManufacturer", 6 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "TurbineManufacturerId", "TurbineManufacturerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "Manufacturer", "Manufacturer", false, (int)SqlDbType.NVarChar, 100, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineManufacturerEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineMarkVersionEntity's mappings</summary>
		private void InitTurbineMarkVersionEntityMappings()
		{
			base.AddElementMapping( "TurbineMarkVersionEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineMarkVersion", 6 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "TurbineMarkVersionId", "TurbineMarkVersionId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "MarkVersion", "MarkVersion", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineMarkVersionEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineMatrixEntity's mappings</summary>
		private void InitTurbineMatrixEntityMappings()
		{
			base.AddElementMapping( "TurbineMatrixEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineMatrix", 18 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineMatrixId", "TurbineMatrixId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineId", "TurbineId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbinePowerRegulationId", "TurbinePowerRegulationId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineRotorDiameterId", "TurbineRotorDiameterId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineNominelPowerId", "TurbineNominelPowerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineVoltageId", "TurbineVoltageId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineFrequencyId", "TurbineFrequencyId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineSmallGeneratorId", "TurbineSmallGeneratorId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineTemperatureVariantId", "TurbineTemperatureVariantId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineMarkVersionId", "TurbineMarkVersionId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbinePlacementId", "TurbinePlacementId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineManufacturerId", "TurbineManufacturerId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 11 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "TurbineOldId", "TurbineOldId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 12 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "Comment", "Comment", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 13 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 14 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 15 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 16 );
			base.AddElementFieldMapping( "TurbineMatrixEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 17 );
		}
		/// <summary>Inits TurbineNominelPowerEntity's mappings</summary>
		private void InitTurbineNominelPowerEntityMappings()
		{
			base.AddElementMapping( "TurbineNominelPowerEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineNominelPower", 6 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "TurbineNominelPowerId", "TurbineNominelPowerId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "NominelPower", "NominelPower", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineNominelPowerEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineOldEntity's mappings</summary>
		private void InitTurbineOldEntityMappings()
		{
			base.AddElementMapping( "TurbineOldEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineOld", 6 );
			base.AddElementFieldMapping( "TurbineOldEntity", "TurbineOldId", "TurbineOldId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineOldEntity", "Turbine", "Turbine", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineOldEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineOldEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineOldEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineOldEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbinePlacementEntity's mappings</summary>
		private void InitTurbinePlacementEntityMappings()
		{
			base.AddElementMapping( "TurbinePlacementEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbinePlacement", 6 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "TurbinePlacementId", "TurbinePlacementId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "Placement", "Placement", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbinePlacementEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbinePowerRegulationEntity's mappings</summary>
		private void InitTurbinePowerRegulationEntityMappings()
		{
			base.AddElementMapping( "TurbinePowerRegulationEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbinePowerRegulation", 6 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "TurbinePowerRegulationId", "TurbinePowerRegulationId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "PowerRegulation", "PowerRegulation", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbinePowerRegulationEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineRotorDiameterEntity's mappings</summary>
		private void InitTurbineRotorDiameterEntityMappings()
		{
			base.AddElementMapping( "TurbineRotorDiameterEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineRotorDiameter", 6 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "TurbineRotorDiameterId", "TurbineRotorDiameterId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "RotorDiameter", "RotorDiameter", false, (int)SqlDbType.Decimal, 0, 2, 5, false, "", null, typeof(System.Decimal), 1 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineRotorDiameterEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineRunStatusEntity's mappings</summary>
		private void InitTurbineRunStatusEntityMappings()
		{
			base.AddElementMapping( "TurbineRunStatusEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineRunStatus", 5 );
			base.AddElementFieldMapping( "TurbineRunStatusEntity", "TurbineRunStatusId", "TurbineRunStatusId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineRunStatusEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineRunStatusEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "TurbineRunStatusEntity", "ParentTurbineRunStatusId", "ParentTurbineRunStatusId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "TurbineRunStatusEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits TurbineSmallGeneratorEntity's mappings</summary>
		private void InitTurbineSmallGeneratorEntityMappings()
		{
			base.AddElementMapping( "TurbineSmallGeneratorEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineSmallGenerator", 6 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "TurbineSmallGeneratorId", "TurbineSmallGeneratorId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "SmallGenerator", "SmallGenerator", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineSmallGeneratorEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineTemperatureVariantEntity's mappings</summary>
		private void InitTurbineTemperatureVariantEntityMappings()
		{
			base.AddElementMapping( "TurbineTemperatureVariantEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineTemperatureVariant", 6 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "TurbineTemperatureVariantId", "TurbineTemperatureVariantId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "TemperatureVariant", "TemperatureVariant", false, (int)SqlDbType.NVarChar, 20, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineTemperatureVariantEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits TurbineVoltageEntity's mappings</summary>
		private void InitTurbineVoltageEntityMappings()
		{
			base.AddElementMapping( "TurbineVoltageEntity", "CIM_ComponentInspectionReports", @"dbo", "TurbineVoltage", 6 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "TurbineVoltageId", "TurbineVoltageId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "Voltage", "Voltage", false, (int)SqlDbType.Int, 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "Created", "Created", false, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "CreatedBy", "CreatedBy", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 3 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "Deleted", "Deleted", true, (int)SqlDbType.SmallDateTime, 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			base.AddElementFieldMapping( "TurbineVoltageEntity", "DeletedBy", "DeletedBy", true, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits VibrationsEntity's mappings</summary>
		private void InitVibrationsEntityMappings()
		{
			base.AddElementMapping( "VibrationsEntity", "CIM_ComponentInspectionReports", @"dbo", "Vibrations", 5 );
			base.AddElementFieldMapping( "VibrationsEntity", "VibrationsId", "VibrationsId", false, (int)SqlDbType.BigInt, 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			base.AddElementFieldMapping( "VibrationsEntity", "Name", "Name", false, (int)SqlDbType.NVarChar, 50, 0, 0, false, "", null, typeof(System.String), 1 );
			base.AddElementFieldMapping( "VibrationsEntity", "LanguageId", "LanguageId", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			base.AddElementFieldMapping( "VibrationsEntity", "ParentVibrationsId", "ParentVibrationsId", true, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			base.AddElementFieldMapping( "VibrationsEntity", "Sort", "Sort", false, (int)SqlDbType.BigInt, 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}

	}
}













