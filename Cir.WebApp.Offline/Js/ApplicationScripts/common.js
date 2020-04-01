var isMobile = false; //initiate as false
function CallClientApi(url, method, jsonBody, IsSilent) {
    var deferredObject = $.Deferred();
    if (Offline.state == "down") {
        setTimeout(function () { deferredObject.reject('User offline'); }, 200)
    }
    else {
        UserCachingController.RefereshUser(false).done(function () {
            UpdateUserEmail();
            if (jsonBody || jsonBody != "") {
                console.log(jsonBody);
            }
            var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            currentuser.forEach(function (item) {
                                client.currentUser = item.objet;
                                client.authData = readCookie("__CirUserToken");// item.objet.mobileServiceAuthenticationToken; 
                            });
                            client.invokeApi(url, {
                                method: method,
                                body: jsonBody
                            }).done(function (response) {
                                deferredObject.resolve(response.result);
                            }, function (error) {
                                waitingDialog.hide();
                                console.log(error);
                                if (error && IsSilent != null && IsSilent == true)
                                    NotifyCirMessage('Error : ', error.message, 'danger');
                                deferredObject.reject(error);
                            });
                        }
                    }
                });
            });
        }).fail(function (error) {
            if (error == "NOTOKEN") {
                waitingDialog.hide();
                waitingDialog.show("No authentication token found locally");
            }
            waitingDialog.hide();
            deferredObject.reject(error);
        });
    }
    return deferredObject.promise();
}

var imageSyncInterval = null;

function finalizeSync(imagesSyncedCallback) {
    let cirQueue = JSON.parse(localStorage.getItem("cirQueue"));
    let currCirId = readCookie("_IsImageSyncingCookie");
    let currCir = cirQueue.filter(x => x.cirId == currCirId)[0];
    let index = cirQueue.indexOf(currCir);

    cirQueue.splice(index, 1);
    localStorage.setItem("cirQueue", JSON.stringify(cirQueue));
    createCookie("_IsImageSyncingCookie", 0);
    if (!!imageSyncInterval) {
        clearInterval(imageSyncInterval);
    }
    imagesSyncedCallback();
}

function callImageAPI(blobsList, cirInProgress, imagesSyncedCallback) {
    var synchronizing = false;
    var counter = 0;
    imageSyncInterval = setInterval(function () {
        if (synchronizing || counter >= blobsList.length) {
            return;
        }
        try {
            synchronizing = true;
            var currentBlob = blobsList[counter];
            createImageSyncData(currentBlob).done(function (requestData) {
                CallImageSyncApi(requestData.url, requestData.method, requestData.data).done(function (response) {
                    var model = response.result;
                    if (!cirInProgress.imageReferences) {
                        cirInProgress.imageReferences = [];
                    }
                    if (currentBlob.state.toLowerCase() == "deleted") {
                        var image = cirInProgress.imageReferences.filter(x => x.imageId === currentBlob.imageId);
                        if (image.length !== 0) {
                            cirInProgress.imageReferences.splice(cirInProgress.imageReferences.indexOf(image[0]), 1);
                        }
                    } else {
                        var blobAlreadySynced = cirInProgress.imageReferences.filter(function (ref) {
                            return ref.imageId === currentBlob.imageId;
                        }).length > 0;
                        if (!blobAlreadySynced) {
                            cirInProgress.imageReferences.push(model);
                        }
                    }
                    cirInProgress.modifiedBy = CurrentUserInfo.Name.toLowerCase();
                    cirInProgress.modifiedOn = new Date();
                    cirInProgress.imageProcessStatus = "Syncing";
                    cirOfflineApp.UpdateCirDataJson(cirInProgress).done(function () {
                        removeBlobFromQueue(currentBlob).done(function () {
                            if (counter < blobsList.length) {
                                counter++;
                            }
                            if (counter === blobsList.length) {
                                finalizeSync(imagesSyncedCallback);
                            }
                            synchronizing = false;
                        });
                    });
                }).fail(function (e) {
                    if (counter === blobsList.length) {
                        createCookie("_IsImageSyncingCookie", 0);
                        if (!!imageSyncInterval) {
                            clearInterval(imageSyncInterval);
                        }
                    }
                    synchronizing = false;
                });
            }).fail(function (e) {
                if (counter === blobsList.length) {
                    createCookie("_IsImageSyncingCookie", 0);
                    if (!!imageSyncInterval) {
                        clearInterval(imageSyncInterval);
                    }
                }
                synchronizing = false;
            });
        } catch (e) {
            if (counter === blobsList.length) {
                createCookie("_IsImageSyncingCookie", 0);
                if (!!imageSyncInterval) {
                    clearInterval(imageSyncInterval);
                }
            }
            synchronizing = false;
        }
    }, 1000);
}

function createImageSyncData(currentBlob) {
    let deferred = $.Deferred();
    let requestData = {};
    if (currentBlob.state.toLowerCase() === "deleted" || (!!currentBlob.url && !!currentBlob.binaryDataUrl)) {
        requestData.url = "BlobStorage/DeleteBlobAsync";
        requestData.method = "DELETE";
        requestData.data = JSON.stringify(currentBlob);
        deferred.resolve(requestData);
    }
    else if (currentBlob.state.toLowerCase() === "added") {
        requestData.url = "BlobStorage/UploadBlob";
        requestData.method = "POST";
        if (window.isElectronApp) {
            let blob = window.callElectronApp("Read", currentBlob.cirId, currentBlob.imageId);
            if (blob && blob.constructor.name == "Object") {
                requestData.data = Object.assign({}, currentBlob);
                requestData.data.binaryData = blob.binaryData;
                requestData.data = JSON.stringify(requestData.data);
                deferred.resolve(requestData);
            }
            else {
                deferred.reject();
            }
        } else {
            cirOfflineApp.GetBlob(currentBlob.imageId).done(function (imageBlob) {
                requestData.data = Object.assign({}, currentBlob);
                requestData.data.binaryData = imageBlob.binaryData;
                requestData.data = JSON.stringify(requestData.data);
                deferred.resolve(requestData);
            }).fail(function () {
                deferred.reject();
            });
        }

    }
    else {
        deferred.reject();
    }
    return deferred.promise();

}
function removeCirFromBlobSyncCirQueue(cirId) {
    let cirStorageQueue = localStorage.getItem("blobSyncCirQueue");
    let blobSyncCirQueue = cirStorageQueue ? JSON.parse(cirStorageQueue) : null;
    if (!!blobSyncCirQueue && blobSyncCirQueue.length > 0) {
        var removalIdx = blobSyncCirQueue.findIndex(function (obj) {
            return obj.cirId === cirId;
        });
        if (removalIdx < 0) {
            return;
        }
        blobSyncCirQueue.splice(removalIdx, 1);
        localStorage.blobSyncCirQueue = JSON.stringify(blobSyncCirQueue ? blobSyncCirQueue : []);
    }
    cirOfflineApp.DeleteCirImageBlobList(cirId);
}

function deleteImageSyncData(currentBlob) {
    let deferred = $.Deferred();
    let requestData = {};
    if (currentBlob.state.toLowerCase() === "deleted" || (!!currentBlob.url && !!currentBlob.binaryDataUrl)) {
        requestData.url = "BlobStorage/DeleteBlobAsync";
        requestData.method = "DELETE";
        requestData.data = JSON.stringify(currentBlob);
        deferred.resolve(requestData);
    }

    else {
        deferred.reject();
    }
    return deferred.promise();
}

