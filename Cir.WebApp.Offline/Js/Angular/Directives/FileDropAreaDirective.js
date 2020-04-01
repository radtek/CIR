angular.module('formio')
    .directive("fileDropArea", [function () {
        return {
            link: function (scope, element, attributes) {
                element.addClass('image-droppable');
                element.addClass('imagedropDefault');

                element.on("dragover", function () {
                    element.addClass("dragover");
                });

                element.on("dragleave", function () {
                    element.removeClass("dragover");
                });

                element.on("drop", function () {
                    element.removeClass("dragover");
                });
            }
        }
    }]);