angular.module('formio')
    .component('imageMetadataList', {
        templateUrl: 'imageMetadataListTemplate.html',
        bindings: {
            metadataList: '=',
            blobList: '=',
            thumbnails: '<'
        },
        controllerAs: '$ctrl',
        controller: class {

            constructor($rootScope, $scope, cirImageService) {
                this.$rootScope = $rootScope;
                this.$scope = $scope;
                this.cirImageService = cirImageService;
                this.showImagePreview = false;
                waitingDialog.show('Loading Images...', { dialogSize: 'sm', progressType: 'primary' });

                $scope.$watchCollection('$ctrl.blobList', function () {
                    if (!!$rootScope.cir) {
                        if (!$rootScope.imageThumbnails && !$rootScope.cir.imageReferences && !!$rootScope.cir.state && $rootScope.cir.state != "Draft") {
                            waitingDialog.hide();
                            return;
                        }
                        if ($rootScope.uploadedImageCount) {
                            if ($rootScope.imageInThumbnail != $rootScope.uploadedImageCount) {
                                return;
                            }
                        }
                        cirImageService.loadThumbnails($rootScope.cir)
                            .done(function (thumbnails) {
                                if (!$rootScope.imageThumbnails) {
                                    $rootScope.imageThumbnails = {};
                                }
                                var i = 0, thumbnailLength = thumbnails.length;
                                thumbnails.forEach(function (thumbnail) {
                                    ++i;
                                    if (!$rootScope.imageThumbnails[thumbnail.imageId]) {
                                        if (thumbnail.binaryData.indexOf("base64") == -1) {
                                            thumbnail.binaryData = "data:image/jpeg;base64," + thumbnail.binaryData;
                                        }
                                        if (!$scope.$$phase) {
                                            $scope.$apply(function () {
                                                $rootScope.imageThumbnails[thumbnail.imageId] = thumbnail.binaryData;
                                            });
                                        } else {
                                            $rootScope.imageThumbnails[thumbnail.imageId] = thumbnail.binaryData;
                                        }
                                    }
                                });
                                if (i == thumbnailLength) {
                                    waitingDialog.hide();
                                }
                            })
                        .fail(function () {
                            waitingDialog.hide();
                        });
                    }
                    else {
                        if (!$rootScope.cir && (!$rootScope.imageInThumbnail && !$rootScope.uploadedImageCount) || !$rootScope.isImageUploaded || (Offline.state == "down" && ($rootScope.imageInThumbnail == $rootScope.uploadedImageCount))) {
                            waitingDialog.hide();
                        }
                    }
                });
            }

            deleteImage(imageId) {
                let imageGuid = this.metadataList[imageId].imageId;
                this.metadataList.splice(imageId, 1);

                this.blobList.filter(i => i.imageId == imageGuid)[0].state = "Deleted";
            }

            moveImageUp(imageId) {
                if (imageId === 0) {
                    return;
                }

                this.metadataList[imageId - 1] = this.metadataList.splice(imageId, 1, this.metadataList[imageId - 1])[0];
            }

            moveImageDown(imageId) {
                if (imageId === this.metadataList.length - 1) {
                    return;
                }

                this.metadataList[imageId + 1] = this.metadataList.splice(imageId, 1, this.metadataList[imageId + 1])[0];
            }

            viewImage(imageId) {
                this.$scope.$broadcast('showPreview', imageId);
                this.showImagePreview = true;
            }

            closePreview() {
                this.showImagePreview = false;
            }
        }
    });