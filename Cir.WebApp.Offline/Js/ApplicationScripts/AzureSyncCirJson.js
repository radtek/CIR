azureSync.SyncCirReports = function (userId) {
    const deferredObject = $.Deferred();
    cirOfflineApp.getCirDataJsonList().done(function (body) {
        let arr = body.map(function (c) {
            return {
                id: c.id,
                modifiedBy: c.modifiedBy,
                modifiedOn: c.modifiedOn,
                sqlProcessStatus: c.sqlProcessStatus,
                imageProcessStatus: c.imageProcessStatus,
                lockedBy: c.lockedBy,
                state: c.state,
                cirId: c.cirId,
                cirTemplateId: c.cirTemplateId,
                templateVersion: c.templateVersion,
                cirCollectionName: c.cirCollectionName,
                imageReferences: (c.state === "Draft" && (c.lockedBy === null || c.lockedBy === "")) ? c.imageReferences : null,
                deletedFromCache: c.deletedFromCache,
                //relatedCirs: c.relatedCirs,
                revisionHistory: c.revisionHistory,
                mailStatus: c.mailStatus
            }
        });
        CallSyncApi("CirSubmissionData/SyncRequest", "POST", arr).done(function (response) {
            deferredObject.resolve(response);
        });
    });

    return deferredObject.promise();
};

azureSync.UpdateCirReports = function (reportsForAzure) {
    const deferredObject = $.Deferred();

    reportsForAzure.forEach(function (report) {
        cirOfflineApp.GetCirDataJsonById(report.id).done(function (loadedReport) {
            CallSyncApi("CirSubmissionData/SyncUpdate", "POST", loadedReport).done(function (response) {
                cirOfflineApp.GetCirDataJsonById(report.id).done(function (cir) {
                    if (cir.cirId) {
                        cir.cirId = response.response;
                        cirOfflineApp.UpdateCirDataJson(cir);
                    }                    
                    
                    //if (cir.relatedCirs != undefined && cir.relatedCirs != null ) {

                    //    //var jsonData = JSON.parse(cir.relatedCirs);
                    //    var ids;       
                    //    if (cir.relatedCirs.length > 0) {
                    //        for (var i = 0; i < cir.relatedCirs.length; i++) {
                    //            ids = ids + "," + "'" + cir.relatedCirs[i].id + "'";
                    //        }
                    //        var birDataDetail = {
                    //            birDataID: "",
                    //            cirIds: ids.substring(10, ids.length),
                    //            rawMaterials: "",
                    //            conclusionsAndRecommendations: "",
                    //            repairingSolutions: "",
                    //            turbineID: cir.data.txtTurbineNumber,
                    //            createdBy: cir.createdBy
                    //        }
                    //        CallSyncApi("BirData/SaveBirData", "POST", birDataDetail).done(function (response) {
                    //            deferredObject.resolve(response);
                    //        }).fail(function () {
                    //            deferredObject.reject();
                    //        });
                    //    }
                    //}

                    azureSync.addCirToImageSyncQueue(cir.id);
                    deferredObject.resolve(response);
                });
            });
        });
    });

    return deferredObject.promise();
};
