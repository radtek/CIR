//_State variable Added By Siddharth Chauhan on 06-06-2016. Added _state parameter.
//to filter the CIR Remote records(UnApproved,Accepted,Rejected). 
//TaskNo. : 75297 
var _state = 0;


//Added by Siddharth Chauhan on 20-06-2016.
// To show the Actions items in Remote CIR Search List.                                        
//Task No. 75299
var _stateRemote = 1;
var _progressRemote = 1;
var _cirDataIDRemote = 0;
var _processRemote = 0;
var _pdfdataRemote = "";
var loadingRemote = 0;
var _CurrentRemotePage = 1;
var _RecordsPerPage = 50;
var _RemoteDataTable = null;
var _LazyLoading = 0;
var _cirId = 0;
var resultdata = [];

var cirOfflineAppSearch = new function () {
    this.loadCirTypes = function () {
        dbtransaction.getItemfromTable('ComponentInspectionReportType', renderReportTypes);
        //Rendring items in list
        function renderReportTypes(reportTypes) {
            reportTypes.forEach(function (item) {
                $('#ddlSearchCirType').append($('<option>', {
                    value: item.ComponentInspectionReportTypeID,
                    text: item.text
                }));
            });

            //Added by Siddharth Chauhan on 02-06-2016
            //To retain the values in the search criteria fields after cliking on search icon.
            //Task No. : 75294
            var searchCirType = getQueryStringValueHash("CirType");
            $('#ddlSearchCirType').val((searchCirType && searchCirType != '0') ? searchCirType : "0");

            if ($('#ddlSearchCirType').val() != null && $('#ddlSearchCirType').val().trim() != "0") {
                $('#ddlSearchCirType').addClass('bold').css("font-weight", "bold");
            }
            else {
                $('#ddlSearchCirType').removeClass('bold');
            }

        }
    }
    this.loadReportTypes = function () {
        dbtransaction.getItemfromTable('ReportType', renderReportTypes);
        //Rendring items in list
        function renderReportTypes(reportTypes) {
            reportTypes.forEach(function (item) {
                $('#ddlSearchReportType').append($('<option>', {
                    value: item.ReportTypeID,
                    text: item.text
                }));
            });

            //Added by Siddharth Chauhan on 02-06-2016
            //To retain the values in the search criteria fields after cliking on search icon.
            //Task No. : 75294
            var searchReportType = getQueryStringValueHash("ReportType");
            $('#ddlSearchReportType').val((searchReportType && searchReportType != '0') ? searchReportType : "0");
            if ($('#ddlSearchReportType').val() != null && $('#ddlSearchReportType').val().trim() != "0") {
                $('#ddlSearchReportType').addClass('bold').css("font-weight", "bold");
            }
            else {
                $('#ddlSearchReportType').removeClass('bold');
            }
        }
    }
    this.loadTurbineRunStatus = function () {
        dbtransaction.getItemfromTable('TurbineRunStatus', renderTurbineRunStatus);
        //Rendring items in list
        function renderTurbineRunStatus(turbineRunStatus) {
            turbineRunStatus.forEach(function (item) {
                $('#ddlSearchRunStatus').append($('<option>', {
                    value: item.TurbineRunStatusID,
                    text: item.text
                }));
            });

            //Added by Siddharth Chauhan on 02-06-2016
            //To retain the values in the search criteria fields after cliking on search icon.
            //Task No. : 75294
            var searchRunStatus = getQueryStringValueHash("RunStatus");
            $('#ddlSearchRunStatus').val((searchRunStatus != null && searchRunStatus != '0') ? searchRunStatus : "0");
            if ($('#ddlSearchRunStatus').val() != null && $('#ddlSearchRunStatus').val().trim() != "0") {
                $('#ddlSearchRunStatus').addClass('bold').css("font-weight", "bold");
            }
            else {
                $('#ddlSearchRunStatus').removeClass('bold');
            }
        }
    }
    var displayText = '';
    var _CIRType = [
                "- Component Type -",
                "Blade",
                "Gearbox",
                "General",
                "Generator",
                "Transformer",
                "Main Bearing",
                "Skiipack",
                "Simplified CIR"
    ];
    var _ReportType = [
                "- Report Type -",
                "Inspection",
                "Failure",
                "Repair",
                "Replacement",
                "Retrofit",
                "CMS Inspection",
                "Skiipack"
    ];

    var _RunType = [
               "- Run Status -",
                "Run",
               "Stop",
               "",
               "",
               "",
               "No power",
               "Pause",
               "Emergency Stop",
               "Transformer",
               "Main Bearing",
               "Skiipack"
    ];


    this.loadLocalCirData = function (recordsPerPage, numberOfPage) {
        //$('table#cirSearchListLocal tr.localitem').remove();
        // $('#cirSearchListLocal').append('<tr class="localitem"><td colspan="13" style="text-align:center;"><i class="fa fa-refresh fa-spin fa-lg"></i></td></td>');

        var CirSearchString = '';
        var searchCirID = getQueryStringValueHash("CirID");
        var searchCirName = getQueryStringValueHash("Name");
        var searchCirType = getQueryStringValueHash("CirType");
        var searchReportType = getQueryStringValueHash("ReportType");
        var searchReportTypeName = getQueryStringValueHash("ReportTypeName");
        var searchCimCase = getQueryStringValueHash("CimCase");
        var searchCountry = getQueryStringValueHash("Country");
        var searchSite = getQueryStringValueHash("Site");
        var searchTurbineType = getQueryStringValueHash("TurbineType");
        var searchTurbineNumber = getQueryStringValueHash("TurbineNumber");
        var searchRunStatus = getQueryStringValueHash("RunStatus");
        var searchSBU = getQueryStringValueHash("SBU");

        var cirSearchjSon = {};
        var filter = [];
        displayText = '';

        if (searchCirID && searchCirID != '') {

            cirSearchjSon.cirId = searchCirID;
            filter.push({ property: "ComponentInspectionReportId", value: searchCirID });

            displayText = displayText + 'CIR ID = ' + searchCirID + "; ";
        }
        else {
            cirSearchjSon.cirId = '';
        }

        if (searchCirName && searchCirName != '') {
            filter.push({ property: "ComponentInspectionReportName", value: searchCirName });
            cirSearchjSon.name = searchCirName;
            displayText = displayText + 'CIR Name = ' + searchCirName + "; ";
        }
        else {
            cirSearchjSon.name = '';
        }
        if (searchTurbineNumber && searchTurbineNumber != '') {
            filter.push({ property: "TurbineNumber", value: searchTurbineNumber });
            cirSearchjSon.turbineNumber = searchTurbineNumber;
            displayText = displayText + 'Turbine Number = ' + searchTurbineNumber + "; ";
        }
        else {
            cirSearchjSon.turbineNumber = '';
        }
        if (searchTurbineType && searchTurbineType != '') {
            filter.push({ property: "TurbineType", value: searchTurbineType });
            cirSearchjSon.turbineType = searchTurbineType;
            displayText = displayText + 'Turbine Type = ' + searchTurbineType + "; ";
        }
        else {
            cirSearchjSon.turbineType = '';
        }
        if (searchReportType && searchReportType != '') {
            filter.push({ property: "ReportTypeId", value: searchReportType });
            cirSearchjSon.reportType = searchReportType;
            displayText = displayText + 'CIR Report Type = ' + _ReportType[searchReportType] + "; ";
        }
        else {
            cirSearchjSon.reportType = '';
        }
        if (searchCimCase && searchCimCase != '') {
            filter.push({ property: "CimCaseNumber", value: searchCimCase });
            cirSearchjSon.cimCase = searchCimCase;
            displayText = displayText + 'CIM Case Number = ' + searchCimCase + "; ";
        }
        else {
            cirSearchjSon.cimCase = '';
        }
        if (searchRunStatus && searchRunStatus != '') {
            filter.push({ property: "RunStatusId", value: searchRunStatus });
            cirSearchjSon.runStatus = searchRunStatus;
            displayText = displayText + 'Run Status = ' + _RunType[searchRunStatus] + "; ";
        }
        else {
            cirSearchjSon.runStatus = '';
        }
        if (searchSBU && searchSBU != '') {
            filter.push({ property: "SBU", value: searchSBU });
            cirSearchjSon.sbu = searchSBU;
            displayText = displayText + 'SBU = ' + searchSBU + "; ";
        }
        else {
            cirSearchjSon.sbu = '';
        }
        if (searchCirType && searchCirType != '') {
            filter.push({ property: "ComponentType", value: searchCirType });

            cirSearchjSon.cirType = searchCirType;
            displayText = displayText + 'CIR Type = ' + _CIRType[searchCirType] + "; ";
        }
        else {
            cirSearchjSon.cirType = '';
        }
        if (searchCountry && searchCountry != '') {
            filter.push({ property: "Country", value: searchCountry });
            cirSearchjSon.turbineCountry = searchCountry;
            displayText = displayText + 'Country = ' + searchCountry + "; ";
        }
        else {
            cirSearchjSon.turbineCountry = '';
        }
        if (searchSite && searchSite != '') {
            filter.push({ property: "SiteName", value: searchSite });
            cirSearchjSon.SiteName = searchSite;
            displayText = displayText + 'Site Name = ' + searchSite + "; ";
        }
        else {
            cirSearchjSon.SiteName = '';
        }
        displayText = displayText.trim();

        displayText = (displayText.length > 0) ? displayText.substring(0, displayText.length - 1) : displayText;
        if (displayText != '') {
            $('#cirSearchText').text(displayText);
            $('#searchRestultDisplay').show();
        }
        else
            $('#searchRestultDisplay').hide();

        cirOfflineAppSearch.bindLocalCirDataGrid(filter);

    }

    this.CheckNumberOfLocalCirRecords = function () {
        if (jQuery('table#cirSearchListLocal td').hasClass('dataTables_empty')) {
            $('.dataTables_paginate').hide();
            $('.dataTables_length').hide();
            $('.dataTables_info').hide();
        }
    }

    this.bindLocalCirDataGrid = function (filter) {

        cirOfflineApp.getCirLocalData().done(function (CirLocalDataList) {
            var result = CirLocalDataList;
            $.each(filter, function (k, filterRow) {
                result = $.grep(result, function (item) { return item[filterRow.property] == filterRow.value; });
            });

            var t = $('#cirSearchListLocal').DataTable({ destroy: true });
            if (result && result.length > 0) {
                $('#spnLocalCount').text(result.length);
            }
            else {
                $('#spnLocalCount').text(0);
            }

            var Draft = 'false';
            $.each(result, function (i, item) {
                //t.row.add([ActionString, Status, item.ComponentInspectionReportId, item.ComponentInspectionReportName, item.CimCaseNumber, item.TurbineType, item.TurbineNumber, item.SiteName, item.CreatedDate]).draw(false);;
                var dataRows = cirDataDiplay.getDataRows(item, '2')[0];
                t.row.add([dataRows.ActionIcons, dataRows.StausIcon + '   ' + dataRows.CIRCurrentStaus, dataRows.DisplayCirId, dataRows.ComponentInspectionReportName, dataRows.CimCaseNumber, dataRows.TurbineType, dataRows.TurbineNumber, dataRows.SiteName, dataRows.CreatedDate]).draw(false);
            });
            cirOfflineAppSearch.CheckNumberOfLocalCirRecords();
        });

    }

    //t.clear().draw();

    this.GetRowCountData = function (appUrl, appID, recordsPerPage, numberOfPage, state) {
        var cirSearchjSon;

        var searchCirID = getQueryStringValueHash("CirID");
        var searchCirName = getQueryStringValueHash("Name");
        var searchCirType = getQueryStringValueHash("CirType");
        var searchReportType = getQueryStringValueHash("ReportType");
        var searchReportTypeName = getQueryStringValueHash("ReportTypeName");
        var searchCimCase = getQueryStringValueHash("CimCase");
        var searchCountry = getQueryStringValueHash("Country");
        var searchSite = getQueryStringValueHash("Site");
        var searchTurbineType = getQueryStringValueHash("TurbineType");
        var searchTurbineNumber = getQueryStringValueHash("TurbineNumber");
        var searchRunStatus = getQueryStringValueHash("RunStatus");
        var searchSBU = getQueryStringValueHash("SBU");

        //Modified by Siddharth Chauhan on 08-06-2016
        //To optimize the code used JSON object instead of string concatination for JSON object.
        var cirSearchjSon = {};
        if (searchCirType && searchCirType != '0') {
            cirSearchjSon.componentInspectionReportTypeId = searchCirType;
        }
        else {
            cirSearchjSon.componentInspectionReportTypeId = 0;
        }

        if (searchReportType && searchReportType != '0') {
            cirSearchjSon.reportTypeId = searchReportType;
        }
        else {
            cirSearchjSon.reportTypeId = 0;
        }

        if (searchCirID && searchCirID != '0') {
            cirSearchjSon.cirID = searchCirID;
        }
        else {
            cirSearchjSon.cirID = 0;
        }

        if (searchCirName && searchCirName != '') {
            cirSearchjSon.name = searchCirName;
        }
        else {
            cirSearchjSon.name = "";
        }

        if (searchCountry && searchCountry != '') {
            cirSearchjSon.country = searchCountry;
        }
        else {
            cirSearchjSon.country = "";
        }
        if (searchSite && searchSite != '') {
            cirSearchjSon.siteName = searchSite;
        }
        else {
            cirSearchjSon.siteName = "";
        }

        if (searchTurbineType && searchTurbineType != '') {
            cirSearchjSon.turbineType = searchTurbineType;
        }
        else {
            cirSearchjSon.turbineType = "";
        }

        if (searchSBU && searchSBU != '') {
            //Added by Siddharth Chauhan on 29-06-2016.
            //To fix the bug : 82364
            cirSearchjSon.sbuName = searchSBU;
        }
        else {
            //Added by Siddharth Chauhan on 29-06-2016.
            //To fix the bug : 82364
            cirSearchjSon.sbuName = "";
        }

        if (searchCimCase && searchCimCase != '0') {
            cirSearchjSon.cimCaseNumber = searchCimCase;
        }
        else {
            cirSearchjSon.cimCaseNumber = 0;
        }

        if (searchRunStatus && searchRunStatus != '0') {
            cirSearchjSon.runStatus = searchRunStatus;
        }
        else {
            cirSearchjSon.runStatus = 0;
        }

        if (searchTurbineNumber && searchTurbineNumber != '') {
            cirSearchjSon.turbineNumber = searchTurbineNumber;
        }
        else {
            cirSearchjSon.turbineNumber = 0;
        }

        //Modified By Siddharth Chauhan on 06-06-2016. Added _state condition parameter.
        //to get selected Tab id for filtering the CIR Remote records(UnApproved,Accepted,Rejected). 
        //To show the Sub-Tabs for Remote CIR List(UnApproved,Accepted,Rejected).
        //TaskNo. : 75297 
         
        cirSearchjSon.state = state;

        //if (state && state != '') {
        //    cirSearchjSon.state = state;
        //}
        //else {
        //    state = 1;
        //    cirSearchjSon.state = 1;
        //}

        var searchObj = {};
        resultdata = [];
        searchObj.currentPageNumber = numberOfPage;
        searchObj.recordsPerPage = recordsPerPage;
        searchObj.totalRecordCount = 0;

        cirSearchjSon.search = searchObj;
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, '');
        dbtransaction.openDatabase(function () {
            dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                if (currentuser) {
                    if (currentuser.length > 0) {
                        currentuser.forEach(function (item) {
                            client.currentUser = item.objet;
                        });
                        if (client.currentUser) {
                            client.invokeApi('CirSearch', {
                                method: 'POST',
                                body: cirSearchjSon
                            }).done(function (response) {
                                var tstunapproved = response.result[0].totalUnApprovedRecords;
                                var tstaccepted = response.result[0].totalAcceptedRecords;
                                var tstrejected = response.result[0].totalRejectedRecords;

                                //Reset State based on Count of records
                                _state = findcountstate(tstunapproved, tstaccepted, tstrejected);

                            });
                        }
                    }
                }
            });
        });
    }

    this.loadRemoteCirData = function (appUrl, appID, recordsPerPage, numberOfPage, state) {
        // To show the Actions items in Remote CIR Search List.                                        
        //$('#divExportRemote').hide();


        /// $('table#cirSearchListRemote tr.item').remove();
        //  $("#cirSearchListRemote > tbody").empty();
        $('#spnRemoteCount').text("0");
        $("#btnLazyLoad").show();
        $("#cirSearchButton").attr("style", "background-color:#008d4c;color:white")
        $("#cirSearchButton").attr("title", "")
        if (Offline.state == "down") {
            waitingDialog.hide();
            $("#cirSearchButton").attr("style", "background-color:#0072BB;color:white")
            $("#cirSearchButton").attr("title", "Only local search will work as you are offine!")
            $("#btnLazyLoad").hide();
            $("#cirSearchListRemote > tbody").html('<tr class="item"><td colspan="13" style="text-align:center;">Remote search is not available in <font color=red>Offline Mode</font></td></td>');
        }
        else {
            ///  $("#cirSearchListRemote > tbody").html('<tr class="item"><td colspan="13" style="text-align:center;"><i class="fa fa-refresh fa-spin fa-lg"></i></td></td>');
            var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
            dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                if (currentuser) {
                    if (currentuser.length > 0) {
                        currentuser.forEach(function (item) {
                            client.currentUser = item.objet;
                        });
                        if (client.currentUser) {
                            var cirSearchjSon;

                            var searchCirID = getQueryStringValueHash("CirID");
                            var searchCirName = getQueryStringValueHash("Name");
                            var searchCirType = getQueryStringValueHash("CirType");
                            var searchReportType = getQueryStringValueHash("ReportType");
                            var searchReportTypeName = getQueryStringValueHash("ReportTypeName");
                            var searchCimCase = getQueryStringValueHash("CimCase");
                            var searchCountry = getQueryStringValueHash("Country");
                            var searchSite = getQueryStringValueHash("Site");
                            var searchTurbineType = getQueryStringValueHash("TurbineType");
                            var searchTurbineNumber = getQueryStringValueHash("TurbineNumber");
                            var searchRunStatus = getQueryStringValueHash("RunStatus");
                            var searchSBU = getQueryStringValueHash("SBU");

                            //Modified by Siddharth Chauhan on 08-06-2016
                            //To optimize the code used JSON object instead of string concatination for JSON object.
                            var cirSearchjSon = {};
                            if (searchCirType && searchCirType != '0') {
                                cirSearchjSon.componentInspectionReportTypeId = searchCirType;
                            }
                            else {
                                cirSearchjSon.componentInspectionReportTypeId = 0;
                            }

                            if (searchReportType && searchReportType != '0') {
                                cirSearchjSon.reportTypeId = searchReportType;
                            }
                            else {
                                cirSearchjSon.reportTypeId = 0;
                            }

                            if (searchCirID && searchCirID != '0') {
                                cirSearchjSon.cirID = searchCirID;
                            }
                            else {
                                cirSearchjSon.cirID = 0;
                            }

                            if (searchCirName && searchCirName != '') {
                                cirSearchjSon.name = searchCirName;
                            }
                            else {
                                cirSearchjSon.name = "";
                            }

                            if (searchCountry && searchCountry != '') {
                                cirSearchjSon.country = searchCountry;
                            }
                            else {
                                cirSearchjSon.country = "";
                            }
                            if (searchSite && searchSite != '') {
                                cirSearchjSon.siteName = searchSite;
                            }
                            else {
                                cirSearchjSon.siteName = "";
                            }

                            if (searchTurbineType && searchTurbineType != '') {
                                cirSearchjSon.turbineType = searchTurbineType;
                            }
                            else {
                                cirSearchjSon.turbineType = "";
                            }

                            if (searchSBU && searchSBU != '') {
                                //Added by Siddharth Chauhan on 29-06-2016.
                                //To fix the bug : 82364
                                cirSearchjSon.sbuName = searchSBU;
                            }
                            else {
                                //Added by Siddharth Chauhan on 29-06-2016.
                                //To fix the bug : 82364
                                cirSearchjSon.sbuName = "";
                            }

                            if (searchCimCase && searchCimCase != '0') {
                                cirSearchjSon.cimCaseNumber = searchCimCase;
                            }
                            else {
                                cirSearchjSon.cimCaseNumber = 0;
                            }

                            if (searchRunStatus && searchRunStatus != '0') {
                                cirSearchjSon.runStatus = searchRunStatus;
                            }
                            else {
                                cirSearchjSon.runStatus = 0;
                            }

                            if (searchTurbineNumber && searchTurbineNumber != '') {
                                cirSearchjSon.turbineNumber = searchTurbineNumber;
                            }
                            else {
                                cirSearchjSon.turbineNumber = 0;
                            }

                            //Modified By Siddharth Chauhan on 06-06-2016. Added _state condition parameter.
                            //to get selected Tab id for filtering the CIR Remote records(UnApproved,Accepted,Rejected). 
                            //To show the Sub-Tabs for Remote CIR List(UnApproved,Accepted,Rejected).
                            //TaskNo. : 75297 
                            if (state && state != '') {
                                cirSearchjSon.state = state;
                            }
                            else {
                                state = 0;
                                cirSearchjSon.state = 0;
                            }

                            var searchObj = {};
                            resultdata = [];
                            searchObj.currentPageNumber = numberOfPage;
                            searchObj.recordsPerPage = recordsPerPage;
                            searchObj.totalRecordCount = 0;

                            cirSearchjSon.search = searchObj;
                            console.log(cirSearchjSon);

                            client.invokeApi('CirSearch', {
                                method: 'POST',
                                body: cirSearchjSon
                            }).done(function (response) {
                                waitingDialog.hide();
                                var resp = response.result;

                                resultdata = resp;

                                console.log(resp);
                                var cirHtml = '';
                                var rows = [];

                                $("#btnLazyLoad").hide();

                                if (resp.length > 0) {
                                    //Added by Siddharth Chauhan on 20-06-2016.
                                    // To show the Actions items in Remote CIR Search List.                                        
                                    //Task No. 75299
                                    var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("Administrator") || hasRole("GirCreator") || hasRole("GBXIRCreator");
                                    if (resp.length > 0) {
                                        var totalRecords = 0;
                                        totalRecords = resp[0].totalRecords;
                                        if (resp[0].cirid != 0) {
                                            rows = cirOfflineAppSearch.getRows(resp);
                                        }

                                        var startNumber = 1;// (parseInt((_CurrentRemotePage - 1) * _RecordsPerPage) + 1);
                                        var lastNumber = (_CurrentRemotePage * _RecordsPerPage);

                                        if (lastNumber > totalRecords)
                                            lastNumber = totalRecords;
                                        // $('table#cirSearchListRemote tr.item').remove();
                                        // $("#cirSearchListRemote > tbody").empty();
                                        if (totalRecords < 50) {
                                            $("#btnLazyLoad").hide();
                                        }
                                        else {
                                            $("#btnLazyLoad").show();
                                        }
                                        // $("#cirSearchListRemote > tbody").html(cirHtml);
                                        $('#spnRemoteCount').text(totalRecords);

                                        //Added By Siddharth Chauhan on 06-06-2016. 
                                        //to show the total count for UnApproved,Accepted,Rejected.                                     
                                        //TaskNo. : 75297 
                                        $('#unApprovedCount').text(resp[0].totalUnApprovedRecords);
                                        $('#acceptedCount').text(resp[0].totalAcceptedRecords);
                                        $('#rejectedCount').text(resp[0].totalRejectedRecords);
                                        if (state == 0) {
                                            state = findcountstate(resp[0].totalUnApprovedRecords, resp[0].totalAcceptedRecords, resp[0].totalRejectedRecords);
                                        }
                                        if (state == 1) {
                                            $("#btnUnApproved").attr("style", "border:2px solid #000000")
                                            $("#btnAccepted").attr("style", "")
                                            $("#btnRejected").attr("style", "")

                                        } else if (state == 2) {
                                            $("#btnAccepted").attr("style", "border:2px solid #000000")
                                            $("#btnUnApproved").attr("style", "")
                                            $("#btnRejected").attr("style", "")
                                        }
                                        else if (state == 3) {
                                            $("#btnRejected").attr("style", "border:2px solid #000000")
                                            $("#btnAccepted").attr("style", "")
                                            $("#btnUnApproved").attr("style", "")
                                        }

                                        //Modified By Siddharth Chauhan on 06-06-2016. Added _state condition parameter.
                                        //to get selected Tab id for filtering the CIR Remote records(UnApproved,Accepted,Rejected). 
                                        //To show the Sub-Tabs for Remote CIR List(UnApproved,Accepted,Rejected).
                                        //TaskNo. : 75297 
                                        if (state == 0) {
                                            $('#lblShowingRecords-Remote').text("Showing : ALL");
                                            $("#cirSearchListRemote th").css('background-color', '#0072BB');
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + totalRecords + ' entries');
                                        }
                                        else if (state == 1) {
                                            $('#lblShowingRecords-Remote').text("Showing : Submitted");
                                            $("#cirSearchListRemote th").css('background-color', '#0072BB');
                                            lastNumber = (lastNumber > resp[0].totalUnApprovedRecords) ? resp[0].totalUnApprovedRecords : lastNumber;
                                            if ((resp[0].totalUnApprovedRecords - lastNumber) <= _RecordsPerPage) {
                                                $("#btnLazyLoad").hide();
                                                lastNumber = resp[0].totalUnApprovedRecords;
                                            }
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalUnApprovedRecords + ' entries');
                                        }
                                        else if (state == 2) {
                                            $('#lblShowingRecords-Remote').text("Showing : Accepted");
                                            $("#cirSearchListRemote th").css('background-color', '#008d4c');
                                            lastNumber = (lastNumber > resp[0].totalAcceptedRecords) ? resp[0].totalAcceptedRecords : lastNumber;
                                            if ((resp[0].totalAcceptedRecords - lastNumber) <= _RecordsPerPage) {
                                                $("#btnLazyLoad").hide();
                                                lastNumber = resp[0].totalAcceptedRecords;
                                            }
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalAcceptedRecords + ' entries');
                                        }
                                        else if (state == 3) {
                                            $('#lblShowingRecords-Remote').text("Showing : Rejected");
                                            $("#cirSearchListRemote th").css('background-color', '#c9302c');
                                            lastNumber = (lastNumber > resp[0].totalRejectedRecords) ? resp[0].totalRejectedRecords : lastNumber;
                                            if ((resp[0].totalRejectedRecords - lastNumber) <= _RecordsPerPage) {
                                                $("#btnLazyLoad").hide();
                                                lastNumber = resp[0].totalRejectedRecords;


                                            }
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalRejectedRecords + ' entries');
                                        }

                                        //Added by Siddharth Chauhan on 20-06-2016.
                                        // To show the Actions items in Remote CIR Search List.                                        
                                        //Task No. 75299
                                        //$('#divExportRemote').show();
                                        if ((state == 1 && resp[0].totalUnApprovedRecords > 0) || (state == 2 && resp[0].totalAcceptedRecords > 0) || (state == 3 && resp[0].totalRejectedRecords > 0)) {
                                            $.each(rows, function (i, item) {
                                                  
                                                _RemoteDataTable.row.add([item.r1, item.r2, item.r3, item.r4, item.r5, item.r6, item.r7, item.r8,item.r9]).draw(false);

                                            });
                                        }

                                     

                                        _LazyLoading = 0;

                                    }
                                    else {
                                        var t = $('#cirSearchListRemote').DataTable({
                                            destroy: true,
                                            searching: false,
                                            paging: false,
                                            info: false
                                        });

                                        t.clear().draw();
                                        $("#btnLazyLoad").hide();
                                        if (state == 0) {
                                            $('#lblShowingRecords-Remote').text("Showing : ALL");
                                            $("#cirSearchListRemote th").css('background-color', '#0072BB');
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + totalRecords + ' entries');
                                        }
                                        else if (state == 1) {
                                            $('#lblShowingRecords-Remote').text("Showing : Submitted");
                                            $("#cirSearchListRemote th").css('background-color', '#0072BB');
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalUnApprovedRecords + ' entries');


                                            $("#btnUnApproved").attr("style", "border:2px solid #000000");
                                            $("#btnAccepted").attr("style", "");
                                            $("#btnRejected").attr("style", "");

                                        }
                                        else if (state == 2) {
                                            $('#lblShowingRecords-Remote').text("Showing : Accepted");
                                            $("#cirSearchListRemote th").css('background-color', '#008d4c');
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalAcceptedRecords + ' entries');


                                            $("#btnAccepted").attr("style", "border:2px solid #000000");
                                            $("#btnUnApproved").attr("style", "");
                                            $("#btnRejected").attr("style", "");
                                        }
                                        else if (state == 3) {
                                            $('#lblShowingRecords-Remote').text("Showing : Rejected");
                                            $("#cirSearchListRemote th").css('background-color', '#c9302c');
                                            $('#lblTotalRecords-Remote').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + resp[0].totalRejectedRecords + ' entries');



                                            $("#btnRejected").attr("style", "border:2px solid #000000");
                                            $("#btnAccepted").attr("style", "");
                                            $("#btnUnApproved").attr("style", "");
                                        }
                                        $('#spnRemoteCount').text("0");
                                        $('table#cirSearchListRemote tr.item').remove();
                                        $("#cirSearchListRemote > tbody").empty();
                                        $("#cirSearchListRemote > tbody").html('<tr class="item"><td colspan="13" style="text-align:center;">No records found</td></td>');

                                    }
                                }


                                if (state == 1) {
                                    $("#btnUnApproved").attr("style", "border:2px solid #000000")
                                    $("#btnAccepted").attr("style", "")
                                    $("#btnRejected").attr("style", "")

                                } else if (state == 2) {
                                    $("#btnAccepted").attr("style", "border:2px solid #000000")
                                    $("#btnUnApproved").attr("style", "")
                                    $("#btnRejected").attr("style", "")
                                }
                                else if (state == 3) {
                                    $("#btnRejected").attr("style", "border:2px solid #000000")
                                    $("#btnAccepted").attr("style", "")
                                    $("#btnUnApproved").attr("style", "")
                                }

                            }, function (error) {
                                waitingDialog.hide();
                                console.log(error);
                            });
                        }
                    }
                }
            });
        }
    }

    this.lazyLoad = function () {
        if (_LazyLoading == 1)
            return false;
        _LazyLoading = 1;
        _CurrentRemotePage++;
        // $("#btnLazyLoadIcon").show();
        cirOfflineAppSearch.loadRemoteCirData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, _CurrentRemotePage, _state);
    }

    this.getRows = function (data) {
        var rows = [];
        var cirHtml = "";
        if (CurrentUserInfo.Roles.length == 0)
        {
            CurrentUserInfo.Roles.push("Viewer");
        }
        var hdnFields = "";
        var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("Administrator") || hasRole("GBXIRCreator");
        var userValid_Attachment = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor") || hasRole("Turbine Technicians") || hasRole("Viewer") || hasRole("Visitor");
        var userValid_Viewer = hasRole("Viewer") || hasRole("Visitor");
        var userValid_Edit = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
        var userValid_Tech = hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians");
        var userValid_AcceptedList = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
        data.forEach(function (item) {

            cirHtml += '<tr class="item" id="' + Date.now() + '">';

            //Added by Siddharth Chauhan on 20-06-2016.
            // To show the Actions items in Remote CIR Search List.                                        
            //Task No. 75299
            var link = "";
            var locked = "";
            locked = item.hideLock.split('|')[0];
            var createdBy = item.hideLock.split('|')[1];
            cirHtml += '<td data-hide="phone" width="14%">';
            hdnFields = '<input id="'+ "hdnCreatedDate"+ item.componentInspectionReportId +'"  type=hidden value="' + item.inspectionDate + '">';
            //link = '<input class="downloadcir" type="checkbox" id="' + item.cirDataID + ' ">';
            link = link + '<a title="View CIR details" onClick=javascript:ShowCirDetails(' + item.cirDataID + ',1);><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
            
            if (userValid_Attachment) {
                link = link + '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';
            }
            if (_state == 2 && userValid_Attachment) {
                link = link + '&nbsp;<a title="Upload/View attachment" onClick=javascript:ShowCirDetails(' + item.cirDataID + ',2);><i style="color:#2E64FE;cursor:pointer" id="iconAttachment" class="fa fa-paperclip fa-lg" title="Upload/View attachment")"></i></a>';
            }
            if (locked == "" || locked == CurrentUserInfo.Name) {
                
                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';
                 
            }

            if (item.hideProgress == 1 && (locked == " " || locked == "") && (userValid || hasRole("Member"))) {
                if (item.componentInspectionReportStateId == 1) {
                    link = link + '&nbsp;<i style="color:#088A08;cursor:pointer" id="iconApprove" class="fa fa-check-circle fa-lg" title="Approve CIR" onclick="Action(4,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Reject CIR" onclick="Action(5,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';
                }
                if (item.componentInspectionReportStateId == 2) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';
                }

            }
            else {
                if (item.componentInspectionReportStateId == 2 && item.hideProgress == 6 && (locked == " " || locked == "") && (userValid || hasRole("Member"))) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';
                }
                if (item.hideProgress == -2) {
                    link = link + '&nbsp;<i style="color:#cccc00;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="This CIR had Error during Migration but has been migrated by resolving the error temporarily. Please [Edit] the CIR to view the Error description"></i>';

                }
                if (item.hideProgress == 5 || item.hideProgress == 6) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="An error occured"></i>';
                }
                if (item.hideProgress == 4) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending (Move to Submitted)"></i>';
                }
                if (item.hideProgress == 2) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for approval"></i>';
                }
                if (item.hideProgress == 3) {
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for rejection"></i>';
                }
            }
            if (locked != " " && locked != "") {
                if (locked == CurrentUserInfo.Name)
                    link = link + '&nbsp;<i style="color:#0000cc;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by you. Please edit and submit to make it available for further process."></i>';
                else
                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by ' + locked + '"></i>';

            }
            if (item.hideProgress == 1 && (locked == " " || locked == "") && (userValid || hasRole("Member"))) {
                link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconDelete" class="fa fa-trash fa-lg" title="Delete CIR" onclick="Action(6,' + item.cirDataID + ',' + item.cirid + ',' + item.componentInspectionReportStateId + ')"></i>';

            }

            if (item.hideTemplateVer != undefined && item.hideTemplateVer != null) {
                if (parseInt(item.hideTemplateVer) <= 4) {
                    link = link.split('{display}').join(';display:none');
                }
                else {
                    if (userValid_Edit == true) {
                        link = link.split('{display}').join('');
                    }
                    else if (userValid_Tech == true) {
                        if ((createdBy != CurrentUserInfo.Name) || (item.totalAcceptedRecords == 1)) {
                            link = link.split('{display}').join(';display:none');
                        }
                        else {
                             
                            link = link.split('{display}').join('');
                        }
                    }
                    else {
                        link = link.split('{display}').join(';display:none');
                    }
                }
            }
            else {
                if (userValid_Edit == true) {
                    link = link.split('{display}').join('');
                }
                else if (userValid_Edit == false && userValid_Viewer == true) {
                    link = link.split('{display}').join(';display:none');
                }
                else {
                    if (CurrentUserInfo.Name.indexOf(createdBy) >= 0) {
                        link = link.split('{display}').join('');
                    }
                    else {
                        link = link.split('{display}').join(';display:none');
                    }
                }
            }

            cirHtml += hdnFields + link + '</td>';
            //Ends Here.Task No. 75299
            var r1 = hdnFields + link;
            cirHtml += '<td data-hide="phone">' + item.componentInspectionReportId;
            var r2 = item.componentInspectionReportId;
            cirHtml += '<td class="expand">' + item.componentInspectionReportName;
            cirHtml += '</td>';
            var r3 = item.componentInspectionReportName;
            cirHtml += '<td data-hide="phone">' + item.cimCaseNumber + '</td>';
            var r4 = item.cimCaseNumber;
            cirHtml += '<td data-hide="phone">' + item.turbineType + '</td>';
            var r5 = item.turbineType;
            cirHtml += '<td data-hide="phone">' + item.turbineNumber + '</td>';
            var r6 = item.turbineNumber;
            cirHtml += '<td data-hide="phone">' + item.country + '</td>';
            var r7 = item.country;
            cirHtml += '<td data-hide="phone">' + item.brand + '</td>';
            var r8 = item.brand;
            cirHtml += '<td data-hide="phone">' + getDate(item.inspectionDate) + '</td>';
            var r9 = getDate(item.inspectionDate);
            cirHtml += '</tr>';
            rows.push({ r1: r1, r2: r2, r3: r3, r4: r4, r5: r5, r6: r6, r7: r7, r8: r8 , r9: r9 })
        });
        return rows;
    }

    this.getExcleRows = function (data) {
        var CIRData = [];
        data.forEach(function (item) {
            var rows = {};
            rows.CIR_ID = item.componentInspectionReportId;
            rows.CIR_Name = item.componentInspectionReportName;
            rows.CIM_Case_Number = item.cimCaseNumber;
            rows.Turbine_Type = item.turbineType;
            rows.Turbine_Number = item.turbineNumber;
            rows.Country = item.country;
            rows.Brand = item.brand;
            rows.Inspection_Date = getDate(item.inspectionDate);

            CIRData.push(rows);
        });
        return CIRData;
    }

    this.DelegateCIRModal = function (id, cirDataLocalID) {
        $("#UserList").empty();
        $("#txtUserToSearch").val('');
        $("#lblUserToSearch_Validation").empty();
        $("#DelegateCIRModal").find('.modal-title').text("Delegate CIR");
        //$('input[name="testing"]').val(theValue);
        $("#CIRId").val(id);
        $("#CirDataLocalID").val(cirDataLocalID);


        $("#DelegateCIRModal").modal('show');
    }
};

