angular.module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('cirNavigation', {
                title: 'CIR Navigation',
                fbtemplate: 'cirNavigationView.html',
                template: 'cirNavigation.html',
                settings: {
                    tableView: true,
                    key: 'cirNavigation',
                    protected: false,
                    unique: false,
                    persistent: true
                },
                icon: 'fa fa-exchange',
                controller: ['$scope', '$timeout', '$rootScope', 'FormioUtils', function ($scope, $timeout, $rootScope, FormioUtils) {
                    $('ul.list-inline').hide();

                    $scope.$formScope = angular.element('.formio-wizard-wrapper').scope();
                    $scope.$formScope = !$scope.$formScope ? null : $scope.$formScope.$$childHead;

                    if (!$scope.$formScope._history) {
                        $scope.$formScope._history = [];
                    }

                    $scope.showNext = function () {
                        if (!$scope.$formScope) {
                            return false;
                        }
                        return $scope.$formScope.currentPage < $scope.$formScope.pages.length - 1;
                    }

                    $scope.showPrev = function () {
                        if (!$scope.$formScope) {
                            return false;
                        }
                        return $scope.$formScope.currentPage > 0;
                    }

                    $scope.prevPage = function () {
                        $rootScope.validationInfo[$scope.$formScope.currentPage] = $scope.$formScope.isValid();

                        $scope.$formScope._history.push($scope.$formScope.currentPage);

                        var prev = $scope.$formScope.history.pop();

                        if ($scope.$formScope._history.findIndex(function (pageNo) { return pageNo === $scope.$formScope.currentPage; }) > -1) {
                            var errors = $scope.$formScope.checkErrors();

                            $scope.$formScope.pageHasErrors[$scope.$formScope.currentPage] = errors;
                        }

                        $scope.$formScope.currentPage = prev;
                        FormioUtils.alter('prevPage', $scope.$formScope, function (err) {
                            $scope.showPage();
                            $scope.$formScope.$emit('wizardPrev', $scope.$formScope.currentPage);
                        }.bind($scope.$formScope));
                    };

                    $scope.nextPage = function () {
                        $rootScope.validationInfo[$scope.$formScope.currentPage] = $scope.$formScope.isValid();
                        var nextPage = $scope.$formScope.getNextPage();
                        if (nextPage >= $scope.$formScope.pages.length) {
                            nextPage = $scope.$formScope.pages.length - 1;
                        }
                        if (nextPage < 0) {
                            nextPage = 0;
                        }

                        $scope.$formScope._history.push($scope.$formScope.currentPage);
                        $scope.$formScope.history.push($scope.$formScope.currentPage);                        

                        if ($scope.$formScope._history.findIndex(function (pageNo) { return pageNo === $scope.$formScope.currentPage; }) > -1) {
                            var errors = $scope.$formScope.checkErrors();

                            $scope.$formScope.pageHasErrors[$scope.$formScope.currentPage] = errors;
                        }

                        $scope.$formScope.currentPage = nextPage;
                        FormioUtils.alter('nextPage', $scope.$formScope, function (err) {
                            $scope.showPage();
                            $scope.$formScope.$emit('wizardNext', $scope.$formScope.currentPage);
                        }.bind($scope.$formScope));
                    };

                    $scope.showPage = function () {
                        $scope.$formScope.currentPage = $scope.$formScope.currentPage || 0;
                        $scope.$formScope.showAlerts(null);
                        $scope.$formScope.pageWasVisited[$scope.$formScope.currentPage] = true;

                        $scope.$formScope.wizardLoaded = false;
                        $scope.$formScope.page.components = [];
                        $scope.$formScope.page.components.length = 0;
                        $timeout(function () {
                            $scope.$formScope.page.components = $scope.$formScope.pages[$scope.$formScope.currentPage].components;
                            $scope.$formScope.activePage = $scope.$formScope.pages[$scope.$formScope.currentPage];
                            $scope.$formScope.formioAlerts = [];
                            $scope.$formScope.wizardLoaded = true;
                            window.scrollTo(0, $scope.$formScope.wizardTop);
                            $scope.$formScope.$emit('wizardPage', $scope.$formScope.currentPage);
                            $timeout($scope.$formScope.$apply.bind($scope.$formScope));
                        });
                    }
                }]
            });
        }
    ]);