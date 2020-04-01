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
                data-placement="top" title="Enter Numeric Cim Case Number" class="form-control" />
            <input type="hidden" id="_hCIRID" value="0" />
            <br>
                <label id="lblCIMCaseError" style="color: red; display: none"></label>
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
        <label class="col-lg-3 control-label">Turbine type</label>
        <div class="col-lg-9">
            <input type="text" id="txtTurbineType" disabled class="form-control" />
        </div>
    </div>
</fieldset>