function GetImageBlobList() {
    if (Offline.state == "up") {
        let cirStorageQueue = localStorage.getItem("blobSyncCirQueue");
        let blobSyncCirQueue = cirStorageQueue ? JSON.parse(cirStorageQueue) : null;
        if (!!blobSyncCirQueue) {
            let cirToRun = [blobSyncCirQueue[0]];
            if (cirToRun.length > 0 && !!cirToRun[0]) {
                cirOfflineApp.GetCirDataJsonById(cirToRun[0].cirId).done(function (cirInProgress) {
                    loadBlobs("Read", cirToRun[0].cirId).done(function (blobsList) {
                        UploadImageClient(blobsList, cirInProgress, GetImageBlobList).fail(function (response) {
                            updateJson(response);
                            removeCirFromBlobSyncCirQueue(response.id);
                            GetImageBlobList();
                        });
                    }).fail(function (_) {
                        removeCirFromBlobSyncCirQueue(cirToRun[0].cirId);
                        GetImageBlobList();
                    });
                }).fail(function (_) {
                    removeCirFromBlobSyncCirQueue(cirToRun[0].cirId);
                    GetImageBlobList();
                });
            } else {
                createCookie("_IsImageUploadingCookie", true);
            }
        } else {
            createCookie("_IsImageUploadingCookie", true);
        }
    }
}

function UploadImageClient(blobsList, cirInProgress, imagesSyncedCallback) {
    let deferred = $.Deferred();
    if (blobsList.length == 0) {
        removeCirFromBlobSyncCirQueue(cirInProgress.id);
        imagesSyncedCallback();
        return deferred.resolve(cirInProgress);
    }
    try {
        if (Offline.state == "up") {
            var functionAppUrl = $("#AzureFunctionsBaseUrl").val();
            var turbineNo = !cirInProgress.data.txtTurbineNumber ? 0 : cirInProgress.data.txtTurbineNumber;
            $.ajax({
                url: functionAppUrl + 'FetchBlobSASTokens',
                type: "GET",
                data: { "cirGuid": cirInProgress.id, "turbineNumber": turbineNo, "docType": "CIR" },
                crossDomain: true,
                success: function (response) {
                    UploadImageInBlob(blobsList, cirInProgress, response.sasKey, response.blobUri, response.containerName).done(function (imageReferenceModel, imageDataList, sasKey, BlobUri, containerName) {
                        UploadTxtInBlob(imageReferenceModel, imageDataList, sasKey, BlobUri, containerName).done(function (cirJson) {
                            if (!!cirJson.imageReferences && cirJson.imageReferences.length > 0) {
                                cirJson.imageReferences = _.uniq(cirJson.imageReferences, 'imageId');
                            }
                            if (!cirJson.sqlProcessStatus.includes("Error:")) {
                                if (!!cirJson && !(!cirJson.imageReferences || (!!cirJson.imageReferences && ((!!cirJson.data.imagecomponentKey && !!cirJson.data.imagecomponentKey.uploadedImagesCache && cirJson.imageReferences.length != cirJson.data.imagecomponentKey.uploadedImagesCache.length) || (!!cirJson.data.page3UploadImages && cirJson.imageReferences.length != cirJson.data.page3UploadImages.length))))) {
                                    cirJson.imageProcessStatus = "Synced";
                                    cirJson.sqlProcessStatus = NewCirSqlNotTransferred;
                                }
                                else if (!!cirJson && !!cirJson.data.page3UploadImages && !!cirJson.imageReferences && cirJson.data.page3UploadImages.length < cirJson.imageReferences.length) {
                                    var imageRefList = cirJson.imageReferences;
                                    for (var i = 0; i < imageRefList.length; i++) {
                                        var currentBlob = imageRefList[i];
                                        var image = cirJson.data.page3UploadImages.filter(x => x.imageId === currentBlob.imageId);
                                        if (image.length == 0) {
                                            cirJson.imageReferences.splice(cirJson.imageReferences.indexOf(imageRefList[i]), 1);
                                        }
                                    }
                                    cirJson.sqlProcessStatus = NewCirSqlNotTransferred;
                                    cirJson.imageProcessStatus = "Synced";
                                }
                                else if (!!cirJson && !!cirJson.data.imagecomponentKey && !!cirJson.data.imagecomponentKey.uploadedImagesCache && !!cirJson.imageReferences && cirJson.data.imagecomponentKey.uploadedImagesCache.length < cirJson.imageReferences.length) {
                                    var imageRefList = cirJson.imageReferences;
                                    for (var i = 0; i < imageRefList.length; i++) {
                                        var currentBlob = imageRefList[i];
                                        var image = cirJson.data.page3UploadImages.filter(x => x.imageId === currentBlob.imageId);
                                        if (image.length == 0) {
                                            cirJson.imageReferences.splice(cirJson.imageReferences.indexOf(imageRefList[i]), 1);
                                        }
                                    }
                                    cirJson.imageProcessStatus = "Synced";
                                    cirJson.sqlProcessStatus = NewCirSqlNotTransferred;
                                }
                                else {
                                    cirJson.sqlProcessStatus = "Error: image count mismatch";
                                    cirJson.imageProcessStatus = "NotSynced";
                                }
                            }
                            cirJson.modifiedBy = CurrentUserInfo.Name.toLowerCase();
                            cirJson.modifiedOn = new Date();
                            removeCirFromBlobSyncCirQueue(cirJson.id);
                            updateJson(cirJson);
                            imagesSyncedCallback();
                            deferred.resolve(cirJson);
                        }).fail(function (response) {
                            response.imageProcessStatus = "NotSynced";
                               deferred.reject(response);
                            synchronizing = false;
                        });
                    }).fail(function (response) {
                        response.imageProcessStatus = "NotSynced";
                         console.log("Images Upload Failed");
                        deferred.reject(response);
                    });
                },
                error: function (ex) {
                    cirInProgress.imageProcessStatus = "NotSynced";
                    deferred.reject(cirInProgress);
                }
            });
        }
    } catch (e) {
        cirInProgress.sqlProcessStatus = "Error: Exception in txt upload";
        deferred.reject(cirInProgress);
    }
    return deferred.promise();
}

function GetSyncImageBlob(cirGuid, imageId) {
    let deferred = $.Deferred();
    if (window.isElectronApp) {
        let blob = window.callElectronApp("Read", cirGuid, imageId);
        if (blob && blob.constructor.name == "Object") {
            deferred.resolve(blob);
        }
        else {
            deferred.reject();
        }
    } else {
        cirOfflineApp.GetBlob(imageId).done(function (imageBlob) {
            deferred.resolve(imageBlob);
        }).fail(function () {
            deferred.reject();
        });
    }
    return deferred.promise();
}
function updateJson(cirInProgress) {
    cirOfflineApp.UpdateCirDataJson(cirInProgress).done(function () {
        console.log("Json updated successfully");
    });
}

function getCirDataJsonByCirId(cirJson, imageId, extn) {
    var imageName = imageId;
    if (!!cirJson.data.page3UploadImages && cirJson.data.page3UploadImages.length > 0) {
        var cnt2 = cirJson.data.page3UploadImages.findIndex(x => x.imageId == imageId);
        if (cnt2 >= 0) {
            imageName = cirJson.data.page3UploadImages[cnt2].fileInfo.name;
        }
    } else if (!!cirJson.data.imagecomponentKey && !!cirJson.data.imagecomponentKey.uploadedImagesCache && cirJson.data.imagecomponentKey.uploadedImagesCache.length > 0) {
        var cnt3 = cirJson.data.imagecomponentKey.uploadedImagesCache.findIndex(x => x.imageId == imageId);
        if (cnt3 >= 0) {
            imageName = cirJson.data.imagecomponentKey.uploadedImagesCache[cnt3].imageName;
        }
    }
    if (cirJson.sqlProcessStatus.includes("Error:")) {
        cirJson.sqlProcessStatus += ", " + imageName;
    }
    else {
        cirJson.sqlProcessStatus = "Error: These image files are not transfered to storage: " + imageName ;
    }
    cirJson.imageProcessStatus = "NotSynced";
    return cirJson;
}

