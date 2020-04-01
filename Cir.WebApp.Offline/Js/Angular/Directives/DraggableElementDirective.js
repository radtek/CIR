angular.module('formio')
    .directive('draggableElement', function () {
        return {
            restrict: 'A',
            clonedDragable: null,
            link: function (scope, element) {
                var clonedDragable = null;

                element.on('dragstart',
                    function (mdEvent) {
                        mdEvent.preventDefault();

                        document.body.style.cursor = 'move';
                        document.body.onmousemove = function (event) {
                            if (!clonedDragable) {
                                return;
                            }

                            clonedDragable.style.top = (event.pageY + 2) + 'px';
                            clonedDragable.style.left = (event.pageX + 2) + 'px';
                        };
                        document.body.onmouseup = function (event) {
                            if (!clonedDragable) {
                                return;
                            }

                            scope.$ctrl.onDragEnd(clonedDragable, event);
                            document.body.removeChild(clonedDragable);

                            clonedDragable = null;
                            document.body.onmousemove = function() {};
                            document.body.onmouseup = function () { };
                            document.body.style.cursor = 'default';
                        };

                        clonedDragable = new Image();

                        document.body.appendChild(clonedDragable);

                        clonedDragable.style.position = 'absolute';
                        clonedDragable.style.maxWidth = '100px';
                        clonedDragable.style.top = (mdEvent.pageY + 2) + 'px';
                        clonedDragable.style.left = (mdEvent.pageX + 2) + 'px';
                        clonedDragable.src = mdEvent.target.src;
                        clonedDragable.dataset.id = mdEvent.target.dataset.id;
                    });
            }
        };
    });