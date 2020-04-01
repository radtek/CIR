angular.module('formio')
    .factory('hotListService', [function () {
        var service = {
            getItems: function () {
                var deferredObject = $.Deferred();

                cirOfflineApp.GetHotListItems().done(function (hotlistItems) {
                    deferredObject.resolve(hotlistItems);
                });

                return deferredObject.promise();
            }
        };

        return service;
    }]);