<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<Cir.WebApp.Offline.Models.Cir.Users.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add / Edit User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <% using (Html.BeginForm())
                   { %>
                <%: Html.AntiForgeryToken() %>
                <%: Html.HiddenFor(m => m.ID) %>

                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Save user</legend>

                            <% if (!Model.IsSuccess)
                               { %>
                            <div class="alert alert-danger" style="text-align:center;">
                                <strong>Error!</strong> <%= ViewData.ModelState["Name"].Errors[0].ErrorMessage %>
                            </div>
                            <% } %>

                            <div class="form-group">
                                <%: Html.LabelFor(m => m.Initials, new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.TextBoxFor(m => m.Initials, new { @class = "form-control", @maxlength = "15" })%>
                                    <%: Html.ValidationMessageFor(m => m.Initials) %>
                                </div>
                            </div>

                            <div class="form-group">
                                <%: Html.LabelFor(m => m.Username, new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.TextBoxFor(m => m.Username, new { @class = "form-control", @maxlength = "15" })%>
                                    <%: Html.ValidationMessageFor(m => m.Username) %>
                                </div>
                            </div>

                            <div class="form-group">
                                <%: Html.LabelFor(m => m.RoleID, new { @class="col-lg-3 control-label" })%>
                                <div class="col-lg-9">
                                    <%: Html.DropDownListFor(m => m.RoleID, new SelectList(Model.Roles, "RoleID", "RoleName"), new { @class = "form-coformntrol" , id = "ddlRole" })%>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-9 col-lg-offset-3">
                                    <input type="submit" class="btn btn-primary" value="Save" />
                                    <a href="/cir/Manage-Users" class="btn btn-default">Cancel</a>
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
