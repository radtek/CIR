var dbPin = "";
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};
function createCookie(name, value, minutes) {
    var expires;

    if (minutes) {
        var date = new Date();
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = encodeURIComponent(name) + "=" + encodeURIComponent(value) + expires + "; path=/";
}
function eraseCookie(name) {
    createCookie(name, "", -15);
}
$(document).ready(function () {
    var a = 0;
    var codetype = '1'; // if 1 then Set Pin, if 2 then Confirm Pin, if 3 then wrong pin, if 4 then change pin
    var wrongTries = 3;
    // fetching user pin if any
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('UserPin', function (user) {
            user.forEach(function (item) {
                if (item) {
                    $('#hdnUserPin').val(item.Pin);
                    console.log(getUrlParameter('Mode'));
                    if ($('#hdnUserPin').val() == '') {
                        $('#TopHead h2').text("Set Pin");
                        $('#hdnPinType').val('1');
                    }
                    else if (getUrlParameter('Mode') && getUrlParameter('Mode') == '1') {
                        $('#TopHead h2').text("Enter your existing pin");
                        $('#hdnPinType').val('3');
                        codetype = 4;
                    }
                    else {
                        $('#TopHead h2').text("Enter your pin");
                        $('#hdnPinType').val('2');
                        codetype = '3';
                    }
                }
            });
        });
    });

    $('.num').click(function () {
        a++;
        $('.a' + a).removeClass('clear');
        $('.a' + a).addClass('active');
        $('.a' + a).prop('title', $(this).attr('data-number'));
        var selectedNumbers = $('.small-circle');
        var setPin = true;
        if ($('#hdnSetPin').val().length < 4)
            $('#hdnSetPin').val('');
        if ($('#hdnConfirmPin').val().length < 4)
            $('#hdnConfirmPin').val('');
        if ($('#hdnExistingPin').val().length < 4)
            $('#hdnExistingPin').val('');

        console.log('Code: ' + codetype);

        if (selectedNumbers)
            for (var i = 0; i < selectedNumbers.length; i++) {
                if (selectedNumbers[i] && $('#' + selectedNumbers[i].id).hasClass('active')) {
                    if ($('#hdnPinType').val() == '1') {
                        if (codetype == '1')
                            $('#hdnSetPin').val($('#hdnSetPin').val() + $('#' + selectedNumbers[i].id).attr('title'));
                        else if (codetype == '2')
                            $('#hdnConfirmPin').val($('#hdnConfirmPin').val() + $('#' + selectedNumbers[i].id).attr('title'));
                    }
                    else if ($('#hdnPinType').val() == '2') {
                        if (codetype == '3')
                            $('#hdnConfirmPin').val($('#hdnConfirmPin').val() + $('#' + selectedNumbers[i].id).attr('title'));
                    }
                    else if ($('#hdnPinType').val() == '3') {
                        if (codetype == '4')
                            $('#hdnExistingPin').val($('#hdnExistingPin').val() + $('#' + selectedNumbers[i].id).attr('title'));
                    }
                }
            }

        if ($('#hdnPinType').val() == '1') { // Set new pin for first login
            if ($('#hdnSetPin').val().length === 4) {
                codetype = '2';
            }
            if ($('#hdnSetPin').val().length === 4 && $('#hdnConfirmPin').val().length === 0) {
                $('#TopHead h2').text("Confirm PIN");
                a = 0;
                $('.small-circle').removeClass('active');
                $('.small-circle').addClass('clear');
                $('.small-circle').prop('title', '');
            }
            else if ($('#hdnSetPin').val().length === 4 && $('#hdnConfirmPin').val().length === 4) {
                if ($('#hdnSetPin').val() != $('#hdnConfirmPin').val()) {
                    $('#DivEnterPass').text("Incorrect Pin");
                    $('#DivEnterPass').css('color', 'red');
                    $('#hdnConfirmPin').val('');
                    a = 0;
                    $('.small-circle').removeClass('active');
                    $('.small-circle').addClass('clear');
                    $('.small-circle').prop('title', '');
                }
                else if ($('#hdnSetPin').val() == $('#hdnConfirmPin').val()) {
                    dbtransaction.openDatabase(function () {
                        dbtransaction.getItemfromTable('UserPin', function (user) {
                            user.forEach(function (item) {
                                item.Pin = $('#hdnSetPin').val();
                                if (item) {
                                    dbtransaction.addItemIntoTable(item, 'UserPin', function () {
                                        console.log('Pin setted');
                                        createCookie("MobileUnlock", $('#hdnSetPin').val(), 15);
                                        window.location.href = "/cir/manage-cir";
                                    });
                                }
                            });
                        });
                    });
                }
            }
        }
        else if ($('#hdnPinType').val() == '2') { // Check pin entered
            if ($('#hdnUserPin').val().length === 4 && $('#hdnConfirmPin').val().length === 4) {
                if ($('#hdnUserPin').val() != $('#hdnConfirmPin').val()) {
                    wrongTries--;
                    $('#DivEnterPass').html("Incorrect Pin </br>" + wrongTries + " tries left");
                    $('#DivEnterPass').css('color', 'red');
                    $('#hdnConfirmPin').val('');
                    a = 0;
                    $('.small-circle').removeClass('active');
                    $('.small-circle').addClass('clear');
                    $('.small-circle').prop('title', '');
                    if (wrongTries === 0) {
                        dbtransaction.openDatabase(function () {
                            dbtransaction.deleteAllItemfromTable('UserInfo', function UserInfo(user) {
                                console.log('User Deleted');
                            });
                            dbtransaction.deleteAllItemfromTable('CurrentUser', function UserInfo(user) {
                                console.log('User Deleted');
                            });
                            dbtransaction.deleteAllItemfromTable('UserPin', function UserInfo(user) {
                                window.location.href = "/cir";
                            });
                        });
                    }
                }
                else if ($('#hdnUserPin').val() == $('#hdnConfirmPin').val()) {
                    console.log('Pin validated');
                    createCookie("MobileUnlock", $('#hdnUserPin').val(), 15);
                    window.location.href = "/cir/manage-cir";
                }
            }
        }
        else if ($('#hdnPinType').val() == '3') { // Reset Pin
            if ($('#hdnExistingPin').val().length === 4) {
                if ($('#hdnExistingPin').val() == $('#hdnUserPin').val()) {
                    $('#TopHead h2').text("Enter new pin");
                    $('#hdnPinType').val('1');
                    codetype = '1';
                    $('#hdnExistingPin').val('');
                    a = 0;
                    $('.small-circle').removeClass('active');
                    $('.small-circle').addClass('clear');
                    $('.small-circle').prop('title', '');
                }
                else {
                    $('#DivEnterPass').html("Incorrect Pin");
                    $('#DivEnterPass').css('color', 'red');
                    $('#hdnExistingPin').val('');
                    a = 0;
                    $('.small-circle').removeClass('active');
                    $('.small-circle').addClass('clear');
                    $('.small-circle').prop('title', '');
                }
            }
        }

    });

    $('.numback').click(function () {
        $('.a' + a).removeClass('active');
        $('.a' + a).addClass('clear');
        $('.a' + a).prop('data-number', '');
        a--;

        var selectedNumbers = $('.small-circle');
        $('#hdnSetPin').val('');
        if (selectedNumbers)
            for (var i = 0; i < selectedNumbers.length; i++) {
                if (selectedNumbers[i] && $('#' + selectedNumbers[i].id).hasClass('active')) {
                    $('#hdnSetPin').val($('#hdnSetPin').val() + $('#' + selectedNumbers[i].id).attr('title'));
                }
            }
    });

});
