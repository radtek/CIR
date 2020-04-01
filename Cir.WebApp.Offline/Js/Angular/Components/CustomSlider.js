angular.module('formio')
    .component('customSlider', {
        templateUrl: 'customSliderTemplate.html',
        bindings: {
            component: '=',
            data: '=',
            showLabel: '<',
            value: '='
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope) {

            }

            $onInit(n) {
                if (this.showLabel === undefined) {
                    this.showLabel = true;                   
                }
                if (this.value=== undefined)
                { this.value = 0; }
            }
             onCheck(n) {
                if (this.value!==undefined) {
                    this.value = parseInt(n);
                }
            }
        }
    });