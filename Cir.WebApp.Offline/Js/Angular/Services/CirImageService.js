angular.module('formio')
    .factory('cirImageService', ['$rootScope', function ($rootScope) {
        var service = {
            saveBlobs: function (cirId, blobList, turbineNumber) {
                let deferred = $.Deferred();
                if (!!blobList) {
                    blobList = blobList.filter(x => !!x.state);

                    cirOfflineApp.GetCirDataJsonById(cirId)
                        .done(function (cir) {
                            if (!!cir.imageReferences && cir.imageReferences.length > 0) {
                                blobList = blobList.filter(x => !cir.imageReferences.filter(i => i.imageId == x.imageId && x.state == "Added")[0]);
                            }
                        })
                        .always(function () {
                            service.saveThumbnails(cirId, blobList).done(function () {
                                if (!blobList || blobList.length === 0) {
                                    deferred.resolve();
                                    return;
                                }
                                cirOfflineApp.SaveImageblobList({ 'cirId': cirId, 'blobList': blobList, 'initialCount': blobList ? blobList.length : 0, 'turbineNumber': turbineNumber })
                                    .done(function () {
                                        deferred.resolve();
                                    });
                            });
                        });
                }
                else {
                    deferred.resolve();
                }
                return deferred.promise();
            },
            saveBlobString: function (cirId, imageId, imageBlob) {
                var deferred = $.Deferred();
                if (window.isElectronApp) {
                    let saveData = window.callElectronApp("Write", cirId, [{ imageId: imageId, binaryData: imageBlob }]);
                    if (saveData != "Data saved successfully") {
                        NotifyCirMessage("", 'Error in saving Data to Electron: ' + saveData, "danger");
                        deferred.reject();
                    } else {
                        deferred.resolve();
                    }
                } else {
                   if (Offline.state == "down") {
                        cirOfflineApp.SaveBlob(cirId, imageId, imageBlob).done(function () {
                            deferred.resolve();
                        });
                    } else { deferred.resolve(); }
                }
                return deferred.promise();
            },
            saveThumbnails: function (cirId, blobList) {
                let saveThumbDeferred = $.Deferred();
                blobList = !blobList ? [] : blobList;
                let thumbnailsList = [];
                cirOfflineApp.GetImageThumbnails(cirId)
                    .done(function (thumbnails) {
                        thumbnailsList = thumbnails;
                    })
                    .always(function () {
                        if (!$rootScope.imageThumbnails) {
                            saveThumbDeferred.resolve();
                            return;
                        }

                        var existingBlobs = thumbnailsList.map(x => x.imageId);
                        var notExistingBlobs = blobList.filter(x => existingBlobs.indexOf(x.imageId) == -1 && !!$rootScope.imageThumbnails[x.imageId]);
                        if (notExistingBlobs.length == 0) {
                            saveThumbDeferred.resolve();
                        }
                        notExistingBlobs.forEach(function (blob, i) {
                            thumbnailsList.push({ imageId: blob.imageId, binaryData: $rootScope.imageThumbnails[blob.imageId] });
                        });
                        cirOfflineApp.SaveImageThumbnails(cirId, thumbnailsList).done(function () {
                            saveThumbDeferred.resolve();
                        });
                    });
                return saveThumbDeferred.promise();
            },
            loadBlobs: function (cirId) {
                let deferred = $.Deferred();

                cirOfflineApp.GetCirImageBlobList(cirId)
                    .done(function (blobList) {
                        deferred.resolve(blobList.blobList);
                    })
                    .fail(function () {
                        deferred.reject();
                    });

                return deferred.promise();
            },
            loadThumbnails: function (cir) {
                let deferred = $.Deferred();
                cirOfflineApp.GetImageThumbnails(cir.id)
                    .done(function (thumbnails) {
                        if (!!cir.imageReferences && cir.imageReferences.length > thumbnails.length) {
                            var i = 0;
                            var thumbnails = [];
                            angular.forEach(cir.imageReferences, function (reference) {
                                CallSyncApi("BlobStorage/GetBlobData?imageUrl=" + reference.binaryDataUrl, "GET", "").done(function (result) {

                                    if (reference.binaryDataUrl.indexOf('servicesprod.inspectools.net') != -1) {
                                        thumbnails.push(
                                            {
                                                imageId: reference.imageId,
                                                binaryData: result.response.replace(/"|\\n/g, "")
                                            });
                                    }
                                    else {
                                        let response = JSON.stringify(result.response);
                                        thumbnails.push({ imageId: reference.imageId, binaryData: response.replace(/["'\\]/g, "") });//.replace(/(\r\n\t|\n|\r\t)/gm,"")
                                    }
                                    if (i == cir.imageReferences.length - 1) {
                                        deferred.resolve(thumbnails);
                                    }
                                    ++i;
                                });
                            });
                        }
                        else {
                            deferred.resolve(thumbnails);
                        }
                    })
                    .fail(function () {
                        var thumbnails = [];
                        if (!cir.imageReferences || (!!cir.imageReferences && cir.imageReferences.length == 0)) {
                            deferred.reject();
                        }

                        var i = 0;
                        angular.forEach(cir.imageReferences, function (reference) {
                            CallSyncApi("BlobStorage/GetBlobData?imageUrl=" + reference.binaryDataUrl, "GET", "").done(function (result) {
                                if (reference.binaryDataUrl.indexOf('servicesprod.inspectools.net') != -1) {
                                    thumbnails.push(
                                        {
                                            imageId: reference.imageId,
                                            binaryData: result.response.replace("\"", "").replace(/"|\\n/g, "")
                                        });
                                }
                                else {
                                    let response = JSON.stringify(result.response);
                                    thumbnails.push({ imageId: reference.imageId, binaryData: response.replace(/["'\\]/g, "") });//.replace(/(\r\n\t|\n|\r\t)/gm,"")
                                }
                                if (i == cir.imageReferences.length - 1) {
                                    deferred.resolve(thumbnails);
                                }
                                ++i;
                            });
                        });
                    });
                return deferred.promise();
            },
            resizeImage: function (img, maxWidth) {
                let deferred = $.Deferred();
                let image = new Image();
                image.onload = function () {
                    //if (Offline.state == "down") {
                        let imgType = img.substring(img.indexOf(':') + 1, img.indexOf(';'));
                        let canvas = window.document.createElement("canvas");
                        let ctx = canvas.getContext("2d");
                        ctx.drawImage(image, 0, 0);
                        let width = image.width;
                        let height = image.height;
                        let scale = (width * 1.0) / height;
                        let newWidth = maxWidth;
                        let newHeight = maxWidth / scale;
                        canvas.width = newWidth;
                        canvas.height = newHeight;
                        ctx = canvas.getContext("2d");
                        ctx.drawImage(image, 0, 0, newWidth, newHeight);
                        let resizedImage = canvas.toDataURL(imgType);
                        canvas.remove();
                        deferred.resolve(resizedImage, newWidth, newHeight);
                    //} else {
                    //    deferred.resolve(img, img.width, img.height);
                    //}
                }
                image.src = img;
                return deferred.promise();
            },
            isBlobAddedDeleted: function (blobList) {
                blobList = !blobList ? [] : blobList;
                for (var i = 0; i < blobList.length; i++) {
                    if (!!blobList[i].state) {
                        return true;
                    }
                }
                return false;
            },
            generateImageId: function (fileBlobModel) {
                let deferred = $.Deferred();
                let imageGuid = cirOfflineApp.generateKey();
                if (!!fileBlobModel && fileBlobModel.length > 0 && fileBlobModel.findIndex(x => x.imageId == imageGuid) > -1) {
                    imageGuid = cirImageService.generateImageId(fileBlobModel);
                }
                else {
                    deferred.resolve(imageGuid);
                }
                return deferred.promise();
            }
        };
        return service;
    }]);
