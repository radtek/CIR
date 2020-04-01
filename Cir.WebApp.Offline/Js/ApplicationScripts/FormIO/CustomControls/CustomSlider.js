angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('customSlider', {
                title: 'Custom Slider',
                fbtemplate: 'customSliderView.html',
                template: 'customSliderView.html',
                settings: {
                    tableView: true,
                    label: 'Custom Slider',
                    key: 'customSlider',
                    description: 'Custom Slider',
                    protected: false,
                    unique: false,
                    persistent: true,
                    input: true,
                    validate: {
                        required: true,
                        custom: '',
                        customPrivate: false
                    }
                },
                icon: 'fa fa-file-image-o',
                views: [
                    {
                        name: 'Display',
                        template: 'customSliderProperties.html'
                    },
                    {
                        name: 'Validation',
                        template: 'formio/components/radio/validate.html'

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
                     },
                    {
                        name: 'Conditionals',
                        template: 'customSliderConditionals.html'
                    }
                ],
                controller: ['$scope', '$rootScope', function ($scope, $rootScope) {
                    if ($scope.data[$scope.component.key] === undefined) {
                        $scope.data[$scope.component.key] = "0";
                    }
                    var defaultValueConditional = function () {
                        if (!!$scope.component.conditionals &&
                            !!$scope.component.conditionals.defaultValueConditional) {
                            var data = _.cloneDeep($scope.submission.data);
                            var input = $scope.data[$scope.component.key];

                            var defaultValue = eval('(function(data, input) { var value = input;' +
                                $scope.component.conditionals.defaultValueConditional.toString() +
                                '; return value; })(data, input)');

                            $scope.data[$scope.component.key] = defaultValue.toString();
                        }
                    };

                    var disabledConditional = function () {
                        if (!!$scope.component.conditionals &&
                            !!$scope.component.conditionals.disabledConditional) {
                            var data = _.cloneDeep($scope.submission.data);
                            var input = $scope.data[$scope.component.key];

                            var isDisabled = eval('(function(data, input) { var disabled = false;' +
                                $scope.component.conditionals.disabledConditional.toString() +
                                '; return disabled; })(data, input)');

                            $scope.component.disabled = isDisabled;
                            $scope.$applyAsync();
                        }
                    };

                    if (!!$scope.component.conditionals &&
                        !!$scope.component.conditionals.defaultValueBindConditional) {
                        $scope.$watch('data.' + $scope.component.conditionals.defaultValueBindConditional,
                            defaultValueConditional,
                            true);
                    }

                    if (!!$scope.component.conditionals &&
                        !!$scope.component.conditionals.disabledBindConditional) {
                        $scope.$watch('data.' + $scope.component.conditionals.disabledBindConditional,
                            disabledConditional,
                            true);
                    }
                }]
            });
        }
    ]);
