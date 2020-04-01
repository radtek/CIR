<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Feedback
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Js/ApplicationScripts/FeedbackSave.js"></script>
    <style>
        div.alert-messages {
            position: fixed;
            top: 50px;
            left: 25%;
            right: 25%;
            z-index: 7000;
        }
    </style>
    <section class="content">
        <div class="alert-messages text-center">
        </div>
        <div class="col-xs-12">


            <div class="well well-White">
                <div class="bs-example form-horizontal">

                    <div class="navbar-left navbar-SubHead">
                        Submit Feedback
                    </div>
                    <br style="clear: both" />

                    <div class="form-group">
                        <label class="col-lg-3 control-label">Feedback Type<span class="errorSpan">*</span></label>
                        <div class="col-lg-9">
                            <select id="ddlFeedbackType" onchange="OnChangeFeedBackType()" class="form-control">
                                <option value="0">Loading..</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label id="lblmsg" class="col-lg-3 control-label">Message<span class="errorSpan">*</span></label>
                        <div class="col-lg-9">
                            <textarea id="txtFeedbackDescription" data-toggle="tooltip"
                                data-placement="top" title="Enter Message" class="form-control" style="width: 100%; height: 150px;" placeholder="Message" maxlength="4000"></textarea>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-9 col-lg-offset-3">
                            <input id="btnsave" type="submit" onclick="SaveFeedback()" class="btn btn-primary" value="Save" />
                           <div id ="cirissue" class="col-lg-9" style="display:none;" >
                          <span style="display:inline;white-space:nowrap;overflow:hidden;"> Please report any issue in ServiceNow using the CIR template: <a id="lnkemail" href="https://vestasprod.service-now.com/com.glideapp.servicecatalog_cat_item_view.do?v=1&sysparm_id=189b35fe376cbf00088e12c543990e59&sysparm_link_parent=4f06da0d37d2074005d41a7943990ead&sysparm_catalog=e0d08b13c3330100c8b837659bba8fb4&sysparm_catalog_view=catalog_default&sysparm_view=text_search" target="_blank" style="color:blue;display:inline">&nbsp;<u>Create Incident</u>&nbsp; </a></span>
                            
                               </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>

    </section>
    <input type="hidden" id="hdnUserInitial" />

</asp:Content>
