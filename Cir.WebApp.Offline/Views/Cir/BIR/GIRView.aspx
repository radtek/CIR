<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage GIR
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
          width:100%
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
        .btnActionOnTop{
            width:135px;
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
                            <legend>Manage Generator Inspection Report</legend>
                            <div class="pull-right">
                                <button id="inbox" class="btn btn-xs btn-primary" type="button" onclick="window.open('/CirView/manage-cirviewlist?rpt=gir', '_self');">                                    
                                        <i style="color:#ffffff;" class="fa fa-plus"></i> Create new GIR
                                </button>
                            </div>
                            <a href="javascript:void(0);" id="searchLink" class="btn btn-primary">Quick Search <i id="iconGirQuickSearch" class="fa fa-chevron-circle-down down"></i></a>
                            <div id="divSearchItems" style="display: none;">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Gir ID</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtGirID" class="form-control" style="width: 50%;" placeholder="Gir ID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Turbine Number</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtTurbineNo" class="form-control" style="width: 50%;" placeholder="Turbine Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Generator Serial No.</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtGeneratorSlno" class="form-control" style="width: 50%;" placeholder="Generator Serial No." />
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
                                    <%--<div id="girDataViewControl">--%>
                                        <table id="tableGIR" class="tablesaw sorted" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th style="width: 8%;">Action</th>
                                                    <th>Name </th>
                                                    <th>GIR ID</th>
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
            CallClientApi("CirPdfFileGIR/" + ids, "POST", "").done(function (result) {
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
                if ($('#iconGirQuickSearch').hasClass('down')) {
                    $('#iconGirQuickSearch').removeClass('fa-chevron-circle-down');
                    $('#iconGirQuickSearch').removeClass('down');
                    $('#iconGirQuickSearch').addClass('fa-chevron-circle-up');
                    $('#iconGirQuickSearch').addClass('up');
                }
                else {
                    $('#iconGirQuickSearch').removeClass('fa-chevron-circle-up');
                    $('#iconGirQuickSearch').removeClass('up');
                    $('#iconGirQuickSearch').addClass('fa-chevron-circle-down');
                    $('#iconGirQuickSearch').addClass('down');
                }
            });

            $('#linkSearch').click(function () {
                loadGirData(1, $(this).val());
            });

            $("#txtCreated").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });

            var oTable;

            $('#ddlNumber').change(function () {
                loadGirData(1, $(this).val());
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

            $('body').on('click', '.downloadGirWord,.downloadGirPdf', function () {
                var objAnchor = $(this);
                var id = $(this).attr('id');
                var downloadUrl = '';
                var isPdf = 0;
                waitingDialog.show('Please Wait..Downloading..', { dialogSize: 'sm', progressType: 'primary' });
                if ($(this).hasClass('downloadGirWord')) {
                    objAnchor.find('#iconWord').removeClass('fa-file-word-o');
                    objAnchor.find('#iconWord').addClass('fa-refresh');
                    objAnchor.find('#iconWord').addClass('fa-spin');
                    downloadUrl = 'GirWordFile/' + id;
                    isPdf = 0;
                }
                else {
                    objAnchor.find('#iconPdf').removeClass('fa-file-pdf-o');
                    objAnchor.find('#iconPdf').addClass('fa-refresh');
                    objAnchor.find('#iconPdf').addClass('fa-spin');
                    downloadUrl = 'GirPdfFile/' + id;
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
                                NotifyCirMessage('Error : ', "GIR Report cannot be downloaded as it has not been generated. Try to Recreate GIR again.", 'danger');

                            });
                        }
                    }
                });
            });

            $('body').on('click', '.removeGir', function () {
                var girID = $(this).attr('id');
                var girCode = $('#tableGIR tr td#td' + girID).text();
                console.log(girCode);
                console.log(girID);
                CirAlert.confirm('Are you sure want to delete Gir ' + girCode + ' ?', 'Cir App', 'Yes', 'No', 'Warning').done(function () {
                    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                        if (currentuser) {
                            if (currentuser.length > 0) {
                                currentuser.forEach(function (item) {
                                    client.currentUser = item.objet;
                                });
                                client.invokeApi('GirDelete/' + girID, {
                                    method: 'DELETE'
                                }).done(function (response) {
                                    var resp = response.result;
                                    if (resp) {
                                        $('table#tableGIR tr#' + girID).remove();
                                        $('table#tableGIR tr#Child' + girID).remove();
                                    }
                                }, function (error) {
                                    console.log(error);
                                });
                            }
                        }
                    });

                });
            });

            var loadGirData = function (paramCurrentPage, paramNumberOfRecords) {
                $('table#tableGIR tr.item').remove();
                $('#tableGIR').append('<tr class="item"><td colspan="13" style="text-align:center;height: 65px;"><i class="loadersign fa fa-spin fa-lg"></i></td></td>');

                var girSearchString = '{';

                if ($('#txtGirID').val() != '' && $('#txtGirID').val() > 0)
                    girSearchString += '"GirDataID":"' + $('#txtGirID').val() + '",';
                else
                    girSearchString += '"GirDataID":"0",';

                if ($('#txtGeneratorSlno').val() != '')
                    girSearchString += '"GeneralSerialNos":"' + $('#txtGeneratorSlno').val() + '",';
                else
                    girSearchString += '"GeneralSerialNos":"",';

                if ($('#txtCreated').val() != '')
                    girSearchString += '"strCreated":"' + $('#txtCreated').val() + '",';
                else
                    girSearchString += '"strCreated":"1900-01-01",';

                if ($('#txtCreatedBy').val() != '')
                    girSearchString += '"CreatedBy":"' + $('#txtCreatedBy').val() + '",';
                else
                    girSearchString += '"CreatedBy":"",';

                girSearchString += '"ComponentInspectionReport": {';

                if ($('#txtTurbineNo').val() != '' && $('#txtTurbineNo').val() > 0)
                    girSearchString += '"TurbineNumber":"' + $('#txtTurbineNo').val() + '",';
                else
                    girSearchString += '"TurbineNumber":"0",';

                if ($('#txtSiteName').val() != '')
                    girSearchString += '"SiteName":"' + $('#txtSiteName').val() + '",';
                else
                    girSearchString += '"SiteName":"",';

                if ($('#txtSBU').val() != '')
                    girSearchString += '"SBUName":"' + $('#txtSBU').val() + '"';
                else
                    girSearchString += '"SBUName":""';

                girSearchString += '},';

                girSearchString += '"Search": {';
                if (paramCurrentPage && paramCurrentPage != '') {
                    girSearchString += '"CurrentPageNumber":"' + paramCurrentPage + '"';
                }

                if (paramNumberOfRecords && paramNumberOfRecords != '') {
                    if (girSearchString != '')
                        girSearchString += ",";
                    girSearchString += '"RecordsPerPage":"' + paramNumberOfRecords + '"';
                }
                girSearchString += '}';
                girSearchString += '}';

                console.log(girSearchString);
                var girSearchjSon = jQuery.parseJSON(girSearchString);

                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            currentuser.forEach(function (item) {
                                client.currentUser = item.objet;
                            });

                            client.invokeApi('GirSearch', {
                                method: 'POST',
                                body: girSearchjSon
                            }).done(function (response) {
                                var resp = response.result;
                                if (resp) {
                                    var userValidForEditDelete = hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator");
                                    var girHtml = '';
                                    var rowCount = 1;
                                    var totalRecords = 0;
                                    if (resp.length > 0) {
                                        resp.forEach(function (item) {
                                            totalRecords = item.search.totalRecordCount;
                                            girHtml += '<tr class="item" id="' + item.girDataID + '">';
                                            if (userValidForEditDelete) {
                                                girHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.girDataID + '" class="expandGrid" rel=' + item.girDataID + '><i style="color:#0072BB;" id="icon' + item.girDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.girDataID + '"   href="javascript:void(0);" class="downloadGirPdf" title="Download GIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.girDataID + '"   href="javascript:void(0);" class="downloadGirWord"  title="Download GIR Word"> <i style="color:#0052cc;" id="iconWord" class="fa fa-file-word-o fa-lg"></i></a><a style="padding: 2px 2px 2px 2px;" title="Delete Gir" id="' + item.girDataID + '" href="javascript:void(0);" class="btn-delete removeGir"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a></td>';
                                            }
                                            else {
                                                girHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.girDataID + '" class="expandGrid" rel=' + item.girDataID + '><i style="color:#0072BB;" id="icon' + item.girDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.girDataID + '"   href="javascript:void(0);" class="downloadGirPdf" title="Download GIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i></a></td>';
                                            }

                                            girHtml += '<td id="td' + item.girDataID + '">' + item.girCode + '</td>';
                                            girHtml += '<td>' + item.girDataID + '</td>';
                                            girHtml += '<td>' + item.revisionNumber + '</td>';
                                            girHtml += '<td>' + 'Generator' + '</td>';
                                            girHtml += '<td></td>';
                                            girHtml += '<td>' + item.componentInspectionReport.turbineType + '</td>';
                                            girHtml += '<td>' + item.componentInspectionReport.turbineNumber + '</td>';
                                            girHtml += '<td>' + item.componentInspectionReport.sbuName + '</td>';
                                            girHtml += '<td>' + item.componentInspectionReport.siteName + '</td>';
                                            girHtml += '<td>' + getDate(item.created) + '</td>';
                                            girHtml += '<td>' + item.createdBy + '</td>';
                                            girHtml += '</tr>';
                                            girHtml += '<tr class="item" id="Child' + item.girDataID + '" style="display:none;">';
                                            girHtml += '<td colspan="13">';
                                            girHtml += '<table id="tableGIRChild" class="FlexResponive list">';
                                            girHtml += '<thead class="table-header">';
                                            girHtml += '<tr>';
                                            girHtml += '<th style="width: 8%;">Action</th>';
                                            girHtml += '<th>Name</th>';
                                            girHtml += '<th>Cir ID</th>';
                                            girHtml += '<th>Cim Case</th>';
                                            girHtml += '<th>Component</th>';
                                            girHtml += '<th>Generator s/n</th>';
                                            girHtml += '<th>Report Type</th>';
                                            girHtml += '<th>Created</th>';
                                            girHtml += '<th>Modified</th>';
                                            girHtml += '</tr>';
                                            girHtml += '</thead>';
                                            girHtml += '<tbody>';
                                            if (item.componentInspectionReportDetails && item.componentInspectionReportDetails.length > 0)
                                                item.componentInspectionReportDetails.forEach(function (childItem) {
                                                    girHtml += '<tr>';
                                                    girHtml += '<td><a title="View CIR details" href="/cir/Cir-Details?ID=' + childItem.cirDataID + '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
                                                    girHtml += '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,' + childItem.cirDataID + ')"></i>';
                                                    if (userValidForEditDelete) {
                                                        girHtml += '&nbsp;<i style="color:#08088A;cursor:pointer" id="iconEdit" data-cirdataid="' + childItem.cirDataID + '" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,' + childItem.componentInspectionReportId + ')"></i></td>';
                                                    }
                                                    girHtml += '<td>' + childItem.cirName + '</td>';
                                                    girHtml += '<td>' + childItem.componentInspectionReportId + '</td>';
                                                    girHtml += '<td>' + childItem.cimCaseNumber + '</td>';
                                                    girHtml += '<td>' + childItem.componentInspectionReportName + '</td>';
                                                    if (childItem.generator)
                                                        girHtml += '<td>' + childItem.generator.generatorSerialNumber + '</td>';
                                                    else
                                                        girHtml += '<td></td>';
                                                    girHtml += '<td>Inspection</td>';
                                                    girHtml += '<td>' + getDate(childItem.created) + '</td>';
                                                    girHtml += '<td>' + getDate(childItem.modified) + '</td>';
                                                    girHtml += '</tr>';
                                                });

                                            girHtml += '</tbody>';
                                            girHtml += '</table></td>';
                                            girHtml += '</tr>';
                                            girHtml += '<tr style="display:none;">';
                                            rowCount++;
                                        });

                                        $('table#tableGIR tr.item').remove();
                                        $('#tableGIR').append(girHtml);

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
                                            loadGirData(num, $('#ddlNumber').val());
                                        });
                                    }
                                    else {
                                        $('table#tableGIR tr.item').remove();
                                        $('#tableGIR').append('<tr class="item"><td colspan="13" style="text-align:center;">No records found</td></td>');
                                    }
                                }
                            }, function (error) {
                                console.log(error);
                                if (error)
                                    NotifyCirMessage('Gir PDF Download', error.message, 'danger');
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
            loadGirData(1, 10);
        });
    </script>
</asp:Content>
