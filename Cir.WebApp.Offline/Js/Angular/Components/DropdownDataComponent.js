angular.module('formio')
    .component('dropdownData', {
        templateUrl: 'dropdownDataTemplate.html',
        bindings: {
            data: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor(globalVariables) {
                this.fileTypes = globalVariables.dropdownDataTypes();
            }
        }
    });