function UpdateJsonAfterImageDeleted(blobsList, cirInProgress, imagesSyncedCallback) {
    var synchronizing = false;
    var counter = 0;
    imageSyncInterval = setInterval(function () {
        if (synchronizing || counter >= blobsList.length) {
            return;
        }
        try {
            synchronizing = true;
            var currentBlob = blobsList[counter];
            deleteImageSyncData(currentBlob).done(function (requestData) {
                CallImageSyncApi(requestData.url, requestData.method, requestData.data).done(function (response) {
                    var model = response.result;
                    if (!cirInProgress.imageReferences) {
                        cirInProgress.imageReferences = [];
                    }
                    if (currentBlob.state.toLowerCase() == "deleted") {

                        var image = cirInProgress.imageReferences.filter(x => x.imageId === currentBlob.imageId);
                        if (image.length !== 0) {
                            cirInProgress.imageReferences.splice(cirInProgress.imageReferences.indexOf(image[0]), 1);
                        }
                    }
                    cirInProgress.modifiedBy = CurrentUserInfo.Name.toLowerCase();
                    cirInProgress.modifiedOn = new Date();
                    //cirInProgress.imageProcessStatus = "Syncing";
                    cirOfflineApp.UpdateCirDataJson(cirInProgress).done(function () {

                        removeBlobFromQueue(currentBlob).done(function () {
                            if (counter < blobsList.length) {
                                counter++;
                            }
                            if (counter === blobsList.length) {
                                finalizeSync(imagesSyncedCallback);
                            }
                            synchronizing = false;
                        });
                    });
                }).fail(function (e) {
                    if (counter === blobsList.length) {
                        if (!!imageSyncInterval) {
                            clearInterval(imageSyncInterval);
                        }
                    }
                    synchronizing = false;
                });
            }).fail(function (e) {
                if (counter === blobsList.length) {
                    if (!!imageSyncInterval) {
                        clearInterval(imageSyncInterval);
                    }
                }
                synchronizing = false;
            });
        } catch (e) {
            if (counter === blobsList.length) {
                if (!!imageSyncInterval) {
                    clearInterval(imageSyncInterval);
                }
            }
            synchronizing = false;
        }
    }, 800);
}

function CopyBlob(imageReferences, turbineNumber, cirId) {
    let deferred = $.Deferred();
    let imageRef = imageReferences.filter(x => x.url.split('/')[4] != turbineNumber);
    if (imageRef.length > 0) {
        var functionAppUrl = $("#AzureFunctionsBaseUrl").val();
        $.ajax({
            url: functionAppUrl + 'FetchBlobSASTokens',
            type: "GET",
            data: { "cirGuid": cirId, "turbineNumber": turbineNumber, "docType": "CIR" },
            crossDomain: true,
            success: function (response) {
                var blobService = AzureStorage.Blob.createBlobServiceWithSas(response.blobUri, response.sasKey).withFilter(new AzureStorage.Blob.ExponentialRetryPolicyFilter());
                var synchronizing = false;
                var numb = 0;
                var responseCounter = 0;
                var imageDataList = [];
                imageSyncTimer = setInterval(function () {
                    if (synchronizing || numb >= imageRef.length) {
                        return;
                    }
                    imageRef[numb].turbineNumber = !!imageRef[numb].turbineNumber ? imageRef[numb].turbineNumber : 0;
                    var imgData = [];
                    if (imageRef[numb].url.split('/')[4] != turbineNumber) {
                        try {
                            synchronizing = true;
                            var sourceUri = imageRef[numb].url + response.sasKey;
                            var targetContainer = response.containerName.Name;
                            var targetBlob = turbineNumber + "/CIR/" + cirId + "/Images/" + imageRef[numb].imageId + ".jpeg";
                            imgData.imageId = imageRef[numb].imageId;
                            var imageId = imageRef[numb].imageId;
                            imgData.turbineNumber = turbineNumber;
                            var splitUrl = imageRef[numb].url.split('/');
                            splitUrl[4] = turbineNumber;
                            imgData.oldTextUrl = imageRef[numb].binaryDataUrl + response.sasKey;
                            imgData.newUrl = splitUrl.join("/");
                            imgData.newTextUrl = imgData.newUrl.replace("jpeg", "txt");
                            imgData.targetContainer = response.containerName.Name;
                            imgData.targetTextBlob = turbineNumber + "/CIR/" + cirId + "/Images/" + imageRef[numb].imageId + ".txt";
                            imageDataList.push(imgData);
                            blobService.startCopyBlob(sourceUri, targetContainer, targetBlob, function (error, result, response) {
                                if (error) {
                                    console.log('copy error');
                                    if (responseCounter == imageRef.length) {
                                        $.each(imageReferences, function (key, value) {
                                            var exists = false;
                                            $.each(imageRef, function (k, val2) {
                                                if (value.imageId == val2.imageId) { exists = true };
                                            });
                                            if (exists == false && value.imageId != "") { imageRef.push(value); }
                                        });
                                        deferred.resolve(imageRef);
                                    }
                                }
                                else {
                                    var copiedImgData = imageDataList.filter(x => x.imageId == imageId);
                                    var imgId = imageId;
                                    blobService.startCopyBlob(copiedImgData[0].oldTextUrl, imgData.targetContainer, imgData.targetTextBlob, function (error, result, response) {
                                        responseCounter++;
                                        if (error) {
                                            console.log('copy error');
                                            if (responseCounter == imageRef.length) {
                                                $.each(imageReferences, function (key, value) {
                                                    var exists = false;
                                                    $.each(imageRef, function (k, val2) {
                                                        if (value.imageId == val2.imageId) { exists = true };
                                                    });
                                                    if (exists == false && value.imageId != "") { imageRef.push(value); }
                                                });
                                                deferred.resolve(imageRef);
                                            }
                                        }
                                        else {
                                            console.log('copy success');
                                            var copiedImgData = imageDataList.filter(x => x.imageId == imgId);
                                            var index = imageRef.findIndex(x => x.imageId == copiedImgData[0].imageId);
                                            imageRef[index].turbineNumber = copiedImgData[0].turbineNumber;
                                            imageRef[index].url = imgData.newUrl;
                                            imageRef[index].binaryDataUrl = imgData.newTextUrl;
                                            if (responseCounter == imageRef.length) {
                                                $.each(imageReferences, function (key, value) {
                                                    var exists = false;
                                                    $.each(imageRef, function (k, val2) {
                                                        if (value.imageId == val2.imageId) { exists = true };
                                                    });
                                                    if (exists == false && value.imageId != "") { imageRef.push(value); }
                                                });
                                                imageRef = _.uniq(imageRef, 'imageId');
                                                deferred.resolve(imageRef);
                                            }
                                        }
                                    });
                                }
                            });
                            if (numb < imageRef.length) {
                                numb++;
                                synchronizing = false;
                            }
                        }
                        catch (e) {
                            if (numb === imageRef.length) {
                                if (!!imageSyncTimer) {
                                    clearInterval(imageSyncTimer);
                                }
                            }
                            synchronizing = false;
                        }
                    }
                    else {
                        numb++;
                        responseCounter++;
                        synchronizing = false;
                        if (responseCounter == imageRef.length) {
                            deferred.resolve(imageRef);
                        }
                    }
                }, 800);
            },
            error: function (ex) {
                deferred.reject(ex);
            }
        });
    }
    else {
        deferred.resolve(imageReferences);
    }
    return deferred.promise();
}

