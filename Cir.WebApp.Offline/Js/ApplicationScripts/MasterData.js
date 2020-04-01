var MasterDataSync;

(function (MasterDataSync) {
    function _SetSyncStatus(status, callback) {
        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTable({ SynsStatus: status, MasterDataSyncStatusID: "1" }, 'MasterDataSyncStatus', function () {
                if (callback)
                    callback();
            });
        });
    }
    var totalMasterItem = 0;
    var processedtables = 0;
    function _GetSyncStatus(callback) {
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('MasterDataSyncStatus', function MasterDataSyncStatus(item) {
                console.log(item);
                if (item[0]) {
                    callback(item[0].SynsStatus);
                }
                else {
                    callback('required');
                }
            });
        });
    }

    function _Sync(silent, OnSuccess, OnError, OnProgress) {
        if (silent == null)
            silent = false;
        if (Offline.state == "down") {
            if (silent == false) {
                NotifyCirMessage('Error : ', "You are not online.", 'danger');
                $("#MasterDataModal").modal('hide');
            }
            if (OnError) {
                OnError('You are not online.');
            }
        } else {           
            if (silent == false) {
                $('#MasterDataModal .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);
            }
            var MobileAppclient = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');
            var MobileServiceClient =
                new WindowsAzure.MobileServiceClient($('#FormIOMobileAppUrl').val(), $('#FormIOMobileAppId').val(), '');
            dbtransaction.openDatabase(function() {
                dbtransaction.getItemfromTable('CurrentUser',
                    function CurrentUser(currentuser) {
                        dbtransaction.getItemfromTable('CurrentUserFormio',
                            function CurrentUserFormio(currentuserformio) {
                                if (currentuser && currentuserformio) {
                                    if (currentuser.length > 0 && currentuserformio.length > 0) {
                                        currentuser.forEach(function(item) {
                                            MobileAppclient.currentUser = item.objet;
                                        });
                                        currentuserformio.forEach(function(item) {
                                            MobileServiceClient.currentUser = item.objet;
                                        });
                                        if (silent == false) {
                                            $('#MasterDataModal .progress-bar').css('width', 25 + '%')
                                                .attr('aria-valuenow', 25);
                                        }
                                        if (OnProgress) {
                                            var progress = {};
                                            progress.tablename = "";
                                            progress.percentage = 25;
                                            OnProgress(progress);
                                        }
                                        MobileAppclient.invokeApi('MasterData',
                                            {
                                                method: 'GET'
                                            }).done(function(result) {
                                                MobileServiceClient
                                                    .invokeApi('UserData/Get',
                                                        {
                                                            method: 'GET'
                                                        }).done(function(cosmosData) {

                                                        if (result && cosmosData) {
                                                            if (silent == false) {
                                                                $('#MasterDataModal .progress-bar')
                                                                    .css('width', 50 + '%')
                                                                    .attr('aria-valuenow', 50);
                                                            }
                                                            if (OnProgress) {
                                                                var progress = {};
                                                                progress.tablename = "";
                                                                progress.percentage = 50;
                                                                OnProgress(progress);
                                                            }
                                                            totalMasterItem =
                                                                result.result.length + cosmosData.result.length;
                                                            processedtables = 0;

                                                            _SyncDataClassic(result.result,
                                                                silent,
                                                                OnSuccess,
                                                                OnError,
                                                                OnProgress);
                                                            _SyncCosmosDBData(cosmosData.result,
                                                                silent,
                                                                OnSuccess,
                                                                OnError,
                                                                OnProgress);
                                                        } else {
                                                            if (silent == false) {
                                                                NotifyCirMessage('Error : ',
                                                                    "Fetching master data error",
                                                                    'danger');
                                                                $("#MasterDataModal").modal('hide');
                                                            }
                                                            _SetSyncStatus('error');
                                                            if (OnError)
                                                                OnError("Fetching master data error");
                                                        }
                                                    });
                                            },
                                            function(error) {
                                                console.log(error);
                                                if (silent == false) {
                                                    NotifyCirMessage('Error : ',
                                                        "Fetching master data error. Please click on [Sync Master] on Left Menu to Sync manually.",
                                                        'danger');
                                                    $("#MasterDataModal").modal('hide');
                                                }
                                                _SetSyncStatus('error');
                                                if (OnError)
                                                    OnError("Fetching master data error :" + error);
                                            });
                                    }
                                }
                            });
                    });
            });
        }
    }

    function _SyncWithoutCir(silent, OnSuccess, OnError, OnProgress) {
        if (silent == null)
            silent = false;
        if (Offline.state == "down") {
            if (silent == false) {
                NotifyCirMessage('Error : ', "You are not online.", 'danger');
                $("#MasterDataModal").modal('hide');
            }
            if (OnError) {
                OnError('You are not online.');
            }
        } else {

            if (silent == false) {
                $('#MasterDataModal .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);
            }
            var MobileAppclient = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');
            var MobileServiceClient =
                new WindowsAzure.MobileServiceClient($('#FormIOMobileAppUrl').val(), $('#FormIOMobileAppId').val(), '');
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('CurrentUser',
                    function CurrentUser(currentuser) {
                        dbtransaction.getItemfromTable('CurrentUserFormio',
                            function CurrentUserFormio(currentuserformio) {
                                if (currentuser && currentuserformio) {
                                    if (currentuser.length > 0 && currentuserformio.length > 0) {
                                        currentuser.forEach(function (item) {
                                            MobileAppclient.currentUser = item.objet;
                                        });
                                        currentuserformio.forEach(function (item) {
                                            MobileServiceClient.currentUser = item.objet;
                                        });
                                        if (silent == false) {
                                            $('#MasterDataModal .progress-bar').css('width', 25 + '%')
                                                .attr('aria-valuenow', 25);
                                        }
                                        if (OnProgress) {
                                            var progress = {};
                                            progress.tablename = "";
                                            progress.percentage = 25;
                                            OnProgress(progress);
                                        }
                                        MobileAppclient.invokeApi('MasterData',
                                            {
                                                method: 'GET'
                                            }).done(function (result) {
                                                MobileServiceClient
                                                    .invokeApi('UserData/GetMasterSync',
                                                        {
                                                            method: 'GET'
                                                        }).done(function (cosmosData) {

                                                        if (result && cosmosData) {
                                                            if (silent == false) {
                                                                $('#MasterDataModal .progress-bar')
                                                                    .css('width', 50 + '%')
                                                                    .attr('aria-valuenow', 50);
                                                            }
                                                            if (OnProgress) {
                                                                var progress = {};
                                                                progress.tablename = "";
                                                                progress.percentage = 50;
                                                                OnProgress(progress);
                                                            }
                                                            totalMasterItem =
                                                                result.result.length + cosmosData.result.length;
                                                            processedtables = 0;

                                                            _SyncDataClassic(result.result,
                                                                silent,
                                                                OnSuccess,
                                                                OnError,
                                                                OnProgress);
                                                            _SyncCosmosDBData(cosmosData.result,
                                                                silent,
                                                                OnSuccess,
                                                                OnError,
                                                                OnProgress);
                                                        } else {
                                                            if (silent == false) {
                                                                NotifyCirMessage('Error : ',
                                                                    "Fetching master data error",
                                                                    'danger');
                                                                $("#MasterDataModal").modal('hide');
                                                            }
                                                            _SetSyncStatus('error');
                                                            if (OnError)
                                                                OnError("Fetching master data error");
                                                        }
                                                    });
                                            },
                                            function (error) {
                                                console.log(error);
                                                if (silent == false) {
                                                    NotifyCirMessage('Error : ',
                                                        "Fetching master data error. Please click on [Sync Master] on Left Menu to Sync manually.",
                                                        'danger');
                                                    $("#MasterDataModal").modal('hide');
                                                }
                                                _SetSyncStatus('error');
                                                if (OnError)
                                                    OnError("Fetching master data error :" + error);
                                            });
                                    }
                                }
                            });
                    });
            });
        }
    }

    function _SyncCosmosDBData(cosmosDBData, silent, OnSuccess, OnError, OnProgress) {
        dbtransaction.openDatabase(function () {
            for (var i = 0, obj; obj = cosmosDBData[i]; i++) {
                if (obj.dataList.length == 0) {
                    processedtables++;
                    continue;
                }
                const tableName = obj.tableName;
                let recnumber = 0;
                let reccount = obj.dataList.length;
                try {
                    for (var j = 0, data; data = obj.dataList[j]; j++) {
                        recnumber++;
                        dbtransaction.addMasterDataItemIntoTable(data, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                    }
                }
                catch (ex) {
                    if (silent == false) {
                        console.log("MasterData Classic Error :" + ex);
                        NotifyCirMessage('Error : ', "Fetching master data error. Please click on [Sync Master] on Left Menu to Sync manually.", 'danger');
                        $("#MasterDataModal").modal('hide');
                    }
                    _SetSyncStatus('error');
                    if (OnError)
                        OnError("Fetching master data error :" + error);
                }
            }
        });
    }

    function _SyncDataClassic(masterdataresponse, silent, OnSuccess, OnError, OnProgress) {
        dbtransaction.openDatabase(function () {
            var masterData = masterdataresponse;
            console.log(masterData.length);

            for (var i = 0, obj; obj = masterData[i]; i++) {
                try {
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

                            switch (tableName) {
                                case 'BladeColor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeColorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BladeDamagePlacement':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeDamagePlacementID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BladeEdge':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeEdgeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BladeInspectionData':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeInspectionDataID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BladeLength':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeLengthID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BladeManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BladeManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'FaultCodeArea':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeAreaID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'FaultCodeCause':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeCauseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'FaultCodeType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FaultCodeTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ReportType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ReportTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ComponentInspectionReportType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentInspectionReportTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TurbineRunStatus':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TurbineRunStatusID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ComponentUpTowerSolution':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentUpTowerSolutionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ComponentGroup':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ComponentGroupID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TransformerManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TransformerManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearboxManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TowerType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TowerTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TowerHeight':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TowerHeightID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ControllerType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ControllerTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'HotItem':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, HotItemID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'SkiipackFailureCause':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, SkiipackFailureCauseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TransformerManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TransformerManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ActionOnTransformer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionOnTransformerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'CoilCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CoilConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'CableCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CableConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Brackets':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BracketsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ArcDetection':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ArcDetectionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Climate':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ClimateID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'SurgeArrestor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, SurgeArrestorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ConnectionBars':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ConnectionBarsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'MainBearingManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MainBearingManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'MainBearingErrorLocation':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MainBearingErrorLocationID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'OilType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OilTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorManufacturer':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorManufacturerID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Coupling':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, CouplingID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ActionToBeTakenOnGenerator':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionToBeTakenOnGeneratorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorDriveEnd':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorDriveEndID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorNonDriveEnd':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorNonDriveEndID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorRotor':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorRotorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GeneratorCover':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GeneratorCoverID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'AirToAirCoolerExternal':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, AirToAirCoolerExternalID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'AirToAirCoolerInternal':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, AirToAirCoolerInternalID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'OhmUnit':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OhmUnitID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearboxType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearboxRevision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearboxRevisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'MechanicalOilPump':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MechanicalOilPumpID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'OilLevel':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OilLevelID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ActionToBeTakenOnGearbox':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ActionToBeTakenOnGearboxID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ElectricalPump':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ElectricalPumpID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ShrinkElement':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShrinkElementID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'FilterBlockType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, FilterBlockTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'InlineFilter':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, InlineFilterID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'DebrisOnMagnet':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DebrisOnMagnetID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Vibrations':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, VibrationsID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Noise':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, NoiseID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'DebrisGearbox':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DebrisGearboxID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'OverallGearboxCondition':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, OverallGearboxConditionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'HousingError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, HousingErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearDamageCategory':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearDamageCategoryID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'Damage':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'DamageParentGearError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageParentGearErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'DamageClassCategoryDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageClassCategoryDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BearingType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BearingError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'BearingPos':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, BearingPosID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'DamageDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, DamageDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ShaftType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShaftTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ShaftError':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ShaftErrorID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'MagnetPos':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, MagnetPosID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'ServiceReportNumberType':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, ServiceReportNumberTypeID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'TemplateDynamicTableDef':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, TemplateDynamicTableDefID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
                                    break;
                                case 'GearTypeDamageDecision':
                                    dbtransaction.addMasterDataItemIntoTable({ text: childObj.value, GearTypeDamageDecisionID: childObj.key }, tableName, recnumber, reccount, function (tbl, recno, count) { if (recno == count) { processedtables++; SendUpdate(tbl, silent, OnSuccess, OnProgress); } });
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
                    if (silent == false) {
                        console.log("MasterData Classic Error :" + ex);
                        NotifyCirMessage('Error : ', "Fetching master data error. Please click on [Sync Master] on Left Menu to Sync manually.", 'danger');
                        $("#MasterDataModal").modal('hide');
                    }
                    _SetSyncStatus('error');
                    if (OnError)
                        OnError("Fetching master data error :" + error);
                }
            }

        });
    }

    function SendUpdate(tableName, silent, OnSuccess, OnProgress) {
        var progress = {};
        console.log("Done::" + processedtables + " total::" + totalMasterItem);
        progress.tablename = tableName;
        if (processedtables == totalMasterItem)
            progress.percentage = 100;
        else
            progress.percentage = parseInt((processedtables / totalMasterItem) * 100);
        if (silent == false) {
            $('#MasterDataModal .progress-bar').css('width', parseInt(50 + (progress.percentage / 2)) + '%').attr('aria-valuenow', parseInt(50 + (progress.percentage / 2)));
        }
        console.log('percentage: ' + progress.percentage + '; table: ' + progress.tablename);
        if (progress.percentage == 100) {
            console.log("Done::");
            if (silent == false) {
                $("#MasterDataModal").modal('hide');
            }
            _SetSyncStatus('done');
            _GetUserInfo().done(function (objUser) {
                CallClientApi("UserMasterSyncItem/" + encodeURIComponent(objUser.userPrincipalName), "POST", null).done(function (result) {
                });
            });
            if (OnSuccess)
                OnSuccess();
        }
        else {
            progress.percentage = parseInt(50 + (progress.percentage / 2));
        }
        if (OnProgress)
            OnProgress(progress);
    }

    MasterDataSync.Sync = _Sync;
    MasterDataSync.SyncWithoutCir = _SyncWithoutCir;
    MasterDataSync.SetSyncStatus = _SetSyncStatus;
    MasterDataSync.GetSyncStatus = _GetSyncStatus;

})(MasterDataSync || (MasterDataSync = {}));