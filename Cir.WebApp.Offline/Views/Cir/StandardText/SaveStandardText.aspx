<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Standard Text
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <script src="../Js/ApplicationScripts/StandardTextSave.js"></script>
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
                            Save Standard Text </div>
                       <br style="clear:both" />

                        <div class="form-group">
        <label class="col-lg-3 control-label">Report Type<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlCirType" class="form-control">
                                            </select>
        </div>
    </div>
                        <div class="form-group">
        <label class="col-lg-3 control-label">Title<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtTitle"  data-toggle="tooltip" 
                data-placement="top" title="Enter Title"  class="form-control" placeholder="Title"/>

        </div>
    </div>
                    <div class="form-group">
        <label class="col-lg-3 control-label">Description<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <textarea id="txtDescription" data-toggle="tooltip" 
                data-placement="top" title="Enter Description"  class="form-control" style="width:100%;height:150px;" placeholder="Description"></textarea>
                        
        </div>
    </div>

                            

                            <div class="form-group">
                                <div class="col-lg-9 col-lg-offset-3">
                                    <input type="submit" onclick="SaveStandardText()" class="btn btn-primary" value="Save" />
                                    <a href="/cir/Manage-StandardText" class="btn btn-default">Cancel</a>
                                </div>
                            </div>
                    </div>
                </div>

               
            </div>
    </section>
    <input type="hidden" id="hdnUserInitial" />
   

</asp:Content>
