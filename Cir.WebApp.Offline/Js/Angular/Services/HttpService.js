angular.module('formio')
    .factory('httpService', [function () {
        var service = {
            httGet: function (url, onSuccess, onError) {
                const zumoName = $('#ZumoHeaderName').val();
                const zumoVersion = $('#ZumoHeaderVersion').val();

                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            let azureHeaders = {};
                            currentuser.forEach(function (item) {
                                azureHeaders["X-ZUMO-AUTH"] = item.objet.mobileServiceAuthenticationToken;
                            });
                            azureHeaders[zumoName] = zumoVersion;

                            $.ajax({
                                method: "GET",
                                url: url,
                                headers: azureHeaders,
                                success: function (response) {
                                    onSuccess(response);
                                },
                                error: function (err) {
                                    onError(err);
                                }
                            });
                        }
                    }
                });
            }
        };

        return service;
    }]);