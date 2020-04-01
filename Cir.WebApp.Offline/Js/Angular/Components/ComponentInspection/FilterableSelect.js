angular.module('formio')
    .component('filterableSelect', {
        templateUrl: 'filterableSelectTemplate.html',
        bindings: {
            items: '<',
            value: '<',
            onvaluechosen: '&'
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor() {
                this.itemsVisible = false;
                this.filteredItems = [];
                this.isFocused = false;
            }

            $onInit() {
                this.filteredItems = [...this.items];
            }

            focus() {
                this.isFocused = true;
            }

            toggleSelectBox() {
                this.itemsVisible = !this.itemsVisible;
            }

            closeSelectBox() {
                // please don't just negate the expression. it's supposed to be false, period.
                this.itemsVisible = false;
                this.isFocused = false;
            }

            chooseValue(value) {
                var chosenItem = this.items.filter(function (el) {
                    return el === value;
                })[0];
                this.value = chosenItem;
                this.filteredItems = [...this.items];

                this.closeSelectBox();
                this.onvaluechosen({ newValue: chosenItem });
            }

            onChangeInput() {
                this.filteredItems = this.items.filter(function(el) {
                    return el.toLowerCase().indexOf(this.value) > -1;
                }.bind(this));
                this.itemsVisible = true;
            }

            onKeyDown(event) {
                if (event.keyCode === 13) {
                    event.preventDefault();
                    event.stopPropagation();

                    return false;
                }

                return true;
            }
        }
    });