var ServiceInfoNotify;

(function (ServiceInfoNotify) {
    function ___createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    function ___createCookieMiliSec(name, value, milisec) {
        if (milisec) {
            var date = new Date();
            date.setTime(date.getTime() + milisec);
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    function ___readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
    function ___eraseCookie(name) {
        createCookie(name, "", -1);
    }

    function _DeleteAll() {
        var deferredObject = $.Deferred();
        var ClearedSIALL = ___readCookie("ClearedSIALL");
        if (ClearedSIALL != undefined && ClearedSIALL != null && ClearedSIALL == 1) {
            setTimeout(function () { deferredObject.resolve(""); }, 300);
        }
        else {
            try {
                dbtransaction.openDatabase(function () {
                    dbtransaction.deleteAllItemfromTable('ServiceInfoNotification', function () {
                        ___createCookie("ClearedSIALL", 1, 365);
                        deferredObject.resolve("");
                    });
                });

            }
            catch (e) {

                console.log(e);
                setTimeout(function () { deferredObject.resolve(""); }, 100);
            }
        }

        return deferredObject.promise();
    }

    function _ReadAll() {
        _DeleteAll().done(function () {
            CallClientApi("MyServiceInformationList", "GET", "").done(function (result) {
                if (result) {
                    try {
                        dbtransaction.openDatabase(function () {
                            for (var i = 0, obj; obj = result[i]; i++) {
                                dbtransaction.seedServiceInfroNotification('ServiceInfoNotification', obj, function (siObj, sinew) {
                                    var objput = {}
                                    if (siObj.objet == null || siObj.objet.id == undefined || siObj.objet.id == null) {
                                        objput.isRead = false;
                                        objput.isShown = false;
                                    }
                                    else {
                                        objput.isRead = siObj.objet.isRead;
                                        objput.isShown = siObj.objet.isShown;
                                    }
                                    objput.id = sinew.id;
                                    objput.message = sinew.message;
                                    objput.severityId = sinew.severityId;
                                    objput.severityName = sinew.severityName;
                                    objput.StrFromDate = sinew.strFromDate;
                                    objput.isExpired = sinew.isExpired;
                                    dbtransaction.addItemIntoTable({ objet: objput, ServiceInfoNotificationID: objput.id }, 'ServiceInfoNotification', function () { console.log('Service Information Added'); });
                                });

                            }
                            _UpdateBadge();
                        });
                    }
                    catch (e) { console.log(e); }
                }
            }).fail(function () {
                console.log('fail to get my service info');
            });
        });
    }

    function _MarkRead(obj, OnlyShown) {
        try {
            dbtransaction.openDatabase(function () {
                dbtransaction.seedServiceInfroNotification('ServiceInfoNotification', obj, function (siObj, sinew) {
                    if (OnlyShown) {
                        siObj.objet.isShown = true;
                    }
                    else {
                        siObj.objet.isShown = true;
                        siObj.objet.isRead = true;
                    }
                    dbtransaction.addItemIntoTable({ objet: siObj.objet, ServiceInfoNotificationID: siObj.objet.id }, 'ServiceInfoNotification', function () { console.log('Service Information Read'); });
                    _UpdateBadge();
                });

            });
        }
        catch (e) { console.log(e); }
    }
    function _UpdateBadge() {
        try {
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('ServiceInfoNotification', function (siList) {
                    siList = $.map(siList, function (val, key) {
                        if (val.objet.isExpired == false && val.objet.isRead == false) return val;
                    });
                    if (siList.length > 0)
                        $('#sibadge').text(siList.length);
                    else
                        $('#sibadge').text('');

                });


            });
        }
        catch (e) { console.log(e); }
    }


    function _Notify() {
        try {
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('ServiceInfoNotification', function (siList) {
                    siList = $.map(siList, function (val, key) {
                        if (val.objet.isExpired == false && val.objet.isRead == false && (val.objet.isShown == null || val.objet.isShown == undefined || val.objet.isShown == false)) return val;
                    });

                    for (var i = 0, obj; obj = siList[i]; i++) {
                        var not = $.notify({
                            // options
                            message: obj.objet.message,
                            icon: 'glyphicon glyphicon-warning-sign'

                        }, {
                            // settings
                            type: ((obj.objet.severityId == 1) ? 'warning' : 'danger'),
                            delay: ((obj.objet.severityId == 2) ? 0 : 7000),
                            placement: {
                                from: "top",
                                align: "right"
                            },
                            z_index: 10031,
                            template: '<div data-notify="container" data-siid="' + obj.objet.id + '" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
		'<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
		'<span data-notify="icon"></span> ' +
		'<span data-notify="title">{1}</span> ' +
		'<span data-notify="message">{2}</span>' +
		'<div class="progress" data-notify="progressbar">' +
			'<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
		'</div>' +
		'<a href="{3}" target="{4}" data-notify="url"></a>' +
	'</div>',
                            onClose: (obj.objet.severityId == 1) ? function () {
                                var obj = {};
                                obj.id = parseInt($(this).attr('data-siid'));
                                _MarkRead(obj, true);
                            } : function () {
                                var obj = {};
                                obj.id = parseInt($(this).attr('data-siid'));
                                _MarkRead(obj, false);
                            },
                            onShown: (obj.objet.severityId == 1) ? function () {
                                var obj = {};
                                obj.id = parseInt($(this).attr('data-siid'));
                                _MarkRead(obj, true);
                            } : null
                        });
                    }
                });


            });
        }
        catch (e) { console.log(e); }
    }
    ServiceInfoNotify.Get = _ReadAll;
    ServiceInfoNotify.UpdateBadge = _UpdateBadge;
    ServiceInfoNotify.Notify = _Notify;
    ServiceInfoNotify.MarkRead = _MarkRead;
})(ServiceInfoNotify || (ServiceInfoNotify = {}));



$(document).ready(function () {
    if (Offline.state == "up") {
        ServiceInfoNotify.Get();
    }
    setTimeout(function () { ServiceInfoNotify.UpdateBadge(); setTimeout(function () { ServiceInfoNotify.Notify(); }, 300); }, 2000);
});