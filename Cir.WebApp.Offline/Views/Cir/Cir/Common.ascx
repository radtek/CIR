<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <legend>Wind Turbine Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Report Type<a tabindex="0" id="Reporhelp" data-toggle="popover" data-trigger="hover" title="Inspection:" data-content="Select “Inspection” when the component was inspected and not failed.">
                <img src="../Images/info-icon.png" />
            </a>
        </label>

        <div class="col-lg-9">
            <select id="ddlReportType" class="form-control" data-fieldType="select" data-dataTable="ReportType" data-textField="text" data-valueField="ReportTypeID" data-defaultvalue="2">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">
            CIM Case Number<span class="errorSpan">*</span>
        </label>

        <div class="col-lg-9">
            <input maxlength="8" id="txtCimNo" placeholder="CIM Case Number" data-toggle="tooltip"
                data-placement="top" title="Enter Numeric Cim Case Number" class="form-control" type="number" />
            <input type="hidden" id="_hCIRID" value="0" />
            <br>
                <label id="lblCIMCaseError" style="color: red; display: none"></label>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Reason For Service</label>
        <div class="col-lg-9">
            <textarea id="txtReasonForService" placeholder="Reason For Service" class="form-control"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">
            Turbine Number<span class="errorSpan">*</span><a tabindex="1" data-toggle="popover" data-trigger="hover" title="About turbine data:"
                data-content="Country, site name and wind turbine parameters are filled out automatically once the CIR is submitted.">
                <img src="../Images/info-icon.png" />
            </a>
            <label class='fa fa-spinner fa-spin' id="lblTurbineWait"></label>
        </label>
        <div class="col-lg-9">
            <input type="number" id="txtTurbineNumber" data-toggle="tooltip" data-placement="top" title="Enter Numeric Turbine Number" class="form-control numbersOnly" />
            <br>
            <%--<div id="dvTurbineError" style="display: none;">--%>
                <label id="lblTurbineError" style="color: red; display: none"></label>
            </div>
        <%--</div>--%>

    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Country</label>
        <div class="col-lg-9">
            <input type="text" id="txtTurbineCountry" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Site Name(ZIP code if appropriate)</label>
        <div class="col-lg-9">
            <input type="text" id="txtTurbineSite" disabled class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine type</label>
        <div class="col-lg-9">
            <input type="text" id="txtTurbineType" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Rotor diameter</label>
        <div class="col-lg-9">
            <input type="text" id="txtRotorDiameter" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Nominel power</label>
        <div class="col-lg-9">
            <input type="text" id="txtNominelPower" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Voltage</label>
        <div class="col-lg-9">
            <input type="text" id="txtVoltage" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Power regulation</label>
        <div class="col-lg-9">
            <input type="text" id="txtPowerRegulation" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Frequency</label>
        <div class="col-lg-9">
            <input type="text" id="txtFrequency" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Small generator</label>
        <div class="col-lg-9">
            <input type="text" id="txtSmallGenerator" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Temperature variant</label>
        <div class="col-lg-9">
            <input type="text" id="txtTemperatureVariant" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">MK version</label>
        <div class="col-lg-9">
            <input type="text" id="txtMKVersion" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Onshore / Offshore</label>
        <div class="col-lg-9">
            <input type="text" id="txtOnshoreOffshore" disabled class="form-control" />
        </div>
    </div>

    <!-- ADD_PAGE --> 
    <div class="form-group">
        <label class="col-lg-3 control-label">Manufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="txtTurbineManufacturer" disabled class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Local turbine ID</label>
        <div class="col-lg-9">
            <input type="text" id="txtLocalTurbineID" disabled class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run status at arrival<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlRunStatus" class="form-control ddlvalidation" data-toggle="tooltip" data-placement="top" title="Enter Run Status at arrival" data-fieldType="select" data-dataTable="TurbineRunStatus" data-textField="text" data-valueField="TurbineRunStatusID">
                <option value="0"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Commissioning date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtCommisioningDate" placeholder="Commissioning date" data-toggle="tooltip" data-placement="top" title="Commissioning date should be prior than Installation date and Failure date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />
        </div>
        
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Installation date of failed component<span class="errorSpan manInstallationDate">*</span></label>
        <div class="col-lg-6">
            <input type="text" id="txtInstallationDate" placeholder="Installation date of failed component" data-toggle="tooltip" data-placement="top" title="Installation date should be later than Commissioning date" style="background-color:#fff" readonly="readonly" maxlength="10" class="form-control" />
        </div>
        <div class="col-lg-3">
            <select id="ddlInstallationDateType" class="form-control" data-toggle="tooltip" data-placement="top" title="Enter Installation date Type">
                 <option value="0"></option>
                 <option value="1">Not Known</option>
                 <option value="2">Original installation date</option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label" id="lblfailuredate">Failure date<span class="errorSpan">*</span> </label>
        <div class="col-lg-9">
            <input type="text" id="txtFailureDate" placeholder="Failure date"  data-toggle="tooltip" data-placement="top" title="Failure date should be later than Commissioning date and prior than Inspection date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection Date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtInspectionDate" placeholder="Inspection Date"  data-toggle="tooltip" data-placement="top" title="Inspection date should be later or the same as Failure date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Service report number<span class="errorSpan manServicePortNo">*</span></label>
        <div class="col-lg-7">
            <input type="text" id="txtServicePortNo" placeholder="Service report number" class="form-control" />
            <br>
            <label id="lblServicReportError" style="color: red; display: none"></label>
        </div>
        <div class="col-lg-2">
            <select id="ddlServiceReportNumberType" class="form-control" data-toggle="tooltip" data-placement="top" title="Enter Service Report Number Type" data-fieldType="select" data-dataTable="ServiceReportNumberType" data-textField="text" data-valueField="ServiceReportNumberTypeID" data-defaultvalue="4" data-insertlable="false" data-sort="true">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Notification number</label>
        <div class="col-lg-9">
            <input type="number" id="txtNotificationNumber" placeholder="Notification number" data-toggle="tooltip" data-placement="top" title="Enter Notification number value in numeric" class="form-control numbersOnly" />
            <br>
            <label id="lblNotificationNumberError" style="color: red; display: none"></label>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Service Engineer/Technician<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtServiceEngineer" placeholder="Service engineer" data-toggle="tooltip" data-placement="top" title="Enter Service engineer" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run (hrs)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtRunHr" placeholder="Run (hrs)" data-toggle="tooltip" data-placement="top" title="Enter turbine run hours 'Turbine OK [h]'" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator 1 (hrs)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGenerator1Hr" placeholder="Generator 1 (hrs)" data-toggle="tooltip"
                data-placement="top" title="Enter Generator 1 value in numeric" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator 2 (hrs)</label>
        <div class="col-lg-9">
            <input type="number" id="txtGenerator2Hr" data-toggle="tooltip"
                data-placement="top" title="Enter Generator 2 value in numeric" placeholder="Generator 2 (hrs)" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Total production (kWh)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtTotalProduction" placeholder="Total production (kWh)" data-toggle="tooltip"
                data-placement="top" title="Enter Total Production value in numeric" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Run status after inspection<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlRunStatusAfterInspection" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="TurbineRunStatus" data-textField="text" data-valueField="TurbineRunStatusID">
            </select>
        </div>
    </div>
