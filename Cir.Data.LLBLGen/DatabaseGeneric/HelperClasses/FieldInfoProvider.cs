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
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>
	/// Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.
	/// </summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal sealed class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion
		
		/// <summary>private ctor to prevent instances of this class.</summary>
		private FieldInfoProviderSingleton()
		{
		}

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			base.InitClass( (154 + 0));
			InitActionOnTransformerEntityInfos();
			InitActionToBeTakenOnGeneratorEntityInfos();
			InitArcDetectionEntityInfos();
			InitBearingDamageCategoryEntityInfos();
			InitBearingErrorEntityInfos();
			InitBearingErrorVendorEntityInfos();
			InitBearingPosEntityInfos();
			InitBearingTypeEntityInfos();
			InitBirDataEntityInfos();
			InitBirReportPlaceholdersEntityInfos();
			InitBirWordDocumentEntityInfos();
			InitBladeColorEntityInfos();
			InitBladeDamagePlacementEntityInfos();
			InitBladeEdgeEntityInfos();
			InitBladeInspectionDataEntityInfos();
			InitBladeLengthEntityInfos();
			InitBladeManufacturerEntityInfos();
			InitBooleanAnswerEntityInfos();
			InitBracketsEntityInfos();
			InitCableConditionEntityInfos();
			InitCimCaseFailureItemsEntityInfos();
			InitCirAttachmentEntityInfos();
			InitCirCommentHistoryEntityInfos();
			InitCirDataEntityInfos();
			InitCirinboxTimestampEntityInfos();
			InitCirInvalidEntityInfos();
			InitCirLogEntityInfos();
			InitCirMailArchiveEntityInfos();
			InitCirMetadataEntityInfos();
			InitCirMetadataLookupEntityInfos();
			InitCirStandardTextsEntityInfos();
			InitCirSystemLogEntityInfos();
			InitCirSystemMonitorEntityInfos();
			InitCirUserEntityInfos();
			InitCirViewEntityInfos();
			InitCirXmlEntityInfos();
			InitClimateEntityInfos();
			InitCoilConditionEntityInfos();
			InitComponentGroupEntityInfos();
			InitComponentInspectionReportEntityInfos();
			InitComponentInspectionReportBladeEntityInfos();
			InitComponentInspectionReportBladeDamageEntityInfos();
			InitComponentInspectionReportBladeRepairRecordEntityInfos();
			InitComponentInspectionReportGearboxEntityInfos();
			InitComponentInspectionReportGeneralEntityInfos();
			InitComponentInspectionReportGeneratorEntityInfos();
			InitComponentInspectionReportMainBearingEntityInfos();
			InitComponentInspectionReportSkiiPEntityInfos();
			InitComponentInspectionReportSkiiPfailedComponentEntityInfos();
			InitComponentInspectionReportSkiiPnewComponentEntityInfos();
			InitComponentInspectionReportStateEntityInfos();
			InitComponentInspectionReportTransformerEntityInfos();
			InitComponentInspectionReportTypeEntityInfos();
			InitComponentUpTowerSolutionEntityInfos();
			InitConnectionBarsEntityInfos();
			InitControllerTypeEntityInfos();
			InitCountryIsoEntityInfos();
			InitCouplingEntityInfos();
			InitDamageEntityInfos();
			InitDamageDecisionEntityInfos();
			InitDebrisGearboxEntityInfos();
			InitDebrisOnMagnetEntityInfos();
			InitDynamicTableInputEntityInfos();
			InitEditHistoryEntityInfos();
			InitElectricalPumpEntityInfos();
			InitFaultCodeAreaEntityInfos();
			InitFaultCodeCauseEntityInfos();
			InitFaultCodeClassificationEntityInfos();
			InitFaultCodeTypeEntityInfos();
			InitFilterBlockTypeEntityInfos();
			InitFirstNotificationEntityInfos();
			InitGearboxDefectCategorizationEntityInfos();
			InitGearboxDefectCategorizationDetailsEntityInfos();
			InitGearboxManufacturerEntityInfos();
			InitGearboxPartTypeEntityInfos();
			InitGearboxRevisionEntityInfos();
			InitGearboxTypeEntityInfos();
			InitGearDamageCategoryEntityInfos();
			InitGearErrorEntityInfos();
			InitGearErrorVendorEntityInfos();
			InitGearTypeEntityInfos();
			InitGenerateCiridEntityInfos();
			InitGeneratorBearingDecisionEntityInfos();
			InitGeneratorComponentDamageEntityInfos();
			InitGeneratorCoverEntityInfos();
			InitGeneratorDefectCategorizationEntityInfos();
			InitGeneratorDefectCategorization2EntityInfos();
			InitGeneratorDefectCategorization2DetailsEntityInfos();
			InitGeneratorDriveEndEntityInfos();
			InitGeneratorManufacturerEntityInfos();
			InitGeneratorMiscDecisionEntityInfos();
			InitGeneratorNonDriveEndEntityInfos();
			InitGeneratorPhaseOutletDecisionEntityInfos();
			InitGeneratorRotorEntityInfos();
			InitGeneratorRotorDecisionEntityInfos();
			InitGeneratorRotorLeadsDecisionEntityInfos();
			InitGeneratorStatorDecisionEntityInfos();
			InitHotItemEntityInfos();
			InitHotItemAdministratorEntityInfos();
			InitHousingErrorEntityInfos();
			InitHousingErrorVendorEntityInfos();
			InitInlineFilterEntityInfos();
			InitInvalidNotificationEntityInfos();
			InitLocationTypeEntityInfos();
			InitMagnetPosEntityInfos();
			InitMainBearingErrorLocationEntityInfos();
			InitMainBearingManufacturerEntityInfos();
			InitMapBirCirEntityInfos();
			InitMechanicalOilPumpEntityInfos();
			InitNoiseEntityInfos();
			InitOhmUnitEntityInfos();
			InitOilLevelEntityInfos();
			InitOilTypeEntityInfos();
			InitOverallGearboxConditionEntityInfos();
			InitPartNameEntityInfos();
			InitPdfEntityInfos();
			InitReceiptNotificationEntityInfos();
			InitRejectNotificationEntityInfos();
			InitReportTypeEntityInfos();
			InitSbuEntityInfos();
			InitSbunotificationEntityInfos();
			InitSburejectNotificationEntityInfos();
			InitSearchProfileEntityInfos();
			InitSearchProfileDetailEntityInfos();
			InitSecondNotificationEntityInfos();
			InitServiceReportNumberTypeEntityInfos();
			InitShaftErrorEntityInfos();
			InitShaftErrorVendorEntityInfos();
			InitShaftTypeEntityInfos();
			InitShrinkElementEntityInfos();
			InitSkiipackFailureCauseEntityInfos();
			InitSurgeArrestorEntityInfos();
			InitTemplateDynamicTableDefEntityInfos();
			InitTemplateInfoEntityInfos();
			InitThreeMwGearboxesEntityInfos();
			InitTowerHeightEntityInfos();
			InitTowerTypeEntityInfos();
			InitTransformerManufacturerEntityInfos();
			InitTurbineEntityInfos();
			InitTurbineDataEntityInfos();
			InitTurbineFrequencyEntityInfos();
			InitTurbineManufacturerEntityInfos();
			InitTurbineMarkVersionEntityInfos();
			InitTurbineMatrixEntityInfos();
			InitTurbineNominelPowerEntityInfos();
			InitTurbineOldEntityInfos();
			InitTurbinePlacementEntityInfos();
			InitTurbinePowerRegulationEntityInfos();
			InitTurbineRotorDiameterEntityInfos();
			InitTurbineRunStatusEntityInfos();
			InitTurbineSmallGeneratorEntityInfos();
			InitTurbineTemperatureVariantEntityInfos();
			InitTurbineVoltageEntityInfos();
			InitVibrationsEntityInfos();

			base.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits ActionOnTransformerEntity's FieldInfo objects</summary>
		private void InitActionOnTransformerEntityInfos()
		{
			base.AddElementFieldInfo("ActionOnTransformerEntity", "ActionOnTransformerId", typeof(System.Int64), true, false, true, false,  (int)ActionOnTransformerFieldIndex.ActionOnTransformerId, 0, 0, 19);
			base.AddElementFieldInfo("ActionOnTransformerEntity", "Name", typeof(System.String), false, false, false, false,  (int)ActionOnTransformerFieldIndex.Name, 100, 0, 0);
			base.AddElementFieldInfo("ActionOnTransformerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ActionOnTransformerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ActionOnTransformerEntity", "ParentActionOnTransformerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ActionOnTransformerFieldIndex.ParentActionOnTransformerId, 0, 0, 19);
			base.AddElementFieldInfo("ActionOnTransformerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ActionOnTransformerFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ActionToBeTakenOnGeneratorEntity's FieldInfo objects</summary>
		private void InitActionToBeTakenOnGeneratorEntityInfos()
		{
			base.AddElementFieldInfo("ActionToBeTakenOnGeneratorEntity", "ActionToBeTakenOnGeneratorId", typeof(System.Int64), true, false, true, false,  (int)ActionToBeTakenOnGeneratorFieldIndex.ActionToBeTakenOnGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("ActionToBeTakenOnGeneratorEntity", "Name", typeof(System.String), false, false, false, false,  (int)ActionToBeTakenOnGeneratorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ActionToBeTakenOnGeneratorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ActionToBeTakenOnGeneratorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ActionToBeTakenOnGeneratorEntity", "ParentActionToBeTakenOnGeneratorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ActionToBeTakenOnGeneratorFieldIndex.ParentActionToBeTakenOnGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("ActionToBeTakenOnGeneratorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ActionToBeTakenOnGeneratorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ArcDetectionEntity's FieldInfo objects</summary>
		private void InitArcDetectionEntityInfos()
		{
			base.AddElementFieldInfo("ArcDetectionEntity", "ArcDetectionId", typeof(System.Int64), true, false, true, false,  (int)ArcDetectionFieldIndex.ArcDetectionId, 0, 0, 19);
			base.AddElementFieldInfo("ArcDetectionEntity", "Name", typeof(System.String), false, false, false, false,  (int)ArcDetectionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ArcDetectionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ArcDetectionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ArcDetectionEntity", "ParentArcDetectionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ArcDetectionFieldIndex.ParentArcDetectionId, 0, 0, 19);
			base.AddElementFieldInfo("ArcDetectionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ArcDetectionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BearingDamageCategoryEntity's FieldInfo objects</summary>
		private void InitBearingDamageCategoryEntityInfos()
		{
			base.AddElementFieldInfo("BearingDamageCategoryEntity", "BearingDamageCategoryId", typeof(System.Int32), true, false, true, false,  (int)BearingDamageCategoryFieldIndex.BearingDamageCategoryId, 0, 0, 10);
			base.AddElementFieldInfo("BearingDamageCategoryEntity", "Name", typeof(System.String), false, false, false, true,  (int)BearingDamageCategoryFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BearingDamageCategoryEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)BearingDamageCategoryFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits BearingErrorEntity's FieldInfo objects</summary>
		private void InitBearingErrorEntityInfos()
		{
			base.AddElementFieldInfo("BearingErrorEntity", "BearingErrorId", typeof(System.Int64), true, false, true, false,  (int)BearingErrorFieldIndex.BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("BearingErrorEntity", "Name", typeof(System.String), false, false, false, false,  (int)BearingErrorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BearingErrorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BearingErrorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BearingErrorEntity", "ParentBearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BearingErrorFieldIndex.ParentBearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("BearingErrorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BearingErrorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BearingErrorVendorEntity's FieldInfo objects</summary>
		private void InitBearingErrorVendorEntityInfos()
		{
			base.AddElementFieldInfo("BearingErrorVendorEntity", "BearingErrorVendorId", typeof(System.Int32), true, false, true, false,  (int)BearingErrorVendorFieldIndex.BearingErrorVendorId, 0, 0, 10);
			base.AddElementFieldInfo("BearingErrorVendorEntity", "Name", typeof(System.String), false, false, false, true,  (int)BearingErrorVendorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BearingErrorVendorEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)BearingErrorVendorFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits BearingPosEntity's FieldInfo objects</summary>
		private void InitBearingPosEntityInfos()
		{
			base.AddElementFieldInfo("BearingPosEntity", "BearingPosId", typeof(System.Int64), true, false, true, false,  (int)BearingPosFieldIndex.BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("BearingPosEntity", "Name", typeof(System.String), false, false, false, false,  (int)BearingPosFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BearingPosEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BearingPosFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BearingPosEntity", "ParentBearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BearingPosFieldIndex.ParentBearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("BearingPosEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BearingPosFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BearingTypeEntity's FieldInfo objects</summary>
		private void InitBearingTypeEntityInfos()
		{
			base.AddElementFieldInfo("BearingTypeEntity", "BearingTypeId", typeof(System.Int64), true, false, true, false,  (int)BearingTypeFieldIndex.BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("BearingTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)BearingTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BearingTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BearingTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BearingTypeEntity", "ParentBearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BearingTypeFieldIndex.ParentBearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("BearingTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BearingTypeFieldIndex.Sort, 0, 0, 19);
            base.AddElementFieldInfo("BearingTypeEntity", "Brand", typeof(System.String), false, false, false, false, (int)BearingTypeFieldIndex.Brand, 50, 0, 0);
        }
		/// <summary>Inits BirDataEntity's FieldInfo objects</summary>
		private void InitBirDataEntityInfos()
		{
			base.AddElementFieldInfo("BirDataEntity", "BirDataId", typeof(System.Int64), true, false, true, false,  (int)BirDataFieldIndex.BirDataId, 0, 0, 19);
			base.AddElementFieldInfo("BirDataEntity", "BirCode", typeof(System.String), false, false, false, false,  (int)BirDataFieldIndex.BirCode, 500, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "RevisionNumber", typeof(System.Int32), false, false, false, false,  (int)BirDataFieldIndex.RevisionNumber, 0, 0, 10);
			base.AddElementFieldInfo("BirDataEntity", "RepairingSolutions", typeof(System.String), false, false, false, false,  (int)BirDataFieldIndex.RepairingSolutions, 4000, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "RawMaterials", typeof(System.String), false, false, false, false,  (int)BirDataFieldIndex.RawMaterials, 4000, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "ConclusionsAndRecommendations", typeof(System.String), false, false, false, false,  (int)BirDataFieldIndex.ConclusionsAndRecommendations, 4000, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "CirIds", typeof(System.String), false, false, false, true,  (int)BirDataFieldIndex.CirIds, 250, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)BirDataFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)BirDataFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "Modified", typeof(System.DateTime), false, false, false, false,  (int)BirDataFieldIndex.Modified, 0, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "ModifiedBy", typeof(System.String), false, false, false, true,  (int)BirDataFieldIndex.ModifiedBy, 50, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)BirDataFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("BirDataEntity", "BladeSerialNos", typeof(System.String), false, false, false, true,  (int)BirDataFieldIndex.BladeSerialNos, 2147483647, 0, 0);
		}
		/// <summary>Inits BirReportPlaceholdersEntity's FieldInfo objects</summary>
		private void InitBirReportPlaceholdersEntityInfos()
		{
			base.AddElementFieldInfo("BirReportPlaceholdersEntity", "BirReportPlaceholderId", typeof(System.Int64), true, false, true, false,  (int)BirReportPlaceholdersFieldIndex.BirReportPlaceholderId, 0, 0, 19);
			base.AddElementFieldInfo("BirReportPlaceholdersEntity", "FieldId", typeof(System.Guid), false, false, false, false,  (int)BirReportPlaceholdersFieldIndex.FieldId, 0, 0, 0);
			base.AddElementFieldInfo("BirReportPlaceholdersEntity", "Placeholder", typeof(System.String), false, false, false, false,  (int)BirReportPlaceholdersFieldIndex.Placeholder, 500, 0, 0);
			base.AddElementFieldInfo("BirReportPlaceholdersEntity", "ComponentType", typeof(System.String), false, false, false, false,  (int)BirReportPlaceholdersFieldIndex.ComponentType, 50, 0, 0);
		}
		/// <summary>Inits BirWordDocumentEntity's FieldInfo objects</summary>
		private void InitBirWordDocumentEntityInfos()
		{
			base.AddElementFieldInfo("BirWordDocumentEntity", "BirWordDocumentId", typeof(System.Int64), true, false, true, false,  (int)BirWordDocumentFieldIndex.BirWordDocumentId, 0, 0, 19);
			base.AddElementFieldInfo("BirWordDocumentEntity", "BirDataId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BirWordDocumentFieldIndex.BirDataId, 0, 0, 19);
			base.AddElementFieldInfo("BirWordDocumentEntity", "WordDocBytes", typeof(System.Byte[]), false, false, false, true,  (int)BirWordDocumentFieldIndex.WordDocBytes, 2147483647, 0, 0);
			base.AddElementFieldInfo("BirWordDocumentEntity", "BirCode", typeof(System.String), false, false, false, true,  (int)BirWordDocumentFieldIndex.BirCode, 500, 0, 0);
		}
		/// <summary>Inits BladeColorEntity's FieldInfo objects</summary>
		private void InitBladeColorEntityInfos()
		{
			base.AddElementFieldInfo("BladeColorEntity", "BladeColorId", typeof(System.Int64), true, false, true, false,  (int)BladeColorFieldIndex.BladeColorId, 0, 0, 19);
			base.AddElementFieldInfo("BladeColorEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeColorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeColorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeColorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeColorEntity", "ParentBladeColorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BladeColorFieldIndex.ParentBladeColorId, 0, 0, 19);
			base.AddElementFieldInfo("BladeColorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeColorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BladeDamagePlacementEntity's FieldInfo objects</summary>
		private void InitBladeDamagePlacementEntityInfos()
		{
			base.AddElementFieldInfo("BladeDamagePlacementEntity", "BladeDamagePlacementId", typeof(System.Int64), true, false, true, false,  (int)BladeDamagePlacementFieldIndex.BladeDamagePlacementId, 0, 0, 19);
			base.AddElementFieldInfo("BladeDamagePlacementEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeDamagePlacementFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeDamagePlacementEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeDamagePlacementFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeDamagePlacementEntity", "ParentBladeDamagePlacementId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BladeDamagePlacementFieldIndex.ParentBladeDamagePlacementId, 0, 0, 19);
			base.AddElementFieldInfo("BladeDamagePlacementEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeDamagePlacementFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BladeEdgeEntity's FieldInfo objects</summary>
		private void InitBladeEdgeEntityInfos()
		{
			base.AddElementFieldInfo("BladeEdgeEntity", "BladeEdgeId", typeof(System.Int64), true, false, true, false,  (int)BladeEdgeFieldIndex.BladeEdgeId, 0, 0, 19);
			base.AddElementFieldInfo("BladeEdgeEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeEdgeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeEdgeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeEdgeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeEdgeEntity", "ParentBladeEdgeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BladeEdgeFieldIndex.ParentBladeEdgeId, 0, 0, 19);
			base.AddElementFieldInfo("BladeEdgeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeEdgeFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("BladeEdgeEntity", "StartVersion", typeof(System.Int32), false, false, false, false,  (int)BladeEdgeFieldIndex.StartVersion, 0, 0, 10);
			base.AddElementFieldInfo("BladeEdgeEntity", "EndVersion", typeof(System.Int32), false, false, false, false,  (int)BladeEdgeFieldIndex.EndVersion, 0, 0, 10);
		}
		/// <summary>Inits BladeInspectionDataEntity's FieldInfo objects</summary>
		private void InitBladeInspectionDataEntityInfos()
		{
			base.AddElementFieldInfo("BladeInspectionDataEntity", "BladeInspectionDataId", typeof(System.Int64), true, false, true, false,  (int)BladeInspectionDataFieldIndex.BladeInspectionDataId, 0, 0, 19);
			base.AddElementFieldInfo("BladeInspectionDataEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeInspectionDataFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeInspectionDataEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeInspectionDataFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeInspectionDataEntity", "ParentBladeInspectionDataId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BladeInspectionDataFieldIndex.ParentBladeInspectionDataId, 0, 0, 19);
			base.AddElementFieldInfo("BladeInspectionDataEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeInspectionDataFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BladeLengthEntity's FieldInfo objects</summary>
		private void InitBladeLengthEntityInfos()
		{
			base.AddElementFieldInfo("BladeLengthEntity", "BladeLengthId", typeof(System.Int64), true, false, true, false,  (int)BladeLengthFieldIndex.BladeLengthId, 0, 0, 19);
			base.AddElementFieldInfo("BladeLengthEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeLengthFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeLengthEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeLengthFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeLengthEntity", "ParentBladeLengthId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BladeLengthFieldIndex.ParentBladeLengthId, 0, 0, 19);
			base.AddElementFieldInfo("BladeLengthEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeLengthFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BladeManufacturerEntity's FieldInfo objects</summary>
		private void InitBladeManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("BladeManufacturerEntity", "BladeManufacturerId", typeof(System.Int64), true, false, true, false,  (int)BladeManufacturerFieldIndex.BladeManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("BladeManufacturerEntity", "Name", typeof(System.String), false, false, false, false,  (int)BladeManufacturerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BladeManufacturerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BladeManufacturerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BladeManufacturerEntity", "ParentBladeManufacturerId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)BladeManufacturerFieldIndex.ParentBladeManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("BladeManufacturerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BladeManufacturerFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("BladeManufacturerEntity", "Email", typeof(System.String), false, false, false, true,  (int)BladeManufacturerFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("BladeManufacturerEntity", "Cc", typeof(System.String), false, false, false, true,  (int)BladeManufacturerFieldIndex.Cc, 50, 0, 0);
			base.AddElementFieldInfo("BladeManufacturerEntity", "EmailContactName", typeof(System.String), false, false, false, true,  (int)BladeManufacturerFieldIndex.EmailContactName, 200, 0, 0);
		}
		/// <summary>Inits BooleanAnswerEntity's FieldInfo objects</summary>
		private void InitBooleanAnswerEntityInfos()
		{
			base.AddElementFieldInfo("BooleanAnswerEntity", "BooleanAnswerId", typeof(System.Int64), true, false, true, false,  (int)BooleanAnswerFieldIndex.BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("BooleanAnswerEntity", "Name", typeof(System.String), false, false, false, false,  (int)BooleanAnswerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BooleanAnswerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BooleanAnswerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BooleanAnswerEntity", "ParentBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BooleanAnswerFieldIndex.ParentBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("BooleanAnswerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BooleanAnswerFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits BracketsEntity's FieldInfo objects</summary>
		private void InitBracketsEntityInfos()
		{
			base.AddElementFieldInfo("BracketsEntity", "BracketsId", typeof(System.Int64), true, false, true, false,  (int)BracketsFieldIndex.BracketsId, 0, 0, 19);
			base.AddElementFieldInfo("BracketsEntity", "Name", typeof(System.String), false, false, false, false,  (int)BracketsFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("BracketsEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)BracketsFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("BracketsEntity", "ParentBracketsId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)BracketsFieldIndex.ParentBracketsId, 0, 0, 19);
			base.AddElementFieldInfo("BracketsEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)BracketsFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits CableConditionEntity's FieldInfo objects</summary>
		private void InitCableConditionEntityInfos()
		{
			base.AddElementFieldInfo("CableConditionEntity", "CableConditionId", typeof(System.Int64), true, false, true, false,  (int)CableConditionFieldIndex.CableConditionId, 0, 0, 19);
			base.AddElementFieldInfo("CableConditionEntity", "Name", typeof(System.String), false, false, false, false,  (int)CableConditionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("CableConditionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)CableConditionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("CableConditionEntity", "ParentCableConditionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)CableConditionFieldIndex.ParentCableConditionId, 0, 0, 19);
			base.AddElementFieldInfo("CableConditionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)CableConditionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits CimCaseFailureItemsEntity's FieldInfo objects</summary>
		private void InitCimCaseFailureItemsEntityInfos()
		{
			base.AddElementFieldInfo("CimCaseFailureItemsEntity", "CaseNo", typeof(System.Int64), false, false, false, false,  (int)CimCaseFailureItemsFieldIndex.CaseNo, 0, 0, 19);
			base.AddElementFieldInfo("CimCaseFailureItemsEntity", "ItemNo", typeof(System.String), false, false, false, false,  (int)CimCaseFailureItemsFieldIndex.ItemNo, 50, 0, 0);
		}
		/// <summary>Inits CirAttachmentEntity's FieldInfo objects</summary>
		private void InitCirAttachmentEntityInfos()
		{
			base.AddElementFieldInfo("CirAttachmentEntity", "CirAttachmentId", typeof(System.Int64), true, false, true, false,  (int)CirAttachmentFieldIndex.CirAttachmentId, 0, 0, 19);
			base.AddElementFieldInfo("CirAttachmentEntity", "CirId", typeof(System.Int64), false, false, false, false,  (int)CirAttachmentFieldIndex.CirId, 0, 0, 19);
			base.AddElementFieldInfo("CirAttachmentEntity", "Filename", typeof(System.String), false, false, false, false,  (int)CirAttachmentFieldIndex.Filename, 256, 0, 0);
			base.AddElementFieldInfo("CirAttachmentEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)CirAttachmentFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirAttachmentEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirAttachmentFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("CirAttachmentEntity", "BinaryData", typeof(System.Byte[]), false, false, false, true,  (int)CirAttachmentFieldIndex.BinaryData, 2147483647, 0, 0);
		}
		/// <summary>Inits CirCommentHistoryEntity's FieldInfo objects</summary>
		private void InitCirCommentHistoryEntityInfos()
		{
			base.AddElementFieldInfo("CirCommentHistoryEntity", "CirCommentHistoryId", typeof(System.Int64), true, false, true, false,  (int)CirCommentHistoryFieldIndex.CirCommentHistoryId, 0, 0, 19);
			base.AddElementFieldInfo("CirCommentHistoryEntity", "CirDataId", typeof(System.Int64), false, true, false, false,  (int)CirCommentHistoryFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirCommentHistoryEntity", "Comment", typeof(System.String), false, false, false, false,  (int)CirCommentHistoryFieldIndex.Comment, 1024, 0, 0);
			base.AddElementFieldInfo("CirCommentHistoryEntity", "Date", typeof(System.DateTime), false, false, false, false,  (int)CirCommentHistoryFieldIndex.Date, 0, 0, 0);
			base.AddElementFieldInfo("CirCommentHistoryEntity", "Initials", typeof(System.String), false, false, false, false,  (int)CirCommentHistoryFieldIndex.Initials, 50, 0, 0);
			base.AddElementFieldInfo("CirCommentHistoryEntity", "Type", typeof(System.Byte), false, false, false, false,  (int)CirCommentHistoryFieldIndex.Type, 0, 0, 3);
		}
		/// <summary>Inits CirDataEntity's FieldInfo objects</summary>
		private void InitCirDataEntityInfos()
		{
			base.AddElementFieldInfo("CirDataEntity", "CirDataId", typeof(System.Int64), true, false, true, false,  (int)CirDataFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirDataEntity", "CirId", typeof(System.Int64), false, false, false, false,  (int)CirDataFieldIndex.CirId, 0, 0, 19);
			base.AddElementFieldInfo("CirDataEntity", "Guid", typeof(System.String), false, false, false, false,  (int)CirDataFieldIndex.Guid, 50, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "State", typeof(System.Byte), false, false, false, false,  (int)CirDataFieldIndex.State, 0, 0, 3);
			base.AddElementFieldInfo("CirDataEntity", "Progress", typeof(System.Byte), false, false, false, false,  (int)CirDataFieldIndex.Progress, 0, 0, 3);
			base.AddElementFieldInfo("CirDataEntity", "Email", typeof(System.String), false, false, false, false,  (int)CirDataFieldIndex.Email, 256, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)CirDataFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirDataFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "Filename", typeof(System.String), false, false, false, false,  (int)CirDataFieldIndex.Filename, 256, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "Modified", typeof(System.DateTime), false, false, false, false,  (int)CirDataFieldIndex.Modified, 0, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "ModifiedBy", typeof(System.String), false, false, false, false,  (int)CirDataFieldIndex.ModifiedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirDataEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)CirDataFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits CirinboxTimestampEntity's FieldInfo objects</summary>
		private void InitCirinboxTimestampEntityInfos()
		{
			base.AddElementFieldInfo("CirinboxTimestampEntity", "CirinboxTimestampId", typeof(System.Int32), true, false, true, false,  (int)CirinboxTimestampFieldIndex.CirinboxTimestampId, 0, 0, 10);
			base.AddElementFieldInfo("CirinboxTimestampEntity", "Timestamp", typeof(System.DateTime), false, false, false, false,  (int)CirinboxTimestampFieldIndex.Timestamp, 0, 0, 0);
			base.AddElementFieldInfo("CirinboxTimestampEntity", "MailSent", typeof(Nullable<System.Int32>), false, false, false, true,  (int)CirinboxTimestampFieldIndex.MailSent, 0, 0, 10);
		}
		/// <summary>Inits CirInvalidEntity's FieldInfo objects</summary>
		private void InitCirInvalidEntityInfos()
		{
			base.AddElementFieldInfo("CirInvalidEntity", "CirInvalidId", typeof(System.Int64), true, false, true, false,  (int)CirInvalidFieldIndex.CirInvalidId, 0, 0, 19);
			base.AddElementFieldInfo("CirInvalidEntity", "Filename", typeof(System.String), false, false, false, false,  (int)CirInvalidFieldIndex.Filename, 256, 0, 0);
			base.AddElementFieldInfo("CirInvalidEntity", "Xml", typeof(System.String), false, false, false, false,  (int)CirInvalidFieldIndex.Xml, 1073741823, 0, 0);
			base.AddElementFieldInfo("CirInvalidEntity", "Error", typeof(System.String), false, false, false, false,  (int)CirInvalidFieldIndex.Error, 1024, 0, 0);
			base.AddElementFieldInfo("CirInvalidEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirInvalidFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("CirInvalidEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)CirInvalidFieldIndex.CreatedBy, 50, 0, 0);
		}
		/// <summary>Inits CirLogEntity's FieldInfo objects</summary>
		private void InitCirLogEntityInfos()
		{
			base.AddElementFieldInfo("CirLogEntity", "CirLogId", typeof(System.Int64), true, false, true, false,  (int)CirLogFieldIndex.CirLogId, 0, 0, 19);
			base.AddElementFieldInfo("CirLogEntity", "CirDataId", typeof(System.Int64), false, false, false, false,  (int)CirLogFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirLogEntity", "Timestamp", typeof(System.DateTime), false, false, false, false,  (int)CirLogFieldIndex.Timestamp, 0, 0, 0);
			base.AddElementFieldInfo("CirLogEntity", "Text", typeof(System.String), false, false, false, false,  (int)CirLogFieldIndex.Text, 1024, 0, 0);
			base.AddElementFieldInfo("CirLogEntity", "Type", typeof(System.Int16), false, false, false, false,  (int)CirLogFieldIndex.Type, 0, 0, 5);
			base.AddElementFieldInfo("CirLogEntity", "Initials", typeof(System.String), false, false, false, false,  (int)CirLogFieldIndex.Initials, 50, 0, 0);
		}
		/// <summary>Inits CirMailArchiveEntity's FieldInfo objects</summary>
		private void InitCirMailArchiveEntityInfos()
		{
			base.AddElementFieldInfo("CirMailArchiveEntity", "CirMailArchiveId", typeof(System.Int64), true, false, true, false,  (int)CirMailArchiveFieldIndex.CirMailArchiveId, 0, 0, 19);
			base.AddElementFieldInfo("CirMailArchiveEntity", "CirDataId", typeof(System.Int64), false, false, false, false,  (int)CirMailArchiveFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirMailArchiveEntity", "Mail", typeof(System.String), false, false, false, false,  (int)CirMailArchiveFieldIndex.Mail, 2147483647, 0, 0);
			base.AddElementFieldInfo("CirMailArchiveEntity", "Type", typeof(System.Int16), false, false, false, false,  (int)CirMailArchiveFieldIndex.Type, 0, 0, 5);
			base.AddElementFieldInfo("CirMailArchiveEntity", "Date", typeof(System.DateTime), false, false, false, false,  (int)CirMailArchiveFieldIndex.Date, 0, 0, 0);
			base.AddElementFieldInfo("CirMailArchiveEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)CirMailArchiveFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits CirMetadataEntity's FieldInfo objects</summary>
		private void InitCirMetadataEntityInfos()
		{
			base.AddElementFieldInfo("CirMetadataEntity", "CirMetadataId", typeof(System.Int64), true, false, true, false,  (int)CirMetadataFieldIndex.CirMetadataId, 0, 0, 19);
			base.AddElementFieldInfo("CirMetadataEntity", "CirDataId", typeof(System.Int64), false, true, false, false,  (int)CirMetadataFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirMetadataEntity", "Metadata", typeof(System.Byte[]), false, false, false, false,  (int)CirMetadataFieldIndex.Metadata, 2147483647, 0, 0);
			base.AddElementFieldInfo("CirMetadataEntity", "TurbineId", typeof(System.String), false, false, false, false,  (int)CirMetadataFieldIndex.TurbineId, 50, 0, 0);
		}
		/// <summary>Inits CirMetadataLookupEntity's FieldInfo objects</summary>
		private void InitCirMetadataLookupEntityInfos()
		{
			base.AddElementFieldInfo("CirMetadataLookupEntity", "CirMetadataLookupId", typeof(System.Int64), true, false, true, false,  (int)CirMetadataLookupFieldIndex.CirMetadataLookupId, 0, 0, 19);
			base.AddElementFieldInfo("CirMetadataLookupEntity", "CirDataId", typeof(System.Int64), false, true, false, false,  (int)CirMetadataLookupFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirMetadataLookupEntity", "FieldId", typeof(System.Int32), false, false, false, false,  (int)CirMetadataLookupFieldIndex.FieldId, 0, 0, 10);
			base.AddElementFieldInfo("CirMetadataLookupEntity", "FieldValue", typeof(System.String), false, false, false, true,  (int)CirMetadataLookupFieldIndex.FieldValue, 100, 0, 0);
			base.AddElementFieldInfo("CirMetadataLookupEntity", "FieldIntegerValue", typeof(Nullable<System.Int32>), false, false, false, true,  (int)CirMetadataLookupFieldIndex.FieldIntegerValue, 0, 0, 10);
		}
		/// <summary>Inits CirStandardTextsEntity's FieldInfo objects</summary>
		private void InitCirStandardTextsEntityInfos()
		{
			base.AddElementFieldInfo("CirStandardTextsEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)CirStandardTextsFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("CirStandardTextsEntity", "Title", typeof(System.String), false, false, false, false,  (int)CirStandardTextsFieldIndex.Title, 500, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "Description", typeof(System.String), false, false, false, false,  (int)CirStandardTextsFieldIndex.Description, 4000, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "ComponentInspectionReportTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)CirStandardTextsFieldIndex.ComponentInspectionReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("CirStandardTextsEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirStandardTextsFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "CreatedBy", typeof(System.String), false, false, false, true,  (int)CirStandardTextsFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "Modified", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)CirStandardTextsFieldIndex.Modified, 0, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "ModifiedBy", typeof(System.String), false, false, false, true,  (int)CirStandardTextsFieldIndex.ModifiedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirStandardTextsEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)CirStandardTextsFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits CirSystemLogEntity's FieldInfo objects</summary>
		private void InitCirSystemLogEntityInfos()
		{
			base.AddElementFieldInfo("CirSystemLogEntity", "CirSystemLogId", typeof(System.Int64), true, false, true, false,  (int)CirSystemLogFieldIndex.CirSystemLogId, 0, 0, 19);
			base.AddElementFieldInfo("CirSystemLogEntity", "Timestamp", typeof(System.DateTime), false, false, false, false,  (int)CirSystemLogFieldIndex.Timestamp, 0, 0, 0);
			base.AddElementFieldInfo("CirSystemLogEntity", "Type", typeof(System.Int16), false, false, false, false,  (int)CirSystemLogFieldIndex.Type, 0, 0, 5);
			base.AddElementFieldInfo("CirSystemLogEntity", "Message", typeof(System.String), false, false, false, false,  (int)CirSystemLogFieldIndex.Message, 256, 0, 0);
			base.AddElementFieldInfo("CirSystemLogEntity", "Details", typeof(System.String), false, false, false, false,  (int)CirSystemLogFieldIndex.Details, 1024, 0, 0);
		}
		/// <summary>Inits CirSystemMonitorEntity's FieldInfo objects</summary>
		private void InitCirSystemMonitorEntityInfos()
		{
			base.AddElementFieldInfo("CirSystemMonitorEntity", "CirSystemMonitorId", typeof(System.Int64), true, false, true, false,  (int)CirSystemMonitorFieldIndex.CirSystemMonitorId, 0, 0, 19);
			base.AddElementFieldInfo("CirSystemMonitorEntity", "LastUpdate", typeof(System.DateTime), false, false, false, false,  (int)CirSystemMonitorFieldIndex.LastUpdate, 0, 0, 0);
			base.AddElementFieldInfo("CirSystemMonitorEntity", "NotificationWarningSent", typeof(System.Boolean), false, false, false, false,  (int)CirSystemMonitorFieldIndex.NotificationWarningSent, 0, 0, 0);
			base.AddElementFieldInfo("CirSystemMonitorEntity", "WatchDogWarningSent", typeof(System.Boolean), false, false, false, false,  (int)CirSystemMonitorFieldIndex.WatchDogWarningSent, 0, 0, 0);
		}
		/// <summary>Inits CirUserEntity's FieldInfo objects</summary>
		private void InitCirUserEntityInfos()
		{
			base.AddElementFieldInfo("CirUserEntity", "CirUserId", typeof(System.Int64), true, false, true, false,  (int)CirUserFieldIndex.CirUserId, 0, 0, 19);
			base.AddElementFieldInfo("CirUserEntity", "Initials", typeof(System.String), false, false, false, false,  (int)CirUserFieldIndex.Initials, 10, 0, 0);
			base.AddElementFieldInfo("CirUserEntity", "UserName", typeof(System.String), false, false, false, false,  (int)CirUserFieldIndex.UserName, 256, 0, 0);
			base.AddElementFieldInfo("CirUserEntity", "PermissionLevel", typeof(System.Int32), false, false, false, false,  (int)CirUserFieldIndex.PermissionLevel, 0, 0, 10);
			base.AddElementFieldInfo("CirUserEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirUserFieldIndex.Created, 0, 0, 0);
		}
		/// <summary>Inits CirViewEntity's FieldInfo objects</summary>
		private void InitCirViewEntityInfos()
		{
			base.AddElementFieldInfo("CirViewEntity", "CirViewId", typeof(System.Int32), true, false, true, false,  (int)CirViewFieldIndex.CirViewId, 0, 0, 10);
			base.AddElementFieldInfo("CirViewEntity", "ViewData", typeof(System.String), false, false, false, false,  (int)CirViewFieldIndex.ViewData, 1073741823, 0, 0);
			base.AddElementFieldInfo("CirViewEntity", "Type", typeof(System.Int16), false, false, false, false,  (int)CirViewFieldIndex.Type, 0, 0, 5);
			base.AddElementFieldInfo("CirViewEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)CirViewFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("CirViewEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)CirViewFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("CirViewEntity", "InspectionApplicable", typeof(System.Boolean), false, false, false, false,  (int)CirViewFieldIndex.InspectionApplicable, 0, 0, 0);
		}
		/// <summary>Inits CirXmlEntity's FieldInfo objects</summary>
		private void InitCirXmlEntityInfos()
		{
			base.AddElementFieldInfo("CirXmlEntity", "CirXmlId", typeof(System.Int64), true, false, true, false,  (int)CirXmlFieldIndex.CirXmlId, 0, 0, 19);
			base.AddElementFieldInfo("CirXmlEntity", "CirDataId", typeof(System.Int64), false, true, false, false,  (int)CirXmlFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("CirXmlEntity", "Xml", typeof(System.String), false, false, false, false,  (int)CirXmlFieldIndex.Xml, 1073741823, 0, 0);
		}
		/// <summary>Inits ClimateEntity's FieldInfo objects</summary>
		private void InitClimateEntityInfos()
		{
			base.AddElementFieldInfo("ClimateEntity", "ClimateId", typeof(System.Int64), true, false, true, false,  (int)ClimateFieldIndex.ClimateId, 0, 0, 19);
			base.AddElementFieldInfo("ClimateEntity", "Name", typeof(System.String), false, false, false, false,  (int)ClimateFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ClimateEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ClimateFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ClimateEntity", "ParentClimateId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ClimateFieldIndex.ParentClimateId, 0, 0, 19);
			base.AddElementFieldInfo("ClimateEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ClimateFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits CoilConditionEntity's FieldInfo objects</summary>
		private void InitCoilConditionEntityInfos()
		{
			base.AddElementFieldInfo("CoilConditionEntity", "CoilConditionId", typeof(System.Int64), true, false, true, false,  (int)CoilConditionFieldIndex.CoilConditionId, 0, 0, 19);
			base.AddElementFieldInfo("CoilConditionEntity", "Name", typeof(System.String), false, false, false, false,  (int)CoilConditionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("CoilConditionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)CoilConditionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("CoilConditionEntity", "ParentCoilConditionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)CoilConditionFieldIndex.ParentCoilConditionId, 0, 0, 19);
			base.AddElementFieldInfo("CoilConditionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)CoilConditionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ComponentGroupEntity's FieldInfo objects</summary>
		private void InitComponentGroupEntityInfos()
		{
			base.AddElementFieldInfo("ComponentGroupEntity", "ComponentGroupId", typeof(System.Int64), true, false, true, false,  (int)ComponentGroupFieldIndex.ComponentGroupId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentGroupEntity", "Name", typeof(System.String), false, false, false, false,  (int)ComponentGroupFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ComponentGroupEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ComponentGroupFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentGroupEntity", "ParentComponentGroupId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentGroupFieldIndex.ParentComponentGroupId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentGroupEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ComponentGroupFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentInspectionReportId", typeof(System.Int64), true, false, false, false,  (int)ComponentInspectionReportFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentInspectionReportTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.ComponentInspectionReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentInspectionReportStateId", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.ComponentInspectionReportStateId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Cirtemplate", typeof(System.Byte[]), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.Cirtemplate, 2147483647, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ReportTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.ReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ReconstructionBooleanAnswerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.ReconstructionBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "CimcaseNumber", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.CimcaseNumber, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ReasonForService", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.ReasonForService, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "TurbineNumber", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.TurbineNumber, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "CountryIsoid", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.CountryIsoid, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "SiteName", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.SiteName, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "TurbineMatrixId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.TurbineMatrixId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "LocationTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.LocationTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "LocalTurbineId", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.LocalTurbineId, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "SecondGeneratorBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportFieldIndex.SecondGeneratorBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "BeforeInspectionTurbineRunStatusId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.BeforeInspectionTurbineRunStatusId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "CommisioningDate", typeof(System.DateTime), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.CommisioningDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "InstallationDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.InstallationDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "FailureDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.FailureDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "InspectionDate", typeof(System.DateTime), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.InspectionDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ServiceReportNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.ServiceReportNumber, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ServiceReportNumberTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.ServiceReportNumberTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ServiceEngineer", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.ServiceEngineer, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "RunHours", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.RunHours, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Generator1Hrs", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.Generator1Hrs, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Generator2Hrs", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.Generator2Hrs, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "TotalProduction", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.TotalProduction, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "AfterInspectionTurbineRunStatusId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.AfterInspectionTurbineRunStatusId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Quantity", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.Quantity, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "AlarmLogNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.AlarmLogNumber, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Description", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.Description, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "DescriptionConsquential", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.DescriptionConsquential, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ConductedBy", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.ConductedBy, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Sbuid", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "CirtemplateGuid", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportFieldIndex.CirtemplateGuid, 36, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "VestasItemNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.VestasItemNumber, 50, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.DeletedBy, 50, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "NotificationNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.NotificationNumber, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "MountedOnMainComponentBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportFieldIndex.MountedOnMainComponentBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentUpTowerSolutionId", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ComponentInspectionReportFieldIndex.ComponentUpTowerSolutionId, 0, 0, 10);
            //New added fields
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentInspectionReportName", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.ComponentInspectionReportName, 2000, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "ComponentInspectionReportVersion", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.ComponentInspectionReportVersion, 20, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "TemplateVersion", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.TemplateVersion, 20, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "SBURecommendation", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.SBURecommendation, 2000, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "InternalComments", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.InternalComments, 2000, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "AdditionalInfo", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.AdditionalInfo, 2000, 0, 0);
            base.AddElementFieldInfo("ComponentInspectionReportEntity", "Brand", typeof(System.String), false, false, false, true, (int)ComponentInspectionReportFieldIndex.Brand, 200, 0, 0);

        }
        /// <summary>Inits ComponentInspectionReportBladeEntity's FieldInfo objects</summary>
        private void InitComponentInspectionReportBladeEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "ComponentInspectionReportBladeId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportBladeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLengthId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeFieldIndex.BladeLengthId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeColorId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeFieldIndex.BladeColorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeSerialNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeFieldIndex.BladeSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladePicturesIncludedBooleanAnswerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeFieldIndex.BladePicturesIncludedBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeOtherSerialNumber1", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber1, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeOtherSerialNumber2", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeOtherSerialNumber2, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeDamageIdentified", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportBladeFieldIndex.BladeDamageIdentified, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeFaultCodeClassificationId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeClassificationId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeFaultCodeCauseId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeCauseId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeFaultCodeTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeFaultCodeAreaId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeFaultCodeAreaId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeClaimRelevantBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsVtNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsVtNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsCalibrationDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsCalibrationDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepairTip", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepairTip, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepairTip", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepairTip, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair3", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair3, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair3", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair3, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair4", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair4, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair4", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair4, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePreRepair5", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePreRepair5, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsLeewardSidePostRepair5", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsLeewardSidePostRepair5, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepairTip", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepairTip, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepairTip", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepairTip, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair3", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair3, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair3", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair3, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair4", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair4, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair4", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair4, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePreRepair5", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePreRepair5, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeLsWindwardSidePostRepair5", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeLsWindwardSidePostRepair5, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeEntity", "BladeInspectionReportDescription", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportBladeFieldIndex.BladeInspectionReportDescription, 5000, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportBladeDamageEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportBladeDamageEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "ComponentInspectionReportBladeDamageId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeDamageId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "ComponentInspectionReportBladeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladeDamagePlacementId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladeDamagePlacementId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladeInspectionDataId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladeInspectionDataId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladeRadius", typeof(System.Double), false, false, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladeRadius, 0, 0, 38);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladeEdgeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladeEdgeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladeDescription", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladeDescription, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "BladePictureNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeDamageFieldIndex.BladePictureNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeDamageEntity", "PictureOrder", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ComponentInspectionReportBladeDamageFieldIndex.PictureOrder, 0, 0, 10);
		}
		/// <summary>Inits ComponentInspectionReportBladeRepairRecordEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportBladeRepairRecordEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "ComponentInspectionReportBladeRepairRecordId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeRepairRecordId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "ComponentInspectionReportBladeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.ComponentInspectionReportBladeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeAmbientTemp", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAmbientTemp, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeHumidity", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHumidity, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeAdditionalDocumentReference", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeAdditionalDocumentReference, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeResinType", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinType, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeResinTypeBatchNumbers", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeBatchNumbers, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeResinTypeExpiryDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinTypeExpiryDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerType", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerType, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerTypeBatchNumbers", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeBatchNumbers, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeHardenerTypeExpiryDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeHardenerTypeExpiryDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeGlassSupplier", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplier, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeGlassSupplierBatchNumbers", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeGlassSupplierBatchNumbers, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeSurfaceMaxTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMaxTemperature, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeSurfaceMinTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeSurfaceMinTemperature, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeResinUsed", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeResinUsed, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladePostCureMaxTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMaxTemperature, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladePostCureMinTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladePostCureMinTemperature, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeTurnOffTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTurnOffTime, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportBladeRepairRecordEntity", "BladeTotalCureTime", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportBladeRepairRecordFieldIndex.BladeTotalCureTime, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportGearboxEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportGearboxEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "ComponentInspectionReportGearboxId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportGearboxId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxRevisionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxRevisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxManufacturerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "OtherGearboxType", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.OtherGearboxType, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxSerialNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOtherManufacturer", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOtherManufacturer, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxLastOilChangeDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxLastOilChangeDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOilTypeId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxMechanicalOilPumpId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxMechanicalOilPumpId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOilLevelId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxRunHours", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxRunHours, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOilTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTemperature, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxProduction", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxProduction, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGeneratorManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGeneratorManufacturerId2", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxElectricalPumpId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxElectricalPumpId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShrinkElementId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShrinkElementSerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementSerialNumber, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxCouplingId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxCouplingId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxFilterBlockTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterBlockTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxInLineFilterId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxInLineFilterId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOffLineFilterId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOffLineFilterId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxSoftwareRelease", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxSoftwareRelease, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation1ShaftTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation1ShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation2ShaftTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation2ShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation3ShaftTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation3ShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsExactLocation4ShaftTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation4ShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage1ShaftErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage1ShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage2ShaftErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage2ShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage3ShaftErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage3ShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxShaftsTypeofDamage4ShaftErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage4ShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation1GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation1GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation2GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation2GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation3GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation3GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation4GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation4GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation5GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation5GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage1GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage1GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage2GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage2GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage3GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage3GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage4GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage4GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage5GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage5GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation1BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation1BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation2BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation2BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation3BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation3BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation4BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation4BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation5BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation5BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition1BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition1BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition2BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition2BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition3BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition3BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition4BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition4BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition5BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition5BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage1BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage1BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage2BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage2BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage3BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage3BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage4BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage4BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage5BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage5BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPlanetStage1HousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage1HousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPlanetStage2HousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage2HousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHelicalStageHousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHelicalStageHousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxFrontPlateHousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxFrontPlateHousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxAuxStageHousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxAuxStageHousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHsstageHousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHsstageHousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxLooseBolts", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxLooseBolts, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBrokenBolts", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBrokenBolts, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDefectDamperElements", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectDamperElements, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTooMuchClearance", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTooMuchClearance, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxCrackedTorqueArm", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxCrackedTorqueArm, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxNeedsToBeAligned", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxNeedsToBeAligned, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing1", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing1, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing2", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing2, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPt100Bearing3", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing3, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOilLevelSensor", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelSensor, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOilPressure", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilPressure, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPt100OilSump", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100OilSump, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxFilterIndicator", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterIndicator, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxImmersionHeater", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxImmersionHeater, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDrainValve", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDrainValve, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxAirBreather", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxAirBreather, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxSightGlass", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxSightGlass, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxChipDetector", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxChipDetector, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxVibrationsId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxVibrationsId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxNoiseId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxNoiseId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDebrisOnMagnetId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisOnMagnetId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDebrisStagesMagnetPosId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisStagesMagnetPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDebrisGearBoxId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisGearBoxId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxMaxTempResetDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxMaxTempResetDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTempBearing1", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing1, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTempBearing2", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing2, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTempBearing3", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing3, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTempOilSump", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTempOilSump, 0, 2, 6);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxLssnrend", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxLssnrend, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxImsnrend", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxImsnrend, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxImsrend", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxImsrend, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHssnrend", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHssnrend, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHssrend", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHssrend, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxPitchTube", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxPitchTube, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxSplitLines", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxSplitLines, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHoseAndPiping", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHoseAndPiping, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxInputShaft", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxInputShaft, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxHsspto", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxHsspto, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxClaimRelevantBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxOverallGearboxConditionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxOverallGearboxConditionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation6GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation6GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation7GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation7GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation8GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation8GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation9GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation9GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation10GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation10GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation11GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation11GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation12GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation12GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation13GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation13GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation14GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation14GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxExactLocation15GearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation15GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage6GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage6GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage7GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage7GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage8GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage8GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage9GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage9GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage10GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage10GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage11GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage11GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage12GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage12GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage13GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage13GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage14GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage14GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxTypeofDamage15GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage15GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision1DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision1DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision2DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision2DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision3DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision3DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision4DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision4DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision5DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision5DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision6DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision6DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision7DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision7DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision8DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision8DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision9DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision9DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision10DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision10DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision11DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision11DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision12DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision12DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision13DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision13DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision14DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision14DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxGearDecision15DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision15DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsLocation6BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation6BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsPosition6BearingPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition6BearingPosId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingsDamage6BearingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage6BearingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision1DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision1DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision2DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision2DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision3DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision3DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision4DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision4DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision5DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision5DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxBearingDecision6DamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision6DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGearboxEntity", "GearboxDefectCategorizationScore", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectCategorizationScore, 10, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportGeneralEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportGeneralEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "ComponentInspectionReportGeneralId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportGeneralId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneralFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralComponentGroupId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentGroupId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralComponentType", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentType, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralComponentManufacturer", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentManufacturer, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralOtherGearboxType", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxType, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralClaimRelevantBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralOtherGearboxManufacturer", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralOtherGearboxManufacturer, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralComponentSerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralComponentSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralGeneratorManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralGeneratorManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralTransformerManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralTransformerManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralGearboxManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralGearboxManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralTowerTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralTowerHeightId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralTowerHeightId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralBlade1SerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade1SerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralBlade2SerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade2SerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralBlade3SerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralBlade3SerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralControllerTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralControllerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralSoftwareRelease", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralSoftwareRelease, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralRamDumpNumber", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralRamDumpNumber, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralVdftrackNumber", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralVdftrackNumber, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralPicturesIncludedBooleanAnswerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralPicturesIncludedBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy1", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy1, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy2", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy2, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy3", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy3, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralInitiatedBy4", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralInitiatedBy4, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted1", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted1, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted2", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted2, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted3", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted3, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralMeasurementsConducted4", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralMeasurementsConducted4, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralExecutedBy1", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy1, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralExecutedBy2", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy2, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralExecutedBy3", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy3, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralExecutedBy4", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralExecutedBy4, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneralEntity", "GeneralPositionOfFailedItem", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneralFieldIndex.GeneralPositionOfFailedItem, 200, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportGeneratorEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportGeneratorEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "ComponentInspectionReportGeneratorId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorManufacturerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorSerialNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "OtherManufacturer", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.OtherManufacturer, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorMaxTemperature", typeof(System.Decimal), false, false, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperature, 0, 2, 5);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorMaxTemperatureResetDate", typeof(System.DateTime), false, false, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorMaxTemperatureResetDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "CouplingId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.CouplingId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "ActionToBeTakenOnGeneratorId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.ActionToBeTakenOnGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorDriveEndId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorNonDriveEndId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorNonDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorRotorId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRotorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorCoverId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorCoverId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "AirToAirCoolerInternalId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerInternalId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "AirToAirCoolerExternalId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.AirToAirCoolerExternalId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorComments", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorComments, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Uground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Uground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Vground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Vground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Wground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Wground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Uv", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Uv, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Uw", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Uw, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Vw", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Vw, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Kground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Kground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Lground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Lground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "Mground", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.Mground, 0, 2, 12);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "UgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.UgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "VgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.VgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "WgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.WgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "UvohmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.UvohmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "UwohmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.UwohmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "VwohmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.VwohmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "KgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.KgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "LgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.LgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "MgroundOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.MgroundOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "U1U2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.U1U2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "V1V2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.V1V2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "W1W2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.W1W2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "K1L1", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.K1L1, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "L1M1", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.L1M1, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "K1M1", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.K1M1, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "K2L2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.K2L2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "L2M2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.L2M2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "K2M2", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.K2M2, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorRewoundLocally", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorRewoundLocally, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportGeneratorEntity", "GeneratorClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportGeneratorFieldIndex.GeneratorClaimRelevantBooleanAnswerId, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportMainBearingEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportMainBearingEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "ComponentInspectionReportMainBearingId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportMainBearingId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingLastLubricationDate", typeof(System.DateTime), false, false, false, false,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLastLubricationDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingTemperature", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTemperature, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingLubricationOilTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationOilTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingGrease", typeof(System.Boolean), false, false, false, false,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingGrease, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingLubricationRunHours", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationRunHours, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingOilTemperature", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingOilTemperature, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingRevision", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRevision, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingErrorLocationId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingErrorLocationId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingSerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingRunHours", typeof(Nullable<System.Int64>), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRunHours, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingMechanicalOilPump", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingMechanicalOilPump, 200, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportMainBearingEntity", "MainBearingClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingClaimRelevantBooleanAnswerId, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportSkiiPEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportSkiiPEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "ComponentInspectionReportSkiiPid", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportSkiiPid, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiPotherDamagedComponentsReplaced", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPotherDamagedComponentsReplaced, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiPcauseId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPcauseId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiPquantityOfFailedModules", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPquantityOfFailedModules, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv521BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv521BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv522BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv522BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv523BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv523BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv524BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv524BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv525BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv525BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP2Mwv526BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv526BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv521BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv521BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv522BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv522BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv523BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv523BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv524xBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524xBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv524yBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524yBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv525xBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525xBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv525yBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525yBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv526xBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526xBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP3Mwv526yBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526yBooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv520BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv520BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv524BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv524BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv525BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv525BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiP850Kwv526BooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv526BooleanAnswerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPEntity", "SkiiPclaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPclaimRelevantBooleanAnswerId, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportSkiiPfailedComponentEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportSkiiPfailedComponentEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPfailedComponentEntity", "ComponentInspectionReportSkiiPfailedComponentId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportSkiiPfailedComponentFieldIndex.ComponentInspectionReportSkiiPfailedComponentId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPfailedComponentEntity", "ComponentInspectionReportSkiiPid", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportSkiiPfailedComponentFieldIndex.ComponentInspectionReportSkiiPid, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentVestasUniqueIdentifier", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPfailedComponentFieldIndex.SkiiPfailedComponentVestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentVestasItemNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPfailedComponentFieldIndex.SkiiPfailedComponentVestasItemNumber, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPfailedComponentEntity", "SkiiPfailedComponentSerialNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPfailedComponentFieldIndex.SkiiPfailedComponentSerialNumber, 2000, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportSkiiPnewComponentEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportSkiiPnewComponentEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPnewComponentEntity", "ComponentInspectionReportSkiiPnewComponentId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportSkiiPnewComponentFieldIndex.ComponentInspectionReportSkiiPnewComponentId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPnewComponentEntity", "ComponentInspectionReportSkiiPid", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportSkiiPnewComponentFieldIndex.ComponentInspectionReportSkiiPid, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentVestasUniqueIdentifier", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPnewComponentFieldIndex.SkiiPnewComponentVestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentVestasItemNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPnewComponentFieldIndex.SkiiPnewComponentVestasItemNumber, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportSkiiPnewComponentEntity", "SkiiPnewComponentSerialNumber", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportSkiiPnewComponentFieldIndex.SkiiPnewComponentSerialNumber, 2000, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportStateEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportStateEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportStateEntity", "ComponentInspectionReportStateId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportStateFieldIndex.ComponentInspectionReportStateId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportStateEntity", "Name", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportStateFieldIndex.Name, 50, 0, 0);
		}
		/// <summary>Inits ComponentInspectionReportTransformerEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportTransformerEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "ComponentInspectionReportTransformerId", typeof(System.Int64), true, false, true, false,  (int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportTransformerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "ComponentInspectionReportId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "VestasUniqueIdentifier", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.VestasUniqueIdentifier, 100, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "TransformerManufacturerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.TransformerManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "TransformerSerialNumber", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.TransformerSerialNumber, 2000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "MaxTemp", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.MaxTemp, 0, 2, 5);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "MaxTempResetDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.MaxTempResetDate, 0, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "ActionOnTransformerId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.ActionOnTransformerId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "HvcoilConditionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.HvcoilConditionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "LvcoilConditionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.LvcoilConditionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "HvcableConditionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.HvcableConditionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "LvcableConditionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.LvcableConditionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "BracketsId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.BracketsId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "TransformerArcDetectionId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.TransformerArcDetectionId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "ClimateId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.ClimateId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "SurgeArrestorId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.SurgeArrestorId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "ConnectionBarsId", typeof(System.Int64), false, true, false, false,  (int)ComponentInspectionReportTransformerFieldIndex.ConnectionBarsId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "Comments", typeof(System.String), false, false, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.Comments, 1000, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportTransformerEntity", "TransformerClaimRelevantBooleanAnswerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportTransformerFieldIndex.TransformerClaimRelevantBooleanAnswerId, 0, 0, 19);
		}
		/// <summary>Inits ComponentInspectionReportTypeEntity's FieldInfo objects</summary>
		private void InitComponentInspectionReportTypeEntityInfos()
		{
			base.AddElementFieldInfo("ComponentInspectionReportTypeEntity", "ComponentInspectionReportTypeId", typeof(System.Int64), true, false, false, false,  (int)ComponentInspectionReportTypeFieldIndex.ComponentInspectionReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ComponentInspectionReportTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ComponentInspectionReportTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTypeEntity", "ParentComponentInspectionReportTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ComponentInspectionReportTypeFieldIndex.ParentComponentInspectionReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ComponentInspectionReportTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ComponentInspectionReportTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ComponentUpTowerSolutionEntity's FieldInfo objects</summary>
		private void InitComponentUpTowerSolutionEntityInfos()
		{
			base.AddElementFieldInfo("ComponentUpTowerSolutionEntity", "ComponentUpTowerSolutionId", typeof(System.Int32), true, false, false, false,  (int)ComponentUpTowerSolutionFieldIndex.ComponentUpTowerSolutionId, 0, 0, 10);
			base.AddElementFieldInfo("ComponentUpTowerSolutionEntity", "Name", typeof(System.String), false, false, false, true,  (int)ComponentUpTowerSolutionFieldIndex.Name, 100, 0, 0);
		}
		/// <summary>Inits ConnectionBarsEntity's FieldInfo objects</summary>
		private void InitConnectionBarsEntityInfos()
		{
			base.AddElementFieldInfo("ConnectionBarsEntity", "ConnectionBarsId", typeof(System.Int64), true, false, true, false,  (int)ConnectionBarsFieldIndex.ConnectionBarsId, 0, 0, 19);
			base.AddElementFieldInfo("ConnectionBarsEntity", "Name", typeof(System.String), false, false, false, false,  (int)ConnectionBarsFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ConnectionBarsEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ConnectionBarsFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ConnectionBarsEntity", "ParentConnectionBarsId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ConnectionBarsFieldIndex.ParentConnectionBarsId, 0, 0, 19);
			base.AddElementFieldInfo("ConnectionBarsEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ConnectionBarsFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ControllerTypeEntity's FieldInfo objects</summary>
		private void InitControllerTypeEntityInfos()
		{
			base.AddElementFieldInfo("ControllerTypeEntity", "ControllerTypeId", typeof(System.Int64), true, false, true, false,  (int)ControllerTypeFieldIndex.ControllerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ControllerTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ControllerTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ControllerTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ControllerTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ControllerTypeEntity", "ParentControllerTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ControllerTypeFieldIndex.ParentControllerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ControllerTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ControllerTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits CountryIsoEntity's FieldInfo objects</summary>
		private void InitCountryIsoEntityInfos()
		{
			base.AddElementFieldInfo("CountryIsoEntity", "CountryIsoid", typeof(System.Int64), true, false, true, false,  (int)CountryIsoFieldIndex.CountryIsoid, 0, 0, 19);
			base.AddElementFieldInfo("CountryIsoEntity", "Name", typeof(System.String), false, false, false, false,  (int)CountryIsoFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("CountryIsoEntity", "ShortName", typeof(System.String), false, false, false, false,  (int)CountryIsoFieldIndex.ShortName, 50, 0, 0);
			base.AddElementFieldInfo("CountryIsoEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)CountryIsoFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("CountryIsoEntity", "ParentCountryIsoid", typeof(Nullable<System.Int64>), false, true, false, true,  (int)CountryIsoFieldIndex.ParentCountryIsoid, 0, 0, 19);
			base.AddElementFieldInfo("CountryIsoEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)CountryIsoFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("CountryIsoEntity", "Sbuid", typeof(Nullable<System.Int64>), false, false, false, true,  (int)CountryIsoFieldIndex.Sbuid, 0, 0, 19);
		}
		/// <summary>Inits CouplingEntity's FieldInfo objects</summary>
		private void InitCouplingEntityInfos()
		{
			base.AddElementFieldInfo("CouplingEntity", "CouplingId", typeof(System.Int64), true, false, true, false,  (int)CouplingFieldIndex.CouplingId, 0, 0, 19);
			base.AddElementFieldInfo("CouplingEntity", "Name", typeof(System.String), false, false, false, false,  (int)CouplingFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("CouplingEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)CouplingFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("CouplingEntity", "ParentCouplingId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)CouplingFieldIndex.ParentCouplingId, 0, 0, 19);
			base.AddElementFieldInfo("CouplingEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)CouplingFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits DamageEntity's FieldInfo objects</summary>
		private void InitDamageEntityInfos()
		{
			base.AddElementFieldInfo("DamageEntity", "DamageId", typeof(System.Int32), true, false, true, false,  (int)DamageFieldIndex.DamageId, 0, 0, 10);
			base.AddElementFieldInfo("DamageEntity", "Name", typeof(System.String), false, false, false, true,  (int)DamageFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("DamageEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)DamageFieldIndex.Sort, 0, 0, 10);
			base.AddElementFieldInfo("DamageEntity", "GearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)DamageFieldIndex.GearErrorId, 0, 0, 19);
		}
		/// <summary>Inits DamageDecisionEntity's FieldInfo objects</summary>
		private void InitDamageDecisionEntityInfos()
		{
			base.AddElementFieldInfo("DamageDecisionEntity", "DamageDecisionId", typeof(System.Int64), true, false, true, false,  (int)DamageDecisionFieldIndex.DamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("DamageDecisionEntity", "Name", typeof(System.String), false, false, false, false,  (int)DamageDecisionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("DamageDecisionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)DamageDecisionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("DamageDecisionEntity", "ParentDamageDecisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)DamageDecisionFieldIndex.ParentDamageDecisionId, 0, 0, 19);
			base.AddElementFieldInfo("DamageDecisionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)DamageDecisionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits DebrisGearboxEntity's FieldInfo objects</summary>
		private void InitDebrisGearboxEntityInfos()
		{
			base.AddElementFieldInfo("DebrisGearboxEntity", "DebrisGearboxId", typeof(System.Int64), true, false, true, false,  (int)DebrisGearboxFieldIndex.DebrisGearboxId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisGearboxEntity", "Name", typeof(System.String), false, false, false, false,  (int)DebrisGearboxFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("DebrisGearboxEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)DebrisGearboxFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisGearboxEntity", "ParentDebrisGearboxId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)DebrisGearboxFieldIndex.ParentDebrisGearboxId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisGearboxEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)DebrisGearboxFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits DebrisOnMagnetEntity's FieldInfo objects</summary>
		private void InitDebrisOnMagnetEntityInfos()
		{
			base.AddElementFieldInfo("DebrisOnMagnetEntity", "DebrisOnMagnetId", typeof(System.Int64), true, false, true, false,  (int)DebrisOnMagnetFieldIndex.DebrisOnMagnetId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisOnMagnetEntity", "Name", typeof(System.String), false, false, false, false,  (int)DebrisOnMagnetFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("DebrisOnMagnetEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)DebrisOnMagnetFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisOnMagnetEntity", "ParentDebrisOnMagnetId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)DebrisOnMagnetFieldIndex.ParentDebrisOnMagnetId, 0, 0, 19);
			base.AddElementFieldInfo("DebrisOnMagnetEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)DebrisOnMagnetFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits DynamicTableInputEntity's FieldInfo objects</summary>
		private void InitDynamicTableInputEntityInfos()
		{
			base.AddElementFieldInfo("DynamicTableInputEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)DynamicTableInputFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("DynamicTableInputEntity", "CirId", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.CirId, 50, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row1Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row1Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row1Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row1Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row1Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row1Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row1Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row1Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row2Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row2Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row2Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row2Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row2Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row2Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row2Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row2Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row3Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row3Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row3Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row3Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row3Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row3Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row3Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row3Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row4Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row4Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row4Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row4Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row4Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row4Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row4Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row4Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row5Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row5Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row5Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row5Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row5Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row5Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row5Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row5Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row6Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row6Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row6Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row6Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row6Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row6Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row6Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row6Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row7Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row7Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row7Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row7Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row7Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row7Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row7Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row7Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row8Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row8Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row8Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row8Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row8Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row8Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row8Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row8Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row9Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row9Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row9Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row9Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row9Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row9Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row9Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row9Col4, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row10Col1", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row10Col1, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row10Col2", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row10Col2, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row10Col3", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row10Col3, 100, 0, 0);
			base.AddElementFieldInfo("DynamicTableInputEntity", "Row10Col4", typeof(System.String), false, false, false, true,  (int)DynamicTableInputFieldIndex.Row10Col4, 100, 0, 0);
		}
		/// <summary>Inits EditHistoryEntity's FieldInfo objects</summary>
		private void InitEditHistoryEntityInfos()
		{
			base.AddElementFieldInfo("EditHistoryEntity", "EditHistoryId", typeof(System.Int64), true, false, true, false,  (int)EditHistoryFieldIndex.EditHistoryId, 0, 0, 19);
			base.AddElementFieldInfo("EditHistoryEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)EditHistoryFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("EditHistoryEntity", "EditInitials", typeof(System.String), false, false, false, false,  (int)EditHistoryFieldIndex.EditInitials, 50, 0, 0);
			base.AddElementFieldInfo("EditHistoryEntity", "EditDate", typeof(System.DateTime), false, false, false, false,  (int)EditHistoryFieldIndex.EditDate, 0, 0, 0);
			base.AddElementFieldInfo("EditHistoryEntity", "EditVersion", typeof(System.Int64), false, false, false, false,  (int)EditHistoryFieldIndex.EditVersion, 0, 0, 19);
			base.AddElementFieldInfo("EditHistoryEntity", "EditReason", typeof(System.String), false, false, false, true,  (int)EditHistoryFieldIndex.EditReason, 512, 0, 0);
		}
		/// <summary>Inits ElectricalPumpEntity's FieldInfo objects</summary>
		private void InitElectricalPumpEntityInfos()
		{
			base.AddElementFieldInfo("ElectricalPumpEntity", "ElectricalPumpId", typeof(System.Int64), true, false, true, false,  (int)ElectricalPumpFieldIndex.ElectricalPumpId, 0, 0, 19);
			base.AddElementFieldInfo("ElectricalPumpEntity", "Name", typeof(System.String), false, false, false, false,  (int)ElectricalPumpFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ElectricalPumpEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ElectricalPumpFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ElectricalPumpEntity", "ParentElectricalPumpId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ElectricalPumpFieldIndex.ParentElectricalPumpId, 0, 0, 19);
			base.AddElementFieldInfo("ElectricalPumpEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ElectricalPumpFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits FaultCodeAreaEntity's FieldInfo objects</summary>
		private void InitFaultCodeAreaEntityInfos()
		{
			base.AddElementFieldInfo("FaultCodeAreaEntity", "FaultCodeAreaId", typeof(System.Int64), true, false, true, false,  (int)FaultCodeAreaFieldIndex.FaultCodeAreaId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "Name", typeof(System.String), false, false, false, false,  (int)FaultCodeAreaFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)FaultCodeAreaFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "ParentFaultCodeAreaId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FaultCodeAreaFieldIndex.ParentFaultCodeAreaId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)FaultCodeAreaFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "StartVersion", typeof(System.Int32), false, false, false, false,  (int)FaultCodeAreaFieldIndex.StartVersion, 0, 0, 10);
			base.AddElementFieldInfo("FaultCodeAreaEntity", "EndVersion", typeof(System.Int32), false, false, false, false,  (int)FaultCodeAreaFieldIndex.EndVersion, 0, 0, 10);
		}
		/// <summary>Inits FaultCodeCauseEntity's FieldInfo objects</summary>
		private void InitFaultCodeCauseEntityInfos()
		{
			base.AddElementFieldInfo("FaultCodeCauseEntity", "FaultCodeCauseId", typeof(System.Int64), true, false, true, false,  (int)FaultCodeCauseFieldIndex.FaultCodeCauseId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeCauseEntity", "Name", typeof(System.String), false, false, false, false,  (int)FaultCodeCauseFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("FaultCodeCauseEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)FaultCodeCauseFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeCauseEntity", "ParentFaultCodeCauseId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FaultCodeCauseFieldIndex.ParentFaultCodeCauseId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeCauseEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)FaultCodeCauseFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits FaultCodeClassificationEntity's FieldInfo objects</summary>
		private void InitFaultCodeClassificationEntityInfos()
		{
			base.AddElementFieldInfo("FaultCodeClassificationEntity", "FaultCodeClassificationId", typeof(System.Int64), true, false, true, false,  (int)FaultCodeClassificationFieldIndex.FaultCodeClassificationId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeClassificationEntity", "Name", typeof(System.String), false, false, false, true,  (int)FaultCodeClassificationFieldIndex.Name, 200, 0, 0);
			base.AddElementFieldInfo("FaultCodeClassificationEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)FaultCodeClassificationFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeClassificationEntity", "ParentFaultCodeClassificationId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FaultCodeClassificationFieldIndex.ParentFaultCodeClassificationId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeClassificationEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)FaultCodeClassificationFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits FaultCodeTypeEntity's FieldInfo objects</summary>
		private void InitFaultCodeTypeEntityInfos()
		{
			base.AddElementFieldInfo("FaultCodeTypeEntity", "FaultCodeTypeId", typeof(System.Int64), true, false, true, false,  (int)FaultCodeTypeFieldIndex.FaultCodeTypeId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)FaultCodeTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("FaultCodeTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)FaultCodeTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeTypeEntity", "ParentFaultCodeTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FaultCodeTypeFieldIndex.ParentFaultCodeTypeId, 0, 0, 19);
			base.AddElementFieldInfo("FaultCodeTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)FaultCodeTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits FilterBlockTypeEntity's FieldInfo objects</summary>
		private void InitFilterBlockTypeEntityInfos()
		{
			base.AddElementFieldInfo("FilterBlockTypeEntity", "FilterBlockTypeId", typeof(System.Int64), true, false, true, false,  (int)FilterBlockTypeFieldIndex.FilterBlockTypeId, 0, 0, 19);
			base.AddElementFieldInfo("FilterBlockTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)FilterBlockTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("FilterBlockTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)FilterBlockTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("FilterBlockTypeEntity", "ParentFilterBlockTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FilterBlockTypeFieldIndex.ParentFilterBlockTypeId, 0, 0, 19);
			base.AddElementFieldInfo("FilterBlockTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)FilterBlockTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits FirstNotificationEntity's FieldInfo objects</summary>
		private void InitFirstNotificationEntityInfos()
		{
			base.AddElementFieldInfo("FirstNotificationEntity", "FirstNotificationId", typeof(System.Int64), true, false, true, false,  (int)FirstNotificationFieldIndex.FirstNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)FirstNotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)FirstNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "Sbuid", typeof(System.Int64), false, true, false, false,  (int)FirstNotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "EditDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)FirstNotificationFieldIndex.EditDate, 0, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "EditInitials", typeof(System.String), false, false, false, true,  (int)FirstNotificationFieldIndex.EditInitials, 50, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "TurbineMatrixId", typeof(System.Int64), false, false, false, false,  (int)FirstNotificationFieldIndex.TurbineMatrixId, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "Sitename", typeof(System.String), false, false, false, true,  (int)FirstNotificationFieldIndex.Sitename, 50, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "CountryIsoid", typeof(System.Int64), false, true, false, false,  (int)FirstNotificationFieldIndex.CountryIsoid, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "ComponentType", typeof(System.String), false, false, false, false,  (int)FirstNotificationFieldIndex.ComponentType, 50, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "ManufacturerId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)FirstNotificationFieldIndex.ManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("FirstNotificationEntity", "SerialNo", typeof(System.String), false, false, false, true,  (int)FirstNotificationFieldIndex.SerialNo, 2000, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "CommisioningDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)FirstNotificationFieldIndex.CommisioningDate, 0, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "FailureDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)FirstNotificationFieldIndex.FailureDate, 0, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "QueuedOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)FirstNotificationFieldIndex.QueuedOn, 0, 0, 0);
			base.AddElementFieldInfo("FirstNotificationEntity", "CirDataId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)FirstNotificationFieldIndex.CirDataId, 0, 0, 19);
		}
		/// <summary>Inits GearboxDefectCategorizationEntity's FieldInfo objects</summary>
		private void InitGearboxDefectCategorizationEntityInfos()
		{
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "GearboxDefectCategorizationId", typeof(System.Int64), true, false, true, false,  (int)GearboxDefectCategorizationFieldIndex.GearboxDefectCategorizationId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "VendorName", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.VendorName, 100, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "GearboxTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxDefectCategorizationFieldIndex.GearboxTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "SerialNumber", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.SerialNumber, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "GearBoxManufacturerId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.GearBoxManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Ratio", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.Ratio, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "OilTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxDefectCategorizationFieldIndex.OilTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Frequency", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.Frequency, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "ComponentInspectionReportGearboxId", typeof(System.Int64), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.ComponentInspectionReportGearboxId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "InspectionDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.InspectionDate, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "InspectedBy", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.InspectedBy, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Email", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "RepairManualNumber", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.RepairManualNumber, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "JobNumber", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.JobNumber, 50, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Timestamp", typeof(System.Byte[]), false, false, true, false,  (int)GearboxDefectCategorizationFieldIndex.Timestamp, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Noise", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.Noise, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "MetalOnMagnet", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.MetalOnMagnet, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "HighTemperature", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.HighTemperature, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Leakage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.Leakage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Painting", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.Painting, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "Others", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.Others, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "None", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.None, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "HssBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.HssBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "ImsBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.ImsBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "LssBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.LssBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "PlanetBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.PlanetBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "OtherBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.OtherBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "NoBearingDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.NoBearingDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "HssToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.HssToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "ImsToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.ImsToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "LssToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.LssToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "PlanetToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.PlanetToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "OtherToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.OtherToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "NoToothDamage", typeof(System.Boolean), false, false, false, false,  (int)GearboxDefectCategorizationFieldIndex.NoToothDamage, 0, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "DetailsOfDamage", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.DetailsOfDamage, 200, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "ServiceHistory", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.ServiceHistory, 2147483647, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "PrimaryFailure", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.PrimaryFailure, 500, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "SecondaryFailure", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.SecondaryFailure, 500, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "ConsequentialDamage", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.ConsequentialDamage, 500, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationEntity", "OtherFindings", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationFieldIndex.OtherFindings, 500, 0, 0);
		}
		/// <summary>Inits GearboxDefectCategorizationDetailsEntity's FieldInfo objects</summary>
		private void InitGearboxDefectCategorizationDetailsEntityInfos()
		{
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "GearboxDefectCategorizationId", typeof(System.Int64), false, true, false, false,  (int)GearboxDefectCategorizationDetailsFieldIndex.GearboxDefectCategorizationId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "PartName", typeof(System.Int32), false, false, false, false,  (int)GearboxDefectCategorizationDetailsFieldIndex.PartName, 0, 0, 10);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "GearboxPartTypeId", typeof(System.Int32), false, false, false, false,  (int)GearboxDefectCategorizationDetailsFieldIndex.GearboxPartTypeId, 0, 0, 10);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "ItemNumber", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.ItemNumber, 100, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "BearingTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.BearingTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "Error1Id", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.Error1Id, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "Error2Id", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.Error2Id, 0, 0, 19);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "Comments", typeof(System.String), false, false, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.Comments, 200, 0, 0);
			base.AddElementFieldInfo("GearboxDefectCategorizationDetailsEntity", "DamageDecisionId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GearboxDefectCategorizationDetailsFieldIndex.DamageDecisionId, 0, 0, 19);
		}
		/// <summary>Inits GearboxManufacturerEntity's FieldInfo objects</summary>
		private void InitGearboxManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("GearboxManufacturerEntity", "GearboxManufacturerId", typeof(System.Int64), true, false, true, false,  (int)GearboxManufacturerFieldIndex.GearboxManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "Name", typeof(System.String), false, false, false, false,  (int)GearboxManufacturerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GearboxManufacturerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "ParentGearboxManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxManufacturerFieldIndex.ParentGearboxManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GearboxManufacturerFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "Email", typeof(System.String), false, false, false, true,  (int)GearboxManufacturerFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "Cc", typeof(System.String), false, false, false, true,  (int)GearboxManufacturerFieldIndex.Cc, 1000, 0, 0);
			base.AddElementFieldInfo("GearboxManufacturerEntity", "EmailContactName", typeof(System.String), false, false, false, true,  (int)GearboxManufacturerFieldIndex.EmailContactName, 200, 0, 0);
		}
		/// <summary>Inits GearboxPartTypeEntity's FieldInfo objects</summary>
		private void InitGearboxPartTypeEntityInfos()
		{
			base.AddElementFieldInfo("GearboxPartTypeEntity", "GearboxPartTypeId", typeof(System.Int32), true, false, true, false,  (int)GearboxPartTypeFieldIndex.GearboxPartTypeId, 0, 0, 10);
			base.AddElementFieldInfo("GearboxPartTypeEntity", "Name", typeof(System.String), false, false, false, true,  (int)GearboxPartTypeFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GearboxPartTypeEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GearboxPartTypeFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GearboxRevisionEntity's FieldInfo objects</summary>
		private void InitGearboxRevisionEntityInfos()
		{
			base.AddElementFieldInfo("GearboxRevisionEntity", "GearboxRevisionId", typeof(System.Int64), true, false, true, false,  (int)GearboxRevisionFieldIndex.GearboxRevisionId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxRevisionEntity", "Name", typeof(System.String), false, false, false, false,  (int)GearboxRevisionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearboxRevisionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GearboxRevisionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxRevisionEntity", "ParentGearboxRevisionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxRevisionFieldIndex.ParentGearboxRevisionId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxRevisionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GearboxRevisionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GearboxTypeEntity's FieldInfo objects</summary>
		private void InitGearboxTypeEntityInfos()
		{
			base.AddElementFieldInfo("GearboxTypeEntity", "GearboxTypeId", typeof(System.Int64), true, false, true, false,  (int)GearboxTypeFieldIndex.GearboxTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)GearboxTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearboxTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GearboxTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxTypeEntity", "ParentGearboxTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxTypeFieldIndex.ParentGearboxTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearboxTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GearboxTypeFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("GearboxTypeEntity", "GearboxManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearboxTypeFieldIndex.GearboxManufacturerId, 0, 0, 19);
		}
		/// <summary>Inits GearDamageCategoryEntity's FieldInfo objects</summary>
		private void InitGearDamageCategoryEntityInfos()
		{
			base.AddElementFieldInfo("GearDamageCategoryEntity", "GearDamageCategoryId", typeof(System.Int32), true, false, true, false,  (int)GearDamageCategoryFieldIndex.GearDamageCategoryId, 0, 0, 10);
			base.AddElementFieldInfo("GearDamageCategoryEntity", "Name", typeof(System.String), false, false, false, true,  (int)GearDamageCategoryFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearDamageCategoryEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GearDamageCategoryFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GearErrorEntity's FieldInfo objects</summary>
		private void InitGearErrorEntityInfos()
		{
			base.AddElementFieldInfo("GearErrorEntity", "GearErrorId", typeof(System.Int64), true, false, true, false,  (int)GearErrorFieldIndex.GearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("GearErrorEntity", "Name", typeof(System.String), false, false, false, false,  (int)GearErrorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearErrorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GearErrorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GearErrorEntity", "ParentGearErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearErrorFieldIndex.ParentGearErrorId, 0, 0, 19);
			base.AddElementFieldInfo("GearErrorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GearErrorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GearErrorVendorEntity's FieldInfo objects</summary>
		private void InitGearErrorVendorEntityInfos()
		{
			base.AddElementFieldInfo("GearErrorVendorEntity", "GearErrorVendorId", typeof(System.Int32), true, false, true, false,  (int)GearErrorVendorFieldIndex.GearErrorVendorId, 0, 0, 10);
			base.AddElementFieldInfo("GearErrorVendorEntity", "Name", typeof(System.String), false, false, false, true,  (int)GearErrorVendorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearErrorVendorEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GearErrorVendorFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GearTypeEntity's FieldInfo objects</summary>
		private void InitGearTypeEntityInfos()
		{
			base.AddElementFieldInfo("GearTypeEntity", "GearTypeId", typeof(System.Int64), true, false, true, false,  (int)GearTypeFieldIndex.GearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)GearTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GearTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GearTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GearTypeEntity", "ParentGearTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GearTypeFieldIndex.ParentGearTypeId, 0, 0, 19);
			base.AddElementFieldInfo("GearTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GearTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GenerateCiridEntity's FieldInfo objects</summary>
		private void InitGenerateCiridEntityInfos()
		{
			base.AddElementFieldInfo("GenerateCiridEntity", "Cirid", typeof(System.Int64), true, false, true, false,  (int)GenerateCiridFieldIndex.Cirid, 0, 0, 19);
		}
		/// <summary>Inits GeneratorBearingDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorBearingDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorBearingDecisionEntity", "GeneratorBearingDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorBearingDecisionFieldIndex.GeneratorBearingDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorBearingDecisionEntity", "Name", typeof(System.String), false, false, false, true,  (int)GeneratorBearingDecisionFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorBearingDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorBearingDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GeneratorComponentDamageEntity's FieldInfo objects</summary>
		private void InitGeneratorComponentDamageEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorComponentDamageEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)GeneratorComponentDamageFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorComponentDamageEntity", "Component", typeof(System.String), false, false, false, false,  (int)GeneratorComponentDamageFieldIndex.Component, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorComponentDamageEntity", "FailureDamage", typeof(System.String), false, false, false, false,  (int)GeneratorComponentDamageFieldIndex.FailureDamage, 50, 0, 0);
		}
		/// <summary>Inits GeneratorCoverEntity's FieldInfo objects</summary>
		private void InitGeneratorCoverEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorCoverEntity", "GeneratorCoverId", typeof(System.Int64), true, false, true, false,  (int)GeneratorCoverFieldIndex.GeneratorCoverId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorCoverEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorCoverFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorCoverEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GeneratorCoverFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorCoverEntity", "ParentGeneratorCoverId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GeneratorCoverFieldIndex.ParentGeneratorCoverId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorCoverEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GeneratorCoverFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GeneratorDefectCategorizationEntity's FieldInfo objects</summary>
		private void InitGeneratorDefectCategorizationEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "GeneratorDefectCategorizationId", typeof(System.Int64), true, false, true, false,  (int)GeneratorDefectCategorizationFieldIndex.GeneratorDefectCategorizationId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "StatorInsulation", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.StatorInsulation, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "StatorInductive", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.StatorInductive, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "StatorVibrations", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.StatorVibrations, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "StatorDecision", typeof(Nullable<System.Int32>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.StatorDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorInsulation", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorInsulation, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorInductive", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorInductive, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorVibrations", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorVibrations, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorPostFailure", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorPostFailure, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorDecision", typeof(Nullable<System.Int32>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorLeadInsulation", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorLeadInsulation, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorLeadConnection", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorLeadConnection, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RotorLeadDecision", typeof(Nullable<System.Int32>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RotorLeadDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "PhaseDamaged", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.PhaseDamaged, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "PhaseDamagedDecision", typeof(Nullable<System.Int32>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.PhaseDamagedDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsBearingFailure", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsBearingFailure, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsInnerRace", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsInnerRace, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsOuterRace", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsOuterRace, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsNoise", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsNoise, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsVibrations", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsVibrations, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsSeal", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsSeal, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "BearingsDecision", typeof(Nullable<System.Int32>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.BearingsDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscBearing", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscBearing, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscBearingDecision", typeof(Nullable<System.Int32>), false, true, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscBearingDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscGenerator", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscGenerator, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscGeneratorDecision", typeof(Nullable<System.Int32>), false, true, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscGeneratorDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscWater", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscWater, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscWaterDecision", typeof(Nullable<System.Int32>), false, true, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscWaterDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscPtsensor", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscPtsensor, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscPtsensorDecision", typeof(Nullable<System.Int32>), false, true, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscPtsensorDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscGrounding", typeof(Nullable<System.Int64>), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscGrounding, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "MiscGroundingDecision", typeof(Nullable<System.Int32>), false, true, false, true,  (int)GeneratorDefectCategorizationFieldIndex.MiscGroundingDecision, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "DefectCategory", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.DefectCategory, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "RepairManualNumber", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorizationFieldIndex.RepairManualNumber, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "ComponentInspectionReportGeneratorId", typeof(System.Int64), false, true, false, false,  (int)GeneratorDefectCategorizationFieldIndex.ComponentInspectionReportGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "Source", typeof(System.String), false, false, false, false,  (int)GeneratorDefectCategorizationFieldIndex.Source, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorizationEntity", "Timestamp", typeof(System.Byte[]), false, false, true, false,  (int)GeneratorDefectCategorizationFieldIndex.Timestamp, 0, 0, 0);
		}
		/// <summary>Inits GeneratorDefectCategorization2Entity's FieldInfo objects</summary>
		private void InitGeneratorDefectCategorization2EntityInfos()
		{
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "GeneratorDefectCategorizationId", typeof(System.Int64), true, false, true, false,  (int)GeneratorDefectCategorization2FieldIndex.GeneratorDefectCategorizationId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "VendorName", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.VendorName, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "GeneratorType", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.GeneratorType, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "Kwtype", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.Kwtype, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "Hz", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.Hz, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "SerialNumber", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.SerialNumber, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "Manufacturer", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.Manufacturer, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "CirId", typeof(System.Int64), false, false, false, false,  (int)GeneratorDefectCategorization2FieldIndex.CirId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "InspectionDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.InspectionDate, 0, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "InspectedBy", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.InspectedBy, 10, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "Email", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.Email, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "RepairManualNumber", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.RepairManualNumber, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "JobNumber", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.JobNumber, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "WindingsType", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.WindingsType, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingManufacturerDe", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerDe, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingTypeDe", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingTypeDe, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingNumberDe", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingNumberDe, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "LubricationTypeDe", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.LubricationTypeDe, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingManufacturerNde", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingManufacturerNde, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingTypeNde", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingTypeNde, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "BearingNumberNde", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.BearingNumberNde, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "LubricationTypeNde", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.LubricationTypeNde, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "PrimaryFailure", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.PrimaryFailure, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "SecondaryFailure", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.SecondaryFailure, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "ConsequentialDamage", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.ConsequentialDamage, 150, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "OtherFindings", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.OtherFindings, 250, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2Entity", "FailureModes", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2FieldIndex.FailureModes, 250, 0, 0);
		}
		/// <summary>Inits GeneratorDefectCategorization2DetailsEntity's FieldInfo objects</summary>
		private void InitGeneratorDefectCategorization2DetailsEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorDefectCategorization2DetailsEntity", "GeneratorDefectCategorization2Id", typeof(System.Int64), true, true, false, false,  (int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorDefectCategorization2Id, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDefectCategorization2DetailsEntity", "GeneratorComponentDamage", typeof(System.Int32), true, true, false, false,  (int)GeneratorDefectCategorization2DetailsFieldIndex.GeneratorComponentDamage, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorDefectCategorization2DetailsEntity", "IsDamage", typeof(System.String), false, false, false, false,  (int)GeneratorDefectCategorization2DetailsFieldIndex.IsDamage, 10, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2DetailsEntity", "Repair", typeof(System.String), false, false, false, true,  (int)GeneratorDefectCategorization2DetailsFieldIndex.Repair, 100, 0, 0);
			base.AddElementFieldInfo("GeneratorDefectCategorization2DetailsEntity", "FailureMode", typeof(System.String), false, false, false, false,  (int)GeneratorDefectCategorization2DetailsFieldIndex.FailureMode, 100, 0, 0);
		}
		/// <summary>Inits GeneratorDriveEndEntity's FieldInfo objects</summary>
		private void InitGeneratorDriveEndEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorDriveEndEntity", "GeneratorDriveEndId", typeof(System.Int64), true, false, true, false,  (int)GeneratorDriveEndFieldIndex.GeneratorDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDriveEndEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorDriveEndFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorDriveEndEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GeneratorDriveEndFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDriveEndEntity", "ParentGeneratorDriveEndId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GeneratorDriveEndFieldIndex.ParentGeneratorDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorDriveEndEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GeneratorDriveEndFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GeneratorManufacturerEntity's FieldInfo objects</summary>
		private void InitGeneratorManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "GeneratorManufacturerId", typeof(System.Int64), true, false, true, false,  (int)GeneratorManufacturerFieldIndex.GeneratorManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorManufacturerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GeneratorManufacturerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "ParentGeneratorManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GeneratorManufacturerFieldIndex.ParentGeneratorManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GeneratorManufacturerFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "Email", typeof(System.String), false, false, false, true,  (int)GeneratorManufacturerFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "Cc", typeof(System.String), false, false, false, true,  (int)GeneratorManufacturerFieldIndex.Cc, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorManufacturerEntity", "EmailContactName", typeof(System.String), false, false, false, true,  (int)GeneratorManufacturerFieldIndex.EmailContactName, 200, 0, 0);
		}
		/// <summary>Inits GeneratorMiscDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorMiscDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorMiscDecisionEntity", "GeneratorMiscDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorMiscDecisionFieldIndex.GeneratorMiscDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorMiscDecisionEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorMiscDecisionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorMiscDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorMiscDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GeneratorNonDriveEndEntity's FieldInfo objects</summary>
		private void InitGeneratorNonDriveEndEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorNonDriveEndEntity", "GeneratorNonDriveEndId", typeof(System.Int64), true, false, true, false,  (int)GeneratorNonDriveEndFieldIndex.GeneratorNonDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorNonDriveEndEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorNonDriveEndFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorNonDriveEndEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GeneratorNonDriveEndFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorNonDriveEndEntity", "ParentGeneratorNonDriveEndId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GeneratorNonDriveEndFieldIndex.ParentGeneratorNonDriveEndId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorNonDriveEndEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GeneratorNonDriveEndFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GeneratorPhaseOutletDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorPhaseOutletDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorPhaseOutletDecisionEntity", "GeneratorPhaseOutletDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorPhaseOutletDecisionFieldIndex.GeneratorPhaseOutletDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorPhaseOutletDecisionEntity", "Name", typeof(System.String), false, false, false, true,  (int)GeneratorPhaseOutletDecisionFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorPhaseOutletDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorPhaseOutletDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GeneratorRotorEntity's FieldInfo objects</summary>
		private void InitGeneratorRotorEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorRotorEntity", "GeneratorRotorId", typeof(System.Int64), true, false, true, false,  (int)GeneratorRotorFieldIndex.GeneratorRotorId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorRotorEntity", "Name", typeof(System.String), false, false, false, false,  (int)GeneratorRotorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("GeneratorRotorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)GeneratorRotorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorRotorEntity", "ParentGeneratorRotorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)GeneratorRotorFieldIndex.ParentGeneratorRotorId, 0, 0, 19);
			base.AddElementFieldInfo("GeneratorRotorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)GeneratorRotorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits GeneratorRotorDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorRotorDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorRotorDecisionEntity", "GeneratorRotorDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorRotorDecisionFieldIndex.GeneratorRotorDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorRotorDecisionEntity", "Name", typeof(System.String), false, false, false, true,  (int)GeneratorRotorDecisionFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorRotorDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorRotorDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GeneratorRotorLeadsDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorRotorLeadsDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorRotorLeadsDecisionEntity", "GeneratorRotorLeadsDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorRotorLeadsDecisionFieldIndex.GeneratorRotorLeadsDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorRotorLeadsDecisionEntity", "Name", typeof(System.String), false, false, false, true,  (int)GeneratorRotorLeadsDecisionFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorRotorLeadsDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorRotorLeadsDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits GeneratorStatorDecisionEntity's FieldInfo objects</summary>
		private void InitGeneratorStatorDecisionEntityInfos()
		{
			base.AddElementFieldInfo("GeneratorStatorDecisionEntity", "GeneratorStatorDecisionId", typeof(System.Int32), true, false, true, false,  (int)GeneratorStatorDecisionFieldIndex.GeneratorStatorDecisionId, 0, 0, 10);
			base.AddElementFieldInfo("GeneratorStatorDecisionEntity", "Name", typeof(System.String), false, false, false, true,  (int)GeneratorStatorDecisionFieldIndex.Name, 20, 0, 0);
			base.AddElementFieldInfo("GeneratorStatorDecisionEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)GeneratorStatorDecisionFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits HotItemEntity's FieldInfo objects</summary>
		private void InitHotItemEntityInfos()
		{
			base.AddElementFieldInfo("HotItemEntity", "HotItemId", typeof(System.Int64), true, false, true, false,  (int)HotItemFieldIndex.HotItemId, 0, 0, 19);
			base.AddElementFieldInfo("HotItemEntity", "ComponentInspectionReportTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)HotItemFieldIndex.ComponentInspectionReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("HotItemEntity", "VestasItemNumber", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.VestasItemNumber, 50, 0, 0);
			base.AddElementFieldInfo("HotItemEntity", "VestasItemName", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.VestasItemName, 50, 0, 0);
			base.AddElementFieldInfo("HotItemEntity", "ManufacturerName", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.ManufacturerName, 50, 0, 0);
			base.AddElementFieldInfo("HotItemEntity", "LanguageId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)HotItemFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("HotItemEntity", "Sort", typeof(Nullable<System.Int64>), false, false, false, true,  (int)HotItemFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("HotItemEntity", "Email", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("HotItemEntity", "Cc", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.Cc, 50, 0, 0);
			base.AddElementFieldInfo("HotItemEntity", "HotItemDisplay", typeof(System.String), false, false, false, true,  (int)HotItemFieldIndex.HotItemDisplay, 108, 0, 0);
		}
		/// <summary>Inits HotItemAdministratorEntity's FieldInfo objects</summary>
		private void InitHotItemAdministratorEntityInfos()
		{
			base.AddElementFieldInfo("HotItemAdministratorEntity", "HotItemAdministratorId", typeof(System.Int32), false, false, true, false,  (int)HotItemAdministratorFieldIndex.HotItemAdministratorId, 0, 0, 10);
			base.AddElementFieldInfo("HotItemAdministratorEntity", "Initials", typeof(System.String), false, false, false, false,  (int)HotItemAdministratorFieldIndex.Initials, 20, 0, 0);
		}
		/// <summary>Inits HousingErrorEntity's FieldInfo objects</summary>
		private void InitHousingErrorEntityInfos()
		{
			base.AddElementFieldInfo("HousingErrorEntity", "HousingErrorId", typeof(System.Int64), true, false, true, false,  (int)HousingErrorFieldIndex.HousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("HousingErrorEntity", "Name", typeof(System.String), false, false, false, false,  (int)HousingErrorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("HousingErrorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)HousingErrorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("HousingErrorEntity", "ParentHousingErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)HousingErrorFieldIndex.ParentHousingErrorId, 0, 0, 19);
			base.AddElementFieldInfo("HousingErrorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)HousingErrorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits HousingErrorVendorEntity's FieldInfo objects</summary>
		private void InitHousingErrorVendorEntityInfos()
		{
			base.AddElementFieldInfo("HousingErrorVendorEntity", "HousingErrorVendorId", typeof(System.Int32), true, false, true, false,  (int)HousingErrorVendorFieldIndex.HousingErrorVendorId, 0, 0, 10);
			base.AddElementFieldInfo("HousingErrorVendorEntity", "Name", typeof(System.String), false, false, false, true,  (int)HousingErrorVendorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("HousingErrorVendorEntity", "Sort", typeof(System.Int32), false, false, false, false,  (int)HousingErrorVendorFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits InlineFilterEntity's FieldInfo objects</summary>
		private void InitInlineFilterEntityInfos()
		{
			base.AddElementFieldInfo("InlineFilterEntity", "InlineFilterId", typeof(System.Int64), true, false, true, false,  (int)InlineFilterFieldIndex.InlineFilterId, 0, 0, 19);
			base.AddElementFieldInfo("InlineFilterEntity", "Name", typeof(System.String), false, false, false, false,  (int)InlineFilterFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("InlineFilterEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)InlineFilterFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("InlineFilterEntity", "ParentInlineFilterId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)InlineFilterFieldIndex.ParentInlineFilterId, 0, 0, 19);
			base.AddElementFieldInfo("InlineFilterEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)InlineFilterFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits InvalidNotificationEntity's FieldInfo objects</summary>
		private void InitInvalidNotificationEntityInfos()
		{
			base.AddElementFieldInfo("InvalidNotificationEntity", "InvalidNotificationId", typeof(System.Int64), false, false, true, false,  (int)InvalidNotificationFieldIndex.InvalidNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("InvalidNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)InvalidNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("InvalidNotificationEntity", "Received", typeof(System.DateTime), false, false, false, false,  (int)InvalidNotificationFieldIndex.Received, 0, 0, 0);
			base.AddElementFieldInfo("InvalidNotificationEntity", "Sbuid", typeof(Nullable<System.Int64>), false, true, false, true,  (int)InvalidNotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("InvalidNotificationEntity", "InfoPathFileName", typeof(System.String), false, false, false, false,  (int)InvalidNotificationFieldIndex.InfoPathFileName, 500, 0, 0);
			base.AddElementFieldInfo("InvalidNotificationEntity", "SendTo", typeof(System.String), false, false, false, true,  (int)InvalidNotificationFieldIndex.SendTo, 200, 0, 0);
		}
		/// <summary>Inits LocationTypeEntity's FieldInfo objects</summary>
		private void InitLocationTypeEntityInfos()
		{
			base.AddElementFieldInfo("LocationTypeEntity", "LocationTypeId", typeof(System.Int64), true, false, true, false,  (int)LocationTypeFieldIndex.LocationTypeId, 0, 0, 19);
			base.AddElementFieldInfo("LocationTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)LocationTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("LocationTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)LocationTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("LocationTypeEntity", "ParentLocationTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)LocationTypeFieldIndex.ParentLocationTypeId, 0, 0, 19);
			base.AddElementFieldInfo("LocationTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)LocationTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits MagnetPosEntity's FieldInfo objects</summary>
		private void InitMagnetPosEntityInfos()
		{
			base.AddElementFieldInfo("MagnetPosEntity", "MagnetPosId", typeof(System.Int64), true, false, true, false,  (int)MagnetPosFieldIndex.MagnetPosId, 0, 0, 19);
			base.AddElementFieldInfo("MagnetPosEntity", "Name", typeof(System.String), false, false, false, false,  (int)MagnetPosFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("MagnetPosEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)MagnetPosFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("MagnetPosEntity", "ParentMagnetPosId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)MagnetPosFieldIndex.ParentMagnetPosId, 0, 0, 19);
			base.AddElementFieldInfo("MagnetPosEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)MagnetPosFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits MainBearingErrorLocationEntity's FieldInfo objects</summary>
		private void InitMainBearingErrorLocationEntityInfos()
		{
			base.AddElementFieldInfo("MainBearingErrorLocationEntity", "MainBearingErrorLocationId", typeof(System.Int64), true, false, true, false,  (int)MainBearingErrorLocationFieldIndex.MainBearingErrorLocationId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingErrorLocationEntity", "Name", typeof(System.String), false, false, false, false,  (int)MainBearingErrorLocationFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("MainBearingErrorLocationEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)MainBearingErrorLocationFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingErrorLocationEntity", "ParentMainBearingErrorLocationId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)MainBearingErrorLocationFieldIndex.ParentMainBearingErrorLocationId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingErrorLocationEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)MainBearingErrorLocationFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits MainBearingManufacturerEntity's FieldInfo objects</summary>
		private void InitMainBearingManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("MainBearingManufacturerEntity", "MainBearingManufacturerId", typeof(System.Int64), true, false, true, false,  (int)MainBearingManufacturerFieldIndex.MainBearingManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingManufacturerEntity", "Name", typeof(System.String), false, false, false, false,  (int)MainBearingManufacturerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("MainBearingManufacturerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)MainBearingManufacturerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingManufacturerEntity", "ParentMainBearingManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)MainBearingManufacturerFieldIndex.ParentMainBearingManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("MainBearingManufacturerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)MainBearingManufacturerFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits MapBirCirEntity's FieldInfo objects</summary>
		private void InitMapBirCirEntityInfos()
		{
			base.AddElementFieldInfo("MapBirCirEntity", "MapBirCirId", typeof(System.Int64), true, false, true, false,  (int)MapBirCirFieldIndex.MapBirCirId, 0, 0, 19);
			base.AddElementFieldInfo("MapBirCirEntity", "BirDataId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)MapBirCirFieldIndex.BirDataId, 0, 0, 19);
			base.AddElementFieldInfo("MapBirCirEntity", "CirDataId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)MapBirCirFieldIndex.CirDataId, 0, 0, 19);
			base.AddElementFieldInfo("MapBirCirEntity", "Master", typeof(System.Boolean), false, false, false, false,  (int)MapBirCirFieldIndex.Master, 0, 0, 0);
			base.AddElementFieldInfo("MapBirCirEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)MapBirCirFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("MapBirCirEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)MapBirCirFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("MapBirCirEntity", "Deleted", typeof(System.Boolean), false, false, false, false,  (int)MapBirCirFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits MechanicalOilPumpEntity's FieldInfo objects</summary>
		private void InitMechanicalOilPumpEntityInfos()
		{
			base.AddElementFieldInfo("MechanicalOilPumpEntity", "MechanicalOilPumpId", typeof(System.Int64), true, false, true, false,  (int)MechanicalOilPumpFieldIndex.MechanicalOilPumpId, 0, 0, 19);
			base.AddElementFieldInfo("MechanicalOilPumpEntity", "Name", typeof(System.String), false, false, false, false,  (int)MechanicalOilPumpFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("MechanicalOilPumpEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)MechanicalOilPumpFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("MechanicalOilPumpEntity", "ParentMechanicalOilPumpId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)MechanicalOilPumpFieldIndex.ParentMechanicalOilPumpId, 0, 0, 19);
			base.AddElementFieldInfo("MechanicalOilPumpEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)MechanicalOilPumpFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits NoiseEntity's FieldInfo objects</summary>
		private void InitNoiseEntityInfos()
		{
			base.AddElementFieldInfo("NoiseEntity", "NoiseId", typeof(System.Int64), true, false, true, false,  (int)NoiseFieldIndex.NoiseId, 0, 0, 19);
			base.AddElementFieldInfo("NoiseEntity", "Name", typeof(System.String), false, false, false, false,  (int)NoiseFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("NoiseEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)NoiseFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("NoiseEntity", "ParentNoiseId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)NoiseFieldIndex.ParentNoiseId, 0, 0, 19);
			base.AddElementFieldInfo("NoiseEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)NoiseFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits OhmUnitEntity's FieldInfo objects</summary>
		private void InitOhmUnitEntityInfos()
		{
			base.AddElementFieldInfo("OhmUnitEntity", "OhmUnitId", typeof(System.Int64), true, false, true, false,  (int)OhmUnitFieldIndex.OhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("OhmUnitEntity", "Name", typeof(System.String), false, false, false, false,  (int)OhmUnitFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("OhmUnitEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)OhmUnitFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("OhmUnitEntity", "ParentOhmUnitId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)OhmUnitFieldIndex.ParentOhmUnitId, 0, 0, 19);
			base.AddElementFieldInfo("OhmUnitEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)OhmUnitFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("OhmUnitEntity", "StartVersion", typeof(System.Int32), false, false, false, false,  (int)OhmUnitFieldIndex.StartVersion, 0, 0, 10);
			base.AddElementFieldInfo("OhmUnitEntity", "EndVersion", typeof(System.Int32), false, false, false, false,  (int)OhmUnitFieldIndex.EndVersion, 0, 0, 10);
		}
		/// <summary>Inits OilLevelEntity's FieldInfo objects</summary>
		private void InitOilLevelEntityInfos()
		{
			base.AddElementFieldInfo("OilLevelEntity", "OilLevelId", typeof(System.Int64), true, false, true, false,  (int)OilLevelFieldIndex.OilLevelId, 0, 0, 19);
			base.AddElementFieldInfo("OilLevelEntity", "Name", typeof(System.String), false, false, false, false,  (int)OilLevelFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("OilLevelEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)OilLevelFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("OilLevelEntity", "ParentOilLevelId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)OilLevelFieldIndex.ParentOilLevelId, 0, 0, 19);
			base.AddElementFieldInfo("OilLevelEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)OilLevelFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits OilTypeEntity's FieldInfo objects</summary>
		private void InitOilTypeEntityInfos()
		{
			base.AddElementFieldInfo("OilTypeEntity", "OilTypeId", typeof(System.Int64), true, false, true, false,  (int)OilTypeFieldIndex.OilTypeId, 0, 0, 19);
			base.AddElementFieldInfo("OilTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)OilTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("OilTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)OilTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("OilTypeEntity", "ParentOilTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)OilTypeFieldIndex.ParentOilTypeId, 0, 0, 19);
			base.AddElementFieldInfo("OilTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)OilTypeFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("OilTypeEntity", "StartVersion", typeof(System.Int32), false, false, false, false,  (int)OilTypeFieldIndex.StartVersion, 0, 0, 10);
			base.AddElementFieldInfo("OilTypeEntity", "EndVersion", typeof(System.Int32), false, false, false, false,  (int)OilTypeFieldIndex.EndVersion, 0, 0, 10);
		}
		/// <summary>Inits OverallGearboxConditionEntity's FieldInfo objects</summary>
		private void InitOverallGearboxConditionEntityInfos()
		{
			base.AddElementFieldInfo("OverallGearboxConditionEntity", "OverallGearboxConditionId", typeof(System.Int64), true, false, true, false,  (int)OverallGearboxConditionFieldIndex.OverallGearboxConditionId, 0, 0, 19);
			base.AddElementFieldInfo("OverallGearboxConditionEntity", "Name", typeof(System.String), false, false, false, false,  (int)OverallGearboxConditionFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("OverallGearboxConditionEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)OverallGearboxConditionFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("OverallGearboxConditionEntity", "ParentOverallGearboxConditionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)OverallGearboxConditionFieldIndex.ParentOverallGearboxConditionId, 0, 0, 19);
			base.AddElementFieldInfo("OverallGearboxConditionEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)OverallGearboxConditionFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits PartNameEntity's FieldInfo objects</summary>
		private void InitPartNameEntityInfos()
		{
			base.AddElementFieldInfo("PartNameEntity", "PartNameId", typeof(System.Int32), true, false, false, false,  (int)PartNameFieldIndex.PartNameId, 0, 0, 10);
			base.AddElementFieldInfo("PartNameEntity", "Name", typeof(System.String), true, false, false, false,  (int)PartNameFieldIndex.Name, 50, 0, 0);
		}
		/// <summary>Inits PdfEntity's FieldInfo objects</summary>
		private void InitPdfEntityInfos()
		{
			base.AddElementFieldInfo("PdfEntity", "Pdfid", typeof(System.Int64), true, false, true, false,  (int)PdfFieldIndex.Pdfid, 0, 0, 19);
			base.AddElementFieldInfo("PdfEntity", "Pdfdata", typeof(System.Byte[]), false, false, false, false,  (int)PdfFieldIndex.Pdfdata, 2147483647, 0, 0);
			base.AddElementFieldInfo("PdfEntity", "Cirstate", typeof(System.Int32), false, false, false, false,  (int)PdfFieldIndex.Cirstate, 0, 0, 10);
			base.AddElementFieldInfo("PdfEntity", "CirtemplateGuid", typeof(System.String), false, false, false, false,  (int)PdfFieldIndex.CirtemplateGuid, 36, 0, 0);
			base.AddElementFieldInfo("PdfEntity", "Cirname", typeof(System.String), false, false, false, false,  (int)PdfFieldIndex.Cirname, 250, 0, 0);
		}
		/// <summary>Inits ReceiptNotificationEntity's FieldInfo objects</summary>
		private void InitReceiptNotificationEntityInfos()
		{
			base.AddElementFieldInfo("ReceiptNotificationEntity", "ReceiptNotificationId", typeof(System.Int64), true, false, true, false,  (int)ReceiptNotificationFieldIndex.ReceiptNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("ReceiptNotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)ReceiptNotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("ReceiptNotificationEntity", "InfoPathFilename", typeof(System.String), false, false, false, false,  (int)ReceiptNotificationFieldIndex.InfoPathFilename, 500, 0, 0);
			base.AddElementFieldInfo("ReceiptNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ReceiptNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("ReceiptNotificationEntity", "SendTo", typeof(System.String), false, false, false, false,  (int)ReceiptNotificationFieldIndex.SendTo, 200, 0, 0);
			base.AddElementFieldInfo("ReceiptNotificationEntity", "CirVersion", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ReceiptNotificationFieldIndex.CirVersion, 0, 1, 10);
		}
		/// <summary>Inits RejectNotificationEntity's FieldInfo objects</summary>
		private void InitRejectNotificationEntityInfos()
		{
			base.AddElementFieldInfo("RejectNotificationEntity", "RejectNotificationId", typeof(System.Int64), true, false, true, false,  (int)RejectNotificationFieldIndex.RejectNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("RejectNotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)RejectNotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("RejectNotificationEntity", "InfoPathFilename", typeof(System.String), false, false, false, false,  (int)RejectNotificationFieldIndex.InfoPathFilename, 500, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)RejectNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "SendTo", typeof(System.String), false, false, false, false,  (int)RejectNotificationFieldIndex.SendTo, 200, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "RejectedBy", typeof(System.String), false, false, false, false,  (int)RejectNotificationFieldIndex.RejectedBy, 50, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "Comment", typeof(System.String), false, false, false, true,  (int)RejectNotificationFieldIndex.Comment, 2147483647, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "Received", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)RejectNotificationFieldIndex.Received, 0, 0, 0);
			base.AddElementFieldInfo("RejectNotificationEntity", "Sbuid", typeof(Nullable<System.Int64>), false, true, false, true,  (int)RejectNotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("RejectNotificationEntity", "CimcaseNo", typeof(Nullable<System.Int64>), false, false, false, true,  (int)RejectNotificationFieldIndex.CimcaseNo, 0, 0, 19);
		}
		/// <summary>Inits ReportTypeEntity's FieldInfo objects</summary>
		private void InitReportTypeEntityInfos()
		{
			base.AddElementFieldInfo("ReportTypeEntity", "ReportTypeId", typeof(System.Int64), true, false, false, false,  (int)ReportTypeFieldIndex.ReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ReportTypeEntity", "Name", typeof(System.String), false, false, false, true,  (int)ReportTypeFieldIndex.Name, 200, 0, 0);
			base.AddElementFieldInfo("ReportTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ReportTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ReportTypeEntity", "ParentReportTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ReportTypeFieldIndex.ParentReportTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ReportTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ReportTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits SbuEntity's FieldInfo objects</summary>
		private void InitSbuEntityInfos()
		{
			base.AddElementFieldInfo("SbuEntity", "Sbuid", typeof(System.Int64), true, false, true, false,  (int)SbuFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("SbuEntity", "Name", typeof(System.String), false, false, false, false,  (int)SbuFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "ShortName", typeof(System.String), false, false, false, false,  (int)SbuFieldIndex.ShortName, 50, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "VpdptId", typeof(System.Int64), false, false, false, false,  (int)SbuFieldIndex.VpdptId, 0, 0, 19);
			base.AddElementFieldInfo("SbuEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)SbuFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)SbuFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SbuFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)SbuFieldIndex.DeletedBy, 50, 0, 0);
			base.AddElementFieldInfo("SbuEntity", "Email", typeof(System.String), false, false, false, true,  (int)SbuFieldIndex.Email, 50, 0, 0);
		}
		/// <summary>Inits SbunotificationEntity's FieldInfo objects</summary>
		private void InitSbunotificationEntityInfos()
		{
			base.AddElementFieldInfo("SbunotificationEntity", "SbunotificationId", typeof(System.Int64), true, false, true, false,  (int)SbunotificationFieldIndex.SbunotificationId, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)SbunotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SbunotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("SbunotificationEntity", "EditDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SbunotificationFieldIndex.EditDate, 0, 0, 0);
			base.AddElementFieldInfo("SbunotificationEntity", "State", typeof(System.String), false, false, false, false,  (int)SbunotificationFieldIndex.State, 50, 0, 0);
			base.AddElementFieldInfo("SbunotificationEntity", "ComponentType", typeof(System.String), false, false, false, false,  (int)SbunotificationFieldIndex.ComponentType, 50, 0, 0);
			base.AddElementFieldInfo("SbunotificationEntity", "TurbineMatrixId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)SbunotificationFieldIndex.TurbineMatrixId, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "Sitename", typeof(System.String), false, false, false, true,  (int)SbunotificationFieldIndex.Sitename, 200, 0, 0);
			base.AddElementFieldInfo("SbunotificationEntity", "CountryIsoid", typeof(Nullable<System.Int64>), false, true, false, true,  (int)SbunotificationFieldIndex.CountryIsoid, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "Sbuid", typeof(System.Int64), false, true, false, false,  (int)SbunotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "CimcaseNo", typeof(Nullable<System.Int64>), false, false, false, true,  (int)SbunotificationFieldIndex.CimcaseNo, 0, 0, 19);
			base.AddElementFieldInfo("SbunotificationEntity", "Warning", typeof(System.Int16), false, false, false, false,  (int)SbunotificationFieldIndex.Warning, 0, 0, 5);
		}
		/// <summary>Inits SburejectNotificationEntity's FieldInfo objects</summary>
		private void InitSburejectNotificationEntityInfos()
		{
			base.AddElementFieldInfo("SburejectNotificationEntity", "SburejectNotificationId", typeof(System.Int64), true, false, true, false,  (int)SburejectNotificationFieldIndex.SburejectNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("SburejectNotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)SburejectNotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("SburejectNotificationEntity", "InfoPathFilename", typeof(System.String), false, false, false, false,  (int)SburejectNotificationFieldIndex.InfoPathFilename, 500, 0, 0);
			base.AddElementFieldInfo("SburejectNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SburejectNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("SburejectNotificationEntity", "RejectedBy", typeof(System.String), false, false, false, false,  (int)SburejectNotificationFieldIndex.RejectedBy, 50, 0, 0);
			base.AddElementFieldInfo("SburejectNotificationEntity", "Comment", typeof(System.String), false, false, false, true,  (int)SburejectNotificationFieldIndex.Comment, 2147483647, 0, 0);
			base.AddElementFieldInfo("SburejectNotificationEntity", "Sbuid", typeof(Nullable<System.Int64>), false, true, false, true,  (int)SburejectNotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("SburejectNotificationEntity", "CimcaseNo", typeof(Nullable<System.Int64>), false, false, false, true,  (int)SburejectNotificationFieldIndex.CimcaseNo, 0, 0, 19);
		}
		/// <summary>Inits SearchProfileEntity's FieldInfo objects</summary>
		private void InitSearchProfileEntityInfos()
		{
			base.AddElementFieldInfo("SearchProfileEntity", "SearchProfileId", typeof(System.Int64), true, false, true, false,  (int)SearchProfileFieldIndex.SearchProfileId, 0, 0, 19);
			base.AddElementFieldInfo("SearchProfileEntity", "UserId", typeof(System.String), false, false, false, false,  (int)SearchProfileFieldIndex.UserId, 50, 0, 0);
			base.AddElementFieldInfo("SearchProfileEntity", "Name", typeof(System.String), false, false, false, false,  (int)SearchProfileFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("SearchProfileEntity", "Public", typeof(System.Boolean), false, false, false, false,  (int)SearchProfileFieldIndex.Public, 0, 0, 0);
		}
		/// <summary>Inits SearchProfileDetailEntity's FieldInfo objects</summary>
		private void InitSearchProfileDetailEntityInfos()
		{
			base.AddElementFieldInfo("SearchProfileDetailEntity", "SearchProfileDetailId", typeof(System.Int64), true, false, true, false,  (int)SearchProfileDetailFieldIndex.SearchProfileDetailId, 0, 0, 19);
			base.AddElementFieldInfo("SearchProfileDetailEntity", "SearchProfileId", typeof(System.Int64), false, true, false, false,  (int)SearchProfileDetailFieldIndex.SearchProfileId, 0, 0, 19);
			base.AddElementFieldInfo("SearchProfileDetailEntity", "InputId", typeof(System.String), false, false, false, false,  (int)SearchProfileDetailFieldIndex.InputId, 1000, 0, 0);
			base.AddElementFieldInfo("SearchProfileDetailEntity", "Value", typeof(System.String), false, false, false, false,  (int)SearchProfileDetailFieldIndex.Value, 1000, 0, 0);
			base.AddElementFieldInfo("SearchProfileDetailEntity", "InputType", typeof(System.String), false, false, false, false,  (int)SearchProfileDetailFieldIndex.InputType, 50, 0, 0);
		}
		/// <summary>Inits SecondNotificationEntity's FieldInfo objects</summary>
		private void InitSecondNotificationEntityInfos()
		{
			base.AddElementFieldInfo("SecondNotificationEntity", "SecondNotificationId", typeof(System.Int64), true, false, true, false,  (int)SecondNotificationFieldIndex.SecondNotificationId, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "ComponentInspectionReportId", typeof(System.Int64), false, false, false, false,  (int)SecondNotificationFieldIndex.ComponentInspectionReportId, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "SendOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)SecondNotificationFieldIndex.SendOn, 0, 0, 0);
			base.AddElementFieldInfo("SecondNotificationEntity", "ManufacturerId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)SecondNotificationFieldIndex.ManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "Sbuid", typeof(System.Int64), false, true, false, false,  (int)SecondNotificationFieldIndex.Sbuid, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "ComponentType", typeof(System.String), false, false, false, false,  (int)SecondNotificationFieldIndex.ComponentType, 50, 0, 0);
			base.AddElementFieldInfo("SecondNotificationEntity", "Cirtemplate", typeof(System.Byte[]), false, false, false, true,  (int)SecondNotificationFieldIndex.Cirtemplate, 2147483647, 0, 0);
			base.AddElementFieldInfo("SecondNotificationEntity", "CimcaseNumber", typeof(System.Int64), false, false, false, false,  (int)SecondNotificationFieldIndex.CimcaseNumber, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "TurbineMatrixId", typeof(Nullable<System.Int64>), false, false, false, true,  (int)SecondNotificationFieldIndex.TurbineMatrixId, 0, 0, 19);
			base.AddElementFieldInfo("SecondNotificationEntity", "CirDataId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)SecondNotificationFieldIndex.CirDataId, 0, 0, 19);
		}
		/// <summary>Inits ServiceReportNumberTypeEntity's FieldInfo objects</summary>
		private void InitServiceReportNumberTypeEntityInfos()
		{
			base.AddElementFieldInfo("ServiceReportNumberTypeEntity", "ServiceReportNumberTypeId", typeof(System.Int64), true, false, true, false,  (int)ServiceReportNumberTypeFieldIndex.ServiceReportNumberTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ServiceReportNumberTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ServiceReportNumberTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ServiceReportNumberTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ServiceReportNumberTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ServiceReportNumberTypeEntity", "ParentServiceReportNumberTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ServiceReportNumberTypeFieldIndex.ParentServiceReportNumberTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ServiceReportNumberTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ServiceReportNumberTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ShaftErrorEntity's FieldInfo objects</summary>
		private void InitShaftErrorEntityInfos()
		{
			base.AddElementFieldInfo("ShaftErrorEntity", "ShaftErrorId", typeof(System.Int64), true, false, true, false,  (int)ShaftErrorFieldIndex.ShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftErrorEntity", "Name", typeof(System.String), false, false, false, false,  (int)ShaftErrorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ShaftErrorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ShaftErrorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftErrorEntity", "ParentShaftErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ShaftErrorFieldIndex.ParentShaftErrorId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftErrorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ShaftErrorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ShaftErrorVendorEntity's FieldInfo objects</summary>
		private void InitShaftErrorVendorEntityInfos()
		{
			base.AddElementFieldInfo("ShaftErrorVendorEntity", "ShaftErrorVendorId", typeof(System.Int32), true, false, true, false,  (int)ShaftErrorVendorFieldIndex.ShaftErrorVendorId, 0, 0, 10);
			base.AddElementFieldInfo("ShaftErrorVendorEntity", "Name", typeof(System.String), false, false, false, true,  (int)ShaftErrorVendorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ShaftErrorVendorEntity", "Sort", typeof(Nullable<System.Int32>), false, false, false, true,  (int)ShaftErrorVendorFieldIndex.Sort, 0, 0, 10);
		}
		/// <summary>Inits ShaftTypeEntity's FieldInfo objects</summary>
		private void InitShaftTypeEntityInfos()
		{
			base.AddElementFieldInfo("ShaftTypeEntity", "ShaftTypeId", typeof(System.Int64), true, false, true, false,  (int)ShaftTypeFieldIndex.ShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ShaftTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ShaftTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ShaftTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftTypeEntity", "ParentShaftTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ShaftTypeFieldIndex.ParentShaftTypeId, 0, 0, 19);
			base.AddElementFieldInfo("ShaftTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ShaftTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits ShrinkElementEntity's FieldInfo objects</summary>
		private void InitShrinkElementEntityInfos()
		{
			base.AddElementFieldInfo("ShrinkElementEntity", "ShrinkElementId", typeof(System.Int64), true, false, true, false,  (int)ShrinkElementFieldIndex.ShrinkElementId, 0, 0, 19);
			base.AddElementFieldInfo("ShrinkElementEntity", "Name", typeof(System.String), false, false, false, false,  (int)ShrinkElementFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("ShrinkElementEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)ShrinkElementFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("ShrinkElementEntity", "ParentShrinkElementId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ShrinkElementFieldIndex.ParentShrinkElementId, 0, 0, 19);
			base.AddElementFieldInfo("ShrinkElementEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)ShrinkElementFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits SkiipackFailureCauseEntity's FieldInfo objects</summary>
		private void InitSkiipackFailureCauseEntityInfos()
		{
			base.AddElementFieldInfo("SkiipackFailureCauseEntity", "SkiipackFailureCauseId", typeof(System.Int64), true, false, true, false,  (int)SkiipackFailureCauseFieldIndex.SkiipackFailureCauseId, 0, 0, 19);
			base.AddElementFieldInfo("SkiipackFailureCauseEntity", "Name", typeof(System.String), false, false, false, false,  (int)SkiipackFailureCauseFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("SkiipackFailureCauseEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)SkiipackFailureCauseFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("SkiipackFailureCauseEntity", "ParentSkiipackFailureCauseId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)SkiipackFailureCauseFieldIndex.ParentSkiipackFailureCauseId, 0, 0, 19);
			base.AddElementFieldInfo("SkiipackFailureCauseEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)SkiipackFailureCauseFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits SurgeArrestorEntity's FieldInfo objects</summary>
		private void InitSurgeArrestorEntityInfos()
		{
			base.AddElementFieldInfo("SurgeArrestorEntity", "SurgeArrestorId", typeof(System.Int64), true, false, true, false,  (int)SurgeArrestorFieldIndex.SurgeArrestorId, 0, 0, 19);
			base.AddElementFieldInfo("SurgeArrestorEntity", "Name", typeof(System.String), false, false, false, false,  (int)SurgeArrestorFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("SurgeArrestorEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)SurgeArrestorFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("SurgeArrestorEntity", "ParentSurgeArrestorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)SurgeArrestorFieldIndex.ParentSurgeArrestorId, 0, 0, 19);
			base.AddElementFieldInfo("SurgeArrestorEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)SurgeArrestorFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits TemplateDynamicTableDefEntity's FieldInfo objects</summary>
		private void InitTemplateDynamicTableDefEntityInfos()
		{
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)TemplateDynamicTableDefFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "CimcaseNo", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.CimcaseNo, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "TableHeader", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.TableHeader, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "ColHeader1", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.ColHeader1, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "ColHeader2", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.ColHeader2, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "ColHeader3", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.ColHeader3, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "ColHeader4", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.ColHeader4, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader1", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader1, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader2", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader2, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader3", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader3, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader4", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader4, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader5", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader5, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader6", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader6, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader7", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader7, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader8", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader8, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader9", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader9, 50, 0, 0);
			base.AddElementFieldInfo("TemplateDynamicTableDefEntity", "RowHeader10", typeof(System.String), false, false, false, true,  (int)TemplateDynamicTableDefFieldIndex.RowHeader10, 50, 0, 0);
		}
		/// <summary>Inits TemplateInfoEntity's FieldInfo objects</summary>
		private void InitTemplateInfoEntityInfos()
		{
			base.AddElementFieldInfo("TemplateInfoEntity", "Version", typeof(System.Decimal), false, false, false, false,  (int)TemplateInfoFieldIndex.Version, 0, 1, 10);
			base.AddElementFieldInfo("TemplateInfoEntity", "Message", typeof(System.String), false, false, false, false,  (int)TemplateInfoFieldIndex.Message, 2147483647, 0, 0);
			base.AddElementFieldInfo("TemplateInfoEntity", "Url", typeof(System.String), false, false, false, false,  (int)TemplateInfoFieldIndex.Url, 256, 0, 0);
		}
		/// <summary>Inits ThreeMwGearboxesEntity's FieldInfo objects</summary>
		private void InitThreeMwGearboxesEntityInfos()
		{
			base.AddElementFieldInfo("ThreeMwGearboxesEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)ThreeMwGearboxesFieldIndex.Id, 0, 0, 10);
			base.AddElementFieldInfo("ThreeMwGearboxesEntity", "Casenumber", typeof(System.Int64), false, false, false, false,  (int)ThreeMwGearboxesFieldIndex.Casenumber, 0, 0, 19);
		}
		/// <summary>Inits TowerHeightEntity's FieldInfo objects</summary>
		private void InitTowerHeightEntityInfos()
		{
			base.AddElementFieldInfo("TowerHeightEntity", "TowerHeightId", typeof(System.Int64), true, false, true, false,  (int)TowerHeightFieldIndex.TowerHeightId, 0, 0, 19);
			base.AddElementFieldInfo("TowerHeightEntity", "Name", typeof(System.String), false, false, false, false,  (int)TowerHeightFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TowerHeightEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)TowerHeightFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("TowerHeightEntity", "ParentTowerHeightId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TowerHeightFieldIndex.ParentTowerHeightId, 0, 0, 19);
			base.AddElementFieldInfo("TowerHeightEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)TowerHeightFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits TowerTypeEntity's FieldInfo objects</summary>
		private void InitTowerTypeEntityInfos()
		{
			base.AddElementFieldInfo("TowerTypeEntity", "TowerTypeId", typeof(System.Int64), true, false, true, false,  (int)TowerTypeFieldIndex.TowerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("TowerTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)TowerTypeFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TowerTypeEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)TowerTypeFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("TowerTypeEntity", "ParentTowerTypeId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TowerTypeFieldIndex.ParentTowerTypeId, 0, 0, 19);
			base.AddElementFieldInfo("TowerTypeEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)TowerTypeFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits TransformerManufacturerEntity's FieldInfo objects</summary>
		private void InitTransformerManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("TransformerManufacturerEntity", "TransformerManufacturerId", typeof(System.Int64), true, false, true, false,  (int)TransformerManufacturerFieldIndex.TransformerManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "Name", typeof(System.String), false, false, false, false,  (int)TransformerManufacturerFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)TransformerManufacturerFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "ParentTransformerManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TransformerManufacturerFieldIndex.ParentTransformerManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)TransformerManufacturerFieldIndex.Sort, 0, 0, 19);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "Email", typeof(System.String), false, false, false, true,  (int)TransformerManufacturerFieldIndex.Email, 50, 0, 0);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "Cc", typeof(System.String), false, false, false, true,  (int)TransformerManufacturerFieldIndex.Cc, 50, 0, 0);
			base.AddElementFieldInfo("TransformerManufacturerEntity", "EmailContactName", typeof(System.String), false, false, false, true,  (int)TransformerManufacturerFieldIndex.EmailContactName, 200, 0, 0);
		}
		/// <summary>Inits TurbineEntity's FieldInfo objects</summary>
		private void InitTurbineEntityInfos()
		{
			base.AddElementFieldInfo("TurbineEntity", "TurbineId", typeof(System.Int64), true, false, true, false,  (int)TurbineFieldIndex.TurbineId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineEntity", "Turbine", typeof(System.String), false, false, false, false,  (int)TurbineFieldIndex.Turbine, 20, 0, 0);
			base.AddElementFieldInfo("TurbineEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineDataEntity's FieldInfo objects</summary>
		private void InitTurbineDataEntityInfos()
		{
			base.AddElementFieldInfo("TurbineDataEntity", "TurbineDataId", typeof(System.Int32), false, false, true, false,  (int)TurbineDataFieldIndex.TurbineDataId, 0, 0, 10);
			base.AddElementFieldInfo("TurbineDataEntity", "TurbineId", typeof(System.String), false, false, false, false,  (int)TurbineDataFieldIndex.TurbineId, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "TurbineType", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.TurbineType, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Voltage", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.Voltage, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Frequency", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.Frequency, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "RotorDiameter", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.RotorDiameter, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "NominalPower", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.NominalPower, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "PowerRegulation", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.PowerRegulation, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "SmallGenerator", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.SmallGenerator, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "TemperatureVariant", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.TemperatureVariant, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "MkVersion", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.MkVersion, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "OnshoreOffshore", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.OnshoreOffshore, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Manufacturer", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.Manufacturer, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Country", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.Country, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Site", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.Site, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "LocalTurbineId", typeof(System.String), false, false, false, true,  (int)TurbineDataFieldIndex.LocalTurbineId, 50, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineDataFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineDataEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineDataFieldIndex.Deleted, 0, 0, 0);
		}
		/// <summary>Inits TurbineFrequencyEntity's FieldInfo objects</summary>
		private void InitTurbineFrequencyEntityInfos()
		{
			base.AddElementFieldInfo("TurbineFrequencyEntity", "TurbineFrequencyId", typeof(System.Int64), true, false, true, false,  (int)TurbineFrequencyFieldIndex.TurbineFrequencyId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineFrequencyEntity", "Frequency", typeof(System.Byte), false, false, false, false,  (int)TurbineFrequencyFieldIndex.Frequency, 0, 0, 3);
			base.AddElementFieldInfo("TurbineFrequencyEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineFrequencyFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineFrequencyEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineFrequencyFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineFrequencyEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineFrequencyFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineFrequencyEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineFrequencyFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineManufacturerEntity's FieldInfo objects</summary>
		private void InitTurbineManufacturerEntityInfos()
		{
			base.AddElementFieldInfo("TurbineManufacturerEntity", "TurbineManufacturerId", typeof(System.Int64), true, false, true, false,  (int)TurbineManufacturerFieldIndex.TurbineManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineManufacturerEntity", "Manufacturer", typeof(System.String), false, false, false, false,  (int)TurbineManufacturerFieldIndex.Manufacturer, 100, 0, 0);
			base.AddElementFieldInfo("TurbineManufacturerEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineManufacturerFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineManufacturerEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineManufacturerFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineManufacturerEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineManufacturerFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineManufacturerEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineManufacturerFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineMarkVersionEntity's FieldInfo objects</summary>
		private void InitTurbineMarkVersionEntityInfos()
		{
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "TurbineMarkVersionId", typeof(System.Int64), true, false, true, false,  (int)TurbineMarkVersionFieldIndex.TurbineMarkVersionId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "MarkVersion", typeof(System.String), false, false, false, false,  (int)TurbineMarkVersionFieldIndex.MarkVersion, 20, 0, 0);
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineMarkVersionFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineMarkVersionFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineMarkVersionFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineMarkVersionEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineMarkVersionFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineMatrixEntity's FieldInfo objects</summary>
		private void InitTurbineMatrixEntityInfos()
		{
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineMatrixId", typeof(System.Int64), true, false, true, false,  (int)TurbineMatrixFieldIndex.TurbineMatrixId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbinePowerRegulationId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbinePowerRegulationId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineRotorDiameterId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineRotorDiameterId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineNominelPowerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineNominelPowerId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineVoltageId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineVoltageId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineFrequencyId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineFrequencyId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineSmallGeneratorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineSmallGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineTemperatureVariantId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineTemperatureVariantId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineMarkVersionId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineMarkVersionId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbinePlacementId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbinePlacementId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineManufacturerId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineManufacturerId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "TurbineOldId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineMatrixFieldIndex.TurbineOldId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineMatrixEntity", "Comment", typeof(System.String), false, false, false, true,  (int)TurbineMatrixFieldIndex.Comment, 50, 0, 0);
			base.AddElementFieldInfo("TurbineMatrixEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineMatrixFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineMatrixEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineMatrixFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineMatrixEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineMatrixFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineMatrixEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineMatrixFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineNominelPowerEntity's FieldInfo objects</summary>
		private void InitTurbineNominelPowerEntityInfos()
		{
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "TurbineNominelPowerId", typeof(System.Int64), true, false, true, false,  (int)TurbineNominelPowerFieldIndex.TurbineNominelPowerId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "NominelPower", typeof(System.Int32), false, false, false, false,  (int)TurbineNominelPowerFieldIndex.NominelPower, 0, 0, 10);
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineNominelPowerFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineNominelPowerFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineNominelPowerFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineNominelPowerEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineNominelPowerFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineOldEntity's FieldInfo objects</summary>
		private void InitTurbineOldEntityInfos()
		{
			base.AddElementFieldInfo("TurbineOldEntity", "TurbineOldId", typeof(System.Int64), true, false, true, false,  (int)TurbineOldFieldIndex.TurbineOldId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineOldEntity", "Turbine", typeof(System.String), false, false, false, false,  (int)TurbineOldFieldIndex.Turbine, 50, 0, 0);
			base.AddElementFieldInfo("TurbineOldEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineOldFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineOldEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineOldFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineOldEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineOldFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineOldEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineOldFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbinePlacementEntity's FieldInfo objects</summary>
		private void InitTurbinePlacementEntityInfos()
		{
			base.AddElementFieldInfo("TurbinePlacementEntity", "TurbinePlacementId", typeof(System.Int64), true, false, true, false,  (int)TurbinePlacementFieldIndex.TurbinePlacementId, 0, 0, 19);
			base.AddElementFieldInfo("TurbinePlacementEntity", "Placement", typeof(System.String), false, false, false, false,  (int)TurbinePlacementFieldIndex.Placement, 20, 0, 0);
			base.AddElementFieldInfo("TurbinePlacementEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbinePlacementFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbinePlacementEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbinePlacementFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbinePlacementEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbinePlacementFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbinePlacementEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbinePlacementFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbinePowerRegulationEntity's FieldInfo objects</summary>
		private void InitTurbinePowerRegulationEntityInfos()
		{
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "TurbinePowerRegulationId", typeof(System.Int64), true, false, true, false,  (int)TurbinePowerRegulationFieldIndex.TurbinePowerRegulationId, 0, 0, 19);
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "PowerRegulation", typeof(System.String), false, false, false, true,  (int)TurbinePowerRegulationFieldIndex.PowerRegulation, 50, 0, 0);
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbinePowerRegulationFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbinePowerRegulationFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbinePowerRegulationFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbinePowerRegulationEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbinePowerRegulationFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineRotorDiameterEntity's FieldInfo objects</summary>
		private void InitTurbineRotorDiameterEntityInfos()
		{
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "TurbineRotorDiameterId", typeof(System.Int64), true, false, true, false,  (int)TurbineRotorDiameterFieldIndex.TurbineRotorDiameterId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "RotorDiameter", typeof(System.Decimal), false, false, false, false,  (int)TurbineRotorDiameterFieldIndex.RotorDiameter, 0, 2, 5);
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineRotorDiameterFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineRotorDiameterFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineRotorDiameterFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineRotorDiameterEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineRotorDiameterFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineRunStatusEntity's FieldInfo objects</summary>
		private void InitTurbineRunStatusEntityInfos()
		{
			base.AddElementFieldInfo("TurbineRunStatusEntity", "TurbineRunStatusId", typeof(System.Int64), true, false, true, false,  (int)TurbineRunStatusFieldIndex.TurbineRunStatusId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineRunStatusEntity", "Name", typeof(System.String), false, false, false, false,  (int)TurbineRunStatusFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("TurbineRunStatusEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)TurbineRunStatusFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineRunStatusEntity", "ParentTurbineRunStatusId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TurbineRunStatusFieldIndex.ParentTurbineRunStatusId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineRunStatusEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)TurbineRunStatusFieldIndex.Sort, 0, 0, 19);
		}
		/// <summary>Inits TurbineSmallGeneratorEntity's FieldInfo objects</summary>
		private void InitTurbineSmallGeneratorEntityInfos()
		{
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "TurbineSmallGeneratorId", typeof(System.Int64), true, false, true, false,  (int)TurbineSmallGeneratorFieldIndex.TurbineSmallGeneratorId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "SmallGenerator", typeof(System.Int32), false, false, false, false,  (int)TurbineSmallGeneratorFieldIndex.SmallGenerator, 0, 0, 10);
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineSmallGeneratorFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineSmallGeneratorFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineSmallGeneratorFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineSmallGeneratorEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineSmallGeneratorFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineTemperatureVariantEntity's FieldInfo objects</summary>
		private void InitTurbineTemperatureVariantEntityInfos()
		{
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "TurbineTemperatureVariantId", typeof(System.Int64), true, false, true, false,  (int)TurbineTemperatureVariantFieldIndex.TurbineTemperatureVariantId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "TemperatureVariant", typeof(System.String), false, false, false, false,  (int)TurbineTemperatureVariantFieldIndex.TemperatureVariant, 20, 0, 0);
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineTemperatureVariantFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineTemperatureVariantFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineTemperatureVariantFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineTemperatureVariantEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineTemperatureVariantFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits TurbineVoltageEntity's FieldInfo objects</summary>
		private void InitTurbineVoltageEntityInfos()
		{
			base.AddElementFieldInfo("TurbineVoltageEntity", "TurbineVoltageId", typeof(System.Int64), true, false, true, false,  (int)TurbineVoltageFieldIndex.TurbineVoltageId, 0, 0, 19);
			base.AddElementFieldInfo("TurbineVoltageEntity", "Voltage", typeof(System.Int32), false, false, false, false,  (int)TurbineVoltageFieldIndex.Voltage, 0, 0, 10);
			base.AddElementFieldInfo("TurbineVoltageEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)TurbineVoltageFieldIndex.Created, 0, 0, 0);
			base.AddElementFieldInfo("TurbineVoltageEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)TurbineVoltageFieldIndex.CreatedBy, 50, 0, 0);
			base.AddElementFieldInfo("TurbineVoltageEntity", "Deleted", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TurbineVoltageFieldIndex.Deleted, 0, 0, 0);
			base.AddElementFieldInfo("TurbineVoltageEntity", "DeletedBy", typeof(System.String), false, false, false, true,  (int)TurbineVoltageFieldIndex.DeletedBy, 50, 0, 0);
		}
		/// <summary>Inits VibrationsEntity's FieldInfo objects</summary>
		private void InitVibrationsEntityInfos()
		{
			base.AddElementFieldInfo("VibrationsEntity", "VibrationsId", typeof(System.Int64), true, false, true, false,  (int)VibrationsFieldIndex.VibrationsId, 0, 0, 19);
			base.AddElementFieldInfo("VibrationsEntity", "Name", typeof(System.String), false, false, false, false,  (int)VibrationsFieldIndex.Name, 50, 0, 0);
			base.AddElementFieldInfo("VibrationsEntity", "LanguageId", typeof(System.Int64), false, false, false, false,  (int)VibrationsFieldIndex.LanguageId, 0, 0, 19);
			base.AddElementFieldInfo("VibrationsEntity", "ParentVibrationsId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)VibrationsFieldIndex.ParentVibrationsId, 0, 0, 19);
			base.AddElementFieldInfo("VibrationsEntity", "Sort", typeof(System.Int64), false, false, false, false,  (int)VibrationsFieldIndex.Sort, 0, 0, 19);
		}
		
	}
}




