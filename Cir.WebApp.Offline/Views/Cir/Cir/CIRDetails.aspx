<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Cir Log History - CIM Inspection Report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <%-- <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />--%>
    <script src="../Js/ApplicationScripts/CirDetails.js"></script>
    <style type="text/css">
        div.alert-messages {
            position: fixed;
            top: 50px;
            left: 25%;
            right: 25%;
            z-index: 7000;
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
                                Details for CIR #<label id="CirIdLabel" />
                                <%-- <div class="Navbar-brandsmall">Details for CIR #</div>--%>
                            </div>
                        </div>
                    </div>
                    <div id="LocalSearch" class="row">
                        <div class="col-xs-12">
                        </div>
                    </div>
                    <div>

                        <asp:HyperLink runat="server" Text="Click here to edit this CIR" ID="DownloadLink" /><br />
                        <br />

                        <ul>
                            <li>CIR state:
                                <label id="CirState" />
                            </li>
                            <li>CIR Name:
                                <label id="CirFilename" />
                            </li>
                            <%--<li id="AdditionalCir" runat="server"><asp:Label runat="server" ID="AdditionalCirInfoText" /> - <asp:HyperLink Text="click here to view" runat="server" ID="AdditionalCirInfoLink" /></li>--%>
                            <li id="liLogViewerLink">
                                <div id="LogViewerLink"></div>
                            </li>
                            <li id="AttachmentsBullet" runat="server" visible="false">
                                <asp:HyperLink Text="Click here to view attachments" runat="server" ID="AttachmentsLink" /></li>
                        </ul>
                    </div>

                    <div id="getAttachments" class="row" style="display:none">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                Attachments
                            </div>
                        </div>

                        <div>
                            <table role="main" id="CirAttachments" class="FlexResponive list">
                                <thead>
                                    <tr>
                                        <th data-class="expand" scope="col" data-sort-initial="true">Action</th>
                                        <th data-class="expand" scope="col" data-sort-initial="true">Cir ID</th>
                                        <th data-class="expand" scope="col" data-sort-initial="true">File Name</th>
                                        <th data-hide="expand" scope="col" data-sort-initial="true">Created By</th>
                                        <th data-class="expand" scope="col" data-sort-initial="true">Created Date</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                        <br />
                        <div id="UploadAttachment" class="row">
                            <div class="col-xs-12">

                                <asp:Label ID="Label1" runat="server" Text="Error" Visible="False" CssClass="ValidationError errLabel"></asp:Label>
                                <asp:Literal ID="Literal1" runat="server" Visible="False"><h5>File Successfully Uploaded!!!</h5> </asp:Literal>
                                <input type="file" id="documentattachment" name="AttachmentFile" size="chars">
                            </div>
                            <br />

                            <div class="col-xs-6">
                                <input type="submit" class="btn btn-primary" id="uploaddocument" onclick="CirDetails.UploadAttachment()" value="Upload Document" style="text-align: left;" />
                            </div>
                            <br />

                        </div>
                    </div>
                    <br />

                    <div id="NonAttachmentSection">
                        <div>
                            <table role="main" id="CirDataDetail" class="FlexResponive list">
                                <thead>
                                    <tr>

                                        <th data-class="expand" colspan="2" scope="col" data-sort-initial="true" style="text-align: center">CIR details</th>

                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div id="LocalSearch" class="row">
                            <div class="col-xs-12">
                                <div class="navbar-left navbar-SubHead">
                                    Comments
                                </div>
                            </div>
                        </div>
                        <div>

                            <table role="main" id="CirCommentHistory" class="FlexResponive list">
                                <thead>
                                    <tr>

                                        <th data-class="expand" scope="col" data-sort-initial="true">Author</th>
                                        <th data-hide="phone" scope="col">Date</th>
                                        <th data-hide="phone" scope="col">Comment</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <!--Task No. : 72518,72519 & 72520 , Added By Siddharth Chauhan on 26-05-2015 -->
                        <div id="LocalSearch" class="row">
                            <div class="col-xs-12">
                                <div class="navbar-left navbar-SubHead">
                                    Revision
                                </div>
                            </div>
                        </div>
                        <div>
                            <!--Task No. : 72518,72519 & 72520 , Added By Siddharth Chauhan on 26-05-2015 -->
                            <table role="main" id="CirRevision" class="FlexResponive list">
                                <thead>
                                    <tr>
                                        <th data-class="expand" scope="col" data-sort-initial="true">Action</th>
                                        <th data-class="expand" scope="col" data-sort-initial="true">Edited On</th>
                                        <th data-hide="phone" scope="col">Edited By</th>
                                    </tr>
                                </thead>
                            </table>
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

                        <br />
                        <div id="LocalSearch" class="row">
                            <div class="col-lg-6">


                                <textarea id="txtComment" placeholder="Comment" data-toggle="tooltip"
                                    data-placement="top" title="Enter Comment" class="form-control" style="width: 100%; height: 150px;"></textarea>
                            </div>
                        </div>
                        <br />
                        <div id="LocalSearch" class="row">
                            <div class="col-lg-6">

                                <input type="submit" onclick="SaveComment()" class="btn btn-primary" value="Add comment" />
                            </div>
                        </div>
                        <br />

                        <br />
                    </div>
                    <div id="UploadFile" class="row">
                        <div class="col-lg-6">

                            <div class="navbar-left navbar-SubHead">
                                Upload Defect Categorization File
                                
                            </div>
                            <br />
                            <asp:Label ID="lblError" runat="server" Text="Error" Visible="False" CssClass="ValidationError errLabel"></asp:Label>
                            <asp:Literal ID="litSuccess" runat="server" Visible="False"><h5>File Successfully Uploaded!!!</h5> </asp:Literal>

                            <input type="file" name="DefectFileUpload" id="defectfileupload" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet,application/vnd.ms-excel.sheet.macroEnabled.12,application/vnd.ms-excel" size="chars"> 
                              
                            <br />
                            <input type="submit" class="btn btn-primary" id="btnuploaddefectdocument" onclick="CirDetails.UploadDefectAttachment()" value="Upload" />
                            <br />



                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
        </div>
    </section>

    <input type="hidden" id="hdnUserInitial" />

    </label>
    </label>
    </label>
    
</asp:Content>
