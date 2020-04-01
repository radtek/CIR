<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Cir Log History - CIM Inspection Report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <script src="../Js/tablesaw.js"></script>
    <link href="../Css/tablesaw.css" rel="stylesheet" type="text/css" />


    <%-- <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />--%>
    <script src="../Js/ApplicationScripts/CirLogHistory.js"></script>

    <section class="content" style="background: transparent">
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Cir Log History
                        <%--<div class="Navbar-brandsmall">Component Inspection Report</div>--%>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row" id="CirDetailsSection_Logview">
                        <div class="col-xs-12">
                            <table role="main" id="CirDataDetail_Logview" class="tablesaw">
                                <thead>
                                    <tr>
                                        <th colspan="4" scope="col" style="text-align: center">Details of CIR ID : <b><span id="spancirId"></span></b></th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                    
                    <br />

                    <div id="LocalSearch" class="row">
                        <div class="col-xs-12">
                            
                        </div>
                    </div>
                    <div>
                        <table role="main" id="localCIRLogTable" class="FlexResponive list">
                            <thead>
                                <tr>
                                    
                                    <th data-class="expand" scope="col" data-sort-initial="true">Message</th>
                                    <th data-hide="phone" scope="col">Initials</th>
                                    <th data-hide="phone" scope="col">Timestamp</th>                                    
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>

                <div id="header-fixed">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Cir Log History
                                <div class="Navbar-brandsmall">Component Inspection Report</div>
                            </div>
                        </div>
                    </div>
                    <div id="LSearchbox" class="row"></div>
                    <table id="Lheader-fixed" class="FlexResponive FlexResponive-loaded default"></table>
                </div>

            </div>
        </div>
        <div>
        </div>
    </section>


</asp:Content>
