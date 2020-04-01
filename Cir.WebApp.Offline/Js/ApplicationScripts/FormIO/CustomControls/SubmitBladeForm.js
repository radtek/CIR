angular.module('formio')
    .config(($locationProvider) =>
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        })
    )
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('submitBladeForm', {
                title: 'Submit Blade Form',
                fbtemplate: 'submitBladeFormView.html',
                template: 'submitBladeForm.html',
                settings: {
                    tableView: true,
                    key: 'submitBladeForm',
                    protected: false,
                    unique: false,
                    persistent: true
                },
                icon: 'fa fa-floppy-o',
                controller: ['$scope', '$rootScope', '$window', '$location', '$timeout', 'cirService', 'cirImageService', 'urlHashService', function ($scope, $rootScope, $window, $location, $timeout, cirService, cirImageService, urlHashService) {

                    $scope.cir = $rootScope.cir ? $rootScope.cir : {
                        schema: $rootScope.form,
                        cirTemplateId: $rootScope.templateId
                    };
                    $scope.urlHashedObject = urlHashService.getHashedObject($location.hash());
                    $scope.cirId = $scope.urlHashedObject.id;

                    $scope.$formScope = angular.element('.formio-wizard-wrapper').scope();
                    $scope.$formScope = !$scope.$formScope ? null : $scope.$formScope.$$childHead;

                    //hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator")
                    $scope.showSubmitButton = function () {
                        return $scope.$formScope.currentPage == $scope.$formScope.pages.length - 1;
                    }
                    $scope.showAddNewBlade = function () {
                        if (($scope.$formScope.currentPage == $scope.$formScope.pages.length - 1) && hasRole("BirCreator"))
                            return true;
                    }
                    $scope.showApproveSubmit = function () {
                        if (($scope.$formScope.currentPage == $scope.$formScope.pages.length - 1) && hasRole("Administrator"))
                            return true;
                    }

                    $scope.validatePages = function () {
                        var formScope = angular.element('#formio-wizard-form').scope().$parent;
                        var pageCount = formScope.pages.length;
                        var pagesVisited = _.size(formScope.pageWasVisited);

                        if (pageCount > pagesVisited) {
                            NotifyCirMessage("", 'Please, visit every page before submiting.', "danger");

                            return false;
                        }

                        for (var pageIndex in formScope.pageHasErrors) {
                            if (formScope.pageHasErrors.hasOwnProperty(pageIndex) && formScope.pageHasErrors[pageIndex]) {
                                NotifyCirMessage("", 'Please, fix errors on page ' + (parseInt(pageIndex) + 1) + ' before submiting.', "danger");

                                return false;
                            }
                        }

                        return true;
                    };

                    $scope.submitForm = function () {
                        var arePagesValid = $scope.validatePages();

                        if (!arePagesValid) {
                            return;
                        }

                        $rootScope.validationInfo[$scope.$formScope.currentPage] = !$scope.formioForm.$invalid;
                        if (!$rootScope.validationInfo || !$rootScope.validationInfo.some(x => !x)) {
                            this.cir.state = 'Submitted';
                            if (!this.cir.cirId) {
                                this.cir.isNewCirData = true;
                            }
                            this.cir.data = $scope.submission.data;
                            if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                                this.cir.imageProcessStatus = "NotSynced";
                            }
                            else {
                                this.cir.imageProcessStatus = "Synced";
                            }
                            if (window.isElectronApp) {
                                this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: Electron Desktop App, Version: " + navigator.appVersion + ", Language: " + navigator.language;
                            }
                            else {
                                this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: " + navigator.userAgent + ", Version: " + navigator.appVersion + ", Language: " + navigator.language;
                            }
                            this.cir.lockedBy = CurrentUserInfo.Name.toLowerCase();

                            waitingDialog.show('Submission..', { dialogSize: 'sm', progressType: 'primary' });

                            cirService.saveCirInCosmosDB(this.cir)
                                .done(function (id) {
                                    $scope.formioForm.$dirty = false;
                                    if ($scope.cirId) {
                                        cirImageService.saveBlobs($scope.cirId, $scope.submission.blobs);
                                    }
                                    $window.location.href = 'local-history';
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Form has been submitted.', "success");
                                }).fail(function (err) {
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Error during submission the template.', "danger");
                                });
                        } else {
                            NotifyCirMessage("", 'Please, correct the validation errors before submiting.', "danger");
                        }
                    };
                    $scope.submitDraft = function () {
                        this.cir.state = 'Draft';
                        if (!this.cir.cirId) {
                            this.cir.isNewCirData = true;
                        }
                        this.cir.data = $scope.submission.data;
                        if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                            this.cir.imageProcessStatus = "NotSynced";
                        }
                        else {
                            this.cir.imageProcessStatus = "Synced";
                        }
                        if (window.isElectronApp) {
                            this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: Electron Desktop App, Version: " + navigator.appVersion + ", Language: " + navigator.language;
                        }
                        else {
                            this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: " + navigator.userAgent + ", Version: " + navigator.appVersion + ", Language: " + navigator.language;
                        }
                        this.cir.lockedBy = CurrentUserInfo.Name.toLowerCase();

                        waitingDialog.show('Saving Changes..', { dialogSize: 'sm', progressType: 'primary' });

                        cirService.saveOrUpdateCirInIndexDB(this.cir)
                            .done(function (id) {
                                $scope.formioForm.$dirty = false;
                                if (!$scope.cirId) {
                                    $window.location.href = $location.hash("id=" + id).url();
                                }
                                else {
                                    cirImageService.saveBlobs($scope.cirId, $scope.submission.blobs);
                                }
                                waitingDialog.hide();
                                if ($scope.$formScope.currentPage == $scope.$formScope.pages.length - 1)
                                    NotifyCirMessage("", 'CIR has been created/updated successfully.<br>\nYou need to submit the CIR for further process.<br>\nYou can also <b>add a new blade </b>to the same wind turbine data by pressing the corresponding button below.', "success");
                                else
                                    NotifyCirMessage("", 'Draft template is saved.', "success");
                            }).fail(function (err) {
                                waitingDialog.hide();
                                NotifyCirMessage("", 'Error during saving the template.', "danger");
                            });
                    };

                  
                    $scope.chageToFirstPage = function () {
                        $scope.$formScope.currentPage = 0;
                        $scope.$formScope.showAlerts(null);
                        $scope.$formScope.pageWasVisited[$scope.$formScope.currentPage] = true;
                        $scope.$formScope.wizardLoaded = false;
                        $scope.$formScope.page.components = [];
                        $scope.$formScope.page.components.length = 0;
                        $timeout(function () {
                            $scope.$formScope.page.components = $scope.$formScope.pages[$scope.$formScope.currentPage].components;
                            $scope.$formScope.activePage = $scope.$formScope.pages[$scope.$formScope.currentPage];
                            $scope.$formScope.formioAlerts = [];
                            $scope.$formScope.wizardLoaded = true;
                            window.scrollTo(0, $scope.$formScope.wizardTop);
                            $scope.$formScope.$emit('wizardPage', $scope.$formScope.currentPage);
                            $timeout($scope.$formScope.$apply.bind($scope.$formScope));
                        });
                    };

                    $scope.copyWindTurbineData = function () {
                        return {
                            rbReportType: $scope.submission.data.rbReportType,
                            txtCimCaseNumber: $scope.submission.data.txtCimCaseNumber,
                            txtReasonforService: $scope.submission.data.txtReasonforService,
                            txtTurbineNumber: $scope.submission.data.txtTurbineNumber,
                            txtLocalPadIdNumber: $scope.submission.data.txtLocalPadIdNumber,
                            ddlRunStatusatArrival: $scope.submission.data.ddlRunStatusatArrival,
                            dtFailuredate: $scope.submission.data.dtFailuredate,
                            dtInspectionDate: $scope.submission.data.dtInspectionDate,
                            txtServiceordernumber: $scope.submission.data.txtServiceordernumber,
                            ddlServiceReportNumberType: $scope.submission.data.ddlServiceReportNumberType,
                            txtSAPNotification: $scope.submission.data.txtSAPNotification,
                            txtRunhrs: $scope.submission.data.txtRunhrs,
                            txtGenerator1hrs: $scope.submission.data.txtGenerator1hrs,
                            txtGenerator2hrs: $scope.submission.data.txtGenerator2hrs,
                            txtTotalproductionkWh: $scope.submission.data.txtTotalproductionkWh,
                            ddlRunstatusafterinspection: $scope.submission.data.ddlRunstatusafterinspection,
                            txtQuantityoffailedcomponentsproblems: $scope.submission.data.txtQuantityoffailedcomponentsproblems,
                            txtDescriptionofactivity: $scope.submission.data.txtDescriptionofactivity,
                            txtDescription: $scope.submission.data.txtDescription,
                            ddlUpTowerSolutionAvailable: $scope.submission.data.ddlUpTowerSolutionAvailable,
                            txtDescriptionofAnyConsequentialProblemsDamage: $scope.submission.data.txtDescriptionofAnyConsequentialProblemsDamage,
                            txtSBURecommendation: $scope.submission.data.txtSBURecommendation,
                            txtAlarmLogNumber: $scope.submission.data.txtSBURecommendation,
                            txtInternalComments: $scope.submission.data.txtSBURecommendation
                        };
                    };

                    /*Auto save and warning about living page*/
                    $scope.autosave = function () {
                        if ($scope.formioForm.$dirty) {
                            $scope.submitDraft();
                        }
                    };
                    $scope.autosaveTimer = setInterval($scope.autosave, 60000);
                    window.onunload = function () {
                        clearInterval($scope.autosaveTimer);
                    };
                    window.onbeforeunload = function () {
                        if ($scope.formioForm.$dirty) {
                            return "Do you really want to close?";
                        }
                    };
                    $scope.submitApproveForm = function () {
                        var arePagesValid = $scope.validatePages();

                        if (!arePagesValid) {
                            return;
                        }

                        $rootScope.validationInfo[$scope.$formScope.currentPage] = !$scope.formioForm.$invalid;
                        if (!$rootScope.validationInfo || !$rootScope.validationInfo.some(x => !x)) {
                            this.cir.state = 'Approved';
                            if (!this.cir.cirId) {
                                this.cir.isNewCirData = true;
                            }
                            if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                                this.cir.imageProcessStatus = "NotSynced";
                            }
                            else {
                                this.cir.imageProcessStatus = "Synced";
                            }
                            if (window.isElectronApp) {
                                this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: Electron Desktop App, Version: " + navigator.appVersion + ", Language: " + navigator.language;
                            }
                            else {
                                this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: " + navigator.userAgent + ", Version: " + navigator.appVersion + ", Language: " + navigator.language;
                            }
                            this.cir.lockedBy = CurrentUserInfo.Name.toLowerCase();

                            this.cir.data = $scope.submission.data;
                            waitingDialog.show('Submission..', { dialogSize: 'sm', progressType: 'primary' });
                            cirService.saveCirInCosmosDB(this.cir)
                                .done(function (id) {
                                    $scope.formioForm.$dirty = false;
                                    if ($scope.cirId) {
                                        cirImageService.saveBlobs($scope.cirId, $scope.submission.blobs);
                                    }
                                    $window.location.href = 'local-history';
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Form has been approved & submitted.', "success");
                                }).fail(function (err) {
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Error during submission the template.', "danger");
                                });
                        } else {
                            NotifyCirMessage("", 'Please, correct the validation errors before submiting.', "danger");
                        }
                    };
                }]
            });
        }
    ]);