function DoSearch() {
    RetainCirSearchValues();

    if (document.URL.toLowerCase().indexOf('cir-search') > -1) {

        setTimeout(function () {
            _RemoteDataTable = $('#cirSearchListRemote').DataTable({
                destroy: true,
                searching: false,
                paging: false,
                info: false,
                order: [[1, 'desc']]
            });
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            cirOfflineAppSearch.loadRemoteCirData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);
        }, 1000);

    }

    if (document.URL.toLowerCase().indexOf('cir-search') > -1)
        dbtransaction.openDatabase(function () {
            console.log('loading');

            cirOfflineAppSearch.loadLocalCirData($("#ddlNumber").val(), 1);

        });

}

function CheckValidUserToken() {
    var deferredObject = $.Deferred();
    if (Offline.state == "down") {
        setTimeout(function () { deferredObject.reject('User offline'); }, 200)
    }
    else {
        UserCachingController.RefereshUser(true).done(function () {
            deferredObject.resolve();
        }).fail(function (error) {
            var oldurl = window.location.href;
            var newoldurl = oldurl.replace("#", "%");
            window.location = '/cir/Sign-In?returnUrl=' + newoldurl;
        });
        return deferredObject.promise();
    }
}

$(document).ready(function () {
    Offline.check();

    setTimeout(function () {
        CheckValidUserToken();
        if (Offline.state == "down")
            return;
        else {
            // cirOfflineAppSearch.GetRowCountData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);
            LoadUserInfo().done(function () {
                $('#hdnUserPrincipal').val(CurrentUserInfo.UserPrincipleName);
            });
        }
    }, 2000);

    //cirOfflineAppSearch.GetRowCountData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);



    $('body').on('click', '.DelegateCIR', function () {
        var cirId = $(this).attr('id');
        var cirDataLocalID = $(this).attr('value');
        if (!cirId)
            return;
        cirOfflineAppSearch.DelegateCIRModal(cirId, cirDataLocalID);
    });

    $("#btnAssignCIR_LSearch").click(function () {

        var selectedUser = $('#UserList option:selected');
        if (selectedUser.length == 0) {

            //alert("Please select User(s) to assign a role!");
            //return false;
            CirAlert.alert('Please select one User to delegate CIR !', 'Cir App', null, 'error').done(function () {
            });
            return false;

        }
        //cirDataDiplay.AssignCIR($('#CIRId').val(), $('#CirDataLocalID').val(), selectedUser.val());
        cirDataDiplay.DelegateCirData($('#CIRId').val(), selectedUser.val());
    });

    $("#btnUserSearch_LSearch").click(function () {
        $('#txtUserToSearch').removeClass('validationerror');
        $('#txtUserToSearch').removeClass('red-tooltip');
        $("#lblUserToSearch_Validation").empty();
        $("#btnUserSearch_AssignCIR").text("Search");
        var userToSearch = $("#txtUserToSearch").val();
        if (userToSearch.trim() == "" || userToSearch.trim().length < 3) {
            $('#txtUserToSearch').addClass('validationerror');
            $('#txtUserToSearch').addClass('red-tooltip');
            $('#lblUserToSearch_Validation').text('Please enter minimum 3 char User Initial !');
            return false;
        }
        //$("#btnUserSearch").text("Please Wait..");
        cirDataDiplay.SearchUsers_LSearch(userToSearch, $('#MobAppURL').val(), $('#MobAppID').val());
    });

    $(".boldOnChange").blur(function () {
        if ($(this).val() != null && $(this).val().trim() != "") {
            $(this).addClass('bold').css("font-weight", "bold");
            $(this).addClass('bold');

        }
        else {
            $(this).removeClass('bold');
            $(this).attr('style', '');
        }
    });
    $(".boldOnChange").focus(function () {
        $(this).removeClass('bold');
        $(this).attr('style', '');

    });

    $('body').on('click', '.RevokeDelegateCIR_Serach', function () {
        var Id = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!Id)
            return;
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            CirAlert.confirm("Do you want to send your changes to the owner ?", 'Cir App', 'Yes', 'No', 'warning').done(function () {
                cirDataDiplay.RevokeDelegatedPermission(Id, true, true);
            }).fail(function (e) {
                cirDataDiplay.RevokeDelegatedPermission(Id, false, true);
            });
        });
    });
    $('body').on('click', '.RevokeDelegateCIR_Owner_Search', function () {
        var Id = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!Id)
            return;
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            CirAlert.confirm("Do you want to take latest changes from delegate ?", 'Cir App', 'Yes', 'No', 'warning').done(function () {
                cirDataDiplay.RevokeDelegatedPermission(Id, true,false);
            }).fail(function (e) {
                cirDataDiplay.RevokeDelegatedPermission(Id, false,false);
            });
        });
    });
    $('body').on('click', '.RemoveLocalCir_Search', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;
        /* if (confirm(cirHead)) {
            //$('table#cirSearchListLocal tr#' + cirLocalId).remove();

            cirOfflineApp.softDeleteCirLocalData(cirLocalId);

            var tblcirSearchListLocal = $('#cirSearchListLocal').DataTable();
            var row = tblcirSearchListLocal.row($(this).parents('tr'));
            row.remove();
            tblcirSearchListLocal.draw();
            $('#spnLocalCount').text(tblcirSearchListLocal.data().length);
            
         }*/
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            //$('table#cirSearchListLocal tr#' + cirLocalId).remove();

            cirOfflineApp.softDeleteCirLocalData(cirLocalId);

            var tblcirSearchListLocal = $('#cirSearchListLocal').DataTable();
            var row = tblcirSearchListLocal.row($(this).parents('tr'));
            row.remove();
            tblcirSearchListLocal.draw();
            $('#spnLocalCount').text(tblcirSearchListLocal.data().length);
            azureSync.StartSyncManual().done(function () { });
        });
    });

    $('body').on('click', '.EditCir', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;
        /*if (confirm(cirHead)) {
            window.open("/cir/manage-cir#cirID=" + cirLocalId, '_self');

        }*/

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            window.open("/cir/manage-cir#cirID=" + cirLocalId, '_self');

        });


    });

    $('body').on('click', '.StatusCir', function () {
        var cirError = $(this).attr('value');
        if (!cirError)
            return;
        showDetails(cirError);
    });

    $('body').on('click', '.EditConCir', function () {
        var id = $(this).attr('id');
        if (!id)
            return;
        ShowConCir(id);
    });

    $('.modal').on('show.bs.modal', function () {
        $(this).show();
        setModalMaxHeight(this);
    });


    function ShowConCir(id) {
        $("#myEditModal").find('.modal-title').text("Resolve Conflict");
        $("#myEditModal").find('#strErrorMsg').html(id);
        $("#_hId").val(id);

        $("#myEditModal").modal('show');
    }

    function KeepLocalVersion() {
        var id = $("#_hId").val();
        azureSync.ResolveConflictKeepLocal(id, true);
        localHistory.loadLocalHistory();
        cirOfflineAppSearch.loadLocalCirData();
        $('#myEditModal').modal('hide');
    }

    function KeepServerVersion() {
        var id = $("#_hId").val();
        azureSync.ResolveConflictKeepServer(id, true);
        cirOfflineAppSearch.loadLocalCirData();
        $('#myEditModal').modal('hide');
    }



    $(window).resize(function () {
        if ($('.modal.in').length != 0) {
            setModalMaxHeight($('.modal.in'));
        }
    });

    $("#btnSaveComments").click(function () {
        $('#hdnDownloadRemoteCirID').val(_cirDataIDRemote);
        _processRemote = 1;
        _pdfdataRemote = "";
        $("#myModalRemote").modal('hide');

        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

        Process();

    });

    $("#tabs").tabs();

    Offline.check();
    var client;
    if (Offline.state == "up")
    {
        if (typeof WindowsAzure !== 'undefined') {
            client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
        }
    }
    //var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
    dbtransaction.openDatabase(function () {
        cirOfflineAppSearch.loadCirTypes();
        cirOfflineAppSearch.loadReportTypes();
        cirOfflineAppSearch.loadTurbineRunStatus();

    });

    DoSearch();


    $('#cirSearchButton').click(function () {
        console.log('hello');
        $('#searchLi').slideToggle(500);

        if ($('#iconSearch').hasClass('down')) {
            $('#iconSearch').removeClass('fa-chevron-circle-down');
            $('#iconSearch').removeClass('down');
            $('#iconSearch').addClass('fa-chevron-circle-up');
            $('#iconSearch').addClass('up');
        }
        else {
            console.log('yes');
            $('#iconSearch').removeClass('fa-chevron-circle-up');
            $('#iconSearch').removeClass('up');
            $('#iconSearch').addClass('fa-chevron-circle-down');
            $('#iconSearch').addClass('down');
        }

    });
    $('#linkCirSearch').click(function () {

        var queryString = '';
        if ($('#txtSearchCirID').val().trim() != '') {
            queryString += 'CirID=' + $('#txtSearchCirID').val();
        }

        if ($('#txtSearchCirName').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'Name=' + $('#txtSearchCirName').val();
        }

        if ($('#txtSearchCimCase').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'CimCase=' + $('#txtSearchCimCase').val();
        }

        if ($('#ddlSearchCirType :selected').val() != '0') {

            if (queryString != '')
                queryString += '#';

            queryString += 'CirType=' + $('#ddlSearchCirType :selected').val();
        }

        if ($('#ddlSearchReportType :selected').val() != '0') {

            if (queryString != '')
                queryString += '#';

            queryString += 'ReportType=' + $('#ddlSearchReportType :selected').val() + '#ReportTypeName=' + $('#ddlSearchReportType :selected').text();
        }

        if ($('#txtSearchCountry').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'Country=' + $('#txtSearchCountry').val();
        }
        if ($('#txtSearchSite').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'Site=' + $('#txtSearchSite').val();
        }


        if ($('#txtSearchTurbineType').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'TurbineType=' + $('#txtSearchTurbineType').val();
        }

        if ($('#txtSearchTurbineNumber').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'TurbineNumber=' + $('#txtSearchTurbineNumber').val();
        }

        if ($('#ddlSearchRunStatus :selected').val() != '0') {

            if (queryString != '')
                queryString += '#';

            queryString += 'RunStatus=' + $('#ddlSearchRunStatus :selected').val();
        }

        if ($('#txtSearchSBU').val().trim() != '') {

            if (queryString != '')
                queryString += '#';

            queryString += 'SBU=' + $('#txtSearchSBU').val();
        }
        if (queryString.trim() == '') {
            NotifyCirMessage('', "Please enter at least one search criteria", 'warning');
            return;
        }
        if (queryString != '')
            window.location.href = '/cir/cir-search#' + queryString;
        else
            window.location.href = '/cir/cir-search';
        if (window.location.href.indexOf("/cir/cir-search") > -1) {
            window.location.reload();
        }
        DoSearch();
    });

    $("#txtSearchCirID,#txtSearchCirName,#txtSearchCimCase,#txtSearchCountry,#txtSearchSite,#txtSearchTurbineType,#txtSearchTurbineNumber,#txtSearchSBU").keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            $('#linkCirSearch').click();
        }

    });
    $('#ddlNumber').change(function () {
        //Modified By Siddharth Chauhan on 06-06-2016. Added _state parameter.
        //to get selected Tab id for filtering the CIR Remote records(UnApproved,Accepted,Rejected). 
        //To show the Sub-Tabs for Remote CIR List(UnApproved,Accepted,Rejected).
        //TaskNo. : 75297 
        // cirOfflineAppSearch.loadRemoteCirData($('#MobAppURL').val(), $('#MobAppID').val(), $("#ddlNumber").val(), 1, _state);


    });

    //Added By Siddharth Chauhan on 06-06-2016.
    //To implement the Delete functionality in Local CIR list. 
    //Fixed the filter earlier filter was not working for the LocalCIR search.
    //TaskNo. : 75302     
    $('body').on('click', '.RemoveCir', function () {
        var cirLocalId = $(this).attr('id');
        if (!cirLocalId)
            return;
        /*if (confirm('Are you sure want to delete this CIR ?')) {
            $('table#cirSearchListLocal tr#data_' + cirLocalId).remove();

            // deleting common data
            dbtransaction.deleteCirCommonDataByID(cirLocalId, function () { console.log('cir common data deleted'); });

            dbtransaction.openDatabase(function () {
                console.log('loading');
                cirOfflineAppSearch.loadLocalCirData($("#ddlNumber").val(), 1);
            });
        }*/

        CirAlert.confirm('Are you sure want to delete this CIR ?', 'Cir App', 'Yes', 'No', 'question').done(function () {

            $('table#cirSearchListLocal tr#data_' + cirLocalId).remove();

            // deleting common data
            dbtransaction.deleteCirCommonDataByID(cirLocalId, function () { console.log('cir common data deleted'); });

            dbtransaction.openDatabase(function () {
                console.log('loading');
                cirOfflineAppSearch.loadLocalCirData($("#ddlNumber").val(), 1);
            });
        });



    });


    //Added By Siddharth Chauhan on 06-06-2016.
    //to get selected Tab id for filtering the CIR Remote records(UnApproved,Accepted,Rejected). 
    //To show the Sub-Tabs for Remote CIR List(UnApproved,Accepted,Rejected).
    //TaskNo. : 75297 

    $("#btnUnApproved").on('click', function () {
        _state = 1;
        _CurrentRemotePage = 1;
        loaddatagrid(_state, _CurrentRemotePage);
    });
    $("#btnAccepted").on('click', function () {
        _state = 2;
        _CurrentRemotePage = 1;
        loaddatagrid(_state, _CurrentRemotePage);
    });
    $("#btnRejected").on('click', function () {
        _state = 3;
        _CurrentRemotePage = 1;
        loaddatagrid(_state, _CurrentRemotePage);
    });

    var loading = 0;
    $('#GlobalSearchExportExcel').click(function (e) {

        //fnExcelReport();

        //var data = $('#cirSearchListRemote');
        //window.open('data:application/vnd.ms-excel,' + encodeURIComponent(data[0].outerHTML));
        //e.preventDefault();

        if (loading == 1)
            return;
        loading = 1;
        if (resultdata != null || resultdata.length > 0)
            waitingDialog.show('please wait..', { dialogsize: 'sm', progresstype: 'primary' });

        try {
            var excelData = cirOfflineAppSearch.getExcleRows(resultdata)
            JSONToXlSXConvertor(excelData, "RemoteCIR_GlobalSearch", true);
        }
        catch (err) {
            NotifyCirMessage("Error", err, "danger")
        }
        waitingDialog.hide();
        loading = 0;
    });
});

