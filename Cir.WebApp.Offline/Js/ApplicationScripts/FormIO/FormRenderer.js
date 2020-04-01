angular
    .module('formRenderer', ['ui.bootstrap', 'ui.select', 'formio'])
    .config(($locationProvider) =>
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        })
    )
    .controller('saveJsonController', ['$scope', '$rootScope', '$location', 'cirService', 'templateService', 'hotListService', 'cirImageService', 'urlHashService', function ($scope, $rootScope, $location, cirService, templateService, hotListService, cirImageService, urlHashService) {
        $scope.formInputModel = { data: {} };
        $scope.templates = [];
        $scope.hotList = [];
        $scope.urlHashedObject = urlHashService.getHashedObject($location.hash());
        $scope.cirTypeVisible = false;
        $scope.hotListVisible = false;
        $scope.templateType = '';
        $rootScope.templateVersion = 0;
        $scope.isWindAmsBrand = false;
        $rootScope.isLocked = false;
        $rootScope.form = null;
        $rootScope.isBlade = false;
        $rootScope.extendedValidation = [];
        $rootScope.AssignedImages = [];
        //$scope.bladeRepairTemplateId = '';

        $scope.showTemplateSelection = () => {
            return !((!!$scope.urlHashedObject.id && $scope.urlHashedObject.id) || $rootScope.form);
        };

        $scope.showForm = () => {
            return !$scope.showTemplateSelection();
        };

        $scope.showCirType = () => {
            $scope.cirTypeVisible = true;
            $scope.hotListVisible = false;
        }

        $scope.showHotList = () => {
            $scope.cirTypeVisible = false;
            $scope.hotListVisible = true;
        }

        $scope.runInspectTool = function () {
            if (window.isElectronApp) {
                electronProxy.RunInspectTool();
            }
        };

        $scope.showBladeInspection = function () {
            return !$rootScope.isBlade;
        };

        $scope.init = function () {
            dbtransaction.openDatabase(function () {
                cirOfflineApp.loadGearTypeDamageDecision();
            });
            let cirId = !!$scope.urlHashedObject.id ? $scope.urlHashedObject.id : null;
            $scope.cirDataId = !!$scope.urlHashedObject.cirDataId ? $scope.urlHashedObject.cirDataId : null;
            $scope.state = !!$scope.urlHashedObject.state ? $scope.urlHashedObject.state : null;
            let isHistoryCir = !!$scope.urlHashedObject.isHistorical ? $scope.urlHashedObject.isHistorical : null;
            if (!$rootScope.validationInfo) {
                $rootScope.validationInfo = [];
            }
            if (cirId) {
                if (isHistoryCir) {
                    cirService.getHistoricalCirByRevisionId(cirId)
                        .done(function (response) {
                            $scope.$apply(function () {
                                $rootScope.cir = response.cirSubmissionData;
                                $rootScope.form = response.cirSubmissionData.schema;
                                $scope.formInputModel.data = response.cirSubmissionData.data;
                                $rootScope.templateId = response.cirSubmissionData.cirTemplateId;
                                $rootScope.isBlade = templateService.isBladeInspection(response.cirSubmissionData.cirTemplateName);
                                $scope.template.name = response.cirSubmissionData.cirTemplateName;
                                cirImageService.loadBlobs(cirId).done(function (blobs) {
                                    $scope.formInputModel.blobs = blobs;
                                });
                            });
                        })
                        .fail(function () {
                            NotifyMe("", "CIR Not Found.", "danger");
                        });
                } else {
                    if ($.isNumeric(cirId)) {
                        cirService.getCirByNumericId(cirId)
                            .done(function (response) {
                                //130795 - if CIR is in Approved/Submitted state but the template is not exists in cirTemplate table in indexedDB. Here we are getting the templage version from the cosmos collection
                                var query = cirOfflineApp.GetCirTemplateById4LocalHistory(response.cirTemplateId);
                                query.done(function (template) {
                                    if (!!template && !!template.versionNumber)
                                        $rootScope.templateVersion = template.versionNumber;
                                    if (template === null) {
                                        CallSyncApi("CirTemplate/GetOldVersion?templateId=" +
                                            response.cirTemplateId,
                                            "GET").done(
                                                function (response) {
                                                    var latestTemplate = JSON.parse(response.response);
                                                    cirOfflineApp.UpdateCirTemplate(latestTemplate).done(function () {
                                                        deferredObject.resolve(latestTemplate);
                                                    })
                                                        .fail(function () {
                                                            deferredObject.reject();
                                                        });
                                                })
                                            .fail(function () {
                                                deferredObject.reject();
                                            });
                                    }
                                }).fail(function (e) {

                                });
                                $scope.cirLoadCallback(response);
                            })
                            .fail(function () {
                                NotifyMe("", "CIR Not Found.", "danger");
                            });

                    } else {
                        cirService.getCirFromIndexDBById(cirId)
                            .done(function (response) {
                                //130767 - If CIR is in draft state but schema field is empty
                                if (response.schema === "") {
                                    var query = cirOfflineApp.GetCirTemplateById4LocalHistory(response.cirTemplateId);
                                    query.done(function (template) {
                                        if (!!template && !!template.versionNumber)
                                            $rootScope.templateVersion = template.versionNumber;
                                        response.schema = template.schema;
                                        $scope.cirLoadCallback(response);
                                    })
                                        .fail(function () {
                                            deferredObject.reject();
                                        });
                                }
                                $scope.cirLoadCallback(response);
                            })
                            .fail(function () {
                                NotifyMe("", "CIR Not Found.", "danger");
                            });
                    }
                }
            } else {
                templateService.getBrands().done(function (brands) {
                    $scope.$apply(function () {
                        $scope.brands = brands;
                    });
                });
            }
        };

        $scope.cirLoadCallback = function (response) {
            var isLocked = response.lockedBy != undefined &&
                response.lockedBy != null &&
                response.lockedBy !== "" &&
                response.lockedBy.toLowerCase() !== CurrentUserInfo.Name.toLowerCase();

            var cirOpenCallback = function (cir) {
                if (cir.templateVersion == 0)
                    cir.templateVersion = $rootScope.templateVersion;
                $rootScope.cir = cir;
                $rootScope.cirId = $rootScope.cir.id;
                $rootScope.form = cir.schema;
                $scope.formInputModel.data = cir.data;
                $rootScope.templateId = cir.cirTemplateId;
                $rootScope.isBlade = templateService.isBladeInspection(cir.cirTemplateName);
                //$scope.template.name = cir.cirTemplateName;


                cirImageService.loadBlobs(cir.id).done(function (blobs) {
                    if (!$scope.formInputModel.blobs) {
                        $scope.formInputModel.blobs = [];
                    }
                    $scope.formInputModel.blobs.push(...blobs);
                    if (!!$rootScope.cir.imageReferences) {
                        $scope.formInputModel.blobs.push(...$rootScope.cir.imageReferences);
                    }

                    $scope.$apply();
                }).fail(function () {
                    $scope.formInputModel.blobs = [];
                    if (!!$rootScope.cir.imageReferences) {
                        $scope.formInputModel.blobs.push(...$rootScope.cir.imageReferences);
                    }

                    $scope.$apply();
                });

                $scope.$apply();
            };

            if (isLocked) {
                NotifyMe("", "CIR Locked By: " + response.lockedBy, "danger");
                //if (response.lockedBy.toLowerCase() !==CurrentUserInfo.Name.toLowerCase()) {
                if (response.lockedBy != undefined &&
                                        response.lockedBy != null && response.lockedBy.toLowerCase() !==CurrentUserInfo.Name.toLowerCase()) {
                    $rootScope.isLocked = true;
                    NotifyMe("", "CIR Locked By: " + response.lockedBy, "danger");
                }
            } else {
                if (!!$scope.cirDataId && !!$scope.state) {
                    var cirDataDetail = {
                        cirDataId: $scope.cirDataId,
                        cirId: "",
                        cirState: $scope.state,
                        filename: "",
                        componentType: "",
                        cIMCaseNumber: "",
                        reportType: "",
                        turbineType: "",
                        turbineNumber: "",
                        progress: 8,
                        modifiedBy: CurrentUserInfo.Name,
                        comment: "",
                        locked: 1,
                        lockedBy: CurrentUserInfo.Name
                    }
                    cirOfflineApp.ValidateLockFromSQL(cirDataDetail).done(function (retVal) {
                        if (retVal.error == 1) {
                            NotifyCirMessage('Error : ', retVal.message, 'danger');
                        }
                    }).fail(function () {

                    });
                }
                if (Offline.state == "down") {
                    cirOpenCallback(response);
                } else {
                    if (response.lockedBy != undefined &&
                        response.lockedBy != null && response.lockedBy.toLowerCase() !== CurrentUserInfo.Name.toLowerCase()) {
                        cirService.postCirLock(response, CurrentUserInfo.Name.toLowerCase()).done(cirOpenCallback).fail(function () {
                            NotifyMe("", "Failed to open CIR.", "danger");
                        });
                    } else {

                        cirOpenCallback(response);
                    }
                }
            }
        }

        $scope.populateTemplatesAndHotlist = function () {
            templateService.getTemplates($scope.selectedBrand).done(function (templates) {
                $scope.$apply(function () {
                    var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Member") || hasRole("Editor") || hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians") || hasRole("Administrator");
                    if (!userValid && hasRole("CIR Evaluator")) {
                        for (var i = templates.length; i--;) {
                            if (templates[i].name !== "SimplifiedCIR")
                                templates.splice(i, 1);
                        }

                    }
                    $scope.templates = templates.map(o => {
                        if (templateService.isBladeInspection(o.name)) {
                            o.name = "Blade";
                        }
                        let parts = o.name.split(/(?=[A-Z])/);

                        o.name = parts.join(' ');

                        return o;
                    });
                });
            });

            hotListService.getItems().done(function (hotListItems) {
                $scope.$apply(function () {
                    $scope.hotList = hotListItems.filter(x => x.brand.id === $scope.selectedBrand);
                });
            });
        }

        $scope.selectTemplate = function () {
            templateService.getTemplateFromApiById($scope.selectedTemplate).done(function (template) {
                $scope.$apply(function () {
                    $rootScope.template = template;
                    if (templateService.isBladeInspection(template.name)) {
                        $rootScope.isBlade = true;
                        if (!!template && !!template.versionNumber)
                            $rootScope.templateVersion = template.versionNumber;
                        $scope.isWindAmsBrand = templateService.isWindAmsBrand(template.cirBrand.name);
                    } else {
                      //if (template.name === 'SimplifiedCIR')
                        //150203 - Preload current user's initials in the Service Engineer/Technician field
                        $scope.formInputModel.data.txtServiceEngineerTechnician = CurrentUserInfo.Name.toLowerCase();
                        $rootScope.isBlade = false;
                        $scope.runTemplate(template);
                    }
                });
            });
        };

        $scope.selectHotlist = function () {
            templateService.getTemplateById($scope.selectedHotListItem.cirTemplate.id).done(function (template) {
                $scope.$apply(function () {
                    $scope.formInputModel.data.txtVestasItemNumber = $scope.selectedHotListItem.vestasItemNumber;
                    $scope.runTemplate(template);
                });
            });
        };

        $scope.selectBladeInspection = function () {
            // $rootScope.isBlade = false; //This varible is futher used when working on blade template.
            $scope.runTemplate($rootScope.template);
        };

        $scope.runTemplate = function (template) {
            $rootScope.form = template.schema;
            $rootScope.templateId = template.id;
            $rootScope.templateName = template.name;
            if (!!template && !!template.versionNumber)
                $rootScope.templateVersion = template.versionNumber;
            $rootScope.cirId = cirOfflineApp.generateKey();
        };

        $scope.$on('formLoad',
            function (form) {
                setTimeout(function () {
                    formRules().applyRoleRules($rootScope);
                }, 0);

                materialUiInit.initStyles();
            });      
    }]);