</fieldset>

<fieldset>
    <legend>Description</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Vestas Item Number<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input id="txtVestasItemNo" maxlength="50" placeholder="Vestas Item Number" data-toggle="tooltip"
                data-placement="top" title="Enter Vestas Item" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Quantity of failed components/problems<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtQuantityOfFailedComponent" placeholder="Quantity of failed components/problems" data-toggle="tooltip"
                data-placement="top" title="Enter Quantity of failed value in numeric" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Description<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <textarea id="txtDescription" placeholder="Description" class="form-control"  data-toggle="tooltip"
                data-placement="top" title="Enter Description value"></textarea>
        </div>
    </div>

    <div class="form-group" data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6">
        <label class="col-lg-3 control-label">Up-Tower Solution Available</label>
        <div class="col-lg-9">
            <select id="ddlUpTowerSolution" class="form-control" data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6" data-fieldType="select" data-dataTable="ComponentUpTowerSolution" data-textField="text" data-valueField="ComponentUpTowerSolutionID">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Description of any consequential problems/damage</label>
        <div class="col-lg-9">
            <textarea id="txtDescriptionConProb" class="form-control" placeholder="Description of any consequential problems/damage"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Additional Information</label>
        <div class="col-lg-9">
            <textarea id="txtAdditionalInfo" class="form-control" placeholder="Additional Information"></textarea>
        </div>
    </div>
    <!-- change the placeholder text for Sprint 4 bug id 83748-->
    <!-- ADD_PAGE --> 
    <div class="form-group">
        <label class="col-lg-3 control-label">Tech. Support recommendation</label>
        <div class="col-lg-9">
            <textarea id="txtSBURecommendation" class="form-control" placeholder="Tech. Support recommendation"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Alarm Log Number</label>
        <div class="col-lg-9">
            <input type="number" id="txtAlarmLogNumber" class="form-control" placeholder="Alarm Log Number" class="form-control numbersOnly" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Internal Comments</label>
        <div class="col-lg-9">
            <textarea id="txtInternalComments" class="form-control" placeholder="Internal Comments - this information is NOT exposed to customers/suppliers"></textarea>
        </div>
    </div>
</fieldset>
