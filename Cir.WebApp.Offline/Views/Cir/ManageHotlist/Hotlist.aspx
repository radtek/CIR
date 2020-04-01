<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Hotlist
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/ApplicationScripts/ManageHotlist.js"></script>
    <style type="text/css">
        .even {
            background-color: #f3f4f5;
        }

        .form-group {
            padding: 5px;
        }
    </style>
    <style>
        table.dataTable th {
            background-color: rgb(0, 114, 187) !important;
        }
    </style>
    <section class="content" style="background: transparent">
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Hotlist Administration
                                 <div class="Navbar-brandsmall">Manage HotList</div>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="form-group">

                            <div class="col-xs-12" style="text-align: right;">
                                <a href="javascript:void(0);" id="btnNew" class="btn btn-primary AddHotlist"><i style="color: #ffffff;" class="fa fa-plus"></i>Create New Hotlist</a>
                            </div>
                        </div>
                    </div>

                    <div id="LocalSearch" class="row">
                        <br />
                        <div class="col-md-12">
                            <div class="panel">
                                <table role="main" id="localHotlistTable" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th data-hide="phone" style="text-align: center !important;" scope="col" data-sort-ignore="true">Action</th>
                                            <th data-class="phone" scope="col" data-sort-initial="true" style="width: 5%">Template</th>
                                            <th data-hide="expand" scope="col" style="width: 5%">Vestas Item Number</th>
                                            <th data-hide="expand" scope="col" style="width: 30%">Vestas Item Name</th>
                                            <th data-hide="expand" scope="col" style="width: 20%">Manufacturer Name</th>
                                            <th data-hide="expand" scope="col" style="width: 20%">Email</th>
                                            <th data-hide="expand" scope="col" style="width: 10%">Cc</th>
                                            <th class="more" scope="col" style="width: 30%">Hotlist Display</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12" style="text-align: left;">
                        <a title="Export list to Excel" onclick="GenerateExcel();" data-target="#ExcelExportModal" data-toggle="modal" data-backdrop="static" data-keyboard="false"><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i>&nbsp;Export list to Excel</a>
                    </div>


                    <div id="header-fixed">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="navbar-left navbar-SubHead">
                                    My Local History
                                <div class="Navbar-brandsmall">Component Inspection Report</div>
                                </div>
                            </div>
                        </div>
                        <div id="LSearchbox" class="row"></div>
                        <table id="Lheader-fixed" class="FlexResponive FlexResponive-loaded default"></table>
                    </div>


                    <!-- Modal -->

                </div>
            </div>
        </div>


        <!-- Modal -->
        <div class="modal fade" id="myDetailsModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body" id="myform">
                        
                        <%--<div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Report Type: </label>
                                <div class="col-lg-9">
                                    <select 
                                        id="ddlInspectionReportType" 
                                        class="form-control" 
                                        data-fieldtype="Blade" 
                                        data-datatable="ComponentInspectionReportType"
                                        data-textfield="text" 
                                        data-valuefield="value" 
                                        style="width: 99%">
                                    </select>
                                </div>
                            </div>
                        </div>--%>

                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Brand Type: </label>
                                <div class="col-lg-9">
                                    <select 
                                        id="ddlBrand" 
                                        class="form-control" 
                                        style="width: 99%">
                                    </select>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Template Type: </label>
                                <div class="col-lg-9">
                                    <select 
                                        id="ddlTemplate" 
                                        class="form-control"  
                                        style="width: 99%">
                                    </select>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Vestas Item Number: </label>
                                <div class="col-lg-9">
                                    <input id="txtVestasItemNumber" data-toggle="tooltip"
                                        data-placement="top" title="Vestas Item Number" class="form-control" placeholder="Vestas Item Number" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Vestas Item Name: </label>
                                <div class="col-lg-9">
                                    <input id="txtVestasItemName" data-toggle="tooltip"
                                        data-placement="top" title="Vestas Item Name" class="form-control" placeholder="Vestas Item Name" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Manufacturer Name: </label>
                                <div class="col-lg-9">
                                    <input id="txtManufacturerName" data-toggle="tooltip"
                                        data-placement="top" title="Manufacturer Name" class="form-control" placeholder="Manufacturer Name" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Email: </label>
                                <div class="col-lg-9">
                                    <input id="txtTo" data-toggle="tooltip"
                                        data-placement="top" title="Email" class="form-control" placeholder="Email" />

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Cc: </label>
                                <div class="col-lg-9">
                                    <textarea id="txtCc" class="form-control" data-toggle="tooltip"
                                        data-placement="top" title="Cc" placeholder="Cc"></textarea>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Hotlist Display: </label>
                                <div class="col-lg-9">
                                    <textarea id="txtHotlistDisplay" class="form-control" data-toggle="tooltip"
                                        data-placement="top" title="Hotlist Display" placeholder="Hotlist Display"></textarea>

                                </div>
                            </div>
                        </div>
                        <input type="hidden" id="txtHdnAzureId" />
                        <input type="hidden" id="txtBrand" />
                        <input type="hidden" id="txtCirTemplate" />
                        <input type="hidden" id="txtReportType" />
                        <input type="hidden" id="txtHotItemDisplay" />

                        <div class="modal-footer">
                            <input type="hidden" id="hId" value="0" />
                            <button type="button" class="btn btn-primary" onclick="clearAllfields();">Clear All Field</button>
                            <button type="button" class="btn btn-primary" onclick="cirhotlist.savehotlist();">Save</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        </div>
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
                        <span style="margin:-5px 0px 0px 0px;">Generating file, Please Wait..</span>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp; <i class="loadersign fa fa-spin fa-lg"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        var DataForExcel = [];
        var dataforexcelnew = [];
        function GenerateExcel() {
            DataForExcel = [];

            $('#divExcelGenWait').hide();
            $('#ExcelExportModal .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);

            ReadDataForExcel(1, function (data) {
                // data = jQuery.parseJSON(data);
                $('#divExcelGenWait').show();
                try {
                    JSONToXlSXConvertor(data, "hotlist", true);
                }
                catch (err) {
                    NotifyCirMessage("Error", err, "danger")
                }
                //waitingDialog.hide();
                $('#ExcelExportModal').modal('hide');
                loading = 0;
            })
        }

        function ReadDataForExcel(cp, callback) {
            var hotlist = {};
            hotlist.SortColumnIndex = 0;
            hotlist.SortDirection = 1;
            hotlist.CurrentPageNumber = cp;
            hotlist.RecordsPerPage = 700;

            try {


                //CallClientApi("GetHotlist", "GET", "").done(function (result) {
                CallSyncApi("HotlistData/GetAll", "GET", "").done(function (data) {
                    var arrData = typeof result != 'object' ? JSON.parse(result) : result;

                    for (var i = 0, d; d = arrData[i]; i++) {

                        DataForExcel.push(d);
                    }
                    $.each(DataForExcel, function (i, item) {


                        if (item.reportTypeId == 1) {
                            item.reportType = "Blade";



                        }


                        if (item.reportTypeId == 2) {
                            item.reportType = "Gearbox";

                        }

                        if (item.reportTypeId == 3) {
                            item.reportType = "General";

                        }

                        if (item.reportTypeId == 4) {
                            item.reportType = "Generator";

                        }

                        if (item.reportTypeId == 5) {
                            item.reportType = "Transformer";

                        }

                        if (item.reportTypeId == 6) {
                            item.reportType = "Main Bearing";

                        }

                        if (item.reportTypeId == 7) {
                            item.reportType = "Skiipack";

                        }




                    });

                    
                    for (var i = 0, d; d = DataForExcel[i]; i++) {

                        dataforexcelnew.push({
                            Id: DataForExcel[i].hotItemId, 'Report type': DataForExcel[i].reportType, 'Vestas item number': arrData[i].vestasItemNumber, 'Vestas item name': arrData[i].vestasItemName, 'Manufacture name': arrData[i].manufacturerName, Email: arrData[i].email, Cc: arrData[i].cc, 'Hotlist display': arrData[i].hotItemDisplay
                        });
                    }

                    callback(dataforexcelnew);

                });
            }

            catch (err) {
                //waitingDialog.hide();
                loading = 0;
                callback(dataforexcelnew);
                NotifyCirMessage("Error", err, "danger")
            }

        }

        function clearAllfields() {
            document.getElementById("ddlInspectionReportType").value = "";
            document.getElementById("txtVestasItemNumber").value = "";
            document.getElementById("txtVestasItemName").value = "";
            document.getElementById("txtManufacturerName").value = "";
            document.getElementById("txtTo").value = "";
            document.getElementById("txtCc").value = "";
            document.getElementById("txtHotlistDisplay").value = "";
        }

    </script>


</asp:Content>






