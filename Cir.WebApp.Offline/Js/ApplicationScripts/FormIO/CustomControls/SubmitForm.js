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
            formioComponentsProvider.register('submitForm', {
                title: 'Submit Form',
                fbtemplate: 'submitFormView.html',
                template: 'submitForm.html',
                settings: {
                    tableView: true,
                    key: 'submitForm',
                    protected: false,
                    unique: false,
                    persistent: true
                },
                icon: 'fa fa-floppy-o',
                controller: ['$scope', '$rootScope', '$window', '$location', '$timeout', 'cirService', 'cirImageService', 'urlHashService', function ($scope, $rootScope, $window, $location, $timeout, cirService, cirImageService, urlHashService) {

                    $scope.urlHashedObject = urlHashService.getHashedObject($location.hash());
                    $scope.cir = $rootScope.cir && $scope.urlHashedObject.id ? $rootScope.cir : {
                        schema: $rootScope.form,
                        cirTemplateId: $rootScope.templateId
                    };
                    $scope.hashCirId = !!$scope.urlHashedObject.id ? $scope.urlHashedObject.id : null;
                    $scope.cirState = !!$scope.urlHashedObject.state ? $scope.urlHashedObject.state : 0;
                    if ($scope.cirState == 0) {
                        $scope.cirState = !!$scope.cir.previousState ? $scope.cir.previousState : 0;
                    }

                    $scope.$formScope = angular.element('.formio-wizard-wrapper').scope();
                    $scope.$formScope = !$scope.$formScope ? null : $scope.$formScope.$$childHead;

                    $scope.showApproveSubmit = function () {
                        if (hasRole("Administrator") || hasRole("Member"))
                            return true;
                    };

                    $scope.showSubmit = function () {
                        if ((hasRole("Administrator") || hasRole("Member")) && ($scope.cirState == 2)) {
                            return false;
                        }
                        else {
                            return true;
                        }
                    };
                    $scope.showAddNewBlade = function () {
                        //Hiding add new blade button 
                        //if ($rootScope.isBlade && (hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians") || hasRole("Administrator")))
                        //    if ($scope.urlHashedObject.id) {
                        //        !this.cir.relatedCirs ? (this.cir.relatedCirs = $scope.$formScope.submission.data.relatedCirs) : this.cir.relatedCirs;
                        //        if (!this.cir.relatedCirs || this.cir.relatedCirs.length < 3) { return true; }
                        //    } else if (!$scope.$formScope.submission.data.relatedCirs || $scope.$formScope.submission.data.relatedCirs.length < 2) { return true; }
                        return false;
                    };

                    $scope.validatePages = function () {

                        var formScope = angular.element('#formio-wizard-form').scope().$parent;
                        var pageCount = formScope.pages.length;
                        var pagesVisited = _.size(formScope.pageWasVisited);
                        if (pageCount > pagesVisited && (this.cir.isNewCirData == undefined || this.cir.isNewCirData == true)) {
                            NotifyCirMessage("", 'Please visit all pages one by one to allow the system to validate data before submitting.', "warning");

                            return false;
                        }

                        for (var pageIndex in formScope.pageHasErrors) {
                            if (formScope.pageHasErrors.hasOwnProperty(pageIndex) && formScope.pageHasErrors[pageIndex]) {
                                NotifyCirMessage("", 'Please fix errors on page ' + (parseInt(pageIndex) + 1) + ' before submitting.', "danger");

                                return false;
                            }
                        }
                        if ($rootScope.extendedValidation.length > 0) {
                            if (formScope.submission.data["ddlServiceReportNumberType"] == '3') {
                                if ($rootScope.extendedValidation.indexOf("Service Report Number") != -1) {
                                    $rootScope.extendedValidation.splice($rootScope.extendedValidation.indexOf("Service Report Number"), 1);
                                }

                                if ($rootScope.extendedValidation.length > 0) {
                                    NotifyCirMessage("", 'Please input the correct ' + $rootScope.extendedValidation.join() + ' before submitting.', "danger");
                                    return false;
                                }
                            }
                            else {
                                NotifyCirMessage("", 'Please input the correct ' + $rootScope.extendedValidation.join() + ' before submitting.', "danger");
                                return false;
                            }
                        }

                        if ($rootScope.AssignedImages.length > 0) {
                            NotifyCirMessage("", 'Please fix errors on page3 before submitting.', "danger");
                            return false;
                        }
                        if (($rootScope.isBlade == false) && ((!$rootScope.uploadedImageCount || $rootScope.uploadedImageCount <= 0) && formScope.submission.data["cbPlateTypePictureNotPossible"] == 0)) {
                            if (!(!!$scope.cir && (!!$scope.cir.imageReferences && $scope.cir.imageReferences.length > 0))) {
                                NotifyCirMessage("", 'Plate image is required. If you dont have a plate image, please provide a reason on page3.', "danger");
                                return false;
                            }
                        }

                        return true;
                    };

                    var finalizeSaveCallback = function (id, status) {
                        $scope.formioForm.$dirty = false;
                        if (!$scope.hashCirId) {
                            cirImageService.saveBlobs($rootScope.cirId, $scope.submission.blobs, $rootScope.txtTurbineNumber).done(function () {
                                $window.location.href = $location.hash("id=" + id).url();
                                $window.location.href = 'local-history';
                            });
                        }
                        else {
                            cirImageService.saveBlobs($rootScope.cirId, $scope.submission.blobs).done(function () {
                                waitingDialog.hide();
                                NotifyCirMessage("", 'Draft template is saved.', "success");
                                $window.location.href = 'local-history';
                            });
                        }
                    };

                    $scope.submitForm = function () {
                        var arePagesValid = $scope.validatePages();
                        if (!arePagesValid) {
                            return;
                        }

                        var finalizeSave = function (id) {
                            waitingDialog.hide();
                            NotifyCirMessage("", 'Form has been submitted.', "success");
                            $window.location.href = 'local-history';
                        };

                        $rootScope.validationInfo[$scope.$formScope.currentPage] = !$scope.formioForm.$invalid;
                        if (!$rootScope.validationInfo || !$rootScope.validationInfo.some(x => !x)) {
                            var cirRecord = this.cir;
                            cirOfflineApp.GetCirTemplateById(cirRecord.cirTemplateId).done(function (template) {
                                cirRecord.state =
                                    cirRecord.cirTemplateName === "BladeInspection" &&
                                        template.cirBrand.name.indexOf("_WindAMS") != -1
                                        ? "PendingForBa"
                                        : "Submitted";
                                if (!cirRecord.cirId) {
                                    cirRecord.isNewCirData = true;
                                }
                                cirRecord.data = $scope.submission.data;
                                cirRecord.id = $rootScope.cirId;
                                if (!!$rootScope.templateVersion && $rootScope.templateVersion != 0)
                                    cirRecord.templateVersion = $rootScope.templateVersion;

                                cirRecord.sqlProcessStatus = NewCirSqlNotTransferred;
                                if ($scope.submission.blobs != undefined) {
                                    $scope.submission.blobs.forEach(function (e) {
                                        e.turbineNumber = $rootScope.txtTurbineNumber; e.cirId = $rootScope.cirId;
                                    });
                                }
                                if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                                    cirRecord.imageProcessStatus = "NotSynced";
                                }
                                else {
                                    cirRecord.imageProcessStatus = "Synced";
                                }
                                if (window.isElectronApp) {
                                    cirRecord.browserDetails =
                                        "Platform: " +
                                        navigator.platform +
                                        ", Agent: Electron Desktop App, Version: " +
                                        navigator.appVersion +
                                        ", Language: " +
                                        navigator.language;
                                } else {
                                    cirRecord.browserDetails =
                                        "Platform: " +
                                        navigator.platform +
                                        ", Agent: " +
                                        navigator.userAgent +
                                        ", Version: " +
                                        navigator.appVersion +
                                        ", Language: " +
                                        navigator.language;
                                }
                                cirRecord.lockedBy = CurrentUserInfo.Name.toLowerCase();

                                if (!cirRecord.cirTemplateName) {
                                    cirRecord.cirTemplateName = $rootScope.templateName;
                                }
                                cirRecord.data = $scope.SetDateFormat(cirRecord.data);
                                cirRecord.mailStatus = "NotSent";
                                if (cirRecord.imageReferences && $rootScope.imageReferences) {
                                    cirRecord.imageReferences = cirRecord.imageReferences.concat($rootScope.imageReferences);
                                    cirRecord.imageReferences = _.uniq(cirRecord.imageReferences, 'imageId');
                                } else {
                                    if (!cirRecord.imageReferences) {
                                        cirRecord.imageReferences = $rootScope.imageReferences ? $rootScope.imageReferences : [];
                                    }
                                }
                                $rootScope.imageReferences = [];
                                waitingDialog.show('Submitting...', { dialogSize: 'sm', progressType: 'primary' });
                                if (Offline.state == "down") {
                                    cirService.saveOrUpdateCirInIndexDB(cirRecord, $scope.hashCirId)
                                        .done(function (id) {
                                            azureSync.addCirToBlobSyncCirQueue($rootScope.cirId);
                                            finalizeSaveCallback(id, cirRecord.state);
                                        }).fail(function (err) {
                                            waitingDialog.hide();
                                            NotifyCirMessage("", 'Error during saving the template.', "danger");
                                        });
                                }
                                else {
                                    //Delete image reference from CIR JSON
                                    var imagelist1 = !!$scope.submission.blobs ? $scope.submission.blobs.filter(x => x.state == "Deleted") : [];
                                    if (imagelist1.length > 0) {
                                        for (var i = 0; i < imagelist1.length; i++) {
                                            var currentBlob = imagelist1[i];
                                            if (currentBlob.state.toLowerCase() == "deleted") {
                                                var image = (!!cirRecord.imageReferences && cirRecord.imageReferences.length > 0) ? cirRecord.imageReferences.filter(x => x.imageId === currentBlob.imageId) : [];
                                                if (image.length !== 0) {
                                                    cirRecord.imageReferences.splice(cirRecord.imageReferences.indexOf(image[0]), 1);
                                                }
                                            }
                                        }
                                    }
                                    CopyBlob(cirRecord.imageReferences, $rootScope.txtTurbineNumber, $rootScope.cirId).done(function (imageReferenceModel) {
                                        cirRecord.imageReferences = imageReferenceModel;
                                        cirRecord.imageProcessStatus = "Synced";
                                        cirRecord = $scope.isImageSynced(cirRecord);
                                        cirService.saveCirInCosmosDB(cirRecord, $scope.hashCirId)
                                            .done(function (id) {
                                                $scope.formioForm.$dirty = false;
                                                finalizeSave(id);
                                            }).fail(function (err) {
                                                waitingDialog.hide();
                                                NotifyCirMessage("", 'Error during submission the template.', "danger");
                                            });
                                    }).fail(function () {
                                        waitingDialog.hide();
                                        NotifyCirMessage("", 'Error during Image Uploading.', "danger");
                                    });
                                }
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
                        this.cir.sqlProcessStatus = NewCirSqlNotTransferred;
                        this.cir.data = $scope.submission.data;
                        if (!!$rootScope.templateVersion && $rootScope.templateVersion != 0)
                            this.cir.templateVersion = $rootScope.templateVersion;
                        $rootScope.txtTurbineNumber = !!$rootScope.txtTurbineNumber ? $rootScope.txtTurbineNumber : 0;
                        this.cir.id = $rootScope.cirId;
                        this.cir.previousState = !!$scope.cirState ? $scope.cirState : 0;
                        if ($scope.submission.blobs != undefined) {
                            $scope.submission.blobs.forEach(function (e) {
                                e.turbineNumber = $rootScope.txtTurbineNumber; e.cirId = $rootScope.cirId;
                            });
                        }
                        if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                            this.cir.imageProcessStatus = "NotSynced";
                        }
                        else {
                            this.cir.imageProcessStatus = "Synced";
                        }
                        if (!this.cir.cirTemplateName) {
                            this.cir.cirTemplateName = $rootScope.templateName;
                        }
                        if (window.isElectronApp) {
                            this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: Electron Desktop App, Version: " + navigator.appVersion + ", Language: " + navigator.language;
                        }
                        else {
                            this.cir.browserDetails = "Platform: " + navigator.platform + ", Agent: " + navigator.userAgent + ", Version: " + navigator.appVersion + ", Language: " + navigator.language;
                        }
                        this.cir.lockedBy = CurrentUserInfo.Name.toLowerCase();
                        this.cir.data = $scope.SetDateFormat(this.cir.data);
                        this.cir.mailStatus = "NotSent";
                        if (this.cir.imageReferences && $rootScope.imageReferences) {
                            this.cir.imageReferences = this.cir.imageReferences.concat($rootScope.imageReferences);
                            this.cir.imageReferences = _.uniq(this.cir.imageReferences, 'imageId');
                        } else {
                            if (!this.cir.imageReferences) {
                                this.cir.imageReferences = $rootScope.imageReferences ? $rootScope.imageReferences : [];
                            }
                        }
                        $rootScope.imageReferences = [];
                        waitingDialog.show('Saving Changes..', { dialogSize: 'sm', progressType: 'primary' });
                        if (Offline.state == "down") {
                            azureSync.addCirToBlobSyncCirQueue($rootScope.cirId);
                            cirService.saveOrUpdateCirInIndexDB(this.cir, this.hashCirId)
                                .done(function (id) {
                                    azureSync.addCirToBlobSyncCirQueue($rootScope.cirId);
                                    finalizeSaveCallback(id);
                                }).fail(function (err) {
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Error during saving the template.', "danger");
                                });
                        } else {
                            //Delete image reference from CIR JSON
                            var imagelist1 = !!$scope.submission.blobs ? $scope.submission.blobs.filter(x => x.state == "Deleted") : [];
                            if (imagelist1.length > 0) {
                                for (var i = 0; i < imagelist1.length; i++) {
                                    var currentBlob = imagelist1[i];
                                    if (currentBlob.state.toLowerCase() == "deleted") {
                                        var image = (!!this.cir.imageReferences && this.cir.imageReferences.length > 0) ? this.cir.imageReferences.filter(x => x.imageId === currentBlob.imageId) : [];
                                        if (image.length !== 0) {
                                            this.cir.imageReferences.splice(this.cir.imageReferences.indexOf(image[0]), 1);
                                        }
                                    }
                                }
                            }
                            var cirData = this.cir;
                            CopyBlob(this.cir.imageReferences, $rootScope.txtTurbineNumber, $rootScope.cirId).done(function (imageReferenceModel) {
                                cirData.imageReferences = imageReferenceModel;
                                cirData.imageProcessStatus = "Synced";
                                cirData = $scope.isImageSynced(cirData);
                                cirService.saveCirInCosmosDB(cirData, $scope.hashCirId)
                                    .done(
                                        function (id) {
                                            $scope.formioForm.$dirty = false;
                                            if (!$scope.hashCirId) {
                                                $window.location.href = $location.hash("id=" + id).url();
                                                $window.location.href = 'local-history';
                                            }
                                            else {
                                                waitingDialog.hide();
                                                NotifyCirMessage("", 'Draft template is saved.', "success");
                                                $window.location.href = 'local-history';
                                            }
                                        }
                                    ).fail(function (err) {
                                        waitingDialog.hide();
                                        NotifyCirMessage("", 'Error during submission the template.', "danger");
                                    })
                            }).fail(function () {
                                waitingDialog.hide();
                                NotifyCirMessage("", 'Error during Image Uploading.', "danger");
                            });
                        }
                    };
                    $scope.SetDateFormat = function (cirData) {
                        if (!!cirData) {
                            var excludedDates = ["dtheaterinsulationandvacuumoff", "modifiedOn", "createdOn"];
                            for (var key in cirData) {
                                if (!!cirData[key] && excludedDates.indexOf(key) == -1 && cirData[key].constructor == Date) {
                                    cirData[key] = $scope.DateParseFunc(cirData[key]);
                                }
                            }
                        }
                        return cirData;
                    };

                    $scope.DateParseFunc = function (dtDateObj) {
                        dtDateObj = new Date(dtDateObj);
                        var dtMonth = ('0' + (dtDateObj.getMonth() + 1)).slice(-2);
                        var dtDate = ('0' + dtDateObj.getDate()).slice(-2);
                        var dtYear = dtDateObj.getFullYear();
                        var dtParseDateObj = dtYear + "-" + dtMonth + "-" + dtDate + 'T12:00:00Z';
                        return dtParseDateObj;
                    };

                    $scope.submitApproveForm = function () {
                        var arePagesValid = $scope.validatePages();
                        //  $scope.SetDateFormat();
                        if (!arePagesValid) {
                            return;
                        }

                        $rootScope.validationInfo[$scope.$formScope.currentPage] = !$scope.formioForm.$invalid;
                        if (!$rootScope.validationInfo || !$rootScope.validationInfo.some(x => !x)) {
                            this.cir.state = "Approved";
                            if (!this.cir.cirId) {
                                this.cir.isNewCirData = true;
                            }
                            this.cir.sqlProcessStatus = NewCirSqlNotTransferred;
                            this.cir.data = $scope.submission.data;
                            if (!!$rootScope.templateVersion && $rootScope.templateVersion != 0)
                                this.cir.templateVersion = $rootScope.templateVersion;

                            this.cir.id = $rootScope.cirId;
                            if ($scope.submission.blobs != undefined) {
                                $scope.submission.blobs.forEach(function (e) {
                                    e.turbineNumber = $rootScope.txtTurbineNumber; e.cirId = $rootScope.cirId;
                                });
                            }
                            if (!!$scope.submission.blobs && cirImageService.isBlobAddedDeleted($scope.submission.blobs)) {
                                this.cir.imageProcessStatus = "NotSynced";
                            }
                            else {
                                this.cir.imageProcessStatus = "Synced";
                            }
                            if (window.isElectronApp) {
                                this.cir.browserDetails =
                                    "Platform: " +
                                    navigator.platform +
                                    ", Agent: Electron Desktop App, Version: " +
                                    navigator.appVersion +
                                    ", Language: " +
                                    navigator.language;
                            } else {
                                this.cir.browserDetails =
                                    "Platform: " +
                                    navigator.platform +
                                    ", Agent: " +
                                    navigator.userAgent +
                                    ", Version: " +
                                    navigator.appVersion +
                                    ", Language: " +
                                    navigator.language;
                            }
                            this.cir.lockedBy = CurrentUserInfo.Name.toLowerCase();

                            if (!this.cir.cirTemplateName) {
                                this.cir.cirTemplateName = $rootScope.templateName;
                            }
                            this.cir.data = $scope.SetDateFormat(this.cir.data);
                            this.cir.mailStatus = "NotSent";
                            if (this.cir.imageReferences && $rootScope.imageReferences) {
                                this.cir.imageReferences = this.cir.imageReferences.concat($rootScope.imageReferences);
                                this.cir.imageReferences = _.uniq(this.cir.imageReferences, 'imageId');
                            } else {
                                if (!this.cir.imageReferences) {
                                    this.cir.imageReferences = $rootScope.imageReferences ? $rootScope.imageReferences : [];
                                }
                            }
                            $rootScope.imageReferences = [];
                            waitingDialog.show('Submitting...', { dialogSize: 'sm', progressType: 'primary' });

                            if (Offline.state == "down") {
                                cirService.saveOrUpdateCirInIndexDB(this.cir, this.hashCirId)
                                    .done(function (id) {
                                        azureSync.addCirToBlobSyncCirQueue($rootScope.cirId);
                                        finalizeSaveCallback(id, "Approved");
                                    }).fail(function (err) {
                                        waitingDialog.hide();
                                        NotifyCirMessage("", 'Error during saving the template.', "danger");
                                    });
                            }
                            else {
                                //Delete image reference from CIR JSON
                                var imagelist1 = !!$scope.submission.blobs ? $scope.submission.blobs.filter(x => x.state == "Deleted") : [];
                                if (imagelist1.length > 0) {
                                    for (var i = 0; i < imagelist1.length; i++) {
                                        var currentBlob = imagelist1[i];
                                        if (currentBlob.state.toLowerCase() == "deleted") {
                                            var image = (!!this.cir.imageReferences && this.cir.imageReferences.length > 0) ? this.cir.imageReferences.filter(x => x.imageId === currentBlob.imageId) : [];
                                            if (image.length !== 0) {
                                                this.cir.imageReferences.splice(this.cir.imageReferences.indexOf(image[0]), 1);
                                            }
                                        }
                                    }
                                }
                                var cirData = this.cir;
                                CopyBlob(this.cir.imageReferences, $rootScope.txtTurbineNumber, $rootScope.cirId).done(function (imageReferenceModel) {
                                    cirData.imageReferences = imageReferenceModel;
                                    cirData.imageProcessStatus = "Synced";
                                    cirData = $scope.isImageSynced(cirData);
                                    cirService.saveCirInCosmosDB(cirData, $scope.hashCirId)
                                        .done(function (id) {
                                            $scope.formioForm.$dirty = false;
                                            waitingDialog.hide();
                                            NotifyCirMessage("", 'Form has been Approved & submitted.', "success");
                                            $window.location.href = 'local-history';

                                        }).fail(function (err) {
                                            waitingDialog.hide();
                                            NotifyCirMessage("", 'Error during submission the template.', "danger");
                                        });
                                }).fail(function () {
                                    waitingDialog.hide();
                                    NotifyCirMessage("", 'Error during Image Uploading.', "danger");
                                });
                            }

                        } else {
                            NotifyCirMessage("", 'Please, correct the validation errors before submiting.', "danger");
                        }
                    };

                    $scope.isImageSynced = function (cirInProgress) {
                        if (!!cirInProgress && !(!cirInProgress.imageReferences || (!!cirInProgress.imageReferences && ((!!cirInProgress.data.imagecomponentKey && !!cirInProgress.data.imagecomponentKey.uploadedImagesCache && cirInProgress.imageReferences.length != cirInProgress.data.imagecomponentKey.uploadedImagesCache.length) || (!!cirInProgress.data.page3UploadImages && cirInProgress.imageReferences.length != cirInProgress.data.page3UploadImages.length))))) {
                            cirInProgress.imageProcessStatus = "Synced";
                        }
                        else if (!!cirInProgress && !!cirInProgress.data.page3UploadImages && !!cirInProgress.imageReferences && cirInProgress.data.page3UploadImages.length < cirInProgress.imageReferences.length) {
                            var imageRefList = cirInProgress.imageReferences;
                            for (var i = 0; i < imageRefList.length; i++) {
                                var currentBlob = imageRefList[i];
                                var image = cirInProgress.data.page3UploadImages.filter(x => x.imageId === currentBlob.imageId);
                                if (image.length == 0) {
                                    cirInProgress.imageReferences.splice(cirInProgress.imageReferences.indexOf(imageRefList[i]), 1);
                                }
                            }
                            cirInProgress.imageProcessStatus = "Synced";
                        }
                        else if (!!cirInProgress && !!cirInProgress.data.imagecomponentKey && !!cirInProgress.data.imagecomponentKey.uploadedImagesCache && !!cirInProgress.imageReferences && cirInProgress.data.imagecomponentKey.uploadedImagesCache.length < cirInProgress.imageReferences.length) {
                            var imageRefList = cirInProgress.imageReferences;
                            for (var i = 0; i < imageRefList.length; i++) {
                                var currentBlob = imageRefList[i];
                                var image = cirInProgress.data.page3UploadImages.filter(x => x.imageId === currentBlob.imageId);
                                if (image.length == 0) {
                                    cirInProgress.imageReferences.splice(cirInProgress.imageReferences.indexOf(imageRefList[i]), 1);
                                }
                            }
                            cirInProgress.imageProcessStatus = "Synced";
                        } else {
                            cirInProgress.sqlProcessStatus = "Error: Image upload failed.";
                            cirInProgress.imageProcessStatus = "NotSynced"
                        }
                        return cirInProgress;
                    }

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
                            ddlCimCaseNumber: $scope.submission.data.ddlCimCaseNumber,
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
                            ctbUpTowerSolutionAvailable: $scope.submission.data.ctbUpTowerSolutionAvailable,
                            txtDescriptionofAnyConsequentialProblemsDamage: $scope.submission.data.txtDescriptionofAnyConsequentialProblemsDamage,
                            txtSBURecommendation: $scope.submission.data.txtSBURecommendation,
                            txtAlarmLogNumber: $scope.submission.data.txtSBURecommendation,
                            dtCommissioningdate: $scope.submission.data.dtCommissioningdate,
                            dtInstallationDate: $scope.submission.data.dtInstallationDate,
                            ddlInstallationDateType: $scope.submission.data.ddlInstallationDateType,
                            ctbAnnualInspection: $scope.submission.data.ctbAnnualInspection,
                            txtInternalComments: $scope.submission.data.txtSBURecommendation,
                            txtAdditionalInformation: $scope.submission.data.txtAdditionalInformation,
                            txtAlarmLogNumber: $scope.submission.data.txtAlarmLogNumber,
                            // relatedCirs: $scope.cir.relatedCirs
                        };
                    };
                    $scope.updateRelatedCirs = function (id, newId, status) {
                        let deferredObject = $.Deferred();
                        //cirOfflineApp.GetCirDataJsonById(id).done(function (item) {
                        //    item.modifiedOn = new Date();
                        //    item.modifiedBy = CurrentUserInfo.Name.toLowerCase();
                        //    item.lockedBy = CurrentUserInfo.Name.toLowerCase();
                        //    var index = item.relatedCirs.findIndex(x => x.id == newId);
                        //    if (index === -1) {
                        //        item.relatedCirs.push({ 'id': newId });
                        //    }
                        //    if (status) {
                        //        item.state = status;
                        //    }
                        //    cirOfflineApp.UpdateCirDataJson(item).done(function () {
                        //        deferredObject.resolve();
                        //    }).fail(function (e) {
                        //        deferredObject.reject();
                        //    });
                        //}).fail(function (ex) {
                        //    deferredObject.reject();
                        //});

                        return deferredObject.promise();
                    };
                    $scope.callUpdateRealtedCirs = function (cirs, guid, status) {
                        //if ($rootScope.isBlade) {
                        //    var array = cirs.filter(function (x) { return x.id != guid; })
                        //    for (var rid in array) {
                        //        $scope.updateRelatedCirs(array[rid].id, guid, status);
                        //    }
                        //}
                    };
                }]
            });
        }
    ]);