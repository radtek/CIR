<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CIR Search - CIM Inspection Report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Js/jquery.dataTables.min.js"></script>
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />   
    <link href="../Css/scroller.dataTables.min.css" rel="stylesheet" />   
      <link href="../Css/tablesaw.css" rel="stylesheet" type="text/css" /> 
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
     <script src="../Js/ApplicationScripts/CirDetails.js"></script>
    <style>
        #cirSearchListLocal td a {
            color: #000 !important;
        }

        .dataTables_wrapper .dataTables_length, .dataTables_wrapper .dataTables_filter, .dataTables_wrapper .dataTables_info, .dataTables_wrapper .dataTables_processing, .dataTables_wrapper .dataTables_paginate {
            color: black !important;
            padding-top: 6px !important;
        }
        
        .dataTables_wrapper .dataTables_paginate .paginate_button.disabled, .dataTables_wrapper .dataTables_paginate .paginate_button.disabled:hover, .dataTables_wrapper .dataTables_paginate .paginate_button.disabled:active {
        color: black !important;
        padding-bottom: 8px !important;
    }

        .localdataTable th
        {
            background-color: rgb(0, 114, 187) !important;
        }

        [class^="icon-"],
        [class*=" icon-"] {
            display: inline-block;
            width: 14px;
            height: 14px;
            margin-top: 1px;
            *
        margin-right: .3em;
            line-height: 14px;
            vertical-align: text-top;
            background-image: url("../Images/glyphicons-halflings.png");
            background-position: 14px 14px;
            background-repeat: no-repeat;
        }

         .icon-top-sign {
            background-position: -288px -95px;
        }

        .cirback-top:hover {
            color: #fff !important;
              background-color: #0072BB;
            text-decoration: none;
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
            color: #fff;
            background-color:#3eaee8;
            text-decoration: none;
            border-radius: 3.2rem;
            text-align: center;
            cursor: pointer;
        }
    </style>



    <section class="content" style="background: transparent">
        
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <div id="divPageContent">
                            <fieldset>
                                <legend>CIR Search Result</legend>
                                <div id="searchRestultDisplay" class="alert alert-success" style="display: none;">
                                    Search Result For:  &nbsp;<strong><span id="cirSearchText"></span></strong>
                                </div>

                                <div class="form-group">
                                    <div class="col-xs-12" style="text-align: right;">
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
                                </div>
                                <div id="tabs">
                                    <ul>

                                        <li><a href="#tabs-2">Remote CIR Data (<strong><span id="spnRemoteCount">Loading..</span></strong>)</a></li>
                                        <li><a href="#tabs-1">Local CIR Data (<strong><span id="spnLocalCount">Loading..</span></strong>)</a></li>
                                    </ul>
                                    <div id="tabs-1">
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: right;">
                                                <div id="page-selection1-Local" class="page-selection-Local"></div>
                                            </div>
                                        </div>
                                        <div class="bs-example form-horizontal">
                                            <div class="form-group">
                                                <div class="table-responsive">
                                                    <table id="cirSearchListLocal" class="table table-striped localdataTable table-bordered dataTable2 no-footer" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th data-sorter="false" data-hide="phone" scope="col" style="min-width: 70px">Action</th>
                                                                <th data-hide="phone" scope="col" style="column-width: 70px">Status</th>
                                                                <th data-hide="phone" scope="col">CIR ID</th>
                                                                <th data-hide="phone" scope="col">Cir Name</th>
                                                                <th data-hide="phone" scope="col">Cim Case</th>
                                                                <th data-hide="phone" scope="col">Turbine Type</th>
                                                                <th data-hide="phone" scope="col">Turbine Number</th>
                                                                <th data-hide="phone" scope="col">Country</th>
                                                                <th data-hide="phone" scope="col">Created On</th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <!--Commented By Siddharth Chauhan on 06-06-2016. To implement the new List layout-->
                                        <%--  <div class="form-group">
                                            <div class="col-xs-12" style="text-align: right;">
                                                <div id="page-selection2-Local" class="page-selection-Local"></div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: right;">
                                                <label class="control-label" id="lblTotalRecords-Local"></label>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <!--Remote CIR Tab modified By Siddharth Chauhan on 09-06-2016. Task No. : 75297-->
                                    <div id="tabs-2">
                                        <div class="row">

                                            <div class="col-xs-6">

                                                <div class="col-xs-12" style="text-align: left;">
                                                    <strong>
                                                        <label class="control-label" id="lblShowingRecords-Remote"></label>
                                                    </strong>
                                                </div>

                                            </div>
                                            <div class="col-xs-6">
                                                <div class="form-group">
                                                    <button id="btnUnApproved" class="btn btn-primary" style="border: 2px solid #000000">
                                                        Submitted <span class="badge" id="unApprovedCount"></span>
                                                    </button>

                                                    <button id="btnAccepted" class="btn btn-success">
                                                        Accepted <span class="badge" id="acceptedCount"></span>
                                                    </button>

                                                    <button id="btnRejected" class="btn btn-danger">
                                                        Rejected <span class="badge" id="rejectedCount"></span>
                                                    </button>
                                                    &nbsp;<a title="Export list to Excel" href="javascript:void(0);" id="GlobalSearchExportExcel" style="color: #333;"><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i><b>&nbsp;Export to Excel</b></a>
                                                    </div>
                                                   
                                                <%--<div>
                                                        <a title="Export list to Excel" href="javascript:void(0);" id="GlobalSearchExportExcel" style="color: #333;"><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i><b>&nbsp;&nbsp;Export result to Excel</b></a>
                                                </div>--%>
                                            </div>
                                        </div>

                                       <%-- <div class="form-group">
                                            <div class="col-xs-12" style="text-align: left;">
                                                <div id="page-selection1-Remote" class="page-selection-Remote"></div>
                                            </div>
                                        </div>--%>
                                        <table role="main" id="cirSearchListRemote" class="table table-striped  table-bordered dataTable2 no-footer dataTable">
                                            <thead>
                                                <tr>
                                                    <th data-sorter="false" data-hide="phone" scope="col" width="16%">Actions</th>
                                                    <th data-hide="phone" scope="col">CIR ID</th>
                                                    <th data-class="expand" scope="col" data-sort-initial="true" width="35%">CIR Name</th>
                                                    <th data-hide="phone" scope="col">CIM Case no.</th>
                                                    <th data-hide="phone" scope="col">Turbine Type</th>
                                                    <th data-hide="phone" scope="col">Turbine no.</th>
                                                    <th data-hide="phone" scope="col">Country</th>
                                                    <th data-hide="phone" scope="col">Brand</th>
                                                    <th data-hide="phone" scope="col">Created On</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                       <%-- <div class="form-group">
                                            <div class="col-xs-12" style="text-align: left;">
                                                <div id="page-selection2-Remote" class="page-selection-Remote"></div>
                                            </div>
                                        </div>--%>
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: left;">
                                                <label class="control-label" id="lblTotalRecords-Remote"></label>
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <div class="col-xs-12" style="text-align: left;">
.                                                <button id="btnLazyLoad" class="btn btn-sm btn-default col-xs-12" >
                                                     Loading more results..&nbsp;<i id="btnLazyLoadIcon" class='fa fa-spinner fa-spin'></i>
                                                 </button>
                                            </div>
                                        </div>
                                       <%-- <div class="form-group">
                                            <div class="col-xs-12" style="text-align: left; display: none" id="divExportRemote">
                                                <a style="color: #000 !important" title="Export list to Excel" onclick="GenerateExcel();" data-target="#ExcelExportModal" data-toggle="modal" data-backdrop="static" data-keyboard="false" ><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i>&nbsp;Export list to Excel</a>
                                            </div>
                                        
                                             </div>--%>
                                        <input type="hidden" name="hdnDownloadRemoteCirID" id="hdnDownloadRemoteCirID" />
                                        <input type="hidden" id="hdnAppCirId" value="<%= System.Configuration.ConfigurationManager.AppSettings["hdnCirId"] %>" />
                                    </div>
                                </div>
                                <div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
             <a href="#" class="cirback-top" title="Click to scroll top"><i class="icon-top-sign"></i></a>
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
                        &nbsp;&nbsp;&nbsp;&nbsp; <i class=" loadersign fa fa-spin fa-lg"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModalRemote" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <p>Add a comment (optional):</p>
                    <textarea id="txtCommentsRemote" class="form-control" rows="5"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary" id="btnSaveComments">Save </button>

                </div>
            </div>
        </div>
    </div>


    <%--Local Data Modal--%>
    <div class="modal fade" id="myDetailsModal" role="dialog">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title"></h4>
                            </div>
                            <div class="modal-body">
                                <p id="strErrorMsg"></p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade align-center" id="myEditModal" role="dialog" tabindex="-1" aria-hidden="true" style="padding-top:10%; overflow-y:visible;">
                    <div class="modal-dialog modal-sm" style="max-width:450px;">
                        <div class="modal-content">
                            <div class="modal-header" style="max-height:40px;">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h5 class="modal-title" style="font-weight:bold"></h5>
                            </div>
                            <div class="modal-body" style="text-align:center">
                                <button type="button" class="btn btn-primary" onclick="KeepLocalVersion()">Keep Local Version</button>&nbsp;&nbsp;
                                <button type="button" class="btn btn-success" onclick="KeepServerVersion()">Keep Server Version</button>&nbsp;&nbsp;
                                <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cancel Edit</button>--%>
                            </div>
                        </div>
                    </div>
                </div>
        <%--Local Data Modal--%>

      <div class="modal fade" id="ModalCirDetails" role="dialog">
        <div class="modal-dialog modal-lg" style="width:70%">
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

    <div class="modal fade" id="DelegateCIRModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <%--==============================================--%>
                        <div class="form-group">
                            <%--<%: Html.Label("Enter Name/Email :", new { @class="col-lg-3 control-label" })%>--%>
                            <label class="col-lg-3 control-label" id="lblUserName">User Initial</label>
                            <div class="col-lg-9">
                                <%--<input type="text" id="txtUserToSearch" class="form-control" placeholder="User Initial" maxlength="15" />--%>
                                <input type="hidden" id="CIRId"/>
                                <input type="hidden" id="CirDataLocalID"/>
                              
                                <%: Html.TextBox("txtUserToSearch", "",  new { @class = "form-control", @placeholder="User Initial (3 characters minimum)", @maxlength = "15" })%>
                                
                            </div>
                        </div>
                        <div class="form-group">
                           <div class="col-lg-9 col-lg-offset-3" style="text-align: left">
                               <label id="lblUserToSearch_Validation" style="color: red;"></label>

                            </div>
                            <div class="col-lg-9 col-lg-offset-3" style="text-align: right">
                                <button id="btnUserSearch_LSearch" type="button" class="btn btn-primary">Search</button>

                            </div>
                        </div>
                        <div class="form-group">
                             <%: Html.Label("Available Users", new { @class="col-lg-3 control-label" })%>
                           <%-- <label class="col-lg-3 control-label" id="lblAvailableUser">Available Users</label>--%>
                            <div class="col-lg-9">
                                <%: Html.DropDownList("UserList", Enumerable.Empty<SelectListItem>(), new { @class = "form-control", size = 8 })%>
                               <%-- <select id="UserList" class="form-control" multiple="multiple" size="8" />--%>
                            </div>
                        </div>
                        <%--================================================--%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" id="btnAssignCIR_LSearch">Delegate</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
