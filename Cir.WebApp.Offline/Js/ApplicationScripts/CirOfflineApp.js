var cirOfflineApp = new function () {
    var __isRivision = false;
    var cirLocalObject = {};
    var _SaveCirTimer = null;
    this.showDialog = 1;
    //-1 Error  - Grid 1
    // 1 Draft  -- Grid 2
    // 2 Submitted -- Grid 2
    // 3 Synced     -- Grid 3
    // 4 Conflict    -- Grid 2
    // 5 Processing  -- Grid 2 (Same as Submitted)
    // 6 ReAssigned
    // 7 Locked by Admin
    // 8 Deleted by Admin
    // 9 Delegated




    // Cir Status 
    //1	Initial
    //2	Awaiting approval
    //3	Rejected
    //4	Accepted
    //5	On Hold

    //1	Blade
    //2	Gearbox
    //3	General
    //4	Generator
    //6	Main Bearing
    //7	Skiipack
    //5	Transformer
    //8 Simplified 
    this.convertUserIdFromPrincipalNameToInitials = function(userId)
    {
        if (userId.indexOf("@") === -1) return userId;

        var divisionMark = '_';

        if (userId.indexOf("#EXT#@") !== -1)
        {
            divisionMark = '_';
        }
        else
        {
            divisionMark = '@';
        }

        var underscoreLocation = userId.lastIndexOf(divisionMark);
        var initialsFromEmail = userId.substr(0, underscoreLocation);
        return initialsFromEmail;
    };



    this.generateKey = function () {
        var d = new Date().getTime();
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    };


    this.SaveCirSchemaJsonWithData = function (cir) {
        let deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTable(cir, 'CirDataJson',
                function () {
                    deferredObject.resolve(cir.id);
                });
        });

        return deferredObject.promise();
    }

    this.GetCirDataJsonById = function (id) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('CirDataJson', id,
                function (item) {
                    deferredObject.resolve(item);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.UpdateCirDataJson = function (cirJson) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTransactionTable(cirJson, 'CirDataJson',
                function () {
                    deferredObject.resolve();
                });
        });

        return deferredObject.promise();
    }

    this.getCirDataJsonList = function () {
        const deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirDataJson',
                function (cirDataJsonList) {
                    let userName = CurrentUserInfo.Name.toLowerCase();
                    cirDataJsonList = cirDataJsonList.filter(x => x.createdBy == userName || x.modifiedBy == userName || x.delegatedTo == userName || x.lockedBy == userName);
                    deferredObject.resolve(cirDataJsonList);
                });
        });

        return deferredObject.promise();
    }

    this.getCurrentUserInfo = function()
    {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CurrentUser', function (userInfo) {
                deferredObject.resolve(userInfo);
            });
        });

        return deferredObject.promise();
    }

    this.GetCirTemplateList = function () {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirTemplates', function (templates) {
                deferredObject.resolve(templates);
            });
        });

        return deferredObject.promise();
    }

    this.GetBrandsName = function () {
        let deferredObject = $.Deferred();
        let userName;
            cirOfflineApp.getCurrentUserInfo().done(function (userInfo) {
                userName = userInfo[0].userInfo.userPrincipalName;
                cirOfflineApp.GetBrands(userName).done(function(userBrands){
                    deferredObject.resolve(userBrands);
                })
            });
            return deferredObject.promise();
    }

    this.GetBrands = function (userName) {
        let deferredObject = $.Deferred();
        let userBrands = [];
        CallSyncApi("BrandData?userId=" + encodeURIComponent(userName), "GET", "").done(function (response) {
            var userBrands = response.result;
            deferredObject.resolve(userBrands);
        })
                                                                     .fail(function () {
                                                                         deferredObject.reject();
                                                                     });

        return deferredObject.promise();
    }
        
       
    


    this.GetCirBrandList = function () {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('Brand', function (brands) {
                deferredObject.resolve(brands);
            });
        });

        return deferredObject.promise();
    }

    this.GetCirTemplateById = function (templateId) {
        let deferredObject = $.Deferred();
        if (!templateId) {
            var obj = { name: "emptyTemplate" };
            deferredObject.resolve(obj);
        } else {
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemByIdIfExists('CirTemplates', templateId,
                    function (template) {
                        deferredObject.resolve(template);
                    },
                    function () {
                        deferredObject.reject();
                    });
            });
        }
        return deferredObject.promise();
    };

    this.GetCirTemplateById4LocalHistory = function (templateId) {
        let deferredObject = $.Deferred();
        if (!templateId) {
            var obj = { name: "emptyTemplate" };
            deferredObject.resolve(obj);
        } else {
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemByIdIfExists('CirTemplates', templateId,
                    function (template) {
                        deferredObject.resolve(template);
                    },
                    function () {
                        deferredObject.resolve(null);
                    });
            });
        }
        return deferredObject.promise();
    };

    this.UpdateCirTemplate = function (template) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTransactionTable(template, 'CirTemplates',
                function () {
                    deferredObject.resolve();
                });
        });

        return deferredObject.promise();
    }

    this.GetCirBrandById = function (brandId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('Brand', brandId,
                function (brand) {
                    deferredObject.resolve(brand);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.GetHotListItems = function () {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('HotList', function (hotListItems) {
                deferredObject.resolve(hotListItems);
            });
        });

        return deferredObject.promise();
    }

    this.SaveImageblobList = function (blobList) {
        let deferredObject = $.Deferred();
        var blobListArray = [];
        for (var i = 0; i < blobList.blobList.length; i++) {
            if (blobList.blobList[i].state.toLowerCase == 'deleted') {
                if (!!blobList.blobList[i].url && !!blobList.blobList[i].binaryDataUrl) {
                    blobListArray.push(blobList.blobList[i]);
                }
            }
            else {
                blobListArray.push(blobList.blobList[i]);
            }
        }
        blobList.blobList = blobListArray;
        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTable(
                blobList,
                'CirImageBlobs',
                function () {
                    deferredObject.resolve();
                });
        });

        return deferredObject.promise();
    }

    this.GetCirImageBlobList = function (cirId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('CirImageBlobs', cirId,
                function (template) {
                    deferredObject.resolve(template);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.GetAllCirImageBlobList = function () {
        let deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirImageBlobs', function (CirImageBlobs) {
                deferredObject.resolve(CirImageBlobs);
            },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.GetCirImageBlobListElements = function (cirId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('CirImageBlobs', cirId,
                function (template) {
                    deferredObject.resolve(template.blobList);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.DeleteCirImageBlobList = function (cirId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.deleteItemfromTable('CirImageBlobs', cirId,
                function () {
                    deferredObject.resolve();
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.GetImageThumbnails = function (cirId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('CirImageThumbnails', cirId,
                function (image) {
                    deferredObject.resolve(image.imageThumbnails);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.SaveImageThumbnails = function (cirId, imageThumbnails) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTable(
                {
                    cirId: cirId,
                    imageThumbnails: imageThumbnails
                },
                'CirImageThumbnails',
                function () {
                    deferredObject.resolve();
                });
        });

        return deferredObject.promise();
    }

    this.SaveBlob = function (cirId, imageId, imageBlob) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTable(
                {
                    cirId: cirId,
                    imageId: imageId,
                    binaryData: imageBlob
                },
                'CirBlobData',
                function () {
                    deferredObject.resolve();
                });
        });

        return deferredObject.promise();
    }

    this.GetBlob = function (imageId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdIfExists('CirBlobData', imageId,
                function (imageBlob) {
                    deferredObject.resolve(imageBlob);
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }
    this.DeleteBlob = function (imageId) {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.deleteItemfromTable('CirBlobData', imageId,
                function () {
                    deferredObject.resolve();
                },
                function () {
                    deferredObject.reject();
                });
        });

        return deferredObject.promise();
    }

    this.GetCimCaseItems = function () {
        let deferredObject = $.Deferred();

        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CimCase', function (cimCaseItems) {
                deferredObject.resolve(cimCaseItems);
            });
        });

        return deferredObject.promise();
    }

    this.softDeleteCirLocalData = function (id) {
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdfromTable('CirDataCommon', id, function (item) {
                dbtransaction.addItemIntoTransactionTable(
                    {
                        CirDataCommonID: id,
                        CirDataLocalID: item.CirDataLocalID,
                        UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                        CreatedDate: item.CreatedDate,
                        Status: item.Status,
                        StatusMessage: 'CIR is for mark for delete',
                        StatusDetailMessage: 'This CIR is in mark for deleted. Deleted CIR will be removed after Sync.',
                        CirData: '',
                        CirDataTemp: '',
                        UserInitial: $('#hdnUserPrincipal').val(),
                        IsDirty: true,
                        Deleted: true,
                        CirStatus: item.CirStatus,
                        RowVersion: item.RowVersion,
                        Remarks: item.Remarks,
                        RelatedUserCirDataID: item.RelatedUserCirDataID
                    }, 'CirDataCommon', function () {
                        waitingDialog.hide();

                        // console.log('Cir Local Marked for deletion. CirDataCommonID : ' + id + ' CIRID: ' + $('#cirLocalID').val());
                    });
                // deferredObject.resolve();
            });

        });
    };

    this.softDeleteNewCirLocalData = function (id) {
        let deferredObject = $.Deferred();

        cirOfflineApp.GetCirDataJsonById(id).done(function(item) {
            //if cir exists only locally, just remove it
            if (item.cirId == null) {
                cirOfflineApp.deleteNewCirLocalData(item);
            }
            else {
                item.modifiedOn = new Date();
                item.modifiedBy = CurrentUserInfo.Name.toLowerCase();
                item.lockedBy = "";
                item.deleting = true;
                item.deletedFromCache = "true";
                cirOfflineApp.UpdateCirDataJson(item).done(function() {
                    deferredObject.resolve();
                }).fail(function() {
                    deferredObject.reject();
                });
            }
        }).fail(function() {
            deferredObject.reject();
        });

        return deferredObject.promise();
    };

    this.deleteNewCirLocalData = function (item) {
        var deferredObject = $.Deferred();
        var id;
        if (!!item.id)
            id = item.id;
        else
            id = item;

        dbtransaction.deleteItemfromTable('CirDataJson', id, function () {
            deferredObject.resolve(true);
        });
        return deferredObject.promise();
    };

    this.softDeleteAllCirLocalData = function () {
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirDataCommon', function (items) {
                $.each(items, function (i, item) {
                    cirOfflineApp.softDeleteCirLocalData(item.CirDataCommonID);
                });

            });

        });
    }

    this.deleteCirLocalData = function (id) {
        //Set as Deleted true..Remember to deleted permanently later after deleted from Azure
        var deferredObject = $.Deferred();
        dbtransaction.deleteItemfromTable('CirDataCommon', id, function () {
            //console.log("Local Data with Id " + id + " deleted.");
            deferredObject.resolve(true);
        });
        return deferredObject.promise();
    }

    this.deleteAllCirLocalData = function (id) {
        dbtransaction.deleteAllItemfromTable('CirDataCommon', function () {
            //console.log("All Local Data deleted.");
        });
    }

    this.saveToLocalStorage = function (id, approve) {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            cirOfflineApp.findCirLocalData(id).done(function (result) {
                if (result != false && result.length != 0) {
                    dbtransaction.deleteCirCommonDataByID(result.CirDataLocalID, function () { });
                    var cirStatus = result.CirStatus;
                    if (approve != undefined && approve != null && approve == true) {
                        cirStatus = 10; // Request for approve
                    }
                    dbtransaction.addItemIntoTransactionTable(
                        {
                            CirDataCommonID: result.CirDataCommonID,
                            CirDataLocalID: result.CirDataLocalID,
                            UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                            CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                            Status: 1,
                            StatusMessage: 'CIR is in Draft version',
                            StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                            CirData: cirLocalObject,
                            CirDataTemp: {},
                            UserInitial: $('#hdnUserPrincipal').val(),
                            IsDirty: true,
                            Deleted: false,
                            CirStatus: cirStatus,
                            Remarks: result.Remarks,
                            RelatedUserCirDataID: result.RelatedUserCirDataID,
                            RowVersion: result.RowVersion

                        }, 'CirDataCommon', function () {
                            deferredObject.resolve(true);
                        });
                }
                else {
                    var cirStatus = 1;
                    if (approve != undefined && approve != null && approve == true) {
                        cirStatus = 10; // Request for approve
                    }
                    dbtransaction.addItemIntoTransactionTable(
                        {
                            CirDataCommonID: $('#CirDataCommonID').val(),
                            CirDataLocalID: $('#cirLocalID').val(),
                            UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                            CreatedDateCreatedDate: GetDateTimeStringFromDateObject(new Date()),
                            Status: 1,
                            StatusMessage: 'CIR is in Draft version',
                            StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                            CirData: cirLocalObject,
                            CirDataTemp: {},
                            UserInitial: $('#hdnUserPrincipal').val(),
                            IsDirty: true,
                            Deleted: false,
                            CirStatus: cirStatus,
                            Remarks: "",
                            RelatedUserCirDataID: 0,
                            RowVersion: 0

                        }, 'CirDataCommon', function () {
                            deferredObject.resolve(true);
                        });

                }


            });
        });
        return deferredObject.promise();
    }

    this.addToLocalStorage = function () {

        var isDirty = false;


        $('#CirForm :input').each(function () {
            if ($(this).data('initialValue') != null && $(this).attr('type') != "hidden") {
                if ($(this).data('initialValue') != $(this).val()) {
                    isDirty = true;
                }
            }
        });

        var newid = getQueryStringValueHash('id');
        var id = $('#CirDataCommonID').val();

        dbtransaction.openDatabase(function () {
            if (isDirty == true) {
                cirOfflineApp.findCirLocalData(id).done(function (result) {
                    if (result != false && result.length != 0) {
                        dbtransaction.addItemIntoTransactionTable(
                            {
                                CirDataCommonID: result.CirDataCommonID,
                                CirDataLocalID: result.CirDataLocalID,
                                UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                                CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                                Status: 1,
                                StatusMessage: 'CIR is in Draft version',
                                StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                                CirData: cirLocalObject,
                                CirDataTemp: {},
                                UserInitial: $('#hdnUserPrincipal').val(),
                                IsDirty: true,
                                Deleted: false,
                                CirStatus: result.CirStatus,
                                RowVersion: result.RowVersion,
                                Remarks: result.Remarks,
                                RelatedUserCirDataID: result.RelatedUserCirDataID
                            }, 'CirDataCommon', function () {

                            });
                    }
                    else {
                        dbtransaction.addItemIntoTransactionTable(
                            {
                                CirDataCommonID: $('#CirDataCommonID').val(),
                                CirDataLocalID: $('#cirLocalID').val(),
                                UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                                CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                                Status: 1,
                                StatusMessage: 'CIR is in Draft version',
                                StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                                CirData: cirLocalObject,
                                CirDataTemp: {},
                                UserInitial: $('#hdnUserPrincipal').val(),
                                IsDirty: true,
                                Deleted: false,
                                CirStatus: 1,
                                RowVersion: 0,
                                Remarks: "",
                                RelatedUserCirDataID: 0
                            }, 'CirDataCommon', function () {

                            });

                    }


                });
            }




        });
    };

    this.findCirLocalDataforPull = function (id) {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
                var _user = $('#hdnUserPrincipal').val();
                if (CirLocalDataList.length == 0) {
                    deferredObject.resolve(false);
                }
                else {
                    try {
                        //var u = CirLocalDataList[0].UserInitial;
                        var result = $.grep(CirLocalDataList, function (i) { return (i.CirDataCommonID == id && i.UserInitial.toLowerCase() == _user.toLowerCase()) });
                        if (result == false)
                            deferredObject.resolve(result);
                        else
                            deferredObject.resolve(result[0]);
                    }
                    catch (e) {
                        console.log(e);
                        alert("Please clear your browser cache, close and reopen the browser instance, click \"ok\" to see how to do this.");
                        window.location = "http://www.refreshyourcache.com/en/home/";
                    }
                }
            });
        });
        return deferredObject.promise();
    };

    //Calls from Azure Sync.js////////////
    this.findCirLocalData = function (id) {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
                var _user = $('#hdnUserPrincipal').val();
                if (CirLocalDataList.length == 0) {
                    deferredObject.resolve(false);
                }
                else {
                    //var u = CirLocalDataList[0].UserInitial;
                    var result = $.grep(CirLocalDataList, function (i) { return (i.CirDataCommonID == id && i.Deleted == false && i.UserInitial.toLowerCase() == _user.toLowerCase()) });
                    if (result == false)
                        deferredObject.resolve(result);
                    else
                        deferredObject.resolve(result[0]);
                }
            });
        });
        return deferredObject.promise();
    };


    this.getCirLocalDataForCIRStatusUpdate = function () {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
                var _user = $('#hdnUserPrincipal').val();
                if (CirLocalDataList.length == 0) {
                    deferredObject.resolve(false);
                }
                else {
                    //var u = CirLocalDataList[0].UserInitial;
                    var result = $.grep(CirLocalDataList, function (i) { return (i.Status == 3 && i.Deleted == false && i.UserInitial.toLowerCase() == _user.toLowerCase()) });
                    if (result == false)
                        deferredObject.resolve(result);
                    else
                        deferredObject.resolve(result);
                }
            });
        });
        return deferredObject.promise();
    };

    this.UpdateItemServerToLocalDB = function (serverItem) {
        var deferredObject = $.Deferred();
        dbtransaction.addItemIntoTransactionTable(
            {
                CirDataCommonID: serverItem.id,
                CirDataLocalID: serverItem.cirDataLocalID,
                UpdateBy: serverItem.updateBy,
                CreatedDate: serverItem.createdDate,
                Status: serverItem.status,
                StatusMessage: serverItem.statusMessage,
                StatusDetailMessage: serverItem.statusDetailMessage,
                CirData: JSON.parse(serverItem.cirData),
                CirDataTemp: {},
                UserInitial: serverItem.userInitial,
                IsDirty: false,
                Deleted: false,
                CirStatus: serverItem.cirStatus,
                RowVersion: serverItem.rowVersion,
                Remarks: serverItem.remarks,
                RelatedUserCirDataID: serverItem.relatedUserCirDataID
            }, 'CirDataCommon', function () {
                deferredObject.resolve();
            });
        return deferredObject.promise();
    };

    this.UpdateResolveConflictLocal = function (item, serverItemRowVersion) {
        var deferredObject = $.Deferred();
        dbtransaction.addItemIntoTransactionTable(
            {
                CirDataCommonID: item.CirDataCommonID,
                CirDataLocalID: item.CirDataLocalID,
                UpdateBy: item.UpdateBy,
                CreatedDate: item.CreatedDate,
                Status: 1,
                StatusMessage: 'CIR is in Draft version',
                StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                CirData: item.CirData,
                CirDataTemp: {},
                UserInitial: item.UserInitial,
                IsDirty: true,
                Deleted: item.Deleted,
                CirStatus: item.CirStatus,
                RowVersion: serverItemRowVersion,
                Remarks: item.Remarks,
                RelatedUserCirDataID: item.RelatedUserCirDataID
            }, 'CirDataCommon', function () {
                deferredObject.resolve();
            });
        return deferredObject.promise();
    };

    this.UpdateResolveConflictServer = function (item) {
        var deferredObject = $.Deferred();
        dbtransaction.addItemIntoTransactionTable(
            {
                CirDataCommonID: item.id,
                CirDataLocalID: item.cirDataLocalID,
                UpdateBy: item.updateBy,
                CreatedDate: item.createdDate,
                Status: item.status,
                StatusMessage: 'CIR is in Draft version',
                StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                CirData: JSON.parse(item.cirData),
                CirDataTemp: {},
                UserInitial: item.userInitial,
                IsDirty: false,
                Deleted: false,
                CirStatus: item.cirStatus,
                RowVersion: item.rowVersion,
                Remarks: item.remarks,
                RelatedUserCirDataID: item.relatedUserCirDataID
            }, 'CirDataCommon', function () {
                deferredObject.resolve();
            });
        return deferredObject.promise();
    };

    this.UpdateItemServerToLocalDBWithConflict = function (localItem) {
        var deferredObject = $.Deferred();
        dbtransaction.addItemIntoTransactionTable(
            {
                CirDataCommonID: localItem.CirDataCommonID,
                CirDataLocalID: localItem.CirDataLocalID,
                UpdateBy: localItem.UpdateBy,
                CreatedDate: localItem.CreatedDate,
                Status: 4, //Set Conflict
                StatusMessage: 'Cir is in conflict state',
                StatusDetailMessage: 'Cir is in conflict state. Please click [Edit] and resolve conflict by selecting either [Keep Local Version] or [Keep Server Version].',
                CirData: localItem.CirData,
                CirDataTemp: {},
                UserInitial: localItem.UserInitial,
                IsDirty: localItem.IsDirty,
                Deleted: localItem.Deleted,
                CirStatus: localItem.CirStatus,
                RowVersion: localItem.RowVersion,
                Remarks: localItem.Remarks,
                RelatedUserCirDataID: localItem.RelatedUserCirDataID
            }, 'CirDataCommon', function () {
                NotifyCirMessage('Error : ', 'CIR [' + localItem.CirData.componentInspectionReportName + '] is in conflicted state', 'danger');
                deferredObject.resolve();
            });
        return deferredObject.promise();
    };
    //////////////////////////////////
    this.getCirLocalData = function () {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirDataCommon', function (cirData) {
                var CirLocalDataList = [];
                var _user = $('#hdnUserPrincipal').val();
                $.each(cirData, function (i, item) {
                    var u = item.UserInitial;
                    if (item.Deleted == false && u.toLowerCase() == _user.toLowerCase()) {
                        var CirLocalData = {};
                        CirLocalData.Id = item.CirDataCommonID;
                        CirLocalData.CirDataId = item.CirData.cirDataID;
                        CirLocalData.ComponentInspectionReportId = item.CirDataLocalID;
                        CirLocalData.DisplayCirId = (item.CirDataLocalID == 0) ? 'New <i style="color:#00cc00;" class="fa fa-exclamation-circle fa-lg" title="New CIR"></i>' : item.CirDataLocalID;
                        CirLocalData.ComponentInspectionReportName = item.CirData.componentInspectionReportName;
                        CirLocalData.CimCaseNumber = item.CirData.cimCaseNumber;
                        CirLocalData.ReportTypeId = item.CirData.reportTypeId;
                        CirLocalData.TurbineType = item.CirData.turbineType;
                        CirLocalData.TurbineNumber = item.CirData.turbineNumber;
                        CirLocalData.Country = item.CirData.country;
                        CirLocalData.SBU = item.CirData.sBUName;  //Doubt on this(Local Data doesnt have SBU)
                        CirLocalData.RunStatusId = item.CirData.beforeInspectionTurbineRunStatusId;
                        CirLocalData.SiteName = item.CirData.siteName;
                        CirLocalData.CirStatus = item.CirStatus;
                        CirLocalData.Status = item.Status;
                        CirLocalData.StatusMessage = item.StatusMessage;
                        CirLocalData.StatusDetailMessage = item.StatusDetailMessage;
                        CirLocalData.UpdateBy = item.UpdateBy;
                        CirLocalData.CreatedDate = (item.CreatedDate.indexOf(":") > 0) ? item.CreatedDate : item.CreatedDate + " 00:00";
                        CirLocalData.UserInitial = item.UserInitial;
                        CirLocalData.IsDirty = item.IsDirty;
                        CirLocalData.Deleted = item.Deleted;
                        CirLocalData.Remarks = item.Remarks;
                        CirLocalData.RelatedUserCirDataID = item.RelatedUserCirDataID;
                        CirLocalData.MError = item.CirData.htmlStr;
                        CirLocalDataList.push(CirLocalData);
                    }
                });
                deferredObject.resolve(CirLocalDataList);
            });

        });
        return deferredObject.promise();
    };

    var that = this;
    this.getNewCirLocalData = function () {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirDataJson',
                function (cirData) {
                    var CirLocalDataList = [];
                    var templateDefereds = [];
                    var _user = CurrentUserInfo.Name ? CurrentUserInfo.Name.toLowerCase() : '';

                    $.each(cirData,
                        function(i, item) {
                            var relatedToMe = isNewCirRelatedToCurrentUser(item);
                            if (relatedToMe && item.state != "PendingForBa" && item.state != "Removed" && !item.deleting) {
                                var query = that.GetCirTemplateById4LocalHistory(item.cirTemplateId);
                                templateDefereds.push(query);
                                query.done(function(template) {
                                    if (template === null) {
                                        return;
                                    }

                                    var turbineNumber = item.data["txtTurbineNumber"];
                                    var cimCaseNo = item.data["ddlCimCaseNumber"];
                                    var siteName = item.data["txtSiteName"];
                                    var turbineType = item.data["txtTurbineType"];

                                    cimCaseNo = !cimCaseNo ? item.data["txtCimCaseNumber"] : cimCaseNo;

                                    var CirLocalData = {};
                                    CirLocalData.Id = item.id;
                                    CirLocalData.CirId = item.cirId;
                                    CirLocalData.CirDataId = "";
                                    CirLocalData.ComponentInspectionReportId = "";
                                    CirLocalData.DisplayCirId =(item.cirId == undefined || item.cirId == 0) ? 'New <i style="color:#00cc00;" class="fa fa-exclamation-circle fa-lg" title="New CIR"></i>' : item.cirId;
                                    CirLocalData.ComponentInspectionReportName =
                                        (siteName ? siteName : "{SiteName}")
                                        + "_"
                                        + template.name + "_"
                                        + (turbineNumber != undefined ? turbineNumber : "{TurbineNo}") + "_" + new Date().toISOString().substring(0, 10) +"_"
                                        + (cimCaseNo != undefined ? cimCaseNo : "{CimCaseNo}");
                                    CirLocalData.CimCaseNumber = cimCaseNo != undefined ? cimCaseNo : "";
                                    CirLocalData.ReportTypeId = "";
                                    CirLocalData.TurbineType = !!turbineType ? turbineType : "";
                                    CirLocalData.TurbineNumber = turbineNumber != undefined ? turbineNumber : "";
                                    CirLocalData.Country = "";
                                    CirLocalData.SBU = "";
                                    CirLocalData.RunStatusId = "";
                                    CirLocalData.SiteName = siteName != undefined ? siteName : "";
                                    CirLocalData.CirStatus = "";
                                    CirLocalData.Status = item.state;
                                    CirLocalData.StatusMessage =
                                        item.errors !== undefined && item.errors !== null && item.errors.length > 0
                                            ? item.errors.join('; \n')
                                            : "";
                                    CirLocalData.StatusDetailMessage = "";
                                    CirLocalData.UpdateBy = "";
                                    CirLocalData.CreatedDate = item.createdOn;
                                    CirLocalData.UserInitial = "";
                                    CirLocalData.IsDirty = "";
                                    CirLocalData.Deleted = "";
                                    CirLocalData.Remarks = '';
                                    CirLocalData.RelatedUserCirDataID = "";
                                    CirLocalData.MError = "";
                                    CirLocalData.IsNewCir = true;
                                    CirLocalData.delegatedTo = item.delegatedTo;
                                    CirLocalData.delegatedBy = item.delegatedBy;
                                    CirLocalData.lockedBy = item.lockedBy;
                                    CirLocalData.sqlProcessStatus = item.sqlProcessStatus;
                                    CirLocalData.imageProcessStatus = item.imageProcessStatus;
                                    CirLocalDataList.push(CirLocalData);
                                }).fail(function (e) {

                                });
                            }
                        });
                    $.when.apply($, templateDefereds).done(function () {
                        deferredObject.resolve(CirLocalDataList);
                    });
                });
        });
        return deferredObject.promise();
    };

    this.getCirLocalDataForSync = function () {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CirDataCommon', function (cirDataList) {
                deferredObject.resolve(cirDataList);
            });

        });
        return deferredObject.promise();
    };

    this.getAllDirtyCirLocalForSync = function (userId) {
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
                var result = $.grep(CirLocalDataList, function (i) { var _user = i.UserInitial; return (i.IsDirty == true && _user.toLowerCase() == userId.toLowerCase()) });
                deferredObject.resolve(result);
            });
        });
        return deferredObject.promise();
    };

    function reviver(key, val) {
        if (key)
            this[key.charAt(0).toLowerCase() + key.slice(1)] = val;
        else
            return val;
    }

    this.getLocalDraftCount = function (guid) {
        var deferredObject = $.Deferred();
        cirOfflineApp.getCirLocalData().done(function (CirLocalDataList) {
            var result = $.grep(CirLocalDataList, function (i) {
                if (guid == undefined || guid == null)
                    guid == '';
                return (i.Status != "3" && i.Id != guid)
            });
            deferredObject.resolve(result.length);
        });
        return deferredObject.promise();
    };


    //Not Used Now
    this.UpdateCir = function (resp, _item) {

        if (resp.status == true && resp.statusMessage == 'Success') {
            _item.StatusMessage = 'Cir Synced Successfully!';
            _item.StatusDetailMessage = 'Cir Synced Successfully!';
            _item.Status = 3;
            _item.CirDataLocalID = resp.cirID;
            _item.CirStatus = 1;
            _item.CirData.componentInspectionReportName = resp.cirName;
            _item.CirData.componentInspectionReportId = resp.cirID;
            _item.CirData.country = resp.turbine.country;
            _item.CirData.siteName = resp.turbine.site;
            _item.CirData.turbineType = resp.turbine.turbineType;
            _item.CirData.turbineData = {
                rotorDiameter: resp.turbine.rotorDiameter,
                nominelPower: resp.turbine.nominelPower,
                voltage: resp.turbine.voltage,
                powerRegulation: resp.turbine.powerRegulation,
                frequency: resp.turbine.frequency,
                smallGenerator: resp.turbine.smallGenerator,
                temperatureVariant: resp.turbine.temperatureVariant,
                markVersion: resp.turbine.mKVersion,
                placement: resp.turbine.onshoreOffshore,
                manufacturer: resp.turbine.turbineManufacturer,

            }
        }
        else {
            _item.StatusMessage = resp.statusMessage;
            _item.StatusDetailMessage = resp.StatusDetailMessage;
            _item.Status = -1;
            _item.CirStatus = 1;

        }
        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTransactionTable(
               {
                   CirDataCommonID: _item.CirDataCommonID,
                   CirDataLocalID: _item.CirDataLocalID,
                   UpdateBy: _item.UpdateBy, // This will be changed after Azure auth
                   CreatedDate: _item.CreatedDate,
                   Status: _item.Status,
                   StatusMessage: _item.StatusMessage,
                   StatusDetailMessage: _item.StatusDetailMessage,
                   CirData: _item.CirData,
                   CirDataTemp: {},
                   UserInitial: _item.UserInitial,
                   IsDirty: _item.IsDirty,
                   Deleted: _item.Deleted,
                   CirStatus: _item.CirStatus,
                   RowVersion: 0
               }, 'CirDataCommon', function () {
                   console.log('Cir Local Updated after Sync with CirDataCommonID : ' + _item.CirDataCommonID + ' CirDataLocalID: ' + _item.CirDataLocalID);
               });
        });



    }

    this.SaveSubmitCir = function (submit, approve) {
        var id = $('#CirDataCommonID').val();
        var deferredObject = $.Deferred();
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemByIdfromTable('CirDataCommon', id, function (item) {
                if (item == false || item.length == 0) {
                    alert("The CIR you are editing is now obsolete as it has been either deleted or locked/ressigned by Admin. Please press [OK] to cancel the CIR editing and discard the changes done by you.");
                    window.location.href = '/cir/local-history';
                    deferredObject.resolve();
                }
                else {
                    if (item.Status == 4) {
                        alert("Conflict occured in the CIR you are editing due to some changes in the same CIR on the Server.Please resolve the conflict from Local History Page.");
                        window.location.href = '/cir/local-history';
                        deferredObject.resolve();
                    }
                    else {
                        if (item.Status == 3) {

                            alert("The CIR you are editing has already been Sync to Server by you. Please press [OK] to cancel the CIR editing and discard the changes done by you.");
                            window.location.href = '/cir/local-history';
                            deferredObject.resolve();
                        }
                        else {
                            cirOfflineApp.showDialog = 0;
                            if (submit == true) {
                                var cirStatus = item.CirStatus;
                                if (approve != undefined && approve != null && approve == true) {
                                    cirStatus = 10; // Request for approve
                                }
                                dbtransaction.addItemIntoTransactionTable(
                                    {
                                        CirDataCommonID: id,
                                        CirDataLocalID: $('#cirLocalID').val(),
                                        UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                                        CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                                        Status: 2,
                                        StatusMessage: 'CIR has been Submitted',
                                        StatusDetailMessage: 'This CIR has been submitted. When online the CIR will be synced and status will be updated.',
                                        CirData: item.CirData,
                                        CirDataTemp: {},
                                        UserInitial: $('#hdnUserPrincipal').val(),
                                        IsDirty: true,
                                        Deleted: false,
                                        CirStatus: cirStatus,
                                        RowVersion: item.RowVersion,
                                        Remarks: item.Remarks,
                                        RelatedUserCirDataID: item.RelatedUserCirDataID,
                                    }, 'CirDataCommon', function () {
                                        deferredObject.resolve();

                                    });
                            }
                            else {
                                var cirStatus = item.CirStatus;
                                if (approve != undefined && approve != null && approve == true) {
                                    cirStatus = 10; // Request for approve
                                }
                                dbtransaction.addItemIntoTransactionTable(
                                    {
                                        CirDataCommonID: id,
                                        CirDataLocalID: $('#cirLocalID').val(),
                                        UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                                        CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                                        Status: 1,
                                        StatusMessage: 'CIR is in Draft version',
                                        StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                                        CirData: item.CirData,
                                        CirDataTemp: {},
                                        UserInitial: $('#hdnUserPrincipal').val(),
                                        IsDirty: true,
                                        Deleted: false,
                                        CirStatus: cirStatus,
                                        RowVersion: item.RowVersion,
                                        Remarks: item.Remarks,
                                        RelatedUserCirDataID: item.RelatedUserCirDataID,
                                    }, 'CirDataCommon', function () {
                                        deferredObject.resolve();

                                    });
                            }
                        }
                    }
                }

            });

        });
        return deferredObject.promise();
    }

    var _checkCIRStatus = 0;

    this.SaveCir = function () {
        //if ($.DirtyForms.isDirty()) {
        //    alert("Your form is so dirty...");
        //} else {
        //    alert("Your form is a saint, nothing dirty about her");
        //}

        //TODO Add logic to check Conflict
        if (azureSync._syncing == 1)
            return;
        var id = $('#CirDataCommonID').val();
        if (_checkCIRStatus == -1) {
            alert("The CIR you are editing is now obsolete as it has been deleted or locked/ressigned by Admin. Please press [OK] to cancel the CIR editing and discard the changes done by you.");
            window.location.href = '/cir/local-history';
        }
        if (_checkCIRStatus == 4) {
            alert("Conflict occured in the CIR you are editing due to some changes in the same CIR on the Server.Please resolve the conflict from Local History Page.Press [OK] to cancel the CIR editing and discard the changes done by you.");
            window.location.href = '/cir/local-history';
        }
        if (_checkCIRStatus == 3) {
            alert("The CIR you are editing has alreday been Sync to Server by you. Please press [OK] to cancel the CIR editing and discard the changes done by you.");
            window.location.href = '/cir/local-history';
        }
        if (getQueryStringValueHash('id') != false) { //Leave the New CIR Record
            cirOfflineApp.findCirLocalData(id).done(function (result) {
                if (result.length == 0 || result == false) {
                    _checkCIRStatus = -1;
                }
                else {
                    _checkCIRStatus = result.Status;
                }

            });
        }

        SaveThisCir();

    }

    this.SaveThisCir = function (submit, approve) {


        var deferredObject = $.Deferred();
        var id = $('#CirDataCommonID').val();
        dbtransaction.openDatabase(function () {
            $("#_saveIndicator").show();
            if ($("#tType").val() == "rdHotlist") {
                var hotlistCirType = $('#ddlHotlist :selected').text();
                hotlistCirType = hotlistCirType.split(":")[0];
                hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
                switch (hotlistCirType) {
                    case 'Blade':
                        $('#ddlCirType :selected').val('1');
                        break;
                    case 'Gearbox':
                        $('#ddlCirType :selected').val('2');
                        break;
                    case 'General':
                        $('#ddlCirType :selected').val('3');
                        break;
                    case 'Generator':
                        $('#ddlCirType :selected').val('4');
                        break;
                    case 'Transformer':
                        $('#ddlCirType :selected').val('5');
                        break;
                    case 'Main Bearing':
                        $('#ddlCirType :selected').val('6');
                        break;
                    case 'Skiipack':
                        $('#ddlCirType :selected').val('7');
                        break;

                }
            }
            var ComponentType = $('#ddlCirType :selected').val();
            if (ComponentType != 8) {
                cirOfflineApp.setCirCommonData(1);
            }
            //var ComponentType = $('#ddlCirType :selected').val();
            if (ComponentType == 1) {

                cirOfflineApp.setCirBladeData(1);

            }
            if (ComponentType == 2) {
                cirOfflineApp.setCirGearboxData(1);
            }
            if (ComponentType == 3) {
                cirOfflineApp.setCirGeneralData(1);
            }
            if (ComponentType == 4) {
                cirOfflineApp.setCirGeneratorData(1);
            }
            if (ComponentType == 5) {
                cirOfflineApp.setCirTransformerData(1);
            }
            if (ComponentType == 6) {
                cirOfflineApp.setCirMainBearingData(1);
            }
            if (ComponentType == 7) {

                cirOfflineApp.setCirSkiipData(1);
            }

            if (ComponentType == 8) {

                cirOfflineApp.setCirSimplifiedData(1);
            }

            if (ComponentType == 8) {
                cirOfflineApp.setSimplifiedCirDynamicData(1);
                cirOfflineApp.setSimplifiedDecisionData(1);
                cirOfflineApp.setSimplifiedCirImageData().done(function () {
                    cirOfflineApp.saveToLocalStorage(id, approve).done(function () {
                        cirOfflineApp.SaveSubmitCir(submit, approve).done(function () {
                            deferredObject.resolve();
                        });

                    });

                });
            }
            else {
                cirOfflineApp.setCirDynamicTableData(1);
            }
            if (ComponentType != 8) {
                cirOfflineApp.setCirImageData().done(function () {
                    cirOfflineApp.saveToLocalStorage(id, approve).done(function () {
                        cirOfflineApp.SaveSubmitCir(submit, approve).done(function () {
                            deferredObject.resolve();
                        });

                    });

                });
            }

        });

        return deferredObject.promise();

    }

    this.SaveRemoteCir = function (item, CirData) {
        var deferredObject = $.Deferred();
        var newId = cirOfflineApp.generateKey();
        if (item == false || item.length == 0) {
            //Do Nothing
        }
        else {
            //if (item.Status == 3) {
            //    cirOfflineApp.softDeleteCirLocalData(item.Id);
            //}
            //else {
            newId = item.Id;
            // }

        }

        dbtransaction.openDatabase(function () {
            dbtransaction.addItemIntoTransactionTable(
                {
                    CirDataCommonID: newId,
                    CirDataLocalID: CirData.componentInspectionReportId,
                    UpdateBy: $('#hdnUserPrincipal').val(), // This will be changed after Azure auth
                    CreatedDate: GetDateTimeStringFromDateObject(new Date()),
                    Status: 1,
                    StatusMessage: 'CIR is in Draft version',
                    StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                    CirData: CirData,
                    CirDataTemp: {},
                    UserInitial: $('#hdnUserPrincipal').val(),
                    IsDirty: true,
                    Deleted: false,
                    CirStatus: 1,
                    RowVersion: 0
                }, 'CirDataCommon', function () {
                    deferredObject.resolve(newId);
                    //console.log('Cir Local created/updated with CirDataCommonID : ' + $('#CirDataCommonID').val() + ' CirDataLocalID: ' + $('#cirLocalID').val());
                });
        });
        return deferredObject.promise();
    }

    this.setCirCommonData = function (n) {
        var d = new Date();
        var tempCirName = ($("#txtTurbineSite").val() == "" ? "{SiteName}" : $("#txtTurbineSite").val());
        tempCirName = (tempCirName.length > 17 ? tempCirName.substring(0, 17) : tempCirName);
        tempCirName = tempCirName + "_" + $('#ddlCirType :selected').text();
        tempCirName = tempCirName + ($('#txtTurbineNumber').val() == "" ? "_{TurbineNo}" : "_" + $("#txtTurbineNumber").val());
        var d = new Date();
        tempCirName = tempCirName + "_" + d.getFullYear() + "-" + ("0" + d.getMonth()).slice(-2) + "-" + ("0" + d.getDay()).slice(-2);
        tempCirName = tempCirName + ($('#txtCimNo').val() == "" ? "_{CimCaseNo}" : "_" + $("#txtCimNo").val());
        if ($('#cirLocalID').val() == "")
            $('#cirLocalID').val("0");
        cirLocalObject = {
            componentInspectionReportId: $('#cirLocalID').val(),
            componentInspectionReportTypeId: $('#ddlCirType :selected').val(),
            componentInspectionReportName: (parseInt($('#cirLocalID').val()) == 0 ? tempCirName : $('#CirName').val()),
            componentInspectionReportStateId: 1,
            cirDataID: $('#cirDataID').val(),
            reportTypeId: $('#ddlReportType').val(),
            reconstructionBooleanAnswerId: 1,
            cimCaseNumber: $('#txtCimNo').val(),
            reasonForService: $('#txtReasonForService').val(),
            turbineNumber: $('#txtTurbineNumber').val(),
            country: $('#txtTurbineCountry').val(),
            siteName: $('#txtTurbineSite').val(),
            turbineType: $('#txtTurbineType').val(),
            beforeInspectionTurbineRunStatusId: $('#ddlRunStatus :selected').val(),
            commisioningDate: $('#txtCommisioningDate').val(),
            strCommisioningDate: $('#txtCommisioningDate').val(),
            installationDate: $('#txtInstallationDate').val(),
            strInstallationDate: $('#txtInstallationDate').val(),
            failureDate: $('#txtFailureDate').val(),
            strFailureDate: $('#txtFailureDate').val(),
            inspectionDate: $('#txtInspectionDate').val(),
            strInspectionDate: $('#txtInspectionDate').val(),
            serviceReportNumber: $('#txtServicePortNo').val(),
            serviceReportNumberTypeId: $('#ddlServiceReportNumberType').val(),
            serviceEngineer: $('#txtServiceEngineer').val(),
            notificationNumber: $('#txtNotificationNumber').val(),
            runHours: $('#txtRunHr').val(),
            generator1Hrs: $('#txtGenerator1Hr').val(),
            generator2Hrs: $('#txtGenerator2Hr').val(),
            totalProduction: $('#txtTotalProduction').val(),
            afterInspectionTurbineRunStatusId: $('#ddlRunStatusAfterInspection :selected').val(),
            vestasItemNumber: $('#txtVestasItemNo').val(),
            quantity: ($('#txtQuantityOfFailedComponent').val() == '') ? "0" : $('#txtQuantityOfFailedComponent').val(),
            description: $('#txtDescription').val(),
            componentUpTowerSolutionID: $('#ddlUpTowerSolution :selected').val(),
            descriptionConsquential: $('#txtDescriptionConProb').val(),
            additionalComments: $('#txtAdditionalInfo').val(),
            sbuRecomendation: $('#txtSBURecommendation').val(),
            alarmLogNumber: ($('#txtAlarmLogNumber').val() == '') ? "0" : $('#txtAlarmLogNumber').val(),
            internalComments: $('#txtInternalComments').val(),
            conductedBy: 1,
            sBUId: 1,
            cIRTemplateGUID: "",
            locationTypeId: 6, //Cant find map
            mountedOnMainComponentBooleanAnswerId: cirOfflineApp.getAuxEquipmentId(),
            // additionalInfo: $('#txtAdditionalInfo').val(),
            templateVersion: cirOfflineApp.TemplateVersion(),
            currentUser: $('#hdnUserPrincipal').val(),
            generator: cirLocalObject.generator,
            mainBearing: cirLocalObject.mainBearing,
            gearbox: cirLocalObject.gearbox,
            skiip: cirLocalObject.skiip,
            transformer: cirLocalObject.transformer,
            bladeData: cirLocalObject.bladeData,
            general: cirLocalObject.general,
            imageData: cirLocalObject.imageData,
            imageDataInfo: cirLocalObject.imageDataInfo,
            dynamicTableInputs: cirLocalObject.dynamicTableInputs,
            htmlStr: $("#Error1").val(),
            turbineData: {
                turbineCountry: '',
                turbineSite: '',
                rotorDiameter: ($('#txtRotorDiameter').val().trim() == "" ? 0 : $('#txtRotorDiameter').val()),
                nominelPower: ($('#txtNominelPower').val().trim() == "" ? 0 : $('#txtNominelPower').val()),
                voltage: ($('#txtVoltage').val().trim() == "" ? 0 : $('#txtVoltage').val()),
                powerRegulation: $('#txtPowerRegulation').val(),
                frequency: ($('#txtFrequency').val().trim() == "" ? 0 : $('#txtFrequency').val()),
                smallGenerator: ($('#txtSmallGenerator').val().trim() == "" ? 0 : $('#txtSmallGenerator').val()),
                temperatureVariant: $('#txtTemperatureVariant').val(),
                markVersion: $('#txtMKVersion').val(),
                placement: $('#txtOnshoreOffshore').val(),
                manufacturer: $('#txtTurbineManufacturer').val(),
                localTurbineId: $('#txtLocalTurbineID').val(),
            }

        }

    };

    this.setCirSimplifiedData = function (n) {
        var d = new Date();
        var tempCirName = "{SiteName}";
        tempCirName = (tempCirName.length > 17 ? tempCirName.substring(0, 17) : tempCirName);
        tempCirName = tempCirName + "_" + $('#ddlCirType :selected').text();
        tempCirName = tempCirName + ($('#txtTurbineNumber_Flang').val() == "" ? "_{TurbineNo}" : "_" + $("#txtTurbineNumber_Flang").val());
        var d = new Date();
        tempCirName = tempCirName + "_" + d.getFullYear() + "-" + ("0" + d.getMonth()).slice(-2) + "-" + ("0" + d.getDay()).slice(-2);
        tempCirName = tempCirName + ($('#txtCimNo_Flang').val() == "" ? "_{CimCaseNo}" : "_" + $("#txtCimNo").val());
        if ($('#cirLocalID').val() == "")
            $('#cirLocalID').val("0");
        cirLocalObject = {
            componentInspectionReportId: $('#cirLocalID').val(),
            componentInspectionReportTypeId: $('#ddlCirType :selected').val(),
            componentInspectionReportName: (parseInt($('#cirLocalID').val()) == 0 ? tempCirName : $('#CirName').val()),
            componentInspectionReportStateId: 1,
            cirDataID: $('#cirDataID').val(),
            reportTypeId: 1,//default value :Insecption
            reconstructionBooleanAnswerId: 1,
            cimCaseNumber: $('#txtCimNo_Flang').val(),
            reasonForService: "",
            turbineNumber: $('#txtTurbineNumber_Flang').val(),
            country: null,
            siteName: "",
            turbineType: null,
            beforeInspectionTurbineRunStatusId: 7,//default value :Insecption
            commisioningDate: d.getDate(),
            strCommisioningDate: $('#txtCommisioningDate').val(),
            installationDate: d.getDate(),
            strInstallationDate: d.getDate(),
            failureDate: d.getDate(),
            strFailureDate: "",
            inspectionDate: $('#txtInspectionDate_Flang').val(),
            strInspectionDate: $('#txtInspectionDate_Flang').val(),
            serviceReportNumber: $('#txtServicePortNo_Flang').val(),
            serviceReportNumberTypeId: $('#ddlServiceReportNumberType_Flang').val(),
            serviceEngineer: $('#txtServiceEngineer_Flang').val(),
            notificationNumber: "",
            runHours: 0,
            generator1Hrs: 0,
            generator2Hrs: 0,
            totalProduction: 0,
            afterInspectionTurbineRunStatusId: $('#ddlRunStatusAfterInspection_Flang :selected').val(),
            vestasItemNumber: "",
            quantity: 0,
            description: '',
            componentUpTowerSolutionID: 0,
            descriptionConsquential: '',
            additionalComments: '',
            sbuRecomendation: $('#txtSBURecommendation_Flang').val(),
            flangDesc: $('#txtDescFlangNo').val(),
            outSideSign: (parseInt($('#ddlOutSideSign').val())) == 1 ? true : false,
            alarmLogNumber: '',
            internalComments: '',
            conductedBy: 1,
            sBUId: 1,
            cIRTemplateGUID: "",
            locationTypeId: 6, //Cant find map
            mountedOnMainComponentBooleanAnswerId: cirOfflineApp.getAuxEquipmentId(),
            // additionalInfo: $('#txtAdditionalInfo').val(),
            templateVersion: cirOfflineApp.TemplateVersion(),
            currentUser: $('#hdnUserPrincipal').val(),
            imageData: cirLocalObject.imageData,
            imageDataInfo: cirLocalObject.imageDataInfo,
            dynamicTableInputs: cirLocalObject.dynamicTableInputs,
            dyanamicDecisionData: cirLocalObject.dyanamicDecisionData,
            //DyanamicDecisionData: [{ "Decision": 30, "Repeatedinspection": 34,"AffectedBolts":0, "FlangNo": 1 }, { "Decision": 31, "Repeatedinspection": 36,"AffectedBolts":0, "FlangNo": 1 }],
            htmlStr: $("#Error1").val(),
            turbineData: {
                turbineCountry: '',
                turbineSite: '',
                rotorDiameter: ($('#txtRotorDiameter').val().trim() == "" ? 0 : $('#txtRotorDiameter').val()),
                nominelPower: ($('#txtNominelPower').val().trim() == "" ? 0 : $('#txtNominelPower').val()),
                voltage: ($('#txtVoltage').val().trim() == "" ? 0 : $('#txtVoltage').val()),
                powerRegulation: $('#txtPowerRegulation').val(),
                frequency: ($('#txtFrequency').val().trim() == "" ? 0 : $('#txtFrequency').val()),
                smallGenerator: ($('#txtSmallGenerator').val().trim() == "" ? 0 : $('#txtSmallGenerator').val()),
                temperatureVariant: $('#txtTemperatureVariant').val(),
                markVersion: $('#txtMKVersion').val(),
                placement: $('#txtOnshoreOffshore').val(),
                manufacturer: $('#txtTurbineManufacturer').val(),
                localTurbineId: $('#txtLocalTurbineID').val(),
            }
        }
    };

    this.setCirGeneralData = function (n) {
        cirLocalObject.general = {
            componentInspectionReportGeneralId: 0,
            componentInspectionReportId: $('#cirLocalID').val(),
            generalComponentGroupId: $('#ddlComponentGroup :selected').val(),
            generalComponentType: $('#txtComponentType').val(),
            vestasUniqueIdentifier: $('#txtVestasItemNo').val(),
            generalComponentManufacturer: $('#txtComponentManufacturer').val(),
            generalOtherGearboxType: $('#txtOtherGearboxType').val(),
            generalClaimRelevantBooleanAnswerId: "2", //
            generalOtherGearboxManufacturer: $('#txtOtherGearboxManufacturer').val(),
            generalComponentSerialNumber: $('#txtComponentSerialNumber').val(),
            generalGeneratorManufacturerId: $('#ddlGeneratorManufacturer :selected').val(),
            generalTransformerManufacturerId: $('#ddlTransformerManufacturer :selected').val(),
            generalGearboxManufacturerId: $('#ddlGearboxManufacturer :selected').val(),
            generalTowerTypeId: $('#ddlTowerType :selected').val(),
            generalTowerHeightId: $('#ddlTowerHeight :selected').val(),
            generalBlade1SerialNumber: $('#txtBladeASerialNumber').val(),
            generalBlade2SerialNumber: $('#txtBladeBSerialNumber').val(),
            generalBlade3SerialNumber: $('#txtBladeCSerialNumber').val(),
            generalControllerTypeId: $('#ddlControllerType :selected').val(),
            generalSoftwareRelease: $('#txtSoftwareRelease').val(),
            generalPicturesIncludedBooleanAnswerId: $('#ddlPicturesAttached :selected').val(),
            generalInitiatedBy1: $('#txtInitiatedBy1').val(),
            generalInitiatedBy2: $('#txtInitiatedBy2').val(),
            generalInitiatedBy3: $('#txtInitiatedBy3').val(),
            generalInitiatedBy4: "",
            generalMeasurementsConducted1: $('#txtMeasurements1').val(),
            generalMeasurementsConducted2: $('#txtMeasurements2').val(),
            generalMeasurementsConducted3: $('#txtMeasurements3').val(),
            generalMeasurementsConducted4: "",
            generalExecutedBy1: $('#txtExecutedBy1').val(),
            generalExecutedBy2: $('#txtExecutedBy2').val(),
            generalExecutedBy3: $('#txtExecutedBy3').val(),
            generalExecutedBy4: "",
            generalPositionOfFailedItem: $('#txtPositionOfFailedItem').val(),
            generalRamDumpNumber: ($('#txtRamDumpNumber').val() == '') ? "0" : $('#txtRamDumpNumber').val(),
            generalVDFTrackNumber: ($('#txtVDFTrackNumber').val() == '') ? "0" : $('#txtVDFTrackNumber').val()
        }


    };

    this.setCirBladeData = function (n) {
        cirLocalObject.general = {};
        cirLocalObject.generator = {};
        cirLocalObject.mainBearing = {};
        cirLocalObject.gearbox = {};
        cirLocalObject.skiip = {};
        cirLocalObject.transformer = {};

        var _BladeDamageData = [];
        var damageSections = $('.bladeDamageSection');
        if (damageSections.length > 0) {
            for (var i = 0; i < damageSections.length; i++) {
                if (damageSections[i]) {
                    if ($('#' + damageSections[i].id).css('display') != 'none') {
                        var dropDamagePlacement = $('#' + damageSections[i].id).find('#ddlDamagePlacement :selected');
                        var dropDamageType = $('#' + damageSections[i].id).find('#ddlDamageType :selected');
                        var dropBladeEdge = $('#' + damageSections[i].id).find('#ddlBladeEdge :selected');
                        var txBladeRadius = $('#' + damageSections[i].id).find('#txtBladeRadius');
                        var txBladeDamageDescription = $('#' + damageSections[i].id).find('#txtBladeDamageDescription');
                        var txPictureNo = $('#' + damageSections[i].id).find('#txtPictureNo');
                        var damageData = {};

                        damageData.componentInspectionReportBladeDamageId = 0;
                        damageData.componentInspectionReportBladeId = 0;
                        damageData.bladeDamagePlacementId = dropDamagePlacement.val();
                        damageData.bladeInspectionDataId = dropDamageType.val();
                        damageData.bladeRadius = ConvertCommatoDecimal(txBladeRadius.val());
                        damageData.bladeEdgeId = dropBladeEdge.val();
                        damageData.bladeDescription = txBladeDamageDescription.val();
                        damageData.bladePictureNumber = txPictureNo.val();
                        damageData.pictureOrder = 0;
                        _BladeDamageData.push(damageData);

                    }
                }
            }
        }

        var repairbladeData = {};
        if ($('#ddlReportType').val() == 3) {
            repairbladeData.bladeAmbientTemp = ConvertCommatoDecimal($('#txtAmbientTemp').val());
            repairbladeData.bladeHumidity = ConvertCommatoDecimal($('#txtHumidity').val());
            repairbladeData.bladeAdditionalDocumentReference = $('#txtAddldocumentref').val();
            repairbladeData.bladeResinType = $('#txtResinType').val();
            repairbladeData.bladeResinTypeBatchNumbers = $('#txtResinTypeBatchNumber').val();
            repairbladeData.bladeResinTypeExpiryDate = $('#txtResinTypeexpirydate').val();
            repairbladeData.strbladeResinTypeExpiryDate = $('#txtResinTypeexpirydate').val();
            repairbladeData.bladeHardenerType = $('#txtHardenertype').val();
            repairbladeData.bladeHardenerTypeBatchNumbers = $('#txtHardenertypebatchnumber').val();
            repairbladeData.bladeHardenerTypeExpiryDate = $('#txthardnertypeexpirydate').val();
            repairbladeData.strbladeHardenerTypeExpiryDate = $('#txthardnertypeexpirydate').val();;
            repairbladeData.bladeGlassSupplier = $('#txtglasssupplier').val();
            repairbladeData.bladeGlassSupplierBatchNumbers = $('#txtglasssupplierbatchnumber').val();
            repairbladeData.bladeSurfaceMaxTemperature = ConvertCommatoDecimal($('#txtmaxbladesurfacetemp').val());
            repairbladeData.bladeSurfaceMinTemperature = ConvertCommatoDecimal($('#txtminbladesurfacetemp').val());
            repairbladeData.bladeResinUsed = $('#txtquantityofmixedresinused').val();
            repairbladeData.bladePostCureMaxTemperature = ConvertCommatoDecimal($('#txtmaxpostcuresurfacetemp').val());
            repairbladeData.bladePostCureMinTemperature = ConvertCommatoDecimal($('#txtminpostcuresurfacetemp').val());
            repairbladeData.bladeTurnOffTime = $('#txtheaterinsulationandvacuumoff').val();
            repairbladeData.strbladeTurnOffTime = $('#txtheaterinsulationandvacuumoff').val();
            repairbladeData.bladeTotalCureTime = $('#txttotalcuretime').val();
        }
        else {
            repairbladeData = null;
        }

        cirLocalObject.bladeData = {
            componentInspectionReportId: 0,
            componentInspectionReportBladeId: $('#cirLocalID').val(),
            bladeManufacturerId: $('#ddlBladeManufacturer :selected').val(),
            bladeLengthId: $('#ddlBladeLengthM :selected').val(),
            bladeColorId: $('#ddlBladeColor :selected').val(),
            vestasUniqueIdentifier: $('#txtVestasItemNo').val(),
            bladeSerialNumber: $('#txtBladeSerialNo').val(),
            //auxEquipment: $('#ddlAuxEquipment :selected').val(),
            bladeInspectionReportDescription: '', //
            bladePicturesIncludedBooleanAnswerId: $('#ddlBladePicIncluded :selected').val(),
            //bladeOtherSerialNumber1: ($('#txtBladeSerialNoOtherBlade').val() == '') ? 1 : $('#txtBladeSerialNoOtherBlade').val(),
            //bladeOtherSerialNumber2: ($('#txtBladeSerialNoOtherBlade2').val() == '') ? 1 : $('#txtBladeSerialNoOtherBlade2').val(),
            bladeOtherSerialNumber1: $('#txtBladeSerialNoOtherBlade').val(),
            bladeOtherSerialNumber2: $('#txtBladeSerialNoOtherBlade2').val(),
            bladeFaultCodeClassificationId: $('#ddlOverallBladeCondition :selected').val(),
            bladeFaultCodeCauseId: $('#ddlFaultCause :selected').val(),
            bladeFaultCodeTypeId: $('#ddlFaultType :selected').val(),
            bladeFaultCodeAreaId: $('#ddlFaultArea :selected').val(),
            bladeLsVtNumber: $('#txtVTnumber').val(),
            bladeLsCalibrationDate: $('#txtCalibrationDate').val(),
            strBladeLsCalibrationDate: $('#txtCalibrationDate').val(),
            bladeLsLeewardSidePreRepairTip: $('#txtLeewardPreTypeValue1').val(),
            bladeLsLeewardSidePostRepairTip: $('#txtLeewardPostTypeValue1').val(),
            bladeLsLeewardSidePreRepair2: $('#txtLeewardPreTypeValue2').val(),
            bladeLsLeewardSidePostRepair2: $('#txtLeewardPostTypeValue2').val(),
            bladeLsLeewardSidePreRepair3: $('#txtLeewardPreTypeValue3').val(),
            bladeLsLeewardSidePostRepair3: $('#txtLeewardPostTypeValue3').val(),
            bladeLsLeewardSidePreRepair4: $('#txtLeewardPreTypeValue4').val(),
            bladeLsLeewardSidePostRepair4: $('#txtLeewardPostTypeValue4').val(),
            bladeLsLeewardSidePreRepair5: $('#txtLeewardPreTypeValue5').val(),
            bladeLsLeewardSidePostRepair5: $('#txtLeewardPostTypeValue5').val(),
            bladeLsWindwardSidePreRepairTip: $('#txtWindwardPreTypeValue1').val(),
            bladeLsWindwardSidePostRepairTip: $('#txtWindwardPostTypeValue1').val(),
            bladeLsWindwardSidePreRepair2: $('#txtWindwardPreTypeValue2').val(),
            bladeLsWindwardSidePostRepair2: $('#txtWindwardPostTypeValue2').val(),
            bladeLsWindwardSidePreRepair3: $('#txtWindwardPreTypeValue3').val(),
            bladeLsWindwardSidePostRepair3: $('#txtWindwardPostTypeValue3').val(),
            bladeLsWindwardSidePreRepair4: $('#txtWindwardPreTypeValue4').val(),
            bladeLsWindwardSidePostRepair4: $('#txtWindwardPostTypeValue4').val(),
            bladeLsWindwardSidePreRepair5: $('#txtWindwardPreTypeValue5').val(),
            bladeLsWindwardSidePostRepair5: $('#txtWindwardPostTypeValue5').val(),

            bladeLsLeewardSidePreRepair6: $('#txtLeewardPreTypeValue6').val(),
            bladeLsLeewardSidePostRepair6: $('#txtLeewardPostTypeValue6').val(),
            bladeLsLeewardSidePreRepair7: $('#txtLeewardPreTypeValue7').val(),
            bladeLsLeewardSidePostRepair7: $('#txtLeewardPostTypeValue7').val(),
            bladeLsLeewardSidePreRepair8: $('#txtLeewardPreTypeValue8').val(),
            bladeLsLeewardSidePostRepair8: $('#txtLeewardPostTypeValue8').val(),

            bladeLsWindwardSidePreRepair6: $('#txtWindwardPreTypeValue6').val(),
            bladeLsWindwardSidePostRepair6: $('#txtWindwardPostTypeValue6').val(),
            bladeLsWindwardSidePreRepair7: $('#txtWindwardPreTypeValue7').val(),
            bladeLsWindwardSidePostRepair7: $('#txtWindwardPostTypeValue7').val(),
            bladeLsWindwardSidePreRepair8: $('#txtWindwardPreTypeValue8').val(),
            bladeLsWindwardSidePostRepair8: $('#txtWindwardPostTypeValue8').val(),
            damageData: _BladeDamageData,
            repairRecordData: repairbladeData

        }



    };

    this.setCirSkiipData = function (n) {
        cirLocalObject.mainBearing = {};
        cirLocalObject.generator = {};
        cirLocalObject.transformer = {};
        cirLocalObject.gearbox = {};
        cirLocalObject.bladeData = {};
        cirLocalObject.general = {};

        var _SkiipackFailedComponent = [];
        var _SkiipackNewComponent = [];


        for (var divCount = 1; divCount <= 9; divCount++) {
            if ($('#divComponentIdentification' + divCount).css('display') != 'none') {
                //Saving data in CirDataSkiipack table
                var skiipFailedComp = {};
                skiipFailedComp.componentInspectionReportSkiiPFailedComponentId = 0;
                skiipFailedComp.componentInspectionReportSkiiPId = 0;
                skiipFailedComp.skiiPFailedComponentVestasUniqueIdentifier = $('#txtSerialNumber' + divCount).val();
                skiipFailedComp.skiiPFailedComponentVestasItemNumber = $('#txtVestasUniqueIdentifierSkiip' + divCount).val();
                skiipFailedComp.skiiPFailedComponentSerialNumber = $('#txtItemNoSkiip' + divCount).val();
                _SkiipackFailedComponent.push(skiipFailedComp);

            }
        }

        for (var divCount = 1; divCount <= 9; divCount++) {
            if ($('#divComponentIdentificationNew' + divCount).css('display') != 'none') {
                var skiipNewComp = {};
                skiipNewComp.componentInspectionReportSkiiPNewComponentId = 0;
                skiipNewComp.componentInspectionReportSkiiPId = 0;
                skiipNewComp.skiiPNewComponentVestasUniqueIdentifier = $('#txtSerialNumberNew' + divCount).val();
                skiipNewComp.skiiPNewComponentVestasItemNumber = $('#txtVestasUniqueIdentifierSkiipNew' + divCount).val();
                skiipNewComp.skiiPNewComponentSerialNumber = $('#txtItemNoSkiipNew' + divCount).val();
                _SkiipackNewComponent.push(skiipNewComp);
            }
        }

        var skiip = {};
        skiip.componentInspectionReportSkiiPId = "0";
        skiip.componentInspectionReportId = $('#cirLocalID').val();
        skiip.skiiPOtherDamagedComponentsReplaced = $('#txtOtherDamagedComponentsReplaced').val();
        skiip.skiiPCauseId = $('#ddlCauseSkiip').val();
        skiip.skiiPNumberofComponents = $('#ddlNumberOfComponentsSkiip').val();

        if ($('#txtQuantityOfFailedModulesSkiip').val() != '')

            skiip.skiiPQuantityOfFailedModules = $('#txtQuantityOfFailedModulesSkiip').val();
        else

            skiip.skiiPQuantityOfFailedModules = "0";

        skiip.skiiP2MWV521BooleanAnswerId = $('#ddl2MWV521').val();
        skiip.skiiP2MWV522BooleanAnswerId = $('#ddl2MWV522').val();
        skiip.skiiP2MWV523BooleanAnswerId = $('#ddl2MWV523').val();
        skiip.skiiP2MWV524BooleanAnswerId = $('#ddl2MWV524').val();
        skiip.skiiP2MWV525BooleanAnswerId = $('#ddl2MWV525').val();
        skiip.skiiP2MWV526BooleanAnswerId = $('#ddl2MWV526').val();
        skiip.skiiP3MWV521BooleanAnswerId = $('#ddl3MWV521').val();
        skiip.skiiP3MWV522BooleanAnswerId = $('#ddl3MWV522').val();
        skiip.skiiP3MWV523BooleanAnswerId = $('#ddl3MWV523').val();
        skiip.skiiP3MWV524xBooleanAnswerId = $('#ddl3MWV524x').val();
        skiip.skiiP3MWV524yBooleanAnswerId = $('#ddl3MWV524y').val();
        skiip.skiiP3MWV525xBooleanAnswerId = $('#ddl3MWV525x').val();
        skiip.skiiP3MWV525yBooleanAnswerId = $('#ddl3MWV525y').val();
        skiip.skiiP3MWV526xBooleanAnswerId = $('#ddl3MWV526x').val();
        skiip.skiiP3MWV526yBooleanAnswerId = $('#ddl3MWV526y').val();
        skiip.skiiP850KWV520BooleanAnswerId = $('#ddl850kWV520').val();
        skiip.skiiP850KWV524BooleanAnswerId = $('#ddl850kWV524').val();
        skiip.skiiP850KWV525BooleanAnswerId = $('#ddl850kWV525').val();
        skiip.skiiP850KWV526BooleanAnswerId = $('#ddl850kWV526').val();
        skiip.skiiPClaimRelevantBooleanAnswerId = "1";
        skiip.skiipFailedComp = _SkiipackFailedComponent;
        skiip.skiipNewComp = _SkiipackNewComponent;
        cirLocalObject.skiip = skiip;




    };

    this.setCirTransformerData = function (n) {
        cirLocalObject.mainBearing = {};
        cirLocalObject.generator = {};
        cirLocalObject.skiip = {};
        cirLocalObject.gearbox = {};
        cirLocalObject.bladeData = {};
        cirLocalObject.general = {};

        //generatorAuxEquipment: $('#ddlGeneratorAuxEquipment :selected').val(),
        var transformer = {};
        transformer.componentInspectionReportTransformerId = 0;
        transformer.componentInspectionReportId = $('#cirLocalID').val();
        transformer.vestasUniqueIdentifier = $('#txtVestasItemNo').val();
        transformer.transformerManufacturerId = $('#ddlTransformerManufacturer2 :selected').val();
        transformer.transformerSerialNumber = $('#txtTransformerSerialNumber').val();
        transformer.maxTemp = $('#txtTransformerMaxTemp').val();
        transformer.maxTempResetDate = $('#txtTransformerMaxTempDate').val();
        transformer.strMaxTempResetDate = $('#txtTransformerMaxTempDate').val();
        transformer.actionOnTransformerId = $('#ddlActionToTransformer :selected').val();
        transformer.hVCoilConditionId = $('#ddlTransformerHVCoil :selected').val();
        transformer.lVCoilConditionId = $('#ddlTransformerLVCoil :selected').val();
        transformer.hVCableConditionId = $('#ddlTransformerHVCable :selected').val();
        transformer.lVCableConditionId = $('#ddlTransformerLVCable :selected').val();
        transformer.bracketsId = $('#ddlTransformerBrackets :selected').val();
        transformer.transformerArcDetectionId = $('#ddlTransformerArcDetection :selected').val();
        transformer.climateId = $('#ddlTransformerClimateCondition :selected').val();
        transformer.surgeArrestorId = $('#ddlTransformerSurgeArrestor :selected').val();
        transformer.connectionBarsId = $('#ddlTransformerConnectionBars :selected').val();
        transformer.comments = $('#txtTransformerComments').val();
        transformer.transformerClaimRelevantBooleanAnswerId = $('#ddlTransformerAuxEquipment :selected').val();
        cirLocalObject.transformer = transformer;



    };

    this.setCirMainBearingData = function (n) {
        cirLocalObject.generator = {};
        cirLocalObject.gearbox = {};
        cirLocalObject.skiip = {};
        cirLocalObject.transformer = {};
        cirLocalObject.bladeData = {};
        cirLocalObject.general = {};
        var mainBearing = {};
        mainBearing.componentInspectionReportMainBearingId = "0";
        mainBearing.componentInspectionReportId = $('#cirLocalID').val();
        mainBearing.vestasUniqueIdentifier = $('#txtVestasItemNo').val();
        mainBearing.mainBearingLastLubricationDate = $('#txtMainBearingLubricationchangeDate').val();
        mainBearing.strMainBearingLastLubricationDate = $('#txtMainBearingLubricationchangeDate').val();
        mainBearing.mainBearingManufacturerId = $('#ddlMainBearingManufacturer').val();
        if (mainBearing.mainBearingManufacturerId == null || mainBearing.mainBearingManufacturerId == "") {
            mainBearing.mainBearingManufacturerId = 0;
        }
        if ($('#txtMainBearingBearingTemperature').val() == '')
            mainBearing.mainBearingTemperature = "0";
        else
            mainBearing.mainBearingTemperature = $('#txtMainBearingBearingTemperature').val();

        mainBearing.mainBearingLubricationOilTypeId = $('#ddlMainBearingLubricationType').val();

        mainBearing.mainBearingGrease = $('#chkMainBearingGrease').is(':checked');

        if ($('#txtMainBearingRunLubrication').val() == '')
            mainBearing.mainBearingLubricationRunHours = "0";
        else
            mainBearing.mainBearingLubricationRunHours = $('#txtMainBearingRunLubrication').val();

        if ($('#txtMainBearingOilTemperature').val() == '')
            mainBearing.mainBearingOilTemperature = "0";
        else
            mainBearing.mainBearingOilTemperature = $('#txtMainBearingOilTemperature').val();

        //Added By Siddharth Chauhan on 24-05-2016
        mainBearing.mainBearingTypeId = $('#ddlMainBearingType :selected').val();
        mainBearing.mainBearingRevision = $('#ddlMainBearingRevision :selected').val();
        mainBearing.mainBearingErrorLocationId = $('#ddlMainBearingFrontRear :selected').val();
        if (mainBearing.mainBearingErrorLocationId == '' || mainBearing.mainBearingErrorLocationId == ' ') {
            mainBearing.mainBearingErrorLocationId = 0;
        }
        mainBearing.mainBearingSerialNumber = $('#txtMainBearingSerialNumber').val();

        if ($('#txtMainBearingRunLubrication').val() == '')
            mainBearing.mainBearingRunHours = "0";
        else
            mainBearing.mainBearingRunHours = $('#txtMainBearingRunLubrication').val();

        mainBearing.mainBearingMechanicalOilPump = $('#txtMainBearingMechanicalOilPump').val();

        mainBearing.mainBearingClaimRelevantBooleanAnswerId = "1";
        cirLocalObject.mainBearing = mainBearing;


    };

    this.setCirGeneratorData = function (n) {
        cirLocalObject.mainBearing = {};
        cirLocalObject.gearbox = {};
        cirLocalObject.skiip = {};
        cirLocalObject.transformer = {};
        cirLocalObject.bladeData = {};
        cirLocalObject.general = {};
        //generatorAuxEquipment: $('#ddlGeneratorAuxEquipment :selected').val(),
        var generator = {};
        generator.componentInspectionReportGeneratorId = 0;
        generator.componentInspectionReportId = $('#cirLocalID').val();
        generator.vestasUniqueIdentifier = $('#txtVestasItemNo').val();
        generator.generatorManufacturerId = $('#ddlGeneratorManufacturer2 :selected').val();

        if (generator.generatorManufacturerId == '') {
            generator.generatorManufacturerId = 8;
        }

        if (generator.generatorManufacturerId == 5) {
            generator.otherManufacturer = $('#txtOtherManufacturerName').val();
        }
        else {

            generator.otherManufacturer = "";
        }
        generator.generatorSerialNumber = $('#txtGeneratorSearialNo').val();



        if ($('#txtGeneratorMaxTemp').val() != '')
            generator.generatorMaxTemperature = ConvertCommatoDecimal($('#txtGeneratorMaxTemp').val());
        else
            generator.generatorMaxTemperature = "0";

        generator.generatorMaxTemperatureResetDate = $('#txtGeneratorMaxTempResetDate').val();
        generator.strGeneratorMaxTemperatureResetDate = $('#txtGeneratorMaxTempResetDate').val();

        generator.couplingId = $('#ddlGeneratorCoupling :selected').val();
        if (generator.couplingId == '') {
            generator.couplingId = 8;
        }
        generator.actionToBeTakenOnGeneratorId = $('#ddlGeneratorActionToBeTaken :selected').val();
        generator.generatorDriveEndId = $('#ddlGeneratorDriveEnd :selected').val();
        generator.generatorNonDriveEndId = $('#ddlGeneratorNonDriveEnd :selected').val();
        generator.generatorRotorId = $('#ddlGeneratorRotor :selected').val();
        generator.generatorCoverId = $('#ddlGeneratorCover :selected').val();
        generator.airToAirCoolerInternalId = $('#ddlGeneratorConditionInternal :selected').val();
        generator.airToAirCoolerExternalId = $('#ddlGeneratorConditionExternal :selected').val();
        generator.generatorComments = $('#txtGeneratorComments').val();
        generator.insulationComments = $('#chkInsulationComments').is(':checked');
        generator.generatorInsulationComments = $('#txtGeneratorInsulationComments').val();

        if ($('#txtGeneratorTestResultUGround').val() != '')
            generator.uGround = ConvertCommatoDecimal($('#txtGeneratorTestResultUGround').val());
        else
            generator.uGround = "0";

        if ($('#txtGeneratorTestResultVGround').val() != '')
            generator.vGround = ConvertCommatoDecimal($('#txtGeneratorTestResultVGround').val());
        else
            generator.vGround = "0";

        if ($('#txtGeneratorTestResultWGround').val() != '')
            generator.wGround = ConvertCommatoDecimal($('#txtGeneratorTestResultWGround').val());
        else
            generator.wGround = "0";

        if ($('#txtGeneratorTestResultUV').val() != '')
            generator.uV = ConvertCommatoDecimal($('#txtGeneratorTestResultUV').val());
        else
            generator.uV = "0";

        if ($('#txtGeneratorTestResultUW').val() != '')
            generator.uW = ConvertCommatoDecimal($('#txtGeneratorTestResultUW').val());
        else
            generator.uW = "0";

        if ($('#txtGeneratorTestResultVW').val() != '')
            generator.vW = ConvertCommatoDecimal($('#txtGeneratorTestResultVW').val());
        else
            generator.vW = "0";

        if ($('#txtGeneratorTestResultKGround').val() != '')
            generator.kGround = ConvertCommatoDecimal($('#txtGeneratorTestResultKGround').val());
        else
            generator.kGround = "0";

        if ($('#txtGeneratorTestResultLGround').val() != '')
            generator.lGround = ConvertCommatoDecimal($('#txtGeneratorTestResultLGround').val());
        else
            generator.lGround = "0";

        if ($('#txtGeneratorTestResultMGround').val() != '')
            generator.mGround = ConvertCommatoDecimal($('#txtGeneratorTestResultMGround').val());
        else
            generator.mGround = "0";

        //Added By Siddharth Chauhan on 24-05-2016
        generator.uGroundOhmUnitId = $('#ddlGeneratorTestResultUGroundUnit :selected').val();
        generator.vGroundOhmUnitId = $('#ddlGeneratorTestResultWGroundUnit :selected').val();
        generator.wGroundOhmUnitId = $('#ddlGeneratorTestResultVGroundUnit :selected').val();

        //Added By Siddharth Chauhan on 24-05-2016
        generator.uVOhmUnitId = $('#ddlGeneratorTestResultUVUnit :selected').val();
        generator.uWOhmUnitId = $('#ddlGeneratorTestResultUWUnit :selected').val();
        generator.vWOhmUnitId = $('#ddlGeneratorTestResultVWUnit :selected').val();

        //Added By Siddharth Chauhan on 24-05-2016
        generator.kGroundOhmUnitId = $('#ddlGeneratorTestResultKGroundUnit :selected').val();
        generator.lGroundOhmUnitId = $('#ddlGeneratorTestResultLGroundUnit :selected').val();
        generator.mGroundOhmUnitId = $('#ddlGeneratorTestResultMGroundUnit :selected').val();

        if ($('#txtGeneratorInductanceTestU1U2').val() != '')
            generator.u1U2 = $('#txtGeneratorInductanceTestU1U2').val();
        else
            generator.u1U2 = "0";

        if ($('#txtGeneratorInductanceTestV1V2').val() != '')
            generator.v1V2 = $('#txtGeneratorInductanceTestV1V2').val();
        else
            generator.v1V2 = "0";

        if ($('#txtGeneratorInductanceTestW1W2').val() != '')
            generator.w1W2 = $('#txtGeneratorInductanceTestW1W2').val();
        else
            generator.w1W2 = "0";


        if ($('#txtGeneratorInductanceTestK1L1').val() != '')
            generator.k1L1 = $('#txtGeneratorInductanceTestK1L1').val();
        else
            generator.k1L1 = "0";

        if ($('#txtGeneratorInductanceTestL1M1').val() != '')
            generator.l1M1 = $('#txtGeneratorInductanceTestL1M1').val();
        else
            generator.l1M1 = "0";

        if ($('#txtGeneratorInductanceTestK1M1').val() != '')
            generator.k1M1 = $('#txtGeneratorInductanceTestK1M1').val();
        else
            generator.k1M1 = "0";

        if ($('#txtGeneratorInductanceTestK2L2').val() != '')
            generator.k2L2 = $('#txtGeneratorInductanceTestK2L2').val();
        else
            generator.k2L2 = "0";

        if ($('#txtGeneratorInductanceTestL2M2').val() != '')
            generator.l2M2 = $('#txtGeneratorInductanceTestL2M2').val();
        else
            generator.l2M2 = "0";

        if ($('#txtGeneratorInductanceTestK2M2').val() != '')
            generator.k2M2 = $('#txtGeneratorInductanceTestK2M2').val();
        else
            generator.k2M2 = "0";

        //Added By Siddharth Chauhan on 24-05-2016
        generator.generatorRewoundLocally = false;
        generator.generatorRewoundLocally = $('#chkGeneratorRewound').is(':checked');
        generator.generatorClaimRelevantBooleanAnswerId = "2";
        cirLocalObject.generator = generator;



    };

    this.setCirGearboxData = function (n) {
        cirLocalObject.mainBearing = {};
        cirLocalObject.generator = {};
        cirLocalObject.skiip = {};
        cirLocalObject.transformer = {};
        cirLocalObject.bladeData = {};
        cirLocalObject.general = {};
        //generatorAuxEquipment: $('#ddlGeneratorAuxEquipment :selected').val(),
        var gearbox = {};
        gearbox.componentInspectionReportGearboxId = "0";
        gearbox.componentInspectionReportId = $('#cirLocalID').val();
        gearbox.vestasUniqueIdentifier = $('#txtVestasItemNo').val();
        gearbox.gearboxManufacturerId = $('#ddlGearboxGManufacturer :selected').val();
        gearbox.gearboxOtherManufacturer = $('#txtOtherGearboxGManufacturer').val();
        gearbox.gearboxTypeId = $('#ddlGearboxGType :selected').val();
        gearbox.otherGearboxType = $('#txtOtherGearboxGType').val();
        gearbox.gearboxRevisionId = $('#ddlGearboxGRevision :selected').val();
        gearbox.gearboxSerialNumber = $('#txtGearboxSerialNumber').val();
        gearbox.gearboxLastOilChangeDate = $('#txtDateForLastOilChange').val();
        gearbox.strGearboxLastOilChangeDate = $('#txtDateForLastOilChange').val();
        gearbox.gearboxOilTypeId = $('#ddlOilGearType :selected').val();
        gearbox.gearboxMechanicalOilPumpId = $('#ddlTypeOfMechanicalOilPump :selected').val();
        gearbox.gearboxOilLevelId = $('#ddlOilLevelInGearbox :selected').val();
        gearbox.gearboxAuxEquipmentId = $('#ddlAuxGearEquipment :selected').val();
        gearbox.gearboxActionToBeTakenOnGearboxId = $('#ddlActionToBeTakenOnGearbox :selected').val();
        gearbox.gearboxRunHours = $('#txtGearboxHrs').val();
        gearbox.gearboxOilTemperature = $('#txtOilTemperatureAtOilLevelCheck').val();
        gearbox.gearboxProduction = $('#txtGearboxProduction').val();
        gearbox.gearboxGeneratorManufacturerId = $('#ddlGeneratorGManufacturer :selected').val();
        gearbox.gearboxGeneratorManufacturerId2 = $('#ddlSecondGeneratorGManufacturer :selected').val();
        gearbox.gearboxElectricalPumpId = $('#ddlElectricalPump :selected').val();
        gearbox.gearboxShrinkElementId = $('#ddlShrinkElement :selected').val();
        gearbox.gearboxShrinkElementSerialNumber = $('#txtSerialNumberofShrinkElement').val();
        gearbox.gearboxCouplingId = $('#ddlGearboxCoupling :selected').val();
        gearbox.gearboxFilterBlockTypeId = $('#ddlFilterBlockType :selected').val();
        gearbox.gearboxInLineFilterId = $('#ddlInlineFilter :selected').val();
        gearbox.gearboxOffLineFilterId = $('#ddlOfflineFilter :selected').val();
        gearbox.gearboxSoftwareRelease = $('#txtGearSoftwareRelease').val();
        gearbox.gearboxShaftsExactLocation1ShaftTypeId = $('#ddlGearboxShaftsExactLocation1ShaftTypeId :selected').val();
        gearbox.gearboxShaftsTypeofDamage1ShaftErrorId = $('#ddlGearboxShaftsTypeofDamage1ShaftErrorId :selected').val();
        gearbox.gearboxShaftsExactLocation2ShaftTypeId = $('#ddlGearboxShaftsExactLocation2ShaftTypeId :selected').val();
        gearbox.gearboxShaftsTypeofDamage2ShaftErrorId = $('#ddlGearboxShaftsTypeofDamage2ShaftErrorId :selected').val();
        gearbox.gearboxShaftsExactLocation3ShaftTypeId = $('#ddlGearboxShaftsExactLocation3ShaftTypeId :selected').val();
        gearbox.gearboxShaftsTypeofDamage3ShaftErrorId = $('#ddlGearboxShaftsTypeofDamage3ShaftErrorId :selected').val();
        gearbox.gearboxShaftsExactLocation4ShaftTypeId = $('#ddlGearboxShaftsExactLocation4ShaftTypeId :selected').val();
        gearbox.gearboxShaftsTypeofDamage4ShaftErrorId = $('#ddlGearboxShaftsTypeofDamage4ShaftErrorId :selected').val();
        gearbox.gearboxExactLocation1GearTypeId = $('#ddlExactLocation1 :selected').val();
        gearbox.gearboxExactLocation2GearTypeId = $('#ddlExactLocation2 :selected').val();
        gearbox.gearboxExactLocation3GearTypeId = $('#ddlExactLocation3 :selected').val();
        gearbox.gearboxExactLocation4GearTypeId = $('#ddlExactLocation4 :selected').val();
        gearbox.gearboxExactLocation5GearTypeId = $('#ddlExactLocation5 :selected').val();
        gearbox.gearboxExactLocation6GearTypeId = $('#ddlExactLocation6 :selected').val();
        gearbox.gearboxExactLocation7GearTypeId = $('#ddlExactLocation7 :selected').val();
        gearbox.gearboxExactLocation8GearTypeId = $('#ddlExactLocation8 :selected').val();
        gearbox.gearboxExactLocation9GearTypeId = $('#ddlExactLocation9 :selected').val();
        gearbox.gearboxExactLocation10GearTypeId = $('#ddlExactLocation10 :selected').val();
        gearbox.gearboxExactLocation11GearTypeId = $('#ddlExactLocation11 :selected').val();
        gearbox.gearboxExactLocation12GearTypeId = $('#ddlExactLocation12 :selected').val();
        gearbox.gearboxExactLocation13GearTypeId = $('#ddlExactLocation13 :selected').val();
        gearbox.gearboxExactLocation14GearTypeId = $('#ddlExactLocation14 :selected').val();
        gearbox.gearboxExactLocation15GearTypeId = $('#ddlExactLocation15 :selected').val();
        gearbox.gearboxTypeofDamage1GearErrorId = ($('#ddlTypeIfDamage1 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage1 :selected').val());
        gearbox.gearboxTypeofDamage2GearErrorId = ($('#ddlTypeIfDamage2 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage2 :selected').val());
        gearbox.gearboxTypeofDamage3GearErrorId = ($('#ddlTypeIfDamage3 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage3 :selected').val());
        gearbox.gearboxTypeofDamage4GearErrorId = ($('#ddlTypeIfDamage4 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage4 :selected').val());
        gearbox.gearboxTypeofDamage5GearErrorId = ($('#ddlTypeIfDamage5 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage5 :selected').val());
        gearbox.gearboxTypeofDamage6GearErrorId = ($('#ddlTypeIfDamage6 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage6 :selected').val());
        gearbox.gearboxTypeofDamage7GearErrorId = ($('#ddlTypeIfDamage7 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage7 :selected').val());
        gearbox.gearboxTypeofDamage8GearErrorId = ($('#ddlTypeIfDamage8 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage8 :selected').val());
        gearbox.gearboxTypeofDamage9GearErrorId = ($('#ddlTypeIfDamage9 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage9 :selected').val());
        gearbox.gearboxTypeofDamage10GearErrorId = ($('#ddlTypeIfDamage10 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage10 :selected').val());
        gearbox.gearboxTypeofDamage11GearErrorId = ($('#ddlTypeIfDamage11 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage11 :selected').val());
        gearbox.gearboxTypeofDamage12GearErrorId = ($('#ddlTypeIfDamage12 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage12 :selected').val());
        gearbox.gearboxTypeofDamage13GearErrorId = ($('#ddlTypeIfDamage13 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage13 :selected').val());
        gearbox.gearboxTypeofDamage14GearErrorId = ($('#ddlTypeIfDamage14 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage14 :selected').val());
        gearbox.gearboxTypeofDamage15GearErrorId = ($('#ddlTypeIfDamage15 :selected').val() == "0" ? "" : $('#ddlTypeIfDamage15 :selected').val());
        gearbox.gearboxGearDecision1DamageDecisionId = $('#ddlDecision1 :selected').val();
        gearbox.gearboxGearDecision2DamageDecisionId = $('#ddlDecision2 :selected').val();
        gearbox.gearboxGearDecision3DamageDecisionId = $('#ddlDecision3 :selected').val();
        gearbox.gearboxGearDecision4DamageDecisionId = $('#ddlDecision4 :selected').val();

        gearbox.gearboxGearDamageClass1DamageId = $('#ddlDamageClass1 :selected').val();
        gearbox.gearboxGearDamageClass2DamageId = $('#ddlDamageClass2 :selected').val();
        gearbox.gearboxGearDamageClass3DamageId = $('#ddlDamageClass3 :selected').val();
        gearbox.gearboxGearDamageClass4DamageId = $('#ddlDamageClass4 :selected').val();
        gearbox.gearboxGearDamageClass5DamageId = $('#ddlDamageClass5 :selected').val();
        gearbox.gearboxGearDamageClass6DamageId = $('#ddlDamageClass6 :selected').val();
        gearbox.gearboxGearDamageClass7DamageId = $('#ddlDamageClass7 :selected').val();
        gearbox.gearboxGearDamageClass8DamageId = $('#ddlDamageClass8 :selected').val();
        gearbox.gearboxGearDamageClass9DamageId = $('#ddlDamageClass9 :selected').val();
        gearbox.gearboxGearDamageClass10DamageId = $('#ddlDamageClass10 :selected').val();
        gearbox.gearboxGearDamageClass11DamageId = $('#ddlDamageClass11 :selected').val();
        gearbox.gearboxGearDamageClass12DamageId = $('#ddlDamageClass12 :selected').val();
        gearbox.gearboxGearDamageClass13DamageId = $('#ddlDamageClass13 :selected').val();
        gearbox.gearboxGearDamageClass14DamageId = $('#ddlDamageClass14 :selected').val();
        gearbox.gearboxGearDamageClass15DamageId = $('#ddlDamageClass15 :selected').val();
        //Added By Siddharth Chauhan on 23-05-2016
        gearbox.gearboxGearDecision5DamageDecisionId = $('#ddlDecision5 :selected').val();
        gearbox.gearboxGearDecision6DamageDecisionId = $('#ddlDecision6 :selected').val();
        gearbox.gearboxGearDecision7DamageDecisionId = $('#ddlDecision7 :selected').val();
        gearbox.gearboxGearDecision8DamageDecisionId = $('#ddlDecision8 :selected').val();
        gearbox.gearboxGearDecision9DamageDecisionId = $('#ddlDecision9 :selected').val();
        gearbox.gearboxGearDecision10DamageDecisionId = $('#ddlDecision10 :selected').val();
        gearbox.gearboxGearDecision11DamageDecisionId = $('#ddlDecision11 :selected').val();
        gearbox.gearboxGearDecision12DamageDecisionId = $('#ddlDecision12 :selected').val();
        gearbox.gearboxGearDecision13DamageDecisionId = $('#ddlDecision13 :selected').val();
        gearbox.gearboxGearDecision14DamageDecisionId = $('#ddlDecision14 :selected').val();
        gearbox.gearboxGearDecision15DamageDecisionId = $('#ddlDecision15 :selected').val();

        gearbox.gearboxBearingsLocation1BearingTypeId = $('#ddlLocation1 :selected').val();
        gearbox.gearboxBearingsLocation2BearingTypeId = $('#ddlLocation2 :selected').val();
        gearbox.gearboxBearingsLocation3BearingTypeId = $('#ddlLocation3 :selected').val();
        gearbox.gearboxBearingsLocation4BearingTypeId = $('#ddlLocation4 :selected').val();
        gearbox.gearboxBearingsLocation5BearingTypeId = $('#ddlLocation5 :selected').val();
        gearbox.gearboxBearingsLocation6BearingTypeId = $('#ddlLocation6 :selected').val();
        gearbox.gearboxBearingsPosition1BearingPosId = $('#ddlPosition1 :selected').val();
        gearbox.gearboxBearingsPosition2BearingPosId = $('#ddlPosition2 :selected').val();
        gearbox.gearboxBearingsPosition3BearingPosId = $('#ddlPosition3 :selected').val();
        gearbox.gearboxBearingsPosition4BearingPosId = $('#ddlPosition4 :selected').val();
        gearbox.gearboxBearingsPosition5BearingPosId = $('#ddlPosition5 :selected').val();
        gearbox.gearboxBearingsPosition6BearingPosId = $('#ddlPosition6 :selected').val();
        gearbox.gearboxBearingsDamage1BearingErrorId = $('#ddlTypeofDamage1 :selected').val();
        gearbox.gearboxBearingsDamage2BearingErrorId = $('#ddlTypeofDamage2 :selected').val();
        gearbox.gearboxBearingsDamage3BearingErrorId = $('#ddlTypeofDamage3 :selected').val();
        gearbox.gearboxBearingsDamage4BearingErrorId = $('#ddlTypeofDamage4 :selected').val();
        gearbox.gearboxBearingsDamage5BearingErrorId = $('#ddlTypeofDamage5 :selected').val();
        gearbox.gearboxBearingsDamage6BearingErrorId = $('#ddlTypeofDamage6 :selected').val();
        //Added By Siddharth Chauhan on 23-05-2016
        gearbox.gearboxBearingDecision1DamageDecisionId = $('#ddlBearingDamageClass1 :selected').val();
        gearbox.gearboxBearingDecision2DamageDecisionId = $('#ddlBearingDamageClass2 :selected').val();
        gearbox.gearboxBearingDecision3DamageDecisionId = $('#ddlBearingDamageClass3 :selected').val();
        gearbox.gearboxBearingDecision4DamageDecisionId = $('#ddlBearingDamageClass4 :selected').val();
        gearbox.gearboxBearingDecision5DamageDecisionId = $('#ddlBearingDamageClass5 :selected').val();
        gearbox.gearboxBearingDecision6DamageDecisionId = $('#ddlBearingDamageClass6 :selected').val();
        //Added By Siddharth Chauhan on 23-05-2016
        gearbox.gearboxPlanetStage1HousingErrorId = $('#ddlPlanetStage1 :selected').val();
        gearbox.gearboxPlanetStage2HousingErrorId = $('#ddlPlanetStage2 :selected').val();
        gearbox.gearboxHelicalStageHousingErrorId = $('#ddlHelicalParallelStage :selected').val();
        gearbox.gearboxFrontPlateHousingErrorId = $('#ddlFrontPlate :selected').val();
        gearbox.gearboxAuxStageHousingErrorId = $('#ddlAuxlliaryStage :selected').val();
        gearbox.gearboxHSStageHousingErrorId = $('#ddlHSStage :selected').val();
        gearbox.gearboxPlanetStage2HousingErrorId = $('#ddlPlanetStage2 :selected').val();
        gearbox.gearboxLooseBolts = $('#chkLooseBolts').is(':checked');
        gearbox.gearboxBrokenBolts = $('#chkBrokenBolts').is(':checked');
        gearbox.gearboxDefectDamperElements = $('#chkDefectDamperElements').is(':checked');
        gearbox.gearboxTooMuchClearance = $('#chkTooMuchClearance').is(':checked');
        gearbox.gearboxCrackedTorqueArm = $('#chkCrackedBrokenTorqueArm').is(':checked');
        gearbox.gearboxNeedsToBeAligned = $('#chkNeedsToBeAligned').is(':checked');
        gearbox.gearboxPT100Bearing1 = $('#chkPt100Bearing1').is(':checked');
        gearbox.gearboxPT100Bearing2 = $('#chkPt100Bearing2').is(':checked');
        gearbox.gearboxPT100Bearing3 = $('#chkPt100Bearing3').is(':checked');
        gearbox.gearboxOilLevelSensor = $('#chkOilLevelsensor').is(':checked');
        gearbox.gearboxOilPressure = $('#chkOilPressures412').is(':checked');
        gearbox.gearboxPT100OilSump = $('#chkPt100OilSump').is(':checked');
        gearbox.gearboxFilterIndicator = $('#chkFilterIndicator').is(':checked');
        gearbox.gearboxImmersionHeater = $('#chkImmersionHeater').is(':checked');
        gearbox.gearboxDrainValve = $('#chkDrainValve').is(':checked');
        gearbox.gearboxAirBreather = $('#chkAirBreather').is(':checked');
        gearbox.gearboxSightGlass = $('#chkSightGlass').is(':checked');
        gearbox.gearboxChipDetector = $('#chkChipDetector').is(':checked');
        gearbox.gearboxVibrationsId = $('#ddlVibrations :selected').val();
        gearbox.gearboxNoiseId = $('#ddlNoise :selected').val();
        gearbox.gearboxDebrisOnMagnetId = $('#ddlDebrisOnMagnet :selected').val();
        gearbox.gearboxDebrisStagesMagnetPosId = $('#ddlMagnetPos :selected').val();
        gearbox.gearboxDebrisGearBoxId = $('#ddlDebrisFoundinGearbox :selected').val();
        gearbox.gearboxOverallGearboxConditionId = $('#ddlOverallGearboxCondition :selected').val();
        gearbox.gearboxMaxTempResetDate = $('#txtDateMaxTemperatureResetDate').val();
        gearbox.gearboxTempBearing1 = $('#txtBearing1').val();
        gearbox.gearboxTempBearing2 = $('#txtBearing2').val();
        gearbox.gearboxTempBearing3 = $('#txtBearing3').val();
        gearbox.gearboxTempOilSump = $('#txtOilSump').val();
        gearbox.gearboxLSSNRend = $('#chkLSSNREnd').is(':checked');
        gearbox.gearboxIMSNRend = $('#chkIMSNREnd').is(':checked');
        gearbox.gearboxIMSRend = $('#chkIMSREnd').is(':checked');
        gearbox.gearboxHSSNRend = $('#chkHSSNREnd').is(':checked');
        gearbox.gearboxHSSRend = $('#chkHSSREnd').is(':checked');
        gearbox.gearboxPitchTube = $('#chkPitchTube').is(':checked');
        gearbox.gearboxSplitLines = $('#chkSpliLines').is(':checked');
        gearbox.gearboxHoseAndPiping = $('#chkHoseandPiping').is(':checked');
        gearbox.gearboxInputShaft = $('#chkInputShaft').is(':checked');
        gearbox.gearboxHSSPTO = $('#chkAuxHSSPTO').is(':checked');
        gearbox.gearboxDefectCategorizationScore = $('#lblDefectSCategorizationScore').text();

        cirLocalObject.gearbox = gearbox;



    };

    this.setCirImageData = function () {
        var deferredObject = $.Deferred();
        GetJsonFromFile(function (data) {

            data.imageInfo = loadInfojsonfromhtml();

            if (data.Images.length > 0) {
                cirLocalObject.imageData = data.Images;
            }
            else {
                cirLocalObject.imageData = [];
            }

            cirLocalObject.imageDataInfo = data.imageInfo;
            deferredObject.resolve();

            $("#_saveIndicator").fadeOut("slow");
            return true;
        });

        return deferredObject.promise();

    };

    this.setSimplifiedCirImageData = function () {
        var deferredObject = $.Deferred();
        GetJsonFromSimplifiedFile(function (data) {

            // data.imageInfo = loadInfojsonfromhtml();

            if (data.Images.length > 0) {
                cirLocalObject.imageData = data.Images;
            }
            else {
                cirLocalObject.imageData = [];
            }

            //cirLocalObject.imageDataInfo = data.imageInfo;
            deferredObject.resolve();

            $("#_saveIndicator").fadeOut("slow");
            return true;
        });

        return deferredObject.promise();

    };

    this.setCirDynamicTableData = function (n) {

        var dynamicTableInputs = {};
        dynamicTableInputs.id = "0";
        dynamicTableInputs.cirId = $('#cirLocalID').val();
        dynamicTableInputs.row1Col1 = $('#txtRow1Col1').val();
        dynamicTableInputs.row1Col2 = $('#txtRow1Col2').val();
        dynamicTableInputs.row1Col3 = $('#txtRow1Col3').val();
        dynamicTableInputs.row1Col4 = $('#txtRow1Col4').val();
        dynamicTableInputs.row2Col1 = $('#txtRow2Col1').val();
        dynamicTableInputs.row2Col2 = $('#txtRow2Col2').val();
        dynamicTableInputs.row2Col3 = $('#txtRow2Col3').val();
        dynamicTableInputs.row2Col4 = $('#txtRow2Col4').val();
        dynamicTableInputs.row3Col1 = $('#txtRow3Col1').val();
        dynamicTableInputs.row3Col2 = $('#txtRow3Col2').val();
        dynamicTableInputs.row3Col3 = $('#txtRow3Col3').val();
        dynamicTableInputs.row3Col4 = $('#txtRow3Col4').val();
        dynamicTableInputs.row4Col1 = $('#txtRow4Col1').val();
        dynamicTableInputs.row4Col2 = $('#txtRow4Col2').val();
        dynamicTableInputs.row4Col3 = $('#txtRow4Col3').val();
        dynamicTableInputs.row4Col4 = $('#txtRow4Col4').val();
        dynamicTableInputs.row5Col1 = $('#txtRow5Col1').val();
        dynamicTableInputs.row5Col2 = $('#txtRow5Col2').val();
        dynamicTableInputs.row5Col3 = $('#txtRow5Col3').val();
        dynamicTableInputs.row5Col4 = $('#txtRow5Col4').val();
        dynamicTableInputs.row6Col1 = $('#txtRow6Col1').val();
        dynamicTableInputs.row6Col2 = $('#txtRow6Col2').val();
        dynamicTableInputs.row6Col3 = $('#txtRow6Col3').val();
        dynamicTableInputs.row6Col4 = $('#txtRow6Col4').val();
        dynamicTableInputs.row7Col1 = $('#txtRow7Col1').val();
        dynamicTableInputs.row7Col2 = $('#txtRow7Col2').val();
        dynamicTableInputs.row7Col3 = $('#txtRow7Col3').val();
        dynamicTableInputs.row7Col4 = $('#txtRow7Col4').val();
        dynamicTableInputs.row8Col1 = $('#txtRow8Col1').val();
        dynamicTableInputs.row8Col2 = $('#txtRow8Col2').val();
        dynamicTableInputs.row8Col3 = $('#txtRow8Col3').val();
        dynamicTableInputs.row8Col4 = $('#txtRow8Col4').val();
        dynamicTableInputs.row9Col1 = $('#txtRow9Col1').val();
        dynamicTableInputs.row9Col2 = $('#txtRow9Col2').val();
        dynamicTableInputs.row9Col3 = $('#txtRow9Col3').val();
        dynamicTableInputs.row9Col4 = $('#txtRow9Col4').val();
        dynamicTableInputs.row10Col1 = $('#txtRow10Col1').val();
        dynamicTableInputs.row10Col2 = $('#txtRow10Col2').val();
        dynamicTableInputs.row10Col3 = $('#txtRow10Col3').val();
        dynamicTableInputs.row10Col4 = $('#txtRow10Col4').val();

        dynamicTableInputs.row1Col5 = $('#txtRow1Col5').val();
        dynamicTableInputs.row1Col6 = $('#txtRow1Col6').val();
        dynamicTableInputs.row2Col5 = $('#txtRow2Col5').val();
        dynamicTableInputs.row2Col6 = $('#txtRow2Col6').val();
        dynamicTableInputs.row3Col5 = $('#txtRow3Col5').val();
        dynamicTableInputs.row3Col6 = $('#txtRow3Col6').val();
        dynamicTableInputs.row4Col5 = $('#txtRow4Col5').val();
        dynamicTableInputs.row4Col6 = $('#txtRow4Col6').val();
        dynamicTableInputs.row5Col5 = $('#txtRow5Col5').val();
        dynamicTableInputs.row5Col6 = $('#txtRow5Col6').val();
        dynamicTableInputs.row6Col5 = $('#txtRow6Col5').val();
        dynamicTableInputs.row6Col6 = $('#txtRow6Col6').val();
        dynamicTableInputs.row7Col5 = $('#txtRow7Col5').val();
        dynamicTableInputs.row7Col6 = $('#txtRow7Col6').val();
        dynamicTableInputs.row8Col5 = $('#txtRow8Col5').val();
        dynamicTableInputs.row8Col6 = $('#txtRow8Col6').val();
        dynamicTableInputs.row9Col5 = $('#txtRow9Col5').val();
        dynamicTableInputs.row9Col6 = $('#txtRow9Col6').val();
        dynamicTableInputs.row10Col5 = $('#txtRow10Col5').val();

        cirLocalObject.dynamicTableInputs = dynamicTableInputs;


    };

    //Flange Dynamic table Inputs
    this.setSimplifiedCirDynamicData = function (n) {
        var dynamicTableInputs = {};
        dynamicTableInputs.id = "0";
        dynamicTableInputs.cirId = $('#cirLocalID').val();
        dynamicTableInputs.row1Col1 = $('#cirDynamicAccordSection1 #controlHeader1').val();
        dynamicTableInputs.row2Col1 = $('#cirDynamicAccordSection1 #controlHeader2').val();
        dynamicTableInputs.row13Col1 = $('#cirDynamicAccordSection1 #txtrowHeader13').val();
        dynamicTableInputs.row14Col1 = $('#cirDynamicAccordSection1 #txtrowHeader14').val();
        dynamicTableInputs.row3Col1 = $('#cirDynamicAccordSection1 #txtrowHeader3').val();
        dynamicTableInputs.row4Col1 = $('#cirDynamicAccordSection1 #controlHeader4').val();
        dynamicTableInputs.row5Col1 = $('#cirDynamicAccordSection1 #txtrowHeader5').val();
        dynamicTableInputs.row6Col1 = $('#cirDynamicAccordSection1 #txtrowHeader6').val();
        dynamicTableInputs.row7Col1 = $('#cirDynamicAccordSection1 #txtrowHeader7').val();
        dynamicTableInputs.row8Col1 = $('#cirDynamicAccordSection1 #chkrowHeader8').val();
        dynamicTableInputs.row9Col1 = $('#cirDynamicAccordSection1 #txtrowHeader9').val();
        dynamicTableInputs.row10Col1 = $('#cirDynamicAccordSection1 #txtrowHeader10').val();
        dynamicTableInputs.row11Col1 = $('#cirDynamicAccordSection1 #txtrowHeader11').val();
        dynamicTableInputs.row12Col1 = $('#cirDynamicAccordSection1 #txtrowHeader12').val();

        dynamicTableInputs.row1Col2 = $('#cirDynamicAccordSection2 #controlHeader1').val();
        dynamicTableInputs.row2Col2 = $('#cirDynamicAccordSection2 #controlHeader2').val();
        dynamicTableInputs.row13Col2 = $('#cirDynamicAccordSection2 #txtrowHeader13').val();
        dynamicTableInputs.row14Col2 = $('#cirDynamicAccordSection2 #txtrowHeader14').val();
        dynamicTableInputs.row3Col2 = $('#cirDynamicAccordSection2 #txtrowHeader3').val();
        dynamicTableInputs.row4Col2 = $('#cirDynamicAccordSection2 #controlHeader4').val();
        dynamicTableInputs.row5Col2 = $('#cirDynamicAccordSection2 #txtrowHeader5').val();
        dynamicTableInputs.row6Col2 = $('#cirDynamicAccordSection2 #txtrowHeader6').val();
        dynamicTableInputs.row7Col2 = $('#cirDynamicAccordSection2 #txtrowHeader7').val();
        dynamicTableInputs.row8Col2 = $('#cirDynamicAccordSection2 #chkrowHeader8').val();
        dynamicTableInputs.row9Col2 = $('#cirDynamicAccordSection2 #txtrowHeader9').val();
        dynamicTableInputs.row10Col2 = $('#cirDynamicAccordSection2 #txtrowHeader10').val();
        dynamicTableInputs.row11Col2 = $('#cirDynamicAccordSection2 #txtrowHeader11').val();
        dynamicTableInputs.row12Col2 = $('#cirDynamicAccordSection2 #txtrowHeader12').val();

        dynamicTableInputs.row1Col3 = $('#cirDynamicAccordSection3 #controlHeader1').val();
        dynamicTableInputs.row2Col3 = $('#cirDynamicAccordSection3 #controlHeader2').val();
        dynamicTableInputs.row13Col3 = $('#cirDynamicAccordSection3 #txtrowHeader13').val();
        dynamicTableInputs.row14Col3 = $('#cirDynamicAccordSection3 #txtrowHeader14').val();
        dynamicTableInputs.row3Col3 = $('#cirDynamicAccordSection3 #txtrowHeader3').val();
        dynamicTableInputs.row4Col3 = $('#cirDynamicAccordSection3 #controlHeader4').val();
        dynamicTableInputs.row5Col3 = $('#cirDynamicAccordSection3 #txtrowHeader5').val();
        dynamicTableInputs.row6Col3 = $('#cirDynamicAccordSection3 #txtrowHeader6').val();
        dynamicTableInputs.row7Col3 = $('#cirDynamicAccordSection3 #txtrowHeader7').val();
        dynamicTableInputs.row8Col3 = $('#cirDynamicAccordSection3 #chkrowHeader8').val();
        dynamicTableInputs.row9Col3 = $('#cirDynamicAccordSection3 #txtrowHeader9').val();
        dynamicTableInputs.row10Col3 = $('#cirDynamicAccordSection3 #txtrowHeader10').val();
        dynamicTableInputs.row11Col3 = $('#cirDynamicAccordSection3 #txtrowHeader11').val();
        dynamicTableInputs.row12Col3 = $('#cirDynamicAccordSection3 #txtrowHeader12').val();

        dynamicTableInputs.row1Col4 = $('#cirDynamicAccordSection4 #controlHeader1').val();
        dynamicTableInputs.row2Col4 = $('#cirDynamicAccordSection4 #controlHeader2').val();
        dynamicTableInputs.row13Col4 = $('#cirDynamicAccordSection4 #txtrowHeader13').val();
        dynamicTableInputs.row14Col4 = $('#cirDynamicAccordSection4 #txtrowHeader14').val();
        dynamicTableInputs.row3Col4 = $('#cirDynamicAccordSection4 #txtrowHeader3').val();
        dynamicTableInputs.row4Col4 = $('#cirDynamicAccordSection4 #controlHeader4').val();
        dynamicTableInputs.row5Col4 = $('#cirDynamicAccordSection4 #txtrowHeader5').val();
        dynamicTableInputs.row6Col4 = $('#cirDynamicAccordSection4 #txtrowHeader6').val();
        dynamicTableInputs.row7Col4 = $('#cirDynamicAccordSection4 #txtrowHeader7').val();
        dynamicTableInputs.row8Col4 = $('#cirDynamicAccordSection4 #chkrowHeader8').val();
        dynamicTableInputs.row9Col4 = $('#cirDynamicAccordSection4 #txtrowHeader9').val();
        dynamicTableInputs.row10Col4 = $('#cirDynamicAccordSection4 #txtrowHeader10').val();
        dynamicTableInputs.row11Col4 = $('#cirDynamicAccordSection4 #txtrowHeader11').val();
        dynamicTableInputs.row12Col4 = $('#cirDynamicAccordSection4 #txtrowHeader12').val();

        dynamicTableInputs.row1Col5 = $('#cirDynamicAccordSection5 #controlHeader1').val();
        dynamicTableInputs.row2Col5 = $('#cirDynamicAccordSection5 #controlHeader2').val();
        dynamicTableInputs.row13Col5 = $('#cirDynamicAccordSection5 #txtrowHeader13').val();
        dynamicTableInputs.row14Col5 = $('#cirDynamicAccordSection5 #txtrowHeader14').val();
        dynamicTableInputs.row3Col5 = $('#cirDynamicAccordSection5 #txtrowHeader3').val();
        dynamicTableInputs.row4Col5 = $('#cirDynamicAccordSection5 #controlHeader4').val();
        dynamicTableInputs.row5Col5 = $('#cirDynamicAccordSection5 #txtrowHeader5').val();
        dynamicTableInputs.row6Col5 = $('#cirDynamicAccordSection5 #txtrowHeader6').val();
        dynamicTableInputs.row7Col5 = $('#cirDynamicAccordSection5 #txtrowHeader7').val();
        dynamicTableInputs.row8Col5 = $('#cirDynamicAccordSection5 #chkrowHeader8').val();
        dynamicTableInputs.row9Col5 = $('#cirDynamicAccordSection5 #txtrowHeader9').val();
        dynamicTableInputs.row10Col5 = $('#cirDynamicAccordSection5 #txtrowHeader10').val();
        dynamicTableInputs.row11Col5 = $('#cirDynamicAccordSection5 #txtrowHeader11').val();
        dynamicTableInputs.row12Col5 = $('#cirDynamicAccordSection5 #txtrowHeader12').val();

        dynamicTableInputs.row1Col6 = $('#cirDynamicAccordSection6 #controlHeader1').val();
        dynamicTableInputs.row2Col6 = $('#cirDynamicAccordSection6 #controlHeader2').val();
        dynamicTableInputs.row13Col6 = $('#cirDynamicAccordSection6 #txtrowHeader13').val();
        dynamicTableInputs.row14Col6 = $('#cirDynamicAccordSection6 #txtrowHeader14').val();
        dynamicTableInputs.row3Col6 = $('#cirDynamicAccordSection6 #txtrowHeader3').val();
        dynamicTableInputs.row4Col6 = $('#cirDynamicAccordSection6 #controlHeader4').val();
        dynamicTableInputs.row5Col6 = $('#cirDynamicAccordSection6 #txtrowHeader5').val();
        dynamicTableInputs.row6Col6 = $('#cirDynamicAccordSection6 #txtrowHeader6').val();
        dynamicTableInputs.row7Col6 = $('#cirDynamicAccordSection6 #txtrowHeader7').val();
        dynamicTableInputs.row8Col6 = $('#cirDynamicAccordSection6 #chkrowHeader8').val();
        dynamicTableInputs.row9Col6 = $('#cirDynamicAccordSection6 #txtrowHeader9').val();
        dynamicTableInputs.row10Col6 = $('#cirDynamicAccordSection6 #txtrowHeader10').val();
        dynamicTableInputs.row11Col6 = $('#cirDynamicAccordSection6 #txtrowHeader11').val();
        dynamicTableInputs.row12Col6 = $('#cirDynamicAccordSection6 #txtrowHeader12').val();

        cirLocalObject.dynamicTableInputs = dynamicTableInputs;


    };

    //Flange Decision Inputs

    this.setSimplifiedDecisionData = function (n) {

        var decisiondata = [];

        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection1 #controlDecision').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection1 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection1 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 1;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection1 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection1 #txtImgInspectionDescription1').val();
        decisiondata.push(dynamicDecisionDetails);
        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection2 #controlDecision').val();
        dynamicDecisionDetails.ImidiateActions = $('#cirDynamicAccordSecdtion2 #txtImgInspectionDescription6').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection2 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection2 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 2;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection2 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection2 #txtImgInspectionDescription2').val();
        decisiondata.push(dynamicDecisionDetails);

        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection3 #controlDecision').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection3 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection3 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 3;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection3 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection3 #txtImgInspectionDescription3').val();
        decisiondata.push(dynamicDecisionDetails);

        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection4 #controlDecision').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection4 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection4 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 4;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection4 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection4 #txtImgInspectionDescription4').val();
        decisiondata.push(dynamicDecisionDetails);

        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection5 #controlDecision').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection5 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection5 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 5;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection5 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection5 #txtImgInspectionDescription5').val();
        decisiondata.push(dynamicDecisionDetails);
        var dynamicDecisionDetails = {};
        dynamicDecisionDetails.id = "0";
        dynamicDecisionDetails.decision = $('#cirDynamicAccordSection6 #controlDecision').val();
        dynamicDecisionDetails.repeatedInspections = $('#cirDynamicAccordSection6 #controlRepeatedInspection').val();
        dynamicDecisionDetails.affectedBolts = $('#cirDynamicAccordSection6 #chkReplaceAffectedBolts').is(':checked') ? 1 : 0;
        dynamicDecisionDetails.flangNo = 6;
        dynamicDecisionDetails.flangeDamageIdentified = $('#cirDynamicAccordSection6 #chkDamageIdentifiedSimplified').is(':checked');
        dynamicDecisionDetails.inspectionDesc = $('#cirDynamicAccordSection6 #txtImgInspectionDescription6').val();
        decisiondata.push(dynamicDecisionDetails);

        cirLocalObject.dyanamicDecisionData = decisiondata;

    }

    //    var dynamicDecisionDetails = {};
    //    dynamicDecisionDetails.id = "0";
    //    dynamicTableInputs.cirId = $('#cirLocalID').val();
    //    cirLocalObject.dynamicTableInputs = dynamicTableInputs;


    //};







    this.TemplateVersion = function () {
        return $('#hdntemplateVersion').val();
    }
    this.getAuxEquipmentId = function () {
        if ($('#ddlCirType').val() == 1) {
            return $('#ddlAuxEquipment').val();
        }
        else if ($('#ddlCirType').val() == 4) {
            return $('#ddlGeneratorAuxEquipment').val();
        } else if ($('#ddlCirType').val() == 5) {
            return $('#ddlTransformerAuxEquipment').val();
        }
        else
            return 1;
    }
    this.UpdateTemplateFields = function () {
        $('#cirTemplateLink').html('Choose Template (Template version ' + $('#hdntemplateVersion').val() + ')');
        $('*[data-templateFieldVisibility="hide"]').each(function (index) {
            var templateprop = $(this).data();
            if ($.inArray($('#hdntemplateVersion').val(), templateprop.templatefor.split(',')) >= 0) {
                $(this).hide();
            }
        });
        $('*[data-templateFieldVisibility="show"]').each(function (index) {
            var templateprop = $(this).data();
            if ($.inArray($('#hdntemplateVersion').val(), templateprop.templatefor.split(',')) >= 0) {
                $(this).show();
            }
        });
    }

    this.LoadDropDowns = function (callback) {
        var deferredObject = $.Deferred();
        var selectelements = $('*[data-fieldType="select"]');
        var taskCount = selectelements.length;
        var taskCompleted = 0;
        selectelements.each(function (index) {
            dbtransaction.BindDropDown($(this)).done(function (selectitem) {
                taskCompleted++;
                if (selectitem.attr('id') == "ddlCauseSkiip") {
                    for (var i = 1; i <= 9; i++) {
                        $('#divComponentIdentification' + i.toString()).attr('data-dbid', 0);;
                        $('#divComponentIdentificationNew' + i.toString()).attr('data-dbid', 0);;
                    }
                }


                if (selectitem.attr('id') == "ddlCirType") {

                    var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Member") || hasRole("Editor") || hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians") || hasRole("Administrator");

                    if (!userValid && hasRole("CIR Evaluator")) {

                        $("#ddlCirType option[value='1'],#ddlCirType option[value='2'],#ddlCirType option[value='3'],#ddlCirType option[value='4'],#ddlCirType option[value='5'],#ddlCirType option[value='6'],#ddlCirType option[value='7'] ").remove();

                    }

                }
                if (taskCount == taskCompleted) {
                    deferredObject.resolve();
                }
            });
        });
        return deferredObject.promise();
    }


    this.LoadDynamicDropDowns = function (cimCaseNo, callback) {
        var deferredObject = $.Deferred();
        var selectelements = $('*[data-fieldType="selectDynamic"]');
        var taskCount = selectelements.length;
        var taskCompleted = 0;
        selectelements.each(function (index) {
            dbtransaction.BindDynamicDropDown(cimCaseNo, $(this)).done(function (selectitem) {
                taskCompleted++;
                if (taskCount == taskCompleted) {
                    deferredObject.resolve();
                }
            });
        });
        return deferredObject.promise();
    }

    this.ValidateLockFromSQL = function (cirDataDetail) {
        var deferredObject = $.Deferred();
        if (Offline.state == "up") {
            CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
                deferredObject.resolve(result);
            }).fail(function () {
                deferredObject.resolve();
            });
        }
        else {
            deferredObject.resolve();
        }
        return deferredObject.promise();
    }

    this.LoadCIMCase = function () {
        var deferredObject = $.Deferred();
        if (Offline.state == "up") {
            CallClientApi("CIMCaseTable", "GET", "").done(function (result) {
                if (result && result.length > 0) {
                    $("#txtCimNo").autocomplete({
                        minLength: 0,
                        source: result
                    }).autocomplete("instance")._renderItem = function (ul, item) {
                        return $("<li>")
                            .append(item.desc)
                            .appendTo(ul);
                    };

                    $("#txtCimNo_Flang").autocomplete({
                        minLength: 0,
                        source: result
                    }).autocomplete("instance")._renderItem = function (ul, item) {
                        return $("<li>")
                            .append(item.desc)
                            .appendTo(ul);
                    };
                }
                deferredObject.resolve();
            }).fail(function () {
                deferredObject.resolve();
            });
        }
        else {
            deferredObject.resolve();
        }
        return deferredObject.promise();
    }

    this.loadTurbine = function () {
        var deferredObject = $.Deferred();
        dbtransaction.getItemfromTable('TurbineData', renderTurbines);
        //Rendring items in list
        function renderTurbines(turbines) {
            var tData = [];
            turbines.forEach(function (item) {
                tData.push({
                    value: item.TurbineID,
                    label: item.TurbineID,
                    site: item.Site,
                    type: item.Type,
                    country: item.Country
                });
            });

            $("#txtTurbineNumber").autocomplete({
                source: tData,
                minLength: 0,
                select: function (event, turbineItem) {
                    if (turbineItem) {
                        $('#txtTurbineCountry').val(turbineItem.item.country);
                        $('#txtTurbineSite').val(turbineItem.item.site);
                        $('#txtTurbineType').val(turbineItem.item.type);
                    }
                }
            });
            deferredObject.resolve();
        }
        return deferredObject.promise();
    }

    this.loadGearTypeDamageDecision = function () {
        var deferredObject = $.Deferred();
        dbtransaction.getItemfromTable('GearTypeDamageDecision', renderGearTypeDamageDecision);
        //Rendring items in list
        function renderGearTypeDamageDecision(gearTypeDamageDecision) {
            var arrayGearTypeDamageDecision = [];
            gearTypeDamageDecision.forEach(function (item) {
                elGearTypeDamageDecision = {};
                elGearTypeDamageDecision.gearTypeDamageDecisionID = item.GearTypeDamageDecisionID;
                elGearTypeDamageDecision.gearTypeDamageDecisionText = item.text;
                arrayGearTypeDamageDecision.push(elGearTypeDamageDecision);

            });
            $('#hdnGearTypeDamageDecision').val(JSON.stringify(arrayGearTypeDamageDecision));
            deferredObject.resolve();
        }
        return deferredObject.promise();
    }

    this.loadData = function (item) {
        cirOfflineApp.showDialog = 1;
        var deferredObject = $.Deferred();
        if (hasRole("Administrator") || hasRole("Member")) {
            $("#linkSubmitApproveCIR").show();
        }
        else {
            $("#linkSubmitApproveCIR").hide();
        }
        if ($('#ddlCirType') != null) {
            $('#ddlCirType').prop("disabled", true);
        }
        $('#cirLocalID').val(item.CirDataLocalID);
        $('#cirlbl').html('Update CIR (' + item.CirDataLocalID + ')');
        $('#CirDataCommonID').val(item.CirDataCommonID);
        $('#CirName').val(item.CirData.componentInspectionReportName);
        $('#hdntemplateVersion').val(item.CirData.templateVersion);
        dbtransaction.openDatabase(function () {
            if (item.CirData.componentInspectionReportTypeId == 8 && !$.isEmptyObject(item.CirData)) {

                renderSimplifiedCirCommonData(getArray(item.CirData));

                $('#txtCimNo_Flang').blur();
                setTimeout(function myfunction() {
                    if (item.CirData.imageData && !$.isEmptyObject(item.CirData.imageData)) {

                        var imgArr = [];
                        $.each(item.CirData.imageData, function (i, x) {
                            var imgObj = {};
                            if (x.imageId != undefined) {
                                imgObj.inspectionDesc = x.inspectionDesc;
                                imgObj.imageDescription = x.imageDescription;
                                imgObj.imageDataString = x.imageDataString;
                                imgObj.imageId = x.imageId;
                                imgObj.imageOrder = x.imageOrder;
                                imgObj.flangNo = x.flangNo;
                                imgArr.push(imgObj);
                            }
                        });
                        renderDynamicInputImages(imgArr);

                    }
                }, 4000);
                var i = 0;
                var objDFlanges = setInterval(function () {
                    if (item.CirData.dynamicTableInputs && !$.isEmptyObject(item.CirData.dynamicTableInputs)) {
                        renderCirDataDynamicFlangSections(getArray(item.CirData.dynamicTableInputs));

                    }
                    if (item.CirData.dyanamicDecisionData == undefined && item.CirData.DyanamicDecisionData != undefined)
                    { item.CirData.dyanamicDecisionData.push(item.CirData.DyanamicDecisionData) }


                    if (item.CirData.dyanamicDecisionData && !$.isEmptyObject(item.CirData.dyanamicDecisionData)) {
                        renderCirDataDynamicDecisionSections(item.CirData.dyanamicDecisionData);
                    }
                    i++
                    if (i == 5)
                    { clearInterval(objDFlanges); }

                }, 2000);

            }
            else {
                renderCirDataCommon(getArray(item.CirData));
                if (item.CirData.bladeData && !$.isEmptyObject(item.CirData.bladeData)) {
                    renderCirDataBlade(getArray(item.CirData.bladeData));
                    if (item.CirData.bladeData.damageData && !$.isEmptyObject(item.CirData.bladeData.damageData))
                        renderCirDataBladeDamage(item.CirData.bladeData.damageData);
                    if (item.CirData.bladeData.repairRecordData && !$.isEmptyObject(item.CirData.bladeData.repairRecordData))
                        renderCirDataBladeRepairRecord(item.CirData.bladeData.repairRecordData);
                }
                if (item.CirData.general && !$.isEmptyObject(item.CirData.general))
                    renderCirDataGeneral(getArray(item.CirData.general));
                if (item.CirData.skiip && !$.isEmptyObject(item.CirData.skiip)) {
                    renderCirSkiipackdata(getArray(item.CirData.skiip));
                    if (item.CirData.skiip.skiipFailedComp && !$.isEmptyObject(item.CirData.skiip.skiipFailedComp))
                        renderCirSkiipackFailedComponent(item.CirData.skiip.skiipFailedComp);
                    if (item.CirData.skiip.skiipNewComp && !$.isEmptyObject(item.CirData.skiip.skiipNewComp))
                        renderCirSkiipackNewComponent(item.CirData.skiip.skiipNewComp);
                }
                if (item.CirData.transformer && !$.isEmptyObject(item.CirData.transformer))
                    renderCirDataTransformer(getArray(item.CirData.transformer));
                if (item.CirData.mainBearing && !$.isEmptyObject(item.CirData.mainBearing))
                    renderCirDataMainBearing(getArray(item.CirData.mainBearing));
                if (item.CirData.generator && !$.isEmptyObject(item.CirData.generator))
                    renderCirDataGenerator(getArray(item.CirData.generator));
                if (item.CirData.gearbox && !$.isEmptyObject(item.CirData.gearbox))
                    renderCirDataGearbox(getArray(item.CirData.gearbox));
                if (item.CirData.dynamicTableInputs && !$.isEmptyObject(item.CirData.dynamicTableInputs))
                    renderCirDataDynamicTable(getArray(item.CirData.dynamicTableInputs));
                if (item.CirData.imageData && !$.isEmptyObject(item.CirData.imageData)) {

                    var imgArr = [];
                    $.each(item.CirData.imageData, function (i, x) {
                        var imgObj = {};
                        imgObj.inspectionDesc = x.inspectionDesc;
                        imgObj.imageDescription = x.imageDescription;
                        imgObj.imageDataString = x.imageDataString;
                        imgObj.imageId = x.imageId;
                        imgObj.imageOrder = x.imageOrder;
                        imgArr.push(imgObj);
                    });
                    renderCirImages(imgArr);
                }
                if (item.CirData.imageDataInfo && !$.isEmptyObject(item.CirData.imageDataInfo)) {
                    item.CirData.imageDataInfo.plateTypeNotPossibleReason = item.CirData.imageDataInfo.plateTypeNotPossibleReason;
                    item.CirData.imageDataInfo.isPlateTypeNotPossible = item.CirData.imageDataInfo.isPlateTypeNotPossible;
                    loadinfoFromJson(item.CirData.imageDataInfo)
                }
            }

            deferredObject.resolve();
        });

        return deferredObject.promise();
    }
    //Called when User clicks the Edit Cir from Local History Page
    this.loadCIRData = function (id) {
        var deferredObject = $.Deferred();

        cirOfflineApp.findCirLocalData(id).done(function (LocalItem) {
            if (LocalItem == false) {
                NotifyMe("Error:", 'Requested CIR was not found locally and cannot be loaded!', "danger");
                waitingDialog.hide();
            }
            else {
                if (LocalItem.Status == -1 || LocalItem.Status == 3) {
                    dbtransaction.addItemIntoTransactionTable(
                        {
                            CirDataCommonID: LocalItem.CirDataCommonID,
                            CirDataLocalID: LocalItem.CirDataLocalID,
                            UpdateBy: LocalItem.UpdateBy, // This will be changed after Azure auth
                            CreatedDate: LocalItem.CreatedDate,
                            Status: 1,
                            StatusMessage: 'CIR is in Draft version',
                            StatusDetailMessage: 'This CIR is in Draft version. Draft version will be synced when online and status will be updated.',
                            CirData: LocalItem.CirData,
                            CirDataTemp: {},
                            UserInitial: LocalItem.UserInitial,
                            IsDirty: true,
                            Deleted: false,
                            CirStatus: LocalItem.CirStatus,
                            RowVersion: LocalItem.RowVersion
                        }, 'CirDataCommon', function () {
                            cirOfflineApp.loadData(LocalItem).done(function () {
                                waitingDialog.show('Loading template data..', { dialogSize: 'sm', progressType: 'primary' });
                                deferredObject.resolve();
                            });

                        });
                }
                else {
                    cirOfflineApp.loadData(LocalItem).done(function () {
                        waitingDialog.show('Loading template data..', { dialogSize: 'sm', progressType: 'primary' });
                        deferredObject.resolve();
                    });


                }
            }

        });


        $('#cirlbl').html('Update CIR');
        return deferredObject.promise();
    };

    this.StartSaveTimer = function () {
        $('#CirForm :input').each(function () {
            $(this).data('initialValue', $(this).val());
        });
        //_SaveCirTimer = setInterval(function () {
        //    cirOfflineApp.SaveCir();
        //}, 5000);
    }

    this.StopSaveTimer = function () {
        clearInterval(_SaveCirTimer);
    }

    //Called when User clicks the Edit Cir from Manage Cir
    this.LoadRemoteCirData = function (remoteCirId, _isRivision, onSucess, OnError) {
        $('#cirlbl').html('Update CIR');
        __isRivision = _isRivision;

        cirOfflineApp.getCirLocalData().done(function (CirLocalDataList) {
            var result = $.grep(CirLocalDataList, function (i) { return (i.ComponentInspectionReportId == remoteCirId && (i.Status == 1 || i.Status == -1)) });
            //No Error or Draft Found
            if (result == false || result.length == 0) {
                var result = $.grep(CirLocalDataList, function (i) { return (i.ComponentInspectionReportId == remoteCirId && (i.Status == 4 || i.Status == 2 || i.Status == 7)) });
                //No Conflict found
                if (result == false || result.length == 0) {
                    var result = $.grep(CirLocalDataList, function (i) { return (i.ComponentInspectionReportId == remoteCirId && (i.Status == 3)) });
                    if (result == false || result.length == 0) {
                        dbtransaction.openDatabase(function () {

                            var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth

                            dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                                if (currentuser) {
                                    if (currentuser.length > 0) {
                                        currentuser.forEach(function (useritem) {
                                            client.currentUser = useritem.objet;
                                            if (client.currentUser) {

                                                client.invokeApi(((__isRivision == true) ? 'GetCirRevision/' : 'CirData/') + remoteCirId, {
                                                    method: 'GET'
                                                }).done(function (response) {
                                                    var resp = response.result;
                                                    var migrationLogError = resp.htmlStr;
                                                    if (migrationLogError != null) {
                                                        if (migrationLogError.length > 0) {
                                                            $("#Error1").val(migrationLogError);

                                                        }
                                                    }
                                                    cirOfflineApp.SaveRemoteCir(result, resp).done(function (Id) {
                                                        cirOfflineApp.loadCIRData(Id).done(function () {
                                                            if (onSucess != undefined && onSucess != null) {
                                                                azureSync.StartSyncManual();
                                                                onSucess();
                                                            }
                                                        });
                                                    });


                                                }, function (error) {
                                                    console.log(error);
                                                    waitingDialog.updateMessage('CIR ' + ((__isRivision == true) ? 'revision ' : '') + 'data not found on the server.', true);
                                                    waitingDialog.hide();
                                                    NotifyMe("", 'CIR with CIRID [' + remoteCirId + '] not found on the server!', "danger");
                                                    if (OnError != undefined && onSucess != null)
                                                        OnError();
                                                });
                                            }

                                        });

                                    }
                                }
                            });
                            //Rendring items in list

                        });
                    }
                    else {


                        dbtransaction.openDatabase(function () {

                            var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth

                            dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                                if (currentuser) {
                                    if (currentuser.length > 0) {
                                        currentuser.forEach(function (useritem) {
                                            client.currentUser = useritem.objet;
                                            if (client.currentUser) {

                                                client.invokeApi(((__isRivision == true) ? 'GetCirRevision/' : 'CirData/') + remoteCirId, {
                                                    method: 'GET'
                                                }).done(function (response) {
                                                    var resp = response.result;
                                                    var migrationLogError = resp.htmlStr;
                                                    if (migrationLogError != null) {
                                                        if (migrationLogError.length > 0) {
                                                            $("#Error1").val(migrationLogError);

                                                        }
                                                    }
                                                    NotifyMe("", 'CIR with CIRID [' + remoteCirId + '] was already successfully synced by you. Draft version of this CIR is being created!', "warning");
                                                    cirOfflineApp.SaveRemoteCir(result[0], resp).done(function (Id) {
                                                        cirOfflineApp.loadCIRData(Id).done(function () {
                                                            if (onSucess != undefined && onSucess != null) {
                                                                azureSync.StartSyncManual();
                                                                onSucess();
                                                            }
                                                        });
                                                    });


                                                }, function (error) {
                                                    console.log(error);
                                                    waitingDialog.updateMessage('CIR ' + ((__isRivision == true) ? 'revision ' : '') + 'data not found on the server.', true);
                                                    waitingDialog.hide();
                                                    NotifyMe("", 'CIR with CIRID [' + remoteCirId + '] not found on the server!', "danger");
                                                    if (OnError != undefined && onSucess != null)
                                                        OnError();
                                                });
                                            }

                                        });

                                    }
                                }
                            });
                            //Rendring items in list

                        });
                    }
                }
                else {
                    //waitingDialog.hide();
                    if (result[0].Status == 2)
                        NotifyMe("", 'Unable to edit this CIR as the CIR is already been submitted to server by you for Syncing to Server!', "danger");
                    else {
                        if (result[0].Status == 4)
                            NotifyMe("", 'Unable to edit this CIR as the CIR is already in conflict state in your local history.Please resolve the conflict first!', "danger");
                        else {
                            if (result[0].Status == 7) {
                                NotifyMe("", 'Unable to edit this CIR as the CIR is delegated to other Ueser !', "danger");
                            }
                            else {
                                // waitingDialog.hide();
                                NotifyMe("", 'CIR cannot be loaded as CIRID [' + remoteCirId + '] was not found on server!', "danger");
                            }
                        }

                    }
                    setTimeout(function () { window.location.href = '/cir/local-history'; }, 3000);
                }

            }
            else {
                if (result[0].Status == 1 || result[0].Status == -1) //If Already has the Draft Version open drafty version
                {
                    // 4 conflit to be written
                    $('#CirDataCommonID').val(result[0].Id);
                    $('#cirLocalID').val(result[0].ComponentInspectionReportId); // Local CIR ID
                    $('#cirlbl').html('Update CIR (' + result[0].ComponentInspectionReportId + ')');
                    dbtransaction.getItemByIdfromTable('CirDataCommon', result[0].Id, function (item) {
                        cirOfflineApp.loadData(item).done(function () {

                            waitingDialog.hide();
                            NotifyMe("", 'Local CIR was loaded instead on Server copy as CIR with same ID was found locally. !', "warning");
                            if (onSucess != undefined && onSucess != null)
                                onSucess();
                        });
                    });
                }
                else {
                    if (onSucess != undefined && onSucess != null)
                        onSucess();
                }

            }



        });



    }

    // this.renderSimplifiedCirCommonData =
    function renderSimplifiedCirCommonData(basicCIRData) {

        var deferredObject = $.Deferred();
        basicCIRData.forEach(function (item) {
            if (item) {
                try {
                    $('#cirDataID').val(item.cirDataID);
                    $('#ddlCirType').val(item.componentInspectionReportTypeId);
                    $("#ddlCirType").change();
                    //$('#ddlReportType').val(item.reportTypeId);
                    //$('#lblfailuredate span').remove();
                    //if ($('#ddlReportType').val() == '2') {
                    //    $('#lblfailuredate').append('<span class="errorSpan">*</span>');
                    //}
                    //else {
                    //    $('#lblfailuredate span').remove();
                    //}
                    //$("#Error1").val(item.htmlStr);

                    $('#txtCimNo_Flang').val(item.cimCaseNumber);
                    $('#txtCimNo_Flang').blur();
                    $('#cirLocalID').val(item.componentInspectionReportId);
                    // $('#cirlbl').html('Update CIR (' + item.componentInspectionReportId + ')');
                    $('#CirName').val(item.componentInspectionReportName);
                    $('#hdntemplateVersion').val(item.templateVersion);
                    $('#cirRemoteID').val(item.componentInspectionReportId);
                    $('#_hCIRID').val(item.componentInspectionReportId);
                    $('#txtTurbineNumber_Flang').val(item.turbineNumber);
                    if (item.inspectionDate != null) { $('#txtInspectionDate_Flang').val(GetDateStringFromDateObject(new Date(item.inspectionDate))); }
                    else {
                        $('#txtInspectionDate_Flang').val('');
                    }
                    // $("#txtInspectionDate_Flang").datepicker("option", "maxDate", null);
                    $('#txtServicePortNo_Flang').val(item.serviceReportNumber);
                    $('#txtServiceEngineer_Flang').attr('readonly', false);
                    $('#txtServiceEngineer_Flang').text(item.serviceEngineer);
                    $('#txtServiceEngineer_Flang').val(item.serviceEngineer);
                    $('#txtServiceEngineer_Flang').attr('readonly', true);
                    $('#ddlServiceReportNumberType_Flang').val(item.serviceReportNumberTypeId);
                    if (item.serviceReportNumberTypeId != 4) {
                        $('.manServiceReportNo').hide();
                    }
                    $('#ddlRunStatusAfterInspection_Flang').val(item.afterInspectionTurbineRunStatusId);
                    $('#txtSBURecommendation_Flang').val(item.sbuRecomendation);
                    if (item.outSideSign == true) { $('#ddlOutSideSign').val('1'); }
                    if (item.outSideSign == false) { $('#ddlOutSideSign').val('0'); }

                    $('#txtDescFlangNo').val(item.flangDesc);
                    PopulateDynamicAccordian(item.cimCaseNumber);

                }
                catch (e) {
                    console.log('Error occured in Loading CIR data common ' + e);
                }
            }
        });

        return deferredObject.promise();
    }

    function renderCirDataDynamicFlangSections(cirDynamicTable) {
        var i = 0;
        var fileListLength = cirDynamicTable.length;
        var flngobj = setInterval(function () {
            var item = cirDynamicTable[i];
            try {
                $('#cirDynamicAccordSection1 #controlHeader2').val(item.row2Col1);
                $('#cirDynamicAccordSection1 #controlHeader1').val(item.row1Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader13').val(item.row13Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader14').val(item.row14Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader3').val(item.row3Col1);
                $('#cirDynamicAccordSection1 #controlHeader4').val(item.row4Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader5').val(item.row5Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader6').val(item.row6Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader7').val(item.row7Col1);
                $('#cirDynamicAccordSection1 #chkrowHeader8').val(item.row8Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader9').val(item.row9Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader10').val(item.row10Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader11').val(item.row11Col1);
                $('#cirDynamicAccordSection1 #txtrowHeader12').val(item.row12Col1);
                $('#cirDynamicAccordSection1 #controlHeader4').change();
                //$('#cirDynamicAccordSection1 #controlDecision').val(item.row12Col1);

                // $('#chkDamageIdentifiedSimplified').val(item.row1Col1);
                $('#cirDynamicAccordSection2 #controlHeader1').val(item.row1Col2);
                $('#cirDynamicAccordSection2 #controlHeader2').val(item.row2Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader13').val(item.row13Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader14').val(item.row14Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader3').val(item.row3Col2);
                $('#cirDynamicAccordSection2 #controlHeader4').val(item.row4Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader5').val(item.row5Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader6').val(item.row6Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader7').val(item.row7Col2);
                $('#cirDynamicAccordSection2 #chkrowHeader8').val(item.row8Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader9').val(item.row9Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader10').val(item.row10Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader11').val(item.row11Col2);
                $('#cirDynamicAccordSection2 #txtrowHeader12').val(item.row12Col2);
                $('#cirDynamicAccordSection2 #controlHeader4').change();
                // $('#cirDynamicAccordSection2 #controlDecision').val(item.row12Col2);

                // $('#chkDamageIdentifiedSimplified').val(item.row1Col1);
                $('#cirDynamicAccordSection3 #controlHeader1').val(item.row1Col3);
                $('#cirDynamicAccordSection3 #controlHeader2').val(item.row2Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader13').val(item.row13Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader14').val(item.row14Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader3').val(item.row3Col3);
                $('#cirDynamicAccordSection3 #controlHeader4').val(item.row4Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader5').val(item.row5Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader6').val(item.row6Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader7').val(item.row7Col3);
                $('#cirDynamicAccordSection3 #chkrowHeader8').val(item.row8Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader9').val(item.row9Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader10').val(item.row10Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader11').val(item.row11Col3);
                $('#cirDynamicAccordSection3 #txtrowHeader12').val(item.row12Col3);
                $('#cirDynamicAccordSection3 #controlHeader4').change();
                //$('#cirDynamicAccordSection3 #controlDecision').val(item.row12Col3);

                // $('#chkDamageIdentifiedSimplified').val(item.row1Col1);
                $('#cirDynamicAccordSection4 #controlHeader1').val(item.row1Col4);
                $('#cirDynamicAccordSection4 #controlHeader2').val(item.row2Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader13').val(item.row13Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader14').val(item.row14Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader3').val(item.row3Col4);
                $('#cirDynamicAccordSection4 #controlHeader4').val(item.row4Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader5').val(item.row5Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader6').val(item.row6Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader7').val(item.row7Col4);
                $('#cirDynamicAccordSection4 #chkrowHeader8').val(item.row8Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader9').val(item.row9Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader10').val(item.row10Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader11').val(item.row11Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader12').val(item.row12Col4);
                $('#cirDynamicAccordSection4 #txtrowHeader12').val(item.row12Col4);
                $('#cirDynamicAccordSection4 #controlHeader4').change();
                //$('#cirDynamicAccordSection4 #controlDecision').val(item.row12Col4);

                // $('#chkDamageIdentifiedSimplified').val(item.row1Col1);
                $('#cirDynamicAccordSection5 #controlHeader1').val(item.row1Col5);
                $('#cirDynamicAccordSection5 #controlHeader2').val(item.row2Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader13').val(item.row13Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader14').val(item.row14Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader3').val(item.row3Col5);
                $('#cirDynamicAccordSection5 #controlHeader4').val(item.row4Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader5').val(item.row5Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader6').val(item.row6Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader7').val(item.row7Col5);
                $('#cirDynamicAccordSection5 #chkrowHeader8').val(item.row8Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader9').val(item.row9Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader10').val(item.row10Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader11').val(item.row11Col5);
                $('#cirDynamicAccordSection5 #txtrowHeader12').val(item.row12Col5);
                $('#cirDynamicAccordSection5 #controlHeader4').change();
                // $('#cirDynamicAccordSection5 #controlDecision').val(item.row12Col5);

                // $('#chkDamageIdentifiedSimplified').val(item.row1Col1);
                $('#cirDynamicAccordSection6 #controlHeader1').val(item.row1Col6);
                $('#cirDynamicAccordSection6 #controlHeader2').val(item.row2Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader13').val(item.row13Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader14').val(item.row14Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader3').val(item.row3Col6);
                $('#cirDynamicAccordSection6 #controlHeader4').val(item.row4Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader5').val(item.row5Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader6').val(item.row6Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader7').val(item.row7Col6);
                $('#cirDynamicAccordSection6 #chkrowHeader8').val(item.row8Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader9').val(item.row9Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader10').val(item.row10Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader11').val(item.row11Col6);
                $('#cirDynamicAccordSection6 #txtrowHeader12').val(item.row12Col6);
                $('#cirDynamicAccordSection6 #controlHeader4').change();
                //$('#cirDynamicAccordSection6 #controlDecision').val(item.row12Col6);

            }
            catch (e) {
                console.log('Error occured while loading CIR data Dynamic Table' + e);
            }
            i++;
            if (i === fileListLength) {
                clearInterval(flngobj);

            }
        }, 1000);



    }
    function renderCirDataDynamicDecisionSections(cirDynamicDecisionData) {

        var i = 0;
        var fileListLength = cirDynamicDecisionData.length;
        var decsionobj = setInterval(function () {
            var item = cirDynamicDecisionData[i];
            try {
                if (item.flangNo == 1) {
                    $('#cirDynamicAccordSection1 #controlDecision').val(item.decision).change();
                    $('#cirDynamicAccordSection1 #controlRepeatedInspection').val(item.repeatedInspections).change();
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection1 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection1 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection1 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection1 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection1 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection1 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection1 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection1 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection1 #txtImgInspectionDescription1').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }

                if (item.flangNo == 2) {
                    $('#cirDynamicAccordSection2 #controlDecision').val(item.decision);
                    $('#cirDynamicAccordSection2 #controlRepeatedInspection').val(item.repeatedInspections);
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection2 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection2 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection2 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection2 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection2 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection2 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection2 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection2 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection2 #txtImgInspectionDescription2').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }
                if (item.flangNo == 3) {
                    $('#cirDynamicAccordSection3 #controlDecision').val(item.decision);
                    $('#cirDynamicAccordSection3 #controlRepeatedInspection').val(item.repeatedInspections);
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection3 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection3 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection3 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection3 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection3 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection3 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection3 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection3 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection3 #txtImgInspectionDescription3').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }
                if (item.flangNo == 4) {
                    $('#cirDynamicAccordSection4 #controlDecision').val(item.decision);
                    $('#cirDynamicAccordSection4 #controlRepeatedInspection').val(item.repeatedInspections);
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection4 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection4 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection4 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection4 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection4 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection4 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection4 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection4 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection4 #txtImgInspectionDescription4').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }
                if (item.flangNo == 5) {
                    $('#cirDynamicAccordSection5 #controlDecision').val(item.decision);
                    $('#cirDynamicAccordSection5 #controlRepeatedInspection').val(item.repeatedInspections);
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection5 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection5 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection5 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection5 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection5 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection5 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection5 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection5 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection5 #txtImgInspectionDescription5').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }
                if (item.flangNo == 6) {
                    $('#cirDynamicAccordSection6 #controlDecision').val(item.decision);
                    $('#cirDynamicAccordSection6 #controlRepeatedInspection').val(item.repeatedInspections);
                    if (item.flangeDamageIdentified == true) {
                        $('#cirDynamicAccordSection6 #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#cirDynamicAccordSection6 #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#cirDynamicAccordSection6 #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#cirDynamicAccordSection6 #showHideFlangeSections').show();
                    }
                    else {
                        $('#cirDynamicAccordSection6 #showHideFlangeSections').hide();
                    }
                    if (item.affectedBolts == 1) {
                        $('#cirDynamicAccordSection6 #chkReplaceAffectedBolts').attr('checked', true);
                        $('#cirDynamicAccordSection6 #chkReplaceAffectedBolts').parent().addClass('checked');
                        $('#cirDynamicAccordSection6 #chkReplaceAffectedBolts').parent().attr('aria-checked', 'true');
                    }
                    $('#cirDynamicAccordSection6 #txtImgInspectionDescription6').val((item.inspectionDesc) ? item.inspectionDesc : "");
                }
            }
            catch (e) {
                console.log('Error occured while loading CIR data Dynamic Table' + e);
            }
            i++;
            if (i === fileListLength) {
                clearInterval(decsionobj);

            }
        }, 1000);

        // waitingDialog.hide();
        //}, 3000);
    }

    function getArray(item) {
        var _item = [];
        _item.push(item);
        return _item;
    }
    function renderCirDataCommon(cirDataCommon) {
        cirDataCommon.forEach(function (item) {
            if (item) {
                try {
                    $('#cirDataID').val(item.cirDataID);
                    $('#ddlCirType').val(item.componentInspectionReportTypeId);
                    $("#ddlCirType").change();
                    $('#ddlReportType').val(item.reportTypeId);
                    $('#lblfailuredate span').remove();
                    if ($('#ddlReportType').val() == '2') {
                        $('#lblfailuredate span').remove();
                        $('#lblfailuredate').append('<span class="errorSpan">*</span>');
                    }
                    else {
                        $('#lblfailuredate span').remove();
                    }
                    $("#Error1").val(item.htmlStr);

                    $('#txtCimNo').val(item.cimCaseNumber);
                    $('#cirLocalID').val(item.componentInspectionReportId);
                    $('#cirlbl').html('Update CIR (' + item.componentInspectionReportId + ')');
                    $('#CirName').val(item.componentInspectionReportName);
                    $('#hdntemplateVersion').val(item.templateVersion);
                    $('#cirRemoteID').val(item.componentInspectionReportId);
                    $('#_hCIRID').val(item.componentInspectionReportId);

                    PopulateDynamicTable(item.cimCaseNumber);
                    $('#txtReasonForService').val(item.reasonForService);
                    $('#txtTurbineNumber').val(item.turbineNumber);
                    $('#txtTurbineCountry').val(item.country);
                    $('#txtTurbineSite').val(item.siteName);
                    $('#txtTurbineType').val(item.turbineType);
                    if (!__isRivision) {
                        $('#txtRotorDiameter').val(item.turbineData.rotorDiameter);
                        $('#txtNominelPower').val(item.turbineData.nominelPower);
                        $('#txtVoltage').val(item.turbineData.voltage);
                        $('#txtPowerRegulation').val(item.turbineData.powerRegulation);
                        $('#txtFrequency').val(item.turbineData.frequency);
                        $('#txtSmallGenerator').val(item.turbineData.smallGenerator);
                        $('#txtTemperatureVariant').val(item.turbineData.temperatureVariant);
                        $('#txtMKVersion').val(item.turbineData.markVersion);
                        $('#txtOnshoreOffshore').val(item.turbineData.placement);
                        $('#txtLocalTurbineID').val(item.turbineData.localTurbineId);
                        $('#txtTurbineManufacturer').val(item.turbineData.manufacturer);
                    }
                    $('#ddlRunStatus').val(item.beforeInspectionTurbineRunStatusId);
                    if (item.strCommisioningDate != null) {
                        $('#txtCommisioningDate').val(item.strCommisioningDate);
                        $('#txtInstallationDate').val(item.strInstallationDate);
                        $('#txtFailureDate').val(item.strFailureDate);
                        if ($('#txtFailureDate').val() == '01-01-2001') {
                            $('#txtFailureDate').val('');
                        }
                        $('#txtInspectionDate').val(item.strInspectionDate);
                    }
                    else {

                        $('#txtCommisioningDate').val(GetDateStringFromDateObject(new Date(item.commisioningDate)));
                        $('#txtInstallationDate').val(GetDateStringFromDateObject(new Date(item.installationDate)));
                        $('#txtFailureDate').val(GetDateStringFromDateObject(new Date(item.failureDate)));
                        if ($('#txtFailureDate').val() == '01-01-2001') {
                            $('#txtFailureDate').val('');
                        }
                        $('#txtInspectionDate').val(GetDateStringFromDateObject(new Date(item.inspectionDate)));
                    }
                    $('#txtServicePortNo').val(item.serviceReportNumber);
                    $('#txtServiceEngineer').val(item.serviceEngineer);
                    $('#txtNotificationNumber').val(item.notificationNumber);
                    $('#ddlServiceReportNumberType').val(item.serviceReportNumberTypeId);
                    $('#txtRunHr').val(item.runHours);
                    $('#txtGenerator1Hr').val(item.generator1Hrs);
                    $('#txtGenerator2Hr').val(item.generator2Hrs);
                    $('#txtTotalProduction').val(item.totalProduction);
                    $('#ddlRunStatusAfterInspection').val(item.afterInspectionTurbineRunStatusId);
                    $('#txtVestasItemNo').val(item.vestasItemNumber);
                    $('#txtQuantityOfFailedComponent').val(item.quantity);
                    $('#txtDescription').val(item.description);
                    $('#ddlUpTowerSolution').val(item.componentUpTowerSolutionID);
                    $('#txtDescriptionConProb').val(item.descriptionConsquential);
                    $('#txtAdditionalInfo').val(item.additionalComments);
                    $('#txtSBURecommendation').val(item.sbuRecomendation);

                    $('#txtAlarmLogNumber').val(item.alarmLogNumber);
                    $('#txtInternalComments').val(item.internalComments);
                    $('#ddlAuxEquipment').val(item.mountedOnMainComponentBooleanAnswerId);
                    $('#ddlTransformerAuxEquipment').val(item.mountedOnMainComponentBooleanAnswerId);
                    $('#ddlGeneratorAuxEquipment').val(item.mountedOnMainComponentBooleanAnswerId);
                }
                catch (e) {
                    console.log('Error occured in Loading CIR data common ' + e);
                }
            }
        });
        if ($('#txtInstallationDate').val() != "") {
            $('#ddlInstallationDateType').val(2);
        }
        else {
            $('#ddlInstallationDateType').val(1);
            $('.manInstallationDate').hide();
        }
    }

    function renderDynamicInputImages(cirImages) {
        var dvPreview1 = $("#dvPreview1");
        var dvPreview2 = $("#dvPreview2");
        var dvPreview3 = $("#dvPreview3");
        var dvPreview4 = $("#dvPreview4");
        var dvPreview5 = $("#dvPreview5");
        var dvPreview6 = $("#dvPreview6");
        dvPreview1.html("");
        dvPreview2.html("");
        dvPreview3.html("");
        dvPreview4.html("");
        dvPreview5.html("");
        dvPreview6.html("");
        //$('#bladeDamageArea').empty();
        try {
            //  var imagedata = item;
            LoadDynamicImagesFromJsonObject(cirImages)


        }
        catch (e) {
            console.log('Error occured during load of CIR data blade damage' + e);
        }

    }

    function renderCirDataBlade(cirDataBlade) {
        if (cirDataBlade && cirDataBlade.length > 0) {
            $('#bladeDataExists').val('Yes');
            cirDataBlade.forEach(function (item) {
                try {

                    $('#ddlBladeManufacturer').val(item.bladeManufacturerId);
                    $('#ddlBladeLengthM').val(item.bladeLengthId);
                    $('#ddlBladeColor').val(item.bladeColorId);
                    $('#txtBladeSerialNo').val(item.bladeSerialNumber);
                    // $('#ddlAuxEquipment').val(item.auxEquipment);
                    $('#ddlBladePicIncluded').val(item.bladePicturesIncludedBooleanAnswerId);
                    if (item.bladeOtherSerialNumber1 == '' || item.bladeOtherSerialNumber2 == '' ||
                        item.bladeOtherSerialNumber1 == null || item.bladeOtherSerialNumber2 == null) {
                    }
                    else {
                        $('#otherBladeSet').show();
                        $('#linkInserOtherBladeSet').text('Remove other blade in set..');

                        $('#txtBladeSerialNoOtherBlade').val(item.bladeOtherSerialNumber1);
                        $('#txtBladeSerialNoOtherBlade2').val(item.bladeOtherSerialNumber2);
                    }
                    $('#ddlOverallBladeCondition').val(item.bladeFaultCodeClassificationId);
                    $('#ddlFaultCause').val(item.bladeFaultCodeCauseId);
                    $('#ddlFaultType').val(item.bladeFaultCodeTypeId);
                    $('#ddlFaultArea').val(item.bladeFaultCodeAreaId);

                    $('#txtVTnumber').val(item.bladeLsVtNumber);
                    if (jQuery.type(item.bladeLsCalibrationDate) == "date") {
                        $('#txtCalibrationDate').val(GetDateStringFromDateObject(new Date(item.bladeLsCalibrationDate)));
                    }
                    else {
                        $('#txtCalibrationDate').val(item.bladeLsCalibrationDate);
                    }
                    $('#txtLeewardPreTypeValue1').val(item.bladeLsLeewardSidePreRepairTip);
                    $('#txtLeewardPostTypeValue1').val(item.bladeLsLeewardSidePostRepairTip);
                    $('#txtLeewardPreTypeValue2').val(item.bladeLsLeewardSidePreRepair2);
                    $('#txtLeewardPostTypeValue2').val(item.bladeLsLeewardSidePostRepair2);
                    $('#txtLeewardPreTypeValue3').val(item.bladeLsLeewardSidePreRepair3);
                    $('#txtLeewardPostTypeValue3').val(item.bladeLsLeewardSidePostRepair3);
                    $('#txtLeewardPreTypeValue4').val(item.bladeLsLeewardSidePreRepair4);
                    $('#txtLeewardPostTypeValue4').val(item.bladeLsLeewardSidePostRepair4);
                    $('#txtLeewardPreTypeValue5').val(item.bladeLsLeewardSidePreRepair5);
                    $('#txtLeewardPostTypeValue5').val(item.bladeLsLeewardSidePostRepair5);
                    $('#txtWindwardPreTypeValue1').val(item.bladeLsWindwardSidePreRepairTip);
                    $('#txtWindwardPostTypeValue1').val(item.bladeLsWindwardSidePostRepairTip);
                    $('#txtWindwardPreTypeValue2').val(item.bladeLsWindwardSidePreRepair2);
                    $('#txtWindwardPostTypeValue2').val(item.bladeLsWindwardSidePostRepair2);
                    $('#txtWindwardPreTypeValue3').val(item.bladeLsWindwardSidePreRepair3);
                    $('#txtWindwardPostTypeValue3').val(item.bladeLsWindwardSidePostRepair3);
                    $('#txtWindwardPreTypeValue4').val(item.bladeLsWindwardSidePreRepair4);
                    $('#txtWindwardPostTypeValue4').val(item.bladeLsWindwardSidePostRepair4);
                    $('#txtWindwardPreTypeValue5').val(item.bladeLsWindwardSidePreRepair5);
                    $('#txtWindwardPostTypeValue5').val(item.bladeLsWindwardSidePostRepair5)
                    //new code added for 12 new fields
                    if (typeof item.bladeLsLeewardSidePreRepair6 != "undefined")
                        $('#txtLeewardPreTypeValue6').val(item.bladeLsLeewardSidePreRepair6);
                    if (typeof item.bladeLsLeewardSidePostRepair6 != "undefined")
                        $('#txtLeewardPostTypeValue6').val(item.bladeLsLeewardSidePostRepair6);
                    if (typeof item.bladeLsLeewardSidePreRepair7 != "undefined")
                        $('#txtLeewardPreTypeValue7').val(item.bladeLsLeewardSidePreRepair7);
                    if (typeof item.bladeLsLeewardSidePostRepair7 != "undefined")
                        $('#txtLeewardPostTypeValue7').val(item.bladeLsLeewardSidePostRepair7);
                    if (typeof item.bladeLsLeewardSidePreRepair8 != "undefined")
                        $('#txtLeewardPreTypeValue8').val(item.bladeLsLeewardSidePreRepair8);
                    if (typeof item.bladeLsLeewardSidePostRepair8 != "undefined")
                        $('#txtLeewardPostTypeValue8').val(item.bladeLsLeewardSidePostRepair8);
                    if (typeof item.bladeLsWindwardSidePreRepair6 != "undefined")
                        $('#txtWindwardPreTypeValue6').val(item.bladeLsWindwardSidePreRepair6);
                    if (typeof item.bladeLsWindwardSidePostRepair6 != "undefined")
                        $('#txtWindwardPostTypeValue6').val(item.bladeLsWindwardSidePostRepair6);
                    if (typeof item.bladeLsWindwardSidePreRepair7 != "undefined")
                        $('#txtWindwardPreTypeValue7').val(item.bladeLsWindwardSidePreRepair7);
                    if (typeof item.bladeLsWindwardSidePostRepair7 != "undefined")
                        $('#txtWindwardPostTypeValue7').val(item.bladeLsWindwardSidePostRepair7);
                    if (typeof item.bladeLsWindwardSidePreRepair8 != "undefined")
                        $('#txtWindwardPreTypeValue8').val(item.bladeLsWindwardSidePreRepair8);
                    if (typeof item.bladeLsWindwardSidePostRepair8 != "undefined")
                        $('#txtWindwardPostTypeValue8').val(item.bladeLsWindwardSidePostRepair8)
                }
                catch (e) {
                    console.log('Error occured in Loading CIR data blade ' + e);
                }
            });
        }
        else {
            $('#bladeDataExists').val('No');
        }
    }
    function renderCirDataBladeDamage(cirDataBladeDamage) {
        var damageHtml = $('#bladeDamageSection').html();
        $('#bladeDamageSection').hide();
        //$('#bladeDamageArea').empty();
        cirDataBladeDamage.forEach(function (item) {
            try {

                var divID = Date.now();
                $('#bladeDamageArea').append($('<div id="' + divID + '" class="bladeDamageSection"></div>').append(damageHtml));

                var BladeDamage = $('#' + divID);

                var dropDamagePlacement = $('#' + divID).find('#ddlDamagePlacement');
                var dropDamageType = $('#' + divID).find('#ddlDamageType');
                var dropBladeEdge = $('#' + divID).find('#ddlBladeEdge');
                var txBladeRadius = $('#' + divID).find('#txtBladeRadius');
                var txBladeDamageDescription = $('#' + divID).find('#txtBladeDamageDescription');
                var txPictureNo = $('#' + divID).find('#txtPictureNo');

                dropDamagePlacement.val(item.bladeDamagePlacementId);
                dropDamageType.val(item.bladeInspectionDataId);
                dropBladeEdge.val(item.bladeEdgeId);
                txBladeRadius.val(item.bladeRadius);
                txBladeDamageDescription.val(item.bladeDescription);
                txPictureNo.val(item.bladePictureNumber);
            }
            catch (e) {
                console.log('Error occured in loading CIR data blade damage' + e);
            }
        });
    }
    function renderCirDataBladeRepairRecord(cirDataBladeRepairRecord) {
        if (cirDataBladeRepairRecord) {

            $('#txtAmbientTemp').val(cirDataBladeRepairRecord.bladeAmbientTemp);
            $('#txtHumidity').val(cirDataBladeRepairRecord.bladeHumidity);
            $('#txtAddldocumentref').val(cirDataBladeRepairRecord.bladeAdditionalDocumentReference);
            $('#txtResinType').val(cirDataBladeRepairRecord.bladeResinType);
            $('#txtResinTypeBatchNumber').val(cirDataBladeRepairRecord.bladeResinTypeBatchNumbers);
            if (cirDataBladeRepairRecord.strbladeResinTypeExpiryDate != null) {
                $('#txtResinTypeexpirydate').val(cirDataBladeRepairRecord.bladeResinTypeExpiryDate);
            }
            else {
                $('#txtResinTypeexpirydate').val(GetDateStringFromDateObject(new Date(cirDataBladeRepairRecord.bladeResinTypeExpiryDate)));

            }

            $('#txtHardenertype').val(cirDataBladeRepairRecord.bladeHardenerType);
            $('#txtHardenertypebatchnumber').val(cirDataBladeRepairRecord.bladeHardenerTypeBatchNumbers);

            if (cirDataBladeRepairRecord.strbladeHardenerTypeExpiryDate != null) {
                $('#txthardnertypeexpirydate').val(cirDataBladeRepairRecord.strbladeHardenerTypeExpiryDate);
            }
            else {
                $('#txthardnertypeexpirydate').val(GetDateStringFromDateObject(new Date(cirDataBladeRepairRecord.bladeHardenerTypeExpiryDate)));

            }
            $('#txtglasssupplier').val(cirDataBladeRepairRecord.bladeGlassSupplier);
            $('#txtglasssupplierbatchnumber').val(cirDataBladeRepairRecord.bladeGlassSupplierBatchNumbers);
            $('#txtmaxbladesurfacetemp').val(cirDataBladeRepairRecord.bladeSurfaceMaxTemperature);
            $('#txtminbladesurfacetemp').val(cirDataBladeRepairRecord.bladeSurfaceMinTemperature);
            $('#txtquantityofmixedresinused').val(cirDataBladeRepairRecord.bladeResinUsed);
            $('#txtmaxpostcuresurfacetemp').val(cirDataBladeRepairRecord.bladePostCureMaxTemperature);
            $('#txtminpostcuresurfacetemp').val(cirDataBladeRepairRecord.bladePostCureMinTemperature);

            if (cirDataBladeRepairRecord.strbladeTurnOffTime != null) {
                $('#txtheaterinsulationandvacuumoff').val(cirDataBladeRepairRecord.strbladeTurnOffTime);
            }
            else {
                $('#txtheaterinsulationandvacuumoff').val(GetDateTimeStringFromDateObject(new Date(cirDataBladeRepairRecord.bladeTurnOffTime)));

            }
            $('#txttotalcuretime').val(cirDataBladeRepairRecord.bladeTotalCureTime);


        }


    }
    function renderCirDataGeneral(cirDataGeneral) {
        var damageHtml = $('#bladeDamageSection').html();
        $('#bladeDamageSection').hide();

        cirDataGeneral.forEach(function (item) {
            try {

                $("#ddlComponentGroup").val(item.generalComponentGroupId);
                $("#txtComponentType").val(item.generalComponentType);
                $("#txtPositionOfFailedItem").val(item.generalPositionOfFailedItem);
                $("#txtComponentManufacturer").val(item.generalComponentManufacturer);
                $("#txtOtherGearboxType").val(item.generalOtherGearboxType);
                $("#txtOtherGearboxManufacturer").val(item.generalOtherGearboxManufacturer);
                if (item.generalComponentSerialNumber == null || item.generalComponentSerialNumber.trim() == "") {

                    $('#chkComponentSerialNumber').attr('checked', true);
                    $('#chkComponentSerialNumber').parent().addClass('checked');
                    $('#chkComponentSerialNumber').parent().attr('aria-checked', 'true');

                }
                $("#txtComponentSerialNumber").val(item.generalComponentSerialNumber);
                $("#ddlGeneratorManufacturer").val(item.generalGeneratorManufacturerId);
                $("#ddlTransformerManufacturer").val(item.generalTransformerManufacturerId);
                $("#ddlGearboxManufacturer").val(item.generalGearboxManufacturerId);
                $("#ddlTowerType").val(item.generalTowerTypeId);
                $("#ddlTowerHeight").val(item.generalTowerHeightId);
                $("#txtBladeASerialNumber").val(item.generalBlade1SerialNumber);
                $("#txtBladeBSerialNumber").val(item.generalBlade2SerialNumber);
                $("#txtBladeCSerialNumber").val(item.generalBlade3SerialNumber);
                $("#ddlControllerType").val(item.generalControllerTypeId);
                $("#txtSoftwareRelease").val(item.generalSoftwareRelease);
                $("#txtRamDumpNumber").val(item.generalRamDumpNumber);
                $("#txtVDFTrackNumber").val(item.generalVDFTrackNumber);
                $("#ddlPicturesAttached").val(item.generalPicturesIncludedBooleanAnswerId);
                $("#txtInitiatedBy1").val(item.generalInitiatedBy1);
                $("#txtInitiatedBy2").val(item.generalInitiatedBy2);
                $("#txtInitiatedBy3").val(item.generalInitiatedBy3);
                $("#txtMeasurements1").val(item.generalMeasurementsConducted1);
                $("#txtMeasurements2").val(item.generalMeasurementsConducted2);
                $("#txtMeasurements3").val(item.generalMeasurementsConducted3);
                $("#txtExecutedBy1").val(item.generalExecutedBy1);
                $("#txtExecutedBy2").val(item.generalExecutedBy2);
                $("#txtExecutedBy3").val(item.generalExecutedBy3);

            }
            catch (e) {
                console.log('Error occured in loading CIR data blade damage' + e);
            }
        });
    }
    function renderCirImages(cirImages) {
        var dvPreview = $("#dvPreview");
        dvPreview.html("");
        //$('#bladeDamageArea').empty();
        try {
            //  var imagedata = item;
            LoadFromJsonObject(cirImages)


        }
        catch (e) {
            console.log('Error occured during load of CIR data blade damage' + e);
        }

    }
    function renderCirSkiipackdata(cirSkiipack) {
        cirSkiipack.forEach(function (item) {
            try {



                $('#txtOtherDamagedComponentsReplaced').val(item.skiiPOtherDamagedComponentsReplaced);
                $('#txtQuantityOfFailedModulesSkiip').val(item.skiiPQuantityOfFailedModules);
                $('#ddlNumberOfComponentsSkiip').val(item.skiiPNumberofComponents);
                $('#ddlCauseSkiip').val(item.skiiPCauseId);

                /* $('#ddlWTGPlatform').val(item.wTGType);
                 switch (item.wTGType) {
                     case "0":
                         $('#WTGdiv1').hide();
                         $('#WTGdiv2').hide();
                         $('#WTGdiv3').hide();
                         break;
                     case "1":
                         $('#WTGdiv1').show();
                         break;
                     case "2":
                         $('#WTGdiv2').show();
                         break;
                     case "3":
                         $('#WTGdiv3').show();
                         break;
                 }
                 */
                $('#ddl2MWV521').val(item.skiiP2MWV521BooleanAnswerId);
                $('#ddl2MWV524').val(item.skiiP2MWV524BooleanAnswerId);
                $('#ddl2MWV522').val(item.skiiP2MWV522BooleanAnswerId);
                $('#ddl2MWV525').val(item.skiiP2MWV525BooleanAnswerId);
                $('#ddl2MWV523').val(item.skiiP2MWV523BooleanAnswerId);
                $('#ddl2MWV526').val(item.skiiP2MWV526BooleanAnswerId);

                $('#ddl3MWV524y').val(item.skiiP3MWV524yBooleanAnswerId);
                $('#ddl3MWV524x').val(item.skiiP3MWV524xBooleanAnswerId);
                $('#ddl3MWV521').val(item.skiiP3MWV521BooleanAnswerId);
                $('#ddl3MWV525y').val(item.skiiP3MWV525yBooleanAnswerId);
                $('#ddl3MWV525x').val(item.skiiP3MWV525xBooleanAnswerId);
                $('#ddl3MWV522').val(item.skiiP3MWV522BooleanAnswerId);

                $('#ddl3MWV526y').val(item.skiiP3MWV526yBooleanAnswerId);
                $('#ddl3MWV526x').val(item.skiiP3MWV526xBooleanAnswerId);
                $('#ddl3MWV523').val(item.skiiP3MWV523BooleanAnswerId);

                $('#ddl850kWV525').val(item.skiiP850KWV525BooleanAnswerId);
                $('#ddl850kWV526').val(item.skiiP850KWV526BooleanAnswerId);
                $('#ddl850kWV524').val(item.skiiP850KWV524BooleanAnswerId);
                $('#ddl850kWV520').val(item.skiiP850KWV520BooleanAnswerId);

            }
            catch (e) {
                console.log('Error occured during load of CIR data skiipack' + e);
            }
        });
    }
    function renderCirSkiipackFailedComponent(cirSkiipackFailedComponent) {
        var divCount = 0;
        cirSkiipackFailedComponent.forEach(function (item) {
            try {

                divCount++;
                $('#divComponentIdentification' + divCount).show();
                $('#divComponentIdentification' + divCount).attr('data-dbid', ((item.componentInspectionReportSkiiPFailedComponentId) ? item.componentInspectionReportSkiiPFailedComponentId : 0));
                $('#txtSerialNumber' + divCount).val(item.skiiPFailedComponentSerialNumber);
                $('#txtVestasUniqueIdentifierSkiip' + divCount).val(item.skiiPFailedComponentVestasUniqueIdentifier);
                $('#txtItemNoSkiip' + divCount).val(item.skiiPFailedComponentVestasItemNumber);

            }
            catch (e) {
                console.log('Error occured during load of CIR data skiipack failed component' + e);
            }
        });
        var itemCount = $('#ddlNumberOfComponentsSkiip').val();
        for (var i = 1; i <= 9; i++) {
            if (i > itemCount) {
                $('#divComponentIdentification' + i.toString()).hide();
                $('#divComponentIdentification' + i.toString() + ' .form-control').val('');
            }
            else {
                $('#divComponentIdentification' + i.toString()).fadeIn(200);
            }
        }
    }
    function renderCirSkiipackNewComponent(cirSkiipackNewComponent) {
        var divCount = 0;
        cirSkiipackNewComponent.forEach(function (item) {
            try {
                divCount++;
                $('#divComponentIdentificationNew' + divCount).show();
                $('#divComponentIdentificationNew' + divCount).attr('data-dbid', ((item.componentInspectionReportSkiiPNewComponentId) ? item.componentInspectionReportSkiiPNewComponentId : 0));
                $('#txtSerialNumberNew' + divCount).val(item.skiiPNewComponentSerialNumber);
                $('#txtVestasUniqueIdentifierSkiipNew' + divCount).val(item.skiiPNewComponentVestasUniqueIdentifier);
                $('#txtItemNoSkiipNew' + divCount).val(item.skiiPNewComponentVestasItemNumber);
            }
            catch (e) {
                console.log('Error occured during load of CIR data skiipack new component' + e);
            }
            var itemCount = $('#ddlNumberOfComponentsSkiip').val();
            for (var i = 1; i <= 9; i++) {
                if (i > itemCount) {
                    $('#divComponentIdentificationNew' + i.toString()).hide();
                    $('#divComponentIdentificationNew' + i.toString() + ' .form-control').val('');
                }
                else {
                    $('#divComponentIdentificationNew' + i.toString()).fadeIn(200);
                }
            }
        });

    }
    function renderCirDataTransformer(cirTransformer) {
        cirTransformer.forEach(function (item) {
            try {

                $('#ddlTransformerManufacturer2').val(item.transformerManufacturerId);
                $('#txtTransformerSerialNumber').val(item.transformerSerialNumber);
                $('#ddlTransformerAuxEquipment').val(item.transformerClaimRelevantBooleanAnswerId);
                $('#txtTransformerMaxTemp').val(item.maxTemp);
                if (item.strMaxTempResetDate != null) {
                    $('#txtTransformerMaxTempDate').val(item.strMaxTempResetDate);
                }
                else {

                    $('#txtTransformerMaxTempDate').val(GetDateStringFromDateObject(new Date(item.maxTempResetDate)));

                }

                $('#ddlActionToTransformer').val(item.actionOnTransformerId);
                $('#ddlTransformerHVCoil').val((item.hVCoilConditionId == undefined) ? item.hvCoilConditionId : item.hVCoilConditionId);
                $('#ddlTransformerLVCoil').val((item.lVCoilConditionId == undefined) ? item.lvCoilConditionId : item.lVCoilConditionId);
                $('#ddlTransformerHVCable').val((item.hVCableConditionId == undefined) ? item.hvCableConditionId : item.hVCableConditionId);
                $('#ddlTransformerLVCable').val((item.lVCableConditionId == undefined) ? item.lvCableConditionId : item.lVCableConditionId);
                $('#ddlTransformerBrackets').val(item.bracketsId);
                $('#ddlTransformerArcDetection').val(item.transformerArcDetectionId);
                $('#ddlTransformerClimateCondition').val(item.climateId);
                $('#ddlTransformerSurgeArrestor').val(item.surgeArrestorId);
                $('#ddlTransformerConnectionBars').val(item.connectionBarsId);
                $('#txtTransformerComments').val(item.comments);
            }
            catch (e) {
                console.log('Error occured while loading CIR data transformer' + e);
            }
        });
    }
    function renderCirDataMainBearing(cirMainBearing) {
        cirMainBearing.forEach(function (item) {
            try {
                $('#ddlMainBearingManufacturer').val(item.mainBearingManufacturerId);
                $('#ddlMainBearingType').val(item.mainBearingTypeId);
                $('#ddlMainBearingRevision').val(item.mainBearingRevision);
                $('#ddlMainBearingFrontRear').val(item.mainBearingErrorLocationId);
                $('#txtMainBearingSerialNumber').val(item.mainBearingSerialNumber);
                $('#ddlMainBearingLubricationType').val(item.mainBearingLubricationOilTypeId);
                $('#txtMainBearingMechanicalOilPump').val(item.mainBearingMechanicalOilPump);
                $('#txtMainBearingOilTemperature').val(item.mainBearingOilTemperature);
                if (item.mainBearingGrease) {
                    $('#chkMainBearingGrease').parent().addClass('checked');
                    $('#chkMainBearingGrease').attr('checked', true);
                }
                $('#txtMainBearingHoursBearing').val(item.mainBearingRunHours);
                $('#txtMainBearingBearingTemperature').val(item.mainBearingTemperature);
                // $('#txtMainBearingLubricationchangeDate').val(item.mainBearingLastLubricationDate);
                if (item.mainBearingLastLubricationDate != "") {
                    if (jQuery.type(item.mainBearingLastLubricationDate) == "date") {
                        $('#txtMainBearingLubricationchangeDate').val(GetDateStringFromDateObject(new Date(item.mainBearingLastLubricationDate)));
                    }
                    else {
                        if (item.mainBearingLastLubricationDate.length > 10)
                            $('#txtMainBearingLubricationchangeDate').val(GetDateStringFromDateObject(new Date(item.mainBearingLastLubricationDate)));
                        else
                            $('#txtMainBearingLubricationchangeDate').val(item.mainBearingLastLubricationDate);
                    }
                }
                else {
                    $('#txtMainBearingLubricationchangeDate').val(item.mainBearingLastLubricationDate);
                }

                $('#txtMainBearingRunLubrication').val(item.mainBearingLubricationRunHours);
            }
            catch (e) {
                console.log('Error occured while loading CIR data main bearing ' + e);
            }
        });
    }
    function renderCirDataGenerator(cirGenerator) {
        cirGenerator.forEach(function (item) {
            try {
                $('#ddlGeneratorManufacturer2').val(item.generatorManufacturerId);
                $('#txtGeneratorSearialNo').val(item.generatorSerialNumber);

                if (item.generatorManufacturerId == 5) {
                    $('#txtOtherManufacturerName').val(item.otherManufacturer);
                    $('#txtOtherManufacturerName').prop('disabled', false);
                }
                // generator.otherManufacturer = $('#txtOtherManufacturerName').val();
                //$('#ddlGeneratorAuxEquipment').val(item.generatorAuxEquipment);
                $('#txtGeneratorMaxTemp').val(item.generatorMaxTemperature);
                if (item.strGeneratorMaxTemperatureResetDate != null) {
                    $('#txtGeneratorMaxTempResetDate').val(item.strGeneratorMaxTemperatureResetDate);
                }
                else {

                    $('#txtGeneratorMaxTempResetDate').val(GetDateStringFromDateObject(new Date(item.generatorMaxTemperatureResetDate)));

                }
                $('#ddlGeneratorCoupling').val(item.couplingId);
                $('#ddlGeneratorActionToBeTaken').val(item.actionToBeTakenOnGeneratorId);
                $('#ddlGeneratorDriveEnd').val(item.generatorDriveEndId);
                $('#ddlGeneratorNonDriveEnd').val(item.generatorNonDriveEndId);
                $('#ddlGeneratorRotor').val(item.generatorRotorId);
                $('#ddlGeneratorCover').val(item.generatorCoverId);
                $('#ddlGeneratorConditionInternal').val(item.airToAirCoolerInternalId);
                $('#ddlGeneratorConditionExternal').val(item.airToAirCoolerExternalId);
                $('#txtGeneratorComments').val(item.generatorComments);
                if (item.insulationComments) {
                    $('#chkInsulationComments').parent().addClass('checked');
                    $('#chkInsulationComments').attr('checked', true);
                }

                $('#txtGeneratorInsulationComments').val(item.generatorInsulationComments);
                $('#txtGeneratorTestResultUGround').val((item.uGround == undefined) ? item.uground : item.uGround);
                $('#ddlGeneratorTestResultUGroundUnit').val((item.uGroundOhmUnitId == undefined) ? item.ugroundOhmUnitId : item.uGroundOhmUnitId);
                $('#txtGeneratorTestResultWGround').val((item.wGround == undefined) ? item.wground : item.wGround);
                $('#ddlGeneratorTestResultWGroundUnit').val((item.vGroundOhmUnitId == undefined) ? item.vgroundOhmUnitId : item.vGroundOhmUnitId);
                $('#txtGeneratorTestResultVGround').val((item.vGround == undefined) ? item.vground : item.vGround);
                $('#ddlGeneratorTestResultVGroundUnit').val((item.wGroundOhmUnitId == undefined) ? item.wgroundOhmUnitId : item.wGroundOhmUnitId);
                $('#txtGeneratorTestResultUV').val((item.uV == undefined) ? item.uv : item.uV);
                $('#ddlGeneratorTestResultUVUnit').val((item.uVOhmUnitId == undefined) ? item.uvOhmUnitId : item.uVOhmUnitId);
                $('#txtGeneratorTestResultUW').val((item.uW == undefined) ? item.uw : item.uW);
                $('#ddlGeneratorTestResultUWUnit').val((item.uWOhmUnitId == undefined) ? item.uwOhmUnitId : item.uWOhmUnitId);
                $('#txtGeneratorTestResultVW').val((item.vW == undefined) ? item.vw : item.vW);
                $('#ddlGeneratorTestResultVWUnit').val((item.vWOhmUnitId == undefined) ? item.vwOhmUnitId : item.vWOhmUnitId);
                $('#txtGeneratorTestResultKGround').val((item.kGround == undefined) ? item.kground : item.kGround);
                $('#ddlGeneratorTestResultKGroundUnit').val((item.kGroundOhmUnitId == undefined) ? item.kgroundOhmUnitId : item.kGroundOhmUnitId);
                $('#txtGeneratorTestResultLGround').val((item.lGround == undefined) ? item.lground : item.lGround);
                $('#ddlGeneratorTestResultLGroundUnit').val((item.lGroundOhmUnitId == undefined) ? item.lgroundOhmUnitId : item.lGroundOhmUnitId);
                $('#txtGeneratorTestResultMGround').val((item.mGround == undefined) ? item.mground : item.mGround);
                $('#ddlGeneratorTestResultMGroundUnit').val((item.mGroundOhmUnitId == undefined) ? item.mgroundOhmUnitId : item.mGroundOhmUnitId);
                $('#txtGeneratorInductanceTestU1U2').val((item.u1U2 == undefined) ? item.u1u2 : item.u1U2);
                $('#txtGeneratorInductanceTestV1V2').val((item.v1V2 == undefined) ? item.v1v2 : item.v1V2);
                $('#txtGeneratorInductanceTestW1W2').val((item.w1W2 == undefined) ? item.w1w2 : item.w1W2);
                $('#txtGeneratorInductanceTestK1L1').val((item.k1L1 == undefined) ? item.k1l1 : item.k1L1);
                $('#txtGeneratorInductanceTestL1M1').val((item.l1M1 == undefined) ? item.l1m1 : item.l1M1);
                $('#txtGeneratorInductanceTestK1M1').val((item.k1M1 == undefined) ? item.k1m1 : item.k1M1);
                $('#txtGeneratorInductanceTestK2L2').val((item.k2L2 == undefined) ? item.k2l2 : item.k2L2);
                $('#txtGeneratorInductanceTestL2M2').val((item.l2M2 == undefined) ? item.l2m2 : item.l2M2);
                $('#txtGeneratorInductanceTestK2M2').val((item.k2M2 == undefined) ? item.k2m2 : item.k2M2);
                if (item.generatorRewoundLocally) {
                    $('#chkGeneratorRewound').parent().addClass('checked');
                    $('#chkGeneratorRewound').attr('checked', true);
                }
                //Bug No- #88689:System allowed CIR to be updated with values not equal to infinity

                if (item.uGround == 0 && item.uGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultUGround').val('');
                }

                if (item.wGround == 0 && item.wGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultWGround').val('');
                }

                if (item.vGround == 0 && item.wGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultVGround').val('');
                }

                if (item.uv == 0 && item.uvOhmUnitId == 6) {
                    $('#txtGeneratorTestResultUV').val('');
                }

                if (item.uw == 0 && item.uwOhmUnitId == 6) {
                    $('#txtGeneratorTestResultUW').val('');

                }

                if (item.vw == 0 && item.vwOhmUnitId == 6) {
                    $('#txtGeneratorTestResultVW').val('');
                }

                if (item.kGround == 0 && item.kGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultKGround').val('');
                }

                if (item.lGround == 0 && item.lGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultLGround').val('');
                }

                if (item.mGround == 0 && item.mGroundOhmUnitId == 6) {
                    $('#txtGeneratorTestResultMGround').val('');
                }




            }
            catch (e) {
                console.log('Error occured while loading CIR data generator' + e);
            }
        });
    }
    function renderCirDataDynamicTable(cirDynamicTable) {
        cirDynamicTable.forEach(function (item) {
            try {
                //    $('#DynamicTableHeader').text(item.tableHeader);
                $('#txtRow1Col1').val(item.row1Col1);
                $('#txtRow1Col2').val(item.row1Col2);
                $('#txtRow1Col3').val(item.row1Col3);
                $('#txtRow1Col4').val(item.row1Col4);
                $('#txtRow2Col1').val(item.row2Col1);
                $('#txtRow2Col2').val(item.row2Col2);
                $('#txtRow2Col3').val(item.row2Col3);
                $('#txtRow2Col4').val(item.row2Col4);
                $('#txtRow3Col1').val(item.row3Col1);
                $('#txtRow3Col2').val(item.row3Col2);
                $('#txtRow3Col3').val(item.row3Col3);
                $('#txtRow3Col4').val(item.row3Col4);
                $('#txtRow4Col1').val(item.row4Col1);
                $('#txtRow4Col2').val(item.row4Col2);
                $('#txtRow4Col3').val(item.row4Col3);
                $('#txtRow4Col4').val(item.row4Col4);
                $('#txtRow5Col1').val(item.row5Col1);
                $('#txtRow5Col2').val(item.row5Col2);
                $('#txtRow5Col3').val(item.row5Col3);
                $('#txtRow5Col4').val(item.row5Col4);
                $('#txtRow6Col1').val(item.row6Col1);
                $('#txtRow6Col2').val(item.row6Col2);
                $('#txtRow6Col3').val(item.row6Col3);
                $('#txtRow6Col4').val(item.row6Col4);
                $('#txtRow7Col1').val(item.row7Col1);
                $('#txtRow7Col2').val(item.row7Col2);
                $('#txtRow7Col3').val(item.row7Col3);
                $('#txtRow7Col4').val(item.row7Col4);
                $('#txtRow8Col1').val(item.row8Col1);
                $('#txtRow8Col2').val(item.row8Col2);
                $('#txtRow8Col3').val(item.row8Col3);
                $('#txtRow8Col4').val(item.row8Col4);
                $('#txtRow9Col1').val(item.row9Col1);
                $('#txtRow9Col2').val(item.row9Col2);
                $('#txtRow9Col3').val(item.row9Col3);
                $('#txtRow9Col4').val(item.row9Col4);
                $('#txtRow10Col1').val(item.row10Col1);
                $('#txtRow10Col2').val(item.row10Col2);
                $('#txtRow10Col3').val(item.row10Col3);
                $('#txtRow10Col4').val(item.row10Col4);

                $('#txtRow1Col5').val(item.row1Col5);
                $('#txtRow1Col6').val(item.row1Col6);
                $('#txtRow2Col5').val(item.row2Col5);
                $('#txtRow2Col6').val(item.row2Col6);
                $('#txtRow3Col5').val(item.row3Col5);
                $('#txtRow3Col6').val(item.row3Col6);
                $('#txtRow4Col5').val(item.row4Col5);
                $('#txtRow4Col6').val(item.row4Col6);
                $('#txtRow5Col5').val(item.row5Col5);
                $('#txtRow5Col6').val(item.row5Col6);
                $('#txtRow6Col5').val(item.row6Col5);
                $('#txtRow6Col6').val(item.row6Col6);
                $('#txtRow7Col5').val(item.row7Col5);
                $('#txtRow7Col6').val(item.row7Col6);
                $('#txtRow8Col5').val(item.row8Col5);
                $('#txtRow8Col6').val(item.row8Col6);
                $('#txtRow9Col5').val(item.row9Col5);
                $('#txtRow9Col6').val(item.row9Col6);
                $('#txtRow10Col5').val(item.row10Col5);
                $('#txtRow10Col6').val(item.row10Col6);
            }
            catch (e) {
                console.log('Error occured while loading CIR data Dynamic Table' + e);
            }
        });
    }
    function renderCirDataGearbox(cirDataGearbox) {
        cirDataGearbox.forEach(function (item) {
            try {
                $("._BearDamageClass").each(function () {
                    $(this).empty();
                })
                $('#ddlGearboxGManufacturer').val(item.gearboxManufacturerId);
                $('#txtOtherGearboxGManufacturer').val(item.gearboxOtherManufacturer);
                $('#ddlGearboxGType').val(item.gearboxTypeId);

                GetGearboxType(item.gearboxManufacturerId, item.gearboxTypeId)

                $('#txtOtherGearboxGType').val(item.otherGearboxType);
                $('#ddlGearboxGRevision').val(item.gearboxRevisionId);
                $('#txtGearboxSerialNumber').val(item.gearboxSerialNumber);
                // GeneratorDriveEnd: $('#ddlAuxGearEquipment :selected').val(),
                if (item.strGearboxLastOilChangeDate != null) {
                    $('#txtDateForLastOilChange').val(item.strGearboxLastOilChangeDate);
                }
                else {

                    $('#txtDateForLastOilChange').val(GetDateStringFromDateObject(new Date(item.gearboxLastOilChangeDate)));

                }
                $('#ddlOilGearType').val(item.gearboxOilTypeId);
                $('#ddlTypeOfMechanicalOilPump').val(item.gearboxMechanicalOilPumpId);
                $('#ddlOilLevelInGearbox').val(item.gearboxOilLevelId);
                if (item.gearboxAuxEquipmentId == null)
                    $('#ddlAuxGearEquipment').val(1);
                else
                    $('#ddlAuxGearEquipment').val(item.gearboxAuxEquipmentId);

                $('#ddlActionToBeTakenOnGearbox').val(item.gearboxActionToBeTakenOnGearboxId);
                $('#txtGearboxHrs').val(item.gearboxRunHours);
                $('#txtOilTemperatureAtOilLevelCheck').val(item.gearboxOilTemperature);
                $('#txtGearboxProduction').val(item.gearboxProduction);
                $('#txtGeneratorInsulationComments').val(item.generatorInsulationComments);
                $('#ddlGeneratorGManufacturer').val(item.gearboxGeneratorManufacturerId);
                $('#ddlSecondGeneratorGManufacturer').val(item.gearboxGeneratorManufacturerId2);
                $('#ddlElectricalPump').val(item.gearboxElectricalPumpId);
                $('#ddlShrinkElement').val(item.gearboxShrinkElementId);
                $('#txtSerialNumberofShrinkElement').val(item.gearboxShrinkElementSerialNumber);
                $('#ddlGearboxCoupling').val(item.gearboxCouplingId);
                $('#ddlFilterBlockType').val(item.gearboxFilterBlockTypeId);
                $('#ddlInlineFilter').val(item.gearboxInLineFilterId);
                $('#ddlOfflineFilter').val(item.gearboxOffLineFilterId);
                $('#txtGearSoftwareRelease').val(item.gearboxSoftwareRelease);
                $('#ddlGearboxShaftsExactLocation1ShaftTypeId').val(item.gearboxShaftsExactLocation1ShaftTypeId);
                $('#ddlGearboxShaftsTypeofDamage1ShaftErrorId').val(item.gearboxShaftsTypeofDamage1ShaftErrorId);
                $('#ddlGearboxShaftsExactLocation2ShaftTypeId').val(item.gearboxShaftsExactLocation2ShaftTypeId);
                $('#ddlGearboxShaftsTypeofDamage2ShaftErrorId').val(item.gearboxShaftsTypeofDamage2ShaftErrorId);
                $('#ddlGearboxShaftsExactLocation3ShaftTypeId').val(item.gearboxShaftsExactLocation3ShaftTypeId);
                $('#ddlGearboxShaftsTypeofDamage3ShaftErrorId').val(item.gearboxShaftsTypeofDamage3ShaftErrorId);
                $('#ddlGearboxShaftsExactLocation4ShaftTypeId').val(item.gearboxShaftsExactLocation4ShaftTypeId);
                $('#ddlGearboxShaftsTypeofDamage4ShaftErrorId').val(item.gearboxShaftsTypeofDamage4ShaftErrorId);

                $('#ddlExactLocation1').val(item.gearboxExactLocation1GearTypeId);
                if (item.gearboxExactLocation1GearTypeId != 2000)
                    GetTypeIfDamage(1, item.gearboxTypeofDamage1GearErrorId)
                $('#ddlExactLocation2').val(item.gearboxExactLocation2GearTypeId);
                if (item.gearboxExactLocation2GearTypeId != 2000)
                    GetTypeIfDamage(2, item.gearboxTypeofDamage2GearErrorId)
                $('#ddlExactLocation3').val(item.gearboxExactLocation3GearTypeId);
                if (item.gearboxExactLocation3GearTypeId != 2000)
                    GetTypeIfDamage(3, item.gearboxTypeofDamage3GearErrorId)
                $('#ddlExactLocation4').val(item.gearboxExactLocation4GearTypeId);
                if (item.gearboxExactLocation4GearTypeId != 2000)
                    GetTypeIfDamage(4, item.gearboxTypeofDamage4GearErrorId)
                $('#ddlExactLocation5').val(item.gearboxExactLocation5GearTypeId);
                if (item.gearboxExactLocation5GearTypeId != 2000)
                    GetTypeIfDamage(5, item.gearboxTypeofDamage5GearErrorId)
                $('#ddlExactLocation6').val(item.gearboxExactLocation6GearTypeId);
                if (item.gearboxExactLocation6GearTypeId != 2000)
                    GetTypeIfDamage(6, item.gearboxTypeofDamage6GearErrorId)
                $('#ddlExactLocation7').val(item.gearboxExactLocation7GearTypeId);
                if (item.gearboxExactLocation7GearTypeId != 2000)
                    GetTypeIfDamage(7, item.gearboxTypeofDamage7GearErrorId)
                $('#ddlExactLocation8').val(item.gearboxExactLocation8GearTypeId);
                if (item.gearboxExactLocation8GearTypeId != 2000)
                    GetTypeIfDamage(8, item.gearboxTypeofDamage8GearErrorId)
                $('#ddlExactLocation9').val(item.gearboxExactLocation9GearTypeId);
                if (item.gearboxExactLocation9GearTypeId != 2000)
                    GetTypeIfDamage(9, item.gearboxTypeofDamage9GearErrorId)
                $('#ddlExactLocation10').val(item.gearboxExactLocation10GearTypeId);
                if (item.gearboxExactLocation10GearTypeId != 2000)
                    GetTypeIfDamage(10, item.gearboxTypeofDamage10GearErrorId)
                $('#ddlExactLocation11').val(item.gearboxExactLocation11GearTypeId);
                if (item.gearboxExactLocation11GearTypeId != 2000)
                    GetTypeIfDamage(11, item.gearboxTypeofDamage11GearErrorId)
                $('#ddlExactLocation12').val(item.gearboxExactLocation12GearTypeId);
                if (item.gearboxExactLocation12GearTypeId != 2000)
                    GetTypeIfDamage(12, item.gearboxTypeofDamage12GearErrorId)
                $('#ddlExactLocation13').val(item.gearboxExactLocation13GearTypeId);
                if (item.gearboxExactLocation13GearTypeId != 2000)
                    GetTypeIfDamage(13, item.gearboxTypeofDamage13GearErrorId)
                $('#ddlExactLocation14').val(item.gearboxExactLocation14GearTypeId);
                if (item.gearboxExactLocation14GearTypeId != 2000)
                    GetTypeIfDamage(14, item.gearboxTypeofDamage14GearErrorId)
                $('#ddlExactLocation15').val(item.gearboxExactLocation15GearTypeId);
                if (item.gearboxExactLocation15GearTypeId != 2000)
                    GetTypeIfDamage(15, item.gearboxTypeofDamage15GearErrorId)



                if (item.gearboxTypeofDamage1GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage1GearErrorId, 1, item.gearboxGearDamageClass1DamageId);
                if (item.gearboxTypeofDamage2GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage2GearErrorId, 2, item.gearboxGearDamageClass2DamageId);
                if (item.gearboxTypeofDamage3GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage3GearErrorId, 3, item.gearboxGearDamageClass3DamageId);
                if (item.gearboxTypeofDamage4GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage4GearErrorId, 4, item.gearboxGearDamageClass4DamageId);
                if (item.gearboxTypeofDamage5GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage5GearErrorId, 5, item.gearboxGearDamageClass5DamageId);
                if (item.gearboxTypeofDamage6GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage6GearErrorId, 6, item.gearboxGearDamageClass6DamageId);
                if (item.gearboxTypeofDamage7GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage7GearErrorId, 7, item.gearboxGearDamageClass7DamageId);
                if (item.gearboxTypeofDamage8GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage8GearErrorId, 8, item.gearboxGearDamageClass8DamageId);
                if (item.gearboxTypeofDamage9GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage9GearErrorId, 9, item.gearboxGearDamageClass9DamageId);
                if (item.gearboxTypeofDamage10GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage10GearErrorId, 10, item.gearboxGearDamageClass10DamageId);
                if (item.gearboxTypeofDamage11GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage11GearErrorId, 11, item.gearboxGearDamageClass11DamageId);
                if (item.gearboxTypeofDamage12GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage12GearErrorId, 12, item.gearboxGearDamageClass12DamageId);
                if (item.gearboxTypeofDamage13GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage13GearErrorId, 13, item.gearboxGearDamageClass13DamageId);
                if (item.gearboxTypeofDamage14GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage14GearErrorId, 14, item.gearboxGearDamageClass14DamageId);
                if (item.gearboxTypeofDamage15GearErrorId != 17)
                    GetDamageClass(item.gearboxTypeofDamage15GearErrorId, 15, item.gearboxGearDamageClass15DamageId);

                if (item.gearboxGearDamageClass1DamageId != null && item.gearboxGearDamageClass1DamageId >= 0)
                    GetGearsDamage(1);
                if (item.gearboxGearDamageClass2DamageId != null && item.gearboxGearDamageClass2DamageId >= 0)
                    GetGearsDamage(2);
                if (item.gearboxGearDamageClass3DamageId != null && item.gearboxGearDamageClass3DamageId >= 0)
                    GetGearsDamage(3);
                if (item.gearboxGearDamageClass4DamageId != null && item.gearboxGearDamageClass4DamageId >= 0)
                    GetGearsDamage(4);
                if (item.gearboxGearDamageClass5DamageId != null && item.gearboxGearDamageClass5DamageId >= 0)
                    GetGearsDamage(5);
                if (item.gearboxGearDamageClass6DamageId != null && item.gearboxGearDamageClass6DamageId >= 0)
                    GetGearsDamage(6);
                if (item.gearboxGearDamageClass7DamageId != null && item.gearboxGearDamageClass7DamageId >= 0)
                    GetGearsDamage(7);
                if (item.gearboxGearDamageClass8DamageId != null && item.gearboxGearDamageClass8DamageId >= 0)
                    GetGearsDamage(8);
                if (item.gearboxGearDamageClass9DamageId != null && item.gearboxGearDamageClass9DamageId >= 0)
                    GetGearsDamage(9);
                if (item.gearboxGearDamageClass10DamageId != null && item.gearboxGearDamageClass10DamageId >= 0)
                    GetGearsDamage(10);
                if (item.gearboxGearDamageClass11DamageId != null && item.gearboxGearDamageClass11DamageId >= 0)
                    GetGearsDamage(11);
                if (item.gearboxGearDamageClass12DamageId != null && item.gearboxGearDamageClass12DamageId >= 0)
                    GetGearsDamage(12);
                if (item.gearboxGearDamageClass13DamageId != null && item.gearboxGearDamageClass13DamageId >= 0)
                    GetGearsDamage(13);
                if (item.gearboxGearDamageClass14DamageId != null && item.gearboxGearDamageClass14DamageId >= 0)
                    GetGearsDamage(14);
                if (item.gearboxGearDamageClass15DamageId != null && item.gearboxGearDamageClass15DamageId >= 0)
                    GetGearsDamage(15);
                $('#ddlDecision1').prop("disabled", false);
                $('#ddlDecision2').prop("disabled", false);
                $('#ddlDecision3').prop("disabled", false);
                $('#ddlDecision4').prop("disabled", false);
                $('#ddlDecision5').prop("disabled", false);
                $('#ddlDecision6').prop("disabled", false);
                $('#ddlDecision7').prop("disabled", false);
                $('#ddlDecision8').prop("disabled", false);
                $('#ddlDecision9').prop("disabled", false);
                $('#ddlDecision10').prop("disabled", false);
                $('#ddlDecision11').prop("disabled", false);
                $('#ddlDecision12').prop("disabled", false);
                $('#ddlDecision13').prop("disabled", false);
                $('#ddlDecision14').prop("disabled", false);
                $('#ddlDecision15').prop("disabled", false);

                $('#ddlDecision1').val(item.gearboxGearDecision1DamageDecisionId);
                $('#ddlDecision2').val(item.gearboxGearDecision2DamageDecisionId);
                $('#ddlDecision3').val(item.gearboxGearDecision3DamageDecisionId);
                $('#ddlDecision4').val(item.gearboxGearDecision4DamageDecisionId);
                $('#ddlDecision7').val(item.gearboxGearDecision7DamageDecisionId);
                $('#ddlDecision8').val(item.gearboxGearDecision8DamageDecisionId);
                $('#ddlDecision6').val(item.gearboxGearDecision6DamageDecisionId);
                $('#ddlDecision9').val(item.gearboxGearDecision9DamageDecisionId);
                $('#ddlDecision11').val(item.gearboxGearDecision10DamageDecisionId);
                $('#ddlDecision10').val(item.gearboxGearDecision11DamageDecisionId);
                $('#ddlDecision12').val(item.gearboxGearDecision12DamageDecisionId);
                $('#ddlDecision13').val(item.gearboxGearDecision13DamageDecisionId);
                $('#ddlDecision14').val(item.gearboxGearDecision14DamageDecisionId);
                $('#ddlDecision15').val(item.gearboxGearDecision15DamageDecisionId);

                $('#ddlLocation1').val(item.gearboxBearingsLocation1BearingTypeId);
                $('#ddlDecision5').val(item.gearboxGearDecision5DamageDecisionId);
                $('#ddlLocation2').val(item.gearboxBearingsLocation2BearingTypeId);
                $('#ddlLocation3').val(item.gearboxBearingsLocation3BearingTypeId);
                $('#ddlLocation4').val(item.gearboxBearingsLocation4BearingTypeId);
                $('#ddlLocation5').val(item.gearboxBearingsLocation5BearingTypeId);
                $('#ddlLocation6').val(item.gearboxBearingsLocation6BearingTypeId);
                $('#ddlPosition1').val(item.gearboxBearingsPosition1BearingPosId);
                $('#ddlPosition2').val(item.gearboxBearingsPosition2BearingPosId);
                $('#ddlPosition3').val(item.gearboxBearingsPosition3BearingPosId);
                $('#ddlPosition4').val(item.gearboxBearingsPosition4BearingPosId);
                $('#ddlPosition5').val(item.gearboxBearingsPosition5BearingPosId);
                $('#ddlPosition6').val(item.gearboxBearingsPosition6BearingPosId);
                $('#ddlTypeofDamage1').val(item.gearboxBearingsDamage1BearingErrorId);
                if (item.gearboxBearingsDamage1BearingErrorId != 1)
                    GetBearingDamage(1, item.gearboxBearingDecision1DamageDecisionId);
                $('#ddlTypeofDamage2').val(item.gearboxBearingsDamage2BearingErrorId);
                if (item.gearboxBearingsDamage2BearingErrorId != 1)
                    GetBearingDamage(2, item.gearboxBearingDecision2DamageDecisionId);
                $('#ddlTypeofDamage3').val(item.gearboxBearingsDamage3BearingErrorId);
                if (item.gearboxBearingsDamage3BearingErrorId != 1)
                    GetBearingDamage(3, item.gearboxBearingDecision3DamageDecisionId);
                $('#ddlTypeofDamage4').val(item.gearboxBearingsDamage4BearingErrorId);
                if (item.gearboxBearingsDamage4BearingErrorId != 1)
                    GetBearingDamage(4, item.gearboxBearingDecision4DamageDecisionId);
                $('#ddlTypeofDamage5').val(item.gearboxBearingsDamage5BearingErrorId);
                if (item.gearboxBearingsDamage5BearingErrorId != 1)
                    GetBearingDamage(5, item.gearboxBearingDecision5DamageDecisionId);
                $('#ddlTypeofDamage6').val(item.gearboxBearingsDamage6BearingErrorId);
                if (item.gearboxBearingsDamage6BearingErrorId != 1)
                    GetBearingDamage(6, item.gearboxBearingDecision6DamageDecisionId);
                $('#ddlPlanetStage1').val(item.gearboxPlanetStage1HousingErrorId);
                $('#ddlPlanetStage2').val(item.gearboxPlanetStage2HousingErrorId);
                $('#ddlHelicalParallelStage').val(item.gearboxHelicalStageHousingErrorId);
                $('#ddlFrontPlate').val(item.gearboxFrontPlateHousingErrorId);
                $('#ddlAuxlliaryStage').val(item.gearboxAuxStageHousingErrorId);
                $('#ddlHSStage').val(item.gearboxHSStageHousingErrorId);
                $('#ddlPlanetStage2').val(item.gearboxPlanetStage2HousingErrorId);
                if (item.gearboxLooseBolts) {
                    $('#chkLooseBolts').parent().addClass('checked'); $('#chkLooseBolts').attr('checked', true);
                }
                if (item.gearboxBrokenBolts)
                { $('#chkBrokenBolts').parent().addClass('checked'); $('#chkBrokenBolts').attr('checked', true); }
                if (item.gearboxDefectDamperElements)
                { $('#chkDefectDamperElements').parent().addClass('checked'); $('#chkDefectDamperElements').attr('checked', true); }
                if (item.gearboxTooMuchClearance)
                { $('#chkTooMuchClearance').parent().addClass('checked'); $('#chkTooMuchClearance').attr('checked', true); }
                if (item.gearboxCrackedTorqueArm)
                { $('#chkCrackedBrokenTorqueArm').parent().addClass('checked'); $('#chkCrackedBrokenTorqueArm').attr('checked', true); }
                if (item.gearboxNeedsToBeAligned)
                { $('#chkNeedsToBeAligned').parent().addClass('checked'); $('#chkNeedsToBeAligned').attr('checked', true); }
                if (item.gearboxPT100Bearing1)
                { $('#chkPt100Bearing1').parent().addClass('checked'); $('#chkPt100Bearing1').attr('checked', true); }
                if (item.gearboxPT100Bearing2)
                { $('#chkPt100Bearing2').parent().addClass('checked'); $('#chkPt100Bearing2').attr('checked', true); }
                if (item.gearboxPT100Bearing3)
                { $('#chkPt100Bearing3').parent().addClass('checked'); $('#chkPt100Bearing3').attr('checked', true); }

                if (item.gearboxOilLevelSensor)
                { $('#chkOilLevelsensor').parent().addClass('checked'); $('#chkOilLevelsensor').attr('checked', true); }
                if (item.gearboxDrainValve)
                { $('#chkDrainValve').parent().addClass('checked'); $('#chkDrainValve').attr('checked', true); }

                if (item.gearboxOilPressure)
                { $('#chkOilPressures412').parent().addClass('checked'); $('#chkOilPressures412').attr('checked', true); }
                if (item.gearboxPT100OilSump)
                { $('#chkPt100OilSump').parent().addClass('checked'); $('#chkPt100OilSump').attr('checked', true); }

                if (item.gearboxFilterIndicator)
                { $('#chkFilterIndicator').parent().addClass('checked'); $('#chkFilterIndicator').attr('checked', true); }
                if (item.gearboxImmersionHeater)
                { $('#chkImmersionHeater').parent().addClass('checked'); $('#chkImmersionHeater').attr('checked', true); }

                if (item.gearboxAirBreather)
                { $('#chkAirBreather').parent().addClass('checked'); $('#chkAirBreather').attr('checked', true); }
                if (item.gearboxSightGlass)
                { $('#chkSightGlass').parent().addClass('checked'); $('#chkSightGlass').attr('checked', true); }
                if (item.gearboxChipDetector)
                { $('#chkChipDetector').parent().addClass('checked'); $('#chkChipDetector').attr('checked', true); }
                $('#lblDefectSCategorizationScore').html(item.gearboxDefectCategorizationScore);
                $('#ddlVibrations').val(item.gearboxVibrationsId);
                $('#ddlNoise').val(item.gearboxNoiseId);
                $('#ddlDebrisOnMagnet').val(item.gearboxDebrisOnMagnetId);
                $('#ddlMagnetPos').val(item.gearboxDebrisStagesMagnetPosId);
                $('#ddlDebrisFoundinGearbox').val(item.gearboxDebrisGearBoxId);
                $('#ddlOverallGearboxCondition').val(item.gearboxOverallGearboxConditionId);
                $('#txtDateMaxTemperatureResetDate').val(item.gearboxMaxTempResetDate);
                $('#txtBearing1').val(item.gearboxTempBearing1);
                $('#txtBearing2').val(item.gearboxTempBearing2);
                $('#txtBearing3').val(item.gearboxTempBearing3);
                $('#txtOilSump').val(item.gearboxTempOilSump);
                if (item.gearboxLSSNRend)
                { $('#chkLSSNREnd').parent().addClass('checked'); $('#chkLSSNREnd').attr('checked', true); }
                if (item.gearboxIMSNRend)
                { $('#chkIMSNREnd').parent().addClass('checked'); $('#chkIMSNREnd').attr('checked', true); }
                if (item.gearboxIMSRend)
                { $('#chkIMSREnd').parent().addClass('checked'); $('#chkIMSREnd').attr('checked', true); }

                if (item.gearboxHSSNRend)
                { $('#chkHSSNREnd').parent().addClass('checked'); $('#chkHSSNREnd').attr('checked', true); }
                if (item.gearboxHSSRend)
                { $('#chkHSSREnd').parent().addClass('checked'); $('#chkHSSREnd').attr('checked', true); }
                if (item.gearboxPitchTube)
                { $('#chkPitchTube').parent().addClass('checked'); $('#chkPitchTube').attr('checked', true); }
                if (item.gearboxSplitLines)
                { $('#chkSpliLines').parent().addClass('checked'); $('#chkSpliLines').attr('checked', true); }
                if (item.gearboxHoseAndPiping)
                { $('#chkHoseandPiping').parent().addClass('checked'); $('#chkHoseandPiping').attr('checked', true); }
                if (item.gearboxInputShaft)
                { $('#chkInputShaft').parent().addClass('checked'); $('#chkInputShaft').attr('checked', true); }
                if (item.gearboxHSSPTO)
                { $('#chkAuxHSSPTO').parent().addClass('checked'); $('#chkAuxHSSPTO').attr('checked', true); }


            }
            catch (e) {
                console.log('Error occured while loading CIR data Gearbox ' + e);
            }
        });
    }

    function deepEquals(o1, o2) {
        var k1 = Object.keys(o1).sort();
        var k2 = Object.keys(o2).sort();
        if (k1.length != k2.length) return false;
        return k1.zip(k2, function (keyPair) {
            if (typeof o1[keyPair[0]] == typeof o2[keyPair[1]] == "object") {
                return deepEquals(o1[keyPair[0]], o2[keyPair[1]])
            } else {
                return o1[keyPair[0]] == o2[keyPair[1]];
            }
        }).all();
    }
    //Datetime string
    function GetDateTimeStringFromDateObject(DateTiemObject) {
        try {

            DateTiemObject.setTime(DateTiemObject.getTime() + DateTiemObject.getTimezoneOffset() * 60 * 1000);
            var dd = DateTiemObject.getDate();
            var mm = DateTiemObject.getMonth() + 1; //January is 0!
            var hours = DateTiemObject.getHours();
            var minutes = DateTiemObject.getMinutes();

            hours = hours < 10 ? '0' + hours : hours;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            var strTime = hours + ':' + minutes;
            var yyyy = DateTiemObject.getFullYear();
            if (dd < 10) {
                dd = '0' + dd
            }
            if (mm < 10) {
                mm = '0' + mm
            }
            return dd + '-' + mm + '-' + yyyy + " " + strTime;;
        }
        catch (e) {
            return DateTiemObject;
        }

    }

    function ConvertCommatoDecimal(val) {
        val = val.replace(',', '.');
        return val;
    }

};
