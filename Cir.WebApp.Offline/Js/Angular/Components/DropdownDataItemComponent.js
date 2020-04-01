angular.module('formio')
    .component('dropdownDataItem', {
        templateUrl: 'dropdownDataItemTemplate.html',
        bindings: {
            data: '=',
            onDelete: '&'
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope) {
                this.$scope = $scope;
            }

            deleteItem(imageId) {
                this.onDelete();
            }
        }
    }
    );