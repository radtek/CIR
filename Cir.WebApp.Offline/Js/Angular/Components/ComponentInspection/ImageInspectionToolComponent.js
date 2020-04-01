angular.module('formio')
    .component('imageInspectionTool', {
        templateUrl: 'imageInspectionToolTemplate.html',
        bindings: {
            component: '=',
            data: '=',
            blobModel: '='
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
                this.assignedRootTEImgsVisible = false;
                this.assignedRootLWImgsVisible = false;
                this.assignedRootLEImgsVisible = false;
                this.assignedRootWWImgsVisible = false;
                this.assignedMidTEImgsVisible = false;
                this.assignedMidLWImgsVisible = false;
                this.assignedMidLEImgsVisible = false;
                this.assignedMidWWImgsVisible = false;
                this.assignedTipTEImgsVisible = false;
                this.assignedTipLWImgsVisible = false;
                this.assignedTipLEImgsVisible = false;
                this.assignedTipWWImgsVisible = false;
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

                this.canvasRenderer.init(this.data.sections, this.severityColors);
                this._initializeSections();
                this._observeBlobModel();
                this.validator.validate(this);
            }

            toggleUnassignedImgs() {
                this.unassignedImgsVisible = !this.unassignedImgsVisible;
                this.assignedImgsVisible = !this.unassignedImgsVisible;
            }

            toggleAssignedImgs() {
                this.assignedImgsVisible = !this.assignedImgsVisible;
                this.unassignedImgsVisible = !this.assignedImgsVisible;
            }

            toggleAssignedSections(event) {
                var id = event.currentTarget.id;
                switch (id) {
                    case "RootTE":
                        this.assignedRootTEImgsVisible = !this.assignedRootTEImgsVisible;
                        break;
                    case "RootLW":
                        this.assignedRootLWImgsVisible = !this.assignedRootLWImgsVisible;
                        break;
                    case "RootLE":
                        this.assignedRootLEImgsVisible = !this.assignedRootLEImgsVisible;
                        break;
                    case "RootWW":
                        this.assignedRootWWImgsVisible = !this.assignedRootWWImgsVisible;
                        break;
                    case "MidTE":
                        this.assignedMidTEImgsVisible = !this.assignedMidTEImgsVisible;
                        break;
                    case "MidLW":
                        this.assignedMidLWImgsVisible = !this.assignedMidLWImgsVisible;
                        break;
                    case "MidLE":
                        this.assignedMidLEImgsVisible = !this.assignedMidLEImgsVisible;
                        break;
                    case "MidWW":
                        this.assignedMidWWImgsVisible = !this.assignedMidWWImgsVisible;
                        break;
                    case "TipTE":
                        this.assignedTipTEImgsVisible = !this.assignedTipTEImgsVisible;
                        break;
                    case "TipLW":
                        this.assignedTipLWImgsVisible = !this.assignedTipLWImgsVisible;
                        break;
                    case "TipLE":
                        this.assignedTipLEImgsVisible = !this.assignedTipLEImgsVisible;
                        break;
                    case "TipWW":
                        this.assignedTipWWImgsVisible = !this.assignedTipWWImgsVisible;
                        break;
                    default:
                        break;

                }

            }

            onCursorImageEnter(image) {
                if (image.region === -1) {
                    this.cursorStyle = {
                        cursor: 'move'
                    };
                }
            }

            onCursorImageLeave() {
                this.cursorStyle = {
                    cursor: 'default'
                };
            }

            onFilesSelected() {
                return function (files) {
                    waitingDialog.show('Uploading Images..', {
                        dialogSize: 'sm', progressType: 'primary'
                    });
                    this._readImages(files);
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
                this._rootScope.isImageUploaded = true;
                this._readImages(event.dataTransfer.files);
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
            onComplete(sortable, element, ui, event) {
                if (sortable.newIndex === -1) {
                    var imageid = $(ui.item).find('img').attr('data-id');
                    var images = this.images.filter(function (image) {
                        return image.imageId === imageid;
                    });

                    if (!images.length) {
                        return;
                    }

                    var imageData = images[0];
                    imageData.side = 'N/A';
                    if (imageData.region > -1) {
                        this.canvasRenderer.removeImageFromRegion(imageData.region, imageid);

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
                var Sectionnumber = [];
                var imagenumber = 1;
                var regionstart = 0, regionend = 0;
                var treeids = $("#sectionTree >.images-section img").map(function (index) {
                    var img = this;
                    return img.getAttribute("data-id");

                });
                for (var i = 0; i < treeids.length; i++) {
                    var index = this.images.findIndex(x => x.imageId === treeids[i]);
                    var regionid = this.images[index].region;
                    Sectionnumber[regionid - 1] = (Sectionnumber[regionid - 1] ? Sectionnumber[regionid - 1] : 0) + 1;
                    this.images[index].imageSectionOrder = Sectionnumber[regionid - 1];
                    this.images[index].imageNumber = imagenumber;
                    imagenumber = imagenumber + 1;
                }

                //let movedItem = this.images.splice(regionstart+startIndex, 1)[0];
                //this.images.splice(regionstart + newIndex, 0, movedItem);

                var unassignedids = $("#unassigned img").map(function (index) {
                    var img = this;
                    return img.getAttribute("data-id");
                });
                for (var i = 0; i < unassignedids.length; i++) {
                    var index = this.images.findIndex(x => x.imageId === unassignedids[i]);

                    this.images[index].imageNumber = imagenumber;
                    imagenumber = imagenumber + 1;
                }
                this._setApiModel();
                this.images = this.filter('orderBy')(this.images, 'imageNumber');
            }
            onDragEnd(img, event) {

                var region = this.canvasRenderer.getRegionFor(event);

                if (region > 0) {
                    var currentId = img.dataset.id;
                    var draggedIds = this.images.filter(function (image) {
                        return image.imageId !== currentId && image.checked;
                    }).map(function (image) {
                        return image.imageId;
                    });

                    draggedIds.unshift(currentId);

                    for (var i = 0; i < draggedIds.length; i++) {
                        var idx = this.images.findIndex(function (image) {
                            return image.imageId === draggedIds[i];
                        });

                        this._assignImgToRegion(draggedIds[i], region);

                        this.images[idx].checked = false;
                        this.images[idx].side = this.sides[this.images[idx].region + ''];
                    }
                } else {
                    this._assignImgToPlate(img, event);
                }
                var imagenumber = 1;
                var Sectionnumber = [];
                var treeids = $("#sectionTree >.images-section img").map(function (index) {
                    var img = this;
                    return img.getAttribute("data-id");

                });
                for (var i = 0; i < treeids.length; i++) {
                    var index = this.images.findIndex(x => x.imageId === treeids[i]);
                    //this["Section" + this.images[index].region].push(this.images[index]);
                    var regionid = this.images[index].region;
                    Sectionnumber[regionid - 1] = (Sectionnumber[regionid - 1] ? Sectionnumber[regionid - 1] : 0) + 1;
                    this.images[index].imageSectionOrder = Sectionnumber[regionid - 1];
                    this.images[index].imageNumber = imagenumber;
                    imagenumber = imagenumber + 1;
                }

                var unassignedids = $("#unassigned img").map(function (index) {
                    var img = this;
                    return img.getAttribute("data-id");
                });
                for (var i = 0; i < unassignedids.length; i++) {
                    var index = this.images.findIndex(x => x.imageId === unassignedids[i]);

                    this.images[index].imageNumber = imagenumber;
                    imagenumber = imagenumber + 1;
                }

                this._setApiModel();
                this.images = this.filter('orderBy')(this.images, 'imageNumber');
            }

            togglePlatePicture() {
                var reason = $('.reason');
                var plate = $('.plate');
                var onToggle = function () {
                    this._scope.$apply(function () {
                        this.data.withPlatePicture = !this.data.withPlatePicture;
                        if (!this.data.withPlatePicture) {

                            var filtered = this.images.filter(function (img) {
                                return img.imageId === this.plateImageId;
                            }.bind(this));
                            if (filtered.length !== 0) {
                                filtered[0].damageSeverity = -1;
                                filtered[0].saved = false;
                                filtered[0].color = null;
                            }

                            this.plateImage = null;
                            this.plateImageId = null;
                            this.data.plate.fileInfo = null;
                            this.data.plate.imageId = null;
                            this.assignedImgsVisible = false;
                            this.unassignedImgsVisible = true;
                            this.assignedRootTEImgsVisible = false;
                            this.assignedRootLWImgsVisible = false;
                            this.assignedRootLEImgsVisible = false;
                            this.assignedRootWWImgsVisible = false;
                            this.assignedMidTEImgsVisible = false;
                            this.assignedMidLWImgsVisible = false;
                            this.assignedMidLEImgsVisible = false;
                            this.assignedMidWWImgsVisible = false;
                            this.assignedTipTEImgsVisible = false;
                            this.assignedTipLWImgsVisible = false;
                            this.assignedTipLEImgsVisible = false;
                            this.assignedTipWWImgsVisible = false;

                        }
                        else {
                            this.data.reason = null;
                        }
                        this.validator.validate(this);
                        this._recalculateNumbers();
                    }.bind(this));
                }.bind(this);

                if (this.data.withPlatePicture) {
                    plate.fadeTo('fast', 0, function () {
                        reason.fadeTo('fast', 1, function () {
                            onToggle();
                        }.bind(this));
                    }.bind(this));
                } else {
                    reason.fadeTo('fast', 0, function () {
                        plate.fadeTo('fast', 1, function () {
                            onToggle();
                        }.bind(this));
                    }.bind(this));
                }
            }

            toggleImageChecked(event, imageId) {
                event.stopPropagation();

                var index = this.images.findIndex(x => x.imageId === imageId);

                this.images[index].checked = !this.images[index].checked;
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

            removeSelected() {

                var current = this;
                var count = 0;
                for (var i = this.images.length - 1; i >= 0; i--) {
                    if (!this.images[i].checked) {
                        continue;
                    } else
                        count++;
                }
                if (count > 0) {
                    CirAlert.confirm('Are you wish to delete selected image(s)? These all will remove permanently from the CIR', 'Cir App', 'Yes', 'No', 'warning').done(function () {
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

            _readImages(files) {
                var fileData = [];
                var counter = 0;
                var failedCount = 0;
                var file;
                var filesLen = files.length;
                this.Totalfile = filesLen;
                var imgsCount = this.images.length;
                let uploadCount = 0;
                angular.forEach(files, function (value, key) {
                    fileData.push(value);
                });
                var ImageComponent = this;
                var fr = new FileReader();
                GetBlobPath(this._rootScope.cirId, this._rootScope.txtTurbineNumber).done(function (response) {
                    // for (var i = 0; i < files.length; i++) {
                    let imageSyncTimer = setTimeout(function upload() {
                        try {
                            var imageBloblist = [];
                            file = fileData[counter];
                            fr.fileName = file.name;
                            fr.readAsDataURL(file);
                            fr.onload = function (loadEvent) {
                                if (fr.result == null) {
                                    setTimeout(upload, 1000);
                                }
                                else {
                                    var imgData = ImageComponent._getImageData(loadEvent.target.fileName, ImageComponent.images);
                                    ImageComponent._biImageService.saveImage(
                                        imgData,
                                        loadEvent.target.result,
                                        {
                                            blobModel: ImageComponent.blobModel,
                                            data: ImageComponent.data,
                                            images: ImageComponent.images,
                                            cache: ImageComponent.data.uploadedImagesCache
                                        },
                                        function (imageBlobData) {
                                            imgData.imageNumber = imgsCount + counter;
                                            ImageComponent.images.push(imgData);
                                            ImageComponent.validator.validate(ImageComponent);
                                            imageBloblist.push(imageBlobData);
                                            if (Offline.state == "down") {
                                                if (counter === filesLen-1) {
                                                    waitingDialog.hide();
                                                }
                                            } else {
                                                let cirRecord = ImageComponent;
                                                cirRecord._rootScope.imageReferences = cirRecord._rootScope.imageReferences ? cirRecord._rootScope.imageReferences : [];
                                                UploadImageClientOnline(imageBloblist, cirRecord._rootScope.imageReferences, cirRecord._rootScope.txtTurbineNumber, cirRecord._rootScope.cirId, cirRecord._rootScope.templateId, response).done(function (imageReferenceModel) {
                                                    uploadCount++;
                                                    if (cirRecord._rootScope.imageReferences.findIndex(x => x.imageId == imageReferenceModel.imageId) < 0 && (imageReferenceModel.binaryData == null || imageReferenceModel.binaryData.length == 0)) {
                                                        cirRecord._rootScope.imageReferences = cirRecord._rootScope.imageReferences.concat(imageReferenceModel);
                                                    }
                                                    if (uploadCount == cirRecord.Totalfile) {
                                                        cirRecord._rootScope.isImageUploaded = false;
                                                        waitingDialog.hide();
                                                        if (Offline.state == "up" && failedCount > 0) {
                                                            NotifyCirMessage("", '- There is some error ocurred during Image Upload.', "info", 8000);
                                                        }
                                                    }
                                                }).fail(function (error) {
                                                    uploadCount++;
                                                    failedCount++;
                                                    if (uploadCount == cirRecord.Totalfile) {
                                                        cirRecord._rootScope.isImageUploaded = false;
                                                        waitingDialog.hide();
                                                        NotifyCirMessage("", '- There is some error ocurred during Image Upload.', "info", 8000);
                                                    }
                                                });
                                            }
                                            counter++;
                                            if (counter < filesLen) {
                                                setTimeout(upload, 100);
                                            }
                                        }.bind(ImageComponent));
                                }
                            }.bind(ImageComponent);
                        } catch (e) {
                            if (counter < filesLen) {
                                counter++;
                            }
                            if (counter === filesLen) {
                                waitingDialog.hide();
                            }
                        }
                    }, 100);
                    // }
                }).fail(function (error) {
                    waitingDialog.hide();
                    NotifyCirMessage("", "- There is some error ocurred during Image Upload.", "info", 8000);
                    Reset();
                });
                this._scope.$parent.formioForm.$$parentForm.$setValidity(false);
            }

            _generateImageId(imageModel) {
                let imageGuid = cirOfflineApp.generateKey();
                if (!!imageModel && imageModel.length > 0 && imageModel.findIndex(x => x.imageId == imageGuid) > -1) {
                    imageGuid = this._generateImageId(imageModel);
                }
                else {
                    return imageGuid;
                }
            }

            _getImageData(name, imageModel) {
                return {
                    groupId: -1,
                    width: 0,
                    height: 0,
                    imageId: this._generateImageId(imageModel),
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
