angular.module("formBuilder", ["ui.bootstrap", "ui.select", "formio", "ngFormBuilder", "ngJsonExplorer"])
    .run([
        "$rootScope",
        'formioComponents',
        '$timeout',
        function (
            $rootScope,
            formioComponents,
            $timeout
        ) {
            $rootScope.displays = [{
                name: 'form',
                title: 'Form'
            }, {
                name: 'wizard',
                title: 'Wizard'
            }];
            $rootScope.form = { "components": [{ "type": "panel", "input": false, "title": "Wind Turbine Data", "theme": "default", "components": [{ "clearOnHide": false, "key": "pageWTDFieldset", "input": false, "tableView": false, "legend": "Wind Turbine Data", "components": [{ "input": true, "tableView": true, "label": "Report Type", "key": "ddlReportType", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Inspection", "$$hashKey": "object:35381" }, { "value": "2", "label": "Failure", "$$hashKey": "object:35382" }, { "value": "3", "label": "Repair", "$$hashKey": "object:35383" }, { "value": "4", "label": "Replacement", "$$hashKey": "object:35384" }, { "value": "5", "label": "Retrofit", "$$hashKey": "object:35385" }, { "value": "6", "label": "CMS Inspection", "$$hashKey": "object:35386" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "2", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "tooltip": "If a component has failed, always select “Failure” as primary. “Failure” reports are used for statistics and notifications to supplier.", "$$hashKey": "object:25157", "isNew": false }, { "tableView": true, "label": "CIM Case Number", "key": "ddlCimCaseNumber", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "$$hashKey": "object:1134", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "validate": { "required": true }, "dataSrc": "url", "template": "<span>{{ item.desc }}</span>", "data": { "url": "https://vestascirmobileappdev.azurewebsites.net/api/CIMCaseTable" }, "valueProperty": "value" }, { "input": true, "tableView": true, "label": "Reason For Service", "key": "txtReasonForService", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:101840" }, { "input": true, "tableView": true, "inputType": "number", "label": "Turbine Number", "key": "txtTurbineNumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "tooltip": "Country, site name and wind turbine parameters are filled out automatically once the CIR is submitted.", "$$hashKey": "object:25159" }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation", "model": { "controlId": "txtTurbineNumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateTurbineNumber/{{txtTurbineNumber}}", "errorMessage": "Turbine Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:49439" }, { "tableView": true, "label": "Turbine Data", "key": "pageWtdFieldsetTurbineData", "model": { "controlId": "txtTurbineNumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateGetTurbineData/{{txtTurbineNumber}}" }, "protected": false, "unique": false, "persistent": true, "type": "turbineData", "$$hashKey": "object:104261" }, { "input": true, "tableView": true, "label": "Run status at arrival", "key": "ddlRunstatusatarrival", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Run", "$$hashKey": "object:25520" }, { "value": "2", "label": "Stop", "$$hashKey": "object:25521" }, { "value": "3", "label": "Restrictions", "$$hashKey": "object:25522" }, { "value": "6", "label": "No power", "$$hashKey": "object:25523" }, { "value": "7", "label": "Pause", "$$hashKey": "object:25524" }, { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:25525" }, { "value": "0", "label": "", "$$hashKey": "object:25526" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "0", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25174" }, { "input": true, "tableView": true, "label": "Commissioning date", "key": "dtCommissioningdate", "placeholder": "Commissioning date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "overlay": { "width": "", "style": "width: 790px;" }, "$$hashKey": "object:25175" }, { "input": true, "tableView": true, "label": "Installation date of failed component", "key": "dtInstallationDate", "placeholder": "Installation date of failed component", "format": "d-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid = new Date(data.dtCommissioningdate) <= input ? true : 'Installation Date should be later than Commissioning Date'" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "overlay": { "width": "" }, "description": "", "customError": "Installation Date should be later than Commissioning Date", "$$hashKey": "object:34389" }, { "input": true, "tableView": true, "label": ".", "key": "ddlInstallationDateType", "placeholder": "", "data": { "values": [{ "value": "0", "label": "", "$$hashKey": "object:584" }, { "value": "1", "label": "Not Known", "$$hashKey": "object:585" }, { "value": "2", "label": "Original installation date", "$$hashKey": "object:586" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "overlay": { "style": "" }, "$$hashKey": "object:34727", "isNew": false }, { "input": true, "tableView": true, "label": "Failure date", "key": "dtFailuredate", "placeholder": "Failure date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid = new Date(data.dtCommissioningdate) <= input && (!data.dtInspectionDate || input <= new Date(data.dtInspectionDate)) ? true : 'Failure date should be later than Commissioning date and prior than Inspection date'" }, "type": "datetime", "tags": [], "conditional": { "show": "true", "when": "ddlReportType", "eq": "2" }, "properties": { "": "" }, "lockKey": true, "customError": "Failure date should be later than Commissioning date and prior than Inspection date", "$$hashKey": "object:25177" }, { "key": "pageWTDFieldsetHtml", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Failure date is not available", "type": "htmlelement", "tags": [], "conditional": { "show": "false", "when": "ddlReportType", "eq": "2" }, "properties": { "": "" }, "$$hashKey": "object:55092" }, { "input": true, "tableView": true, "label": "Inspection Date", "key": "dtInspectionDate", "placeholder": "Inspection Date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid =  !data.dtFailuredate || new Date(data.dtFailuredate) <= input ? true : 'Inspection date should be later or the same as Failure date'" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customError": "Inspection date should be later or the same as Failure date", "$$hashKey": "object:25178" }, { "clearOnHide": false, "input": false, "key": "pageWTDTable", "numRows": 1, "numCols": 2, "rows": [[{ "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Service report number", "key": "txtServicereportnumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "false", "when": "ddlServiceReportNumberType", "eq": "3" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:55700" }, { "key": "pageWTDFieldsetHtml2", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Service Report Number is not available", "type": "htmlelement", "tags": [], "conditional": { "show": "true", "when": "ddlServiceReportNumberType", "eq": "3" }, "properties": { "": "" }, "style": { "margin-top": "40px" }, "$$hashKey": "object:55701" }], "$$hashKey": "object:55694" }, { "components": [{ "input": true, "tableView": true, "label": "", "key": "ddlServiceReportNumberType", "placeholder": "", "data": { "values": [{ "value": "3", "label": "N/A", "$$hashKey": "object:25642" }, { "value": "1", "label": "ECR", "$$hashKey": "object:25643" }, { "value": "4", "label": "MAM/SAP", "$$hashKey": "object:25644" }, { "value": "2", "label": "VSS", "$$hashKey": "object:25645" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "4", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "style": { "margin-top": "23px" }, "$$hashKey": "object:25564" }], "$$hashKey": "object:25391" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": false, "tableView": false, "type": "table", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "style": { "margin-bottom": "-20px" }, "$$hashKey": "object:25179", "isNew": false }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation3", "model": { "controlId": "txtServicereportnumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateServiceReportNumber/{{txtServicereportnumber}}/{{txtTurbineNumber}}", "errorMessage": "Service Report Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:112094" }, { "input": true, "tableView": true, "inputType": "number", "label": "Notification number", "key": "txtNotificationnumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25180" }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation2", "model": { "controlId": "txtNotificationnumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateServiceNotificationNumber/{{txtNotificationnumber}}/{{txtTurbineNumber}}", "errorMessage": "Notification Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:89915" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Service Engineer/Technician", "key": "txtServiceEngineerTechnician", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25181" }, { "input": true, "tableView": true, "inputType": "number", "label": "Run (hrs)", "key": "txtRunhrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25182" }, { "input": true, "tableView": true, "inputType": "number", "label": "Generator 1 (hrs)", "key": "txtGenerator1hrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25183" }, { "input": true, "tableView": true, "inputType": "number", "label": "Generator 2 (hrs)", "key": "txtGenerator2hrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25184" }, { "input": true, "tableView": true, "inputType": "number", "label": "Total production (kWh)", "key": "txtTotalproductionkWh", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25185" }, { "input": true, "tableView": true, "label": "Run status after inspection", "key": "ddlRunstatusafterinspection", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Run", "$$hashKey": "object:25586" }, { "value": "2", "label": "Stop", "$$hashKey": "object:25587" }, { "value": "3", "label": "Restrictions", "$$hashKey": "object:25588" }, { "value": "6", "label": "No power", "$$hashKey": "object:25589" }, { "value": "7", "label": "Pause", "$$hashKey": "object:25590" }, { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:25591" }, { "value": "0", "label": "", "$$hashKey": "object:25592" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "0", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25186" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:25146" }, { "clearOnHide": false, "key": "fieldsetDescription", "input": false, "tableView": false, "legend": "Description", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Item Number", "key": "txtVestasItemNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25714" }, { "input": true, "tableView": true, "inputType": "number", "label": "Quantity of failed components/problems", "key": "txtQuantityoffailedcomponentsproblems", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25715" }, { "input": true, "tableView": true, "label": "Description", "key": "pageWTDFieldsetTextareaField", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:25716" }, { "input": true, "tableView": true, "label": "Up-Tower Solution Available", "key": "ddlRunstatusafterinspection2", "placeholder": "", "data": { "values": [{ "value": "1", "label": "No", "$$hashKey": "object:25806" }, { "value": "2", "label": "Yes", "$$hashKey": "object:25807" }, { "value": "", "label": "", "$$hashKey": "object:25808" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "$$hashKey": "object:25717" }, { "input": true, "tableView": true, "label": "Description of any consequential problems/damage", "key": "txtDescriptionofanyconsequentialproblemsdamage", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25718" }, { "input": true, "tableView": true, "label": "Additional Information", "key": "txtAdditionalInformation", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25719" }, { "input": true, "tableView": true, "label": "Tech. Support recommendation", "key": "txtTechSupportrecommendation", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25720" }, { "input": true, "tableView": true, "inputType": "number", "label": "Alarm Log Number", "key": "txtAlarmLogNumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25721" }, { "input": true, "tableView": true, "label": "Internal Comments", "key": "txtInternalComments", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25722", "description": "", "tooltip": "" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "$$hashKey": "object:25703" }, { "clearOnHide": false, "input": false, "key": "undefinedTable", "numRows": 1, "numCols": 1, "rows": [[{ "components": [{ "tableView": true, "key": "undefinedColumnsCirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "$$hashKey": "object:68506" }], "$$hashKey": "object:34287" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": false, "tableView": false, "type": "table", "$$hashKey": "object:34276", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "$$hashKey": "object:20", "clearOnHide": false, "tableView": false }, { "type": "panel", "title": "Skiipack", "components": [{ "clearOnHide": false, "key": "page2Fieldset", "input": false, "tableView": false, "legend": "SkiiP - Pack data", "components": [{ "input": true, "tableView": true, "label": "Number of Components", "key": "ddlNumberOfComponents", "placeholder": "", "data": { "values": [{ "value": "0", "label": "0", "$$hashKey": "object:206672" }, { "value": "1", "label": "1", "$$hashKey": "object:206673" }, { "value": "2", "label": "2", "$$hashKey": "object:206674" }, { "value": "3", "label": "3", "$$hashKey": "object:206675" }, { "value": "4", "label": "4", "$$hashKey": "object:206676" }, { "value": "5", "label": "5", "$$hashKey": "object:206677" }, { "value": "6", "label": "6", "$$hashKey": "object:206678" }, { "value": "7", "label": "7", "$$hashKey": "object:206679" }, { "value": "8", "label": "8", "$$hashKey": "object:206680" }, { "value": "9", "label": "9", "$$hashKey": "object:206681" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "$$hashKey": "object:43071", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "isNew": false }, { "clearOnHide": false, "key": "page2FieldsetFieldset", "input": false, "tableView": false, "legend": "1. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId1SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:189143", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId1VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:189144", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId1ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:189145", "lockKey": true }], "type": "fieldset", "$$hashKey": "object:69109", "tags": [], "conditional": { "show": "true", "when": "ddlNumberOfComponents", "eq": "" }, "properties": { "": "" }, "customConditional": "show=data['ddlNumberOfComponents'] >=1" }, { "clearOnHide": false, "key": "page2FieldsetFieldset10", "input": false, "tableView": false, "legend": "2. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId2SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188604", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId2VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188605", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId2ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188606", "lockKey": true }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188593", "customConditional": "show=data['ddlNumberOfComponents'] >=2" }, { "clearOnHide": false, "key": "page2FieldsetFieldset9", "input": false, "tableView": false, "legend": "3. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId3SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188557", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId3VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188558", "lockKey": true, "isNew": false }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId3ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188559", "lockKey": true, "isNew": false }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188546", "customConditional": "show=data['ddlNumberOfComponents'] >=3" }, { "clearOnHide": false, "key": "page2FieldsetFieldset8", "input": false, "tableView": false, "legend": "4. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId4SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:516734", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId4VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:516735", "lockKey": true, "isNew": false }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId4ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:516736", "lockKey": true }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188499", "lockKey": true, "customConditional": "show=data['ddlNumberOfComponents'] >=4" }, { "clearOnHide": false, "key": "page2FieldsetFieldset7", "input": false, "tableView": false, "legend": "5. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId5SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:619904" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId5VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:619905", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId5ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:619906" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188452", "lockKey": true, "customConditional": "show=data['ddlNumberOfComponents'] >=5" }, { "clearOnHide": false, "key": "page2FieldsetFieldset6", "input": false, "tableView": false, "legend": "6. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId6SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188416" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId6VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188417" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId6ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188418" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188405", "customConditional": "show=data['ddlNumberOfComponents'] >=6" }, { "clearOnHide": false, "key": "page2FieldsetFieldset5", "input": false, "tableView": false, "legend": "7. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId7SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188369" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId7VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188370" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId7ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188371" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188358", "customConditional": "show=data['ddlNumberOfComponents'] >=7" }, { "clearOnHide": false, "key": "page2FieldsetFieldset4", "input": false, "tableView": false, "legend": "8. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId8SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188322", "customConditional": "show=data['ddlNumberOfComponents'] >=8" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId8VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188323" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId8ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188324" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188311", "customConditional": "show=data['ddlNumberOfComponents'] >=8" }, { "clearOnHide": false, "key": "page2FieldsetFieldset3", "input": false, "tableView": false, "legend": "9. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "ComponentId9SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27556" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "ComponentId9VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27557" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "ComponentId9ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27558" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188264", "customConditional": "show=data['ddlNumberOfComponents'] >=9", "isNew": false }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:30743", "isNew": false }, { "clearOnHide": false, "key": "page2Fieldset2", "input": false, "tableView": false, "legend": "Replacements", "components": [{ "input": true, "tableView": true, "label": "Other Damaged Components Replaced", "key": "tbOtherDamagedComponentsReplaced", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "$$hashKey": "object:861517", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true }, { "clearOnHide": false, "key": "page2Fieldset2Fieldset", "input": false, "tableView": false, "legend": "New Modules Installed", "components": [{ "clearOnHide": false, "key": "page2FieldsetFieldset2", "input": false, "tableView": false, "legend": "1. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule1SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27346" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule1VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27347" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule1ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:27348" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:171300", "customConditional": "show=data['ddlNumberOfComponents'] >=1" }, { "clearOnHide": false, "key": "page2FieldsetFieldset17", "input": false, "tableView": false, "legend": "2. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule2SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188933" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule2VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188934" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule2ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188935" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188922", "customConditional": "show=data['ddlNumberOfComponents'] >=2" }, { "clearOnHide": false, "key": "page2FieldsetFieldset16", "input": false, "tableView": false, "legend": "3. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule3SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188886" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule3VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188887" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule3ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188888" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188875", "customConditional": "show=data['ddlNumberOfComponents'] >=3" }, { "clearOnHide": false, "key": "page2FieldsetFieldset15", "input": false, "tableView": false, "legend": "4. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule4SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188839" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule4VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188840" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule4ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188841" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188828", "customConditional": "show=data['ddlNumberOfComponents'] >=4" }, { "clearOnHide": false, "key": "page2FieldsetFieldset14", "input": false, "tableView": false, "legend": "5. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule5SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188792" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule5VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188793" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule5ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188794" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188781", "customConditional": "show=data['ddlNumberOfComponents'] >=5" }, { "clearOnHide": false, "key": "page2FieldsetFieldset13", "input": false, "tableView": false, "legend": "6. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule6SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188745" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule6VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188746" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule6ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188747" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188734", "customConditional": "show=data['ddlNumberOfComponents'] >=6" }, { "clearOnHide": false, "key": "page2FieldsetFieldset12", "input": false, "tableView": false, "legend": "7. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule7SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188698" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule7VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188699" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule7ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188700" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188687", "customConditional": "show=data['ddlNumberOfComponents'] >=7" }, { "clearOnHide": false, "key": "page2FieldsetFieldset11", "input": false, "tableView": false, "legend": "8. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule8SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188651" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule8VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188652" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule8ItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:188653" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:188640", "customConditional": "show=data['ddlNumberOfComponents'] >=8" }, { "clearOnHide": false, "key": "page2FieldsetFieldset18", "input": false, "tableView": false, "legend": "9. Component Identification", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number", "key": "NewModule9SerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:164331" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Unique Identifier", "key": "NewModule9VestasUniqueIdentifier", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:164332", "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Item No.", "key": "NewModule9VestasItemNo", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "$$hashKey": "object:164333" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show=data['ddlNumberOfComponents'] >=8", "$$hashKey": "object:164320" }], "type": "fieldset", "$$hashKey": "object:35081", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:844586" }, { "clearOnHide": false, "key": "page2Fieldset3", "input": false, "tableView": false, "legend": "Failure Descriptions", "components": [{ "input": true, "tableView": true, "label": "Reason", "key": "ddlSkiiPackReason", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Module Failure", "$$hashKey": "object:172479" }, { "value": "2", "label": "External Failure", "$$hashKey": "object:172480" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:172415" }, { "input": true, "tableView": true, "label": "Quantity od Failed Modules", "key": "tbQuantityodFailedModules", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "$$hashKey": "object:997333", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true }], "type": "fieldset", "$$hashKey": "object:929441", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }, { "clearOnHide": false, "key": "page2Fieldset4", "input": false, "tableView": false, "legend": "WTG Platform", "components": [{ "clearOnHide": false, "key": "page2Fieldset4Fieldset", "input": false, "tableView": false, "legend": "2MW", "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page2Fieldset4FieldsetColumns", "columns": [{ "components": [{ "input": true, "tableView": true, "label": "7.30.030 V521", "key": "ddl730030V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34914" }, { "value": "1", "label": "NO", "$$hashKey": "object:34915" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34848" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34826" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.040 V521", "key": "ddl730040V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34921" }, { "value": "1", "label": "NO", "$$hashKey": "object:34922" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34852" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34827" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.050 V521", "key": "ddl730050V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34928" }, { "value": "1", "label": "NO", "$$hashKey": "object:34929" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34856" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34828" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.060 V521", "key": "ddl730060V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34935" }, { "value": "1", "label": "NO", "$$hashKey": "object:34936" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34860" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34829" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.070 V521", "key": "ddl730070V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34942" }, { "value": "1", "label": "NO", "$$hashKey": "object:34943" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34864" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34830" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.080 V521", "key": "ddl730080V521", "placeholder": "", "data": { "values": [{ "value": "0", "label": "YES", "$$hashKey": "object:34949" }, { "value": "1", "label": "NO", "$$hashKey": "object:34950" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:34868" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:34831" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:34821" }], "type": "fieldset", "$$hashKey": "object:1065229", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "isNew": false }, { "clearOnHide": false, "key": "page2Fieldset4Fieldset2", "input": false, "tableView": false, "legend": "3MW", "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page2Fieldset4Fieldset2Columns", "columns": [{ "components": [{ "input": true, "tableView": true, "label": "7.30.090 V524y", "key": "ddl730090V524y", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:1419" }, { "value": "1", "label": "NO", "$$hashKey": "object:1420" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:172403", "isNew": false }, { "input": true, "tableView": true, "label": "7.30.150 V526y", "key": "ddl730150V526y", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:172465" }, { "value": "1", "label": "NO", "$$hashKey": "object:172466" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:172404" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172381" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.100 V524x", "key": "ddl730100V524", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:172472" }, { "value": "1", "label": "NO", "$$hashKey": "object:172473" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:172411" }, { "input": true, "tableView": true, "label": "7.30.160 V526x", "key": "ddl730160V526x", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:334741" }, { "value": "1", "label": "NO", "$$hashKey": "object:334742" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:334727" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172384" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.110 V521", "key": "ddl730110V522", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:249749" }, { "value": "1", "label": "NO", "$$hashKey": "object:249750" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:249735" }, { "input": true, "tableView": true, "label": "7.30.170 V523", "key": "ddl730170V523", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:172479" }, { "value": "1", "label": "NO", "$$hashKey": "object:172480" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:172415" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172385" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.120 V525y", "key": "ddl730120V525y2", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:266717" }, { "value": "1", "label": "NO", "$$hashKey": "object:266718" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:266703" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172386" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.130 V525x", "key": "ddl730130V525x", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:189638" }, { "value": "1", "label": "NO", "$$hashKey": "object:189639" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:189624" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172670" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.140 V522", "key": "ddl730140V522", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:283685" }, { "value": "1", "label": "NO", "$$hashKey": "object:283686" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:283671" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:172676" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:172376" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:1846703", "isNew": false }, { "clearOnHide": false, "key": "page2Fieldset4Fieldset3", "input": false, "tableView": false, "legend": "850kW", "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page2Fieldset4Fieldset3Columns", "columns": [{ "components": [{ "input": true, "tableView": true, "label": "7.30.180 V525", "key": "ddl730180V525", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:215423" }, { "value": "1", "label": "NO", "$$hashKey": "object:215424" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:215378" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:215359" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.190 V526", "key": "ddl730190V526", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:215430" }, { "value": "1", "label": "NO", "$$hashKey": "object:215431" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:215382" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:215360" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.200 V524", "key": "ddl730200V524", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:215437" }, { "value": "1", "label": "NO", "$$hashKey": "object:215438" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:215386" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:215361" }, { "components": [{ "input": true, "tableView": true, "label": "7.30.210 V520", "key": "ddl730210V520", "placeholder": "", "data": { "values": [{ "value": "2", "label": "YES", "$$hashKey": "object:215444" }, { "value": "1", "label": "NO", "$$hashKey": "object:215445" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:215390" }], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:215362" }, { "components": [], "width": 2, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:215363" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:215354" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:2050689", "isNew": false }], "type": "fieldset", "$$hashKey": "object:1031297", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }, { "clearOnHide": false, "input": false, "tableView": false, "key": "undefinedColumns2", "columns": [{ "components": [{ "tableView": true, "key": "undefinedColumns2CirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "isNew": true, "$$hashKey": "object:691788" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:657874" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:657875" }], "type": "columns", "$$hashKey": "object:657869", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page2", "$$hashKey": "object:5443", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }, { "type": "panel", "title": "Images", "components": [{ "input": true, "inputType": "checkbox", "tableView": true, "label": "Plate Type Picture Not possible", "datagridLabel": true, "key": "cbPlateTypePictureNotPossible", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:128164", "hideLabel": true, "style": { "margin-left": "20px" } }, { "input": true, "tableView": true, "label": "Reason", "key": "tbPlateTypePictureNotPossibleReason", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "$$hashKey": "object:85378", "tags": [], "conditional": { "show": "true", "when": "cbPlateTypePictureNotPossible", "eq": "true" }, "properties": { "": "" }, "lockKey": true }, { "tableView": true, "label": "Upload Images", "key": "page3UploadImages", "description": "Drag files here or click to upload", "protected": false, "unique": false, "persistent": true, "type": "imageUploader", "$$hashKey": "object:6894" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "undefinedColumns3", "columns": [{ "components": [{ "tableView": true, "key": "undefinedColumns3CirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "isNew": true, "$$hashKey": "object:6371" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:18917" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:19203" }], "type": "columns", "$$hashKey": "object:18912", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page3", "$$hashKey": "object:6582", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }, { "type": "panel", "title": "Dynamic Fields", "components": [{ "tableView": true, "label": "Dynamic Fields", "key": "page5DynamicFields", "description": "Custom Slider", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicFields", "tagas": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "model": { "controlId": "ddlCimCaseNumber" }, "$$hashKey": "object:171132", "tags": [] }], "input": false, "key": "page5", "$$hashKey": "object:85584", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": "txtReasonForService", "eq": "3800" }, "properties": { "": "" }, "customConditional": "show=data['ddlCimCaseNumber'] ==3800 || data['ddlCimCaseNumber'] ==3786 || data['ddlCimCaseNumber'] ==3664 ||  data['ddlCimCaseNumber'] ==3550  ||  data['ddlCimCaseNumber'] ==3921" }, { "type": "panel", "title": "Submission", "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page4Columns", "columns": [{ "components": [{ "tableView": true, "key": "page4ColumnsCirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "$$hashKey": "object:68777" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:59582" }, { "components": [{ "tableView": true, "key": "page4ColumnsSubmitForm", "protected": false, "unique": false, "persistent": true, "type": "submitForm", "$$hashKey": "object:73238" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:59583" }], "type": "columns", "$$hashKey": "object:59577", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page4", "$$hashKey": "object:45863", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "display": "wizard", "page": 1, "numPages": 5 };
                //$rootScope.form = { "components": [{ "type": "panel", "input": false, "title": "Wind Turbine Data", "theme": "default", "components": [{ "clearOnHide": false, "key": "pageWTDFieldset", "input": false, "tableView": false, "legend": "Wind Turbine Data", "components": [{ "input": true, "tableView": true, "label": "Report Type", "key": "ddlReportType", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Inspection", "$$hashKey": "object:25455" }, { "value": "2", "label": "Failure", "$$hashKey": "object:25456" }, { "value": "3", "label": "Repair", "$$hashKey": "object:25457" }, { "value": "4", "label": "Replacement", "$$hashKey": "object:25458" }, { "value": "5", "label": "Retrofit", "$$hashKey": "object:25459" }, { "value": "6", "label": "CMS Inspection", "$$hashKey": "object:25460" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "2", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "tooltip": "If a component has failed, always select “Failure” as primary. “Failure” reports are used for statistics and notifications to supplier.", "$$hashKey": "object:25157" }, { "tableView": true, "label": "CIM Case Number", "key": "ddlCimCaseNumber", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "$$hashKey": "object:1134", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "validate": { "required": true }, "dataSrc": "url", "template": "<span>{{ item.desc }}</span>", "data": { "url": "https://vestascirmobileappdev.azurewebsites.net/api/CIMCaseTable" }, "valueProperty": "value" }, { "input": true, "tableView": true, "label": "Reason For Service", "key": "txtReasonForService", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:101840" }, { "input": true, "tableView": true, "inputType": "number", "label": "Turbine Number", "key": "txtTurbineNumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "tooltip": "Country, site name and wind turbine parameters are filled out automatically once the CIR is submitted.", "$$hashKey": "object:25159" }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation", "model": { "controlId": "txtTurbineNumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateTurbineNumber/{{txtTurbineNumber}}", "errorMessage": "Turbine Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:49439" }, { "tableView": true, "label": "Turbine Data", "key": "pageWtdFieldsetTurbineData", "model": { "controlId": "txtTurbineNumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateGetTurbineData/{{txtTurbineNumber}}" }, "protected": false, "unique": false, "persistent": true, "type": "turbineData", "$$hashKey": "object:104261" }, { "input": true, "tableView": true, "label": "Run status at arrival", "key": "ddlRunstatusatarrival", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Run", "$$hashKey": "object:25520" }, { "value": "2", "label": "Stop", "$$hashKey": "object:25521" }, { "value": "3", "label": "Restrictions", "$$hashKey": "object:25522" }, { "value": "6", "label": "No power", "$$hashKey": "object:25523" }, { "value": "7", "label": "Pause", "$$hashKey": "object:25524" }, { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:25525" }, { "value": "0", "label": "", "$$hashKey": "object:25526" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "0", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25174" }, { "input": true, "tableView": true, "label": "Commissioning date", "key": "dtCommissioningdate", "placeholder": "Commissioning date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "overlay": { "width": "", "style": "width: 790px;" }, "$$hashKey": "object:25175" }, { "input": true, "tableView": true, "label": "Installation date of failed component", "key": "dtInstallationDate", "placeholder": "Installation date of failed component", "format": "d-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid = new Date(data.dtCommissioningdate) <= input ? true : 'Installation Date should be later than Commissioning Date'" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "overlay": { "width": "" }, "description": "", "customError": "Installation Date should be later than Commissioning Date", "$$hashKey": "object:34389" }, { "input": true, "tableView": true, "label": ".", "key": "ddlInstallationDateType", "placeholder": "", "data": { "values": [{ "value": "0", "label": "", "$$hashKey": "object:34741" }, { "value": "1", "label": "Not Known", "$$hashKey": "object:34742" }, { "value": "2", "label": "Original installation date", "$$hashKey": "object:34743" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "style": { "margin-top": "23px" }, "overlay": { "style": "" }, "$$hashKey": "object:34727" }, { "input": true, "tableView": true, "label": "Failure date", "key": "dtFailuredate", "placeholder": "Failure date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid = new Date(data.dtCommissioningdate) <= input && (!data.dtInspectionDate || input <= new Date(data.dtInspectionDate)) ? true : 'Failure date should be later than Commissioning date and prior than Inspection date'" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customError": "Failure date should be later than Commissioning date and prior than Inspection date", "$$hashKey": "object:25177" }, { "input": true, "tableView": true, "label": "Inspection Date", "key": "dtInspectionDate", "placeholder": "Inspection Date", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "custom": "valid =  !data.dtFailuredate || new Date(data.dtFailuredate) <= input ? true : 'Inspection date should be later or the same as Failure date'" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customError": "Inspection date should be later or the same as Failure date", "$$hashKey": "object:25178" }, { "clearOnHide": false, "input": false, "key": "pageWTDTable", "numRows": 1, "numCols": 2, "rows": [[{ "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Service report number", "key": "txtServicereportnumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25560" }], "$$hashKey": "object:25390" }, { "components": [{ "input": true, "tableView": true, "label": "", "key": "ddlServiceReportNumberType", "placeholder": "", "data": { "values": [{ "value": "3", "label": "N/A", "$$hashKey": "object:25642" }, { "value": "1", "label": "ECR", "$$hashKey": "object:25643" }, { "value": "4", "label": "MAM/SAP", "$$hashKey": "object:25644" }, { "value": "2", "label": "VSS", "$$hashKey": "object:25645" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "4", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "style": { "margin-top": "23px" }, "$$hashKey": "object:25564" }], "$$hashKey": "object:25391" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": false, "tableView": false, "type": "table", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "style": { "margin-bottom": "-20px" }, "$$hashKey": "object:25179" }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation3", "model": { "controlId": "txtServicereportnumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateServiceReportNumber/{{txtServicereportnumber}}/{{txtTurbineNumber}}", "errorMessage": "Service Report Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:112094" }, { "input": true, "tableView": true, "inputType": "number", "label": "Notification number", "key": "txtNotificationnumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25180" }, { "tableView": true, "label": "Advanced Validation", "key": "pageWtdFieldsetAdvancedValidation2", "model": { "controlId": "txtNotificationnumber", "apiUrl": "https://vestascirmobileappdev.azurewebsites.net/api/ValidateServiceNotificationNumber/{{txtNotificationnumber}}/{{txtTurbineNumber}}", "errorMessage": "Notification Number is invalid." }, "protected": false, "unique": false, "persistent": true, "type": "advancedValidation", "$$hashKey": "object:89915" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Service Engineer/Technician", "key": "txtServiceEngineerTechnician", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25181" }, { "input": true, "tableView": true, "inputType": "number", "label": "Run (hrs)", "key": "txtRunhrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25182" }, { "input": true, "tableView": true, "inputType": "number", "label": "Generator 1 (hrs)", "key": "txtGenerator1hrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25183" }, { "input": true, "tableView": true, "inputType": "number", "label": "Generator 2 (hrs)", "key": "txtGenerator2hrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25184" }, { "input": true, "tableView": true, "inputType": "number", "label": "Total production (kWh)", "key": "txtTotalproductionkWh", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25185" }, { "input": true, "tableView": true, "label": "Run status after inspection", "key": "ddlRunstatusafterinspection", "placeholder": "", "data": { "values": [{ "value": "1", "label": "Run", "$$hashKey": "object:25586" }, { "value": "2", "label": "Stop", "$$hashKey": "object:25587" }, { "value": "3", "label": "Restrictions", "$$hashKey": "object:25588" }, { "value": "6", "label": "No power", "$$hashKey": "object:25589" }, { "value": "7", "label": "Pause", "$$hashKey": "object:25590" }, { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:25591" }, { "value": "0", "label": "", "$$hashKey": "object:25592" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "0", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25186" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:25146" }, { "clearOnHide": false, "key": "fieldsetDescription", "input": false, "tableView": false, "legend": "Description", "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Vestas Item Number", "key": "txtVestasItemNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25714" }, { "input": true, "tableView": true, "inputType": "number", "label": "Quantity of failed components/problems", "key": "txtQuantityoffailedcomponentsproblems", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25715" }, { "input": true, "tableView": true, "label": "Description", "key": "pageWTDFieldsetTextareaField", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:25716" }, { "input": true, "tableView": true, "label": "Up-Tower Solution Available", "key": "ddlRunstatusafterinspection2", "placeholder": "", "data": { "values": [{ "value": "1", "label": "No", "$$hashKey": "object:25806" }, { "value": "2", "label": "Yes", "$$hashKey": "object:25807" }, { "value": "", "label": "", "$$hashKey": "object:25808" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "$$hashKey": "object:25717" }, { "input": true, "tableView": true, "label": "Description of any consequential problems/damage", "key": "txtDescriptionofanyconsequentialproblemsdamage", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25718" }, { "input": true, "tableView": true, "label": "Additional Information", "key": "txtAdditionalInformation", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25719" }, { "input": true, "tableView": true, "label": "Tech. Support recommendation", "key": "txtTechSupportrecommendation", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25720" }, { "input": true, "tableView": true, "inputType": "number", "label": "Alarm Log Number", "key": "txtAlarmLogNumber", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25721" }, { "input": true, "tableView": true, "label": "Internal Comments", "key": "txtInternalComments", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:25722", "description": "", "tooltip": "" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "$$hashKey": "object:25703" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "undefinedColumns", "columns": [{ "components": [{ "tableView": true, "key": "undefinedColumnsCirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "$$hashKey": "object:13424" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:13415" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:13417" }], "type": "columns", "$$hashKey": "object:13144", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "$$hashKey": "object:20", "clearOnHide": false, "tableView": false }, { "type": "panel", "title": "Gearbox", "isNew": true, "components": [{ "clearOnHide": false, "key": "page2Fieldset", "input": false, "tableView": false, "legend": "Gearbox Data", "components": [{ "tableView": true, "label": "Gearbox Manufacturer", "key": "ddlGearboxManufacturer", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "10", "label": "N/A", "$$hashKey": "object:30966" }, { "value": "11", "label": "IMO", "$$hashKey": "object:30967" }, { "value": "13", "label": "JaKe", "$$hashKey": "object:30968" }, { "value": "12", "label": "Laulagun", "$$hashKey": "object:30969" }, { "value": "4", "label": "Lohmann/Rexroth", "$$hashKey": "object:30970" }, { "value": "5", "label": "Metso/Valmet/Santasalo/Moventas", "$$hashKey": "object:30971" }, { "value": "7", "label": "Other Manufacturer", "$$hashKey": "object:30972" }, { "value": "14", "label": "Vestas Spareparts/Repair", "$$hashKey": "object:30973" }, { "value": "9", "label": "Winergy/Flender", "$$hashKey": "object:30974" }, { "value": "1", "label": "Zf / Hansen", "$$hashKey": "object:30975" }] }, "lockKey": true, "validate": { "required": true }, "input": true, "$$hashKey": "object:30754" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Other Gearbox Manufacturer", "key": "txtOtherGearboxManufacturer", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:30755" }, { "input": true, "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeEmpty", "placeholder": "", "data": { "values": [{ "value": "", "label": "", "$$hashKey": "object:30992" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlGearboxManufacturer;", "$$hashKey": "object:30756" }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeZfHansen", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "1" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "211", "label": "Atlas 1.0", "$$hashKey": "object:30997" }, { "value": "212", "label": "Atlas 1.1", "$$hashKey": "object:30998" }, { "value": "213", "label": "Atlas 1.2", "$$hashKey": "object:30999" }, { "value": "7", "label": "EF901", "$$hashKey": "object:31000" }, { "value": "8", "label": "EH55", "$$hashKey": "object:31001" }, { "value": "9", "label": "EH551", "$$hashKey": "object:31002" }, { "value": "10", "label": "EH552", "$$hashKey": "object:31003" }, { "value": "11", "label": "EH553", "$$hashKey": "object:31004" }, { "value": "12", "label": "EH601", "$$hashKey": "object:31005" }, { "value": "13", "label": "EH80", "$$hashKey": "object:31006" }, { "value": "14", "label": "EH801L21", "$$hashKey": "object:31007" }, { "value": "15", "label": "EH801L31", "$$hashKey": "object:31008" }, { "value": "16", "label": "EH802", "$$hashKey": "object:31009" }, { "value": "17", "label": "EH803", "$$hashKey": "object:31010" }, { "value": "18", "label": "EH804", "$$hashKey": "object:31011" }, { "value": "215", "label": "EH921", "$$hashKey": "object:31012" }, { "value": "216", "label": "EH922", "$$hashKey": "object:31013" }, { "value": "90", "label": "RTH7C1", "$$hashKey": "object:31014" }] }, "validate": { "required": true }, "customConditional": "", "lockKey": true, "$$hashKey": "object:30757" }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeJaKe", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "13" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "CS 520", "$$hashKey": "object:31036" }, { "value": "2", "label": "CS 530", "$$hashKey": "object:31037" }, { "value": "3", "label": "CS 630", "$$hashKey": "object:31038" }, { "value": "4", "label": "CS 631", "$$hashKey": "object:31039" }, { "value": "5", "label": "CSF 681", "$$hashKey": "object:31040" }, { "value": "6", "label": "CSF 681 Split", "$$hashKey": "object:31041" }, { "value": "78", "label": "PSC 1000", "$$hashKey": "object:31042" }, { "value": "79", "label": "PSC 1001", "$$hashKey": "object:31043" }, { "value": "80", "label": "PSC 1010", "$$hashKey": "object:31044" }, { "value": "81", "label": "PSC 1020", "$$hashKey": "object:31045" }, { "value": "82", "label": "PSC 1030", "$$hashKey": "object:31046" }, { "value": "83", "label": "PSC 1050", "$$hashKey": "object:31047" }, { "value": "84", "label": "PSC 1051", "$$hashKey": "object:31048" }, { "value": "85", "label": "PSC 1052", "$$hashKey": "object:31049" }, { "value": "86", "label": "PSC 1400", "$$hashKey": "object:31050" }, { "value": "87", "label": "PSC 1430", "$$hashKey": "object:31051" }] }, "validate": { "required": true }, "$$hashKey": "object:30758" }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeLohmannRexroth", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "4" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "19", "label": "GPV300", "$$hashKey": "object:31071" }, { "value": "20", "label": "GPV300S", "$$hashKey": "object:31072" }, { "value": "21", "label": "GPV305", "$$hashKey": "object:31073" }, { "value": "22", "label": "GPV305S", "$$hashKey": "object:31074" }, { "value": "23", "label": "GPV305S1", "$$hashKey": "object:31075" }, { "value": "24", "label": "GPV306", "$$hashKey": "object:31076" }, { "value": "25", "label": "GPV306S", "$$hashKey": "object:31077" }, { "value": "26", "label": "GPV306S1", "$$hashKey": "object:31078" }, { "value": "27", "label": "GPV306S2", "$$hashKey": "object:31079" }, { "value": "28", "label": "GPV400", "$$hashKey": "object:31080" }, { "value": "29", "label": "GPV401", "$$hashKey": "object:31081" }, { "value": "30", "label": "GPV401S", "$$hashKey": "object:31082" }, { "value": "31", "label": "GPV440", "$$hashKey": "object:31083" }, { "value": "32", "label": "GPV440S", "$$hashKey": "object:31084" }, { "value": "33", "label": "GPV440S1", "$$hashKey": "object:31085" }, { "value": "34", "label": "GPV441", "$$hashKey": "object:31086" }, { "value": "35", "label": "GPV441S", "$$hashKey": "object:31087" }, { "value": "36", "label": "GPV441S1", "$$hashKey": "object:31088" }, { "value": "37", "label": "GPV442", "$$hashKey": "object:31089" }, { "value": "38", "label": "GPV442S", "$$hashKey": "object:31090" }, { "value": "39", "label": "GPV442S1", "$$hashKey": "object:31091" }, { "value": "209", "label": "GPV570D", "$$hashKey": "object:31092" }] }, "lockKey": true, "$$hashKey": "object:30759", "validate": { "required": true } }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeVestasSparepartsRepair", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "14" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "106", "label": "CS_520", "$$hashKey": "object:31118" }, { "value": "107", "label": "CS_530", "$$hashKey": "object:31119" }, { "value": "108", "label": "CS_630", "$$hashKey": "object:31120" }, { "value": "109", "label": "CS_631", "$$hashKey": "object:31121" }, { "value": "110", "label": "CSF_681", "$$hashKey": "object:31122" }, { "value": "111", "label": "CSF_681 Split", "$$hashKey": "object:31123" }, { "value": "112", "label": "EF_901", "$$hashKey": "object:31124" }, { "value": "113", "label": "EH_55", "$$hashKey": "object:31125" }, { "value": "114", "label": "EH_551", "$$hashKey": "object:31126" }, { "value": "115", "label": "EH_552", "$$hashKey": "object:31127" }, { "value": "116", "label": "EH_553", "$$hashKey": "object:31128" }, { "value": "117", "label": "EH_601", "$$hashKey": "object:31129" }, { "value": "118", "label": "EH_80", "$$hashKey": "object:31130" }, { "value": "119", "label": "EH_801L21", "$$hashKey": "object:31131" }, { "value": "120", "label": "EH_801L31", "$$hashKey": "object:31132" }, { "value": "121", "label": "EH_802", "$$hashKey": "object:31133" }, { "value": "122", "label": "EH_803", "$$hashKey": "object:31134" }, { "value": "123", "label": "EH_804", "$$hashKey": "object:31135" }, { "value": "124", "label": "GPV_300", "$$hashKey": "object:31136" }, { "value": "125", "label": "GPV_300S", "$$hashKey": "object:31137" }, { "value": "126", "label": "GPV_305", "$$hashKey": "object:31138" }, { "value": "127", "label": "GPV_305S", "$$hashKey": "object:31139" }, { "value": "128", "label": "GPV_305S1", "$$hashKey": "object:31140" }, { "value": "129", "label": "GPV_306", "$$hashKey": "object:31141" }, { "value": "130", "label": "GPV_306S", "$$hashKey": "object:31142" }, { "value": "131", "label": "GPV_306S1", "$$hashKey": "object:31143" }, { "value": "132", "label": "GPV_306S2", "$$hashKey": "object:31144" }, { "value": "133", "label": "GPV_400", "$$hashKey": "object:31145" }, { "value": "134", "label": "GPV_401", "$$hashKey": "object:31146" }, { "value": "135", "label": "GPV_401S", "$$hashKey": "object:31147" }, { "value": "136", "label": "GPV_440", "$$hashKey": "object:31148" }, { "value": "137", "label": "GPV_440S", "$$hashKey": "object:31149" }, { "value": "138", "label": "GPV_440S1", "$$hashKey": "object:31150" }, { "value": "139", "label": "GPV_441", "$$hashKey": "object:31151" }, { "value": "140", "label": "GPV_441S", "$$hashKey": "object:31152" }, { "value": "141", "label": "GPV_441S1", "$$hashKey": "object:31153" }, { "value": "142", "label": "GPV_442", "$$hashKey": "object:31154" }, { "value": "143", "label": "GPV_442S", "$$hashKey": "object:31155" }, { "value": "144", "label": "GPV_442S1", "$$hashKey": "object:31156" }, { "value": "145", "label": "PEAB_4285", "$$hashKey": "object:31157" }, { "value": "146", "label": "PEAB_4320", "$$hashKey": "object:31158" }, { "value": "147", "label": "PEAB_4395", "$$hashKey": "object:31159" }, { "value": "148", "label": "PEAB_4420", "$$hashKey": "object:31160" }, { "value": "149", "label": "PEAB_4435", "$$hashKey": "object:31161" }, { "value": "150", "label": "PEAB_4460", "$$hashKey": "object:31162" }, { "value": "151", "label": "PEAB_4500", "$$hashKey": "object:31163" }, { "value": "152", "label": "PEAC_4280", "$$hashKey": "object:31164" }, { "value": "153", "label": "PEAC_4300", "$$hashKey": "object:31165" }, { "value": "154", "label": "PEAC_4355", "$$hashKey": "object:31166" }, { "value": "155", "label": "PEAC_4455", "$$hashKey": "object:31167" }, { "value": "156", "label": "PEAK_4224", "$$hashKey": "object:31168" }, { "value": "157", "label": "PEAK_4280", "$$hashKey": "object:31169" }, { "value": "158", "label": "PEAK_4300", "$$hashKey": "object:31170" }, { "value": "159", "label": "PEAK_4355", "$$hashKey": "object:31171" }, { "value": "160", "label": "PEAL_4290", "$$hashKey": "object:31172" }, { "value": "161", "label": "PEAS_4285 ", "$$hashKey": "object:31173" }, { "value": "162", "label": "PEAS_4290", "$$hashKey": "object:31174" }, { "value": "163", "label": "PEAS_4300", "$$hashKey": "object:31175" }, { "value": "164", "label": "PEAS_4355", "$$hashKey": "object:31176" }, { "value": "165", "label": "PEAS_4390", "$$hashKey": "object:31177" }, { "value": "166", "label": "PEAS_4395", "$$hashKey": "object:31178" }, { "value": "167", "label": "PEAS_4460", "$$hashKey": "object:31179" }, { "value": "168", "label": "PLH_1100", "$$hashKey": "object:31180" }, { "value": "169", "label": "PLH_1400", "$$hashKey": "object:31181" }, { "value": "170", "label": "PLH_3000", "$$hashKey": "object:31182" }, { "value": "171", "label": "PLH_302", "$$hashKey": "object:31183" }, { "value": "172", "label": "PLH_304", "$$hashKey": "object:31184" }, { "value": "173", "label": "PLH_306", "$$hashKey": "object:31185" }, { "value": "174", "label": "PLH_307", "$$hashKey": "object:31186" }, { "value": "175", "label": "PLH_308", "$$hashKey": "object:31187" }, { "value": "176", "label": "PLH_309", "$$hashKey": "object:31188" }, { "value": "177", "label": "PLH_310", "$$hashKey": "object:31189" }, { "value": "178", "label": "PLH_311", "$$hashKey": "object:31190" }, { "value": "179", "label": "PLH_312", "$$hashKey": "object:31191" }, { "value": "180", "label": "PLH_360", "$$hashKey": "object:31192" }, { "value": "181", "label": "PLH_400", "$$hashKey": "object:31193" }, { "value": "182", "label": "PLH_500", "$$hashKey": "object:31194" }, { "value": "183", "label": "PSC_1000", "$$hashKey": "object:31195" }, { "value": "184", "label": "PSC_1001", "$$hashKey": "object:31196" }, { "value": "185", "label": "PSC_1010", "$$hashKey": "object:31197" }, { "value": "186", "label": "PSC_1020", "$$hashKey": "object:31198" }, { "value": "187", "label": "PSC_1030", "$$hashKey": "object:31199" }, { "value": "188", "label": "PSC_1050", "$$hashKey": "object:31200" }, { "value": "189", "label": "PSC_1051", "$$hashKey": "object:31201" }, { "value": "190", "label": "PSC_1052", "$$hashKey": "object:31202" }, { "value": "191", "label": "PSC_1400", "$$hashKey": "object:31203" }, { "value": "192", "label": "PSC_1430", "$$hashKey": "object:31204" }, { "value": "193", "label": "PSC_1431", "$$hashKey": "object:31205" }, { "value": "194", "label": "PZAB_3620", "$$hashKey": "object:31206" }, { "value": "195", "label": "RTH_7C1", "$$hashKey": "object:31207" }, { "value": "196", "label": "S2GH_451X", "$$hashKey": "object:31208" }, { "value": "197", "label": "S3GHD_500X", "$$hashKey": "object:31209" }, { "value": "198", "label": "S3GHD_506X", "$$hashKey": "object:31210" }, { "value": "199", "label": "SDAK_2555", "$$hashKey": "object:31211" }, { "value": "200", "label": "SOND_2410", "$$hashKey": "object:31212" }, { "value": "201", "label": "SZAK_2410", "$$hashKey": "object:31213" }, { "value": "202", "label": "SZAK_2425", "$$hashKey": "object:31214" }, { "value": "203", "label": "VTA_2450", "$$hashKey": "object:31215" }, { "value": "204", "label": "WW_500/3700", "$$hashKey": "object:31216" }, { "value": "205", "label": "WW_550/4100", "$$hashKey": "object:31217" }, { "value": "206", "label": "WW_600/4200", "$$hashKey": "object:31218" }, { "value": "207", "label": "AA_410", "$$hashKey": "object:31219" }] }, "validate": { "required": true }, "$$hashKey": "object:30760" }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeMetsoValmetSantasaloMoventas", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "5" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "63", "label": "PLH-1100", "$$hashKey": "object:31325" }, { "value": "64", "label": "PLH-1400", "$$hashKey": "object:31326" }, { "value": "65", "label": "PLH-300", "$$hashKey": "object:31327" }, { "value": "66", "label": "PLH-302", "$$hashKey": "object:31328" }, { "value": "67", "label": "PLH-304", "$$hashKey": "object:31329" }, { "value": "68", "label": "PLH-306", "$$hashKey": "object:31330" }, { "value": "69", "label": "PLH-307", "$$hashKey": "object:31331" }, { "value": "70", "label": "PLH-308", "$$hashKey": "object:31332" }, { "value": "71", "label": "PLH-309", "$$hashKey": "object:31333" }, { "value": "72", "label": "PLH-310", "$$hashKey": "object:31334" }, { "value": "73", "label": "PLH-311", "$$hashKey": "object:31335" }, { "value": "74", "label": "PLH-312", "$$hashKey": "object:31336" }, { "value": "75", "label": "PLH-360", "$$hashKey": "object:31337" }, { "value": "76", "label": "PLH400", "$$hashKey": "object:31338" }, { "value": "77", "label": "PLH-500", "$$hashKey": "object:31339" }, { "value": "91", "label": "S2GH-451X", "$$hashKey": "object:31340" }, { "value": "92", "label": "S3GHD-500X", "$$hashKey": "object:31341" }, { "value": "93", "label": "S3GHD-506X", "$$hashKey": "object:31342" }] }, "validate": { "required": true }, "$$hashKey": "object:30761" }, { "tableView": true, "label": "Gearbox Type", "key": "ddlGearboxTypeWinergyFlender", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "true", "when": "ddlGearboxManufacturer", "eq": "9" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "40", "label": "PEAB 4285", "$$hashKey": "object:31364" }, { "value": "41", "label": "PEAB 4320", "$$hashKey": "object:31365" }, { "value": "42", "label": "PEAB 4395", "$$hashKey": "object:31366" }, { "value": "43", "label": "PEAB 4420", "$$hashKey": "object:31367" }, { "value": "44", "label": "PEAB 4435", "$$hashKey": "object:31368" }, { "value": "45", "label": "PEAB 4460", "$$hashKey": "object:31369" }, { "value": "46", "label": "PEAB 4500", "$$hashKey": "object:31370" }, { "value": "214", "label": "PEAB_4440", "$$hashKey": "object:31371" }, { "value": "47", "label": "PEAC 4280", "$$hashKey": "object:31372" }, { "value": "48", "label": "PEAC 4300", "$$hashKey": "object:31373" }, { "value": "49", "label": "PEAC 4355", "$$hashKey": "object:31374" }, { "value": "50", "label": "PEAC 4455", "$$hashKey": "object:31375" }, { "value": "51", "label": "PEAK 4224", "$$hashKey": "object:31376" }, { "value": "52", "label": "PEAK 4280", "$$hashKey": "object:31377" }, { "value": "53", "label": "PEAK 4300", "$$hashKey": "object:31378" }, { "value": "54", "label": "PEAK 4355", "$$hashKey": "object:31379" }, { "value": "55", "label": "PEAL 4290", "$$hashKey": "object:31380" }, { "value": "56", "label": "PEAS 4285 ", "$$hashKey": "object:31381" }, { "value": "57", "label": "PEAS 4290", "$$hashKey": "object:31382" }, { "value": "58", "label": "PEAS 4300", "$$hashKey": "object:31383" }, { "value": "59", "label": "PEAS 4355", "$$hashKey": "object:31384" }, { "value": "60", "label": "PEAS 4390", "$$hashKey": "object:31385" }, { "value": "61", "label": "PEAS 4395", "$$hashKey": "object:31386" }, { "value": "62", "label": "PEAS 4460", "$$hashKey": "object:31387" }, { "value": "208", "label": "PZAB 3530", "$$hashKey": "object:31388" }, { "value": "89", "label": "PZAB 3620", "$$hashKey": "object:31389" }, { "value": "94", "label": "SDAK 2555", "$$hashKey": "object:31390" }, { "value": "95", "label": "SOND 2410", "$$hashKey": "object:31391" }, { "value": "96", "label": "SZAK 2410", "$$hashKey": "object:31392" }, { "value": "97", "label": "SZAK 2425", "$$hashKey": "object:31393" }] }, "lockKey": true, "validate": { "required": true }, "$$hashKey": "object:30762" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Other Gearbox Type", "key": "txtOtherGearboxType", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": true, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:30763" }, { "tableView": true, "label": "Gearbox Revision", "key": "ddlGearboxGRevision", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "24", "label": "N/A", "$$hashKey": "object:31430" }, { "value": "1", "label": "1", "$$hashKey": "object:31431" }, { "value": "2", "label": "2", "$$hashKey": "object:31432" }, { "value": "3", "label": "3", "$$hashKey": "object:31433" }, { "value": "4", "label": "4", "$$hashKey": "object:31434" }, { "value": "5", "label": "5", "$$hashKey": "object:31435" }, { "value": "6", "label": "6", "$$hashKey": "object:31436" }, { "value": "7", "label": "7", "$$hashKey": "object:31437" }, { "value": "8", "label": "8", "$$hashKey": "object:31438" }, { "value": "9", "label": "9", "$$hashKey": "object:31439" }, { "value": "10", "label": "A", "$$hashKey": "object:31440" }, { "value": "11", "label": "B", "$$hashKey": "object:31441" }, { "value": "12", "label": "C", "$$hashKey": "object:31442" }, { "value": "25", "label": "CH", "$$hashKey": "object:31443" }, { "value": "13", "label": "D", "$$hashKey": "object:31444" }, { "value": "14", "label": "E", "$$hashKey": "object:31445" }, { "value": "15", "label": "F", "$$hashKey": "object:31446" }, { "value": "16", "label": "M", "$$hashKey": "object:31447" }, { "value": "17", "label": "non", "$$hashKey": "object:31448" }, { "value": "18", "label": "R", "$$hashKey": "object:31449" }, { "value": "19", "label": "R1", "$$hashKey": "object:31450" }, { "value": "20", "label": "R2", "$$hashKey": "object:31451" }, { "value": "21", "label": "R3", "$$hashKey": "object:31452" }, { "value": "22", "label": "R-EX", "$$hashKey": "object:31453" }, { "value": "23", "label": "RR", "$$hashKey": "object:31454" }] }, "lockKey": true, "validate": { "required": true }, "input": true, "$$hashKey": "object:30764" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Gearbox Serial Number", "key": "txtGearboxSerialNumber", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "$$hashKey": "object:639659", "tags": [], "properties": { "": "" }, "lockKey": true, "tooltip": "Hansen Transmissions:\nCan be a 6-digit number i.e. “236588” or an up to 21 character no.  i.e. “RW_EF901A-001L/LM0001”. “RW” is a prefix used when gears have been returned from Hansen Transmissions after repair. Metso/Valmet/Santasalo/Moventas:\nCan be 5- 8 digit number i.e. “J51236R1” “R1” is a suffix used by this supplier to indicate that this gear unit has been refurbished/repaired once.  \nWinergy/Flender:\nHas 16-18 characters i.e. 421.106.802–0010–1 or 4.803.487–0020–2\nLohmann/Rexroth:\nCan either be a 4 digit number i.e. “3928”, a 7 digit number i.e. “1027063” or a 11 digit number i.e. “10306083765”. However if a gearbox has been refurbished/repaired the serial number can have a suffix i.e. “R”, “RR”, or “REX”\nJahnel-Kestermann:\ns a 16 characters number i.e. “31.00.6259.01.03.” Exception: If the gearbox is refurbished/repaired a rep. number is added in front of the original s/n i.e. “30.02.7914.01/31.98.3813.02.07.”\nWind World: \nIs either a 3 or 4 digit number i.e. “948” or “1037”\nKumera:\nIs a 10 digit number i.e. “270690/97-4/1”" }, { "input": true, "tableView": true, "label": "Aux. equipment", "key": "ddlAuxEquipment", "placeholder": "", "data": { "values": [{ "value": "1", "label": "NO", "$$hashKey": "object:31486" }, { "value": "2", "label": "YES", "$$hashKey": "object:31487" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "1", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "tooltip": "Help for Aux. Equipment (failure reports only):\nSelect yes if the item is an aux. equipment mounted on the main component e.g :\n- torque arm\n- mech. Oil pump\n- brake\n\nSelect no if the item is e.g:\n-  bearings.", "$$hashKey": "object:30766" }, { "input": true, "tableView": true, "label": "Date For Last Oil Change", "key": "dtDateForLastOilChange", "placeholder": "Date For Last Oil Change", "format": "dd-MM-yyyy", "enableDate": true, "enableTime": false, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "custom": "" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "lockKey": true, "$$hashKey": "object:30767" }, { "tableView": true, "label": "Oil Type", "key": "ddlOilGearType", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "11", "label": "N/A", "$$hashKey": "object:31496" }, { "value": "1", "label": "Aral Degol BG 320+", "$$hashKey": "object:31497" }, { "value": "18", "label": "BASF Plurasafe GL Plus 320", "$$hashKey": "object:31498" }, { "value": "2", "label": "Castrol Alphasyn PG 320", "$$hashKey": "object:31499" }, { "value": "19", "label": "Castrol Optigear Synthetic CT 320", "$$hashKey": "object:31500" }, { "value": "12", "label": "Cognis Breox SL320", "$$hashKey": "object:31501" }, { "value": "21", "label": "Fuchs Gearmaster ECO 320", "$$hashKey": "object:31502" }, { "value": "20", "label": "Klübersynth GEM 4-320 N", "$$hashKey": "object:31503" }, { "value": "13", "label": "Mobil SHC Grease 460 WT", "$$hashKey": "object:31504" }, { "value": "3", "label": "Mobilgear SHC 320", "$$hashKey": "object:31505" }, { "value": "4", "label": "Mobilgear SHC XMP 320", "$$hashKey": "object:31506" }, { "value": "14", "label": "Mobilith SHC 460", "$$hashKey": "object:31507" }, { "value": "17", "label": "SKF LGWM1", "$$hashKey": "object:31508" }, { "value": "6", "label": "Texaco Meropa 320", "$$hashKey": "object:31509" }, { "value": "7", "label": "Texaco Pinnacle WM 320", "$$hashKey": "object:31510" }, { "value": "8", "label": "Tribol 1100/320", "$$hashKey": "object:31511" }, { "value": "9", "label": "Tribol 1510/320", "$$hashKey": "object:31512" }, { "value": "16", "label": "Tribol 1510/680", "$$hashKey": "object:31513" }, { "value": "10", "label": "Tribol 1710/320", "$$hashKey": "object:31514" }, { "value": "5", "label": "Other", "$$hashKey": "object:31515" }] }, "validate": { "required": true }, "input": true, "$$hashKey": "object:30768" }, { "tableView": true, "label": "Type of Mechanical Oil Pump", "key": "ddlTypeOfMechanicalOilPump", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "10", "label": "N/A", "$$hashKey": "object:31539" }, { "value": "1", "label": "Kracht KF2/50", "$$hashKey": "object:31540" }, { "value": "2", "label": "Kracht KF3/112", "$$hashKey": "object:31541" }, { "value": "3", "label": "Rickmeier R4,5/45 (external piping)", "$$hashKey": "object:31542" }, { "value": "4", "label": "Rickmeier R4,5/45 (integrated ports)", "$$hashKey": "object:31543" }, { "value": "11", "label": "SHW 109-F35011", "$$hashKey": "object:31544" }, { "value": "5", "label": "SHW 31 1059-175", "$$hashKey": "object:31545" }, { "value": "6", "label": "SHW 70 1004-353", "$$hashKey": "object:31546" }, { "value": "7", "label": "SHW 702417", "$$hashKey": "object:31547" }, { "value": "8", "label": "SHW48", "$$hashKey": "object:31548" }, { "value": "9", "label": "Tuthill", "$$hashKey": "object:31549" }] }, "validate": { "required": true }, "input": true, "$$hashKey": "object:30769" }, { "tableView": true, "label": "Oil Level in Gearbox (in %)", "key": "ddlOilLevelInGearbox", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "lockKey": true, "validate": { "required": true }, "data": { "values": [{ "value": "14", "label": "N/A", "$$hashKey": "object:31564" }, { "value": "13", "label": "Below Min.", "$$hashKey": "object:31565" }, { "value": "1", "label": "0% Min.", "$$hashKey": "object:31566" }, { "value": "2", "label": "10%", "$$hashKey": "object:31567" }, { "value": "4", "label": "20%", "$$hashKey": "object:31568" }, { "value": "5", "label": "30%", "$$hashKey": "object:31569" }, { "value": "6", "label": "40%", "$$hashKey": "object:31570" }, { "value": "7", "label": "50% Half.", "$$hashKey": "object:31571" }, { "value": "8", "label": "60%", "$$hashKey": "object:31572" }, { "value": "9", "label": "70%", "$$hashKey": "object:31573" }, { "value": "10", "label": "80%", "$$hashKey": "object:31574" }, { "value": "11", "label": "90%", "$$hashKey": "object:31575" }, { "value": "3", "label": "100% Max.", "$$hashKey": "object:31576" }, { "value": "12", "label": "Above Max.", "$$hashKey": "object:31577" }] }, "input": true, "$$hashKey": "object:30770" }, { "input": true, "tableView": true, "inputType": "number", "label": "Gearbox (hrs)", "key": "txtGearboxhrs", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:30771" }, { "input": true, "tableView": true, "inputType": "number", "label": "Oil Temperature at oil level check (ºC)", "key": "txtOilTemperatureatoillevelcheck", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": true, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:30772" }, { "input": true, "tableView": true, "inputType": "number", "label": "Gearbox Production (kWh)", "key": "txtGearboxProductionkWh", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:30773" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:30743" }, { "clearOnHide": false, "key": "page2Fieldset2", "input": false, "tableView": false, "legend": "Additional Gearbox Data", "components": [{ "tableView": true, "label": "Action performed on gearbox", "key": "ddlActionToBeTakenOnGearbox", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "validate": { "required": true }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "3", "label": "Endoscopic inspection", "$$hashKey": "object:31987" }, { "value": "4", "label": "Visual inspection", "$$hashKey": "object:31988" }] }, "input": true, "$$hashKey": "object:31870" }, { "clearOnHide": false, "key": "page2Fieldset2Panel", "input": false, "title": "Generator Manufacturer", "theme": "default", "tableView": false, "components": [{ "tableView": true, "label": "Generator Manufacturer", "key": "ddlGeneratorGManufacturer", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "8", "label": "N/A", "$$hashKey": "object:32087" }, { "value": "1", "label": "ABB", "$$hashKey": "object:32088" }, { "value": "2", "label": "ELIN", "$$hashKey": "object:32089" }, { "value": "3", "label": "Leroy Somer", "$$hashKey": "object:32090" }, { "value": "4", "label": "Loher/Winergy", "$$hashKey": "object:32091" }, { "value": "5", "label": "Other Manufacturer", "$$hashKey": "object:32092" }, { "value": "9", "label": "Vestas Spareparts/Repair", "$$hashKey": "object:32093" }, { "value": "7", "label": "Weier/VND", "$$hashKey": "object:32094" }] }, "$$hashKey": "object:31937" }, { "tableView": true, "label": "Second Generator Manufacturer", "key": "ddlSecondGeneratorGManufacturer", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "8", "label": "N/A", "$$hashKey": "object:32106" }, { "value": "1", "label": "ABB", "$$hashKey": "object:32107" }, { "value": "2", "label": "ELIN", "$$hashKey": "object:32108" }, { "value": "3", "label": "Leroy Somer", "$$hashKey": "object:32109" }, { "value": "4", "label": "Loher/Winergy", "$$hashKey": "object:32110" }, { "value": "5", "label": "Other Manufacturer", "$$hashKey": "object:32111" }, { "value": "9", "label": "Vestas Spareparts/Repair", "$$hashKey": "object:32112" }, { "value": "7", "label": "Weier/VND", "$$hashKey": "object:32113" }] }, "$$hashKey": "object:31938" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:31871" }, { "tableView": true, "label": "Electrical Pump", "key": "ddlElectricalPump", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "$$hashKey": "object:39565", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "10", "label": "N/A", "$$hashKey": "object:56695" }, { "value": "1", "label": "Oiltech ?? (screw pump)", "$$hashKey": "object:56696" }, { "value": "2", "label": "Oiltech CPM 30", "$$hashKey": "object:56697" }, { "value": "3", "label": "Oiltech CPM 60", "$$hashKey": "object:56698" }, { "value": "4", "label": "Oiltech QPM 40", "$$hashKey": "object:56699" }, { "value": "5", "label": "Seim PX40", "$$hashKey": "object:56700" }, { "value": "6", "label": "Seim PX45", "$$hashKey": "object:56701" }, { "value": "7", "label": "Seim PX55", "$$hashKey": "object:56702" }, { "value": "8", "label": "Settima S0", "$$hashKey": "object:56703" }, { "value": "9", "label": "Settima S4", "$$hashKey": "object:56704" }] }, "lockKey": true }, { "tableView": true, "label": "Shrink Element", "key": "ddlShrinkElement", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "$$hashKey": "object:57279", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "7", "label": "N/A", "$$hashKey": "object:74403" }, { "value": "1", "label": "Ringfeder (Mech.)", "$$hashKey": "object:74404" }, { "value": "2", "label": "Schäfer (Mech)", "$$hashKey": "object:74405" }, { "value": "3", "label": "SKF/OVACO (Hydr.)", "$$hashKey": "object:74406" }, { "value": "4", "label": "SKF/OVACO (Mech)", "$$hashKey": "object:74407" }, { "value": "5", "label": "Stüve (Hydr.)", "$$hashKey": "object:74408" }, { "value": "6", "label": "Stüve (Mech.)", "$$hashKey": "object:74409" }] }, "lockKey": true }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Serial Number of Shrink Element", "key": "txtSerialNumberofShrinkElement", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:31874", "isNew": false }, { "tableView": true, "label": "Coupling", "key": "ddlGearboxCoupling", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "8", "label": "N/A", "$$hashKey": "object:32016" }, { "value": "1", "label": "Ball Cardan", "$$hashKey": "object:32017" }, { "value": "2", "label": "Centalink", "$$hashKey": "object:32018" }, { "value": "3", "label": "Composite", "$$hashKey": "object:32019" }, { "value": "4", "label": "Cross Cardan", "$$hashKey": "object:32020" }, { "value": "5", "label": "Rubber (Centaflex)", "$$hashKey": "object:32021" }, { "value": "6", "label": "Vestas Composite", "$$hashKey": "object:32022" }, { "value": "7", "label": "Zero Max", "$$hashKey": "object:32023" }] }, "input": true, "$$hashKey": "object:31875" }, { "tableView": true, "label": "Filter Block Type", "key": "ddlFilterBlockType", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "10", "label": "N/A", "$$hashKey": "object:32035" }, { "value": "1", "label": "HG426", "$$hashKey": "object:32036" }, { "value": "2", "label": "HG617", "$$hashKey": "object:32037" }, { "value": "3", "label": "HG617+HG833", "$$hashKey": "object:32038" }, { "value": "4", "label": "HG645", "$$hashKey": "object:32039" }, { "value": "5", "label": "HG645+HG935+IMF(S412)", "$$hashKey": "object:32040" }, { "value": "6", "label": "HG674", "$$hashKey": "object:32041" }, { "value": "7", "label": "HG732", "$$hashKey": "object:32042" }, { "value": "8", "label": "HG772", "$$hashKey": "object:32043" }, { "value": "9", "label": "HG772+IMF(S412)", "$$hashKey": "object:32044" }] }, "input": true, "$$hashKey": "object:31876" }, { "tableView": true, "label": "In-line Filter", "key": "ddlInlineFilter", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "6", "label": "N/A", "$$hashKey": "object:32058" }, { "value": "1", "label": "HC 35 Mahle 10µm", "$$hashKey": "object:32059" }, { "value": "5", "label": "Hydac", "$$hashKey": "object:32060" }, { "value": "3", "label": "NG 1000 Mahle 10µm", "$$hashKey": "object:32061" }, { "value": "4", "label": "NG 1000 Mahle 25µm", "$$hashKey": "object:32062" }, { "value": "2", "label": "NG 1000 Mahle 6µm", "$$hashKey": "object:32063" }] }, "input": true, "$$hashKey": "object:31877" }, { "input": true, "tableView": true, "label": "Off-line Filter", "key": "ddlOfflineFilter", "placeholder": "", "data": { "values": [{ "value": "1", "label": "NO", "$$hashKey": "object:32073" }, { "value": "2", "label": "YES", "$$hashKey": "object:32074" }, { "value": "", "label": "", "$$hashKey": "object:32075" }], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "1", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:31878" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "Software Release", "key": "txtSoftwareRelease", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:31879" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:31859" }, { "clearOnHide": false, "key": "page2Fieldset3", "input": false, "tableView": false, "legend": "Clearly Identified Damages", "components": [{ "clearOnHide": false, "key": "page2Panel6", "input": false, "title": "Shafts", "theme": "default", "tableView": false, "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page2Fieldset3Columns7", "columns": [{ "components": [{ "tableView": true, "label": "Exact Location", "key": "ddlGearboxShaftsExactLocation1ShaftTypeId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:35196" }, { "value": "1", "label": "Auxilliary High Speed Shaft", "$$hashKey": "object:35197" }, { "value": "2", "label": "High speed shaft", "$$hashKey": "object:35198" }, { "value": "4", "label": "Hollow Shaft", "$$hashKey": "object:35199" }, { "value": "6", "label": "Input Shaft", "$$hashKey": "object:35200" }, { "value": "7", "label": "Intermediate speed planet carrier", "$$hashKey": "object:35201" }, { "value": "5", "label": "Intermediate speed shaft", "$$hashKey": "object:35202" }, { "value": "9", "label": "Low speed planet carrier", "$$hashKey": "object:35203" }, { "value": "10", "label": "Low speed shaft", "$$hashKey": "object:35204" }, { "value": "14", "label": "Planet Pin ", "$$hashKey": "object:35205" }, { "value": "16", "label": "Sun Shaft", "$$hashKey": "object:35206" }, { "value": "3", "label": "HSIM (High speed intermediate shaft)", "$$hashKey": "object:35207" }, { "value": "8", "label": "LLSIM (Lower low speed intermediate shaft)", "$$hashKey": "object:35208" }, { "value": "11", "label": "LSIM (Low speed intermediate shaft)", "$$hashKey": "object:35209" }, { "value": "12", "label": "Pitch tube", "$$hashKey": "object:35210" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35211" }, { "value": "15", "label": "Power Take Off", "$$hashKey": "object:35212" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:35213" }] }, "input": true, "$$hashKey": "object:33299" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsExactLocation2ShaftTypeId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:35235" }, { "value": "1", "label": "Auxilliary High Speed Shaft", "$$hashKey": "object:35236" }, { "value": "2", "label": "High speed shaft", "$$hashKey": "object:35237" }, { "value": "4", "label": "Hollow Shaft", "$$hashKey": "object:35238" }, { "value": "6", "label": "Input Shaft", "$$hashKey": "object:35239" }, { "value": "7", "label": "Intermediate speed planet carrier", "$$hashKey": "object:35240" }, { "value": "5", "label": "Intermediate speed shaft", "$$hashKey": "object:35241" }, { "value": "9", "label": "Low speed planet carrier", "$$hashKey": "object:35242" }, { "value": "10", "label": "Low speed shaft", "$$hashKey": "object:35243" }, { "value": "14", "label": "Planet Pin ", "$$hashKey": "object:35244" }, { "value": "16", "label": "Sun Shaft", "$$hashKey": "object:35245" }, { "value": "3", "label": "HSIM (High speed intermediate shaft)", "$$hashKey": "object:35246" }, { "value": "8", "label": "LLSIM (Lower low speed intermediate shaft)", "$$hashKey": "object:35247" }, { "value": "11", "label": "LSIM (Low speed intermediate shaft)", "$$hashKey": "object:35248" }, { "value": "12", "label": "Pitch tube", "$$hashKey": "object:35249" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35250" }, { "value": "15", "label": "Power Take Off", "$$hashKey": "object:35251" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:35252" }] }, "input": true, "$$hashKey": "object:33300" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsExactLocation3ShaftTypeId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:35274" }, { "value": "1", "label": "Auxilliary High Speed Shaft", "$$hashKey": "object:35275" }, { "value": "2", "label": "High speed shaft", "$$hashKey": "object:35276" }, { "value": "4", "label": "Hollow Shaft", "$$hashKey": "object:35277" }, { "value": "6", "label": "Input Shaft", "$$hashKey": "object:35278" }, { "value": "7", "label": "Intermediate speed planet carrier", "$$hashKey": "object:35279" }, { "value": "5", "label": "Intermediate speed shaft", "$$hashKey": "object:35280" }, { "value": "9", "label": "Low speed planet carrier", "$$hashKey": "object:35281" }, { "value": "10", "label": "Low speed shaft", "$$hashKey": "object:35282" }, { "value": "14", "label": "Planet Pin ", "$$hashKey": "object:35283" }, { "value": "16", "label": "Sun Shaft", "$$hashKey": "object:35284" }, { "value": "3", "label": "HSIM (High speed intermediate shaft)", "$$hashKey": "object:35285" }, { "value": "8", "label": "LLSIM (Lower low speed intermediate shaft)", "$$hashKey": "object:35286" }, { "value": "11", "label": "LSIM (Low speed intermediate shaft)", "$$hashKey": "object:35287" }, { "value": "12", "label": "Pitch tube", "$$hashKey": "object:35288" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35289" }, { "value": "15", "label": "Power Take Off", "$$hashKey": "object:35290" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:35291" }] }, "input": true, "$$hashKey": "object:33301" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsExactLocation4ShaftTypeId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:35313" }, { "value": "1", "label": "Auxilliary High Speed Shaft", "$$hashKey": "object:35314" }, { "value": "2", "label": "High speed shaft", "$$hashKey": "object:35315" }, { "value": "4", "label": "Hollow Shaft", "$$hashKey": "object:35316" }, { "value": "6", "label": "Input Shaft", "$$hashKey": "object:35317" }, { "value": "7", "label": "Intermediate speed planet carrier", "$$hashKey": "object:35318" }, { "value": "5", "label": "Intermediate speed shaft", "$$hashKey": "object:35319" }, { "value": "9", "label": "Low speed planet carrier", "$$hashKey": "object:35320" }, { "value": "10", "label": "Low speed shaft", "$$hashKey": "object:35321" }, { "value": "14", "label": "Planet Pin ", "$$hashKey": "object:35322" }, { "value": "16", "label": "Sun Shaft", "$$hashKey": "object:35323" }, { "value": "3", "label": "HSIM (High speed intermediate shaft)", "$$hashKey": "object:35324" }, { "value": "8", "label": "LLSIM (Lower low speed intermediate shaft)", "$$hashKey": "object:35325" }, { "value": "11", "label": "LSIM (Low speed intermediate shaft)", "$$hashKey": "object:35326" }, { "value": "12", "label": "Pitch tube", "$$hashKey": "object:35327" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35328" }, { "value": "15", "label": "Power Take Off", "$$hashKey": "object:35329" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:35330" }] }, "input": true, "$$hashKey": "object:33302" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsExactLocation5ShaftTypeId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:35352" }, { "value": "1", "label": "Auxilliary High Speed Shaft", "$$hashKey": "object:35353" }, { "value": "2", "label": "High speed shaft", "$$hashKey": "object:35354" }, { "value": "4", "label": "Hollow Shaft", "$$hashKey": "object:35355" }, { "value": "6", "label": "Input Shaft", "$$hashKey": "object:35356" }, { "value": "7", "label": "Intermediate speed planet carrier", "$$hashKey": "object:35357" }, { "value": "5", "label": "Intermediate speed shaft", "$$hashKey": "object:35358" }, { "value": "9", "label": "Low speed planet carrier", "$$hashKey": "object:35359" }, { "value": "10", "label": "Low speed shaft", "$$hashKey": "object:35360" }, { "value": "14", "label": "Planet Pin ", "$$hashKey": "object:35361" }, { "value": "16", "label": "Sun Shaft", "$$hashKey": "object:35362" }, { "value": "3", "label": "HSIM (High speed intermediate shaft)", "$$hashKey": "object:35363" }, { "value": "8", "label": "LLSIM (Lower low speed intermediate shaft)", "$$hashKey": "object:35364" }, { "value": "11", "label": "LSIM (Low speed intermediate shaft)", "$$hashKey": "object:35365" }, { "value": "12", "label": "Pitch tube", "$$hashKey": "object:35366" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35367" }, { "value": "15", "label": "Power Take Off", "$$hashKey": "object:35368" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:35369" }] }, "input": true, "$$hashKey": "object:33303" }], "width": 7, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:32697" }, { "components": [{ "tableView": true, "label": "Type of Damage", "key": "ddlGearboxShaftsTypeofDamage1ShaftErrorId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:35391" }, { "value": "1", "label": "Broken", "$$hashKey": "object:35392" }, { "value": "2", "label": "Corroded", "$$hashKey": "object:35393" }, { "value": "3", "label": "Cracks", "$$hashKey": "object:35394" }] }, "input": true, "$$hashKey": "object:33319" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsTypeofDamage2ShaftErrorId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:35402" }, { "value": "1", "label": "Broken", "$$hashKey": "object:35403" }, { "value": "2", "label": "Corroded", "$$hashKey": "object:35404" }, { "value": "3", "label": "Cracks", "$$hashKey": "object:35405" }] }, "input": true, "$$hashKey": "object:33320" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsTypeofDamage3ShaftErrorId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:35413" }, { "value": "1", "label": "Broken", "$$hashKey": "object:35414" }, { "value": "2", "label": "Corroded", "$$hashKey": "object:35415" }, { "value": "3", "label": "Cracks", "$$hashKey": "object:35416" }] }, "input": true, "$$hashKey": "object:33321" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsTypeofDamage4ShaftErrorId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:35424" }, { "value": "1", "label": "Broken", "$$hashKey": "object:35425" }, { "value": "2", "label": "Corroded", "$$hashKey": "object:35426" }, { "value": "3", "label": "Cracks", "$$hashKey": "object:35427" }] }, "input": true, "$$hashKey": "object:33322" }, { "tableView": true, "label": "", "key": "ddlGearboxShaftsTypeofDamage5ShaftErrorId", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:35435" }, { "value": "1", "label": "Broken", "$$hashKey": "object:35436" }, { "value": "2", "label": "Corroded", "$$hashKey": "object:35437" }, { "value": "3", "label": "Cracks", "$$hashKey": "object:35438" }] }, "input": true, "$$hashKey": "object:33323" }], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:32698" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32406" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:32391" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "page2Fieldset3Columns2", "columns": [{ "components": [], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:32411" }, { "components": [{ "key": "page2Fieldset3Columns2Html", "input": false, "tag": "header", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Gears defect", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:32708" }], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:32412" }, { "components": [], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:32413" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:32392" }, { "clearOnHide": false, "input": false, "key": "page2Fieldset3Table", "numRows": 16, "numCols": 5, "rows": [[{ "components": [], "$$hashKey": "object:32450" }, { "components": [{ "key": "page2Fieldset3Columns3Html", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Exact Location", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32717" }], "$$hashKey": "object:32451" }, { "components": [{ "key": "page2Fieldset3Columns3Html2", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Type of Damage", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32721" }], "$$hashKey": "object:32452" }, { "components": [{ "key": "page2Fieldset3Columns3Html3", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Damage Class", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32725" }], "$$hashKey": "object:32453" }, { "components": [{ "key": "page2Fieldset3Columns3Html4", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Decision", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32729" }], "$$hashKey": "object:32454" }], [{ "components": [{ "key": "html1", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "1", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32733" }], "$$hashKey": "object:32460" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:37424" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:37425" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:37426" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:37427" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:37428" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:37429" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:37430" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:37431" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:37432" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:37433" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:37434" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:37435" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:37436" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:37437" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:37438" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:37439" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:37440" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:37441" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:37442" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:37443" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:37444" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:37445" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:37446" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:37447" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:37448" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:37449" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:37450" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:37451" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:37452" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:37453" }] }, "input": true, "$$hashKey": "object:32737", "isNew": false }], "$$hashKey": "object:32461" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:33752" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:33753" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:33754" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:33755" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:33756" }, { "value": "6", "label": "Other", "$$hashKey": "object:33757" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:33758" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:33759" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:33760" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:33761" }, { "value": "17", "label": "N/A", "$$hashKey": "object:33762" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation1;", "$$hashKey": "object:32741" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty1", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation1;", "$$hashKey": "object:32742" }], "$$hashKey": "object:32462" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage1]" }, "refreshOn": "ddlTypeIfDamage1", "clearOnRefresh": true, "$$hashKey": "object:32749", "isNew": false }], "$$hashKey": "object:32463" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision1", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage1 && \n                             element[1] == data.ddlDamageClass1.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32753" }], "$$hashKey": "object:32464" }], [{ "components": [{ "key": "html2", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "2", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32757" }], "$$hashKey": "object:32470" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:33789" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:33790" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:33791" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:33792" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:33793" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:33794" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:33795" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:33796" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:33797" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:33798" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:33799" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:33800" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:33801" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:33802" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:33803" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:33804" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:33805" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:33806" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:33807" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:33808" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:33809" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:33810" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:33811" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:33812" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:33813" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:33814" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:33815" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:33816" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:33817" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:33818" }] }, "input": true, "$$hashKey": "object:32761" }], "$$hashKey": "object:32471" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:33852" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:33853" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:33854" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:33855" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:33856" }, { "value": "6", "label": "Other", "$$hashKey": "object:33857" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:33858" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:33859" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:33860" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:33861" }, { "value": "17", "label": "N/A", "$$hashKey": "object:33862" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation2;", "$$hashKey": "object:32765" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty2", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation2;", "$$hashKey": "object:32766" }], "$$hashKey": "object:32472" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage2]" }, "refreshOn": "ddlTypeIfDamage2", "clearOnRefresh": true, "$$hashKey": "object:32773" }], "$$hashKey": "object:32473" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision2", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage2 && \n                             element[1] == data.ddlDamageClass2.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32777" }], "$$hashKey": "object:32474" }], [{ "components": [{ "key": "html3", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "3", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32781" }], "$$hashKey": "object:32480" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:33889" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:33890" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:33891" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:33892" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:33893" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:33894" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:33895" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:33896" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:33897" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:33898" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:33899" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:33900" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:33901" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:33902" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:33903" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:33904" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:33905" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:33906" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:33907" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:33908" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:33909" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:33910" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:33911" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:33912" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:33913" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:33914" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:33915" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:33916" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:33917" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:33918" }] }, "input": true, "$$hashKey": "object:32785" }], "$$hashKey": "object:32481" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:33952" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:33953" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:33954" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:33955" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:33956" }, { "value": "6", "label": "Other", "$$hashKey": "object:33957" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:33958" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:33959" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:33960" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:33961" }, { "value": "17", "label": "N/A", "$$hashKey": "object:33962" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation3;", "$$hashKey": "object:32789" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty3", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation3;", "$$hashKey": "object:32790" }], "$$hashKey": "object:32482" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage3]" }, "refreshOn": "ddlTypeIfDamage3", "clearOnRefresh": true, "$$hashKey": "object:32797" }], "$$hashKey": "object:32483" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision3", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage3 && \n                             element[1] == data.ddlDamageClass3.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32801" }], "$$hashKey": "object:32484" }], [{ "components": [{ "key": "html4", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "4", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32805" }], "$$hashKey": "object:32490" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:33989" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:33990" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:33991" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:33992" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:33993" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:33994" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:33995" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:33996" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:33997" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:33998" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:33999" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34000" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34001" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34002" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34003" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34004" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34005" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34006" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34007" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34008" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34009" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34010" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34011" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34012" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34013" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34014" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34015" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34016" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34017" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34018" }] }, "input": true, "$$hashKey": "object:32809" }], "$$hashKey": "object:32491" }, { "components": [{ "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty4", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation4;", "$$hashKey": "object:32813" }, { "tableView": true, "label": "", "key": "ddlTypeIfDamage4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34055" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34056" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34057" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34058" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34059" }, { "value": "6", "label": "Other", "$$hashKey": "object:34060" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34061" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34062" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34063" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34064" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34065" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation4;", "$$hashKey": "object:32814" }], "$$hashKey": "object:32492" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage4]" }, "refreshOn": "ddlTypeIfDamage4", "clearOnRefresh": true, "$$hashKey": "object:32821" }], "$$hashKey": "object:32493" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision4", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage4 && \n                             element[1] == data.ddlDamageClass4.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32825" }], "$$hashKey": "object:32494" }], [{ "components": [{ "key": "html5", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "5", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32829" }], "$$hashKey": "object:32500" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34089" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34090" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34091" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34092" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34093" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34094" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34095" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34096" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34097" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34098" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34099" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34100" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34101" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34102" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34103" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34104" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34105" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34106" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34107" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34108" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34109" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34110" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34111" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34112" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34113" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34114" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34115" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34116" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34117" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34118" }] }, "input": true, "$$hashKey": "object:32833" }], "$$hashKey": "object:32501" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34152" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34153" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34154" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34155" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34156" }, { "value": "6", "label": "Other", "$$hashKey": "object:34157" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34158" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34159" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34160" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34161" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34162" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation5;", "$$hashKey": "object:32837" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty5", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation5;", "$$hashKey": "object:32838" }], "$$hashKey": "object:32502" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage5]" }, "refreshOn": "ddlTypeIfDamage5", "clearOnRefresh": true, "$$hashKey": "object:32845" }], "$$hashKey": "object:32503" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision5", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage5 && \n                             element[1] == data.ddlDamageClass5.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32849" }], "$$hashKey": "object:32504" }], [{ "components": [{ "key": "html6", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "6", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32853" }], "$$hashKey": "object:32510" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34189" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34190" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34191" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34192" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34193" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34194" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34195" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34196" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34197" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34198" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34199" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34200" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34201" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34202" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34203" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34204" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34205" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34206" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34207" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34208" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34209" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34210" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34211" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34212" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34213" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34214" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34215" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34216" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34217" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34218" }] }, "input": true, "$$hashKey": "object:32857" }], "$$hashKey": "object:32511" }, { "components": [{ "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty6", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation6;", "$$hashKey": "object:32861" }, { "tableView": true, "label": "", "key": "ddlTypeIfDamage6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34255" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34256" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34257" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34258" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34259" }, { "value": "6", "label": "Other", "$$hashKey": "object:34260" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34261" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34262" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34263" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34264" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34265" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation6;", "$$hashKey": "object:32862" }], "$$hashKey": "object:32512" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage6]" }, "refreshOn": "ddlTypeIfDamage6", "clearOnRefresh": true, "$$hashKey": "object:32869" }], "$$hashKey": "object:32513" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision6", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage6 && \n                             element[1] == data.ddlDamageClass6.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32873" }], "$$hashKey": "object:32514" }], [{ "components": [{ "key": "html7", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "7", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32877" }], "$$hashKey": "object:32520" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation7", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34289" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34290" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34291" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34292" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34293" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34294" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34295" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34296" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34297" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34298" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34299" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34300" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34301" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34302" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34303" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34304" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34305" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34306" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34307" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34308" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34309" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34310" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34311" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34312" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34313" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34314" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34315" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34316" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34317" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34318" }] }, "input": true, "$$hashKey": "object:32881" }], "$$hashKey": "object:32521" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage7", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34352" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34353" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34354" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34355" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34356" }, { "value": "6", "label": "Other", "$$hashKey": "object:34357" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34358" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34359" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34360" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34361" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34362" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation7;", "$$hashKey": "object:32885" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty7", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation7;", "$$hashKey": "object:32886" }], "$$hashKey": "object:32522" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass7", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage7]" }, "refreshOn": "ddlTypeIfDamage7", "clearOnRefresh": true, "$$hashKey": "object:32893" }], "$$hashKey": "object:32523" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision7", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage7 && \n                             element[1] == data.ddlDamageClass7.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32897" }], "$$hashKey": "object:32524" }], [{ "components": [{ "key": "html8", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "8", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32901" }], "$$hashKey": "object:32530" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation8", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34389" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34390" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34391" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34392" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34393" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34394" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34395" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34396" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34397" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34398" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34399" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34400" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34401" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34402" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34403" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34404" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34405" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34406" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34407" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34408" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34409" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34410" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34411" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34412" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34413" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34414" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34415" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34416" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34417" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34418" }] }, "input": true, "$$hashKey": "object:32905" }], "$$hashKey": "object:32531" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage8", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34452" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34453" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34454" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34455" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34456" }, { "value": "6", "label": "Other", "$$hashKey": "object:34457" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34458" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34459" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34460" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34461" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34462" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation8;", "$$hashKey": "object:32909" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty8", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation8;", "$$hashKey": "object:32910" }], "$$hashKey": "object:32532" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass8", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage8]" }, "refreshOn": "ddlTypeIfDamage8", "clearOnRefresh": true, "$$hashKey": "object:32917" }], "$$hashKey": "object:32533" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision8", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage8 && \n                             element[1] == data.ddlDamageClass8.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32921" }], "$$hashKey": "object:32534" }], [{ "components": [{ "key": "html9", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "9", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32925" }], "$$hashKey": "object:32540" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation9", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34489" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34490" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34491" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34492" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34493" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34494" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34495" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34496" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34497" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34498" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34499" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34500" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34501" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34502" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34503" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34504" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34505" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34506" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34507" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34508" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34509" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34510" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34511" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34512" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34513" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34514" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34515" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34516" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34517" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34518" }] }, "input": true, "$$hashKey": "object:32929" }], "$$hashKey": "object:32541" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage9", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34552" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34553" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34554" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34555" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34556" }, { "value": "6", "label": "Other", "$$hashKey": "object:34557" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34558" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34559" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34560" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34561" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34562" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation9;", "$$hashKey": "object:32933" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty9", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation9;", "$$hashKey": "object:32934" }], "$$hashKey": "object:32542" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass9", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage9]" }, "refreshOn": "ddlTypeIfDamage9", "clearOnRefresh": true, "$$hashKey": "object:32941" }], "$$hashKey": "object:32543" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision9", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage9 && \n                             element[1] == data.ddlDamageClass9.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32945" }], "$$hashKey": "object:32544" }], [{ "components": [{ "key": "html10", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "10", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32949" }], "$$hashKey": "object:32550" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation10", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34589" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34590" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34591" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34592" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34593" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34594" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34595" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34596" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34597" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34598" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34599" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34600" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34601" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34602" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34603" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34604" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34605" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34606" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34607" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34608" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34609" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34610" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34611" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34612" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34613" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34614" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34615" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34616" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34617" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34618" }] }, "input": true, "$$hashKey": "object:32953" }], "$$hashKey": "object:32551" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage10", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34652" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34653" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34654" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34655" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34656" }, { "value": "6", "label": "Other", "$$hashKey": "object:34657" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34658" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34659" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34660" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34661" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34662" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation10;", "$$hashKey": "object:32957" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty10", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation10;", "$$hashKey": "object:32958" }], "$$hashKey": "object:32552" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass10", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage10]" }, "refreshOn": "ddlTypeIfDamage10", "clearOnRefresh": true, "$$hashKey": "object:32965" }], "$$hashKey": "object:32553" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision10", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage10 && \n                             element[1] == data.ddlDamageClass10.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32969" }], "$$hashKey": "object:32554" }], [{ "components": [{ "key": "html11", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "11", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32973" }], "$$hashKey": "object:32560" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation11", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34689" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34690" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34691" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34692" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34693" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34694" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34695" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34696" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34697" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34698" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34699" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34700" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34701" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34702" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34703" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34704" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34705" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34706" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34707" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34708" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34709" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34710" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34711" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34712" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34713" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34714" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34715" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34716" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34717" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34718" }] }, "input": true, "$$hashKey": "object:32977" }], "$$hashKey": "object:32561" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage11", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34752" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34753" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34754" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34755" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34756" }, { "value": "6", "label": "Other", "$$hashKey": "object:34757" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34758" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34759" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34760" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34761" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34762" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation11;", "$$hashKey": "object:32981" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty11", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation11;", "$$hashKey": "object:32982" }], "$$hashKey": "object:32562" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass11", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage11]" }, "refreshOn": "ddlTypeIfDamage11", "clearOnRefresh": true, "$$hashKey": "object:32989" }], "$$hashKey": "object:32563" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision11", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage11 && \n                             element[1] == data.ddlDamageClass11.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:32993" }], "$$hashKey": "object:32564" }], [{ "components": [{ "key": "html12", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "12", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32997" }], "$$hashKey": "object:32570" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation12", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34789" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34790" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34791" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34792" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34793" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34794" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34795" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34796" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34797" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34798" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34799" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34800" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34801" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34802" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34803" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34804" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34805" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34806" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34807" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34808" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34809" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34810" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34811" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34812" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34813" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34814" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34815" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34816" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34817" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34818" }] }, "input": true, "$$hashKey": "object:33001" }], "$$hashKey": "object:32571" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage12", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34852" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34853" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34854" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34855" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34856" }, { "value": "6", "label": "Other", "$$hashKey": "object:34857" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34858" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34859" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34860" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34861" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34862" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation12;", "$$hashKey": "object:33005" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty12", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation12;", "$$hashKey": "object:33006" }], "$$hashKey": "object:32572" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass12", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage12]" }, "refreshOn": "ddlTypeIfDamage12", "clearOnRefresh": true, "$$hashKey": "object:33013" }], "$$hashKey": "object:32573" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision12", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage12 && \n                             element[1] == data.ddlDamageClass12.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:33017" }], "$$hashKey": "object:32574" }], [{ "components": [{ "key": "html13", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "13", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:33021" }], "$$hashKey": "object:32580" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation13", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34889" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34890" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34891" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34892" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34893" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34894" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34895" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34896" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34897" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34898" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34899" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:34900" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:34901" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:34902" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:34903" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:34904" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:34905" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:34906" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:34907" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:34908" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:34909" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:34910" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:34911" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:34912" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:34913" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:34914" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:34915" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:34916" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:34917" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:34918" }] }, "input": true, "$$hashKey": "object:33025" }], "$$hashKey": "object:32581" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage13", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:34952" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:34953" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:34954" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:34955" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:34956" }, { "value": "6", "label": "Other", "$$hashKey": "object:34957" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:34958" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:34959" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:34960" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:34961" }, { "value": "17", "label": "N/A", "$$hashKey": "object:34962" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation13;", "$$hashKey": "object:33029" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty13", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation13;", "$$hashKey": "object:33030" }], "$$hashKey": "object:32582" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass13", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage13]" }, "refreshOn": "ddlTypeIfDamage13", "clearOnRefresh": true, "$$hashKey": "object:33037" }], "$$hashKey": "object:32583" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision13", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage13 && \n                             element[1] == data.ddlDamageClass13.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:33041" }], "$$hashKey": "object:32584" }], [{ "components": [{ "key": "html14", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "14", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:33045" }], "$$hashKey": "object:32590" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation14", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:34989" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:34990" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:34991" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:34992" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:34993" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:34994" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:34995" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:34996" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:34997" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:34998" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:34999" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:35000" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:35001" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:35002" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:35003" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:35004" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:35005" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:35006" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:35007" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:35008" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:35009" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:35010" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:35011" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:35012" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35013" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:35014" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:35015" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:35016" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:35017" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:35018" }] }, "input": true, "$$hashKey": "object:33049" }], "$$hashKey": "object:32591" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage14", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:35052" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:35053" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:35054" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:35055" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:35056" }, { "value": "6", "label": "Other", "$$hashKey": "object:35057" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:35058" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:35059" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:35060" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:35061" }, { "value": "17", "label": "N/A", "$$hashKey": "object:35062" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation14;", "$$hashKey": "object:33053" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty14", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation14;", "$$hashKey": "object:33054" }], "$$hashKey": "object:32592" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass14", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage14]" }, "refreshOn": "ddlTypeIfDamage14", "clearOnRefresh": true, "$$hashKey": "object:33061" }], "$$hashKey": "object:32593" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision14", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage14 && \n                             element[1] == data.ddlDamageClass14.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:33065" }], "$$hashKey": "object:32594" }], [{ "components": [{ "key": "html15", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "15", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:33069" }], "$$hashKey": "object:32600" }, { "components": [{ "tableView": true, "label": "", "key": "ddlExactLocation15", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "20", "label": "Not inspected", "$$hashKey": "object:35089" }, { "value": "1", "label": "Annulus Gear (Ring gear)", "$$hashKey": "object:35090" }, { "value": "24", "label": "Annulus Gear (Ring gear) STG2", "$$hashKey": "object:35091" }, { "value": "31", "label": "Auxilliary High Speed Gear Wheel", "$$hashKey": "object:35092" }, { "value": "30", "label": "High Speed Gear Wheel", "$$hashKey": "object:35093" }, { "value": "6", "label": "High Speed Pinion", "$$hashKey": "object:35094" }, { "value": "8", "label": "Intermediate Speed Gear Wheel", "$$hashKey": "object:35095" }, { "value": "9", "label": "Intermediate Speed Pinion", "$$hashKey": "object:35096" }, { "value": "12", "label": "Low Speed Gear Wheel", "$$hashKey": "object:35097" }, { "value": "21", "label": "Planet Gear Wheel 1", "$$hashKey": "object:35098" }, { "value": "25", "label": "Planet Gear Wheel 1 STG2", "$$hashKey": "object:35099" }, { "value": "22", "label": "Planet Gear Wheel 2", "$$hashKey": "object:35100" }, { "value": "26", "label": "Planet Gear Wheel 2 STG2", "$$hashKey": "object:35101" }, { "value": "23", "label": "Planet Gear Wheel 3", "$$hashKey": "object:35102" }, { "value": "28", "label": "Planet Gear Wheel 3 STG2", "$$hashKey": "object:35103" }, { "value": "11", "label": "Sun Pinion", "$$hashKey": "object:35104" }, { "value": "29", "label": "Sun Pinion STG2", "$$hashKey": "object:35105" }, { "value": "2", "label": "Auxilliary High Speed Gear", "$$hashKey": "object:35106" }, { "value": "10", "label": "High Speed Shaft Gear", "$$hashKey": "object:35107" }, { "value": "5", "label": "Hollow Shaft", "$$hashKey": "object:35108" }, { "value": "4", "label": "Hollow Shaft Gear", "$$hashKey": "object:35109" }, { "value": "3", "label": "HS Gear", "$$hashKey": "object:35110" }, { "value": "7", "label": "Idler Gear", "$$hashKey": "object:35111" }, { "value": "14", "label": "LS Intermediate Pinion", "$$hashKey": "object:35112" }, { "value": "13", "label": "Planet Carrier", "$$hashKey": "object:35113" }, { "value": "15", "label": "Planet Gear Wheel", "$$hashKey": "object:35114" }, { "value": "16", "label": "Power Take Off Gear", "$$hashKey": "object:35115" }, { "value": "17", "label": "Sun Gear", "$$hashKey": "object:35116" }, { "value": "18", "label": "ULS Intermediate Gear", "$$hashKey": "object:35117" }, { "value": "19", "label": "ULS Intermediate Pinion", "$$hashKey": "object:35118" }] }, "input": true, "$$hashKey": "object:33073" }], "$$hashKey": "object:32601" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeIfDamage15", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "Abrasion", "$$hashKey": "object:35152" }, { "value": "2", "label": "Corrosion", "$$hashKey": "object:35153" }, { "value": "3", "label": "Tooth cracks and fractures", "$$hashKey": "object:35154" }, { "value": "4", "label": "Polishing", "$$hashKey": "object:35155" }, { "value": "5", "label": "Debris Indentations", "$$hashKey": "object:35156" }, { "value": "6", "label": "Other", "$$hashKey": "object:35157" }, { "value": "8", "label": "Micropitting", "$$hashKey": "object:35158" }, { "value": "13", "label": "Spalling and (macro-)pitting", "$$hashKey": "object:35159" }, { "value": "14", "label": "Standstill Marks", "$$hashKey": "object:35160" }, { "value": "15", "label": "No Damage", "$$hashKey": "object:35161" }, { "value": "17", "label": "N/A", "$$hashKey": "object:35162" }] }, "lockKey": true, "customConditional": "show = !!data.ddlExactLocation15;", "$$hashKey": "object:33077" }, { "input": true, "tableView": true, "label": "", "key": "ddlTypeIfDamageEmpty15", "placeholder": "", "data": { "values": [], "json": "", "url": "", "resource": "", "custom": "" }, "dataSrc": "values", "valueProperty": "", "defaultValue": "", "refreshOn": "", "filter": "", "authenticate": false, "template": "<span>{{ item.label }}</span>", "multiple": false, "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false }, "type": "select", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "customConditional": "show = !data.ddlExactLocation15;", "$$hashKey": "object:33078" }], "$$hashKey": "object:32602" }, { "components": [{ "tableView": true, "label": "", "key": "ddlDamageClass15", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "custom", "template": "<span>{{ item.label }}</span>", "data": { "custom": "var damageValues = {\n\t1: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t2: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}],\n\t3: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t4: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}],\n\t5: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t8: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t6: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}],\n\t13: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t14: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}],\n\t15: [{ \"value\": 2, \"label\":\t\"Cat. 1\"}, { \"value\":3, \"label\":\t\"Cat. 2\"}, { \"value\":4, \"label\":\t\"Cat. 3\"}, { \"value\":5, \"label\":\t\"Cat. 4\"}, { \"value\":6, \"label\":\t\"Cat. 5\"}]\n};\n\nvalues = damageValues[data.ddlTypeIfDamage15]" }, "refreshOn": "ddlTypeIfDamage15", "clearOnRefresh": true, "$$hashKey": "object:33085" }], "$$hashKey": "object:32603" }, { "components": [{ "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "txtDecision15", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "tags": [], "properties": { "": "" }, "lockKey": true, "calculateValue": "var categoryDecision =\n[[1,2, \"Re-use\"],\n[1,3,\"Re-work\"],\n[1,4,\"Re-work\"],\n[1,5,\"Re-work\"],\n[2,2,\"Re-use\"],\n[2,3,\"Re-work\"],\n[2,4,\"Re-work\"],\n[3,2,\"Re-use\"],\n[3,5,\"Scrap\"],\n[3,6,\"Scrap\"],\n[4,2,\"Re-use\"],\n[4,3,\"Re-work\"],\n[5,2,\"Re-use\"],\n[5,3,\"Re-work\"],\n[5,4,\"Re-work\"],\n[5,5,\"Scrap\"],\n[8,2,\"Re-use\"],\n[8,3,\"Re-work\"],\n[8,4,\"Re-work\"],\n[8,5,\"Scrap\"],\n[6,2,\"Re-use\"],\n[6,6,\"Scrap\"],\n[13,2,\"Re-use\"],\n[13,5,\"Scrap\"],\n[14,2,\"Re-use\"],\n[14,3,\"Re-use\"],\n[14,4,\"Re-use\"],\n[14,5,\"Re-use\"],\n[15,2,\"Re-use\"],\n[15,3,\"Re-use\"],\n[15,4,\"Re-use\"],\n[15,5,\"Re-use\"],\n[15,6,\"Re-use\"]];\nvar foundElement = categoryDecision.filter(function(element){ \n                  return element[0] == data.ddlTypeIfDamage15 && \n                             element[1] == data.ddlDamageClass15.value ;});\nvalue = foundElement.length > 0 ? foundElement[0][2] : '' ;", "disabled": true, "$$hashKey": "object:33089" }], "$$hashKey": "object:32604" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": true, "tableView": false, "type": "table", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:32393" }], "type": "fieldset", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": [], "$$hashKey": "object:32380" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "page2Columns", "columns": [{ "components": [], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:35706" }, { "components": [{ "key": "page2ColumnsHtml", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Bearings defect", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:35720" }], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:35707" }, { "components": [], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:35708" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:35701" }, { "clearOnHide": false, "input": false, "key": "page2Table", "numRows": 7, "numCols": 5, "rows": [[{ "components": [], "$$hashKey": "object:36005" }, { "components": [{ "key": "page2TableHtml", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Location", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36115" }], "$$hashKey": "object:36006" }, { "components": [{ "key": "page2TableHtml2", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Position", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36119" }], "$$hashKey": "object:36007" }, { "components": [{ "key": "page2TableHtml3", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Type of Damage", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36123" }], "$$hashKey": "object:36008" }, { "components": [{ "key": "page2TableHtml4", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Damage Class", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36127" }], "$$hashKey": "object:36009" }], [{ "components": [{ "key": "page2TableHtml5", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "1", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36131" }], "$$hashKey": "object:36015" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:36500" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:36501" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:36502" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:36503" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:36504" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:36505" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:36506" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:36507" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:36508" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:36509" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:36510" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:36511" }, { "value": "14", "label": "Planet", "$$hashKey": "object:36512" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:36513" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:36514" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:36515" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:36516" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:36517" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:36518" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:36519" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:36520" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:36521" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:36522" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:36523" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:36524" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:36525" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:36526" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:36527" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:36528" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:36529" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:36530" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:36531" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:36532" }] }, "lockKey": true, "$$hashKey": "object:36135" }], "$$hashKey": "object:36016" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:36569" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:36570" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:36571" }, { "value": "8", "label": "N/A", "$$hashKey": "object:36572" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:36573" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:36574" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:36575" }] }, "lockKey": true, "$$hashKey": "object:36139" }], "$$hashKey": "object:36017" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:36586" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:36587" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:36588" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:36589" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:36590" }, { "value": "15", "label": "Other", "$$hashKey": "object:36591" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:36592" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:36593" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:36594" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:36595" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:36596" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:36597" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:36598" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:36599" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:36600" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:36601" }] }, "$$hashKey": "object:36143" }], "$$hashKey": "object:36018" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClass1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:36621" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:36622" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:36623" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:36624" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:36625" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:36626" }] }, "customConditional": "show = !!data.ddlTypeofDamage1 && data.ddlTypeofDamage1 != 1;", "lockKey": true, "$$hashKey": "object:36147" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage1 || data.ddlTypeofDamage1 == 1;", "lockKey": true, "$$hashKey": "object:36148" }], "$$hashKey": "object:36019" }], [{ "components": [{ "key": "page2TableHtml6", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "2", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36155" }], "$$hashKey": "object:36025" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:36642" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:36643" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:36644" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:36645" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:36646" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:36647" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:36648" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:36649" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:36650" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:36651" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:36652" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:36653" }, { "value": "14", "label": "Planet", "$$hashKey": "object:36654" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:36655" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:36656" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:36657" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:36658" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:36659" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:36660" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:36661" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:36662" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:36663" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:36664" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:36665" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:36666" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:36667" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:36668" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:36669" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:36670" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:36671" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:36672" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:36673" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:36674" }] }, "lockKey": true, "$$hashKey": "object:36159" }], "$$hashKey": "object:36026" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:36711" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:36712" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:36713" }, { "value": "8", "label": "N/A", "$$hashKey": "object:36714" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:36715" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:36716" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:36717" }] }, "lockKey": true, "$$hashKey": "object:36163" }], "$$hashKey": "object:36027" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:36728" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:36729" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:36730" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:36731" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:36732" }, { "value": "15", "label": "Other", "$$hashKey": "object:36733" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:36734" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:36735" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:36736" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:36737" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:36738" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:36739" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:36740" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:36741" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:36742" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:36743" }] }, "$$hashKey": "object:36167" }], "$$hashKey": "object:36028" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClass2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:36763" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:36764" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:36765" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:36766" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:36767" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:36768" }] }, "customConditional": "show = !!data.ddlTypeofDamage2 && data.ddlTypeofDamage2 != 1;", "lockKey": true, "$$hashKey": "object:36171" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage2 || data.ddlTypeofDamage2 == 1;", "lockKey": true, "$$hashKey": "object:36172" }], "$$hashKey": "object:36029" }], [{ "components": [{ "key": "page2TableHtml7", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "3", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36179" }], "$$hashKey": "object:36035" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:36784" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:36785" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:36786" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:36787" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:36788" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:36789" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:36790" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:36791" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:36792" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:36793" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:36794" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:36795" }, { "value": "14", "label": "Planet", "$$hashKey": "object:36796" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:36797" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:36798" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:36799" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:36800" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:36801" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:36802" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:36803" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:36804" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:36805" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:36806" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:36807" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:36808" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:36809" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:36810" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:36811" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:36812" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:36813" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:36814" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:36815" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:36816" }] }, "lockKey": true, "$$hashKey": "object:36183" }], "$$hashKey": "object:36036" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:36853" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:36854" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:36855" }, { "value": "8", "label": "N/A", "$$hashKey": "object:36856" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:36857" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:36858" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:36859" }] }, "lockKey": true, "$$hashKey": "object:36187" }], "$$hashKey": "object:36037" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:36870" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:36871" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:36872" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:36873" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:36874" }, { "value": "15", "label": "Other", "$$hashKey": "object:36875" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:36876" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:36877" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:36878" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:36879" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:36880" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:36881" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:36882" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:36883" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:36884" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:36885" }] }, "$$hashKey": "object:36191" }], "$$hashKey": "object:36038" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClass3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:36905" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:36906" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:36907" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:36908" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:36909" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:36910" }] }, "customConditional": "show = !!data.ddlTypeofDamage3 && data.ddlTypeofDamage3 != 1;", "lockKey": true, "$$hashKey": "object:36195" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty3", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage3 || data.ddlTypeofDamage3 == 1;", "lockKey": true, "$$hashKey": "object:36196" }], "$$hashKey": "object:36039" }], [{ "components": [{ "key": "page2TableHtml8", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "4", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36203" }], "$$hashKey": "object:36045" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:36926" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:36927" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:36928" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:36929" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:36930" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:36931" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:36932" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:36933" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:36934" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:36935" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:36936" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:36937" }, { "value": "14", "label": "Planet", "$$hashKey": "object:36938" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:36939" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:36940" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:36941" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:36942" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:36943" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:36944" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:36945" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:36946" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:36947" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:36948" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:36949" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:36950" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:36951" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:36952" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:36953" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:36954" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:36955" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:36956" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:36957" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:36958" }] }, "lockKey": true, "$$hashKey": "object:36207" }], "$$hashKey": "object:36046" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:36995" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:36996" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:36997" }, { "value": "8", "label": "N/A", "$$hashKey": "object:36998" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:36999" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:37000" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:37001" }] }, "lockKey": true, "$$hashKey": "object:36211" }], "$$hashKey": "object:36047" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:37012" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:37013" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:37014" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:37015" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:37016" }, { "value": "15", "label": "Other", "$$hashKey": "object:37017" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:37018" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:37019" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:37020" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:37021" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:37022" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:37023" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:37024" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:37025" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:37026" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:37027" }] }, "$$hashKey": "object:36215" }], "$$hashKey": "object:36048" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage4 || data.ddlTypeofDamage4 == 1;", "lockKey": true, "$$hashKey": "object:36219" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClass4", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:37050" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:37051" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:37052" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:37053" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:37054" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:37055" }] }, "customConditional": "show = !!data.ddlTypeofDamage4 && data.ddlTypeofDamage4 != 1;", "lockKey": true, "$$hashKey": "object:36220" }], "$$hashKey": "object:36049" }], [{ "components": [{ "key": "page2TableHtml9", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "5", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36227" }], "$$hashKey": "object:36055" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:37068" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:37069" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:37070" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:37071" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:37072" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:37073" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:37074" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:37075" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:37076" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:37077" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:37078" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:37079" }, { "value": "14", "label": "Planet", "$$hashKey": "object:37080" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:37081" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:37082" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:37083" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:37084" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:37085" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:37086" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:37087" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:37088" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:37089" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:37090" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:37091" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:37092" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:37093" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:37094" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:37095" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:37096" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:37097" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:37098" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:37099" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:37100" }] }, "lockKey": true, "$$hashKey": "object:36231" }], "$$hashKey": "object:36056" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:37137" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:37138" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:37139" }, { "value": "8", "label": "N/A", "$$hashKey": "object:37140" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:37141" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:37142" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:37143" }] }, "lockKey": true, "$$hashKey": "object:36235" }], "$$hashKey": "object:36057" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:37154" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:37155" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:37156" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:37157" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:37158" }, { "value": "15", "label": "Other", "$$hashKey": "object:37159" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:37160" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:37161" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:37162" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:37163" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:37164" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:37165" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:37166" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:37167" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:37168" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:37169" }] }, "$$hashKey": "object:36239" }], "$$hashKey": "object:36058" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage5 || data.ddlTypeofDamage5 == 1;", "lockKey": true, "$$hashKey": "object:36243" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClass5", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:37192" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:37193" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:37194" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:37195" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:37196" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:37197" }] }, "customConditional": "show = !!data.ddlTypeofDamage5 && data.ddlTypeofDamage5 != 1;", "lockKey": true, "$$hashKey": "object:36244" }], "$$hashKey": "object:36059" }], [{ "components": [{ "key": "page2TableHtml10", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "6", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:36251" }], "$$hashKey": "object:36065" }, { "components": [{ "tableView": true, "label": "", "key": "ddlLocation6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "18", "label": "Not Inspected", "$$hashKey": "object:37210" }, { "value": "12", "label": "Auxilliary High Speed Bearing NRE", "$$hashKey": "object:37211" }, { "value": "11", "label": "Auxilliary High Speed Bearing RE", "$$hashKey": "object:37212" }, { "value": "33", "label": "Axial Bearing", "$$hashKey": "object:37213" }, { "value": "9", "label": "High Speed Bearing NRE", "$$hashKey": "object:37214" }, { "value": "8", "label": "High Speed Bearing RE", "$$hashKey": "object:37215" }, { "value": "7", "label": "Intermediate Speed Bearing NRE", "$$hashKey": "object:37216" }, { "value": "6", "label": "Intermediate Speed Bearing RE", "$$hashKey": "object:37217" }, { "value": "5", "label": "Low Speed Bearing NRE", "$$hashKey": "object:37218" }, { "value": "4", "label": "Low Speed Bearing RE", "$$hashKey": "object:37219" }, { "value": "13", "label": "Pitch tube", "$$hashKey": "object:37220" }, { "value": "10", "label": "Pitch Tube Bearing", "$$hashKey": "object:37221" }, { "value": "14", "label": "Planet", "$$hashKey": "object:37222" }, { "value": "15", "label": "Planet Carrier", "$$hashKey": "object:37223" }, { "value": "25", "label": "Planet Carrier  STG2 RE", "$$hashKey": "object:37224" }, { "value": "2", "label": "Planet Carrier NRE", "$$hashKey": "object:37225" }, { "value": "1", "label": "Planet Carrier RE", "$$hashKey": "object:37226" }, { "value": "26", "label": "Planet Carrier STG2 NRE ", "$$hashKey": "object:37227" }, { "value": "27", "label": "Planet Gear 1  STG2 Bearing  RE", "$$hashKey": "object:37228" }, { "value": "20", "label": "Planet Gear 1 Bearing NRE", "$$hashKey": "object:37229" }, { "value": "19", "label": "Planet Gear 1 Bearing RE", "$$hashKey": "object:37230" }, { "value": "28", "label": "Planet Gear 1 STG2 Bearing  NRE", "$$hashKey": "object:37231" }, { "value": "22", "label": "Planet Gear 2 Bearing NRE", "$$hashKey": "object:37232" }, { "value": "21", "label": "Planet Gear 2 Bearing RE", "$$hashKey": "object:37233" }, { "value": "30", "label": "Planet Gear 2 STG2 Bearing NRE", "$$hashKey": "object:37234" }, { "value": "29", "label": "Planet Gear 2 STG2 Bearing RE", "$$hashKey": "object:37235" }, { "value": "24", "label": "Planet Gear 3 Bearing NRE", "$$hashKey": "object:37236" }, { "value": "23", "label": "Planet Gear 3 Bearing RE", "$$hashKey": "object:37237" }, { "value": "32", "label": "Planet Gear 3 STG2 Bearing NRE", "$$hashKey": "object:37238" }, { "value": "31", "label": "Planet Gear 3 STG2 Bearing RE", "$$hashKey": "object:37239" }, { "value": "3", "label": "Planet Gear Bearings", "$$hashKey": "object:37240" }, { "value": "16", "label": "PTO Shaft", "$$hashKey": "object:37241" }, { "value": "17", "label": "ULSIM (Upper low speed intermediate shaft)", "$$hashKey": "object:37242" }] }, "lockKey": true, "$$hashKey": "object:36255" }], "$$hashKey": "object:36066" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPosition6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "2", "label": "In Board", "$$hashKey": "object:37279" }, { "value": "1", "label": "Mid (In Board)", "$$hashKey": "object:37280" }, { "value": "5", "label": "Mid (Out Board)", "$$hashKey": "object:37281" }, { "value": "8", "label": "N/A", "$$hashKey": "object:37282" }, { "value": "6", "label": "Out Board", "$$hashKey": "object:37283" }, { "value": "3", "label": "R-End (In Board)", "$$hashKey": "object:37284" }, { "value": "7", "label": "R-End (Out Board)", "$$hashKey": "object:37285" }] }, "lockKey": true, "$$hashKey": "object:36259" }], "$$hashKey": "object:36067" }, { "components": [{ "tableView": true, "label": "", "key": "ddlTypeofDamage6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "No Damage", "$$hashKey": "object:37296" }, { "value": "10", "label": "Mat rollers", "$$hashKey": "object:37297" }, { "value": "11", "label": "Noisy", "$$hashKey": "object:37298" }, { "value": "13", "label": "Spalling/Flaking (macro-pitting)", "$$hashKey": "object:37299" }, { "value": "14", "label": "Standstill marks (false brinelling)", "$$hashKey": "object:37300" }, { "value": "15", "label": "Other", "$$hashKey": "object:37301" }, { "value": "16", "label": "Worn-out", "$$hashKey": "object:37302" }, { "value": "17", "label": "Not Inspected", "$$hashKey": "object:37303" }, { "value": "2", "label": "Micropitting", "$$hashKey": "object:37304" }, { "value": "3", "label": "Corrosion", "$$hashKey": "object:37305" }, { "value": "4", "label": "Cracks and Fractures", "$$hashKey": "object:37306" }, { "value": "5", "label": "Circumfrential Marks", "$$hashKey": "object:37307" }, { "value": "6", "label": "High wear rate", "$$hashKey": "object:37308" }, { "value": "7", "label": "Debris Indentations", "$$hashKey": "object:37309" }, { "value": "8", "label": "Loose IR", "$$hashKey": "object:37310" }, { "value": "9", "label": "Loose OR", "$$hashKey": "object:37311" }] }, "$$hashKey": "object:36263" }], "$$hashKey": "object:36068" }, { "components": [{ "tableView": true, "label": "", "key": "ddlBearingDamageClass6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "N/A", "$$hashKey": "object:37331" }, { "value": "2", "label": "Cat. 1", "$$hashKey": "object:37332" }, { "value": "3", "label": "Cat. 2", "$$hashKey": "object:37333" }, { "value": "4", "label": "Cat. 3", "$$hashKey": "object:37334" }, { "value": "5", "label": "Cat. 4", "$$hashKey": "object:37335" }, { "value": "6", "label": "Cat. 5", "$$hashKey": "object:37336" }] }, "customConditional": "show = !!data.ddlTypeofDamage6 && data.ddlTypeofDamage6 != 1;", "lockKey": true, "$$hashKey": "object:36267" }, { "tableView": true, "label": "", "key": "ddlBearingDamageClassEmpty6", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customConditional": "show = !data.ddlTypeofDamage6 || data.ddlTypeofDamage6 == 1;", "lockKey": true, "$$hashKey": "object:36268" }], "$$hashKey": "object:36069" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": true, "tableView": false, "type": "table", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:35986" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "page2Columns2", "columns": [{ "components": [{ "key": "page2Columns2Html", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Housing", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37619" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:37609" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:37610" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37604" }, { "clearOnHide": false, "input": false, "key": "page2Table2", "numRows": 6, "numCols": 3, "rows": [[{ "components": [{ "key": "page2Columns3Html", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Planet Stage 1", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37960" }], "$$hashKey": "object:37902" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPlanetStage1", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38071" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38072" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38073" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38074" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38075" }, { "value": "6", "label": "Other", "$$hashKey": "object:38076" }] }, "lockKey": true, "$$hashKey": "object:37964" }], "$$hashKey": "object:37903" }, { "components": [], "$$hashKey": "object:37904" }], [{ "components": [{ "key": "page2Columns3Html2", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Planet Stage 2", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37969" }], "$$hashKey": "object:37908" }, { "components": [{ "tableView": true, "label": "", "key": "ddlPlanetStage2", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38089" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38090" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38091" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38092" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38093" }, { "value": "6", "label": "Other", "$$hashKey": "object:38094" }] }, "$$hashKey": "object:37973" }], "$$hashKey": "object:37909" }, { "components": [], "$$hashKey": "object:37910" }], [{ "components": [{ "key": "page2Columns3Html3", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Helical/Parallel Stage", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37978" }], "$$hashKey": "object:37914" }, { "components": [{ "tableView": true, "label": "", "key": "ddlHelicalParallelStage", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38107" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38108" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38109" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38110" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38111" }, { "value": "6", "label": "Other", "$$hashKey": "object:38112" }] }, "$$hashKey": "object:37982" }], "$$hashKey": "object:37915" }, { "components": [], "$$hashKey": "object:37916" }], [{ "components": [{ "key": "page2Columns3Html4", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Front Plate", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37987" }], "$$hashKey": "object:37920" }, { "components": [{ "tableView": true, "label": "", "key": "ddlFrontPlate", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38125" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38126" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38127" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38128" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38129" }, { "value": "6", "label": "Other", "$$hashKey": "object:38130" }] }, "$$hashKey": "object:37991" }], "$$hashKey": "object:37921" }, { "components": [], "$$hashKey": "object:37922" }], [{ "components": [{ "key": "page2Columns3Html5", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "Auxilliary Stage", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37996" }], "$$hashKey": "object:37926" }, { "components": [{ "tableView": true, "label": "", "key": "ddlAuxlliaryStage", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38143" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38144" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38145" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38146" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38147" }, { "value": "6", "label": "Other", "$$hashKey": "object:38148" }] }, "$$hashKey": "object:38000" }], "$$hashKey": "object:37927" }, { "components": [], "$$hashKey": "object:37928" }], [{ "components": [{ "key": "page2Columns3Html6", "input": false, "tag": "p", "attrs": [{ "value": "", "attr": "" }], "className": "", "content": "HS Stage", "type": "htmlelement", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:38005" }], "$$hashKey": "object:37932" }, { "components": [{ "tableView": true, "label": "", "key": "ddlHSStage", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "Not Inspected", "$$hashKey": "object:38161" }, { "value": "5", "label": "Damaged Torque-arm", "$$hashKey": "object:38162" }, { "value": "1", "label": "Faulty Gearbox Bolts", "$$hashKey": "object:38163" }, { "value": "2", "label": "Housing Cracks", "$$hashKey": "object:38164" }, { "value": "3", "label": "No Damage", "$$hashKey": "object:38165" }, { "value": "6", "label": "Other", "$$hashKey": "object:38166" }] }, "$$hashKey": "object:38009" }], "$$hashKey": "object:37933" }, { "components": [], "$$hashKey": "object:37934" }]], "header": [], "caption": "", "striped": false, "bordered": false, "hover": false, "condensed": true, "tableView": false, "type": "table", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:37885" }, { "clearOnHide": false, "key": "page2Panel", "input": false, "title": "Torque Arm System", "theme": "default", "tableView": false, "components": [{ "input": true, "inputType": "checkbox", "tableView": true, "label": "Loose Bolts", "datagridLabel": true, "key": "page2PanelLooseBolts", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-right": "", "margin-left": "15px" }, "$$hashKey": "object:38442" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Borken Bolts", "datagridLabel": true, "key": "page2PanelBorkenBolts", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38443" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Defect Damper Elements", "datagridLabel": true, "key": "page2PanelDefectDamperElements", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38444" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Too Much Clearance", "datagridLabel": true, "key": "page2PanelTooMuchClearance", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38445" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Cracked Broken Torque Arm", "datagridLabel": true, "key": "page2PanelCrackedBrokenTorqueArm", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38446" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Needs To Be Aligned", "datagridLabel": true, "key": "page2PanelNeedsToBeAligned", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38447" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:38431" }, { "clearOnHide": false, "key": "page2Panel2", "input": false, "title": "Defect Accessories", "theme": "default", "tableView": false, "components": [{ "input": true, "inputType": "checkbox", "tableView": true, "label": "Pt 100 Bearing 1", "datagridLabel": true, "key": "page2Panel2Pt100Bearing1", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38774" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Pt 100 Bearing 2", "datagridLabel": true, "key": "page2Panel2Pt100Bearing2", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38775" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Pt 100 Bearing 3", "datagridLabel": true, "key": "page2Panel2Pt100Bearing3", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38776" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Oil Level sensor", "datagridLabel": true, "key": "page2Panel2OilLevelsensor", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38777" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Oil Pressure (s412)", "datagridLabel": true, "key": "page2Panel2OilPressures412", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38778" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Pt 100 Oil Sump", "datagridLabel": true, "key": "page2Panel2Pt100OilSump", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "hideLabel": true, "$$hashKey": "object:38779" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Filter Indicator", "datagridLabel": true, "key": "page2Panel2FilterIndicator", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38780" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Immersion Heater", "datagridLabel": true, "key": "page2Panel2ImmersionHeater", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38781" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Drain Valve", "datagridLabel": true, "key": "page2Panel2DrainValve", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38782" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Air Breather", "datagridLabel": true, "key": "page2Panel2AirBreather", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38783" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Sight Glass", "datagridLabel": true, "key": "page2Panel2SightGlass", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38784" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Chip Detector", "datagridLabel": true, "key": "page2Panel2ChipDetector", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "$$hashKey": "object:38785" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:38763" }, { "input": true, "tableView": true, "inputType": "text", "inputMask": "", "label": "", "key": "page2TextField", "placeholder": "", "prefix": "", "suffix": "", "multiple": false, "defaultValue": "", "protected": false, "unique": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "minLength": "", "maxLength": "", "pattern": "", "custom": "", "customPrivate": false }, "conditional": { "show": "", "when": null, "eq": "" }, "type": "textfield", "$$hashKey": "object:56416", "tags": [], "properties": { "": "" }, "calculateValue": "function CalculateTotalPercentage() {\n    var totalPercentage = 0\n    var value = $('#hdnGearTypeDamageDecision').val();\n    if(!value) return \"\";\n\n    var GearTypeDamageDecisionData = JSON.parse(value);\n\n    for (var elementCount = 1; elementCount <= 15; elementCount++) {\n        var exLocVal = data['ddlExactLocation' + elementCount];\n        var exactLocation = 0;\n        if (parseInt(exLocVal) >= 0) {\n            exactLocation = parseInt(exLocVal);\n        }\n\n        var decisionText = data['txtDecision' + elementCount];\n\n        var decision = 0;\n        switch(decisionText){\n            case \"Re-work\" : decision = 1; break;\n            case \"Re-use\" : decision = 2; break;\n            case \"Scrap\" : decision = 3; break;\n            case \"Upgrade\" : decision = 4; break;\n            case \"N/A\" : decision = 5; break;\n        }\n\n        for (var eCount = 0; eCount < GearTypeDamageDecisionData.length; eCount++) {\n            var d = GearTypeDamageDecisionData[eCount].gearTypeDamageDecisionText;\n            var s = d.split(',');\n            if (((s[0] == exactLocation) && (s[1] == decision)))\n                totalPercentage = totalPercentage + parseFloat(s[2]);\n        }\n\n    }\n    if (totalPercentage > 0) {\n        totalPercentage = totalPercentage + parseFloat(\"38.13\");\n    }\n    var planetStage1 = data['ddlPlanetStage1'];\n    var planetStage2 = data['ddlPlanetStage2'];\n    var helicalStage =data['ddlHelicalParallelStage'];\n    var frontPlate = data['ddlFrontPlate'];\n    var auxStage = data['ddlAuxlliaryStage'];\n    var hSStage = data['ddlHSStage'];\n    if (planetStage1 == \"1\" || planetStage1 == \"2\" ||\n        planetStage2 == \"1\" || planetStage2 == \"2\" ||\n        helicalStage == \"1\" || helicalStage == \"2\" ||\n        frontPlate == \"1\" || frontPlate == \"2\" ||\n        auxStage == \"1\" || auxStage == \"2\" || hSStage == \"1\" || hSStage == \"2\") {\n        totalPercentage = totalPercentage + parseFloat(\"23.99\");\n    }\n\n\n    var ShaftLocation1 = data['ddlGearboxShaftsExactLocation1ShaftTypeId'];\n    var ShaftLocation2 = data['ddlGearboxShaftsExactLocation2ShaftTypeId'];\n    var ShaftLocation3 = data['ddlGearboxShaftsExactLocation3ShaftTypeId'];\n    var ShaftLocation4 = data['ddlGearboxShaftsExactLocation4ShaftTypeId'];\n    if (((ShaftLocation1 == \"13\") || ((ShaftLocation2 == \"13\") || ((ShaftLocation3 == \"13\") || (ShaftLocation4 == \"13\"))))) {\n        totalPercentage = totalPercentage + parseFloat(\"12.37\");\n    }\n\n    if (((ShaftLocation1 == \"4\") || ((ShaftLocation2 == \"4\") || ((ShaftLocation3 == \"4\") || (ShaftLocation4 == \"4\"))))) {\n        totalPercentage = totalPercentage + parseFloat(\"6.04\");\n    }\n    var score = \"\";\n    if (totalPercentage < 50)\n        score = \"A\";\n    else if (totalPercentage < 65)\n        score = \"B\";\n    else if (totalPercentage < 80)\n        score = \"C\";\n    else\n        score = \"D\";\n\n    return score;\n};\n\nvalue = \"Defect Categorization Score :\t\" + CalculateTotalPercentage();", "disabled": true }, { "clearOnHide": false, "key": "page2Panel3", "input": false, "title": "Symptoms", "theme": "default", "tableView": false, "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page2Panel3Columns", "columns": [{ "components": [{ "tableView": true, "label": "Vibrations", "key": "ddlVibrations", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "validate": { "required": true }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:40612" }, { "value": "1", "label": "High", "$$hashKey": "object:40613" }, { "value": "2", "label": "Normal", "$$hashKey": "object:40614" }, { "value": "3", "label": "Very High", "$$hashKey": "object:40615" }] }, "lockKey": true, "$$hashKey": "object:40589" }, { "tableView": true, "label": "Noise", "key": "ddlNoise", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "validate": { "required": true }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:40623" }, { "value": "1", "label": "High Pitched/Yelling", "$$hashKey": "object:40624" }, { "value": "2", "label": "Normal", "$$hashKey": "object:40625" }, { "value": "3", "label": "Rough/Loud", "$$hashKey": "object:40626" }] }, "lockKey": true, "$$hashKey": "object:40590" }], "width": 9, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:40579" }, { "components": [], "width": 3, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:40580" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:40574" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "page2Panel3Columns2", "columns": [{ "components": [{ "tableView": true, "label": "Debris on Magnet", "key": "ddlDebrisOnMagnet", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "validate": { "required": true }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "5", "label": "N/A", "$$hashKey": "object:40930" }, { "value": "1", "label": "Few", "$$hashKey": "object:40931" }, { "value": "2", "label": "Many", "$$hashKey": "object:40932" }, { "value": "3", "label": "No ", "$$hashKey": "object:40933" }, { "value": "4", "label": "No magnet", "$$hashKey": "object:40934" }] }, "lockKey": true, "$$hashKey": "object:40907" }], "width": 4, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:40894" }, { "components": [{ "tableView": true, "label": "Magnet Position", "key": "ddlMagnetPos", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "5", "label": "N/A", "$$hashKey": "object:40943" }, { "value": "1", "label": "Helical stage", "$$hashKey": "object:40944" }, { "value": "2", "label": "IS planetary stage", "$$hashKey": "object:40945" }, { "value": "3", "label": "LS planetary stage", "$$hashKey": "object:40946" }, { "value": "6", "label": "Main stage", "$$hashKey": "object:40947" }, { "value": "4", "label": "Planetary stage", "$$hashKey": "object:40948" }] }, "validate": { "required": true }, "lockKey": true, "$$hashKey": "object:40911" }], "width": 5, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:40895" }, { "components": [], "width": 3, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:40896" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:40889" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "page2Panel3Columns3", "columns": [{ "components": [{ "tableView": true, "label": "Debris found in Gearbox", "key": "ddlDebrisFoundinGearbox", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "validate": { "required": true }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "4", "label": "N/A", "$$hashKey": "object:39341" }, { "value": "1", "label": "Few", "$$hashKey": "object:39342" }, { "value": "2", "label": "Many", "$$hashKey": "object:39343" }, { "value": "3", "label": "No", "$$hashKey": "object:39344" }] }, "lockKey": true, "$$hashKey": "object:39238" }, { "tableView": true, "label": "Overall Gearbox Condition", "key": "ddlOverallGearboxCondition", "description": "", "uploadLink": "", "downloadLink": "", "protected": false, "unique": false, "persistent": true, "input": true, "type": "dynamicDropdown", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "dataSrc": "file", "template": "<span>{{ item.label }}</span>", "data": { "values": [{ "value": "1", "label": "1", "$$hashKey": "object:39352" }, { "value": "2", "label": "2", "$$hashKey": "object:39353" }, { "value": "3", "label": "3", "$$hashKey": "object:39354" }, { "value": "4", "label": "4", "$$hashKey": "object:39355" }, { "value": "5", "label": "5", "$$hashKey": "object:39356" }] }, "lockKey": true, "tooltip": "*See INS 0022-7865 in DMS for more information\nA Category 1 is indicative of a normal gearbox condition.  This may include manufacturing marks that do not affect the performance of the gearbox nor require any further actions.  It is recommended that the turbine be placed in RUN status as no further actions are required.  \nA Category 2 demonstrates indications of minor gearbox damage and wear. These signs do not affect the performance of the gearbox in their current state but should be documented in a CIR for tracking purposes.\nA Category 3 demonstrates indications of advanced gearbox damage or wear. The submittal of a CIR is required for engineering monitoring and potential further recommendations. \nA Category 4 implies that damage in the gearbox has advanced to potential failure. A full gearbox inspection should be conducted as soon as possible to determine the extent of the damage. The engineering department in the local SBU should be consulted to determine whether the turbine is safe to run. \nA Category 5 implies that the gearbox has a potentially serious failure that could cause catastrophic failure. Often accompanied by abnormal noise and vibration. A full gearbox inspection should be conducted as soon as possible to investigate the extent of the damage.", "$$hashKey": "object:39239" }], "width": 9, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:39197" }, { "components": [], "width": 3, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:39198" }], "type": "columns", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:39174" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "$$hashKey": "object:39161" }, { "clearOnHide": false, "key": "page2Panel4", "input": false, "title": "Max Temperature", "theme": "default", "tableView": false, "components": [{ "input": true, "tableView": true, "label": "Reset Date", "key": "txtDateMaxTemperatureResetDate", "placeholder": "", "format": "yyyy-MM-dd hh:mm a", "enableDate": true, "enableTime": true, "defaultDate": "", "datepickerMode": "day", "datePicker": { "showWeeks": true, "startingDay": 0, "initDate": "", "minMode": "day", "maxMode": "year", "yearRows": 4, "yearColumns": 5, "datepickerMode": "day" }, "timePicker": { "hourStep": 1, "minuteStep": 1, "showMeridian": true, "readonlyInput": false, "mousewheel": true, "arrowkeys": true }, "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "custom": "" }, "type": "datetime", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:41489" }, { "input": true, "tableView": true, "inputType": "number", "label": "Bearing 1", "key": "txtBearing1", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "$$hashKey": "object:517772", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "isNew": false }, { "input": true, "tableView": true, "inputType": "number", "label": "Bearing 2", "key": "txtBearing2", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "$$hashKey": "object:552658", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true }, { "input": true, "tableView": true, "inputType": "number", "label": "Bearing 3", "key": "txtBearing3", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "$$hashKey": "object:570500", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true }, { "input": true, "tableView": true, "inputType": "number", "label": "Oil Sump", "key": "txtOilSump", "placeholder": "", "prefix": "", "suffix": "", "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "clearOnHide": true, "validate": { "required": false, "min": "", "max": "", "step": "any", "integer": "", "multiple": "", "custom": "" }, "type": "number", "$$hashKey": "object:605086", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:41478" }, { "clearOnHide": false, "key": "page2Panel5", "input": false, "title": "Leakage /Droplets", "theme": "default", "tableView": false, "components": [{ "input": true, "inputType": "checkbox", "tableView": true, "label": "LSS NR-end", "datagridLabel": true, "key": "chkLSSNREnd", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "style": { "margin-left": "15px" }, "$$hashKey": "object:41817", "isNew": false }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "MS NR-end", "datagridLabel": true, "key": "chkIMSNREnd", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41818" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "IMS R-end", "datagridLabel": true, "key": "chkIMSREnd", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41819" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "HSS NR-end", "datagridLabel": true, "key": "chkHSSNREnd", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41820" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "HSS R-end", "datagridLabel": true, "key": "chkHSSREnd", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41821" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Pitch Tube", "datagridLabel": true, "key": "chkPitchTube", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41822" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Split Lines", "datagridLabel": true, "key": "chkSpliLines", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41823" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Hose and Piping", "datagridLabel": true, "key": "chkHoseandPiping", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41824" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Input Shaft", "datagridLabel": true, "key": "chkInputShaft", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41825" }, { "input": true, "inputType": "checkbox", "tableView": true, "label": "Aux. - HSS/PTO", "datagridLabel": true, "key": "chkAuxHSSPTO", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "hideLabel": true, "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "style": { "margin-left": "15px" }, "lockKey": true, "$$hashKey": "object:41826" }], "type": "panel", "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "customClass": "expandable-panel collapsed", "$$hashKey": "object:41806" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "undefinedColumns2", "columns": [{ "components": [{ "tableView": true, "key": "undefinedColumns2CirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "$$hashKey": "object:6574" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:6027" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:18369" }], "type": "columns", "$$hashKey": "object:6022", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page2", "$$hashKey": "object:5443", "clearOnHide": false, "theme": "default", "tableView": false }, { "type": "panel", "title": "Images", "components": [{ "input": true, "inputType": "checkbox", "tableView": true, "label": "Plate Type Picture Not possible", "datagridLabel": true, "key": "cbPlateTypePictureNotPossible", "defaultValue": false, "protected": false, "persistent": true, "hidden": false, "name": "", "value": "", "clearOnHide": true, "validate": { "required": false }, "type": "checkbox", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" }, "lockKey": true, "$$hashKey": "object:128164", "hideLabel": true, "style": { "margin-left": "20px" } }, { "input": true, "tableView": true, "label": "Reason", "key": "tbPlateTypePictureNotPossibleReason", "placeholder": "", "prefix": "", "suffix": "", "rows": 3, "multiple": false, "defaultValue": "", "protected": false, "persistent": true, "hidden": false, "wysiwyg": false, "clearOnHide": true, "validate": { "required": true, "minLength": "", "maxLength": "", "pattern": "", "custom": "" }, "type": "textarea", "$$hashKey": "object:85378", "tags": [], "conditional": { "show": "true", "when": "cbPlateTypePictureNotPossible", "eq": "true" }, "properties": { "": "" }, "lockKey": true }, { "tableView": true, "label": "Upload Images", "key": "page3UploadImages", "description": "Drag files here or click to upload", "protected": false, "unique": false, "persistent": true, "type": "imageUploader", "$$hashKey": "object:6894" }, { "clearOnHide": false, "input": false, "tableView": false, "key": "undefinedColumns3", "columns": [{ "components": [{ "tableView": true, "key": "undefinedColumns3CirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "isNew": true, "$$hashKey": "object:6371" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:18917" }, { "components": [], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:19203" }], "type": "columns", "$$hashKey": "object:18912", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page3", "$$hashKey": "object:6582", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }, { "type": "panel", "title": "Submission", "components": [{ "clearOnHide": false, "input": false, "tableView": false, "key": "page4Columns", "columns": [{ "components": [{ "tableView": true, "key": "page4ColumnsCirNavigation", "protected": false, "unique": false, "persistent": true, "type": "cirNavigation", "$$hashKey": "object:68777" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:59582" }, { "components": [{ "tableView": true, "key": "page4ColumnsSubmitForm", "protected": false, "unique": false, "persistent": true, "type": "submitForm", "$$hashKey": "object:73238" }], "width": 6, "offset": 0, "push": 0, "pull": 0, "$$hashKey": "object:59583" }], "type": "columns", "$$hashKey": "object:59577", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "input": false, "key": "page4", "$$hashKey": "object:45863", "clearOnHide": false, "theme": "default", "tableView": false, "breadcrumb": "default", "tags": [], "conditional": { "show": "", "when": null, "eq": "" }, "properties": { "": "" } }], "display": "wizard", "page": 0, "numPages": 4 };
            // Blade
            /*$rootScope.form = {
                "components": [
                    {
                        "type": "panel",
                        "input": false,
                        "title": "Wind Turbine Data",
                        "theme": "default",
                        "components": [
                            {
                                "tableView": true,
                                "key": "undefinedToggleEitorfields",
                                "protected": false,
                                "unique": false,
                                "persistent": true,
                                "type": "roleToggleButton",
                                "$$hashKey": "object:826",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "visible-roles": "Visitor" },
                                "label": "Toggle Editor fields",
                                "selectedRoles": ["Editor"]
                            },
                            {
                                "clearOnHide": false,
                                "key": "undefinedPanel2",
                                "input": false,
                                "title": "Wind turbine data",
                                "theme": "default",
                                "tableView": false,
                                "components": [
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "radio",
                                        "label": "Report Type",
                                        "key": "rbReportType",
                                        "values":
                                        [
                                            { "value": "1", "label": "Inspection" },
                                            { "value": "2", "label": "Failure" }, { "value": "3", "label": "Repair" },
                                            { "value": "5", "label": "Retrofit" }
                                        ],
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": { "required": false, "custom": "", "customPrivate": false },
                                        "type": "radio",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "disable-roles": "Editor" },
                                        "inline": true,
                                        "lockKey": true,
                                        "tooltip":
                                            "If a component has failed, always select “Failure” as primary. “Failure” reports are used for statistics and notifications to supplier.",
                                        "$$hashKey": "object:1831"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Reason for Service",
                                        "key": "txtReasonforService",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "visible-roles": "Visitor" },
                                        "lockKey": true,
                                        "$$hashKey": "object:2104",
                                        "isNew": false
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Turbine Number",
                                        "key": "txtTurbineNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "visible-roles": "Editor" },
                                        "lockKey": true,
                                        "tooltip": "",
                                        "$$hashKey": "object:2367"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Local Pad ID Number",
                                        "key": "txtLocalPadIdNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "visible-roles": "GBXIRCreator" },
                                        "disabled": false,
                                        "lockKey": true,
                                        "$$hashKey": "object:2630"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "CIM Case Number",
                                        "key": "txttCimCaseNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "visible-roles": "Editor" },
                                        "lockKey": true,
                                        "$$hashKey": "object:2893"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Run Status at Arrival",
                                        "key": "ddlRunStatusatArrival",
                                        "placeholder": "",
                                        "data": {
                                            "values": [
                                                { "value": "1", "label": "Run", "$$hashKey": "object:3170" },
                                                { "value": "2", "label": "Stop", "$$hashKey": "object:3171" },
                                                { "value": "3", "label": "Restrictions", "$$hashKey": "object:3172" },
                                                { "value": "6", "label": "No power", "$$hashKey": "object:3173" },
                                                { "value": "7", "label": "Pause", "$$hashKey": "object:3174" },
                                                { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:3175" },
                                                { "value": "0", "label": "", "$$hashKey": "object:3176" }
                                            ],
                                            "json": "",
                                            "url": "",
                                            "resource": "",
                                            "custom": ""
                                        },
                                        "dataSrc": "values",
                                        "valueProperty": "",
                                        "defaultValue": "0",
                                        "refreshOn": "",
                                        "filter": "",
                                        "authenticate": false,
                                        "template": "<span>{{ item.label }}</span>",
                                        "multiple": false,
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": { "required": false },
                                        "type": "select",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "visible-roles": "Editor,GBXIRCreator" },
                                        "lockKey": true,
                                        "$$hashKey": "object:3156"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Failure date",
                                        "key": "dtFailuredate",
                                        "placeholder": "Failure date",
                                        "format": "dd-MM-yyyy",
                                        "enableDate": true,
                                        "enableTime": false,
                                        "defaultDate": "",
                                        "datepickerMode": "day",
                                        "datePicker":
                                        {
                                            "showWeeks": true,
                                            "startingDay": 0,
                                            "initDate": "",
                                            "minMode": "day",
                                            "maxMode": "year",
                                            "yearRows": 4,
                                            "yearColumns": 5,
                                            "datepickerMode": "day"
                                        },
                                        "timePicker":
                                        {
                                            "hourStep": 1,
                                            "minuteStep": 1,
                                            "showMeridian": true,
                                            "readonlyInput": false,
                                            "mousewheel": true,
                                            "arrowkeys": true
                                        },
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "custom":
                                                "valid = new Date(!data.dtInspectionDate || input <= new Date(data.dtInspectionDate)) ? true : 'Failure date should be prior than Inspection date'"
                                        },
                                        "type": "datetime",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "disable-roles": "Editor" },
                                        "lockKey": true,
                                        "customError": "missing ) after argument list",
                                        "$$hashKey": "object:5875"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Inspection Date",
                                        "key": "dtInspectionDate",
                                        "placeholder": "Inspection Date",
                                        "format": "dd-MM-yyyy",
                                        "enableDate": true,
                                        "enableTime": false,
                                        "defaultDate": "",
                                        "datepickerMode": "day",
                                        "datePicker":
                                        {
                                            "showWeeks": true,
                                            "startingDay": 0,
                                            "initDate": "",
                                            "minMode": "day",
                                            "maxMode": "year",
                                            "yearRows": 4,
                                            "yearColumns": 5,
                                            "datepickerMode": "day"
                                        },
                                        "timePicker":
                                        {
                                            "hourStep": 1,
                                            "minuteStep": 1,
                                            "showMeridian": true,
                                            "readonlyInput": false,
                                            "mousewheel": true,
                                            "arrowkeys": true
                                        },
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "custom":
                                                "valid =  !data.dtFailuredate || new Date(data.dtFailuredate) <= input ? true : 'Inspection date should be later or the same as Failure date'"
                                        },
                                        "type": "datetime",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "customError": "Inspection date should be later or the same as Failure date",
                                        "$$hashKey": "object:5609"
                                    },
                                    {
                                        "clearOnHide": false,
                                        "input": false,
                                        "key": "pageWTDTable",
                                        "numRows": 1,
                                        "numCols": 2,
                                        "rows": [
                                            [
                                                {
                                                    "components": [
                                                        {
                                                            "input": true,
                                                            "tableView": true,
                                                            "inputType": "text",
                                                            "inputMask": "",
                                                            "label": "Service order number",
                                                            "key": "txtServiceordernumber",
                                                            "placeholder": "",
                                                            "prefix": "",
                                                            "suffix": "",
                                                            "multiple": false,
                                                            "defaultValue": "",
                                                            "protected": false,
                                                            "unique": false,
                                                            "persistent": true,
                                                            "hidden": false,
                                                            "clearOnHide": true,
                                                            "validate": {
                                                                "required": false,
                                                                "minLength": "",
                                                                "maxLength": "",
                                                                "pattern": "",
                                                                "custom": "",
                                                                "customPrivate": false
                                                            },
                                                            "conditional": { "show": "", "when": null, "eq": "" },
                                                            "type": "textfield",
                                                            "tags": [],
                                                            "properties": { "": "" },
                                                            "lockKey": true,
                                                            "$$hashKey": "object:6157"
                                                        }
                                                    ],
                                                    "$$hashKey": "object:6147"
                                                },
                                                {
                                                    "components": [
                                                        {
                                                            "input": true,
                                                            "tableView": true,
                                                            "label": "",
                                                            "key": "ddlServiceReportNumberType",
                                                            "placeholder": "",
                                                            "data": {
                                                                "values": [
                                                                    {
                                                                        "value": "3",
                                                                        "label": "N/A",
                                                                        "$$hashKey": "object:6179"
                                                                    },
                                                                    {
                                                                        "value": "1",
                                                                        "label": "ECR",
                                                                        "$$hashKey": "object:6180"
                                                                    },
                                                                    {
                                                                        "value": "4",
                                                                        "label": "MAM/SAP",
                                                                        "$$hashKey": "object:6181"
                                                                    },
                                                                    {
                                                                        "value": "2",
                                                                        "label": "VSS",
                                                                        "$$hashKey": "object:6182"
                                                                    }
                                                                ],
                                                                "json": "",
                                                                "url": "",
                                                                "resource": "",
                                                                "custom": ""
                                                            },
                                                            "dataSrc": "values",
                                                            "valueProperty": "",
                                                            "defaultValue": "4",
                                                            "refreshOn": "",
                                                            "filter": "",
                                                            "authenticate": false,
                                                            "template": "<span>{{ item.label }}</span>",
                                                            "multiple": false,
                                                            "protected": false,
                                                            "unique": false,
                                                            "persistent": true,
                                                            "hidden": false,
                                                            "clearOnHide": true,
                                                            "validate": { "required": false },
                                                            "type": "select",
                                                            "tags": [],
                                                            "conditional": { "show": "", "when": null, "eq": "" },
                                                            "properties": { "": "" },
                                                            "lockKey": true,
                                                            "style": { "margin-top": "23px" },
                                                            "$$hashKey": "object:6161"
                                                        }
                                                    ],
                                                    "$$hashKey": "object:6148"
                                                }
                                            ]
                                        ],
                                        "header": [],
                                        "caption": "",
                                        "striped": false,
                                        "bordered": false,
                                        "hover": false,
                                        "condensed": false,
                                        "tableView": false,
                                        "type": "table",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": [],
                                        "style": { "margin-bottom": "-20px" },
                                        "$$hashKey": "object:6140"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "SAP Notification",
                                        "key": "txtSAPNotification",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "disabled": false,
                                        "lockKey": true,
                                        "$$hashKey": "object:6924"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Run (hrs)",
                                        "key": "txtRunhrs",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:6441"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Generator 1 (hrs)",
                                        "key": "txtGenerator1hrs",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:4262"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Generator 2 (hrs)",
                                        "key": "txtGenerator2hrs",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:4525"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Total production (kWh)",
                                        "key": "txtTotalproductionkWh",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:4788"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Run status after inspection",
                                        "key": "ddlRunstatusafterinspection",
                                        "placeholder": "Run status after inspection",
                                        "data": {
                                            "values": [
                                                { "value": "1", "label": "Run", "$$hashKey": "object:7197" },
                                                { "value": "2", "label": "Stop", "$$hashKey": "object:7198" },
                                                { "value": "3", "label": "Restrictions", "$$hashKey": "object:7199" },
                                                { "value": "6", "label": "No power", "$$hashKey": "object:7200" },
                                                { "value": "7", "label": "Pause", "$$hashKey": "object:7201" },
                                                { "value": "8", "label": "Emergency Stop", "$$hashKey": "object:7202" },
                                                { "value": "0", "label": "", "$$hashKey": "object:7203" }
                                            ],
                                            "json": "",
                                            "url": "",
                                            "resource": "",
                                            "custom": ""
                                        },
                                        "dataSrc": "values",
                                        "valueProperty": "",
                                        "defaultValue": "0",
                                        "refreshOn": "",
                                        "filter": "",
                                        "authenticate": false,
                                        "template": "<span>{{ item.label }}</span>",
                                        "multiple": false,
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": { "required": false },
                                        "type": "select",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:7183"
                                    }
                                ],
                                "type": "panel",
                                "breadcrumb": "default",
                                "$$hashKey": "object:1220",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" },
                                "customClass": "expandable-panel"
                            },
                            {
                                "clearOnHide": false,
                                "key": "undefinedPanel",
                                "input": false,
                                "title": "Other fields",
                                "theme": "default",
                                "tableView": false,
                                "components": [
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Quantity of failed components/problems",
                                        "key": "txtQuantityoffailedcomponentsproblems",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "hide-roles": "Visitor" },
                                        "lockKey": true,
                                        "$$hashKey": "object:2214"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Description",
                                        "key": "txtDescription",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:2477"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Description (of activity)",
                                        "key": "txtDescriptionofactivity",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:2740"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Up-Tower Solution Available",
                                        "key": "ddlUpTowerSolutionAvailable",
                                        "description": "Toggle Button",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "type": "ToggleButton",
                                        "tags": [],
                                        "properties": { "disable-roles": "Editor" },
                                        "lockKey": true,
                                        "validate": { "required": false },
                                        "input": true,
                                        "$$hashKey": "object:3003",
                                        "conditional": { "show": "", "when": null, "eq": "" }
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Description of Any Consequential Problems/Damage",
                                        "key": "txtDescriptionofAnyConsequentialProblemsDamage",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:3263"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "SBU Recommendation",
                                        "key": "txtSBURecommendation",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:3526"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "number",
                                        "label": "Alarm Log Number",
                                        "key": "txtAlarmLogNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "min": "",
                                            "max": "",
                                            "step": "any",
                                            "integer": "",
                                            "multiple": "",
                                            "custom": ""
                                        },
                                        "type": "number",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:3789"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Vestas Confidential Comments",
                                        "key": "txtInternalComments",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "rows": 3,
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "wysiwyg": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": ""
                                        },
                                        "type": "textarea",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:4053"
                                    }
                                ],
                                "type": "panel",
                                "breadcrumb": "default",
                                "$$hashKey": "object:1593",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" },
                                "customClass": "expandable-panel"
                            },
                            {
                                "clearOnHide": false,
                                "input": false,
                                "tableView": false,
                                "key": "undefinedColumns",
                                "columns": [
                                    {
                                        "components": [
                                            {
                                                "tableView": true,
                                                "key": "undefinedColumnsCirNavigation",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "type": "cirNavigation",
                                                "$$hashKey": "object:13424"
                                            }
                                        ],
                                        "width": 4,
                                        "offset": 0,
                                        "push": 0,
                                        "pull": 0,
                                        "$$hashKey": "object:13415"
                                    },
                                    {
                                        "components": [
                                            {
                                                "tableView": true,
                                                "key": "undefinedColumnsSubmitForm",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "type": "submitForm",
                                                "isNew": true,
                                                "$$hashKey": "object:1028"
                                            }
                                        ],
                                        "width": 8,
                                        "offset": 0,
                                        "push": 0,
                                        "pull": 0,
                                        "$$hashKey": "object:13417"
                                    }
                                ],
                                "type": "columns",
                                "$$hashKey": "object:13144",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" }
                            }
                        ],
                        "$$hashKey": "object:20",
                        "clearOnHide": false,
                        "tableView": false
                    },
                    {
                        "type": "panel",
                        "title": "Blade",
                        "components": [
                            {
                                "clearOnHide": false,
                                "key": "page4Panel",
                                "input": false,
                                "title": "Blade Data",
                                "theme": "default",
                                "tableView": false,
                                "components": [
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Blade Item Number",
                                        "key": "txtBladeItemNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "",
                                        "lockKey": true,
                                        "$$hashKey": "object:7051"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Blade Serial Number",
                                        "key": "txtBladeSerialNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate":
                                        {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip":
                                            "Is either a 4-6 digit number. i.e. 2354 or 35854 If the whole batch number is noted it is a 6 digit number-warehouse letter and a 4-6 digit number. i.e. 761003WHBY35964\n <br /><b>\nOld NEGMicon blades: </b>\nA 4 digit number\n <br /><b>\nLM blades: </b>\nA letter followed by a number. i.e. E-1234",
                                        "lockKey": true,
                                        "$$hashKey": "object:7362"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Reason, if No Blade ID",
                                        "key": "txtReasonifNoBladeID",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "",
                                        "lockKey": true,
                                        "$$hashKey": "object:7675"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Blade Length (m)",
                                        "key": "ddlBladeLength",
                                        "description": "",
                                        "uploadLink": "",
                                        "downloadLink": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "input": true,
                                        "type": "dynamicDropdown",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "dataSrc": "file",
                                        "template": "<span>{{ item.label }}</span>",
                                        "data": {
                                            "values": [
                                                { "value": "29", "label": "N/A", "$$hashKey": "object:12218" },
                                                { "value": "30", "label": "10.5", "$$hashKey": "object:12219" },
                                                { "value": "31", "label": "11.5", "$$hashKey": "object:12220" },
                                                { "value": "32", "label": "13", "$$hashKey": "object:12221" },
                                                { "value": "33", "label": "17", "$$hashKey": "object:12222" },
                                                { "value": "34", "label": "19", "$$hashKey": "object:12223" },
                                                { "value": "1", "label": "20.5", "$$hashKey": "object:12224" },
                                                { "value": "2", "label": "23", "$$hashKey": "object:12225" },
                                                { "value": "3", "label": "25", "$$hashKey": "object:12226" },
                                                { "value": "4", "label": "32", "$$hashKey": "object:12227" },
                                                { "value": "5", "label": "39", "$$hashKey": "object:12228" },
                                                { "value": "6", "label": "44", "$$hashKey": "object:12229" },
                                                { "value": "7", "label": "49", "$$hashKey": "object:12230" },
                                                { "value": "37", "label": "51", "$$hashKey": "object:12231" },
                                                { "value": "38", "label": "54", "$$hashKey": "object:12232" },
                                                { "value": "36", "label": "55", "$$hashKey": "object:12233" },
                                                { "value": "39", "label": "62", "$$hashKey": "object:12234" },
                                                { "value": "40", "label": "67", "$$hashKey": "object:12235" },
                                                { "value": "8", "label": "AL23,8", "$$hashKey": "object:12236" },
                                                { "value": "9", "label": "AL26,8", "$$hashKey": "object:12237" },
                                                { "value": "10", "label": "AL31,8", "$$hashKey": "object:12238" },
                                                { "value": "11", "label": "AL35,8", "$$hashKey": "object:12239" },
                                                { "value": "12", "label": "AL40,8", "$$hashKey": "object:12240" },
                                                { "value": "13", "label": "LM19,1", "$$hashKey": "object:12241" },
                                                { "value": "14", "label": "LM21,5", "$$hashKey": "object:12242" },
                                                { "value": "15", "label": "LM23,2", "$$hashKey": "object:12243" },
                                                { "value": "16", "label": "LM23,5", "$$hashKey": "object:12244" },
                                                { "value": "17", "label": "LM25,2", "$$hashKey": "object:12245" },
                                                { "value": "18", "label": "LM25,5", "$$hashKey": "object:12246" },
                                                { "value": "19", "label": "LM26,0", "$$hashKey": "object:12247" },
                                                { "value": "20", "label": "LM26,1", "$$hashKey": "object:12248" },
                                                { "value": "21", "label": "LM29,0", "$$hashKey": "object:12249" },
                                                { "value": "22", "label": "LM29,1", "$$hashKey": "object:12250" },
                                                { "value": "23", "label": "LM31,2", "$$hashKey": "object:12251" },
                                                { "value": "24", "label": "LM35,0", "$$hashKey": "object:12252" },
                                                { "value": "25", "label": "LM35.0 P2", "$$hashKey": "object:12253" },
                                                { "value": "26", "label": "LM38,8", "$$hashKey": "object:12254" },
                                                { "value": "35", "label": "LM40,1", "$$hashKey": "object:12255" },
                                                { "value": "27", "label": "LM44,8", "$$hashKey": "object:12256" },
                                                { "value": "28", "label": "LM54,0", "$$hashKey": "object:12257" }
                                            ]
                                        },
                                        "validate": { "required": true },
                                        "lockKey": true,
                                        "placeholder": "Blade Length (m)",
                                        "$$hashKey": "object:12204"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Blade Manufacturer",
                                        "key": "ddlBladeManufacturer",
                                        "description": "",
                                        "uploadLink": "",
                                        "downloadLink": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "input": true,
                                        "type": "dynamicDropdown",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "validate": { "required": true },
                                        "dataSrc": "file",
                                        "template": "<span>{{ item.label }}</span>",
                                        "data": {
                                            "values": [
                                                { "value": "1", "label": "LM Wind Power", "$$hashKey": "object:12606" },
                                                { "value": "2", "label": "Vestas Blades", "$$hashKey": "object:12607" },
                                                {
                                                    "value": "3",
                                                    "label": "AL – AeroLaminates",
                                                    "$$hashKey": "object:12608"
                                                }
                                            ]
                                        },
                                        "placeholder": "Blade Manufacturer",
                                        "$$hashKey": "object:12592"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Blade Color",
                                        "key": "ddlBladeColor",
                                        "description": "",
                                        "uploadLink": "",
                                        "downloadLink": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "input": true,
                                        "type": "dynamicDropdown",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "dataSrc": "file",
                                        "template": "<span>{{ item.label }}</span>",
                                        "data": {
                                            "values": [
                                                {
                                                    "value": "1",
                                                    "label": "Ral 7035 Light Gray",
                                                    "$$hashKey": "object:12921"
                                                },
                                                { "value": "2", "label": "Ral 7040 Gray", "$$hashKey": "object:12922" },
                                                {
                                                    "value": "3",
                                                    "label": "Ral 9010 White",
                                                    "$$hashKey": "object:12923"
                                                }, { "value": "4", "label": "N/A", "$$hashKey": "object:12924" },
                                                {
                                                    "value": "5",
                                                    "label": "Ral 7040 Gray / Ral 3020 Red Tip",
                                                    "$$hashKey": "object:12925"
                                                },
                                                {
                                                    "value": "6",
                                                    "label": "Ral 7035 Light Gray / Ral 3020 Red Stripes",
                                                    "$$hashKey": "object:12926"
                                                },
                                                {
                                                    "value": "7",
                                                    "label": "Ral 7040 Gray / Ral 3020 Red Stripes",
                                                    "$$hashKey": "object:12927"
                                                },
                                                {
                                                    "value": "8",
                                                    "label": "Ral 7035 Light Gray / Ral 3020 Red Tip",
                                                    "$$hashKey": "object:12928"
                                                },
                                                {
                                                    "value": "9",
                                                    "label": "Ral 9010 White / Ral 2009 Orange Stripes",
                                                    "$$hashKey": "object:12929"
                                                },
                                                {
                                                    "value": "10",
                                                    "label": "Ral 9010 White / Ral 2009 Orange Tip",
                                                    "$$hashKey": "object:12930"
                                                },
                                                {
                                                    "value": "11",
                                                    "label": "Ral 9010 White / Ral 3020 Red Stripes",
                                                    "$$hashKey": "object:12931"
                                                },
                                                {
                                                    "value": "12",
                                                    "label": "Ral 9010 White / Ral 3020 Red Tip",
                                                    "$$hashKey": "object:12932"
                                                }
                                            ]
                                        },
                                        "validate": { "required": true },
                                        "lockKey": true,
                                        "placeholder": "Blade Color",
                                        "$$hashKey": "object:12907"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Damage Identified",
                                        "key": "chkDamageIdentified",
                                        "description": "Toggle Button",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "type": "ToggleButton",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "validate": { "required": true },
                                        "lockKey": true,
                                        "input": true,
                                        "$$hashKey": "object:13239"
                                    },
                                    {
                                        "tableView": true,
                                        "label": "Overall Blade Condition",
                                        "key": "ddlOverallBladeCondition",
                                        "description": "Drag files here or click to upload",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "type": "customSlider",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "input": true,
                                        "$$hashKey": "object:13542"
                                    }
                                ],
                                "type": "panel",
                                "breadcrumb": "default",
                                "$$hashKey": "object:1896",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" },
                                "customClass": "expandable-panel"
                            },
                            {
                                "clearOnHide": false,
                                "key": "page4Panel2",
                                "input": false,
                                "title": "Blade/Retrofit Data",
                                "theme": "default",
                                "tableView": false,
                                "components": [
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Ambient Temperature (˚C)",
                                        "key": "txtAmbientTemperature",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "Ambient Temperature (˚C)",
                                        "lockKey": true,
                                        "$$hashKey": "object:5781"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Humidity (%)",
                                        "key": "txtHumidity",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "Humidity (%)",
                                        "lockKey": true,
                                        "$$hashKey": "object:6089"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Blade Surface Temperature During Repair (˚C)",
                                        "key": "txtBladeSurfaceTemperatureDuringRepair",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "Blade Surface Temperature During Repair (˚C)",
                                        "lockKey": true,
                                        "$$hashKey": "object:6397"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Total Cure Time",
                                        "key": "txtTotalCureTime",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": true,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "Total Cure Time",
                                        "lockKey": true,
                                        "$$hashKey": "object:6705"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "VT Number",
                                        "key": "txtVTNumber",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "VT Number",
                                        "lockKey": true,
                                        "$$hashKey": "object:7013"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "label": "Calibration Date",
                                        "key": "dtCalibrationDate",
                                        "placeholder": "Calibration Date",
                                        "format": "yyyy-MM-dd hh:mm",
                                        "enableDate": true,
                                        "enableTime": false,
                                        "defaultDate": "",
                                        "datepickerMode": "day",
                                        "datePicker":
                                        {
                                            "showWeeks": true,
                                            "startingDay": 0,
                                            "initDate": "",
                                            "minMode": "day",
                                            "maxMode": "year",
                                            "yearRows": 4,
                                            "yearColumns": 5,
                                            "datepickerMode": "day"
                                        },
                                        "timePicker": {
                                            "hourStep": 1,
                                            "minuteStep": 1,
                                            "showMeridian": true,
                                            "readonlyInput": false,
                                            "mousewheel": true,
                                            "arrowkeys": true
                                        },
                                        "protected": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": { "required": false, "custom": "" },
                                        "type": "datetime",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:8657"
                                    },
                                    {
                                        "input": true,
                                        "tableView": true,
                                        "inputType": "text",
                                        "inputMask": "",
                                        "label": "Additional Document Reference",
                                        "key": "txtAdditionalDocumentReference",
                                        "placeholder": "",
                                        "prefix": "",
                                        "suffix": "",
                                        "multiple": false,
                                        "defaultValue": "",
                                        "protected": false,
                                        "unique": false,
                                        "persistent": true,
                                        "hidden": false,
                                        "clearOnHide": true,
                                        "validate": {
                                            "required": false,
                                            "minLength": "",
                                            "maxLength": "",
                                            "pattern": "",
                                            "custom": "",
                                            "customPrivate": false
                                        },
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "type": "textfield",
                                        "tags": [],
                                        "properties": { "": "" },
                                        "description": "",
                                        "tooltip": "Additional Document Reference",
                                        "lockKey": true,
                                        "$$hashKey": "object:7321"
                                    },
                                    {
                                        "clearOnHide": false,
                                        "key": "page4FieldsetFieldset2",
                                        "input": false,
                                        "tableView": false,
                                        "legend": "Resin Data",
                                        "components": [
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Resin Type",
                                                "key": "txtResinType",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Resin Type",
                                                "lockKey": true,
                                                "$$hashKey": "object:7640"
                                            },
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Resin Type Batch Number(s)",
                                                "key": "txtResinTypeBatchNumbers",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Resin Type Batch Number(s)",
                                                "lockKey": true,
                                                "$$hashKey": "object:7641"
                                            },
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "label": "Resin Type Expiry Date",
                                                "key": "dtResinTypeExpiryDate",
                                                "placeholder": "Resin Type Expiry Date",
                                                "format": "yyyy-MM-dd hh:mm",
                                                "enableDate": true,
                                                "enableTime": false,
                                                "defaultDate": "",
                                                "datepickerMode": "day",
                                                "datePicker":
                                                {
                                                    "showWeeks": true,
                                                    "startingDay": 0,
                                                    "initDate": "",
                                                    "minMode": "day",
                                                    "maxMode": "year",
                                                    "yearRows": 4,
                                                    "yearColumns": 5,
                                                    "datepickerMode": "day"
                                                },
                                                "timePicker":
                                                {
                                                    "hourStep": 1,
                                                    "minuteStep": 1,
                                                    "showMeridian": true,
                                                    "readonlyInput": false,
                                                    "mousewheel": true,
                                                    "arrowkeys": true
                                                },
                                                "protected": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": { "required": false, "custom": "" },
                                                "type": "datetime",
                                                "tags": [],
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "properties": { "": "" },
                                                "lockKey": true,
                                                "$$hashKey": "object:7642"
                                            }
                                        ],
                                        "type": "fieldset",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "$$hashKey": "object:7629"
                                    },
                                    {
                                        "clearOnHide": false,
                                        "key": "fsHardenerData",
                                        "input": false,
                                        "tableView": false,
                                        "legend": "Hardener Data",
                                        "components": [
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Hardener Type",
                                                "key": "txtHardenerType",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Hardener Type",
                                                "lockKey": true,
                                                "$$hashKey": "object:7987"
                                            },
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Hardener Type Batch Number(s)",
                                                "key": "txtHardenerTypeBatchNumbers",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Hardener Type Batch Number(s)",
                                                "lockKey": true,
                                                "$$hashKey": "object:7988"
                                            },
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "label": "Hardener Type Expiry Date",
                                                "key": "dtHardenerTypeExpiryDate",
                                                "placeholder": "Hardener Type Expiry Date",
                                                "format": "yyyy-MM-dd hh:mm",
                                                "enableDate": true,
                                                "enableTime": false,
                                                "defaultDate": "",
                                                "datepickerMode": "day",
                                                "datePicker":
                                                {
                                                    "showWeeks": true,
                                                    "startingDay": 0,
                                                    "initDate": "",
                                                    "minMode": "day",
                                                    "maxMode": "year",
                                                    "yearRows": 4,
                                                    "yearColumns": 5,
                                                    "datepickerMode": "day"
                                                },
                                                "timePicker":
                                                {
                                                    "hourStep": 1,
                                                    "minuteStep": 1,
                                                    "showMeridian": true,
                                                    "readonlyInput": false,
                                                    "mousewheel": true,
                                                    "arrowkeys": true
                                                },
                                                "protected": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": { "required": false, "custom": "" },
                                                "type": "datetime",
                                                "tags": [],
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "properties": { "": "" },
                                                "lockKey": true,
                                                "$$hashKey": "object:7989"
                                            }
                                        ],
                                        "type": "fieldset",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:7976"
                                    },
                                    {
                                        "clearOnHide": false,
                                        "key": "fsGlassData",
                                        "input": false,
                                        "tableView": false,
                                        "legend": "Glass Data",
                                        "components": [
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Glass Supplier",
                                                "key": "txtGlassSupplier",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Glass Supplier",
                                                "lockKey": true,
                                                "$$hashKey": "object:8334"
                                            },
                                            {
                                                "input": true,
                                                "tableView": true,
                                                "inputType": "text",
                                                "inputMask": "",
                                                "label": "Glass Supplier Batch Number(s)",
                                                "key": "txtGlassSupplierBatchNumbers",
                                                "placeholder": "",
                                                "prefix": "",
                                                "suffix": "",
                                                "multiple": false,
                                                "defaultValue": "",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "hidden": false,
                                                "clearOnHide": true,
                                                "validate": {
                                                    "required": false,
                                                    "minLength": "",
                                                    "maxLength": "",
                                                    "pattern": "",
                                                    "custom": "",
                                                    "customPrivate": false
                                                },
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "type": "textfield",
                                                "tags": [],
                                                "properties": { "": "" },
                                                "description": "",
                                                "tooltip": "Glass Supplier Batch Number(s)",
                                                "lockKey": true,
                                                "$$hashKey": "object:8335"
                                            }
                                        ],
                                        "type": "fieldset",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:8323"
                                    }
                                ],
                                "type": "panel",
                                "breadcrumb": "default",
                                "$$hashKey": "object:5129",
                                "tags": [],
                                "conditional": { "show": "true", "when": "rbReportType", "eq": "3 || 4" },
                                "properties": { "": "" },
                                "customClass": "expandable-panel",
                                "customConditional": "show  = (data['rbReportType'] ==3 ||data['rbReportType'] ==5)"
                            },
                            {
                                "clearOnHide": false,
                                "key": "page4Panel3",
                                "input": false,
                                "title": "LPS Receptor Inspection (optional)",
                                "theme": "default",
                                "tableView": false,
                                "components": [
                                    {
                                        "clearOnHide": false,
                                        "key": "fsReceptorLeewardsSide",
                                        "input": false,
                                        "tableView": false,
                                        "legend": "Receptor Leeward`s Side",
                                        "components": [
                                            {
                                                "clearOnHide": false,
                                                "input": false,
                                                "key": "fsReceptorLeewardsSideTable",
                                                "numRows": 9,
                                                "numCols": 3,
                                                "rows": [
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Tip",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "customClass": "",
                                                                    "$$hashKey": "object:5965"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5880"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml2",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Pre-repair",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:5969"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5881"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml3",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Post-repair",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:5973"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5882"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml4",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "1",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:5977"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5886"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue1",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:5981"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5887"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue1",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:5985"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5888"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "2",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:5989"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5892"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue2",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:5993"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5893"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue2",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:5997"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5894"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml7",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "3",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6001"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5898"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue3",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6005"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5899"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue3",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6009"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5900"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml6",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "4",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6013"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5904"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue4",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6017"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5905"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue4",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6021"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5906"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml5",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "5",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6025"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5910"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue5",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6029"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5911"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue5",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6033"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5912"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml4",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "6",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6037"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5916"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue6",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6041"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5917"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue6",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6045"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5918"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml3",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "7",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6049"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5922"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue7",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6053"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5923"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue7",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6057"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5924"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml2",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "8",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6061"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5928"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPreTypeValue8",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6065"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5929"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPLeewardPostTypeValue8",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6069"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:5930"
                                                        }
                                                    ]
                                                ],
                                                "header": [],
                                                "caption": "",
                                                "striped": false,
                                                "bordered": false,
                                                "hover": false,
                                                "condensed": false,
                                                "tableView": true,
                                                "type": "table",
                                                "tags": [],
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "properties": { "": "" },
                                                "$$hashKey": "object:5857"
                                            }
                                        ],
                                        "type": "fieldset",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:5846"
                                    },
                                    {
                                        "clearOnHide": false,
                                        "key": "fsReceptorLeewardsSide2",
                                        "input": false,
                                        "tableView": false,
                                        "legend": "Receptor Windward`s Side",
                                        "components": [
                                            {
                                                "clearOnHide": false,
                                                "input": false,
                                                "key": "fsReceptorLeewardsSideTable2",
                                                "numRows": 6,
                                                "numCols": 3,
                                                "rows": [
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml5",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Tip",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "customClass": "",
                                                                    "$$hashKey": "object:6632"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6574"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml6",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Pre-repair",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6636"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6575"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml7",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "Post-repair",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6640"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6576"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsReceptorLeewardsSideTableHtml8",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "1",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6644"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6580"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPreTypeValue1",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6648"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6581"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPostTypeValue1",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6652"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6582"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml8",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "2",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6656"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6586"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPreTypeValue2",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6660"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6587"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPostTypeValue2",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6664"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6588"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml9",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "3",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6668"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6592"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPreTypeValue3",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6672"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6593"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPostTypeValue3",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6676"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6594"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml10",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "4",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6680"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6598"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPreTypeValue4",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6684"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6599"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPostTypeValue4",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6688"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6600"
                                                        }
                                                    ],
                                                    [
                                                        {
                                                            "components": [
                                                                {
                                                                    "key": "fsGlassDataHtml11",
                                                                    "input": false,
                                                                    "tag": "p",
                                                                    "attrs": [{ "value": "", "attr": "" }],
                                                                    "className": "",
                                                                    "content": "5",
                                                                    "type": "htmlelement",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "$$hashKey": "object:6692"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6604"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPreTypeValue5",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6696"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6605"
                                                        },
                                                        {
                                                            "components": [
                                                                {
                                                                    "input": true,
                                                                    "tableView": true,
                                                                    "inputType": "number",
                                                                    "label": "",
                                                                    "key": "txtLSPWindwardPostTypeValue5",
                                                                    "placeholder": "Type value (m Ohm)",
                                                                    "prefix": "",
                                                                    "suffix": "",
                                                                    "defaultValue": "",
                                                                    "protected": false,
                                                                    "persistent": true,
                                                                    "hidden": false,
                                                                    "clearOnHide": true,
                                                                    "validate": {
                                                                        "required": false,
                                                                        "min": "",
                                                                        "max": "",
                                                                        "step": "any",
                                                                        "integer": "",
                                                                        "multiple": "",
                                                                        "custom": ""
                                                                    },
                                                                    "type": "number",
                                                                    "tags": [],
                                                                    "conditional": {
                                                                        "show": "",
                                                                        "when": null,
                                                                        "eq": ""
                                                                    },
                                                                    "properties": { "": "" },
                                                                    "lockKey": true,
                                                                    "$$hashKey": "object:6700"
                                                                }
                                                            ],
                                                            "$$hashKey": "object:6606"
                                                        }
                                                    ]
                                                ],
                                                "header": [],
                                                "caption": "",
                                                "striped": false,
                                                "bordered": false,
                                                "hover": false,
                                                "condensed": false,
                                                "tableView": true,
                                                "type": "table",
                                                "tags": [],
                                                "conditional": { "show": "", "when": null, "eq": "" },
                                                "properties": { "": "" },
                                                "$$hashKey": "object:6557"
                                            }
                                        ],
                                        "type": "fieldset",
                                        "tags": [],
                                        "conditional": { "show": "", "when": null, "eq": "" },
                                        "properties": { "": "" },
                                        "lockKey": true,
                                        "$$hashKey": "object:6546"
                                    }
                                ],
                                "type": "panel",
                                "breadcrumb": "default",
                                "$$hashKey": "object:3816",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" },
                                "customClass": "expandable-panel"
                            },
                            {
                                "clearOnHide": false,
                                "input": false,
                                "tableView": false,
                                "key": "page4FieldsetColumns",
                                "columns": [
                                    {
                                        "components": [],
                                        "width": 4,
                                        "offset": 0,
                                        "push": 0,
                                        "pull": 0,
                                        "$$hashKey": "object:8870"
                                    },
                                    {
                                        "components": [
                                            {
                                                "tableView": true,
                                                "key": "page4FieldsetColumnsSubmitForm2",
                                                "protected": false,
                                                "unique": false,
                                                "persistent": true,
                                                "type": "submitForm",
                                                "$$hashKey": "object:8881"
                                            }
                                        ],
                                        "width": 8,
                                        "offset": 0,
                                        "push": 0,
                                        "pull": 0,
                                        "$$hashKey": "object:8871"
                                    }
                                ],
                                "type": "columns",
                                "tags": [],
                                "conditional": { "show": "", "when": null, "eq": "" },
                                "properties": { "": "" },
                                "$$hashKey": "object:8865"
                            },
                            {
                                "tableView": true,
                                "key": "page4FieldsetColumnsCirNavigation2",
                                "protected": false,
                                "unique": false,
                                "persistent": true,
                                "type": "cirNavigation",
                                "$$hashKey": "object:8560"
                            }
                        ],
                        "input": false,
                        "key": "page4",
                        "$$hashKey": "object:10417",
                        "clearOnHide": false,
                        "theme": "default",
                        "tableView": false,
                        "breadcrumb": "default",
                        "tags": [],
                        "conditional": { "show": "", "when": null, "eq": "" },
                        "properties": { "": "" }
                    },
                    {
                        "type": "panel",
                        "title": "Submit",
                        "components": [
                            {
                                "tableView": true,
                                "key": "page3SubmitBladeForm",
                                "protected": false,
                                "unique": false,
                                "persistent": true,
                                "type": "submitBladeForm",
                                "isNew": true,
                                "$$hashKey": "object:3367"
                            }
                        ],
                        "input": false,
                        "key": "page3",
                        "$$hashKey": "object:3000",
                        "clearOnHide": false,
                        "theme": "default",
                        "tableView": false,
                        "breadcrumb": "default",
                        "tags": [],
                        "conditional": { "show": "", "when": null, "eq": "" },
                        "properties": { "": "" }
                    }
                ],
                "display": "wizard",
                "page": 0,
                "numPages": 3
            };*/

            // $rootScope.form = {
            //     components: [
            //         {
            //             type: 'textfield',
            //             label: 'Title',
            //             placeholder: 'Enter the title.',
            //             key: 'title',
            //             input: true,
            //             inputType: 'text'
            //         },
            //         {
            //             type: 'textarea',
            //             label: 'Content',
            //             placeholder: 'Enter content here',
            //             wysiwyg: true,
            //             key: 'content',
            //             input: true,
            //             inputType: 'text'
            //         },
            //         {
            //             type: 'button',
            //             action: 'submit',
            //             label: 'Submit',
            //             theme: 'primary',
            //             key: 'submit'
            //         }
            //     ],
            //     "display": "form",
            //     "page": 0
            // };
            $rootScope.renderForm = true;

            $rootScope.saveJSON = function () {
                console.log($rootScope.form);
            };

            $rootScope.$on('formUpdate', function (event, form) {
                angular.merge($rootScope.form, form);
                $rootScope.renderForm = false;
                setTimeout(function () {
                    $rootScope.renderForm = true;
                    window.console.log(JSON.stringify($rootScope.form));
                }, 10);
            });
            var originalComps = _.cloneDeep($rootScope.form.components);
            originalComps.push(angular.copy(formioComponents.components.button.settings));
            $rootScope.jsonCollapsed = true;
            $timeout(function () {
                $rootScope.jsonCollapsed = false;
            }, 200);
            var currentDisplay = 'form';
            $rootScope.$on('formLoad',
                function (form) {
                    materialUiInit.initStyles();
                });

            $rootScope.$watch('form.page',
                function (page) {
                    materialUiInit.initStyles();
                });
            $rootScope.$watch('form.display', function (display) {
                if (display && (display !== currentDisplay)) {
                    currentDisplay = display;
                    if (display === 'form') {
                        $rootScope.form.components = originalComps;
                    } else {
                        //these lines commented since they are broke the form in builder. 
                        //Need further investigation regarding necessity of these part of code. 
                        //$rootScope.form.components = [{
                        //    type: 'panel',
                        //    input: false,
                        //    title: 'Page 1',
                        //    theme: 'default',
                        //    components: originalComps
                        //}];
                    }
                }
            });
        }
    ]);