<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Local History - CIM Inspection Report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     
    <link href="../Css/footable.core.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>  
    <script src="../Js/footable.all.min.js"></script>  
    <script src="../Js/ApplicationScripts/CirDataDisplay.js"></script>
    <script src="../Js/ApplicationScripts/SynchronizationProgressController.js"></script>
    <script src="../Js/ApplicationScripts/localHistory.js"></script>
    
   <style type="text/css">
       .well-White {
           width: 100%;
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
           background-color: #3eaee8;
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
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                My Local History
                        <div class="Navbar-brandsmall">Component Inspection Report</div>
                            </div>

                            <div class="nav navbar-top-links navbar-right" style="text-align: right; Margin-top: 17px">
                                <button id="reject" class="btn btn-xs btn-danger" onclick="ClearAllCIRs()" type="button">
                                    <i style="color:#ffffff;" class="fa fa-trash-o fa-lg"></i>   Clear All 
                                </button>

                                <button id="inbox" class="btn btn-xs btn-primary CreatenewCirLink" type="button">                                    
                                        <i style="color:#ffffff;" class="fa fa-plus"></i> Create new CIR
                                </button>
                            </div>
                        </div>
                    </div>
                    <div id="LocalSearch" class="row">                       
                        <br />
                        <div class="col-md-12">
                            <div class="panel panel-danger">
                                <div class="panel-heading">
                                    <div style="width: 100%;">
                                    <div style="width: 40px; float: left;">
                                        <i class="fa fa-exclamation-triangle fa-3x" style="color:#cc0000;"></i>
                                    </div>
                                    <div style="margin-left: 43px;">
                                        <h3 class="panel-title"><b>Need My Attention</b></h3>
                                        <b>CIRs With Sync Error</b>
                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-minus"></i></span>
                                    </div>
                                </div>
                                </div>
                                <div class="panel-body" style="padding:0px">
                                    <table role="main" id="localHistoryTableWithErrors" class="footable table toggle-arrow-alt redtheme" data-sorting="false">
                                        <thead>
                                            <tr>
                                                                                            
                                                <th style="width:10px;text-align:center">Status</th>
                                                <th>CIR ID</th>
                                                <th>CIR Name</th>
                                                <th style="max-width:50px;text-align:center" data-hide="phone">CIM Case</th>
                                                <th data-hide="phone">Turbine Type</th>
                                                <th data-hide="phone">Turbine No.</th>
                                                <th data-hide="phone">Site Name</th>
                                                <th data-hide="phone">Created On</th>
                                                <th data-hide="phone,tablet">Action</th>   
                                              
                                            </tr>
                                        </thead>
                                    </table>

                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-12">
                            <div class="panel panel-warning">
                                <div class="panel-heading">
                                    <div style="width: 100%;">
                                    <div style="width: 40px; float: left;">
                                        <i class="fa fa-lock fa-3x" style="color:#8a6d3b;"></i>
                                    </div>
                                    <div style="margin-left: 43px;">
                                       <h3 class="panel-title"><b>CIRs Locked By Me</b></h3>
                                        <b>Local Draft Versions</b>
                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-minus"></i></span>
                                    </div>
                                </div>
                                </div>
                                <div class="panel-body"  style="padding:0px">
                                    <table role="main" id="localHistoryTableLocked" class="footable table toggle-arrow-alt yellowtheme"  data-sorting="false">
                                        <thead>
                                            <tr>
                                                                                           
                                                <th style="width:10px;text-align:center">Status</th>
                                                <th>CIR ID</th>
                                                <th>CIR Name</th>
                                                <th data-hide="phone" style="max-width:50px;text-align:center">CIM Case</th>
                                                <th data-hide="phone">Turbine Type</th>
                                                <th data-hide="phone">Turbine No.</th>
                                                <th data-hide="phone">Site Name</th>
                                                <th data-hide="phone">Created On</th>
                                                <th data-hide="phone,tablet" style="min-width:50px;text-align:center">Action</th>   
                                                <th data-hide="phone">Sync</th>
                                            </tr>
                                        </thead>
                                    </table>                                     
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />
                        <div class="col-md-12">
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                    <div style="width: 100%;">
                                    <div style="width: 40px; float: left;">
                                        <i class="fa fa-history fa-3x" style="color:#3c763d;"></i>
                                    </div>
                                    <div style="margin-left: 43px;">
                                       <h3 class="panel-title"><b>My History</b></h3>
                                        <b>All succesfully synced CIRs</b>
                                        <span class="pull-right clickable"><i class="glyphicon glyphicon-minus"></i></span>
                                        <div id="_pageCount"></div>
                                    </div>
                                </div>
                                </div>
                                <div class="panel-body"  style="padding:0px">
                                    <table role="main" id="localHistoryTable" class="footable table toggle-arrow-alt greentheme"  data-sorting="false">
                                        <thead>
                                            <tr>
                                                <th style="width:10px;text-align:center" data-sort-ignore="true">Status</th> 
                                                <th data-sort-ignore="true">CIR ID</th>
                                                <th data-sort-ignore="true">CIR Name</th>
                                                <th data-sort-ignore="true" data-hide="phone"  style="max-width:50px;text-align:center">CIM Case</th>
                                                <th data-sort-ignore="true" style="width:80px;text-align:center" data-hide="phone">Turbine Type</th>
                                                <th data-sort-ignore="true" data-hide="phone">Turbine No.</th>
                                                <th data-sort-ignore="true" data-hide="phone">Site Name</th>
                                                <th data-sort-ignore="true" data-hide="phone">Created On</th>
                                                <th data-sort-ignore="true" data-hide="phone">CIR Status</th>
                                                <th data-sort-ignore="true" data-hide="phone,tablet" style="min-width:50px;text-align:center">Action</th>   
                                            
                                            </tr>
                                        </thead>
                                    </table>
                                     <%--<div class="col-xs-12" style="text-align:center">
                                                 <button id="btnLazyLoad" class="btn btn-sm btn-default col-xs-12" >
                                                     Loading more results..&nbsp;<i id="btnLazyLoadIcon" class='fa fa-spinner fa-spin'></i>
                                                 </button>
                                       </div>--%>
                                </div>
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
                                <p id="strErrorMsg"></p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>

                            </div>
                        </div>
                    </div>
                </div>

            <div class="modal fade align-center" id="myEditModal" role="dialog" tabindex="-1" aria-hidden="true" style="padding-top: 10%; overflow-y: visible;">
                <div class="modal-dialog modal-sm" style="max-width: 450px;">
                    <div class="modal-content">
                        <div class="modal-header" style="max-height: 40px;">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h5 class="modal-title" style="font-weight: bold"></h5>
                            <input type="hidden" value="" id="_hId"/>
                        </div>
                        <div class="modal-body" style="text-align: center">
                            <button type="button" class="btn btn-primary" onclick="KeepLocalVersion()">Keep Local Version</button>&nbsp;&nbsp;
                                    <button type="button" class="btn btn-success" onclick="KeepServerVersion()">Keep Server Version</button>&nbsp;&nbsp;
                                    <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cancel Edit</button>--%>
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
                                <input type="hidden" id="isNew"/>
                              
                                <%: Html.TextBox("txtUserToSearch", "",  new { @class = "form-control", @placeholder="User Initial (3 characters minimum)", @maxlength = "15" })%>
                                
                            </div>
                        </div>
                        <div class="form-group">
                           <div class="col-lg-9 col-lg-offset-3" style="text-align: left">
                               <label id="lblUserToSearch_Validation" style="color: red;"></label>

                            </div>
                            <div class="col-lg-9 col-lg-offset-3" style="text-align: right">
                                <button id="btnUserSearch_LHistory" type="button" class="btn btn-primary">Search</button>

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
                        <button type="button" class="btn btn-primary" id="btnAssignCIR_LHistory">Delegate</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

  <a href="#" class="cirback-top" title="Click to scroll top"><i class="icon-top-sign"></i></a>
</asp:Content>
