<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Js/FileSaver.min.js"></script>
    <script src="../Js/ApplicationScripts/CirView.js"></script>
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="../Css/tablesaw.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery.contextMenu.js"></script>
    <script src="../Js/jquery.ui.position.js"></script>
    <link href="../Css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
    <script src="../Js/tablesaw.js"></script>
    <script src="../Js/ApplicationScripts/CirDetails.js"></script>
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
    <section class="content" style="background: transparent">

        <div>
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">

                        <div class="col-xs-6">
                            <div class="navbar-left navbar-SubHead" id="cirHead">
                                Manage CIR 
                        <div class="Navbar-brandsmall">Manage Component Inspection Report</div>
                            </div>
                        </div>
                        <div class="col-xs-6">

                            <button id="inbox" class="btn btn-sm btn-primary btnActionOnTop" style="border: 2px solid #000000" type="button">
                                Submitted <span class="badge" id="inboxCount"></span>
                            </button>

                            <button id="accept" class="btn btn-sm btn-success btnActionOnTop" type="button">
                                Accepted <span class="badge" id="acceptCount"></span>
                            </button>

                            <button id="reject" class="btn btn-sm btn-danger btnActionOnTop" type="button">
                                Rejected <span class="badge" id="rejectCount"></span>
                            </button>

                        </div>
                    </div>
                    <%using (Html.BeginForm("manage-cirview", "CirView", FormMethod.Post, new { name = "frmCirView", id = "frmCirView", role = "form" }))
                        { %>
                    <div class="row">
                        <div class="bs-example form-horizontal">
                            <div class="col-sm-2">
                                <label class="control-label">Available Views : </label>

                            </div>
                            <div class="col-sm-4">
                                <select id="ddlCirViews" name="ddlCirViews" class="form-control" onchange="onChangeView();">
                                    <option value="0">Loading..</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-sm btn-default" disabled id="btnEditView" value="Edit" />
                                <input type="button" class="btn btn-sm btn-default" disabled id="btnCreateView" value="Create" />
                            </div>
                            <div class="col-xs-4" style="text-align: right; display: none" id="divExport">
                                <a title="Export list to Excel" onclick="GenerateExcel();" data-target="#ExcelExportModal" data-toggle="modal" data-backdrop="static" data-keyboard="false"><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i>&nbsp;Export list to Excel</a>

                            </div>
                        </div>
                    </div>


                    <%  }%>
                    <br />
                    <a href="javascript:QuickSearch();" id="searchLink" class="btn btn-sm btn-primary">Quick Search <i id="iconCirQuickSearch" class="fa fa-chevron-circle-down down"></i></a>

                    <div class="row" id="divSearchItems" style="display: none;">
                        <div class="form-horizontal">
                            <div class="col-sm-1">
                            </div>
                            <div class="col-sm-5">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Brand</label>
                                    <div class="col-lg-9">
                                        <select id="ddlBrandType" class="form-control">
                                            <option value="0">- Brand -</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">CIR ID</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtCirId" class="form-control" placeholder="CIR ID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">CIR Name</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtCirNo" class="form-control" placeholder="CIR Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">CIM Case</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtCimCase" class="form-control" placeholder="CIM Case" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Component Type</label>
                                    <div class="col-lg-9">
                                        <select id="ddlQuickCirType" class="form-control">
                                            <option value="0">- Component Type -</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Report Type</label>
                                    <div class="col-lg-9">
                                        <select id="ddlQuickReportType" class="form-control">
                                            <option value="0">- Report Type -</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Country</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtCountry" class="form-control" placeholder="Country" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Site Name</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtSite" class="form-control" placeholder="Site Name" />
                                    </div>
                                </div>

                            </div>
                            <div class="col-sm-5">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Turbine Type</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtTurbineType" class="form-control" placeholder="Turbine Type" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Turbine Number</label>
                                    <div class="col-lg-9">
                                        <input type="number" id="txtTurbineNumber" class="form-control" placeholder="Turbine Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Run Status</label>
                                    <div class="col-lg-9">
                                        <select id="ddlQuickRunStatus" class="form-control">
                                            <option value="0">- Run Status -</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">SBU</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtSBU" class="form-control" placeholder="SBU" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Created</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtCreated" class="form-control" placeholder="Created" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Modified</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtModified" class="form-control" placeholder="Modified" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Modified By</label>
                                    <div class="col-lg-9">
                                        <input type="text" id="txtModifiedBy" class="form-control" placeholder="Modified By" />
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="form-horizontal">
                            <div class="col-sm-1">
                            </div>
                            <div class="col-sm-5">

                                <div class="form-group">
                                    <label class="col-lg-3 control-label"></label>
                                    <div class="col-lg-9">
                                        <a href="javascript:void(0);" id="linkQuickSearch" class="btn btn-sm btn-primary">Search</a>
                                        <a href="javascript:void(0);" id="linkQuickSearch_Reset" class="btn btn-sm btn-primary">Reset</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-5">
                            </div>

                        </div>

                    </div>
                    <br />

                    <div id="quickSearchRestultDisplay" class="alert alert-success" style="display: none;">
                        Search Result For:  &nbsp;<strong><span id="cirQuickSearchText"></span> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | &nbsp;&nbsp;<a title="Clear filter" style="text-align: right"> <i id="iconCirQuickSearch_Close" style="text-align: right; cursor: pointer" class="fa fa-times QuickSearch_Close"></i></a></strong>
                    </div>

                    <div class="row">

                        <div class="col-xs-12">
                            <div class="">
                                <div>
                                    <div class="context-menu-one box menu-1">
                                        <div class="col-xs-12" id="divCirList">
                                        </div>
                                        <div class="col-xs-12" style="text-align: center">
                                            <button id="btnLazyLoadManageCIR" class="btn btn-sm btn-default col-xs-12">
                                                Loading more results..&nbsp;<i id="btnLazyLoadIcon" class='fa fa-spinner fa-spin'></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="col-xs-7 dataTables_info" style="text-align: left;">
                                        <label class="control-label" id="lblTotalRecords"></label>
                                    </div>

                                    <input type="hidden" name="hdnchkDownload" id="hdnchkDownload" />
                                    <input type="hidden" name="hdnchk" id="hdnchk" />
                                    <input type="hidden" name="hdnTemplateVersion" id="hdnTemplateVersion" value="8" />
                                    <%--<input type="hidden" name="hdnTemplateVersion" id="hdnTemplateVersion" value="7" />--%>
                                    <input type="hidden" name="hdnDownloadCirID" id="hdnDownloadCirID" />
                                    <input type="hidden" id="hdnAppCirId" value="<%= System.Configuration.ConfigurationManager.AppSettings["hdnCirId"] %>" />
                                    <input type="hidden" id="hdnCirIdBirCreation" value="<%= System.Configuration.ConfigurationManager.AppSettings["hdnCirIdBirCreation"] %>" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="IRModal" role="dialog">
            <div class="modal-dialog" style="width: 82%;">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Choose Master CIR</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="well well-White">


                                    <div>
                                        <table role="main" id="tblCirPopupTable" class="FlexResponive list">
                                            <thead>
                                                <tr>
                                                    <th data-hide="phone" scope="col"></th>
                                                    <th data-class="expand" scope="col" data-sort-initial="true">Name</th>
                                                    <th data-hide="phone" scope="col">CIR ID</th>
                                                    <th data-hide="phone" scope="col">Component Type</th>
                                                    <th id="rptsl" data-hide="phone" scope="col">Blade s/n</th>
                                                    <th data-hide="phone" scope="col">Report Type</th>
                                                    <th data-hide="phone" scope="col">Turbine Number</th>
                                                    <th data-hide="phone" scope="col">Created</th>
                                                    <th data-hide="phone" scope="col" data-sort-ignore="true" style="width: 7%"></th>
                                                </tr>
                                            </thead>
                                        </table>


                                    </div>
                                    <div id="birrptinputs" style="display: none">
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Repairing solutions : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtRepairingsolutions" data-toggle="tooltip"
                                                    data-placement="top" title="Repairing solutions" class="form-control" style="width: 100%; height: 150px;" placeholder="Repairing solutions"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Inspection tool description : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtRawMaterialsforrepair" data-toggle="tooltip"
                                                    data-placement="top" title="Inspection tool description" class="form-control" style="width: 100%; height: 150px;" placeholder="Inspection tool description"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Conclusions and Recommendations : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtConclusionsandRecommendations" data-toggle="tooltip"
                                                    data-placement="top" title="Conclusions and Recommendations" class="form-control" style="width: 100%; height: 150px;" placeholder="Conclusions and Recommendations"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                    </div>

                                    <div id="girrptinputs" style="display: none">
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Classification Of Damage : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtClassificationOfDamage" data-toggle="tooltip"
                                                    data-placement="top" title="Classification Of Damage" class="form-control" style="width: 100%; height: 150px;" placeholder="Classification Of Damage"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Analysis Of Picture : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtAnalysisOfPicture" data-toggle="tooltip"
                                                    data-placement="top" title="Analysis Of Picture" class="form-control" style="width: 100%; height: 150px;" placeholder="Analysis Of Picture"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Analysis Of Measurments : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtAnalysisOfMeasurments" data-toggle="tooltip"
                                                    data-placement="top" title="Analysis Of Measurments" class="form-control" style="width: 100%; height: 150px;" placeholder="Analysis Of Measurments"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Conclusions and Recommendations : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtConclusionsandRecommendationsGir" data-toggle="tooltip"
                                                    data-placement="top" title="Conclusions and Recommendations" class="form-control" style="width: 100%; height: 150px;" placeholder="Conclusions and Recommendations"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                    <div id="gbxrptinputs" style="display: none">
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Oil Analysis: </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtOilAnalysis" data-toggle="tooltip"
                                                    data-placement="top" title="Oil Analysis" class="form-control" style="width: 100%; height: 150px;" placeholder="Oil Analysis"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">CMS Analysis: </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtCMSAnalysis" data-toggle="tooltip"
                                                    data-placement="top" title="CMS Analysis" class="form-control" style="width: 100%; height: 150px;" placeholder="CMS Analysis"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Analysis: </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtAnalysis" data-toggle="tooltip"
                                                    data-placement="top" title="Analysis" class="form-control" style="width: 100%; height: 150px;" placeholder="Analysis"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <label class="col-lg-3 control-label">Conclusions and Recommendations : </label>
                                            <div class="col-lg-9">
                                                <textarea id="txtgbxConclusionsandRecommendations" data-toggle="tooltip"
                                                    data-placement="top" title="Conclusions and Recommendations" class="form-control" style="width: 100%; height: 150px;" placeholder="Conclusions and Recommendations"></textarea>

                                            </div>
                                        </div>
                                        <br />
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-9 col-lg-offset-3">
                                            <input type="submit" class="btn btn-sm btn-primary" onclick="GetReportData()" value="Retrieve  Latest Record" />

                                        </div>
                                    </div>
                                </div>



                            </div>




                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sm btn-primary" onclick="SaveReportData()">Save changes</button>
                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <div class="modal fade" id="ExcelExportModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Generating Excel</h5>
                </div>
                <div class="modal-body">
                    <div class="progress">
                        <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="0"
                            aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                            Reading Data..
                        </div>
                    </div>
                    <br />
                    <div id="divExcelGenWait" style="display: none">
                        <span style="margin: -5px 0px 0px 0px;">Generating file, Please Wait..</span>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp; <i class="loadersign fa fa-spin fa-lg"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="CreateBIRgif" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" id="imgCreateBIR">&times;</button>
                    <h4 class="modal-title">Create BIR</h4>
                </div>
                <div class="modal-body">
                    <p id="msg-bd"></p>
                    <img src="../../../Images/createrpt/bladereport.gif" style="width: 100%; height: 100%" />
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-primary" id="btnCreateBIR">Ok </button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="CreateGIRgif" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" id="imgCreateGIR">&times;</button>
                    <h4 class="modal-title">Create GIR</h4>
                </div>
                <div class="modal-body">
                    <p id="msg-bd"></p>
                    <img src="../../../Images/createrpt/generatorreport.gif" style="width: 100%; height: 100%" />
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-primary" id="btnCreateGIR">Ok </button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="CreateGBXIRgif" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" id="imgCreateGBXIR">&times;</button>
                    <h4 class="modal-title">Create GBXIR</h4>
                </div>
                <div class="modal-body">
                    <p id="msg-bd"></p>
                    <img src="../../../Images/createrpt/gearboxreport.gif" style="width: 100%; height: 100%" />
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-primary" id="btnCreateGBXIR">Ok </button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="hdnUserInitial" />
    <a href="#" class="cirback-top" title="Click to scroll top">&#8593;</a>


    <script type="text/javascript">
        $("input[data-type='number']").keyup(function () {
            var val = this.value;
            this.value = this.value.replace(/[^\d]/g, '');
        });


        var allViews = null;
        var ViewId = readCookie("CirViewId");

        if (ViewId == null || ViewId == "") {
            ViewId = "<%:ViewBag.ViewId %>";
        }
        var _ViewList = [];
        var _state = 1;
        var _progress = 1;
        var _key = 0;
        var _process = 0;
        var _pdfdata = "";
        var _pCirId = null;
        var _forState = null;





        //var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), '');
        //client.invokeApi('BirDelete', {
        //    method: 'POST'
        //}).done(function (response) {
        //    var resp = response.result;
        //    alert(resp);
        //}, function (error) {
        //    console.log(error);
        //}
        function getParameterByName(name, url) {
            if (!url) {
                url = window.location.href;
            }
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
        var getquery = getParameterByName('rpt');
        var birViewId, girViewId, gbxirViewId;

        if (getquery == 'bir') {
            CallClientApi("GetBIRViewId", "GET", null).done(function (result) {
                birViewId = result;
                if (getquery == 'bir') {
                    //eraseCookie("CreateGifPopup1");
                    var guidepopup = readCookie("CreateGifPopup");
                    if (guidepopup == null) {
                        createCookie("CreateGifPopup", 1, "");
                        showCreateBIR();
                    }

                    ViewId = birViewId;
                    state = 2;
                }

                function showCreateBIR() {
                    waitingDialog.hide();
                    $("#CreateBIRgif").modal('show');
                    setTimeout(function () {
                        //$('.data_' + itm.id).removeClass('unread'); ServiceInfoNotify.MarkRead(itm, false);
                        setTimeout(function () { }, 300);
                    }, 2000);
                }

                function hide_CreateBIR() {
                    $("#CreateBIRgif").modal('hide');
                }

            }).fail(function (err) {
                console.log(err);
            });
        }

        if (getquery == 'gir') {
            CallClientApi("GetGIRViewId", "GET", null).done(function (result) {
                girViewId = result;

                if (getquery == 'gir') {
                    //eraseCookie("CreateGifPopup1");
                    var guidepopup = readCookie("CreateGIRGifPopup");
                    if (guidepopup == null) {
                        createCookie("CreateGIRGifPopup", 1, "");
                        showCreateGIR();
                    }

                    ViewId = girViewId;
                    state = 2;
                }

                function showCreateGIR() {
                    waitingDialog.hide();
                    $("#CreateGIRgif").modal('show');
                    setTimeout(function () {
                        //$('.data_' + itm.id).removeClass('unread'); ServiceInfoNotify.MarkRead(itm, false);
                        setTimeout(function () { }, 300);
                    }, 2000);
                }

                function hide_CreateGIR() {
                    $("#CreateGIRgif").modal('hide');
                }

            }).fail(function (err) {
                console.log(err);
            });
        }

        if (getquery == 'gbxir') {
            CallClientApi("GetGBXIRViewId", "GET", null).done(function (result) {
                gbxirViewId = result;

                if (getquery == 'gbxir') {
                    //eraseCookie("CreateGBXIRGifPopup");
                    var guidepopup = readCookie("CreateGBXIRGifPopup");
                    if (guidepopup == null) {
                        createCookie("CreateGBXIRGifPopup", 1, "");
                        showCreateGBXIR();
                    }

                    ViewId = gbxirViewId;
                    state = 2;
                }

                function showCreateGBXIR() {
                    waitingDialog.hide();
                    $("#CreateGBXIRgif").modal('show');
                    setTimeout(function () {
                        //$('.data_' + itm.id).removeClass('unread'); ServiceInfoNotify.MarkRead(itm, false);
                        setTimeout(function () { }, 300);
                    }, 2000);
                }


                function hide_CreateGBXIR() {
                    $("#CreateGBXIRgif").modal('hide');
                }

            }).fail(function (err) {
                console.log(err);
            });
        }

        $(document).ready(function () {
            if (Offline.state == "down")
                window.location.href = '/cir/local-history';

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            _pCirId = GetQueryStringParams("cirid");
            $("#txtCirId").val(_pCirId);
            if (_pCirId != null && ViewId > 0) {
                ViewId = -1;
            }
            loadAllViews(); //Load All Views in Dropdown

            $("#inbox").click(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                state = 1;
                currentPageNumber = 1;
                sortColumnIndex = 13; //CIRID
                sortDirection = 1;
                loadGrid();
            });
            $("#accept").click(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                state = 2;
                currentPageNumber = 1;
                sortColumnIndex = 13;//CIRID
                sortDirection = 1;
                loadGrid();
            });
            $("#reject").click(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                state = 3;
                currentPageNumber = 1;
                sortColumnIndex = 13;//CIRID
                sortDirection = 1;
                loadGrid();
            });

            $("#btnEditView").click(function () {
                var viewId = $('#ddlCirViews').val();
                if (viewId == 0 || viewId.trim() == "") {
                    alert("Please select a valid CIR View!");
                    return false;
                }
                if (viewId == -1) {
                    alert("Cannot Edit Default CIR View!");
                    return false;
                }
                this.form.submit();
                // GetView(viewId);

            });
            $("#btnCreateView").click(function () {
                $('#ddlCirViews').val(-1);
                this.form.submit();
                // GetView(viewId);

            });

            $("#btnSave").click(function () {
                $('#hdnDownloadCirID').val(_key);
                _process = 1;
                _pdfdata = "";
                _filename = "No Name";
                $("#myModal").modal('hide');

                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

                Process();

            });

            $('#iconCirQuickSearch_Close').click(function () {

                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

                $('#quickSearchRestultDisplay').hide();

                $('#divSearchItems :input').val('');

                $("#ddlQuickCirType").prop("selectedIndex", 0);
                $("#ddlQuickReportType").prop("selectedIndex", 0);
                $("#ddlQuickRunStatus").prop("selectedIndex", 0);

                currentPageNumber = 1;
                sortColumnIndex = 11;
                sortDirection = 1;
                loadGrid();
                //waitingDialog.hide();
            });

            //Added By Siddharth Chauhan on 14-06-2016.            
            //to show the quick search parameter div container.
            //TaskNo. : 75301 

            //Added By Siddharth Chauhan on 14-06-2016.            
            //to show the quick search parameter div container.
            //TaskNo. : 75301 
            $("#txtCreated").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });

            //Added By Siddharth Chauhan on 14-06-2016.            
            //to show the quick search parameter div container.
            //TaskNo. : 75301 
            $("#txtModified").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });

            //Added By Siddharth Chauhan on 14-06-2016.            
            //to show the quick search parameter div container.
            //TaskNo. : 75301 
            $("#linkQuickSearch").click(function () {
                $(window).scrollTop(0);
                ViewId = $('#ddlCirViews').val();
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                loading = 2;
                _lazyLoading = 0;
                $('#divSearchItems').slideToggle(200);

                $('#iconCirQuickSearch').removeClass('fa-chevron-circle-up');
                $('#iconCirQuickSearch').removeClass('up');

                $('#iconCirQuickSearch').addClass('fa-chevron-circle-down');
                $('#iconCirQuickSearch').addClass('down');
                currentPageNumber = 1;
                sortColumnIndex = 11;
                sortDirection = 1;
                loadGrid();

            });

            $("#linkQuickSearch_Reset").click(function () {
                //$(window).scrollTop(0);
                $('#divSearchItems :input').val('');
                $("#ddlBrandType").prop("selectedIndex", "0");
                $("#ddlQuickCirType").prop("selectedIndex", 0);
                $("#ddlQuickReportType").prop("selectedIndex", 0);
                $("#ddlQuickRunStatus").prop("selectedIndex", 0);
            });

            //$('#frmCirView').keydown(function () {
            $(document).keypress(function (e) {
                if ($('#iconCirQuickSearch').hasClass('up')) {
                    var key = e.which;
                    if (key == 13) {    // As ASCII code for ENTER key is "13"
                        $("#linkQuickSearch").trigger("click");
                    }
                }
            });
        });


        function QuickSearch() {
            $('#divSearchItems').slideToggle(500);
            if ($('#iconCirQuickSearch').hasClass('down')) {
                $('#iconCirQuickSearch').removeClass('fa-chevron-circle-down');
                $('#iconCirQuickSearch').removeClass('down');
                $('#iconCirQuickSearch').addClass('fa-chevron-circle-up');
                $('#iconCirQuickSearch').addClass('up');
            }
            else {
                $('#iconCirQuickSearch').removeClass('fa-chevron-circle-up');
                $('#iconCirQuickSearch').removeClass('up');
                $('#iconCirQuickSearch').addClass('fa-chevron-circle-down');
                $('#iconCirQuickSearch').addClass('down');
            }
        }
        function Process() {

            var cirDataDetail = {
                cirDataId: _key,
                cirId: "",
                cirState: _state,
                filename: "",
                PdfDataUri: "",
                componentType: "",
                cIMCaseNumber: "",
                reportType: "",
                turbineType: "",
                turbineNumber: "",
                progress: _progress,
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
                    reloadGrid();
                    return false;
                }
                else {
                    var msg = '';
                    var cirid = $("#hdnCirID" + _key).val();
                    var comment = $("#txtComments").val() == undefined ? "" : $("#txtComments").val();
                    switch (_progress) {
                        case 2: CallSyncApi("CirSubmissionData/Approve?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                            .done(function () {
                                msg = "CIR has been approved!";
                                reloadGrid();
                                NotifyCirMessage(' ', msg, 'info');
                            }); break;
                        case 3: CallSyncApi("CirSubmissionData/Reject?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                            .done(function () {
                                msg = "CIR has been rejected!";
                                reloadGrid();
                                NotifyCirMessage(' ', msg, 'info');
                            }); break;
                        case 4: CallSyncApi("CirSubmissionData/BackToSubmit?reportId=" + cirid + "&comment=" + comment, "PUT", "")
                            .done(function () {
                                msg = "CIR has been moved to Submitted section!";
                                reloadGrid();
                                NotifyCirMessage(' ', msg, 'info');
                            }); break;
                        case 7: CallSyncApi("CirSubmissionData/Delete?reportId=" + cirid, "DELETE", "")
                            .done(function () {
                                msg = "CIR has been deleted!";
                                reloadGrid();
                                NotifyCirMessage(' ', msg, 'info');

                            }); break;
                        default:
                            reloadGrid();
                            break;
                    }
                }
            });

        }


        function reloadGrid() {
            currentPageNumber = 1;
            loadGrid();
            _process = 0;
            _pdfdata = "";
        }

        function findView(id) {
            return $.grep(_ViewList, function (item) {
                if (item.ViewId == id)
                    return item;
            });

        }

        var loading = 0;
        var state = 1;
        if (getquery == 'bir') {
            state = 2;
        }
        if (getquery == 'gir') {
            state = 2;
        }
        if (getquery == 'gbxir') {
            state = 2;
        }
        var currentPageNumber = 1;
        var sortColumnIndex = 0;
        var sortDirection = 2;
        var recordsPerPage = 50;
        var IsCheckbox = 0;
        var _cirList = null;
        var _cirListForExcel = null;
        var _lazyLoading = 0;
        function onChangeView() {


            //Addedd By Siddharth Chauhan on 17-06-2016
            //To hide the quick search parameters values from Label.
            //Task No. : 75301
            $("#txtCirId").val('');
            $("#txtCirNo").val('');
            $("#txtCimCase").val('');
            $("#ddlQuickCirType").val('0').attr('selected', true);;
            $("#ddlQuickReportType").val('0').attr('selected', true);;
            $("#txtCountry").val('');
            $("#txtTurbineType").val('');
            $("#txtTurbineNumber").val('');
            $("#ddlQuickRunStatus").val('0').attr('selected', true);;
            $("#txtSBU").val('');
            $("#txtCreated").val('');
            $("#txtModified").val('');
            $("#txtModifiedBy").val('');
            //$('#cirQuickSearchText').text('');
            //$('#quickSearchRestultDisplay').hide();

            ViewId = $('#ddlCirViews').val();
            if (getquery == 'bir') {
                ViewId = birViewId;
                state = 2;
            }
            if (getquery == 'gir') {
                ViewId = girViewId;
                state = 2;
            }
            if (getquery == 'gbxir') {
                ViewId = gbxirViewId;
                state = 2;
            }
            else {
                createCookie("CirViewId", ViewId, "");
            }
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            loading = 2;
            currentPageNumber = 1;
            loadGrid();
            $("#btnEditView").show();
            if (ViewId == -1 || ViewId == -2) {
                $("#btnEditView").hide();
            }
            else {
                if (!hasRole("Administrator")) {
                    var v = findView(ViewId);
                    if (v[0].CreatedBy != CurrentUserInfo.Name) {
                        $("#btnEditView").hide();
                    }
                }
            }
            var userValid_Viewer = hasRole("Viewer");
            if (userValid_Viewer == true) {
                var v = findView(ViewId);
                if (v[0].Type == "Private") {
                    $("#btnCreateView").show();
                    $("#btnEditView").show();
                }

            }
        }


        function Action(type, key) {
            //CurrentUserInfo.UserDisplayName ;
            // CurrentUserInfo.Roles = result.appRoles;
            // CurrentUserInfo.Name 


            if (type == 1) {
                ViewDetails(key);
            }
            if (type == 2) {
                // var cirid = $("#hdnCirID" + key).val();
                $('#hdnDownloadCirID').val(key);
                downloadPDF();

            }
            if (type == 3) {

                cirOfflineApp.getLocalDraftCount().done(function (count) {
                    // var cirDataDetail = {
                    //    cirDataId: key,
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
                    //};

                    //var releaseDate = new Date(2018, 2, 26);

                    //CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
                    //    var error = result.error;
                    //    var msg = result.message;
                    //    if (error == 1) {
                    //        NotifyCirMessage('Error : ', msg, 'danger');
                    //        return false;
                    //    }
                    var cirid = $("#hdnCirID" + key).val();
                    var NewFormIOcirId = $('#hdnAppCirId').val();
                    //var cirCreatedOnValue = $("#hdnCreateDate" + key).val().split("/");
                    //var cirCreatedOnDate =
                    //    new Date(cirCreatedOnValue[2], cirCreatedOnValue[1] - 1, cirCreatedOnValue[0]);

                    //if (cirCreatedOnDate >= releaseDate) 
                    if (parseInt(cirid) >= NewFormIOcirId) {

                        location.href = "/cir/formio-cir#id=" + cirid + "&cirDataId=" + key + '&state=' + state;
                        return false;
                    }

                    location.href = "/cir/manage-cir?remotecirID=" + cirid;
                    //  });

                });

            }

            _key = key;
            if (type == 4) {
                _progress = 2;
                _state = state;
                $("#txtComments").val("");
                $("#myModal").find('.modal-title').text('Approve CIR');
                $("#myModal").modal('show');
            }
            if (type == 5) {
                _progress = (state == 1) ? 3 : 4;
                _state = state;
                $("#txtComments").val("");
                $("#myModal").find('.modal-title').text(((state == 1) ? 'Reject CIR' : 'Move CIR to Submitted'));
                $("#myModal").modal('show');
            }
            if (type == 6) {
                _progress = 7;
                _state = state;
                $("#txtComments").val("");
                $("#myModal").find('.modal-title').text('Delete CIR');
                $("#myModal").modal('show');
            }
            //if (type == 5)
            //    Reject(key);

        }

        function SortGrid(key) {
            if (key == sortColumnIndex)
                sortDirection = (sortDirection == 1) ? 2 : 1;
            else
                sortDirection = 2;
            sortColumnIndex = key;
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            currentPageNumber = 1;
            loadGrid();
        }


        function loadGrid() {
            if (loading == 1)
                return;
            loading = 1;
            $('#divExport').hide();
            if (CurrentUserInfo.Roles.length == 0) {
                CurrentUserInfo.Roles.push("Viewer");
            }
            var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator");
            var userValid_CIREvalutor = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");

            var userValid_AcceptedList = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
            var userValid_Edit = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
            //var userVaild_CIREvalutor = hasRole("CIR Evaluator");
            var userValid_Attachment = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor") || hasRole("Turbine Technicians") || hasRole("Viewer") || hasRole("Visitor");


            var userValid_Viewer = hasRole("Viewer") || hasRole("Visitor");
            var userValid_Tech = hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians");
            //Below variables added by Siddharth Chauhan on 15-06-2016.
            //To get the filter CIR remote data based on search filters.
            //Task No. 75301
            var searchCirID = $("#txtCirId").val();
            var searchCirNo = $("#txtCirNo").val();
            var searchCirCase = $("#txtCimCase").val();
            var searchCirType = $("#ddlQuickCirType :selected").val();
            var searchReportType = $("#ddlQuickReportType :selected").val();
            var searchCountry = $("#txtCountry").val();
            var searchSite = $("#txtSite").val();
            var searchTurbineType = $("#txtTurbineType").val();
            var searchTurbineNumber = $("#txtTurbineNumber").val();
            var searchRunStatus = $("#ddlQuickRunStatus :selected").val();
            var searchSBU = $("#txtSBU").val();
            var searchCreated = $("#txtCreated").val();
            var searchModified = $("#txtModified").val();
            var searchModifiedBy = $("#txtModifiedBy").val();
            var searchBrandType = $("#ddlBrandType :selected").val();


            var cirList = {};
            cirList.ViewId = ViewId;
            cirList.State = state;
            if (sortColumnIndex == 0) {
                sortColumnIndex = 13;
                sortDirection = 1;
            }
            cirList.SortColumnIndex = sortColumnIndex;
            cirList.SortDirection = sortDirection;
            cirList.CurrentPageNumber = currentPageNumber;
            cirList.RecordsPerPage = recordsPerPage;

            //Below parameters added by Siddharth Chauhan on 15-06-2016.
            //To get the filter CIR remote data based on search filters.
            //Task No. 75301
            var displayText = "";
            if (searchCirID && searchCirID != '') {
                cirList.cirId = searchCirID;
                displayText = displayText + 'CIR ID = ' + searchCirID + ",";
            }
            else {
                cirList.cirId = "";
            }
            if (searchCirNo && searchCirNo != '') {
                cirList.cirName = searchCirNo;
                displayText = displayText + 'CIR No. = ' + searchCirNo + ",";
            }
            else {
                cirList.cirName = "";
            }
            if (searchCirCase && searchCirCase != '') {
                cirList.cimCase = searchCirCase;
                displayText = displayText + 'CIM Case = ' + searchCirCase + ",";
            }
            else {
                cirList.cimCase = "";
            }
            if ((searchCirType && searchCirType != '') && searchCirType > 0) {
                cirList.componentType = searchCirType;
                displayText = displayText + 'Component Type = ' + $("#ddlQuickCirType :selected").text() + ",";
            }
            else {
                cirList.componentType = "";
            }
            if ((searchReportType && searchReportType != '') && searchReportType > 0) {
                cirList.reportType = searchReportType;
                displayText = displayText + 'Report Type = ' + $("#ddlQuickReportType :selected").text() + ",";
            }
            else {
                cirList.reportType = "";
            }
            if (searchCountry && searchCountry != '') {
                cirList.country = searchCountry;
                displayText = displayText + 'Country = ' + searchCountry + ",";
            }
            else {
                cirList.country = "";
            }
            if (searchSite && searchSite != '') {
                cirList.siteName = searchSite;
                displayText = displayText + 'Site Name = ' + searchSite + "; ";
            }
            else {
                cirList.siteName = '';
            }
            if (searchTurbineType && searchTurbineType != '') {
                cirList.turbineType = searchTurbineType;
                displayText = displayText + 'Turbine Type = ' + searchTurbineType + ",";
            }
            else {
                cirList.turbineType = "";
            }
            if (searchTurbineNumber && searchTurbineNumber != '') {
                cirList.turbineNumber = searchTurbineNumber;
                displayText = displayText + 'Turbine No. = ' + searchTurbineNumber + ",";
            }
            else {
                cirList.turbineNumber = "";
            }

            if ((searchRunStatus && searchRunStatus != '') && searchRunStatus > 0) {
                cirList.runStatus = searchRunStatus;
                displayText = displayText + 'Run Status = ' + $("#ddlQuickRunStatus :selected").val() + ",";
            }
            else {
                cirList.runStatus = "";
            }
            if (searchSBU && searchSBU != '') {
                cirList.sBU = searchSBU;
                displayText = displayText + 'SBU = ' + searchSBU + ",";
            }
            else {
                cirList.sBU = "";
            }
            if (searchCreated && searchCreated != '') {
                var created = searchCreated.split("-");
                createdLocal = new Date(created[2], created[1] - 1, created[0]);
                createdLocal.setMinutes(createdLocal.getMinutes() + 330);
                //cirList.created = searchCreated;
                cirList.created = new Date(createdLocal);
                displayText = displayText + 'Created = ' + searchCreated + ",";
            }
            else {
                cirList.created = "";
            }
            if (searchModified && searchModified != '') {
                var modified = searchModified.split("-");
                modifiedLocal = new Date(modified[2], modified[1] - 1, modified[0]);
                modifiedLocal.setMinutes(modifiedLocal.getMinutes() + 330);
                cirList.modified = new Date(modifiedLocal);
                displayText = displayText + 'Modified = ' + searchModified + ",";
            }
            else {
                cirList.modified = "";
            }
            if (searchModifiedBy && searchModifiedBy != '') {
                cirList.modifiedBy = searchModifiedBy;
                displayText = displayText + 'Modified By = ' + searchModifiedBy + ",";
            }
            else {
                cirList.modifiedBy = "";
            }
            if ((searchBrandType && searchBrandType != '') && searchBrandType != '0') {
                cirList.brandType = searchBrandType;
                displayText = displayText + 'Brand Type = ' + $("#ddlBrandType :selected").text() + ",";
            }
            else {
                cirList.brandType = "";
            }

            //To Show the Search filters parameters in Label
            //Task No. : 75301
            displayText = (displayText.length > 0) ? displayText.substring(0, displayText.length - 1) : displayText;
            if (displayText != '') {
                $('#cirQuickSearchText').text(displayText);
                $('#quickSearchRestultDisplay').show();
            }
            else {
                $('#quickSearchRestultDisplay').hide();
            }
            _cirList = cirList;
            if (cirList.CurrentPageNumber == 1) {
                $("#btnLazyLoadManageCIR").show()
            }
            _cirListForExcel = cirList;
            CallClientApi("CirList", "POST", cirList).done(function (result) {
                // $("#cirList").html(result.data);
                var rows = JSON.parse(result.data);

                if (_pCirId != undefined && _pCirId > 0 && _forState == null) {
                    if (result.totalRecordCountApprove > 0) {
                        loading = 0;
                        state = 2;
                        currentPageNumber = 1;
                        sortColumnIndex = 13;
                        sortDirection = 1;
                        _forState = true;
                        loadGrid();
                        return;
                    }
                    else if (result.totalRecordCountReject > 0) {
                        loading = 0;
                        state = 3;
                        currentPageNumber = 1;
                        sortColumnIndex = 13;
                        sortDirection = 2;
                        loadGrid();
                        _forState = true;
                        return;
                    }
                    // _pCirId = null;
                }
                _forState = null;
                if (result.state == 1) {
                    $("#inbox").attr("style", "border:2px solid #000000")
                    $("#accept").attr("style", "")
                    $("#reject").attr("style", "")
                    $("#cirHead").html("Manage CIR - <b><font color=black>Submitted</b>");
                }
                if (result.state == 2) {
                    $("#accept").attr("style", "border:2px solid #000000")
                    $("#inbox").attr("style", "")
                    $("#reject").attr("style", "")
                    $("#cirHead").html("Manage CIR - <b><font color=black>Accepted</b>");
                }
                if (result.state == 3) {
                    $("#reject").attr("style", "border:2px solid #000000")
                    $("#inbox").attr("style", "")
                    $("#accept").attr("style", "")
                    $("#cirHead").html("Manage CIR - <b><font color=black>Rejected</b>");
                }

                $("#inboxCount").html(result.totalRecordCount);
                $("#acceptCount").html(result.totalRecordCountApprove);
                $("#rejectCount").html(result.totalRecordCountReject);

                if (rows.length == 0) {
                    waitingDialog.hide();
                    loading = 2;
                    $('#divCirList').html('<table id="tableCir" class="table table-striped table-bordered dataTable no-footer"><thead><tr id="dth"><th>There is no CIR data in this view.</th></tr></thead></table>');
                    $("#page-selection1").empty();
                    $("#page-selection2").empty();
                    $('#lblTotalRecords').text('');
                    $("#btnLazyLoadManageCIR").hide();
                    return;
                }

                var keys = $.map(rows[0], function (value, key) {
                    return key;
                });


                currentPageNumber = result.currentPageNumber;
                sortColumnIndex = result.sortColumnIndex;
                sortDirection = result.sortDirection;
                recordsPerPage = result.recordsPerPage;


                // $("#page-selection1").empty();
                // $("#page-selection2").empty();
                //console.log(result);
                var theadbkColor = "";
                if (result.state == 1) {
                    //$("tablesaw thead tr:first-child th").addClass('background-color', '#0072BB')
                    theadbkColor = "submitted"
                }
                if (result.state == 2) {
                    //$("tablesaw thead tr:first-child th").addClass('background-color', '#008d4c')
                    theadbkColor = "accepted"
                }
                if (result.state == 3) {
                    // $("tablesaw thead tr:first-child th").addClass('background-color', '#c9302c')
                    theadbkColor = "rejected"
                }

                var _nameKey = 0;
                var divwidth = $(window).width();
                var iPhoneWidthFix = "";
                if (divwidth <= 375) {
                    iPhoneWidthFix = 'style="table-layout:fixed"';
                }

                $('#divCirList').html('<table id="tableCir" ' + iPhoneWidthFix + ' width="100%" class="tablesaw sorted ' + theadbkColor + '" data-tablesaw-mode="swipe" data-tablesaw-minimap><thead><tr id="dth"></tr></thead><tbody></tbody></table>');
                var ordertext = "ascending";
                ordertext = (result.sortDirection == 1) ? "ascending" : "descending";
                var _c = 1;
                $.each(keys, function (key, value) {
                    if (value == "ID")
                        $('#dth').append('<th nowrap scope="col" data-tablesaw-priority="persist"><b>Action</b></th>');
                    else {
                        if (value.trim() == "Name") {
                            _nameKey = key;
                        }
                        if (value.substring(0, 6) != "_hide_") {
                            var persistCol = (_c == 1 && divwidth > 450) ? "data-tablesaw-priority=persist" : "data-tablesaw-priority=" + _c;
                            _c++;
                            if ((key) == result.sortColumnIndex) {
                                if (result.sortDirection == 1)
                                    $('#dth').append('<th nowrap scope="col" ' + persistCol + ' class="sorting_asc" style="cursor:pointer" onclick="SortGrid(' + key + ')" tabindex="0"  aria-sort="ascending"><b>' + value + '</b></th>');
                                else
                                    $('#dth').append('<th nowrap scope="col" ' + persistCol + ' class="sorting_desc" style="cursor:pointer" onclick="SortGrid(' + key + ')" tabindex="0"  aria-sort="descending"><b>' + value + '</b></th>');
                            }
                            else
                                $('#dth').append('<th nowrap scope="col"  ' + persistCol + ' class="sorting" tabindex="0" style="cursor:pointer" onclick="SortGrid(' + key + ')" aria-label="Click ' + value + ' to activate to sort column ascending/descending"><b>' + value + '</b></th>');
                        }
                    }

                });

                //code  changess to fixed bug #88688
                var Cimindex = keys.indexOf("CIM Case no.");
                if (Cimindex == -1)
                    Cimindex = keys.indexOf("CIM Case Number");
                //end of code change

                var CirCreatedBy;
                $.each(rows, function (index, data) {

                    var ComponentType = data._hide_ComponentType;
                    $('#tableCir tbody').append('<tr id="t' + index + '"></tr>');
                    var values = $.map(data, function (value, key) {
                        if (key == '_hide_CreatedBy') {
                            CirCreatedBy = (value == null) ? " " : value;
                        }
                        return ((value == null) ? " " : value);
                    });
                    //Done = 1,
                    //PendingApprove = 2,
                    //PendingReject = 3,
                    //PendingInitial = 4,
                    //ProcessError = 5,
                    //InitialError = 6,
                    //PendingDelete = 7
                    var link = "";
                    var hdnFields = "";
                    var locked = "";
                    var isnew = false;
                    var tversion = "";
                    var tversionNum = "";
                    var ydate = new Date();
                    ydate.setDate(ydate.getDate() - 1);
                    var isError = 0;
                    var v = findView(ViewId);
                    IsCheckbox = ((v[0].InspectionAvailable == true || v[0].GeneralInspectionApplicable == true || v[0].GBXInspectionApplicable == true) && state == 2 && userValid == true) ? true : false; //also add Bircreator role
                    hdnFields = (IsCheckbox == true) ? '<input class="subscriber" type=checkbox id="{0}">' : '<input class="downloadcir" type=checkbox id="{0}">'
                    $.each(values, function (key, value) {
                        if (key == 0) {
                            locked = value;
                        }
                        if (IsCheckbox == true) {

                            if (key == 2) {
                                hdnFields = hdnFields + '<input id="hdnCirID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 3) {
                                isError = (value.trim() == "") ? 1 : 0;
                                hdnFields = hdnFields + '<input id="hdnComponentType{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 4) {
                                hdnFields = hdnFields + '<input id="hdnReportType{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 5) {
                                hdnFields = hdnFields + '<input id="hdnCreateDate{0}"  type=hidden value="' + value + '">';
                                if (parseDate(value) > ydate) {
                                    isnew = true;
                                }
                            }
                            if (key == 6) {
                                hdnFields = hdnFields + '<input id="hdnName{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 7) {
                                hdnFields = hdnFields + '<input id="hdnTemplateVer{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 8) {
                                hdnFields = hdnFields + '<input id="hdnTurbineID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 9) {
                                hdnFields = hdnFields + '<input id="hdnBladeSerial{0}"  type=hidden value="' + value + '">';
                            }
                        }
                        else {
                            if (key == 3) {
                                isError = (value.trim() == "") ? 1 : 0;

                            }
                            if (key == 2) {
                                hdnFields = hdnFields + '<input id="hdnCirID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 5) {
                                hdnFields = hdnFields + '<input id="hdnCreateDate{0}"  type=hidden value="' + value + '">';
                                if (parseDate(value) > ydate) {
                                    isnew = true;
                                }
                            }
                        }

                        if (key == 1) {
                            link = '<a title="View CIR details" onClick=javascript:ShowCirDetails("{0}",1)><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
                            if (userValid_Attachment) {
                                link = link + '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,{0})"></i>';
                            }
                            if (state == 2 && userValid_Attachment) {

                                link = link + '&nbsp;<a title="Upload/View attachment" onClick=javascript:ShowCirDetails("{0}",2)><i style="color:#2E64FE;cursor:pointer" id="iconAttachment" class="fa fa-paperclip fa-lg" title="Upload/View attachment")"></i></a>';
                            }

                            if (value == 1 || value == 5 || value == 6 || value == -2) {
                                if (state == 2) {

                                    if (userValid_AcceptedList) {
                                        if (locked != " " && locked == CurrentUserInfo.Name) {

                                            if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {

                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                            else {
                                                if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                            }
                                        }
                                        else {
                                            if (locked == " ") {
                                                if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                                else {
                                                    if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                        link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else {
                                    if (locked != " " && locked == CurrentUserInfo.Name) {

                                        if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                            link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                        }
                                        else {
                                            if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                        }
                                    }
                                    else {
                                        if (locked == " ") {


                                            if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase()))
                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            else {
                                                if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                            }
                                            //link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                        }
                                    }
                                }

                            }

                            if (value == 1 && locked == " " && (hasRole("Administrator") || hasRole("Member"))) {
                                if (state == 1) {
                                    link = link + '&nbsp;<i style="color:#088A08;cursor:pointer" id="iconApprove" class="fa fa-check-circle fa-lg" title="Approve CIR" onclick="Action(4,{0})"></i>&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Reject CIR" onclick="Action(5,{0})"></i>';
                                }
                                if (state == 2) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,{0})"></i>';
                                }

                            }
                            else {
                                if (state == 2 && value == 6 && locked == " " && (hasRole("Administrator") || hasRole("Member"))) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,{0})"></i>';
                                }
                                if (value == 5 || value == 6) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="This CIR has Error Status from Infopath"></i>';

                                }
                                if (value == -2) {
                                    link = link + '&nbsp;<i style="color:#cccc00;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="This CIR had Error during Migration but has been migrated by resolving the error temporarily. Please [Edit] the CIR to view the Error description"></i>';

                                }
                                if (value == 4) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending (Move to Submitted)"></i>';
                                }
                                if (value == 2) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for approval"></i>';
                                }
                                if (value == 3) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for rejection"></i>';
                                }
                            }
                            if (locked != " ") {
                                if (locked == CurrentUserInfo.Name)
                                    link = link + '&nbsp;<i style="color:#0000cc;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by you. Please edit and submit to make it available for further process."></i>';
                                else
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by ' + locked + '"></i>';

                            }
                            if (value == 1 && locked == " " && (userValid || hasRole("Member"))) {
                                link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconDelete" class="fa fa-trash-o fa-lg" title="Delete CIR" onclick="Action(6,{0})"></i>';

                            }
                            locked = " ";
                        }
                        if (key == 7) {
                            tversion = "";
                            tversionNum = value;
                            if (value != undefined && value != null) {
                                if (parseInt(value) <= 4) {
                                    if (isError == 1)
                                        tversion = "Editing for this CIR is not available as the CIR data is not migrated into new system due to some error";
                                    else
                                        tversion = "Editing for this CIR (Template Version " + value + ") is not available as the CIR Template Version is less than 5";

                                }
                                else {
                                    if (isError == 1)
                                        tversion = "CIR data is not migrated into new system due to some error";
                                    else
                                        tversion = "CIR Template Version " + value;

                                }
                            }
                            else {

                            }
                        }
                        if (key == 10) {
                            if (tversionNum != undefined && tversionNum != null) {
                                if (parseInt(tversionNum) <= 4) {
                                    link = link.split('{display}').join(';display:none');
                                }
                                else {
                                    if (userValid_Edit == true) {
                                        link = link.split('{display}').join('');
                                    }
                                    else if (userValid_Tech == true) {
                                        if (value != CurrentUserInfo.Name) {
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
                                else if (userValid_Tech == true) {
                                    if (value != CurrentUserInfo.Name) {
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



                        if (key == 11) {
                            link = link.split('{0}').join(value);
                            hdnFields = hdnFields.split('{0}').join(value);
                            $('#t' + index).append('<td nowrap title="' + tversion + '">' + hdnFields + link + '</td>');
                            link = "";
                            hdnFields = "";
                        }
                        if (key > 11) {
                            var txt = (value.length > 20) ? value.substring(0, 15) + "..." : value;
                            if (_nameKey == key && isnew == true) {
                                $('#t' + index).append('<td nowrap title="' + value + '">' + txt + ' <b><i style="color:#00cc00;cursor:pointer"  class="fa fa-exclamation-circle fa-sm" title="New CIR"></i></b></td>');
                                isnew = false;
                            }
                            else {
                                ////$('#t' + index).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                //if (key == 14) {
                                //    $('#t' + index).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a href="javascript:void(0);" style="color:#0009ba; text-decoration: underline;" id="CIM_anchor" >' + txt + '</a>') + '</td>');
                                //}
                                ////if (key == 14) {
                                ////    $('#t' + index).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a style="color:#0009ba; text-decoration: underline;" target="_blank" href=http://pman.vestas.net/AdvancedSearch.aspx?searchinitiated=true&caseid=' + txt + '>' + txt + '</a>') + '</td>');
                                ////}
                                //else {
                                //    $('#t' + index).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                //}
                                if (key == 14 && key == Cimindex && value != -1) {
                                    $('#t' + index).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a href="javascript:void(0);" style="color:#0009ba; text-decoration: underline;" id="CIM_anchor" >' + txt + '</a>') + '</td>');
                                }
                                //if (key == 14) {
                                //    $('#t' + index).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a style="color:#0009ba; text-decoration: underline;" target="_blank" href=http://pman.vestas.net/AdvancedSearch.aspx?searchinitiated=true&caseid=' + txt + '>' + txt + '</a>') + '</td>');
                                //}
                                else {
                                    //code changes to fixed bug #88688
                                    if (key == Cimindex && value != -1)
                                        $('#t' + index).append('<td nowrap title="' + value + '">' + '<a href="javascript:void(0);" style="color:#0009ba; text-decoration: underline;" id="CIM_anchor" >' + txt + '</a>' + '</td>');
                                    else
                                        $('#t' + index).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                    //end of code change
                                }
                            }

                        }
                    });
                });


                waitingDialog.hide();
                $('#tableCir').wrap('<div id="scroll_div" width="100%"></div>');
                $(document).trigger("enhance.tablesaw");
                $(window).trigger('resize');
                var tCount = 0;
                if (state == 1)
                    tCount = result.totalRecordCount;
                if (state == 2)
                    tCount = result.totalRecordCountApprove;
                if (state == 3)
                    tCount = result.totalRecordCountReject;


                var startNumber = 1;// (parseInt((result.currentPageNumber - 1) * result.recordsPerPage) + 1);
                var lastNumber = (result.currentPageNumber * result.recordsPerPage);
                if (lastNumber > tCount)
                    lastNumber = tCount;

                //if ((tCount - lastNumber) <= result.recordsPerPage) {
                //    $("#btnLazyLoadManageCIR").hide();
                //    lastNumber = tCount;
                //}



                var TotalPages = 0;

                if ((tCount % result.recordsPerPage) == 0) {
                    TotalPages = tCount / result.recordsPerPage;
                }
                else {
                    TotalPages = (tCount / result.recordsPerPage) + 1;
                }
                TotalPages = parseInt(TotalPages);



                if ((result.currentPageNumber > TotalPages) || TotalPages == 1) {
                    $("#btnLazyLoadManageCIR").hide();
                    lastNumber = tCount;
                }


                $('#lblTotalRecords').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + tCount + ' entries');
                $('#divExport').show();
                //$('.page-selection').bootpag({
                //    total: parseInt(tCount / result.recordsPerPage) + 1,
                //    page: result.currentPageNumber,
                //    maxVisible: 5,
                //    leaps: true,
                //    firstLastUse: true,
                //    first: '←',
                //    last: '→',
                //    wrapClass: 'pagination',
                //    activeClass: 'active',
                //    disabledClass: 'disabled',
                //    nextClass: 'next',
                //    prevClass: 'prev',
                //    lastClass: 'last',
                //    firstClass: 'first'
                //});
                //$('#page-selection1').on("page", function (event, num) {
                //    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                //    currentPageNumber = num;
                //    loadGrid()
                //});
                //$('#page-selection2').on("page", function (event, num) {
                //    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                //    currentPageNumber = num;
                //    loadGrid()
                //});
                loading = 0;


                // $('#tableCir').table("refresh");
            })
                .fail(function (e) {
                    $('#divCirList').html('<table id="tableCir" class="table table-striped table-bordered dataTable no-footer"><thead><tr id="dth"><th>The view cannot be rendered due to some error.</th></tr></thead></table>');
                    $('#lblTotalRecords').text('');
                    $("#btnLazyLoadManageCIR").hide();
                });


        }

        function LazyLoadGrid() {
            if (_lazyLoading == 1)
                return;
            if (CurrentUserInfo.Roles.length == 0) {
                CurrentUserInfo.Roles.push("Viewer");
            }
            var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator");
            var userValid_AcceptedList = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member");
            var userValid_Attachment = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor") || hasRole("Turbine Technicians") || hasRole("Viewer") || hasRole("Visitor");
            var userValid_Edit = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("CIR Evaluator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
            var userValid_CIREvalutor = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator") || hasRole("Administrator") || hasRole("Member") || hasRole("Editor");
            var userValid_Viewer = hasRole("Viewer") || hasRole("Visitor");
            var userValid_Tech = hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians");

            currentPageNumber++;
            _cirList.CurrentPageNumber = currentPageNumber;
            _lazyLoading = 1;
            var state = _cirList.State;

            CallClientApi("CirList", "POST", _cirList).done(function (result) {
                var rows = JSON.parse(result.data);

                if (rows.length == 0) {
                    $("#btnLazyLoadManageCIR").hide();
                    return;
                }

                var keys = $.map(rows[0], function (value, key) {
                    return key;
                });
                //code changes to fixed bug #88688
                var Cimindex = keys.indexOf("CIM Case no.");
                if (Cimindex == -1)
                    Cimindex = keys.indexOf("CIM Case Number");
                //end of code change

                currentPageNumber = result.currentPageNumber;
                sortColumnIndex = result.sortColumnIndex;
                sortDirection = result.sortDirection;
                recordsPerPage = result.recordsPerPage;
                var _nameKey = 0;
                var tableRowIndex = (currentPageNumber * recordsPerPage) + 1;
                var CirCreatedBy;
                $.each(rows, function (index, data) {
                    $('#tableCir tbody').append('<tr id="t' + tableRowIndex + '"></tr>');
                    var values = $.map(data, function (value, key) {
                        if (key == '_hide_CreatedBy') {
                            CirCreatedBy = (value == null) ? " " : value;
                        }
                        return ((value == null) ? " " : value);
                    });

                    var link = "";
                    var hdnFields = "";
                    var locked = "";
                    var isnew = false;
                    var tversion = "";
                    var ydate = new Date();
                    var tversionNum = 0;
                    var tversionNum = "";
                    ydate.setDate(ydate.getDate() - 1);
                    var isError = 0;
                    var v = findView(ViewId);
                    IsCheckbox = ((v[0].InspectionAvailable == true || v[0].GeneralInspectionApplicable == true || v[0].GBXInspectionApplicable == true) && state == 2 && userValid == true) ? true : false; //also add Bircreator role
                    hdnFields = (IsCheckbox == true) ? '<input class="subscriber" type=checkbox id="{0}">' : '<input class="downloadcir" type=checkbox id="{0}">'
                    $.each(values, function (key, value) {
                        if (key == 0) {
                            locked = value;
                        }
                        if (IsCheckbox == true) {

                            if (key == 2) {
                                hdnFields = hdnFields + '<input id="hdnCirID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 3) {
                                isError = (value.trim() == "") ? 1 : 0;
                                hdnFields = hdnFields + '<input id="hdnComponentType{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 4) {
                                hdnFields = hdnFields + '<input id="hdnReportType{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 5) {
                                hdnFields = hdnFields + '<input id="hdnCreateDate{0}"  type=hidden value="' + value + '">';
                                if (parseDate(value) > ydate) {
                                    isnew = true;
                                }
                            }
                            if (key == 6) {
                                hdnFields = hdnFields + '<input id="hdnName{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 7) {
                                hdnFields = hdnFields + '<input id="hdnTemplateVer{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 8) {
                                hdnFields = hdnFields + '<input id="hdnTurbineID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 9) {
                                hdnFields = hdnFields + '<input id="hdnBladeSerial{0}"  type=hidden value="' + value + '">';
                            }
                        }
                        else {
                            if (key == 3) {
                                isError = (value.trim() == "") ? 1 : 0;

                            }
                            if (key == 2) {
                                hdnFields = hdnFields + '<input id="hdnCirID{0}"  type=hidden value="' + value + '">';
                            }
                            if (key == 5) {
                                hdnFields = hdnFields + '<input id="hdnCreateDate{0}"  type=hidden value="' + value + '">';
                                if (parseDate(value) > ydate) {
                                    isnew = true;
                                }
                            }
                        }

                        if (key == 1) {
                            link = '<a title="View CIR details" onClick=javascript:ShowCirDetails("{0}","Details")><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-info-circle fa-lg" title="View CIR Details")"></i></a>';
                            //link = link + '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,{0})"></i>';
                            if (userValid_Attachment) {
                                link = link + '&nbsp;<i style="color:#8A0829;cursor:pointer" id="iconPdf" class="fa fa-file-pdf-o fa-lg" title="View as PDF" onclick="Action(2,{0})"></i>';
                            }
                            if (state == 2 && userValid_Attachment) {
                                link = link + '&nbsp;<a title="Upload/View attachment" onClick=javascript:ShowCirDetails("{0}",2)><i style="color:#2E64FE;cursor:pointer" id="iconAttachment" class="fa fa-paperclip fa-lg" title="Upload/View attachment")"></i></a>';
                            }

                            if (value == 1 || value == 5 || value == 6 || value == -2) {
                                if (state == 2) {
                                    if (userValid_AcceptedList) {

                                        if (locked != " " && locked == CurrentUserInfo.Name) {

                                            if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                            else {
                                                if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                            }
                                            //link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                        }
                                        else {
                                            if (locked == " ") {
                                                if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                                else {
                                                    if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                        link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                    }
                                                }

                                                //link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                        }
                                    }
                                }
                                else {
                                    if (locked != " " && locked == CurrentUserInfo.Name) {
                                        if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                            link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                        }
                                        else {
                                            if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                        }

                                        //link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                    }
                                    else {
                                        if (locked == " ") {
                                            if (userValid_CIREvalutor || !hasRole("CIR Evaluator") || (userValid_Tech && CirCreatedBy.toLowerCase() == CurrentUserInfo.Name.toLowerCase())) {
                                                link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                            }
                                            else {
                                                if (ComponentType == 'Simplified CIR' && hasRole("CIR Evaluator")) {

                                                    link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                                }
                                            }
                                            //link = link + '&nbsp;<i style="color:#08088A;cursor:pointer {display}" id="iconEdit" class="fa fa-pencil-square-o fa-lg" title="Edit CIR" onclick="Action(3,{0})"></i>';
                                        }
                                    }
                                }

                            }

                            if (value == 1 && locked == " " && (hasRole("Administrator") || hasRole("Member"))) {
                                if (state == 1) {
                                    link = link + '&nbsp;<i style="color:#088A08;cursor:pointer" id="iconApprove" class="fa fa-check-circle fa-lg" title="Approve CIR" onclick="Action(4,{0})"></i>&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Reject CIR" onclick="Action(5,{0})"></i>';
                                }
                                if (state == 2) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,{0})"></i>';
                                }

                            }
                            else {
                                if (state == 2 && value == 6 && locked == " " && (hasRole("Administrator") || hasRole("Member"))) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconReject" class="fa fa-minus-circle fa-lg" title="Move to Submitted" onclick="Action(5,{0})"></i>';
                                }
                                if (value == 5 || value == 6) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="An error occured"></i>';
                                }
                                if (value == -2) {
                                    link = link + '&nbsp;<i style="color:#cccc00;cursor:pointer" id="iconError" onClick=javascript:ShowCirDetails("{0}",-1) class="fa fa-exclamation-triangle fa-lg" title="This CIR had Error during Migration but has been migrated by resolving the error temporarily. Please [Edit] the CIR to view the Error description"></i>';

                                }
                                if (value == 4) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending (Move to Submitted)"></i>';
                                }
                                if (value == 2) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for approval"></i>';
                                }
                                if (value == 3) {
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconHour" class="fa fa-hourglass-1 fa-lg" title="Pending for rejection"></i>';
                                }
                            }
                            if (locked != " ") {
                                if (locked == CurrentUserInfo.Name)
                                    link = link + '&nbsp;<i style="color:#0000cc;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by you. Please edit and submit to make it available for further process."></i>';
                                else
                                    link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconLocked" class="fa fa-lock fa-lg" title="This CIR is locked by ' + locked + '"></i>';

                            }
                            if (value == 1 && locked == " " && (userValid || hasRole("Member"))) {
                                link = link + '&nbsp;<i style="color:#cc0000;cursor:pointer" id="iconDelete" class="fa fa-trash-o fa-lg" title="Delete CIR" onclick="Action(6,{0})"></i>';

                            }
                            locked = " ";
                        }
                        if (key == 7) {
                            tversion = "";
                            tversionNum = value;
                            if (value != undefined && value != null) {
                                if (parseInt(value) <= 4) {
                                    if (isError == 1)
                                        tversion = "Editing for this CIR is not available as the CIR data is not migrated into new system due to some error";
                                    else
                                        tversion = "Editing for this CIR (Template Version " + value + ") is not available as the CIR Template Version is less than 5";

                                }
                                else {
                                    if (isError == 1)
                                        tversion = "CIR data is not migrated into new system due to some error";
                                    else
                                        tversion = "CIR Template Version " + value;

                                }
                            }

                        }
                        if (key == 10) {
                            if (tversionNum != undefined && tversionNum != null) {
                                if (parseInt(tversionNum) <= 4) {
                                    link = link.split('{display}').join(';display:none');
                                }
                                else {
                                    if (userValid_Edit == true) {
                                        link = link.split('{display}').join('');
                                    }
                                    else if (userValid_Tech == true) {
                                        if (value != CurrentUserInfo.Name) {
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
                                else if (userValid_Tech == true) {
                                    if (value != CurrentUserInfo.Name) {
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
                        if (key == 11) {
                            link = link.split('{0}').join(value);
                            hdnFields = hdnFields.split('{0}').join(value);
                            $('#t' + tableRowIndex).append('<td nowrap title="' + tversion + '">' + hdnFields + link + '</td>');
                            link = "";
                            hdnFields = "";
                        }
                        if (key > 11) {
                            var txt = (value.length > 20) ? value.substring(0, 15) + "..." : value;
                            if (_nameKey == key && isnew == true) {
                                $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + txt + ' <b><i style="color:#00cc00;cursor:pointer"  class="fa fa-exclamation-circle fa-sm" title="New CIR"></i></b></td>');
                                isnew = false;
                            }
                            else {
                                ////$('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                //if (key == 14) {
                                //    $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a href="javascript:void(0);" style="color:#0009ba; text-decoration: underline;" id="CIM_anchor" >' + txt + '</a>') + '</td>');
                                //}
                                ////if (key == 14) {
                                ////    $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a style="color:#0009ba; text-decoration: underline;" target="_blank" href=http://pman.vestas.net/AdvancedSearch.aspx?searchinitiated=true&caseid=' + txt + '>' + txt + '</a>') + '</td>');
                                ////}
                                //else {
                                //    $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                //}

                                //code changes to fixed bug #88688
                                if (key == 14 && key == Cimindex && value != -1) {
                                    $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + (txt == "-1" ? -1 : '<a href="javascript:void(0);" style="color:#0009ba; text-decoration: underline;" id="CIM_anchor" >' + txt + '</a>') + '</td>');
                                }
                                else {
                                    if (key == Cimindex && value != -1)
                                        $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + '<a href="javascript:void(0);" style="color:#0009ba; text-decoration:underline;" id="CIM_anchor" >' + txt + '</a>' + '</td>');
                                    else
                                        $('#t' + tableRowIndex).append('<td nowrap title="' + value + '">' + txt + '</td>');
                                }
                                //end of code change

                            }

                        }
                    });
                    tableRowIndex++;
                });

                waitingDialog.hide();
                // $('#tableCir').wrap('<div id="scroll_div"></div>');
                $('#tableCir').table().data("table").refresh();
                $('#tableCir').trigger("enhance.tablesaw");
                $(window).trigger('resize');
                _lazyLoading = 0;
                var tCount = 0;
                if (state == 1)
                    tCount = result.totalRecordCount;
                if (state == 2)
                    tCount = result.totalRecordCountApprove;
                if (state == 3)
                    tCount = result.totalRecordCountReject;


                var startNumber = 1;//(parseInt((result.currentPageNumber - 1) * result.recordsPerPage) + 1);
                var lastNumber = (result.currentPageNumber * result.recordsPerPage);
                if (lastNumber > tCount)
                    lastNumber = tCount;


                var TotalPages = 0;

                if ((tCount % result.recordsPerPage) == 0) {
                    TotalPages = tCount / result.recordsPerPage;
                }
                else {
                    TotalPages = (tCount / result.recordsPerPage) + 1;
                }
                TotalPages = parseInt(TotalPages);


                if ((result.currentPageNumber > TotalPages) || TotalPages == 1) {
                    $("#btnLazyLoadManageCIR").hide();
                    lastNumber = tCount;
                }

                //if ((tCount - lastNumber) <= result.recordsPerPage) {
                //    $("#btnLazyLoadManageCIR").hide();
                //    lastNumber = tCount;
                //}


                $('#lblTotalRecords').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + tCount + ' entries');

            });

        }

        $(window).scroll(function () {

            if ($('#btnLazyLoadManageCIR').is(":visible")) {
                var t = $('#btnLazyLoadManageCIR').isOnScreen();
                if (t == true) {
                    LazyLoadGrid();

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

        var DataForExcel = [];
        function GenerateExcel() {

            if (loading == 1)
                return;
            loading = 1;
            DataForExcel = [];
            //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            $('#divExcelGenWait').hide();
            $('#ExcelExportModal .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);
            /* var cirList = {
                 ViewId: ViewId,
                 State: state,
                 SortColumnIndex: 0,
                 SortDirection: 1,
                 CurrentPageNumber: 0,
                 RecordsPerPage: 10
             }
             CallClientApi("CirList", "POST", cirList).done(function (result) {
                 loading = 0;
                 JSONToXlSXConvertor(result.data, "CirList", true);
             });*/

            ReadDataForExcel(ViewId, state, 1, function (data) {

                // data = jQuery.parseJSON(data);
                $('#divExcelGenWait').show();
                try {
                    JSONToXlSXConvertor(data, "CirList", true);
                }
                catch (err) {
                    NotifyCirMessage("Error", err, "danger")
                }
                //waitingDialog.hide();
                $('#ExcelExportModal').modal('hide');
                loading = 0;
            })
        }



        function ReadDataForExcel(vid, st, cp, callback) {
            var cirList = {};
            cirList = _cirListForExcel;
            cirList.ViewId = vid;
            cirList.State = st;
            cirList.SortColumnIndex = 0;
            cirList.SortDirection = 1;
            cirList.CurrentPageNumber = cp;
            cirList.RecordsPerPage = 1000;

            try {

                CallClientApi("CirList", "POST", cirList).done(function (result) {
                    var arrData = typeof result.data != 'object' ? JSON.parse(result.data) : result.data;
                    for (var i = 0, d; d = arrData[i]; i++) {
                        DataForExcel.push(d);
                    }

                    var tCount = 0;
                    if (st == 1)
                        tCount = result.totalRecordCount;
                    if (st == 2)
                        tCount = result.totalRecordCountApprove;
                    if (st == 3)
                        tCount = result.totalRecordCountReject;
                    if (tCount > 60000)
                        tCount = 60000;
                    var ExcelTotalPages = parseInt(tCount / result.recordsPerPage) + 1
                    var per = parseInt((DataForExcel.length * 100) / tCount);
                    $('#ExcelExportModal .progress-bar').css('width', per + '%').attr('aria-valuenow', per);
                    if (result.currentPageNumber == ExcelTotalPages && callback != null) {
                        par = 100;
                        $('#ExcelExportModal .progress-bar').css('width', per + '%').attr('aria-valuenow', per);
                        callback(DataForExcel);
                    }
                    else {
                        if (result.currentPageNumber == ExcelTotalPages - 1)
                            $('#divExcelGenWait').show();
                        ReadDataForExcel(result.viewId, result.state, result.currentPageNumber + 1, callback);
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

    </script>

    <script type="text/javascript">

        $('#hdnTemplateVersion').val('7');
        var chkBoxes = $('.subscriber');

        var TableHeader = '';
        var crID;
        var chkCIRID = new Array();

        $("#tblCirPopupTable").delegate('input.up', 'click', function (e) {

            var it = $(this).closest('tr');
            var prev = $(this).closest('tr').prev('tr');

            if (it.attr("id") != $(this).closest('table').find(' tbody tr:first').attr('id')) {
                it.remove();
                it.insertBefore(prev);
            }
        });
        $("#tblCirPopupTable").delegate('input.down', 'click', function (e) {

            var it = $(this).closest('tr');
            var next = $(this).closest('tr').next('tr');

            if (it.attr("id") != $("tr:last").attr("id")) {
                it.remove();
                it.insertAfter(next);
            }
        });
        $(document).ready(function () {

            $("#btnCreateGBXIR").bind("click", "hide_CreateGBXIR");
            $("#imgCreateGBXIR").bind("click", "hide_CreateGBXIR");
            $("#btnCreateGIR").bind("click", "hide_CreateGIR");
            $("#imgCreateGIR").bind("click", "hide_CreateGIR");
            $("#btnCreateBIR").bind("click", "hide_CreateGBXIR");
            $("#imgCreateBIR").bind("click", "hide_CreateGBXIR");

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

            $(document).on("click", "a[id='CIM_anchor']", function (e) {
                if (Offline.state == "down") {
                    CirAlert.alert('You need to be Online in order to user this link', 'Cir App - User Offline', null, 'error').done(function () {
                        return false;
                    });
                }
                else {
                    var id = $(this).text();
                    window.open('<%= System.Configuration.ConfigurationManager.AppSettings["PMANURL"] %>' + id, '_blank');
                    //window.open('http://pman.vestas.net/AdvancedSearch.aspx?searchinitiated=true&caseid='+id, '_blank');
                }
            });

            $('.modal').on('show.bs.modal', function () {
                $(this).show();
                setModalMaxHeight(this);
            });

            $(window).resize(function () {
                if ($('.modal.in').length != 0) {
                    setModalMaxHeight($('.modal.in'));
                }
            });
            // Click event of CIR grid
            $('.context-menu-one').on('mousedown', function (event) {
                switch (event.which) {
                    case 3:
                        var iSelect = false;
                        var iSelect2 = false;
                        if (state == 2) {
                            $('input:checkbox[class=subscriber]').each(function () {
                                if (this.checked) {
                                    iSelect = true;
                                }
                            });
                            if (iSelect) {
                                $.contextMenu('destroy');
                                downloadContextMenu1();
                            }

                            $('input:checkbox[class=downloadcir]').each(function () {
                                if (this.checked) {
                                    iSelect2 = true;
                                }
                            });
                            if (iSelect2) {
                                $.contextMenu('destroy');
                                downloadContextMenu2();
                            }
                        }
                        else {
                            $('input:checkbox[class=downloadcir]').each(function () {
                                if (this.checked) {
                                    iSelect = true;
                                }
                            });
                            if (iSelect) {
                                $.contextMenu('destroy');
                                downloadContextMenu2();
                            }
                        }
                        if (iSelect == false && iSelect2 == false) {
                            $.contextMenu('destroy');
                            return false;
                        }

                        break;
                }
            });

            $(document).on('change', '[type=checkbox]', function () {
                var chkcss = ((state == 1) ? "downloadcir" : "subscriber");
                $('#hdnDownloadCirID').val('');
                $('input:checkbox[class=' + chkcss + ']').each(function () {
                    var chkid = $(this).attr('id');
                    var cirid = chkid;
                    if (this.checked) {
                        if ($('#hdnDownloadCirID').val() != '') {
                            $('#hdnDownloadCirID').val($('#hdnDownloadCirID').val() + ',');
                        }
                        $('#hdnDownloadCirID').val($('#hdnDownloadCirID').val() + cirid);
                    }
                });
            });




        });


        function downloadContextMenu1() {

            var rptArray = [];

            var v = findView(ViewId);
            var ReportName = null;
            var rpttype = null;
            if (v[0].InspectionAvailable == true) {
                ReportName = { name: "Create Blade Report (BIR)", icon: "createbir" };
                rpttype = 'bir';
            }
            else if (v[0].GeneralInspectionApplicable == true) {
                ReportName = { name: "Create Generator Report (GIR)", icon: "creategir" };
                rpttype = 'gir';
            }
            else if (v[0].GBXInspectionApplicable == true) {
                ReportName = { name: "Create Gearbox Report (GBXIR)", icon: "createbir" };
                rpttype = 'gbxir';
            }
            $.contextMenu({
                selector: '.context-menu-one',
                callback: function (key, options) {
                    if (key == 'create') {
                        var iSelect = false
                        var ccount = 0;
                        var v = findView(ViewId);
                        $('input:checkbox[class=subscriber]').each(function () {
                            if (this.checked) {
                                iSelect = true;
                                ccount++;
                                var chkid = $(this).attr('id');
                                var reportItem = {};
                                reportItem.CirDataID = chkid;
                                reportItem.CirID = $('#hdnCirID' + chkid).val();
                                reportItem.ComponentType = $('#hdnComponentType' + chkid).val();
                                reportItem.ReportType = $('#hdnReportType' + chkid).val();
                                reportItem.CreateDate = $('#hdnCreateDate' + chkid).val();
                                reportItem.Name = $('#hdnName' + chkid).val();
                                reportItem.TemplateVer = $('#hdnTemplateVer' + chkid).val().trim() == "" ? "7" : $('#hdnTemplateVer' + chkid).val();
                                reportItem.TurbineID = $('#hdnTurbineID' + chkid).val();
                                reportItem.Serial = $('#hdnBladeSerial' + chkid).val();
                                rptArray.push(reportItem);
                            }
                        });
                        if (!iSelect) {
                            NotifyCirMessage('', "Plese select a CIR", 'danger');
                            return;
                        }
                        if (v[0].InspectionAvailable == true) {
                            if (ccount > 3) {
                                NotifyCirMessage('', "User can select maximum of 3 CIR for Blade Report", 'danger');
                                return;
                            }
                        }
                        else if (v[0].GeneralInspectionApplicable == true) {
                            if (ccount > 1) {
                                NotifyCirMessage('', "User can select maximum of 1 CIR for Generator Report", 'danger');
                                return;
                            }
                        }
                        else if (v[0].GBXInspectionApplicable == true) {
                            if (ccount > 1) {
                                NotifyCirMessage('', "User can select maximum of 1 CIR for Gearbox Report", 'danger');
                                return;
                            }
                        }
                        if (iSelect == true) {
                            if (v[0].InspectionAvailable == true) {
                                if (!CheckBlade(rptArray)) {
                                    NotifyCirMessage('', "Selected CIR-Component Type should only be Blade", 'danger');
                                    return;
                                }
                                if (!CheckCirDate(rptArray)) {
                                    NotifyCirMessage('', "Selected CIR-created date should be within 3 months", 'danger');
                                    return;
                                }
                                if (!CheckCirTurbine(rptArray)) {
                                    NotifyCirMessage('', "Please Select blade from same Turbine Number", 'danger');
                                    return;
                                }
                                if (!CheckWhetherCIRsAreEitherAllNewOrAllOld(rptArray)) {
                                    NotifyCirMessage('', "Invalid selection of CIRs, Please select a valid set of CIRs to generate BIRs", 'danger');
                                    return;
                                }
                            }
                            else if (v[0].GeneralInspectionApplicable == true) {
                                if (rptArray[0].ComponentType == "Generator" == false) {
                                    NotifyCirMessage('', "Selected CIR-Component Type should only be Generator", 'danger');
                                    return;
                                }
                            }
                            else if (v[0].GBXInspectionApplicable == true) {
                                if (rptArray[0].ComponentType == "Gearbox" == false) {
                                    NotifyCirMessage('', "Selected CIR-Component Type should only be Generator", 'danger');
                                    return;
                                }
                            }
                            if (!CheckCirTemplate(rptArray)) {
                                NotifyCirMessage('', "Please select the CIRs with the latest template version", 'danger');
                                return;
                            }
                            OpenCreateReport(rptArray, rpttype);

                        }

                        if (!iSelect) {
                            return;
                        }


                    }
                    else if (key == 'download') {
                        downloadPDFAll();
                    }
                },
                items: {
                    "create": ReportName, //{ name: "Create BIR", icon: "createbir" },
                    "download": { name: "Download CIR", icon: "download" },
                    "sep1": "---------",
                    "quit": {
                        name: "Close", icon: function () {
                            return 'context-menu-icon context-menu-icon-quit';
                        }
                    }
                }


            });
        }

        function downloadContextMenu2() {
            $.contextMenu({
                selector: '.context-menu-one',
                callback: function (key, options) {
                    if (key == 'download') {
                        // window.location.href = "download/PdfDownloadMultiple.ashx?id=" + $('#hdnDownloadCirID').val();                       
                        downloadPDFAll();
                    }
                },
                items: {
                    "download": { name: "Download CIR", icon: "download" },
                    "sep1": "---------",
                    "quit": {
                        name: "Close", icon: function () {
                            return 'context-menu-icon context-menu-icon-quit';
                        }
                    }
                }
            });
        }

        function parseDate(str) {
            var myDateArray = str.split("/");// "2008-03-02".split("-");ddmmyyyy
            var theDate = new Date(myDateArray[2], myDateArray[1] - 1, myDateArray[0]);
            return theDate;

        }


        function CreateReportModel(reportArray, rpttype) {
            if (rpttype == 'bir') {
                $('#rptsl').text('Blade S/N');
                //$("#birrptinputs").show();
                $("#gbxrptinputs").hide();
                $("#girrptinputs").hide();
            }
            else if (rpttype == 'gir') {
                $('#rptsl').text('Generator S/N');
                $("#birrptinputs").hide();
                $("#gbxrptinputs").hide();
                $("#girrptinputs").show();
            }
            else if (rpttype == 'gbxir') {
                $('#rptsl').text('Gearbox S/N');
                $("#birrptinputs").hide();
                $("#gbxrptinputs").show();
                $("#girrptinputs").hide();
            }
            $('table#tblCirPopupTable tr.item').remove();
            var $row = $(this).closest("tr");
            var $tds = $row.find("td");

            for (var i = 0, l = reportArray.length; i < l; i++) {
                var tr = $('<tr id="tr' + i + '" class="item"></tr>');
                if (i == 0)
                    $('<td><input type="radio" title="Select master CIR" name="SelectMaster" class="SelectMaster" id="' + reportArray[i].CirDataID + '" checked="checked" /></td>').appendTo(tr);
                else
                    $('<td><input type="radio" title="Select master CIR" name="SelectMaster" class="SelectMaster" id="' + reportArray[i].CirDataID + '"/></td>').appendTo(tr);
                $('<td>' + reportArray[i].Name + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].CirID + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].ComponentType + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].Serial + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].ReportType + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].TurbineID + '</td>').appendTo(tr);
                $('<td>' + reportArray[i].CreateDate + '</td>').appendTo(tr);
                if (rpttype == 'bir') {
                    $('<td> <input type="button" class="up" value="&#8679;"/><input type="button" class="down" value="&#8681;"/></td>').appendTo(tr);
                }
                else {
                    $('<td></td>').appendTo(tr);
                }
                $("#tblCirPopupTable").append(tr);

            }


        }
        function GetReportData() {
            var v = findView(ViewId);

            if (v[0].InspectionAvailable == true) {
                GetBIRData();
            }
            else if (v[0].GeneralInspectionApplicable == true) {
                GetGIRData();
            }
            else if (v[0].GBXInspectionApplicable == true) {
                GetGBXIRData();
            }

        }
        function CheckRevision(reportArray, rpttype) {
            var deferredObject = $.Deferred();
            if (rpttype == 'bir') {
                setTimeout(function () { deferredObject.reject(); }, 200)
            }
            else if (rpttype == 'gir') {

                var GirData = {
                    cirIDs: reportArray[0].TurbineID + '/' + reportArray[0].CirID,
                    turbineID: 0
                }
                console.log(GirData);
                CallClientApi("GIRData", "POST", GirData).done(function (result) {
                    if (result.cirIDs != null) {
                        deferredObject.resolve();
                    }
                    else {
                        deferredObject.reject();
                    }
                }).fail(function (err) {
                    deferredObject.reject();
                });
            }
            else if (rpttype == 'gbxir') {
                var GBXirData = {
                    cirIDs: reportArray[0].TurbineID + '/' + reportArray[0].CirID,
                    turbineID: 0
                }
                console.log(GBXirData);
                CallClientApi("GBXIRData", "POST", GBXirData).done(function (result) {
                    if (result.cirIDs != null) {
                        deferredObject.resolve();
                    }
                    else {
                        deferredObject.reject();
                    }
                }).fail(function (err) {
                    deferredObject.reject();
                });
            }
            return deferredObject.promise();
        }

        function SaveReportData() {
            var v = findView(ViewId);

            if (v[0].InspectionAvailable == true) {
                SaveBIRData();
            }
            else if (v[0].GeneralInspectionApplicable == true) {
                SaveGIRData();
            }
            else if (v[0].GBXInspectionApplicable == true) {
                SaveGBXIRData();
            }

        }

        function GetBIRData() {
            var birID = '';
            var terbineID = '';
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;
                birID = birID + '/' + this.cells[2].innerHTML;

            });
            birID = terbineID + birID;

            var BirData = {
                cirIDs: birID,
                turbineID: 0
            }
            console.log(BirData);
            CallClientApi("BIRData", "POST", BirData).done(function (result) {
                // $("#cirList").html(result.data);

                $('#txtRepairingsolutions').val(result.repairingSolutions);
                $('#txtRawMaterialsforrepair').val(result.rawMaterials);
                $('#txtConclusionsandRecommendations').val(result.conclusionsAndRecommendations);
            });

        }
        function GetGIRData() {
            var girID = '';
            var terbineID = '';
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;
                girID = girID + '/' + this.cells[2].innerHTML;

            });
            girID = terbineID + girID;

            var GirData = {
                cirIDs: girID,
                turbineID: 0
            }
            console.log(GirData);
            CallClientApi("GIRData", "POST", GirData).done(function (result) {
                // $("#cirList").html(result.data);

                $('#txtClassificationOfDamage').val(result.classificationOfDamage);
                $('#txtAnalysisOfPicture').val(result.analysisOfPicture);
                $('#txtAnalysisOfMeasurments').val(result.analysisOfMeasurments);
                $('#txtConclusionsandRecommendationsGir').val(result.conclusionsAndRecommendations);
            });

        }
        function GetGBXIRData() {
            var gbxirID = '';
            var terbineID = '';
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;
                gbxirID = gbxirID + '/' + this.cells[2].innerHTML;

            });
            gbxirID = terbineID + gbxirID;

            var GBXirData = {
                cirIDs: gbxirID,
                turbineID: 0
            }
            console.log(GBXirData);
            CallClientApi("GBXIRData", "POST", GBXirData).done(function (result) {
                // $("#cirList").html(result.data);

                $('#txtOilAnalysis').val(result.oilAnalysis);
                $('#txtCMSAnalysis').val(result.cmsAnalysis);
                $('#txtAnalysis').val(result.analysis);
                $('#txtgbxConclusionsandRecommendations').val(result.conclusionsAndRecommendations);
            });

        }

        function SaveBIRData() {

            var CIRDataIDs;
            $('#tblCirPopupTable input[name=SelectMaster]').each(function () {
                CIRDataIDs = CIRDataIDs + '/' + $(this).attr("id")
            });
            var terbineID;
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;

            });

            var MasterDataID = $('input[name=SelectMaster]:checked').attr("id");

            var birDataDetail = {
                birDataID: MasterDataID,
                cirIDs: CIRDataIDs.substring(10, CIRDataIDs.length),
                rawMaterials: $("#txtRawMaterialsforrepair").val(),
                conclusionsAndRecommendations: $("#txtConclusionsandRecommendations").val(),
                repairingSolutions: $("#txtRepairingsolutions").val(),
                turbineID: terbineID,
                createdBy: CurrentUserInfo.Name
            }

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("BIRData", "POST", birDataDetail).done(function (result) {
                var error = result.error;
                var msg = result.message;
                if (error == 1) {
                    waitingDialog.hide();
                    NotifyCirMessage('Error : ', msg, 'danger');
                    return false;
                }
                else { location.href = "/cir/manage-bir" }
            })
                .fail(function (e) {
                    NotifyCirMessage('Error : ', "Some Error occured", 'danger');
                    waitingDialog.hide();
                });


        }
        function SaveGIRData() {

            var CIRDataIDs;
            $('#tblCirPopupTable input[name=SelectMaster]').each(function () {
                CIRDataIDs = CIRDataIDs + '/' + $(this).attr("id")
            });
            var terbineID;
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;

            });

            var MasterDataID = $('input[name=SelectMaster]:checked').attr("id");


            var girDataDetail = {
                girDataID: MasterDataID,
                cirIDs: CIRDataIDs.substring(10, CIRDataIDs.length),
                classificationOfDamage: $("#txtClassificationOfDamage").val(),
                analysisOfMeasurments: $("#txtAnalysisOfMeasurments").val(),
                conclusionsAndRecommendations: $("#txtConclusionsandRecommendationsGir").val(),
                analysisOfPicture: $("#txtAnalysisOfPicture").val(),
                turbineID: terbineID,
                createdBy: CurrentUserInfo.Name
            }

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("GIRData", "POST", girDataDetail).done(function (result) {
                var error = result.error;
                var msg = result.message;
                if (error == 1) {
                    waitingDialog.hide();
                    NotifyCirMessage('Error : ', msg, 'danger');
                    return false;
                }
                else { location.href = "/cir/manage-gir" }
            })
                .fail(function (e) {
                    NotifyCirMessage('Error : ', "Some Error occured", 'danger');
                    waitingDialog.hide();
                });


        }
        function SaveGBXIRData() {

            var CIRDataIDs;
            $('#tblCirPopupTable input[name=SelectMaster]').each(function () {
                CIRDataIDs = CIRDataIDs + '/' + $(this).attr("id")
            });
            var terbineID;
            $('#tblCirPopupTable tr').each(function () {
                if (!this.rowIndex) return; // skip first row 
                terbineID = this.cells[6].innerHTML;

            });

            var MasterDataID = $('input[name=SelectMaster]:checked').attr("id");

            var gbxirDataDetail = {
                GbxDataID: MasterDataID,
                cirIDs: CIRDataIDs.substring(10, CIRDataIDs.length),
                oilAnalysis: $("#txtOilAnalysis").val(),
                cmsAnalysis: $("#txtCMSAnalysis").val(),
                analysis: $("#txtAnalysis").val(),
                conclusionsAndRecommendations: $("#txtgbxConclusionsandRecommendations").val(),
                turbineID: terbineID,
                createdBy: CurrentUserInfo.Name
            }

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("GBXIRData", "POST", gbxirDataDetail).done(function (result) {
                var error = result.error;
                var msg = result.message;
                if (error == 1) {
                    waitingDialog.hide();
                    NotifyCirMessage('Error : ', msg, 'danger');
                    return false;
                }
                else { location.href = "/cir/manage-gbxir" }
            })
                .fail(function (e) {
                    NotifyCirMessage('Error : ', "Some Error occured " + e, 'danger');
                    waitingDialog.hide();
                });


        }


        function OpenCreateReport(reportArray, rpttype) {
            var userValid = false;
            if (rpttype == 'bir') {
                userValid = hasRole("BirCreator") || hasRole("Administrator");
            }
            else if (rpttype == 'gir') {
                userValid = hasRole("GirCreator") || hasRole("Administrator");
            }
            else if (rpttype == 'gbxir') {
                userValid = hasRole("GBXIRCreator") || hasRole("Administrator");
            }
            if (userValid == true) {
                CheckRevision(reportArray, rpttype).done(function () {
                    CirAlert.confirm('Documnet already exist for this CIR, do you want to create a new revision?', 'Cir App', 'Yes', 'No', 'warning').done(function () {
                        CreateReportModel(reportArray, rpttype);
                        $("#IRModal").modal('show');
                    });
                }).fail(function () {
                    CreateReportModel(reportArray, rpttype);
                    $("#IRModal").modal('show');
                });
            }
            else {
                NotifyCirMessage('Error : ', 'You dont have sufficient role to access this feature', 'danger');
            }
            //alert("Open Cir Here");
        }


        function CheckCirTemplate(reportArray) {

            var TemplateVersion = $('#hdnTemplateVersion').val();

            if (reportArray.length == 1)
                return (parseInt(reportArray[0].TemplateVer) >= TemplateVersion);

            if (reportArray.length == 2) {
                return (parseInt(reportArray[0].TemplateVer) >= TemplateVersion && parseInt(reportArray[1].TemplateVer) >= TemplateVersion);
            }
            if (reportArray.length == 3) {
                return (parseInt(reportArray[0].TemplateVer) >= TemplateVersion && parseInt(reportArray[1].TemplateVer) >= TemplateVersion && parseInt(reportArray[2].TemplateVer) >= TemplateVersion);
            }
            return true;
        }

        function CheckCirTurbine(reportArray) {
            if (reportArray.length == 1)
                return true;
            if (reportArray.length == 2) {
                return reportArray[0].TurbineID == reportArray[1].TurbineID;
            }
            if (reportArray.length == 3) {
                return (reportArray[0].TurbineID == reportArray[1].TurbineID && reportArray[1].TurbineID == reportArray[2].TurbineID && reportArray[0].TurbineID == reportArray[2].TurbineID);
            }
            return true;
        }
        //Added this function to ensure that user could generate BIRs against either group of new blade cirs or group of old blade cirs. Hybrid group of old and new cirs cannot be used to generate BIRs. BIR v3.1
        function CheckWhetherCIRsAreEitherAllNewOrAllOld(reportArray) {
            var result = false;
            var matchCirId = $('#hdnCirIdBirCreation').val();
            if (reportArray.length == 1)
                result = true;
            if (reportArray.length == 2) {
                result = (parseInt(reportArray[0].CirID) >= matchCirId && parseInt(reportArray[1].CirID) >= matchCirId) || (parseInt(reportArray[0].CirID) < matchCirId && parseInt(reportArray[1].CirID) < matchCirId);
            }
            if (reportArray.length == 3) {
                result = (parseInt(reportArray[0].CirID) >= matchCirId && parseInt(reportArray[1].CirID) >= matchCirId && parseInt(reportArray[2].CirID) >= matchCirId) || (parseInt(reportArray[0].CirID) < matchCirId && parseInt(reportArray[1].CirID) < matchCirId && parseInt(reportArray[2].CirID) < matchCirId);;
            }
            return result;
        }


        function CheckBlade(reportArray) {
            if (reportArray.length == 1)
                return reportArray[0].ComponentType == "Blade";
            if (reportArray.length == 2) {
                return reportArray[0].ComponentType == "Blade" && reportArray[1].ComponentType == "Blade";
            }
            if (reportArray.length == 3) {
                return reportArray[0].ComponentType == "Blade" && reportArray[1].ComponentType == "Blade" && reportArray[2].ComponentType == "Blade";
            }
            return true;
        }

        function CheckCirDate(reportArray) {
            if (reportArray.length == 1)
                return true;
            if (reportArray.length == 2) {

                var datepickerBegin = parseDate(reportArray[0].CreateDate);
                var datepickerEnd = parseDate(reportArray[1].CreateDate);
                var months = datepickerBegin.getMonth() - datepickerEnd.getMonth() + (12 * (datepickerBegin.getFullYear() - datepickerEnd.getFullYear()));
                if (datepickerBegin.getDate() < datepickerEnd.getDate()) {
                    months--;
                }

                if ((months < -3) || (months > 3)) {
                    return false;
                }
            }
            if (reportArray.length == 3) {
                var newArr = [];
                newArr[0] = reportArray[0];
                newArr[1] = reportArray[1];
                if (!CheckCirDate(newArr)) {
                    return false;
                }
                newArr[0] = reportArray[1];
                newArr[1] = reportArray[2];
                if (!CheckCirDate(newArr)) {
                    return false;
                }

            }
            return true;
        }



        var pdfPending = {};
        var pdfPendingIndex = 0;
        var zip = null;

        //function PDFLoaded(pdf) {
        //    if (pdfPending.length > 1) {
        //        var data = pdf.output();
        //        zip.file(pdfPending[pdfPendingIndex] + '_Doc.pdf', btoa(data), { base64: true });
        //    }
        //    else {
        //        if (_process == 0)
        //            pdf.save(pdfPending[pdfPendingIndex] + '_Doc.pdf');
        //    }


        //    pdfPendingIndex++;
        //    if (pdfPendingIndex < pdfPending.length) {
        //        downloadPDF(pdfPending[pdfPendingIndex]);
        //    }
        //    else {
        //        if (pdfPending.length > 1) {
        //            var content = zip.generate({ type: "blob" });
        //            saveAs(content, "CIR.zip");
        //        }
        //        if (_process == 0)
        //            waitingDialog.hide();
        //        else {
        //            var data = pdf.output();
        //            _pdfdata = btoa(data);
        //            Process();
        //        }
        //    }
        //}

        //function downloadPDF(cirid) {
        //    try {

        //        $('iframe').remove();
        //        $('body').append('<iframe src="/cir/manage-cir?remotecirID=' + cirid + '&pdf=1" name="frame1" id="frame1" style="border:none; width:620px;height:0px;overflow:hidden;"></iframe>');
        //    }
        //    catch (e) {
        //        NotifyCirMessage('Error : ', e, 'danger');
        //    }
        //}

        function downloadPDF() {
            var ids = $('#hdnDownloadCirID').val();
            var cirId = $('#hdnCirID' + ids).val();
            //pdfPending = ids.split(',');
            //pdfPendingIndex = 0;
            waitingDialog.show('Downloading PDF..', { dialogSize: 'sm', progressType: 'primary' });
            //zip = new JSZip();
            //downloadPDF(pdfPending[pdfPendingIndex]);

            CallSyncApi("CirSubmissionData/CirPdfFile?cirId=" + cirId, "PUT", "").done(function (result) {
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
        function downloadPDFAll() {
            var ids = $('#hdnDownloadCirID').val();
            var cirIds;
            var cirDataIds = ids.split(',');
            cirDataIds.forEach(function (element) {
                cirIds = cirIds + ',' + $('#hdnCirID' + element).val();
            });
            cirIds = cirIds.substring(10, cirIds.length);

            waitingDialog.show('Downloading PDF..', { dialogSize: 'sm', progressType: 'primary' });
            //zip = new JSZip();
            //downloadPDF(pdfPending[pdfPendingIndex]);

            CallSyncApi("CirSubmissionData/CirPdfFileZip?cirIds=" + cirIds, "PUT", "").done(function (result) {
                waitingDialog.hide();
                if (result) {

                    if (result.result.downloadUrl) {
                        var iOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
                        if (iOS) {
                            window.location = "data:application/zip;base64," + result.result.downloadUrl;
                            openTab("data:application/application/zip;base64," + result.result.downloadUrl);
                        }
                        else {
                            var blob = b64toBlob(result.result.downloadUrl, "application/zip");
                            saveAs(blob, result.result.fileName);
                        }
                    }
                }
                else {
                    NotifyCirMessage('Error : ', "Cir PDF loading error", 'danger');
                }
            });

        }


    </script>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <p>Add a comment (optional):</p>
                    <textarea id="txtComments" class="form-control" rows="5"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary" id="btnSave">Save </button>

                </div>
            </div>
        </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="ModalCirDetails" role="dialog">
        <div class="modal-dialog modal-lg" style="width: 70%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">CIR Details</h4>
                </div>
                <div class="modal-body" id="CirDetailsBody">
                </div>

            </div>
        </div>
    </div>
</asp:Content>
