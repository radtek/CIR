<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <script src="../Js/swapelement.js"></script>
    <script src="../Js/ApplicationScripts/CirView.js"></script>

    <style>
        .notvisible {
            display: none;
        }

        .form-control-small {
            text-align: center;
        }

        .col-sm-2 {
            padding-left: 2px;
            padding-right: 2px;
        }

        .btnselectview {
            min-width: 250px;
        }

        .input-group {
            min-width: 250px;
            max-width: 250px;
        }

        .divblocks .close {
            right: 11%;
            top: 2px;
            position: absolute;
            background-color: #ff0000;
            opacity: .8;
            background-color: #ff0000;
            font-size: 22px;
            z-index: 1000;
            border-radius: 50%;
            padding: 2px;
            line-height: 15px;
        }
    </style>
    <section class="content" style="background: transparent">

        <div class="well well-White">
            <div class="row">
                <div class="col-xs-12">
                    <div class="navbar-left navbar-SubHead">
                        <%if (ViewBag.ViewId > 0)
                          {%>
                            Edit CIR View     
                        <%}
                          else
                          { %>     
                           Create CIR View     
                        <%} %>
                    </div>
                </div>
            </div>

            <ul class="nav nav-tabs">
                <li class="active"><a href="#menu1">Modify Filter</a></li>
                <li><a href="#menu2">Modify View</a></li>
            </ul>

            <div class="tab-content">
                <div id="menu1" class="tab-pane fade in active">
                    <div class="bs-example form-horizontal">
                        <div id="divViewFiter">
                            <div class="panel panel-default">
                                <div class="panel-header">
                                    <label class="control-label">&nbsp;&nbsp;Please fill in the Filter details</label>
                                </div>
                                <div class="panel-body">
                                    <fieldset>
                                        <legend>General</legend>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label"><span class="errorSpan">*</span>Name</label>
                                            <div class="col-lg-4">
                                                <input type="text" id="txtViewName" class="form-control" placeholder="View Name" data-toggle="tooltip"
                                                    data-placement="top" title="Enter View Name" />
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <input id="chkPublicView" type="checkbox" name="chkPublicView" class="form-control" /><label for="chkPublicView">&nbsp;Public view</label>
                                                    </div>
                                                    <div class="administrator col-lg-6">
                                                        <input id="chkInspectionApplicable" type="checkbox" name="chkInspectionApplicable" class="form-control chkreport" /><label for="chkInspectionApplicable">&nbsp;Applicable for Blade Report</label>
                                                    </div>
                                                    </div>
                                                <div class="row">
                                                    <div class="administrator col-lg-6">
                                                        <input id="chkGeneralInspectionApplicable" type="checkbox" name="chkGeneralInspectionApplicable" class=" form-control chkreport" /><label for="chkGeneralInspectionApplicable">&nbsp;Applicable for Generator Report</label>
                                                    </div>
                                                    <div class="administrator col-lg-6">
                                                        <input id="chkGBXInspectionApplicable" type="checkbox" name="chkGBXInspectionApplicable" class="form-control chkreport" /><label for="chkGBXInspectionApplicable">&nbsp;Applicable for Gearbox Report</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <br />
                                    <fieldset>
                                        <legend>Filtering</legend>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Quick Filter : </label>
                                            <div class="col-lg-4">
                                                <select name="ddlQuickFilter" id="ddlQuickFilter" class="form-control">
                                                    <option value="0"></option>
                                                </select>
                                            </div>

                                            <div class="col-lg-5">
                                                <select name="FilterMatchAll" id="FilterMatchAll" class="form-control">
                                                    <option value="true">Match all filters</option>
                                                    <option value="false">Match any filter</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <table id="FilterDiv" class="form-group" width="100%">
                                                <tr id="FilterDivRow">
                                                    <td>&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <label class="col-lg-2 control-label">Filter By : </label>
                                                        <div class="col-lg-4">
                                                            <select class="ddlFilterField form-control">
                                                                <option value="0"></option>
                                                            </select>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <select class="ddlFilterNegate form-control">
                                                                <option value="equal">Equals</option>
                                                                <option value="notEqual">Does not equal</option>
                                                                <option value="in">In</option>
                                                                <option value="notIn">Not in</option>
                                                                <option value="contains">Contains</option>
                                                            </select>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <input type="text" class="FilterValue form-control" maxlength="50" />

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <a href="javascript:void(0);" id="AddFilter" title="Add Filter" class="btn btn-primary">+</a>
                                                            <a href="javascript:void(0);" id="DeleteFilterRow" title="Remove Filter" class="notvisible btn btn-primary">X</a>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>


                                    </fieldset>



                                    <br />
                                    <fieldset>
                                        <legend>Ordering</legend>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Order By :</label>
                                            <div class="col-lg-4">
                                                <select name="ddlOrderFields" id="ddlOrderFields" class="form-control">
                                                </select>
                                            </div>
                                            <div class="col-lg-4">
                                                <select name="ddlSort" id="ddlSort" class="form-control">
                                                    <option value="true">Ascending</option>
                                                    <option value="false">Descending</option>

                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Results per Page :</label>
                                            <div class="col-lg-4">
                                                <select name="ddlResultsPerPage" id="ddlResultsPerPage" class="form-control">
                                                    <option value="10">10</option>
                                                    <option value="20">20</option>
                                                    <option value="50">50</option>
                                                    <option value="100">100</option>
                                                </select>

                                            </div>
                                        </div>
                                    </fieldset>
                                    <br />
                                    <div class="form-group">

                                        <div class="col-lg-12">
                                            <a href="<%:Url.Action("manage-cirviewlist", "CirView")  %>" class="linkCancel btn btn-primary">Cancel</a>
                                            <a href="javascript:void(0);" disabled class="btnDelete btn btn-primary">Delete</a>
                                            <a href="javascript:void(0);" disabled class="btnSaveView btn btn-primary">Save</a>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <div id="menu2" class="tab-pane fade">
                    <div class="bs-example form-horizontal">
                        <div class="panel panel-default">
                            <div class="panel-header">
                                <label class="control-label">&nbsp;&nbsp;Select a field by adding a number in the text box according to column order in your view.</label>
                            </div>
                            <div class="panel-body">

                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-default template">
                                        <div class="panel-heading accordion-toggle" style="cursor: pointer" data-toggle="collapse" data-parent="#accordion" data-target="#Fields">
                                            <h4 class="panel-title">
                                                <b>Currently Selected Fields</b> &nbsp;(<i>To change order click <i style="color: #000; cursor: pointer" class="fa fa-angle-double-left fa-sm"></i>&nbsp;<i style="color: #000; cursor: pointer" class="fa fa-angle-double-right fa-sm"></i> to move fields left or right</i>)

                                            </h4>
                                        </div>
                                        <div id="Fields" class="panel-collapse collapse in">
                                            <div class="panel-body" id="FieldData_1">
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="form-group">

                                    <div class="col-lg-12">
                                        <a href="<%:Url.Action("manage-cirviewlist", "CirView")  %>" class="linkCancel btn btn-primary">Cancel</a>
                                        <a href="javascript:void(0);" disabled class="btnDelete btn btn-primary">Delete</a>
                                        <a href="javascript:void(0);" disabled class="btnSaveView btn btn-primary">Save</a>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <input type="hidden" id="hdnUserInitial" />
    <input type="hidden" id="hdnUserRole" />



    <script type="text/javascript">
        var $template = $(".template");
        var hash = 1;

        function AddPanel(groupChar) {
            // console.log(groupChar + " Adding..");
            var $newPanel = $template.clone();
            $newPanel.find(".collapse").removeClass("in");
            $newPanel.find(".accordion-toggle").attr("data-target", "#" + (++hash))
                     .html("<b><i>" + groupChar + "</i></b>");
            $newPanel.find(".panel-collapse").attr("id", hash).addClass("collapse").removeClass("in");
            $("#accordion").append($newPanel.fadeIn());

            $("#" + hash).find("div").html("");
            $("#" + hash).find("div").attr("id", "FieldData_" + hash);
            // console.log(groupChar + " Added");
        }
        function ScrollTo(item) {
            $('html,body').animate({
                scrollTop: $("#" + item).offset().top - 45
            }, 'slow');
        }

        function limit(element) {
            var max_chars = 2;

            if (element.value.length > max_chars) {
                element.value = element.value.substr(0, max_chars);
            }
        }
    </script>
    <script type="text/javascript">
        var View = null;
        var AllFieldData = null;
        $(document).ready(function () {
            //Load View
            var ViewId = "<%:ViewBag.ViewId %>";
            if (ViewId) {
                loadView(ViewId);
            }
            else {

                NotifyCirMessage('Error Invalid ViewId ', error.message, 'danger');
            }

            //Load User
            LoadUserInfo().done(function () {
                if (CurrentUserInfo) {
                    if (ViewId > 0) {
                        $(".btnDelete").removeAttr('disabled');
                    }
                    else {
                        $(".btnDelete").hide();
                    }
                    $(".btnSaveView").removeAttr('disabled');
                }
            });
           
            function ChkViewID(callmethod, chkboxctrl, findprevcontrol) {
                
                CallClientApi(callmethod, "GET", null).done(function (result) {
                    var cirHead = "";
                    if (ViewId != result) {
                        CirAlert.confirm("View is already tagged for a report, do you want to override it ?", 'Cir App', 'Yes', 'No', 'warning').done(function () {
                            chkboxctrl.iCheck('check');
                        }).fail(function (e) {
                            chkboxctrl.iCheck('uncheck');
                            findprevcontrol.iCheck('check');
                            });
                    }
                    else {
                        chkboxctrl.iCheck('check');
                    }
                });

            }

            $(".chkreport").on('ifClicked', function () {
                var findprevcontrol;
                var id = this.id;
                
                $('input.chkreport').each(function () {
                    if ($('#' + this.id).iCheck('update')[0].checked == true && (id != this.id)) {
                        findprevcontrol = $('#' + this.id);
                    }
                });

                $('input.chkreport').each(function () {
                    if (id != this.id) {
                        $('#' + this.id).iCheck('uncheck');
                    }
                    else {
                                    var callmethod, boolViewID = true, chkvalue = this.id;
                                    if (chkvalue == 'chkInspectionApplicable') {
                                        callmethod = 'GetBIRViewId';
                                    }
                                    else if (chkvalue == 'chkGeneralInspectionApplicable') {
                                        callmethod = 'GetGIRViewId';
                                    }
                                    else if (chkvalue == 'chkGBXInspectionApplicable') {
                                        callmethod = 'GetGBXIRViewId';
                                    }
                                    ChkViewID(callmethod, $('#' + this.id), findprevcontrol);
                    }
                });
            });
                
            $(".nav-tabs a").click(function () {
                $(this).tab('show');
            });

            $(".btnDelete").click(function () {
                var ViewId = "<%:ViewBag.ViewId %>";
                var data = jQuery.parseJSON('{"ViewId": "' + ViewId + '"}');

                /* if (confirm("Do you wish to delete the View?")) {
                     CallClientApi("CirView", "DELETE", data).done(function (result) {
                         if (result == false) {
                             NotifyCirMessage(' ', "System view cannot be deleted!", 'danger');
                         }
                         else {
                             NotifyCirMessage(' ', "View deleted successfully!", 'info');
                             PostBack(-1);
                         }
                     });
                 }*/

                CirAlert.confirm('Do you wish to delete the View?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    CallClientApi("CirView", "DELETE", data).done(function (result) {
                        if (result == false) {
                            NotifyCirMessage(' ', "System view cannot be deleted!", 'danger');
                        }
                        else {
                            NotifyCirMessage(' ', "View deleted successfully!", 'info');
                            PostBack(-1);
                        }
                    });

                });

            });

            $(".btnSaveView").click(function () {
                if (ValidateView()) {

                    //if (confirm("Do you wish to save ?")) {
                    //var viewId = "<%:ViewBag.ViewId%>";
                    /*var cirViewData = CreateView(viewId);
                    CallClientApi("CirView", "POST", cirViewData).done(function (result) {
                        if (result == -1) {
                            NotifyCirMessage(' ', "You do not have permission to edit System view!", 'danger');
                        }
                        else {
                            NotifyCirMessage(' ', "View saved successfully!", 'info');
                            PostBack(result);
                        }
                    });
                }*/
                    CirAlert.confirm('"Do you wish to save ?"', 'Cir App', 'Yes', 'No', 'question').done(function () {
                        var viewId = "<%:ViewBag.ViewId%>";
                        var cirViewData = CreateView(viewId);
                        CallClientApi("CirView", "POST", cirViewData).done(function (result) {
                            if (result == -1) {
                                NotifyCirMessage(' ', "You do not have permission to edit System view!", 'danger');
                            }
                            else {
                                NotifyCirMessage(' ', "View saved successfully!", 'info');
                                PostBack(result);
                            }
                        });
                    });

                }
            });


            $('#DeleteFilterRow').click(function () {

                $(this).closest('tr').remove();
            });

            $('#AddFilter').click(function () {
                AddFilterRow();
            });


        });

        function PostBack(id, url) {
            var url = "<%:Url.Action("save-cirviewid", "CirView")  %>";
            $.post(url, { viewId: id },
            function (data) {
                createCookie("CirViewId", id, "");
                window.location.href = "<%:Url.Action("manage-cirviewlist", "CirView")  %>";
            });
        }

    </script>

</asp:Content>
