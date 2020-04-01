angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('advancedValidation', {
                title: 'Advanced Validation',
                fbtemplate: 'advancedValidationView.html',
                template: 'advancedValidation.html',
                settings: {
                    tableView: true,
                    label: 'Advanced Validation',
                    key: 'advancedValidation',
                    model: {},
                    protected: false,
                    unique: false,
                    persistent: true
                },
                views: [
                    {
                        name: 'Settings',
                        template: 'advancedValidationDisplay.html'
                    }],
                icon: 'fa fa-check-square'
            });
        }
    ]);