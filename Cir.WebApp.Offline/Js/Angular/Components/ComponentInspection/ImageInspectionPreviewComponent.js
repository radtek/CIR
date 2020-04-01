angular.module('formio')
    .component('imageInspectionPreview', {
        templateUrl: 'imageInspectionPreviewTemplate.html',
        bindings: {
            activeImage: '=',
            onClose: '&'          
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope, $element) {
                this.$scope = $scope;             

                this.swiper = new Swiper($element.find('.swiper-container'), {
                    zoom: false,
                    keyboardControl: false,
                    slidesPerView: 1
                });

                $scope.$on('showInspectionPreview', function (event, imageId) {
                    event.currentScope.$ctrl.swiper.update();
                });

            }
            closePreview() {
                this.onClose();
            }
           
        }
    });