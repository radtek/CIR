<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<ul class="sidebar-menu" id="side-menu">
    <li class="sidebar-search">
        <div class="input-group custom-search-form">
            <input type="text" id="txtSearchCirID" class="form-control boldOnChange" placeholder="CIR ID">
            <span class="input-group-btn">
                <button class="btn btn-default" id="linkCirSearch" type="button">
                    <i class="fa fa-search"></i>
                </button>
                <button class="btn btn-default down" id="cirSearchButton" type="button">
                    <i id="iconSearch" class="fa fa-chevron-circle-down down"></i>
                </button>
            </span>
        </div>


        <!-- /input-group -->
    </li>
    <li id="searchLi" style="display: none;">
        <a href="/Cir/Advanced-Search"><i class="fa fa-search AdvancedSearchMenu"></i><span>Advanced Search</span></a>
        <div style="padding: 2px 2px 2px 2px;">
            <input type="text" id="txtSearchCirName" placeholder="CIR Name" class="form-control  boldOnChange" />
            <input type="text" id="txtSearchCimCase" placeholder="CIM Case" class="form-control boldOnChange" />
            <select id="ddlSearchCirType" class="form-control boldOnChange">
                <option value="0">- Component Type -</option>
            </select>
            <select id="ddlSearchReportType" class="form-control boldOnChange">
                <option value="0">- Report Type -</option>
            </select>
            <input type="text" id="txtSearchCountry" placeholder="Country" class="form-control boldOnChange" />
            <input type="text" id="txtSearchSite" placeholder="Site Name" class="form-control boldOnChange" />
            <input type="text" id="txtSearchTurbineType" placeholder="Turbine Type" class="form-control boldOnChange" />
            <input type="text" id="txtSearchTurbineNumber" placeholder="Turbine Number" class="form-control boldOnChange" />
            <select id="ddlSearchRunStatus" class="form-control boldOnChange">
                <option value="0">- Run Status -</option>
            </select>
            <input type="text" id="txtSearchSBU" placeholder="SBU" class="form-control boldOnChange" />

        </div>
    </li>    
    <li class="administrator bircreator gircreator gbxircreator cirevaluator member editor contractorturbinetechnicians turbinetechnicians"><a href="/cir/local-history">
        <span>My Local History</span><i class="history icon" style="float: right"></i></a></li>
    <li class="administrator bircreator gircreator gbxircreator cirevaluator member editor contractorturbinetechnicians turbinetechnicians"><a href="/cir/formio-cir">
        <span>Create New CIR</span> <i class="add square icon" style="float: right"></i></a></li>
    <%--<li class="administrator bircreator gircreator gbxircreator cirevaluator member editor contractorturbinetechnicians turbinetechnicians CreatenewCirLink"><a href="/cir/manage-cir">
        <span>Create New CIR</span> <i class="add square icon" style="float: right"></i></a></li>--%>
    <li class="administrator bircreator gircreator gbxircreator member editor contractorturbinetechnicians turbinetechnicians viewer reportviewer visitor forallroles"><a href="/CirView/manage-cirviewlist">
        <i class="briefcase icon" style="float: right"></i><span>Manage CIR</span></a>
    </li>

    <li class="administrator bircreator gircreator gbxircreator member editor rptparent reportviewer"><a href="#Admin">
        <span>Reports</span> <i class="arrow down icon" style="float: right"></i></a>
        <ul class="nav nav-second-level inspection-ul">
            <li class="administrator bircreator member editor rptinspection reportviewer" id="birmenu"><a href="javascript:void(0);" title="Blade Inspection Report">
                <span>Blade Inspection </span><i class="arrow down icon" style="float: right"></i></a>
                <ul class="nav nav-second-level manage-create">
                    <li class="administrator bircreator member editor rptaction reportviewer">
                        <a href="/Cir/manage-bir" class="new-menu-anchor" title="Manage blade inspection Report">
                            <i class="glyphicon glyphicon-cog"></i><span>Manage</span>
                        </a>
                       <div class="administrator bircreator gircreator gbxircreator">
                        <a href="/CirView/manage-cirviewlist?rpt=bir" style="margin-top: 10px;" class=" new-menu-anchor" title="Create new blade inspection Report">
                            <i class="glyphicon glyphicon-plus !important"></i><span>Create</span>
                        </a>
                           </div>
                       
                         
                        <%-- <a class="closeInspection new-menu-anchor" href="javascript:void(0);" title="Close" >   
                    <i class="glyphicon glyphicon-remove"></i>
                 </a> --%>           
                    </li>
                </ul>   
            </li>
            <li class="administrator gircreator member editor rptinspection reportviewer" id="girmenu"><a href="javascript:void(0);" title="Generator Inspection Report">
                <span>Generator Inspection </span><i class="arrow down icon" style="float: right"></i></a>
                <ul class="nav nav-second-level manage-create">
                    <li class="administrator gircreator member editor rptaction reportviewer">
                        <a href="/Cir/Manage-GIR" class="new-menu-anchor" title="Manage Generator inspection Report">
                            <i class="glyphicon glyphicon-cog"></i><span>Manage</span>
                        </a>
                       <div class="administrator bircreator gircreator gbxircreator">
                        <a href="/CirView/manage-cirviewlist?rpt=gir"  style="margin-top: 10px;"  class="new-menu-anchor" title="Create new Generator inspection Report">
                            <i class="glyphicon glyphicon-plus !important"></i><span>Create</span>
                        </a>
                           </div>
                    </li>
                </ul>
            </li>
            <li class="administrator gbxircreator member editor rptinspection reportviewer" id="gbxirmenu"><a href="javascript:void(0);" title="Gearbox Inspection Report">
                <span>Gearbox Inspection </span><i class="arrow down icon" style="float: right"></i></a>
                <ul class="nav nav-second-level manage-create">
                    <li  class="administrator gbxircreator member editor rptaction reportviewer">
                        <a href="/Cir/Manage-GBXIR" class="new-menu-anchor" title="Manage Gearbox inspection Report">
                            <i class="glyphicon glyphicon-cog"></i><span>Manage</span>
                        </a>
                        <div class="administrator bircreator gircreator gbxircreator">
                        <a href="/CirView/manage-cirviewlist?rpt=gbxir" style="margin-top: 10px;" class="new-menu-anchor" title="Create new Gearbox inspection Report">
                            <i class="glyphicon glyphicon-plus !important"></i><span>Create</span>
                        </a>
                            </div>
                    </li>
                </ul>
            </li>
        </ul>
    </li>

    <li class="administrator bircreator gircreator gbxircreator member editor contractorturbinetechnicians turbinetechnicians viewer visitor reportviewer"><a href="/Cir/my-service-information">
        <span>Service Information </span><span id="sibadge" class="badge badge-error"></span><i class="info circle icon" style="float: right"></i></a></li>
    <li class="administrator rptparent"><a href="#Admin">
        <span name="Admin">Administration</span> <i class="arrow down icon" style="float: right"></i></a>
        <ul class="nav nav-second-level">
            <li><a href="/Cir/manage-user">
                <i class="users icon" style="float: right"></i><span>Manage Users</span></a>
            </li>
            <li><a href="/Cir/Manage-StandardText">
                <i class="file text icon" style="float: right"></i><span>Standard Texts</span></a></li>
            <li><a href="/Cir/feedback-list">
                <i class="comment outline icon" style="float: right"></i><span>Manage Feedback</span></a></li>
            <li><a href="/Cir/create-template">
                <i class="add square icon" style="float: right"></i><span>Create Template</span></a></li>
            <li><a href="/Cir/Service-Information">
                <i class="info outline icon" style="float: right"></i><span>Service Information</span></a></li>
            <li><a href="/Cir/manufacturer">
                <i class="truck icon" style="float: right"></i><span>Manage Manufacturer</span></a></li>
            <li><a href="/Cir/hotlist">
                <i class="fire icon" style="float: right"></i><span>Manage Hotlist</span></a></li>
            <li><a href="/Cir/System-Log">
                <i class="fa fa-file-code-o" style="float: right"></i><span>System Log</span></a></li>
            <li><a href="/Cir/Manage-Draft">
                <i class="fa fa-wrench" style="float: right"></i><span>Manage Draft/Error CIR</span></a></li>
        </ul>
    </li>


    <li class="administrator bircreator gircreator gbxircreator member editor contractorturbinetechnicians turbinetechnicians viewer visitor forallroles rptparent reportviewer"><a href="/Cir/Show-pdf" target="_blank">
        <span>Help</span><i class="arrow down icon" style="float: right"></i> </a>
        <ul class="nav nav-second-level">
            <li><a href="/Cir/Show-pdf" target="_blank">
                <i class="file text icon" style="float: right"></i><span>Technician User Guide</span></a>
            </li>
            <li><a href="/Cir/Show-pdf2" target="_blank">
                <i class="file text icon" style="float: right"></i><span>Tech. Support User Guide</span></a></li>
           <li><a href="https://trainingtube.vestas.com/channel/cir-creation-training/" target="_blank">
                <i class="file text icon" style="float: right"></i><span>CIR training movies</span></a></li>

             <li><a href="/Cir/Show-pdf3" target="_blank">
                <i class="file text icon" style="float: right"></i><span>Translated DE guide</span></a>
            </li>
            <li><a href="/Cir/Show-pdf4" target="_blank">
                <i class="file text icon" style="float: right"></i><span>Translated ES guide</span></a></li>

             <li><a href="#" onclick="openKnownIssuesPdf()">
                <i class="file text icon" style="float: right"></i><span>Known Issues</span></a></li>

             <li><a href="#" onclick="openCreateNewCIRRequestWindow()">
                <i class="file text icon" style="float: right"></i><span>Request access to create a CIR</span></a>
            </li>
            <li>
                <a href="https://trainingtube.vestas.com/channel/cir-creation-training/?c=clearing-cache-of-cir-application" target="_blank">
                <i class="file text icon" style="float: right"></i><span>Cache Cleaning Video</span></a>

            </li>
        </ul>

    </li>
  
    <li class="administrator bircreator gircreator gbxircreator member editor contractorturbinetechnicians turbinetechnicians viewer visitor forallroles reportviewer"><a href="/Cir/manage-feedback">
        <span>Feedback</span><i class="comment outline icon" style="float: right"></i></a></li>
    <li class="dropdown user-dropdown">
        <a href="#User" class="dropdown-toggle" data-toggle="dropdown">
            <i class="user icon"></i><span id="spEmail"></span><b class="caret"></b></a>
        <ul class="nav nav-second-level">
            <li id="lichangepin"><a href="MobileUnlockPage?Mode=1"><i class="fa fa-unlock-alt" style="float: right"></i>&nbsp;Change Pin</a></li>
            <li id="lichangepindiv" class="divider"></li>
            <li><a style="cursor: pointer" onclick="MasterDataSync.SyncWithoutCir();" data-target="#MasterDataModal" data-toggle="modal" data-backdrop="static" data-keyboard="false"><i class="loadersign" style="float: right"></i>&nbsp;Sync Master</a></li>
            <li class="divider"></li>
            <li><a href="#" onclick='clearElectronCache()' id="linkClearCache"><i class="fa fa-eraser" style="float: right"></i>&nbsp;Clear Offline Data</a></li>
            <li><a href="/cir/Sign-Out" id="linkLogout"><i class="fa fa-power-off" style="float: right"></i>&nbsp;Log Out</a></li>
        </ul>
    </li>
