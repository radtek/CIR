angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('turbineData', {
                title: 'Turbine Data',
                fbtemplate: 'turbineData.html',
                template: 'turbineData.html',
                settings: {
                    tableView: true,
                    label: 'Turbine Data',
                    key: 'turbineData',
                    model: {},
                    protected: false,
                    unique: false,
                    persistent: true
                },
                views: [
                    {
                        name: 'Settings',
                        template: 'turbineDataDisplay.html'
                    }],
                icon: 'fa fa-cogs'
            });
        }
    ]);