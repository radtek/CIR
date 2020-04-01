function updateCacheStatus(msg) {
    try {
        if ($('#appcachelog') != null && $('#appcachelog').length > 0)
            $('#appcachelog').html(msg);
        else
            console.log(msg);

        /* if (window.applicationCache != null && window.applicationCache.status != null) {
             if (window.applicationCache.status == 1 || window.applicationCache.status == 4) {
 
             }
         }*/
    }
    catch (e)
    { }
}

function GetQueryStringParams(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}



//User Caching
var UserCachingController;

(function (UserCachingController) {
    var _userAccessToken, _userDisplayName = '', _email = '';
    var _code = GetQueryStringParams('code');
    var _objUser;
    var _client;
    var ___isMobile = false;
    var __RefreshingToken = false;

    function __createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    function __createCookieMiliSec(name, value, milisec) {
        if (milisec) {
            var date = new Date();
            date.setTime(date.getTime() + milisec);
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    function __readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }
    function __eraseCookie(name) {
        createCookie(name, "", -1);
    }

    function _GetUserCridentialURL() {
         
        var deferredObject = $.Deferred();
        updateCacheStatus("Reading local user token...");
        dbtransaction.openDatabase(function () {
            var _ObjAuthData;
            var _ObjCurUser;
            dbtransaction.openDatabase(function () {
                console.log('Connection open');
                dbtransaction.getItemfromTable('AuthTokenInfo', function AuthTokenInfo(AuthTokenInfoData) {
                    if (AuthTokenInfoData) {
                        console.log('Get AuthTokenInfo');
                        if (AuthTokenInfoData.length > 0) {
                            AuthTokenInfoData.forEach(function (item) {
                                _ObjAuthData = item;
                                console.log(item);
                            });
                        }
                    }
                    else {
                        Log('AuthTokenInfo null');
                    }
                    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuserData) {
                        if (currentuserData) {
                            console.log('Get user');
                            if (currentuserData.length > 0) {
                                currentuserData.forEach(function (item) {
                                    _ObjCurUser = item;
                                    console.log(item);
                                });
                            }
                        }
                        else {
                            Log('CurrentUser null');
                        }
                        if (_ObjCurUser && _ObjCurUser.userInfo && _ObjCurUser.userInfo.userPrincipalName)
                            var userPrincipalName = _ObjCurUser.userInfo.userPrincipalName;
                        if (_ObjAuthData && _ObjAuthData.objet && _ObjAuthData.objet.AuthData && _ObjAuthData.objet.AuthData.RefreshToken)
                            var refToken = _ObjAuthData.objet.AuthData.RefreshToken;
                        if (_ObjAuthData && _ObjAuthData.objet && _ObjAuthData.objet.AuthData && _ObjAuthData.objet.AuthData.RefreshTokenCreationTime)
                        {                            
                            var refTokenCreationTime = _ObjAuthData.objet.AuthData.RefreshTokenCreationTime;
                            var _date = refTokenCreationTime.split('/')[1].substring(5, 18);
                        }
                        var url = '/cir/referesh-user?userid=' + encodeURIComponent(userPrincipalName) + '&refToken=' + refToken + '&silent=1' + '&refTokenCreationTime=' + _date;                        
                        deferredObject.resolve(url);
                    });
                });


            });
        });
        return deferredObject.promise();
    }

    function _GetUserCridentialURLFormio() {
        var deferredObject = $.Deferred();
        updateCacheStatus("Reading local user token...");
        dbtransaction.openDatabase(function () {
            var _ObjAuthData;
            var _ObjCurUser;
            dbtransaction.openDatabase(function () {
                dbtransaction.getItemfromTable('AuthTokenInfoFormio', function AuthTokenInfo(AuthTokenInfoData) {
                    if (AuthTokenInfoData) {
                        if (AuthTokenInfoData.length > 0) {
                            AuthTokenInfoData.forEach(function (item) {
                                _ObjAuthData = item;
                            });
                        }
                    }
                    dbtransaction.getItemfromTable('CurrentUserFormio', function CurrentUser(currentuserData) {
                        if (currentuserData) {
                            if (currentuserData.length > 0) {
                                currentuserData.forEach(function (item) {
                                    _ObjCurUser = item;
                                });
                            }
                        }
                        if (_ObjCurUser && _ObjCurUser.userInfo && _ObjCurUser.userInfo.userPrincipalName)
                            var userPrincipalName = _ObjCurUser.userInfo.userPrincipalName;
                        if (_ObjAuthData && _ObjAuthData.objet && _ObjAuthData.objet.AuthData && _ObjAuthData.objet.AuthData.RefreshToken)
                            var refToken = _ObjAuthData.objet.AuthData.RefreshToken;
                        if (_ObjAuthData && _ObjAuthData.objet && _ObjAuthData.objet.AuthData && _ObjAuthData.objet.AuthData.RefreshTokenCreationTime) {
                            var refTokenCreationTime = _ObjAuthData.objet.AuthData.RefreshTokenCreationTime;
                            var _date = refTokenCreationTime.split('/')[1].substring(5, 18);
                        }
                        var url = '/cir/refresh-user-formio?userid=' + encodeURIComponent(userPrincipalName) + '&refToken=' + refToken + '&silent=1' + '&refTokenCreationTime=' + _date;
                        deferredObject.resolve(url);
                    });
                });


            });
        });
        return deferredObject.promise();
    }

    function _UpdateUserToken(url, masterdataRequired) {
        var deferredObject = $.Deferred();
       
        updateCacheStatus("Validating user credentials...");
        _client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ""); // Azure auth
        
        $.ajax({
            type: 'GET',
            async: true,
            cache: false,
            url: url, //$('#userURL').val(),
            success: function (data) {
                
                if (data.ErrorCode != null || data.StatusCode != null)
                {
                    window.location.href = '/cir/Sign-Out';
                     
                }
                updateCacheStatus("Refreshing user informations...");
                console.log(data);
                var isLoggedIn = data.MobileUser !== null;
                if (isLoggedIn) {
                    __createCookie("__CirUserTokenRefTime", new Date(parseInt(data.AuthData.ExpiresOn.replace(/\//g, "").replace("Date(", "").replace(")", ""))));
                    dbtransaction.openDatabase(function () {
                        dbtransaction.addItemIntoTable({ objet: data, AuthTokenInfoID: "1" }, 'AuthTokenInfo', function () { console.log('AuthTokenInfo Added'); });
                    });
                    _client.currentUser = data.MobileUser;
                    _client.authData = data.AuthData.AccessToken; 
                    __createCookie("__CirUserToken", data.AuthData.AccessToken);
                    if (_client.currentUser) {
                        console.log(_client.currentUser);
                        _userAccessToken = _client.currentUser.mobileServiceAuthenticationToken;
                    }
                    _client.invokeApi('GetUserInfo', {
                        method: 'GET'
                    }).done(function (response) {
                        
                        _objUser = response.result;
                        if (!!_objUser && !!_objUser.appRoles && _objUser.appRoles.length == 0) {
                            window.location.href = '/cir/Sign-Out';
                        }
                        _userDisplayName = _objUser.displayName;
                        console.log(_objUser.appRoles);
                        console.log(_objUser);
                        //_objUser.userPrincipalName = "dhksi_vestas.com#EXT#@VestasDev.onmicrosoft.com";
                        _email = _objUser.userPrincipalName.split("@", 1);
                       
                        //CallClientApi("UserLastLogin/" + encodeURIComponent(_objUser.userPrincipalName), "POST", null).done(function (rsp) {
                        //   }).fail(function (err) {
                        //    //  console.log(err);

                        //});

                        //Saving user info
                        dbtransaction.openDatabase(function () {

                            dbtransaction.addItemIntoTable({ objet: _client.currentUser, roles: _objUser.appRoles, userInfo: _objUser, CurrentUserID: "1" }, 'CurrentUser', function () { });

                            //Saving access token with User details
                            dbtransaction.addItemIntoTable({ AccessToken: _userAccessToken, DisplayName: _userDisplayName, UserInfoID: "1", Pin: '', Email: _email[0] }, 'UserInfo', function () {
                                if (masterdataRequired != undefined && masterdataRequired != null && masterdataRequired == true) {
                                    MasterDataSync.SetSyncStatus('required', function () {
                                        deferredObject.resolve(_objUser);
                                    });
                                }
                                else {
                                    deferredObject.resolve(_objUser);
                                }
                            });
                        });

                        }, function (error) {
                          updateCacheStatus("error refreshing user informations");
                        console.log(error);
                        deferredObject.reject(error);
                    });
                }
                else {
                    updateCacheStatus("no mobile app user validated");
                    deferredObject.reject("no mobile app user");
                }
            },
            error: function (data) {
                
                updateCacheStatus("error while validating user credentials...");
                console.log(data.responseText);
                deferredObject.reject(data.responseText);
            },
            dataType: 'json'
        });

        return deferredObject.promise();
    }

    function _UpdateUserTokenFormIo(url, masterdataRequired) {
        
        var deferredObject = $.Deferred();
        updateCacheStatus("Validating user credentials...");
        var formioClient = new WindowsAzure.MobileServiceClient($('#FormIOMobileAppUrl').val(), $('#FormIOMobileAppId').val(), ""); // Azure auth
        
        $.ajax({
            type: 'GET',
            async: true,
            cache: false,
            url: url, //$('#userURL').val(),
            success: function (data) {
                
                if (data.ErrorCode != null || data.StatusCode != null) {
                    window.location.href = '/cir/Sign-In';

                }
                updateCacheStatus("Refreshing formio user informations...");
                var isLoggedIn = data.MobileUser !== null;
                if (isLoggedIn) {
                    dbtransaction.openDatabase(function () {
                        dbtransaction.addItemIntoTable({ objet: data, AuthTokenInfoID: "1" }, 'AuthTokenInfoFormio', function () { });
                    });
                    formioClient.currentUser = data.MobileUser;
                    formioClient.authData = __readCookie("__CirUserToken");//data.AuthData.AccessToken;
                    formioClient.invokeApi('UserData/GetUserInfo', {
                        method: 'GET'
                    }).done(function (response) {
                        var user = response.result;
                        if (!!user && !!user.appRoles && user.appRoles.length == 0) {
                            window.location.href = '/cir/Sign-Out';
                        }
                        var email = user.userPrincipalName.split("@", 1);

                        //Saving user info
                        dbtransaction.openDatabase(function () {

                            dbtransaction.addItemIntoTable({ objet: formioClient.currentUser, roles: user.appRoles, userInfo: user, CurrentUserID: "1" }, 'CurrentUserFormio', function () { });

                            //Saving access token with User details
                            dbtransaction.addItemIntoTable({ AccessToken: formioClient.currentUser.mobileServiceAuthenticationToken, DisplayName: user.displayName, UserInfoID: "1", Pin: '', Email: email[0] }, 'UserInfoFormio', function () {
                                if (masterdataRequired != undefined && masterdataRequired != null && masterdataRequired == true) {
                                    MasterDataSync.SetSyncStatus('required', function () {
                                        deferredObject.resolve(user);
                                    });
                                }
                                else {
                                    deferredObject.resolve(user);
                                }
                            });
                        });

                    }, function (error) {
                        updateCacheStatus("error refreshing user informations");
                        deferredObject.reject(error);
                    });
                }
                else {
                    updateCacheStatus("no mobile app user validated");
                    deferredObject.reject("no mobile app user");
                }
            },
            error: function (data) {
                
                updateCacheStatus("error while validating user credentials...");
                deferredObject.reject(data.responseText);
            },
            dataType: 'json'
        });

        return deferredObject.promise();
    }

    function _SetPIN() {
        var deferredObject = $.Deferred();
        if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
    || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) ___isMobile = true;
        if (___isMobile) {
            $.confirm({
                title: 'Select a PIN',
                confirmButtonClass: 'btn-success',
                cancelButton: false,
                content: '<div class="form-group" style="text-align:center"><label>NEW PIN</label><input autofocus="" maxlength="4" type="password" id="input-pin" pattern="[0-9]*" inputmode="numeric" class="form-control" style="font-size: 25px;text-align: center;height: 45px;width: 135px; margin-left: 50px"/><label>CONFIRM PIN</label><input autofocus="" type="password" maxlength="4" id="input-c-pin" pattern="[0-9]*" inputmode="numeric" class="form-control" style="font-size: 25px;text-align: center;height: 45px;width: 135px;  margin-left: 50px"/></div><p class="text-danger" style="display:none">The modal is prevented to close until the input is valid!</p>',
                onOpen: function () {
                    var pin = this.$b.find('input#input-pin');
                    pin.focus();
                },
                confirm: function () {
                    var pin = this.$b.find('input#input-pin');
                    var cpin = this.$b.find('input#input-c-pin');
                    var errorText = this.$b.find('.text-danger');
                    if (pin.val() == '') {
                        errorText.html('New PIN is required');
                        errorText.show();
                        return false;
                    } else {
                        if (pin.val().length != 4) {
                            errorText.html('Required Length is 4');
                            errorText.show();
                            return false;
                        }
                        else {
                            if (pin.val() != cpin.val()) {
                                errorText.html('New PIN and Confirm PIN not matching');
                                errorText.show();
                                return false;
                            }
                            else {
                                dbtransaction.openDatabase(function () {
                                    dbtransaction.addItemIntoTable({ objet: { PIN: pin.val() }, UserPinID: "1" }, 'UserPin', function () {
                                        console.log('UserPin Added');
                                        $.confirm({
                                            title: 'CIR offline app',
                                            content: 'Your PIN is saved',
                                            autoClose: 'confirm|3000',
                                            confirmButtonClass: 'btn-success',
                                            cancelButton: false,
                                            confirm: function () {
                                                __createCookieMiliSec("UserPin", 1, (60 * 1000 * 10));
                                                __createCookie("__InvalidPINCount", 0);
                                                deferredObject.resolve(true);
                                            }
                                        });
                                    });
                                });

                            }
                        }
                    }
                }
            });
        }
        else {
            setTimeout(function () { deferredObject.resolve(true); }, 1000);
        }
        return deferredObject.promise();
    }

    function _RefereshPin() {
        var deferredObject = $.Deferred();
        if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
|| /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) ___isMobile = true;

        if (___isMobile) {
            var PinReq = __readCookie("UserPin");
            if (PinReq != undefined && PinReq != null && PinReq == 1) {
                __createCookieMiliSec("UserPin", 1, (60 * 1000 * 10));
                __createCookie("__InvalidPINCount", 0);
                }
            else {
                dbtransaction.getItemfromTable('UserPin', function CurrentUser(UserPinData) {
                    if (UserPinData) {
                        var _UserPin = '';
                        console.log('Get user pin idb');
                        if (UserPinData.length > 0 && UserPinData[0].objet != undefined && UserPinData[0].objet.PIN != undefined) {
                            _UserPin = UserPinData[0].objet.PIN;
                        }
                        $.confirm({
                            title: 'PIN Required',
                            cancelButton: false,
                            confirmButtonClass: 'btn-success',
                            content: '<div class="form-group" style="text-align:center"><label>Enter PIN</label><input autofocus="" maxlength="4" type="password" id="input-pin" pattern="[0-9]*" inputmode="numeric" class="form-control" style="font-size: 25px;text-align: center;height: 45px;width: 135px; margin-left: 50px"/></div><p class="text-danger" style="display:none">The modal is prevented to close until the input is valid!</p>',
                            onOpen: function () {
                                var pin = this.$b.find('input#input-pin');
                                pin.focus();
                            },
                            confirm: function () {
                                var pin = this.$b.find('input#input-pin');
                                var errorText = this.$b.find('.text-danger');
                                if (pin.val() == '') {
                                    errorText.html('PIN is required');
                                    errorText.show();
                                    return false;
                                } else {
                                    if (pin.val().length != 4) {
                                        errorText.html('Required Length is 4');
                                        errorText.show();
                                        return false;
                                    }
                                    else {

                                        if (_UserPin == pin.val()) {
                                            console.log('UserPin Varified');
                                            __createCookieMiliSec("UserPin", 1, (60 * 1000 * 10));
                                            __createCookie("__InvalidPINCount", 0);
                                            deferredObject.resolve(true);
                                        }
                                        else {
                                            console.log('UserPin Varification failed');
                                            var __InvalidPINCount = __readCookie("__InvalidPINCount");
                                            if (__InvalidPINCount == undefined || __InvalidPINCount == null)
                                                __InvalidPINCount = 0;
                                            if (__InvalidPINCount <= 2) {
                                                __createCookie("__InvalidPINCount", __InvalidPINCount + 1);
                                                errorText.html('Invalid PIN');
                                                pin.val('');
                                                errorText.show();
                                                return false;
                                            }
                                            else {
                                                $.confirm({
                                                    title: 'CIR offline app',
                                                    confirmButtonClass: 'btn-success',
                                                    content: 'Reached Maximum numbers of atempt, please click okay to relogin',
                                                    cancelButton: false,
                                                    confirm: function () {
                                                        //deferredObject.reject(false);
                                                        dbtransaction.openDatabase(function () {
                                                            dbtransaction.deleteAllItemfromTable('UserInfo', function UserInfo(user) {
                                                                console.log('User Deleted');
                                                                dbtransaction.deleteAllItemfromTable('AuthTokenInfo', function () {
                                                                    console.log('AuthTokenInfo truncated');

                                                                    dbtransaction.deleteAllItemfromTable('CurrentUser', function UserInfo(user) {
                                                                        console.log('User Deleted');
                                                                        dbtransaction.deleteAllItemfromTable('UserPin', function UserInfo(user) {
                                                                            console.log('UserPin Deleted');
                                                                            window.location.href = '/cir/Sign-Out'; // User not authenticated
                                                                        });

                                                                    });

                                                                });
                                                            });
                                                        });
                                                    }
                                                });
                                            }
                                        }

                                    }
                                }
                            }
                        });
                    }
                    else {
                        $.confirm({
                            title: 'CIR offline app',
                            content: 'No User PIN found, please click okay to relogin',
                            cancelButton: false,
                            confirm: function () {
                               dbtransaction.openDatabase(function () {
                                    dbtransaction.deleteAllItemfromTable('UserInfo', function UserInfo(user) {
                                        console.log('User Deleted');
                                        dbtransaction.deleteAllItemfromTable('AuthTokenInfo', function () {
                                            console.log('AuthTokenInfo truncated');

                                            dbtransaction.deleteAllItemfromTable('CurrentUser', function UserInfo(user) {
                                                console.log('User Deleted');
                                                dbtransaction.deleteAllItemfromTable('UserPin', function UserInfo(user) {
                                                    console.log('UserPin Deleted');
                                                    window.location.href = '/cir/Sign-Out'; // User not authenticated
                                                });

                                            });

                                        });
                                    });
                                });
                            }
                        });
                    }
                });
            }
        }
        else {
            setTimeout(function () { deferredObject.resolve(true); }, 1000);
        }
        return deferredObject.promise();

    }
   
    function _Login() {
    updateCacheStatus("Validating user credentials...");
        $.when(_GetUserInfo(), _GetUserInfoFormio()).done(function () {
            if (Offline.state == "down") {
                updateCacheStatus("Redirecting...");
                RedirectToLandingPage();
            }
                  
            else {

                var checktest = 0;
                setTimeout(function () {
                    if (checktest == 0) {
                        $('#cirerrormsg').show();
                        checktest = 1;
                    }
                }, 120000);

                $.when(_GetUserCridentialURL(), _GetUserCridentialURLFormio()).done(function (oldAppUrl, newAppUrl) {
$.when(_UpdateUserToken(oldAppUrl), _UpdateUserTokenFormIo(newAppUrl)).done(function() {
                        RedirectToLandingPage();
                    }).fail(function(error) {
                        if (error.ErrorCode != null || error.StatusCode != null) {
                            window.location.href = '/cir/Sign-Out';
                        }
                        $('#cirProcessingSection').hide();
                        $('#add-re-login').click(function () {
                            window.location.href = '/cir/Sign-Out';
                        });
                    });
                });
            }
        }).fail(function () {
            updateCacheStatus("No valid user token found.");
            if (Offline.state == "down") {
                alert('you are offline, with no valid token')
            }
            else {
                if (!_code) {
                    updateCacheStatus("Redirecting to login page...");
                    var returnUrl = encodeURIComponent(document.URL);
                    window.location.href = '/cir/Sign-In?returnUrl=' + returnUrl;
                }
                else {
                    $.when(_UpdateUserToken($('#userURL').val()), _UpdateUserTokenFormIo($('#userURLFormio').val()))
                        .done(function() {
                            updateCacheStatus("User cridentials updated.");
                            $('#cirProcessingSection .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);
                            _SetPIN().done(function() {
                                MasterDataSync.Sync(true,
                                    function() {
                                        RedirectToLandingPage();
                                    },
                                    function() {
                                        alert("masterdata error");
                                    },
                                    function(progress) {
                                        var message = 'Downloading offline master data... ';
                                        $('#cirProcessingSection .progress-bar').css('width', progress.percentage + '%')
                                            .attr('aria-valuenow', progress.percentage);
                                        updateCacheStatus(message);
                                    });
                            });
                        }).fail(function(error) {
                            if (error.ErrorCode != null || error.StatusCode != null) {
                                window.location.href = '/cir/Sign-Out';
                            }
                            //$('#cirUnauthorized').show();
                            $('#cirProcessingSection').hide();
                            $('#add-re-login').click(function() {
                                window.location.href = '/cir/Sign-Out';
                            });
                        });
                }
            }
        });
    }

    function _RefereshUser(bForce) {
        var deferredObject = $.Deferred();
        var required = false;
        if (__RefreshingToken == true || bForce == undefined || bForce == null || bForce == false) {
            var lstTime = new Date(__readCookie("__CirUserTokenRefTime"));
            var timenow = new Date();
            if ((timenow - lstTime) < (60 * 1000 * 5)) {
                setTimeout(function () { deferredObject.resolve(""); }, 200);
            }
            else {
                required = true;
            }
        }
        else {
            required = true;
        }
        if (required) {
            __RefreshingToken = true;
            updateCacheStatus("Validating user credentials...");
            $.when(_GetUserInfo(), _GetUserInfoFormio()).done(function () {
                if (Offline.state == "down") {
                    __RefreshingToken = false;
                    deferredObject.reject();
                }
                else {
                    $.when(_GetUserCridentialURL(), _GetUserCridentialURLFormio()).done(function (oldAppUrl, newAppUrl) {
                        $.when(_UpdateUserToken(oldAppUrl), _UpdateUserTokenFormIo(newAppUrl)).done(
                            function(oldUserData, newUserData) {
                                //__createCookie("__CirUserTokenRefTime", new Date());
                                __RefreshingToken = false;
                                deferredObject.resolve(oldUserData);
                            }).fail(function(error) {
                            __RefreshingToken = false;
                            deferredObject.reject(error);
                        });
                    });
                }
            }).fail(function () {
                updateCacheStatus("No valid user token found.");
                if (Offline.state == "down") {
                    alert('you are offline, with no valid token');
                }
                else {
                    if (!_code) {
                        updateCacheStatus("Redirecting to login page...");
                        var returnUrl =  encodeURIComponent(document.URL);
                        window.location.href = '/cir/Sign-In?returnUrl=' + returnUrl;
                    }
                    else {
                        
                        $.when(_UpdateUserToken($('#userURL').val()), _UpdateUserTokenFormIo($('#userURLFormio').val()))
                            .done(function() {
                                updateCacheStatus("User cridentials updated.");
                                $('#cirProcessingSection .progress-bar').css('width', 0 + '%').attr('aria-valuenow', 0);
                                
                            }).fail(function(error) {
                                if (error.ErrorCode != null || error.StatusCode != null) {
                                    window.location.href = '/cir/Sign-Out';
                                }
                                //$('#cirUnauthorized').show();
                                $('#cirProcessingSection').hide();
                                $('#add-re-login').click(function() {
                                    window.location.href = '/cir/Sign-Out';
                                });
                            });
                    }

                }
                
                __RefreshingToken = false;
                deferredObject.reject("NOTOKEN");
            });
        }
        return deferredObject.promise();
    }

    UserCachingController.Login = _Login;

    UserCachingController.RefereshUser = _RefereshUser;

    UserCachingController.RefereshPin = _RefereshPin;
})(UserCachingController || (UserCachingController = {}));

