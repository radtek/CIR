angular.module('formio')
    .factory('globalVariables', function () {
        return {
            imageTypes: function () {
                return $('#ImageTypes').val();
            },
            imageDefaultWidth: function () {
                return $('#ImageResolutionWidth').val();
            },
            dropdownDataTypes: function () {
                return $('#DropdownDataTypes').val();
            }
        }
    });