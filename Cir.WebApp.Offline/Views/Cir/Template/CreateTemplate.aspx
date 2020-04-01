<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>


<asp:Content ID="ct_FormIoBuilder_Head" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="ct_FormIoBuilder_Main" ContentPlaceHolderID="MainContent" runat="server">
     
    <%= Scripts.Render("~/bundles/js-multibrand") %>
    <%= Scripts.Render("~/bundles/ng-templates") %>
    <%= Styles.Render("~/bundles/css-multibrand") %>
   
   <script type="text/javascript">
       $(document).ready(function () {
           $("#nav-icon1").toggleClass("open");
           $('.left-side').toggleClass("collapse-left");
           $(".right-side").toggleClass("strech");
       });
   </script>

    <div ng-app="formBuilder">
        <div class="page-content" ng-app="formioApp">
            <div class="container-fluid">
                <div>
                    <div class="row">
                        <div class="col-sm-8">
                            <h3 class="text-center text-muted">Form Type
                                <select class="form-control form-type-select" ng-model="form.display" ng-options="display.name as display.title for display in displays"></select></h3>
                            <pre class="text-center bg-info"><h4><code>&lt;form-builder form="form"&gt;&lt;/form-builder&gt;</code></h4></pre>
                            <div class="well" style="background-color: #fdfdfd;">
                                <form-builder form="form"></form-builder>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <h3 class="text-center text-muted">as JSON Schema</h3>
                            <pre class="bg-info"><h4><code>$rootScope.form = </code></h4></pre>
                            <div class="well jsonviewer" style="max-width: 500px">
                                <json-explorer data="form" collapsed="jsonCollapsed"></json-explorer>
                            </div>
                        </div>
                    </div>
                    <div class="saveButton">
                        <input id="btnSaveJSON" type="submit" class="btn btn-primary btn-md" ng-click="saveJSON()" value="Save JSON" />
                    </div>
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2">
                            <h3 class="text-center text-muted">which Renders as a Form in your Application</h3>
                            <pre class="text-center bg-info"><h4><code>&lt;formio form="form"&gt;&lt;/formio&gt;</code></h4></pre>
                            <div class="well">
                                <formio form="form" ng-if="renderForm"></formio>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
