angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('ToggleButton', {
                title: ' Custom Toggle Button',
                fbtemplate: 'ToggleButton.html',
                template: 'ToggleButton.html',
                settings: {
                    tableView: true,
                    label: 'Toggle',
                    key: 'ToggleButton',
                    description: 'Toggle Button',
                    protected: false,
                    unique: false,
                    persistent: true,
                    input: true
                },
                icon: 'fa fa-file-image-o',
                views: [
                    {
                        name: 'Display',
                        template: 'ToggleButtonProperties.html'
                    },
                    {
                        name: 'Data',
                        template: 'formio/components/common/data.html'
                    },
                     {
                         name: 'Validation',
                         template: 'formio/components/checkbox/validate.html'

                     },
                    {
                        name: 'API',
                        template: 'formio/components/common/api.html'
                    },
                    {
                        name: 'Layout',
                        template: 'formio/components/common/layout.html'
                    },
                     {
                         name: 'Conditional',
                         template: 'formio/components/common/conditional.html'
                     }
                ],
                controller: ['$scope', '$rootScope', function ($scope, $rootScope) {
                    $scope.onInit = function () {
                       // var formScope = angular.element('#formio-wizard-form').scope().$parent;
                        
                            //if (formScope.$root.cir === undefined) {
                            //    if ($rootScope.setRepairData === undefined) {
                            //        if ($scope.component.key == "ctbDamageIdentified") {
                            //            $scope.data["ctbDamageIdentified"] = true;
                            //            $rootScope.setRepairData = true;
                            //        }
                            //    }
                            //}

                            if ($scope.data[$scope.component.key] === undefined) {
                            if (!!$scope.component.defaultValue) {
                                $scope.data[$scope.component.key] = $scope.component.defaultValue == true ? true : false;
                            } else {
                                $scope.data[$scope.component.key] = false;
                            }
                        }
                    
                    };
                }]
            });
        }
    ]);


