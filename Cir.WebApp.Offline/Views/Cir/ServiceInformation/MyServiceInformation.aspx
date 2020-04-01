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
        .unread{
            font-weight: bold;background-color: #F5E7E7;
        }
        .unread td{
            font-weight: bold;background-color: #F5E7E7;
        }
        
          .datetimepicker {
            top: 27%;
            left: 50%;
            z-index: 100000;
        }
    </style>


        <section class="content">
        <div class="modal fade" id="myDetailsModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Service information</h4>
                    </div>
                    <div class="modal-body">
                        <p id="msg-bd"></p>
                        <br />
                        <br />
                        <p>created on:  <span id="msg-ct"></span></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn btn-primary" id="btnSave">Ok </button>

                    </div>
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
                         <br/>
                        <div class="bs-example form-horizontal">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="tableServiceInfo" class="table table-striped table-bordered dataTable2 no-footer" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>Severity</th>
                                                <th>Message</th>
                                                <th>Read</th>
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
        var tableServiceInfo = null;
        $(document).ready(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            dbtransaction.openDatabase(function () {
                dbtransaction.getServiceInfroNotificationAll(function (result) {
                    if (result) {
                       
                        ServiceInfoData = result;
                        tableServiceInfo = $('#tableServiceInfo').dataTable({
                            data: ServiceInfoData,
                            search: false,
                            "createdRow": function (row, data, index) {
                                $(row).addClass('data_' + data.id);
                                if (data.isExpired==false && data.isRead == false ) {
                                    $(row).addClass('unread');
                                }
                            },
                            "order": [[ 0, "desc" ]],
                            columns: [
                                { data: "id", "visible": false },
                                { data: "severityName", "width": "150px", "orderable": false },
                                {
                                    data: null, render: function (data, type, row) {
                                        if (data != null && data.message != null)
                                            return data.message + '...';
                                        else
                                            return "";
                                    },
                                    "orderable": false
                                },

                                {
                                    data: null, "width": "25px", render: function (data, type, row) {
                                        return '<a title="Read" class="tooltip-r"  data-id="' + data.id + '" href="javascript:void(0);" onclick="showServiceInfo(' + data.id + ');" ><i class="fa fa-external-link fa-lg"></i></a>';
                                    },
                                    "orderable": false
                                }
                            ]
                        });
                    }
                    else {
                        NotifyCirMessage('Error : ', "Data loading error", 'danger');
                    }
                    waitingDialog.hide();
                });
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
        var itm;
        function getDetails(id) {
            itm = null
            itm = $.map(ServiceInfoData, function (val, key) {
                if (val.id == id) return val;
            });
            return itm[0];
        }
        function showServiceInfo(id) {
            var itm = getDetails(id);
            if (itm != null|| itm != undefined ){
                $("#myDetailsModal").find('#msg-bd').text("");
                $("#myDetailsModal").find('#msg-ct').text("");
                $("#myDetailsModal").find('#msg-bd').html(itm.message);
                $("#myDetailsModal").find('#msg-ct').text(itm.StrFromDate);
                $("#myDetailsModal").modal('show');
                setTimeout(function () { $('.data_' + itm.id).removeClass('unread'); ServiceInfoNotify.MarkRead(itm,false); setTimeout(function () { ServiceInfoNotify.UpdateBadge(); }, 300); }, 2000);
            }
        }
    </script>

</asp:Content>
