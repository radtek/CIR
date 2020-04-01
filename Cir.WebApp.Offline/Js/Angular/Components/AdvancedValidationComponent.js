angular.module('formio')
    .component('advancedValidation', {
        templateUrl: 'advancedValidationTemplate.html',
        bindings: {
            model: '=',
            data: '=',
            key: '='
           
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope, httpService, urlAnchorService,$rootScope) {
                $scope.firstLoad = true;
                $scope.$watch('$ctrl.data',
                    function () {
                        if (!$scope.$ctrl.data[$scope.$ctrl.key]) {
                            $scope.$ctrl.data[$scope.$ctrl.key] = '';
                        }
                    }
                );

                $scope.$watch('$ctrl.data[$ctrl.model.controlId]',
                    function () {
                        if (!$scope.firstLoad) {
                            let url = urlAnchorService.replaceAnchors($scope.$ctrl.model.apiUrl, $scope.$ctrl.data);
                            httpService.httGet(url, function (response) {
                                $scope.$apply(function () {
                                    if (!response) {
                                        $scope.$ctrl.data[$scope.$ctrl.key] = $scope.$ctrl.model.errorMessage;
                                        if ($rootScope.extendedValidation.indexOf($scope.$ctrl.model.controlName) == -1) {
                                            $rootScope.extendedValidation.push($scope.$ctrl.model.controlName);
                                        }
                                    } else {
                                        $scope.$ctrl.data[$scope.$ctrl.key] = '';
                                        if ($rootScope.extendedValidation.indexOf($scope.$ctrl.model.controlName) != -1) {
                                            $rootScope.extendedValidation.pop($scope.$ctrl.model.controlName);
                                        }
                                    }
                                });
                            },
                            function (err) {
                                console.log(err);
                            });
                        } else {
                            $scope.firstLoad = false;
                        }
                    });
            }
        }
    });