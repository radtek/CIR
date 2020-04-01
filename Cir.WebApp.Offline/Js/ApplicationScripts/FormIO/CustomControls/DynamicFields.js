angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('dynamicFields', {
                title: 'Dynamic Fields',
                fbtemplate: 'dynamicFieldsTemplate.html',
                template: 'dynamicFields.html',
                settings: {
                    tableView: true,
                    label: 'Dynamic Fields',
                    key: 'customSlider',
                    description: 'Custom Slider',
                    protected: false,
                    unique: false,
                    persistent: true,
                    input: true
                },
                icon: 'fa fa-file-image-o',
                views: [
                    {
                        name: 'Other',
                        template: 'dynamicFieldsOther.html'
                    },
                    {
                        name: 'Validation',
                        template: 'formio/components/radio/validate.html'

                    },
                    {
                        name: 'API',
                        template: 'formio/components/common/api.html'
                    },
                     
                     {
                         name: 'Layout',
                         template: 'formio/components/common/layout.html'
                     },
                     {
                         name: 'Conditional',
                         template: 'formio/components/common/conditional.html'
                     },
                    {
                        name: 'Data',
                        template: 'formio/components/common/data.html'
                    }
                ]
            });
        }
    ]);