function UploadImageInBlob(imageBloblist, cirInProgress, sasKey, blobUri, containerName) {
    var synchronizing = false;
    var numb = 0;
    var responseCounter = 0;
    let deferred = $.Deferred();
    var imageDataList = [];
    imageSyncTimer = setInterval(function () {
        if (synchronizing || numb >= imageBloblist.length) {
            return;
        }
        try {
            synchronizing = true;
            var cirId = cirInProgress.id;
            var turbineNumber = cirInProgress.data.txtTurbineNumber;
            var templateId = cirInProgress.cirTemplateId;
            turbineNumber = !turbineNumber ? 0 : turbineNumber;
            var imageBlobData = imageBloblist[numb];
            var blobService = AzureStorage.Blob.createBlobServiceWithSas(blobUri, sasKey).withFilter(new AzureStorage.Blob.ExponentialRetryPolicyFilter());
            GetSyncImageBlob(cirId, imageBlobData.imageId).done(function (imageBlob) {
                //if (imageBlob.binaryData.length > 0) {
                var imageName = imageBlob.imageId;
                var splitBinaryData = imageBlob.binaryData.indexOf(',');
                var textdata = imageBlob.binaryData.substring(splitBinaryData + 1, imageBlob.binaryData.length);

                //Image file Creation from datastring
                var bs = atob(textdata);
                var buffer = new ArrayBuffer(bs.length);
                var ba = new Uint8Array(buffer);
                for (var i = 0; i < bs.length; i++) {
                    ba[i] = bs.charCodeAt(i);
                }
                var blob = new Blob([ba], { type: "image/jpeg" });
                var file = new File([blob], imageName + ".jpeg", { type: "image/jpeg" });
                var path = turbineNumber + "/CIR/" + cirId + "/Images/" + imageName + ".jpeg"; // "CIR/{blobData.CirId}/{blobType}/{blobData.BlobGuid}.{blobData.ContentType}";

                var customBlockSize = file.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
                blobService.singleBlobPutThresholdInBytes = customBlockSize;
                //End

                blobService.createBlockBlobFromBrowserFile(containerName.Name, path, file, { blockSize: customBlockSize }, function (error, result, response) {
                    responseCounter++;
                    if (error) {
                        cirInProgress = getCirDataJsonByCirId(cirInProgress, imageName, 'jpeg');
                        var imgId = imageName;
                        if (!!cirInProgress.data.page3UploadImages && cirInProgress.data.page3UploadImages.length > 0) {
                            var cnt2 = cirInProgress.data.page3UploadImages.findIndex(x => x.imageId == imgId);
                            if (cnt2 >= 0) {
                                cirInProgress.data.page3UploadImages.splice(cnt2, 1);
                            }
                        } else if (!!cirInProgress.data.imagecomponentKey && !!cirInProgress.data.imagecomponentKey.uploadedImagesCache && cirInProgress.data.imagecomponentKey.uploadedImagesCache.length > 0) {
                            var cnt1 = cirInProgress.data.imagecomponentKey.uploadedImagesCache.findIndex(x => x.imageId == imgId);
                            if (cnt1 >= 0) {
                                cirInProgress.data.imagecomponentKey.uploadedImagesCache.splice(cnt1, 1);
                            }
                            if (!!cirInProgress.data.imagecomponentKey.plate && !!cirInProgress.data.imagecomponentKey.plate.imageId) {
                                if (cirInProgress.data.imagecomponentKey.plate.imageId == imgId) {
                                    cirInProgress.data.imagecomponentKey.plate = {};
                                }
                            }
                            if (!!cirInProgress.data.imagecomponentKey.sections) {
                                for (var i = 1; i <= 12; i++) {
                                    if (cirInProgress.data.imagecomponentKey.sections["section" + i]) {
                                        var cnt3 = cirInProgress.data.imagecomponentKey.sections["section" + i].images.findIndex(x => x.imageId == imgId);
                                        if (cnt3 >= 0) {
                                            cirInProgress.data.imagecomponentKey.sections["section" + i].images.splice(cnt3, 1);
                                        }
                                    }
                                }
                            }
                        }
                        if (responseCounter == imageBloblist.length) {
                            if (cirInProgress.imageReferences && cirInProgress.imageReferences.length > 0) {
                                deferred.resolve(cirInProgress,imageDataList, sasKey, blobUri, containerName.Name);
                            } else { deferred.reject(cirInProgress,imageDataList, sasKey, blobUri, containerName.Name); }
                        }
                    } else {
                        if (!cirInProgress.imageReferences) {
                            cirInProgress.imageReferences = [];
                        }
                        var imageData = [];
                        imageData.imageId = imageName;
                        imageData.binaryData = imageBlob.binaryData;
                        imageDataList.push(imageData);
                        var indxImage = cirInProgress.imageReferences.findIndex(x => x.imageId == imageName);
                        if (indxImage == -1) {
                            var responseData = {
                                imageId: imageName,
                                blobGuid: imageName,
                                cirId: cirId,
                                templateId: templateId,
                                url: blobUri + containerName.Name + "/" + turbineNumber + "/CIR/" + cirId + "/Images/" + imageName + ".jpeg",
                                contentType: "jpeg",
                                turbineNumber: turbineNumber,
                                flangeNo: "",
                                imageDescription: "",
                                binaryData: ''
                            };
                            cirInProgress.imageReferences.push(responseData);
                        } else {
                            var cirimg = cirInProgress.imageReferences[indxImage];
                            cirimg.turbineNumber = turbineNumber;
                            cirimg.url = blobUri + containerName.Name + "/" + turbineNumber + "/CIR/" + cirId + "/Images/" + imageName + ".jpeg";
                            cirimg.binaryData = '';
                        }
                        cirInProgress.modifiedOn = new Date();
                        if (responseCounter == imageBloblist.length) {
                            deferred.resolve(cirInProgress,imageDataList, sasKey, blobUri, containerName.Name);
                        }
                    }
                });
                //}
                if (numb < imageBloblist.length) {
                    numb++;
                }
                synchronizing = false;
            });
            // }
        } catch (e) {
            if (numb === imageBloblist.length) {
                if (!!imageSyncTimer) {
                    clearInterval(imageSyncTimer);
                }
            }
            synchronizing = false;
        }
    }, 800);
    return deferred.promise();
}

