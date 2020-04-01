angular.module('formio')
    .directive("sortableContainer", [function () {
        return {
            scope: {
                sortableContainer: "="
            },
            link: function (scope, element, attributes) {
                element.sortable({
                    distance: 5,
                    delay: 300,
                    opacity: 0.6,
                    cursor: 'move',
                    start: function (event, ui) {
                        scope.startIndex = ui.item.index();
                        scope.newIndex = -1;
                    },
                    change: function (event, ui) {
                        scope.newIndex = ui.placeholder.index();

                        //handle jquery-ui numbering behaviour
                        if (scope.startIndex < scope.newIndex) {
                            scope.newIndex--;
                        }
                    },
                    stop: function (event, ui) {
                        if (!scope.$parent.$ctrl.onComplete) {
                            if (scope.newIndex === -1) {
                                return;
                            }
                            scope.$apply(function () {
                                angular.forEach(scope.sortableContainer, function (value, key) {
                                    let movedItem = scope.sortableContainer[key].splice(scope.startIndex, 1)[0];
                                    scope.sortableContainer[key].splice(scope.newIndex, 0, movedItem);
                                });
                            });
                        } else {
                            scope.$parent.$ctrl.onComplete(scope,this,ui, event);
                        }
                    }
                });
            }
        }
    }]);