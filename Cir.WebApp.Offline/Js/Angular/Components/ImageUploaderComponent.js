angular.module('formio')
    .component('imageUploader', {
        templateUrl: 'imageUploaderTemplate.html',
        bindings: {
            component: '=',
            data: '=',
            blobModel: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($rootScope, $scope, $location, cirImageService, globalVariables) {
                this.imageTypes = globalVariables.imageTypes();
                this.cirId = $rootScope.cir ? $rootScope.cir.id : '';
                this.templateId = $rootScope.templateId;
                this.$scope = $scope;
                //following fix is implemented to sort the uploaded inspection images in custom image control of non blade templates.
                $scope.$watchCollection('$ctrl.data', function (newValue, oldValue) {
                    var tempValue = newValue;
                    if (newValue != null && oldValue != null && newValue.length > oldValue.length) {
                        for (var i = 0; i <= newValue.length - 1; i++) {
                            for (var j = 0; j <= oldValue.length - 1; j++) {
                                if (newValue[i] == oldValue[j]) {
                                    if (oldValue[j] != tempValue[j]) {
                                        tempValue[i] = tempValue[j];
                                        tempValue[j] = oldValue[j];
                                    }
                                }
                            }
                        }
                        newValue = tempValue;
                        oldValue = tempValue;
                        tempValue = null;
                    }
                });

                if (!!$rootScope.cir) {
                    this.imageThubmnails = [];
                }
            }


        }
    });