function UploadTxtInBlob(cirJson, imageDataList, sasKey, blobUri, containerName) {
    var synchronizing = false;
    var numb = 0;
    var index = 0;
    var isError = false;
    let deferred = $.Deferred();
    if (!!cirJson.imageReferences) {
        var imageRefCount = imageDataList.filter(function (obj) {
            return obj.binaryData != "";
        }).length;

        if (imageRefCount == 0) {
            return deferred.resolve(cirJson);
        }
        
        imageSyncTimer = setInterval(function () {
            if (synchronizing || numb >= cirJson.imageReferences.length) {
                return;
            }

            try {
                synchronizing = true;
                var responseData = cirJson.imageReferences[numb];
                var dataIndex = imageDataList.findIndex(x => x.imageId == responseData.imageId);
                if (dataIndex >= 0 && imageDataList[dataIndex].binaryData != "" && (!responseData.binaryDataUrl || responseData.binaryDataUrl.indexOf(".txt") < 0)) {
                    var blobService = AzureStorage.Blob.createBlobServiceWithSas(blobUri, sasKey).withFilter(new AzureStorage.Blob.ExponentialRetryPolicyFilter());
                    var textdata = imageDataList[dataIndex].binaryData.replace('data:image/jpeg;base64,', '');
                    //txt file creation from datastring
                    var txtName = responseData.imageId;
                    var turbineNumber = !responseData.turbineNumber ? 0 : responseData.turbineNumber;
                    var cirId = responseData.cirId;
                    var textblob = new Blob([textdata], { type: "text/plain" });
                    var txtfile = new File([textblob], responseData.imageId + ".txt", { type: "text/plain" });
                    var path = responseData.turbineNumber + "/CIR/" + responseData.cirId + "/Images/" + responseData.imageId + ".txt";
                    var customBlockSize = txtfile.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
                    blobService.singleBlobPutThresholdInBytes = customBlockSize;
                    blobService.createBlockBlobFromBrowserFile(containerName, path, txtfile, { blockSize: customBlockSize }, function (error, result, response) {
                        index++;
                        if (error) {
                            isError = true;
                            var imgId = txtName;
                            var count = cirJson.imageReferences.findIndex(x => x.imageId == imgId);
                            if (count >= 0) {
                                cirJson.imageReferences.splice(count, 1);
                            }
                            if (!!cirJson.data.page3UploadImages && cirJson.data.page3UploadImages.length > 0) {
                                var cnt2 = cirJson.data.page3UploadImages.findIndex(x => x.imageId == imgId);
                                if (cnt2 >= 0) {
                                    cirJson.data.page3UploadImages.splice(cnt2, 1);
                                }
                            } else if (!!cirJson.data.imagecomponentKey && !!cirJson.data.imagecomponentKey.uploadedImagesCache && cirJson.data.imagecomponentKey.uploadedImagesCache.length > 0) {
                                var cnt1 = cirJson.data.imagecomponentKey.uploadedImagesCache.findIndex(x => x.imageId == imgId);
                                if (cnt1 >= 0) {
                                    cirJson.data.imagecomponentKey.uploadedImagesCache.splice(cnt1, 1);
                                }
                                if (!!cirJson.data.imagecomponentKey.plate && !!cirJson.data.imagecomponentKey.plate.imageId) {
                                    if (cirJson.data.imagecomponentKey.plate.imageId == imgId) {
                                        cirJson.data.imagecomponentKey.plate = {};
                                    }
                                }
                                if (!!cirJson.data.imagecomponentKey.sections) {
                                    for (var i = 1; i <= 12; i++) {
                                        if (cirJson.data.imagecomponentKey.sections["section" + i]) {
                                            var cnt3 = cirJson.data.imagecomponentKey.sections["section" + i].images.findIndex(x => x.imageId == imgId);
                                            if (cnt3 >= 0) {
                                                cirJson.data.imagecomponentKey.sections["section" + i].images.splice(cnt3, 1);
                                            }
                                        }
                                    }
                                }
                            }
                            cirJson = getCirDataJsonByCirId(cirJson, txtName, 'txt');//Update error in cirdatajson.
                            removeImageBlobList(responseData.cirId, txtName);
                        } else {
                            var count = cirJson.imageReferences.findIndex(x => x.imageId == txtName);//result.name.split('/')[4].split('.')[0]);
                            cirJson.imageReferences[count].binaryData = '';
                            cirJson.imageReferences[count].binaryDataUrl = blobUri + containerName + "/" + turbineNumber + "/CIR/" + cirId + "/Images/" + txtName + ".txt";//blobUri + result.container + "/" + result.name;
                            cirJson.imageReferences[count].binaryContentType = "txt";
                            removeImageBlobList(responseData.cirId, responseData.imageId);
                        }
                        if (index == imageRefCount) {
                            if (isError) {
                                cirOfflineApp.DeleteCirImageBlobList(responseData.cirId).done(function () {
                                    deferred.reject(cirJson);
                                });
                            } else {
                                cirOfflineApp.DeleteCirImageBlobList(responseData.cirId).done(function () {
                                    deferred.resolve(cirJson);
                                });
                            }
                        }

                    });
                }
                if (numb < imageRefCount) {
                    numb++;
                }
                if (numb === imageRefCount) {
                    if (!!imageSyncTimer) {
                        clearInterval(imageSyncTimer);
                    }
                }
                synchronizing = false;
                // }
            } catch (e) {
                if (numb === imageRefCount) {
                    if (!!imageSyncTimer) {
                        clearInterval(imageSyncTimer);
                    }
                    deferred.reject(cirJson);
                }
                synchronizing = false;
            }
        }, 800);
    } else {
        deferred.resolve(cirJson);
    }
    return deferred.promise();
}

function GetBlobPath(cirId, turbineNumber) {
    let deferred = $.Deferred();
    try {
        if (Offline.state == "up") {
            turbineNumber = !turbineNumber ? 0 : turbineNumber;
            var functionAppUrl = $("#AzureFunctionsBaseUrl").val();
            $.ajax({
                url: functionAppUrl + 'FetchBlobSASTokens',
                type: "GET",
                data: { "cirGuid": cirId, "turbineNumber": turbineNumber, "docType": "CIR" },
                crossDomain: true,
                success: function (response) {
                    deferred.resolve(response);
                },
                error: function (ex) {
                    deferred.reject(ex);
                }
            }); 
        }
        else { deferred.resolve(true); }
    } catch (e) {
        console.log("Txt Upload Failed");
        deferred.reject(e);
    }
    return deferred.promise();
}

function UploadImageClientOnline(blobsList, imageReferences, turbineNumber, cirId, templateId, response) {
    let deferred = $.Deferred();
    if (blobsList.length == 0) {
        return deferred.resolve(imageReferences);
    }
    try {
        if (Offline.state == "up") {
            UploadImageInBlobOnline(blobsList, imageReferences, cirId, turbineNumber, templateId, response.sasKey, response.blobUri, response.containerName).done(function (imageReferenceModel, sasKey, BlobUri, containerName) {
                UploadTxtInBlobOnline(imageReferenceModel, sasKey, BlobUri, containerName).done(function (imageReferenceModel) {
                    if (!!imageReferenceModel && imageReferenceModel.length > 0) {
                        imageReferenceModel = _.uniq(imageReferenceModel, 'imageId');
                    }
                    deferred.resolve(imageReferenceModel);
                }).fail(function (response) {
                    console.log("Txt Upload Failed");
                    deferred.reject(response);
                });
            }).fail(function (response) {
                console.log("Image Upload Failed");
                deferred.reject(response);
            });
        }
    } catch (e) {
        console.log("Txt Upload Failed");
        deferred.reject(e);
    }
    return deferred.promise();
}

function UploadImageInBlobOnline(imageBloblist, imageReferences, cirId, turbineNumber, templateId, sasKey, blobUri, containerName) {
    var synchronizing = false;
    var numb = 0;
    var responseCounter = 0;
    var imageReferences = [];
    let deferred = $.Deferred();
    imageSyncTimer = setInterval(function () {
        if (synchronizing || numb >= imageBloblist.length) {
            return;
        }
        try {
            synchronizing = true;
            turbineNumber = !turbineNumber ? 0 : turbineNumber;
            var imageBlobData = imageBloblist[numb];
            var blobService = AzureStorage.Blob.createBlobServiceWithSas(blobUri, sasKey).withFilter(new AzureStorage.Blob.ExponentialRetryPolicyFilter());
            var imageName = imageBlobData.imageId;
            var splitBinaryData = imageBlobData.binaryData.indexOf(',');
            var textdata = imageBlobData.binaryData.substring(splitBinaryData + 1, imageBlobData.binaryData.length);

            //Image file Creation from datastring
            var bs = atob(textdata);
            var buffer = new ArrayBuffer(bs.length);
            var ba = new Uint8Array(buffer);
            for (var i = 0; i < bs.length; i++) {
                ba[i] = bs.charCodeAt(i);
            }
            var blob = new Blob([ba], { type: "image/jpeg" });
            var file = new File([blob], imageName + ".jpeg", { type: "image/jpeg" });
            var path = turbineNumber + "/CIR/" + cirId + "/Images/" + imageName + ".jpeg"; // "CIR/{blobData.CirId}/{blobType}/{blobData.BlobGuid}.{blobData.ContentType}";

            var customBlockSize = file.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
            blobService.singleBlobPutThresholdInBytes = customBlockSize;
            //End


            blobService.createBlockBlobFromBrowserFile(containerName.Name, path, file, { blockSize: customBlockSize }, function (error, result, response) {
                responseCounter++;
                if (error) {
                    if (responseCounter == imageBloblist.length) {
                        if (imageReferences.length > 0) {
                            deferred.resolve(imageReferences, sasKey, blobUri, containerName.Name);
                        } else { deferred.reject(imageReferences, sasKey, blobUri, containerName.Name); }
                    }
                } else {
                    var responseData = {
                        imageId: imageName,
                        blobGuid: imageName,
                        cirId: cirId,
                        templateId: templateId,
                        url: blobUri + containerName.Name + "/" + turbineNumber + "/CIR/" + cirId + "/Images/" + imageName + ".jpeg",// result.container + "/" + result.name,
                        contentType: "jpeg",
                        turbineNumber: turbineNumber,
                        flangeNo: "",
                        imageDescription: "",
                        binaryData: imageBlobData.binaryData
                    };
                    //if (!imageReferences) {
                    //    imageReferences = [];
                    //}
                    imageReferences.push(responseData);
                    if (responseCounter == imageBloblist.length) {
                        deferred.resolve(imageReferences, sasKey, blobUri, containerName.Name);
                    }
                }
            });
            if (numb < imageBloblist.length) {
                waitingDialog.show('Uploading Images..', { dialogSize: 'sm', progressType: 'primary' });
                numb++;
            }
            synchronizing = false;
            // }
        } catch (e) {
            if (numb === imageBloblist.length) {
                if (!!imageSyncTimer) {
                    clearInterval(imageSyncTimer);
                }
            }
            synchronizing = false;
        }
    }, 800);
    return deferred.promise();
}

