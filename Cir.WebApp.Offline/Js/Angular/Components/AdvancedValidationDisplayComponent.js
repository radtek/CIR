angular.module('formio')
    .component('advancedValidationDisplay', {
        templateUrl: 'advancedValidationDisplayTemplate.html',
        bindings: {
            model: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope, $rootScope, FormioUtils) {
                this.$rootScope = $rootScope;
                this.FormioUtils = FormioUtils;

                this.existedComponents = this.FormioUtils.flattenComponents(this.$rootScope.form.components);
                this.existedComponents = _.reject(this.existedComponents, function (c) {
                    return !c.input || (c.type === 'button') || (!c.label && !c.key);
                }).map(c => c.key);
            }
        }
    });