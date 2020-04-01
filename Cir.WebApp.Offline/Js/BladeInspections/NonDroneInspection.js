﻿
var NonDroneInspection = {
    getCookie: function(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    },
    setCookie:function(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    },
    OnPageReady: function () {
        var that = this;
        if (that.getCookie("not-first-time") !== 'true') {
            $("#myModal").modal('show');
            $('#myModal').on('hidden.bs.modal',
                function() {
                    document.getElementById("my-video").pause();
                    that.setCookie("not-first-time", 'true', 365);
                });
            $("#blade-instruction-modal-btn").click(function() {
                $("#myModal").modal('hide');
            });
        };
    }
};             