</ul>

<div class="modal fade" id="OfflineModal" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-sm" style="max-width: 300px">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">CIR Offline</h5>
            </div>
            <div class="modal-body">
                <h5 style="margin: 0;">This feature is available only when you are online</h5>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
            </div>
        </div>
    </div>
</div>
 
<script type="text/javascript">
    //Set Highlighted selected menu
    function showcontrolaccess(role) {
        if (hasRole(role)) {
            $('.' + role.toLowerCase().replace(/ /g, '')).show();
        }

        $('.' + 'forallroles'.toLowerCase().replace(/ /g, '')).show();
    }

    function openCreateNewCIRRequestWindow()
    {
        window.open("http://teamsitesemea.vestas.net/sites/43010/shareddocuments/How%20to%20Request%20Access%20to%20CIR.vestas.com.pdf", ' _blank');
    }

    function openKnownIssuesPdf()
    {
        window.open("http://teamsitesemea.vestas.net/sites/43010/shareddocuments/Known_Issues_CIR_appl.pdf", ' _blank');

    }


    function clearElectronCache() {
        if (window.isElectronApp) {
            CirAlert.confirm('Please be aware you will loose all the not synced data. Are you sure to clear all offline data?', 'Cir App', 'Yes', 'No', 'warning').done(function () {
                window.clearCache();
            });
        }
    }

    $(document).ready(function () {
        $(".CreatenewCirLink").click(function (e) {
            e.preventDefault();
            cirOfflineApp.getLocalDraftCount().done(function (count) {
                     window.location.href = '/cir/formio-cir';
                
            });
        });

        $('#side-menu').click(function (e) {
            if (!!document.formioForm && document.formioForm.className.match('ng-dirty') && document.location.href.toString().toLowerCase().indexOf('formio-cir') > -1) {
                if (!confirm('Unsaved data will be lost. Are you sure you want to quit?')) {
                    return false;
                }
            }            
        });

        LoadUserInfo().done(function () {
            //$('#displayUser').text(CurrentUserInfo.UserDisplayName);
            $('#spEmail').text(CurrentUserInfo.UserDisplayName);
            $('#hdnUserPrincipal').val(CurrentUserInfo.UserPrincipleName);
            jQuery.each(AllRoles, function (i, val) {
                showcontrolaccess(val);
            });
            if (hasRole("BirCreator") == false && hasRole("Administrator") == false && hasRole("Editor") == false && hasRole("Member") == false && hasRole("Report Viewer") == false)
            {
                $('#birmenu').remove();
            }
            if (hasRole("GirCreator") == false && hasRole("Administrator") == false && hasRole("Editor") == false && hasRole("Member") == false && hasRole("Report Viewer") == false) {
                $('#girmenu').remove();
            }
            if (hasRole("GBXirCreator") == false && hasRole("Administrator") == false && hasRole("Editor") == false && hasRole("Member") == false && hasRole("Report Viewer") == false) {
                $('#gbxirmenu').remove();
            }
        });

        $('#side-menu a').click(function (e) {
            if (Offline.state == "down") {
                if ($(this).attr('href') != '/cir/local-history' && $(this).attr('href') != '/Cir/my-service-information' && $(this).attr('href') != '/cir/manage-cir' && $(this).attr('href') !== '/cir/formio-cir') {
                    CirAlert.alert('You need to be Online in order to user this link', 'Cir App - User Offline', null, 'error').done(function () {
                        return false;
                    });
                    return false;
                }
            }
        });

        $('#linkLogout').click(function (e) {
            e.preventDefault();
            dbtransaction.openDatabase(function () {
                dbtransaction.deleteAllItemfromTable('UserInfo', function UserInfo(user) {
                    console.log('User Deleted');
                    dbtransaction.deleteAllItemfromTable('AuthTokenInfo', function () {
                        console.log('AuthTokenInfo truncated');

                        dbtransaction.deleteAllItemfromTable('CurrentUser', function UserInfo(user) {
                            console.log('User Deleted');
                            window.location.href = '/cir/Sign-Out'; // User not authenticated
                        });

                    });
                });
            });

        });
        $(".sidebar-menu li").each(function (index) {
            var href = $(this).find("a").attr("href");//.toLowerCase();
            if (location.href.toString().toLowerCase().indexOf(href) > 0) {
                $(this).addClass("active");
                return;
            }
        });

        if (!window.isElectronApp) {
            $('#linkClearCache').hide();
        }

    });


