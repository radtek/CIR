angular.module('formio')
    .directive('droppableFileArea', function () {
        return {
            restrict: 'A',
            link: function (scope, element) {
                element.on('drop',
                    function(ev) {
                        ev.preventDefault();
                        scope.$ctrl.onDrop(ev.originalEvent);
                    });
                element.on('dragover',
                    function(ev) {
                        ev.preventDefault();
                    });
                element.on('dragend',
                    function(ev) {
                        scope.$ctrl.onCleanUp(ev.originalEvent);
                    });
            }
        };
    });