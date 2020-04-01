var BlobModelManager = {
    initializeImages: function (images, blobModel, thumbnails, plateImageId, plateImageCallback) {
        for (var i = 0; i < thumbnails.length; i++) {
            var jsonImgData = images.filter(function (obj) {
                return obj.groupId === thumbnails[i].imageId || obj.imageId === thumbnails[i].imageId;
            });
            var blob = blobModel.filter(function (obj) {
                return obj.imageId === thumbnails[i].imageId;
            });

            if (!jsonImgData.length || !blob.length) {
                continue;
            }

            var imgSrc = thumbnails[i].binaryData.substr(0, 4) === 'data'
                ? thumbnails[i].binaryData
                : 'data:image/jpeg;base64,' + thumbnails[i].binaryData;

            if (thumbnails[i].imageId === plateImageId) {
                plateImageCallback(imgSrc);
            }

            jsonImgData[0].src = imgSrc;
        }
    },

    add: function(imgData, blobModel, cirId, templateId) {
        var addedItems = blobModel.filter(i => i.state === 'Added');
        var startIndex = addedItems.length !== 0 ? blobModel.indexOf(addedItems[addedItems.length - 1]) + 1 : 0;

        blobModel.splice(startIndex, 0, {
            imageId: imgData.imageId,
            templateId: templateId,
            cirId: cirId,
            state: 'Added'
        });
    },

    remove: function (imgIds, blobModel) {
        for (var i = 0; i < imgIds.length; i++) {
            var imgId = imgIds[i];
            var index = blobModel.findIndex(function(model) {
                return model.imageId === imgId;
            });

            if (index < 0) {
                return;
            }

            var model = blobModel[index];

            model.state = 'Deleted';

            blobModel.splice(index, 1);
            blobModel.push(model);
        }
    }
};