var loaddatagrid = function loaddatagrid(_state, _CurrentRemotePage) {
    //_state = 3;
    //_CurrentRemotePage = 1
    _RemoteDataTable.clear().draw();
    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    cirOfflineAppSearch.loadRemoteCirData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);

    if (_state == 1) {
        $("#btnUnApproved").attr("style", "border:2px solid #000000")
        $("#btnAccepted").attr("style", "")
        $("#btnRejected").attr("style", "")

    } else if (_state == 2) {
        $("#btnAccepted").attr("style", "border:2px solid #000000")
        $("#btnUnApproved").attr("style", "")
        $("#btnRejected").attr("style", "")
    }
    else if (_state == 3) {
        $("#btnRejected").attr("style", "border:2px solid #000000")
        $("#btnAccepted").attr("style", "")
        $("#btnUnApproved").attr("style", "")
    }
};

var getDate = function getDate(date) {
    var today = new Date(date);
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    return dd + '-' + mm + '-' + yyyy;
}
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? '' : sParameterName[1];
        }
    }
};

$(window).scroll(function () {
    if ($('#btnLazyLoad').is(":visible")) {
        var t = $('#btnLazyLoad').isOnScreen();
        if (t == true) {
            cirOfflineAppSearch.lazyLoad();
        }
    }
});

