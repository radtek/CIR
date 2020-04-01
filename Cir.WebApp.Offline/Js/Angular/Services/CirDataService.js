angular.module('formio')
    .factory('cirService', [function () {
        var service = {
            saveOrUpdateCirInIndexDB: function(cir, cirId) {
                let deferred = $.Deferred();
                
                if (cirId) {
                    cir.modifiedBy = CurrentUserInfo.Name.toLowerCase();                   
                    cir.modifiedOn = new Date();
                    cirOfflineApp.UpdateCirDataJson(cir)
                        .done(function() { deferred.resolve(cir.id); })
                        .fail(function() { deferred.reject(); });
                } else {
                    cir.createdBy = CurrentUserInfo.Name.toLowerCase();
                    cir.modifiedBy = CurrentUserInfo.Name.toLowerCase();                    
                    cir.createdOn = new Date();
                    cir.modifiedOn = new Date();

                    cirOfflineApp.SaveCirSchemaJsonWithData(cir)
                        .done(function(id) { deferred.resolve(id); })
                        .fail(function() { deferred.reject(); });
                }

                return deferred.promise();
            },

            saveCirInCosmosDB: function(cir, cirId) {
                let deferred = $.Deferred();

                try {
                    this.saveOrUpdateCirInIndexDB(cir, cirId).done(function(id) {
                        CallSyncApi("CirSubmissionData/SyncUpdate", "POST", cir).done(function(response) {
                            if (!cir.cirId) {
                                cir.cirId = parseInt(response.response);
                            }
                            service.saveOrUpdateCirInIndexDB(cir, id).done(function() {
                                deferred.resolve(id);
                            });
                        });
                    });
                } catch (e) {
                    deferred.reject(e);
                }

                return deferred.promise();
            },

            getCirFromIndexDBById: function(cirId) {
                let deferred = $.Deferred();

                LoadUserInfo().done(function() {
                    let isTosSpecialist = hasRole("Member");

                    cirOfflineApp.GetCirDataJsonById(cirId)
                        .done(function(cir) {
                            if (!isTosSpecialist ||
                                cir.state === "Draft" ||
                                cir.state === "PendingForBa") {
                                deferred.resolve(cir);
                            } else {
                                CallSyncApi("CirTosLock/LockByTos?id=" + cir.id + "&templateId=" + cir.cirTemplateId,
                                        "POST",
                                        {})
                                    .done(function(result) {
                                        deferred.resolve(JSON.parse(result.response));
                                    }).fail(function() { deferred.reject(); });
                            }
                        })
                        .fail(function() { deferred.reject(); });
                });

                return deferred.promise();
            },

            getCirByNumericId: function(cirId) {
                let deferred = $.Deferred();

                CallSyncApi("CirSubmissionData/GetById?reportId=" + cirId, "GET", "").done(function(result) {
                    deferred.resolve(JSON.parse(result.response));
                });

                return deferred.promise();
            },

            getHistoricalCirByRevisionId: function(revisionId) {
                let deferred = $.Deferred();

                try {
                    CallSyncApi("CirRevisionHistory/GetHistoryCir?cirId=" + revisionId, "GET", {}).done(
                        function(response) {
                            deferred.resolve(JSON.parse(response.response));
                        });
                } catch (e) {
                    deferred.reject(e);
                }

                return deferred.promise();
            },

            postCirLock: function (cir, currentUser) {
                let deferred = $.Deferred();

                CallSyncApi("CirLock/Lock?cirId=" + cir.cirId + "&templateId=" + cir.cirTemplateId + "&currentUser=" + currentUser,
                    "POST",
                    cir).done(
                        function (response) {
                            var lockedCir = JSON.parse(response.response);

                            cirOfflineApp.UpdateCirDataJson(lockedCir)
                                .done(function () { deferred.resolve(lockedCir); })
                                .fail(function () { deferred.reject(); });
                        });

                return deferred.promise();
            }
        };

        return service;
    }]);