angular.module('formio')
    .factory('urlHashService', [function () {
        var service = {
            getHashedObject: function (hash) {
                let hashSplitted = hash.split("&");
                let hashedObject = {};

                hashSplitted.forEach(function(property) {
                    let propertySplitted = property.split("=");

                    if (propertySplitted.length === 2) {
                        hashedObject[propertySplitted[0]] = propertySplitted[1];
                    } else {
                        hashedObject[propertySplitted[0]] = null;
                    }
                });

                return hashedObject;
            }
        };

        return service;
    }]);