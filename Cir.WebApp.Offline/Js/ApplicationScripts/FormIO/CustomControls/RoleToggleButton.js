angular.module('formio')
    .config(($locationProvider) =>
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        })
    )
    .config([
        'formioComponentsProvider',
        function(formioComponentsProvider) {
            formioComponentsProvider.register('roleToggleButton',
                {
                    title: 'Role Toggle Button',
                    fbtemplate: 'roleToggleButtonView.html',
                    template: 'roleToggleButton.html',
                    settings: {
                        tableView: true,
                        key: 'roleToggleButton',
                        protected: false,
                        unique: false,
                        persistent: true
                    },
                    icon: 'fa fa-stop',
                    views: [
                        {
                            name: 'Display',
                            template: 'roleToggleButtonProperties.html'
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
                    onEdit: ['$scope', function($scope) {
                        $scope.roles = function() {
                            return AllRoles;
                        }
                    }],
                    controller: [
                        '$scope', '$rootScope', 'FormioUtils', function ($scope, $rootScope, FormioUtils) {
                            var getHiddenFields = function (allComponents) {
                                var components = [];
                                var visibleRolesFlag = formRules().visibleRolesKey;
                                var rolesToToggle = $scope.component.selectedRoles;

                                for (let prop in allComponents) {
                                    if (allComponents.hasOwnProperty(prop) &&
                                        allComponents[prop].hasOwnProperty("properties") &&
                                        allComponents[prop].properties.hasOwnProperty(visibleRolesFlag) &&
                                        allComponents[prop].properties[visibleRolesFlag] !== "") {
                                        var roles = allComponents[prop].properties[visibleRolesFlag].split(",");

                                        $.grep(rolesToToggle,
                                            function(role) {
                                                if (roles.indexOf(role) >= 0) {
                                                    var flag = false;
                                                    $.grep(roles,
                                                        function(item) {
                                                            if (hasRole(item))
                                                                flag = true;
                                                        });

                                                    //it means that component is visible for $scope.component.selectedRoles but not visible for current user role
                                                    if (!flag) {
                                                        components.push(allComponents[prop]);
                                                    }
                                                }
                                            });
                                    }
                                }

                                return components;
                            };

                            var toggleComponentsVisible = function(components) {
                                $.grep(components,
                                    function(component) {
                                        component.hidden = !component.hidden;

                                        if (!component.hidden &&
                                            component.hasOwnProperty("validate") &&
                                            component.validate.hasOwnProperty("wasRequired") &&
                                            component.validate.wasRequired) {
                                            component.validate.required = true;
                                        }
                                    });
                            };

                            $scope.toggleRoleFields = function() {
                                var allComponents = FormioUtils.flattenComponents($rootScope.form.components);
                                var hiddenComponents = getHiddenFields(allComponents);

                                toggleComponentsVisible(hiddenComponents);

                                $rootScope.$applyAsync();
                            };
                        }
                    ]
                });
        }
    ]);