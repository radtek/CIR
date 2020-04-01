<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html manifest="/manifest.appcache">
<head runat="server">
    <meta charset='utf-8' />
    <meta name="viewport" content="width=device-width" />
    <title>Default</title>
    <%= Styles.Render("~/bundles/css-admin") %>
    <script src="../Js/jquery-1.10.1.min.js"></script>
    <script src="../Js/jquery-ui-1.10.3.js"></script>
    <script src="../Js/jquery-ui-1.10.3.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/jquery.validate.min.js"></script>
    <script src="../Js/jquery.validate.unobtrusive.min.js"></script>
    <script src="../Js/jquery-ui.js"></script>
    <script src="../Js/ApplicationScripts/modernizr-2.6.2.js"></script>
    <script src="../Js/ApplicationScripts/common.js"></script>

    <%--Notify--%>
    <script src="../Js/Notify/bootstrap-notify.js"></script>
    <script src="../Js/Notify/bootstrap-notify.min.js"></script>
    <%------%>
    <script src="../Js/encryption/sjcl.js"></script>
    <script src="../Js/metisMenu.min.js"></script>
    <script src="../Js/app.js"></script>
    <script src="../Js/common.admin.js"></script>
    <script src="../Js/ApplicationScripts/indexeddb.shim.min.js"></script>

    <script src="../Js/ApplicationScripts/offlineTransactions.js"></script>
    <script src="../Js/MobileApp/MobileService.js"></script>
     <script src="../Js/ApplicationScripts/MasterData.js"></script>
     <script src="../Js/OfflineJs/offline.min.js"></script>

    <%--<script src='http://ajax.aspnetcdn.com/ajax/mobileservices/MobileServices.Web-2.0.0-beta.min.js'></script>--%>

    <script>
        $(document).ready(function () {
            var userAccessToken, userDisplayName = '', email = '';
            var client = new WindowsAzure.MobileServiceClient('<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppURL"] %>', '<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppID"] %>', ''); // Azure auth
            var objUser;
            var code = GetQueryStringParams('code');
           


            $('#cirLoginSection').hide();
            $('#loadingSpan').text('Loading CIR Web Application');

            // Login click
            $('#add-login').click(function () {
                if (!code) {
                    window.location.href = '/cir/Sign-In';
                }
                else {
                    $.ajax({
                        type: 'GET',
                        async: true,
                        cache: false,
                        url: '<%= Url.Action("referesh-user", "cir")%>',
                        success: function (data) {
                            console.log(data);
                            var isLoggedIn = data.MobileUser !== null;
                            if (isLoggedIn) {
                                dbtransaction.openDatabase(function () {
                                    dbtransaction.addItemIntoTable({ objet: data, AuthTokenInfoID: "1" }, 'AuthTokenInfo', function () { console.log('AuthTokenInfo Added'); });
                                });
                                client.currentUser = data.MobileUser;
                                if (client.currentUser) {
                                    console.log(client.currentUser);
                                    userAccessToken = client.currentUser.mobileServiceAuthenticationToken;
                                }
                                client.invokeApi('GetUserInfo', {
                                    method: 'GET'
                                }).done(function (response) {
                                    $('#cirLoginSection').hide();
                                    $('#cirProcessingSection').show();
                                    $('#loadingSpan').text('Synchronizing Cir Master Data');

                                    objUser = response.result;
                                    userDisplayName = objUser.displayName;
                                    console.log(objUser.appRoles);
                                    console.log(objUser);
                                    email = objUser.userPrincipalName.split("@", 1);
                                    //Saving user info
                                    dbtransaction.openDatabase(function () {

                                        dbtransaction.addItemIntoTable({ objet: client.currentUser, roles: objUser.appRoles, userInfo: objUser, CurrentUserID: "1" }, 'CurrentUser', function () { });

                                        //USer PIN inseter 
                                        dbtransaction.deleteAllItemfromTable('UserPin', function () { console.log('UserPin truncated'); });
                                        dbtransaction.addItemIntoTable({ UserPinID: Date.now(), Pin: '' }, 'UserPin', function () { });

                                        //Saving access token with User details
                                        dbtransaction.addItemIntoTable({ AccessToken: userAccessToken, DisplayName: userDisplayName, UserInfoID: "1", Pin: '', Email: email[0] }, 'UserInfo', function () {
                                          

                                            //above line is commented to skip sync masterdata. it will be sync on matser page 
                                            MasterDataSync.SetSyncStatus('required', function () {
                                                setTimeout(function () {
                                                    $('#cirProcessingSection').hide();
                                                    RedirectToLandingPage();
                                                }, 30);
                                            });
                                            setTimeout(function () {
                                                $('#cirProcessingSection').hide();
                                                RedirectToLandingPage(); // User authenticated
                                            }, 3000);
                                        });
                                    });

                                }, function (error) {
                                    console.log(error);
                                });
                            }  
                            else {

                            }
                        },
                        error: function (data) {
                            console.log(data.responseText);
                            if (data.ErrorCode != null || data.StatusCode != null) {
                                window.location.href = '/cir/Sign-Out';
                            }
                            $('#cirLoginSection').hide();
                            $('#cirProcessingSection').hide();
                            $('#add-re-login').click(function () {
                                window.location.href = '/cir/Sign-Out';
                            });
                        },
                        dataType: 'json'
                    });
                }
            });

            if (Offline.state == "down") { // If user is offline
                dbtransaction.openDatabase(function () {
                    dbtransaction.getItemfromTable('UserInfo', function UserInfo(user) {
                        console.log(user);
                        if (user) {
                            if (user.length > 0) {
                                user.forEach(function (item) {
                                    console.log(item.AccessToken);
                                    if (item.AccessToken && item.AccessToken != '') {
                                        RedirectToLandingPage(); // User authenticated
                                    }
                                });
                            }
                            else {
                                Log('Current user not exists');
                                $('#cirProcessingSection').hide();
                                $('#cirLoginSection').fadeIn(500);
                            }
                        }
                        else {
                            Log('Current user null');
                            $('#cirProcessingSection').hide();
                            $('#cirLoginSection').fadeIn(500);
                        }
                    });
                });
            }
            else { // if user is online
                var ObjAuthData;
                var ObjCurUser;
                dbtransaction.openDatabase(function () {
                    console.log('Connection open');
                    dbtransaction.getItemfromTable('AuthTokenInfo', function AuthTokenInfo(AuthTokenInfoData) {
                        if (AuthTokenInfoData) {
                            console.log('Get AuthTokenInfo');
                            if (AuthTokenInfoData.length > 0) {
                                AuthTokenInfoData.forEach(function (item) {
                                    ObjAuthData = item;
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
                                        ObjCurUser = item;
                                        console.log(item);
                                    });
                                }
                            }
                            else {
                                Log('CurrentUser null');
                            }
                            if (ObjCurUser && ObjCurUser.userInfo && ObjCurUser.userInfo.userPrincipalName)
                                var userPrincipalName = ObjCurUser.userInfo.userPrincipalName;
                            if (ObjAuthData && ObjAuthData.objet && ObjAuthData.objet.AuthData && ObjAuthData.objet.AuthData.RefreshToken)
                                var refToken = ObjAuthData.objet.AuthData.RefreshToken;
                            if (_ObjAuthData && _ObjAuthData.objet && _ObjAuthData.objet.AuthData && _ObjAuthData.objet.AuthData.RefreshTokenCreationTime)
                            {
                                var refTokenCreationTime = _ObjAuthData.objet.AuthData.RefreshTokenCreationTime;
                                var _date = refTokenCreationTime.split('/')[1].substring(5, 18);
                            }
                            
                            $.ajax({
                                type: 'GET',
                                async: true,
                                cache: false,
                                url: '/cir/referesh-user?userid=' + userPrincipalName + '&refToken=' + refToken + '&silent=1' + '&=refTokenCreationTime' + _date,
                                success: function (data) {                                  
                                        console.log(data);
                                        var isLoggedIn = data.MobileUser !== null;
                                        if (isLoggedIn) {
                                            dbtransaction.openDatabase(function () {
                                                dbtransaction.deleteAllItemfromTable('AuthTokenInfo', function () { console.log('AuthTokenInfo truncated'); });
                                                dbtransaction.addItemIntoTable({ objet: data, AuthTokenInfoID: "1" }, 'AuthTokenInfo', function () { console.log('AuthTokenInfo Added'); });
                                            });
                                            client.currentUser = data.MobileUser;
                                            if (client.currentUser) {
                                                console.log(client.currentUser);
                                                userAccessToken = client.currentUser.mobileServiceAuthenticationToken;
                                            }
                                            client.invokeApi('GetUserInfo', {
                                                method: 'GET'
                                            }).done(function (response) {

                                                objUser = response.result;
                                                userDisplayName = objUser.displayName;
                                                console.log(objUser.appRoles);
                                                console.log(objUser);
                                                email = objUser.userPrincipalName.split("@", 1);
                                                //Saving user info
                                                dbtransaction.openDatabase(function () {
                                                    dbtransaction.addItemIntoTable({ objet: client.currentUser, roles: objUser.appRoles, userInfo: objUser, CurrentUserID: "1" }, 'CurrentUser', function () { });
                                                    //Saving/Updating access token with User details
                                                    dbtransaction.addItemIntoTable({ AccessToken: userAccessToken, DisplayName: userDisplayName, UserInfoID: "1", Pin: '', Email: email[0] }, 'UserInfo', function () {
                                                    });
                                                    console.log(objUser.displayName);
                                                    RedirectToLandingPage(); // User authenticated
                                                });

                                            }, function (error) {
                                                console.log(error);
                                                if (code) {
                                                    $('#add-login').click();
                                                }
                                                else {
                                                    Log(error);
                                                    $('#cirProcessingSection').hide();
                                                    $('#cirLoginSection').fadeIn(500);
                                                    window.location.href = '/cir/Sign-In';
                                                }
                                            });
                                        }
                                        else {
                                            if (code) {
                                                $('#add-login').click();
                                            }
                                            else {
                                                Log('Current user not exists');
                                                $('#cirProcessingSection').hide();
                                                $('#cirLoginSection').fadeIn(500);
                                                window.location.href = '/cir/Sign-In';
                                            }
                                        }                                   
                                },
                                error: function (data) {
                                    console.log(data.responseText);
                                    if (code) {
                                        $('#add-login').click();
                                    }
                                    else {
                                        $('#cirProcessingSection').hide();
                                        $('#cirLoginSection').fadeIn(500);
                                        window.location.href = '/cir/Sign-In';
                                    }
                                },
                                dataType: 'json'
                            });
                        });
                    });
                });
            }
        });
        function Log(logMessage) {
            return true;
            $('#logBody').append(logMessage);
            $('#logBody').append("</br>");
        }
        // Bootstrap notification pop-up
        function NotifyMe(title, message, type) {
            $.notify({
                // options
                icon: 'glyphicon glyphicon-warning-sign',
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
                delay: 5000,
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
                template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                    '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                    '<span data-notify="icon"></span> ' +
                    '<span data-notify="title">{1}</span> ' +
                    '<span data-notify="message">{2}</span>' +
                    '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                    '</div>' +
                    '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
            });
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
        function checkOnline()
        {
            if (Offline.state == "down") { // If user is offline
                dbtransaction.openDatabase(function () {
                    dbtransaction.getItemfromTable('UserInfo', function UserInfo(user) {
                        console.log(user);
                        if (user) {
                            if (user.length > 0) {
                                user.forEach(function (item) {
                                    console.log(item.AccessToken);
                                    if (item.AccessToken && item.AccessToken != '') {
                                        console.log('Connection Offline..Taking to Local History');
                                        window.location.href = '/cir/local-history';
                                    }
                                });
                            }
                          
                        }                       
                    });
                });
            }
            else { // if user is online
               
            }
        }

    </script>
</head>
<body>
    <input type="hidden" id="MobAppURL" value="<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppURL"] %>" />
    <input type="hidden" id="MobAppID" value="<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppID"] %>" />
    <input type="hidden" id="FormIOServiceUrl" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOServiceUrl"] %>" />
    <input type="hidden" id="FormIOMobileAppId" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOMobileAppId"] %>" />
    <input type="hidden" id="FormIOMobileAppUrl" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOMobileAppUrl"] %>" />
    <div>
        <section class="content">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div class="well well-White">
                        <div class="bs-example form-horizontal">
                            <div id="cirLoginSection" style="display: none;">
                                <div id="LoginDiv" class="ui-corner-all">
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: center;">
                                            You are not logged in :
                                            <button id="add-login" style="display: none;" class="btn btn-primary">Log in</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="cirUnauthorized" style="display: none;">
                                <div id="UnauthorizedLoginDiv" class="ui-corner-all">
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: center;">
                                            You are not authorized to use this application, please sign out and sign in again using an different account.
                                            <button id="add-re-login" class="btn btn-primary">Sign out</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="LoggingSection" style="display: block;">
                                <div class="ui-corner-all">
                                    <div class="form-group">
                                        <div class="col-xs-12" id="logBody" style="text-align: center;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="cirProcessingSection" style="display: block;">
                                <div id="loading-div" class="ui-corner-all">
                                    <div class="form-group">
                                        <div class="col-xs-12" style="text-align: center;">
                                            <img style="height: 25px; width: 150px;" src="/images/cir-loader.gif" alt="Loading.." /><br>
                                            <strong><span id="loadingSpan" style="font-size: medium">Loading Cir Web Application</span><br />
                                                Please wait</strong>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</body>
</html>
