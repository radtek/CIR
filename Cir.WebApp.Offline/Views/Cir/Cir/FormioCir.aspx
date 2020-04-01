<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="ct_FormIoRenderer_Head" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="ct_FormIoRenderer_Main" ContentPlaceHolderID="MainContent" runat="server">
    <%= Scripts.Render("~/bundles/js-multibrand") %>
    <%= Scripts.Render("~/bundles/ng-templates") %>
    <%= Styles.Render("~/bundles/css-multibrand") %>
    <div ng-app='formRenderer'>
        <div class='page-content' ng-app='formioApp'>
            <div class='container-fluid'>
                <div>
                    <div class='row'>
                        <div ng-controller="saveJsonController" ng-init='init()' class="col-sm-11" >
                            <div class="panel panel-default panelModified" ng-hide="!showTemplateSelection()">
                                <div class="panel-heading panelheadingFormIo ng-scope">
                                    <h3 class="panel-title ng-binding">Select Template
                                    </h3>
                                </div>
                                <div class="panel-body" style='background-color: #f9f9f9; padding-top: 20px;'>
                                    <div class="material-ui-radios template-wizard">
                                        <div class="input-group">
                                            <div class="form-group">
                                                <label for="brandList" class="control-label">Brand Type</label>
                                                <select class="form-control"
                                                    id="brandList"
                                                    ng-model="selectedBrand"
                                                    ng-change="populateTemplatesAndHotlist()"
                                                    ng-options="item.id as item.name for item in brands track by item.id">
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Template Type</label>
                                                <div>
                                                    <div class="radio-inline">
                                                        <label class="control-label" for="cir-type">
                                                            CIR Type
                                                            <input type="radio" id="cir-type" value="1" name="template-type" class="no-icheck" ng-model="templateType" ng-change="showCirType()">
                                                            <div class="radioImage"></div>
                                                            
                                                        </label>
                                                    </div>
                                                    <div class="radio-inline">
                                                        <label class="control-label" for="hot-list">
                                                             Hot List
                                                            <input type="radio" id="hot-list" value="2" name="template-type" class="no-icheck" ng-model="templateType" ng-change="showHotList()">
                                                            <div class="radioImage"></div>
                                                           
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group" ng-hide="!cirTypeVisible">
                                                <label for="templateList" class="control-label">CIR Type</label>
                                                <select class="form-control"
                                                    id="templateList"
                                                    ng-model="selectedTemplate"
                                                    ng-change="selectTemplate()"
                                                    ng-options="item.id as item.name for item in templates track by item.id">
                                                </select>
                                            </div>
                                            <div class="form-group" ng-hide="!hotListVisible">
                                                <label for="templateList" class="control-label">Hot List</label>
                                                <select class="form-control"
                                                    id="hotList"
                                                    ng-model="selectedHotListItem"
                                                    ng-change="selectHotlist()"
                                                    ng-options="item as item.hotItemDisplay for item in hotList track by item.id">
                                                </select>
                                            </div>
                                        </div>
                                    </div><div style="height:170px;margin-top: 30px; ">
                                    <div class="col-md-6 inspection-options" style='background-color: #ffffff; padding: 20px; margin-left:10px; margin-right:-10px; height:inherit' ng-hide="showBladeInspection()">
                                        <h4>Drone Inspection (coming soon...)</h4>
                                        <p style="height:30%">
                                            Start creating a new drone inspection by pressing the button below.
                                    You will be directed to Wind AMS.
                                        </p>
                                        <!--<button type="button" class="btn btn-primary" id="drone-inspection-btn" ng-click="runInspectTool()" ng-disabled="!isWindAmsBrand">Drone Inspection</button>-->
                                        <button type="button" class="btn btn-primary" id="drone-inspection-btn" ng-click="runInspectTool()" disabled>Drone Inspection</button>
                                    </div>
                                    <div style="width: 20px;" class="col-md-1"></div>
                                    <div class="col-md-6 inspection-options" style='background-color: #ffffff; padding: 20px; margin-left:10px; margin-right:-10px; height:inherit' ng-hide="showBladeInspection()">
                                        <h4>Non-drone Inspection</h4>
                                        <p style="height:30%">Start creating a new non- drone inspection by pressing the button below.</p>
                                        <button type="button" class="btn btn-primary" id="non-drone-inspection-btn" ng-click="selectBladeInspection()" onclick="NonDroneInspection.OnPageReady()">Non Drone Inspection</button>
                                    </div>
                                        </div>
                                </div>
                            </div>
                            <div class='well wellFormIo' ng-hide="!showForm()">
                                <formio form='form' submission="formInputModel"></formio>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Vestas blade instruction</h4>
                </div>
                <div class="modal-body">
                    <video id="my-video" class="video-js" controls preload="none" width="500" height="264" data-setup="{}">
                        <source src=" /cir/show-video" type='video/mp4'>
                        <p class="vjs-no-js">
                            To view this video please enable JavaScript, and consider upgrading to a web browser that
                                <a href="http://videojs.com/html5-video-support/" target="_blank">supports HTML5 video</a>
                        </p>
                    </video>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="blade-instruction-modal-btn">Ok</button>

                </div>
            </div>
        </div>
    </div>

    <input type="hidden" id="hdnGearTypeDamageDecision" value="" />
</asp:Content>