function UploadTxtInBlobOnline(imageReferenceModel, sasKey, blobUri, containerName) {
    var synchronizing = false;
    var numb = 0;
    var index = 0;
    let deferred = $.Deferred();
    if (!!imageReferenceModel) {
        if (imageReferenceModel.length == 0) {
            return deferred.resolve(imageReferenceModel);
        }
        imageSyncTimer = setInterval(function () {
            if (synchronizing || numb >= imageReferenceModel.length) {
                return;
            }
            try {
                synchronizing = true;
                //for (var numb = 0; numb < imageReferenceModel.length; numb++) {
                var responseData = imageReferenceModel[numb];
                var blobService = AzureStorage.Blob.createBlobServiceWithSas(blobUri, sasKey).withFilter(new AzureStorage.Blob.ExponentialRetryPolicyFilter());
                var textdata = responseData.binaryData.replace('data:image/jpeg;base64,', ''); 
                //txt file creation from datastring
                var txtName = responseData.imageId;
                var turbineNumber = !responseData.turbineNumber ? 0 : responseData.turbineNumber;
                var cirId = responseData.cirId;
                var textblob = new Blob([textdata], { type: "text/plain" });
                var txtfile = new File([textblob], responseData.imageId + ".txt", { type: "text/plain" });
                var path = responseData.turbineNumber + "/CIR/" + responseData.cirId + "/Images/" + responseData.imageId + ".txt";
                var customBlockSize = txtfile.size > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
                blobService.singleBlobPutThresholdInBytes = customBlockSize;

                blobService.createBlockBlobFromBrowserFile(containerName, path, txtfile, { blockSize: customBlockSize }, function (error, result, response) {
                    index++;
                    if (error) {
                        if (index == imageReferenceModel.length) {
                            deferred.reject(imageReferenceModel);
                        }
                    } else {
                        var count = imageReferenceModel.findIndex(x => x.imageId == txtName);//result.name.split('/')[4].split('.')[0]);
                        imageReferenceModel[count].binaryData = '';
                        imageReferenceModel[count].binaryDataUrl = blobUri + containerName + "/" + turbineNumber + "/CIR/" + cirId + "/Images/" + txtName + ".txt";//result.container + "/" + result.name;
                        imageReferenceModel[count].binaryContentType = "txt";
                        if (index == imageReferenceModel.length) {
                            deferred.resolve(imageReferenceModel);
                        }
                    }

                });
                if (numb < imageReferenceModel.length) {
                    waitingDialog.show('Uploading Images..', { dialogSize: 'sm', progressType: 'primary' });
                    numb++;
                }
                //}
                synchronizing = false;
                // }
            } catch (e) {
                if (numb === imageReferenceModel.length) {
                    if (!!imageSyncTimer) {
                        clearInterval(imageSyncTimer);
                    }
                }
                synchronizing = false;
            }
        }, 800);
    } else {
        deferred.resolve(imageReferenceModel);
    }
    return deferred.promise();
}

function removeBlobFromQueue(currBlob) {
    var deferred = $.Deferred();
    cirOfflineApp.GetCirImageBlobList(currBlob.cirId)
        .done(function (blobInfo) {
            cirOfflineApp.GetCirDataJsonById(currBlob.cirId).done(function (cir) {
                let remainedBlobList = blobInfo.blobList;
                let currImageBlob = remainedBlobList.filter(x => x.cirId == currBlob.cirId && x.imageId == currBlob.imageId)[0];
                if ((!currImageBlob || cir.imageReferences.findIndex(x => x.imageId == currBlob.imageId) == -1) && currBlob.state.toLowerCase() == "added") {
                    deferred.resolve();
                    return;
                }
                remainedBlobList.splice(remainedBlobList.indexOf(currImageBlob), 1);

                cirOfflineApp.SaveImageblobList({ 'cirId': currBlob.cirId, 'blobList': remainedBlobList, 'initialCount': blobInfo.initialCount, 'turbineNumber': cir.data.txtTurbineNumber }).done(function () {
                    if (window.isElectronApp && currBlob.state.toLowerCase() == "added") {
                        window.callElectronApp("RemoveSyncedImage", currBlob.cirId, currBlob.imageId);
                        deferred.resolve();
                    } else if (currBlob.state.toLowerCase() == "added") {
                        cirOfflineApp.DeleteBlob(currBlob.imageId).done(function () {
                            deferred.resolve();
                        });
                    } else {
                        cirOfflineApp.GetBlob(currBlob.imageId).done(function (imageBlob) {
                            cirOfflineApp.DeleteBlob(currBlob.imageId).done(function () {
                            });
                        });
                        cirOfflineApp.GetImageThumbnails(currBlob.cirId).done(function (thumbnails) {
                            let removedBlob = thumbnails.filter(x => x.imageId === currBlob.imageId);
                            if (!removedBlob || removedBlob.length === 0) {
                                deferred.resolve();
                                return;
                            }
                            thumbnails.splice(thumbnails.indexOf(removedBlob[0]), 1);
                            cirOfflineApp.SaveImageThumbnails(currBlob.cirId, thumbnails).done(function () {
                                deferred.resolve();
                            });
                        });
                    }
                });
            });
        });
    return deferred.promise();
}

function removeImageBlobList(cirId, imageId) {
    var deferred = $.Deferred();
    cirOfflineApp.GetCirImageBlobList(cirId)
        .done(function (blobInfo) {
            //    cirOfflineApp.GetCirDataJsonById(cirId).done(function (cir) {
            let remainedBlobList = blobInfo.blobList;
            let currImageBlob = remainedBlobList.filter(x => x.cirId == cirId && x.imageId == imageId)[0];
            remainedBlobList.splice(remainedBlobList.indexOf(currImageBlob), 1);
            cirOfflineApp.SaveImageblobList({ 'cirId': cirId, 'blobList': remainedBlobList, 'initialCount': blobInfo.initialCount }).done(function () {
                if (window.isElectronApp) {
                    window.callElectronApp("RemoveSyncedImage", cirId, imageId);
                    deferred.resolve();
                } else {
                    cirOfflineApp.DeleteBlob(imageId).done(function () {
                        deferred.resolve();
                    });
                }
            });
            //  });
        }).fail(function () {
            cirOfflineApp.DeleteBlob(imageId).done(function () {
                deferred.resolve();
            });
        });
    //cirOfflineApp.DeleteCirImageBlobList(cirId).done(function () {
    //    deferred.resolve();
    //});
    return deferred.promise();
}

function loadBlobs(operationName, cirId) {
    let deferred = $.Deferred();
    cirOfflineApp.GetCirImageBlobList(cirId)
        .done(function (blobList) {
            deferred.resolve(blobList.blobList);
        })
        .fail(function () {
            deferred.reject();
        });
    return deferred.promise();
}

