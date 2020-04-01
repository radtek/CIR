angular.module('formio')
    .factory('urlAnchorService', [function () {
        var service = {
            replaceAnchors: function (url, data) {
                let urlToReplace = angular.copy(url);

                while (urlToReplace.indexOf('{{') != -1) {
                    let startIndex = urlToReplace.indexOf('{{');
                    let endIndex = urlToReplace.indexOf('}}');
                    let controlIdToReplace = urlToReplace.substring(startIndex + 2, endIndex);

                    urlToReplace = urlToReplace.replace('{{' + controlIdToReplace + '}}', data[controlIdToReplace]);
                }
                return urlToReplace;
            }
        };

        return service;
    }]);