$.fn.isOnScreen = function () {

    var viewport = {};
    viewport.top = $(window).scrollTop();
    viewport.bottom = viewport.top + $(window).height();
    var bounds = {};
    bounds.top = this.offset().top;
    bounds.bottom = bounds.top + this.outerHeight();
    return ((bounds.top <= viewport.bottom) && (bounds.bottom >= viewport.top));
}

function fnExcelReport() {
    var tab_text = "<table border='2px'><tr bgcolor='#87AFC6'>";
    var textRange; var j = 0;
    //var data = $('#cirSearchListRemote');
    tab = document.getElementById('cirSearchListRemote'); // id of table

    for (j = 0 ; j < tab.rows.length ; j++) {
        tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
        //tab_text=tab_text+"</tr>";
    }

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
    {
        txtArea1.document.open("txt/html", "replace");
        txtArea1.document.write(tab_text);
        txtArea1.document.close();
        txtArea1.focus();
        sa = txtArea1.document.execCommand("SaveAs", true, "RemoteCIR_GlobalSearch.xlsx");
    }
    else                 //other browser not tested on IE 11
        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

    return (sa);
}

//Added by Siddharth Chauhan on 02-06-2016
//To retain the values in the search criteria fields after cliking on search icon.
//Task No. : 75294
function RetainCirSearchValues() {
    var searchCirID = getQueryStringValueHash("CirID");
    var searchCirName = getQueryStringValueHash("Name");
    var searchCimCase = getQueryStringValueHash("CimCase");
    var searchCountry = getQueryStringValueHash("Country");
    var searchSite = getQueryStringValueHash("Site");
    var searchTurbineType = getQueryStringValueHash("TurbineType");
    var searchTurbineNumber = getQueryStringValueHash("TurbineNumber");
    var searchRunStatus = getQueryStringValueHash("RunStatus");
    var searchSBU = getQueryStringValueHash("SBU");
    var searchCirType = getQueryStringValueHash("CirType");
    var searchReportType = getQueryStringValueHash("ReportType");
    var searchReportTypeName = getQueryStringValueHash("ReportTypeName");

    //Added by Siddharth Chauhan on 02-06-2016
    //To retain the values in the search criteria fields after cliking on search icon.
    //Task No. : 75294
    $('#txtSearchCirID').val((searchCirID && searchCirID != '') ? searchCirID : "");
    $('#txtSearchCirName').val((searchCirName && searchCirName != '') ? searchCirName : "");
    $('#txtSearchCimCase').val((searchCimCase && searchCimCase != '') ? searchCimCase : "");
    $('#txtSearchCountry').val((searchCountry && searchCountry != '') ? searchCountry : "");
    $('#txtSearchSite').val((searchSite && searchSite != '') ? searchSite : "");
    $('#txtSearchTurbineType').val((searchTurbineType && searchTurbineType != '') ? searchTurbineType : "");
    $('#txtSearchTurbineNumber').val((searchTurbineNumber && searchTurbineNumber != '') ? searchTurbineNumber : "");
    $('#txtSearchSBU').val((searchSBU && searchSBU != '') ? searchSBU : "");
    //$('#ddlSearchCirType').val((searchCirType && searchCirType != '0') ? searchCirType : "0");
    //$('#ddlSearchReportType').val((searchReportType && searchReportType != '0') ? searchReportType : "0");
    //$('#ddlSearchRunStatus').val((searchRunStatus && searchRunStatus != '0') ? searchRunStatus : "");

    if ((searchCirName && searchCirName != '') || (searchCimCase && searchCimCase != '') || (searchCountry && searchCountry != '') || (searchSite && searchSite != '') || (searchTurbineType && searchTurbineType != '') || (searchTurbineNumber && searchTurbineNumber != '') || (searchSBU && searchSBU != '') || (searchCirType && searchCirType != '0') || (searchReportType && searchReportType != '0') || (searchRunStatus && searchRunStatus != '0')) {
        if ($('#iconSearch').hasClass('down')) {
            $('#searchLi').css('display', 'list-item');
            $('#iconSearch').removeClass('fa-chevron-circle-down');
            $('#iconSearch').removeClass('down');
            $('#iconSearch').addClass('fa-chevron-circle-up');
            $('#iconSearch').addClass('up');
        }
    }
    $("#searchLi input").each(function (index) {
        if ($(this).val() != null && $(this).val().trim() != "") {
            $(this).addClass('bold');
        }
        else {
            $(this).removeClass('bold');
        }
    });

}


