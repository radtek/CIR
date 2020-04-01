angular.module('formio')
    .component('imageMetadata', {
        templateUrl: 'imageMetadataTemplate.html',
        bindings: {
            metadata: '<',
            binaryData: '<',
            onClickImage: '&',
            onDelete: '&',
            onMoveUp: '&',
            onMoveDown: '&'
        },
        controllerAs: '$ctrl',
        controller: class {

            deleteImage() {
                this.onDelete();
            }

            moveUp() {
                this.onMoveUp();
            }

            moveDown() {
                this.onMoveDown();
            }

            viewImage() {
                this.onClickImage();
            }
        }
    });