angular.module('formio')
    .component('imagePreview', {
        templateUrl: 'imagePreviewTemplate.html',
        bindings: {
            imageMetadataList: '=',
            imageThumbnails: '<',
            imageBlobs: '<',
            onClose: '&'
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope, $element) {
                this.$scope = $scope;

                this.imageUrls = [];

                this.swiper = new Swiper($element.find('.swiper-container'), {
                    nextButton: $element.find('.swiper-button-next'),
                    prevButton: $element.find('.swiper-button-prev'),
                    pagination: $element.find('.swiper-pagination'),
                    paginationClickable: $element.find('.swiper-pagination'),
                    zoom: true,
                    keyboardControl: true,
                    slidesPerView: 1
                });

                $scope.$on('showPreview', function (event, imageId) {
                    event.currentScope.$ctrl.swiper.update();
                    event.currentScope.$ctrl.swiper.setWrapperTranslate(0);
                    event.currentScope.$ctrl.swiper.slideTo(imageId, 0, false);
                });

                $scope.$watch('$ctrl.imageBlobs', function () {
                    angular.forEach($scope.$ctrl.imageBlobs, function (val, i) {
                        if ($scope.$ctrl.imageUrls[val.imageId] || !$scope.$ctrl.imageBlobs) {
                            return;
                        }

                        let imageBlobData = $scope.$ctrl.imageBlobs.filter(x => x.imageId == val.imageId)[0];

                        if (imageBlobData && imageBlobData.url) {
                            CallSyncApi("BlobStorage/GetBlob?imageUrl=" + imageBlobData.url, "GET", "").done(function (url) {
                                $scope.$apply(function () {
                                    let result = JSON.stringify(url.response);
                                    $scope.$ctrl.imageUrls[val.imageId] = result.replace(/["'\\]/g, "");
                                });
                            });
                        }
                    });
                });
            }

            closePreview() {
                this.onClose();
            }
        }
    });