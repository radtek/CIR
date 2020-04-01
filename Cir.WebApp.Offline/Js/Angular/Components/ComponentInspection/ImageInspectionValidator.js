angular.module('formio')
    .factory('imageInspectionValidator', ['$rootScope', function ($rootScope) {
        var service = {
            validations: {
                allAssigned: true,
                allSaved: true,
                hasPlate: true,
                hasReason: true
            },

            validate: function (ctrl) {
                this.validations = {
                    allAssigned: true,
                    allSaved: true,
                    hasPlate: true,
                    hasReason: true
                };

                validateAllAssigned(ctrl);
                validateAllSaved(ctrl);
                validateHasPlate(ctrl);
                validateHasReason(ctrl);
                clearOnValid(ctrl);
            }
        };

        function propagateValidation(ctrl) {
            if ($rootScope.AssignedImages.indexOf(ctrl.component.key) === -1) {
                $rootScope.AssignedImages.push(ctrl.component.key);
            }
        }

        function validateAllAssigned(ctrl) {
            for (var i = 0; i < ctrl.images.length; i++) {
                if (ctrl.images[i].region !== -1 || ctrl.images[i].imageId === ctrl.plateImageId) {
                    continue;
                }

                propagateValidation(ctrl);

                service.validations.allAssigned = false;
            }
        }

        function validateAllSaved(ctrl) {
            if (ctrl.images.filter(img => !img.saved).length > 0) {
                propagateValidation(ctrl);

                service.validations.allSaved = false;
            }
        }

        function validateHasPlate(ctrl) {
            if (!ctrl.images.length && ctrl.data.withPlatePicture) {
                propagateValidation(ctrl);

                service.validations.hasPlate = false;
            }
        }

        function validateHasReason(ctrl) {
            if (ctrl.images.length && !ctrl.data.reason && !ctrl.plateImageId) {
                propagateValidation(ctrl);

                service.validations.hasReason = false;
            }
        }

        function clearOnValid(ctrl) {
            if (service.validations.allAssigned && service.validations.allSaved && service.validations.hasReason && service.validations.hasPlate) {
                if ($rootScope.AssignedImages.indexOf(ctrl.component.key) !== -1) {
                    $rootScope.AssignedImages.pop(ctrl.component.key);
                }
            }
        }

        return service;
    }]);