</script>
<script>
    $(document).ready(function () {

        $('.rptparent').click(function () {
            $(".rptparent").find(':first i').removeClass('arrow up icon').addClass('arrow down icon');

            if ($(this).hasClass("active")) {
                $(this).find(":first i").removeClass('arrow down icon').addClass('arrow up icon');
            }
            else {
                $(this).find(":first i").removeClass('arrow up icon').addClass('arrow down icon');
                //$(".rptinspection.active :first i").removeClass('arrow up icon').addClass('arrow down icon');
            }
        });

        $(".rptinspection").click(function () {

            //$(".rptinspection").find(':first i').each(function () {
            //    $(this).removeClass('arrow up icon').addClass('arrow down icon');
            //});

            $(".rptinspection").find(':first i').removeClass('arrow up icon').addClass('arrow down icon');

            if ($(this).hasClass("active")) {
                $(this).find(":first i").removeClass('arrow down icon').addClass('arrow up icon');
            }
            else {
                $(this).find(":first i").removeClass('arrow up icon').addClass('arrow down icon');
                //$(".rptinspection.active :first i").removeClass('arrow up icon').addClass('arrow down icon');
            }
        })


    });
    //$(document).ready(function () {
    //    $(".rpt-parent").click(function () {

    //        if ($(".rpt-parent").parent().hasClass("active")) {
    //            $(".inspection-ul").css("display", "block");
    //            $(".manage-create").css("display", "none");
    //        }
    //        else {
    //            $(".inspection-ul").css("display", "none");
    //            $(".manage-create").css("display", "none");
    //        }
    //    });
    //    $(".rptinspection").click(function () {               
    //        $(".inspection-ul").css("display", "none");
    //        //$(".manage-create").css("display", "block");
    //        $(".manage-create").show('slide', { direction: 'right' }, 100)
    //    });
    //    $(".closeInspection").click(function () {             

    //        $(".inspection-ul").show('slide', { direction: 'left' }, 100);
    //        //$(".inspection-ul").css("display", "block");
    //        $(".manage-create").css("display", "none");
    //    });

    //});
</script>
