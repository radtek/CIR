angular.module('formio')
    .component('imageEditModal', {
        templateUrl: 'imageEditModalTemplate.html',
        bindings: {
            component: '<',
            sides: '<',
            active: '<',
            colors: '<',
            images: '<',
            activeid: '<',
            onsaveimage: '&',
            onclose: '&'
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope) {
                this._scope = $scope;
                this._regionsColor = '#0094FF';
                this._activeRegionColor = '#0026FF';
                this._damageMarkers = null;
                this.activeImgId = '';
                this.activeField = null;
                this.editMode = true;
                this.viewedImage = '';
                this.template = '';
                this.damageDescriptions = damageDescriptions;
                this.model = {
                    imagearea: '',
                    imageside: '',
                    lblImageareaside:'',
                    imageId: '',
                    imageName: null,
                    imageNumber: null,
                    damagePlacement: 'external',
                    damageType: '',
                    side: 'N/A',
                    radius: null,
                    damageDescription: null,
                    damageDescriptionText: null,
                    damageSeverity: 0,
                    damageIdentified: false
                };
            }

            $onInit() {
                this._damageMarkers = document.getElementById('damage-markers');
            }

            $onChanges() {
                this.activeImgId = this.activeid;

                this._reinitializeFields();
                this._redrawComponent();
                this._redrawPolygon();
            }

            toggleDamageIdentified() {
                this.model.damagePlacement = 'external';
                this.model.damageType = '';
                this.model.radius = null;
                this.model.damageDescription = null;
                this.model.damageDescriptionText = null;
                this.model.damageSeverity = 0;
                this.model.damageIdentified = !this.model.damageIdentified;
                }

            closeModal(event) {
                event.stopPropagation();

                var wasInEditMode = this.editMode;

                this.editMode = true;

                if (wasInEditMode) {
                    this._setFormClean();
                    this.onclose();
                }
            }

            showFullImg(event) {
                event.preventDefault();

                var images = this.images.filter(function(image) {
                    return image.imageId === this.activeImgId;
                }.bind(this));

                if (!images.length) {
                    return;
                }

                var fullImg = images[0];

                this.editMode = false;
                this.viewedImage = fullImg.src;
            }

            markActive(field) {
                this.activeField = field;
            }

            removeActive() {
                this.activeField = null;
            }

            canShowPrevImage() {
                return true;
            }

            showPrevImage() {
                if (!this._onNavigation()) {
                    return;
                }

                var currentIdx = this.images.findIndex(function (img) {
                    return img.imageId === this.activeImgId;
                }.bind(this));
                var prevIdx = -1;
                if (currentIdx > 0) {
                    for (var i = currentIdx - 1; i >= 0; i--) {
                        if (this.images[i].region === -1) {
                            continue;
                        }
                        prevIdx = i;
                        break;
                    }
                }
                if (prevIdx < 0) {
                    for (var i = this.images.length - 1 ; i >= 0; i--) {
                        if (this.images[i].region === -1) {
                            continue;
                        }
                        prevIdx = i;
                        break;
                    }
                }
                if (prevIdx < 0) {
                    return;
                }

                this.activeImgId = this.images[prevIdx].imageId;
                this._reinitializeFields();
                this._redrawComponent();
                this._redrawPolygon();
                this._setObservationValues();
            }
            
            canShowNextImage() {
                return true;
            }

            showNextImage() {
                if (!this._onNavigation()) {
                    return;
                }
                var currentIdx = this.images.findIndex(function (img) {
                    return img.imageId === this.activeImgId;
                }.bind(this));
                var nextIdx = -1;
                if (currentIdx < this.images.length - 1) {
                    for (var i = currentIdx; i < this.images.length; i++) {
                        if (this.images[i].region === -1 || this.images[i].imageId === this.activeImgId) {
                            continue;
                        }
                        nextIdx = i;
                        break;
                    }
                }
                else {
                    for (var i = 0; i < this.images.length; i++) {
                        if (this.images[i].region === -1 || this.images[i].imageId === this.activeImgId) {
                            continue;
                        }
                        nextIdx = i;

                        break;
                    }
                }
                if (nextIdx < 0) {
                    return;
                }

                this.activeImgId = this.images[nextIdx].imageId;
                this._reinitializeFields();
                this._redrawComponent();
                this._redrawPolygon();
                this._setObservationValues();
            }

            submitForm(event) {
                event.preventDefault();

                if (!this._scope.imageForm.$valid) {
                    this._setFormDirty();

                    return;
                }

                this._setFormClean();
                this.onsaveimage({ model: this.model });

                var nextIndex = this._findFirstUnsavedImageIndex();

                this.model.damageDescription = null;

                if (nextIndex < 0) {
                    this.onclose();

                    return;
                }

                this.activeImgId = this.images[nextIndex].imageId;

                this._reinitializeFields();
                this._redrawComponent();
                this._redrawPolygon();
            }

            damageDescriptionSelected(newValue) {
                this.model.damageDescriptionText = newValue;
                this.model.damageDescription = newValue;
            }

            _onNavigation() {
                if (!this._scope.imageForm.$valid) {
                    this._setFormDirty();

                    return false;
                }
                this._setFormClean();
                this.onsaveimage({ model: this.model });

                this.model.damageDescription = null;

                return true;
            }

            _findFirstUnsavedImageIndex() {
                var images = this.images.filter(function (img) {
                    return img.imageId === this.activeImgId;
                }.bind(this));

                var currentRegion = images[0].region;
                var nextIndex = -1;

                if (currentRegion <= Object.keys(this.sides).length) {
                    nextIndex = this.images.findIndex(function (image) {
                        return !image.saved && image.region >= currentRegion && image.imageId !== this.activeImgId;
                    }.bind(this));

                }
                if (nextIndex < 0) {
                    nextIndex = this.images.findIndex(function (image) {
                        return !image.saved && image.region != -1 && image.imageId !== this.activeImgId;
                    }.bind(this));
                }
                return nextIndex;
            }

            _setFormDirty() {
                this._scope.imageForm.imageName.$dirty = true;
                this._scope.imageForm.imageNumber.$dirty = true;
                this._scope.imageForm.damageType.$dirty = true;
                this._scope.imageForm.damageDescriptionText.$dirty = true;
                this._scope.imageForm.side.$dirty = true;
                this._scope.imageForm.radius.$dirty = true;
            }

            _setFormClean() {
                this._scope.imageForm.imageName.$dirty = false;
                this._scope.imageForm.imageNumber.$dirty = false;

                if (this._scope.imageForm.damageType) {
                    this._scope.imageForm.damageType.$dirty = false;
                }
                if (this._scope.imageForm.damageDescriptionText) {
                    this._scope.imageForm.damageDescriptionText.$dirty = false;
                }
                if (this._scope.imageForm.side) {
                    this._scope.imageForm.side.$dirty = false;
                }
                if (this._scope.imageForm.radius) {
                    this._scope.imageForm.radius.$dirty = false;
                }
            }

            _Getimagearea(region) {
                if (region >= 1 && region <= 4) {
                    return 'Root';
                }
                else if (region >= 5 && region <= 8) {
                    return 'Mid';
                }
                else if (region >= 9 && region <= 12) {
                    return 'Tip';
                }
            }
            _Getimageside(region) {
                switch (region) {
                    case 2:
                    case 6:
                    case 10:
                        return 'LW';
                        break;
                    case 3:
                    case 7:
                    case 11:
                        return 'LE';
                        break;
                    case 1:
                    case 5:
                    case 9:
                        return 'TE';
                        break;
                    case 4:
                    case 8:
                    case 12:
                        return 'WW';
                        break;
                    default:
                        break;
                }
            }

            _reinitializeFields() {
                var model = this.model;
                cirOfflineApp.GetCirTemplateById(this._scope.$root.templateId).done(function (template) {
                    model.templateVersion = template.versionNumber;
                });

                if (this.activeImgId === '') {
                    return;
                }

                var images = this.images.filter(function(image) {
                    return image.imageId === this.activeImgId;
                }.bind(this));

                if (!images.length) {
                    return;
                }

                var img = images[0];
                
                this.model.txtdamageDescription = img.damageDescription;
                this.model.imagearea = this._Getimagearea(img.region);
                this.model.imageside = this._Getimageside(img.region);
                this.model.lblImageareaside = this.model.imageside + ' ' + this.model.imagearea+' -';
                this.model.imageId = img.imageId;
                this.model.imageName = img.imageName;
                this.model.imageNumber = img.imageNumber;
                this.model.damagePlacement = img.damagePlacement;
                this.model.damageType = img.damageType ? img.damageType : '';
                this.model.radius = img.radius;
                this.model.damageSeverity = img.damageSeverity;
                this.model.side = img.side ? img.side : this.sides[img.region + ''];
                this.model.damageIdentified = img.damageIdentified === undefined || img.damageIdentified === null
                    ? false
                    : !!img.damageIdentified;

                if (this.damageDescriptions.findIndex(function(desc) { return desc === img.damageDescription; }) < 0) {
                    this.model.damageDescriptionText = img.damageDescription;
                    this.model.damageDescription = null;
                } else {
                    this.model.damageDescriptionText = img.damageDescription;
                    this.model.damageDescription = img.damageDescription;
                }
            }

            _setObservationValues() {
                if (this.activeImgId === '') {
                    return;
                }

                var images = this.images.filter(function (image) {
                    return image.imageId === this.activeImgId;
                }.bind(this));

                if (!images.length) {
                    return;
                }

                var img = images[0];

                if (!!this.model.observations) {
                    this.model.observations.push({
                        observationType: null,
                        surfaceType: null,
                        location: null,
                        size: {
                            width: img.width,
                            height: img.height,
                            depth: null
                        },
                        severity: img.damageSeverity,
                        date: null,
                        name: null,
                        findingType: img.damageType,
                        comment: null,
                        polygons: [
                            {
                                text: '',
                                center: {
                                    z: null,
                                    x: img.width / 2,
                                    y: img.height / 2
                                },
                                severity: img.damageSeverity,
                                geometry: [
                                    {
                                        z: null,
                                        x: 0,
                                        y: 0
                                    },
                                    {
                                        z: null,
                                        x: img.width,
                                        y: 0
                                    },
                                    {
                                        z: null,
                                        x: img.width,
                                        y: img.height
                                    },
                                    {
                                        z: null,
                                        x: 0,
                                        y: img.height
                                    }
                                ]
                            }
                        ]
                    });
                }
            }

            _redrawComponent() {
                if (this.activeImgId === '') {
                    return;
                }

                var images = this.images.filter(function (img) {
                    return img.imageId === this.activeImgId;
                }.bind(this));

                if (!images.length) {
                    return;
                }

                var image = images[0];
                var pixels = this.component.data.imageData.pixels;
                var canvas = document.createElement('canvas');
                var ctx = canvas.getContext('2d');
                var imageData = [];

                for (var i = 0; i < pixels.length; i++) {
                    imageData.push(BitArrayCompressionAlgorithm.decompress(pixels[i]));
                }

                canvas.width = imageData[0].length;
                canvas.height = imageData.length;
                ctx.fillStyle = this._regionsColor;

                for (var y = 0; y < imageData.length; y++) {
                    for (var x = 0; x < imageData[y].length; x++) {
                        if (parseInt(imageData[y][x]) === -1) {
                            continue;
                        }
                        if (parseInt(imageData[y][x]) === image.region) {
                            ctx.fillStyle = this._activeRegionColor;
                        } else {
                            ctx.fillStyle = this._regionsColor;
                        }

                        ctx.fillRect(x, y, 1, 1);
                    }
                }

                this.template = canvas.toDataURL('image/png');
            }

            _redrawPolygon() {
                if (this.activeImgId === '') {
                    return;
                }

                var images = this.images.filter(function (img) {
                    return img.imageId === this.activeImgId;
                }.bind(this));

                if (!images.length) {
                    return;
                }

                var image = images[0];

                if (!image.observations ||
                    !image.observations.length ||
                    !image.observations[0].polygons ||
                    !image.observations[0].polygons.length) {
                    return;
                }

                var ctx = this._damageMarkers.getContext('2d');
            }
        }
    });