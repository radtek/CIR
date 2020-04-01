<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %> - Service Informations
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Js/jquery.dataTables.min.js"></script>
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>

    <script src="../Js/bootstrap-datetimepicker.min.js"></script>
    <link href="../Css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css">
    <script src="../Js/ApplicationScripts/ServiceInformation.js"></script>

    <style type="text/css">
        .ui-tooltip {
            max-width: 800px;
            top: 0px;
        }

        .ui-tooltip-content {
            background-color: #CEDBEB;
            white-space: pre-wrap;
            padding: 2px;
            line-height: 18px;
        }

        .LatestRec {
            top: 250px;
        }

        .table-header {
            background-color: #0072BB;
            border: 1px solid #aaaaaa;
        }

        #tableFeedback {
            margin-bottom: -15px !important;
            margin-top: -15px !important;
        }

            #tableFeedback tbody tr {
                cursor: pointer;
            }

        /*#tableFeedback tr:nth-child(even) td {
                background-color: #EFF2F4;
            }*/

        /*.dataTables_scrollBody thead {visibility: hidden;}*/
        #tableFeedback_info, #tableFeedback_paginate {
            margin-top: 13px;
        }


        .datetimepicker {
            top: 27%;
            left: 50%;
            z-index: 100000;
        }
    </style>


    <section class="content">
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <%--<div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Delete service information</h4>
                    </div>--%>
                    <%--<div class="modal-body">
                        <p>Are you sure to delete the service information</p>
                    </div>--%>
                    <%--<div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        <button type="button" class="btn btn-primary" id="btnSave">Yes </button>

                    </div>--%>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Service Informations</legend>
                        </fieldset>
                        <br />
                        <div class="col-xs-12" style="text-align: right;">

                            <a href="javascript:void(0);" onclick="ServiceInfoEditor.show(0);" style="margin-right: -32px;" class="btn btn-primary">Add New Service Information</a>
                            <br />

                        </div>
                        <div class="bs-example form-horizontal">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="tableServiceInfo" class="FlexResponive list dataTable no-footer" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>Severity</th>
                                                <th>From Date</th>
                                                <th>To Date</th>
                                                <th>Message</th>
                                                <th>Edit/Delete</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        var ServiceInfoData = [];
        removeServiceInfobtn = null;
        var tableServiceInfo = null;
        $(document).ready(function () {
            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "date-uk-pre": function (a) {
                    if (a == null || a == "") {
                        return 0;
                    }
                    var ukDatea = a.split('-');
                    return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
                },

                "date-uk-asc": function (a, b) {
                    return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                },

                "date-uk-desc": function (a, b) {
                    return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                }
            });

            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("ServiceInformationList", "GET", "").done(function (result) {
                if (result) {
                    ServiceInfoData = result;
                    tableServiceInfo = $('#tableServiceInfo').dataTable({
                        data: ServiceInfoData,
                        columns: [
                            { data: "id", "width": "25px", className: "id-cont", type: "num" },
                            { data: "severityName" },
                             { data: "strFromDate", type: "date-uk" },
                             { data: "strToDate", type: "date-uk" },
                            {
                                data: null, "width": "35%", render: function (data, type, row) {
                                    if (data != null && data.message != null)
                                        return data.message.slice(0, 50) + '...';
                                    else
                                        return "";
                                }
                            },

                            {
                                data: null, "width": "25px", render: function (data, type, row) {
                                    return '<a title="Edit"  data-id="' + data.id + '" href="javascript:void(0);" onclick="ServiceInfoEditor.show(' + data.id + ');" ><i class="fa fa-pencil-square-o fa-lg"></i></a> / <a title="Delete" data-id="' + data.id + '" href="javascript:void(0);" class="btn-delete removeseviceInfo"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a>';
                                },
                                "orderable": false
                            }
                        ],
                        "order": [[0, "desc"]]
                    });

                    $('#tableServiceInfo').on('click', 'a.removeseviceInfo', function (e) {
                        e.preventDefault();
                        $("#myModal").modal('show');
                        removeServiceInfobtn = $(this);
                    });
                    $('#tableServiceInfo').on('click', 'tbody tr .id-cont', function (e) {
                        e.preventDefault();
                        ServiceInfoEditor.view(parseInt($(this).find('.id-cont').text()));
                    });
                }
                else {
                    NotifyCirMessage('Error : ', "Data loading error", 'danger');
                }
                waitingDialog.hide();
            });
            // $("#btnSave").click(function () {
            $('body').on('click', '.removeseviceInfo', function () {

                $("#myModal").modal('hide');
                //if (removeServiceInfobtn) {
                //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                var id = removeServiceInfobtn.attr('data-id');
                CirAlert.confirm('Are you sure to delete the service information?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                    CallClientApi("ServiceInformations/" + id, "DELETE", "").done(function (result) {
                        if (result) {
                            findAndRemove(ServiceInfoData, 'id', id);
                            tableServiceInfo.fnDeleteRow(removeServiceInfobtn.closest('tr'));
                        }
                        else {
                            NotifyCirMessage('Error : ', "Delete record error", 'danger');
                        }
                        waitingDialog.hide();
                        removeServiceInfobtn = null;
                    });
                });
                // }

            });
            $('.tooltip-r').tooltip({
                item: "",
                display: "",
                content: function () {
                    var element = $(this);
                    return element.attr("title");
                }
            });



        });

        function findAndRemove(array, property, value) {
            array.forEach(function (result, index) {
                if (result[property] == value) {
                    //Remove from array
                    array.splice(index, 1);
                }
            });
        }


    </script>


    <%--  <section class="content" style="background: transparent">
        <div class="alert-messages text-center">
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Service Information
                        
                            </div>
                        </div>
                        <br style="clear: both;" />
                        <div class="col-xs-12">
                            <div class="col-xs-3" style="text-align: left;">
                               
                            </div>
                            <div class="col-xs-4" style="text-align: left;">
                               
                            </div>
                            <div class="col-xs-5" style="text-align: right;">
                                <a href="javascript:void(0);" onclick="ServiceInfoEditor.show(0);" class="btn btn-primary">Add New Service Information</a>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div>
                        <table role="main" id="localServiceInfoTable" class="FlexResponive list">
                            <thead class="table-header">
                                <tr>
                                    <th data-hide="expand" scope="col">Severity</th>
                                    <th data-hide="expand" scope="col">From Date</th>
                                    <th data-hide="expand" scope="col">To Date</th>
                                    <th data-hide="expand" scope="col" style="width: 50%">Message</th>
                                    <th data-hide="phone" scope="col" data-sort-ignore="true" style="width: 7%"></th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>

                <div id="header-fixed">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Service Information                        
                            </div>
                        </div>
                    </div>
                    <table id="Lheader-fixed" class="FlexResponive FlexResponive-loaded default"></table>
                </div>
            </div>
        </div>
        <div>
        </div>

    </section>

    <input type="hidden" id="hdnUserInitial" />
    <input type="hidden" id="hdnStatus" />--%>
</asp:Content>
