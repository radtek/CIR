<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <legend>Common Data (Wind Turbine + Description)</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Brand</label>
        <div class="col-lg-9">
            <select multiple="multiple" id="CIRBrandType"  class="chosen-select form-control" style="width: 350px;" >
            <%--<select id="CIRBrandType" class="form-control">--%>
                <option value="0">- Brand -</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDTurbineNo" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <%--<div class="form-group">
        <label class="col-lg-3 control-label">Alarm Log Number</label>
       <div class="col-lg-9">
           <input id="CIRWTDAlarmLogNumber" data-toggle="tooltip" placeholder="Alarm Log Number" class="form-control" />
        </div>
    </div>--%>

    <div class="form-group">
        <label class="col-lg-3 control-label">CIM Case Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDCaseNo" data-toggle="tooltip" data-placement="top" placeholder="CIM Case Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">CIR ID</label>
        <div class="col-lg-9">
            <input id="CIRCIRID" data-toggle="tooltip" data-placement="top" placeholder="CIR ID" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Commissioning From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDCommisioningDateFrom_txtDate" placeholder="Commissioning from date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Commisioning from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Commissioning To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDCommisioningDateTo_txtDate" placeholder="Commissioning to date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Commisioning to date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Component Type</label>
        <div class="col-lg-9">
            <%--<select id="CIRComponentType" data-placeholder="Your Favorite Types of Bear" style="width:350px;" multiple class="chosen-select" data-datatable="ComponentInspectionReportType" data-textfield="text" data-valuefield="ComponentInspectionReportTypeID">--%>
            <%--<select id="CIRComponentType" data-placeholder="Your Favorite Types of Bear"  data-fieldtype="select" data-datatable="ComponentInspectionReportType" data-textfield="text" data-valuefield="ComponentInspectionReportTypeID"  multiple class="chosen-select form-control" >--%>
            <select id="CIRComponentType" multiple="multiple" style="width: 350px;" data-fieldtype="select" data-datatable="ComponentInspectionReportType" data-textfield="text" data-valuefield="ComponentInspectionReportTypeID" class="chosen-select" placeholder="CIRComponentType">
                <option value="-1"></option>
                <%--   <select id="CIRComponentType" multiple="multiple" class="form-control" data-fieldtype="select" data-datatable="ComponentInspectionReportType" data-textfield="text" data-valuefield="ComponentInspectionReportTypeID"  >--%>
                <%--<select id="CIRComponentType" data-valuefield="ComponentInspectionReportTypeID"  data-placeholder="Your Favorite Types of Bear" multiple class="chosen-select" style="width:350px;">--%>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Conducted By</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDConductedBy" data-toggle="tooltip" data-placement="top" placeholder="Conducted By" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Country</label>
        <div class="col-lg-9">
            <select id="CIRWTDCountry" style="width: 350px;" multiple="multiple" data-fieldtype="select-remote" data-datatable="Country" data-textfield="text" data-valuefield="value" class="chosen-select">
                <option value="-1"></option>
                <%-- <select id="CIRWTDCountry" class="form-control"   multiple="multiple" data-fieldType="select-remote" data-dataTable="Country" data-valueField="value" data-textField="text"  data-sort="true">--%>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Description</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDDescription" placeholder="Description" class="form-control" data-toggle="tooltip" data-placement="top" title="Enter Description" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Failure From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDFailureDateFrom_txtDate" placeholder="Failure from date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Failure from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Failure To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDFailureDateTo_txtDate" placeholder="Failure to date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Failure to date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator 1 (hrs)</label>
        <div class="col-lg-9">
            <input id="CIRWTDGenerator1Hours" placeholder="Generator 1 (hrs)" data-toggle="tooltip"
                data-placement="top" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator 2 (hrs)</label>
        <div class="col-lg-9">
            <input id="CIRWTDGenerator2Hours" data-toggle="tooltip"
                data-placement="top" placeholder="Generator 2 (hrs)" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDInspectionDateFrom_txtDate" placeholder="Inspection from date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Inspection From Date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDInspectionDateTo_txtDate" placeholder="Inspection to date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Inspection to date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Installation From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDInstallationDateFrom_txtDate" placeholder="Installation from date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Installation from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Installation To Date</label>

        <div class="col-lg-9">
            <input type="text" id="CIRWTDInstallationDateTo_txtDate" placeholder="Installation to date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Installation to date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Local Turbine ID</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDLocalTurbineId" class="form-control" placeholder="Local Turbine ID" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Notification Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDNotificationNumber" placeholder="Notification number" data-toggle="tooltip" data-placement="top" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Quan. Failed Comp.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDQuantity" class="form-control" placeholder="Quan. Failed Comp." />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Reason For Service</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDReasonForService" class="form-control" placeholder="Reason For Service" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Reconstruction</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRWTDReconstruction" class="form-control">
                <option value="1">No</option>
                <option value="2">Yes</option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Report Type</label>
        <div class="col-lg-9">
            <select id="CIRWTDReportType" multiple="multiple" data-fieldtype="select" style="width: 350px;" data-datatable="ReportType" data-textfield="text" data-valuefield="ReportTypeID" data-sort="true" data-placeholder="Report Type" class="chosen-select">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run (Hrs)</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDRunHours" class="form-control" placeholder="Run (Hrs)" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run Status After Inspection</label>
        <div class="col-lg-9">
            <select multiple="multiple" id="CIRWTDRunStatusAfterInspection" class="chosen-select" data-placeholder="Run Status After Inspection" style="width: 350px;" data-fieldtype="select" data-datatable="TurbineRunStatus"
                data-textfield="text" data-valuefield="TurbineRunStatusID" data-sort="true">
                <option value="-1"></option>
            </select>
            <%--<select size="2" multiple="multiple" id="CIRWTDRunStatusAfterInspection" class="form-control">
			    <option value="6">No power</option>
			    <option value="1">Run</option>
			    <option value="2">Stop</option>
			    <option value="3">Restrictions</option>
			    <option value="7">Pause</option>
			    <option value="8">Emergency Stop</option>
		    </select>--%>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run Status Before Inspection</label>
        <div class="col-lg-9">
            <select multiple="multiple" id="CIRWTDRunStatusBeforeInspection" data-fieldtype="select" data-datatable="TurbineRunStatus" data-sort="true"
                data-textfield="text" data-valuefield="TurbineRunStatusID" class="chosen-select" data-placeholder="Run Status Before Inspection" style="width: 350px;">
                <option value="-1"></option>
            </select>
            <%-- <select size="2" multiple="multiple" id="CIRWTDRunStatusBeforeInspection" class="form-control">
			    <option value="6">No power</option>
			    <option value="1">Run</option>
			    <option value="2">Stop</option>
			    <option value="3">Restrictions</option>
			    <option value="7">Pause</option>
			    <option value="8">Emergency Stop</option>
		    </select>--%>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Second Generator</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRWTDSecondGenerator" class="form-control">
                <option value="1">No</option>
                <option value="2">Yes</option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Service Engineer</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDServiceEngineer" class="form-control" placeholder="Service Engineer" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Service Report Number Type</label>
        <div class="col-lg-9">
            <select multiple="multiple" id="CIRWTDServiceReportNumberType" data-fieldtype="select" data-datatable="ServiceReportNumberType" data-textfield="text" data-valuefield="ServiceReportNumberTypeID" data-sort="true" class="chosen-select" style="width: 350px;" data-placeholder="Service Report Number Type">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Service Report Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDServiceReportNumber" class="form-control" placeholder="Service Report Number" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Site Name</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDSiteName" class="form-control" placeholder="Site Name" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">TotalProduction (kWh)</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDTotalProduction" class="form-control" placeholder="TotalProduction (kWh)" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Type</label>
        <div class="col-lg-9">
            <select multiple="multiple" id="CIRWTDTurbineType" data-fieldtype="select-remote" data-datatable="TurbineType"
                data-textfield="text" data-valuefield="value" class="chosen-select" style="width: 350px;" data-placeholder="Turbine Type">
                <option value="-1"></option>

            </select>


        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Vestas Item No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDVestasItemNo" class="form-control" placeholder="Vestas Item No." />
        </div>
    </div>

    <%--   New Added field--%>
    <div class="form-group">
        <label class="col-lg-3 control-label">Up-Tower Solution Available</label>
        <div class="col-lg-9">
            <select id="CIRWTDUpTowerSolution" class="form-control" data-fieldtype="select" data-datatable="ComponentUpTowerSolution" data-textfield="text" data-valuefield="ComponentUpTowerSolutionID">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Description of any consequential problems/damage</label>
        <div class="col-lg-9">
            <textarea id="CIRWTDDescriptionConProb" class="form-control" placeholder="Description of any consequential problems/damage"></textarea>

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Additional Information</label>
        <div class="col-lg-9">
            <textarea id="CIRWTDAdditionalInfo" class="form-control" placeholder="Additional Information"></textarea>

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Tech. Support recommendation</label>
        <div class="col-lg-9">
            <textarea id="CIRWTDSBURecommendation" class="form-control" placeholder="Tech. Support recommendation"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Alarm Log Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRWTDAlarmLogNumber" class="form-control" placeholder="Alarm Log Number" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Internal Comments</label>
        <div class="col-lg-9">
            <textarea id="CIRWTDInternalComments" class="form-control" placeholder="Internal Comments - this information is NOT exposed to customers/suppliers"></textarea>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_linkCirAdvSearch_Common" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_Common" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>


</fieldset>
