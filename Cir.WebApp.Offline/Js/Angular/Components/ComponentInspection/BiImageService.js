angular.module('formio')
    .factory('biImageService', ['$rootScope', 'cirImageService', 'globalVariables', function ($rootScope, cirImageService, globalVariables) {
        function getImageForCache(imgData) {
            var tmpImgData = {};

            for (var key in imgData) {
                if (!imgData.hasOwnProperty(key) || key === 'src') {
                    continue;
                }

                tmpImgData[key] = imgData[key];
            }

            return tmpImgData;
        }

        function onThumbnailsLoaded(thumbnails) {
            if (!$rootScope.imageThumbnails) {
                $rootScope.imageThumbnails = {};
            }

            thumbnails.forEach(function (thumbnail) {
                if (!$rootScope.imageThumbnails[thumbnail.imageId]) {
                    if (thumbnail.binaryData.indexOf("base64") === -1) {
                        thumbnail.binaryData = "data:image/jpeg;base64," + thumbnail.binaryData;
                    }
                    if (!$rootScope.$$phase) {
                        $rootScope.$apply(function () {
                            $rootScope.imageThumbnails[thumbnail.imageId] = thumbnail.binaryData;
                        });
                    } else {
                        $rootScope.imageThumbnails[thumbnail.imageId] = thumbnail.binaryData;
                    }
                }
            });
        }

        function backupLoadThumbnails(blobModel, images, plateImageId, plateImageCallback) {
            var thumbnails = [];

            for (var key in $rootScope.imageThumbnails) {
                if (!$rootScope.imageThumbnails.hasOwnProperty(key)) {
                    continue;
                }

                var myImage = images.filter(function (dataImage) {
                    return dataImage.imageId === key;
                }).length > 0;

                if (!myImage) {
                    continue;
                }

                thumbnails.push({ imageId: key, binaryData: $rootScope.imageThumbnails[key] });
            }

            BlobModelManager.initializeImages(images, blobModel, thumbnails, plateImageId, plateImageCallback);
        }

        function getThumbnailsFromBackend(blobModel, images, plateImageId, plateImageCallback) {
            cirImageService.loadThumbnails($rootScope.cir).done(function (thumbnails) {
                if (!thumbnails) {
                    return;
                }

                if (!$rootScope.$$phase) {
                    $rootScope.$apply(function () {
                        BlobModelManager.initializeImages(images,
                            blobModel,
                            thumbnails,
                            plateImageId,
                            plateImageCallback);
                    });
                } else {
                    BlobModelManager.initializeImages(images, blobModel, thumbnails, plateImageId, plateImageCallback);
                }
            }).fail(function () {
                if (!$rootScope.$$phase) {
                    $rootScope.$apply(function () {
                        backupLoadThumbnails(blobModel, images, plateImageId, plateImageCallback);
                    });
                } else {
                    backupLoadThumbnails(blobModel, images, plateImageId, plateImageCallback);
                }
            });
        }

        var service = {
            saveImage: function (imgData, frResult, componentData, doneCallback) {
                if (!$rootScope.imageThumbnails) {
                    $rootScope.imageThumbnails = {};
                }

                cirImageService.resizeImage(frResult, globalVariables.imageDefaultWidth()).done(function (resizedImage, width, height) {
                    imgData.width = width;
                    imgData.height = height;
                    imgData.src = resizedImage;

                    cirImageService.saveBlobString($rootScope.cirId, imgData.imageId, resizedImage).done(
                        function () {
                            cirImageService.resizeImage(resizedImage, 1024).done(function (thumbnail) {
                                $rootScope.$apply(function () {
                                    $rootScope.imageThumbnails[imgData.imageId] = thumbnail;
                                    document.getElementById('choose-images').value = '';

                                    componentData.data.uploadedImagesCache.push(getImageForCache(imgData));

                                    if (!componentData.blobModel || !$rootScope.templateId) {
                                        return;
                                    }

                                    BlobModelManager.add(imgData,
                                        componentData.blobModel,
                                        $rootScope.cirId,
                                        $rootScope.templateId);

                                    var imageBlobData = [];
                                    if (Offline.state != "down") {
                                        imageBlobData.imageId = imgData.imageId;
                                        imageBlobData.binaryData = resizedImage;
                                    }

                                    doneCallback(imageBlobData);
                                });
                            });
                        });
                });
            },

            updateImage: function (data, imgData) {
                var tmpImgData = {};

                for (var key in imgData) {
                    if (!imgData.hasOwnProperty(key) || key === 'src') {
                        continue;
                    }

                    tmpImgData[key] = imgData[key];
                }

                var index = data.uploadedImagesCache.findIndex(function (cachedImg) {
                    return cachedImg.imageId === imgData.imageId;
                });

                if (index < 0) {
                    return;
                }

                data.uploadedImagesCache[index] = tmpImgData;
            },

            removeImages: function (idsToRemove, blobModel, data) {
                for (var i = 0; i < idsToRemove.length; i++) {
                    var imgId = idsToRemove[i];
                    var cacheIdx = data.uploadedImagesCache.findIndex(function (el) {
                        return el.imageId === imgId;
                    });

                    if (cacheIdx < 0) {
                        continue;
                    }

                    data.uploadedImagesCache.splice(cacheIdx, 1);
                }

                BlobModelManager.remove(idsToRemove, blobModel, $rootScope.cirId);
                cirOfflineApp.GetCirImageBlobList($rootScope.cirId).done(function () {
                    cirOfflineApp.SaveImageblobList({
                        'cirId': $rootScope.cirId,
                        'blobList': blobModel,
                        'initialCount': blobModel.length,
                        'turbineNumber': $rootScope.turbineNumber
                    });
                });
            },

            cacheThumbnails: function () {
                if (!$rootScope.cir) {
                    return;
                }
                if (!!$rootScope.imageThumbnails) {
                    return;
                }

                cirImageService.loadThumbnails($rootScope.cir).done(onThumbnailsLoaded);
            },

            updateImagesFromBlob: function (blobModel, images, uploadedImagesCache, plateImageId, plateImageCallback) {
                for (var i = 0; i < uploadedImagesCache.length; i++) {
                    if (images.findIndex(function (img) {
                        return !img ? false : img.imageId === uploadedImagesCache[i].imageId;
                    }) > -1) {
                        continue;
                    }

                    var tmpImgData = {};

                    for (var key in uploadedImagesCache[i]) {
                        if (!uploadedImagesCache[i].hasOwnProperty(key) || key === 'src') {
                            continue;
                        }

                        tmpImgData[key] = uploadedImagesCache[i][key];
                    }

                    images.push(tmpImgData);
                }
                if (!$rootScope.cir) {
                    backupLoadThumbnails(blobModel, images, plateImageId, plateImageCallback);
                } else {
                    getThumbnailsFromBackend(blobModel, images, plateImageId, plateImageCallback);
                }
            }
        };

        return service;
    }]);