//Added by Siddharth Chauhan on 20-06-2016.
// To show the Actions items in Remote CIR Search List.                                        
//Task No. 75299
function Action(type, cirDataId, cirid, state) {
    _cirId = cirid;
    if (type == 1) {
        ViewDetails(cirDataId);
    }
    if (type == 2) {
        // var cirid = $("#hdnCirID" + key).val();
        $('#hdnDownloadRemoteCirID').val(cirid);
        downloadPDF();

    }
    if (type == 3) {
        //var cirDataDetail = {
        //    cirDataId: cirDataId,
        //    cirId: "",
        //    cirState: state,
        //    filename: "",
        //    componentType: "",
        //    cIMCaseNumber: "",
        //    reportType: "",
        //    turbineType: "",
        //    turbineNumber: "",
        //    progress: 8,
        //    modifiedBy: CurrentUserInfo.Name,
        //    comment: "",
        //    locked: 1,
        //    lockedBy: CurrentUserInfo.Name
        //}
        
        var NewFormIOcirId = $('#hdnAppCirId').val();
        if (cirid >= NewFormIOcirId) {
            location.href = "/cir/formio-cir#id=" + cirid + "&cirDataId=" + cirDataId + "&state=" + state; 
            return false;
        }
        //var cirid = $("#hdnCirID" + key).val();
        location.href = "/cir/manage-cir?remotecirID=" + cirid;


       // var releaseDate = new Date(2018, 2, 26);
        //CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
        //    var error = result.error;
        //    var msg = result.message;
        //    if (error == 1) {
        //        NotifyCirMessage('Error : ', msg, 'danger');
        //        return false;
        //    }
        //    //var cirid = $("#hdnCirID" + cirid).val();
        //    //var cirCreatedOnValue = getDate($("#hdnCreatedDate" + cirid).val()).split("-");
        //    //var cirCreatedOnDate =
        //    //    new Date(cirCreatedOnValue[2], cirCreatedOnValue[1] - 1, cirCreatedOnValue[0]);

        //    //if (cirCreatedOnDate >= releaseDate) {
        //    var NewFormIOcirId = $('#hdnAppCirId').val();
        //    if (cirid >= NewFormIOcirId)
        //    {
        //        location.href = "/cir/formio-cir#id=" + cirid;
        //        return false;
        //    }
        //    //var cirid = $("#hdnCirID" + key).val();
        //    location.href = "/cir/manage-cir?remotecirID=" + cirid;
        //});

    }

    _cirDataIDRemote = cirDataId;
    if (type == 4) {
        _progressRemote = 2;
        _stateRemote = state;
        $("#txtCommentsRemote").val("");
        $("#myModalRemote").find('.modal-title').text('Approve CIR');
        $("#myModalRemote").modal('show');
    }
    if (type == 5) {
        _progressRemote = (state == 1) ? 3 : 4;
        _stateRemote = state;
        $("#txtCommentsRemote").val("");
        $("#myModalRemote").find('.modal-title').text(((state == 1) ? 'Reject CIR' : 'Move CIR to Submitted'));
        $("#myModalRemote").modal('show');
    }
    if (type == 6) {
        _progressRemote = 7;
        _stateRemote = state;
        $("#txtCommentsRemote").val("");
        $("#myModalRemote").find('.modal-title').text('Delete CIR');
        $("#myModalRemote").modal('show');
    }
    //if (type == 5)
    //    Reject(key);

}

