var CirSyncErrors = new function () {

    this.loadSyncErrorsGrid = function () {

        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

        //var UserInitial = $('#txtUserInitial').val();

        var CirData = {};
        CirData.UserInitial = $('#txtUserInitial').val();
        CirData.Status = $('#ddlLogType').val();
        CirData.CirDataLocalID = ($('#txtCIRId').val() == "" ? 0 : $('#txtCIRId').val());

        CallClientApi("GetCirSyncErrorData", "POST", CirData).done(function (result) {
            cirdata = [];
            var StausIcon;
            var ActionIcons;
            var IsSubmitted;
            var tempLastUpdatedDate;
            var LastUpdatedDate;

            var tblDraftSyncError = $('#DraftSyncErrorGrid').DataTable({
                destroy: true,
                order: [[1, "desc"]],
                searching: true,
                paging: true,
                info: false
            });
            tblDraftSyncError.clear().draw();

            if (result) {
                if (result.length > 0) {

                    $.each(result, function (i, item) {
                        cirdata = JSON.parse(item.cirData);

                        var tempLastUpdatedDate = new Date(item.updatedAt);
                        var day = tempLastUpdatedDate.getDate();
                        var month = tempLastUpdatedDate.getMonth();
                        month += 1;  // JavaScript months are 0-11
                        var year = tempLastUpdatedDate.getFullYear();
                        LastUpdatedDate = day + '-' + month + '-' + year + ' ' + tempLastUpdatedDate.getHours() + ':' + tempLastUpdatedDate.getMinutes()

                        stUpdatedDate = tempLastUpdatedDate + " " + item.updatedAt.toTimeString().substring(0, 5)
                        if (item.status == -1) {
                            StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' + item.statusMessage + '" value="' + item.statusDetailMessage + '" class="fa fa-exclamation-triangle fa-lg CirErrorDraftStatus" style="color:#cc0000;cursor:pointer;"></i></a>' + ' - Error';
                            ActionIcons = '<a title="Edit CIR" id="' + item.id + '" value= "' + item.cirDataLocalID + '" href="javascript:void(0);" class="EditCIRByAdmin"><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;'
                                            + '<a title="Delete/Unlock CIR" id="' + item.id + '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History. This will also Unlock the CIR and make it available to other users." class="btn-delete DeleteUnlockCIR_Error"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                                            + '<a title="Reassign CIR" id="' + item.id + '" value= "' + item.cirDataLocalID + '" href="javascript:void(0);" class="btn-reassign ReassignCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                            IsSubmitted = "Yes"
                        }
                        else {
                            StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' + item.statusMessage + '" value="' + item.statusDetailMessage + '" class="fa fa-exclamation-triangle fa-lg CirErrorDraftStatus" style="color:#FF8C00;cursor:pointer;"></i></a>' + ' - Draft';
                            ActionIcons = '<a title="Edit CIR" id="' + item.id + '" value= "' + item.cirDataLocalID + '" href="javascript:void(0);" class="EditCIRByAdmin"><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;'
                                          + '<a title="Delete/Unlock CIR" id="' + item.id + '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History. This will also Unlock the CIR and make it available to other users." class="btn-delete DeleteUnlockCIR_Draft"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                                          + '<a title="Reassign CIR" id="' + item.id + '" value= "' + item.cirDataLocalID + '" href="javascript:void(0);" class="btn-reassign ReassignCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                            IsSubmitted = "No"
                        }
                        tblDraftSyncError.row.add([ActionIcons, StausIcon, (item.cirDataLocalID == 0 ? 'New <i style="color:#00cc00;" class="fa fa-exclamation-circle fa-lg" title="New CIR"></i>' : item.cirDataLocalID), item.userInitial, cirdata.componentInspectionReportName, cirdata.cimCaseNumber, cirdata.turbineNumber, cirdata.country, cirdata.siteName, LastUpdatedDate, IsSubmitted]).draw(false);
                    });

                    waitingDialog.hide();

                }
                else {
                    waitingDialog.hide();
                    NotifyCirMessage('No data found : ', 'No records found for user [' + CirData.UserInitial + ']', 'info');
                }
                CirSyncErrors.CheckNumberOfRecords();
            }
        }).fail(function (error) {
            NotifyCirMessage('Error : ', 'Failed to retrive data!', 'danger');
        });
    };

    this.CheckNumberOfRecords = function () {
        if (jQuery('table#DraftSyncErrorGrid td').hasClass('dataTables_empty')) {
            $('.dataTables_paginate').hide();
            $('.dataTables_length').hide();
            $('.dataTables_info').hide();
            $('.dataTables_filter').hide();
        }
    }

    this.showDetails = function (strMsg) {
        $("#StatusDetailsModal").find('.modal-title').text("Status details");
        $("#StatusDetailsModal").find('#strErrorMsg').html(strMsg);
        $("#StatusDetailsModal").modal('show');
    }

    this.ReassignCIRModal = function (id, cirDataLocalID) {
        $("#UserList").empty();
        $("#txtUserToSearch").val('');
        $("#lblUserToSearch_Validation").empty();
        $("#ReassignCIRModal").find('.modal-title').text("Assign CIR");
        //$('input[name="testing"]').val(theValue);
        $("#CIRId").val(id);
        $("#CirDataLocalID").val(cirDataLocalID);


        $("#ReassignCIRModal").modal('show');
    }

    this.stringToDate = function (_date, _format, _delimiter) {
        var formatLowerCase = _format.toLowerCase();
        var formatItems = formatLowerCase.split(_delimiter);
        var dateItems = _date.split(_delimiter);
        var monthIndex = formatItems.indexOf("mm");
        var dayIndex = formatItems.indexOf("dd");
        var yearIndex = formatItems.indexOf("yyyy");
        var month = parseInt(dateItems[monthIndex]);
        month -= 1;
        var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
        return formatedDate;
    }

    this.drawDataGrid = function () {
        var tblSystemLogGrid = $('#DraftSyncErrorGrid').DataTable({
            destroy: true,
            order: [[1, "desc"]],
            searching: true,
            paging: true,
            info: false
        });
        tblSystemLogGrid.clear().draw();

        CirSyncErrors.CheckNumberOfRecords();
    }

    this.DeleteUserCirData = function (id) {
        var deferredObject = $.Deferred();
        CallClientApi("UserCirData/" + id, "DELETE", '', true).done(function (result) {

            NotifyCirMessage('Success : ', 'CIR deleted successfully !', 'info');
            deferredObject.resolve(true);

        }).fail(function (error) {
            NotifyCirMessage('Error : ', 'Failed to delete CIR !', 'danger');
            deferredObject.reject();
        });
        return deferredObject.promise();
    }

    this.EditUserCirData = function (id) {
        CallClientApi("EditByAdminUserCirData/" + id, "POST", '').done(function (result) {
            waitingDialog.hide();
            if (result) {
                // <i class="fa fa-spinner fa-spin">
                CirAlert.confirm('This CIR has been moved to your Local History page & will be avilable after the next sync. Do you want to go to "My Local History" page now ?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    window.location.href = '/cir/local-history';
                });
            }
            else {
                CirAlert.alert('Error while making the CIR available for edit !', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }

        }).fail(function (error) {
            return false;
        });
    }

    this.SearchUsers = function (keyword, appUrl, appID) {
        //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        $("#btnUserSearch_AssignCIR").text("Please Wait..");
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        $("#UserList").empty();
        $("#lblUserToSearch_Validation").empty();
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('GetAssignedUser/' + keyword, {
                            method: 'GET'//,
                            //parameters: { userSearchKeywrod: keyword }
                        }).done(function (response) {
                            var resp = response.result;
                            var Users = resp;
                            console.log(resp);
                            
                            
                            if (Users.length == 0) {
                                console.log("No users found");
                                $("#lblUserToSearch_Validation").text("User is not valid or does not exist");
                            }
                            else {
                                for (var i = 0; i < Users.length; i++) {
                                    $("#UserList").append("<option value=" + Users[i].internalUPN + ">" +
                                     Users[i].extName + "</option>");
                                }
                            }
                            $("#btnUserSearch_AssignCIR").text("Search");
                            return resp;
                        }, function (error) {
                            NotifyCirMessage(' ', "You do not have valid permission to search User", 'danger');
                            $("#btnUserSearch_AssignCIR").text("Search");
                        });
                    }
                }
            }
        });
        waitingDialog.hide();
    }

    this.AssignCIR = function (id, cirDataLocalID, userInitial) {
        var patch = {};
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        patch.cirDataLocalID = cirDataLocalID;
        patch.userInitial = userInitial;
        patch.remarks = "This CIR is assigned to you by Admin";
        CallClientApi("UserCirData/" + id, "PATCH", patch).done(function (result) {
            if (result.id == id) {
                //NotifyCirMessage('Success : ', 'CIR successfully assigned to [' + userInitial + '] !', 'info');
                waitingDialog.hide();
                CirAlert.alert('CIR successfully assigned to [' + userInitial + '] !', 'Cir App', null, 'info').done(function () {
                    $("#ReassignCIRModal").modal('hide');
                    CirSyncErrors.loadSyncErrorsGrid();
                });
            }
        }).fail(function (error) {
            waitingDialog.hide();
            //NotifyCirMessage('Error : ', 'Failed to assign CIR !', 'danger');
            CirAlert.alert('Failed to assign CIR !', 'Cir App', null, 'error').done(function () {
                return false;
            });
        });
    }

    this.AssignCIRToAdmin = function (id, cirDataLocalID) {
        var patch = {};

        patch.cirDataLocalID = cirDataLocalID;
        patch.remarks = "This CIR is taken over by you";
        CallClientApi("AssignUserCirDataToAdmin/" + id, "POST", patch).done(function (result) {
            waitingDialog.hide();
            if (result.id == id) {
                
                CirAlert.confirm('This CIR has been moved to your Local History page & will be avilable after the next sync. Do you want to go to "My Local History" page now ?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    window.location.href = '/cir/local-history';
                }).fail(function (e) {
                    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                    CirSyncErrors.loadSyncErrorsGrid();
                    waitingDialog.hide();
                });
            }
            else {
                CirAlert.alert('Error while making the CIR available for edit !', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
        }).fail(function (error) {
            //NotifyCirMessage('Error : ', 'Failed to assign CIR !', 'danger');
            CirAlert.alert('Failed to make the CIR available for edit !', 'Cir App', null, 'error').done(function () {
                return false;
            });
        });
    }

    //this.CirProcess = function (LockedUserName) {
    //    var cirDataDetail = {
    //        cirDataId: key,
    //        cirId: "",
    //        cirState: state,
    //        filename: "",
    //        componentType: "",
    //        cIMCaseNumber: "",
    //        reportType: "",
    //        turbineType: "",
    //        turbineNumber: "",
    //        progress: 8,
    //        modifiedBy: LockedUserName, //CurrentUserInfo.Name,
    //        comment: "",
    //        locked: 1,
    //        lockedBy: LockedUserName
    //    }

    //    CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
    //        var error = result.error;
    //        var msg = result.message;
    //        if (error == 1) {
    //            NotifyCirMessage('Error : ', msg, 'danger');
    //            return false;
    //        }
    //        return true;
    //    });

    //}
};


