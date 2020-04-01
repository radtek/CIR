﻿angular.module('formio')
    .component('imageRepairTool', {
        templateUrl: 'imageRepairToolView.html',
        bindings: {
            component: '=',
            data: '=',
            blobModel: '=',
            fulldata: '=',
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($rootScope, $scope, $filter, biImageService, globalVariables, imageInspectionValidator) {
                this._rootScope = $rootScope;
                this._scope = $scope;
                this.filter = $filter;
                this._biImageService = biImageService;
                this._activeSection = -1;
                this.validator = imageInspectionValidator;
                this.plateImageId = '';
                this.assignedImgsVisible = false;
                this.unassignedImgsVisible = true;
                this.sides = {};
                this.severityColors = [
                    '#808080',
                    '#00963D',
                    '#8BC34A',
                    '#FFDF25',
                    '#FFB700',
                    '#CC0000'
                ];
                this.plateImage = null;
                this.canvasRenderer = null;
                this.hoverColor = '#0094FF';
                this.images = [];
                this.cntrl = '$ctrl';
                this.modalOpenRequested = false;
                this.imagePreviewOpenRequested = false;
                this.activeImgId = '';
                this.hasTemplate = true;
                this.cursorStyle = { cursor: 'default' };
                this.acceptImageTypes = globalVariables.imageTypes();
                this.activeImageSrc = '';
            }

            $onInit() {
                if (!this.hasTemplate) {
                    return;
                }
                if (!this.data) {
                    this.data = {};
                }
                if (!this.data.uploadedImagesCache) {
                    this.data.uploadedImagesCache = [];
                }
                if (this.data.withPlatePicture === undefined) {
                    this.data.withPlatePicture = true;
                }
                if (!this.blobModel) {
                    this.blobModel = [];
                }
                if (!this.component.data.imageData) {
                    this.hasTemplate = false;
                }

                this.canvasRenderer = CanvasRendererController(
                    document.getElementById('renderer-component-canvas'),
                    document.getElementById('canvas-wrapper'),
                    this.component.data,
                    -1);

                for (var key in this.component.data.sidesData) {
                    if (!this.component.data.sidesData.hasOwnProperty(key)) {
                        continue;
                    }

                    this.sides[key + ''] = this.component.data.sidesData[key].side;
                }

                this._initializeSections();
                this._observeBlobModel();
                this.validator.validate(this);
            }

            onFilesSelected() {
                return function (files) {
                    waitingDialog.show('Uploading Images..', {
                        dialogSize: 'sm', progressType: 'primary'
                    });
                    this._readImages(files, function () {
                        this.plateImageId = this.images[0].imageId;
                        this.plateImage = this.images[0].src;
                        this._setApiModel();
                    }.bind(this));
                }.bind(this);
            }

            redirectToFilePicker(event) {
                event.preventDefault();
                document.getElementById('choose-images').click();
            }

            onDrop(event) {
                waitingDialog.show('Uploading Images..', {
                    dialogSize: 'sm', progressType: 'primary'
                });
                this._readImages(event.dataTransfer.files, function () {
                    this.plateImageId = this.images[0].imageId;
                    this.plateImage = this.images[0].src;
                    this._setApiModel();
                }.bind(this));
                
            }

            onCleanUp(event) {
                var dt = event.dataTransfer;

                if (dt.items) {
                    for (var i = 0; i < dt.items.length; i++) {
                        dt.items.remove(i);
                    }
                } else {
                    event.dataTransfer.clearData();
                }
            }

            closeModal() {
                this.modalOpenRequested = false;
            }

            saveImage(model) {
                var images = this.images.filter(function (img) {
                    return img.imageId === model.imageId;
                });

                if (!images.length) {
                    return;
                }

                var image = images[0];
                if (model.damageIdentified) {
                    this._updateImageDmgIdentified(model, image);
                } else {
                    this._updateImageDmgNotIdentified(image, model);
                }
                this.plateImageId
                this._setApiModel();
                this._biImageService.updateImage(this.data, image);
                this.validator.validate(this);
            }

            _updateImageDmgIdentified(model, image) {
                for (var key in model) {
                    if (!model.hasOwnProperty(key) || key === 'damageDescriptionText') {
                        continue;
                    }

                    image[key] = model[key];
                }
                if (!!model.damageDescriptionText) {
                    image.damageDescription = model.damageDescriptionText;
                }
                if (image.region !== -1) {
                    image.color = this.severityColors[image.damageSeverity];
                    image.saved = true;

                    this.canvasRenderer.updateImageOnRegion(
                        image.region,
                        {
                            id: model.imageId,
                            severity: image.damageSeverity,
                            color: image.color
                        });
                    //this.images = this.filter('orderBy')(this.images, '-damageSeverity');
                }
            }

            _updateImageDmgNotIdentified(image, model) {
                image.damagePlacement = '';
                image.damageType = '';
                image.side = 'N/A';
                image.radius = null;
                image.damageDescription = null;
                if (model != null) {
                    if (model.txtdamageDescription == null || model.txtdamageDescription == '')
                        image.damageDescription = "No Damage";
                    else
                        image.damageDescription = model.txtdamageDescription;
                }
                image.damageSeverity = 0;
                image.damageIdentified = false;
                image.color = this.severityColors[image.damageSeverity];
                image.saved = true;
                image.observations = [];
                if (model != null) {
                    this.canvasRenderer.updateImageOnRegion(
                           image.region,
                           {
                               id: model.imageId,
                               severity: image.damageSeverity,
                               color: image.color
                           });
                }
            }

            removeImages() {
                var idsToRemove = [];

                for (var i = this.images.length - 1; i >= 0; i--) {
                    if (!this.images[i].checked) {
                        continue;
                    }

                    var img = this.images.splice(i, 1)[0];

                    idsToRemove.push(img.imageId);

                    if (img.imageId === this.plateImageId) {
                        this.plateImageId = null;
                        this.plateImage = null;
                    } else {
                        this.canvasRenderer.removeImageFromRegion(img.region, img.imageId);
                    }
                }

                this._setApiModel();
                this._biImageService.removeImages(idsToRemove, this.blobModel, this.data);
                this.validator.validate(this);
                this._recalculateNumbers();
            }

            highlight(event) {
                this.canvasRenderer.highlight(event);
            }

            removeHighlighting() {
                this.canvasRenderer.removeHighlighting();
            }

            openModal(event) {
                this._activeSection = this.canvasRenderer.getRegionFor(event);

                if (this._activeSection === -1) {
                    return;
                }

                //this.images = this.images.sort(function (a, b) {
                //    return a.region - b.region || a.saved - b.saved || b.damageSeverity - a.damageSeverity;
                //});

                var filtered = this.images.filter(function (img) {
                    return img.region === this._activeSection;
                }.bind(this));

                if (filtered.length === 0) {
                    return;
                }

                this.modalOpenRequested = true;
                this.activeImgId = filtered[0].imageId;
                this.images = this.filter('orderBy')(this.images, 'imageNumber');
            }
            openPreview(event) {
                if (this.plateImage == null) {
                    return;
                }
                this.activeImageSrc = this.plateImage;
                this.imagePreviewOpenRequested = true;
                this._scope.$broadcast('showInspectionPreview', this.activeImageSrc);

            }
            closePreview() {
                this.imagePreviewOpenRequested = false;
                this.activeImageSrc = '';
            }
            openImagePreview(event, imageid) {
                if (imageid != undefined && imageid != '') {
                    var filtered = this.images.filter(function (img) {
                        return img.imageId === imageid;
                    }.bind(this));
                    if (filtered.length === 0) {
                        return;
                    }
                    this.activeImageSrc = filtered[0].src;
                    this.imagePreviewOpenRequested = true;
                    this._scope.$broadcast('showInspectionPreview', this.activeImageSrc);

                }
            }
            validateReason() {
                this.validator.validate(this);

                if (!this._scope.reasonForm.$valid) {
                    this._scope.reasonForm.reason.$dirty = true;

                    return;
                }
            }

            removeSelected() {
                var current = this;
                for (var i = this.images.length - 1; i >= 0; i--) {
                    this.images[i].checked = true;
                }
                if (this.images.length > 0) {
                    CirAlert.confirm('Are you wish to delete Tag Id image? These all will remove permanently from the CIR', 'Cir App', 'Yes', 'No', 'warning').done(function () {
                        current.removeImages();
                        current._scope.$apply();
                        var imagenumber = 1;
                        var Sectionnumber = [];
                        var treeids = $("#sectionTree >.images-section img").map(function (index) {
                            var img = this;
                            return img.getAttribute("data-id");

                        });
                        for (var i = 0; i < treeids.length; i++) {
                            var index = current.images.findIndex(x => x.imageId === treeids[i]);
                            var regionid = current.images[index].region;
                            Sectionnumber[regionid - 1] = (Sectionnumber[regionid - 1] ? Sectionnumber[regionid - 1] : 0) + 1;
                            current.images[index].imageSectionOrder = Sectionnumber[regionid - 1];
                            current.images[index].imageNumber = imagenumber;
                            imagenumber = imagenumber + 1;
                        }

                        var unassignedids = $("#unassigned img").map(function (index) {
                            var img = this;
                            return img.getAttribute("data-id");
                        });
                        for (var i = 0; i < unassignedids.length; i++) {
                            var index = current.images.findIndex(x => x.imageId === unassignedids[i]);

                            current.images[index].imageNumber = imagenumber;
                            imagenumber = imagenumber + 1;
                        }
                        current._setApiModel();
                    });

                }
            }

            _recalculateNumbers() {
                var idx = this.images.findIndex(function (img) {
                    return img.imageId === this.plateImageId;
                }.bind(this));

                if (this.data.withPlatePicture && idx > -1) {
                    this.images[idx].imageNumber = 0;
                }
                var imgNumber = 1;
                for (var i = 0; i < this.images.length; i++) {
                    if (i != idx) {
                        this.images[i].imageNumber = imgNumber;
                        imgNumber++;
                    }
                }
            }

            _assignImgToRegion(id, region) {
                var images = this.images.filter(function (image) {
                    return image.imageId === id;
                });

                if (!images.length) {
                    return;
                }

                var imageData = images[0];

                if (imageData.region > -1) {
                    this.canvasRenderer.removeImageFromRegion(imageData.region, id);
                }
                if (imageData.damageDescription === null) {
                    imageData.saved = false;
                }

                this.canvasRenderer.putImageOnRegion(
                    region,
                    {
                        id: id,
                        severity: parseInt(imageData.damageSeverity),
                        color: imageData.color
                    });

                imageData.region = region;

                this._scope.$apply(function () {
                    if (id === this.plateImageId) {
                        this.plateImageId = '';
                        this.plateImage = null;
                    }

                    this._recalculateNumbers();
                    this.validator.validate(this);
                }.bind(this));
                //this.images = this.filter('orderBy')(this.images, '-damageSeverity');
            }

            _assignImgToPlate(img, event) {
                var id = img.dataset.id;
                var images = this.images.filter(function (image) {
                    return image.imageId === id;
                });

                if (!images.length) {
                    return;
                }

                var imageData = images[0];

                imageData.side = 'N/A';

                if (imageData.region > -1) {
                    this.canvasRenderer.removeImageFromRegion(imageData.region, id);

                    imageData.region = -1;
                }

                var plate = document.getElementsByClassName('plate')[0];
                var activatedElement = document.elementFromPoint(event.clientX - 1, event.clientY - 1);

                this._updateImageDmgNotIdentified(imageData, null);
                this._scope.$apply(function () {
                    if (plate === activatedElement || plate === activatedElement.parentNode) {
                        this.plateImage = img.src;
                        this.plateImageId = id;

                        this._recalculateNumbers();
                        this.validator.validate(this);
                    }
                }.bind(this));
            }

            _readImages(files, doneCallback) {
                var counter = 0;
                var filesLen = files.length;
                var imgsCount = this.images.length;

                for (var i = 0; i < files.length; i++) {
                    var fr = new FileReader();

                    fr.onload = function (loadEvent) {
                        var imgData = this._getImageData(loadEvent.target.fileName);

                        this._biImageService.saveImage(
                            imgData,
                            loadEvent.target.result,
                            {
                                blobModel: this.blobModel,
                                data: this.data,
                                images: this.images,
                                cache: this.data.uploadedImagesCache
                            },
                            function () {
                                imgData.imageNumber = imgsCount + counter;
                                this.images.push(imgData);
                                this.validator.validate(this);

                                counter++;

                                if (counter === filesLen) {
                                    waitingDialog.hide();
                                }
                                if (doneCallback) {
                                    doneCallback();
                                }
                            }.bind(this));
                    }.bind(this);
                    fr.fileName = files[i].name;

                    fr.readAsDataURL(files[i]);
                }

                this._scope.$parent.formioForm.$$parentForm.$setValidity(false);
            }

            _getImageData(name) {
                return {
                    groupId: -1,
                    width: 0,
                    height: 0,
                    imageId: cirOfflineApp.generateKey(),
                    checked: false,
                    color: null,
                    region: -1,
                    imageName: name,
                    imageNumber: 0,
                    uploadedAt: ImageInspectionUtils.getNowDateStr(),
                    damagePlacement: 'external',
                    damageType: '',
                    side: 'N/A',
                    radius: null,
                    damageDescription: null,
                    damageSeverity: -1,
                    saved: false,
                    observations: [],
                    imageSectionOrder: 0
                };
            }

            _setApiModel() {
                var apiModel = ImageModelMapper.toApiModel(this.images, this.component.data.sidesData, this.plateImageId);

                this.data.sections = apiModel.sections;
                this.data.plate = apiModel.plate;
            }

            _initializeSections() {
                var viewModel = ImageModelMapper.fromApiModel(this.data.sections);

                this.images = viewModel;
            }

            _observeBlobModel() {
                var blobModelWatchUnregister = this._scope.$watchCollection('$ctrl.blobModel',
                    function () {
                        if (!this.blobModel || this.blobModel.length === 0) {
                            return;
                        }
                        if (this.data.plate) {
                            this.plateImageId = this.data.plate.imageId;
                        }

                        this._biImageService.updateImagesFromBlob(this.blobModel, this.images, this.data.uploadedImagesCache, this.plateImageId, function (src) {
                            this.plateImage = src;
                        }.bind(this));
                        this._biImageService.cacheThumbnails();

                        for (var i = 0; i < this.images.length; i++) {
                            this.images[i].saved = true;
                        }

                        this.validator.validate(this);
                        blobModelWatchUnregister();
                    }.bind(this));
            }
        }
    });