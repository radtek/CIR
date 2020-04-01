<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Group
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/bootstrap-tags.min.js"></script>
    <script src="../Js/bootstrap-tagsBrand.min.js"></script>
    <style type="text/css">
        table.dataTable th {
            background-color: #0072BB !important;
            font-weight: bold;
            color: #ffffff;
        }

        table.dataTable thead {
            background-color: #0072BB !important;
            font-weight: bold;
            color: #ffffff;
        }
        /*Visitor = -1,
		Viewer = 0,
		Editor = 1,
		Member = 2,
        BIRCreator = 4,
		Administrator = 5
        ContractorTurbineTechnicians
        TurbineTechnicians
            */
        .class_Administrator {
            background-color: #064369;
        }

        .class_BIRCreator {
            background-color: #115f90;
        }
        .class_GIRCreators {
            background-color: #115f90;
        }
         .class_GIRCreator {
            background-color: #115f90;
        }

         .class_GBXIRCreator {
            background-color: #115f90;
        }
         .class_GBXIRCreators {
            background-color: #115f90;
        }

        .class_Owner {
            background-color: #34739b;
        }

        .class_Member {
            background-color: #518fb6;
        }

        .class_Editor {
            background-color: #1d88cc;
        }

        .class_ContractorTurbineTechnicians {
            background-color: #3f9dd9;
        }

        .class_TurbineTechnicians {
            background-color: #77bbe6;
        }

        .class_Viewer {
            background-color: #69baed;
        }

        .class_Visitor {
            background-color: #87cbf6;
        }

        .rowCenter {
            text-align: center;
        }

        .well {
            padding-bottom: 6px;
            background-image: none;
            background-color: #ffffff;
        }

        .btn-extrasm {
            height: 26px;
        }

        .bs-tags .tag-badge {
            margin-right: 5px;
            font-weight: 100;
            font-size: 14px;
            line-height: 20px;
        }

        .badge-info-admin {
            background-color: #0080FF;
            color: #ffffff;
        }

        .bs-tags .tag-icon {
            margin-left: 5px;
            margin-right: -3px;
        }

        .bs-tags .tag-badge a.tag-link {
            color: #ffffff;
            text-decoration: underline;
        }

        .tag-add {
            margin-bottom: 20px;
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

        .icon-plus-sign {
            background-position: 0 -96px;
        }

        .icon-info-sign {
            background-position: -120px -96px;
        }

        .icon-remove-sign {
            background-position: -48px -96px;
        }

        .icon-clock-sign {
            background-position: -48px -25px;
        }
         .icon-search-sign {
            background-position: -48px -0px;
        }

        /*span > button.btn {
            height: 26px;
        }*/

        .tooltip-inner {
            max-width: none;
            white-space: nowrap;
        }

        .vcenter {
            white-space: nowrap;
        }

            .vcenter > * {
                white-space: normal;
            }

            .vcenter:before,
            .vcenter > * {
                display: inline-block;
                vertical-align: middle;
            }

            .vcenter:before {
                content: "";
                height: 100%;
            }


            .vcenter > * {
                word-spacing: normal;
            }
    </style>
    <section class="content">
        <div class="row">
            <div class="col-sm-12">

                <div class="well well-White" style="padding-top: 25px">
                    <div class="row">
                        <div style="position: absolute; margin-top: -20px; z-index: 1000">

                            <span style="margin-left: 28px">
                                 <input name="optSearchType" id="optSearchType2" value="2" type="radio" checked title="Search by Initials might take long depending on number of users." /><span title="Search by Initials might take long.">Search by Initials</span>
                                <input name="optSearchType" id="optSearchType1" value="1" type="radio"  title="Search by Exact Email will search faster." /><span title="Search by Exact Email will search faster."> Search by Email</span>
                                  <input name="optSearchType" id="optSearchType3" value="3" type="radio" checked="checked"  title="Manage Active Directory User Group." /><span title="Manage Active Directory User Group."> Manage Group</span>
                             
                            </span>
                        </div>

                        <div class="col-sm-4">
                            <div class="col-sm-9 form-group">
                                <input type="text" id="txtGroupToSearch" class="form-control" data-toggle="tooltip"
                                    data-placement="top" title="Enter Group name to Search.." maxlength="50" placeholder="Enter Group name to Search.." />

                            </div>
                            <div class="col-sm-3 form-group">
                                <button id="btnGroupToSearch" type="button" class="btn btn-primary"><i class="icon-search-sign"></i>&nbsp;Search</button>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="col-sm-11 form-group">
                                <select id="AppRoleList" class="form-control" data-fieldtype="select">
                                </select>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="col-sm-11 form-group">
                                <select id="AppBrandList" class="form-control" data-fieldtype="select">
                                </select>
                            </div>
                        </div>

                        <div class="col-sm-4" id="divAddRole" style="display:none">
                            <div class="col-sm-8 form-group">
                                <input type="text" id="txtGroupToAdd" class="form-control" data-toggle="tooltip"
                                    data-placement="top" title="Enter Group name to Add.." maxlength="50" placeholder="Enter Group name to Add.." />
                            </div>
                            <div class="col-sm-4 text-right form-group">
                                <button id="btnAddRole" type="button" class="btn btn-primary">&nbsp;Add</button>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive" id="groupListDiv" style="display: none">
                        <table id="groupList" class="display compact">
                            <thead>
                                <tr>
                                    <td nowrap>Group Name</td>
                                    <td>Email</td>
                                    <td style="" align="left">Roles <span width="10px" style="cursor: pointer"><i class="icon-info-sign icon-info-sign-roles" style="" title="Click here for more information on roles"></i></span></td>
                                    <td style="text-align: center" nowrap>Add Role</td>
                                    <td style="text-align: center">Remove Role</td>
                                    <td>Brands</td>
                                    <td style="text-align: center" nowrap>Add Brand</td>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script type="text/javascript">

        var _brands = [];
        var _groupGrid = null;
        var _Data = [];
        var _SearchType = 2;
        var eObj = {};
        var eBrandObj = {};
        var delObj = {};
        var _AppRoles = [];
        function _sortAppRoles(r) {
            var roles = []
            $.each(r, function (i, x) {
                var order = 1;
                if (x.value == "Administrator") order = 1;
                if (x.value == "BIRCreator") order = 2;
                if (x.value == "Member") order = 3;
                if (x.value == "Editor") order = 4;
                if (x.value == "ContractorTurbineTechnicians") order = 5;
                if (x.value == "TurbineTechnicians") order = 6;
                if (x.value == "Viewer") order = 7;
                if (x.value == "Visitor") order = 8;
                if (x.value == "GIRCreator") order = 9;
                if (x.value == "GBXIRCreator") order = 9;
                // FilteredfieldsData.sort(SortByTableName);

                roles.push({ "id": x.id, "displayName": x.displayName, "value": x.value, "order": order, "description": x.description })
            })
            return roles;
        }

        function SortByColumnOrder(x, y) {
            return ((x.order == y.order) ? 0 : ((parseInt(x.order) > parseInt(y.order)) ? 1 : -1));
        }

        $(document).ready(function () {

            //Radio Click
            $("#optSearchType1").next().click(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                _SearchType = 1;
                window.location.href = '/cir/manage-user#type=' + _SearchType;
            });
            $("#optSearchType2").next().click(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                _SearchType = 2;
                window.location.href = '/cir/manage-user#type=' + _SearchType;
            });

            //Load App Roles on Page Load
            $("#AppRoleList").empty();
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("AppRoles", "GET", "").done(function (data) {
                waitingDialog.hide();
                $("#AppRoleList").empty();
                $("#AppRoleList").append("<option value=0>--Select Role--</option>");
                _AppRole = data;
                var r = _sortAppRoles(data);
                r.sort(SortByColumnOrder);
                $.each(r, function (i, item) {
                    $("#AppRoleList").append("<option value=" + item.id + ">" +
                        item.displayName + "</option>");
                });

                if (data.length == 0) {
                    NotifyCirMessage('', 'No Application Roles found!', 'info');
                }
            })
                .fail(function () {
                    waitingDialog.hide();
                    NotifyCirMessage('Error: ', 'Error occurred while getting App Roles', 'danger');
                });

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallSyncApi("BrandData", "GET", "").done(function (data) {
                waitingDialog.hide();
                $("#AppBrandList").empty();
                $("#AppBrandList").append("<option value=0>--Select Brand--</option>");

                _brands = data.result;
                var r = data.result;

                $.each(r, function (i, item) {
                    $("#AppBrandList").append("<option value=" + item.id + ">" +
                        item.name + "</option>");
                });

                if (data.result.length == 0) {
                    NotifyCirMessage('', 'No Application Brands found!', 'info');
                }
            })
                .fail(function () {
                    waitingDialog.hide();
                    NotifyCirMessage('Error: ', 'Error occurred while getting App Brands', 'danger');
                });

            //Initialize Grid
            _groupGrid = $('#groupList').dataTable({
                "searching": false,
                responsive: true,
                "columnDefs": [
                ],
                "aoColumns": [
                    null,
                    { "bSortable": false },
                    null,
                    null,
                    { "bSortable": false },
                    { "bSortable": false, "width": "80px" },
                    { "bSortable": false, "width": "80px" },
                ],
                "order": [[0, "asc"]],
                "language": {
                    "paginate": {
                        "previous": "&laquo;",
                        "next": "&raquo;"
                    }
                }
            });

            //OnChange AppRole DropDown 
            $("#AppRoleList").change(function () {
                var roleId = $(this).val();
                if (roleId == 0) {
                    emptyGroupGrid();
                    return;
                }
                $("#divAddRole").show();
                $("#btnAddRole").text("Add");// + $("#AppRoleList :selected").text());
                $("#txtgroupToSearch").val("");
                $("#txtgroupToAdd").val("");

                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                CallClientApi("GetGroupsAssignedRoles/" + roleId, "GET", "").done(function (data) {
                    waitingDialog.hide();
                    if (data.length == 0) {
                        _groupGrid.fnClearTable();
                        waitingDialog.hide();
                        NotifyCirMessage('', 'No Groups found assigned in <b>' + $("#AppRoleList :selected").text() + '</b> role!', 'info');
                    }
                    else {
                        _Data = data;
                        loadGroupGrid();
                    }
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occurred while getting Groups!', 'danger');
                    });
            });

            $("#btnGroupToSearch").click(function () {

                var groupToSearch = $("#txtGroupToSearch").val();
                if (groupToSearch.trim() == "") {
                    NotifyCirMessage('', 'Please provide group name to search', 'warning');
                    return false;
                }
                if (groupToSearch.length <= 1) {
                    NotifyCirMessage('', 'Number of characters in group name must be more than one', 'warning');
                    return false;
                }
                $("#AppRoleList").val("0");
                $("#divAddRole").hide();
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                //CallClientApi("GetSearchGroup/" + groupToSearch + "/" + _SearchType, "GET", "").done(function (data) {
                CallClientApi("GetSearchGroup/" + groupToSearch, "GET", "").done(function (data) {
                    waitingDialog.hide();
                    if (data.length == 0) {
                        NotifyCirMessage('', 'The group name <b>"' + groupToSearch + '"</b> cannot be found!', 'warning');
                        emptyGroupGrid();
                    }
                    else {
                        emptyGroupGrid();
                        _Data = data;
                        loadGroupGrid();
                    }
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occurred while searching Groups!', 'danger');
                    });
            });

            $("#btnAddRole").click(function () {

                var groupToAdd = $("#txtGroupToAdd").val();

                if (groupToAdd.trim() == "") {
                    NotifyCirMessage('', 'Please provide Group to add!', 'warning');
                    return false;
                }

                var roleId = $("#AppRoleList").val();

                if (roleId == "0") {
                    NotifyCirMessage('', 'Please select role to assign!', 'warning');
                    return false;
                }

                var oldText = $("#btnAddRole").text();
                $("#txtGroupToSearch").val("");
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

                CallClientApi("GetAssignRoleToGroup/" + groupToAdd + "/" + roleId + "/0/" + roleId, "GET", "").done(function (data) {
                    waitingDialog.hide();

                    if (data.status == -1) {
                        NotifyCirMessage('', data.message, 'warning');
                    }
                    else {
                        updateRow(data);
                        NotifyCirMessage('', "<b>" + groupToAdd + "</b> assigned to <b>" + $("#AppRoleList :selected").text() + "</b> role!", 'info');
                    }

                    $("#txtGroupToAdd").val("");
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error Assigning role!', 'danger');
                    });
            });

            $('#txtGroupToSearch').keyup(function (e) {
                if (e.keyCode == 13) {
                    e.stopPropagation();
                    $("#btnGroupToSearch").trigger("click");
                }
            });

            $('#txtGroupToAdd').keyup(function (e) {
                if (e.keyCode == 13) {
                    e.stopPropagation();
                    $("#btnAddRole").trigger("click");
                }
            });

            //Empty GroupGrid
            function emptyGroupGrid() {
                _groupGrid.fnClearTable();
                $("#divAddRole").hide();
                $("#groupListDiv").hide();
            }

            $(".icon-info-sign-roles").click(function () {
                $('#RoleInfoModal').modal('show');
            });

            $('#groupList').on('click', 'tr', function () {
                _RowIndex = this.rowIndex;
            });
        });

        function loadGroupGrid() {
            _groupGrid.fnClearTable();

            $.each(_Data, function (index, item) {
                var roles = '';
                var brands = '';
                var suggestions = [];
                var values = [];
                var brandValues = [];
                var can_add = true;
                var no_roles = true;
                var availRoles = [];
                var availBrands = [];
                var r = _sortAppRoles(_AppRole);
                r.sort(SortByColumnOrder);
                var userBrands = [];

                CallSyncApi("BrandData?groupName=" + encodeURIComponent(item.groupName), "GET", "").done(function (userGroupBrand) {

                    //assign available data to add brand dropdown button for this row
                    userBrands = userGroupBrand.result;

                    $.each(r, function (yindex, yitem) {
                        var found = 0;
                        $.each(item.roleList, function (zindex, zitem) {
                            if (yitem.id == zitem.id) {
                                found = 1;
                            }
                        });
                        if (found == 0) {
                            availRoles.push({ "id": yitem.id, "text": yitem.displayName, "uid": item.objectID, "order": yitem.order });
                        }
                    });

                    roles = roles + '' + '<div id="bs-tags' + index + '" class="bs-tags vcenter"></div>';

                    $.each(_brands, function (yindex, yitem) {
                        var found = 0;
                        $.each(userBrands, function (zindex, zitem) {
                            if (yitem.id == zitem.id) {
                                found = 1;
                            }
                        });
                        if (found == 0) {
                            availBrands.push({ "id": yitem.id, "text": yitem.name, "uid": item.groupName, "order": yitem.order });
                        }
                    });

                    brands = brands + '' + '<div id="br-tags' + index + '" class="br-tags vcenter"></div>';

                    waitingDialog.hide();

                    if (userGroupBrand.result.length == 0) {
                        NotifyCirMessage('', 'No Application Brands found!', 'info');
                    }

                    $.each(userBrands, function (xindex, xitem) {
                        brandValues.push({ "id": xitem.id, "text": xitem.name, "title": xitem.name, "value": xitem.name, "groupName": item.groupName });
                    });

                    var roleList = _sortAppRoles(item.roleList);
                    roleList.sort(SortByColumnOrder);

                    if (roleList.length > 0) {

                        $.each(roleList, function (xindex, xitem) {
                            values.push({ "id": xitem.id + ":" + item.objectID, "text": xitem.displayName, "title": xitem.description, "value": xitem.value });
                        });

                        if (roleList == 8) {//8 Roles Max
                            can_add = false;
                        }
                        no_roles = false;
                    }

                    //  item.lastLogin,
                    roles = roles + "";
                    var addstring = "";
                    if (can_add == true) {
                        addstring = '<div class="btn-group">' +
                            '<button type="button" class="btn btn-default btn-xs">Add Role</button>' +
                            '<button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                            '<span class="caret"></span>' +
                            '<span class="sr-only">Add Role</span>' +
                            ' </button>' +
                            '<ul class="dropdown-menu">';

                        var l = "";
                        availRoles.sort(SortByColumnOrder);
                        $.each(availRoles, function (i, t) {
                            l = l + '<li><a href=javascript:AssignThisRole("' + t.uid + '","' + t.id + '");>' + t.text + '</a></li>';
                        });
                        addstring = addstring + l + '</ul></div>';
                    }
                    var actionStr = "";
                    var delString = (no_roles == true) ? '' : '<button class="btn btn-default btn-xs"  title="Unassigned all roles from ' + item.groupName + '" onclick="DeleteRole(\'' + item.objectID + '\',\'' + item.groupName + '\');">Remove</button>';
                    actionStr = addstring;

                    var addBrandstring = "";

                    addBrandstring = '<div class="btn-group">' +
                        '<button type="button" class="btn btn-default btn-xs">Add Brand</button>' +
                        '<button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                        '<span class="caret"></span>' +
                        '<span class="sr-only">Add Brand</span>' +
                        ' </button>' +
                        '<ul class="dropdown-menu">';

                    var lBrand = "";
                    availBrands.sort(SortByColumnOrder);

                    $.each(availBrands, function (i, t) {
                        lBrand = lBrand + '<li><a href=javascript:AssignThisBrand("' + item.groupName + '","' + t.id + '");>' + t.text + '</a></li>';
                    });

                    addBrandstring = addBrandstring + lBrand + '</ul></div>';
                    var actionBrandStr = "";
                    actionBrandStr = addBrandstring;

                    _groupGrid.fnAddData([
                        item.groupName,
                        ((item.emailAddress == null || item.emailAddress == "") ? 'Not available' : item.emailAddress),
                        roles,
                        actionStr,
                        ((roles == "") ? '' : delString),
                        brands,
                        actionBrandStr
                    ]);

                    $('#bs-tags' + index).tags({
                        suggestions: "", can_add: false,
                        values: values
                    });

                    $('#br-tags' + index).brandTags({
                        suggestions: "", can_add: false,
                        values: brandValues
                    });
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occurred while getting App Brands', 'danger');
                    });
            });

            // if (flag == true) {
            $("#groupListDiv").show();
            //  }
        }

        function DeleteRole(uid, uname) {
            if (uid.trim() == "") {
                NotifyCirMessage('Error: ', 'Please select a Group to Unassign Role!', 'danger');
                return false;
            }
            CirAlert.confirm('Do you wish to unassign all roles from <b>"' + uname + '"</b>?<br> <b>"' + uname + '"</b> will no more be able to access this application!', 'Cir App', 'Yes', 'No', 'question').done(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                CallClientApi("GetUnAssignAllRoleToGroup/" + uid + "/" + uname + "/" + $("#AppRoleList").val(), "GET", "").done(function (data) {
                    waitingDialog.hide();
                    NotifyCirMessage('', 'All roles unassigned from the selected group', 'info');
                    updateRow(data);

                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occured while unassigning role', 'danger');
                    });
            });
        }

        function AssignThisBrand(groupName, brandId) {
            var roleIdToDisplay = $("#AppBrandList").val();
            var txtUserToSearch = $("#txtUserToSearch").val();
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            CallSyncApi("BrandData/AssignBrandToGroup?groupId=" + encodeURIComponent(groupName) + "&brandId=" + brandId, "GET", "").done(function (data) {
                waitingDialog.hide();
                updateRow(data);
            })
                .fail(function () {
                    waitingDialog.hide();
                    NotifyCirMessage('Error: ', 'Error occured while assigning brand', 'danger');
                });
        }

        function DeleteThisBrand() {
            var ids = eBrandObj.v.id;
            var brandId = ids.split(":")[0];
            var groupName = eBrandObj.v.groupName;

            //message body changed for Sprint 4 bug id 83758
            //comment copied from original source at DeleteThisRole function in this file
            CirAlert.confirm('Do you wish to remove this brand from the selected user?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                CallSyncApi("BrandData/UnassignBrandFromUserGroup?userGroupId=" + encodeURIComponent(groupName) + "&brandId=" + brandId, "GET", "").done(function (data) {
                    waitingDialog.hide();
                    NotifyCirMessage('', 'Brand unassigned from the selected user!', 'info');
                    updateRow(data);
                    eBrandObj.t.removeTag(eBrandObj.el);
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occured while unassigning brand', 'danger');
                    });
            });
        }

        function AssignThisRole(uid, roleid) {
            var roleIdToDisplay = $("#AppRoleList").val();
            var txtGroupToSearch = $("#txtGroupToSearch").val();
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            CallClientApi("GetAssignRoleToGroup/0/" + roleid + "/" + uid + "/" + roleIdToDisplay, "GET", "").done(function (data) {
                waitingDialog.hide();
                updateRow(data);
            })
                .fail(function () {
                    waitingDialog.hide();
                    NotifyCirMessage('Error: ', 'Error occured while assigning role', 'danger');
                });
        }

        function DeleteThisRole() {
            var ids = eObj.v.id;
            var roleid = ids.split(":")[0];
            var uid = ids.split(":")[1];
            var txtGroupToSearch = "";
            var roleIdToDisplay = $("#AppRoleList").val();
            if ($("#AppRoleList").val() == "0") {
                txtGroupToSearch = $("#txtGroupToSearch").val();
            }
            //message body changed for Sprint 4 bug id 83758
            CirAlert.confirm('Do you wish to remove this role from the selected group?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                CallClientApi("GetUnAssignRoleToGroup/" + uid + "/" + roleid + "/" + roleIdToDisplay, "GET", "").done(function (data) {
                    waitingDialog.hide();
                    NotifyCirMessage('', 'Role unassigned from the selected group!', 'info');
                    updateRow(data);
                    eObj.t.removeTag(eObj.el);
                })
                    .fail(function () {
                        waitingDialog.hide();
                        NotifyCirMessage('Error: ', 'Error occured while unassigning role', 'danger');
                    });
            });
        }

        function GetLastSeen(upn, uid) {
            $("#divLastSeen_" + uid).text("Fetching..");

            CallClientApi("GroupLoginDetailsFor/" + encodeURIComponent(upn), "GET", "").done(function (data) {
                if (data == null || data == "")
                    $("#divLastSeen_" + uid).text("Not known");
                else
                    $("#divLastSeen_" + uid).text(data.lastOnlineTime);

            }).fail(function (error) {
                $("#divLastSeen_" + uid).text("Not known");
            });
        }

        function updateRow(data) {
            var newlist;
            if (data.roleList != null) {
                if (data.roleList.length == 0) {
                    newlist = $.grep(_Data, function (i) { return (i.objectID != data.objectID) });
                    _Data = newlist;
                }
                else {
                    var found = 0;
                    var newlist;
                    $.each(_Data, function (i, x) {
                        if (x.objectID == data.objectID) {
                            _Data[i] = data;
                            found = 1;
                            return false;
                        }
                    });
                    if (found == 0) {
                        _Data.push(data);
                    }
                }
            }
            else {
                newlist = $.grep(_Data, function (i) { return (i.objectID != data.objectID) });
                _Data = newlist;
            }

            loadGroupGrid();
        }
    </script>

    <div id='RoleInfoModal' class='modal' tabindex='-1' data-backdrop='static' data-keyboard='true' role='dialog'>
        <div class='modal-dialog'>
            <div class='modal-content'>
                <div class='modal-header'>
                    <h5 class='modal-title'><b>System Roles</b></h5>
                </div>
                <div class='modal-body'>
                    <table cellpadding="3">
                        <tr>
                            <td>Administrator</td>
                            <td>Administrators have access to full functionalities of the application.</td>
                        </tr>
                        <tr>
                            <td>BIRCreator</td>
                            <td>BIRCreator can create BIRs</td>
                        </tr>
                        <tr>
                            <td>GIRCreator</td>
                            <td>GIRCreator can create Generator Reports (GIRs)</td>
                        </tr>
                        <tr>
                             <td>GBXIRCreator</td>
                            <td>GBXIRCreator can create Generator Reports (GBXIRs)</td>
                        </tr>
                        <tr>
                            <td>Member</td>
                            <td>Member</td>
                        </tr>
                        <tr>
                            <td>Editor</td>
                            <td>Editor</td>
                        </tr>
                        <tr>
                            <td>Turbine Technician</td>
                            <td>Turbine Technician</td>
                        </tr>
                        <tr>
                            <td>Contractor Turbine Technician</td>
                            <td>Contractor Turbine Technician</td>
                        </tr>
                        <tr>
                            <td>Viewer</td>
                            <td>Groups who can only view the CIRS</td>
                        </tr>
                        <tr>
                            <td>Visitor</td>
                            <td>Groups who can only view the CIRS</td>
                        </tr>
                    </table>
                </div>
                <div class='modal-footer'>
                    <button type='button' class='btn btn-default' data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>