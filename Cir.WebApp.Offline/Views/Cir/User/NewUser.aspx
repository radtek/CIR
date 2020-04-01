<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Assign User with a role
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <% using (Html.BeginForm())
                   { %>
                <%: Html.AntiForgeryToken() %>

                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Assign Role</legend>


                            <div class="form-group">
                                <%: Html.Label("Enter Name/Email :", new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.TextBox("txtUserToSearch", "",  new { @class = "form-control", @maxlength = "15" })%>
                                    <%: Html.ValidationMessage("txtUserToSearch") %>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-9 col-lg-offset-3">
                                    <button id="btnUserSearch" type="button" class="btn btn-primary">Search</button>
                                </div>
                            </div>
                            <div class="form-group">
                                <%: Html.Label("Available Users", new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.DropDownList("UserList", Enumerable.Empty<SelectListItem>(), new { @class = "form-control", size = 8 })%>
                                </div>

                            </div>

                            <div class="form-group">
                                <%: Html.Label("Available Roles", new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.DropDownList("AppRoleList", Enumerable.Empty<SelectListItem>(), new { @class = "form-control" })%>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-9 col-lg-offset-3">
                                     <button id="btnAssign" type="button" class="btn btn-primary">Assign</button>
                                    <a href="/cir/assign-user" class="btn btn-default">Cancel</a>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>

                <%} %>
            </div>
        </div>
    </section>
</asp:Content>

