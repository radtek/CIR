var UserManagemnt = new function () {
    this.GetAppRoles = function (appUrl, appID) {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('AppRoles', {
                            method: 'GET'
                        }).done(function (response) {
                            var resp = response.result;
                            console.log(resp);
                            var AppRoles = resp;
                            $("#AppRoleList").empty();
                            $("#AppRoleList").append("<option value=''>Select a role</option>");
                            for (var i = 0; i < AppRoles.length; i++) {
                                $("#AppRoleList").append("<option value=" + AppRoles[i].id + ">" +
                                 AppRoles[i].displayName + "</option>");
                            }
                            if (AppRoles.length == 0) {
                                console.log("No Application Roles found!");
                            }
                            return resp;
                        }, function (error) {
                            console.log(error);
                        });
                    }
                }
            }
        });
    }

    this.GetUserAppRoles = function (userId, appUrl, appID) {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('UserRoles/' + encodeURIComponent(userId), {
                            method: 'GET'
                        }).done(function (response) {
                            var resp = response.result;
                            console.log(resp);
                            var AppRoles = resp;
                            if (AppRoles.length == 0) {
                                console.log("No Roles found!");
                            }
                            if (document.URL.toLowerCase().indexOf('unassign-user') > -1) {
                                $("#AppRoleList").empty();
                                for (var i = 0; i < AppRoles.length; i++) {
                                    $("#AppRoleList").append("<option value=" + AppRoles[i].id + ">" +
                                     AppRoles[i].displayName + "</option>");
                                }
                                $("#btnUnAssign").text("Un Assign");
                            }
                            else if (document.URL.toLowerCase().indexOf('assign-user') > -1) 
                            {
                                $('#AppRoleList option').prop("disabled", false)
                                for (var i = 0; i < AppRoles.length; i++) {
                                    $("#AppRoleList option[value='" + AppRoles[i].id + "']").prop('disabled', true)
                                }
                                $("#btnAssign").text("Assign");
                            }
                            return resp;
                        }, function (error) {
                            console.log(error);
                            $("#btnUnAssign").text("Un Assign");
                        });
                    }
                }
            }
        });
    }
    this.SearchUsers = function (keyword, appUrl, appID) {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        $("#UserList").empty();
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('Users/' + keyword, {
                            method: 'GET'//,
                            //parameters: { userSearchKeywrod: keyword }
                        }).done(function (response) {
                            var resp = response.result;
                            var Users = resp;
                            console.log(resp);
                            for (var i = 0; i < Users.length; i++) {
                                $("#UserList").append("<option value=" + Users[i].internalUPN + ">" +
                                 Users[i].extName + "</option>");
                            }
                            if (Users.length == 0) {
                                console.log("No users found");
                            }
                            $("#btnUserSearch").text("Search");
                            return resp;
                        }, function (error) {
                            console.log(error);
                            $("#btnUserSearch").text("Search");
                        });
                    }
                }
            }
        });
    }

    this.AssignUserRole = function (object, appUrl, appID) {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('UserRole', {
                            method: 'POST',
                            body: object
                        }).done(function (response) {
                            var resp = response.result;
                            console.log(resp);
                            if (resp) {
                                console.log("Role Assigned to User");
                                $("#UserList").empty();
                                $('#AppRoleList option:selected').prop("selected", false)
                                $('#AppRoleList option').prop("disabled", false)
                                $('txtUserToSearch').val('');
                                NotifyCirMessage("Assign Role : ", 'Role Assigned to User Successfully!', "success");
                            }
                            $("#btnAssign").text("Assign");
                            return resp;
                        }, function (error) {
                            console.log(error);
                            $("#btnAssign").text("Assign");
                            NotifyCirMessage('Assign Role : ', "User already have the selected role.", 'danger');
                        });
                    }
                }
            }
        });
    }

    this.UnAssignUserRole = function (object, appUrl, appID) {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('UserRole', {
                            method: 'DELETE',
                            body: object
                        }).done(function (response) {
                            var resp = response.result;
                            console.log(resp);
                            if (resp) {
                                console.log("Role Removed from User");
                                $("#UserList").empty();
                                $("#AppRoleList").empty();
                                $('txtUserToSearch').val('');
                                NotifyCirMessage("Un Assign Role : ", 'Role Removed from User Successfully!', "success");
                            }
                            $("#btnUnAssign").text("Un Assign");
                            return resp;
                        }, function (error) {
                            console.log(error);
                            $("#btnUnAssign").text("Un Assign");
                            NotifyCirMessage('Un Assign Role : ', "Unable to remove role. Error : " + error, 'danger');
                        });
                    }
                }
            }
        });
    }
};
$(document).ready(function () {

    if (Offline.state == "down")
        return;
    else {
        var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
    }

    $("#btnUserSearch").click(function () {

        var userToSearch = $("#txtUserToSearch").val();
        if (userToSearch.trim() == "") {
            console.log("Please provide name or email to search");
            return false;
        }
        $("#btnUserSearch").text("Please Wait..");
        UserManagemnt.SearchUsers(userToSearch, $('#MobAppURL').val(), $('#MobAppID').val());
    });

    setTimeout(function () {
        if (document.URL.toLowerCase().indexOf('assign-user') > -1) {
            if (document.URL.toLowerCase().indexOf('unassign-user') == -1) {
                UserManagemnt.GetAppRoles($('#MobAppURL').val(), $('#MobAppID').val());
            }
        }
    }, 300)

    $("#btnAssign").click(function () {
        var selectedUsers = $('#UserList option:selected');
        if (selectedUsers.length == 0) {

            //alert("Please select User(s) to assign a role!");
            //return false;
            CirAlert.alert('Please select User(s) to assign a role!', 'Cir App', null, 'error').done(function () {
            });
            return false;

        }
        var selectedRole = $('#AppRoleList option:selected');
        if (selectedRole.length == 0 || selectedRole.val() == "") {

            //  alert("Please select a role to assign!");
           // return false;
            CirAlert.alert('Please select a role to assign!', 'Cir App', null, 'error').done(function () {
                return false;
            });
        }
        $("#btnAssign").text("Please Wait..");
        var UserRolestring = '{ "UserId": "' + selectedUsers.val() + '", "AppRoleId": "' + selectedRole.val() + '" }';
        console.log(UserRolestring);
        var UserRole = jQuery.parseJSON(UserRolestring);
        UserManagemnt.AssignUserRole(UserRole, $('#MobAppURL').val(), $('#MobAppID').val());
    });

    $('#UserList').change(function () {
        var selectedUsers = $('#UserList option:selected');
        if (document.URL.toLowerCase().indexOf('unassign-user') > -1) {
            $("#AppRoleList").empty();
        }
        $("#btnUnAssign").text("Please Wait..");
        $("#btnAssign").text("Please Wait..");
        UserManagemnt.GetUserAppRoles(selectedUsers.val(), $('#MobAppURL').val(), $('#MobAppID').val());

    });

    $("#btnUnAssign").click(function () {
        var selectedUsers = $('#UserList option:selected');
        if (selectedUsers.length == 0) {

            //alert("Please select User(s) to assign a role!");
            //return false;
            CirAlert.alert('Please select User(s) to unassign a role!', 'Cir App', null, 'error').done(function () {
            });
            return false;
        }
        var selectedRole = $('#AppRoleList option:selected');
        if (selectedRole.length == 0) {

            //alert("Please select a role to unassign!");
            // return false;
            CirAlert.alert('Please select a role to unassign!', 'Cir App', null, 'error').done(function () {
                return false;
            });
        }
        $("#btnUnAssign").text("Please Wait..");
        var UserRolestring = '{ "UserId": "' + selectedUsers.val() + '", "AppRoleId": "' + selectedRole.val() + '" }';
        console.log(UserRolestring);
        var UserRole = jQuery.parseJSON(UserRolestring);
        UserManagemnt.UnAssignUserRole(UserRole, $('#MobAppURL').val(), $('#MobAppID').val());
    });
});