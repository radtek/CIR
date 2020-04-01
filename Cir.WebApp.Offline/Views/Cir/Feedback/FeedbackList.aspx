<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" Inherits="System.Web.Mvc.ViewPage<Cir.WebApp.Offline.Models.Cir.BIR.BIRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Js/jquery.dataTables.min.js"></script>
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>

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

       
    </style>

    <section class="content">
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <%--<div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Delete feedback</h4>
                    </div>--%>
                    <%--<div class="modal-body">
                        <p>Are you sure to delete the feedback</p>
                    </div>--%>
                    <%--<div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        <button type="button" class="btn btn-primary" id="btnSave">Yes </button>

                    </div>--%>
                </div>
            </div>
        </div>
        <div class="modal fade" id="myDetailsModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <p id="fdbkfrom"></p>
                        <br />
                        <br />
                        <p id="fdbkmsg"></p>
                        <br />
                        <br />
                        <p id="fdbkenv"></p>
                        <br />
                        <br />
                        <p id="fdbkon"></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal" id="btnSave">Ok</button>

                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="bs-example form-horizontal">
                        <fieldset>
                            <legend>Manage Feedback</legend>
                        </fieldset>
                        <div class="bs-example form-horizontal">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="tableFeedback" class="FlexResponive list dataTable no-footer" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>Message</th>
                                                <th>Feedback Type</th>
                                                <th>Created on</th>
                                                <th>Created By</th>
                                                <th>Enviroment</th>
                                                <th>Delete</th>
                                            </tr>
                                        </thead>
                                        <%-- <tfoot>
                                            <tr>
                                                <th>Id</th>
                                                <th>Message</th>
                                                <th>Feedback Type</th>
                                                <th>Created on</th>
                                                <th>Created By</th>
                                                <th>Enviroment</th>
                                                <th>Edit / Delete</th>
                                            </tr>
                                        </tfoot>--%>
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
        var feedbackdata = [];
        removefeedbackbtn = null;
        var tablefeedback = null;
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
            CallClientApi("Feedback", "GET", "").done(function (result) {
                if (result) {
                    feedbackdata = result;
                    tablefeedback = $('#tableFeedback').dataTable({
                        data: feedbackdata,
                        columns: [
                            { data: "id", "width": "25px", className: "id-cont", type: "num" },
                            {
                                data: null, "width": "35%", render: function (data, type, row) {
                                    if (data != null && data.message != null)
                                        return data.message.slice(0, 50) + '...';
                                    else
                                        return "";
                                }
                            },
                            { data: "feedbackType" },
                            {
                                data: null, render: function (data, type, row) {
                                    return getDate(data.created);
                                },
                                type: "date-uk"
                            },
                            { data: "createdBy" },
                            {
                                data: null, render: function (data, type, row) {
                                    if (data != null && data.enviroment != null)
                                        return data.enviroment.slice(0, 50) + '...';
                                    else
                                        return "";
                                }
                            },
                            {
                                data: null, "width": "25px", render: function (data, type, row) {
                                    return '<a title="Delete" data-id="' + data.id + '" href="javascript:void(0);" class="btn-delete removefeedback"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a>';
                                }
                            }
                        ],
                        "order": [[3, "desc"]]
                    });
                    $('#tableFeedback').on('click', 'a.removefeedback', function (e) {
                        e.preventDefault();
                        $("#myModal").modal('show');
                        removefeedbackbtn = $(this);
                    });
                    $('#tableFeedback').on('click', 'tbody tr', function (e) {
                        e.preventDefault();
                        showDetails(parseInt($(this).find('.id-cont').text()));
                    });
                }
                else {
                    NotifyCirMessage('Error : ', "Feebcak loading error", 'danger');
                }
              
                waitingDialog.hide();
            });

            $("#btnSave").click(function () {

                $("#myModal").modal('hide');
                //if (removefeedbackbtn) {

                    //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                    var id = removefeedbackbtn.attr('data-id');
                    CirAlert.confirm('Do you wish to delete the feedback?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                        CallClientApi("Feedback/" + id, "DELETE", "").done(function (result) {
                            if (result) {
                                findAndRemove(feedbackdata, 'id', id);
                                tablefeedback.fnDeleteRow(removefeedbackbtn.closest('tr'));
                            }
                            else {
                                NotifyCirMessage('Error : ', "Delete Feedback error", 'danger');
                            }

                            waitingDialog.hide();
                            removefeedbackbtn = null;
                        });
                    });
               // }

            });
            var getDate = function getDate(date) {
                var today = new Date(date);
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!

                var yyyy = today.getFullYear();
                if (dd < 10) {
                    dd = '0' + dd
                }
                if (mm < 10) {
                    mm = '0' + mm
                }
                return dd + '-' + mm + '-' + yyyy;
            }
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

        function getDetails(id) {
            var itm = null
            feedbackdata.forEach(function (result, index) {
                if (result['id'] == id) {
                    // return result;
                    //return false;
                    itm = result;
                }

            });
            return itm;
        }
        function showDetails(id) {
            var itm = getDetails(id);
            $("#myDetailsModal").find('.modal-title').text("Feedback details ()");
            $("#myDetailsModal").find('#fdbkfrom').html("From : <br/>");
            $("#myDetailsModal").find('#fdbkmsg').html("Message : <br/>");
            $("#myDetailsModal").find('#fdbkenv').html("Enviroment : <br/>");
            $("#myDetailsModal").find('#fdbkon').text("Created on ");

            $("#myDetailsModal").find('.modal-title').text("Feedback details (" + itm.feedbackType + ")");
            $("#myDetailsModal").find('#fdbkfrom').html("From : <br/>" + itm.createdBy);
            $("#myDetailsModal").find('#fdbkmsg').html("Message : <br/>" + itm.message);
            $("#myDetailsModal").find('#fdbkenv').html("Enviroment : <br/>" + itm.enviroment);
            $("#myDetailsModal").find('#fdbkon').text("Created on " +getDate(itm.created));
            $("#myDetailsModal").modal('show');
        }
    </script>
</asp:Content>
