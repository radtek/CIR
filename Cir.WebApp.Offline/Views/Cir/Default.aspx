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
    <script src="../Js/jquery-confirm.min.js"></script>
    <script src="../Js/ApplicationScripts/AppCacheController.js"></script>
    <link href="../../Css/jquery-confirm.min.css" rel="stylesheet">
    <script src="../Js/ApplicationScripts/UserCachingController.js"></script>    
    <script>       
        // Set our options for the Offline detection library
        Offline.options = {
            checkOnLoad: true,
            checks: {
                image: {
                    url: function () {
                        return '../../Images/tiny-image.png?_=' + (Math.floor(Math.random() * 1000000000));
                    }
                },
                active: 'image'
            }
        }
        Offline.check();
    </script>
</head>
<body>
    <input type="hidden" id="MobAppURL" value="<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppURL"] %>" />
    <input type="hidden" id="MobAppID" value="<%= System.Configuration.ConfigurationManager.AppSettings["MobileAppID"] %>" />
    <input type="hidden" id="FormIOServiceUrl" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOServiceUrl"] %>" />
    <input type="hidden" id="FormIOMobileAppId" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOMobileAppId"] %>" />
    <input type="hidden" id="FormIOMobileAppUrl" value="<%= System.Configuration.ConfigurationManager.AppSettings["FormIOMobileAppUrl"] %>" />
    <input type="hidden" id="userURL" value="<%= Url.Action("referesh-user", "cir")%>" />
    <input type="hidden" id="userURLFormio" value="<%= Url.Action("refresh-user-formio", "cir")%>" />
    <div>
        <section class="content">
            <div class="row">
                <div class="col-md-4 col-md-offset-8" style="float: none; margin: 0 auto;">
                    <div id="cirProcessingSection">
                        <div class="modal-body">
                            <div class="col-xs-12" style="text-align: center;">
                                <img src="../Images/Vestas-Loading-Icon004_grey.gif" style="height: 50px; margin-bottom: 25px;"/>
                                <div class="progress" style="height: 4px">
                                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="0"
                                        aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                                    </div>
                                </div>
                                <p class="summary" id='appcachelog'>Checking for update...</p>
                            </div>
                        </div>
                    </div>
                    <div id="cirUnauthorized" style="display: none;">
                        <div class="modal-header">
                            <h5 class="modal-title">UNAUTHORIZED...</h5>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <div class="col-xs-12" style="text-align: center;">
                                    You are not authorized to use this application, please sign out and sign in again using an different account.
                                            <button id="add-re-login" class="btn btn-primary">Sign out</button>
                                </div>
                            </div>
                        </div>
                    </div>
                       <div id="cirerrormsg" style="display: none;">
                        <div class="modal-body">
                            <div class="form-group">
                                <div class="col-xs-12" style="text-align: center;color:red;font-weight:bold">
                                    <b> This is taking more time than usual, no reply from server. We will be working on it. Kindly try to login again in 20 mins.</b>
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
