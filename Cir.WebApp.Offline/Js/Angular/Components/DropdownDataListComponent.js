angular.module('formio')
    .component('dropdownDataList', {
        templateUrl: 'dropdownDataListTemplate.html',
        bindings: {
            itemsList: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope) {
                this.$scope = $scope;
            }
            deleteItem(itemId) {
                this.itemsList.splice(itemId, 1);
            }
            addItem() {
                if (!this.itemsList) {
                    this.itemsList = [];
                }
                if (this.validateNewFields()) {
                    this.itemsList.push({ "label": this.newlabel, "value": this.newvalue });
                    this.clearNewItemFields();
                }
            }

            clearNewItemFields() {
                this.newlabel = '';
                this.newvalue = '';
            }

            validateNewFields() {
                if (this.newlabel == ''
                        || typeof(this.newlabel) === 'undefined'
                        || this.newvalue == ''
                        || typeof (this.newvalue) === 'undefined')
                    return false;
                return true;
            }
        }
    });