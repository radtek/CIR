var localdbversion = 30
//var window = self;
var dbtransaction = new function () {

    var masterTables = [
       'MasterDataSyncStatus',
       'ReportType',
       'ComponentInspectionReportType',
       'TurbineData',
       'TurbineRunStatus',
       'ComponentUpTowerSolution',
       'BladeManufacturer',
       'BladeLength',
       'BladeColor',
       'BladeDamagePlacement',
       'BladeEdge',
       'BladeInspectionData',
       'FaultCodeCause',
       'FaultCodeType',
       'FaultCodeArea',
       'UserInfo',
       'CurrentUser',
       'ComponentGroup',
       'GeneratorManufacturer',
       'TransformerManufacturer',
       'GearboxManufacturer',
       'TowerType',
       'TowerHeight',
       'ControllerType',
       'HotItem',
       'SkiipackFailureCause',
       'TransformerManufacturer',
       'ActionOnTransformer',
       'CoilCondition',
       'CableCondition',
       'Brackets',
       'ArcDetection',
       'Climate',
       'SurgeArrestor',
       'ConnectionBars',
       'UserPin',
       'MainBearingManufacturer',
       'MainBearingErrorLocation',
       'OilType',
       'GeneratorManufacturer',
       'Coupling',
       'ActionToBeTakenOnGenerator',
       'GeneratorDriveEnd',
       'GeneratorNonDriveEnd',
       'GeneratorRotor',
       'GeneratorCover',
       'AirToAirCoolerExternal',
       'AirToAirCoolerInternal',
       'OhmUnit',
       'GearboxType',
       'GearboxRevision',
       'MechanicalOilPump',
       'OilLevel',
       'ActionToBeTakenOnGearbox',
       'ElectricalPump',
       'ShrinkElement',
       'FilterBlockType',
       'InlineFilter',
       //'LocationType',
       'Vibrations',
       'Noise',
       'DebrisGearbox',
       'OverallGearboxCondition',
       'DebrisOnMagnet',
       'HousingError',
       'GearType',
       'GearDamageCategory',
       'Damage',
       'DamageParentGearError',
       'BearingType',
       'BearingError',
       'BearingPos',
       'DamageDecision',
       'ShaftType',
       'ShaftError',
       'MagnetPos',
       'TemplateDynamicTableDef',
       'AuthTokenInfo',
       'ServiceReportNumberType',
       'DamageClassCategoryDecision',
       'GearTypeDamageDecision',
       'ServiceInfoNotification',
       'CIRIDParam',
       'Country',
       'DynamicFields',
      'TmpBlobStorage',
       { name: 'CirDataJson', key: 'id', unique: false },
       { name: 'CirTemplates', key: 'id', unique: false },
       { name: 'CirImageBlobs', key: 'cirId', unique: false },
       { name: 'AuthTokenInfoFormio', key: 'AuthTokenInfoID', unique: false },
       { name: 'CurrentUserFormio', key: 'CurrentUserID', unique: false },
       { name: 'UserInfoFormio', key: 'UserInfoID', unique: false },
       { name: 'CirBlobData', key: 'imageId', unique: false },
       { name: 'CirImageThumbnails', key: 'cirId', unique: false },
       { name: 'HotList', key: 'id', unique: false },
       { name: 'CimCase', key: 'value', unique: false }

    ];
    //'DynamicFields'
    // 'global' variable to store reference to the database
    var isIDBMigrationRunning = 0;
    var db;
    /* keep track of which salts have been used. */
    var form, usedIvs = { '': 1 }, usedSalts = { '': 1 };


    function encrypt(ptext) {
        var iv = sjcl.codec.hex.toBits("5BA31526 CE3375D0 901CD3EE BC94FB7A"), password = "vfr5yHu1S", key = sjcl.codec.hex.toBits('983D1D2E 3DBFC1FD 4F8E4227 C56AE57D'), adata = "", aes, plaintext = ptext, rp = {}, ct, p;

        p = {
            adata: adata,
            iter: '1000',
            mode: 'ccm',
            ts: parseInt(64),
            ks: parseInt(128)
        };
        p.iv = iv
        p.salt = sjcl.codec.hex.toBits('BF6C7C6E 73658B04');
        ct = sjcl.encrypt(password || key, JSON.stringify(plaintext), p, rp).replace(/,/g, ",\n");
        return ct;
    }
    /* Decrypt a message */
    function decrypt(ctext) {
        var myobj = ctext.data;
        var ctext = myobj;
        var iv = sjcl.codec.hex.toBits("5BA31526 CE3375D0 901CD3EE BC94FB7A"), password = "vfr5yHu1S", key = sjcl.codec.hex.toBits('983D1D2E 3DBFC1FD 4F8E4227 C56AE57D'), adata = "", aes, ciphertext = ctext, rp = {}, plaintext;

        if (ciphertext.match("{")) {
            /* it's jsonized */
            try {
                plaintext = sjcl.decrypt(password || key, ciphertext, {}, rp);
                return JSON.parse(plaintext);
            } catch (e) {
                alert("Can't decrypt: " + e);
                return;
            }
        } else {
            /* it's raw */
            alert("Can't decrypt: format error");
        }
    }

    databaseOpen(function () {
        console.log("Connected to CIM_InspectionReport");
    });

    function databaseOpen(callback, onIndexDBerror) {
        navigator.browserdetail = (function () {
            var ua = navigator.userAgent, tem,
            M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
            if (/trident/i.test(M[1])) {
                tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
                return 'IE ' + (tem[1] || '');
            }
            if (M[1] === 'Chrome') {
                tem = ua.match(/\b(OPR|Edge)\/(\d+)/);
                if (tem != null) return tem.slice(1).join(' ').replace('OPR', 'Opera');
            }
            M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
            if ((tem = ua.match(/version\/(\d+)/i)) != null) M.splice(1, 1, tem[1]);
            return M.join(' ');
        })();
        var browsername = navigator.browserdetail.split(' ')[0].toLocaleLowerCase();
        var browserversion = navigator.browserdetail.split(' ')[1] != undefined ? parseInt(navigator.browserdetail.split(' ')[1]) : 0;
        if ((browsername == "msie") || (browsername == "opera" && browserversion < 44)
            || (browsername == "chrome" && browserversion < 49) || (browsername == "firefox" && browserversion < 52) || (browsername == "safari" )) // If Internet Explorer, return version number
        {
            alert("This application is not supported by your current browser. Please use Chrome or the desktop application.");
            return;
        }
        var indexedDB = window.indexedDB || window.mozIndexedDB || window.webkitIndexedDB || window.msIndexedDB || window.shimIndexedDB;
        if (!indexedDB) {
            if (onIndexDBerror != undefined && onIndexDBerror != null) {
                onIndexDBerror();
            }
            else {
                alert("Your browser doesn't support a stable version of IndexedDB. Such and such feature will not be available.");
                return;
            }

        }
        //sjcl.random.startCollectors();
        // Open a database, specify the name and version
        var version = localdbversion;
        var request = indexedDB.open('CIM_InspectionReport', version);

        // Run migrations if necessary
        request.onupgradeneeded = function (e) {


            isIDBMigrationRunning = 1;
            db = e.target.result;
            e.target.transaction.onerror = function (e) {
                isIDBMigrationRunning = 0;
                console.log("IDBMigration Error" + e);

                alert("IDBMigration Error" + e);
            };
            e.target.transaction.onsuccess = function (e) {
                isIDBMigrationRunning = 0;
                console.log("IDBMigration Done");
                alert("IDBMigration Error on suceess" + e.version);
            };

            var txn = e.target.transaction;

            if (e.oldVersion <= 28) {
                if (!db.objectStoreNames.contains('CirDataCommon')) {
                    var objectStore = db.createObjectStore("CirDataCommon", { keyPath: "CirDataCommonID" });
                    objectStore.createIndex("CirDataLocalID", "CirDataLocalID", { unique: false });
                }
                else {
                    RemoveEncryptionMigration(txn, 'CirDataCommon');
                }
                //Master tables
                masterTables.forEach(function (masterdatatable) {
                    if (masterdatatable.constructor.name === "String") {
                        if (!db.objectStoreNames.contains(masterdatatable) && !db.objectStoreNames.contains(masterdatatable.name)) {
                            if (masterdatatable.name != '' && masterdatatable.name != undefined) {

                                db.createObjectStore(masterdatatable.name, { keyPath: masterdatatable.key });
                            }
                            else {
                                db.createObjectStore(masterdatatable, { keyPath: masterdatatable + 'ID' });
                            }

                            console.log(masterdatatable + ' table created locally');
                        }
                        else {
                            RemoveEncryptionMigration(txn, masterdatatable);
                        }
                    }
                    else {
                        db.createObjectStore(masterdatatable.name, { keyPath: masterdatatable.key });
                    }
                });
            }
            else {
                if (!db.objectStoreNames.contains('CirDataCommon')) {
                    var objectStore = db.createObjectStore("CirDataCommon", { keyPath: "CirDataCommonID" });
                    objectStore.createIndex("CirDataLocalID", "CirDataLocalID", { unique: false });
                }

                //Master tables
                masterTables.forEach(function (item) {
                    if (!db.objectStoreNames.contains(item) && !db.objectStoreNames.contains(item.name)) {

                        if (item.name != '' && item.name != undefined) {
                            db.createObjectStore(item.name, { keyPath: item.key });
                        }
                        else {
                            db.createObjectStore(item, { keyPath: item + 'ID' });

                        }
                        // db.createObjectStore(item, { keyPath: item + 'ID' });
                        console.log(item + ' table created locally');
                    }
                });
            }
            DeleteextraStores(db);

        };

        request.onsuccess = function (e) {
            db = e.target.result;
            console.log("IDBMigration Done Successfully");
            if (isIDBMigrationRunning == 1) {
                isIDBMigrationRunning = 0;
                location.reload();
            }
            callback();
        };
        request.onerror = function (e) {
            isIDBMigrationRunning = 0;
            databaseError(e);
        }
    }

    function RemoveEncryptionMigration(transaction, table) {
        var store = transaction.objectStore(table);
        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;
            var item = null;
            if (result) {
                try {
                    item = decrypt(result.value);
                }
                catch (e) {
                    if (e.name == "MasterKeyNotProvidedError") {
                        item = result.value;
                    }
                }
                if (item != null) {
                    var request = store.put(item);
                    request.oncomplete = function (e) {
                        console.log(' Copied');
                    };
                    request.onerror = function (e) {
                        console.log(' Copied Error');
                    }
                }
                result.continue();

                // Reach the end of the data
            } else {
                console.log(table + ' migration completed');
            }
        };

    }

    function DeleteextraStores(migrationdb) {
        // Transaction tables

        if (migrationdb.objectStoreNames.contains('CirDataBlade')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataBlade")
        }
        if (migrationdb.objectStoreNames.contains('CirDataBladeDamage')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataBladeDamage");

        }
        if (migrationdb.objectStoreNames.contains('CirDataGeneral')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataGeneral");

        }
        if (migrationdb.objectStoreNames.contains('CirImages')) {
            var objectStore = migrationdb.deleteObjectStore("CirImages");

        }
        if (migrationdb.objectStoreNames.contains('CirDataSkiipack')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataSkiipack");

        }
        if (migrationdb.objectStoreNames.contains('CirDataSkiipackFailedComponent')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataSkiipackFailedComponent");

        }
        if (migrationdb.objectStoreNames.contains('CirDataSkiipackNewComponent')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataSkiipackNewComponent");

        }
        if (migrationdb.objectStoreNames.contains('CirDataTransformer')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataTransformer");

        }
        if (migrationdb.objectStoreNames.contains('CirDataMainBearing')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataMainBearing");

        }
        if (migrationdb.objectStoreNames.contains('CirDataGenerator')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataGenerator");

        }
        if (migrationdb.objectStoreNames.contains('CirDataGearbox')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataGearbox");

        }
        if (migrationdb.objectStoreNames.contains('CirDataDynamicTable')) {
            var objectStore = migrationdb.deleteObjectStore("CirDataDynamicTable");
        }
    }

    this.openDatabase = function (callback, onerror) {

        if (db == null) {
            databaseOpen(function () {
                console.log("Connected to CIM_InspectionReport");
                callback();
            }, function () {
                if (onerror != undefined && onerror != null)
                    onerror();
            });

        }
        else {
            if (isIDBMigrationRunning == 0) {
                callback();
            }
            else {
                //  setTimeout(this.openDatabase(callback, onerror), 3000);
            }
        }

    }
    this.CheckTable = function (tablename) {
        return db.objectStoreNames.contains(tablename);
    }
    //Adding items into table for web worker
    this.addMasterDataItemIntoTable = function (items, table, currentRecordNumber, totalRecords, callback) {
        var transaction = db.transaction([table], 'readwrite');
        var store = transaction.objectStore(table);
        //idbID = items[table + 'ID'];
        //var encrypted = encrypt(items);
        //var myObject = new Object();
        //myObject.data = encrypted;
        //myObject[table + 'ID'] = idbID;
        var request = store.put(items);
        // var request = store.put(myObject);
        transaction.oncomplete = function (e) {
            callback(table, currentRecordNumber, totalRecords);
        };
        request.onerror = databaseError;
    }
    //Adding items into table
    this.addItemIntoTable = function (items, table, callback) {
        var transaction = db.transaction([table], 'readwrite');
        var store = transaction.objectStore(table);
        //idbID = items[table + 'ID'];
        //var encrypted = encrypt(items);
        //var myObject = new Object();
        //myObject.data = encrypted;
        //myObject[table + 'ID'] = idbID;
        var request = store.put(items);
        // var request = store.put(myObject);
        transaction.oncomplete = function (e) {
            callback();
        };
        request.onerror = databaseError;
    }
    //Adding items into table
    this.addItemIntoTransactionTable = function (items, table, callback) {
        var transaction = db.transaction([table], 'readwrite');
        var store = transaction.objectStore(table);
        //idbID = items[table + 'ID'];
        //IDBIndex = items['CirDataLocalID'];
        //var encrypted = encrypt(items);
        //var myObject = new Object();
        //myObject.data = encrypted;
        //myObject[table + 'ID'] = idbID;
        //myObject['CirDataLocalID'] = IDBIndex;
        var request = store.put(items);
        //var request = store.put(myObject);
        transaction.oncomplete = function (e) {
            callback();
        };
        request.onerror = databaseError;
    }
    //Handling DB errors
    function databaseError(e) {
        console.error('An error has occurred during connected to CIM_InspectionReport database', e);
        NotifyMe("", 'An error has occurred during connected to CIM_InspectionReport local database', "danger");
    }
    //Get Items
    this.getItemfromTable = function (table, callback) {
        //if (table == 'CurrentUserFormio')
        //{
        //    table = 'CurrentUser';
        //}

        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);

        // Get everything in the store
        var keyRange
        if (table == 'CimCase') {
            keyRange = IDBKeyRange.lowerBound(-1);
        }
        else {
            keyRange = IDBKeyRange.lowerBound(0);
        }
        var cursorRequest = store.openCursor(keyRange);

        // This fires once per row in the store. So, for simplicity,
        // collect the data in an array (data), and pass it in the
        // callback in one go.
        var data = [];
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;

            // If there's data, add it to array
            if (result) {
                //try {
                //    data.push(decrypt(result.value));
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data.push(result.value);
                //}
                data.push(result.value);
                result.continue();

                // Reach the end of the data
            } else {
                callback(data);
            }
        };
    }

    this.getItemfromTablePromise = function (table) {
        var deferred = $.Deferred();
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);

        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);

        var data = [];
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;
            if (result) {
                data.push(result.value);
                result.continue();
            } else {
                deferred.resolve(data);
            }
        };
        return deferred;
    }

    //Get Items
    //Get Items
    this.BindDropDown = function (selectElement) {

        var deferredObject = $.Deferred();
        var selectprop = selectElement.data();
        var table = selectprop.datatable;
        if (table == undefined || table == null)
            deferredObject.resolve(selectElement);
        else {
            var transaction = db.transaction([table], 'readonly');
            var store = transaction.objectStore(table);

            // Get everything in the store
            var keyRange = IDBKeyRange.lowerBound(0);
            var cursorRequest = store.openCursor(keyRange);

            // This fires once per row in the store. So, for simplicity,
            // collect the data in an array (data), and pass it in the
            // callback in one go.
            var data = [];
            cursorRequest.onsuccess = function (e) {
                var result = e.target.result;

                // If there's data, add it to array
                if (result) {
                    //try {
                    //    data.push(decrypt(result.value));
                    //}
                    //catch (e) {
                    //    if (e.name == "MasterKeyNotProvidedError")
                    //        data.push(result.value);
                    //}
                    data.push(result.value);
                    result.continue();

                    // Reach the end of the data
                } else {
                    try {
                        if (selectprop.sort != undefined && selectprop.sort != null && selectprop.sort == true) {
                            data.sort(function (a, b) {
                                if (a.text > b.text) return 1;
                                else if (a.text < b.text) return -1;
                                else return 0
                            })
                        }
                        data.forEach(function (item) {
                            selectElement.append($('<option>', {
                                value: item[selectprop.valuefield],
                                text: item[selectprop.textfield]
                            }));
                        });

                        if (selectprop.sort != undefined && selectprop.sort != null && selectprop.sort == true) {
                            var options = selectElement.find('option');
                            var natext = (selectprop.topitem != undefined && selectprop.topitem != null) ? selectprop.topitem : "N/A";
                            var naoption = $.grep(options, function (e) {
                                return e.text == natext
                            });
                            $(naoption).insertBefore($(options[0]));

                            // $(naoption).prop('selected', true);
                        }
                        if (selectprop.defaultvalue != undefined && selectprop.defaultvalue != null) {
                            selectElement.find("option[value='" + selectprop.defaultvalue + "']").prop('selected', true);
                        }
                        else {
                            var options = selectElement.find('option');
                            var naoption = $.grep(options, function (e) {
                                return ($.trim(e.text) == "" || $.trim(e.value) == "")
                            });
                            if (naoption != null && naoption.length > 0) {
                                $(naoption).insertBefore($(options[0]));
                                $(naoption).prop('selected', true);
                            }
                            else {
                                if (selectprop.insertlable == undefined || selectprop.insertlable == true) {
                                    $('<option>', {
                                        value: "",
                                        text: ""
                                    }).insertBefore($(options[0]));
                                }
                            }
                            var options1 = selectElement.find('option');
                            var naoption1 = $.grep(options1, function (e) {
                                return ($.trim(e.text) == "" || $.trim(e.value) == "")
                            });
                            if (naoption1 != null && naoption1.length > 0) {
                                $(naoption1).prop('selected', true);
                            }
                        }

                        $(selectElement).trigger("chosen:updated");

                        //$('.chosen-select').chosen({
                        //    placeholder_text_multiple: "Select Project/Initiative...",
                        //    no_results_text: "Oops, nothing found!"
                        //});

                        //$(selectElement).attr("data-placeholder", " Select ");
                        //callback(selectElement, index);
                        deferredObject.resolve(selectElement);
                    }
                    catch (e) {
                        //callback(selectElement, index);
                        deferredObject.resolve(selectElement);
                    }
                }
            };

            return deferredObject.promise();
        }
    }

    this.BindDynamicDropDown = function (cimCaseNo, selectElement) {
        var deferredObject = $.Deferred();
        var selectprop = selectElement.data();
        var table = selectprop.datatable;
        if (table == undefined || table == null)
            deferredObject.resolve(selectElement);
        else {
            var transaction = db.transaction(['DynamicFields'], 'readonly');
            var store = transaction.objectStore('DynamicFields');

            // Get everything in the store
            var keyRange = IDBKeyRange.lowerBound(0);
            var cursorRequest = store.openCursor(keyRange);

            // This fires once per row in the store. So, for simplicity,
            // collect the data in an array (data), and pass it in the
            // callback in one go.
            var data = [];
            cursorRequest.onsuccess = function (e) {
                var resultTarget = e.target.result;
                if (resultTarget) {
                    var resultText = resultTarget.value.text;
                    var resultJson = jQuery.parseJSON(resultText);
                    var CimCaseNum = resultJson.CIMCaseNo;
                    //data.push(resultTarget.value);
                    //resultTarget.continue();
                    if (cimCaseNo == resultJson.CIMCaseNo) {
                        var fields = resultJson.Fields;
                        var flength = fields.length;
                        for (i = 0; i < flength; i++) {
                            if (table == fields[i].FieldId) {
                                for (j = 0; j < fields[i].FieldValues.length; j++) {
                                    var result = fields[i].FieldValues[j];
                                    if (result) {
                                        data.push(result);
                                    }
                                }

                            }
                        }
                    }
                    resultTarget.continue();
                }
                else {
                    try {
                        data.forEach(function (item) {
                            if (selectElement.find('option[value=' + item[selectprop.valuefield] + ']').length == 0) {
                                selectElement.append($('<option>', {
                                    value: item[selectprop.valuefield],
                                    text: item[selectprop.textfield]
                                }));
                            }
                        });
                        if (selectprop.sort != undefined && selectprop.sort != null && selectprop.sort == true) {
                            var options = selectElement.find('option');
                            var natext = (selectprop.topitem != undefined && selectprop.topitem != null) ? selectprop.topitem : "N/A";
                            var naoption = $.grep(options, function (e) {
                                return e.text == natext
                            });
                            $(naoption).insertBefore($(options[0]));

                            // $(naoption).prop('selected', true);
                        }
                        if (selectprop.defaultvalue != undefined && selectprop.defaultvalue != null) {
                            selectElement.find("option[value='" + selectprop.defaultvalue + "']").prop('selected', true);
                        }
                        else {
                            var options = selectElement.find('option');
                            var naoption = $.grep(options, function (e) {
                                return ($.trim(e.text) == "" || $.trim(e.value) == "")
                            });
                            if (naoption != null && naoption.length > 0) {
                                $(naoption).insertBefore($(options[0]));
                                $(naoption).prop('selected', true);
                            }
                            else {
                                if (selectprop.insertlable == undefined || selectprop.insertlable == true) {
                                    $('<option>', {
                                        value: "",
                                        text: ""
                                    }).insertBefore($(options[0]));
                                }
                            }
                            var options1 = selectElement.find('option');
                            var naoption1 = $.grep(options1, function (e) {
                                return ($.trim(e.text) == "" || $.trim(e.value) == "")
                            });
                            if (naoption1 != null && naoption1.length > 0) {
                                $(naoption1).prop('selected', true);
                            }
                        }

                        $(selectElement).trigger("chosen:updated");
                        deferredObject.resolve(selectElement);
                    }
                    catch (e) {
                        deferredObject.resolve(selectElement);
                    }
                }
                // If there's data, add it to array

            };

            return deferredObject.promise();
        }
    }

    //Get Items by Id
    this.getItemByIdfromTable = function (table, id, callback) {
        //  if (!id || parseFloat(id) <= 0)
        //   callback(null);
        if (id == "")
            callback(null);
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);
        var storedata = store.get(id);
        var data = {};
        storedata.onsuccess = function (e) {
            var result = e.target.result;
            if (result) {
                //try {
                //    data = decrypt(result);
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data = decrypt(result);
                //}
                data = result;
                callback(data);
            }
        }
        storedata.onerror = databaseError;
    }

    this.getItemByIdIfExists = function (table, id, callbackExists, callbackNotExists) {
        if (id == "")
            callback(null);
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);
        var storedata = store.get(id);
        var data = {};
        storedata.onsuccess = function (e) {
            var result = e.target.result;
            if (result) {
                data = result;
                callbackExists(data);
            }
            else {
                callbackNotExists();
            }
        }

        storedata.onerror = databaseError;
    }

    this.getItemByIdfromTable = function (table, id, callback, errorCallback) {
        if (id == "")
            callback(null);
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);
        var storedata = store.get(id);
        var data = {};
        storedata.onsuccess = function (e) {
            var result = e.target.result;
            if (result) {
                data = result;
                callback(data);
            }
            else {
                if (errorCallback !== undefined) {
                    errorCallback();
                }
            }
        }
        storedata.onerror = databaseError;
    }

    //Deleting items
    this.deleteItemfromTable = function (table, id, callback) {
        var transaction = db.transaction([table], 'readwrite');
        var store = transaction.objectStore(table);
        var request = store.delete(id);
        transaction.oncomplete = function (e) {
            callback();
        };
        request.onerror = databaseError;
    }

    //Deleting items
    this.deleteAllItemfromTable = function (table, callback) {
        var transaction = db.transaction([table], 'readwrite');
        var store = transaction.objectStore(table);
        var request = store.clear();
        transaction.oncomplete = function (e) {
            callback();
        };
        request.onerror = databaseError;
    }

    //Get Items by Id
    this.seedServiceInfroNotification = function (table, obj, callback) {
        if (obj == null || !obj.id || parseFloat(obj.id) <= 0)
            callback(null, obj);
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);
        var storedata = store.get(obj.id);
        var data = {};
        storedata.onsuccess = function (e) {
            var result = e.target.result;
            if (result) {
                //try {
                //    data = decrypt(result);
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data = decrypt(result);
                //}
                data = result;
            }
            callback(data, obj);
        }
        storedata.onerror = databaseError;
    }
    this.getServiceInfroNotificationAll = function (callback) {
        var table = 'ServiceInfoNotification'
        var transaction = db.transaction([table], 'readonly');
        var store = transaction.objectStore(table);

        // Get everything in the store
        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);

        // This fires once per row in the store. So, for simplicity,
        // collect the data in an array (data), and pass it in the
        // callback in one go.
        var data = [];
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;

            // If there's data, add it to array
            if (result) {
                //try {
                //    data.push(decrypt(result.value).objet);
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data.push(result.value.objet);
                //}
                data.push(result.value.objet);
                result.continue();

                // Reach the end of the data
            } else {
                callback(data);
            }
        };
    }

    this.getCIRDataByID = function (localID, callback) {
        if (!localID || parseFloat(localID) <= 0)
            return;

        var transaction = db.transaction(["CirDataCommon"], "readonly");
        var objectStore = transaction.objectStore("CirDataCommon");
        var index = objectStore.index("CirDataLocalID");
        var storeCirDataCommon = index.get(localID);
        var data = [];
        storeCirDataCommon.onsuccess = function (e) {
            var result = e.target.result;
            // If there's data, add it to array
            if (result) {
                //try {
                //    data.push(decrypt(result));
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data.push(result);
                //}
                data.push(result);
                callback(data);
                // Reach the end of the data
            }
        }
    }
    this.getCIRDatabyLocalID = function (localID, callback) {
        if (!localID || parseFloat(localID) <= 0)
            return;

        var transaction = db.transaction(["CirDataCommon"], "readonly");
        var objectStore = transaction.objectStore("CirDataCommon");
        var index = objectStore.index("CirDataLocalID");
        var storeCirDataCommon = index.get(localID);
        var data = [];
        storeCirDataCommon.onsuccess = function (e) {
            var result = e.target.result;
            // If there's data, add it to array
            if (result) {
                //try {
                //    data.push(decrypt(result));
                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                //        data.push(result);
                //}
                data.push(result);
                callback(data);
                // Reach the end of the data
            }
        }
    }



    //sujan

    this.deleteCirCommonDataByID = function (localID, callback) {
        if (!localID || parseFloat(localID) <= 0)
            return;

        console.log(localID);

        var transaction = db.transaction(["CirDataCommon"], "readwrite");
        var objectStore = transaction.objectStore("CirDataCommon");
        var index = objectStore.index("CirDataLocalID");
        var storeCirDataCommon = index.openCursor(IDBKeyRange.only(localID));
        storeCirDataCommon.onsuccess = function () {
            var cursor = storeCirDataCommon.result;
            if (cursor) {
                cursor.delete();
                cursor.continue;
            }
        }
    }

    var MobileUnclockPage = new function () {
        this.loadMobileUnclockPage = function () {

            dbtransaction.getItemfromTable('UserInfo', renderCirData);
            function renderCirData(CirData) {
                CirData.forEach(function (cirItem) {
                    dbPin = cirItem.pin;
                });
            }
        };
    };
    this.getDynamicInputFromCimCase = function (cimCaseNumber, callback) {
        var transaction = db.transaction(['TemplateDynamicTableDef'], 'readonly');
        var store = transaction.objectStore('TemplateDynamicTableDef');

        // Get everything in the store
        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);

        // This fires once per row in the store. So, for simplicity,
        // collect the data in an array (data), and pass it in the
        // callback in one go.
        var data = [];
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;
            // If there's data, add it to array
            if (result) {
                //try {
                //    var inputResult = decrypt(result.value);
                //    if (inputResult) {
                //        data.push(inputResult);
                //    }

                //}
                //catch (e) {
                //    if (e.name == "MasterKeyNotProvidedError")
                if (result.value) {
                    data.push(result.value);
                }
                //}
                result.continue();

                // Reach the end of the data
            } else {
                callback(data);
            }
        };
    }

    ////New function is Creatd by Siddharth Chauhan on 06-06-2016
    ////To show CIR Status in the local CIR list. and filter was not working for the LocalCIR search.
    ////TaskNo. : 75303
    //this.getLocalCIRItems = function (filterObject, callback) {
    //    var transaction = db.transaction('CirDataCommon', 'readonly');
    //    var store = transaction.objectStore('CirDataCommon');

    //    // Get everything in the store
    //    var keyRange = IDBKeyRange.lowerBound(0);
    //    var cursorRequest = store.openCursor(keyRange);

    //    // This fires once per row in the store. So, for simplicity,
    //    // collect the data in an array (data), and pass it in the
    //    // callback in one go.
    //    var data = [];
    //    cursorRequest.onsuccess = function (e) {
    //        var result = e.target.result;

    //        // If there's data, add it to array
    //        if (result) {
    //            try {
    //                var filterMatch = true;

    //                if (filterObject.cirId != "" && (!(String(result.value.CirDataLocalID).includes(filterObject.cirId)))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.name != "" && (!(String(decrypt(result.value).CirData.componentInspectionReportName).toLowerCase().includes(filterObject.name.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.turbineNumber != "" && (!(String(decrypt(result.value).CirData.turbineNumber).toLowerCase().includes(filterObject.turbineNumber.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.turbineType != "" && (!(String(decrypt(result.value).CirData.turbineType).toLowerCase().includes(filterObject.turbineType.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.reportType != "" && (!(String(decrypt(result.value).CirData.reportTypeId).toLowerCase().includes(filterObject.reportType.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.cimCase != "" && (!(String(decrypt(result.value).CirData.cimCaseNumber).toLowerCase().includes(filterObject.cimCase.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.runStatus != "" && (!(String(decrypt(result.value).CirData.beforeInspectionTurbineRunStatusId).toLowerCase().includes(filterObject.runStatus.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.sbu != "" && (!(String(decrypt(result.value).CirData.sBURecommendation).toLowerCase().includes(filterObject.sbu.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.cirType != "" && (!(String(decrypt(result.value).CirData.componentInspectionReportTypeId).toLowerCase().includes(filterObject.cirType.toLowerCase())))) {
    //                    filterMatch = false;
    //                }
    //                if (filterObject.turbineCountry != "" && (!(String(decrypt(result.value).CirData.country).toLowerCase().includes(filterObject.turbineCountry.toLowerCase())))) {
    //                    filterMatch = false;
    //                }

    //                if (filterMatch) {
    //                    data.push(decrypt(result.value));
    //                }
    //            }
    //            catch (e) {
    //                if (e.name == "MasterKeyNotProvidedError")
    //                    data.push(result.value);
    //            }
    //            result.continue();

    //            // Reach the end of the data
    //        } else {
    //            callback(data);
    //        }
    //    };
    //}

    this.getLocalCIRItems = function (filterObject, callback) {
        var transaction = db.transaction('CirDataCommon', 'readonly');
        var store = transaction.objectStore('CirDataCommon');

        // Get everything in the store
        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);

        // This fires once per row in the store. So, for simplicity,
        // collect the data in an array (data), and pass it in the
        // callback in one go.
        var data = [];
        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;

            // If there's data, add it to array
            if (result && result.value != undefined && result.value != null) {

                var filterMatch = true;

                if (filterObject.cirId != "" && (!(String(result.value.CirDataLocalID).includes(filterObject.cirId)))) {
                    filterMatch = false;
                }
                if (filterObject.name != "" && (!(String(result.value.CirData.componentInspectionReportName).toLowerCase().includes(filterObject.name.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.turbineNumber != "" && (!(String(result.value.CirData.turbineNumber).toLowerCase().includes(filterObject.turbineNumber.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.turbineType != "" && (!(String(result.value.CirData.turbineType).toLowerCase().includes(filterObject.turbineType.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.reportType != "" && (!(String(result.value.CirData.reportTypeId).toLowerCase().includes(filterObject.reportType.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.cimCase != "" && (!(String(result.value.CirData.cimCaseNumber).toLowerCase().includes(filterObject.cimCase.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.runStatus != "" && (!(String(result.value.CirData.beforeInspectionTurbineRunStatusId).toLowerCase().includes(filterObject.runStatus.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.sbu != "" && (!(String(result.value.CirData.sBURecommendation).toLowerCase().includes(filterObject.sbu.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.cirType != "" && (!(String(result.value.CirData.componentInspectionReportTypeId).toLowerCase().includes(filterObject.cirType.toLowerCase())))) {
                    filterMatch = false;
                }
                if (filterObject.turbineCountry != "" && (!(String(result.value.CirData.country).toLowerCase().includes(filterObject.turbineCountry.toLowerCase())))) {
                    filterMatch = false;
                }

                if (filterMatch) {
                    data.push(result.value);
                }

                result.continue();

                // Reach the end of the data
            } else {
                callback(data);
            }
        };
    }
};


function NotifyMe(title, message, type) {
    $.notify({
        // options
        icon: 'glyphicon glyphicon-warning-sign',
        title: title,
        message: message
    }, {
        // settings
        element: 'body',
        position: null,
        type: type,
        allow_dismiss: true,
        newest_on_top: false,
        showProgressbar: false,
        placement: {
            from: "top",
            align: "center"
        },
        offset: 20,
        spacing: 10,
        z_index: 1031,
        delay: 5000,
        timer: 1000,
        mouse_over: null,
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        onShow: null,
        onShown: null,
        onClose: null,
        onClosed: null,
        icon_type: 'class',
        template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
            '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
            '<span data-notify="icon"></span> ' +
            '<span data-notify="title">{1}</span> ' +
            '<span data-notify="message">{2}</span>' +
            '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
            '</div>' +
            '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'
    });
}