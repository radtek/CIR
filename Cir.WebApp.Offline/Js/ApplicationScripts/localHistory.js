var _CurrentSyncPage = 1;
var localHistory = new function () {
    this._orderBy1 = [[7, 'desc']];
    this._currentOrder1 = 'desc';

    this._orderBy2 = [[7, 'desc']];
    this._currentOrder2 = 'desc';

    this._orderBy3 = [[7, 'desc']];
    this._currentOrder3 = 'desc';
    var _footable = null;
    var progressControllers = [];

    var _RecordsPerPage = 2;
    var _LazyLoading = 10;
    var tblLocalHistory = null;
    var _localHistoryRows = [];
    var _localHistoryDraftRows = [];
    var _localHistoryErrorRows = [];
    function CheckNumberOfRecords() {
        if (jQuery('table#localHistoryTable td').hasClass('dataTables_empty')) {
            $('.dataTables_paginate').hide();
            $('.dataTables_length').hide();
            $('.dataTables_info').hide();
        }

        $("#localHistoryTable tr td:nth-child(4)").each(function (i) {
            $(this).addClass('txtAlignCenter');
        });
        $("#localHistoryTableLocked tr td:nth-child(4)").each(function (i) {
            $(this).addClass('txtAlignCenter');
        });
        $("#localHistoryTableWithErrors tr td:nth-child(4)").each(function (i) {
            $(this).addClass('txtAlignCenter');
        });
    }

    function observeSyncProgress(initialCount, currentCount, cirId, progressCtrl) {
        var percent = 100;

        if (initialCount === 0) {
            progressCtrl.stop();
        }
        if (initialCount === currentCount && initialCount > 0) {
            percent = 0;
        } else if (initialCount > 0) {
            var diff = initialCount - currentCount;

            percent = parseInt(diff / initialCount * 100);
        }

        var index = parseInt(localHistoryCache.get(cirId));

        $('#localHistoryTableLocked tbody tr:nth-child(' + index + ') td:last-child').text(percent + '%');
    }

    this.loadLegacyLocalHistory = function () {
        var deferredObject = $.Deferred();
        cirOfflineApp.getCirLocalData().done(function (CirLocalDataList) {
            counter = 0;
            $.each(CirLocalDataList, function (i, item) {
                var dataRows = cirDataDiplay.getDataRows(item, '1')[0];
                var nr = null;

                var createdDateString = dataRows.CreatedDate.split(' ')[0].split("-");
                var createdDate = new Date(createdDateString[1] + '/' + createdDateString[0] + '/' + createdDateString[2] + '/' + dataRows.CreatedDate.split(' ')[1] + ' UTC');
                dataRows.CreatedDate = createdDate;

                if (document.getElementById("btnSync") != null || document.getElementById("btnSync") != undefined) {
                    if (Offline.state == "up") {
                        var c = $(".fa-pencil-square-o").parent(0);
                        var elems = document.querySelectorAll(".fa-pencil-square-o")
                        if (document.getElementById("btnSync").innerHTML.indexOf("Syncing") != -1) {
                            if (c.is("a")) {
                                $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                                $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
                            }
                            $(".fa-pencil-square-o").css("pointer-esvents", "none");
                            $(".fa-pencil-square-o").attr("disabled", 'disabled');
                            $(".fa-pencil-square-o").css("color", "#c0c0c0");
                        }
                    }
                }

                if (item.Status == "-1") {     //Error
                    _localHistoryErrorRows.push(dataRows);
                }
                else if (item.Status == "3") {    //Submited
                    _localHistoryRows.push(dataRows);
                }
                else {     //Draft, Conflict, Locked
                    _localHistoryDraftRows.push(dataRows);
                }
                if (document.getElementById("btnSync") != null || document.getElementById("btnSync") != undefined) {
                    if (Offline.state == "up") {
                        var c = $(".fa-pencil-square-o").parent(0);
                        var elems = document.querySelectorAll(".fa-pencil-square-o")
                        if (document.getElementById("btnSync").innerHTML.indexOf("Syncing") != -1) {
                            if (c.is("a")) {
                                $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                                $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
                            }
                            $(".fa-pencil-square-o").css("pointer-esvents", "none");
                            $(".fa-pencil-square-o").attr("disabled", 'disabled');
                            $(".fa-pencil-square-o").css("color", "#c0c0c0");
                        }
                    }
                }

            });


            CheckNumberOfRecords();

            if (_footable == null) {
                _footable = $('.footable').footable();

            }
            else {
                $('.footable').trigger('footable_redraw');
            }
            $(".dataTables_empty").each(function () {
                $(this).attr("align", "center");
                $(this).html("No CIRs found");
            })


            deferredObject.resolve();
        });
        return deferredObject.promise();
    }
    //
    this.loadNewLocalHistory = function () {
        var deferredObject = $.Deferred();
        cirOfflineApp.getNewCirLocalData().done(function (CirLocalDataList) {
            var userName = CurrentUserInfo.Name ? CurrentUserInfo.Name.toLowerCase() : '';

            CirLocalDataList.forEach(function (item) {
                item.CreatedDate = new Date(item.CreatedDate);
            });

            CirLocalDataList.sort(function (first, second) {
                return first.CreatedDate.getTime() - second.CreatedDate.getTime();
            }).reverse();

            $.each(CirLocalDataList, function (i, item) {
                var dataRows = cirDataDiplay.getDataRows(item, '1')[0];
                var nr = null;

                if (document.getElementById("btnSync") != null || document.getElementById("btnSync") != undefined) {
                    if (Offline.state == "up") {
                        var c = $(".fa-pencil-square-o").parent(0);
                        var elems = document.querySelectorAll(".fa-pencil-square-o")
                        if (document.getElementById("btnSync").innerHTML.indexOf("Syncing") != -1) {
                            if (c.is("a")) {
                                $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                                $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
                            }
                            $(".fa-pencil-square-o").css("pointer-esvents", "none");
                            $(".fa-pencil-square-o").attr("disabled", 'disabled');
                            $(".fa-pencil-square-o").css("color", "#c0c0c0");
                        }
                    }
                }

                if (((item.lockedBy !== undefined &&
                        item.lockedBy !== null &&
                        item.lockedBy.toLowerCase() === userName.toLowerCase()) ||
                    (item.delegatedTo !== undefined &&
                        item.delegatedTo !== null &&
                        item.delegatedTo.toLowerCase() === userName.toLowerCase()) ||
                    (item.delegatedBy !== undefined &&
                        item.delegatedBy !== null &&
                    item.delegatedBy.toLowerCase() === userName.toLowerCase())) && !isNewCirStateError(item)) {
                    _localHistoryDraftRows.push(dataRows);
                } else if (isNewCirStateError(item)) {
                    _localHistoryErrorRows.push(dataRows);
                } else {
                    if (item.Status === "Draft") {
                        return;
                    }
                    if (item.sqlProcessStatus.toLowerCase() !== "nottransferred") {
                        _localHistoryRows.push(dataRows);
                    }
                }

                if (document.getElementById("btnSync") != null || document.getElementById("btnSync") != undefined) {
                    if (Offline.state == "up") {
                        var c = $(".fa-pencil-square-o").parent(0);
                        var elems = document.querySelectorAll(".fa-pencil-square-o")
                        if (document.getElementById("btnSync").innerHTML.indexOf("Syncing") != -1) {
                            if (c.is("a")) {
                                $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                                $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
                            }
                            $(".fa-pencil-square-o").css("pointer-esvents", "none");
                            $(".fa-pencil-square-o").attr("disabled", 'disabled');
                            $(".fa-pencil-square-o").css("color", "#c0c0c0");
                        }
                    }
                }
            });


            CheckNumberOfRecords();

            if (_footable == null) {
                _footable = $('.footable').footable();

            }
            else {
                $('.footable').trigger('footable_redraw');
            }
            $(".dataTables_empty").each(function () {
                $(this).attr("align", "center");
                $(this).html("No CIRs found");
            })



            deferredObject.resolve();
        });
        return deferredObject.promise();
    }
    this.loadLocalHistory = function () {
        var tblLocalHistoryWithErrors = $('#localHistoryTableWithErrors').DataTable({
            destroy: true,
            order: localHistory._orderBy1,
            searching: false,
            paging: false,
            info: false,
            columnDefs: [
                { type: 'de_datetime', targets: 7 },
                { targets: [0, 8], 'orderable': false }
            ]
        });
        var tblLocalHistoryLocked = $('#localHistoryTableLocked').DataTable({
            destroy: true,
            order: localHistory._orderBy2,
            searching: false,
            paging: false,
            info: false,
            columnDefs: [
                { type: 'de_datetime', targets: 7 },
                { targets: [0, 8], 'orderable': false }
            ]
        });

        localHistoryCache.clear();

        for (var i = 0; i < progressControllers.length; i++) {
            progressControllers[i].stop();
        }

        progressControllers.splice(0, progressControllers.length);
        tblLocalHistoryWithErrors.clear().draw();
        tblLocalHistoryLocked.clear().draw();
        _localHistoryRows = [];
        _localHistoryErrorRows = [];
        _localHistoryDraftRows = [];
        var that = this;
        var counter;
        this.loadLegacyLocalHistory().done(function () {

            that.loadNewLocalHistory().done(function () {
                that.lazyLoadLocalHistory();
                waitingDialog.hide();

            });

        });

    };

    this.lazyLoadLocalHistory = function () {
        var tblLocalHistoryWithErrors = $('#localHistoryTableWithErrors').DataTable({
            destroy: true,
            order: localHistory._orderBy1,
            searching: false,
            paging: false,
            info: false,
            columnDefs: [
                { type: 'de_datetime', targets: 7 },
                { targets: [0, 8], 'orderable': false }
            ]
        });
        var tblLocalHistoryLocked = $('#localHistoryTableLocked').DataTable({
            destroy: true,
            order: localHistory._orderBy2,
            searching: false,
            paging: false,
            info: false,
            columnDefs: [
                { type: 'de_datetime', targets: 7 },
                { targets: [0, 8], 'orderable': false }
            ]
        });

        var synRows = _localHistoryRows;
        var PageLength = (_CurrentSyncPage * _RecordsPerPage);
        if (PageLength > synRows) {
            PageLength = synRows;
        }
        var synRowsPaged = synRows.sort(function (obj1, obj2) {
            return obj2.CreatedDate - obj1.CreatedDate;
        }).slice(0, 20);
        _localHistoryRows = synRowsPaged;
        tblLocalHistory = $('#localHistoryTable').DataTable({
            destroy: true,
            order: localHistory._orderBy3,
            searching: false,
            paging: false,
            info: false,
            columnDefs: [
                { type: 'de_datetime', targets: 7 },
                { targets: [0, 9], 'orderable': false }

            ]
        });
        tblLocalHistory.clear().draw();

        $.each(synRowsPaged, function (i, item) {

            var cname = item.ComponentInspectionReportName;
            if (cname.length > 16) {
                cname = "<span title='" + cname + "'>" + cname.substring(0, 16) + "..." + "</span>";
            }

            tblLocalHistory.row.add([item.StausIcon, '<a  href="/cir/cir-search#CirID=' + item.DisplayCirId + '" style=" color:#3c763d;cursor:pointer;text-decoration:underline">' + item.DisplayCirId + '</a>', cname, item.CimCaseNumber, item.TurbineType, item.TurbineNumber, item.SiteName, item.CreatedDate, item.CIRCurrentStaus, item.ActionIcons]).draw(false);

        });

        var synErrorRowsPaged = _localHistoryErrorRows.sort(function (obj1, obj2) {
            return obj2.CreatedDate - obj1.CreatedDate;
        }).slice(0, 20);
        _localHistoryErrorRows = synErrorRowsPaged;

        $.each(synErrorRowsPaged, function (i, item) {
            nr = tblLocalHistoryWithErrors.row.add([
                item.StausIcon, item.DisplayCirId, item.ComponentInspectionReportName,
                item.CimCaseNumber, item.TurbineType, item.TurbineNumber, item.SiteName,
                item.CreatedDate, item.ActionIcons, '0%'
            ]).draw(false);
        });

        var synDraftRowsPaged = _localHistoryDraftRows.sort(function (obj1, obj2) {
            return obj2.CreatedDate - obj1.CreatedDate;
        });

        $.each(synDraftRowsPaged, function (i, item) {
            nr = tblLocalHistoryLocked.row.add([
                item.StausIcon, item.DisplayCirId, item.ComponentInspectionReportName,
                item.CimCaseNumber, item.TurbineType, item.TurbineNumber, item.SiteName,
                item.CreatedDate, item.ActionIcons, '0%'
            ]).draw(false);
            localHistoryCache.put(item.RowId, ++counter);

            var ctrl = SynchronizationProgressController(item.RowId, observeSyncProgress);

            ctrl.start();

            progressControllers.push(ctrl);
        });

        if (document.getElementById("btnSync") != null || document.getElementById("btnSync") != undefined) {
            if (Offline.state == "up") {
                var c = $(".fa-pencil-square-o").parent(0);
                var elems = document.querySelectorAll(".fa-pencil-square-o")
                if (document.getElementById("btnSync").innerHTML.indexOf("Syncing") != -1) {
                    if (c.is("a")) {
                        $(".fa-pencil-square-o").parent().css("pointer-events", "none");
                        $(".fa-pencil-square-o").parent().attr("disabled", 'disabled');
                    }
                    $(".fa-pencil-square-o").css("pointer-esvents", "none");
                    $(".fa-pencil-square-o").attr("disabled", 'disabled');
                    $(".fa-pencil-square-o").css("color", "#c0c0c0");
                }
            }
        }
        $('.footable').trigger('footable_redraw');
        _CurrentSyncPage++;
    };

    this.DelegateCIRModal = function (id, cirDataLocalID, isNew) {
        $("#UserList").empty();
        $("#txtUserToSearch").val('');
        $("#lblUserToSearch_Validation").empty();
        $("#DelegateCIRModal").find('.modal-title').text("Delegate CIR");
        $("#CIRId").val(id);
        $("#isNew").val(isNew);
        $("#CirDataLocalID").val(cirDataLocalID);


        $("#DelegateCIRModal").modal('show');
    }
};
function StoreRowID(rowid) {
    alert(rowid);
}
function showDetails(strMsg) {
    $("#myDetailsModal").find('.modal-title').text("Status details");
    $("#myDetailsModal").find('#strErrorMsg').html(strMsg);
    $("#myDetailsModal").modal('show');
}
function ShowConCir(id) {
    $("#myEditModal").find('.modal-title').text("Resolve Conflict");
    $("#myEditModal").find('#strErrorMsg').html(id);
    $("#_hId").val(id);

    $("#myEditModal").modal('show');
}
function KeepLocalVersion() {
    var id = $("#_hId").val();
    azureSync.ResolveConflictKeepLocal(id, true);
    localHistory.loadLocalHistory();
    $('#myEditModal').modal('hide');
}
function KeepServerVersion() {
    var id = $("#_hId").val();
    azureSync.ResolveConflictKeepServer(id, true);
    localHistory.loadLocalHistory();
    $('#myEditModal').modal('hide');
}
function ClearAllCIRs() {
    CirAlert.confirm('Do you want to clear all CIRs saved locally? This will also unlock the the CIRs you are editing. All your changes will by lost in the CIRs you have not submitted.', 'Cir App', 'Yes', 'No', 'warning').done(function () {
        var tblLocalHistoryWithErrors = $('#localHistoryTableWithErrors').DataTable({
            destroy: true,
            searching: false,
            paging: false,
            info: false
        });
        var tblLocalHistoryLocked = $('#localHistoryTableLocked').DataTable({
            destroy: true,
            searching: false,
            paging: false,
            info: false
        });
        var tblLocalHistory = $('#localHistoryTable').DataTable({
            destroy: true,
            searching: false,
            paging: false,
            info: false
        });
        tblLocalHistoryWithErrors.clear().draw(); tblLocalHistoryLocked.clear().draw(); tblLocalHistory.clear().draw();
        cirOfflineApp.softDeleteAllCirLocalData();

    });
}
$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-minus').addClass('glyphicon-plus');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-plus').addClass('glyphicon-minus');
    }
});
$(document).on('click', '.panel div.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-minus').addClass('glyphicon-plus');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-plus').addClass('glyphicon-minus');
    }
});
jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "de_datetime-asc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split(' ');
            var deTimea = (deDatea.length == 1) ? "00:00".split(':') : deDatea[1].split(':');
            var deDatea2 = deDatea[0].split('-');
            x = (deDatea2[2] + deDatea2[1] + deDatea2[0] + deTimea[0] + deTimea[1]) * 1;
        } else {
            x = Infinity; // = l'an 1000 ...
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split(' ');
            var deTimeb = (deDateb.length == 1) ? "00:00".split(':') : deDateb[1].split(':');
            deDateb = deDateb[0].split('-');
            y = (deDateb[2] + deDateb[1] + deDateb[0] + deTimeb[0] + deTimeb[1]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? -1 : ((x > y) ? 1 : 0));
        return z;
    },

    "de_datetime-desc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split(' ');
            var deTimea = (deDatea.length == 1) ? "00:00".split(':') : deDatea[1].split(':');
            var deDatea2 = deDatea[0].split('-');
            x = (deDatea2[2] + deDatea2[1] + deDatea2[0] + deTimea[0] + deTimea[1]) * 1;
        } else {
            x = Infinity;
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split(' ');
            var deTimeb = (deDateb.length == 1) ? "00:00".split(':') : deDateb[1].split(':');
            deDateb = deDateb[0].split('-');
            y = (deDateb[2] + deDateb[1] + deDateb[0] + deTimeb[0] + deTimeb[1]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? 1 : ((x > y) ? -1 : 0));
        return z;
    },

    "de_date-asc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split('-');
            x = (deDatea[2] + deDatea[1] + deDatea[0]) * 1;
        } else {
            x = Infinity; // = l'an 1000 ...
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split('-');
            y = (deDateb[2] + deDateb[1] + deDateb[0]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? -1 : ((x > y) ? 1 : 0));
        return z;
    },

    "de_date-desc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split('-');
            x = (deDatea[2] + deDatea[1] + deDatea[0]) * 1;
        } else {
            x = Infinity;
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split('.');
            y = (deDateb[2] + deDateb[1] + deDateb[0]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? 1 : ((x > y) ? -1 : 0));
        return z;
    }
});
$(document).ready(function () {
    var fSync = getQueryStringValueHash('syncnow');
    if (fSync != undefined && fSync != null && fSync == 1) {
        if (document.referrer != undefined && document.referrer != null) {
            var search = "/cir/manage-cir";
            if (document.referrer.indexOf(search) > -1) {
                if (Offline.state == "down")
                    return;
                else {
                    LoadUserInfo().done(function () {
                        $('#hdnUserPrincipal').val(CurrentUserInfo.UserPrincipleName);
                        azureSync.StartSyncManual().done(function () { });
                    });
                }
            }
        }
    }
    $(window).resize(function () {
        $(".dataTables_empty").each(function () {
            $(this).html("No CIRs found");
        })

    });

    $('body').on('click', '.DelegateCIR', function () {
        var cirId = $(this).attr('id');
        var cirDataLocalID = $(this).attr('value');
        var isNew = $(this).attr('isNew');
        if (!cirId)
            return;
        localHistory.DelegateCIRModal(cirId, cirDataLocalID, isNew);
    });

    $("#btnAssignCIR_LHistory").click(function () {
        var selectedUser = $('#UserList option:selected');
        if (selectedUser.length == 0) {
            CirAlert.alert('Please select one User to delegate CIR !', 'Cir App', null, 'error').done(function () {
            });
            return false;

        }
        cirDataDiplay.DelegateCirData($('#CIRId').val(),
            selectedUser.val(),
            $('#isNew').val(),
            function () {
                setTimeout(function () {
                    localHistory.loadLocalHistory();
                    waitingDialog.hide();
                },
                    500);
            });
    });

    $("#btnUserSearch_LHistory").click(function () {
        $('#txtUserToSearch').removeClass('validationerror');
        $('#txtUserToSearch').removeClass('red-tooltip');
        $("#lblUserToSearch_Validation").empty();
        $("#btnUserSearch_AssignCIR").text("Search");
        var userToSearch = $("#txtUserToSearch").val();
        if (userToSearch.trim() == "" || userToSearch.trim().length < 3) {
            $('#txtUserToSearch').addClass('validationerror');
            $('#txtUserToSearch').addClass('red-tooltip');
            $('#lblUserToSearch_Validation').text('Please enter minimum 3 char User Initial !');
            return false;
        }
        cirDataDiplay.SearchUsers_LHistory(userToSearch, $('#MobAppURL').val(), $('#MobAppID').val());
    });

    $('#localHistoryTableWithErrors th').on('click', function () {
        var index = $(this).index();
        if (localHistory._orderBy1[0][0] != index) {
            localHistory._currentOrder1 = 'desc';
        }
        if (localHistory._currentOrder1 == 'desc') {
            localHistory._orderBy1 = [[index, 'asc']];
            localHistory._currentOrder1 = 'asc'
        }
        else {
            localHistory._orderBy1 = [[index, 'desc']];
            localHistory._currentOrder1 = 'desc'
        }
    });

    $('#localHistoryTableLocked th').on('click', function () {
        var index = $(this).index();
        if (localHistory._orderBy2[0][0] != index) {
            localHistory._currentOrder2 = 'desc';
        }
        if (localHistory._currentOrder2 == 'desc') {
            localHistory._orderBy2 = [[index, 'asc']];
            localHistory._currentOrder2 = 'asc'
        }
        else {
            localHistory._orderBy2 = [[index, 'desc']];
            localHistory._currentOrder2 = 'desc'
        }

    });
    $('#localHistoryTable th').on('click', function () {
        var index = $(this).index();
        if (localHistory._orderBy3[0][0] != index) {
            localHistory._currentOrder3 = 'desc';
        }
        if (localHistory._currentOrder3 == 'desc') {
            localHistory._orderBy3 = [[index, 'asc']];
            localHistory._currentOrder3 = 'asc'
        }
        else {
            localHistory._orderBy3 = [[index, 'desc']];
            localHistory._currentOrder3 = 'desc'
        }

    })//;
    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

    $("[data-toggle=popover]").popover();
    localHistory.loadLocalHistory();
    var timerRefToken = $.timer(function () {
        if (Offline.state == "down")
            return;
        localHistory.loadLocalHistory();
    });

    $('body').on('click', '.RemoveCirs', function () {
        var originalStr = $(this).attr('id');
        var counter = originalStr.indexOf(",");
        var cirLocalId = originalStr.substr(0, counter);
        var cirid = originalStr.substr(counter + 1);

        var cirHead = $(this).attr('value');
        var isNew = $(this).attr('isNew');
        if (!cirLocalId)
            return;

        var finalizeRemove = function (id) {
            if (localStorage.cirQueue !== undefined) {
                var cirQueue = JSON.parse(localStorage.cirQueue);

                if (!!cirQueue) {
                    var idx = cirQueue.findIndex(function (el) {
                        return el.cirId === id;
                    });
                    if (idx >= 0) {
                        cirQueue.splice(idx, 1);
                        localStorage.cirQueue = JSON.stringify(cirQueue);
                    }
                }
            }

            setTimeout(function () {
                localHistory.loadLocalHistory();
                waitingDialog.hide();
            }, 500);
        };

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

            if (isNew) {
                cirOfflineApp.softDeleteNewCirLocalData(cirLocalId).done(function () {
                    finalizeRemove(cirLocalId);
                    CallSyncApi("CirSubmissionData/Delete?reportId=" + cirid + '.0', "DELETE", "")
                     .done(function () {
                         msg = "CIR has been deleted!";
                         waitingDialog.hide();
                         NotifyCirMessage(' ', msg, 'info');
                     });
                });
            } else {
                cirOfflineApp.softDeleteCirLocalData(cirLocalId);
                finalizeRemove(cirLocalId);
            }
        });
    });

    $('body').on('click', '.RemoveLocalCirs', function () {
        var cirLocalId = $(this).attr('id');
        var isNew = $(this).attr('isNew');
        var cirHead = $(this).attr('value');
        var lockedBy = $(this).attr('lockedBy');
        if (!cirLocalId)
            return;

        var finalizeRemove = function (id) {
            if (localStorage.cirQueue !== undefined) {
                var cirQueue = JSON.parse(localStorage.cirQueue);

                if (!!cirQueue) {
                    var idx = cirQueue.findIndex(function (el) {
                        return el.cirId === id;
                    });
                    if (idx >= 0) {
                        cirQueue.splice(idx, 1);
                        localStorage.cirQueue = JSON.stringify(cirQueue);
                    }
                }
            }

            setTimeout(function () {
                localHistory.loadLocalHistory();
                waitingDialog.hide();
            }, 500);
        };

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            //$('table#localHistoryTableLocked tr#' + cirLocalId).remove();

            if (isNew) {
                cirOfflineApp.softDeleteNewCirLocalData(cirLocalId).done(function () {
                    finalizeRemove(cirLocalId);
                });
            } else {
                cirOfflineApp.softDeleteCirLocalData(cirLocalId);
                finalizeRemove(cirLocalId);
            }
        });
    });

    $('body').on('click', '.RemoveLocalSynCirs', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            cirOfflineApp.softDeleteCirLocalData(cirLocalId);
            setTimeout(function () {
                localHistory.loadLocalHistory();
                azureSync.StartSyncManual().done(function () { });
                waitingDialog.hide();
            }, 500);

        });
    });

    $('body').on('click', '.EditCir', function () {
        var cirLocalId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!cirLocalId)
            return;

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            window.open("/cir/manage-cir#cirID=" + cirLocalId, '_self');
        });
    });

    $('body').on('click', '.RevokeDelegateCIR',
        function () {
            var Id = $(this).attr('id');
            var cirHead = $(this).attr('value');
            var isNew = $(this).attr('isNew');
            if (!Id)
                return;
            CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
                if (isNew) {
                    cirDataDiplay.RevokeDelegatedPermission(Id, true, true, isNew, function () {
                        setTimeout(function () {
                            localHistory.loadLocalHistory();
                            waitingDialog.hide();
                        },
                            500);
                    });
                } else {
                    CirAlert.confirm("Do you want to send your changes to the owner ?",
                        'Cir App',
                        'Yes',
                        'No',
                        'warning').done(function () {
                            cirDataDiplay.RevokeDelegatedPermission(Id, true, true, isNew);
                        }).fail(function (e) {
                            cirDataDiplay.RevokeDelegatedPermission(Id, false, true, isNew);
                        });
                }
            });

        });

    $('body').on('click', '.RevokeDelegateCIR_Owner', function () {
        var Id = $(this).attr('id');
        var cirHead = $(this).attr('value');
        var isNew = $(this).attr('isNew');
        if (!Id)
            return;
        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            if (isNew) {
                cirDataDiplay.RevokeDelegatedPermission(Id, true, true, isNew, function () {
                    setTimeout(function () {
                        localHistory.loadLocalHistory();
                        waitingDialog.hide();
                    },
                        500);
                });
            } else {
                CirAlert.confirm("Do you want to take latest changes from delegate ?", 'Cir App', 'Yes', 'No', 'warning').done(function () {
                    cirDataDiplay.RevokeDelegatedPermission(Id, true, false, isNew);
                }).fail(function (e) {
                    cirDataDiplay.RevokeDelegatedPermission(Id, false, false, isNew);
                });
            }
        });
    });

    $('body').on('click', '.StatusCir', function () {
        var cirError = $(this).attr('value');
        if (!cirError)
            return;
        showDetails(cirError);
    });

    $('body').on('click', '.EditConCir', function () {
        var id = $(this).attr('id');
        if (!id)
            return;
        ShowConCir(id);
    });
});
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? '' : sParameterName[1];
        }
    }
};
var localHistoryCache = {
    _cache: {},

    put: function (id, index) {
        this._cache[index] = id;
    },

    get: function (id) {
        for (var key in this._cache) {
            if (!this._cache.hasOwnProperty(key)) {
                continue;
            }
            if (this._cache[key] === id) {
                return key;
            }
        }

        return null;
    },

    clear: function () {
        delete this._cache;

        this._cache = {};
    }
};
