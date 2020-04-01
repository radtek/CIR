<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<Cir.WebApp.Offline.Models.Cir.Users.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User And Permissions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="col-xs-12">
            <div class="well well-White">
                <form name="UserList">
                    <div class="bs-example form-horizontal">
                        <div class="form-group">
                            <div class="col-xs-8">
                                Role
                            </div>
                            <div class="col-xs-9">
                                <%: Html.DropDownListFor(m => m.RoleID, new SelectList(Model.Roles, "RoleID", "RoleName"), new { @class = "form-coformntrol" , id = "ddlRole" })%>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-8" style="padding-top: 14px;">
                        </div>
                        <div class="col-xs-4" style="text-align: right;">
                            <a href="/cir/save-user" class="btn btn-primary">Add New User</a>
                        </div>
                    </div>
                    <br />
                    <br />

                </form>
                <div class="table-responsive">
                    <table class="table table-bordered table-striped dataTable">
                        <thead>
                            <tr>
                                <td>Initials</td>
                                <td>Name</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            <% if (Model.UserList.Count > 0)
                               {
                                   foreach (var item in Model.UserList)
                                   { %>
                            <tr>
                                <td><%= item.Initials %></td>
                                <td><%= item.UserName %></td>
                                <td><a href="/cir/save-user?id=<%= item.Id %>">Edit</a> </td>
                            </tr>
                            <% }
                               }
                               else
                               { %>
                            <tr>
                                <td colspan="3">No user exists</td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <script>
            $(document).ready(function () {
                $("#ddlRole").change(function () {
                    var selectedID = $(this).val();
                    window.location.href = '/cir/Manage-Users?PermissionLevel=' + selectedID;
                });
            });
        </script>
    </section>
</asp:Content>
