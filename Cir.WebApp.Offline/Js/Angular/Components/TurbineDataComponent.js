angular.module('formio')
    .component('turbineData', {
        templateUrl: 'turbineDataTemplate.html',
        bindings: {
            model: '=',
            data: '=',
            key: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope, httpService, urlAnchorService, $rootScope) {
                $scope.firstLoad = false;

                $scope.$watch('$ctrl.data[$ctrl.model.controlId]',
                    function () {
                        $rootScope.txtTurbineNumber = $scope.$ctrl.data.txtTurbineNumber;
                        if (!$scope.firstLoad) {
                            let url = urlAnchorService.replaceAnchors($scope.$ctrl.model.apiUrl, $scope.$ctrl.data);
                            httpService.httGet(url, function (response) {
                                $scope.$apply(function () {
                                    $scope.$ctrl.data.txtCountry = response.country;
                                    $scope.$ctrl.data.txtSiteName = response.site;
                                    $scope.$ctrl.data.txtTurbineType = response.turbine;
                                    $scope.$ctrl.data.txtRotorDiameter = response.rotorDiameter != 0 ? response.rotorDiameter : '';
                                    $scope.$ctrl.data.txtNominelPower = response.nominelPower != 0 ? response.nominelPower : '';
                                    $scope.$ctrl.data.txtVoltage = response.voltage != 0 ? response.voltage : '';
                                    $scope.$ctrl.data.txtPowerRegulation = response.powerRegulation;
                                    $scope.$ctrl.data.txtFrequency = response.frequency != 0 ? response.frequency : '';
                                    $scope.$ctrl.data.txtSmallGenerator = response.smallGenerator != 0 ? response.smallGenerator : '';
                                    $scope.$ctrl.data.txtTemperatureVariant = response.temperatureVariant;
                                    $scope.$ctrl.data.txtMKversion = response.markVersion;
                                    $scope.$ctrl.data.txtOnshoreOffshore = response.placement;
                                    $scope.$ctrl.data.txtManufacturer = response.manufacturer;
                                    $scope.$ctrl.data.txtLocalturbineId = response.localTurbineId;
                                })
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