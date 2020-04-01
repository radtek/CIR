var azureSync = new function () {
    this.__LocalServerGuidMapping = [];
    this._syncing = 0;
    this.SinglePull = function (LocalItem) {
        var deferredObject = $.Deferred();
        CallClientApi("UserCirData/" + LocalItem.CirDataCommonID, "GET", "").done(function (ServerItem) {
            if (ServerItem.__deleted == true && ServerItem.rowVersion >= LocalItem.RowVersion) {
                cirOfflineApp.deleteCirLocalData(LocalItem.CirDataCommonID).done(function () { deferredObject.resolve(null); });
            }
            else {
                azureSync.Process(ServerItem, LocalItem).done(function () { deferredObject.resolve(ServerItem); });
            }
        });
        return deferredObject.promise();
    };
    this.SyncDeleted = function (userId) {
        var deferredObject = $.Deferred();
        var DataWithClientList = [];
        if (userId.trim() == "") {
            console.log("User Id is empty");
            deferredObject.resolve();
        }
        //Get all Local Data
        cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
            var DataWithClientList = [];
            $.each(CirLocalDataList, function (i, item) {
                if (userId == item.UserInitial && item.RowVersion > 0) {
                    var DataVersionMapping = {};
                    DataVersionMapping.cirDataCommonID = item.CirDataCommonID;
                    DataVersionMapping.rowVersion = item.RowVersion;
                    DataWithClientList.push(DataVersionMapping);
                }
            });
            //Call Azure Service sending userId and DataWithClientList and Get Data from Server in ServerResult
            CallClientApi("DeletedCirData/" + encodeURIComponent(userId), "POST", DataWithClientList).done(function (ServerResult) {
                //Read Each ServerData
                var taskCount = ServerResult.length;
                var taskCompleted = 0;
                if (taskCount == 0)
                    deferredObject.resolve();
                $.each(ServerResult, function (i, DeletedItem) {
                    //Look up the ServerItem in LocalDb
                    cirOfflineApp.findCirLocalDataforPull(DeletedItem).done(function (LocalItem) {
                        if (LocalItem != false) {
                            var cname = LocalItem.CirData.componentInspectionReportName;
                            cirOfflineApp.deleteCirLocalData(LocalItem.CirDataCommonID).done(function () {
                                NotifyCirMessage('', 'CIR [' + cname + '] has been deleted either by you from another device or deleted/reassigned by admin!', 'danger', 3000);
                                taskCompleted++
                                if (taskCompleted == taskCount) {
                                    deferredObject.resolve();
                                }
                            });
                        }
                        else {
                            taskCompleted++
                            if (taskCompleted == taskCount) {
                                deferredObject.resolve();
                            }
                        }

                    });

                });
            }).fail(function () {
                azureSync.StopSyncNow();
                deferredObject.resolve();
            });

        });
        return deferredObject.promise();
    }

    this.Pull = function (userId) {
        var deferredObject = $.Deferred();

        if (userId.trim() == "") {
            console.log("User Id is empty");
            deferredObject.resolve();
        }
        azureSync.SyncDeleted(userId).done(function () {
            var DataWithClientList = [];
            //Get all Local Data
            cirOfflineApp.getCirLocalDataForSync().done(function (CirLocalDataList) {
                var DataWithClientList = [];
                $.each(CirLocalDataList, function (i, item) {
                    if (userId == item.UserInitial) {
                        var DataVersionMapping = {};
                        DataVersionMapping.cirDataCommonID = item.CirDataCommonID;
                        DataVersionMapping.rowVersion = item.RowVersion;
                        DataWithClientList.push(DataVersionMapping);
                    }
                });
                //Call Azure Service sending userId and DataWithClientList and Get Data from Server in ServerResult
                CallClientApi("PullCirData/" + encodeURIComponent(userId), "POST", DataWithClientList).done(function (ServerResult) {
                    //Read Each ServerData
                    var taskCount = ServerResult.length;
                    var taskCompleted = 0;
                    $.each(ServerResult, function (i, ServerItem) {
                        //Look up the ServerItem in LocalDb
                        cirOfflineApp.findCirLocalDataforPull(ServerItem.id).done(function (LocalItem) {
                            azureSync.Process(ServerItem, LocalItem).done(function () {
                                taskCompleted++;
                                if (taskCompleted == taskCount) {
                                    deferredObject.resolve();
                                }
                            });

                        });
                    });
                    if (ServerResult.length == 0) {
                        deferredObject.resolve();
                    }
                });
            });

        }).fail(function () {
            azureSync.StopSyncNow();
            deferredObject.resolve();
        });
        return deferredObject.promise();
    };

    this.Push = function (userId) {
        var deferredObject = $.Deferred();
        azureSync.__LocalServerGuidMapping = [];
        //Call Pull Before Push
        azureSync.Pull(userId).done(function () {
            //send isDirty records to server.in loop
            cirOfflineApp.getAllDirtyCirLocalForSync(userId).done(function (DirtyData) {
                var taskCount = DirtyData.length;
                var taskCompleted = 0;
                $.each(DirtyData, function (i, item) {
                    //Call Azure Service sending userId and DataWithClientList and Get Data from Server in ServerResult
                    if (item.Deleted == true) {
                        CallClientApi("UserCirData/" + item.CirDataCommonID, "DELETE", '', true).done(function (result) {
                            cirOfflineApp.deleteCirLocalData(item.CirDataCommonID).done(function () {
                                taskCompleted++;
                                if (taskCompleted == taskCount) {
                                    deferredObject.resolve();
                                }
                            });
                        }).fail(function () {
                            cirOfflineApp.deleteCirLocalData(item.CirDataCommonID).done(function () {
                                taskCompleted++;
                                if (taskCompleted == taskCount) {
                                    deferredObject.resolve();
                                }
                            });
                        });
                    }
                    else {
                        if (item.Status != 4) {
                            var patch = {};
                            patch.updateBy = item.UpdateBy;
                            patch.createdDate = item.CreatedDate;
                            patch.cirDataLocalID = item.CirDataLocalID;
                            patch.status = item.Status;
                            patch.cirData = JSON.stringify(item.CirData);
                            patch.userInitial = item.UserInitial;
                            patch.statusMessage = item.StatusMessage;
                            patch.statusDetailMessage = item.StatusDetailMessage;
                            patch.cirStatus = item.CirStatus;
                            patch.rowVersion = item.RowVersion;
                            CallClientApi("UserCirData/" + item.CirDataCommonID, "PATCH", patch).done(function (ServerItem) {
                                if (ServerItem.id != item.CirDataCommonID) {
                                    var guidmapping = {};
                                    guidmapping.LocalGuid = item.CirDataCommonID;
                                    guidmapping.ServerGuid = ServerItem.id;
                                    azureSync.__LocalServerGuidMapping.push(guidmapping);
                                    cirOfflineApp.deleteCirLocalData(item.CirDataCommonID).done(function () {
                                        cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                                            //Fix for Multiple CIR Create First time on Manage CIR
                                            if ($('#CirDataCommonID').val() == item.CirDataCommonID) {
                                                $('#CirDataCommonID').val(ServerItem.id);
                                            }
                                            taskCompleted++;
                                            if (taskCompleted == taskCount) {
                                                deferredObject.resolve();
                                            }
                                        });
                                    });
                                }
                                else {
                                    if (ServerItem.status != 0) {
                                        cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                                            taskCompleted++;
                                            if (taskCompleted == taskCount) {
                                                deferredObject.resolve();
                                            }
                                        });
                                    }
                                    else {
                                        taskCompleted++;
                                        if (taskCompleted == taskCount) {
                                            deferredObject.resolve();
                                        }
                                    }
                                }
                            });
                        }
                        else {
                            taskCompleted++;
                            if (taskCompleted == taskCount) {
                                deferredObject.resolve();
                            }
                        }
                    }
                });
                if (DirtyData.length == 0) {
                    deferredObject.resolve();
                }
            });

        });
        return deferredObject.promise();
    };

    this.Process = function (ServerItem, LocalItem) {
        var deferredObject = $.Deferred();
        //Update Local Store Data as neccessary 
        if (LocalItem == false) //Not found in LocalDB
        {
            //Add in LocalDB
            cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                var objCirData = $.parseJSON(ServerItem.cirData);
                var cname = objCirData.componentInspectionReportName;
                if ((ServerItem.remarks != undefined && ServerItem.remarks != null && ServerItem.remarks != 'null' && ServerItem.remarks != "")) {
                    NotifyCirMessage('', 'CIR [' + cname + '], ' + ServerItem.remarks, 'danger', 0);
                }
                deferredObject.resolve();
            });
        }
        else {

            if (ServerItem.status == 1) { // Draft Version
                if ((ServerItem.rowVersion == LocalItem.RowVersion) && (LocalItem.IsDirty == false)) {
                    // No Changes to be Done
                    deferredObject.resolve();
                }
                else if ((ServerItem.rowVersion == LocalItem.RowVersion) && (LocalItem.IsDirty == true)) {
                    //Push Local DB to Server DB
                    deferredObject.resolve();
                }
                else if ((ServerItem.rowVersion > LocalItem.RowVersion) && (LocalItem.IsDirty == false)) {
                    //Update the Local DB with Server DB                                   
                    cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                        if (LocalItem.Status == 7 && ServerItem.remarks != undefined && ServerItem.remarks != null && ServerItem.remarks != 'null' && ServerItem.remarks != "") {
                            var objCirData = $.parseJSON(ServerItem.cirData);
                            var cname = objCirData.componentInspectionReportName;
                            NotifyCirMessage('', 'CIR [' + cname + '], ' + ServerItem.remarks, 'danger', 0);
                        }
                        deferredObject.resolve();
                    });
                }
                else if ((ServerItem.rowVersion > LocalItem.RowVersion) && (LocalItem.IsDirty == true)) {
                    //Update the Local DB with Server DB                                   
                    cirOfflineApp.UpdateItemServerToLocalDBWithConflict(LocalItem).done(function () {
                        deferredObject.resolve();
                    });
                }
                else {
                    deferredObject.resolve();
                }
            }

            else if (ServerItem.status == 2) { // Submitted Version                               
                //Update the Local DB with Server DB   
                cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                    if (LocalItem.Status == 7 && ServerItem.remarks != undefined && ServerItem.remarks != null && ServerItem.remarks != 'null' && ServerItem.remarks != "") {
                        var objCirData = $.parseJSON(ServerItem.cirData);
                        var cname = objCirData.componentInspectionReportName;
                        NotifyCirMessage('', 'CIR [' + cname + '], ' + ServerItem.remarks, 'danger', 0);
                    }
                    deferredObject.resolve();
                });

            }
            else if (ServerItem.status == -1) { // Error Version                                                            
                if (LocalItem.IsDirty == false) {
                    //Update the Local DB with Server DB   
                    cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                        deferredObject.resolve();
                    });
                }
                else if (LocalItem.IsDirty == true && (ServerItem.rowVersion != LocalItem.RowVersion)) {
                    //Update the Local DB with Server DB   
                    cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                        deferredObject.resolve();
                    });
                }
                else {
                    deferredObject.resolve();
                }
            }
            else {

                if ((ServerItem.rowVersion > LocalItem.RowVersion)) {
                    cirOfflineApp.UpdateItemServerToLocalDB(ServerItem).done(function () {
                        deferredObject.resolve();
                    });
                }
                else {
                    deferredObject.resolve();
                }
            }
        }
        return deferredObject.promise();
    }

    this.ResolveConflictKeepLocal = function (id, openEdit) {
        //Get Conflict Data from Local 
        cirOfflineApp.findCirLocalData(id).done(function (oldLocalItem) {
            //Pull Updated Data from Server
            azureSync.SinglePull(oldLocalItem).done(function (ServerItem) {
                //check if delted on server and local
                if (ServerItem == null) {
                    CirAlert.alert('This CIR is deleted from another device', 'Cir App', null, 'error').done(function () {
                        window.location.href = '/cir/local-history';
                    });
                }
                else {
                    //Get Updated Data from Local               
                    cirOfflineApp.UpdateResolveConflictLocal(oldLocalItem, ServerItem.rowVersion).done(function () {
                        if (openEdit == true) {
                            window.location.href = '/cir/manage-cir#id=' + id;
                        }
                    });
                }
            });
        });
    };

    this.ResolveConflictKeepServer = function (id, openEdit) {
        //Get Conflict Data from Local and Updated it as Resolved 
        //Get Conflict Data from Local 
        cirOfflineApp.findCirLocalData(id).done(function (oldLocalItem) {
            //Pull Updated Data from Server
            azureSync.SinglePull(oldLocalItem).done(function (ServerItem) {
                //check if delted on server and local
                if (ServerItem == null) {
                    //  alert("This CIR is deleted from another device");
                    CirAlert.alert('This CIR is deleted from another device', 'Cir App', null, 'error').done(function () {
                        window.location.href = '/cir/local-history';
                    });
                }
                else {
                    //Get Updated Data from Local               
                    cirOfflineApp.UpdateResolveConflictServer(ServerItem).done(function () {
                        if (openEdit == true) {
                            window.location.href = '/cir/manage-cir#id=' + id;
                        }
                    });
                }
            });
        });
    };

    //Sync Timer
    var _timer = null;
    var SyncTime = 180; ///60
    var _INTERVAL = 180;//60; 
    var _timerState = null;
    var _itimer = null;
    var ImageSync = 60;
    createCookie("_IsImageSyncingCookie", 0);
    var isPreviousStateOnline = false; 

    function removeObsoleteCirFromQueue(cirId, item) {
        let storageQueue = localStorage.getItem("cirQueue");
        let cirQueue = storageQueue ? JSON.parse(storageQueue) : null;
        if (!!cirQueue && cirQueue.length > 0) {
            var removalIdx = cirQueue.findIndex(function (obj) {
                return obj.cirId === cirId;
            });
            if (removalIdx < 0) {
                return;
            }
            cirQueue.splice(removalIdx, 1);
            localStorage.cirQueue = JSON.stringify(cirQueue ? cirQueue : []);
            if (cirQueue == null || cirQueue.length == 0) {
                loadAllCIRImageBlobs("Read").done(function (cirImageblobList) {
                    azureSync.AddPendingCirToImageSync(cirImageblobList);
                });
            }
            if (!item.imageReferences || (!!item.imageReferences && ((!!item.data.imagecomponentKey && !!item.data.imagecomponentKey.uploadedImagesCache && item.imageReferences.length != item.data.imagecomponentKey.uploadedImagesCache.length) || (!!item.data.page3UploadImages && item.imageReferences.length != item.data.page3UploadImages.length)))) {
                azureSync.addCirToImageSyncQueue(cirId);
            }
            else {
                cirOfflineApp.DeleteCirImageBlobList(cirId);
                updateStatus(item);
            }
        }
    }

    function updateStatus(item) {
        cirOfflineApp.GetCirTemplateById(item.cirTemplateId).done(function (template) {
            item.state = item.cirTemplateName === "BladeInspection" && template.cirBrand.name.indexOf("_WindAMS") != -1 ? "PendingForBa" : item.state;
            if (item.state === "Submitted" || item.state === "Approved" || item.state === "PendingForBa") {
                item.isNewCirData = false;
            }
            if (!!item && !(!item.imageReferences || (!!item.imageReferences && ((!!item.data.imagecomponentKey && !!item.data.imagecomponentKey.uploadedImagesCache && item.imageReferences.length != item.data.imagecomponentKey.uploadedImagesCache.length) || (!!item.data.page3UploadImages && item.imageReferences.length != item.data.page3UploadImages.length))))) {
                item.imageProcessStatus = "Synced";
            }
            item.modifiedOn = new Date();
            item.modifiedBy = CurrentUserInfo.Name.toLowerCase();
            cirOfflineApp.UpdateCirDataJson(item).done(function () {
                waitingDialog.hide();
            });
        });
    }

    this.AddPendingCirToImageSync = function (cirImageblobList) {
        if (!!cirImageblobList) {
            for (i = 0; i < cirImageblobList.length; i++) {
                if (!!cirImageblobList[i].blobList && cirImageblobList[i].blobList.length && !!cirImageblobList[i].cirId) {
                    azureSync.addCirToImageSyncQueue(cirImageblobList[i].cirId);
                }
                else if (!!cirImageblobList[i].cirId) {
                    cirOfflineApp.GetCirDataJsonById(cirImageblobList[i].cirId).done(function (item) {
                        if (!!item && !(!item.imageReferences || (!!item.imageReferences && ((!!item.data.imagecomponentKey && !!item.data.imagecomponentKey.uploadedImagesCache && item.imageReferences.length != item.data.imagecomponentKey.uploadedImagesCache.length) || (!!item.data.page3UploadImages && item.imageReferences.length != item.data.page3UploadImages.length))))) {
                            cirOfflineApp.DeleteCirImageBlobList(item.id);
                            updateStatus(item);
                        }
                    }).fail(function (_) {
                    });
                }
            }
        }
        return;
    }

    this.SyncImagesToBlob = function () {
        imageSyncInterval = setInterval(function () {
            if (Offline.state == "up" && isPreviousStateOnline == false && (readCookie("_IsImageUploadingCookie") == null || readCookie("_IsImageUploadingCookie"))) {
                isPreviousStateOnline = true;
                try { 
                    createCookie("_IsImageUploadingCookie", false);
                    GetImageBlobList();
                }
                catch (e) {

                }
            }
            else if (Offline.state != "up") {
                createCookie("_IsImageUploadingCookie", true);
                isPreviousStateOnline = false;
            }
        }, 1000);
    } 
    this.StartImageSync = function () {
        if (!!_itimer) {
            return;
        }
        var _itime = readCookie("_ImageSyncCookie");
        if (parseInt(_itime) > 0) {
            ImageSync = _itime;
        }
        _itimer = setInterval(function () {
            if (Offline.state === "up") {
                if (readCookie("_IsImageSyncingCookie") !== '0') {
                    return;
                }
                ImageSync--;
                if (ImageSync <= 0) {
                    ImageSync = 60;
                }
                createCookie("_ImageSyncCookie", ImageSync);
                let storageQueue = localStorage.getItem("cirQueue");
                let cirQueue = storageQueue ? JSON.parse(storageQueue) : null;
                if (!!cirQueue) {
                    let cirToRun = cirQueue.filter(x => x.Status == "Run");
                    if (cirQueue.length !== 0 && cirToRun.length == 0) {
                        $.each(cirQueue, function (i, item) {
                            item.Status = "Run";
                        });
                        cirToRun = [cirQueue[0]];
                    }
                    if (cirToRun.length !== 0) {
                        if (readCookie("_IsImageSyncingCookie") != '0') {
                            return;
                        }
                        createCookie("_IsImageSyncingCookie", cirToRun[0].cirId);
                        cirOfflineApp.GetCirDataJsonById(cirToRun[0].cirId).done(function (item) {
                            loadBlobs("Read", cirToRun[0].cirId).done(function (blobs) {
                                if (!blobs || !blobs.length) {
                                    createCookie("_IsImageSyncingCookie", 0);
                                    removeObsoleteCirFromQueue(cirToRun[0].cirId, item);
                                    return;
                                }
                                if (Offline.state == "up") {
                                    callImageAPI(blobs, item, function () {
                                        cirOfflineApp.GetCirDataJsonById(item.id).done(function (updatedItem) {
                                            createCookie("_IsImageSyncingCookie", 0);
                                            removeObsoleteCirFromQueue(cirToRun[0].cirId, updatedItem);
                                        }).fail(function (_) {
                                            createCookie("_IsImageSyncingCookie", 0);
                                            removeObsoleteCirFromQueue(cirToRun[0].cirId, item);
                                        });
                                    });
                                }
                            }).fail(function (_) {
                                createCookie("_IsImageSyncingCookie", 0);
                                loadAllCIRImageBlobs("Read").done(function (cirImageblobList) {
                                    azureSync.AddPendingCirToImageSync(cirImageblobList);
                                    removeObsoleteCirFromQueue(cirToRun[0].cirId, item);
                                }).fail(function (_) {
                                    removeObsoleteCirFromQueue(cirToRun[0].cirId, item);
                                });
                            });
                        });
                    }
                    else {
                        createCookie("_IsImageSyncingCookie", 0);
                        loadAllCIRImageBlobs("Read").done(function (cirImageblobList) {
                            azureSync.AddPendingCirToImageSync(cirImageblobList);
                        });
                    }
                }
                else {
                    createCookie("_IsImageSyncingCookie", 0);
                    loadAllCIRImageBlobs("Read").done(function (cirImageblobList) {
                        azureSync.AddPendingCirToImageSync(cirImageblobList);
                    });
                }
            }
        }, 1000);
    }

    this.StartSyncTimer = function () {
        var _stime = readCookie("_SyncCookieTimer");
        if (parseInt(_stime) > 0) {
            SyncTime = _stime;
        }
        else {
            createCookie("_SyncCookieTimer", SyncTime);
        }
        $("#btnSync").attr("class", "btn btn-xs btn-primary");
        _timer = setInterval(function () {
            if (Offline.state == "up") {
                var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');
                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            if (SyncTime < 0 || azureSync._syncing == 1) {
                                return;
                            }
                            SyncTime--;
                            createCookie("_SyncCookieTimer", SyncTime);
                            if (SyncTime == 0) {
                                azureSync.StartSync();
                            }
                            else {
                                var c = $(".fa-pencil-square-o").parent(0);
                                var elems = document.querySelectorAll(".fa-pencil-square-o")
                                if (c.is("a")) {
                                    $(".fa-pencil-square-o").parent().css("pointer-events", "");
                                    $(".fa-pencil-square-o").parent().removeAttr("disabled");
                                }
                                $(".fa-pencil-square-o").css("pointer-events", "");
                                $(".fa-pencil-square-o").removeAttr("disabled");
                                if (window.location.pathname.indexOf("local-history") != -1) {
                                    $(".fa-pencil-square-o").css("color", "#000000");
                                }
                                else if (elems != undefined && elems[elems.length - 1] != undefined) {
                                    if (elems[elems.length - 1].style.color) {
                                        $(".fa-pencil-square-o").css("color", "#08088A");
                                    }
                                }
                                if (readCookie("_IsImageSyncingCookie") != 0) {
                                    let cirInImgSync = readCookie("_IsImageSyncingCookie");
                                    $(".fa-pencil-square-o").parent('#' + cirInImgSync).css("pointer-events", "none");
                                    $(".fa-pencil-square-o").parent('#' + cirInImgSync).attr("disabled", 'disabled');

                                    $(".fa-pencil-square-o").parent('#' + cirInImgSync).children().css("pointer-events", "none");
                                    $(".fa-pencil-square-o").parent('#' + cirInImgSync).children().attr("disabled", 'disabled');
                                    $(".fa-pencil-square-o").parent('#' + cirInImgSync).children().css("color", "#c0c0c0");
                                }
                                $("#btnSync").attr("class", "btn btn-xs btn-primary");
                                $("#btnSync").html("<i class='fa fa-spinner fa-spin'></i> Next Sync in " + SyncTime + " secs");
                            }

                        }
                        else {
                            $("#btnSync").attr("class", "btn btn-xs btn-danger");
                            $("#btnSync").html("<i class='fa fa-spinner'></i> User Inactive");
                        }
                    }
                    else {
                        $("#btnSync").attr("class", "btn btn-xs btn-danger");
                        $("#btnSync").html("<i class='fa fa-spinner'></i> User Inactive");
                    }
                });

            }
            else {
                $("#btnSync").attr("class", "btn btn-xs btn-danger");
                $("#btnSync").html("<i class='fa fa-spinner'></i> Offline");
            }
        }, 1000);
    };

    this.StartStopTimer = function () {
        if (_timer) {
            clearInterval(_timer);
            createCookie("_SyncCookieTimerState", 0);
            _timer = null;
            $("#btnSync").attr("class", "btn btn-xs btn-danger");
            $("#btnSync").html("<i class='fa fa-spinner'></i> Sync");
        }
        else {
            createCookie("_SyncCookieTimer", _INTERVAL);
            createCookie("_SyncCookieTimerState", 1);
            azureSync.StartSyncTimer();
        }
    }

    this.GetTimerState = function () {
        return readCookie("_SyncCookieTimerState");
    };

    this.SyncNow = function () {
        azureSync.StartSync();
    }

    this.StopSyncNow = function () {
        clearInterval(_timer);
        createCookie("_SyncCookieTimerState", 0);
        _timer = null;
        $("#btnSync").attr("class", "btn btn-xs btn-danger");
        $("#btnSync").html("<i class='fa fa-spinner'></i> Sync");
        azureSync._syncing = 0;
    }

    this.StartSync = function () {
        var deferredObject = $.Deferred();
        if (Offline.state == "up") {
            var c = $(".fa-pencil-square-o").parent(0);
            if (c.is("a")) {
                $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
            }
            $(".fa-pencil-square-o").css("pointer-events", "none");
            $(".fa-pencil-square-o").attr("disabled", 'disabled');
            $(".fa-pencil-square-o").css("color", "#c0c0c0");
        }
        $("#btnSync").attr("class", "btn btn-xs btn-success");
        $("#btnSync").html("<i class='fa fa-spinner fa-spin'></i> Syncing..");
        var u = $('#hdnUserPrincipal').val();
        azureSync._syncing = 1;
        azureSync.SyncCirJson();
        azureSync.SyncMessages();
        azureSync.Push(u).done(function () {
            azureSync._syncing = 0;
            $("#btnSync").attr("class", "btn btn-xs btn-primary");
            SyncTime = _INTERVAL;
            UpdatedCIRStatus();
            CallClientApi("UserLastLogin/" + encodeURIComponent(u), "POST", null).done(function (rsp) {
            }).fail(function (err) {
            });
            try {
                if (window.location.href.indexOf("local-history") > 0) {
                    localHistory.loadLocalHistory();
                }
            } catch (e) { }
            deferredObject.resolve();
        }).fail(function () {
            _syncing = 0;
            deferredObject.reject();
        });
        return deferredObject.promise();
    }

    this.SyncMessages = function () {
        CallSyncApi('MessageData/GetAllNotReceived?receiver=' + encodeURIComponent(CurrentUserInfo.UserPrincipleName), "GET", '').done(function (response) {
            var messages = JSON.parse(response.response);
            $.each(messages, function (i, item) {
                NotifyCirMessage('', item.messageText, 'danger', 0);
            });
        });
    }

    this.SendMessage = function (receiver, messageText) {
        var message = {
            messageText: messageText,
            sender: CurrentUserInfo.UserPrincipleName,
            receiver: receiver,
        };
        CallSyncApi('MessageData/Send', "POST", message).done(function (response) {
        });
    }

    this.SyncCirJson = function () {
        azureSync.SyncCirReports($('#hdnUserPrincipal').val()).done(function (response) {
            var reports = response.result;
            var updateReportDeferreds = [];
            reports.updateClientCirs.forEach(function (item, index) {
                updateReportDeferreds.push(cirOfflineApp.SaveCirSchemaJsonWithData(item));
            });
            $.when.apply($, updateReportDeferreds).done(function () {
                var deleteReportDeferreds = [];
                reports.removeClientCirs.forEach(function (item, index) {
                    deleteReportDeferreds.push(cirOfflineApp.deleteNewCirLocalData(item));
                });
                $.when.apply($, deleteReportDeferreds).done(function () {
                    var reportsForAzure = [];
                    var reportDeferreds = [];
                    reports.resendCirs.forEach(function (item, index) {
                        reportDeferreds.push(cirOfflineApp.GetCirDataJsonById(item).done(function (loadedReport) {
                            reportsForAzure.push(loadedReport);
                        }));
                    });
                    $.when.apply($, reportDeferreds).done(function () {
                        azureSync.UpdateCirReports(reportsForAzure);
                    });
                });
            });
        });
    }

    this.StartSyncManual = function () {
        var deferredObject = $.Deferred();
        if (Offline.state == "up") {
            $(".fa-pencil-square-o").css("pointer-esvents", "none");
            $(".fa-pencil-square-o").attr("disabled", 'disabled');
            $(".fa-pencil-square-o").css("color", "#c0c0c0");
        }
        azureSync.StartSync().done(function () {
            deferredObject.resolve();
        }).fail(function () {
            deferredObject.reject();
        });
        return deferredObject.promise();
    }

    function UpdatedCIRStatus() {
        var CirIDs = [];
        cirOfflineApp.getCirLocalDataForCIRStatusUpdate().done(function (result) {
            $.each(result, function (i, item) {
                CirIDs.push({ CirDataLocalID: item.CirDataCommonID, CIRId: item.CirDataLocalID, CIRState: item.CirStatus });
            });
            CallClientApi("GetCirStateByCirIDs", "POST", CirIDs).done(function (data) {
                $.each(data, function (x, xitem) {
                    cirOfflineApp.findCirLocalData(xitem.cirDataLocalID).done(function (item) {
                        if (item.CirStatus != xitem.cirState) {
                            dbtransaction.addItemIntoTransactionTable(
                                {
                                    CirDataCommonID: item.CirDataCommonID,
                                    CirDataLocalID: item.CirDataLocalID,
                                    UpdateBy: item.UpdateBy,
                                    CreatedDate: item.CreatedDate,
                                    Status: item.Status,
                                    StatusMessage: item.StatusMessage,
                                    StatusDetailMessage: item.StatusDetailMessage,
                                    CirData: item.CirData,
                                    CirDataTemp: item.CirDataTemp,
                                    UserInitial: item.UserInitial,
                                    IsDirty: item.IsDirty,
                                    Deleted: item.Deleted,
                                    CirStatus: xitem.cirState, // Updated CIR Status
                                    RowVersion: item.RowVersion
                                }, 'CirDataCommon', function () {
                                });
                        }
                    });

                });

            }).fail(function () {

            });

        });



    }
    function falseSync() {
        for (i = 0; i <= 100000000; i++);
    }

    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    this.addCirToBlobSyncCirQueue = function (cirId) {
        let blobSyncCirQueue = JSON.parse(localStorage.getItem("blobSyncCirQueue"));
        if (!blobSyncCirQueue) {
            blobSyncCirQueue = [];
        }
        if (blobSyncCirQueue.filter(x => x.cirId == cirId).length == 0) {
            blobSyncCirQueue.push({ "cirId": cirId });
            localStorage.setItem("blobSyncCirQueue", JSON.stringify(blobSyncCirQueue));
        }
    }

    this.addCirToImageSyncQueue = function (cirId) {
        let cirQueue = JSON.parse(localStorage.getItem("cirQueue"));
        if (!cirQueue) {
            cirQueue = [];
        }
        if (cirQueue.filter(x => x.cirId == cirId).length == 0) {
            cirQueue.push({ "cirId": cirId, "Status": "Run" });
            localStorage.setItem("cirQueue", JSON.stringify(cirQueue));
        }
    }

    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    function eraseCookie(name) {
        createCookie(name, "", -1);
    }

    this.sticky_relocate = function () {
        var window_top = $(window).scrollTop();
        var div_top = $('#sticky-anchor').offset().top;
        if (window_top > div_top) {
            $('#sticky').addClass('stick');
            $('#sticky-anchor').height($('#sticky').outerHeight());
        } else {
            $('#sticky').removeClass('stick');
            $('#sticky-anchor').height(0);
        }
    }
}