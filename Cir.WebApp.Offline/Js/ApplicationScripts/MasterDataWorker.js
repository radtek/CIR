importScripts("../encryption/sjcl.js");
importScripts("offlineTransactions.js");
importScripts("indexeddb.shim.min.js");
onmessage = function (e) {

    SyncData(e.data);
};
var window = self;
var totalMasterItem = 0;
var processedtables = 0;
function SyncData(masterdataresponse) {
    try {
        dbtransaction.openDatabase(function () {
            var masterData = masterdataresponse;
            console.log(masterData.length);
            totalMasterItem = masterData.length;
            var itemProcessed = 0;
            for (var i = 0, obj; obj = masterData[i]; i++) {
                try {
                    itemProcessed++;
                    var tableName = obj.key;
                    if (tableName) {
                        var keyID = 0;
                        var reccount = obj.masterKeyValue.length;
                        var recnumber = 0
                        for (var idx = 0, childObj; childObj = obj.masterKeyValue[idx]; idx++) {
                            if (childObj.key == '') {
                                keyID++;
                                childObj.key = keyID;
                            }
                            else {
                                keyID = 0;
                            }
                            recnumber++;
                            reccount = obj.masterKeyValue.length;
                            /* if (dbtransaction.CheckTable(tableName))
                             {
                                 var masterDataObjet = {};
                                 masterDataObjet.text = childObj.value;
                                 masterDataObjet[tableName + 'ID'] = childObj.key;
     
                                 dbtransaction.addMasterDataItemIntoTable(masterDataObjet, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                             }
                             else {
                                 if (recnumber == reccount) { processedtables++; SendUpdate(tableName); }
                             }*/

                            switch (tableName) {
                                case 'BladeColor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeColorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BladeDamagePlacement':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeDamagePlacementID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BladeEdge':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeEdgeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BladeInspectionData':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeInspectionDataID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BladeLength':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeLengthID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BladeManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'FaultCodeArea':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeAreaID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'FaultCodeCause':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeCauseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'FaultCodeType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ReportType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ReportTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ComponentInspectionReportType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentInspectionReportTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TurbineRunStatus':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TurbineRunStatusID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ComponentUpTowerSolution':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentUpTowerSolutionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ComponentGroup':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentGroupID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TransformerManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TransformerManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearboxManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TowerType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TowerTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TowerHeight':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TowerHeightID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ControllerType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ControllerTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'HotItem':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, HotItemID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'SkiipackFailureCause':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, SkiipackFailureCauseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TransformerManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TransformerManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ActionOnTransformer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionOnTransformerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'CoilCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CoilConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'CableCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CableConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Brackets':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BracketsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ArcDetection':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ArcDetectionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Climate':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ClimateID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'SurgeArrestor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, SurgeArrestorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ConnectionBars':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ConnectionBarsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'MainBearingManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MainBearingManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'MainBearingErrorLocation':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MainBearingErrorLocationID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'OilType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OilTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Coupling':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CouplingID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ActionToBeTakenOnGenerator':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionToBeTakenOnGeneratorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorDriveEnd':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorDriveEndID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorNonDriveEnd':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorNonDriveEndID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorRotor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorRotorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GeneratorCover':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorCoverID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'AirToAirCoolerExternal':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, AirToAirCoolerExternalID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'AirToAirCoolerInternal':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, AirToAirCoolerInternalID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'OhmUnit':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OhmUnitID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearboxType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearboxRevision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxRevisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'MechanicalOilPump':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MechanicalOilPumpID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'OilLevel':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OilLevelID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ActionToBeTakenOnGearbox':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionToBeTakenOnGearboxID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ElectricalPump':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ElectricalPumpID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ShrinkElement':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShrinkElementID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'FilterBlockType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FilterBlockTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'InlineFilter':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, InlineFilterID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DebrisOnMagnet':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DebrisOnMagnetID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Vibrations':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, VibrationsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Noise':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, NoiseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DebrisGearbox':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DebrisGearboxID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'OverallGearboxCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OverallGearboxConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'HousingError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, HousingErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearDamageCategory':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearDamageCategoryID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'Damage':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DamageParentGearError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageParentGearErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DamageClassCategoryDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageClassCategoryDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BearingType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BearingError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'BearingPos':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingPosID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DamageDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ShaftType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShaftTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ShaftError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShaftErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'MagnetPos':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MagnetPosID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'ServiceReportNumberType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ServiceReportNumberTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'TemplateDynamicTableDef':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TemplateDynamicTableDefID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'GearTypeDamageDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearTypeDamageDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl); } });
                                    break;
                                case 'DynamicFields':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DynamicFieldsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                default:
                                    if (recnumber == reccount) { processedtables++; SendUpdate(tableName); }
                                    break;

                            }

                        }
                    }

                }
                catch (ex) {
                    console.log("MasterData WebWorker Error :" + ex);
                    postMessage("Error", null);
                }
            }

        }, function () { console.log("MasterData WebWorker indexdberror"); postMessage("Error", null);  });
    }
    catch (ex) {
        console.log("MasterData WebWorker Error :" + ex);
        postMessage("Error", null);
    }
}

function SendUpdate(tableName) {
    var progress = {};
    console.log("Done::" + processedtables + " total::" + totalMasterItem);
    itemProcessed = processedtables;
    progress.tablename = tableName;
    if (itemProcessed == totalMasterItem)
        progress.percentage = 100;
    else
        progress.percentage = parseInt((itemProcessed / totalMasterItem) * 100);
    // $('#ExcelExportModal .progress-bar').css('width', progress.percentage + '%').attr('aria-valuenow', progress.percentage);
    console.log('percentage: ' + progress.percentage + '; table: ' + progress.tablename);
    if (progress.percentage == 100) {
        console.log("Done::");
    }
    postMessage(progress, null);
}