var DataForExcel = [];
function GenerateExcel() {
    if (loadingRemote == 1)
        return;
    loadingRemote = 1;
    DataForExcel = [];

    $('#divExcelGenWait').hide();
    $('#ExcelExportModal .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);

    ReadDataForExcel(_state, 1, function (data) {

        $('#divExcelGenWait').show();
        try {
            JSONToXlSXConvertor(data, "cirSearchjSon", true);
        }
        catch (err) {
            NotifyCirMessage("Error", err, "danger")
        }
        //waitingDialog.hide();
        $('#ExcelExportModal').modal('hide');
        loading = 0;
    });
}

function ReadDataForExcel(st, cp, cirCallback) {

    try {

        var searchCirID = getQueryStringValueHash("CirID");
        var searchCirName = getQueryStringValueHash("Name");
        var searchCirType = getQueryStringValueHash("CirType");
        var searchReportType = getQueryStringValueHash("ReportType");
        var searchReportTypeName = getQueryStringValueHash("ReportTypeName");
        var searchCimCase = getQueryStringValueHash("CimCase");
        var searchCountry = getQueryStringValueHash("Country");
        var searchSite = getQueryStringValueHash("Site");
        var searchTurbineType = getQueryStringValueHash("TurbineType");
        var searchTurbineNumber = getQueryStringValueHash("TurbineNumber");
        var searchRunStatus = getQueryStringValueHash("RunStatus");
        var searchSBU = getUrlParamgetQueryStringValueHasheter("SBU");

        //Modified by Siddharth Chauhan on 08-06-2016
        //To optimize the code used JSON object instead of string concatination for JSON object.
        var cirSearchjSon = {};
        if (searchCirType && searchCirType != '0') {
            cirSearchjSon.componentInspectionReportTypeId = searchCirType;
        }
        else {
            cirSearchjSon.componentInspectionReportTypeId = 0;
        }

        if (searchReportType && searchReportType != '0') {
            cirSearchjSon.reportTypeId = searchReportType;
        }
        else {
            cirSearchjSon.reportTypeId = 0;
        }

        if (searchCirID && searchCirID != '0') {
            cirSearchjSon.cirID = searchCirID;
        }
        else {
            cirSearchjSon.cirID = 0;
        }

        if (searchCirName && searchCirName != '') {
            cirSearchjSon.name = searchCirName;
        }
        else {
            cirSearchjSon.name = "";
        }

        if (searchCountry && searchCountry != '') {
            cirSearchjSon.country = searchCountry;
        }
        else {
            cirSearchjSon.country = "";
        }
        if (searchSite && searchSite != '') {
            cirSearchjSon.siteName = searchSite;
        }
        else {
            cirSearchjSon.siteName = "";
        }

        if (searchTurbineType && searchTurbineType != '') {
            cirSearchjSon.turbineType = searchTurbineType;
        }
        else {
            cirSearchjSon.turbineType = "";
        }

        if (searchSBU && searchSBU != '') {
            cirSearchjSon.sbu = searchSBU;
        }
        else {
            cirSearchjSon.sbu = "";
        }

        if (searchCimCase && searchCimCase != '0') {
            cirSearchjSon.cimCaseNumber = searchCimCase;
        }
        else {
            cirSearchjSon.cimCaseNumber = 0;
        }

        if (searchRunStatus && searchRunStatus != '0') {
            cirSearchjSon.runStatus = searchRunStatus;
        }
        else {
            cirSearchjSon.runStatus = 0;
        }

        if (searchTurbineNumber && searchTurbineNumber != '') {
            cirSearchjSon.turbineNumber = searchTurbineNumber;
        }
        else {
            cirSearchjSon.turbineNumber = 0;
        }

        cirSearchjSon.state = st;

        var searchObj = {};
        searchObj.currentPageNumber = cp;
        searchObj.recordsPerPage = 1500;
        searchObj.totalRecordCount = 0;

        cirSearchjSon.search = searchObj;
        console.log(cirSearchjSon);

        CallClientApi("CirSearch", "POST", cirSearchjSon).done(function (result) {
            //var arrData = typeof result.data != 'object' ? JSON.parse(result.data) : result.data;          
            var arrData = result;
            for (var i = 0, d; d = arrData[i]; i++) {
                DataForExcel.push(d);
            }

            var tCount = 0;
            if (st == 0)
                tCount = result[0].totalRecords;
            if (st == 1)
                tCount = result[0].totalUnApprovedRecords;
            if (st == 2)
                tCount = result[0].totalAcceptedRecords;
            if (st == 3)
                tCount = result[0].totalRejectedRecords;
            if (tCount > 60000)
                tCount = 60000;
            var ExcelTotalPages = parseInt(tCount / searchObj.recordsPerPage) + 1
            var per = parseInt((DataForExcel.length * 100) / tCount);
            $('#ExcelExportModal .progress-bar').css('width', per + '%').attr('aria-valuenow', per);
            if (searchObj.currentPageNumber == ExcelTotalPages) {
                par = 100;
                $('#ExcelExportModal .progress-bar').css('width', per + '%').attr('aria-valuenow', per);
                cirCallback(DataForExcel);
            }
            else {
                if (result.currentPageNumber == ExcelTotalPages - 1)
                    $('#divExcelGenWait').show();
                ReadDataForExcel(st, searchObj.currentPageNumber + 1, cirCallback);
            }
        });

    }
    catch (err) {
        //waitingDialog.hide();
        loading = 0;
        callback(DataForExcel);
        NotifyCirMessage("Error", err, "danger")
    }
}


//Added by Siddharth Chauhan on 20-06-2016.
// To show the Actions items in Remote CIR Search List.                                        
//Task No. 75299
function Process() {

    var cirDataDetail = {
        cirDataId: _cirDataIDRemote,
        cirId: "",
        cirState: _stateRemote,
        filename: "",
        PdfDataUri: "",
        componentType: "",
        cIMCaseNumber: "",
        reportType: "",
        turbineType: "",
        turbineNumber: "",
        progress: _progressRemote,
        modifiedBy: CurrentUserInfo.Name,
        comment: $("#txtComments").val(),
        locked: 1,
        lockedBy: CurrentUserInfo.Name
    }


    CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
        var error = result.error;
        var msg = result.message;
        waitingDialog.hide();
        $("#waitMsg").text("Please Wait..");
        if (error == 1) {
            NotifyCirMessage('Error : ', msg, 'danger');
            return false;
        }
        else {
            var msg = '';
            var cirid = _cirId;
            var comment = $("#txtComments").val() == undefined ? "" : $("#txtComments").val();
            switch (_progressRemote) {
                case 2: CallSyncApi("CirSubmissionData/Approve?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                    .done(function () {
                        msg = "CIR has been approved!";
                        NotifyCirMessage(' ', msg, 'info');
                    }); break;
                case 3: CallSyncApi("CirSubmissionData/Reject?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                    .done(function () {
                        msg = "CIR has been rejected!";
                        NotifyCirMessage(' ', msg, 'info');
                    }); break;
                case 4: CallSyncApi("CirSubmissionData/BackToSubmit?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                    .done(function () {
                        msg = "CIR has been moved to Submitted section!";
                        NotifyCirMessage(' ', msg, 'info');
                    }); break;
                case 7: CallSyncApi("CirSubmissionData/Delete?reportId=" + cirid, "DELETE", "")
                    .done(function () {
                        msg = "CIR has been deleted!";
                        NotifyCirMessage(' ', msg, 'info');

                    }); break;
                default:
                    break;
            }

                //var msg = (_progressRemote == 2) ? "CIR has been approved!" : "";
                //if (_progressRemote == 3) msg = "CIR has been rejected!";
                //if (_progressRemote == 4) msg = "CIR has been moved to Submitted Section!";
                //if (_progressRemote == 7) msg = "CIR has been deleted!";
                //NotifyCirMessage(' ', msg, 'info');            
        }
            _CurrentRemotePage = 1;
            _RemoteDataTable.clear().draw();
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            cirOfflineAppSearch.loadRemoteCirData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);
            _processRemote = 0;
            _pdfdataRemote = "";
        });   
}




