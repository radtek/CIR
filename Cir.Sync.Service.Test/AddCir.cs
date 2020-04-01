namespace Cir.Sync.Service.Test
{
    //[TestClass]
    //public class AddCir
    //{
    //    // mock wcf interface
    //    Mock<Services.ServiceContracts.ISyncService> wcfMock = null;
    //    [TestInitialize]
    //    public void Init_CirData()
    //    {
    //        wcfMock = new Mock<Services.ServiceContracts.ISyncService>();
    //    }

    //    [TestMethod]
    //    public void Add_cir()
    //    {
    //        ComponentInspectionReport CIRList = new ComponentInspectionReport();
    //        CirResponse obj = new CirResponse();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<CirResponse>(s => s.SaveCIRData(It.IsAny<ComponentInspectionReport>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        var str = "{\r\n \"TemplateVersion\":\"7\",\"ComponentInspectionReportId\":0,\"ComponentInspectionReportTypeId\":4,\"ComponentInspectionReportStateId\":1,\"ReportTypeId\":2,\"ReconstructionBooleanAnswerId\":1,\"CIMCaseNumber\":1234,\"ReasonForService\":\"\",\"TurbineNumber\":20722,\"CountryISOId\":0,\"Country\":\"Denmark\",\"TurbineType\":\"V47\",\"SiteName\":\"Roslevvej 39, Jebjerg\",\"TurbineMatrixId\":null,\"LocationTypeId\":6,\"LocalTurbineId\":null,\"SecondGeneratorBooleanAnswerId\":null,\"BeforeInspectionTurbineRunStatusId\":6,\"CommisioningDate\":\"2017-03-21T00:00:00\",\"strCommisioningDate\":\"21-03-2017\",\"InstallationDate\":\"0001-01-01T00:00:00\",\"strInstallationDate\":\"\",\"FailureDate\":\"2017-03-21T00:00:00\",\"strFailureDate\":\"21-03-2017\",\"InspectionDate\":\"2017-03-21T00:00:00\",\"strInspectionDate\":\"21-03-2017\",\"ServiceReportNumber\":\"1\",\"ServiceReportNumberTypeId\":1,\"ServiceEngineer\":\"1\",\"RunHours\":1,\"Generator1Hrs\":1,\"Generator2Hrs\":null,\"TotalProduction\":1,\"AfterInspectionTurbineRunStatusId\":3,\"Quantity\":0,\"AlarmLogNumber\":\"0\",\"Description\":\"1\",\"DescriptionConsquential\":\"\",\"ConductedBy\":\"1\",\"SBUId\":1,\"CIRTemplateGUID\":\"1f30ef1c-7384-42e5-b50a-dfb14dc203f2\",\"VestasItemNumber\":\"1\",\"Deleted\":\"0001-01-01T00:00:00\",\"DeletedBy\":null,\"NotificationNumber\":300836598,\"ErrorMessage\":null,\"MountedOnMainComponentBooleanAnswerId\":2,\"ComponentUpTowerSolutionID\":null,\"CurrentUser\":\"ciradmin\",\"SBURecomendation\":\"\",\"AdditionalComments\":\"\",\"InternalComments\":\"\",\"ComponentInspectionReportVersion\":null,\"ComponentInspectionReportName\":\"Roslevvej 39, Jeb_Generator_1232_2017-02-02_1234\",\"SBUName\":null,\"CirDataID\":460815,\"CirName\":null,\"Created\":\"0001-01-01T00:00:00\",\"Modified\":\"0001-01-01T00:00:00\",\"TotalRecords\":0,\"TotalUnApprovedRecords\":0,\"TotalAcceptedRecords\":0,\"TotalRejectedRecords\":0,\"HideProgress\":null,\"HideLock\":null,\"CIRID\":0,\"HideTemplateVer\":null,\"BladeData\":{ \"ComponentInspectionReportBladeId\":0,\"ComponentInspectionReportId\":0,\"VestasUniqueIdentifier\":null,\"BladeLengthId\":0,\"BladeColorId\":0,\"BladeManufacturerId\":null,\"BladeSerialNumber\":null,\"BladePicturesIncludedBooleanAnswerId\":0,\"BladeOtherSerialNumber1\":null,\"BladeOtherSerialNumber2\":null,\"BladeDamageIdentified\":false,\"BladeFaultCodeClassificationId\":null,\"BladeFaultCodeCauseId\":null,\"BladeFaultCodeTypeId\":null,\"BladeFaultCodeAreaId\":null,\"BladeClaimRelevantBooleanAnswerId\":null,\"BladeLsVtNumber\":null,\"BladeLsCalibrationDate\":\"0001-01-01T00:00:00\",\"strBladeLsCalibrationDate\":null,\"BladeLsLeewardSidePreRepairTip\":null,\"BladeLsLeewardSidePostRepairTip\":null,\"BladeLsLeewardSidePreRepair2\":null,\"BladeLsLeewardSidePostRepair2\":null,\"BladeLsLeewardSidePreRepair3\":null,\"BladeLsLeewardSidePostRepair3\":null,\"BladeLsLeewardSidePreRepair4\":null,\"BladeLsLeewardSidePostRepair4\":null,\"BladeLsLeewardSidePreRepair5\":null,\"BladeLsLeewardSidePostRepair5\":null,\"BladeLsWindwardSidePreRepairTip\":null,\"BladeLsWindwardSidePostRepairTip\":null,\"BladeLsWindwardSidePreRepair2\":null,\"BladeLsWindwardSidePostRepair2\":null,\"BladeLsWindwardSidePreRepair3\":null,\"BladeLsWindwardSidePostRepair3\":null,\"BladeLsWindwardSidePreRepair4\":null,\"BladeLsWindwardSidePostRepair4\":null,\"BladeLsWindwardSidePreRepair5\":null,\"BladeLsWindwardSidePostRepair5\":null,\"BladeInspectionReportDescription\":null,\"DamageData\":null,\"RepairRecordData\":null},\"Skiip\":{ \"ComponentInspectionReportSkiiPId\":0,\"ComponentInspectionReportId\":0,\"SkiiPOtherDamagedComponentsReplaced\":null,\"SkiiPCauseId\":0,\"SkiiPQuantityOfFailedModules\":0,\"SkiiP2MWV521BooleanAnswerId\":null,\"SkiiP2MWV522BooleanAnswerId\":null,\"SkiiP2MWV523BooleanAnswerId\":null,\"SkiiP2MWV524BooleanAnswerId\":null,\"SkiiP2MWV525BooleanAnswerId\":null,\"SkiiP2MWV526BooleanAnswerId\":null,\"SkiiP3MWV521BooleanAnswerId\":null,\"SkiiP3MWV522BooleanAnswerId\":null,\"SkiiP3MWV523BooleanAnswerId\":null,\"SkiiP3MWV524xBooleanAnswerId\":null,\"SkiiP3MWV524yBooleanAnswerId\":null,\"SkiiP3MWV525xBooleanAnswerId\":null,\"SkiiP3MWV525yBooleanAnswerId\":null,\"SkiiP3MWV526xBooleanAnswerId\":null,\"SkiiP3MWV526yBooleanAnswerId\":null,\"SkiiP850KWV520BooleanAnswerId\":null,\"SkiiP850KWV524BooleanAnswerId\":null,\"SkiiP850KWV525BooleanAnswerId\":null,\"SkiiP850KWV526BooleanAnswerId\":null,\"SkiiPClaimRelevantBooleanAnswerId\":null,\"SkiipFailedComp\":null,\"SkiipNewComp\":null,\"SkiiPNumberofComponents\":null},\"Gearbox\":{ \"ComponentInspectionReportGearboxId\":0,\"ComponentInspectionReportId\":0,\"VestasUniqueIdentifier\":null,\"GearboxTypeId\":0,\"GearboxRevisionId\":0,\"GearboxManufacturerId\":0,\"OtherGearboxType\":null,\"GearboxSerialNumber\":null,\"GearboxOtherManufacturer\":null,\"GearboxLastOilChangeDate\":\"0001-01-01T00:00:00\",\"strGearboxLastOilChangeDate\":null,\"GearboxOilTypeId\":0,\"GearboxMechanicalOilPumpId\":0,\"GearboxOilLevelId\":0,\"GearboxRunHours\":null,\"GearboxOilTemperature\":0.0,\"GearboxProduction\":null,\"GearboxGeneratorManufacturerId\":null,\"GearboxGeneratorManufacturerId2\":null,\"GearboxElectricalPumpId\":null,\"GearboxShrinkElementId\":null,\"GearboxShrinkElementSerialNumber\":null,\"GearboxCouplingId\":null,\"GearboxFilterBlockTypeId\":null,\"GearboxInLineFilterId\":null,\"GearboxOffLineFilterId\":null,\"GearboxSoftwareRelease\":null,\"GearboxShaftsExactLocation1ShaftTypeId\":null,\"GearboxShaftsExactLocation2ShaftTypeId\":null,\"GearboxShaftsExactLocation3ShaftTypeId\":null,\"GearboxShaftsExactLocation4ShaftTypeId\":null,\"GearboxShaftsTypeofDamage1ShaftErrorId\":null,\"GearboxShaftsTypeofDamage2ShaftErrorId\":null,\"GearboxShaftsTypeofDamage3ShaftErrorId\":null,\"GearboxShaftsTypeofDamage4ShaftErrorId\":null,\"GearboxExactLocation1GearTypeId\":null,\"GearboxExactLocation2GearTypeId\":null,\"GearboxExactLocation3GearTypeId\":null,\"GearboxExactLocation4GearTypeId\":null,\"GearboxExactLocation5GearTypeId\":null,\"GearboxTypeofDamage1GearErrorId\":null,\"GearboxTypeofDamage2GearErrorId\":null,\"GearboxTypeofDamage3GearErrorId\":null,\"GearboxTypeofDamage4GearErrorId\":null,\"GearboxTypeofDamage5GearErrorId\":null,\"GearboxBearingsLocation1BearingTypeId\":null,\"GearboxBearingsLocation2BearingTypeId\":null,\"GearboxBearingsLocation3BearingTypeId\":null,\"GearboxBearingsLocation4BearingTypeId\":null,\"GearboxBearingsLocation5BearingTypeId\":null,\"GearboxBearingsPosition1BearingPosId\":null,\"GearboxBearingsPosition2BearingPosId\":null,\"GearboxBearingsPosition3BearingPosId\":null,\"GearboxBearingsPosition4BearingPosId\":null,\"GearboxBearingsPosition5BearingPosId\":null,\"GearboxBearingsDamage1BearingErrorId\":null,\"GearboxBearingsDamage2BearingErrorId\":null,\"GearboxBearingsDamage3BearingErrorId\":null,\"GearboxBearingsDamage4BearingErrorId\":null,\"GearboxBearingsDamage5BearingErrorId\":null,\"GearboxPlanetStage1HousingErrorId\":null,\"GearboxPlanetStage2HousingErrorId\":null,\"GearboxHelicalStageHousingErrorId\":null,\"GearboxFrontPlateHousingErrorId\":null,\"GearboxAuxStageHousingErrorId\":null,\"GearboxHSStageHousingErrorId\":null,\"GearboxLooseBolts\":false,\"GearboxBrokenBolts\":false,\"GearboxDefectDamperElements\":false,\"GearboxTooMuchClearance\":false,\"GearboxCrackedTorqueArm\":false,\"GearboxNeedsToBeAligned\":false,\"GearboxPT100Bearing1\":false,\"GearboxPT100Bearing2\":false,\"GearboxPT100Bearing3\":false,\"GearboxOilLevelSensor\":false,\"GearboxOilPressure\":false,\"GearboxPT100OilSump\":false,\"GearboxFilterIndicator\":false,\"GearboxImmersionHeater\":false,\"GearboxDrainValve\":false,\"GearboxAirBreather\":false,\"GearboxSightGlass\":false,\"GearboxChipDetector\":false,\"GearboxVibrationsId\":0,\"GearboxNoiseId\":0,\"GearboxDebrisOnMagnetId\":0,\"GearboxDebrisStagesMagnetPosId\":0,\"GearboxDebrisGearBoxId\":0,\"GearboxMaxTempResetDate\":\"0001-01-01T00:00:00\",\"GearboxTempBearing1\":null,\"GearboxTempBearing2\":null,\"GearboxTempBearing3\":null,\"GearboxTempOilSump\":null,\"GearboxLSSNRend\":false,\"GearboxIMSNRend\":false,\"GearboxIMSRend\":false,\"GearboxHSSNRend\":false,\"GearboxHSSRend\":false,\"GearboxPitchTube\":false,\"GearboxSplitLines\":false,\"GearboxHoseAndPiping\":false,\"GearboxInputShaft\":false,\"GearboxHSSPTO\":false,\"GearboxClaimRelevantBooleanAnswerId\":null,\"GearboxOverallGearboxConditionId\":null,\"GearboxExactLocation6GearTypeId\":null,\"GearboxExactLocation7GearTypeId\":null,\"GearboxExactLocation8GearTypeId\":null,\"GearboxExactLocation9GearTypeId\":null,\"GearboxExactLocation10GearTypeId\":null,\"GearboxExactLocation11GearTypeId\":null,\"GearboxExactLocation12GearTypeId\":null,\"GearboxExactLocation13GearTypeId\":null,\"GearboxExactLocation14GearTypeId\":null,\"GearboxExactLocation15GearTypeId\":null,\"GearboxTypeofDamage6GearErrorId\":null,\"GearboxTypeofDamage7GearErrorId\":null,\"GearboxTypeofDamage8GearErrorId\":null,\"GearboxTypeofDamage9GearErrorId\":null,\"GearboxTypeofDamage10GearErrorId\":null,\"GearboxTypeofDamage11GearErrorId\":null,\"GearboxTypeofDamage12GearErrorId\":null,\"GearboxTypeofDamage13GearErrorId\":null,\"GearboxTypeofDamage14GearErrorId\":null,\"GearboxTypeofDamage15GearErrorId\":null,\"GearboxGearDecision1DamageDecisionId\":null,\"GearboxGearDecision2DamageDecisionId\":null,\"GearboxGearDecision3DamageDecisionId\":null,\"GearboxGearDecision4DamageDecisionId\":null,\"GearboxGearDecision5DamageDecisionId\":null,\"GearboxGearDecision6DamageDecisionId\":null,\"GearboxGearDecision7DamageDecisionId\":null,\"GearboxGearDecision8DamageDecisionId\":null,\"GearboxGearDecision9DamageDecisionId\":null,\"GearboxGearDecision10DamageDecisionId\":null,\"GearboxGearDecision11DamageDecisionId\":null,\"GearboxGearDecision12DamageDecisionId\":null,\"GearboxGearDecision13DamageDecisionId\":null,\"GearboxGearDecision14DamageDecisionId\":null,\"GearboxGearDecision15DamageDecisionId\":null,\"GearboxBearingsLocation6BearingTypeId\":null,\"GearboxBearingsPosition6BearingPosId\":null,\"GearboxBearingsDamage6BearingErrorId\":null,\"GearboxBearingDecision1DamageDecisionId\":null,\"GearboxBearingDecision2DamageDecisionId\":null,\"GearboxBearingDecision3DamageDecisionId\":null,\"GearboxBearingDecision4DamageDecisionId\":null,\"GearboxBearingDecision5DamageDecisionId\":null,\"GearboxBearingDecision6DamageDecisionId\":null,\"GearboxGearDamageClass1DamageId\":null,\"GearboxGearDamageClass2DamageId\":null,\"GearboxGearDamageClass3DamageId\":null,\"GearboxGearDamageClass4DamageId\":null,\"GearboxGearDamageClass5DamageId\":null,\"GearboxGearDamageClass6DamageId\":null,\"GearboxGearDamageClass7DamageId\":null,\"GearboxGearDamageClass8DamageId\":null,\"GearboxGearDamageClass9DamageId\":null,\"GearboxGearDamageClass10DamageId\":null,\"GearboxGearDamageClass11DamageId\":null,\"GearboxGearDamageClass12DamageId\":null,\"GearboxGearDamageClass13DamageId\":null,\"GearboxGearDamageClass14DamageId\":null,\"GearboxGearDamageClass15DamageId\":null,\"GearboxAuxEquipmentId\":null,\"GearboxActionToBeTakenOnGearboxId\":null,\"GearboxDefectCategorizationScore\":null},\"Generator\":{ \"ComponentInspectionReportGeneratorId\":0,\"ComponentInspectionReportId\":0,\"VestasUniqueIdentifier\":\"1\",\"GeneratorManufacturerId\":8,\"GeneratorSerialNumber\":\"1234\",\"OtherManufacturer\":\"\",\"GeneratorMaxTemperature\":0.0,\"GeneratorMaxTemperatureResetDate\":\"2017-03-21T00:00:00\",\"strGeneratorMaxTemperatureResetDate\":\"21-03-2017\",\"CouplingId\":8,\"ActionToBeTakenOnGeneratorId\":1,\"GeneratorDriveEndId\":2,\"GeneratorNonDriveEndId\":1,\"GeneratorRotorId\":2,\"GeneratorCoverId\":1,\"AirToAirCoolerInternalId\":null,\"AirToAirCoolerExternalId\":null,\"GeneratorComments\":\"\",\"UGround\":1.0,\"VGround\":10.0,\"WGround\":10.0,\"UV\":10.0,\"UW\":10.0,\"VW\":10.0,\"KGround\":10.0,\"LGround\":10.0,\"MGround\":10.0,\"UGroundOhmUnitId\":3,\"VGroundOhmUnitId\":1,\"WGroundOhmUnitId\":3,\"UVOhmUnitId\":1,\"UWOhmUnitId\":2,\"VWOhmUnitId\":1,\"KGroundOhmUnitId\":3,\"LGroundOhmUnitId\":1,\"MGroundOhmUnitId\":1,\"U1U2\":0,\"V1V2\":0,\"W1W2\":0,\"K1L1\":0,\"L1M1\":0,\"K1M1\":0,\"K2L2\":0,\"L2M2\":0,\"K2M2\":0,\"GeneratorRewoundLocally\":false,\"GeneratorClaimRelevantBooleanAnswerId\":2,\"InsulationComments\":false,\"GeneratorInsulationComments\":\"\"},\"Transformer\":{ \"ComponentInspectionReportTransformerId\":0,\"ComponentInspectionReportId\":0,\"VestasUniqueIdentifier\":null,\"TransformerManufacturerId\":0,\"TransformerSerialNumber\":null,\"MaxTemp\":null,\"MaxTempResetDate\":\"0001-01-01T00:00:00\",\"strMaxTempResetDate\":null,\"ActionOnTransformerId\":0,\"HVCoilConditionId\":0,\"LVCoilConditionId\":0,\"HVCableConditionId\":0,\"LVCableConditionId\":0,\"BracketsId\":0,\"TransformerArcDetectionId\":0,\"ClimateId\":0,\"SurgeArrestorId\":0,\"ConnectionBarsId\":0,\"Comments\":null,\"TransformerClaimRelevantBooleanAnswerId\":null},\"General\":{ \"ComponentInspectionReportGeneralId\":0,\"ComponentInspectionReportId\":0,\"GeneralComponentGroupId\":null,\"GeneralComponentType\":null,\"VestasUniqueIdentifier\":null,\"GeneralComponentManufacturer\":null,\"GeneralOtherGearboxType\":null,\"GeneralClaimRelevantBooleanAnswerId\":null,\"GeneralOtherGearboxManufacturer\":null,\"GeneralComponentSerialNumber\":null,\"GeneralGeneratorManufacturerId\":null,\"GeneralTransformerManufacturerId\":null,\"GeneralGearboxManufacturerId\":null,\"GeneralTowerTypeId\":null,\"GeneralTowerHeightId\":null,\"GeneralBlade1SerialNumber\":null,\"GeneralBlade2SerialNumber\":null,\"GeneralBlade3SerialNumber\":null,\"GeneralControllerTypeId\":null,\"GeneralSoftwareRelease\":null,\"GeneralRamDumpNumber\":null,\"GeneralVDFTrackNumber\":null,\"GeneralPicturesIncludedBooleanAnswerId\":0,\"GeneralInitiatedBy1\":null,\"GeneralInitiatedBy2\":null,\"GeneralInitiatedBy3\":null,\"GeneralInitiatedBy4\":null,\"GeneralMeasurementsConducted1\":null,\"GeneralMeasurementsConducted2\":null,\"GeneralMeasurementsConducted3\":null,\"GeneralMeasurementsConducted4\":null,\"GeneralExecutedBy1\":null,\"GeneralExecutedBy2\":null,\"GeneralExecutedBy3\":null,\"GeneralExecutedBy4\":null,\"GeneralPositionOfFailedItem\":null},\"MainBearing\":{ \"ComponentInspectionReportMainBearingId\":0,\"ComponentInspectionReportId\":0,\"VestasUniqueIdentifier\":null,\"MainBearingLastLubricationDate\":\"0001-01-01T00:00:00\",\"strMainBearingLastLubricationDate\":null,\"MainBearingManufacturerId\":0,\"MainBearingTemperature\":0,\"MainBearingLubricationOilTypeId\":0,\"MainBearingGrease\":false,\"MainBearingLubricationRunHours\":0,\"MainBearingOilTemperature\":0,\"MainBearingTypeId\":0,\"MainBearingRevision\":0,\"MainBearingErrorLocationId\":0,\"MainBearingSerialNumber\":null,\"MainBearingRunHours\":0,\"MainBearingMechanicalOilPump\":null,\"MainBearingClaimRelevantBooleanAnswerId\":0},\"DynamicTableInputs\":{ \"Id\":0,\"CirId\":\"0\",\"Row1Col1\":\"\",\"Row1Col2\":\"\",\"Row1Col3\":\"\",\"Row1Col4\":\"\",\"Row2Col1\":\"\",\"Row2Col2\":\"\",\"Row2Col3\":\"\",\"Row2Col4\":\"\",\"Row3Col1\":\"\",\"Row3Col2\":\"\",\"Row3Col3\":\"\",\"Row3Col4\":\"\",\"Row4Col1\":\"\",\"Row4Col2\":\"\",\"Row4Col3\":\"\",\"Row4Col4\":\"\",\"Row5Col1\":\"\",\"Row5Col2\":\"\",\"Row5Col3\":\"\",\"Row5Col4\":\"\",\"Row6Col1\":\"\",\"Row6Col2\":\"\",\"Row6Col3\":\"\",\"Row6Col4\":\"\",\"Row7Col1\":\"\",\"Row7Col2\":\"\",\"Row7Col3\":\"\",\"Row7Col4\":\"\",\"Row8Col1\":\"\",\"Row8Col2\":\"\",\"Row8Col3\":\"\",\"Row8Col4\":\"\",\"Row9Col1\":\"\",\"Row9Col2\":\"\",\"Row9Col3\":\"\",\"Row9Col4\":\"\",\"Row10Col1\":\"\",\"Row10Col2\":\"\",\"Row10Col3\":\"\",\"Row10Col4\":\"\",\"Row1Col5\":\"\",\"Row1Col6\":\"\",\"Row2Col5\":\"\",\"Row2Col6\":\"\",\"Row3Col5\":\"\",\"Row3Col6\":\"\",\"Row4Col5\":\"\",\"Row4Col6\":\"\",\"Row5Col5\":\"\",\"Row5Col6\":\"\",\"Row6Col5\":\"\",\"Row6Col6\":\"\",\"Row7Col5\":\"\",\"Row7Col6\":\"\",\"Row8Col5\":\"\",\"Row8Col6\":\"\",\"Row9Col5\":\"\",\"Row9Col6\":\"\",\"Row10Col5\":\"\",\"Row10Col6\":\"\"},\"ImageData\":[{\"ImageId\":0,\"ImageDataString\":\"data:image/jpeg;base64,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\",\"ImageDescription\":\"1.jpg\",\"ImageOrder\":0,\"InspectionDesc\":\"\",\"IsPlateType\":false}],\"ImageDataInfo\":{\"IsPlateTypeNotPossible\":false,\"PlateTypeNotPossibleReason\":\"\"},\"TurbineData\":{\"TurbineMatrixId\":null,\"Turbine\":null,\"Frequency\":50,\"Manufacturer\":\"Vestas\",\"MarkVersion\":\"MK-\",\"NominelPower\":660,\"NominelPowerId\":0,\"Placement\":\"Onshore\",\"PowerRegulation\":\"\",\"RotorDiameter\":47.0,\"SmallGenerator\":0,\"TemperatureVariant\":\"STD\",\"Voltage\":690,\"CountryIsoId\":0,\"Country\":null,\"Site\":null,\"LocalTurbineId\":\"\"},\"HtmlStr\":\"\"}";
    //        CIRList = Newtonsoft.Json.JsonConvert.DeserializeObject<ComponentInspectionReport>(str);
    //        //Act section
    //        //obj = serviceAgent.SaveCIRData(CIRList);
    //        //Assert section
    //        //on URL Service Report no is not validating with turbine no/cim case no
    //        //http://sapdxc.vestas.net:50000/WSAdapter/CS0601/ValidateServiceReportNumber
    //        //Assert.AreNotEqual(obj.CirID, 0);
    //    }

    //    [TestMethod]
    //    public void Validate_cim_case_no()
    //    {
    //        bool obj=true;
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<bool>(s => s.ValidateCIMCaseNumber(It.IsAny<string>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        string CimCaseNumber = "1232";
    //        //Act section
    //        obj = serviceAgent.ValidateCIMCaseNumber(CimCaseNumber);
    //        //Assert section
    //        Assert.AreEqual(obj,true);
    //    }

    //    [TestMethod]
    //    public void Validate_turbine_no()
    //    {
    //        bool obj = true;
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<bool>(s => s.ValidateTurbineNumber(It.IsAny<string>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        string TurbineNumber = "1232";
    //        //Act section
    //        obj = serviceAgent.ValidateTurbineNumber(TurbineNumber);
    //        //Assert section
    //        Assert.AreEqual(obj, true);
    //    }

    //    [TestMethod]
    //    public void Validate_service_report_no()
    //    {
    //        bool obj = true;
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<bool>(s => s.IsValidServiceReportNumber(It.IsAny<string>(), It.IsAny<string>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        string ServiceReportNumber = "1";
    //        string TurbineNumber = "1232";
    //        //Act section
    //        obj = serviceAgent.IsValidServiceReportNumber(ServiceReportNumber, TurbineNumber);
    //        //Assert section
    //        Assert.AreEqual(obj, true);
    //        //Assert.AreEqual(obj, false);
    //    }

    //    [TestMethod]
    //    public void Get_Cir_Master_Data()
    //    {
    //        List<CirMasterData> obj = new List<CirMasterData>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<CirMasterData>>(s => s.GetMasterData()).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        //Act section
    //        obj = serviceAgent.GetMasterData();
    //        //Service problem
    //        //Assert section
    //        //Problem with validation url
    //        //Assert.AreEqual(obj, true);
    //        Assert.IsNotNull(obj);
    //    }

    //    [TestMethod]
    //    public void Get_Master_Data_By_Name()
    //    {
    //        List<CirMasterTable> obj = new List<CirMasterTable>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<CirMasterTable>>(s => s.GetMasterDataByName(It.IsAny<string>(), It.IsAny<string>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        string TableName= "SearchProfile";
    //        string UserId= @"VESTAS\mggub";
    //        //Arrange section
    //        //Act section
    //        obj = serviceAgent.GetMasterDataByName(TableName, UserId);
    //        //Service problem
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }


    //    [TestMethod]
    //    public void Get_CIM_Case_Data()
    //    {
    //        List<CirCIMCaseTable> obj = new List<CirCIMCaseTable>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<CirCIMCaseTable>>(s => s.GetCIMCaseData()).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        //Act section
    //        obj = serviceAgent.GetCIMCaseData();
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }

    //    [TestMethod]
    //    public void Get_All_View()
    //    {
    //        List<CirViewData> obj = new List<CirViewData>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<CirViewData>>(s => s.GetAllView()).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        //Act section
    //        obj = serviceAgent.GetAllView();
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }
    //    //public List<Cir.Sync.Services.DataContracts.CirLogs> GetCirLog(long CirDataId)
    //    [TestMethod]
    //    public void Get_Cir_Log()
    //    {
    //        List<Cir.Sync.Services.DataContracts.CirLogs> obj = new List<Cir.Sync.Services.DataContracts.CirLogs>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<Cir.Sync.Services.DataContracts.CirLogs>>(s => s.GetCIRLog(It.IsAny<long>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        long CirID = 306663;
    //        //Act section
    //        obj = serviceAgent.GetCirLog(CirID);
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }
    //    [TestMethod]
    //    public void Get_Cir_Comment_History()
    //    {
    //        List<CirCommentHistorys> obj = new List<CirCommentHistorys>();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<List<CirCommentHistorys>>(s => s.GetCirCommentHistory(It.IsAny<long>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        long CirID = 306663;
    //        //Act section
    //        obj = serviceAgent.GetCirCommentHistory(CirID);
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }
    //    //public Cir.Sync.Services.DataContracts.Hotlist GetHotlist(int id)
    //    [TestMethod]
    //    public void Get_Hot_list()
    //    {
    //        Cir.Sync.Services.DataContracts.Hotlist obj = new Cir.Sync.Services.DataContracts.Hotlist();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<Cir.Sync.Services.DataContracts.Hotlist>(s => s.GetHotlist(It.IsAny<int>())).Returns(obj);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
    //        //Arrange section
    //        int Id =14;
    //        //Act section
    //        obj = serviceAgent.GetHotlist(Id);
    //        //Assert section
    //        Assert.IsNotNull(obj);
    //    }
    //    //public List<CirCommentHistorys> GetCirCommentHistory(long CirDataId)
    //    [TestCleanup]
    //    public void Clean_CirData()
    //    {
    //        wcfMock = null;
    //    }
    //}
}