function loadAllCIRImageBlobs(operationName) {
    let deferred = $.Deferred();
    cirOfflineApp.GetAllCirImageBlobList()
        .done(function (cirImageblobList) {
            deferred.resolve(cirImageblobList);
        })
        .fail(function () {
            deferred.reject();
        });
    return deferred.promise();
}

function CallImageSyncApi(url, method, jsonBody) {
    var deferredImgObject = $.Deferred();
    if (Offline.state == "down") {
        setTimeout(function () { deferredImgObject.reject('User offline'); }, 200)
    }
    else {
        var MobileServiceClient = new WindowsAzure.MobileServiceClient($('#FormIOMobileAppUrl').val(), $('#FormIOMobileAppId').val(), '');
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CurrentUserFormio', function CurrentUser(currentuser) {
                if (currentuser) {
                    if (currentuser.length > 0) {
                        currentuser.forEach(function (item) {
                            MobileServiceClient.currentUser = item.objet;
                        });
                        MobileServiceClient.invokeApi(url, {
                            method: method,
                            body: jsonBody
                        }).done(function (response) {
                            deferredImgObject.resolve(response);
                        }, function (error) {
                            if (url == "BlobStorage/DeleteBlobAsync") {
                                deferredImgObject.resolve(jsonBody);
                            }
                            else {
                                console.log(error);
                                deferredImgObject.reject(error);
                            }
                        });
                    }
                } else {
                    deferredImgObject.reject();
                }
            });
        });
    }
    return deferredImgObject.promise();
}

function CallSyncApi(url, method, jsonBody) {
    var deferredObject = $.Deferred();
    if (Offline.state == "down") {
        setTimeout(function () { deferredObject.reject('User offline'); }, 200)
    }
    else {
        UserCachingController.RefereshUser(false).done(function () {
            UpdateUserEmail();

            var MobileServiceClient = new WindowsAzure.MobileServiceClient($('#FormIOMobileAppUrl').val(), $('#FormIOMobileAppId').val(), '');
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('CurrentUserFormio', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            currentuser.forEach(function (item) {
                                MobileServiceClient.currentUser = item.objet;
                            });
                            MobileServiceClient.authData = readCookie("__CirUserToken");
                            MobileServiceClient.invokeApi(url, {
                                method: method,
                                body: jsonBody
                            }).done(function (response) {
                                deferredObject.resolve(response);
                            }, function (error) {
                                //waitingDialog.hide(); //This Hide image Upload Dialog in case of Sync Update error
                                console.log(error);
                                if (error && IsSilent != null && IsSilent == true)
                                    NotifyCirMessage('Error : ', error.message, 'danger');
                                deferredObject.reject(error);
                            });
                        }
                    }
                })
            });
        }).fail(function (error) {
            if (error == "NOTOKEN") {
                waitingDialog.hide();
                waitingDialog.show("No authentication token found locally");
            }
            waitingDialog.hide();
            deferredObject.reject(error);
        });
    }
    return deferredObject.promise();
}

function UpdateUserEmail() {
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('UserInfo', function UserInfo(user) {
            if (user) {
                if (user.length > 0) {
                    user.forEach(function (item) {
                        $('#hdnUserInitial').val(item.Email);
                    });
                }
            }
        });
    });
}

var CurrentUserInfo = new Object();
var CurrentUserInfoFormio = new Object();

function _GetUserInfo() {
    var deferredObject = $.Deferred();
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser && currentuser.length > 0) {
                deferredObject.resolve(currentuser[0].userInfo);
            }
            else {
                deferredObject.reject();
            }
        });
    });
    return deferredObject.promise();
}

function _GetUserInfoFormio() {
    var deferredObject = $.Deferred();
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('CurrentUserFormio', function CurrentUser(currentuser) {
            if (currentuser && currentuser.length > 0) {
                deferredObject.resolve(currentuser[0].userInfo);
            }
            else {
                deferredObject.reject();
            }
        });
    });
    return deferredObject.promise();
}

function LoadUserInfo() {
    var deferredObject = $.Deferred();
    _GetUserInfo().done(function (result) {
        try {
            CurrentUserInfo.UserDisplayName = result.displayName;
            CurrentUserInfo.Roles = result.appRoles;
            CurrentUserInfo.Name = result.userPrincipalName.split("@", 1)[0];
            if (result.otherMails != null) {
                if (result.otherMails.length > 0 && result.otherMails[0] != "") {
                    CurrentUserInfo.Name = result.otherMails[0].split("@", 1)[0];
                }
            }
            CurrentUserInfo.UserPrincipleName = result.userPrincipalName;
            deferredObject.resolve();
        }
        catch (e) {
            console.log(e);
            alert("Please clear your browser cache, close and reopen the browser instance, click \"ok\" to see how to do this.")
            window.location = "http://www.refreshyourcache.com/en/home/";
        }
    });
    return deferredObject.promise();
}

function LoadUserInfoFormio() {
    var deferredObject = $.Deferred();
    _GetUserInfoFormio().done(function (result) {
        try {
            CurrentUserInfoFormio.UserDisplayName = result.displayName;
            CurrentUserInfoFormio.Roles = result.appRoles;
            CurrentUserInfoFormio.Name = result.userPrincipalName.split("@", 1)[0];
            if (result.otherMails != null) {
                if (result.otherMails.length > 0 && result.otherMails[0] != "") {
                    CurrentUserInfoFormio.Name = result.otherMails[0].split("@", 1)[0];
                }
            }
            CurrentUserInfoFormio.UserPrincipleName = result.userPrincipalName;
            deferredObject.resolve();
        }
        catch (e) {
            console.log(e);
            alert("Please clear your browser cache, close and reopen the browser instance, click \"ok\" to see how to do this.")
            window.location = "http://www.refreshyourcache.com/en/home/";
        }
    });
    return deferredObject.promise();
}

function hasRole(role) {
    if (!!CurrentUserInfo && !!CurrentUserInfo.Roles) {
        if (CurrentUserInfo.Roles.length == 0) {
            window.location.href = '/cir/Sign-Out';
        }
        var flg = false;
        $.grep(CurrentUserInfo.Roles, function (item) {
            if (item.toLowerCase() == role.toLowerCase())
                flg = true;
        });
        return flg;
    }
}

