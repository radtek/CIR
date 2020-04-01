angular.module('formio').config([
    'formioComponentsProvider',
    function (formioComponentsProvider) {
        formioComponentsProvider.register('dynamicDropdown', {
            title: 'Custom Dropdown',
            fbtemplate: 'formio/components/select.html',
            template: 'formio/components/select.html',
            settings: {
                tableView: true,
                label: 'New Select',
                key: 'dynamicDropdown',
                description: '',
                uploadLink: '',
                downloadLink: '',
                protected: false,
                unique: false,
                persistent: true,
                input: true
            },
            icon: 'fa fa-th-list',
            views: [
                {
                    name: 'Display',
                    template: 'dropdownDisplayTemplate.html'
                },
                {
                    name: 'Data',
                    template: 'dropdownDatasourceTemplate.html'
                },
                {
                    name: 'Validation',
                    template: 'dropdownValidateTemplate.html'
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
                }
            ],
            onEdit: ['$scope', 'FormioUtils', function ($scope, FormioUtils) {
                $scope.dataSources = {
                    json: 'Raw JSON',
                    url: 'URL',
                    custom: 'Custom',
                    file: 'Excel sheet',
                    indexeddb: 'Indexed DB'
                };
                $scope.resources = [];
                $scope.resourceFields = [];

                var getInputFields = function (components) {
                    var fields = [];
                    FormioUtils.eachComponent(components, function (component) {
                        if (component.key && component.input && (component.type !== 'button') && component.key !== $scope.component.key) {
                            var comp = _.clone(component);
                            if (!comp.label) {
                                comp.label = comp.key;
                            }
                            fields.push(comp);
                        }
                    });
                    return fields;
                };

                $scope.formFields = [{ label: 'Any Change', key: 'data' }].concat(getInputFields($scope.form.components));

                var loadFields = function () {
                    if (!$scope.component.data || !$scope.component.data.resource || ($scope.resources.length === 0)) {
                        return;
                    }
                    var selected = null;
                    $scope.resourceFields = [
                        {
                            property: '',
                            title: '{Entire Object}'
                        },
                        {
                            property: '_id',
                            title: 'Submission Id'
                        }
                    ];
                    if ($scope.formio.projectId) {
                        $scope.component.data.project = $scope.formio.projectId;
                    }
                    for (var index in $scope.resources) {
                        if ($scope.resources[index]._id.toString() === $scope.component.data.resource) {
                            selected = $scope.resources[index];
                            break;
                        }
                    }
                    if (selected) {
                        var fields = getInputFields(selected.components);
                        for (var i in fields) {
                            var field = fields[i];
                            var title = field.label || field.key;
                            $scope.resourceFields.push({
                                property: 'data.' + field.key,
                                title: title
                            });
                        }
                        if (!$scope.component.valueProperty && $scope.resourceFields.length) {
                            $scope.component.valueProperty = $scope.resourceFields[0].property;
                        }
                    }
                };

                $scope.$watch('component.dataSrc', function (source, prevSource) {
                    if (source !== prevSource) {
                        $scope.component.template = '<span>{{ item.label }}</span>';
                    }

                    if (($scope.resources.length === 0) && (source === 'resource')) {
                        $scope.formio.loadForms({ params: { type: 'resource', limit: 4294967295 } }).then(function (resources) {
                            $scope.resources = resources;
                            loadFields();
                        });
                    }
                });

                $scope.$watch('component.data.resource', function (resourceId) {
                    if (!resourceId) {
                        return;
                    }
                    loadFields();
                });

                $scope.currentValueProperty = $scope.component.valueProperty;
                $scope.$watch('component.valueProperty', function (property) {
                    if ($scope.component.dataSrc === 'resource' && $scope.currentValueProperty !== property) {
                        if (!property) {
                            $scope.component.searchField = '';
                            $scope.component.template = '<span>{{ item.data }}</span>';
                        }
                        else {
                            $scope.component.searchField = property + '__regex';
                            $scope.component.template = '<span>{{ item.' + property + ' }}</span>';
                        }
                    }
                });

                loadFields();
            }],

            tableView: function (data, component, $interpolate) {
                var getItem = function (data) {
                    switch (component.dataSrc) {
                        case 'values':
                            component.data.values.forEach(function (item) {
                                if (item.value === data) {
                                    data = item;
                                }
                            });
                            return data;
                        case 'json':
                            if (component.valueProperty) {
                                var selectItems;
                                try {
                                    selectItems = angular.fromJson(component.data.json);
                                }
                                catch (error) {
                                    selectItems = [];
                                }
                                selectItems.forEach(function (item) {
                                    if (item[component.valueProperty] === data) {
                                        data = item;
                                    }
                                });
                            }
                            return data;
                        case 'file':
                            component.data.values.forEach(function (item) {
                                if (item.value === data) {
                                    data = item;
                                }
                            });
                            return data;

                        case 'url':
                        case 'resource':
                        case 'indexeddb':
                        default:
                            return data;
                    }
                };
                if (component.multiple && Array.isArray(data)) {
                    return data.map(getItem).reduce(function (prev, item) {
                        var value;
                        if (typeof item === 'object') {
                            value = $interpolate(component.template)({ item: item });
                        }
                        else {
                            value = item;
                        }
                        return (prev === '' ? '' : ', ') + value;
                    }, '');
                }
                else {
                    var item = getItem(data);
                    var value;
                    if (typeof item === 'object') {
                        value = $interpolate(component.template)({ item: item });
                    }
                    else {
                        value = item;
                    }
                    return value;
                }
            },

            controller: [
                '$rootScope',
                '$scope',
                '$http',
                'Formio',
                'FormioUtils',
                '$interpolate',
                '$q',
                '$timeout',
                function (
                    $rootScope,
                    $scope,
                    $http,
                    Formio,
                    FormioUtils,
                    $interpolate,
                    $q,
                    $timeout
                ) {

                    if ($scope.options && $scope.options.building) return;
                    var settings = $scope.component;
                    var options = {};
                    $scope.nowrap = true;
                    $scope.hasNextPage = false;
                    $scope.selectItems = [];

                    var initialized = $q.defer();
                    initialized.promise.then(function () {
                        $scope.$emit('selectLoaded', $scope.component);
                    });

                    var selectValues = $scope.component.selectValues;
                    var valueProp = $scope.component.valueProperty;
                    $scope.getSelectItem = function (item) {
                        if (!item) {
                            return '';
                        }
                        if (settings.dataSrc === 'values' || settings.dataSrc === 'file') {
                            return item.value;
                        }

                        var itemValue = valueProp ? _.get(item, valueProp) : item;
                        if (itemValue === undefined) {
                            console.warn('Cannot find value property within select: ' + valueProp);
                        }

                        return itemValue;
                    };

                    $scope.refreshItems = function () {
                        return $q.resolve([]);
                    };
                    $scope.$on('refreshList', function (event, url, input) {
                        $scope.refreshItems(input, url);
                    });

                    var refreshing = false;
                    var initialLoadCount = 2;
                    var refreshValue = function () {
                        if (refreshing) {
                            return;
                        }
                        refreshing = true;
                        var tempData = $scope.data[settings.key];
                        $scope.data[settings.key] = initialLoadCount > 0 && !!tempData ? tempData : settings.multiple ? [] : '';
                        initialLoadCount--;
                        if (!settings.clearOnRefresh) {
                            $timeout(function () {
                                $scope.data[settings.key] = tempData;
                                refreshing = false;
                                $scope.$emit('selectLoaded', $scope.component);
                            });
                        }
                        else {
                            refreshing = false;
                            $scope.$emit('selectLoaded', $scope.component);
                        }
                    };

                    var ensureValue = function (value) {
                        value = value || $scope.data[settings.key];
                        if (!value || (Array.isArray(value) && value.length === 0)) {
                            return;
                        }
                        if (Array.isArray(value)) {
                            value.forEach(ensureValue);
                            return;
                        }

                        var found = false;
                        for (var i = 0; i < $scope.selectItems.length; i++) {
                            var item = $scope.selectItems[i];
                            var selectItem = $scope.getSelectItem(item);
                            if (_.isEqual(selectItem, value)) {
                                found = true;
                                break;
                            }
                        }

                        if ($scope.loadedItems && !found) {
                            for (var i = 0; i < $scope.loadedItems.length; i++) {
                                var item = $scope.loadedItems[i];
                                var selectItem = $scope.getSelectItem(item);
                                if (_.isEqual(selectItem, value)) {
                                    $scope.selectItems.push(item);
                                    found = true;
                                    break;
                                }
                            }
                        }


                        if (!found) {
                            var itemValue = value;
                            if (valueProp) {
                                itemValue = {};
                                _.set(itemValue, valueProp, value);
                            }
                            $scope.selectItems.push(itemValue);
                        }
                    };

                    var refreshItemsWhenReady = function () {
                        initialized.promise.then(function () {
                            var refreshPromise = $scope.refreshItems(true);
                            if (refreshPromise) {
                                refreshPromise.then(refreshValue);
                            }
                            else {
                                refreshValue();
                            }
                        });
                    };

                    if (settings.refreshOn) {
                        if (settings.refreshOn === 'data') {
                            $scope.$watch('data', refreshItemsWhenReady, true);
                            return;
                        }

                        $scope.$watch('data.' + settings.refreshOn, refreshItemsWhenReady);
                        $scope.$watch('submission.data.' + settings.refreshOn, refreshItemsWhenReady);
                    }
                    else {
                        var dataWatch = $scope.$watch('data.' + settings.key, function (value) {
                            if (value) {
                                initialized.promise.then(function () {
                                    dataWatch();
                                    ensureValue();
                                });
                            }
                        });
                    }

                    var lastInput;
                    switch (settings.dataSrc) {
                        case 'values':
                        case 'file':
                            $scope.selectItems = settings.data.values;
                            initialized.resolve();
                            break;
                        case 'json':
                            var items;

                            var setResult = function (data, append) {
                                if (!(data instanceof Array)) {
                                    data = [data];
                                }

                                if (data.length < options.params.limit) {
                                    $scope.hasNextPage = false;
                                }
                                if (append) {
                                    $scope.selectItems = $scope.selectItems.concat(data);
                                }
                                else {
                                    $scope.selectItems = data;
                                }
                            };

                            try {
                                if (typeof $scope.component.data.json === 'string') {
                                    items = angular.fromJson($scope.component.data.json);
                                }
                                else if (typeof $scope.component.data.json === 'object') {
                                    items = $scope.component.data.json;
                                }
                                else {
                                    items = [];
                                }

                                if (selectValues) {
                                    if (selectValues.indexOf('.') !== -1) {
                                        var parts = selectValues.split('.');
                                        var select = items;
                                        for (var i in parts) {
                                            select = select[parts[i]];
                                        }
                                        items = select;
                                    }
                                    else {
                                        items = items[selectValues];
                                    }
                                }
                            }
                            catch (error) {
                                items = [];
                            }
                            options.params = {
                                limit: $scope.component.limit || 20,
                                skip: 0
                            };

                            $scope.refreshItems = function (input, url, append) {
                                if (lastInput !== input) {
                                    lastInput = input;
                                    options.params.skip = 0;
                                }
                                var selectItems = items;
                                if (input) {
                                    selectItems = selectItems.filter(function (item) {
                                        var value = $interpolate($scope.component.template)({ item: item }).replace(/<(?:.|\n)*?>/gm, '');
                                        switch ($scope.component.filter) {
                                            case 'startsWith':
                                                return value.toLowerCase().indexOf(input.toLowerCase()) !== -1;
                                            case 'contains':
                                            default:
                                                return value.toLowerCase().lastIndexOf(input.toLowerCase(), 0) === 0;
                                        }
                                    });
                                }
                                options.params.skip = parseInt(options.params.skip, 10);
                                options.params.limit = parseInt(options.params.limit, 10);
                                selectItems = selectItems.slice(options.params.skip, options.params.skip + options.params.limit);
                                setResult(selectItems, append);
                                return initialized.resolve($scope.selectItems);
                            };
                            $scope.refreshItems();
                            break;
                        case 'custom':
                            $scope.refreshItems = function () {
                                try {
                                    var data = _.cloneDeep($scope.submission.data);
                                    var row = _.cloneDeep($scope.data);
                                    $scope.selectItems = eval('(function(data, row) { var values = [];' + settings.data.custom.toString() + '; return values; })(data, row)');
                                }
                                catch (error) {
                                    $scope.selectItems = [];
                                }
                                return initialized.resolve($scope.selectItems);
                            };
                            $scope.refreshItems();
                            break;
                        case 'url':
                        case 'resource':
                        case 'indexeddb':
                            if (settings.filter === 'contains' || settings.filter === 'startsWith') {
                                settings.filter = '';
                                $scope.component.filter = '';
                            }
                            $scope.options = $scope.options || {};
                            var url = '';
                            var baseUrl = $scope.options.baseUrl || Formio.getBaseUrl();
                            if (settings.dataSrc === 'url') {
                                url = settings.data.url;
                                if (url.substr(0, 1) === '/') {
                                    url = baseUrl + settings.data.url;
                                }

                                if (!settings.authenticate && url.indexOf(baseUrl) === -1) {
                                    options.disableJWT = true;
                                    options.headers = options.headers || {};
                                    options.headers.Authorization = undefined;
                                    options.headers.Pragma = undefined;
                                    options.headers['Cache-Control'] = undefined;
                                }
                            }
                            else if ($scope.formio) {
                                url = $scope.formio.formsUrl + '/' + settings.data.resource + '/submission';
                            }
                            else {
                                url = baseUrl;
                                if (settings.data.project) {
                                    url += '/project/' + settings.data.project;
                                }
                                url += '/form/' + settings.data.resource + '/submission';
                            }

                            options.params = {
                                limit: $scope.component.limit || 100,
                                skip: 0
                            };

                            $scope.loadMoreItems = function ($select, $event) {
                                $event.stopPropagation();
                                $event.preventDefault();
                                options.params.skip = parseInt(options.params.skip, 10);
                                options.params.skip += parseInt(options.params.limit, 10);
                                $scope.refreshItems(true, null, true);
                            };

                            if (url) {
                                $scope.hasNextPage = true;
                                $scope.refreshItems = function (input, newUrl, append) {
                                    if (typeof input === 'string') {
                                        if (input === lastInput) {
                                            return;
                                        }
                                        else {
                                            options.params.limit = $scope.component.limit || 100;
                                            options.params.skip = 0;
                                        }
                                    }

                                    lastInput = input;
                                    newUrl = newUrl || url;
                                    newUrl = $interpolate(newUrl)({
                                        data: $scope.submission ? $scope.submission.data : {},
                                        row: $scope.data || {},
                                        formioBase: $rootScope.apiBase
                                    });
                                    if (!newUrl) {
                                        return;
                                    }

                                    if (
                                        settings.searchField &&
                                        (typeof input === 'string') &&
                                        input
                                    ) {
                                        options.params[settings.searchField] = /__regex$/.test(settings.searchField)
                                            ? FormioUtils.escapeRegExCharacters(input)
                                            : input;
                                    }
                                    else if (!append) {
                                        delete options.params[settings.searchField];
                                    }

                                    if (settings.filter) {
                                        _.assign(options.params, _.mapValues(JSON.parse('{"' + decodeURI(settings.filter).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}'), function (value) {
                                            return $interpolate(value)({
                                                data: $scope.submission ? $scope.submission.data : {},
                                                row: $scope.data
                                            });
                                        }));
                                    }

                                    if (settings.selectFields) {
                                        options.params.select = settings.selectFields;
                                    }

                                    var setResult = function (data) {
                                        if (!(data instanceof Array)) {
                                            data = [data];
                                        }

                                        if (data.length < options.params.limit) {
                                            $scope.hasNextPage = false;
                                        }
                                        else {
                                            $scope.hasNextPage = true;
                                        }
                                        if (append) {
                                            $scope.selectItems = $scope.selectItems.concat(data);
                                        }
                                        else {
                                            $scope.selectItems = data;
                                        }

                                        if (valueProp) {
                                            let uniqueElements = [];
                                            $.each($scope.selectItems, function (i, el) {
                                                if (uniqueElements.filter(x => x[valueProp] == el[valueProp]).length == 0) {
                                                    uniqueElements.push(el);
                                                }
                                            });
                                            $scope.selectItems = uniqueElements;

                                            $scope.selectItems.sort(function (a, b) { return (a[valueProp] > b[valueProp]) ? 1 : ((b[valueProp] > a[valueProp]) ? -1 : 0); });
                                        }
                                        ensureValue();
                                    };

                                    var promise;
                                    if (settings.dataSrc === 'resource') {
                                        promise = (new Formio(newUrl, { base: baseUrl })).loadSubmissions(options);
                                    }
                                    else if (settings.dataSrc === 'url') {
                                        const zumoName = $('#ZumoHeaderName').val();
                                        const zumoVersion = $('#ZumoHeaderVersion').val();

                                        promise = $q.defer();
                                        dbtransaction.getItemfromTablePromise('CurrentUser').done(function (currentuser) {
                                            if (currentuser) {
                                                if (currentuser.length > 0) {
                                                    options.headers = [];
                                                    currentuser.forEach(function (item) {
                                                        options.headers["X-ZUMO-AUTH"] = item.objet.mobileServiceAuthenticationToken;
                                                    });
                                                    options.headers[zumoName] = zumoVersion;
                                                }
                                            }
                                            $http.get(newUrl, options).then(function (result) {
                                                promise.resolve(result.data);
                                            });
                                        });
                                    }
                                    else {
                                        promise = $q.defer();
                                        cirOfflineApp.GetCimCaseItems().done(function (cimCaseItems) {
                                            $scope.loadedItems = cimCaseItems;
                                            if (settings.searchField && options.params[settings.searchField]) {
                                                cimCaseItems = cimCaseItems.filter(x => x[settings.searchField].indexOf(options.params[settings.searchField]) != -1);
                                            }
                                            cimCaseItems = cimCaseItems.slice(options.params.skip, options.params.skip + options.params.limit);
                                            promise.resolve(cimCaseItems);
                                        });
                                    }

                                    return promise.promise.then(function (data) {
                                        if (data) {
                                            if (selectValues) {
                                                setResult(_.get(data, selectValues, []));
                                            }
                                            else if (data.hasOwnProperty('data')) {
                                                setResult(data.data);
                                            }
                                            else if (data.hasOwnProperty('items')) {
                                                setResult(data.items);
                                            }
                                            else {
                                                setResult(data);
                                            }
                                        }
                                        return $scope.selectItems;
                                    }).finally(function () {
                                        initialized.resolve($scope.selectItems);
                                    });
                                };
                                $scope.refreshItems(true);
                            }
                            break;
                        default:
                            $scope.selectItems = [];
                            initialized.resolve($scope.selectItems);
                    }
                }
            ]
        });
    }
]);
