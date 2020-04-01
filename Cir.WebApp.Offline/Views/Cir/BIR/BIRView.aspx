<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<Cir.WebApp.Offline.Models.Cir.BIR.BIRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage BIR
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

    <style>
        .dropbtn {
            background-color: #3498DB;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
            cursor: pointer;
        }

            .dropbtn:hover, .dropbtn:focus {
                background-color: #2980B9;
            }

        .dropdown {
            position: relative;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            padding: 2px 2px 4px 0px;
            background-color: #EEE;
            position: absolute;
            min-width: 80px;
            overflow: auto;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                color: black;
                padding: 2px 16px;
                text-decoration: none;
                display: block;
            }

        .context-menu-separator {
            margin-bottom: 2px;
            border-bottom: 1px solid #DDD;
        }
    </style>

    <section class="content">

        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Manage Blade Inspection Report</legend>
                            <div class="pull-right">
                                <button id="inbox" class="btn btn-xs btn-primary" type="button" onclick="window.open('/CirView/manage-cirviewlist?rpt=bir', '_self');">
                                    <i style="color: #ffffff;" class="fa fa-plus"></i>Create new BIR
                                </button>
                            </div>
                            <a href="javascript:void(0);" id="searchLink" class="btn btn-primary">Quick Search <i id="iconBirQuickSearch" class="fa fa-chevron-circle-down down"></i></a>
                            <div id="divSearchItems" style="display: none;">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Bir ID</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtBirID" class="form-control" style="width: 50%;" placeholder="Bir ID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Turbine Number</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtTurbineNo" class="form-control" style="width: 50%;" placeholder="Turbine Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Blade Serial No.</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtBladeSlno" class="form-control" style="width: 50%;" placeholder="Blade Serial No." />
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
                                    <table id="tableBIR" class="tablesaw sorted" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th style="width: 8%;">Action</th>
                                                <th>Name </th>
                                                <th>BIR ID</th>
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
                        NotifyCirMessage('Error : ', "Cir PDF has not been generated yet!, Please try again in a minute", 'danger');
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
                if ($('#iconBirQuickSearch').hasClass('down')) {
                    $('#iconBirQuickSearch').removeClass('fa-chevron-circle-down');
                    $('#iconBirQuickSearch').removeClass('down');
                    $('#iconBirQuickSearch').addClass('fa-chevron-circle-up');
                    $('#iconBirQuickSearch').addClass('up');
                }
                else {
                    $('#iconBirQuickSearch').removeClass('fa-chevron-circle-up');
                    $('#iconBirQuickSearch').removeClass('up');
                    $('#iconBirQuickSearch').addClass('fa-chevron-circle-down');
                    $('#iconBirQuickSearch').addClass('down');
                }
            });

            $('#linkSearch').click(function () {
                loadBirData(1, $(this).val());
            });

            $("#txtCreated").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });

            var oTable;

            $('#ddlNumber').change(function () {
                loadBirData(1, $(this).val());
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
            $(document.body).click(function (e) {
                $('div[class="dropdown-content show"]').each(function (index, item) {
                    $(this).toggleClass("show");
                });
            });

            $('body').on('click', '.dropdown-content a', function (e) {
                 e.stopPropagation();
                if ($(this)[0].innerText == 'Close') {
                    $('div[class="dropdown-content show"]').each(function (index, item) {
                        $(this).toggleClass("show");
                    });
                }
                else {
                     var lauagugeId = $(this).attr('id')
                    var id = $(this).closest('tr')[0].id
                     
                    if (lauagugeId == 4) {
                        var downloadUrl = '';
                        var isPdf = 0;
                        var objAnchor = $(this);
                        waitingDialog.show('Please Wait..Downloading..', { dialogSize: 'sm', progressType: 'primary' });
                        if ($(this).hasClass('downloadBirWord')) {
                            objAnchor.find('#iconWord').removeClass('fa-file-word-o');
                            objAnchor.find('#iconWord').addClass('fa-refresh');
                            objAnchor.find('#iconWord').addClass('fa-spin');
                            downloadUrl = 'GenerateBIRWordReport/' + id + '/' + lauagugeId;
                            isPdf = 0;
                        }
                        else {
                            objAnchor.find('#iconPdf').removeClass('fa-file-pdf-o');
                            objAnchor.find('#iconPdf').addClass('fa-refresh');
                            objAnchor.find('#iconPdf').addClass('fa-spin');
                            downloadUrl = 'GenerateBIRPdfReport/' + id + '/' + lauagugeId;
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

                                            if (resp.fileStatus == "NotGenerated")
                                            {
                                                waitingDialog.hide();
                                                NotifyCirMessage('Error : ', "BIR Report creation is in progress.", 'danger');
                                                return;
                                            }

                                            if (resp.fileStatus == "Error") {
                                                waitingDialog.hide();
                                                NotifyCirMessage('Error : ', "BIR Report cannot be downloaded as it has not been generated. Try to Recreate BIR again.", 'danger');
                                                return;
                                            }

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
                                        NotifyCirMessage('Error : ', "BIR Report cannot be downloaded as it has not been generated. Try to Recreate BIR again.", 'danger');

                                    });
                                }
                            }
                        });

                    }
                    else {
                        if (lauagugeId == 1) {
                            var objAnchor = $(this);
                            var downloadUrl = '';
                            var isPdf = 0;
                            waitingDialog.show('Please Wait..Downloading..', { dialogSize: 'sm', progressType: 'primary' });
                            if ($(this).hasClass('downloadBirWord')) {
                                objAnchor.find('#iconWord').removeClass('fa-file-word-o');
                                objAnchor.find('#iconWord').addClass('fa-refresh');
                                objAnchor.find('#iconWord').addClass('fa-spin');
                                downloadUrl = 'BirWordFile/' + id;
                                isPdf = 0;
                            }
                            else {
                                objAnchor.find('#iconPdf').removeClass('fa-file-pdf-o');
                                objAnchor.find('#iconPdf').addClass('fa-refresh');
                                objAnchor.find('#iconPdf').addClass('fa-spin');
                                downloadUrl = 'BirPdfFile/' + id;
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
                                                if (resp.fileStatus == "NotGenerated") {
                                                    waitingDialog.hide();
                                                    NotifyCirMessage('Error : ', "BIR Report creation is in progress.", 'danger');
                                                    return;
                                                }

                                                if (resp.fileStatus == "Error") {
                                                    waitingDialog.hide();
                                                    NotifyCirMessage('Error : ', "BIR Report cannot be downloaded as it has not been generated. Try to Recreate BIR again.", 'danger');
                                                    return;
                                                }
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
                                            NotifyCirMessage('Error : ', "BIR Report cannot be downloaded as it has not been generated. Try to Recreate BIR again.", 'danger');

                                        });
                                    }
                                }
                            });
                        }
                    }
                }
            });

            $('body').on('click', '.downloadBirWord,.downloadBirPdf', function (e) {
                e.stopPropagation();
                $('#dropdown-content').hide();
                $('div[class="dropdown-content show"]').each(function (index, item) {
                    $(this).toggleClass("show");
                });
                if (1 == 1) {
                    $(this).next().toggleClass("show");
                }
                else {
                    var objAnchor = $(this);
                    var id = $(this).attr('id');
                    var downloadUrl = '';
                    var isPdf = 0;
                    waitingDialog.show('Please Wait..Downloading..', { dialogSize: 'sm', progressType: 'primary' });
                    if ($(this).hasClass('downloadBirWord')) {
                        objAnchor.find('#iconWord').removeClass('fa-file-word-o');
                        objAnchor.find('#iconWord').addClass('fa-refresh');
                        objAnchor.find('#iconWord').addClass('fa-spin');
                        downloadUrl = 'BirWordFile/' + id;
                        isPdf = 0;
                    }
                    else {
                        objAnchor.find('#iconPdf').removeClass('fa-file-pdf-o');
                        objAnchor.find('#iconPdf').addClass('fa-refresh');
                        objAnchor.find('#iconPdf').addClass('fa-spin');
                        downloadUrl = 'BirPdfFile/' + id;
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
                                    NotifyCirMessage('Error : ', "BIR Report cannot be downloaded as it has not been generated. Try to Recreate BIR again.", 'danger');

                                });
                            }
                        }
                    });
                }
            });
            $('body').on('click', '.removeBir', function () {
                var birID = $(this).attr('id');
                var birCode = $('#tableBIR tr td#td' + birID).text();
                console.log(birCode);
                console.log(birID);
                CirAlert.confirm('Are you sure want to delete Bir ' + birCode + ' ?', 'Cir App', 'Yes', 'No', 'Warning').done(function () {
                    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                        if (currentuser) {
                            if (currentuser.length > 0) {
                                currentuser.forEach(function (item) {
                                    client.currentUser = item.objet;
                                });
                                client.invokeApi('BirDelete/' + birID, {
                                    method: 'POST'
                                }).done(function (response) {
                                    var resp = response.result;
                                    if (resp) {
                                        $('table#tableBIR tr#' + birID).remove();
                                        $('table#tableBIR tr#Child' + birID).remove();
                                    }
                                }, function (error) {
                                    console.log(error);
                                });
                            }
                        }
                    });

                });
            });

            var loadBirData = function (paramCurrentPage, paramNumberOfRecords) {
                $('table#tableBIR tr.item').remove();
                $('#tableBIR').append('<tr class="item"><td colspan="13" style="text-align:center;height: 65px;"><i class="loadersign fa fa-spin fa-lg"></i></td></td>');

                var birSearchString = '{';

                if ($('#txtBirID').val() != '' && $('#txtBirID').val() > 0)
                    birSearchString += '"BirDataID":"' + $('#txtBirID').val() + '",';
                else
                    birSearchString += '"BirDataID":"0",';

                if ($('#txtBladeSlno').val() != '')
                    birSearchString += '"BladeSerialNos":"' + $('#txtBladeSlno').val() + '",';
                else
                    birSearchString += '"BladeSerialNos":"",';

                if ($('#txtCreated').val() != '')
                    birSearchString += '"strCreated":"' + $('#txtCreated').val() + '",';
                else
                    birSearchString += '"strCreated":"1900-01-01",';

                if ($('#txtCreatedBy').val() != '')
                    birSearchString += '"CreatedBy":"' + $('#txtCreatedBy').val() + '",';
                else
                    birSearchString += '"CreatedBy":"",';

                birSearchString += '"ComponentInspectionReport": {';

                if ($('#txtTurbineNo').val() != '' && $('#txtTurbineNo').val() > 0)
                    birSearchString += '"TurbineNumber":"' + $('#txtTurbineNo').val() + '",';
                else
                    birSearchString += '"TurbineNumber":"0",';

                if ($('#txtSiteName').val() != '')
                    birSearchString += '"SiteName":"' + $('#txtSiteName').val() + '",';
                else
                    birSearchString += '"SiteName":"",';

                if ($('#txtSBU').val() != '')
                    birSearchString += '"SBUName":"' + $('#txtSBU').val() + '"';
                else
                    birSearchString += '"SBUName":""';

                birSearchString += '},';

                birSearchString += '"Search": {';
                if (paramCurrentPage && paramCurrentPage != '') {
                    birSearchString += '"CurrentPageNumber":"' + paramCurrentPage + '"';
                }

                if (paramNumberOfRecords && paramNumberOfRecords != '') {
                    if (birSearchString != '')
                        birSearchString += ",";
                    birSearchString += '"RecordsPerPage":"' + paramNumberOfRecords + '"';
                }
                birSearchString += '}';
                birSearchString += '}';

                console.log(birSearchString);
                var birSearchjSon = jQuery.parseJSON(birSearchString);

                dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
                    if (currentuser) {
                        if (currentuser.length > 0) {
                            currentuser.forEach(function (item) {
                                client.currentUser = item.objet;
                            });

                            client.invokeApi('BirSearch', {
                                method: 'POST',
                                body: birSearchjSon
                            }).done(function (response) {
                                var resp = response.result;
                                if (resp) {
                                    var userValidForEditDelete = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator");
                                    var birHtml = '';
                                    var rowCount = 1;
                                    var totalRecords = 0;
                                    if (resp.length > 0) {
                                        resp.forEach(function (item) {
                                             totalRecords = item.search.totalRecordCount;
                                            birHtml += '<tr class="item" id="' + item.birDataID + '">';
                                            if (userValidForEditDelete) {
                                                birHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.birDataID + '" class="expandGrid" rel=' + item.birDataID + '><i style="color:#0072BB;" id="icon' + item.birDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.birDataID + '"   href="javascript:void(0);" class="downloadBirPdf" title="Download BIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i> <div class="dropdown-content"><a id="1" href="javascript:void(0);">English</a><a class="context-menu-separator not-selectable"></a><a id="4" class="downloadBirPdf" href="javascript:void(0);">Chinese</a><a class="context-menu-separator not-selectable"></a><a href="javascript:void(0);">Close</a></div> </a><a style="padding: 1px 1px 1px 1px;" id="' + item.birDataID + '" href="javascript:void(0);" class="downloadBirWord"  title="Download BIR Word"> <i style="color:#0052cc;" id="iconWord" class="fa fa-file-word-o fa-lg"></i><div class="dropdown-content"><a id="1" class="downloadBirWord" href="javascript:void(0);">English</a><a class="context-menu-separator not-selectable"></a><a id="4" class="downloadBirWord" href="javascript:void(0);">Chinese</a><a class="context-menu-separator not-selectable"></a><a href="javascript:void(0);">Close</a></div></a><a style="padding: 2px 2px 2px 2px;" title="Delete Bir" id="' + item.birDataID + '" href="javascript:void(0);" class="btn-delete removeBir"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a></td>';
                                            }
                                            else {
                                                birHtml += '<td><a href="javascript:void(0);" style="padding: 2px 2px 2px 2px;" id="' + item.birDataID + '" class="expandGrid" rel=' + item.birDataID + '><i style="color:#0072BB;" id="icon' + item.birDataID + '" class="fa fa-plus-square-o fa-lg"></i></a><a style="padding: 1px 1px 1px 1px;" id="' + item.birDataID + '"   href="javascript:void(0);" class="downloadBirPdf" title="Download BIR Pdf"><i style="color:#cc0000;" id="iconPdf" class="fa fa-file-pdf-o fa-lg"></i> <div class="dropdown-content"><a id="1" href="javascript:void(0);">English</a><a class="context-menu-separator not-selectable"></a><a id="4" href="javascript:void(0);">Chinese</a><a class="context-menu-separator not-selectable"></a><a href="javascript:void(0);">Close</a></div> </a></td>';
                                            }

                                            birHtml += '<td id="td' + item.birDataID + '">' + item.birCode + '</td>';
                                            birHtml += '<td>' + item.birDataID + '</td>';
                                            birHtml += '<td>' + item.revisionNumber + '</td>';
                                            birHtml += '<td>' + 'Blade' + '</td>';
                                            birHtml += '<td></td>';
                                            birHtml += '<td>' + item.componentInspectionReport.turbineType + '</td>';
                                            birHtml += '<td>' + item.componentInspectionReport.turbineNumber + '</td>';
                                            birHtml += '<td>' + item.componentInspectionReport.sbuName + '</td>';
                                            birHtml += '<td>' + item.componentInspectionReport.siteName + '</td>';
                                            birHtml += '<td>' + getDate(item.created) + '</td>';
                                            birHtml += '<td>' + item.createdBy + '</td>';
                                            birHtml += '</tr>';
                                            birHtml += '<tr class="item" id="Child' + item.birDataID + '" style="display:none;">';
                                            birHtml += '<td colspan="13">';
                                            birHtml += '<table id="tableBIRChild" class="FlexResponive list">';
                                            birHtml += '<thead class="table-header">';
                                            birHtml += '<tr>';
                                            birHtml += '<th style="width: 8%;">Action</th>';
                                            birHtml += '<th>Name</th>';
                                            birHtml += '<th>Cir ID</th>';
                                            birHtml += '<th>Cim Case</th>';
                                            birHtml += '<th>Component</th>';
                                            birHtml += '<th>Blade s/n</th>';
                                            birHtml += '<th>Report Type</th>';
                                            birHtml += '<th>Created</th>';
                                            birHtml += '<th>Modified</th>';
                                            birHtml += '</tr>';
                                            birHtml += '</thead>';
                                            birHtml += '<tbody>';
                                            if (item.componentInspectionReportDetails && item.componentInspectionReportDetails.length > 0)
                                                item.componentInspectionReportDetails.forEach(function (childItem) {
                                                    birHtml += '<tr>';
                                                    birHtml += '<td><a title="View CIR details" href="/cir/Cir-Details?ID=' + childItem.cirDataID + '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
                                                    birHtml += '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,' + childItem.cirDataID + ')"></i>';
                                                    if (userValidForEditDelete) {
                                                        birHtml += '&nbsp;<i style="color:#08088A;cursor:pointer" id="iconEdit" data-cirdataid="' + childItem.cirDataID + '" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,' + childItem.componentInspectionReportId + ')"></i></td>';
                                                    }
                                                    birHtml += '<td>' + childItem.cirName + '</td>';
                                                    birHtml += '<td parentBIRId="' + item.birDataID + '">' + childItem.componentInspectionReportId + '</td>';
                                                    birHtml += '<td>' + childItem.cimCaseNumber + '</td>';
                                                    birHtml += '<td>' + childItem.componentInspectionReportName + '</td>';
                                                    if (childItem.bladeData)
                                                        birHtml += '<td>' + childItem.bladeData.bladeSerialNumber + '</td>';
                                                    else
                                                        birHtml += '<td></td>';
                                                    birHtml += '<td>Inspection</td>';
                                                    birHtml += '<td>' + getDate(childItem.created) + '</td>';
                                                    birHtml += '<td>' + getDate(childItem.modified) + '</td>';
                                                    birHtml += '</tr>';
                                                });

                                            birHtml += '</tbody>';
                                            birHtml += '</table></td>';
                                            birHtml += '</tr>';
                                            birHtml += '<tr style="display:none;">';
                                            rowCount++;
                                        });

                                        $('table#tableBIR tr.item').remove();
                                        $('#tableBIR').append(birHtml);

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
                                            loadBirData(num, $('#ddlNumber').val());
                                        });
                                    }
                                    else {
                                        $('table#tableBIR tr.item').remove();
                                        $('#tableBIR').append('<tr class="item"><td colspan="13" style="text-align:center;">No records found</td></td>');
                                    }
                                }
                            }, function (error) {
                                console.log(error);
                                if (error)
                                    NotifyCirMessage('Bir PDF Download', error.message, 'danger');
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

            loadBirData(1, 10);

        });
    </script>
</asp:Content>
