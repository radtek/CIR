<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Manufacturer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/ApplicationScripts/ManageManufacturer.js"></script>
    <style type="text/css">
        .even {
            background-color: #f3f4f5;
        }
        .form-group{
            padding:5px
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
                                Manage Manufacturer
                                 <div class="Navbar-brandsmall">Manage Manufacturer List</div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">

                            <div class="col-xs-3 text-right">
                                <b>Manufacturer Type : </b>
                            </div>
                            <div class="col-xs-4" style="text-align: left;">
                                <select id="ddlManufacturerType" class="form-control">
                                    <option value="1">Blade</option>
                                    <option value="3">Gearbox</option>
                                    <option value="2">Generator</option>
                                    <option value="4">Transformer</option>
                                    <option value="5">Other</option>
                                </select>
                            </div>
                            <div class="col-xs-5" style="text-align: right;">
                                <a href="javascript:void(0);" id="btnNew" class="btn btn-primary AddManufacturer"><i style="color: #ffffff;" class="fa fa-plus"></i>Create New Blade Manufacturer</a>
                            </div>

                        </div>
                    </div>

                    <div id="LocalSearch" class="row">
                        <br />
                        <div class="col-md-12">
                            <div class="panel">


                                <table role="main" id="localManufacturerTable" class="FlexResponive list">
                                    <thead>
                                        <tr>
                                            <th data-hide="phone" style="text-align: center !important;" scope="col" data-sort-ignore="true">Action</th>
                                            <th data-class="phone" scope="col" data-sort-initial="true" style="width: 24%">Manufacturer Name</th>
                                            <th data-hide="expand" scope="col" style="width: 24%">Contact Name</th>
                                            <th data-hide="expand" scope="col" style="width: 24%">To</th>
                                            <th data-hide="expand" scope="col" style="width: 24%">Cc</th>

                                        </tr>
                                    </thead>
                                </table>


                            </div>
                        </div>

                    </div>

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
        <div>
        </div>


        <!-- Modal -->
        <div class="modal fade" id="myDetailsModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Name : </label>
                                <div class="col-lg-9">
                                    <input id="txtManufacturerName" data-toggle="tooltip"
                                        data-placement="top" title="Manufacturer Name" class="form-control" placeholder="Manufacturer Name" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Contact : </label>
                                <div class="col-lg-9">
                                    <input id="txtContactName" data-toggle="tooltip"
                                        data-placement="top" title="Contact Name" class="form-control" placeholder="Contact Name" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">To : </label>
                                <div class="col-lg-9">
                                    <input id="txtTo" data-toggle="tooltip"
                                        data-placement="top" title="To" class="form-control" placeholder="To" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Cc : </label>
                                <div class="col-lg-9">
                                    <textarea id="txtCc" class="form-control" data-toggle="tooltip"
                                        data-placement="top" title="Cc" placeholder="Cc"></textarea>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="hidden" id="hId" value="0" />
                        <button type="button" class="btn btn-primary" onclick="cirManufacturer.saveManufacturer();">Save</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                    </div>
                </div>
            </div>
        </div>


    </section>


</asp:Content>






