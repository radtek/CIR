angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('imageUploader', {
                title: 'Image Uploader',
                fbtemplate: 'imageUploaderView.html',
                template: 'imageUploader.html',
                settings: {
                    tableView: true,
                    label: 'Upload Images',
                    key: 'imageUploader',
                    description: 'Drag files here or click to upload',
                    protected: false,
                    unique: false,
                    persistent: true
                },
                icon: 'fa fa-file-image-o',
                views: [
                    {
                        name: 'Display',
                        template: 'imageDisplayProperties.html'
                    }
                ]
            });
        }
    ]);