function isNumber(evt, element) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (
        (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
        (charCode != 44 || $(element).val().indexOf(',') != -1) &&
        (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function getQueryStringValueHash(variable) {
    var query = window.location.href;
    var vars = query.split("#");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return decodeURIComponent(pair[1]); }
    }
    return (false);
}

function GetQueryStringParams(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}

function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


var NotifyCirMessage = function (title, message, type, delay) {
    if (delay == null || delay == undefined)
        delay = 4000;
    var closeicon = false;
    if (delay == 0)
        closeicon = true;
    var icn = (type == "info") ? "glyphicon-info-sign" : "glyphicon-exclamation-sign";
    $.notify({
        // options
        icon: 'glyphicon ' + icn,
        title: title,
        message: message
    }, {
            // settings
            element: 'body',
            position: null,
            type: type,
            allow_dismiss: closeicon,
            newest_on_top: false,
            showProgressbar: false,
            placement: {
                from: "top",
                align: "center"
            },
            offset: 20,
            spacing: 10,
            z_index: 10031,
            delay: delay,
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

function GetDateStringFromDateObject(DateTiemObject) {
    try {
        var dd = DateTiemObject.getDate();
        var mm = DateTiemObject.getMonth() + 1; //January is 0!
        var yyyy = DateTiemObject.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }
        return dd + '-' + mm + '-' + yyyy;
    }
    catch (e) {
        return DateTiemObject;
    }

}

function GetDateObject(strDate) {
    try {
        var parts = strDate.split("/");
        if (parts.length > 2) {
            var dt = new Date(parseInt(parts[2], 10),
                parseInt(parts[1], 10) - 1,
                parseInt(parts[0], 10) + 1);
            return dt;
        }
        else {
            var parts1 = strDate.split("-");
            if (parts1.length > 2) {
                var dt = new Date(parseInt(parts1[2], 10),
                    parseInt(parts1[1], 10) - 1,
                    parseInt(parts1[0], 10) + 1);
                return dt;
            }
            else {
                return strDate;
            }
        }
    }
    catch (e) {
        return strDate;
    }
}


function JSONToXlSXConvertor(JSONData, FileName, ShowLabel) {
    export_table_to_excel(JSONData, ShowLabel, FileName)
}

// sequence should be lower to higher
var AllRoles = ['Visitor', 'Report Viewer', 'Viewer', 'Turbine Technicians', 'Contractor Turbine Technicians', 'Member', 'Editor', 'CIR Evaluator', 'BIRCreator', 'GIRCreator', 'Administrator', 'GBXIRCreator'];

function RedirectToLandingPage() {
    LoadUserInfo().done(function () {
        var _returnUrl = GetQueryStringParams('returnUrl');
        if (hasRole('Turbine Technicians') || hasRole('Contractor Turbine Technicians')) {
            window.location.href = '/cir/local-history';
        }
        else {
            if (Offline.state == "up") {
                if (_returnUrl != null) {
                    _returnUrl = (document.URL).split('&')[2].replace("returnUrl=", "");
                    if (_returnUrl.toLowerCase().indexOf('cir-pdf') > -1) {
                        _returnUrl = '/cir/' + _returnUrl.split('/cir/')[1];
                    }
                    window.location.href = _returnUrl;
                }
                else
                    window.location.href = '/cirView/manage-cirviewlist';
            }
            else
                window.location.href = '/cir/local-history';
        }
    });
}

function openTab(url) {
    // Create link in memory
    var a = window.document.createElement("a");
    a.target = '_blank';
    a.href = url;
    // Dispatch fake click
    var e = window.document.createEvent("MouseEvents");
    e.initMouseEvent("click", true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
    a.dispatchEvent(e);
};

function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;
    var byteCharacters = atob(b64Data);
    var byteArrays = [];
    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
}

function isNewCirRelatedToCurrentUser(item) {
    var userName = (!!CurrentUserInfo && !!CurrentUserInfo.Name) ? CurrentUserInfo.Name.toLowerCase() : null;
    return (item.lockedBy !== undefined &&
        item.lockedBy !== null &&
        item.lockedBy.toLowerCase() === userName.toLowerCase()) ||
        (item.createdBy !== undefined &&
            item.createdBy !== null &&
            item.createdBy.toLowerCase() === userName.toLowerCase()) ||
        (item.modifiedBy !== undefined &&
            item.modifiedBy !== null &&
            item.modifiedBy.toLowerCase() === userName.toLowerCase()) ||
        (item.delegatedTo !== undefined &&
            item.delegatedTo !== null &&
            item.delegatedTo.toLowerCase() === userName.toLowerCase()) ||
        (item.delegatedBy !== undefined &&
            item.delegatedBy !== null &&
            item.delegatedBy.toLowerCase() === userName.toLowerCase()) &&
        ((item.statusChangedBy === undefined ||
            item.statusChangedBy === null ||
            item.statusChangedBy.toLowerCase() !== userName.toLowerCase()) ||
            (item.createdBy !== undefined &&
                item.createdBy !== null &&
                item.createdBy.toLowerCase() === userName.toLowerCase()) ||
            (item.modifiedBy !== undefined &&
                item.modifiedBy !== null &&
                item.modifiedBy.toLowerCase() === userName.toLowerCase()));
}

function isNewCirStateError(item) {
    return item.Status === "Error" ||
        (item.sqlProcessStatus !== NewCirSqlNotTransferred && item.sqlProcessStatus !== NewCirSqlTransferred) ||
        item.sqlProcessStatus === undefined ||
        item.sqlProcessStatus === null;
}

const NewCirSqlNotTransferred = "NotTransferred";
const NewCirSqlTransferred = "Transferred";

var waitingDialog = waitingDialog || (function ($) {
    'use strict';
    // Creating modal dialog's DOM
    var $dialog = $(
        '<div class="modal bs-example-modal-sm" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:10%; overflow-y:visible;">' +
        '<div class="modal-dialog modal-sm" style="max-width:200px">' +
        '<div class="modal-content" style="left:40%">' +
        '<div class="modal-header text-center"><h5 style="margin:-5px 0px 0px 0px;"></h5>&nbsp;&nbsp;<i class="loadersign fa fa-spin fa-lg"></i></div>' +
        '</div></div></div>');

    return {
        show: function (message, options) {
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            if (typeof message === 'undefined') {
                message = 'Loading';
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);
            $dialog.find('i.loadersign').show();
            // Configuring dialog
            $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            $dialog.find('h5').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialog);
                });
            }
            // Opening dialog
            $dialog.modal();
        },
        hide: function () {
            $dialog.modal('hide');
        },
        updateMessage: function (message, hideLoader) {
            $dialog.find('h5').text(message);
            if (hideLoader != undefined && hideLoader != null && hideLoader == true) {
                $dialog.find('i.loadersign').hide();
            }
        }
    };
})(jQuery);

var CirAlert = CirAlert || (function ($) {
    'use strict';
    return {
        alert: function (message, title, buttontext, type) {
            var deferredObject = $.Deferred();
            if (title == null && title.trim() == "")
                title = "CIR offline app";
            if (message == null)
                message = "";
            if (buttontext == null || buttontext.trim() == "")
                buttontext = "OKAY";
            if (type == null)
                type = "";
            else if (type = "warning")
                type = 'fa fa-warning';
            else if (type = "info")
                type = 'fa fa-info';
            else if (type = "error")
                type = 'fa fa-times';
            else if (type = "question")
                type = 'fa fa-question';
            $.alert({
                title: title,
                content: message,
                confirmButton: buttontext,
                animation: 'rotateYR',
                closeAnimation: 'scale',
                animationBounce: 1.5,
                icon: type,
                theme: 'material', // 'supervan', 'bootstrap'
                confirm: function () {
                    deferredObject.resolve("OKAY");
                }
            });
            return deferredObject.promise();
        },
        confirm: function (message, title, confirmButton, cancelButton, type) {
            var deferredObject = $.Deferred();
            if (title == null && title.trim() == "")
                title = "CIR offline app";
            if (message == null)
                message = "";
            if (confirmButton == null || confirmButton.trim() == "")
                confirmButton = "OKAY";
            if (cancelButton == null || cancelButton.trim() == "")
                cancelButton = "CLOSE";
            if (type == null)
                type = "";
            else if (type = "warning")
                type = 'fa fa-warning';
            else if (type = "info")
                type = 'fa fa-info';
            else if (type = "error")
                type = 'fa fa-times';
            else if (type = "question")
                type = 'fa fa-question';
            $.confirm({
                title: title,
                content: message,
                confirmButton: confirmButton,
                cancelButton: cancelButton,
                animation: 'rotateYR',
                closeAnimation: 'scale',
                animationBounce: 1.5,
                icon: type,
                theme: 'material', // 'supervan', 'bootstrap'
                confirm: function () {
                    deferredObject.resolve("OKAY");
                }, cancel: function () {
                    deferredObject.reject("CLOSE");
                }
            });
            return deferredObject.promise();
        }
    };
})(jQuery);

//Back to Top
var offset = 220;
var duration = 500;
jQuery(window).scroll(function () {
    if (jQuery(this).scrollTop() > offset) {
        jQuery('.cirback-top').fadeIn(duration);
    } else {
        jQuery('.cirback-top').fadeOut(duration);
    }
});

jQuery('.cirback-top').click(function (event) {
    event.preventDefault();
    jQuery('html, body').animate({ scrollTop: 0 }, duration);
    return false;
})
