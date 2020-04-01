$(document).ready(function () {
    var UserTokenRefreshed = false;
    var userAccessToken, userDisplayName = '';
    var objUser;


    var _TokenRefreshTime = 60;
    var _TokenRefreshTimer = null;
    StartTokenRefreshTimer();

    function StartTokenRefreshTimer() {

        var _TokenRefreshCookie = readCookie("_TokenRefreshCookie");

        if (parseInt(_TokenRefreshCookie) > 0) {
            _TokenRefreshTime = _TokenRefreshCookie;
        }
        else {
            createCookie("_TokenRefreshCookie", _TokenRefreshTime);
        }

        _TokenRefreshTimer = setInterval(function () {
            _TokenRefreshTime--;
            createCookie("_TokenRefreshCookie", _TokenRefreshTime);
            if (_TokenRefreshTime == 0) {

                if (Offline.state == "down")
                    return;
                UserTokenRefreshing = 1;
                UserCachingController.RefereshUser(true).done(function (obj) {

                }).fail(function (obj) {

                });

                _TokenRefreshTime = 60;
            }
        }, 1000);

    }
});

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function downloadJsonforDebug(json) {
    var blob = new Blob([json], { type: "application/json" });
    var url = URL.createObjectURL(blob);
    window.open(url);


}

function NotifySyncMessage(title, message, type) {
    return true;
    //type : Success, Info, Warning & Danger
    $.notify({
        // options
        icon: 'glyphicon glyphicon-info-sign',
        title: title,
        message: message
    }, {
        // settings
        element: 'body',
        position: null,
        type: type,
        allow_dismiss: true,
        newest_on_top: false,
        showProgressbar: false,
        placement: {
            from: "top",
            align: "center"
        },
        offset: 20,
        spacing: 10,
        z_index: 1031,
        delay: 4000,
        timer: 1000,
        mouse_over: null,
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        onShow: null,
        onShown: null,
        onClose: null,
        onClosed: null,
        icon_type: 'class',
        template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-info" role="alert">' +
            '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
            '<span data-notify="icon"></span> ' +
            '<span data-notify="title">{1}</span> ' +
            '<span data-notify="message">{2}</span>' +
            '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
            '</div>' +
        '</div>'
    });
}