$(document).ready(function () {

    var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth

    //Get user initials
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('UserInfo', function UserInfo(user) {
            if (user) {
                if (user.length > 0) {
                    user.forEach(function (item) {
                        $('#hdnUserInitial').val(item.Email);
                    });
                }
            }
        });
    });

    CirSyncErrors.drawDataGrid();

    $('#linkSearchDraftSyncErrors').click(function () {

        $('#txtUserInitial').removeClass('validationerror');
        $('#txtUserInitial').removeClass('red-tooltip');

        $('#txtCIRId').removeClass('validationerror');
        $('#txtCIRId').removeClass('red-tooltip');
        $('#ddlLogType').removeClass('validationerror');
        $('#ddlLogType').removeClass('red-tooltip');



        if ($("#ddlLogType").val() == "0") {
            $('#ddlLogType').addClass('validationerror');
            $('#ddlLogType').addClass('red-tooltip');

            if ($.trim($('#txtUserInitial').val()) === "") {
                $('#txtUserInitial').addClass('validationerror');
                $('#txtUserInitial').addClass('red-tooltip');
            }
            else {
                $('#txtUserInitial').removeClass('validationerror');
                $('#txtUserInitial').removeClass('red-tooltip');
            }
            return;
        }
        else //if ($("#ddlLogType").val() == "-1") {   //Error
            if ($.trim($('#txtUserInitial').val()) === "") {
                $('#txtUserInitial').addClass('validationerror');
                $('#txtUserInitial').addClass('red-tooltip');
                return;
            }
            else {
                $('#txtUserInitial').removeClass('validationerror');
                $('#txtUserInitial').removeClass('red-tooltip');
            }
        //}
        //else if ($("#ddlLogType").val() == "1") {   // Draft

        //    if ($.trim($('#txtCIRId').val()) === "") {
        //        $('#txtCIRId').addClass('validationerror');
        //        $('#txtCIRId').addClass('red-tooltip');
        //        return;
        //    }
        //    else {
        //        $('#txtCIRId').removeClass('validationerror');
        //        $('#txtCIRId').removeClass('red-tooltip');

        //        if ($.trim($('#txtUserInitial').val()) === "") {
        //            $('#txtUserInitial').addClass('validationerror');
        //            $('#txtUserInitial').addClass('red-tooltip');
        //            return;
        //        }
        //        else {
        //            $('#txtUserInitial').removeClass('validationerror');
        //            $('#txtUserInitial').removeClass('red-tooltip');
        //        }
        //    }
        //}
        CirSyncErrors.loadSyncErrorsGrid();
    });

    $('body').on('click', '.CirErrorDraftStatus', function () {
        var cirError = $(this).attr('value');
        if (!cirError)
            return;
        CirSyncErrors.showDetails(cirError);
    });

    $('body').on('click', '.ReassignCIR', function () {
        var cirId = $(this).attr('id');
        var cirDataLocalID = $(this).attr('value');
        if (!cirId)
            return;
        CirSyncErrors.ReassignCIRModal(cirId, cirDataLocalID);
    });

    $('body').on('click', '.DeleteUnlockCIR_Error', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            //if (confirm(cirHead)) {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            CirSyncErrors.DeleteUserCirData(cirLocalId).done(function () {
                //var tblDraftSyncErrorGrid = $('#DraftSyncErrorGrid').DataTable();
                //tblDraftSyncErrorGrid.row($(this).parents('tr')).remove().draw(false);
                CirSyncErrors.loadSyncErrorsGrid();
                waitingDialog.hide();

            })
            .fail(function (e) {
                waitingDialog.hide();
            });
        });
        //});
    });

    $('body').on('click', '.DeleteUnlockCIR_Draft', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
        //if (confirm(cirHead)) {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            CirSyncErrors.DeleteUserCirData(cirLocalId).done(function () {
                //var tblDraftSyncErrorGrid = $('#DraftSyncErrorGrid').DataTable();
                //tblDraftSyncErrorGrid.row($(this).parents('tr')).remove().draw(false);
                CirSyncErrors.loadSyncErrorsGrid();
                waitingDialog.hide();
            })
            .fail(function (e) {
                waitingDialog.hide();
            });
        //}
        });
    });

    $("#btnAssignCIR").click(function () {

        var selectedUser = $('#UserList option:selected');
        if (selectedUser.length == 0) {

            //alert("Please select User(s) to assign a role!");
            //return false;
            CirAlert.alert('Please select one User to assign CIR !', 'Cir App', null, 'error').done(function () {
            });
            return false;

        }
        CirSyncErrors.AssignCIR($('#CIRId').val(), $('#CirDataLocalID').val(), selectedUser.val());
    });

    $("#btnUserSearch_AssignCIR").click(function () {
        $('#txtUserToSearch').removeClass('validationerror');
        $('#txtUserToSearch').removeClass('red-tooltip');
        $("#lblUserToSearch_Validation").empty();
        $("#btnUserSearch_AssignCIR").text("Search");
        var userToSearch = $("#txtUserToSearch").val();
        if (userToSearch.trim() == "" || userToSearch.trim().length < 3) {
            $('#txtUserToSearch').addClass('validationerror');
            $('#txtUserToSearch').addClass('red-tooltip');
            //$('#lblUserError').text('Entered User Initial is not valid !');
            return false;
        }
        //$("#btnUserSearch").text("Please Wait..");
        CirSyncErrors.SearchUsers(userToSearch, $('#MobAppURL').val(), $('#MobAppID').val());
    });

    $('body').on('click', '.EditCIRByAdmin', function () {
        var id = $(this).attr('id');
        var cirDataLocalID = $(this).attr('value');
        cirOfflineApp.getLocalDraftCount().done(function (count) {
                 var RetVal;
                if (!id)
                    return;
                waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

                //RetVal = CirSyncErrors.EditUserCirData(id);
                CirSyncErrors.AssignCIRToAdmin(id, cirDataLocalID);
            
        });
        
    });
});