angular.module('formio')
    .component('dynamicFields', {
        templateUrl: 'dynamicFieldsTemplate.html',
        bindings: {
            component: '=',
            data: '=',
            model: '=',
            fdata:'=',
        },
        controllerAs: '$ctrl',
        controller: class {
            constructor($scope) {
                if ($scope)

                $scope.definitions = [
                    {
                        Id: 1,
                        CimCaseNo: 3786,
                        TableHeader: 'CIM case 3786 Measurements',
                        ColHeaders: [' ', '', '', '','',''],
                        RowHeaders: ['Spring length [mm]', 'Spring length [mm]', 'Spring length [mm]', 'Double nut ? [Y/N]', 'Signs of slippage inside clamp ? [Y/N]', 'Wrinkling of protection mat [Y/N]', 'Previously adjusted and later backed off? [Y/N]', 'Cable manufacturer [Nexans / Draka]', 'Date of Manufacturing (week/year) [xx/20xx]', '', '', '', '', '', '', '']
                    },
                    {
                        Id: 2,
                        CimCaseNo: 3664,
                        TableHeader: 'Measurements CIM case 3664',
                        ColHeaders: ['Flange 1', 'Flange 2', 'Flange 3', 'Flange 4', 'Flange 5', 'Flange 6'],
                        RowHeaders: ['Bolt manufacturer [Name]', 'Bolt size [Mxx]', 'Broken bolts [No. of bolts]', 'Moving Flanges [Yes /No]', 'Sealant ingress-[Affected area 0-200 bolts]', 'Cracked Paint-[Affected area 0-200 bolts]', 'Metallization dust-[Affected area 0-200 bolts]', 'Corrosion marks on platform', 'Sign of service loose bolts-[No. of bolts 0-200]', 'Water ingress between flanges-[Affected area 0-200 bolts]', 'Water ingress on bolt heads-[No. of bolts 0-200]', 'Obvious loose bolts-[No. of bolts 0-200]', 'VUI Bolt plate - [Item no.]', 'Outside Signs [Affected area 0-200 bolts]']
                    },
                    {
                        Id: 3,
                        CimCaseNo: 3550,
                        TableHeader: 'Failure Categorization of SPL bolts',
                        ColHeaders: ['Category 3 Failure (1=Yes)', 'Comment', '', '','',''],
                        RowHeaders: ['SPL#  1 (WW)', 'SPL#  3 (WW)', 'SPL#  5 (WW)', 'SPL#  7 (WW)', 'SPL#  2 (LW)', 'SPL#  4 (LW)', 'SPL#  6 (LW)', 'SPL#  8 (LW)', '', '', '', '', '', '', '', '']
                    },
                    {
                        Id: 4,
                        CimCaseNo: 3800,
                        TableHeader: 'Fill the sheet according to DMS 0069-1780',
                        ColHeaders: ['Question 1', 'Question 2', 'Question 3', 'Question 4','',''],
                        RowHeaders: ['1. Highspeed coupling', '2. Generator shims placement', '3. Generator bolts', '4. Gear torque bushings', '5. Generator alignment', '6. Nacelle Rear Structure', '7. Gearbox runout', '', '', '', '', '', '', '', '', '']
                    },
                    {
                        Id: 5,
                        CimCaseNo: 3921,
                        TableHeader: 'Fill the sheet according to DMS 0042-2024',
                        ColHeaders: ['Blade A (LW)', 'Blade A (WW)', 'Blade B (LW)', 'Blade B (WW)', 'Blade C (LW)', 'Blade C (WW)'],
                        RowHeaders: ['R1', 'R2', 'R3', 'R4', 'R5', 'R6', 'R7', 'R8', '', '', '', '', '', '', '', '']
                    }
                ];
                $scope.currentDefinition= $scope.definitions[0];
                $scope.firstLoad = false;
                $scope.getCellIdent = function (col,row) {
                    return col+row;                    
                }
                $scope.$watch('$ctrl.data[$ctrl.model.controlId]',
                    function () {
                        if (!$scope.firstLoad) {
                            $scope.currentDefinition = $scope.definitions.find((el) => el.CimCaseNo == $scope.$ctrl.fdata[$scope.$ctrl.model.controlId]);
                            $scope.$applyAsync();
                        } else {
                            $scope.firstLoad = false;
                        }
                    });
                
                
            }
            $onInit() {
                if (!this.data) {
                    this.data = {};
                }
            }
        }
      
    });