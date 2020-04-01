angular.module('formio')
    .directive("importExcelSheetData", [function () {
        return {
            scope: {
                importExcelSheetData: "="
            },
            link: function (scope, element) {
                element.on('change', function (changeEvent) {
                    var reader = new FileReader();

                    if (!scope.jsonData) {
                        scope.importExcelSheetData = [];
                    }

                    reader.onload = function (e) {
                        var bstr = e.target.result;
                        var workbook = XLSX.read(bstr, { type: 'binary' });
                        var sheetname = workbook.SheetNames[0];
                        var sheet = workbook.Sheets[sheetname];
                        scope.importExcelSheetData = XLSX.utils.sheet_to_json(sheet);
                    };

                    reader.readAsBinaryString(changeEvent.target.files[0]);
                });
            }
        };
    }]);