//Added by Siddharth Chauhan on 20-06-2016.
// To show the Actions items in Remote CIR Search List.                                        
//Task No. 75299
function setModalMaxHeight(element) {
    this.$element = $(element);
    this.$content = this.$element.find('.modal-content');
    var borderWidth = this.$content.outerHeight() - this.$content.innerHeight();
    var dialogMargin = $(window).width() < 768 ? 20 : 60;
    var contentHeight = $(window).height() - (dialogMargin + borderWidth);
    var headerHeight = this.$element.find('.modal-header').outerHeight() || 0;
    var footerHeight = this.$element.find('.modal-footer').outerHeight() || 0;
    var maxHeight = contentHeight - (headerHeight + footerHeight);

    this.$content.css({
        'overflow': 'hidden'
    });

    this.$element
      .find('.modal-body').css({
          'max-height': maxHeight,
          'overflow-y': 'auto'
      });

}

function downloadPDF() {
    var ids = $('#hdnDownloadRemoteCirID').val();
    //pdfPending = ids.split(',');
    //pdfPendingIndex = 0;
    waitingDialog.show('Downloading PDF..', { dialogSize: 'sm', progressType: 'primary' });
    //zip = new JSZip();
    //downloadPDF(pdfPending[pdfPendingIndex]);

    CallSyncApi("CirSubmissionData/CirPdfFile?cirId=" + ids, "PUT", "").done(function (result) {
        waitingDialog.hide();
        if (result) {
            if (result.result.downloadUrl) {
                var blob = b64toBlob(result.result.downloadUrl, "application/pdf");
                saveAs(blob, result.result.fileName);
                var iOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
                if (iOS) {
                    window.location = "data:application/pdf;base64," + result.result.downloadUrl;
                    openTab("data:application/pdf;base64," + result.result.downloadUrl);
                }
            }
            else {
                NotifyCirMessage('Error : ', "Cir PDF has not been generated yet!, Please try again in a minute", 'danger');
            }

        }
        else {
            NotifyCirMessage('Error : ', "Cir PDF loading error", 'danger');
        }
    });

}


function findcountstate(tstunapproved, tstaccepted, tstrejected) {
    var arr = [{ "ID": "tstunapproved", "value": tstunapproved, "state": 1 }, { "ID": "tstaccepted", "value": tstaccepted, "state": 2 }, { "ID": "tstrejected", "value": tstrejected, "state": 3 }];
    var max, newstate;
    for (var i = 0 ; i < arr.length ; i++) {
        if (!max || parseInt(arr[i].value) > parseInt(max.value))
            max = arr[i];
    }
    return max.state;
}