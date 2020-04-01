<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage GBXIR
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/jQueryUI/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery.ui.accordion.css" rel="stylesheet" />
    <script src="../Js/Excel/Blob.js"></script>
    <script src="../Js/FileSaver.min.js"></script>
    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>

    <script src="../Js/jquery.dataTables.min.js"></script>
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/tablesaw.css" rel="stylesheet" type="text/css" />

    <style>
        #divWait {
            position: absolute;
            z-index: 1015;
            top: 5%;
            left: 40%;
            width: 200px;
            height: 80px;
            background-color: white;
            border: 1px solid #000000;
            text-align: center;
        }

        .well-White {
            width: 100%;
        }

        table.dataTable th {
            font-size: 11px;
            padding: 5px 5px 5px 5px;
            color: white;
            font-weight: normal;
            white-space: nowrap;
        }

        .page-selection {
            padding: 5px;
            margin-bottom: 10px;
            height: 40px;
        }

        .table-striped {
            line-height: 10px;
            vertical-align: middle;
            padding: 3px;
        }

        .cirback-top:hover {
            color: #fff !important;
            background-color: #0072BB;
            text-decoration: none;
        }

        .btnActionOnTop {
            width: 135px;
        }

        .cirback-top {
            display: none;
            position: fixed;
            bottom: 1rem;
            right: 1rem;
            width: 3.2rem;
            height: 3.2rem;
            line-height: 3.2rem;
            font-size: 1.4rem;
            color: #000000;
            background-color: #3eaee8;
            text-decoration: none;
            border-radius: 3.2rem;
            text-align: center;
            cursor: pointer;
        }
    </style>

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Manage Gearbox Inspection Report</legend>
                            <div class="pull-right">
                                <button id="inbox" class="btn btn-xs btn-primary" type="button" onclick="window.open('/CirView/manage-cirviewlist?rpt=gbxir', '_self');">
                                    <i style="color: #ffffff;" class="fa fa-plus"></i>Create new GBXIR
                                </button>
                            </div>
                            <a href="javascript:void(0);" id="searchLink" class="btn btn-primary">Quick Search <i id="iconGBXirQuickSearch" class="fa fa-chevron-circle-down down"></i></a>
                            <div id="divSearchItems" style="display: none;">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">GBXir ID</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtGBXirID" class="form-control" style="width: 50%;" placeholder="GBXir ID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Turbine Number</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtTurbineNo" class="form-control" style="width: 50%;" placeholder="Turbine Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Gearbox Serial No.</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtBladeSlno" class="form-control" style="width: 50%;" placeholder="Gearbox Serial No." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Created</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtCreated" readonly="readonly" class="form-control" style="width: 50%;" placeholder="Created" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Created By</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtCreatedBy" class="form-control" style="width: 50%;" placeholder="Created By" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">SBU</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtSBU" class="form-control" style="width: 50%;" placeholder="SBU" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Site Name</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtSiteName" class="form-control" style="width: 50%;" placeholder="Site Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label"></label>
                                    <div class="col-lg-9">
                                        <a href="javascript:void(0);" id="linkSearch" class="btn btn-primary">Search</a>
                                    </div>
                                </div>
                            </div>

                        </fieldset>

                        <div class="bs-example form-horizontal">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: left;">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: left;">
                                            Showing
                                            <select id="ddlNumber">
                                                <option value="10">10</option>
                                                <option value="20">20</option>
                                                <option value="30">30</option>
                                                <option value="40">40</option>
                                                <option value="50">50</option>
                                                <option value="100">100</option>
                                            </select>
                                            records
                                        </div>
                                        <div class="col-xs-12" style="text-align: left;">
                                            <div id="page-selection1" class="page-selection"></div>
                                        </div>
                                    </div>
                                    <table id="tableGBXIR" class="tablesaw sorted" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th style="width: 8%;">Action</th>
                                                <th>Name </th>
                                                <th>GBXIR ID</th>
                                                <th>Rev No</th>
                                                <th>ReportType</th>
                                                <th>Country</th>
                                                <th>Turbine Type</th>
                                                <th>Turbine Number</th>
                                                <th>SBU</th>
                                                <th>Site</th>
                                                <th>Created</th>
                                                <th>Created  by</th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: left;">
                                            <div id="page-selection2" class="page-selection"></div>
                                        </div>
                                        <div class="col-xs-12" style="text-align: left;">
                                            <label class="control-label" id="lblTotalRecords"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" name="hdnchkDownload" id="hdnchkDownload" />
        <input type="hidden" name="hdnDownloadCirID" id="hdnDownloadCirID" />
        <input type="hidden" id="hdnAppCirId" value="<%= System.Configuration.ConfigurationManager.AppSettings["hdnCirId"] %>" />
    </section>
    <script>
        function Action(type, key) {
            if (type == 1)
                ViewDetails(key);
            if (type == 2) {
                var cirid = key;
                $('#hdnDownloadCirID').val(cirid);
                downloadPDFAll();
            }
            if (type == 3) {
                var cirDataDetail = {
                    cirDataId: key,
                    cirId: "",
                    cirState: 1,
                    filename: "",
                    componentType: "",
                    cIMCaseNumber: "",
                    reportType: "",
                    turbineType: "",
                    turbineNumber: "",
                    progress: 8,
                    modifiedBy: "",
                    comment: "",
                    locked: 1,
                    lockedBy: ""
                }

                CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
                    var error = result.error;
                    var msg = result.message;
                    if (error == 1) {
                        NotifyCirMessage('Error : ', msg, 'danger');
                        return false;
                    }
                    var NewFormIOcirId = $('#hdnAppCirId').val();
                    if (key >= NewFormIOcirId) {
                        var cirDataId = $("#iconEdit").data("cirdataid");
                        location.href = "/cir/formio-cir#id=" + key + "&cirDataId=" + cirDataId;
                        return false;
                    }
                    location.href = "/cir/manage-cir?remotecirID=" + key;
                });
            }
        }
        var pdfPending = {};
        var pdfPendingIndex = 0;
        function downloadPDFAll() {
            var ids = $('#hdnDownloadCirID').val();
            waitingDialog.show('Downloading PDF..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("CirPdfFile/" + ids, "POST", "").done(function (result) {
                waitingDialog.hide();
                if (result) {

                    if (result.downloadUrl) {
                        var blob = b64toBlob(result.downloadUrl, "application/octet-stream");
                        saveAs(blob, result.fileName);
                    }
                    else {
                        NotifyCirMessage('Error : ', "Cir PDF has not been generated yet!", 'danger');
                    }

                }
                else {
                    NotifyCirMessage('Error : ', "Cir PDF loading error", 'danger');
                }
            });

        }
        $(document).ready(function () {
            var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');

            waitingDialog.hide();
            $('#searchLink').click(function () {
                $('#divSearchItems').slideToggle(500);
                if ($('#iconGBXirQuickSearch').hasClass('down')) {
                    $('#iconGBXirQuickSearch').removeClass('fa-chevron-circle-down');
                    $('#iconGBXirQuickSearch').removeClass('down');
                    $('#iconGBXirQuickSearch').addClass('fa-chevron-circle-up');
                    $('#iconGBXirQuickSearch').addClass('up');
                }
                else {
                    $('#iconGBXirQuickSearch').removeClass('fa-chevron-circle-up');
                    $('#iconGBXirQuickSearch').removeClass('up');
                    $('#iconGBXirQuickSearch').addClass('fa-chevron-circle-down');
                    $('#iconGBXirQuickSearch').addClass('down');
                }
            });

            $('#linkSearch').click(function () {
                loadGBXirData(1, $(this).val());
            });

            $("#txtCreated").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });

            var oTable;

            $('#ddlNumber').change(function () {
                loadGBXirData(1, $(this).val());
            });

            $('body').on('click', '.expandGrid', function () {
                var id = $(this).attr('id');
                if (id) {
                    $('#Child' + id).slideToggle(200);
                    if ($('#icon' + id).hasClass('fa-plus-square-o')) {
                        $('#icon' + id).removeClass('fa-plus-square-o')
                        $('#icon' + id).addClass('fa-minus-square-o')
                    }
                    else {
                        $('#icon' + id).removeClass('fa-minus-square-o')
                        $('#icon' + id).addClass('fa-plus-square-o')
                    }
                }
            });

            var downloadURI = function (uri, name) {
                var link = document.createElement("a");
                link.download = name;
                link.href = uri;
                link.click();
            }

            $('body').on('click', '.downloadGBXirWord,.downloadGBXirPdf', function () {
                var objAnchor = $(this);
                var id = $(this).attr('id');
                var downloadUrl = '';
                var isPdf = 0;
                waitingDialog.show('Please Wait..Downloading..', { dialogSize: 'sm', progressType: 'primary' });
                if ($(this).hasClass('downloadGBXirWord')) {
                    objAnchor.find('#iconWord').removeClass('fa-file-word-o');
                    objAnchor.find('#iconWord').addClass('fa-refresh');
                    objAnchor.find('#iconWord').addClass('fa-spin');
                    downloadUrl = 'GBXirWordFile/' + id;
                    isPdf = 0;
                }
                else {
                    objAnchor.find('#iconPdf').removeClass('fa-file-pdf-o');
                    objAnchor.find('#iconPdf').addClass('fa-refresh');
                    objAnchor.find('#iconPdf').addClass('fa-spin');
                    downloadUrl = 'GBXirPdfFile/' + id;
                    isPdf = 1;
                }

                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            console.log(currentuser);
                            currentuser.forEach(function (item) {
                                client.currentUser = item.objet;
                            });
                            client.invokeApi(downloadUrl, {
                                method: 'POST'
                            }).done(function (response) {
                                var resp = response.result;
                                if (resp) {
                                    var blob = b64toBlob(resp.downloadUrl, "application/octet-stream");
                                    saveAs(blob, resp.fileName);
                                    waitingDialog.hide();

                                    if (isPdf == 1) {
                                        objAnchor.find('#iconPdf').removeClass('fa-refresh');
                                        objAnchor.find('#iconPdf').removeClass('fa-spin');
                                        objAnchor.find('#iconPdf').addClass('fa-file-pdf-o');
                                    }
                                    else {
                                        objAnchor.find('#iconWord').removeClass('fa-refresh');
                                        objAnchor.find('#iconWord').removeClass('fa-spin');
                                        objAnchor.find('#iconWord').addClass('fa-file-word-o');
                                    }
                                }
                            }, function (error) {
                                waitingDialog.hide();

                                if (isPdf == 1) {
                                    objAnchor.find('#iconPdf').removeClass('fa-refresh');
                                    objAnchor.find('#iconPdf').removeClass('fa-spin');
                                    objAnchor.find('#iconPdf').addClass('fa-file-pdf-o');
                                }
                                else {
                                    objAnchor.find('#iconWord').removeClass('fa-refresh');
                                    objAnchor.find('#iconWord').removeClass('fa-spin');
                                    objAnchor.find('#iconWord').addClass('fa-file-word-o');
                                }
                                NotifyCirMessage('Error : ', "GBXIR Report cannot be downloaded as it has not been generated. Try to Recreate GBXIR again.", 'danger');

                            });
                        }
                    }
                });
            });

            $('body').on('click', '.removeGBXir', function () {
                var gbxirID = $(this).attr('id');
                var gbxCode = $('#tableGBXIR tr td#td' + gbxirID).text();
                console.log(gbxCode);
                console.log(gbxirID);
                CirAlert.confirm('Are you sure want to delete GBXir ' + gbxCode + ' ?', 'Cir App', 'Yes', 'No', 'Warning').done(function () {
                    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                        if (currentuser) {
                            if (currentuser.length > 0) {
                                currentuser.forEach(function (item) {
                                    client.currentUser = item.objet;
                                });
                                client.invokeApi('GBXirDelete/' + gbxirID, {
                                    method: 'DELETE'
                                }).done(function (response) {
                                    var resp = response.result;
                                    if (resp) {
                                        $('table#tableGBXIR tr#' + gbxirID).remove();
                                        $('table#tableGBXIR tr#Child' + gbxirID).remove();
                                    }
                                }, function (error) {
                                    console.log(error);
                                });
                            }
                        }
                    });

                });
            });

            var loadGBXirData = function (paramCurrentPage, paramNumberOfRecords) {
                $('table#tableGBXIR tr.item').remove();
                $('#tableGBXIR').append('<tr class="item"><td colspan="13" style="text-align:center;height: 65px;"><i class="loadersign fa fa-spin fa-lg"></i></td></td>');

                var gbxirSearchString = '{';

                if ($('#txtGBXirID').val() != '' && $('#txtGBXirID').val() > 0)
                    gbxirSearchString += '"GBXirDataID":"' + $('#txtGBXirID').val() + '",';
                else
                    gbxirSearchString += '"GBXirDataID":"0",';

                if ($('#txtBladeSlno').val() != '')
                    gbxirSearchString += '"BladeSerialNos":"' + $('#txtBladeSlno').val() + '",';
                else
                    gbxirSearchString += '"BladeSerialNos":"",';

                if ($('#txtCreated').val() != '')
                    gbxirSearchString += '"strCreated":"' + $('#txtCreated').val() + '",';
                else
                    gbxirSearchString += '"strCreated":"1900-01-01",';

                if ($('#txtCreatedBy').val() != '')
                    gbxirSearchString += '"CreatedBy":"' + $('#txtCreatedBy').val() + '",';
                else
                    gbxirSearchString += '"CreatedBy":"",';

                gbxirSearchString += '"ComponentInspectionReport": {';

                if ($('#txtTurbineNo').val() != '' && $('#txtTurbineNo').val() > 0)
                    gbxirSearchString += '"TurbineNumber":"' + $('#txtTurbineNo').val() + '",';
                else
                    gbxirSearchString += '"TurbineNumber":"0",';

                if ($('#txtSiteName').val() != '')
                    gbxirSearchString += '"SiteName":"' + $('#txtSiteName').val() + '",';
                else
                    gbxirSearchString += '"SiteName":"",';

                if ($('#txtSBU').val() != '')
                    gbxirSearchString += '"SBUName":"' + $('#txtSBU').val() + '"';
                else
                    gbxirSearchString += '"SBUName":""';

                gbxirSearchString += '},';

                gbxirSearchString += '"Search": {';
                if (paramCurrentPage && paramCurrentPage != '') {
                    gbxirSearchString += '"CurrentPageNumber":"' + paramCurrentPage + '"';
                }

                if (paramNumberOfRecords && paramNumberOfRecords != '') {
                    if (gbxirSearchString != '')
                        gbxirSearchString += ",";
                    gbxirSearchString += '"RecordsPerPage":"' + paramNumberOfRecords + '"';
                }
                gbxirSearchString += '}';
                gbxirSearchString += '}';

                console.log(gbxirSearchString);
                var gbxirSearchjSon = jQuery.parseJSON(gbxirSearchString);

                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            currentuser.forEach(function (item) {
                                client.currentUser = item.objet;
                            });

                            client.invokeApi('GBXirSearch', {
                                method: 'POST',
                                body: gbxirSearchjSon
                            }).done(function (response) {
                                var resp = response.result;
                                if (resp) {
                                    var userValidForEditDelete = hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator");
                                    var gbxirHtml = '';
                                    var rowCount = 1;
                                    var totalRecords = 0;
                                    if (resp.length > 0) {
                                        resp.forEach(function (item) {
                                            totalRecords = item.search.totalRecordCount;
                                            gbxirHtml += '<tr class="item" id="' + item.gbxDataID + '">';
                                            if (userValidForEditDelete) {
                                                gbxirHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.gbxDataID + '" class="expandGrid" rel=' + item.gbxDataID + '><i style="color:#0072BB;" id="icon' + item.gbxDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.gbxDataID + '"   href="javascript:void(0);" class="downloadGBXirPdf" title="Download GBXIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.gbxDataID + '"   href="javascript:void(0);" class="downloadGBXirWord"  title="Download GBXIR Word"> <i style="color:#0052cc;" id="iconWord" class="fa fa-file-word-o fa-lg"></i></a><a style="padding: 2px 2px 2px 2px;" title="Delete GBXir" id="' + item.gbxDataID + '" href="javascript:void(0);" class="btn-delete removeGBXir"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a></td>';
                                            }
                                            else {
                                                gbxirHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.gbxDataID + '" class="expandGrid" rel=' + item.gbxDataID + '><i style="color:#0072BB;" id="icon' + item.gbxDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.gbxDataID + '"   href="javascript:void(0);" class="downloadGBXirPdf" title="Download GBXIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i></a></td>';
                                            }

                                            gbxirHtml += '<td id="td' + item.gbxDataID + '">' + item.gbxCode + '</td>';
                                            gbxirHtml += '<td>' + item.gbxDataID + '</td>';
                                            gbxirHtml += '<td>' + item.revisionNumber + '</td>';
                                            gbxirHtml += '<td>' + 'Gearbox' + '</td>';
                                            gbxirHtml += '<td></td>';
                                            gbxirHtml += '<td>' + item.componentInspectionReport.turbineType + '</td>';
                                            gbxirHtml += '<td>' + item.componentInspectionReport.turbineNumber + '</td>';
                                            gbxirHtml += '<td>' + item.componentInspectionReport.sbuName + '</td>';
                                            gbxirHtml += '<td>' + item.componentInspectionReport.siteName + '</td>';
                                            gbxirHtml += '<td>' + getDate(item.created) + '</td>';
                                            gbxirHtml += '<td>' + item.createdBy + '</td>';
                                            gbxirHtml += '</tr>';
                                            gbxirHtml += '<tr class="item" id="Child' + item.gbxDataID + '" style="display:none;">';
                                            gbxirHtml += '<td colspan="13">';
                                            gbxirHtml += '<table id="tableGBXIRChild" class="FlexResponive list">';
                                            gbxirHtml += '<thead class="table-header">';
                                            gbxirHtml += '<tr>';
                                            gbxirHtml += '<th style="width: 8%;">Action</th>';
                                            gbxirHtml += '<th>Name</th>';
                                            gbxirHtml += '<th>Cir ID</th>';
                                            gbxirHtml += '<th>Cim Case</th>';
                                            gbxirHtml += '<th>Component</th>';
                                            gbxirHtml += '<th>Gearbox/n</th>';
                                            gbxirHtml += '<th>Report Type</th>';
                                            gbxirHtml += '<th>Created</th>';
                                            gbxirHtml += '<th>Modified</th>';
                                            gbxirHtml += '</tr>';
                                            gbxirHtml += '</thead>';
                                            gbxirHtml += '<tbody>';
                                            if (item.componentInspectionReportDetails && item.componentInspectionReportDetails.length > 0)
                                                item.componentInspectionReportDetails.forEach(function (childItem) {
                                                    gbxirHtml += '<tr>';
                                                    gbxirHtml += '<td><a title="View CIR details" href="/cir/Cir-Details?ID=' + childItem.cirDataID + '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
                                                    gbxirHtml += '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,' + childItem.cirDataID + ')"></i>';
                                                    if (userValidForEditDelete) {
                                                        gbxirHtml += '&nbsp;<i style="color:#08088A;cursor:pointer" id="iconEdit" data-cirdataid="' + childItem.cirDataID + '" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,' + childItem.componentInspectionReportId + ')"></i></td>';
                                                    }
                                                    gbxirHtml += '<td>' + childItem.cirName + '</td>';
                                                    gbxirHtml += '<td>' + childItem.componentInspectionReportId + '</td>';
                                                    gbxirHtml += '<td>' + childItem.cimCaseNumber + '</td>';
                                                    gbxirHtml += '<td>' + childItem.componentInspectionReportName + '</td>';
                                                    if (childItem.gearbox)
                                                        gbxirHtml += '<td>' + childItem.gearbox.gearboxSerialNumber + '</td>';
                                                    else
                                                        gbxirHtml += '<td></td>';
                                                    gbxirHtml += '<td>Inspection</td>';
                                                    gbxirHtml += '<td>' + getDate(childItem.created) + '</td>';
                                                    gbxirHtml += '<td>' + getDate(childItem.modified) + '</td>';
                                                    gbxirHtml += '</tr>';
                                                });

                                            gbxirHtml += '</tbody>';
                                            gbxirHtml += '</table></td>';
                                            gbxirHtml += '</tr>';
                                            gbxirHtml += '<tr style="display:none;">';
                                            rowCount++;
                                        });

                                        $('table#tableGBXIR tr.item').remove();
                                        $('#tableGBXIR').append(gbxirHtml);

                                        var startNumber = (parseInt((paramCurrentPage - 1) * $("#ddlNumber").val()) + 1);
                                        var lastNumber = (paramCurrentPage * $("#ddlNumber").val());
                                        if (lastNumber > totalRecords)
                                            lastNumber = totalRecords;

                                        $('#lblTotalRecords').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + totalRecords + ' entries');

                                        $('.page-selection').bootpag({
                                            total: parseInt(totalRecords / $('#ddlNumber').val()) + 1,
                                            page: paramCurrentPage,
                                            maxVisible: 5,
                                            leaps: true,
                                            firstLastUse: true,
                                            first: '←',
                                            last: '→',
                                            wrapClass: 'pagination',
                                            activeClass: 'active',
                                            disabledClass: 'disabled',
                                            nextClass: 'next',
                                            prevClass: 'prev',
                                            lastClass: 'last',
                                            firstClass: 'first'
                                        }).on("page", function (event, num) {
                                            loadGBXirData(num, $('#ddlNumber').val());
                                        });
                                    }
                                    else {
                                        $('table#tableGBXIR tr.item').remove();
                                        $('#tableGBXIR').append('<tr class="item"><td colspan="13" style="text-align:center;">No records found</td></td>');
                                    }
                                }
                            }, function (error) {
                                console.log(error);
                                if (error)
                                    NotifyCirMessage('GBXir PDF Download', error.message, 'danger');
                            });
                        }
                    }
                });
            }
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
            $('.tooltip-r').tooltip({
                item: "",
                display: "",
                content: function () {
                    var element = $(this);
                    return element.attr("title");
                }
            });

            loadGBXirData(1, 10);

        });
    </script>
</asp:Content>
