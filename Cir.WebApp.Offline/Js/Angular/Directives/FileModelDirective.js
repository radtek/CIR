angular.module('formio')
    .directive("fileModel", ['$rootScope', 'cirImageService', 'globalVariables', '$q', function ($rootScope, cirImageService, globalVariables, $q) {
        return {
            scope: {
                fileMetadataModel: "=",
                fileBlobModel: "=",
                cirTemplateId: '<'
            },
            link: function (scope, element, attributes) {
                scope.imageWidth = globalVariables.imageDefaultWidth();
                element.on("change", function (changeEvent) {
                    if (changeEvent.target.files.length === 0) {
                        return;
                    }
                    if (!scope.fileBlobModel) {
                        scope.fileBlobModel = [];
                    }
                    if (!scope.fileMetadataModel) {
                        scope.fileMetadataModel = [];
                    }

                    if (!$rootScope.imageThumbnails) {
                        $rootScope.imageThumbnails = {};
                    }
                    scope.files = [];
                    $rootScope.uploadedImageCount = changeEvent.target.files.length;
                    $rootScope.imageInThumbnail = 0;
                    waitingDialog.show('Uploading Images..', { dialogSize: 'sm', progressType: 'primary' });
                    $rootScope.isImageUploaded = true;
                    let i = 0;

                    angular.forEach(changeEvent.target.files, function (value, key) {
                        scope.files.push(value);
                    });
                    scope.files.sort(function (a, b) {
                        var aMixed = SortMixedDataValue(a.name);
                        var bMixed = SortMixedDataValue(b.name);
                        return (aMixed < bMixed ? -1 : 1);
                    });
                    var reader = new FileReader();
                    var file;
                    var deferred = $q.defer();
                    var ImageAfterresize;
                    var ImgGuid;
                    var imgthumbnails;
                    var filename;
                    var uploadCount = 0;
                    var failedCount = 0;
                    GetBlobPath($rootScope.cirId, $rootScope.txtTurbineNumber).done(function (response) {
                        let ImageUpload = setTimeout(function run() {
                            if (i < scope.files.length) {
                                file = scope.files[i];
                                filename = file.name;
                                reader.readAsDataURL(file);
                                reader.onload = function (e) {
                                    if (reader.result == null) {
                                        setTimeout(run, 1000);
                                    }
                                    else {
                                        cirImageService.generateImageId(scope.fileBlobModel).done(function (imageGuid) {
                                            if (imageGuid == null || imageGuid == 'undefined') {
                                                setTimeout(run, 1000);
                                            }
                                            else {
                                                ImgGuid = imageGuid;
                                                cirImageService.resizeImage(reader.result, scope.imageWidth).done(function (resizedImage) {
                                                    ImageAfterresize = resizedImage;
                                                    if (resizedImage == null) {
                                                        setTimeout(run, 1000);
                                                    }
                                                    else {
                                                        cirImageService.saveBlobString($rootScope.cirId, imageGuid, resizedImage).done(function () {
                                                            if (!deferred.promise) {
                                                                setTimeout(run, 1000);
                                                            }
                                                            else {
                                                                deferred.resolve();
                                                                cirImageService.resizeImage(resizedImage, 1024).done(function (thumbnail) {
                                                                    if (thumbnail == null) {
                                                                        setTimeout(run, 1000);
                                                                    }
                                                                    else {
                                                                        imgthumbnails = thumbnail;
                                                                        scope.$apply(function () {
                                                                            $rootScope.imageThumbnails[imageGuid] = thumbnail;
                                                                            $rootScope.imageInThumbnail = $rootScope.imageInThumbnail + 1;

                                                                            var imageBloblist = [];
                                                                            if (Offline.state == "up") {
                                                                                var imageBlobData = [];
                                                                                imageBlobData.imageId = imageGuid;
                                                                                imageBlobData.binaryData = resizedImage;
                                                                                imageBloblist.push(imageBlobData);

                                                                                $rootScope.imageReferences = $rootScope.imageReferences ? $rootScope.imageReferences : [];
                                                                                UploadImageClientOnline(imageBloblist, $rootScope.imageReferences, $rootScope.txtTurbineNumber, $rootScope.cirId, scope.cirTemplateId, response).done(function (imageReferenceModel) {
                                                                                    uploadCount++;
                                                                                    scope.$apply(function () {
                                                                                        scope.fileBlobModel.push({
                                                                                            imageId: imageReferenceModel[0].imageId,
                                                                                            templateId: scope.cirTemplateId,
                                                                                            cirId: $rootScope.cirId,
                                                                                            binaryData: '',
                                                                                            state: "Added"
                                                                                        });
                                                                                    });
                                                                                    if ($rootScope.imageReferences.findIndex(x => x.imageId == imageReferenceModel.imageId) < 0 && (imageReferenceModel.binaryData==null || imageReferenceModel.binaryData.length == 0)) {
                                                                                        $rootScope.imageReferences = $rootScope.imageReferences.concat(imageReferenceModel);
                                                                                    }
                                                                                    if (uploadCount == scope.files.length) {
                                                                                        Reset();
                                                                                        setTimeout(run, 100);
                                                                                    }
                                                                                }).fail(function (error) {
                                                                                    uploadCount++;
                                                                                    failedCount++;
                                                                                    if (uploadCount == scope.files.length) {
                                                                                        Reset();
                                                                                        setTimeout(run, 100);
                                                                                    }
                                                                                });
                                                                            } else {
                                                                                scope.fileBlobModel.push({
                                                                                    imageId: imageGuid,
                                                                                    templateId: scope.cirTemplateId,
                                                                                    cirId: $rootScope.cirId,
                                                                                    binaryData: '',
                                                                                    state: "Added"
                                                                                });
                                                                            }
                                                                            scope.fileMetadataModel.push({
                                                                                fileInfo: { name: filename },
                                                                                description: '',
                                                                                imageId: imageGuid
                                                                            });
                                                                            i++;
                                                                            if (i < changeEvent.target.files.length) {
                                                                                Reset();
                                                                                setTimeout(run, 100);
                                                                            }
                                                                            else if (i == changeEvent.target.files.length && Offline.state == "down") {
                                                                                waitingDialog.hide();
                                                                                NotifyCirMessage("", '- Images can be dragged for reordering.<br /> - Slide images for previews.<br /> - Image descriptions are editable.', "info", 8000);
                                                                            }
                                                                        });
                                                                    }
                                                                });
                                                            }
                                                        });
                                                    }
                                                });
                                            }
                                        });
                                    }
                                }
                            } else {
                                if (uploadCount == scope.files.length) {
                                    var notifyMsg = "";
                                    if (Offline.state == "down") {
                                        notifyMsg = "- Images can be dragged for reordering.<br /> - Slide images for previews.<br /> - Image descriptions are editable.";
                                    }
                                    else if (Offline.state == "up" && failedCount == 0) {
                                        notifyMsg = "- Images can be dragged for reordering.<br /> - Slide images for previews.<br /> - Image descriptions are editable.";
                                    } else {
                                        notifyMsg = "- There is some error ocurred during Image Upload.";
                                    }
                                    $rootScope.isImageUploaded = false;
                                    waitingDialog.hide();
                                    NotifyCirMessage("", notifyMsg, "info", 8000);
                                    clearTimeout(ImageUpload);
                                } else {
                                    Reset();
                                    setTimeout(run, 100);
                                }
                            }
                        }, 100)
                    }).fail(function (error) {
                        waitingDialog.hide();
                        NotifyCirMessage("", "- There is some error ocurred during Image Upload.", "info", 8000);
                        Reset();
                    });
                });
            }
        }

        function Reset() {
            file = "";
            ImageAfterresize = "";
            ImgGuid = "";
            imgthumbnails = "";
            filename = "";
        }

        function SortMixedDataValue(field) {
            var padding = '00000000000000000000';
            var value = field.replace(/(\d+)((\.\d+)+)?/g, function ($0, integer, decimal, $3) {
                if (decimal !== $3) {
                    return $0.replace(/(\d+)/g, function ($d) {
                        return padding.slice($d.length) + $d
                    });
                } else {
                    decimal = decimal || ".0";
                    return padding.slice(integer.length) + integer + decimal + padding.slice(decimal.length);
                }
            });
            return value;
        }
    }]);
