var ImageModelMapper = {
    toApiModel: function (images, sidesData, plateImgId) {
        var result = {
            plate: {},
            sections: {}
        };
        var mergedImages = this._mergeImages(images).filter(function(img) {
            return img !== undefined;
        });
        var groupedImages = this._makeGroups(mergedImages,
            function(image) {
                return image.region;
            });
        var sortedGroups = this._sortGroups(groupedImages,
            function (obj1, obj2) {
                // descending
                return obj2.imageNumber - obj1.imageNumber;
            });
        var SeveritySorted = this._sortGroups(groupedImages,
                    function (obj1, obj2) {
                        // descending
                        return obj2.damageSeverity - obj1.damageSeverity;
                    });
        var noGroupId = -1;

        for (var key in sortedGroups) {
            if (!sortedGroups.hasOwnProperty(key) || parseInt(key) === noGroupId) {
                continue;
            }

            var resultKey = key.indexOf('section') > -1 ? key : 'section' + key;

            key = parseInt(key);
            result.sections[resultKey] = {
                side: sidesData[key].side,
                damageSeverity: SeveritySorted[key].length ? SeveritySorted[key][0].damageSeverity : 0,
                images: sortedGroups[key].map(function(image) {
                    return this._imageToApiModel(image, sidesData);
                }.bind(this))
            };
        }
        if (sortedGroups[noGroupId]) {
            var imgs = images.filter(function(image) {
                return image.imageId === plateImgId;
            });

            if (imgs.length) {
                result.plate.fileInfo = {
                    name: imgs[0].imageName
                };
                result.plate.imageId = plateImgId;
            }
        }

        return result;
    },

    fromApiModel: function (sections) {
        var backendImages = [];

        for (var key in sections) {
            if (!sections.hasOwnProperty(key)) {
                continue;
            }
            for (var i = 0; i < sections[key].images.length; i++) {
                backendImages.push({ section: key, image: sections[key].images[i] });
            }
        }

        var result = backendImages.sort(function(img1, img2) {
            return img1.image.number - img2.image.number;
        }).map(function(img) {
            return this._apiModelToImages(img.image, img.section);
        }.bind(this)).reduce(function(a, b) {
            return a.concat(b);
        }, []);

        return result;
    },

    _imageToApiModel: function (image, sidesData) {
        var apiModel = {
            coords: [sidesData[image.region].x, sidesData[image.region].y],
            fileInfo: {
                name: image.imageName
            },
            imageId: image.imageId,
            number: image.imageNumber,
            damagePlacement: image.damagePlacement,
            radius: image.radius,
            damageDescription: image.damageDescription,
            damageSeverity: image.damageSeverity,
            side: image.side,
            observations: image.observations.length ? image.observations : [],
            damageIdentified: image.damageIdentified,
            imageSectionOrder: image.imageSectionOrder
        };

        if (apiModel.observations.length === 1 && apiModel.observations[0].polygons.length === 4) {
            apiModel.observations[0].polygons[0].severity = image.damageSeverity;
            apiModel.observations[0].polygons[0].center.x = image.width / 2;
            apiModel.observations[0].polygons[0].center.y = image.height / 2;
            apiModel.observations[0].polygons[0].geometry[1].x = image.width;
            apiModel.observations[0].polygons[0].geometry[2].x = image.width;
            apiModel.observations[0].polygons[0].geometry[2].y = image.height;
            apiModel.observations[0].polygons[0].geometry[3].y = image.height;
        }
        if (!image.observations.length) {
            apiModel.observations.push({
                observationType: null,
                surfaceType: null,
                location: null,
                size: {
                    width: image.width,
                    height: image.height,
                    depth: null
                },
                severity: image.damageSeverity,
                date: null,
                name: null,
                findingType: image.damageType,
                comment: null,
                polygons: [
                    {
                        text: '',
                        center: {
                            z: null,
                            x: image.width / 2,
                            y: image.height / 2
                        },
                        severity: image.damageSeverity,
                        geometry: [
                            {
                                z: null,
                                x: 0,
                                y: 0
                            },
                            {
                                z: null,
                                x: image.width,
                                y: 0
                            },
                            {
                                z: null,
                                x: image.width,
                                y: image.height
                            },
                            {
                                z: null,
                                x: 0,
                                y: image.height
                            }
                        ]
                    }
                ]
            });
        }

        return apiModel;
    },

    _apiModelToImages: function (model, section) {
        var image;

        if (!model.observations[0].polygons.length || model.observations[0].polygons.length < 2) {
            image = this._getImageObj(model, section);
            image.groupId = -1;
            image.damageSeverity = model.observations[0].severity;
            image.imageId = model.imageId;
            
            return [image];
        } else {
            var images = [];
            var observation = model.observations[0];

            for (var i = 0; i < observation.polygons; i++) {
                image = this._getImageObj(model, section);
                image.groupId = model.imageId;
                image.damageSeverity = observation.polygons[i].severity;
                image.imageId = this._generateImageId(imageModel);

                images.push(image);
            }

            return images;
        }
    },

    _generateImageId: function (imageModel) {
        let imageGuid = cirOfflineApp.generateKey();
        if (!!imageModel && imageModel.length > 0 && imageModel.findIndex(x => x.imageId == imageGuid) > -1) {
            imageGuid = this._generateImageId(imageModel);
        }
        else {
            return imageGuid;
        }
    },

    _getImageObj: function (model, section) {
        return {
            width: model.observations[0].size.width,
            height: model.observations[0].size.height,
            src: '',
            checked: false,
            color: null,
            region: parseInt(section.substring(7)),
            imageName: model.fileInfo.name,
            imageNumber: model.number,
            uploadedAt: '',
            damagePlacement: model.damagePlacement,
            damageType: model.observations[0].findingType,
            radius: model.radius,
            damageDescription: model.damageDescription,
            damageDescriptionText: null,
            side: model.side,
            saved: true,
            observations: model.observations,
            damageIdentified: model.damageIdentified,
            imageSectionOrder: model.imageSectionOrder
        };
    },

    _mergeImages: function(images) {
        var groups = this._makeGroups(images,
            function(image) {
                return image.groupId;
            });
        var result = [].concat(groups[-1]);

        delete groups[-1];

        for (var key in groups) {
            if (!groups.hasOwnProperty(key)) {
                continue;
            }

            var img = groups[key][0];

            img.imageId = img.groupId;

            delete img.groupId;

            for (var i = 1; i < groups[key].length; i++) {
                img.observations.polygons.push(groups[key][i].polygons[0]);
            }

            result.push(img);
        }

        return result;
    },

    _makeGroups: function(iterable, selector) {
        var result = {};
        var key;

        for (var i = 0; i < iterable.length; i++) {
            key = selector(iterable[i]);

            if (!result[key]) {
                result[key] = [];
            }

            result[key].push(iterable[i]);
        }

        return result;
    },

    _sortGroups: function (groupedItems, sortFn) {
        var result = {};

        for (var key in groupedItems) {
            if (!groupedItems.hasOwnProperty(key)) {
                continue;
            }

            result[key] = groupedItems[key].sort(sortFn);
        }

        return result;
    }
};
