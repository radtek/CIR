<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    System Log
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/ApplicationScripts/CirSystemLog.js"></script>
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
                                Cir System Log
                            </div>
                        </div>
                    </div>

                    <fieldset id="fsProfile">
                        <legend></legend>
                        <table style="width: 100%;">
                            <tr style="height: 10px;">
                                <td>
                                    <label class="col-lg-3 control-label" id="lblDumy1" style="width: 100%;"></label>
                                </td>
                            </tr>
                            <tr style="width: 100%;">
                                <td style="width: 20%; text-align: right;">
                                    <label class="col-lg-3 control-label" id="lblSearchfilters" style="width: 100%;">Log Type</label>
                                </td>
                                <td style="width: 10%; white-space: nowrap;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width: 80%;">
                                                <select id="LogType" class="form-control">
                                                    <option selected="selected" value=0>All</option>
                                                    <option value=1>Information</option>
                                                    <option value=3>Warning</option>
                                                    <option value=2>Error</option>
                                                </select>
                                            </td>
                                            <td style="width: 20%;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:30%;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width: 45%;">
                                                <input type="text" id="txtFromDate" placeholder="From Date" data-toggle="tooltip" data-placement="top" title="Log from date" maxlength="10" class="form-control" />
                                            </td>
                                            <td style="width: 10%;">
                                            </td>
                                            <td style="width:45%;">
                                                <input type="text" id="txtToDate" placeholder="To Date" data-toggle="tooltip" data-placement="top" title="Log to date" maxlength="10" class="form-control" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <td style="width: 30%;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width:10%;">
                                                
                                            </td>
                                            <td style="width: 90%;">
                                                <a href="javascript:void(0);" id="linkGetCirLog" class="btn btn-primary AdvancedSearchButton">Get Log</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr style="height: 10px;">
                                <td>
                                    <label class="col-lg-3 control-label" id="lblDumy2" style="width: 100%;"></label>
                                </td>
                            </tr>

                            <tr style="width: 100%;">
                                <td style="width: 20%;"></td>
                                <td style="width: 20%;"></td>
                                <td style="width: 30%;"></td>
                                <td style="width: 30%;"></td>
                            </tr>

                        </table>
                        
                        <div class="col-lg-12" style="text-align: left;">
                            <div id="page-selection1" class="page-selection"></div>
                        </div>
                        <div class="col-lg-12">
                            <table id="SystemLogGrid" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th onclick="SortGrid('0')" style="width: 5%">CIR Log Id</th>
                                        <th onclick="SortGrid('1')" style="width: 5%">Log Type</th>
                                        <th onclick="SortGrid('2')" style="width: 5%">Message</th>
                                        <th class="more" id="LogDetailsCol" onclick="SortGrid('3')" style="width: 80%">Details</th>
                                        <th onclick="SortGrid('4')" style="width: 5%">Log Date Time</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div class="col-lg-12" style="text-align: left;">
                            <div id="page-selection2" class="page-selection"></div>
                        </div>
                        <div class="col-xs-7 dataTables_info" style="text-align: left;">
                            <label class="control-label" id="lblTotalRecords"></label>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <div>
        </div>
    </section>


</asp:Content>
