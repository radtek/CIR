<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Draft CIR
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/ApplicationScripts/ManageDraftCIR.js"></script>
      <style>
        table.dataTable th {
            background-color: rgb(0, 114, 187) !important;
        }
    </style>
    <section class="content" style="background: transparent">
        <div class="panel-body" style="padding: 0px">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Manage Draft CIR / Remote Sync Errors
                            </div>
                        </div>
                    </div>

                    <fieldset id="fsProfile">
                        <legend></legend>

                        <table style="width: 100%;">
                            
                           
                            <tr style="width: 100%;">
                                <td style="width: 25%; text-align: right;">
                                    <label class="col-lg-3 control-label" id="lblCIRState" style="width: 100%;">CIR State</label>
                                </td>
                                <td style="width: 50%;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width: 70%;">
                                                <select id="ddlLogType" class="form-control" style="width: 98%;">
                                                    <option selected="selected" value="0">Select CIR State</option>
                                                    <option value="1">Draft</option>
                                                    <option value="-1">Error</option>
                                                </select>
                                            </td>
                                            <td style="width: 30%;">
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 25%;"></td>
                            </tr>


                             <tr style="width: 100%;">
                                <td style="width: 25%; text-align: right;">
                                    <label class="col-lg-3 control-label" id="lblUserInitial" style="width: 100%;">User Initial</label>
                                </td>
                                <td style="width: 50%;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width: 70%;">
                                                <input type="text" id="txtUserInitial" class="form-control numbersOnly" style="width: 98%;" placeholder="User Initial" />
                                            <%--value="ciradmin@VestasDev.onmicrosoft.com"--%>
                                            </td>
                                            <td style="width: 30%;">
                                                 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 25%;"></td>
                            </tr>

                            <tr id="CirIdRow" width: 100%;">
                                <td style="width: 25%; text-align: right;">
                                    <label class="col-lg-3 control-label" id="lblCIRId" style="width: 100%;">CIR Id</label>
                                </td>
                                <td style="width: 50%;">
                                    <table style="width: 100%;">
                                        <tr style="width: 100%;">
                                            <td style="width: 70%;">
                                                <input type="number" id="txtCIRId" class="form-control" style="width: 98%;" placeholder="CIR Id" />
                                            </td>
                                            <td style="width: 30%;">
                                               <a href="javascript:void(0);" id="linkSearchDraftSyncErrors" class="btn btn-primary">Search</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 25%;"></td>
                            </tr>

                            <tr style="height: 20px;">
                                <td>
                                    <label class="col-lg-3 control-label" id="lblDumy1" style="width: 100%;"></label>
                                </td>
                            </tr>

                        </table>
                      <%--  <div class="row">
                            <div class="col-xs-4">
                                 <label  id="lblSearchProfileName">User Initial</label>
                            </div>
                            <div class="col-xs-4">
                                <input type="text" id="txtUserInitial" class="form-control" placeholder="Exact Initial - Ex: InitialName@vestas.com" />
                            </div>
                            <div class="col-xs-4">
                                 <select id="LogType" class="form-control">
                                    <option selected="selected" value=0>Select CIR State</option>
                                    <option value=1>Draft</option>
                                    <option value=-1>Error</option>
                                </select>
                            </div>
                             <div class="col-xs-4">
                                  <a href="javascript:void(0);" id="linkSearchSyncErrors" class="btn btn-primary">Search</a>
                            </div>
                        </div>--%>
                        <div class="col-lg-12" style="overflow-x: scroll; max-width: 1000px">
                        <table id="DraftSyncErrorGrid"  class="table table-striped table-bordered dataTable2 no-footer">
                                <thead>
                                    <tr>
                                        <th>Action</th>
                                        <th>Status</th>
                                        <th>CIR Id</th>
                                        <th>User Name</th>
                                        <th>CIR Name</th>
                                        <th>CIM Case No</th>
                                        <th>Turbine No</th>
                                        <th>Country</th>
                                        <th>Site Name</th>
                                        <th>Last Update Datetime</th>
                                        <th>Is Submitted?</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </fieldset>

                </div>
            </div>
        </div>
        <div>
        </div>

        <div class="modal fade" id="StatusDetailsModal" role="dialog">
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

        <div class="modal fade" id="ReassignCIRModal" role="dialog">
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
                                <button id="btnUserSearch_AssignCIR" type="button" class="btn btn-primary">Search</button>

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
                        <button type="button" class="btn btn-primary" id="btnAssignCIR">Assign </button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
