<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Standard Text
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <script src="../Js/ApplicationScripts/StandardText.js"></script>


    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />

    <script src="../Js/FlexResponive.sortable.js"></script>
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/jquery.bootpag.min.js"></script>
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />

    <link href="../../../Css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
    <script src="../../../Js/jquery.dataTables.min.js"></script>
    <script src="../../../Js/jquery.bootpag.min.js"></script>



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

        #localStandTextTable {
            margin-bottom: -15px !important;
            margin-top: -15px !important;
        }

        .bottom {
            padding-top: 25px;
        }

        .bottom {
            padding-top: 25px;
        }

        .dataTables_info {
            visibility: hidden;
        }

        div.alert-messages {
            position: fixed;
            top: 50px;
            left: 25%;
            right: 25%;
            z-index: 7000;
        }

        /*table.dataTable thead, table.dataTable thead tr, table.dataTable thead tr th {
            background-color: #0072BB !important;
        }*/

        .dataTables_wrapper .top {
            width: 100% !important;
        }

            .dataTables_wrapper .top .dataTables_length,
            .dataTables_wrapper .top .dataTables_paginate {
                display: block;
                width: 100% !important;
            }

                .dataTables_wrapper .top .dataTables_length label {
                    float: right !important;
                }

                .dataTables_wrapper .top .dataTables_paginate a.paginate_button.current,
                .dataTables_wrapper .bottom .dataTables_paginate a.paginate_button.current {
                    background-color: #0072BB !important;
                    background: -webkit-linear-gradient(top, #0072BB 0%, #0072BB 100%) !important;
                }

        .dataTables_wrapper .dataTables_paginate .paginate_button:hover,
        .dataTables_wrapper .dataTables_paginate .paginate_button:hover {
            background-color: #EEE !important;
            background: -webkit-linear-gradient(top, #EEE 0%, #EEE 100%) !important;
        }

        .dataTables_wrapper .bottom {
            position: relative;
        }

            .dataTables_wrapper .bottom .dataTables_info {
                position: absolute;
                right: 0;
                top: 52px;
            }
    </style>


    <section class="content" style="background: transparent">
        <div class="alert-messages text-center">
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Standard Text
                        
                            </div>
                        </div>
                        <br style="clear: both;" />
                        <div class="col-xs-12">
                            <div class="col-xs-3" style="text-align: left;">
                                <b>Common Inspection Report Type : </b>
                            </div>
                            <div class="col-xs-4" style="text-align: left;">
                                <select id="ddlCirType" class="form-control">
                                </select>
                            </div>
                            <div class="col-xs-5" style="text-align: right;">
                                <a href="/cir/save-StandText?ID=0" class="btn btn-primary">Add New Standard Text</a>
                            </div>
                        </div>
                    </div>

                    <br />
                    <div id="LocalSearch" class="row">
                        <div class="col-xs-12">
                            <!-- /.dropdown -->
                            <div class="nav navbar-top-links navbar-right" style="text-align: right">

                                <%--<span id="MSearch">
                                    <input type="search" title="Insert Search Item" placeholder="Search">
                                </span>
                                <a class="dropdown-toggle btn-circle" data-toggle="dropdown" href="#" style="padding: 5px 1px;">
                                    <i class="fa fa-tasks fa-fw"></i><i class="fa fa-caret-down"></i>
                                </a>--%>


                                <!-- /.dropdown-tasks -->


                            </div>

                        </div>

                    </div>
                    <div>
                        <table role="main" id="localStandTextTable" class="FlexResponive list">
                            <thead>
                                <tr>

                                    <th data-class="phone" scope="col" data-sort-initial="true" style="width: 20%">Title</th>
                                    <th data-hide="expand" scope="col" style="width: 63%">Description</th>
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
                                Standard Text
                        
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
    <input type="hidden" id="hdnStatus" />
</asp:Content>
